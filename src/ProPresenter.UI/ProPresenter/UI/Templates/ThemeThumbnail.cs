using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
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
public class ThemeThumbnail : ContentControl, IDisposable
{
	private const string PART_SelectionBorder = "PART_SelectionBorder";

	private const string PART_ThumbnailBorder = "PART_ThumbnailBorder";

	private const string PART_Thumbnail = "PART_Thumbnail";

	private const string PART_Name = "PART_Name";

	private readonly IDebouncer<CustomSlide> _themeChangeDebouncer;

	private readonly ISlidePreviewService _slidePreviewService;

	private readonly ObservableDictionary<Guid, BitmapSource> _slideBitmaps = new ObservableDictionary<Guid, BitmapSource>();

	private Border? _selectionBorder;

	private Border? _thumbnailBorder;

	private Image? _thumbnail;

	private EditableTextBlock? _editTextBlock;

	private bool _isSelected;

	public static readonly DependencyProperty IsMediaActionEnabledProperty;

	public static readonly DependencyProperty GroupProperty;

	public static readonly DependencyProperty HasThumbnailProperty;

	public static readonly DependencyProperty ShowThemeNotificationIndicatorProperty;

	public static readonly DependencyProperty ShowMouseHoverPreviewProperty;

	public static readonly DependencyProperty ThemeProperty;

	public static readonly DependencyProperty SelectedTemplateSlideProperty;

	public static readonly DependencyProperty SelectThemeCommandProperty;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

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

