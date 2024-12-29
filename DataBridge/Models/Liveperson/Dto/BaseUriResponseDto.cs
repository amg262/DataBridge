using System.Text.Json.Serialization;

namespace DataBridge.Models.Liveperson.Dto;

public record BaseUriResponseDto
{
    [JsonPropertyName("baseURIs")] public List<BaseUriDto> BaseURIs { get; set; }
}

public record BaseUriDto
{
    [JsonPropertyName("service")] public string? Service { get; set; }

    [JsonPropertyName("account")] public string? Account { get; set; }

    [JsonPropertyName("baseURI")] public string? BaseURI { get; set; }
}