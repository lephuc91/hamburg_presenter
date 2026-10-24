namespace ProPresenter.DO.Media;

public class CropInsets
{
	public double Left { get; }

	public double Top { get; }

	public double Right { get; }

	public double Bottom { get; }

	public CropInsets(double left, double top, double right, double bottom)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}

	public CropInsets()
		: this(0.0, 0.0, 0.0, 0.0)
	{
	}
}
