using Microsoft.AspNetCore.Mvc;
using ReferralRock.Test.HttpClients.Contracts;
using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Referrals;
using ReferralRock.Test.Models.Extensions;
using ReferralRock.Test.Models.Filters;
using ReferralRock.Test.Models.Request;
using ReferralRock.Test.Models.Response;
using ReferralRock.Test.Models.ViewModels;

namespace ReferralRock.Test.Controllers;

public class ReferralsController : Controller
{
    private readonly IReferralRockHttpClient _httpClient;
    public ReferralsController(IReferralRockHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetReferralForMember(Guid memberId)
    {
        ReferralSet referralSet =  await _httpClient.GetReferrals(memberId);

        return View("Index", referralSet.ToReferralsViewModel(new ReferralsFilter(){ MemberId = memberId}));
    }

    [HttpPost]
    public async Task<IActionResult> GetReferralsForMemberFiltered(ReferralsFilter filter)
    {
        ReferralSet referralSet = await _httpClient.GetReferrals(filter);
        
        return View("Index", referralSet.ToReferralsViewModel(filter));
    }

    [HttpGet]
    public async Task<IActionResult> CreateReferral(Guid memberId)
    {
        ProgramSet programSet = await _httpClient.GetPrograms();
        
        return View("CreateReferral", programSet.ToCreateReferralViewModel());
    }

    [HttpGet]
    public async Task<IActionResult> DeleteReferral(Guid referralId, Guid memberId)
    {
        IEnumerable<RemoveReferralInfo> referralsToBeDeleted =
            new[] { new RemoveReferralInfo(new ReferralQuery(referralId)) };
        
        ActionMessage removalResult = await _httpClient.DeleteReferral(referralsToBeDeleted);
        
        ReferralSet referralSet = await _httpClient.GetReferrals(new ReferralsFilter(memberId));

        return View("Index", referralSet.ToReferralsViewModel(new ReferralsFilter(){ MemberId = memberId}, removalResult));
    }

    [HttpGet]
    public async Task<IActionResult> EditReferral(Guid referralId)
    {
        Referral referral = await _httpClient.GetSingleReferral(referralId);

        return View("EditReferral", referral.ToEditReferralViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> UpdateReferral(EditReferralViewModel viewModel, Guid memberId)
    {
        IEnumerable<ReferralUpdate> referralsToBeUpdated =
            new[] { new ReferralUpdate(viewModel) };

        var result = await _httpClient.UpdateReferral(referralsToBeUpdated);

        return RedirectToAction("GetReferralForMember", new { memberId});
    }

    [HttpGet]
    public IActionResult CreateReferralForMember(string programName, string memberDisplayName, string memberReferralCode)
    {
        Referral newReferral = new Referral()
        {
            ProgramName = programName,
            ReferringMemberName = memberDisplayName,
            MemberReferralCode = memberReferralCode
        };

        return View("CreateReferralSubmission", new ReferralSubmissionViewModel(){ ReferralDetails = newReferral});
    }

    [HttpPost]
    public async Task<IActionResult> SubmitReferralCreation(ReferralSubmissionViewModel viewModel)
    {
        var referralConfirmation = await _httpClient.PostReferral(viewModel.ReferralDetails);

        return referralConfirmation.Referral is not null
            ? RedirectToAction("GetReferralForMember", new { memberId = referralConfirmation.Referral.ReferringMemberId})
            : View("CreateReferralSubmission", new ReferralSubmissionViewModel() 
                {ReferralDetails = viewModel.ReferralDetails, ErrorMessage = referralConfirmation.Message});
    }
}