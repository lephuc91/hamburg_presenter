using System;
using Pro.Common.Dispatcher;
using Pro.Common.Versioning;
using Pro.CoreApplication.CoreInteraction;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.UI.DialogService;

namespace ProPresenter.Services;

public class ApplicationFailureMessageService(IUiDispatcher _uiDispatcher, ILocalization _localization, IVersionInfoProvider _versionInfoProvider) : IApplicationFailureMessageService
{
	[Flags]
	private enum ApplicationFailureUserButtons
	{
		[LocalizedString("GLOBAL_CONTINUE_BUTTON_title")]
		Continue = 1,
		[LocalizedString("GLOBAL_QUIT")]
		Quit = 2,
		[LocalizedString("GLOBAL_RETRY_BUTTON_title")]
		Retry = 4
	}

	public IApplicationFailureMessageService.StartupUserSelection ShowMediaServiceStartupFailure(string error)
	{
		return _uiDispatcher.Invoke(() => Convert(MessageDialogService.ShowDialog(null, _localization.Get("MEDIA_MANAGER_INTERNAL_FAILURE_ALERT_title"), _localization.Get("MEDIA_MANAGER_INTERNAL_FAILURE_ALERT_info", new object[1] { error }), ApplicationFailureUserButtons.Continue | ApplicationFailureUserButtons.Quit | ApplicationFailureUserButtons.Retry, ApplicationFailureUserButtons.Retry)));
	}

	private static IApplicationFailureMessageService.StartupUserSelection Convert(ApplicationFailureUserButtons? userSelection)
	{
		return userSelection switch
		{
			ApplicationFailureUserButtons.Continue => IApplicationFailureMessageService.StartupUserSelection.Continue, 
			ApplicationFailureUserButtons.Quit => IApplicationFailureMessageService.StartupUserSelection.Quit, 
			_ => IApplicationFailureMessageService.StartupUserSelection.Retry, 
		};
	}

	public IApplicationFailureMessageService.VersionMismatchUserSelection ShowMediaServiceApiVersionMismatch()
	{
		return _uiDispatcher.Invoke(delegate
		{
			IApplicationFailureMessageService.VersionMismatchUserSelection userSelection = IApplicationFailureMessageService.VersionMismatchUserSelection.Update;
			MessageDialogService.ShowDialog(null, _localization.Get("APP_OUTDATED_ALERT_message"), _localization.Get("APP_OUTDATED_ALERT_info", new object[1] { _versionInfoProvider.ShortDisplayAppVersion }), new global::_003C_003Ez__ReadOnlyArray<ButtonDescriptor>(new ButtonDescriptor[3]
			{
				new ButtonDescriptor(_localization.Get("APP_OUTDATED_CONTINUE_button", new object[1] { _versionInfoProvider.ShortDisplayAppVersion }), IsDefault: false, IsCancel: false, delegate
				{
					userSelection = IApplicationFailureMessageService.VersionMismatchUserSelection.Continue;
				}),
				new ButtonDescriptor(_localization.Get("APP_OUTDATED_UPDATE_button"), IsDefault: true, IsCancel: false, delegate
				{
					userSelection = IApplicationFailureMessageService.VersionMismatchUserSelection.Update;
				}),
				new ButtonDescriptor(_localization.Get("APP_OUTDATED_QUIT_button"), IsDefault: false, IsCancel: false, delegate
				{
					userSelection = IApplicationFailureMessageService.VersionMismatchUserSelection.Quit;
				})
			}));
			return userSelection;
		});
	}

	public void ShowServiceBootstrapError()
	{
		_uiDispatcher.Invoke(delegate
		{
			MessageDialogService.ShowAlert(_localization.Get("APP_BOOTSTRAP_ALERT_heading"), _localization.Get("APP_BOOTSTRAP_ALERT_message"));
		});
	}
}
