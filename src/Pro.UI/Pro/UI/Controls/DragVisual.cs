using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class DragVisual : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(int), typeof(DragVisual), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1));

	public static readonly DependencyProperty VisualProperty = DependencyProperty.Register("Visual", typeof(UIElement), typeof(DragVisual), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnVisualPropertyChanged)));

	public int Count
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CountProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CountProperty, (object)value);
		}
	}

	public UIElement Visual
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(VisualProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisualProperty, (object)value);
		}
	}

	private static void OnVisualPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((DragVisual)(object)callerObject).AddContent(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as UIElement, ((DependencyPropertyChangedEventArgs)(ref e)).OldValue as UIElement);
	}

	public DragVisual()
	{
		InitializeComponent();
	}

	private void AddContent(UIElement? newVisual, UIElement? oldVisual)
	{
		if (newVisual != null)
		{
			ContentGrid.Children.Insert(0, newVisual);
		}
		if (oldVisual != null)
		{
			ContentGrid.Children.Remove(oldVisual);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
