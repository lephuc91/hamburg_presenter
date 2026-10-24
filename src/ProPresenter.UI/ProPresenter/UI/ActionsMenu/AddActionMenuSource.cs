using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;

namespace ProPresenter.UI.ActionsMenu;

public partial class AddActionMenuSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty CanAddMediaActionProperty = DependencyProperty.Register("CanAddMediaAction", typeof(bool), typeof(AddActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanAddPlaylistActionProperty = DependencyProperty.Register("CanAddPlaylistAction", typeof(bool), typeof(AddActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanAddCaptureActionProperty = DependencyProperty.Register("CanAddCaptureAction", typeof(bool), typeof(AddActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public bool CanAddMediaAction
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanAddMediaActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanAddMediaActionProperty, (object)value);
		}
	}

	public bool CanAddPlaylistAction
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanAddPlaylistActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanAddPlaylistActionProperty, (object)value);
		}
	}

	public bool CanAddCaptureAction
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanAddCaptureActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanAddCaptureActionProperty, (object)value);
		}
	}

	public AddActionMenuSource()
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
