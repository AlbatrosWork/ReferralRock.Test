using System.Text.Json.Serialization;

namespace ReferralRock.Test.Models.Request;

public class RemoveReferralInfo
{
    [JsonPropertyName("query")]
    public ReferralQuery Query { get; set; }

    public RemoveReferralInfo(ReferralQuery query)
    {
        Query = query;
    }
}