using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.Registration.Services;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProContent;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Extensions;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Registration;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_userAvatarSubscription", "_headerVM" })]
public class RegistrationMainPageVM : ObservableObject, IRegistrationMainPageVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem, IProvideOrganizationIcon, IDisposable
{
	private readonly ILocalization _localization;

	private readonly IRegistrationSubpageVMFactory _registrationSubpageVMFactory;

	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Registration", "ListItemSubscript")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Registration", "ListItemTitle")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("Registration", "UpdateHeader")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Registration", "ProPresenter")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Registration", "ProContent")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Registration", "Footer")]
	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IDisposable _userAvatarSubscription;

	private IHeaderVM _headerVM;

	[ObservableProperty]
	private ImageSource? _icon;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? refreshCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public string Name { get; }

	public string ListItemTitle => GetListItemTitle();

	public string ListItemSubscript => GetListItemSubscript();

	public IHeaderVM Header => _headerVM;

	public IProPresenterSectionVM ProPresenter => GetProPresenter();

	public IProContentSectionVM ProContent => _registrationSubpageVMFactory.GetProContent(_registrationStateProvider.Registration.ProContent, _registrationStateProvider.Registration.ProPresenter is IRegisteredState);

	public IFooterVM Footer
	{
		get
		{
			ISubscriptionState subscriptionState = _registrationStateProvider.Registration.SubscriptionState;
			if (!(subscriptionState is UnsubscribedState))
			{
				if (subscriptionState is global::ProPresenter.DO.Registration.State.Subscription.SubscribedState subscribedState)
				{
					return GetSubscribedFooter(subscribedState);
				}
				return _registrationSubpageVMFactory.GetFooter_Undetermined();
			}
			return _registrationSubpageVMFactory.GetFooter_SignedOut(_registrationStateProvider.Registration.ProPresenter.IsRegistered);
		}
	}

	public ISettingsItemVM? Parent => null;

	public Brush? Background => null;

	public bool IsNavigable => true;

	public bool CanExit => true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ImageSource? Icon
	{
		get
		{
			return _icon;
		}
		set
		{
			if (!EqualityComparer<ImageSource>.Default.Equals(_icon, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Icon);
				_icon = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Icon);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RefreshCommand => refreshCommand ?? (refreshCommand = new RelayCommand(Refresh));

	public RegistrationMainPageVM(ILocalization localization, IRegistrationStateProvider registrationStateProvider, IRegistrationSubpageVMFactory registrationSubpageVMFactory, IRegistrationOperationFactory registrationOperationFactory, ISettingsSearchFactory settingsSearchFactory, IUserAvatarProvider userAvatarProvider)
	{
		Name = localization.Get("SETTINGS_ACCOUNT_PAGE_title");
		_localization = localization;
		_registrationStateProvider = registrationStateProvider;
		_registrationSubpageVMFactory = registrationSubpageVMFactory;
		_registrationOperationFactory = registrationOperationFactory;
		_userAvatarSubscription = userAvatarProvider.Subscribe(delegate(ImageSource value)
		{
			Icon = value;
		});
		_headerVM = GetHeader();
		AddPropertyLinks();
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_SIGN_IN_label", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_SIGN_IN_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_SIGN_UP_BUTTON_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_GROUP_PROPRESENTER_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_CURRENT_SEAT_STATE_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_REGISTER_ENTERING_UNLOCK_CODE_label", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_GROUP_PROCONTENT_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_ACCOUNT_ACCOUNT_TYPE_label", this, isComponent: true));
	}

	[RelayCommand]
	private void Refresh()
	{
		_registrationOperationFactory.Refresh();
	}

	private IProPresenterSectionVM GetProPresenter()
	{
		IRegistrationState proPresenter = _registrationStateProvider.Registration.ProPresenter;
		if (!(proPresenter is CodeState state))
		{
			if (!(proPresenter is global::ProPresenter.DO.Registration.State.ProPresenter.SubscribedState state2))
			{
				if (proPresenter is UnregisteredState)
				{
					return _registrationSubpageVMFactory.GetProPresenter_Unregistered(_registrationStateProvider.Registration.SubscriptionState is global::ProPresenter.DO.Registration.State.Subscription.SubscribedState);
				}
				return _registrationSubpageVMFactory.GetProPresenter_Undetermined();
			}
			return _registrationSubpageVMFactory.GetProPresenter_Subscribed(state2);
		}
		return _registrationSubpageVMFactory.GetProPresenter_RegistrationCode(state);
	}

	private string GetListItemSubscript()
	{
		return _registrationStateProvider.ToItemSubtitle(_localization);
	}

	private string GetListItemTitle()
	{
		return _registrationStateProvider.ToItemTitle(_localization);
	}

	private IHeaderVM GetHeader()
	{
		if (_registrationStateProvider.Registration.ProPresenter is CodeState)
		{
			return _registrationSubpageVMFactory.GetHeader_RegisteredWithCode();
		}
		ISubscriptionState subscriptionState = _registrationStateProvider.Registration.SubscriptionState;
		if (!(subscriptionState is global::ProPresenter.DO.Registration.State.Subscription.SubscribedState state))
		{
			if (subscriptionState is UnsubscribedState)
			{
				return _registrationSubpageVMFactory.GetHeader_SignedOut();
			}
			return _registrationSubpageVMFactory.GetHeader_Undetermined();
		}
		return _registrationSubpageVMFactory.GetHeader_SignedIn(state, this);
	}

	public void PromptUnableToExit()
	{
		throw new InvalidOperationException();
	}

	private IFooterVM GetSubscribedFooter(global::ProPresenter.DO.Registration.State.Subscription.SubscribedState subscribedState)
	{
		if (!(_registrationStateProvider.Registration.ProPresenter is global::ProPresenter.DO.Registration.State.ProPresenter.SubscribedState subscribedState2))
		{
			RegistrationState registrationState = (_registrationStateProvider.Registration.ProPresenter.IsRegistered ? RegistrationState.RegisteredLegacyLicense : RegistrationState.NotRegistered);
			return _registrationSubpageVMFactory.GetFooter_SignedIn(subscribedState, registrationState, isProPresenterRegisteredWithSubscription: false);
		}
		RegistrationState registrationState2 = (subscribedState2.IsTryoutLicense ? RegistrationState.RegisteredTrialLicense : RegistrationState.RegisteredSubscription);
		return _registrationSubpageVMFactory.GetFooter_SignedIn(subscribedState, registrationState2, subscribedState2.SeatInfo.IsActive);
	}

	private void UpdateHeader()
	{
		_headerVM.Dispose();
		_headerVM = GetHeader();
		OnPropertyChanged("Header");
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_userAvatarSubscription.Dispose();
			_headerVM.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _registrationStateProvider_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Registration")
		{
			OnPropertyChanged("ListItemSubscript");
			OnPropertyChanged("ListItemTitle");
			UpdateHeader();
			OnPropertyChanged("ProPresenter");
			OnPropertyChanged("ProContent");
			OnPropertyChanged("Footer");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_registrationStateProvider.PropertyChanged += _registrationStateProvider_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_registrationStateProvider.PropertyChanged -= _registrationStateProvider_PropertyChanged;
	}
}
