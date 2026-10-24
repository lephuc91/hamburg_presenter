using System;
using System.Collections.Generic;
using System.Windows;
using Pro.Common.HTTP;
using Pro.Common.HTTP.Results;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.UI.DialogService;
using Pro.Web.Services;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Consumer.Model.Result;

namespace ProPresenter.ViewModels.ProContent.Dialog;

public class ProContentDownloadFailedDialogService : IProContentDownloadFailedDialogService
{
	private readonly ILocalization _localization;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	private readonly IHyperlinkService _hyperlinkService;

	public ProContentDownloadFailedDialogService(ILocalization localization, IRegistrationWebResourceService registrationWebResourceService, IHyperlinkService hyperlinkService)
	{
		_localization = localization;
		_registrationWebResourceService = registrationWebResourceService;
		_hyperlinkService = hyperlinkService;
	}

	public void ShowInternetUnavailable()
	{
		MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
		{
			Heading = _localization.Get("PRO_CONTENT_MEDIA_BIN_ERROR_DISCONNECTED_title"),
			Message = _localization.Get("PRO_CONTENT_MEDIA_BIN_ERROR_DISCONNECTED_text")
		}, new global::_003C_003Ez__ReadOnlySingleElementList<ButtonDescriptor>(new ButtonDescriptor(_localization.Get("GLOBAL_OK_BUTTON_title"))), ProContentDialogService.ProContentLogo, null);
	}

	public void ShowNotSignedIn()
	{
		MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MarkdownSubscriptDialogContent
		{
			Heading = _localization.Get("PRO_CONTENT_MEDIA_BIN_UNAUTHORIZED_DOWNLOAD_message"),
			Message = _localization.Get("PRO_CONTENT_MEDIA_BIN_UNAUTHORIZED_DOWNLOAD_text"),
			Markdown = _localization.Get("PRO_CONTENT_MEDIA_BIN_NOT_SIGNED_IN_DOWNLOAD_text", new object[1] { _registrationWebResourceService.GetSignIn() })
		}, new global::_003C_003Ez__ReadOnlyArray<ButtonDescriptor>(new ButtonDescriptor[2]
		{
			new ButtonDescriptor(_localization.Get("GLOBAL_CANCEL_BUTTON_title")),
			new ButtonDescriptor(_localization.Get("PRO_CONTENT_MEDIA_BIN_SIGN_UP_BUTTON_text"), IsDefault: true, IsCancel: false, delegate
			{
				_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetSignUp()));
			})
		}), ProContentDialogService.ProContentLogo, null);
	}

	public void Show(ProPresenter.DO.ProContent.Consumer.Model.Result.IRequestResult result)
	{
		if (!(result is Pro.Common.HTTP.Results.ErrorResult))
		{
			RedirectResult redirectResult = result as RedirectResult;
			if ((object)redirectResult != null)
			{
				List<ButtonDescriptor> buttons = new List<ButtonDescriptor>
				{
					new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title")),
					new ButtonDescriptor(LocalizedStrings.Get("PRO_CONTENT_MEDIA_BIN_DOWNLOAD_UPGRADE_title"), IsDefault: true, IsCancel: false, delegate
					{
						ProcessHelper.StartProcess(redirectResult.RedirectUrl.ToString());
					})
				};
				MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
				{
					Heading = LocalizedStrings.Get("PRO_CONTENT_MEDIA_BIN_REQUIRES_PREMIUM_message"),
					Message = LocalizedStrings.Get("PRO_CONTENT_MEDIA_BIN_REQUIRES_PREMIUM_info")
				}, buttons, ProContentDialogService.ProContentLogo, null);
			}
		}
		else
		{
			MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
			{
				Heading = LocalizedStrings.Get("PRO_CONTENT_MEDIA_BIN_ERROR_DOWNLOAD_title"),
				Message = LocalizedStrings.Get("PRO_CONTENT_MEDIA_BIN_ERROR_DOWNLOAD_text")
			}, new global::_003C_003Ez__ReadOnlySingleElementList<ButtonDescriptor>(new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_OK_BUTTON_title"))), ProContentDialogService.ProContentLogo, null);
		}
	}
}
