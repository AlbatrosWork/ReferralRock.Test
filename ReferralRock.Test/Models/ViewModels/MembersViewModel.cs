using ReferralRock.Test.Models.Domain.Members;
using ReferralRock.Test.Models.Filters;

namespace ReferralRock.Test.Models.ViewModels;

public class MembersViewModel
{
    public IEnumerable<Member> Members { get; set; }
    public MembersFilter Filter { get; set; }
    public IEnumerable<string> Programs { get; set; }
    public IEnumerable<string> SortOptions { get; set; }
}