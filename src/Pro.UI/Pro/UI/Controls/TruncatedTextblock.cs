using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Text;

namespace Pro.UI.Controls;

public class TruncatedTextblock : ContentControl
{
	private const string ReplaceString = "…";

	private FormattedText? _formattedText;

	public static readonly DependencyProperty LineHeightProperty;

	public static readonly DependencyProperty HorizontalTextAlignmentProperty;

	public static readonly DependencyProperty VerticalTextAlignmentProperty;

	public static readonly DependencyProperty TextProperty;

	public static readonly DependencyProperty TruncatingModeProperty;

	public double LineHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LineHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LineHeightProperty, (object)value);
		}
	}

	public ParagraphAlignment HorizontalTextAlignment
	{
		get
		{
			return (ParagraphAlignment)((DependencyObject)this).GetValue(HorizontalTextAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HorizontalTextAlignmentProperty, (object)value);
		}
	}

	public DocumentAlignment VerticalTextAlignment
	{
		get
		{
			return (DocumentAlignment)((DependencyObject)this).GetValue(VerticalTextAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VerticalTextAlignmentProperty, (object)value);
		}
	}

	public string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public TruncatingMode TruncatingMode
	{
		get
		{
			return (TruncatingMode)((DependencyObject)this).GetValue(TruncatingModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TruncatingModeProperty, (object)value);
		}
	}

	private static void TextPropertiesChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((TruncatedTextblock)(object)callerObject).OnTextPropertiesChanged();
	}

	static TruncatedTextblock()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		LineHeightProperty = TextBlock.LineHeightProperty.AddOwner(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
		HorizontalTextAlignmentProperty = DependencyProperty.Register("HorizontalTextAlignment", typeof(ParagraphAlignment), typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ParagraphAlignment.Left, new PropertyChangedCallback(TextPropertiesChanged)));
		VerticalTextAlignmentProperty = DependencyProperty.Register("VerticalTextAlignment", typeof(DocumentAlignment), typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DocumentAlignment.Top, new PropertyChangedCallback(TextPropertiesChanged)));
		TextProperty = TextBlock.TextProperty.AddOwner(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
		TruncatingModeProperty = DependencyProperty.Register("TruncatingMode", typeof(TruncatingMode), typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TruncatingMode.End, new PropertyChangedCallback(TextPropertiesChanged)));
		Control.FontFamilyProperty.OverrideMetadata(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
		Control.FontStyleProperty.OverrideMetadata(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
		Control.FontWeightProperty.OverrideMetadata(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
		Control.FontStretchProperty.OverrideMetadata(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
		Control.FontSizeProperty.OverrideMetadata(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
		Control.ForegroundProperty.OverrideMetadata(typeof(TruncatedTextblock), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertiesChanged)));
	}

	public TruncatedTextblock()
	{
		base.ClipToBounds = true;
	}

	protected override Size ArrangeOverride(Size arrangeBounds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		OnTextPropertiesChanged();
		return base.ArrangeOverride(arrangeBounds);
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		base.OnRender(drawingContext);
		UpdateText(new Vector2<double>(base.ActualWidth, base.ActualHeight));
		if (_formattedText != null)
		{
			Vector2<double> zero = Vector2<double>.Zero;
			if (VerticalTextAlignment == DocumentAlignment.Middle)
			{
				zero.Y = (base.ActualHeight - _formattedText.Height) / 2.0;
			}
			else if (VerticalTextAlignment == DocumentAlignment.Bottom)
			{
				zero.Y = base.ActualHeight - _formattedText.Height;
			}
			drawingContext.DrawText(_formattedText, zero);
		}
	}

	private void OnTextPropertiesChanged()
	{
		_formattedText = null;
		InvalidateVisual();
	}

	private void UpdateText(Vector2<double> maxSize)
	{
		if (_formattedText != null || string.IsNullOrWhiteSpace(Text))
		{
			return;
		}
		bool flag = false;
		string text = Text.Trim();
		int num = -1;
		while (_formattedText == null || _formattedText.Height > maxSize.Y)
		{
			string text2 = (flag ? text.Insert(num, "…") : text);
			_formattedText = CreateFormattedText(text2, maxSize.X);
			if (text.Length <= 1 || _formattedText.Height <= maxSize.Y)
			{
				break;
			}
			flag = true;
			switch (TruncatingMode)
			{
			case TruncatingMode.Beginning:
			{
				int num3 = text.FindIndex(char.IsWhiteSpace);
				text = ((num3 < 0) ? text.Substring(1) : text.Substring(num3 + 1).TrimStart());
				num = 0;
				break;
			}
			case TruncatingMode.Middle:
			{
				num = text.Length / 2;
				int num4 = text.FindIndex(char.IsWhiteSpace, num);
				int num5 = FindPreviousIndex(text, num - 1, char.IsWhiteSpace);
				if (num5 >= 0 && num4 >= 0)
				{
					text = text.Remove(num5, num4 - num5);
					num = num5;
				}
				else if (num5 >= 0)
				{
					num4 = num5;
					num5 = FindPreviousIndex(text, num4 - 1, char.IsWhiteSpace);
					if (num5 >= 0)
					{
						text = text.Remove(num5, num4 - num5);
						num = num5;
					}
					else
					{
						text = text.Substring(num4).TrimStart();
						num = 0;
					}
				}
				else if (num4 >= 0)
				{
					num5 = num4;
					num4 = text.FindIndex(char.IsWhiteSpace, num5 + 1);
					if (num4 >= 0)
					{
						text = text.Remove(num5, num4 - num5);
						num = num5;
					}
					else
					{
						text = text.Substring(0, num5).TrimEnd();
						num = text.Length;
					}
				}
				else
				{
					text = text.Remove(num, 1);
				}
				break;
			}
			case TruncatingMode.End:
			{
				int num2 = FindPreviousIndex(text, text.Length - 1, char.IsWhiteSpace);
				text = ((num2 < 0) ? text.Substring(0, text.Length - 1) : text.Substring(0, num2).TrimEnd());
				num = text.Length;
				break;
			}
			}
		}
	}

	private FormattedText CreateFormattedText(string text, double maxWidth)
	{
		Typeface typeface = new Typeface(base.FontFamily, base.FontStyle, base.FontWeight, base.FontStretch);
		return new FormattedText(text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, typeface, base.FontSize, base.Foreground)
		{
			LineHeight = (double.IsNaN(LineHeight) ? 0.0 : LineHeight),
			TextAlignment = GetTextAlignment(),
			MaxTextWidth = maxWidth,
			Trimming = TextTrimming.None
		};
	}

	private TextAlignment GetTextAlignment()
	{
		return HorizontalTextAlignment switch
		{
			ParagraphAlignment.Left => TextAlignment.Left, 
			ParagraphAlignment.Center => TextAlignment.Center, 
			ParagraphAlignment.Right => TextAlignment.Right, 
			ParagraphAlignment.Justified => TextAlignment.Justify, 
			_ => throw new NotSupportedException(), 
		};
	}

	private int FindPreviousIndex(string text, int startingIndex, Predicate<char> predicate)
	{
		for (int num = startingIndex; num >= 0; num--)
		{
			if (predicate(text[num]))
			{
				return num;
			}
		}
		return -1;
	}
}
