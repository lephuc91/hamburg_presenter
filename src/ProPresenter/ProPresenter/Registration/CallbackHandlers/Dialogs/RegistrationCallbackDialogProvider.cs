using System;
using System.Linq;
using System.Windows;
using Pro.Common.Dispatcher;
using Pro.Common.Startup;
using Pro.Common.Time;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.Web;
using ProPresenter.UI.Registration;
using ProPresenter.ViewModels.Registration;

namespace ProPresenter.Registration.CallbackHandlers.Dialogs;

public class RegistrationCallbackDialogProvider : IRegistrationCallbackDialogProvider
{
	private readonly IUiDispatcher _uiDispatcher;

	private readonly ICurrentTime _currentTime;

	private readonly Action _showSettings;

	private readonly IAfterStartupCompleteQueue _afterStartupCompleteQueue;

	private readonly IWebSourceProvider _webSourceProvider;

	public RegistrationCallbackDialogProvider(IUiDispatcher uiDispatcher, ICurrentTime currentTime, Action showSettings, IAfterStartupCompleteQueue afterStartupCompleteQueue, IWebSourceProvider webSourceProvider)
	{
		_uiDispatcher = uiDispatcher;
		_currentTime = currentTime;
		_showSettings = showSettings;
		_afterStartupCompleteQueue = afterStartupCompleteQueue;
		_webSourceProvider = webSourceProvider;
	}

	public void ShowExpiration(int days)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("REGISTRATION_WARNING_ALERT_message"), LocalizedStrings.Get("REGISTRATION_WARNING_EXPIRING_IN_N_DAYS_info", new object[1] { _currentTime.Now.AddDays(days).ToString("d") }));
		});
	}

	public bool ShowInAppRenewalStore()
	{
		return ShowInAppStore(InAppStoreType.Renewal);
	}

	public void ShowInAppBibleStore()
	{
		ShowInAppStore(InAppStoreType.Bibles);
	}

	public void ShowDialog<T>(TextDescriptor title, TextDescriptor message, params ButtonDescriptor<T>[] buttons) where T : struct
	{
		ShowDialog(title, message, null, buttons);
	}

	public void ShowDialog<T>(TextDescriptor title, TextDescriptor message, Action<T>? continuation, params ButtonDescriptor<T>[] buttons) where T : struct
	{
		ShowDialog(title, message, default(T), continuation, buttons);
	}

	public void ShowDialog<T>(TextDescriptor title, TextDescriptor message, T closeResult, params ButtonDescriptor<T>[] buttons) where T : struct
	{
		ShowDialog(title, message, closeResult, null, buttons);
	}

	public void ShowDialog<T>(TextDescriptor title, TextDescriptor message, T closeResult, Action<T>? continuation, params ButtonDescriptor<T>[] buttons) where T : struct
	{
		_afterStartupCompleteQueue.Enqueue(delegate
		{
			_uiDispatcher.Invoke(delegate
			{
				MessageContent messageContent = new MessageContent();
				string key = title.Key;
				object[] parameters = title.Parameters;
				messageContent.Heading = LocalizedStrings.Get(key, parameters);
				string key2 = message.Key;
				parameters = message.Parameters;
				messageContent.Message = LocalizedStrings.Get(key2, parameters);
				return MessageDialogService.ShowDialog(null, (DependencyObject)(object)messageContent, buttons.Select(delegate(ButtonDescriptor<T> button, int index)
				{
					string key3 = button.Key;
					object[] parameters2 = button.Parameters;
					return new ButtonDescriptor(LocalizedStrings.Get(key3, parameters2), index == 0, IsCancel: false, delegate
					{
						continuation?.Invoke(button.Result);
					});
				}), null, null, canClose: true);
			});
		});
	}

	public void ShowError(TextDescriptor title, TextDescriptor message)
	{
		_uiDispatcher.InvokeAsync(delegate
		{
			string key = title.Key;
			object[] parameters = title.Parameters;
			string heading = LocalizedStrings.Get(key, parameters);
			string key2 = message.Key;
			parameters = message.Parameters;
			MessageDialogService.ShowAlert(heading, LocalizedStrings.Get(key2, parameters));
		});
	}

	public void ShowErrorWithCheckbox(TextDescriptor title, TextDescriptor message, TextDescriptor checkboxTitle, Action<bool> continuation)
	{
		_uiDispatcher.Invoke(delegate
		{
			CheckboxDialogContent checkboxDialogContent = new CheckboxDialogContent();
			string key = title.Key;
			object[] parameters = title.Parameters;
			checkboxDialogContent.Heading = LocalizedStrings.Get(key, parameters);
			string key2 = message.Key;
			parameters = message.Parameters;
			checkboxDialogContent.Message = LocalizedStrings.Get(key2, parameters);
			string key3 = checkboxTitle.Key;
			parameters = checkboxTitle.Parameters;
			checkboxDialogContent.CheckboxText = LocalizedStrings.Get(key3, parameters);
			CheckboxDialogContent checkboxDialogContent2 = checkboxDialogContent;
			MessageDialogService.ShowDialog(null, (DependencyObject)(object)checkboxDialogContent2, new ButtonDescriptor[1]
			{
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_OK_BUTTON_title"))
			}, null, null, canClose: true);
			continuation(checkboxDialogContent2.Checked);
		});
	}

	private bool ShowInAppStore(InAppStoreType storeType)
	{
		return _uiDispatcher.Invoke(delegate
		{
			PurchaseWindowVM purchaseWindowVM = new PurchaseWindowVM();
			PurchaseWindow purchaseWindow = new PurchaseWindow
			{
				DataContext = purchaseWindowVM,
				InAppLink = _webSourceProvider.GenerateLink(storeType).ToString(),
				StoreType = storeType
			};
			if (!purchaseWindow.IsVisible)
			{
				purchaseWindow.ShowDialog();
			}
			return purchaseWindowVM.IsPurchaseComplete;
		});
	}

	public void ShowSettings()
	{
		_uiDispatcher.InvokeAsync(_showSettings);
	}
}
