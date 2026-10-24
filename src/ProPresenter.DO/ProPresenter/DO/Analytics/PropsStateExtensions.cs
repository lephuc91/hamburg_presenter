using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class PropsStateExtensions
{
	public static LowerRightPropsState.Types.State ToProtoPropsState(this PropsState state)
	{
		return state switch
		{
			PropsState.Show => LowerRightPropsState.Types.State.Show, 
			PropsState.Clear => LowerRightPropsState.Types.State.Clear, 
			_ => LowerRightPropsState.Types.State.Unknown, 
		};
	}
}
