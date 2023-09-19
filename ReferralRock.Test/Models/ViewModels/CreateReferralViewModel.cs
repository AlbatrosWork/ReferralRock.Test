namespace ReferralRock.Test.Models.ViewModels;

public class CreateReferralViewModel
{
    public IEnumerable<string> SelectablePrograms { get; set; }
    public string SelectedProgram { get; set; } = string.Empty;

    public string QuerySearch { get; set; } = string.Empty;
}