using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.CloudOnboarding.Model;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.CloudOnboarding;

namespace ProPresenter.ViewModels.CloudOnboarding;

public sealed class CloudOnboardingPricingVM : ObservableObject, ICloudOnboardingPricingVM, INotifyPropertyChanged
{
	private readonly ICloudOnboardingService _service;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly ICloudOnboardingShellNavigator _shell;

	private readonly IWebSourceProvider _webSource;

	[ObservableProperty]
	private bool _isBusy;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IntroMessage")]
	[NotifyPropertyChangedFor("PricingMessage")]
	[NotifyPropertyChangedFor("DisclaimerMessage")]
	[NotifyPropertyChangedFor("CurrentPlanTitle")]
	[NotifyPropertyChangedFor("CurrentPlanStorageGb")]
	[NotifyPropertyChangedFor("RecommendedPlanTitle")]
	[NotifyPropertyChangedFor("RecommendedPlanStorageGb")]
	private PricingOptionsResponse? _pricingOptions;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openLearnMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? backCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? continueWithoutCloudCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? convertToCloudCommand;

	public string IntroMessage => PricingOptions?.Data?.Messages?.Intro ?? string.Empty;

	public string PricingMessage => PricingOptions?.Data?.Messages?.Pricing ?? string.Empty;

	public string DisclaimerMessage => PricingOptions?.Data?.Messages?.Disclaimer ?? string.Empty;

	public string CurrentPlanTitle => PricingOptions?.Data?.CurrentPlan?.Title ?? string.Empty;

	public int CurrentPlanStorageGb => (PricingOptions?.Data?.CurrentPlan?.StorageGb).GetValueOrDefault();

	public string RecommendedPlanTitle => PricingOptions?.Data?.RecommendedPlan?.Title ?? string.Empty;

	public int RecommendedPlanStorageGb => (PricingOptions?.Data?.RecommendedPlan?.StorageGb).GetValueOrDefault();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsBusy
	{
		get
		{
			return _isBusy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isBusy, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsBusy);
				_isBusy = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsBusy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public PricingOptionsResponse? PricingOptions
	{
		get
		{
			return _pricingOptions;
		}
		set
		{
			if (!EqualityComparer<PricingOptionsResponse>.Default.Equals(_pricingOptions, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PricingOptions);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IntroMessage);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PricingMessage);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DisclaimerMessage);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CurrentPlanTitle);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CurrentPlanStorageGb);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.RecommendedPlanTitle);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.RecommendedPlanStorageGb);
				_pricingOptions = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PricingOptions);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IntroMessage);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PricingMessage);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DisclaimerMessage);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CurrentPlanTitle);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CurrentPlanStorageGb);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.RecommendedPlanTitle);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.RecommendedPlanStorageGb);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenLearnMoreCommand => openLearnMoreCommand ?? (openLearnMoreCommand = new RelayCommand(OpenLearnMore));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> BackCommand => backCommand ?? (backCommand = new RelayCommand<ICloseable>(Back));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> ContinueWithoutCloudCommand => continueWithoutCloudCommand ?? (continueWithoutCloudCommand = new RelayCommand<ICloseable>(ContinueWithoutCloud));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> ConvertToCloudCommand => convertToCloudCommand ?? (convertToCloudCommand = new RelayCommand<ICloseable>(ConvertToCloud));

	public CloudOnboardingPricingVM(ICloudOnboardingService service, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ICloudOnboardingShellNavigator shell)
	{
		_service = service;
		_hyperlinkService = hyperlinkService;
		_webSource = webSourceProvider;
		_shell = shell;
		PricingOptions = _service.CachedPricingOptions;
	}

	[RelayCommand]
	public void OpenLearnMore()
	{
		_hyperlinkService.Open(_webSource.UnlockCloud);
	}

	[RelayCommand]
	public void Back(ICloseable closeable)
	{
		_shell.HandleNavigationIntent(OnboardingIntent.Back, closeable);
	}

	[RelayCommand]
	public void ContinueWithoutCloud(ICloseable closeable)
	{
		_shell.HandleNavigationIntent(OnboardingIntent.Continue, closeable);
	}

	[RelayCommand]
	public void ConvertToCloud(ICloseable closeable)
	{
		_shell.HandleNavigationIntent(OnboardingIntent.Convert, closeable);
	}
}
