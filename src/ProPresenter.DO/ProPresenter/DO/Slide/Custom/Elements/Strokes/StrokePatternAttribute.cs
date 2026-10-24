using System;

namespace ProPresenter.DO.Slide.Custom.Elements.Strokes;

[AttributeUsage(AttributeTargets.Field)]
public class StrokePatternAttribute : Attribute
{
	public double[] Pattern { get; }

	public StrokePatternAttribute(double[] pattern)
	{
		Pattern = pattern;
	}
}
