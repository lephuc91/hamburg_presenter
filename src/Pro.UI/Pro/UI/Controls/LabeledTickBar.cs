using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class LabeledTickBar : TickBar
{
	public static readonly DependencyProperty LabelsProperty = DependencyProperty.Register("Labels", typeof(ObservableCollection<string>), typeof(LabeledTickBar));

	public ObservableCollection<string>? Labels
	{
		get
		{
			return (ObservableCollection<string>)((DependencyObject)this).GetValue(LabelsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelsProperty, (object)value);
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		double num = base.Maximum - base.Minimum;
		double num2 = 1.0;
		Point val = default(Point);
		((Point)(ref val))._002Ector(0.0, 0.0);
		double num3 = base.ReservedSpace * 0.5;
		Size val2 = default(Size);
		((Size)(ref val2))._002Ector(base.ActualWidth, base.ActualHeight);
		double tickFrequency = base.TickFrequency;
		switch (base.Placement)
		{
		case TickBarPlacement.Top:
		case TickBarPlacement.Bottom:
			((Size)(ref val2)).Width = ((Size)(ref val2)).Width - base.ReservedSpace;
			((Point)(ref val))._002Ector(num3, 0.0);
			num2 = ((Size)(ref val2)).Width / num;
			break;
		}
		if (base.Placement != TickBarPlacement.Bottom && base.Placement != TickBarPlacement.Top)
		{
			return;
		}
		if (tickFrequency > 0.0)
		{
			double num4 = (base.Maximum - base.Minimum) / ((Size)(ref val2)).Width;
			if (tickFrequency < num4)
			{
				tickFrequency = num4;
			}
		}
		DoubleCollection ticks = base.Ticks;
		if (ticks == null || ticks.Count < 0)
		{
			return;
		}
		for (int i = 0; i < ticks.Count; i++)
		{
			if (!(ticks[i] < base.Minimum) || !(ticks[i] > base.Maximum))
			{
				double num5 = (ticks[i] - base.Minimum) * num2 + ((Point)(ref val)).X;
				string textToFormat = ((Labels == null || Labels.Count == 0) ? ((int)ticks[i]).ToString() : Labels[i]);
				DpiScale dpi = VisualTreeHelper.GetDpi(this);
				FormattedText formattedText = new FormattedText(textToFormat, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(TextElement.GetFontFamily((DependencyObject)(object)this), TextElement.GetFontStyle((DependencyObject)(object)this), TextElement.GetFontWeight((DependencyObject)(object)this), TextElement.GetFontStretch((DependencyObject)(object)this)), TextElement.GetFontSize((DependencyObject)(object)this), TextElement.GetForeground((DependencyObject)(object)this), dpi.PixelsPerDip);
				double num6 = formattedText.Width / 2.0;
				dc.DrawText(formattedText, new Point(num5 - num6, ((Point)(ref val)).Y));
			}
		}
	}
}
