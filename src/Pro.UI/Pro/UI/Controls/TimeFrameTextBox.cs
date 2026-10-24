using System.Linq;
using System.Windows;
using Pro.Common.Time;

namespace Pro.UI.Controls;

public class TimeFrameTextBox : TimeSliceTextBox
{
	public static readonly DependencyProperty FramesPerSecondProperty;

	public double FramesPerSecond
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(FramesPerSecondProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FramesPerSecondProperty, (object)value);
		}
	}

	static TimeFrameTextBox()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		FramesPerSecondProperty = DependencyProperty.Register("FramesPerSecond", typeof(double), typeof(TimeFrameTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TimeFrameTextBox)(object)d).UpdateDisplayText();
		}));
		ValidatingTextBox.UpdateTextOnEnterKeyProperty.OverrideMetadata(typeof(TimeFrameTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	protected override string GetDisplayText()
	{
		TimeSlice timeValue = base.TimeValue;
		double value = ((FramesPerSecond > 0.0) ? ((double)timeValue.Milliseconds / 1000.0 * FramesPerSecond) : 0.0);
		return $"{timeValue.Hours:00}:{timeValue.Minutes:00}:{timeValue.Seconds:00};{value:00}";
	}

	protected override TimeSlice ParseNumbersIntoTime(double[] numbers, bool isNegative = false)
	{
		TimeSlice timeSlice2;
		if (numbers.Length >= 4)
		{
			TimeSlice timeSlice = base.ParseNumbersIntoTime(numbers.Take(numbers.Length - 1).ToArray(), isNegative);
			double num = numbers[^1];
			double milliseconds = ((FramesPerSecond == 0.0) ? 0.0 : (num * 1000.0 / FramesPerSecond));
			timeSlice2 = timeSlice + TimeSlice.FromMilliseconds(milliseconds);
		}
		else
		{
			timeSlice2 = base.ParseNumbersIntoTime(numbers, isNegative);
		}
		if (!isNegative)
		{
			return timeSlice2;
		}
		return timeSlice2 * -1.0;
	}
}
