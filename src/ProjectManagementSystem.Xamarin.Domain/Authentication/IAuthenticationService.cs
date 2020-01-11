using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Xamarin.Domain.Authentication
{
    public interface IAuthenticationService
    {
        Task AuthenticationByPassword(string username, string password, CancellationToken cancellationToken);
        Task AuthenticationByRefreshToken(string refreshToken, CancellationToken cancellationToken);
    }
}
