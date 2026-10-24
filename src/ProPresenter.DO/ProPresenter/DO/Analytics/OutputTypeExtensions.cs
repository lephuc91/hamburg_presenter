using System;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Analytics;

public static class OutputTypeExtensions
{
	public static OutputType ToOutputType(this DeviceType deviceType)
	{
		switch (deviceType)
		{
		case DeviceType.Unknown:
		case DeviceType.Screen:
			return OutputType.System;
		case DeviceType.BlackmagicCard:
			return OutputType.SDI;
		case DeviceType.NDI:
			return OutputType.NDI;
		case DeviceType.Placeholder:
			return OutputType.Placeholder;
		default:
			throw new NotSupportedException();
		}
	}
}
