using System.Text.Json.Serialization;
using ReferralRock.Test.Models.Domain.Referrals;

namespace ReferralRock.Test.Models.Request;
public class ReferralQuery
{
    [JsonPropertyName("primaryInfo")]
    public ReferralPrimaryInfo PrimaryInfo { get; set; }
    public ReferralQuery(Guid referralId)
    {
        PrimaryInfo = new ReferralPrimaryInfo()
        {
            ReferralId = referralId.ToString()
        };
    }

    public ReferralQuery()
    {
        
    }
}