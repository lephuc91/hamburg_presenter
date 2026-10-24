using System;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Time;

namespace ProPresenter.UI.Timer;

public partial class ElapseTimeEndTextBox : UserControl, IComponentConnector
{
	private bool _ignoreChange;

	public static readonly DependencyProperty AllowNegativeValuesProperty = DependencyProperty.Register("AllowNegativeValues", typeof(bool), typeof(ElapseTimeEndTextBox));

	public static readonly DependencyProperty EndTimeProperty = DependencyProperty.Register("EndTime", typeof(TimeSlice), typeof(ElapseTimeEndTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnEndTimePropertyChanged)));

	public static readonly DependencyProperty HasEndTimeProperty = DependencyProperty.Register("HasEndTime", typeof(bool), typeof(ElapseTimeEndTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnHasEndTimePropertyChanged)));

	private static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ElapseTimeEndTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, new PropertyChangedCallback(OnTextPropertyChanged)));

	public bool AllowNegativeValues
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowNegativeValuesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowNegativeValuesProperty, (object)value);
		}
	}

	public TimeSlice EndTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(EndTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndTimeProperty, (object)value);
		}
	}

	public bool HasEndTime
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HasEndTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HasEndTimeProperty, (object)value);
		}
	}

	private string Text
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

	[GeneratedRegex("^[0-9]|:$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex ValidInputRegex()
	{
		return _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__ValidInputRegex_2.Instance;
	}

	[GeneratedRegex("^-?|:[0-9]|:$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex ValidInputAllowNegRegex()
	{
		return _003CRegexGenerator_g_003EF8ACA57CDC3152D75084771C473CAD159A7649D6F35BCED21482230A547BF386A__ValidInputAllowNegRegex_3.Instance;
	}

	private static void OnEndTimePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ElapseTimeEndTextBox)(object)d).EndTimeChanged((TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnHasEndTimePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ElapseTimeEndTextBox)(object)d).HasEndTimeChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ElapseTimeEndTextBox)(object)d).TextChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public ElapseTimeEndTextBox()
	{
		InitializeComponent();
	}

	private void EndTimeInput_PreviewTextInput(object? sender, TextCompositionEventArgs e)
	{
		e.Handled = ((e.Text != Environment.NewLine && AllowNegativeValues) ? (!ValidInputAllowNegRegex().IsMatch(e.Text)) : (!ValidInputRegex().IsMatch(e.Text)));
	}

	private void EndTimeChanged(TimeSlice endTime)
	{
		UpdateText(endTime, HasEndTime);
	}

	private void HasEndTimeChanged(bool hasEndTime)
	{
		UpdateText(EndTime, hasEndTime);
	}

	private void UpdateText(TimeSlice endTime, bool hasEndTime)
	{
		if (!_ignoreChange)
		{
			_ignoreChange = true;
			string text = string.Empty;
			if (hasEndTime)
			{
				text = TimeSliceHelper.TimeSliceToString(endTime);
			}
			((DependencyObject)this).SetCurrentValue(TextProperty, (object)text);
			_ignoreChange = false;
		}
	}

	private void TextChanged(string timeString)
	{
		if (!_ignoreChange)
		{
			_ignoreChange = true;
			TimeSlice timeSlice = TimeSlice.Zero;
			bool num = !string.IsNullOrEmpty(timeString);
			((DependencyObject)this).SetCurrentValue(HasEndTimeProperty, (object)(!string.IsNullOrEmpty(timeString)));
			if (num)
			{
				timeSlice = TimeSliceHelper.StringToTimeSlice(timeString);
				timeString = TimeSliceHelper.TimeSliceToString(timeSlice);
			}
			((DependencyObject)this).SetCurrentValue(EndTimeProperty, (object)timeSlice);
			((DependencyObject)this).SetCurrentValue(TextProperty, (object)timeString);
			_ignoreChange = false;
		}
	}
}
