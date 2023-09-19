using ReferralRock.Test.Models.Domain.Referrals;
using ReferralRock.Test.Models.Filters;

namespace ReferralRock.Test.Models.ViewModels;

public class ReferralsViewModel
{
    public IEnumerable<Referral> Referrals { get; set; }
    public ReferralsFilter Filter { get; set; }
    public IEnumerable<string> Statuses { get; set; }
    public ActionMessage ActionMessage{ get; set; }
}