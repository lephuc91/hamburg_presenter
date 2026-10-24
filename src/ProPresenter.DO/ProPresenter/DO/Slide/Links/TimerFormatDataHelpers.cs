using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

internal static class TimerFormatDataHelpers
{
	public static TimerFormatData Deserialize(this Pro.SerializationInterop.RVProtoData.Timer.Types.Format proto)
	{
		TimerFormatData timerFormatData = new TimerFormatData();
		timerFormatData.Deserialize(proto);
		return timerFormatData;
	}
}
