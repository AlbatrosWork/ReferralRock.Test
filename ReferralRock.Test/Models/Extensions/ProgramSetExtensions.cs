using ReferralRock.Test.Models.Response;
using ReferralRock.Test.Models.ViewModels;

namespace ReferralRock.Test.Models.Extensions;

public static class ProgramSetExtensions
{
    public static CreateReferralViewModel ToCreateReferralViewModel(this ProgramSet programSet)
    {
        return new CreateReferralViewModel()
        {
            SelectablePrograms = programSet.Programs
                .Where(p => p.IsActive)
                .Select(p => p.Name)
        };
    }
}