using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using ProPresenter.DO.Notifications;
using ProPresenter.UI.ViewModels.Notification;

namespace ProPresenter.ViewModels.Notification;

public class NotificationVM : ObservableObject, INotificationVM, INotifyPropertyChanged
{
	private readonly INotification _model;

	private readonly IHyperlinkService _hyperlinkService;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showLinkCommand;

	public Guid Id => _model.Id;

	public string Header => _model.Header;

	public string Body => _model.Body;

	public string UrlDisplayText => _model.UrlDisplayText;

	public DateTimeOffset CreatedAt => _model.CreatedAt.ToLocalTime();

	public bool IsRead => _model.IsRead;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowLinkCommand => showLinkCommand ?? (showLinkCommand = new RelayCommand(ShowLink));

	public NotificationVM(INotification model, IHyperlinkService hyperlinkService)
	{
		_model = model;
		_hyperlinkService = hyperlinkService;
	}

	[RelayCommand]
	private void ShowLink()
	{
		if (Uri.TryCreate(_model.Url, UriKind.RelativeOrAbsolute, out Uri result))
		{
			_hyperlinkService.Open(result);
		}
	}
}
