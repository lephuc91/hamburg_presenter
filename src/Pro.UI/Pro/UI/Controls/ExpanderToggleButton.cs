using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace Pro.UI.Controls;

[ContentProperty("LeftContent")]
public partial class ExpanderToggleButton : BorderlessToggleButton, IComponentConnector
{
	public static readonly DependencyProperty ExpandedPathTypeProperty = DependencyProperty.Register("ExpandedPathType", typeof(PathType), typeof(ExpanderToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PathType.DownArrow));

	public static readonly DependencyProperty CollapsedPathTypeProperty = DependencyProperty.Register("CollapsedPathType", typeof(PathType), typeof(ExpanderToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PathType.RightArrow));

	public static readonly DependencyProperty ShouldFillProperty = DependencyProperty.Register("ShouldFill", typeof(bool), typeof(ExpanderToggleButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register("LeftContent", typeof(object), typeof(ExpanderToggleButton));

	public PathType ExpandedPathType
	{
		get
		{
			return (PathType)((DependencyObject)this).GetValue(ExpandedPathTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExpandedPathTypeProperty, (object)value);
		}
	}

	public PathType CollapsedPathType
	{
		get
		{
			return (PathType)((DependencyObject)this).GetValue(CollapsedPathTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollapsedPathTypeProperty, (object)value);
		}
	}

	public bool ShouldFill
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShouldFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShouldFillProperty, (object)value);
		}
	}

	public object LeftContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(ButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonContentProperty, value);
		}
	}

	public ExpanderToggleButton()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
