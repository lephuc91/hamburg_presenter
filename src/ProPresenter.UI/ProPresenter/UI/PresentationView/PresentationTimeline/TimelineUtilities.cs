namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public static class TimelineUtilities
{
	public static string SecondsToTimeString(double secondsInt, bool hideSeconds = false)
	{
		string text = "00";
		string text2 = "00";
		string text3 = "00";
		double num = secondsInt % 60.0;
		text3 = ((num < 10.0) ? $"0{(int)num}" : ((int)num).ToString());
		if (secondsInt >= 60.0)
		{
			int num2 = (int)(secondsInt / 60.0) % 60;
			text2 = ((num2 < 10) ? $"0{num2}" : num2.ToString()).ToString();
		}
		if (secondsInt >= 3600.0)
		{
			int num3 = (int)(secondsInt / 3600.0) % 60;
			text = ((num3 < 10) ? $"0{num3}" : num3.ToString()).ToString();
		}
		if (!hideSeconds)
		{
			return $"{text}:{text2}:{text3}";
		}
		return text + ":" + text2;
	}
}
