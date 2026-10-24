namespace ProPresenter.DO.Slide.Custom.Elements.Strokes;

public enum StrokeStyle
{
	[StrokePattern(new double[] { })]
	SolidLine,
	[StrokePattern(new double[] { 1.0, 1.0 })]
	SquareDash,
	[StrokePattern(new double[] { 2.0, 2.0 })]
	ShortDash,
	[StrokePattern(new double[] { 4.0, 2.0 })]
	LongDash
}
