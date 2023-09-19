using System.Text.Json.Serialization;
using ReferralRock.Test.Models.Domain.Referrals;
using ReferralRock.Test.Models.Request;
using ReferralRock.Test.Models.ViewModels;

namespace ReferralRock.Test.Models.Response;

public class ReferralUpdate
{
    [JsonPropertyName("query")]
    public ReferralQuery Query { get; set; }
    
    [JsonPropertyName("referral")]
    public Referral UpdateReferral { get; set; }
    
    [JsonPropertyName("resultInfo")]
    public ResultInfo ResultInfo { get; set; }

    public ReferralUpdate(EditReferralViewModel viewModel)
    {
        Query = new ReferralQuery(viewModel.Referral.Id);
        UpdateReferral = new Referral()
        {
            FirstName = viewModel.Referral.FirstName,
            LastName = viewModel.Referral.LastName,
            Email = viewModel.Referral.Email,
            CompanyName = viewModel.Referral.CompanyName,
            Amount = viewModel.Referral.Amount,
            PublicNote = viewModel.Referral.PublicNote,
            ExternalIdentifier = viewModel.Referral.ExternalIdentifier
        };
    }

    //Deserialization purposes
    public ReferralUpdate()
    {
        
    }
        
}