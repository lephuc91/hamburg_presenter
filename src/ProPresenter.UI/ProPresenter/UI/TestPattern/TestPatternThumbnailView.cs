using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProPresenter.UI.TestPattern;

public partial class TestPatternThumbnailView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ThumbnailProperty = DependencyProperty.Register("Thumbnail", typeof(ImageSource), typeof(TestPatternThumbnailView));

	public ImageSource? Thumbnail
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(ThumbnailProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailProperty, (object)value);
		}
	}

	public double AspectRatio => 1.7777777777777777;

	public TestPatternThumbnailView()
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
