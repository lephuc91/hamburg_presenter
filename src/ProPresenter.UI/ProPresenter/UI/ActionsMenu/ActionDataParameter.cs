using Pro.DO.Triggering;

namespace ProPresenter.UI.ActionsMenu;

public class ActionDataParameter
{
	public ActionBase Action { get; }

	public object Data { get; }

	public ActionDataParameter(ActionBase action, object data)
	{
		Action = action;
		Data = data;
	}
}
