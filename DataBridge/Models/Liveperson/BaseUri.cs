using System.Text.Json.Serialization;

namespace DataBridge.Models.Liveperson;

public class BaseUriResponse
{
    [JsonPropertyName("baseURIs")]
    public List<BaseUri> BaseURIs { get; set; }
}

public class BaseUri
{
    [JsonPropertyName("service")]
    public string? Service { get; set; }

    [JsonPropertyName("account")]
    public string? Account { get; set; }

    [JsonPropertyName("baseURI")]
    public string? BaseURI { get; set; }
}