using Pro.Text;

namespace ProPresenter.DO.Analytics;

public static class FillTypeExtensions
{
	public static FillType ToFillType(this TextFillType textFillType)
	{
		return textFillType switch
		{
			TextFillType.SolidColor => FillType.Solid, 
			TextFillType.Gradient => FillType.Gradient, 
			_ => FillType.Solid, 
		};
	}
}
