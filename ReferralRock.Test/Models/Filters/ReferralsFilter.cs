namespace ReferralRock.Test.Models.Filters;

public class ReferralsFilter
{
    public Guid MemberId { get; set; }
    public string QuerySearch { get; set; } = string.Empty;
    public string SelectedStatus { get; set; } = string.Empty;

    public ReferralsFilter(Guid memberId)
    {
        MemberId = memberId;
    }

    public ReferralsFilter()
    {
        
    }
}