using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Referrals;

namespace ReferralRock.Test.Models.ViewModels;

public class ReferralSubmissionViewModel
{
    public Referral ReferralDetails { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}