using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Members;

namespace ReferralRock.Test.Models.Response;

public class MemberSet : BaseCollectionResponse
{
    /// <summary>
    /// List of members
    /// </summary>
    public IEnumerable<Member> Members { get; set; } 
}