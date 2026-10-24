using System;

namespace ProPresenter.DO.Registration.State;

public record OAuthToken(string AccessToken, string RefreshToken, DateTimeOffset ExpiresAt);
