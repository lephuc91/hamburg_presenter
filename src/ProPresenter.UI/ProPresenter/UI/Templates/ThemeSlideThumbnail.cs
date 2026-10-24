using System;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;
using ProPresenter.Rendering;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Templates;

[TemplatePart(Name = "PART_SelectionBorder", Type = typeof(Border))]
[TemplatePart(Name = "PART_ThumbnailBorder", Type = typeof(Border))]
[TemplatePart(Name = "PART_Thumbnail", Type = typeof(Image))]
[TemplatePart(Name = "PART_Name", Type = typeof(EditableTextBlock))]
[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_themeChangeDebouncer" })]
public class ThemeSlideThumbnail : ContentControl, IDisposable
{
	private const string PART_SelectionBorder = "PART_SelectionBorder";

	private const string PART_ThumbnailBorder = "PART_ThumbnailBorder";

	private const string PART_Thumbnail = "PART_Thumbnail";

	private const string PART_Name = "PART_Name";

	private readonly IDebouncer<CustomSlide> _themeChangeDebouncer;

	private readonly ISlidePreviewService _slidePreviewService;

	private Border? _selectionBorder;

	private Border? _thumbnailBorder;

	private Image? _thumbnail;

	private bool _isSelected;

	private readonly IThemeService _themeService;

	private EditableTextBlock? _nameLabel;

	public static readonly DependencyProperty TemplateSlideTooltipTextProperty;

	public static readonly DependencyProperty IsMediaActionEnabledProperty;

	public static readonly DependencyProperty SupportsMediaActionThumbnailProperty;

	public static readonly DependencyProperty GroupProperty;

	public static readonly DependencyProperty HasThumbnailProperty;

	public static readonly DependencyProperty RenameTemplateSlideCommandProperty;

	public static readonly DependencyProperty ShowThemeNotificationIndicatorProperty;

	public static readonly DependencyProperty TemplateSlideProperty;

	public static readonly DependencyProperty SelectedTemplateSlideProperty;

	public static readonly DependencyProperty SelectTemplateSlideCommandProperty;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TemplateSlide TemplateSlide
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(TemplateSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateSlideProperty, (object)value);
		}
	}

	public TemplateSlide SelectedTemplateSlide
	{
		get
		{
			return (TemplateSlide)((DependencyObject)this).GetValue(SelectedTemplateSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTemplateSlideProperty, (object)value);
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

	public bool ShowThemeNotificationIndicator
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowThemeNotificationIndicatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowThemeNotificationIndicatorProperty, (object)value);
		}
	}

	public ICommand RenameTemplateSlideCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(RenameTemplateSlideCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenameTemplateSlideCommandProperty, (object)value);
		}
	}

	public bool HasThumbnail
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HasThumbnailProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HasThumbnailProperty, (object)value);
		}
	}

	public ThemePickerGroup Group
	{
		get
		{
			return (ThemePickerGroup)((DependencyObject)this).GetValue(GroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GroupProperty, (object)value);
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

	public bool SupportsMediaActionThumbnail
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SupportsMediaActionThumbnailProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SupportsMediaActionThumbnailProperty, (object)value);
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

	private static void OnTemplateSlidePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ThemeSlideThumbnail)(object)d).OnTemplateSlideChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TemplateSlide, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TemplateSlide);
	}

	private static void OnSelectedTemplateSlideChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ThemeSlideThumbnail)(object)d).SelectedTemplateSlideChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TemplateSlide);
	}

	private static void OnMediaActionEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ThemeSlideThumbnail { TemplateSlide: not null } themeSlideThumbnail)
		{
			themeSlideThumbnail.UpdateThumbnail(themeSlideThumbnail.TemplateSlide.Slide);
		}
	}

	static ThemeSlideThumbnail()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		TemplateSlideTooltipTextProperty = DependencyProperty.Register("TemplateSlideTooltipText", typeof(string), typeof(ThemeSlideThumbnail), new PropertyMetadata((PropertyChangedCallback)null));
		IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(ThemeSlideThumbnail), new PropertyMetadata((object)true, new PropertyChangedCallback(OnMediaActionEnabledChanged)));
		SupportsMediaActionThumbnailProperty = DependencyProperty.Register("SupportsMediaActionThumbnail", typeof(bool), typeof(ThemeSlideThumbnail), new PropertyMetadata((object)true, new PropertyChangedCallback(OnMediaActionEnabledChanged)));
		GroupProperty = DependencyProperty.Register("Group", typeof(ThemePickerGroup), typeof(ThemeSlideThumbnail), new PropertyMetadata((PropertyChangedCallback)null));
		HasThumbnailProperty = DependencyProperty.Register("HasThumbnail", typeof(bool), typeof(ThemeSlideThumbnail), new PropertyMetadata((object)false));
		RenameTemplateSlideCommandProperty = DependencyProperty.Register("RenameTemplateSlideCommand", typeof(ICommand), typeof(ThemeSlideThumbnail), new PropertyMetadata((PropertyChangedCallback)null));
		ShowThemeNotificationIndicatorProperty = DependencyProperty.Register("ShowThemeNotificationIndicator", typeof(bool), typeof(ThemeSlideThumbnail), new PropertyMetadata((object)false));
		TemplateSlideProperty = DependencyProperty.Register("TemplateSlide", typeof(TemplateSlide), typeof(ThemeSlideThumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTemplateSlidePropertyChanged)));
		SelectedTemplateSlideProperty = DependencyProperty.Register("SelectedTemplateSlide", typeof(TemplateSlide), typeof(ThemeSlideThumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTemplateSlideChanged)));
		SelectTemplateSlideCommandProperty = DependencyProperty.Register("SelectTemplateSlideCommand", typeof(ICommand<TemplateSlide>), typeof(ThemeSlideThumbnail));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ThemeSlideThumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ThemeSlideThumbnail)));
	}

	public ThemeSlideThumbnail()
	{
		IDebouncerFactory service = UIServiceProvider.GetService<IDebouncerFactory>();
		IAsyncExecutor asyncExecutor = UIServiceProvider.GetService<IAsyncExecutor>();
		_slidePreviewService = UIServiceProvider.GetService<ISlidePreviewService>();
		_themeChangeDebouncer = service.Create(delegate(CustomSlide s)
		{
			asyncExecutor.ExecuteAsync(() => CreateThumbnail(s));
		});
		_themeService = UIServiceProvider.GetService<IThemeService>();
		RenameTemplateSlideCommand = new RelayCommand(delegate
		{
			_nameLabel?.EnterEditMode();
		});
	}

	public override void OnApplyTemplate()
	{
		_selectionBorder = (Border)(object)GetTemplateChild("PART_SelectionBorder");
		_thumbnailBorder = (Border)(object)GetTemplateChild("PART_ThumbnailBorder");
		_thumbnail = (Image)(object)GetTemplateChild("PART_Thumbnail");
		_nameLabel = (EditableTextBlock)(object)GetTemplateChild("PART_Name");
		((DependencyObject?)(object)_nameLabel)?.Bind(EditableTextBlock.TextProperty, TemplateSlide, "Name");
		((DependencyObject?)(object)_thumbnail)?.Bind(FrameworkElement.ToolTipProperty, this, "TemplateSlideTooltipText");
		CreateThumbnailAndUpdateSelectionAsync().ExecuteAsync();
	}

	private async Task CreateThumbnailAndUpdateSelectionAsync()
	{
		await CreateThumbnail(TemplateSlide?.Slide);
		SelectedTemplateSlideChanged(SelectedTemplateSlide);
	}

	private void OnTemplateSlideChanged(TemplateSlide? oldSlide, TemplateSlide? newSlide)
	{
		TearDownTemplateSlide(oldSlide);
		SetupTemplateSlide(newSlide);
	}

	private void TearDownTemplateSlide(TemplateSlide? templateSlide)
	{
		if (templateSlide != null)
		{
			templateSlide.VisualInvalidated -= Templatelide_VisualInvalidated;
		}
	}

	private void SetupTemplateSlide(TemplateSlide? templateSlide)
	{
		if (templateSlide != null)
		{
			templateSlide.VisualInvalidated += Templatelide_VisualInvalidated;
			UpdateThumbnail(templateSlide.Slide);
		}
	}

	private void Templatelide_VisualInvalidated(TemplateSlide templateSlide)
	{
		UpdateThumbnail(templateSlide.Slide);
	}

	private void UpdateThumbnail(CustomSlide slide)
	{
		_themeChangeDebouncer?.Invoke(slide);
	}

	private async Task CreateThumbnail(CustomSlide? slide)
	{
		if (slide == null || _thumbnailBorder == null || _thumbnail == null)
		{
			return;
		}
		Vector2<double> targetSize = await ((DispatcherObject)this).Dispatcher.InvokeAsync<Vector2<double>>((Func<Vector2<double>>)(() => new Vector2<double>(_thumbnailBorder.Width, _thumbnailBorder.Height)));
		Vector2<double> slideSize = slide.Size.ScaleToFitSize(targetSize);
		bool includeBackgroundMedia = await ((DispatcherObject)this).Dispatcher.InvokeAsync<bool>((Func<bool>)(() => SupportsMediaActionThumbnail && IsMediaActionEnabled));
		SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(slideSize.Cast<int>(), IncludeBackground: true, includeBackgroundMedia, Colors.Transparent, ElementsRenderOption.None, null, IncludeTextPlaceholder: true);
		IBitmapHandle bitmap = await _slidePreviewService.RenderSlidePreviewAsync(slide, renderParams);
		try
		{
			await ((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
			{
				_thumbnail.Source = bitmap.BitmapSource;
				HasThumbnail = true;
			});
		}
		finally
		{
			if (bitmap != null)
			{
				bitmap.Dispose();
			}
		}
	}

	private void SelectedTemplateSlideChanged(TemplateSlide? templateSlide)
	{
		_isSelected = templateSlide != null && TemplateSlide != null && templateSlide.ID == TemplateSlide.ID;
		if (_selectionBorder != null)
		{
			_selectionBorder.BorderBrush = (_isSelected ? ((Brush)AppTheme.Active.SECONDARY) : Brushes.Transparent);
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		base.OnMouseUp(e);
		if (e.ChangedButton == MouseButton.Left)
		{
			SelectTemplateSlideCommand?.Invoke(TemplateSlide);
			_themeService?.AddRecentlyAppliedTemplateSlideAsync(TemplateSlide.ID);
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_themeChangeDebouncer.Dispose();
		}
	}
}
