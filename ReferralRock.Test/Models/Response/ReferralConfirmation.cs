using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Referrals;

namespace ReferralRock.Test.Models.Response;

public class ReferralConfirmation
{
    public string Message { get; set; }
    public Referral Referral { get; set; }
}