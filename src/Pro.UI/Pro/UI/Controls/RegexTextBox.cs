using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pro.UI.Controls;

public class RegexTextBox : TextBox
{
	public static readonly DependencyProperty AllowSpaceProperty = DependencyProperty.Register("AllowSpace", typeof(bool), typeof(RegexTextBox), new PropertyMetadata((object)true));

	public static readonly DependencyProperty RegexStringProperty = DependencyProperty.Register("RegexString", typeof(string), typeof(RegexTextBox), new PropertyMetadata(new PropertyChangedCallback(OnRegexStringChanged)));

	protected Regex? Regex { get; private set; }

	public bool AllowSpace
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowSpaceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowSpaceProperty, (object)value);
		}
	}

	public string? RegexString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(RegexStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RegexStringProperty, (object)value);
		}
	}

	private static void OnRegexStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((RegexTextBox)(object)d).RegexStringUpdated(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as string, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as string);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		if (!AllowSpace && (int)e.Key == 18)
		{
			e.Handled = true;
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnPreviewTextInput(TextCompositionEventArgs e)
	{
		e.Handled = !(Regex?.IsMatch(e.Text) ?? true);
		base.OnPreviewTextInput(e);
	}

	protected virtual void RegexStringUpdated(string? oldValue, string? newValue)
	{
		Regex = ((!string.IsNullOrWhiteSpace(newValue)) ? new Regex(newValue) : null);
	}
}
