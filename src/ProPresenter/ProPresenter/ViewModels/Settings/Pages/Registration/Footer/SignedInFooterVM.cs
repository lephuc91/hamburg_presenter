using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Web.Services;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.Registration.UserInteraction;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.Footer;

public class SignedInFooterVM : ObservableObject, ISignedInFooterVM, IFooterVM, INotifyPropertyChanged
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly IRegistrationUserDialogService _registrationUserDialogService;

	private readonly SubscribedState _state;

	private readonly bool _isProPresenterRegisteredWithSubscription;

	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	private readonly Uri _manageAccountUri;

	private readonly Uri _helpUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? signOutCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? manageAccountCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? helpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SignOutCommand => signOutCommand ?? (signOutCommand = new AsyncRelayCommand(SignOut, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ManageAccountCommand => manageAccountCommand ?? (manageAccountCommand = new RelayCommand(ManageAccount));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand HelpCommand => helpCommand ?? (helpCommand = new RelayCommand(Help));

	public SignedInFooterVM(IRegistrationOperationFactory registrationOperationFactory, IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService, IRegistrationUserDialogService registrationUserDialogService, SubscribedState state, RegistrationState registrationState, bool isProPresenterRegisteredWithSubscription)
	{
		_hyperlinkService = hyperlinkService;
		_registrationUserDialogService = registrationUserDialogService;
		_state = state;
		_isProPresenterRegisteredWithSubscription = isProPresenterRegisteredWithSubscription;
		_registrationOperationFactory = registrationOperationFactory;
		_manageAccountUri = new Uri(registrationWebResourceService.GetManageAccount());
		_helpUri = new Uri(registrationWebResourceService.GetAccountsKnowledgeBase(registrationState switch
		{
			RegistrationState.NotRegistered => AccountState.SignedInInactiveSubscription, 
			RegistrationState.RegisteredLegacyLicense => AccountState.SignedInWithLegacyLicense, 
			RegistrationState.RegisteredTrialLicense => AccountState.SignedInTrialSubscription, 
			_ => AccountState.SignedInActiveSubscription, 
		}));
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	public async Task SignOut()
	{
		if (!_isProPresenterRegisteredWithSubscription || _registrationUserDialogService.DoesUserReallyWantToSignOut(_state.OrganizationName))
		{
			await _registrationOperationFactory.Signout();
		}
	}

	[RelayCommand]
	public void ManageAccount()
	{
		_hyperlinkService.Open(_manageAccountUri);
	}

	[RelayCommand]
	public void Help()
	{
		_hyperlinkService.Open(_helpUri);
	}
}
