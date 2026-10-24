using ProPresenter.DO.Analytics.Events.Startup;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public static class CopyrightDisplayTypeExtensions
{
	public static CopyrightDisplayType ToUICopyrightDisplayType(this CCLIDisplayType displayType)
	{
		return displayType switch
		{
			CCLIDisplayType.First => CopyrightDisplayType.First, 
			CCLIDisplayType.Last => CopyrightDisplayType.Last, 
			CCLIDisplayType.FirstAndLast => CopyrightDisplayType.FirstAndLast, 
			CCLIDisplayType.AllSlides => CopyrightDisplayType.AllSlides, 
			_ => CopyrightDisplayType.First, 
		};
	}

	public static CopyRightStyleValue ToUICopyrightStyleValue(this CCLIDisplayType displayType)
	{
		return displayType switch
		{
			CCLIDisplayType.First => CopyRightStyleValue.CopyrightStyleFirst, 
			CCLIDisplayType.Last => CopyRightStyleValue.CopyrightStyleLast, 
			CCLIDisplayType.FirstAndLast => CopyRightStyleValue.CopyrightStyleFirstAndLast, 
			CCLIDisplayType.AllSlides => CopyRightStyleValue.CopyrightStyleAllSlides, 
			_ => CopyRightStyleValue.CopyrightStyleFirst, 
		};
	}

	public static CCLIDisplayType ToCopyrightDisplayType(this CopyrightDisplayType displayType)
	{
		return displayType switch
		{
			CopyrightDisplayType.First => CCLIDisplayType.First, 
			CopyrightDisplayType.Last => CCLIDisplayType.Last, 
			CopyrightDisplayType.FirstAndLast => CCLIDisplayType.FirstAndLast, 
			CopyrightDisplayType.AllSlides => CCLIDisplayType.AllSlides, 
			_ => CCLIDisplayType.First, 
		};
	}
}
