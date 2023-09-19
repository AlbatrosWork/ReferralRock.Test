using System.ComponentModel;
using ReferralRock.Test.Models.Domain.Base;

namespace ReferralRock.Test.Models.Domain.Referrals;

public class Referral : BaseModel
{
    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string Source { get; set; }
    public Guid ReferringMemberId { get; set; }
    public string ReferringMemberName { get; set; }
    public string MemberEmail { get; set; }
    public string MemberReferralCode { get; set; }
    public string MemberExternalIdentifier { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public DateTime? QualifiedDate { get; set; }
    
    [DisplayName("Amount")]
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public string CompanyName { get; set; }
    public string Note { get; set; }
    
    [DisplayName("Public Note")]
    public string PublicNote { get; set; }
}