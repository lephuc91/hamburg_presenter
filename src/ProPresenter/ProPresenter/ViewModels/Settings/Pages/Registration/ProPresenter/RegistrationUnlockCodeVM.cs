using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.ProPresenter;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.ProPresenter;

public class RegistrationUnlockCodeVM : ObservableObject, IRegistrationUnlockCodeVM, INotifyPropertyChanged
{
	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("RegisterCommand")]
	private string _registrationName = string.Empty;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("RegisterCommand")]
	private string _unlockCode = string.Empty;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("RegisterCommand")]
	private string _deviceName;

	[ObservableProperty]
	private bool _isVisible;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? registerCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cancelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string RegistrationName
	{
		get
		{
			return _registrationName;
		}
		[MemberNotNull("_registrationName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_registrationName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.RegistrationName);
				_registrationName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.RegistrationName);
				RegisterCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string UnlockCode
	{
		get
		{
			return _unlockCode;
		}
		[MemberNotNull("_unlockCode")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_unlockCode, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.UnlockCode);
				_unlockCode = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.UnlockCode);
				RegisterCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string DeviceName
	{
		get
		{
			return _deviceName;
		}
		[MemberNotNull("_deviceName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_deviceName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DeviceName);
				_deviceName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DeviceName);
				RegisterCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isVisible, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsVisible);
				_isVisible = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RegisterCommand => registerCommand ?? (registerCommand = new AsyncRelayCommand(Register, CanRegister, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CancelCommand => cancelCommand ?? (cancelCommand = new RelayCommand(Cancel));

	public RegistrationUnlockCodeVM(IRegistrationOperationFactory registrationOperationFactory, string deviceName)
	{
		_registrationOperationFactory = registrationOperationFactory;
		_deviceName = deviceName;
	}

	[RelayCommand(CanExecute = "CanRegister", FlowExceptionsToTaskScheduler = true)]
	private async Task Register()
	{
		IsVisible = false;
		if (await _registrationOperationFactory.RegisterWithUnlockCode(RegistrationName, UnlockCode, DeviceName))
		{
			RegistrationName = string.Empty;
			UnlockCode = string.Empty;
		}
	}

	private bool CanRegister()
	{
		if (!string.IsNullOrEmpty(RegistrationName) && !string.IsNullOrEmpty(UnlockCode))
		{
			return !string.IsNullOrEmpty(DeviceName);
		}
		return false;
	}

	[RelayCommand]
	private void Cancel()
	{
		IsVisible = false;
	}
}
