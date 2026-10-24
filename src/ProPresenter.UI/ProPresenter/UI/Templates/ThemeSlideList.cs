using System.Windows;
using System.Windows.Controls;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates;

[TemplatePart(Name = "PART_List", Type = typeof(ItemsControl))]
public class ThemeSlideList : ContentControl
{
	private const string PART_List = "PART_List";

	public static readonly DependencyProperty IsMediaActionEnabledProperty;

	public static readonly DependencyProperty TemplateSlideTooltipTextProperty;

	public static readonly DependencyProperty EnableContextMenuOptionsProperty;

	public static readonly DependencyProperty DeleteTemplateSlideCommandProperty;

	public static readonly DependencyProperty ThemeProperty;

	public static readonly DependencyProperty SelectTemplateSlideCommandProperty;

	public static readonly DependencyProperty SelectedTemplateProperty;

	public Theme Theme
	{
		get
		{
			return (Theme)((DependencyObject)this).GetValue(ThemeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemeProperty, (object)value);
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

	public ICommand<TemplateSlide> DeleteTemplateSlideCommand
	{
		get
		{
			return (ICommand<TemplateSlide>)((DependencyObject)this).GetValue(DeleteTemplateSlideCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteTemplateSlideCommandProperty, (object)value);
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

	public string TemplateSlideTooltipText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TemplateSlideTooltipTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateSlideTooltipTextProperty, (object)value);
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

	static ThemeSlideList()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(ThemeSlideList), new PropertyMetadata((object)true));
		TemplateSlideTooltipTextProperty = DependencyProperty.Register("TemplateSlideTooltipText", typeof(string), typeof(ThemeSlideList), new PropertyMetadata((PropertyChangedCallback)null));
		EnableContextMenuOptionsProperty = DependencyProperty.Register("EnableContextMenuOptions", typeof(bool), typeof(ThemeSlideList), new PropertyMetadata((object)false));
		DeleteTemplateSlideCommandProperty = DependencyProperty.Register("DeleteTemplateSlideCommand", typeof(ICommand<TemplateSlide>), typeof(ThemeSlideList), new PropertyMetadata((PropertyChangedCallback)null));
		ThemeProperty = DependencyProperty.Register("Theme", typeof(Theme), typeof(ThemeSlideList));
		SelectTemplateSlideCommandProperty = DependencyProperty.Register("SelectTemplateSlideCommand", typeof(ICommand<TemplateSlide>), typeof(ThemeSlideList));
		SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(TemplateSlide), typeof(ThemeSlideList));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ThemeSlideList), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ThemeSlideList)));
	}

	public override void OnApplyTemplate()
	{
		((DependencyObject?)(object)(ItemsControl)(object)GetTemplateChild("PART_List")).Bind(ItemsControl.ItemsSourceProperty, this, "Theme");
	}
}
