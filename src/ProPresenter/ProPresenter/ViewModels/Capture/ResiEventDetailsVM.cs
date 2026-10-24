using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Localization;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.ViewModels.Capture;

public class ResiEventDetailsVM : ObservableObject
{
	private readonly IPeriodicTimer _timer;

	private readonly ICloseableDialog _dialog;

	private int _elapsedTimeSeconds = 15;

	[ObservableProperty]
	[NotifyPropertyChangedFor("StreamButtonContent")]
	private string _name = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("StreamButtonContent")]
	private string _description = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? startStreamCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? cancelStreamCommand;

	public string StreamButtonContent => LocalizedStrings.Get("RECORDING_BUTTON_CONTEXT_MENU_START_STREAM_title") + ((_elapsedTimeSeconds < 0) ? string.Empty : $" ({_elapsedTimeSeconds})");

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Name
	{
		get
		{
			return _name;
		}
		[MemberNotNull("_name")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.StreamButtonContent);
				_name = value;
				OnNameChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.StreamButtonContent);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Description
	{
		get
		{
			return _description;
		}
		[MemberNotNull("_description")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_description, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Description);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.StreamButtonContent);
				_description = value;
				OnDescriptionChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Description);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.StreamButtonContent);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand StartStreamCommand => startStreamCommand ?? (startStreamCommand = new RelayCommand(StartStream));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CancelStreamCommand => cancelStreamCommand ?? (cancelStreamCommand = new RelayCommand(CancelStream));

	public ResiEventDetailsVM(ITimerFactory timerFactory, ICloseableDialog dialog)
	{
		_timer = timerFactory.CreatePeriodicDispatched(TimeSlice.FromSeconds(1.0), OnTimerTick);
		_timer.Start();
		_dialog = dialog;
	}

	[RelayCommand]
	private void StartStream()
	{
		Close(result: true);
	}

	[RelayCommand]
	private void CancelStream()
	{
		Close(result: false);
	}

	private void Close(bool result)
	{
		_dialog.DialogResult = result;
		_dialog.Close();
		_elapsedTimeSeconds = -1;
		_timer.Stop();
	}

	private void OnTimerTick()
	{
		_elapsedTimeSeconds--;
		if (_elapsedTimeSeconds <= 0)
		{
			StartStreamCommand.Execute(null);
		}
		OnPropertyChanged("StreamButtonContent");
	}

	private void Stop()
	{
		_timer.Stop();
		_elapsedTimeSeconds = -1;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnNameChanged(string value)
	{
		Stop();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnDescriptionChanged(string value)
	{
		Stop();
	}
}
