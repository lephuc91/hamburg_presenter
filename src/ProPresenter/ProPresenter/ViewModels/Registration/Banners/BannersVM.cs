using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Updates;
using ProPresenter.UI.ViewModels.Registration.Banners;

namespace ProPresenter.ViewModels.Registration.Banners;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class BannersVM : ObservableObject, IBannersVM, INotifyPropertyChanged, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.ActionLink("BannerMessage", "UpdateBanners")]
	private readonly IRegistrationStateProvider _registrationStateProvider;

	[Pro.Common.SourceGenerator.Attributes.ActionLink("BuildAvailable", "UpdateBanners")]
	private readonly IAppUpdateService _appUpdateService;

	private readonly ILocalization _localization;

	private readonly ICommand _openRegistrationCommand;

	[ObservableProperty]
	private IReadOnlyList<IBannerVM> _banners;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyList<IBannerVM> Banners
	{
		get
		{
			return _banners;
		}
		[MemberNotNull("_banners")]
		set
		{
			if (!EqualityComparer<IReadOnlyList<IBannerVM>>.Default.Equals(_banners, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Banners);
				_banners = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Banners);
			}
		}
	}

	public BannersVM(IRegistrationStateProvider registrationStateProvider, ILocalization localization, Action openRegistration, IAppUpdateService appUpdateService)
	{
		_registrationStateProvider = registrationStateProvider;
		_localization = localization;
		_appUpdateService = appUpdateService;
		_openRegistrationCommand = new RelayCommand(openRegistration);
		AddPropertyLinks();
		_banners = GenerateBanners();
	}

	private void UpdateBanners()
	{
		Banners = GenerateBanners();
	}

	private IReadOnlyList<IBannerVM> GenerateBanners()
	{
		List<BannerVM> list = new List<BannerVM>();
		if ((object)_appUpdateService.BuildAvailable != null)
		{
			list.Add(new BannerVM(_localization.Get("BANNER_UPDATE_AVAILABLE_title"), BannerStyle.UpdateAvailable, new RelayCommand(_appUpdateService.ShowUpdateViewer)));
		}
		if (_registrationStateProvider.BannerMessage == BannerMessage.ActivateProPresenter)
		{
			list.Add(new BannerVM(_localization.Get("BANNER_ACTIVATE_PROPRESENTER_title"), BannerStyle.Activate, _openRegistrationCommand));
		}
		return list;
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
		if (e.PropertyName == "BannerMessage")
		{
			UpdateBanners();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _appUpdateService_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "BuildAvailable")
		{
			UpdateBanners();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_registrationStateProvider.PropertyChanged += _registrationStateProvider_PropertyChanged;
		_appUpdateService.PropertyChanged += _appUpdateService_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_registrationStateProvider.PropertyChanged -= _registrationStateProvider_PropertyChanged;
		_appUpdateService.PropertyChanged -= _appUpdateService_PropertyChanged;
	}
}
