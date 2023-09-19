using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Referrals;

namespace ReferralRock.Test.Models.Response;

public class ReferralSet : BaseCollectionResponse
{
    public IEnumerable<Referral> Referrals { get; set; }
}