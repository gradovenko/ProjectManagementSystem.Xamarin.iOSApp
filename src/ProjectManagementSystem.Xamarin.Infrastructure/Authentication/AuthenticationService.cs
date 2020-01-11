using System.Threading;
using System.Threading.Tasks;
using ProjectManagementSystem.Xamarin.Domain.Authentication;
using ProjectManagementSystem.Xamarin.Infrastructure.AuthenticationApi;
using ProjectManagementSystem.Xamarin.Infrastructure.TokenStores;

namespace ProjectManagementSystem.Xamarin.Infrastructure.Authentication
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationApi _authenticationApi;
        private readonly TokenStore _tokenStore;

        public AuthenticationService(IAuthenticationApi authenticationApi, TokenStore tokenStore)
        {
            _authenticationApi = authenticationApi;
            _tokenStore = tokenStore;
        }

        public async Task AuthenticationByPassword(string username, string password, CancellationToken cancellationToken)
        {
            var tokenView = await _authenticationApi.Authentication(new AuthenticationBuilder()
                .GrantType(AuthenticationGrantType.Password)
                .Username(username)
                .Password(password));

            await _tokenStore.Save(new Token(tokenView.AccessToken, tokenView.RefreshToken));
        }

        public async Task AuthenticationByRefreshToken(string refreshToken, CancellationToken cancellationToken)
        {
            var tokenView = await _authenticationApi.Authentication(new AuthenticationBuilder()
                .GrantType(AuthenticationGrantType.RefreshToken)
                .RefreshToken(refreshToken));

            await _tokenStore.Save(new Token(tokenView.AccessToken, tokenView.RefreshToken));
        }
    }
}
