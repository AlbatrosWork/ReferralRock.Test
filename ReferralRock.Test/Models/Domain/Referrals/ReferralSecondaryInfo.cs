using System.Text.Json.Serialization;

namespace ReferralRock.Test.Models.Domain.Referrals;

public class ReferralSecondaryInfo
{
    [JsonPropertyName("externalIdentifier")]
    public string ExternalIdentifier { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }
}