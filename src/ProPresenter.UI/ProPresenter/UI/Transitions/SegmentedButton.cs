using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Nullability;
using Pro.DO.Transitions;
using ProPresenter.Controller.Outputs;

namespace ProPresenter.UI.Transitions;

public partial class SegmentedButton : UserControl, IComponentConnector
{
	public enum ButtonDisplayMode
	{
		Foreground,
		Background
	}

	private bool _updateInProgress;

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(SegmentedButton));

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(SegmentedButton));

	public static readonly DependencyProperty SelectedTransitionProperty = DependencyProperty.Register("SelectedTransition", typeof(TransitionParameters), typeof(SegmentedButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTranstionChanged)));

	public static readonly DependencyProperty InternalSelectedTransitionProperty = DependencyProperty.Register("InternalSelectedTransition", typeof(TransitionParameters), typeof(SegmentedButton));

	public static readonly DependencyProperty IsGlobalAllowedProperty = DependencyProperty.Register("IsGlobalAllowed", typeof(bool), typeof(SegmentedButton));

	public static readonly DependencyProperty SimplifiedTransitionsButtonsProperty = DependencyProperty.Register("SimplifiedTransitionsButtons", typeof(bool), typeof(SegmentedButton));

	public static readonly DependencyProperty CollapseControlWidthProperty = DependencyProperty.Register("CollapseControlWidth", typeof(int), typeof(SegmentedButton), new PropertyMetadata(new PropertyChangedCallback(CollapseControlWidth_Changed)));

	public static readonly DependencyProperty ParentControlWidthProperty = DependencyProperty.Register("ParentControlWidth", typeof(double), typeof(SegmentedButton), new PropertyMetadata(new PropertyChangedCallback(CollapseControlWidth_Changed)));

	public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register("DisplayMode", typeof(ButtonDisplayMode), typeof(SegmentedButton));

	private static readonly DependencyProperty ControlHasExtraRoomVisibilityProperty = DependencyProperty.Register("ControlHasExtraRoomVisibility", typeof(Visibility), typeof(SegmentedButton));

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public TransitionHandler? TransitionHandler
	{
		get
		{
			return (TransitionHandler)((DependencyObject)this).GetValue(TransitionHandlerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionHandlerProperty, (object)value);
		}
	}

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return (TransitionParameters)((DependencyObject)this).GetValue(SelectedTransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTransitionProperty, (object)value);
		}
	}

	public TransitionParameters? InternalSelectedTransition
	{
		get
		{
			return (TransitionParameters)((DependencyObject)this).GetValue(InternalSelectedTransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InternalSelectedTransitionProperty, (object)value);
		}
	}

	public bool IsGlobalAllowed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsGlobalAllowedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsGlobalAllowedProperty, (object)value);
		}
	}

	public ButtonDisplayMode DisplayMode
	{
		get
		{
			return (ButtonDisplayMode)((DependencyObject)this).GetValue(DisplayModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayModeProperty, (object)value);
		}
	}

	public bool SimplifiedTransitionsButtons
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SimplifiedTransitionsButtonsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SimplifiedTransitionsButtonsProperty, (object)value);
		}
	}

	public int CollapseControlWidth
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CollapseControlWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollapseControlWidthProperty, (object)value);
		}
	}

	public double ParentControlWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ParentControlWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParentControlWidthProperty, (object)value);
		}
	}

	private Visibility ControlHasExtraRoomVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(ControlHasExtraRoomVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ControlHasExtraRoomVisibilityProperty, (object)value);
		}
	}

	private static void OnSelectedTranstionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as SegmentedButton)?.SelectedTransitionChanged((TransitionParameters)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public SegmentedButton()
	{
		InitializeComponent();
		transitionSelectControl.SelectorClosed += TransitionSelectControl_SelectorClosed;
		base.Loaded += delegate
		{
			UpdateCheckedStatus(initializing: true);
		};
	}

	private static void CollapseControlWidth_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is SegmentedButton segmentedButton)
		{
			if (segmentedButton.CollapseControlWidth > 0 && segmentedButton.ParentControlWidth <= (double)segmentedButton.CollapseControlWidth)
			{
				segmentedButton.ControlHasExtraRoomVisibility = Visibility.Collapsed;
			}
			else
			{
				segmentedButton.ControlHasExtraRoomVisibility = Visibility.Visible;
			}
		}
	}

	private void TransitionSelectControl_SelectorClosed()
	{
		UpdateCheckedStatus();
	}

	private void SelectedTransitionChanged(TransitionParameters newTransition)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		InternalSelectedTransition = newTransition;
		CollapseControlWidth_Changed((DependencyObject)(object)this, default(DependencyPropertyChangedEventArgs));
	}

	private void CutButton_Checked(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress && TransitionHandler != null)
		{
			_updateInProgress = true;
			TransitionHandler.IsContinuousFinalize = true;
			TransitionHandler.ActivateTransition(TransitionStoreType.Cut);
			CheckCut();
			SelectedTransition = TransitionHandler.ActiveParameters;
			_updateInProgress = false;
		}
	}

	private void CutButton_Unchecked(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			CutButton.IsChecked = true;
			_updateInProgress = false;
		}
	}

	private void AutoButton_Checked(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress && TransitionHandler != null)
		{
			_updateInProgress = true;
			TransitionHandler.IsContinuousFinalize = true;
			TransitionHandler.ActivateTransition(TransitionStoreType.Auto);
			CheckAuto();
			SelectedTransition = TransitionHandler.ActiveParameters;
			_updateInProgress = false;
		}
	}

	private void AutoButton_Unchecked(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			AutoButton.IsChecked = true;
			_updateInProgress = false;
		}
	}

	private void AdvButton_Checked(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress && TransitionHandler != null)
		{
			_updateInProgress = true;
			CheckAdvanced();
			if (!TransitionHandler.IsActive)
			{
				TransitionHandler.IsContinuousFinalize = false;
				TransitionHandler.ActivateTransition(TransitionStoreType.Advanced);
				InternalSelectedTransition = null;
				transitionSelectControl.OpenSelector();
			}
			else
			{
				TransitionHandler.IsContinuousFinalize = true;
				TransitionHandler.ActivateTransition(TransitionStoreType.Advanced);
				SelectedTransition = TransitionHandler.ActiveParameters;
			}
			_updateInProgress = false;
		}
	}

	private void AdvButton_Unchecked(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			AdvButton.IsChecked = true;
			transitionSelectControl.OpenSelector();
			_updateInProgress = false;
		}
	}

	private void UpdateCheckedStatus(bool initializing = false)
	{
		if (_updateInProgress || TransitionHandler == null)
		{
			return;
		}
		_updateInProgress = true;
		switch (TransitionHandler.Provider.ActiveStoreType)
		{
		case TransitionStoreType.Cut:
			CheckCut();
			break;
		case TransitionStoreType.Auto:
			CheckAuto();
			break;
		case TransitionStoreType.Advanced:
			CheckAdvanced();
			if (initializing)
			{
				SelectedTransition = TransitionHandler.ActiveParameters;
			}
			break;
		}
		_updateInProgress = false;
	}

	private void CheckCut()
	{
		CutButton.IsChecked = true;
		AutoButton.IsChecked = false;
		AdvButton.IsChecked = false;
	}

	private void CheckAuto()
	{
		AutoButton.IsChecked = true;
		CutButton.IsChecked = false;
		AdvButton.IsChecked = false;
	}

	private void CheckAdvanced()
	{
		AdvButton.IsChecked = true;
		AutoButton.IsChecked = false;
		CutButton.IsChecked = false;
	}

	internal void RefreshCheckStatus()
	{
		UpdateCheckedStatus();
	}

	private void SimpleTransitionButton_Click(object? sender, RoutedEventArgs e)
	{
		if (!_updateInProgress)
		{
			_updateInProgress = true;
			TransitionHandler.ThrowWhenNull("TransitionHandler");
			TransitionHandler.IsContinuousFinalize = true;
			TransitionHandler.ActivateTransition(TransitionStoreType.Advanced);
			InternalSelectedTransition = null;
			transitionSelectControl.OpenSelector();
			_updateInProgress = false;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
