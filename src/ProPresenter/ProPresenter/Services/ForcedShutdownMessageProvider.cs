using System.Windows;
using Pro.Common.Dispatcher;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Localization;
using Pro.UI.Controls;
using Pro.UI.DialogService;
using ProPresenter.DO.Analytics.Events.ForceQuit;
using ProPresenter.UI.Theming;

namespace ProPresenter.Services;

public class ForcedShutdownMessageProvider : IForcedShutdownMessageProvider
{
	private readonly IUiDispatcher _uiDispatcher;

	private readonly IMessageService _messageService;

	private readonly IForceQuitEventPublisher _eventPublisher;

	public ForcedShutdownMessageProvider(IUiDispatcher uiDispatcher, IMessageService messageService, IForceQuitEventPublisher eventPublisher)
	{
		_uiDispatcher = uiDispatcher;
		_messageService = messageService;
		_eventPublisher = eventPublisher;
	}

	public void ShowForcedApplicationShutdownDialog(IForcedShutdownMessageProvider.ShutdownReason reason)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			_eventPublisher.ForceQuit(GetAnalyticReason(reason));
			CountdownAlert countdownAlert = new CountdownAlert
			{
				Message = LocalizedStrings.Get(GetShutdownTitle(reason)),
				Subtext = LocalizedStrings.Get(GetShutdownMessage(reason)),
				CountdownForeground = AppTheme.Active.ERROR,
				StartingSeconds = 60
			};
			Window window = null;
			countdownAlert.CountdownComplete += delegate
			{
				window?.Close();
				_messageService.PublishMessage(new RequestApplicationCloseMessage());
			};
			window = MessageDialogService.ShowDialogNonBlocking(string.Empty, (DependencyObject)(object)countdownAlert, new global::_003C_003Ez__ReadOnlySingleElementList<ButtonDescriptor>(new ButtonDescriptor(LocalizedStrings.Get(GetShutdownConfirmationButton(reason)), IsDefault: true, IsCancel: false, delegate
			{
				window?.Close();
			})));
			window.Closing += delegate
			{
				_messageService.PublishMessage(new RequestApplicationCloseMessage());
			};
			window.Topmost = true;
		});
	}

	private static string GetShutdownTitle(IForcedShutdownMessageProvider.ShutdownReason reason)
	{
		return reason switch
		{
			IForcedShutdownMessageProvider.ShutdownReason.HostsFile => "REGISTRATION_HOSTS_FILE_ALERT_message", 
			IForcedShutdownMessageProvider.ShutdownReason.SystemTime => "REGISTRATION_ERROR_TIME_DISCREPANCY_ALERT_message", 
			IForcedShutdownMessageProvider.ShutdownReason.PiratedSoftware => "REGISTRATION_ERROR_PIRATED_SOFTWARE_ALERT_message", 
			_ => "REGISTRATION_WATERMARK_ALERT_message", 
		};
	}

	private static string GetShutdownMessage(IForcedShutdownMessageProvider.ShutdownReason reason)
	{
		return reason switch
		{
			IForcedShutdownMessageProvider.ShutdownReason.HostsFile => "REGISTRATION_HOSTS_FILE_ALERT_info", 
			IForcedShutdownMessageProvider.ShutdownReason.SystemTime => "REGISTRATION_ERROR_TIME_DISCREPANCY_ALERT_info", 
			IForcedShutdownMessageProvider.ShutdownReason.PiratedSoftware => "REGISTRATION_ERROR_PIRATED_SOFTWARE_ALERT_info", 
			_ => "REGISTRATION_WATERMARK_ALERT_info", 
		};
	}

	private static string GetShutdownConfirmationButton(IForcedShutdownMessageProvider.ShutdownReason reason)
	{
		return reason switch
		{
			IForcedShutdownMessageProvider.ShutdownReason.HostsFile => "REGISTRATION_HOSTS_FILE_ALERT_QUIT_title", 
			IForcedShutdownMessageProvider.ShutdownReason.SystemTime => "REGISTRATION_ERROR_TIME_DISCREPANCY_ALERT_QUIT_title", 
			IForcedShutdownMessageProvider.ShutdownReason.PiratedSoftware => "REGISTRATION_ERROR_PIRATED_SOFTWARE_ALERT_QUIT_title", 
			_ => "REGISTRATION_WATERMARK_ALERT_QUIT_title", 
		};
	}

	private static ForceQuitReason GetAnalyticReason(IForcedShutdownMessageProvider.ShutdownReason reason)
	{
		return reason switch
		{
			IForcedShutdownMessageProvider.ShutdownReason.HostsFile => ForceQuitReason.HostsFile, 
			IForcedShutdownMessageProvider.ShutdownReason.SystemTime => ForceQuitReason.SystemTime, 
			IForcedShutdownMessageProvider.ShutdownReason.PiratedSoftware => ForceQuitReason.PiratedSoftware, 
			_ => ForceQuitReason.Watermark, 
		};
	}
}
