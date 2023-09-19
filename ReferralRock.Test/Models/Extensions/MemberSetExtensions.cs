using ReferralRock.Test.Models.Filters;
using ReferralRock.Test.Models.Response;
using ReferralRock.Test.Models.ViewModels;

namespace ReferralRock.Test.Models.Extensions;

public static class MemberSetExtensions
{
    public static MembersViewModel ToMembersViewModel(this MemberSet memberSet, MembersFilter filter = null)
    {
        var programs = memberSet.Members
            .Select(m => m.ProgramName)
            .Distinct();


        if (filter is null)
        {
            return new MembersViewModel()
            {
                Members = memberSet.Members,
                Filter = new MembersFilter(),
                Programs = programs
            };
        }
        return new MembersViewModel()
        {
            Members = memberSet.Members,
            Filter = new MembersFilter()
            {
                SelectedProgram = filter.SelectedProgram,
                QuerySearch = filter.QuerySearch,
                ShowDisabled = filter.ShowDisabled
            },
            Programs = programs
        };
    }
}