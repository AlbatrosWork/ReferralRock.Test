using System.Text.Json.Serialization;
using ReferralRock.Test.Models.Domain;
using ReferralRock.Test.Models.Domain.Referrals;

namespace ReferralRock.Test.Models.Request;

public class NewReferral
{
    [JsonPropertyName("referralCode")]
    public string ReferralCode { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    // [JsonPropertyName("phoneNumber")]
    // public string PhoneNumber { get; set; }

    // [JsonPropertyName("preferredContact")]
    // public string PreferredContact { get; set; }

    [JsonPropertyName("externalIdentifier")]
    public string ExternalIdentifier { get; set; }

    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }

    public NewReferral(Referral referral)
    {
        ReferralCode = referral.MemberReferralCode;
        FirstName = referral.FirstName;
        LastName = referral.LastName;
        Email = referral.Email;
        ExternalIdentifier = referral.ExternalIdentifier;
        Amount = referral.Amount;
        Status = referral.Status;
    }
}