using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Actions.Capture;

public sealed class CaptureStart : ObservableObject, ICapture, INotifyPropertyChanged
{
	private readonly ICapturePresetCollection _presets;

	private readonly ICaptureValidator _validator;

	[ObservableProperty]
	private Identifier _presetIdentifier = Identifier.Empty;

	public CaptureType CaptureType => CaptureType.Start;

	public bool IsValid => _validator?.GetIsValid(this) ?? true;

	public UndoStack UndoStack { get; set; } = new UndoStack();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Identifier PresetIdentifier
	{
		get
		{
			return _presetIdentifier;
		}
		[MemberNotNull("_presetIdentifier")]
		set
		{
			if (!EqualityComparer<Identifier>.Default.Equals(_presetIdentifier, value))
			{
				Identifier presetIdentifier = _presetIdentifier;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PresetIdentifier);
				_presetIdentifier = value;
				OnPresetIdentifierChanged(presetIdentifier, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PresetIdentifier);
			}
		}
	}

	public event System.Action? DataModified;

	public CaptureStart(ICapturePresetCollection presets, ICaptureValidator validator)
	{
		_validator = validator;
		_validator.IsValidInvalidated += delegate
		{
			OnPropertyChanged("IsValid");
		};
		_presets = presets;
		_presets.PresetRenamed += Presets_PresetRenamed;
	}

	private void Presets_PresetRenamed(ICapturePreset preset)
	{
		if (PresetIdentifier.ID == preset.ID)
		{
			PresetIdentifier = new Identifier(preset.ID, preset.Name);
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType action)
	{
		if (action.Start != null)
		{
			PresetIdentifier = ((action.Start.PresetIdentification == null || action.Start.PresetIdentification.ParameterUuid == null) ? Identifier.Empty : new Identifier(action.Start.PresetIdentification));
		}
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType action)
	{
		action.Start = new Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType.Types.CaptureStart
		{
			PresetIdentification = ((PresetIdentifier == Identifier.Empty) ? null : PresetIdentifier.Serialize())
		};
	}

	public void Cleanup()
	{
		_presets.PresetRenamed -= Presets_PresetRenamed;
	}

	public void CopyProperties(ICapture other)
	{
		if (other is CaptureStart captureStart)
		{
			captureStart.PresetIdentifier = PresetIdentifier?.Clone() ?? new Identifier(Guid.Empty, string.Empty);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnPresetIdentifierChanged(Identifier? oldValue, Identifier newValue)
	{
		OnDataModified();
		OnPropertyChanged("IsValid");
		UndoStack?.Commit(UndoActionTypes.ActionCaptureStartSetPreset.ToAction(), this, "PresetIdentifier", oldValue, newValue);
	}
}
