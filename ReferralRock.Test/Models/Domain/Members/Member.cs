using ReferralRock.Test.Models.Domain.Base;

namespace ReferralRock.Test.Models.Domain.Members;

public class Member : BaseModel
{
    public string Phone{ get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }    
    public string City { get; set; }
    public string CountrySubDivision { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public bool DisabledFlag { get; set; }
    public MemberPayoutInfo PayoutInfo { get; set; }
    public string ReferralCode { get; set; }
    public string ReferralUrl { get; set; }
    public int EmailShares { get; set; }
    public int SocialShares { get; set; }
    public DateTime? LastShare { get; set; }
    public int Referrals { get; set; }
}