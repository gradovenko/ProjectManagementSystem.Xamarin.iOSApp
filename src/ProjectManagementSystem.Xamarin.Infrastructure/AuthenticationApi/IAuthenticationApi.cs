using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace ProjectManagementSystem.Xamarin.Infrastructure.AuthenticationApi
{
    public interface IAuthenticationApi
    {
        [Post("/auth/token")]
        Task<TokenView> Authentication([Body]HttpContent content);
    }
}
