using ReferralRock.Test.Models.Request;

namespace ReferralRock.Test.Models.Response;

public class RemoveReferralResult
{
    public ReferralQuery ReferralQuery { get; set; }
    public ResultInfo ResultInfo { get; set; }
}