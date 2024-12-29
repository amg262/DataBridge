using AutoMapper;
using DataBridge.Data;
using DataBridge.Models.Liveperson;
using DataBridge.Models.Liveperson.Dto;
using DataBridge.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using RestSharp;

namespace DataBridge.Services;

/// <summary>
/// Service for interacting with Liveperson API and managing Liveperson data.
/// </summary>
public class LivePersonService : IHealthCheck
{
    private readonly AppDbContext _db;
    private readonly RestClient _restClient;
    private readonly ILogger<LivePersonService> _logger;
    private readonly IMapper _mapper;
    private readonly LivePersonOptions _options;

    /// <summary>
    /// Initializes a new instance of the LivePersonService class.
    /// </summary>
    /// <param name="db">The database context.</param>
    /// <param name="logger">The logger for this service.</param>
    /// <param name="mapper">The AutoMapper instance for object mapping.</param>
    /// <param name="livepersonOptions">The Liveperson configuration options.</param>
    /// <param name="restClient">The RestClient for making API requests.</param>
    public LivePersonService(AppDbContext db, ILogger<LivePersonService> logger, IMapper mapper,
        IOptions<LivePersonOptions> livepersonOptions, RestClient restClient)
    {
        _db = db;
        _logger = logger;
        _mapper = mapper;
        _options = livepersonOptions.Value;
        _restClient = restClient;
    }

    /// <summary>
    /// Retrieves the base URI for a specified Liveperson service.
    /// </summary>
    /// <param name="service">The name of the service to get the base URI for. Defaults to "leDataReporting".</param>
    /// <returns>The base URI for the specified service.</returns>
    /// <exception cref="Exception">Thrown when unable to retrieve the base URI or find the specified service endpoint.</exception>
    public async Task<string?> GetBaseUriAsync(string? service = "leDataReporting")
    {
        var baseUriUrl = $"https://api.liveperson.net/api/account/{_options.AccountId}/service/baseURI.json?version=1.0";
        var baseUriRequest = new RestRequest(baseUriUrl, Method.Get);
        var baseUriResponse = await _restClient.ExecuteAsync<BaseUriResponseDto>(baseUriRequest);
        var baseUris = _mapper.Map<BaseUriResponse>(baseUriResponse.Data);

        if (baseUris == null) throw new Exception("Failed to retrieve base URI from Liveperson API.");

        var endpoint = baseUris.BaseURIs.FirstOrDefault(x => x.Service == service);

        if (endpoint == null) throw new Exception($"Failed to find {service} endpoint.");

        return endpoint.BaseURI;
    }

    /// <summary>
    /// Retrieves a list of users from the Liveperson API.
    /// </summary>
    /// <returns>A list of User objects.</returns>
    /// <exception cref="Exception">Thrown when unable to retrieve users from the Liveperson API.</exception>
    public async Task<List<User>> GetUsersAsync()
    {
        var baseUri = await GetBaseUriAsync("accountConfigReadWrite");
        var url = $"https://{baseUri}/api/account/{_options.AccountId}/configuration/le-users/users";
        var request = new RestRequest(url, Method.Get);
        var response = await _restClient.ExecuteAsync<List<User>>(request);

        return response.Data;
    }

    /// <summary>
    /// Retrieves details for a specific user from the Liveperson API.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve details for.</param>
    /// <returns>A UserDetails object containing the user's information.</returns>
    /// <exception cref="Exception">Thrown when unable to retrieve user details from the Liveperson API.</exception>
    public async Task<UserDetails> GetUserByIdAsync(string userId)
    {
        var baseUri = await GetBaseUriAsync("accountConfigReadWrite");
        var url = $"https://{baseUri}/api/account/{_options.AccountId}/configuration/le-users/users/{userId}";
        var request = new RestRequest(url, Method.Get);
        var response = await _restClient.ExecuteAsync<UserDetails>(request);

        return response.Data;
    }

