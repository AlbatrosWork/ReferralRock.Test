using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Referrals;
using ReferralRock.Test.Models.Filters;
using ReferralRock.Test.Models.Request;
using ReferralRock.Test.Models.Response;

namespace ReferralRock.Test.HttpClients.Contracts;

public interface IReferralRockHttpClient
{
    /// <summary>
    /// endpoint to get members with optional filtering
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<MemberSet> GetMembers(MembersFilter filter = null);

    /// <summary>
    /// endpoint to get a single referral by a uniquely defined ID
    /// </summary>
    /// <param name="referralId"></param>
    /// <returns></returns>
    Task<Referral> GetSingleReferral(Guid referralId);
    /// <summary>
    /// endpoint to get referrals by memberId
    /// </summary>
    /// <param name="memberId"></param>
    /// <returns></returns>
    Task<ReferralSet> GetReferrals(Guid memberId);
    
    /// <summary>
    /// endpoint to get referrals with optional filtering
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<ReferralSet> GetReferrals(ReferralsFilter filter = null);
    
    /// <summary>
    /// endpoint to return all programs of customer the account
    /// </summary>
    /// <returns></returns>
    Task<ProgramSet> GetPrograms();
    
    /// <summary>
    /// endpoint that creates a new referral
    /// </summary>
    /// <param name="referral"></param>
    /// <returns></returns>
    Task<ReferralConfirmation> PostReferral(Referral referral);

    /// <summary>
    /// referral containing fields that need to be updated
    /// </summary>
    /// <param name="referralUpdate"></param>
    /// <returns></returns>
    Task<IEnumerable<ReferralUpdate>> UpdateReferral(IEnumerable<ReferralUpdate> referralUpdate);
    
    /// <summary>
    ///  endpoint to delete a referral
    /// </summary>
    /// <param name="referralsToBeDeleted"></param>
    /// <returns></returns>
    Task<ActionMessage> DeleteReferral(IEnumerable<RemoveReferralInfo> referralsToBeDeleted);
}