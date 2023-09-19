using System.Net;
using System.Text;
using ReferralRock.Test.Models.Filters;

namespace ReferralRock.Test.Helpers;

public static class HttpHelpers
{
    /// <summary>
    /// Returns members filter object as uri parameter string
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
     public static string GetMembersQueryString(MembersFilter filter)
     {
        StringBuilder stringBuilder = new StringBuilder();

        if (filter is null)
        {
            return string.Empty;
        }

        List<string> queryParams = new List<string>();

        if (!string.IsNullOrEmpty(filter.SelectedProgram))
        {
            queryParams.Add($"programId={WebUtility.UrlEncode(filter.SelectedProgram)}");
        }

        if (!string.IsNullOrEmpty(filter.QuerySearch))
        {
            queryParams.Add($"query={WebUtility.UrlEncode(filter.QuerySearch)}");
        }

        if (!string.IsNullOrEmpty(filter.SortBy))
        {
            queryParams.Add($"sort={filter.SortBy}");
        }

        if (filter.ShowDisabled)
        {
            queryParams.Add($"showDisabled={filter.ShowDisabled}");
        }

        return string.Join("&", queryParams);
     }
    
    /// <summary>
    /// Returns Referral filter object as uri parameter string
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>

     public static string GetReferralsQueryString(ReferralsFilter filter)
     {
         StringBuilder stringBuilder = new StringBuilder();
         
         List<string> queryParams = new List<string>();

         queryParams.Add($"memberId={filter.MemberId}");

         if (!string.IsNullOrEmpty(filter.QuerySearch))
         {
             queryParams.Add($"query={WebUtility.UrlEncode(filter.QuerySearch)}");
         }

         if (!string.IsNullOrEmpty(filter.SelectedStatus))
         {
             queryParams.Add($"status={filter.SelectedStatus}");
         }

         return string.Join("&", queryParams);
     }
    
    /// <summary>
    /// Constructs a delete request for delete endpoints which require a body
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="collection"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>

     public static HttpRequestMessage ConstructDeleteRequest<T>(string endpoint, T collection)
     {
         return new HttpRequestMessage
         {
             Method = HttpMethod.Delete,
             RequestUri = new Uri(endpoint),
             Content = SerializationHelper.SerializeBodyContent(collection)
         };
     }
}