    /// <summary>
    /// Retrieves saved conversations from the database.
    /// </summary>
    /// <param name="skip">The number of records to skip.</param>
    /// <param name="take">The number of records to take.</param>
    /// <returns>A list of ConversationInfo objects.</returns>
    public async Task<List<ConversationInfo>> GetConversationsAsync(int skip = 0, int take = 100)
    {
        return await _db.ConversationInfo
            .AsNoTracking()
            .OrderByDescending(c => c.StartTime)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a specific conversation and its related data from the database.
    /// </summary>
    /// <param name="conversationId">The ID of the conversation to retrieve.</param>
    /// <returns>A ConversationDetails object containing the conversation and its related data.</returns>
    public async Task<ConversationDetails?> GetConversationDetailsAsync(string conversationId)
    {
        var conversation = await _db.ConversationInfo
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ConversationId == Guid.Parse(conversationId));

        if (conversation == null) return null;

        var details = new ConversationDetails
        {
            Conversation = conversation,
            Messages = await _db.MessageRecords
                .AsNoTracking()
                .Where(m => m.ConversationId == Guid.Parse(conversationId))
                .ToListAsync(),
            Transfers = await _db.Transfers
                .AsNoTracking()
                .Where(t => t.ConversationId == Guid.Parse(conversationId))
                .ToListAsync(),
            Interactions = await _db.Interactions
                .AsNoTracking()
                .Where(i => i.ConversationId == Guid.Parse(conversationId))
                .ToListAsync(),
            ConsumerParticipants = await _db.ConsumerParticipants
                .AsNoTracking()
                .Where(c => c.ConversationId == Guid.Parse(conversationId))
                .ToListAsync(),
            SurveyData = await _db.ConversationSurveyData
                .AsNoTracking()
                .Where(s => s.ConversationId == Guid.Parse(conversationId))
                .ToListAsync(),
            Summary = await _db.SummaryData
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ConversationId == Guid.Parse(conversationId))
        };

