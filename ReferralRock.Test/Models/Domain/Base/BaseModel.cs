using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ReferralRock.Test.Models.Domain.Base;

public abstract class BaseModel
{
    public Guid Id { get; set; } 
    public string DisplayName { get; set; }
    
    [DisplayName("First Name")]
    public string FirstName { get; set; }
    
    [DisplayName("Last Name")]
    public string LastName { get; set; }
    
    [DisplayName("Email")]
    public string Email { get; set; }
    
    [DisplayName("External Identifier")]
    [JsonPropertyName("externalIdentifier")]
    public string ExternalIdentifier { get; set; }
    public Guid ProgramId { get; set; }
    public string ProgramName { get; set; }
    public string ProgramTitle { get; set; }
    public string UtmSource { get; set; }
    public string UtmMedium { get; set; }
    public string UtmCampaign { get; set; }
    public string BrowserReferrerUrl { get; set; }
}
