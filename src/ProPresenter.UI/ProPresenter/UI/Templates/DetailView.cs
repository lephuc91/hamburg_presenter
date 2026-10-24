using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates;

public partial class DetailView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(DetailView), new PropertyMetadata((object)true));

	public static readonly DependencyProperty TemplateSlideTooltipTextProperty = DependencyProperty.Register("TemplateSlideTooltipText", typeof(string), typeof(DetailView), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty EnableContextMenuOptionsProperty = DependencyProperty.Register("EnableContextMenuOptions", typeof(bool), typeof(DetailView), new PropertyMetadata((object)false));

	public static readonly DependencyProperty DeleteTemplateSlideCommandProperty = DependencyProperty.Register("DeleteTemplateSlideCommand", typeof(ICommand<TemplateSlide>), typeof(DetailView), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty CurrentThemeContainerProperty = DependencyProperty.Register("CurrentThemeContainer", typeof(ThemeContainer), typeof(DetailView));

	public static readonly DependencyProperty SelectTemplateCommandProperty = DependencyProperty.Register("SelectTemplateCommand", typeof(ICommand<TemplateSlide>), typeof(DetailView));

	public static readonly DependencyProperty SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(TemplateSlide), typeof(DetailView));

	public IThemeContainer CurrentThemeContainer
	{
		get
		{
			return (ThemeContainer)((DependencyObject)this).GetValue(CurrentThemeContainerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentThemeContainerProperty, (object)value);
		}
	}

	public ICommand<TemplateSlide> SelectTemplateCommand
	{
		get
		{
			return (ICommand<TemplateSlide>)((DependencyObject)this).GetValue(SelectTemplateCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectTemplateCommandProperty, (object)value);
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

	public DetailView()
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
