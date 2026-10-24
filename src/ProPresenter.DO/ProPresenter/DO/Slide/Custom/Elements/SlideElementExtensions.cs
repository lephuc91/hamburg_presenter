namespace ProPresenter.DO.Slide.Custom.Elements;

public static class SlideElementExtensions
{
	public static bool IsTextElement(this SlideElementBase element)
	{
		if (!element.AdditionalInfo.HasFlag(AdditionalInfo.Text))
		{
			if (element is ClosedBezierPath closedBezierPath)
			{
				return closedBezierPath.Text?.HasText ?? false;
			}
			return false;
		}
		return true;
	}
}
