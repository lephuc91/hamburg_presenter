using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ProPresenter.UI.Controls;

[TemplatePart(Name = "PART_Input", Type = typeof(TextBox))]
public class SecondsInput : Control
{
	private Regex Regex;

	private TextBox? _inputBox;

	private const string MASK_VALUE = "s";

	public static readonly DependencyProperty ValueProperty;

	public static readonly DependencyProperty InputRegexProperty;

	public string InputRegex
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(InputRegexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InputRegexProperty, (object)value);
		}
	}

	public double Value
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, (object)value);
		}
	}

	static SecondsInput()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		Type? typeFromHandle = typeof(double);
		Type? typeFromHandle2 = typeof(SecondsInput);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata).DefaultValue = 0.0;
		frameworkPropertyMetadata.BindsTwoWayByDefault = true;
		frameworkPropertyMetadata.DefaultUpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
		((PropertyMetadata)frameworkPropertyMetadata).PropertyChangedCallback = new PropertyChangedCallback(OnValueChanged);
		ValueProperty = DependencyProperty.Register("Value", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		InputRegexProperty = DependencyProperty.Register("InputRegex", typeof(string), typeof(SecondsInput), new PropertyMetadata((object)".*[0-9]"));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SecondsInput), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(SecondsInput)));
	}

	public SecondsInput()
	{
		Regex = new Regex(InputRegex);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_inputBox = GetTemplateChild("PART_Input") as TextBox;
		if (_inputBox != null)
		{
			_inputBox.PreviewKeyDown += OnInputPreviewKeyDown;
			_inputBox.PreviewTextInput += OnInputPreviewTextInput;
			_inputBox.TextChanged += OnInputTextChanged;
			_inputBox.LostFocus += OnInputLostFocus;
			UpdateDisplayText();
		}
	}

	private void OnInputPreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Invalid comparison between Unknown and I4
		if ((int)e.Key == 24)
		{
			Value += 1.0;
		}
		else if ((int)e.Key == 26 && Value > 0.0)
		{
			Value -= 1.0;
		}
		else if ((int)e.Key == 6)
		{
			BindingOperations.GetBindingExpression((DependencyObject)(object)this, ValueProperty)?.UpdateSource();
		}
	}

	private void OnInputLostFocus(object? sender, RoutedEventArgs e)
	{
		if (_inputBox != null && _inputBox.Text.Length == 1 && _inputBox.Text.Contains("s"))
		{
			_inputBox.Text = "0s";
		}
		if (_inputBox != null && double.TryParse(_inputBox.Text.Replace("s", ""), out var result) && result != Value)
		{
			Value = result;
		}
		StripLeadingZeros();
		UpdateDisplayText();
	}

	private void OnInputTextChanged(object? sender, TextChangedEventArgs e)
	{
		if (_inputBox != null && !_inputBox.Text.Contains("s"))
		{
			_inputBox.Text += "s";
			_inputBox.CaretIndex = _inputBox.Text.Length - 1;
		}
		UpdateValueProperty();
	}

	private void OnInputPreviewTextInput(object? sender, TextCompositionEventArgs e)
	{
		e.Handled = !(Regex?.IsMatch(e.Text) ?? true);
	}

	private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is SecondsInput { _inputBox: not null } secondsInput)
		{
			secondsInput.UpdateDisplayText();
		}
	}

	private void UpdateValueProperty()
	{
		if (_inputBox != null && double.TryParse(_inputBox.Text.Replace("s", ""), out var result) && result > 0.0)
		{
			Value = result;
		}
	}

	private void UpdateDisplayText()
	{
		if (_inputBox != null)
		{
			_inputBox.Text = $"{Value}{"s"}";
		}
	}

	private void StripLeadingZeros()
	{
		if (_inputBox == null)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		string text = _inputBox.Text;
		foreach (char c in text)
		{
			if (c != '0' || flag)
			{
				flag = true;
				stringBuilder.Append(c);
			}
		}
		_inputBox.Text = stringBuilder.ToString();
	}
}
