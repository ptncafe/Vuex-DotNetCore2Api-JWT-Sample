using Newtonsoft.Json;
using System.Net;

namespace Sendo.Seller.Client.V5.Api.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case (int) HttpStatusCode.Forbidden:
                    return "Forbidden";

                case (int)HttpStatusCode.Unauthorized:
                    return "Unauthorized";

                case (int)HttpStatusCode.BadRequest:
                    return "Bad request";

                case (int)HttpStatusCode.NotFound:
                    return "Resource not found";

                case (int)HttpStatusCode.InternalServerError:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }
}
