using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.Text;
using Pro.Text.Fills;
using Pro.Text.Reversibility;
using Pro.UI.DependencyInjection;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.SlideEditor.Inspectors.Text;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_mediaChangeDebouncer" })]
public partial class TextBackgroundBlurFill : UserControl, IComponentConnector, IDisposable
{
	private readonly IDebouncer<double> _mediaChangeDebouncer;

	private bool _ignoreChanges;

	public static readonly DependencyProperty SlideProperty = DependencyProperty.Register("SelectedSlide", typeof(CustomSlide), typeof(TextBackgroundBlurFill), new PropertyMetadata(new PropertyChangedCallback(OnSelectedSlidePropertyChanged)));

	public static readonly DependencyProperty ApplyParagraphSettingsProviderProperty = DependencyProperty.Register("ApplyParagraphSettingsProvider", typeof(ApplyParagraphSettingsDelegate), typeof(TextBackgroundBlurFill));

	public static readonly DependencyProperty ApplyRunSettingsProviderProperty = DependencyProperty.Register("ApplyRunSettingsProvider", typeof(ApplyRunSettingsDelegate), typeof(TextBackgroundBlurFill));

	public static readonly DependencyProperty BlurAmountProperty = DependencyProperty.Register("BlurAmount", typeof(double), typeof(TextBackgroundBlurFill), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(UpdateFill)));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(TextFillBase), typeof(TextBackgroundBlurFill), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnFillPropertyChanged)));

	public static readonly DependencyProperty SaturationProperty = DependencyProperty.Register("Saturation", typeof(double), typeof(TextBackgroundBlurFill), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(UpdateFill)));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ApplyParagraphSettingsDelegate? ApplyParagraphSettingsProvider
	{
		get
		{
			return (ApplyParagraphSettingsDelegate)((DependencyObject)this).GetValue(ApplyParagraphSettingsProviderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ApplyParagraphSettingsProviderProperty, (object)value);
		}
	}

	public ApplyRunSettingsDelegate? ApplyRunSettingsProvider
	{
		get
		{
			return (ApplyRunSettingsDelegate)((DependencyObject)this).GetValue(ApplyRunSettingsProviderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ApplyRunSettingsProviderProperty, (object)value);
		}
	}

	public Func<IReadOnlyList<TextDocument>?>? GetDocumentsAction { get; set; }

	public double BlurAmount
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BlurAmountProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BlurAmountProperty, (object)value);
		}
	}

	public TextFillBase? Fill
	{
		get
		{
			return (TextFillBase)((DependencyObject)this).GetValue(FillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillProperty, (object)value);
		}
	}

	public double Saturation
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SaturationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SaturationProperty, (object)value);
		}
	}

	public CustomSlide? SelectedSlide
	{
		get
		{
			return (CustomSlide)((DependencyObject)this).GetValue(SlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideProperty, (object)value);
		}
	}

	private static void OnSelectedSlidePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TextBackgroundBlurFill textBackgroundBlurFill = (TextBackgroundBlurFill)(object)d;
		CustomSlide customSlide = (CustomSlide)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		CustomSlide customSlide2 = (CustomSlide)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (customSlide != null)
		{
			customSlide.PropertyChanged -= textBackgroundBlurFill.SelectedSlideOnPropertyChanged;
		}
		if (customSlide2 != null)
		{
			textBackgroundBlurFill.BlurAmount = customSlide2.BlurAmount;
			customSlide2.PropertyChanged += textBackgroundBlurFill.SelectedSlideOnPropertyChanged;
		}
	}

	private void SelectedSlideOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!_ignoreChanges)
		{
			_ignoreChanges = true;
			BlurAmount = SelectedSlide?.BlurAmount ?? 0.0;
			_ignoreChanges = false;
		}
	}

	public TextBackgroundBlurFill()
	{
		InitializeComponent();
		IDebouncerFactory service = UIServiceProvider.GetService<IDebouncerFactory>();
		_mediaChangeDebouncer = service.CreateDispatched<double>(delegate
		{
			_ignoreChanges = true;
			ChangeFill();
			_ignoreChanges = false;
		}, 200.0);
	}

	private void ChangeFill()
	{
		TextFillUtility.ChangeFill(GetDocumentsAction, new BackgroundBlurTextFill(Saturation, BlurAmount), UndoActionTypes.TextBackgroundBlurFill, ApplyRunSettingsProvider, ApplyParagraphSettingsProvider, delegate(BackgroundBlurTextFill f)
		{
			((DependencyObject)this).SetCurrentValue(FillProperty, (object)f);
		});
		if (SelectedSlide != null)
		{
			SelectedSlide.BlurAmount = BlurAmount;
		}
	}

	private static void UpdateFill(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TextBackgroundBlurFill textBackgroundBlurFill = (TextBackgroundBlurFill)(object)d;
		if (!textBackgroundBlurFill._ignoreChanges)
		{
			textBackgroundBlurFill._mediaChangeDebouncer.Invoke((double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private void OnFillChanged(BackgroundBlurTextFill? newValue)
	{
		if (!_ignoreChanges && newValue != null)
		{
			_ignoreChanges = true;
			Saturation = newValue.Saturation;
			_ignoreChanges = false;
		}
	}

	private static void OnFillPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TextBackgroundBlurFill)(object)d).OnFillChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as BackgroundBlurTextFill);
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
			_mediaChangeDebouncer.Dispose();
		}
	}
}
