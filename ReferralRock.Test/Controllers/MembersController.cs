using Microsoft.AspNetCore.Mvc;
using ReferralRock.Test.HttpClients.Contracts;
using ReferralRock.Test.Models.Extensions;
using ReferralRock.Test.Models.Filters;
using ReferralRock.Test.Models.Response;

namespace ReferralRock.Test.Controllers;

public class MembersController : Controller
{
    private readonly IReferralRockHttpClient _httpClient;
    public MembersController(IReferralRockHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IActionResult> Index()
    {
        MemberSet memberSet =  await _httpClient.GetMembers();

        return View("Index", memberSet.ToMembersViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> GetMembers(MembersFilter filter, bool IsPartialView = false)
    {
        MemberSet memberSet = await _httpClient.GetMembers(filter);

        return IsPartialView
            ? PartialView("Partials/_MembersList", memberSet)
            : View("Index", memberSet.ToMembersViewModel(filter));
    }
}