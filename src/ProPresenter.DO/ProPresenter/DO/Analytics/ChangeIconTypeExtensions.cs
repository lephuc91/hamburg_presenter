using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class ChangeIconTypeExtensions
{
	public static ClearGroupsChangeIcon.Types.IconType ToProto(this ChangeIconType type)
	{
		return type switch
		{
			ChangeIconType.Default => ClearGroupsChangeIcon.Types.IconType.Default, 
			ChangeIconType.Custom => ClearGroupsChangeIcon.Types.IconType.Custom, 
			_ => ClearGroupsChangeIcon.Types.IconType.Unknown, 
		};
	}
}
