using System.Text.Json.Serialization;

namespace DataBridge.Models.Liveperson;

/// <summary>
/// Represents the root response structure for the Liveperson API.
/// </summary>
public class LivepersonResponse
{
    /// <summary>
    /// List of metrics data grouped by intervals.
    /// </summary>
    [JsonPropertyName("metricsByIntervals")]
    public List<MetricsByInterval>? MetricsByIntervals { get; set; }

    /// <summary>
    /// Skills metrics data for agents.
    /// </summary>
    [JsonPropertyName("skillsMetricsPerAgent")]
    public SkillsMetricsPerAgent? SkillsMetricsPerAgent { get; set; }
}

/// <summary>
/// Represents metrics data for a specific time interval.
/// </summary>
public class MetricsByInterval
{
    /// <summary>
    /// Timestamp of the interval in milliseconds since epoch.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>
    /// Metrics data for this interval.
    /// </summary>
    [JsonPropertyName("metricsData")]
    public MetricsData? MetricsData { get; set; }
}

/// <summary>
/// Represents metrics data structure.
/// </summary>
public class MetricsData
{
    /// <summary>
    /// Skills metrics data for agents.
    /// </summary>
    [JsonPropertyName("skillsMetricsPerAgent")]
    public SkillsMetricsPerAgent? SkillsMetricsPerAgent { get; set; }
}

/// <summary>
/// Represents skills metrics data for agents.
/// </summary>
public class SkillsMetricsPerAgent
{
    /// <summary>
    /// Metrics data per skill. The key is the skill ID.
    /// </summary>
    [JsonPropertyName("metricsPerSkill")]
    public Dictionary<string, SkillMetrics>? MetricsPerSkill { get; set; }

    /// <summary>
    /// Total metrics across all skills.
    /// </summary>
    [JsonPropertyName("metricsTotals")]
    public AgentMetrics? MetricsTotals { get; set; }
}

/// <summary>
/// Represents metrics data for a specific skill.
/// </summary>
public class SkillMetrics
{
    /// <summary>
    /// Metrics data per agent for this skill. The key is the agent ID.
    /// </summary>
    [JsonPropertyName("metricsPerAgent")]
    public Dictionary<string, AgentMetrics>? MetricsPerAgent { get; set; }

    /// <summary>
    /// Total metrics for this skill across all agents.
    /// </summary>
    [JsonPropertyName("metricsTotals")]
    public AgentMetrics? MetricsTotals { get; set; }
}

/// <summary>
/// Represents metrics data for a specific agent or totals.
/// </summary>
public class AgentMetrics
{
    /// <summary>
    /// Number of conversations resolved by CCP.
    /// </summary>
    [JsonPropertyName("resolvedConversations_byCCP")]
    public int? ResolvedConversationsByCCP { get; set; }

    /// <summary>
    /// Number of conversations resolved by consumer.
    /// </summary>
    [JsonPropertyName("resolvedConversations_byConsumer")]
    public int? ResolvedConversationsByConsumer { get; set; }

    /// <summary>
    /// Number of conversations resolved by system.
    /// </summary>
    [JsonPropertyName("resolvedConversations_bySystem")]
    public int? ResolvedConversationsBySystem { get; set; }

    /// <summary>
    /// Total number of resolved conversations.
    /// </summary>
    [JsonPropertyName("totalResolvedConversations")]
    public int? TotalResolvedConversations { get; set; }

    /// <summary>
    /// Total handling time for conversations resolved by CCP.
    /// </summary>
    [JsonPropertyName("totalHandlingTime_resolvedConversations_byCCP")]
    public long? TotalHandlingTimeResolvedConversationsByCCP { get; set; }

    /// <summary>
    /// Total handling time for conversations resolved by consumer.
    /// </summary>
    [JsonPropertyName("totalHandlingTime_resolvedConversations_byConsumer")]
    public long? TotalHandlingTimeResolvedConversationsByConsumer { get; set; }

    /// <summary>
    /// Total handling time for conversations resolved by system.
    /// </summary>
    [JsonPropertyName("totalHandlingTime_resolvedConversations_bySystem")]
    public long? TotalHandlingTimeResolvedConversationsBySystem { get; set; }

    /// <summary>
    /// Total handling time for all resolved conversations.
    /// </summary>
    [JsonPropertyName("totalHandlingTime_resolvedConversations")]
    public long? TotalHandlingTimeResolvedConversations { get; set; }

    /// <summary>
    /// Average time for conversations resolved by CCP.
    /// </summary>
    [JsonPropertyName("avgTime_resolvedConversations_byCCP")]
    public double? AvgTimeResolvedConversationsByCCP { get; set; }

    /// <summary>
    /// Average time for conversations resolved by consumer.
    /// </summary>
    [JsonPropertyName("avgTime_resolvedConversations_byConsumer")]
    public double? AvgTimeResolvedConversationsByConsumer { get; set; }

    /// <summary>
    /// Average time for conversations resolved by system.
    /// </summary>
    [JsonPropertyName("avgTime_resolvedConversations_bySystem")]
    public double? AvgTimeResolvedConversationsBySystem { get; set; }

    /// <summary>
    /// Average time for all resolved conversations.
    /// </summary>
    [JsonPropertyName("avgTime_resolvedConversations")]
    public double? AvgTimeResolvedConversations { get; set; }
}

/// <summary>
/// Represents total metrics across all skills or agents.
/// </summary>
public class MetricsTotals : AgentMetrics
{
    // class inherits all properties from AgentMetrics because its the same DS
}