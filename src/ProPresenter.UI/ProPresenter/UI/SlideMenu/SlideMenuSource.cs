using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.SlideMenu;

public partial class SlideMenuSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty ShowQuickEditProperty = DependencyProperty.Register("ShowQuickEdit", typeof(bool), typeof(SlideMenuSource));

	public static readonly DependencyProperty ThemeContextGroupProperty = DependencyProperty.Register("ThemeContextGroup", typeof(ThemePickerGroup), typeof(SlideMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ThemePickerGroup.Presentation));

	public bool ShowQuickEdit
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowQuickEditProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowQuickEditProperty, (object)value);
		}
	}

	public ThemePickerGroup ThemeContextGroup
	{
		get
		{
			return (ThemePickerGroup)((DependencyObject)this).GetValue(ThemeContextGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemeContextGroupProperty, (object)value);
		}
	}

	public SlideMenuSource()
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
