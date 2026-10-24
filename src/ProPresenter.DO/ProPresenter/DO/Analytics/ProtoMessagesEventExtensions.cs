using System;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class ProtoMessagesEventExtensions
{
	public static LowerRightMessagesState.Types.State ToProtoState(this MessageState state)
	{
		return state switch
		{
			MessageState.Show => LowerRightMessagesState.Types.State.Show, 
			MessageState.Clear => LowerRightMessagesState.Types.State.Clear, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static LowerRightMessagesEdit.Types.Action ToProtoAction(this MessageEditAction action)
	{
		return action switch
		{
			MessageEditAction.AddTextToken => LowerRightMessagesEdit.Types.Action.AddTextToken, 
			MessageEditAction.AddTimerToken => LowerRightMessagesEdit.Types.Action.AddTimerToken, 
			MessageEditAction.AddCustomToken => LowerRightMessagesEdit.Types.Action.AddCustomToken, 
			MessageEditAction.SetTheme => LowerRightMessagesEdit.Types.Action.SetTheme, 
			MessageEditAction.SetText => LowerRightMessagesEdit.Types.Action.SetText, 
			MessageEditAction.SetWebNotification => LowerRightMessagesEdit.Types.Action.SetWebNotification, 
			MessageEditAction.SetDismissBehavior => LowerRightMessagesEdit.Types.Action.SetDismissBehavior, 
			_ => throw new NotSupportedException(), 
		};
	}
}
