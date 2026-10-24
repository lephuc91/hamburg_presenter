using System;
using System.Windows;
using Pro.Common.Dispatcher;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.UI.Registration.PopUpAlerts;

namespace ProPresenter.Registration.UserInteraction;

public class RegistrationUserDialogService : IRegistrationUserDialogService
{
	private sealed class DisposingOnUiThread : IDisposable
	{
		private readonly IDisposable _toDispose;

		private readonly IUiDispatcher _uiDispatcher;

		public DisposingOnUiThread(IDisposable toDispose, IUiDispatcher uiDispatcher)
		{
			_toDispose = toDispose;
			_uiDispatcher = uiDispatcher;
		}

		public void Dispose()
		{
			_uiDispatcher.Invoke(_toDispose.Dispose);
		}
	}

	private readonly IUiDispatcher _uiDispatcher;

	public RegistrationUserDialogService(IUiDispatcher uiDispatcher)
	{
		_uiDispatcher = uiDispatcher;
	}

	public bool DoesUserReallyWantToSwitchToInactiveSeat()
	{
		return _uiDispatcher.Invoke(() => MessageDialogService.ShowDialog(null, LocalizedStrings.Get("REGISTRATION_WARNING_SEAT_INACTIVE_ALERT_message"), LocalizedStrings.Get("REGISTRATION_WARNING_SEAT_INACTIVE_ALERT_info"), DefaultButtons.OK | DefaultButtons.CANCEL, DefaultButtons.CANCEL) == DefaultButtons.OK);
	}

	public bool DoesUserReallyWantToSignOut(string organizationName)
	{
		bool shouldSignOut = false;
		_uiDispatcher.Invoke(delegate
		{
			MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
			{
				Heading = LocalizedStrings.Get("SETTINGS_ACCOUNT_SIGN_OUT_WARNING_message"),
				Message = LocalizedStrings.Get("SETTINGS_ACCOUNT_SIGN_OUT_WARNING_info", new object[1] { organizationName })
			}, new ButtonDescriptor[2]
			{
				new ButtonDescriptor(LocalizedStrings.Get("SETTINGS_ACCOUNT_SIGN_OUT_BUTTON_title"), IsDefault: true, IsCancel: false, delegate
				{
					shouldSignOut = true;
				}),
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title"))
			}, null, null, canClose: true);
		});
		return shouldSignOut;
	}

	public IDisposable? ShowActivationInProgress()
	{
		return _uiDispatcher.Invoke(delegate
		{
			ActivatingSpinner activatingSpinner = new ActivatingSpinner();
			activatingSpinner.Show();
			return new DisposingOnUiThread(activatingSpinner, _uiDispatcher);
		});
	}
}
