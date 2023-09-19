namespace ReferralRock.Test.Models.Filters;

public class MembersFilter
{
    public string QuerySearch { get; set; } = string.Empty;
    public string SelectedProgram { get; set; } = string.Empty;
    public string SortBy { get; set; } = string.Empty;
    public bool ShowDisabled { get; set; } = false;
}