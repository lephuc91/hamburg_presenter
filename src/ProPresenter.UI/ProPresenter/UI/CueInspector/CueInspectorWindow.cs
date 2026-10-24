using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Commands;
using Pro.UI.Controls;
using Pro.UI.Controls.Windowing;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO.InputActionMap;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.CueInspector;

public partial class CueInspectorWindow : ChromedWindow, IComponentConnector
{
	private readonly IInputActions _inputActions;

	public static readonly DependencyProperty HideOnCloseProperty = DependencyProperty.Register("HideOnClose", typeof(bool), typeof(CueInspectorWindow), new PropertyMetadata((object)true));

	public bool HideOnClose
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideOnCloseProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideOnCloseProperty, (object)value);
		}
	}

	public CueInspectorWindow()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		_inputActions = UIServiceProvider.GetService<IInputActions>();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(CueInspectorWindow_DataContextChanged);
	}

	private void CueInspectorWindow_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		InitializeComponent();
		base.CommandBindings.Clear();
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is ICueInspectorVM cueInspectorVM)
		{
			cueInspectorVM.PropertyChanged -= CueInspectorVM_PropertyChanged;
		}
		object newValue = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		ICueInspectorVM cueInspectorVM2 = newValue as ICueInspectorVM;
		if (cueInspectorVM2 == null)
		{
			return;
		}
		cueInspectorVM2.PropertyChanged += CueInspectorVM_PropertyChanged;
		base.CommandBindings.Add(_inputActions.ProCommon.SetMediaInPoint.BindCommand, delegate
		{
			cueInspectorVM2?.CIMediaControlVM?.SetMediaInPointCommand?.Invoke();
		}, canExecute, () => !canExecute());
		base.CommandBindings.Add(_inputActions.ProCommon.SetMediaOutPoint.BindCommand, delegate
		{
			cueInspectorVM2?.CIMediaControlVM?.SetMediaOutPointCommand?.Invoke();
		}, canExecute, () => !canExecute());
		base.CommandBindings.Add(_inputActions.ProCommon.AddMediaMarker.BindCommand, delegate
		{
			cueInspectorVM2?.PlaybackMarkersVM?.AddMarkerCommand?.Invoke();
		}, canExecute, () => !canExecute());
		base.CommandBindings.Add(_inputActions.ProCommon.PlaybackJumpStart.BindCommand, delegate
		{
			cueInspectorVM2?.CIMediaControlVM?.GoToCIPositionCommand?.Invoke(parameter: true);
		}, () => cueInspectorVM2?.CIMediaControlVM?.ActiveMediaCue != null);
		base.CommandBindings.Add(_inputActions.ProCommon.PlaybackJumpEnd.BindCommand, delegate
		{
			cueInspectorVM2?.CIMediaControlVM?.GoToCIPositionCommand?.Invoke(parameter: false);
		}, () => cueInspectorVM2?.CIMediaControlVM?.ActiveMediaCue != null);
		base.CommandBindings.Add(_inputActions.ProCommon.TogglePlaybackState.BindCommand, delegate
		{
			if (cueInspectorVM2?.CIMediaControlVM?.IsPlaying == true)
			{
				cueInspectorVM2.CIMediaControlVM?.PauseCIMediaCommand?.Invoke();
			}
			else
			{
				cueInspectorVM2?.CIMediaControlVM?.PlayCIMediaCommand?.Invoke();
			}
		}, () => cueInspectorVM2?.CIMediaControlVM?.ActiveMediaCue != null);
		base.CommandBindings.Add(_inputActions.ProCommon.PlaybackJumpBack.BindCommand, delegate
		{
			if (cueInspectorVM2?.ActiveMediaCue?.MediaCue?.MediaAction?.IsAudioMedia == true || cueInspectorVM2?.CIMediaControlVM?.IsPlaying == true)
			{
				cueInspectorVM2.CIMediaControlVM?.JumpBack15SecondsCommand?.Invoke();
			}
			else
			{
				cueInspectorVM2?.CIMediaControlVM?.StepCIMediaBackwardCommand?.Invoke();
			}
		}, () => cueInspectorVM2?.CIMediaControlVM?.ActiveMediaCue != null);
		base.CommandBindings.Add(_inputActions.ProCommon.PlaybackJumpForward.BindCommand, delegate
		{
			if (cueInspectorVM2?.ActiveMediaCue?.MediaCue?.MediaAction?.IsAudioMedia == true || cueInspectorVM2?.CIMediaControlVM?.IsPlaying == true)
			{
				cueInspectorVM2.CIMediaControlVM?.JumpForward15SecondsCommand?.Invoke();
			}
			else
			{
				cueInspectorVM2?.CIMediaControlVM?.StepCIMediaForwardCommand?.Invoke();
			}
		}, () => cueInspectorVM2?.CIMediaControlVM?.ActiveMediaCue != null);
		static bool canExecute()
		{
			return !(Keyboard.FocusedElement is TextBoxBase);
		}
	}

	private void CueInspectorVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveMediaCue")
		{
			CheckSelectedTabAvailability();
		}
	}

	private void CheckSelectedTabAvailability()
	{
		if (base.DataContext is ICueInspectorVM { ActiveMediaCue: not null } cueInspectorVM && base.RightContent is FrameworkElement depObj)
		{
			BorderlessRadioToggleButton? borderlessRadioToggleButton = ((DependencyObject)(object)depObj).FindVisualChildren<BorderlessRadioToggleButton>().FirstOrDefault((BorderlessRadioToggleButton c) => c.IsChecked == true);
			if (borderlessRadioToggleButton != null && borderlessRadioToggleButton.Visibility == Visibility.Collapsed)
			{
				cueInspectorVM.ActiveTab = 0;
			}
		}
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		CueInspector?.CloseCI();
		base.Owner?.Focus();
		base.OnClosing(e);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
