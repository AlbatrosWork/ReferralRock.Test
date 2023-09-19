namespace ReferralRock.Test.Models.Domain.Programs;

public class Program
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string MemberOffer { get; set; }
    public string ReferralOffer { get; set; }
}