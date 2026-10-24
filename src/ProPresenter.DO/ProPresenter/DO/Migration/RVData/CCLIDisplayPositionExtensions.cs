using System;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Migration.RVData;

public static class CCLIDisplayPositionExtensions
{
	public static CCLIDisplayType ToCCLIDisplayType(this CCLIDisplayPosition position)
	{
		return position switch
		{
			CCLIDisplayPosition.FirstSlide => CCLIDisplayType.First, 
			CCLIDisplayPosition.LastSlide => CCLIDisplayType.Last, 
			CCLIDisplayPosition.FirstAndLastSlide => CCLIDisplayType.FirstAndLast, 
			CCLIDisplayPosition.AllSlide => CCLIDisplayType.AllSlides, 
			_ => throw new NotSupportedException(), 
		};
	}
}
