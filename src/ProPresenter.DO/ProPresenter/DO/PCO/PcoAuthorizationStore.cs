using System;
using System.CodeDom.Compiler;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.PCO;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_isAuthorized" })]
public class PcoAuthorizationStore : IOAuth2AuthorizationStore, IDisposable
{
	private readonly IApp _app;

	private readonly SubjectBase<bool> _isAuthorized;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<bool> IsAuthorized => _isAuthorized;

	public PcoAuthorizationStore(IApp app)
	{
		_app = app;
		_isAuthorized = new BehaviorSubject<bool>(_app.PCOAccessTokenExpiry.HasValue && !string.IsNullOrEmpty(_app.PCORefreshToken));
	}

	public void ClearAuthorization()
	{
		_app.PCOAccessToken = string.Empty;
		_app.PCORefreshToken = string.Empty;
		_app.PCOAccessTokenExpiry = null;
		_isAuthorized.OnNext(value: false);
	}

	public OAuth2AuthorizationDataStored GetAuthorization()
	{
		return new OAuth2AuthorizationDataStored(_app.PCOAccessToken, _app.PCORefreshToken, _app.PCOAccessTokenExpiry);
	}

	public void StoreAuthorization(OAuth2AuthorizationDataStored data)
	{
		_app.PCOAccessToken = data.AccessToken;
		_app.PCORefreshToken = data.RefreshToken;
		_app.PCOAccessTokenExpiry = data.ExpirationDate;
		_isAuthorized.OnNext(value: true);
	}

	public Task RefreshAuthorization()
	{
		ClearAuthorization();
		return Task.CompletedTask;
	}

	public bool OverrideOAuthRefresh()
	{
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_isAuthorized.Dispose();
		}
	}
}
