using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Web.Services;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.Header;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class SignedOutHeaderVM : ObservableObject, ISignedOutHeaderVM, IHeaderVM, INotifyPropertyChanged, IDisposable
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly Uri _signInUri;

	private readonly Uri _signUpUri;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signInCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? signUpCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignInCommand => signInCommand ?? (signInCommand = new RelayCommand(SignIn));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SignUpCommand => signUpCommand ?? (signUpCommand = new RelayCommand(SignUp));

	public SignedOutHeaderVM(IHyperlinkService hyperlinkService, IRegistrationWebResourceService registrationWebResourceService)
	{
		_hyperlinkService = hyperlinkService;
		_signInUri = new Uri(registrationWebResourceService.GetSignIn());
		_signUpUri = new Uri(registrationWebResourceService.GetSignUp());
	}

	[RelayCommand]
	private void SignIn()
	{
		_hyperlinkService.Open(_signInUri);
	}

	[RelayCommand]
	private void SignUp()
	{
		_hyperlinkService.Open(_signUpUri);
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
