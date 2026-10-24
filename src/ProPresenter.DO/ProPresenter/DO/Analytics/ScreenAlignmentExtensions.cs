using System;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Analytics;

public static class ScreenAlignmentExtensions
{
	public static ScreenAlignment ToScreenAlignment(this SubrectTargetMode subrectTargetMode)
	{
		return subrectTargetMode switch
		{
			SubrectTargetMode.Full => ScreenAlignment.Full, 
			SubrectTargetMode.TwoByOne => ScreenAlignment.TwoByOne, 
			SubrectTargetMode.TwoByTwo => ScreenAlignment.TwoByTwo, 
			SubrectTargetMode.ThreeByOne => ScreenAlignment.ThreeByOne, 
			SubrectTargetMode.Custom => ScreenAlignment.Custom, 
			_ => throw new NotSupportedException(), 
		};
	}
}
