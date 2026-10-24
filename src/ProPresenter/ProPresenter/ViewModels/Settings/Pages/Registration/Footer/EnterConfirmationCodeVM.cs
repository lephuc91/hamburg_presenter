using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.UI.ViewModels.Settings.Pages.Registration.Footer;

namespace ProPresenter.ViewModels.Settings.Pages.Registration.Footer;

public class EnterConfirmationCodeVM : ObservableObject, IEnterConfirmationCodeVM, INotifyPropertyChanged
{
	private readonly IRegistrationOperationFactory _operationFactory;

	[ObservableProperty]
	private bool _isVisible;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("SubmitCommand")]
	private string _confirmationCode = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cancelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? submitCommand;

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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ConfirmationCode
	{
		get
		{
			return _confirmationCode;
		}
		[MemberNotNull("_confirmationCode")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_confirmationCode, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ConfirmationCode);
				_confirmationCode = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ConfirmationCode);
				SubmitCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CancelCommand => cancelCommand ?? (cancelCommand = new RelayCommand(Cancel));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SubmitCommand => submitCommand ?? (submitCommand = new AsyncRelayCommand(Submit, CanSubmit, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public EnterConfirmationCodeVM(IRegistrationOperationFactory operationFactory)
	{
		_operationFactory = operationFactory;
	}

	[RelayCommand]
	private void Cancel()
	{
		IsVisible = false;
	}

	[RelayCommand(CanExecute = "CanSubmit", FlowExceptionsToTaskScheduler = true)]
	private async Task Submit()
	{
		await _operationFactory.Activate(ConfirmationCode);
		IsVisible = false;
	}

	private bool CanSubmit()
	{
		return !string.IsNullOrEmpty(ConfirmationCode);
	}
}
