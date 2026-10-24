using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Model.Extensions;

internal static class SeatTypeExtensions
{
	public static SeatType ToProtoSeatType(this bool isActive)
	{
		if (!isActive)
		{
			return SeatType.Inactive;
		}
		return SeatType.Basic;
	}
}
