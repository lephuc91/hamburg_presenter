using System;

namespace Pro.Common.OAuth.Authenticator;

public record OAuth2AuthorizationDataStored(string AccessToken, string RefreshToken, DateTimeOffset? ExpirationDate);