	public bool ShowMouseHoverPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMouseHoverPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMouseHoverPreviewProperty, (object)value);
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

	private static void OnThemePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ThemeThumbnail)(object)d).OnThemeChangedAsync(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as Theme, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as Theme).ExecuteAsync();
	}

	private static void OnSelectedTemplateSlideChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ThemeThumbnail)(object)d).SelectedTemplateSlideChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TemplateSlide);
	}

	private static void OnMediaActionEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		ThemeThumbnail themeThumbnail = d as ThemeThumbnail;
		if (themeThumbnail != null && themeThumbnail.Theme != null)
		{
			themeThumbnail.Theme.ForEach(async delegate(TemplateSlide theme)
			{
				await themeThumbnail.CreateThumbnailAsync(theme.Slide);
				themeThumbnail.SetDefaultThumbnail();
			});
		}
	}

	static ThemeThumbnail()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		IsMediaActionEnabledProperty = DependencyProperty.Register("IsMediaActionEnabled", typeof(bool), typeof(ThemeThumbnail), new PropertyMetadata((object)true, new PropertyChangedCallback(OnMediaActionEnabledChanged)));
		GroupProperty = DependencyProperty.Register("Group", typeof(ThemePickerGroup), typeof(ThemeThumbnail), new PropertyMetadata((PropertyChangedCallback)null));
		HasThumbnailProperty = DependencyProperty.Register("HasThumbnail", typeof(bool), typeof(ThemeThumbnail), new PropertyMetadata((object)false));
		ShowThemeNotificationIndicatorProperty = DependencyProperty.Register("ShowThemeNotificationIndicator", typeof(bool), typeof(ThemeThumbnail), new PropertyMetadata((object)false));
		ShowMouseHoverPreviewProperty = DependencyProperty.Register("ShowMouseHoverPreview", typeof(bool), typeof(ThemeThumbnail), new PropertyMetadata((object)true));
		ThemeProperty = DependencyProperty.Register("Theme", typeof(Theme), typeof(ThemeThumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnThemePropertyChanged)));
		SelectedTemplateSlideProperty = DependencyProperty.Register("SelectedTemplateSlide", typeof(TemplateSlide), typeof(ThemeThumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedTemplateSlideChanged)));
		SelectThemeCommandProperty = DependencyProperty.Register("SelectThemeCommand", typeof(ICommand<Theme>), typeof(ThemeThumbnail));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ThemeThumbnail), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ThemeThumbnail)));
	}

	public ThemeThumbnail()
	{
		ThemeThumbnail themeThumbnail = this;
		_slidePreviewService = UIServiceProvider.GetService<ISlidePreviewService>();
		IDebouncerFactory service = UIServiceProvider.GetService<IDebouncerFactory>();
		IAsyncExecutor asyncExecutor = UIServiceProvider.GetService<IAsyncExecutor>();
		_themeChangeDebouncer = service.Create(delegate(CustomSlide t)
		{
			asyncExecutor.ExecuteAsync(() => themeThumbnail.CreateThumbnailAsync(t));
		}, 200.0);
		_slideBitmaps.CollectionChanged += SlideBitmaps_CollectionChanged;
	}

	public override void OnApplyTemplate()
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		_selectionBorder = (Border)(object)GetTemplateChild("PART_SelectionBorder");
		_thumbnailBorder = (Border)(object)GetTemplateChild("PART_ThumbnailBorder");
		_thumbnail = (Image)(object)GetTemplateChild("PART_Thumbnail");
		_editTextBlock = (EditableTextBlock)(object)GetTemplateChild("PART_Name");
		((DependencyObject?)(object)_editTextBlock)?.Bind(EditableTextBlock.TextProperty, Theme, "Name");
		((DependencyObject?)(object)_editTextBlock)?.Bind(FrameworkElement.ToolTipProperty, Theme, "Name");
		if (_thumbnail != null)
		{
			_thumbnail.MouseEnter += Thumbnail_MouseEnter;
			_thumbnail.MouseMove += Thumbnail_MouseMove;
			_thumbnail.MouseLeave += Thumbnail_MouseLeave;
			_thumbnail.IsVisibleChanged += new DependencyPropertyChangedEventHandler(Thumbnail_IsVisibleChanged);
		}
		_slideBitmaps.Clear();
		CreateThumbnailsAndUpdateSelectionAsync().ExecuteAsync();
	}

	private async Task CreateThumbnailsAndUpdateSelectionAsync()
	{
		await CreateThumbnails(Theme);
		SelectedTemplateSlideChanged(SelectedTemplateSlide);
	}

	private void Thumbnail_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			SetDefaultThumbnail();
		}
	}

	private void Thumbnail_MouseEnter(object? sender, MouseEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (ShowMouseHoverPreview)
		{
			Point position = e.GetPosition(_thumbnail);
			SetThumbnail(((Point)(ref position)).X);
		}
	}

	private void Thumbnail_MouseMove(object? sender, MouseEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (ShowMouseHoverPreview)
		{
			Point position = e.GetPosition(_thumbnail);
			SetThumbnail(((Point)(ref position)).X);
		}
	}

	private void Thumbnail_MouseLeave(object? sender, MouseEventArgs e)
	{
		SetDefaultThumbnail();
	}

	private void SlideBitmaps_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		SetDefaultThumbnail();
	}

	private void SetDefaultThumbnail()
	{
		TemplateSlide templateSlide = Theme?.FirstOrDefault();
		if (templateSlide?.Slide != null && _thumbnail != null && _slideBitmaps.TryGetValue(templateSlide.Slide.ID, out BitmapSource value))
		{
			_thumbnail.Source = value;
			HasThumbnail = true;
		}
	}

	private void SetThumbnail(double mousePos)
	{
		if (_thumbnail != null && !_slideBitmaps.Empty())
		{
			double num = _thumbnail.ActualWidth / (double)_slideBitmaps.Count;
			int index = (int)Math.Round(mousePos / num);
			KeyValuePair<Guid, BitmapSource> keyValuePair = _slideBitmaps.ElementAtOrDefault(index);
			if (keyValuePair.Value != null)
			{
				_thumbnail.Source = keyValuePair.Value;
			}
		}
	}

	private async Task OnThemeChangedAsync(Theme? oldTheme, Theme? newTheme)
	{
		if (oldTheme != null)
		{
			oldTheme.CollectionChanged -= Theme_CollectionChanged;
			TeardownTemplateSlides(oldTheme);
		}
		if (newTheme != null)
		{
			newTheme.CollectionChanged += Theme_CollectionChanged;
			SetupTemplateSlides(newTheme);
		}
		await CreateThumbnails(newTheme);
	}

	private void Theme_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems is IEnumerable<TemplateSlide> templateSlides)
		{
			TeardownTemplateSlides(templateSlides);
		}
		if (e.NewItems is IEnumerable<TemplateSlide> enumerable)
		{
			SetupTemplateSlides(enumerable);
			CreateThumbnails(enumerable).ExecuteAsync();
		}
	}

	private void TeardownTemplateSlides(IEnumerable<TemplateSlide> templateSlides)
	{
		templateSlides.ForEach(delegate(TemplateSlide t)
		{
			t.VisualInvalidated -= TemplateSlide_VisualInvalidated;
			_slideBitmaps.Remove(t.Slide.ID);
		});
	}

	private void SetupTemplateSlides(IEnumerable<TemplateSlide> templateSlides)
	{
		templateSlides.ForEach(delegate(TemplateSlide t)
		{
			t.VisualInvalidated += TemplateSlide_VisualInvalidated;
		});
	}

	private void TemplateSlide_VisualInvalidated(TemplateSlide templateSlide)
	{
		UpdateThumbnail(templateSlide.Slide);
	}

	private void UpdateThumbnail(CustomSlide slide)
	{
		_themeChangeDebouncer?.Invoke(slide);
	}

	private async Task CreateThumbnails(IEnumerable<TemplateSlide>? newSlides)
	{
		if (newSlides == null)
		{
			return;
		}
		foreach (TemplateSlide newSlide in newSlides)
		{
			await CreateThumbnailAsync(newSlide.Slide);
		}
	}

	private async Task CreateThumbnailAsync(CustomSlide slide)
	{
		if (slide == null || _thumbnailBorder == null)
		{
			return;
		}
		Vector2<double> targetSize = await ((DispatcherObject)this).Dispatcher.InvokeAsync<Vector2<double>>((Func<Vector2<double>>)(() => new Vector2<double>(_thumbnailBorder.Width, _thumbnailBorder.Height)));
		Vector2<double> slideSize = slide.Size.ScaleToFitSize(targetSize);
		bool includeBackgroundMedia = await ((DispatcherObject)this).Dispatcher.InvokeAsync<bool>((Func<bool>)(() => IsMediaActionEnabled));
		SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(slideSize.Cast<int>(), IncludeBackground: true, includeBackgroundMedia, Colors.Transparent, ElementsRenderOption.None, null, IncludeTextPlaceholder: true);
		IBitmapHandle bitmap = await _slidePreviewService.RenderSlidePreviewAsync(slide, renderParams);
		try
		{
			await ((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
			{
				if (bitmap?.BitmapSource != null)
				{
					_slideBitmaps[slide.ID] = bitmap.BitmapSource;
				}
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
		_isSelected = templateSlide != null && Theme != null && templateSlide.ParentTheme?.Path == Theme.Path;
		if (_selectionBorder != null)
		{
			_selectionBorder.BorderBrush = (_isSelected ? ((Brush)AppTheme.Active.SECONDARY) : Brushes.Transparent);
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			SelectThemeCommand?.Invoke(Theme);
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
