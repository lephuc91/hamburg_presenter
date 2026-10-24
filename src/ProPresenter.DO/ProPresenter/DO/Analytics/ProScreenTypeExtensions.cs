using System;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Analytics;

public static class ProScreenTypeExtensions
{
	public static ProScreenType ToScreenType(this ScreenTargetType screenType)
	{
		return screenType switch
		{
			ScreenTargetType.Audience => ProScreenType.Audience, 
			ScreenTargetType.Stage => ProScreenType.Stage, 
			_ => throw new NotSupportedException(), 
		};
	}
}
