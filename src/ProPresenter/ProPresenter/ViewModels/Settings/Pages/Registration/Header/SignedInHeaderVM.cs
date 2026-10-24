using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.Header;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class SignedInHeaderVM : ObservableObject, ISignedInHeaderVM, IHeaderVM, INotifyPropertyChanged, IDisposable
{
	private readonly IRegistrationStateProvider _registrationProvider;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Icon", "OrganizationLogo")]
	private readonly IProvideOrganizationIcon _iconProvider;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? copyOrganizationIdCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ImageSource? OrganizationLogo => _iconProvider.Icon;

	public string OrganizationName { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CopyOrganizationIdCommand => copyOrganizationIdCommand ?? (copyOrganizationIdCommand = new RelayCommand(CopyOrganizationId));

	public SignedInHeaderVM(SubscribedState state, IRegistrationStateProvider registrationProvider, IProvideOrganizationIcon iconProvider)
	{
		OrganizationName = state.OrganizationName;
		_registrationProvider = registrationProvider;
		_iconProvider = iconProvider;
		AddPropertyLinks();
	}

	[RelayCommand]
	public void CopyOrganizationId()
	{
		Clipboard.SetText(_registrationProvider.OrganizationId);
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
	private void _iconProvider_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Icon")
		{
			OnPropertyChanged("OrganizationLogo");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_iconProvider.PropertyChanged += _iconProvider_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_iconProvider.PropertyChanged -= _iconProvider_PropertyChanged;
	}
}
