using Pro.Common.Dispatcher;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

internal static class MiscHandler
{
	public static NetworkAPI_v1? Handle(IUiDispatcher dispatcher, API_v1_Miscellaneous_Request r)
	{
		if (r != null && r.FindMyMouse != null)
		{
			return FindMouse(dispatcher);
		}
		return null;
	}

	private static NetworkAPI_v1 FindMouse(IUiDispatcher dispatcher)
	{
		dispatcher.Invoke(Utility.FindMyMouse);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().MiscResponse().FindMyMouse = new API_v1_Miscellaneous_Response.Types.FindMyMouse();
		});
	}

	private static API_v1_Miscellaneous_Response MiscResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.MiscellaneousResponse ?? (action.MiscellaneousResponse = new API_v1_Miscellaneous_Response());
	}
}
