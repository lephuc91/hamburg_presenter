using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions.Capture;

public sealed class CaptureStop : ObservableObject, ICapture, INotifyPropertyChanged
{
	[ObservableProperty]
	private bool _showAlertBeforeStopping = true;

	private readonly ICaptureValidator _validator;

	public CaptureType CaptureType => CaptureType.Stop;

	public bool IsValid => _validator.GetIsValid(this);

	public UndoStack UndoStack { get; set; } = new UndoStack();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowAlertBeforeStopping
	{
		get
		{
			return _showAlertBeforeStopping;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showAlertBeforeStopping, value))
			{
				bool showAlertBeforeStopping = _showAlertBeforeStopping;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowAlertBeforeStopping);
				_showAlertBeforeStopping = value;
				OnShowAlertBeforeStoppingChanged(showAlertBeforeStopping, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowAlertBeforeStopping);
			}
		}
	}

	public event System.Action? DataModified;

	public CaptureStop(ICaptureValidator validator)
	{
		_validator = validator;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType action)
	{
		ShowAlertBeforeStopping = action?.Stop?.ShowsAlertBeforeStopping == true;
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType action)
	{
		if (action != null)
		{
			action.Stop = new Pro.SerializationInterop.RVProtoData.Action.Types.CaptureType.Types.CaptureStop
			{
				ShowsAlertBeforeStopping = ShowAlertBeforeStopping
			};
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void CopyProperties(ICapture other)
	{
		if (other is CaptureStop captureStop)
		{
			captureStop.ShowAlertBeforeStopping = ShowAlertBeforeStopping;
		}
	}

	public void Cleanup()
	{
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnShowAlertBeforeStoppingChanged(bool oldValue, bool newValue)
	{
		UndoStack?.Commit(UndoActionTypes.ActionCaptureStopShowAlert.ToAction(), this, "ShowAlertBeforeStopping", oldValue, newValue);
		OnDataModified();
	}
}
