using System;
using System.ComponentModel;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Pro.Common.Components;
using Pro.Common.OAuth.Authenticator;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;

namespace ProPresenter.Data;

public class ProContentRegistrationAuthorizationStorage : DisposableBase, IOAuth2AuthorizationStore
{
	private static readonly DateTimeOffset ExpirationInvalid = DateTimeOffset.FromUnixTimeSeconds(0L);

	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly SubjectBase<bool> _isAuthorized;

	public IObservable<bool> IsAuthorized => _isAuthorized;

	public ProContentRegistrationAuthorizationStorage(IRegistrationOperationFactory registrationOperationFactory, IRegistrationStateProvider registrationStateProvider)
	{
		_registrationOperationFactory = registrationOperationFactory;
		_registrationStateProvider = registrationStateProvider;
		_isAuthorized = new BehaviorSubject<bool>(GetIsAuthorized(_registrationStateProvider.Token));
		registrationStateProvider.PropertyChanged += On_RegistrationStateProvider_PropertyChanged;
	}

	public void ClearAuthorization()
	{
		_registrationOperationFactory.SetOAuthToken(string.Empty, string.Empty, ExpirationInvalid);
	}

	public OAuth2AuthorizationDataStored GetAuthorization()
	{
		return new OAuth2AuthorizationDataStored(_registrationStateProvider.Token?.AccessToken ?? string.Empty, _registrationStateProvider.Token?.RefreshToken ?? string.Empty, _registrationStateProvider.Token?.ExpiresAt);
	}

	public void StoreAuthorization(OAuth2AuthorizationDataStored data)
	{
		_registrationStateProvider.UpdateToken(data.AccessToken, data.RefreshToken, data.ExpirationDate ?? ExpirationInvalid);
		_registrationOperationFactory.SetOAuthToken(data.AccessToken, data.RefreshToken, data.ExpirationDate ?? ExpirationInvalid);
	}

	public async Task RefreshAuthorization()
	{
		await _registrationOperationFactory.RefreshAccessToken();
	}

	public bool OverrideOAuthRefresh()
	{
		return true;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_registrationStateProvider.PropertyChanged -= On_RegistrationStateProvider_PropertyChanged;
		}
		base.OnDispose(disposeObjects);
	}

	private void On_RegistrationStateProvider_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Token")
		{
			_isAuthorized.OnNext(GetIsAuthorized(_registrationStateProvider.Token));
		}
	}

	private static bool GetIsAuthorized(OAuthToken? token)
	{
		if ((object)token != null && !string.IsNullOrEmpty(token.RefreshToken))
		{
			return token.ExpiresAt > DateTimeOffset.FromUnixTimeSeconds(0L);
		}
		return false;
	}
}
