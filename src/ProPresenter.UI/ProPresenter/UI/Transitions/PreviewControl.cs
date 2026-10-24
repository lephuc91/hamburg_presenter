using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.DO.Effects;
using Pro.DO.Transitions;
using ProPresenter.Controller.Outputs;

namespace ProPresenter.UI.Transitions;

public partial class PreviewControl : UserControl, IComponentConnector
{
	private static readonly TimeSlice UpdateDelay = TimeSlice.FromSeconds(0.25);

	private DispatcherTimer _previewUpdateTimer;

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(PreviewControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTransitionHandlerChanged)));

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(PreviewControl));

	public static readonly DependencyProperty PreviewWidthProperty = DependencyProperty.Register("PreviewWidth", typeof(int), typeof(PreviewControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)120));

	public static readonly DependencyProperty PreviewHeightProperty = DependencyProperty.Register("PreviewHeight", typeof(int), typeof(PreviewControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)70));

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

	public int PreviewWidth
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PreviewWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewWidthProperty, (object)value);
		}
	}

	public int PreviewHeight
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PreviewHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewHeightProperty, (object)value);
		}
	}

	private static void OnTransitionHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PreviewControl)(object)d).TransitionHandlerChanged((TransitionHandler)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TransitionHandler)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public PreviewControl()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		InitializeComponent();
		_previewUpdateTimer = new DispatcherTimer
		{
			IsEnabled = false,
			Interval = UpdateDelay
		};
		_previewUpdateTimer.Tick += delegate
		{
			_previewUpdateTimer.Stop();
			DoPreviewFrameUpdate();
		};
		base.Loaded += TransitionPreviewControl_Loaded;
	}

	private void TransitionPreviewControl_Loaded(object? sender, RoutedEventArgs e)
	{
		DoPreviewFrameUpdate();
	}

	private void TransitionHandlerChanged(TransitionHandler oldTransitionHandler, TransitionHandler newTransitionHandler)
	{
		if (oldTransitionHandler != null)
		{
			oldTransitionHandler.ActiveParametersChanged -= OnActiveParametersPropertyChanged;
		}
		if (newTransitionHandler != null)
		{
			newTransitionHandler.ActiveParametersChanged += OnActiveParametersPropertyChanged;
		}
		DoPreviewFrameUpdate();
	}

	private void OnActiveParametersPropertyChanged(TransitionParameters? oldParameters, TransitionParameters? newParameters)
	{
		if (oldParameters != null)
		{
			oldParameters.ParametersChanged -= OnActiveParametersChanged;
		}
		if (newParameters != null)
		{
			newParameters.ParametersChanged += OnActiveParametersChanged;
		}
		DoPreviewFrameUpdate();
	}

	private void OnActiveParametersChanged(EffectParameters parameters)
	{
		_previewUpdateTimer.Stop();
		_previewUpdateTimer.Start();
	}

	private void DoPreviewFrameUpdate()
	{
		if (OutputController != null && TransitionHandler != null && TransitionHandler.IsActive && (object)TransitionHandler.ActiveParameters != null)
		{
			TransitionPreview.PlaybackDuration = TransitionHandler.ActiveParameters.Duration;
			TransitionPreview.Preview = OutputController.GetTransitionPreview(TransitionHandler.ActiveParameters, PreviewImages.StartImage, PreviewImages.EndImage, new Vector2<int>(PreviewWidth, PreviewHeight));
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
