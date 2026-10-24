using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Text;

namespace Pro.UI.Controls;

public partial class FormattedTextBlock : FrameworkElement, IComponentConnector
{
	private readonly ArrangedText _text = new ArrangedText(SharedTypefaceLibrary.Library)
	{
		Document = new TextDocument()
	};

	public static readonly DependencyProperty FormattedTextProperty = DependencyProperty.Register("FormattedText", typeof(string), typeof(FormattedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(TextPropertyChangedCallback)));

	public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(int), typeof(FormattedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(12, FrameworkPropertyMetadataOptions.AffectsMeasure, null, new CoerceValueCallback(FontSizeCoerceCallback)));

	public static readonly DependencyProperty FontSelectionProperty = DependencyProperty.Register("FontSelection", typeof(FontInfo), typeof(FormattedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(RunSettings.DefaultFont, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(FontInfoPropertyChangedCallback)));

	public static readonly DependencyProperty UnicodeFontProperty = DependencyProperty.Register("UnicodeFont", typeof(FontInfo), typeof(FormattedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(RunSettings.DefaultFont, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(FontInfoPropertyChangedCallback)));

	public static readonly DependencyProperty FontBrushProperty = DependencyProperty.Register("FontBrush", typeof(Brush), typeof(FormattedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty EnsureUnicodeDisplayProperty = DependencyProperty.Register("EnsureUnicodeDisplay", typeof(bool), typeof(FormattedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(FontInfoPropertyChangedCallback)));

	public string FormattedText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FormattedTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormattedTextProperty, (object)value);
		}
	}

	public int FontSize
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(FontSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FontSizeProperty, (object)value);
		}
	}

	public FontInfo FontSelection
	{
		get
		{
			return (FontInfo)((DependencyObject)this).GetValue(FontSelectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FontSelectionProperty, (object)value);
		}
	}

	public FontInfo UnicodeFont
	{
		get
		{
			return (FontInfo)((DependencyObject)this).GetValue(UnicodeFontProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnicodeFontProperty, (object)value);
		}
	}

	public Brush FontBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(FontBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FontBrushProperty, (object)value);
		}
	}

	public bool EnsureUnicodeDisplay
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EnsureUnicodeDisplayProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnsureUnicodeDisplayProperty, (object)value);
		}
	}

	private static void TextPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		ArrangedText text = ((FormattedTextBlock)(object)d)._text;
		text.Document?.Clear();
		text.Document?.InsertText(text.Document.LastCharacterIndex, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static object FontSizeCoerceCallback(DependencyObject d, object baseValue)
	{
		return ((int)baseValue).Clamp(1, 10000);
	}

	private static void FontInfoPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((FormattedTextBlock)(object)d).ApplyFont();
	}

	public FormattedTextBlock()
	{
		InitializeComponent();
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		ApplyFontSize();
		Vector2<double> vector = (Vector2<double>)base.MeasureOverride(availableSize);
		vector = new Vector2<double>((!double.IsNaN(base.Width)) ? base.Width : ((!double.IsInfinity(((Size)(ref availableSize)).Width) && !double.IsNaN(((Size)(ref availableSize)).Width)) ? ((Size)(ref availableSize)).Width : vector.X), (!double.IsNaN(base.Height)) ? base.Height : ((!double.IsInfinity(((Size)(ref availableSize)).Height) && !double.IsNaN(((Size)(ref availableSize)).Height)) ? ((Size)(ref availableSize)).Height : vector.Y));
		if (_text != null)
		{
			_text.MaxSize = new Vector2<double>(double.PositiveInfinity, double.PositiveInfinity);
			if (!double.IsNaN(_text.ArrangedSize.X) && !double.IsNaN(_text.ArrangedSize.Y))
			{
				return _text.ArrangedSize;
			}
		}
		return vector;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		_text.RenderText(drawingContext, new TextRenderParams(FontBrush, FontBrush, FontBrush, FontBrush, renderShadow: false, renderFill: true, useStandardMaskBrush: false, null, translateOverrideMaskBrush: true, null));
	}

	private void ApplyFont()
	{
		_text.Document?.IterateRuns(Range.All, splitRuns: false, delegate(RunBase r)
		{
			r.Settings.Font = FontSelection;
			if (!FontSelection.IsUnicode && EnsureUnicodeDisplay)
			{
				r.Settings.Font = UnicodeFont;
			}
		});
	}

	private void ApplyFontSize()
	{
		_text.Document?.IterateRuns(Range.All, splitRuns: false, delegate(RunBase r)
		{
			r.Settings.CharacterSize = FontSize;
		});
	}
}
