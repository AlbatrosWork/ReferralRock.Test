using System.Text.Json.Serialization;

namespace ReferralRock.Test.Models.Domain.Referrals;

public class ReferralTertiaryInfo
{
    [JsonPropertyName("programId")]
    public string ProgramId { get; set; }
    
    [JsonPropertyName("programName")]
    public string ProgramName { get; set; }
    
    [JsonPropertyName("programTitle")]
    public string ProgramTitle { get; set; }
}