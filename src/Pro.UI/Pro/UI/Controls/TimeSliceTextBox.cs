using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Strings;
using Pro.Common.Time;

namespace Pro.UI.Controls;

public class TimeSliceTextBox : ValidatingTextBox
{
	private static readonly string ValidationPattern = string.Format("^{2}({0}){2}({1}){2}({1}){2}({1}){2}({1}){2}$", "[0-9]+", "[0-9]*", "[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*");

	private static readonly string ValidationPatternNeg = string.Format("^{2}({0}){2}({1}){2}({1}){2}({1}){2}({1}){2}$", "-?[0-9]+", "-?[0-9]*", "[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*");

	private static readonly string InputPattern = "^[0-9]*[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*$";

	private static readonly string InputPatternNeg = "^-?[0-9]*[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*$";

	public static readonly DependencyProperty TimeValueProperty = DependencyProperty.Register("TimeValue", typeof(TimeSlice), typeof(TimeSliceTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, new PropertyChangedCallback(UpdateText), new CoerceValueCallback(CoerceTimeValueCallback)));

	public static readonly DependencyProperty ShowMillisecondsProperty = DependencyProperty.Register("ShowMilliseconds", typeof(bool), typeof(TimeSliceTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(UpdateText)));

	public static readonly DependencyProperty ShowHoursProperty = DependencyProperty.Register("ShowHours", typeof(bool), typeof(TimeSliceTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(UpdateText)));

	public static readonly DependencyProperty AllowNegativeValuesProperty = DependencyProperty.Register("AllowNegativeValues", typeof(bool), typeof(TimeSliceTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnAllowNegativeValuesPropertyChanged)));

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

	public TimeSlice TimeValue
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(TimeValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeValueProperty, (object)value);
		}
	}

	public bool ShowHours
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowHoursProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowHoursProperty, (object)value);
		}
	}

	public bool ShowMilliseconds
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMillisecondsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMillisecondsProperty, (object)value);
		}
	}

	[GeneratedRegex("([0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]*)")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NextGroupRegex()
	{
		return _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__NextGroupRegex_1.Instance;
	}

	[GeneratedRegex("(-?[0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*(-?[0-9]*)")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NextGroupRegexNeg()
	{
		return _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__NextGroupRegexNeg_2.Instance;
	}

	private static object CoerceTimeValueCallback(DependencyObject d, object baseValue)
	{
		(d as TimeSliceTextBox)?.UpdateDisplayText();
		return baseValue;
	}

	private static void UpdateText(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as TimeSliceTextBox)?.UpdateDisplayText();
	}

	public TimeSliceTextBox()
		: base(ValidationPattern, InputPattern)
	{
	}

	protected override string GetDisplayText()
	{
		TimeComponents timeComponents = TimeComponents.All;
		if (!ShowHours)
		{
			timeComponents &= ~TimeComponents.Hours;
		}
		if (!ShowMilliseconds)
		{
			timeComponents &= ~TimeComponents.Milliseconds;
		}
		return TimeSliceHelper.TimeSliceToString(TimeValue, timeComponents);
	}

	protected override void HandleInput(Match inputMatch)
	{
		bool isNegative = !string.IsNullOrEmpty(inputMatch.Value) && inputMatch.Value[0] == '-';
		double[] numbers = (from n in inputMatch.Groups.Cast<Group>().Skip(1)
			where !string.IsNullOrWhiteSpace(n.Value)
			orderby n.Index
			select double.Parse(n.Value)).ToArray();
		((DependencyObject)this).SetCurrentValue(TimeValueProperty, (object)ParseNumbersIntoTime(numbers, isNegative));
	}

	protected override void HandleLostFocus(RoutedEventArgs e)
	{
		UpdateDisplayText(parseBeforeUpdate: true);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Key == 3)
		{
			e.Handled = SelectNextGroup(((Enum)e.KeyboardDevice.Modifiers).HasFlag((Enum)(object)(ModifierKeys)4));
		}
		base.OnPreviewKeyDown(e);
	}

	private bool SelectNextGroup(bool reverse)
	{
		if (!reverse)
		{
			base.CaretIndex += base.SelectedText?.Length ?? 0;
		}
		string text = (reverse ? base.Text.Inverse() : base.Text);
		int num = (reverse ? (text.Length - base.CaretIndex) : base.CaretIndex);
		int startat = Math.Max(num - 1, 0);
		Match match = (AllowNegativeValues ? NextGroupRegexNeg().Match(text, startat) : NextGroupRegex().Match(text, startat));
		if (match.Success)
		{
			Group group = ((num > 0 || string.IsNullOrWhiteSpace(match.Groups[1].Value)) ? match.Groups[2] : match.Groups[1]);
			if (!string.IsNullOrWhiteSpace(group.Value))
			{
				int start = (reverse ? (text.Length - group.Length - group.Index) : group.Index);
				Select(start, group.Length);
				return true;
			}
		}
		return false;
	}

	protected virtual TimeSlice ParseNumbersIntoTime(double[] numbers, bool isNegative = false)
	{
		TimeSlice timeSlice = TimeSlice.Zero;
		switch (numbers.Length)
		{
		case 1:
			timeSlice = minutes(0);
			break;
		case 2:
			timeSlice = minutes(0) + seconds(1);
			break;
		case 3:
			timeSlice = (ShowHours ? (hours(0) + minutes(1) + seconds(2)) : (minutes(0) + seconds(1) + milliseconds(2)));
			break;
		case 4:
			timeSlice = hours(0) + minutes(1) + seconds(2) + milliseconds(3);
			break;
		case 5:
			timeSlice = days(0) + hours(1) + minutes(2) + seconds(3) + milliseconds(4);
			break;
		}
		if (!(AllowNegativeValues && isNegative))
		{
			return timeSlice;
		}
		return timeSlice * -1.0;
		TimeSlice days(int index)
		{
			return TimeSlice.FromDays(numbers[index]);
		}
		TimeSlice hours(int index)
		{
			return TimeSlice.FromHours(numbers[index]);
		}
		TimeSlice milliseconds(int index)
		{
			return TimeSlice.FromMilliseconds(numbers[index] * 10.0);
		}
		TimeSlice minutes(int index)
		{
			return TimeSlice.FromMinutes(numbers[index]);
		}
		TimeSlice seconds(int index)
		{
			return TimeSlice.FromSeconds(numbers[index]);
		}
	}

	private static void OnAllowNegativeValuesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimeSliceTextBox timeSliceTextBox = (TimeSliceTextBox)(object)d;
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			timeSliceTextBox.UpdateValidationPattern(ValidationPatternNeg, InputPatternNeg);
		}
		else
		{
			timeSliceTextBox.UpdateValidationPattern(ValidationPattern, InputPattern);
		}
	}
}
