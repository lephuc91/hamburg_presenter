using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Common.SourceGenerator.Attributes;
using Pro.UI.Themes;
using Pro.Web.Services;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.Header;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class RegisteredWithCodeHeaderVM : ObservableObject, IRegisteredWithCodeHeaderVM, IHeaderVM, INotifyPropertyChanged, IDisposable
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _learnMoreUri;

	private readonly Uri _migrateUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? learnMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? migrateCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ImageSource? OrganizationLogo => Icons.GetIcon(Icons.SettingsRegistrationSignedOut);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand LearnMoreCommand => learnMoreCommand ?? (learnMoreCommand = new RelayCommand(LearnMore));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand MigrateCommand => migrateCommand ?? (migrateCommand = new RelayCommand(Migrate));

	public RegisteredWithCodeHeaderVM(IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
	{
		_hyperlinkService = hyperlinkService;
		_learnMoreUri = new Uri(registrationWebResourceService.GetRenewedVisionAccountDiscoverSubscription());
		_migrateUri = new Uri(registrationWebResourceService.GetUpgradeToSubscription());
	}

	[RelayCommand]
	private void LearnMore()
	{
		_hyperlinkService.Open(_learnMoreUri);
	}

	[RelayCommand]
	private void Migrate()
	{
		_hyperlinkService.Open(_migrateUri);
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
		}
	}
}
