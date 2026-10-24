using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pro.Common.Time;
using Pro.Common.Versioning;
using Pro.CoreApplication.Registration;
using Pro.CoreApplication.Registration.Interaction;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Settings;
using ProPresenter.Registration.Operations.Bible;
using ProPresenter.Registration.Operations.Downloads;
using ProPresenter.Registration.Operations.OAuthToken;
using ProPresenter.Registration.Operations.Registration;
using ProPresenter.Registration.Operations.State;
using ProPresenter.Registration.Operations.UpDowngrade;
using ProPresenter.Registration.UserInteraction;

namespace ProPresenter.Registration.Operations;

public class RegistrationOperationFactory : IRegistrationOperationFactory
{
	private sealed class DummyAwaitableOperation : IAwaitableOperation
	{
		private readonly Task _delay = Task.Delay(500);

		public TaskAwaiter GetAwaiter()
		{
			return _delay.GetAwaiter();
		}
	}

	private readonly IRegistrationUserDialogService _registerOperationUserDialogService;

	private readonly IRegistrationClient _registrationClient;

	private readonly IApp _app;

	private readonly IVersionInfoProvider _versionInfoProvider;

	private readonly RegistrationStateRefresher _registrationStateRefresher;

	public RegistrationOperationFactory(IRegistrationUserDialogService registerOperationUserDialogService, IRegistrationClient registrationClient, IApp app, ICurrentTime currentTime, IVersionInfoProvider versionInfoProvider)
	{
		_registerOperationUserDialogService = registerOperationUserDialogService;
		_registrationClient = registrationClient;
		_app = app;
		_versionInfoProvider = versionInfoProvider;
		_registrationStateRefresher = new RegistrationStateRefresher(currentTime);
	}

	public IAwaitableOperation Activate(string confirmationCode, bool showVisualIndication)
	{
		return Add(new ActivateOperation(confirmationCode, showVisualIndication, _registerOperationUserDialogService));
	}

	public IAwaitableOperation Unregister()
	{
		return Add(new UnregisterRegistrationOperation());
	}

	public IAwaitableOperation Signout()
	{
		return Add(new SignoutRegistrationOperation());
	}

	public IAwaitableOperation<bool> RegisterWithUnlockCode(string userName, string unlockCode, string deviceName)
	{
		return Add(new RegisterWithUnlockCodeOperation((bool isActive) => Add(GetChangeSeatTypeRegistrationOperation(isActive)), userName, unlockCode, deviceName, _registerOperationUserDialogService, _versionInfoProvider, GetUpdateChannel()));
	}

	public IAwaitableOperation Refresh()
	{
		return _registrationStateRefresher.Refresh(() => EnqueueRefresh(GetUpdateChannel()));
	}

	public IAwaitableOperation RefreshBibles()
	{
		return Add(new RefreshBibleStateRegistrationOperation());
	}

	public IAwaitableOperation ActivateBible(string bibleId)
	{
		return Add(new ActivateBibleRegistrationOperation(bibleId));
	}

	public IAwaitableOperation DeactivateBible(string bibleId)
	{
		return Add(new DeactivateBibleRegistrationOperation(bibleId));
	}

	public IDownloadOperation DownloadBible(string bibleId, string fileName)
	{
		return Add(new BibleDownloadOperation(fileName, bibleId));
	}

	public IAwaitableOperation ChangeSeatType(bool isActive)
	{
		return new ChangeSeatOperation(_registrationClient, _registerOperationUserDialogService, isActive, GetChangeSeatTypeRegistrationOperation(isActive));
	}

	private IAwaitableRegistrationOperation GetChangeSeatTypeRegistrationOperation(bool isActive)
	{
		return new ChangeSeatRegistrationOperation(isActive, GetUpdateChannel());
	}

	public IAwaitableOperation<AvailableSoftware> GetAvailableUpgrades(bool isBeta)
	{
		return Add(new GetAppUpgradesOperation(isBeta, _versionInfoProvider.AppVersion));
	}

	public IDownloadOperation DownloadApp(string url, string fileName)
	{
		return Add(new ApplicationDownloadOperation(fileName, url));
	}

	public void SetOAuthToken(string token, string refreshToken, DateTimeOffset expiresAt)
	{
		Add(new SetOAuthDataRegistrationOperation(token, refreshToken, expiresAt));
	}

	public IAwaitableOperation RefreshAccessToken()
	{
		return Add(new RefreshAccessTokenOperation());
	}

	public IAwaitableOperation SetDeviceName(string deviceName)
	{
		return new DummyAwaitableOperation();
	}

	private UpdateChannel GetUpdateChannel()
	{
		return _app.UpdateChannel;
	}

	private T Add<T>(T operation) where T : IRegistrationOperation
	{
		_registrationClient.Add(operation);
		return operation;
	}

	private IAwaitableOperation EnqueueRefresh(UpdateChannel channel)
	{
		return Add(new RefreshRegistrationOperation(channel));
	}
}
