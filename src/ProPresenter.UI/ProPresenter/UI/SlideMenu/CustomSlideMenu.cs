using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ReflowEditor;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.SlideMenu;

public partial class CustomSlideMenu : ContextMenu, IComponentConnector
{
	public static readonly DependencyProperty ShowQuickEditProperty = DependencyProperty.Register("ShowQuickEdit", typeof(bool), typeof(CustomSlideMenu), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ThemeContextGroupProperty = DependencyProperty.Register("ThemeContextGroup", typeof(ThemePickerGroup), typeof(CustomSlideMenu), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ThemePickerGroup.Presentation));

	private ICustomSlideMenuVM? CustomSlideMenuVM => base.DataContext as ICustomSlideMenuVM;

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

	public CustomSlideMenu()
	{
		InitializeComponent();
	}

	protected override void OnOpened(RoutedEventArgs e)
	{
		if (CustomSlideMenuVM != null)
		{
			CustomSlideMenuVM.PlacementTarget = null;
			CustomSlideMenuVM.SelectedSlide = null;
			base.OnOpened(e);
			GetPlacementTarget(out FrameworkElement placementTarget, out ArrangedCue arrangedCue);
			CustomSlideMenuVM.PlacementTarget = placementTarget;
			CustomSlideMenuVM.SelectedSlide = arrangedCue;
		}
	}

	private void GetPlacementTarget(out FrameworkElement? placementTarget, out ArrangedCue? arrangedCue)
	{
		if (base.PlacementTarget is Thumbnail thumbnail)
		{
			placementTarget = thumbnail;
			arrangedCue = thumbnail.Source as ArrangedCue;
		}
		else
		{
			placementTarget = base.PlacementTarget as FrameworkElement;
			arrangedCue = ((DependencyObject)(object)placementTarget)?.FindVisualParent<ReflowText>()?.DataContext as ArrangedCue;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
