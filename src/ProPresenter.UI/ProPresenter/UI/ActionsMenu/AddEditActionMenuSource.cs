using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.DO.Triggering;
using Pro.UI.Components;

namespace ProPresenter.UI.ActionsMenu;

public partial class AddEditActionMenuSource : FrameworkCollection, IComponentConnector
{
	private static readonly DependencyProperty RootActionProperty = DependencyProperty.Register("RootAction", typeof(ActionBase), typeof(AddEditActionMenuSource));

	public static readonly DependencyProperty CanAddMediaActionProperty = DependencyProperty.Register("CanAddMediaAction", typeof(bool), typeof(AddEditActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanAddPlaylistActionProperty = DependencyProperty.Register("CanAddPlaylistAction", typeof(bool), typeof(AddEditActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanAddCaptureActionProperty = DependencyProperty.Register("CanAddCaptureAction", typeof(bool), typeof(AddEditActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowOpenMacrosProperty = DependencyProperty.Register("ShowOpenMacros", typeof(bool), typeof(AddEditActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	private ActionBase RootAction
	{
		get
		{
			return (ActionBase)((DependencyObject)this).GetValue(RootActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RootActionProperty, (object)value);
		}
	}

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

	public bool ShowOpenMacros
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowOpenMacrosProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowOpenMacrosProperty, (object)value);
		}
	}

	public AddEditActionMenuSource()
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
