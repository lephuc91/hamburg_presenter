using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.DO.Transitions;
using ProPresenter.Controller.Outputs;

namespace ProPresenter.UI.Transitions;

public partial class ItemPreview : UserControl, IComponentConnector
{
	private readonly int PreviewWidth = 112;

	private readonly int PreviewHeight = 63;

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(ItemPreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OutputControllerPropertyChanged)));

	public static readonly DependencyProperty TransitionProperty = DependencyProperty.Register("Transition", typeof(TransitionBase), typeof(ItemPreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(TransitionPropertyChanged)));

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

	public TransitionBase? Transition
	{
		get
		{
			return (TransitionBase)((DependencyObject)this).GetValue(TransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionProperty, (object)value);
		}
	}

	private static void OutputControllerPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ItemPreview)(object)callerObject).UpdatePreviewFrames();
	}

	private static void TransitionPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ItemPreview)(object)callerObject).TransitionChanged((TransitionBase)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TransitionBase)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public ItemPreview()
	{
		InitializeComponent();
	}

	private void TransitionChanged(TransitionBase oldTransition, TransitionBase newTransition)
	{
		if (oldTransition != null)
		{
			oldTransition.PropertyChanged -= OnTransitionPropertyChanged;
		}
		if (newTransition != null)
		{
			newTransition.PropertyChanged += OnTransitionPropertyChanged;
		}
		UpdatePreviewFrames();
	}

	private void OnTransitionPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Preset")
		{
			UpdatePreviewFrames();
		}
	}

	private void UpdatePreviewFrames()
	{
		if (OutputController != null && (object)Transition?.Preset?.Parameters != null)
		{
			TransitionPreview.PlaybackDuration = Transition.Preset.Parameters.Duration;
			TransitionPreview.Preview = OutputController.GetTransitionPreview(Transition.Preset.Parameters, PreviewImages.StartImage, PreviewImages.EndImage, new Vector2<int>(PreviewWidth, PreviewHeight));
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
