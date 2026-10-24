using System.Windows;
using System.Windows.Input;

namespace Pro.UI.Controls;

public class SearchBox : PlaceholderTextBox
{
	public static readonly DependencyProperty EscapeToClearInputProperty;

	public bool EscapeToClearInput
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(EscapeToClearInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EscapeToClearInputProperty, (object)value);
		}
	}

	static SearchBox()
	{
		EscapeToClearInputProperty = DependencyProperty.Register("EscapeToClearInput", typeof(bool), typeof(SearchBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		PlaceholderTextBox.ShowClearButtonProperty.OverrideMetadata(typeof(SearchBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		PlaceholderTextBox.PlaceholderPathTypeProperty.OverrideMetadata(typeof(SearchBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PathType.Magnifier));
	}

	protected override void HandleKeyEvent(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13 && EscapeToClearInput)
		{
			ClearInput();
		}
		base.HandleKeyEvent(e);
	}
}
