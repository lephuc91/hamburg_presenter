using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.ThumbnailOverlay;

public partial class MissingIconOnly : UserControl, IComponentConnector
{
	public static readonly DependencyProperty RingGridProperty = DependencyProperty.Register("RingGrid", typeof(FrameworkElement), typeof(MissingIconOnly), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty RingSizeProperty = DependencyProperty.Register("RingSize", typeof(RingSize), typeof(MissingIconOnly), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)RingSize.Large));

	public FrameworkElement? RingGrid
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(RingGridProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RingGridProperty, (object)value);
		}
	}

	public RingSize RingSize
	{
		get
		{
			return (RingSize)((DependencyObject)this).GetValue(RingSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RingSizeProperty, (object)value);
		}
	}

	public MissingIconOnly()
	{
		InitializeComponent();
		((DependencyObject)this).SetCurrentValue(RingGridProperty, (object)IconGrid);
	}

	private void IconGrid_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(RingGridProperty, (object)IconGrid);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
