namespace ReferralRock.Test.Models.Response;

public class ProgramSet : BaseCollectionResponse
{
    public IEnumerable<Domain.Programs.Program> Programs { get; set; }
}