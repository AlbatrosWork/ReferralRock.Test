using System.Text;
using System.Text.Json;

namespace ReferralRock.Test.Helpers;

public static class SerializationHelper
{
    
    private static readonly JsonSerializerOptions DefaultOptions =  new()
    {
        PropertyNameCaseInsensitive = true
    };
    /// <summary>
    /// Deserializes a given json input to the requested T type
    /// </summary>
    /// <param name="json"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json, DefaultOptions);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    } 
    
    /// <summary>
    /// Serializes a given T input to a string json
    /// </summary>
    /// <param name="contentToSerialize"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static HttpContent SerializeBodyContent<T>(T contentToSerialize)
    {
        string json = JsonSerializer.Serialize(contentToSerialize);

        return new StringContent(json, Encoding.UTF8, "application/json");
    }
}