using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

public class UnregisteredProPresenterSectionVM : ObservableObject, IUnregisteredProPresenterSectionVM, IProPresenterSectionVM, INotifyPropertyChanged
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly bool _isSubscribed;

	private readonly Uri _activateUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? activateCommand;

	public IRegistrationUnlockCodeVM UnlockCodeVM { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ActivateCommand => activateCommand ?? (activateCommand = new RelayCommand(Activate, CanActivate));

	public UnregisteredProPresenterSectionVM(IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, IRegistrationUnlockCodeVM registrationUnlockCodeVM, bool isSubscribed)
	{
		_hyperlinkService = hyperlinkService;
		UnlockCodeVM = registrationUnlockCodeVM;
		_isSubscribed = isSubscribed;
		_activateUri = new Uri(registrationWebResourceService.GetSignIn());
	}

	[RelayCommand(CanExecute = "CanActivate")]
	private void Activate()
	{
		_hyperlinkService.Open(_activateUri);
	}

	private bool CanActivate()
	{
		return _isSubscribed;
	}
}
