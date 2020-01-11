using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ProjectManagementSystem.Xamarin.Infrastructure.AuthenticationApi
{
    public sealed class AuthenticationBuilder
    {
        private AuthenticationGrantType? _grantType;
        public AuthenticationBuilder GrantType(AuthenticationGrantType value) { _grantType = value; return this; }

        private string _username;
        public AuthenticationBuilder Username(string value) { _username = value; return this; }

        private string _password;
        public AuthenticationBuilder Password(string value) { _password = value; return this; }

        private string _refreshToken;
        public AuthenticationBuilder RefreshToken(string value) { _refreshToken = value; return this; }

        public HttpContent Build
        {
            get
            {
                if (_grantType == null)
                    throw new InvalidOperationException($"{nameof(GrantType)} must be set");

                switch (_grantType)
                {
                    case AuthenticationGrantType.Password:
                        if (_username == null)
                            throw new InvalidOperationException($"{nameof(Username)} must be set");
                        if (_password == null)
                            throw new InvalidOperationException($"{nameof(Password)} must be set for {nameof(Username)}: {_grantType}");
                        break;
                    case AuthenticationGrantType.RefreshToken:
                        if (_refreshToken == null)
                            throw new InvalidOperationException($"{nameof(RefreshToken)} must be set for {nameof(Username)}: {_grantType}");
                        break;
                }

                return new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "grant_type", GetGrantType(_grantType) },
                    { "login", _username },
                    { "password", _password },
                    { "refresh_token", _refreshToken }
                });
            }
        }

        private string GetGrantType(AuthenticationGrantType? gt)
        {
            switch (gt)
            {
                case AuthenticationGrantType.Password:
                    return "password";
                case AuthenticationGrantType.RefreshToken:
                    return "refresh_token";
            }
            return null;
        }

        public static implicit operator HttpContent(AuthenticationBuilder builder)
        {
            return builder.Build;
        }
    }
}
