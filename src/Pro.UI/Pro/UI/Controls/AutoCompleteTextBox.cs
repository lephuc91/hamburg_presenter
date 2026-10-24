using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.Common.Collections;

namespace Pro.UI.Controls;

public class AutoCompleteTextBox : TextBox
{
	private bool _ignoreChanges;

	public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable<string>), typeof(AutoCompleteTextBox));

	public IEnumerable<string>? ItemsSource
	{
		get
		{
			return (IEnumerable<string>)((DependencyObject)this).GetValue(ItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceProperty, (object)value);
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6 && base.SelectionLength > 0 && base.SelectionStart + base.SelectionLength == base.Text.Length)
		{
			int selectionStart = (base.CaretIndex = base.Text.Length);
			base.SelectionStart = selectionStart;
			base.SelectionLength = 0;
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		if (e.Changes.Where((TextChange c) => c.AddedLength > 0).Any())
		{
			IEnumerable<string>? itemsSource = ItemsSource;
			if (itemsSource != null && itemsSource.Any() && !string.IsNullOrEmpty(base.Text) && !_ignoreChanges)
			{
				int textLength = base.Text.Length;
				string text = (from v in ItemsSource.NonNull()
					where v.Length >= textLength
					where v.Substring(0, textLength).Equals(base.Text, StringComparison.InvariantCultureIgnoreCase)
					select v).FirstOrDefault();
				if (!string.IsNullOrEmpty(text))
				{
					_ignoreChanges = true;
					((DependencyObject)this).SetCurrentValue(TextBox.TextProperty, (object)text);
					base.CaretIndex = textLength;
					base.SelectionStart = textLength;
					base.SelectionLength = text.Length;
					_ignoreChanges = false;
				}
			}
		}
		base.OnTextChanged(e);
	}
}
