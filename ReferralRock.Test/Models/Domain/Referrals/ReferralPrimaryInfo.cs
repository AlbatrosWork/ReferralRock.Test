using System.Text.Json.Serialization;

namespace ReferralRock.Test.Models.Domain.Referrals;

public class ReferralPrimaryInfo
{
    [JsonPropertyName("referralId")]
    public string ReferralId { get; set; }
}