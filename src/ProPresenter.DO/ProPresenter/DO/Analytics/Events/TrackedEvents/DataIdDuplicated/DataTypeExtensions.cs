using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.DataIdDuplicated;

public static class DataTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.DataIdDuplicated.Types.DataType ToProtoDataType(this DataType type)
	{
		return type switch
		{
			DataType.Presentation => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.DataIdDuplicated.Types.DataType.Presentation, 
			DataType.Media => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.DataIdDuplicated.Types.DataType.Media, 
			_ => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.DataIdDuplicated.Types.DataType.Presentation, 
		};
	}
}
