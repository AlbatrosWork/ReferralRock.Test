using ReferralRock.Test.Helpers;
using ReferralRock.Test.HttpClients.Contracts;
using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Members;
using ReferralRock.Test.Models.Domain.Referrals;
using ReferralRock.Test.Models.Filters;
using ReferralRock.Test.Models.Request;
using ReferralRock.Test.Models.Response;

namespace ReferralRock.Test.HttpClients.Implementations;

public class ReferralRockHttpClient : IReferralRockHttpClient
{
    private readonly HttpClient _httpClient;

    public ReferralRockHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc/>
    public async Task<MemberSet> GetMembers(MembersFilter filter = null)
    {
        string uriParameters = HttpHelpers.GetMembersQueryString(filter);
        
        var response = await _httpClient.GetAsync($"members?{uriParameters}");

        if (!response.IsSuccessStatusCode)
        {
            return EmptyMemberSet();
        }
        
        string content = await response.Content.ReadAsStringAsync();


        if (string.IsNullOrEmpty(content))
        {
            return EmptyMemberSet();
        }

        MemberSet memberSet = SerializationHelper.Deserialize<MemberSet>(content);

        return memberSet;
    }
    
    /// <inheritdoc/>
    public async Task<Referral> GetSingleReferral(Guid referralId)
    {
        var response = await _httpClient.GetAsync($"referral/single?referralId={referralId}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await response.Content.ReadAsStringAsync();

        Referral referral = SerializationHelper.Deserialize<Referral>(content);

        return referral;
    }
    
    /// <inheritdoc/>
    public async Task<ReferralSet> GetReferrals(Guid memberId)
    {
        var response = await _httpClient.GetAsync($"referrals?memberId={memberId}");
        
        if (!response.IsSuccessStatusCode)
        {
            return EmptyReferralSet();
        }
        
        string content = await response.Content.ReadAsStringAsync();


        if (string.IsNullOrEmpty(content))
        {
            return EmptyReferralSet();
        }

        return SerializationHelper.Deserialize<ReferralSet>(content);
    }

    /// <inheritdoc/>
    public async Task<ReferralSet> GetReferrals(ReferralsFilter filter = null)
    {
        string uriParameters = HttpHelpers.GetReferralsQueryString(filter);
        
        var response = await _httpClient.GetAsync($"referrals?{uriParameters}");

        if (!response.IsSuccessStatusCode)
        {
            return EmptyReferralSet();
        }

        string content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(content))
        {
            return EmptyReferralSet();
        }
        
        return SerializationHelper.Deserialize<ReferralSet>(content);
    }

    /// <inheritdoc/>
    public async Task<ProgramSet> GetPrograms()
    {
        var response = await _httpClient.GetAsync($"programs");
        
        if (!response.IsSuccessStatusCode)
        {
            return EmptyProgramSet();
        }
        
        string content = await response.Content.ReadAsStringAsync();


        if (string.IsNullOrEmpty(content))
        {
            return EmptyProgramSet();
        }

        return SerializationHelper.Deserialize<ProgramSet>(content);

    }

    /// <inheritdoc/>
    public async Task<ReferralConfirmation> PostReferral(Referral referral)
    {
        NewReferral newReferral = new NewReferral(referral);
        var body = SerializationHelper.SerializeBodyContent(newReferral);
        
        var response = await _httpClient.PostAsync("referrals", body);

        return SerializationHelper.Deserialize<ReferralConfirmation>(await response.Content.ReadAsStringAsync());

    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ReferralUpdate>> UpdateReferral(IEnumerable<ReferralUpdate> referralsToUpdate)
    {
        var body = SerializationHelper.SerializeBodyContent(referralsToUpdate);
        var response = await _httpClient.PostAsync("referral/update", body);

        string content = await response.Content.ReadAsStringAsync();

        return SerializationHelper.Deserialize<IEnumerable<ReferralUpdate>>(content);
    }

    /// <inheritdoc/>
    public async Task<ActionMessage> DeleteReferral(IEnumerable<RemoveReferralInfo> referralsToBeDeleted)
    {
        var request =
            HttpHelpers.ConstructDeleteRequest($"{_httpClient.BaseAddress}referral/remove", referralsToBeDeleted);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var removalResult =
            SerializationHelper.Deserialize<IEnumerable<RemoveReferralResult>>(await response.Content.ReadAsStringAsync());

        RemoveReferralResult result = removalResult.FirstOrDefault();

        ActionMessage actionMessage = new ActionMessage();

        if (result is null) return actionMessage;
        
        if (string.Equals(result.ResultInfo.Status, "Success", StringComparison.OrdinalIgnoreCase))
        {
            actionMessage.IsSuccessMessage = true;
            actionMessage.Message = "Referral successfully deleted";
        }
        else
        {
            actionMessage.IsSuccessMessage = false;
            actionMessage.Message = result.ResultInfo.Message;
        }
        return actionMessage;
    }

    private MemberSet EmptyMemberSet()
    {
        return new MemberSet()
        {
            Members = Enumerable.Empty<Member>()
        };
    }

    private ReferralSet EmptyReferralSet()
    {
        return new ReferralSet()
        {
            Referrals = Enumerable.Empty<Referral>()
        };
    }

    private ProgramSet EmptyProgramSet()
    {
        return new ProgramSet()
        {
            Programs = Enumerable.Empty<Models.Domain.Programs.Program>()
        };
    }
}