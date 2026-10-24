using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.FeatureFlag;
using Pro.Common.MessageService;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Export;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Templates;

public partial class ThemePicker : UserControl, IComponentConnector
{
	public const double WIDTH = 395.0;

	private readonly IThemeService _themeService;

	public static readonly DependencyProperty IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(ThemePicker), new PropertyMetadata((object)true));

	public static readonly DependencyProperty FetchThemePickerSettingsCommandProperty = DependencyProperty.Register("FetchThemePickerSettingsCommand", typeof(ICommand<ThemePickerGroup>), typeof(ThemePicker), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty TemplateSlideTooltipTextProperty = DependencyProperty.Register("TemplateSlideTooltipText", typeof(string), typeof(ThemePicker), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty AllowCreateAndEditThemeProperty = DependencyProperty.Register("AllowCreateAndEditTheme", typeof(bool), typeof(ThemePicker), new PropertyMetadata((object)true));

	public static readonly DependencyProperty EnableContextMenuOptionsProperty = DependencyProperty.Register("EnableContextMenuOptions", typeof(bool), typeof(ThemePicker), new PropertyMetadata((object)false));

	public static readonly DependencyProperty ContextGroupProperty = DependencyProperty.Register("ContextGroup", typeof(ThemePickerGroup), typeof(ThemePicker), new PropertyMetadata((object)ThemePickerGroup.Presentation));

	public static readonly DependencyProperty FetchRecentlyAppliedThemeDataCommandProperty = DependencyProperty.Register("FetchRecentlyAppliedThemeDataCommand", typeof(ICommand), typeof(ThemePicker), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty SelectTemplateCommandProperty = DependencyProperty.Register("SelectTemplateCommand", typeof(ICommand<TemplateSlide>), typeof(ThemePicker));

	public static readonly DependencyProperty SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(TemplateSlide), typeof(ThemePicker));

	public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ThemePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty ResetViewCommandProperty = DependencyProperty.Register("ResetViewCommand", typeof(ICommand), typeof(ThemePicker));

	public static readonly DependencyProperty CanDeleteThemeProperty = DependencyProperty.Register("CanDeleteTheme", typeof(bool), typeof(ThemePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty RemoveSelectedTemplateHeaderProperty = DependencyProperty.Register("RemoveSelectedTemplateHeader", typeof(string), typeof(ThemePicker));

	public static readonly DependencyProperty CanRemoveSelectedTemplateProperty = DependencyProperty.Register("CanRemoveSelectedTemplate", typeof(bool), typeof(ThemePicker));

	public static readonly DependencyProperty AddNewSlideTemplateProperty = DependencyProperty.Register("AddNewSlideTemplate", typeof(TemplateSlide), typeof(ThemePicker));

	private static readonly DependencyProperty ThemePickerSelectTemplateCommandProperty = DependencyProperty.Register("ThemePickerSelectTemplateCommand", typeof(ICommand<TemplateSlide>), typeof(ThemePicker));

	public static readonly DependencyProperty ShowOptionsProperty = DependencyProperty.Register("ShowOptions", typeof(bool), typeof(ThemePicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CurrentThemeContainerProperty = DependencyProperty.Register("CurrentThemeContainer", typeof(ThemeContainer), typeof(ThemePicker));

	public static readonly DependencyProperty ShowMediaActionButtonProperty = DependencyProperty.Register("ShowMediaActionButton", typeof(bool), typeof(ThemePicker), new PropertyMetadata((object)true));

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

	public bool IsOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsOpenProperty, (object)value);
		}
	}

	public ICommand ResetViewCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ResetViewCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResetViewCommandProperty, (object)value);
		}
	}

	public bool CanDeleteTheme
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanDeleteThemeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanDeleteThemeProperty, (object)value);
		}
	}

	public string RemoveSelectedTemplateHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(RemoveSelectedTemplateHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveSelectedTemplateHeaderProperty, (object)value);
		}
	}

	public bool CanRemoveSelectedTemplate
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanRemoveSelectedTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanRemoveSelectedTemplateProperty, (object)value);
		}
	}

	public TemplateSlide AddNewSlideTemplate
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(AddNewSlideTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddNewSlideTemplateProperty, (object)value);
		}
	}

	private ICommand<TemplateSlide> ThemePickerSelectTemplateCommand
	{
		get
		{
			return (ICommand<TemplateSlide>)((DependencyObject)this).GetValue(ThemePickerSelectTemplateCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemePickerSelectTemplateCommandProperty, (object)value);
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

	public ThemeContainer CurrentThemeContainer
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

	public ICommand? FetchRecentlyAppliedThemeDataCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(FetchRecentlyAppliedThemeDataCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FetchRecentlyAppliedThemeDataCommandProperty, (object)value);
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
			return (string)((DependencyObject)this).GetValue(TemplateSlideTooltipTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateSlideTooltipTextProperty, (object)value);
		}
	}

	public ICommand<ThemePickerGroup>? FetchThemePickerSettingsCommand
	{
		get
		{
			return (ICommand<ThemePickerGroup>)((DependencyObject)this).GetValue(FetchThemePickerSettingsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FetchThemePickerSettingsCommandProperty, (object)value);
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

	public ThemePicker()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		ThemePickerSelectTemplateCommand = new RelayCommand<TemplateSlide>(ThemePickerSelectTemplateCommandExecuted);
		InitializeComponent();
		IProPresenterResourceService service = UIServiceProvider.GetService<IProPresenterResourceService>();
		_themeService = UIServiceProvider.GetService<IThemeService>();
		base.DataContext = new TemplateVM(service.Themes, new SlideSelectorStrategy(UIServiceProvider.GetService<IMainLayoutVM>()), _themeService, new ThemePrompt(service), UIServiceProvider.GetService<IMessageService>(), UIServiceProvider.GetService<IProContentProvider>(), UIServiceProvider.GetService<IExportProcessFactory>(), UIServiceProvider.GetService<IProPresenterDOFactoryProvider>(), UIServiceProvider.GetService<IFlagService>());
		base.Loaded += delegate
		{
			((DependencyObject?)(object)this).Bind(ResetViewCommandProperty, base.DataContext, "ResetViewCommand");
			((DependencyObject?)(object)this).Bind(CurrentThemeContainerProperty, base.DataContext, "CurrentThemeContainer");
			((DependencyObject?)(object)this).Bind(IsMediaActionEnabledProperty, base.DataContext, "PickerSettings.MediaActionEnabled", BindingMode.TwoWay);
			ThemePickerGroup contextGroup = ContextGroup;
			((DependencyObject?)(object)this).Bind(ContextGroupProperty, base.DataContext, "ContextGroup", BindingMode.OneWayToSource);
			ContextGroup = contextGroup;
			FetchRecentlyAppliedThemeDataCommand?.Execute(null);
			FetchThemePickerSettingsCommand?.Execute(ContextGroup);
		};
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(OnThemeUIPickerVisibilityChanged);
		SetBinding(FetchRecentlyAppliedThemeDataCommandProperty, "FetchRecentlyAppliedThemeDataCommand");
		SetBinding(FetchThemePickerSettingsCommandProperty, "FetchThemePickerSettingsCommand");
	}

	private void OnThemeUIPickerVisibilityChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			FetchRecentlyAppliedThemeDataCommand?.Execute(null);
			FetchThemePickerSettingsCommand?.Execute(ContextGroup);
		}
	}

	private void ThemePickerSelectTemplateCommandExecuted(TemplateSlide templateSlide)
	{
		SelectTemplateCommand?.Invoke(templateSlide);
		((DependencyObject)this).SetCurrentValue(IsOpenProperty, (object)false);
	}
}