        return details;
    }


    /// <summary>
    /// Retrieves and processes conversation data from the Liveperson API.
    /// </summary>
    /// <param name="batchSize">The number of conversations to retrieve. Defaults to 200.</param>
    public async Task PostConversationsAsync(int? batchSize = 200)
    {
        var baseUri = await GetBaseUriAsync("msgHist");
        var offset = 0;

        while (offset < batchSize)
        {
            var url =
                $"https://{baseUri}/messaging_history/api/account/{_options.AccountId}/conversations/search?offset={offset}&limit=100&source=WEB_SITE&v=1";

            var request = new RestRequest(url, Method.Post);
            var body = new
            {
                start = new
                {
                    to = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    from = DateTimeOffset.UtcNow.AddDays(-14).ToUnixTimeMilliseconds(),
                }
            };

            request.AddJsonBody(body);

            var response = await _restClient.ExecuteAsync<ConversationHistoryResponseDto>(request);

            var conversationHistoryRecords = response.Data?.ConversationHistoryRecords;

            if (conversationHistoryRecords == null || conversationHistoryRecords.Count == 0) break;

            await ProcessConversationsDataAsync(conversationHistoryRecords);
            _db.ChangeTracker.Clear();
            offset += 100;
        }
    }

    /// <summary>
    /// Processes conversation data and updates the database.
    /// </summary>
    /// <param name="conversationHistoryRecords">A list of ConversationHistoryRecord objects to process.</param>
    private async Task ProcessConversationsDataAsync(List<ConversationHistoryRecord> conversationHistoryRecords)
    {
        var incomingCampaigns = conversationHistoryRecords.Select(ch => ch.Campaign)
            .Distinct()
            .ToHashSet();

        var incomingConversations = conversationHistoryRecords
            .Select(ch => new
            {
                Conversation = ch.Info,
                CampaignId = ch.Campaign?.CampaignId,
            })
            .Distinct()
            .ToHashSet();

        var incomingSummaries = conversationHistoryRecords
            .Select(ch => new
            {
                Summary = ch.Summary,
                ConversationId = ch.Info.ConversationId,
            })
            .Distinct()
            .ToHashSet();

        var incomingConsumers = conversationHistoryRecords
            .SelectMany(ch => ch.ConsumerParticipants
                .Select(c => new
                {
                    Participant = c,
                    ConversationId = ch.Info.ConversationId
                }))
            .Distinct()
            .ToHashSet();

        var incomingInteractions = conversationHistoryRecords
            .SelectMany(ch => ch.Interactions
                .Select(c => new
                {
                    Interaction = c,
                    ConversationId = ch.Info.ConversationId
                }))
            .Distinct()
            .ToHashSet();

        var incomingMessages = conversationHistoryRecords
            .SelectMany(ch => ch.MessageRecords
                .Select(mr => new
                    {
                        MessageRecord = mr,
                        MessageId = mr.MessageId,
                        ConversationId = ch.Info.ConversationId,
                        MessageText = mr.MessageData?.Msg?.Text,
                        Score = ch.MessageScores.FirstOrDefault(s => s.MessageId == mr.MessageId),
                        Status = ch.MessageStatuses.FirstOrDefault(s => s.MessageId == mr.MessageId)
                    }
                ))
            .Distinct()
            .ToHashSet();

        var incomingTransfers = conversationHistoryRecords
            .SelectMany(ch => ch.Transfers
                .Select(t => new
                {
                    Transfer = t,
                    ConversationId = ch.Info.ConversationId
                }))
            .Distinct()
            .ToHashSet();

        var incomingSurveys = conversationHistoryRecords
            .SelectMany(ch => ch.ConversationSurveys
                .SelectMany(cs => cs.SurveyData
                    .Select(sd => new
                    {
                        SurveyData = sd,
                        ConversationId = ch.Info.ConversationId,
                    })))
            .Distinct()
            .ToHashSet();

        var existingCampaigns = await _db.Campaigns.AsNoTracking().ToListAsync();
        var existingConversations = await _db.ConversationInfo.AsNoTracking().ToDictionaryAsync(c => c.ConversationId);
        var existingTransfers = await _db.Transfers.AsNoTracking().ToListAsync();
        var existingInteractions = await _db.Interactions.AsNoTracking().ToListAsync();
        var existingConsumers = await _db.ConsumerParticipants.AsNoTracking().ToListAsync();
        var existingMessages = await _db.MessageRecords.AsNoTracking().ToListAsync();
        var existingSurveys = await _db.ConversationSurveyData.AsNoTracking().ToListAsync();
        var existingSummaries = await _db.SummaryData.AsNoTracking().ToListAsync();

        foreach (var incomingCampaign in incomingCampaigns)
        {
            var campaign = _mapper.Map<Campaign>(incomingCampaign);
            var existingCampaign = existingCampaigns.FirstOrDefault(c => c.Equals(campaign));
            if (existingCampaign == null)
            {
                _db.Campaigns.Add(campaign);
            }
            else
            {
                _mapper.Map(campaign, existingCampaign);
                _db.Campaigns.Update(existingCampaign);
            }
        }

        foreach (var incomingConversation in incomingConversations)
        {
            var conversation = _mapper.Map<ConversationInfo>(incomingConversation.Conversation);
            var conversationId = conversation.ConversationId;
            conversation.CampaignId = incomingConversation.CampaignId;

            if (!existingConversations.TryGetValue(conversationId, out var existingConvo))
            {
                _db.ConversationInfo.Add(conversation);
            }
            else
            {
                _mapper.Map(conversation, existingConvo);
                _db.ConversationInfo.Update(existingConvo);
            }
        }

        foreach (var incomingSummary in incomingSummaries)
        {
            if (incomingSummary.Summary?.ProcessedSummary == null) continue;

            var summary = _mapper.Map<SummaryData>(incomingSummary.Summary.ProcessedSummary);
            summary.ConversationId = incomingSummary.ConversationId;

            var existingSummary = existingSummaries.FirstOrDefault(s => s.Equals(summary));
            if (existingSummary == null)
            {
                _db.SummaryData.Add(summary);
            }
            else
            {
                _mapper.Map(summary, existingSummary);
                _db.SummaryData.Update(existingSummary);
            }
        }

        foreach (var messageRecord in incomingMessages)
        {
            var message = _mapper.Map<MessageRecord>(messageRecord.MessageRecord);
            message.ConversationId = messageRecord.ConversationId;
            message.MessageText = messageRecord.MessageRecord.MessageData?.Msg?.Text;
            message.MessageId = messageRecord.MessageId;
            message.Mcs = messageRecord.Score?.Mcs;
            message.MessageRawScore = messageRecord.Score?.MessageRawScore;
            message.MessageStatus = messageRecord.Status?.MessageDeliveryStatus;

            var existingMessage = existingMessages.FirstOrDefault(m => m.Equals(message));
            if (existingMessage == null)
            {
                _db.MessageRecords.Add(message);
            }
            else
            {
                _mapper.Map(message, existingMessage);
                _db.MessageRecords.Update(existingMessage);
            }
        }

        foreach (var interactionDto in incomingInteractions)
        {
            var interaction = _mapper.Map<Interaction>(interactionDto.Interaction);
            interaction.ConversationId = interactionDto.ConversationId;

            var existingInteraction = existingInteractions.FirstOrDefault(i => i.Equals(interaction));
            if (existingInteraction == null)
            {
                _db.Interactions.Add(interaction);
            }
            else
            {
                _mapper.Map(interaction, existingInteraction);
                _db.Interactions.Update(existingInteraction);
            }
        }

        foreach (var incomingTransfer in incomingTransfers)
        {
            var transfer = _mapper.Map<Transfer>(incomingTransfer.Transfer);
            transfer.ConversationId = incomingTransfer.ConversationId;

            var existingTransfer = existingTransfers.FirstOrDefault(t => t.Equals(transfer));
            if (existingTransfer == null)
            {
                _db.Transfers.Add(transfer);
            }
            else
            {
                _mapper.Map(transfer, existingTransfer);
                _db.Transfers.Update(existingTransfer);
            }
        }

        foreach (var incomingConsumer in incomingConsumers)
        {
            var consumer = _mapper.Map<ConsumerParticipant>(incomingConsumer.Participant);
            consumer.ConversationId = incomingConsumer.ConversationId;

            var existingConsumer = existingConsumers.FirstOrDefault(c => c.Equals(consumer));
            if (existingConsumer == null)
            {
                _db.ConsumerParticipants.Add(consumer);
            }
            else
            {
                _mapper.Map(consumer, existingConsumer);
                _db.ConsumerParticipants.Update(existingConsumer);
            }
        }

        foreach (var incomingSurvey in incomingSurveys)
        {
            var survey = _mapper.Map<ConversationSurveyData>(incomingSurvey.SurveyData);
            survey.ConversationId = incomingSurvey.ConversationId;
            survey.AnswerScore = incomingSurvey.SurveyData.AnswerScore;

            var existingSurvey = existingSurveys.FirstOrDefault(s => s.Equals(survey));
            if (existingSurvey == null)
            {
                _db.ConversationSurveyData.Add(survey);
            }
            else
            {
                _mapper.Map(survey, existingSurvey);
                _db.ConversationSurveyData.Update(existingSurvey);
            }
        }

        await _db.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves reporting data from the Liveperson API.
    /// </summary>
    /// <returns>A string containing the raw response content from the API.</returns>
    public async Task<string> GetReportingAsync()
    {
        var baseUri = await GetBaseUriAsync("leDataReporting");

        var body = new
        {
            start = new
            {
                to = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                from = DateTimeOffset.UtcNow.AddDays(-10).ToUnixTimeSeconds(),
                interval = 60,
                source = "LP_AgentUI",
                v = "1"
            }
        };

        var url = $"https://{baseUri}/operations/api/account/{_options.AccountId}/nht?v=1&source={body.start.source}";

        var request = new RestRequest(url, Method.Post);
        request.AddJsonBody(body);

        var response = await _restClient.ExecuteAsync(request);

        return response.Content;
    }

    /// <summary>
    /// Retrieves agent segments data from the Liveperson API.
    /// </summary>
    /// <returns>A string containing the raw response content from the API.</returns>
    public async Task<string> GetAgentSegmentsAsync()
    {
        var baseUri = await GetBaseUriAsync("agentActivityDomain");
        var url = $"https://{baseUri}/api/account/{_options.AccountId}/agent-segments?source=LP_AgentUI&v=1";

        var request = new RestRequest(url, Method.Get);

        var response = await _restClient.ExecuteAsync(request);

        return response.Content;
    }

    /// <summary>
    /// Creates a manager workspace and retrieves related metrics from the Liveperson API.
    /// </summary>
    /// <returns>A string containing the raw response content from the API.</returns>
    public async Task<string> CreateManagerAsync()
    {
        var baseUri = await GetBaseUriAsync("agentManagerWorkspace");
        var url =
            $"https://{baseUri}/manager_workspace/api/account/{_options.AccountId}/metrics?offset=0&limit=50&sort=closedConversations:desc";

        var body = new
        {
            filters = new
            {
                time = new
                {
                    from = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeMilliseconds(),
                    to = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                },
                userTypes = new[] { "HUMAN" }
            },
            groupBy = "agentGroupId",
            responseSections = new[] { "groupBy" },
            metricsToRetrieveCurrentValue = new[]
            {
                "assigned_conversations",
                "human_agent_load"
            },
            metricsToRetrieveByTime = new[]
            {
                "avg_wait_time",
                "avg_time_to_response",
                "avg_wait_time_first_response",
                "avg_time_to_first_response_first_assignment",
                "closed_conversations"
            }
        };

        var request = new RestRequest(url, Method.Post);
        request.AddJsonBody(body);

        var response = await _restClient.ExecuteAsync(request);

        return response.Content;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Check if we can connect to the Liveperson API
            var baseUri = await GetBaseUriAsync();
            if (string.IsNullOrEmpty(baseUri)) return HealthCheckResult.Unhealthy("Unable to retrieve Liveperson base URI.");

            // Check users both api connectivity and db access
            var users = await GetUsersAsync();

            return users.Count == 0
                ? HealthCheckResult.Degraded("No users retrieved from Liveperson API.")
                : HealthCheckResult.Healthy("Liveperson service is healthy.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy($"An error occurred while checking Liveperson service health: {ex.Message}");
        }
    }
}

public class ConversationDetails
{
    public ConversationInfo Conversation { get; set; }
    public List<MessageRecord> Messages { get; set; }
    public List<Transfer> Transfers { get; set; }
    public List<Interaction> Interactions { get; set; }
    public List<ConsumerParticipant> ConsumerParticipants { get; set; }
    public List<ConversationSurveyData> SurveyData { get; set; }
    public SummaryData? Summary { get; set; }
}