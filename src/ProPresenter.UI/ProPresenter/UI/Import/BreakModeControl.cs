using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Localization;
using ProPresenter.DO.Import;

namespace ProPresenter.UI.Import;

public partial class BreakModeControl : UserControl, IComponentConnector
{
	public static readonly string NewLine = LocalizedStrings.Get(BreakMode.NewLine);

	public static readonly string BlankLine = LocalizedStrings.Get(BreakMode.BlankLine);

	public static readonly DependencyProperty BreakModeProperty = DependencyProperty.Register("BreakMode", typeof(BreakMode), typeof(BreakModeControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)BreakMode.BlankLine, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty CustomDelimiterProperty;

	public BreakMode BreakMode
	{
		get
		{
			return (BreakMode)((DependencyObject)this).GetValue(BreakModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BreakModeProperty, (object)value);
		}
	}

	public string CustomDelimiter
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CustomDelimiterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomDelimiterProperty, (object)value);
		}
	}

	private static object CoerceCustomDelimiter(DependencyObject d, object baseValue)
	{
		if (!(baseValue is string result))
		{
			return string.Empty;
		}
		return result;
	}

	private static void OnCustomDelimiterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BreakModeControl)(object)d).CustomDelimiterChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public BreakModeControl()
	{
		InitializeComponent();
	}

	private void CustomDelimiterChanged(string value)
	{
		if (value.Equals(NewLine))
		{
			((DependencyObject)this).SetCurrentValue(BreakModeProperty, (object)BreakMode.NewLine);
		}
		else if (value.Equals(BlankLine))
		{
			((DependencyObject)this).SetCurrentValue(BreakModeProperty, (object)BreakMode.BlankLine);
		}
		else
		{
			((DependencyObject)this).SetCurrentValue(BreakModeProperty, (object)BreakMode.Custom);
		}
	}

	static BreakModeControl()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		Type? typeFromHandle = typeof(string);
		Type? typeFromHandle2 = typeof(BreakModeControl);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCustomDelimiterChanged));
		((PropertyMetadata)frameworkPropertyMetadata).CoerceValueCallback = new CoerceValueCallback(CoerceCustomDelimiter);
		CustomDelimiterProperty = DependencyProperty.Register("CustomDelimiter", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
	}
}
