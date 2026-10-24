using System;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Analytics;

public static class ScreenTypeExtensions
{
	public static ScreenType ToScreenType(this ScreenArrangementType arrangementType)
	{
		return arrangementType switch
		{
			ScreenArrangementType.Single => ScreenType.Single, 
			ScreenArrangementType.Mirror => ScreenType.Mirrored, 
			ScreenArrangementType.Group => ScreenType.Grouped, 
			ScreenArrangementType.EdgeBlend => ScreenType.EdgeBlend, 
			_ => throw new NotSupportedException(), 
		};
	}
}
