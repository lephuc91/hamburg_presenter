using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pro.UI.Controls;

public abstract class ValidatingTextBox : RegexTextBox
{
	private Regex? _validationRegex;

	private bool _canUpdateDisplayText = true;

	public static readonly DependencyProperty UpdateTextOnEnterKeyProperty = DependencyProperty.Register("UpdateTextOnEnterKey", typeof(bool), typeof(ValidatingTextBox));

	public bool UpdateTextOnEnterKey
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UpdateTextOnEnterKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UpdateTextOnEnterKeyProperty, (object)value);
		}
	}

	protected ValidatingTextBox(string validationPattern, string inputPattern)
	{
		UpdateValidationPattern(validationPattern, inputPattern);
	}

	public void UpdateValidationPattern(string validationPattern, string inputPattern)
	{
		_validationRegex = new Regex(validationPattern, RegexOptions.Compiled);
		base.RegexString = inputPattern;
		UpdateDisplayText();
	}

	protected abstract string GetDisplayText();

	protected abstract void HandleInput(Match inputMatch);

	protected virtual void HandleLostFocus(RoutedEventArgs e)
	{
		UpdateDisplayText();
	}

	protected void UpdateDisplayText(bool parseBeforeUpdate = false)
	{
		if (parseBeforeUpdate)
		{
			ParseInput();
		}
		if (_canUpdateDisplayText)
		{
			base.Text = GetDisplayText();
		}
	}

	private void RevertChanges()
	{
		if (UpdateTextOnEnterKey)
		{
			UpdateDisplayText();
		}
	}

	private void ParseInput()
	{
		Match match = _validationRegex?.Match(base.Text);
		if (match != null && match.Success)
		{
			_canUpdateDisplayText = false;
			HandleInput(match);
			_canUpdateDisplayText = true;
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		Key key = e.Key;
		if ((int)key != 6)
		{
			if ((int)key == 13)
			{
				RevertChanges();
				e.Handled = true;
			}
		}
		else
		{
			UpdateDisplayText(parseBeforeUpdate: true);
			e.Handled = true;
		}
		base.OnPreviewKeyDown(e);
	}

	protected sealed override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		HandleLostFocus(e);
		base.OnLostKeyboardFocus(e);
	}

	protected override void OnLostFocus(RoutedEventArgs e)
	{
		HandleLostFocus(e);
		base.OnLostFocus(e);
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		if (!UpdateTextOnEnterKey)
		{
			ParseInput();
		}
	}
}
