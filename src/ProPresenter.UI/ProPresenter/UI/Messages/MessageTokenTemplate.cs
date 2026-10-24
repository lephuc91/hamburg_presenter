using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Messages;

public partial class MessageTokenTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TextProperty;

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

	public MessageTokenTemplate()
	{
		InitializeComponent();
	}

	static MessageTokenTemplate()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Type? typeFromHandle = typeof(string);
		Type? typeFromHandle2 = typeof(MessageTokenTemplate);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata((object)string.Empty);
		((PropertyMetadata)frameworkPropertyMetadata).CoerceValueCallback = (CoerceValueCallback)((DependencyObject d, object baseValue) => baseValue ?? string.Empty);
		TextProperty = DependencyProperty.Register("Text", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
	}
}
