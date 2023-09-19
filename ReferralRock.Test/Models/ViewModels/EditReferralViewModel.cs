using ReferralRock.Test.Models.Domain.Referrals;

namespace ReferralRock.Test.Models.ViewModels;

public class EditReferralViewModel
{
    public Referral Referral { get; set; }
    public string ErrorMessage { get; set; }
}