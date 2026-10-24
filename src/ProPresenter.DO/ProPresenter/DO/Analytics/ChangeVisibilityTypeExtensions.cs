using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class ChangeVisibilityTypeExtensions
{
	public static ClearGroupsChangeVisibility.Types.Visibility ToProto(this ChangeVisibilityType type)
	{
		return type switch
		{
			ChangeVisibilityType.Shown => ClearGroupsChangeVisibility.Types.Visibility.Shown, 
			ChangeVisibilityType.Hidden => ClearGroupsChangeVisibility.Types.Visibility.Hidden, 
			_ => ClearGroupsChangeVisibility.Types.Visibility.Unknown, 
		};
	}
}
