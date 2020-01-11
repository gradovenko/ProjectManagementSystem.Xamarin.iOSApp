using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ProjectManagementSystem.Xamarin.Infrastructure.AuthenticationApi
{
    public sealed class ErrorView
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }

        public static ErrorView Parse(string s)
        {
            return JsonConvert.DeserializeObject<ErrorView>(s);
        }
    }
}
