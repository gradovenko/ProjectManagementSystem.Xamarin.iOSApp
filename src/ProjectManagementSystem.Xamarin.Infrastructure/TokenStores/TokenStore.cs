using System.Threading.Tasks;

namespace ProjectManagementSystem.Xamarin.Infrastructure.TokenStores
{
    public sealed class TokenStore
    {
        public Token Token { get; private set; }

        public Task Save(Token token)
        {
            Token = token;

            return Task.CompletedTask;
        }
    }
}
