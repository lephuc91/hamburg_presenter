using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public partial class PlaybackMarker : UserControl, IComponentConnector
{
	private static DependencyProperty IsTextProperty = DependencyProperty.Register("IsText", typeof(bool), typeof(PlaybackMarker), new PropertyMetadata((object)false));

	public bool IsText
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTextProperty, (object)value);
		}
	}

	public PlaybackMarker()
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
