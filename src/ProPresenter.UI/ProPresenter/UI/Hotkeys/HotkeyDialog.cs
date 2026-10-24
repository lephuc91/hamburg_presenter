using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Strings;

namespace ProPresenter.UI.Hotkeys;

public partial class HotkeyDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(Key), typeof(HotkeyDialog), new PropertyMetadata((object)(Key)0));

	public Key Key
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Key)((DependencyObject)this).GetValue(KeyProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(KeyProperty, (object)value);
		}
	}

	public HotkeyDialog()
	{
		InitializeComponent();
	}

	private void ValidateTextInput(object? sender, TextCompositionEventArgs e)
	{
		bool flag = RegexFilters.CharactersOnly.IsMatch(e.Text);
		if (flag)
		{
			HotkeyTextBox.Text = string.Empty;
		}
		e.Handled = !flag;
	}

	private void HotkeyDialog_Loaded(object? sender, RoutedEventArgs e)
	{
		HotkeyTextBox.Focus();
	}
}
