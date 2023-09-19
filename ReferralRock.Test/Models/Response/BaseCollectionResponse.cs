using System.Text.Json.Serialization;

namespace ReferralRock.Test.Models.Response;

public abstract class BaseCollectionResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    [JsonPropertyName("offset")]
    public int Offset { get; set; }
    
    [JsonPropertyName("total")]
    public int Total { get; set; }
}