using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Messages;

public partial class TextTokenTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TokenNameProperty;

	public static readonly DependencyProperty TextProperty;

	public string TokenName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TokenNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokenNameProperty, (object)value);
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

	public TextTokenTemplate()
	{
		InitializeComponent();
	}

	static TextTokenTemplate()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		Type? typeFromHandle = typeof(string);
		Type? typeFromHandle2 = typeof(TextTokenTemplate);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata((object)string.Empty);
		((PropertyMetadata)frameworkPropertyMetadata).CoerceValueCallback = (CoerceValueCallback)((DependencyObject d, object baseValue) => baseValue ?? string.Empty);
		TokenNameProperty = DependencyProperty.Register("TokenName", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		Type? typeFromHandle3 = typeof(string);
		Type? typeFromHandle4 = typeof(TextTokenTemplate);
		FrameworkPropertyMetadata frameworkPropertyMetadata2 = new FrameworkPropertyMetadata((object)string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault);
		((PropertyMetadata)frameworkPropertyMetadata2).CoerceValueCallback = (CoerceValueCallback)((DependencyObject d, object baseValue) => baseValue ?? string.Empty);
		TextProperty = DependencyProperty.Register("Text", typeFromHandle3, typeFromHandle4, (PropertyMetadata)(object)frameworkPropertyMetadata2);
	}
}
