using ReferralRock.Test.Helpers;
using ReferralRock.Test.HttpClients.Contracts;
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

        return await ProcessResponse(response, EmptyMemberSet);
    }
    
    /// <inheritdoc/>
    public async Task<Referral> GetSingleReferral(Guid referralId)
    {
        var response = await _httpClient.GetAsync($"referral/single?referralId={referralId}");

        return await ProcessResponse<Referral>(response);
    }
    
    /// <inheritdoc/>
    public async Task<ReferralSet> GetReferrals(Guid memberId)
    {
        var response = await _httpClient.GetAsync($"referrals?memberId={memberId}");
        
        return await ProcessResponse(response, EmptyReferralSet);
    }

    /// <inheritdoc/>
    public async Task<ReferralSet> GetReferrals(ReferralsFilter filter = null)
    {
        string uriParameters = HttpHelpers.GetReferralsQueryString(filter);
        
        var response = await _httpClient.GetAsync($"referrals?{uriParameters}");

        return await ProcessResponse(response, EmptyReferralSet);
    }

    /// <inheritdoc/>
    public async Task<ProgramSet> GetPrograms()
    {
        var response = await _httpClient.GetAsync($"programs");

        return await ProcessResponse(response, EmptyProgramSet);
    }

    /// <inheritdoc/>
    public async Task<ReferralConfirmation> PostReferral(Referral referral)
    {
        NewReferral newReferral = new NewReferral(referral);
        var body = SerializationHelper.SerializeBodyContent(newReferral);
        
        var response = await _httpClient.PostAsync("referrals", body);

        return await ProcessResponse<ReferralConfirmation>(response);

    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ReferralUpdate>> UpdateReferral(IEnumerable<ReferralUpdate> referralsToUpdate)
    {
        var body = SerializationHelper.SerializeBodyContent(referralsToUpdate);
        var response = await _httpClient.PostAsync("referral/update", body);

        return await ProcessResponse<IEnumerable<ReferralUpdate>>(response);
    }

    /// <inheritdoc/>
    public async Task<ActionMessage> DeleteReferral(IEnumerable<RemoveReferralInfo> referralsToBeDeleted)
    {
        var request =
            HttpHelpers.ConstructDeleteRequest($"{_httpClient.BaseAddress}referral/remove", referralsToBeDeleted);

        var response = await _httpClient.SendAsync(request);
        
        var removalResult = await ProcessResponse<IEnumerable<RemoveReferralResult>>(response);

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
    
    private async Task<T> ProcessResponse<T>(HttpResponseMessage response, Func<T> emptyResult = null)
    {
        if (!response.IsSuccessStatusCode)
        {
            return emptyResult.Invoke(); 
        }

        string content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(content))
        {
            return emptyResult.Invoke();
        }

        return SerializationHelper.Deserialize<T>(content);
    }

    private MemberSet EmptyMemberSet() => new() { Members = Enumerable.Empty<Member>() };
    private ReferralSet EmptyReferralSet() => new() { Referrals = Enumerable.Empty<Referral>() };
    private ProgramSet EmptyProgramSet() => new() { Programs = Enumerable.Empty<Models.Domain.Programs.Program>() };
}