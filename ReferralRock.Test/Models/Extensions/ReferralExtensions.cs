using ReferralRock.Test.Models.Domain.Referrals;
using ReferralRock.Test.Models.ViewModels;

namespace ReferralRock.Test.Models.Extensions;

public static class ReferralExtensions
{
    public static EditReferralViewModel ToEditReferralViewModel(this Referral referral, string errorMessage = "")
    {
        return new EditReferralViewModel()
        {
            Referral = new Referral()
            {
                Id = referral.Id,
                ProgramId = referral.ProgramId,
                ReferringMemberId = referral.ReferringMemberId,
                FirstName = referral.FirstName,
                LastName = referral.LastName,
                Email = referral.Email,
                ExternalIdentifier = referral.ExternalIdentifier,
                CompanyName = referral.CompanyName,
                Amount = referral.Amount,
                PublicNote = referral.PublicNote
            },
            ErrorMessage = errorMessage
        };
    }
}