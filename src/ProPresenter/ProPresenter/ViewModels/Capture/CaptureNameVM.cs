using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Nullability;

namespace ProPresenter.ViewModels.Capture;

public class CaptureNameVM : ObservableObject, ICaptureNameVM, INotifyPropertyChanged
{
	private readonly ICapturePrompt _capturePrompt;

	private Predicate<string> _isNameUnique;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("SetPresetNameCommand")]
	private string _presetName = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? setPresetNameCommand;

	private bool CanSetPresetName
	{
		get
		{
			if (_isNameUnique != null)
			{
				return _isNameUnique(PresetName);
			}
			return true;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PresetName
	{
		get
		{
			return _presetName;
		}
		[MemberNotNull("_presetName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_presetName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PresetName);
				_presetName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PresetName);
				SetPresetNameCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SetPresetNameCommand => setPresetNameCommand ?? (setPresetNameCommand = new RelayCommand(SetPresetName, () => CanSetPresetName));

	public CaptureNameVM(ICapturePrompt capturePrompt, Predicate<string> isNameUnique)
	{
		_capturePrompt = capturePrompt;
		_isNameUnique = isNameUnique;
	}

	[RelayCommand(CanExecute = "CanSetPresetName")]
	private void SetPresetName()
	{
		_capturePrompt.ClosePresetNameDialog();
	}

	public bool TryGetPresetName(out string presetName, string? nameValue = "")
	{
		if (!nameValue.NullableIsNullOrEmpty())
		{
			PresetName = nameValue;
		}
		bool result = _capturePrompt.ShowPresetNameDialog(this);
		presetName = PresetName;
		PresetName = "";
		return result;
	}
}
