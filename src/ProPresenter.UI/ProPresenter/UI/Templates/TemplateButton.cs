using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Controls;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.Templates;

public partial class TemplateButton : BorderlessButton, IComponentConnector
{
	private const string ThemePickerUI = "ThemePickerUI";

	public static readonly DependencyProperty IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(TemplateButton), new PropertyMetadata((object)true));

	public static readonly DependencyProperty TemplateSlideTooltipProperty = DependencyProperty.Register("TemplateSlideTooltipText", typeof(string), typeof(TemplateButton), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty AllowCreateAndEditThemeProperty = DependencyProperty.Register("AllowCreateAndEditTheme", typeof(bool), typeof(TemplateButton), new PropertyMetadata((object)true));

	public static readonly DependencyProperty ContextGroupProperty = DependencyProperty.Register("ContextGroup", typeof(ThemePickerGroup), typeof(TemplateButton), new PropertyMetadata((object)ThemePickerGroup.Presentation));

	public static readonly DependencyProperty SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(TemplateSlide), typeof(TemplateButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty DefaultTemplateProperty = DependencyProperty.Register("DefaultTemplate", typeof(TemplateSlide), typeof(TemplateButton));

	public static readonly DependencyProperty DefaultTemplateHeaderProperty = DependencyProperty.Register("DefaultTemplateHeader", typeof(string), typeof(TemplateButton));

	public static readonly DependencyProperty ShowNoneOptionProperty = DependencyProperty.Register("ShowNoneOption", typeof(bool), typeof(TemplateButton));

	public static readonly DependencyProperty ShowRefactorPreferencesProperty = DependencyProperty.Register("ShowRefactorPreferences", typeof(bool), typeof(TemplateButton));

	public static readonly DependencyProperty ShowLabelProperty = DependencyProperty.Register("ShowLabel", typeof(bool), typeof(TemplateButton));

	public static readonly DependencyProperty SelectTemplateCommandProperty = DependencyProperty.Register("SelectTemplateCommand", typeof(ICommand<TemplateSlide>), typeof(TemplateButton));

	public static readonly DependencyProperty IsThemeUIOpenProperty = DependencyProperty.Register("IsThemeUIOpen", typeof(bool), typeof(TemplateButton));

	public static readonly DependencyProperty TemplateButtonTypeProperty = DependencyProperty.Register("TemplateButtonType", typeof(TemplateButtonType), typeof(TemplateButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TemplateButtonType.Thumbnail));

	public static readonly DependencyProperty ShowOptionsProperty = DependencyProperty.Register("ShowOptions", typeof(bool), typeof(TemplateButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowMediaActionButtonProperty = DependencyProperty.Register("ShowMediaActionButton", typeof(bool), typeof(TemplateButton), new PropertyMetadata((object)true));

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

	public TemplateSlide DefaultTemplate
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(DefaultTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultTemplateProperty, (object)value);
		}
	}

	public string DefaultTemplateHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DefaultTemplateHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultTemplateHeaderProperty, (object)value);
		}
	}

	public bool ShowNoneOption
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowNoneOptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowNoneOptionProperty, (object)value);
		}
	}

	public bool ShowRefactorPreferences
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowRefactorPreferencesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowRefactorPreferencesProperty, (object)value);
		}
	}

	public bool ShowLabel
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowLabelProperty, (object)value);
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

	public bool IsThemeUIOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsThemeUIOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsThemeUIOpenProperty, (object)value);
		}
	}

	public TemplateButtonType TemplateButtonType
	{
		get
		{
			return (TemplateButtonType)((DependencyObject)this).GetValue(TemplateButtonTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateButtonTypeProperty, (object)value);
		}
	}

	public bool ShowOptions
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowOptionsProperty, (object)value);
		}
	}

	public ThemePickerGroup ContextGroup
	{
		get
		{
			return (ThemePickerGroup)((DependencyObject)this).GetValue(ContextGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextGroupProperty, (object)value);
		}
	}

	public bool AllowCreateAndEditTheme
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowCreateAndEditThemeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowCreateAndEditThemeProperty, (object)value);
		}
	}

	public string TemplateSlideTooltipText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TemplateSlideTooltipProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateSlideTooltipProperty, (object)value);
		}
	}

	public bool ShowMediaActionButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMediaActionButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMediaActionButtonProperty, (object)value);
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

	public TemplateButton()
	{
		((DependencyObject)this).SetCurrentValue(SelectTemplateCommandProperty, (object)new RelayCommand<TemplateSlide>(delegate(TemplateSlide t)
		{
			((DependencyObject)this).SetValue(SelectedTemplateProperty, (object)t);
		}));
		InitializeComponent();
	}

	private void TemplateButton_PreviewMouseDown(object? sender, RoutedEventArgs e)
	{
		bool flag = !IsThemeUIOpen;
		((DependencyObject)this).SetCurrentValue(IsThemeUIOpenProperty, (object)flag);
		e.Handled = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
