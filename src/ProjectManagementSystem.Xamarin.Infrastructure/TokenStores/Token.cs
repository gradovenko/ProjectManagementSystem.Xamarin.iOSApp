﻿namespace ProjectManagementSystem.Xamarin.Infrastructure.TokenStores
{
    public sealed class Token
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }

        public Token(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
