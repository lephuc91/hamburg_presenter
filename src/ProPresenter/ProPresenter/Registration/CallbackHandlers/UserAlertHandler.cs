using System;
using Pro.Common.HTTP;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using Pro.Web.Services;
using ProPresenter.Registration.CallbackHandlers.Dialogs;

namespace ProPresenter.Registration.CallbackHandlers;

public class UserAlertHandler : IRegistrationCallbackHandler
{
	private readonly IRegistrationCallbackDialogProvider _dialogProvider;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	public UserAlertHandler(IRegistrationCallbackDialogProvider dialogProvider, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
	{
		_dialogProvider = dialogProvider;
		_hyperlinkService = hyperlinkService;
		_registrationWebResourceService = registrationWebResourceService;
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		return responseCallback.CallbackCase switch
		{
			Callback.CallbackOneofCase.VerificationComplete => HandleClientAlert(responseCallback.VerificationComplete.ClientAlert, responseCallback.VerificationComplete.Result, requestSender), 
			Callback.CallbackOneofCase.DownloadProgress => HandleClientAlert(responseCallback.DownloadProgress.ClientAlert, responseCallback.DownloadProgress.Status, requestSender), 
			Callback.CallbackOneofCase.UpgradesAvailable => HandleClientAlert(responseCallback.UpgradesAvailable.ClientAlert, responseCallback.UpgradesAvailable.Status, requestSender), 
			Callback.CallbackOneofCase.BibleDownloadProgress => HandleClientAlert(responseCallback.BibleDownloadProgress.ClientAlert, responseCallback.BibleDownloadProgress.Status, requestSender), 
			_ => false, 
		};
	}

	private bool HandleClientAlert(ClientAlertMessage alert, Status status, IRegistrationRequestSender sender)
	{
		switch (alert)
		{
		case ClientAlertMessage.NoNetwork:
			ShowSimpleError("GLOBAL_NO_INTERNET_CONNECTION_message", "GLOBAL_NO_INTERNET_CONNECTION_info");
			break;
		case ClientAlertMessage.InvalidLicense:
			ShowErrorAllowingToRemoveLicenseData("REGISTRATION_ERROR_ALERT_message", "REGISTRATION_ERROR_INVALID_LICENSE", sender);
			break;
		case ClientAlertMessage.CodeExpiredAlert:
			ShowSimpleError("SETTINGS_ACCOUNT_CONFIRMATION_CODE_EXPIRED_ERROR_message", "SETTINGS_ACCOUNT_CONFIRMATION_CODE_EXPIRED_ERROR_info");
			break;
		case ClientAlertMessage.CodeInvalidAlert:
			ShowSimpleError("SETTINGS_ACCOUNT_CONFIRMATION_CODE_INVALID_ERROR_message", "SETTINGS_ACCOUNT_CONFIRMATION_CODE_INVALID_ERROR_info");
			break;
		case ClientAlertMessage.BibleMissingAlert:
			ShowSimpleError("REGISTRATION_ERROR_BIBLE_NOT_FOUND_message", "REGISTRATION_ERROR_BIBLE_NOT_FOUND_info");
			break;
		case ClientAlertMessage.UnsuccessfulBibleActivationLegacy:
			ShowSimpleError("REGISTRATION_ERROR_BIBLE_ACTIVATION_MISSING_ALERT_message", "REGISTRATION_ERROR_BIBLE_ACTIVATION_MISSING_ALERT_info");
			break;
		case ClientAlertMessage.IoerrorAlert:
		case ClientAlertMessage.UnknownAlert:
			_dialogProvider.ShowError(new TextDescriptor("REGISTRATION_ERROR_ALERT_message"), new TextDescriptor("REGISTRATION_ERROR_UNKNOWN_ALERT_info", status.ToString()));
			break;
		case ClientAlertMessage.ExpiredSubscription:
			HandleExpiredSubscription(sender);
			break;
		case ClientAlertMessage.NoSeatsSubscription:
			ShowSimpleBooleanSelection("REGISTRATION_NO_SEATS_AVAILABLE_message", "REGISTRATION_NO_SEATS_AVAILABLE_info", "REGISTRATION_NO_SEATS_AVAILABLE_MANAGE_SEATS_title", "REGISTRATION_NO_SEATS_AVAILABLE_CONTINUE_WITH_WATERMARKS_title", delegate
			{
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetManageSeats()));
			});
			break;
		case ClientAlertMessage.SeatDeactivatedSubscription:
			ShowSimpleBooleanSelection("REGISTRATION_REMOTE_SEAT_DEACTIVATED_message", "REGISTRATION_REMOTE_SEAT_DEACTIVATED_info", "REGISTRATION_REMOTE_SEAT_DEACTIVATED_OPEN_ACCOUNT_SETTINGS_title", "REGISTRATION_REMOTE_SEAT_DEACTIVATED_CONTINUE_WITH_WATERMARKS_title", _dialogProvider.ShowSettings);
			break;
		case ClientAlertMessage.UnsuccessfulActivation:
			ShowSimpleBooleanSelection("REGISTRATION_ACTIVATION_UNSUCCESSFUL_message", "REGISTRATION_ACTIVATION_UNSUCCESSFUL_info", "REGISTRATION_ACTIVATION_OPEN_ACCOUNT_SETTINGS_title", "REGISTRATION_ACTIVATION_CONTINUE_WITHOUT_ACTIVATING_title", _dialogProvider.ShowSettings);
			break;
		case ClientAlertMessage.NoBibleCopies:
			HandleNoBibleCopies();
			break;
		case ClientAlertMessage.BibleNotPurchasedLegacy:
			HandleBibleNotPurchased(_dialogProvider.ShowInAppBibleStore);
			break;
		case ClientAlertMessage.BibleNotPurchasedSubscription:
			HandleBibleNotPurchased(delegate
			{
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetPurchaseBibles()));
			});
			break;
		case ClientAlertMessage.UnsuccessfulBibleActivationSubscription:
			ShowSimpleBooleanSelection("REGISTRATION_ERROR_BIBLE_ACTIVATION_MISSING_ALERT_message", "REGISTRATION_ERROR_BIBLE_ACTIVATION_MISSING_ALERT_info", "REGISTRATION_ERROR_MANAGE_BIBLES_title", "GLOBAL_CANCEL_BUTTON_title", delegate
			{
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetManageBibles()));
			});
			break;
		case ClientAlertMessage.NoSeatsLegacy:
			HandleNoSeatsAvailableLegacy(sender);
			break;
		case ClientAlertMessage.ExpiredLicenseLegacy:
			ShowSimpleBooleanSelection("REGISTRATION_TRIAL_RENTAL_LICENSE_EXPIRED_message", "REGISTRATION_TRIAL_RENTAL_LICENSE_EXPIRED_info", "REGISTRATION_TRIAL_RENTAL_LICENSE_EXPIRED_PURCHASE_BUTTON_title", "REGISTRATION_TRIAL_RENTAL_LICENSE_EXPIRED_CONTINUE_WITH_WATERMARKS_BUTTON_title", delegate
			{
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetUpgradeToSubscription()));
			});
			break;
		case ClientAlertMessage.DeviceSignedOutSubscription:
			ShowSimpleBooleanSelection("REGISTRATION_REMOTE_SIGNED_OUT_message", "REGISTRATION_REMOTE_SIGNED_OUT_info", "REGISTRATION_REMOTE_SIGNED_OUT_OPEN_ACCOUNT_SETTINGS_title", "REGISTRATION_REMOTE_SIGNED_OUT_CONTINUE_WITH_WATERMARKS_title", _dialogProvider.ShowSettings);
			break;
		}
		return true;
	}

	private void ShowSimpleError(string title, string message)
	{
		_dialogProvider.ShowError(new TextDescriptor(title), new TextDescriptor(message));
	}

	private void ShowErrorAllowingToRemoveLicenseData(string title, string message, IRegistrationRequestSender requestSender)
	{
		_dialogProvider.ShowErrorWithCheckbox(new TextDescriptor(title), new TextDescriptor(message), new TextDescriptor("REGISTRATION_ERROR_LOAD_DATA_REMOVE_DATA_title"), delegate(bool result)
		{
			if (result)
			{
				requestSender.Send(new Pro.SerializationInterop.RVProtoData.Registration.Request
				{
					Unregister = new Unregister()
				});
			}
		});
	}

	private void ShowSimpleBooleanSelection(string title, string message, string trueButtonKey, string falseButtonKey, Action onTrue)
	{
		_dialogProvider.ShowDialog(new TextDescriptor(title), new TextDescriptor(message), delegate(bool result)
		{
			if (result)
			{
				onTrue();
			}
		}, new ButtonDescriptor<bool>(trueButtonKey, true), new ButtonDescriptor<bool>(falseButtonKey, false));
	}

	private void HandleExpiredSubscription(IRegistrationRequestSender sender)
	{
		_dialogProvider.ShowDialog(new TextDescriptor("REGISTRATION_SUBSCRIPTION_EXPIRED_message"), new TextDescriptor("REGISTRATION_SUBSCRIPTION_EXPIRED_info"), PurchaseWatermarksUnsubscribeResult.ContinueWithWatermarks, delegate(PurchaseWatermarksUnsubscribeResult continuation)
		{
			switch (continuation)
			{
			case PurchaseWatermarksUnsubscribeResult.Purchase:
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetPurchase(PurchaseOrigin.Expired)));
				break;
			case PurchaseWatermarksUnsubscribeResult.Unregister:
				sender.Send(new Pro.SerializationInterop.RVProtoData.Registration.Request
				{
					Signout = new Signout()
				});
				break;
			}
		}, new ButtonDescriptor<PurchaseWatermarksUnsubscribeResult>("REGISTRATION_SUBSCRIPTION_EXPIRED_RENEW_SUBSCRIPTION_title", PurchaseWatermarksUnsubscribeResult.Purchase), new ButtonDescriptor<PurchaseWatermarksUnsubscribeResult>("REGISTRATION_SUBSCRIPTION_EXPIRED_CONTINUE_WITH_WATERMARKS_title", PurchaseWatermarksUnsubscribeResult.ContinueWithWatermarks), new ButtonDescriptor<PurchaseWatermarksUnsubscribeResult>("REGISTRATION_SUBSCRIPTION_EXPIRED_SIGN_OUT_title", PurchaseWatermarksUnsubscribeResult.Unregister));
	}

	private void HandleNoBibleCopies()
	{
		_dialogProvider.ShowDialog(new TextDescriptor("REGISTRATION_ERROR_NO_COPIES_AVAILABLE_ALERT_message"), new TextDescriptor("REGISTRATION_ERROR_NO_COPIES_AVAILABLE_ALERT_info"), NoBiblesCopiesResult.Cancel, delegate(NoBiblesCopiesResult continuation)
		{
			switch (continuation)
			{
			case NoBiblesCopiesResult.Manage:
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetManageBibles()));
				break;
			case NoBiblesCopiesResult.Purchase:
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetPurchaseBibles()));
				break;
			}
		}, new ButtonDescriptor<NoBiblesCopiesResult>("REGISTRATION_ERROR_MANAGE_BIBLES_title", NoBiblesCopiesResult.Manage), new ButtonDescriptor<NoBiblesCopiesResult>("REGISTRATION_ERROR_PURCHASE_BIBLES_title", NoBiblesCopiesResult.Purchase), new ButtonDescriptor<NoBiblesCopiesResult>("GLOBAL_CANCEL_BUTTON_title", NoBiblesCopiesResult.Cancel));
	}

	private void HandleBibleNotPurchased(Action purchaseAction)
	{
		ShowSimpleBooleanSelection("REGISTRATION_ERROR_BIBLE_NOT_PURCHASED_ALERT_message", "REGISTRATION_ERROR_BIBLE_NOT_PURCHASED_ALERT_info", "REGISTRATION_ERROR_PURCHASE_BIBLES_title", "GLOBAL_CANCEL_BUTTON_title", purchaseAction);
	}

	private void HandleNoSeatsAvailableLegacy(IRegistrationRequestSender sender)
	{
		_dialogProvider.ShowDialog(new TextDescriptor("REGISTRATION_NO_SEATS_AVAILABLE_LEGACY_message"), new TextDescriptor("REGISTRATION_NO_SEATS_AVAILABLE_LEGACY_info"), PurchaseWatermarksUnsubscribeResult.ContinueWithWatermarks, delegate(PurchaseWatermarksUnsubscribeResult continuation)
		{
			switch (continuation)
			{
			case PurchaseWatermarksUnsubscribeResult.Purchase:
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetUpgradeToSubscription()));
				break;
			case PurchaseWatermarksUnsubscribeResult.Unregister:
				sender.Send(new Pro.SerializationInterop.RVProtoData.Registration.Request
				{
					Unregister = new Unregister()
				});
				break;
			}
		}, new ButtonDescriptor<PurchaseWatermarksUnsubscribeResult>("REGISTRATION_NO_SEATS_AVAILABLE_LEGACY_UPGRADE_TO_SUBSCRIPTION_title", PurchaseWatermarksUnsubscribeResult.Purchase), new ButtonDescriptor<PurchaseWatermarksUnsubscribeResult>("REGISTRATION_NO_SEATS_AVAILABLE_LEGACY_CONTINUE_WITH_WATERMARKS_title", PurchaseWatermarksUnsubscribeResult.ContinueWithWatermarks), new ButtonDescriptor<PurchaseWatermarksUnsubscribeResult>("REGISTRATION_NO_SEATS_AVAILABLE_LEGACY_CANCEL_REGISTRATION_title", PurchaseWatermarksUnsubscribeResult.Unregister));
	}
}
