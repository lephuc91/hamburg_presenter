using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates;

[TemplatePart(Name = "PART_List", Type = typeof(ItemsControl))]
public class ThemeList : ContentControl
{
	private const string PART_List = "PART_List";

	public static readonly DependencyProperty IsMediaActionEnabledProperty;

	public static readonly DependencyProperty EnableContextMenuOptionsProperty;

	public static readonly DependencyProperty DeleteThemeCommandProperty;

	public static readonly DependencyProperty ThemesProperty;

	public static readonly DependencyProperty SelectThemeCommandProperty;

	public static readonly DependencyProperty SelectTemplateSlideCommandProperty;

	public static readonly DependencyProperty SelectedTemplateProperty;

	public IEnumerable<ThemeContainer> Themes
	{
		get
		{
			return (IEnumerable<ThemeContainer>)((DependencyObject)this).GetValue(ThemesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemesProperty, (object)value);
		}
	}

	public ICommand<Theme> SelectThemeCommand
	{
		get
		{
			return (ICommand<Theme>)((DependencyObject)this).GetValue(SelectThemeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectThemeCommandProperty, (object)value);
		}
	}

	public ICommand<TemplateSlide> SelectTemplateSlideCommand
	{
		get
		{
			return (ICommand<TemplateSlide>)((DependencyObject)this).GetValue(SelectTemplateSlideCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectTemplateSlideCommandProperty, (object)value);
		}
	}

	public TemplateSlide SelectedTemplate
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(SelectedTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTemplateProperty, (object)value);
		}
	}

	public ICommand<Theme> DeleteThemeCommand
	{
		get
		{
			return (ICommand<Theme>)((DependencyObject)this).GetValue(DeleteThemeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteThemeCommandProperty, (object)value);
		}
	}

	public bool EnableContextMenuOptions
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EnableContextMenuOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnableContextMenuOptionsProperty, (object)value);
		}
	}

	public bool IsMediaActionEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMediaActionEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMediaActionEnabledProperty, (object)value);
		}
	}

	static ThemeList()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(ThemeList), new PropertyMetadata((object)true));
		EnableContextMenuOptionsProperty = DependencyProperty.Register("EnableContextMenuOptions", typeof(bool), typeof(ThemeList), new PropertyMetadata((object)false));
		DeleteThemeCommandProperty = DependencyProperty.Register("DeleteThemeCommand", typeof(ICommand<Theme>), typeof(ThemeList), new PropertyMetadata((PropertyChangedCallback)null));
		ThemesProperty = DependencyProperty.Register("Themes", typeof(IEnumerable<ThemeContainer>), typeof(ThemeList));
		SelectThemeCommandProperty = DependencyProperty.Register("SelectThemeCommand", typeof(ICommand<Theme>), typeof(ThemeList));
		SelectTemplateSlideCommandProperty = DependencyProperty.Register("SelectTemplateSlideCommand", typeof(ICommand<TemplateSlide>), typeof(ThemeList));
		SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(TemplateSlide), typeof(ThemeList));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ThemeList), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ThemeList)));
	}

	public override void OnApplyTemplate()
	{
		((DependencyObject?)(object)(ItemsControl)(object)GetTemplateChild("PART_List"))?.Bind(ItemsControl.ItemsSourceProperty, this, "Themes");
	}
}
