using System;
using System.IO;
using System.IO.Abstractions;
using Jab;
using Pro.Common.AuthenticatingApiConsumer.OAuth2;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.Common.Logging;
using Pro.Common.Startup;
using Pro.Common.Time;
using Pro.CoreApplication.Registration;
using Pro.CoreApplication.Registration.Interaction;
using Pro.Web.Services;
using ProPresenter.DO;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.Registration.CallbackHandlers;
using ProPresenter.Registration.CallbackHandlers.Dialogs;
using ProPresenter.Registration.CallbackHandlers.Notifications;
using ProPresenter.Registration.CallbackHandlers.PopUpAlert;
using ProPresenter.Registration.Operations;
using ProPresenter.Registration.Services;
using ProPresenter.Registration.UserInteraction;

namespace ProPresenter.Registration.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IRegistrationCallbackHandler>(Factory = "GetRegistrationStateHandler")]
[Jab.Transient<IRegistrationStateProvider>(Factory = "GetRegistrationStateHandler")]
[Jab.Transient<IRegistrationCallbackDialogProvider>(Factory = "GetRegistrationCallbackDialogProvider")]
[Jab.Singleton<IRegistrationCallbackHandler, ExpirationDialogHandler>]
[Jab.Singleton<IRegistrationCallbackHandler, HardExitHandler>]
[Jab.Singleton<IRegistrationCallbackHandler, ProContentTokenReader>]
[Jab.Singleton<IRegistrationCallbackHandler>(Factory = "GetRegistrationDataStorageHandler")]
[Jab.Singleton<IRegistrationCallbackHandler, WatermarkHandler>]
[Jab.Singleton<IRegistrationCallbackHandler, LogHandler>]
[Jab.Singleton<IRegistrationCallbackHandler, GetProductInformationHandler>]
[Jab.Singleton<IRegistrationCallbackHandler, UserAlertHandler>]
[Jab.Singleton<UserMessageHandler>]
[Jab.Transient<IRegistrationCallbackHandler>(Factory = "GetUserMessageHandler")]
[Jab.Transient<ILaunchPopUpProvider>(Factory = "GetUserMessageHandler")]
[Jab.Singleton<ProContentClientInformationProvider>]
[Jab.Transient<IRegistrationCallbackHandler>(Factory = "GetProContentClientInformationProvider")]
[Jab.Transient<IOAuth2ClientInfoProvider>(Factory = "GetProContentClientInformationProvider", Name = "ProContentRegistrationAuthorizationInfoProviderKey")]
[Jab.Transient<IPopUpAlertFactory, PopUpAlertFactory>]
[Jab.Transient<IActivationKeyProvider, ActivationKeyProvider>]
[Jab.Singleton<RegistrationClient>]
[Jab.Transient<IRegistrationClient>(Factory = "GetRegistrationClient")]
[Jab.Transient<IRegistrationRequestSender>(Factory = "GetRegistrationClient")]
[Jab.Singleton<IRegistrationOperationFactory, RegistrationOperationFactory>]
[Jab.Singleton<IRegistrationUserDialogService, RegistrationUserDialogService>]
[Jab.Singleton<NotificationCallbackHandler>]
[Jab.Transient<IRegistrationCallbackHandler>(Factory = "GetNotificationCallbackHandler")]
[Jab.Transient<INotificationCallbackHandler>(Factory = "GetNotificationCallbackHandler")]
[Jab.Singleton<IRegistrationCallbackHandler>(Factory = "GetNotificationDataStoreHandler")]
[Jab.Singleton<IUserAvatarProvider, UserAvatarProvider>]
public interface IRegistrationServiceProviderModule
{
	private const string RegistrationStorageFileName = "RegistrationData";

	private const string NotificationStorageFileName = "NotificationData";

	internal const string ShowRegistrationSettingsKey = "ShowRegistrationSettingsKey";

	internal static RegistrationStateHandler GetRegistrationStateHandler(RegistrationStateHandler handler)
	{
		return handler;
	}

	internal static RegistrationClient GetRegistrationClient(RegistrationClient client)
	{
		return client;
	}

	internal static NotificationCallbackHandler GetNotificationCallbackHandler(NotificationCallbackHandler handler)
	{
		return handler;
	}

	internal static IRegistrationCallbackDialogProvider GetRegistrationCallbackDialogProvider(IUiDispatcher uiDispatcher, ICurrentTime currentTime, [Jab.FromNamedServices("ShowRegistrationSettingsKey")] Action showSettings, IAfterStartupCompleteQueue afterStartupCompleteQueue, IWebSourceProvider webSourceProvider)
	{
		return new RegistrationCallbackDialogProvider(uiDispatcher, currentTime, showSettings, afterStartupCompleteQueue, webSourceProvider);
	}

	internal static UserMessageHandler GetUserMessageHandler(UserMessageHandler handler)
	{
		return handler;
	}

	internal static ProContentClientInformationProvider GetProContentClientInformationProvider(ProContentClientInformationProvider provider)
	{
		return provider;
	}

	internal static RegistrationDataStorageHandler GetRegistrationDataStorageHandler(ILogger logger, IFileSystem fileSystem, IApp app, IErrorReporter errorReporter)
	{
		return new RegistrationDataStorageHandler(Path.Combine(CommonPaths.Registration, "RegistrationData"), logger, fileSystem, app, errorReporter);
	}

	internal static NotificationDataStoreHandler GetNotificationDataStoreHandler(ILogger logger, IFileSystem fileSystem, IApp app, IErrorReporter errorReporter)
	{
		return new NotificationDataStoreHandler(Path.Combine(CommonPaths.Registration, "NotificationData"), logger, fileSystem, app, errorReporter);
	}
}
