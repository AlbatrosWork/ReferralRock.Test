using System.Text;
using ReferralRock.Test.HttpClients.Contracts;
using ReferralRock.Test.HttpClients.Implementations;

namespace ReferralRock.Test.ServiceCollectionExtensions;

public static class RegisterHttpClients
{
    public static IServiceCollection AddTypedHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        string baseUrl = configuration["ReferralRockApi:BaseUrl"];
        string publicApiKey = configuration["ReferralRockApi:PublicApiKey"];
        string privateApiKey = configuration["ReferralRockApi:PrivateApiKey"];

        var base64 = GetBase64Credentials(publicApiKey, privateApiKey);
        services.AddHttpClient<IReferralRockHttpClient, ReferralRockHttpClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {base64}");
        });

        return services;
    }

    private static string GetBase64Credentials(string publicApiKey, string privateApiKey)
    {
        string credentials = $"{publicApiKey}:{privateApiKey}";
        var bytes = Encoding.ASCII.GetBytes(credentials);
        return Convert.ToBase64String(bytes);
    }
}