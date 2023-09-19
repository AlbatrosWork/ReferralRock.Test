using ReferralRock.Test.Models.Filters;
using ReferralRock.Test.Models.Response;
using ReferralRock.Test.Models.ViewModels;

namespace ReferralRock.Test.Models.Extensions;

public static class ReferralSetExtensions
{
    private static readonly IEnumerable<string> AllStatuses = new[] { "Pending", "Qualified", "Approved", "Denied" };

    public static ReferralsViewModel ToReferralsViewModel(this ReferralSet referralSet, ReferralsFilter filter, ActionMessage actionMessage = null)
    {
        return new ReferralsViewModel()
        {
            Referrals = referralSet.Referrals,
            Filter = new ReferralsFilter()
            {
                SelectedStatus = filter.SelectedStatus,
                QuerySearch = filter.QuerySearch,
                MemberId = filter.MemberId
            },
            Statuses = AllStatuses,
            ActionMessage = actionMessage
        };
    }
}