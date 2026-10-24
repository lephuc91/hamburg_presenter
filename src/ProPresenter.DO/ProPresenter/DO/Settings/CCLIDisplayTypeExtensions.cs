using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Settings;

public static class CCLIDisplayTypeExtensions
{
	public static CCLIDocument.Types.DisplayType ToProtoDisplayType(this CCLIDisplayType displayType)
	{
		return displayType switch
		{
			CCLIDisplayType.First => CCLIDocument.Types.DisplayType.FirstSlide, 
			CCLIDisplayType.Last => CCLIDocument.Types.DisplayType.LastSlide, 
			CCLIDisplayType.FirstAndLast => CCLIDocument.Types.DisplayType.FirstAndLastSlide, 
			CCLIDisplayType.AllSlides => CCLIDocument.Types.DisplayType.AllSlides, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static CCLIDisplayType ToDisplayType(this CCLIDocument.Types.DisplayType displayType)
	{
		return displayType switch
		{
			CCLIDocument.Types.DisplayType.FirstSlide => CCLIDisplayType.First, 
			CCLIDocument.Types.DisplayType.LastSlide => CCLIDisplayType.Last, 
			CCLIDocument.Types.DisplayType.FirstAndLastSlide => CCLIDisplayType.FirstAndLast, 
			CCLIDocument.Types.DisplayType.AllSlides => CCLIDisplayType.AllSlides, 
			_ => throw new NotSupportedException(), 
		};
	}
}
