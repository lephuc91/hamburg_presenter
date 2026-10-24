using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Localization;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI;

public partial class SlidePreviewSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(CustomSlide), typeof(SlidePreviewSelector));

	public static readonly DependencyProperty ShowLabelProperty = DependencyProperty.Register("ShowLabel", typeof(bool), typeof(SlidePreviewSelector));

	public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register("LabelText", typeof(string), typeof(SlidePreviewSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(string.Empty, null, new CoerceValueCallback(CoerceLabelText)));

	public static readonly DependencyProperty RenderTransparencyCheckerboardProperty = DependencyProperty.Register("RenderTransparencyCheckerboard", typeof(bool), typeof(SlidePreviewSelector));

	public CustomSlide? Source
	{
		get
		{
			return (CustomSlide)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public bool? ShowLabel
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(ShowLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowLabelProperty, (object)value);
		}
	}

	public string? LabelText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LabelTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelTextProperty, (object)value);
		}
	}

	public bool? RenderTransparencyCheckerboard
	{
		get
		{
			return (bool?)((DependencyObject)this).GetValue(RenderTransparencyCheckerboardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderTransparencyCheckerboardProperty, (object)value);
		}
	}

	private static object CoerceLabelText(DependencyObject d, object baseValue)
	{
		if ((d as SlidePreviewSelector)?.Source != null)
		{
			return baseValue;
		}
		return LocalizedStrings.Get("GLOBAL_NONE");
	}

	public SlidePreviewSelector()
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
