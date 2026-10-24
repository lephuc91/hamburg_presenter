using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.Input;

public partial class AudioInputModeSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty BehaviorModeProperty = DependencyProperty.Register("BehaviorMode", typeof(BehaviorMode), typeof(AudioInputModeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)BehaviorMode.On, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty LinkedVideoInputsProperty = DependencyProperty.Register("LinkedVideoInputs", typeof(LinkedVideoInputs), typeof(AudioInputModeSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((AudioInputModeSelector)(object)s).UpdateLinkedVideoInputCheckedState();
	}));

	public static readonly DependencyProperty VideoInputsProperty = DependencyProperty.Register("VideoInputs", typeof(IEnumerable<LiveVideoInput>), typeof(AudioInputModeSelector));

	public static readonly DependencyProperty VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(AudioInputModeSelector));

	public BehaviorMode BehaviorMode
	{
		get
		{
			return (BehaviorMode)((DependencyObject)this).GetValue(BehaviorModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BehaviorModeProperty, (object)value);
		}
	}

	public LinkedVideoInputs? LinkedVideoInputs
	{
		get
		{
			return (LinkedVideoInputs)((DependencyObject)this).GetValue(LinkedVideoInputsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkedVideoInputsProperty, (object)value);
		}
	}

	public IEnumerable<LiveVideoInput>? VideoInputs
	{
		get
		{
			return (IEnumerable<LiveVideoInput>)((DependencyObject)this).GetValue(VideoInputsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoInputsProperty, (object)value);
		}
	}

	public double VerticalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(VerticalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VerticalOffsetProperty, (object)value);
		}
	}

	public ICommand<LiveVideoInput?>? ToggleLinkedVideoInputCommand => new RelayCommand<LiveVideoInput>(OnToggleLinkedVideoInput);

	public AudioInputModeSelector()
	{
		InitializeComponent();
	}

	private void OnToggleLinkedVideoInput(LiveVideoInput? videoInput)
	{
		if (LinkedVideoInputs != null && videoInput != null)
		{
			LinkedVideoInputs.ToggleLink(videoInput);
			UpdateLinkedVideoInputCheckedState();
		}
	}

	private void OnLinkedVideoInputsPopupOpened(object? sender, EventArgs e)
	{
		UpdateLinkedVideoInputCheckedState();
	}

	private void OnLinkedVideoInputsPopupClosed(object? sender, EventArgs e)
	{
		if (BehaviorMode == BehaviorMode.AutoOn)
		{
			AudioInputAutoOnChangeEvent.Publish((uint)(LinkedVideoInputs?.Count ?? 0));
		}
	}

	private void UpdateLinkedVideoInputCheckedState()
	{
		((DependencyObject)(object)linkedVideoInputsPopup?.Child)?.FindVisualChildren<CheckBox>().ForEach(delegate(CheckBox m)
		{
			m.GetBindingExpression(ToggleButton.IsCheckedProperty).UpdateTarget();
		});
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
