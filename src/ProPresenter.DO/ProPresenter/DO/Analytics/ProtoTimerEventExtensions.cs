using System;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

public static class ProtoTimerEventExtensions
{
	public static LowerRightTimersCollapse.Types.State ToProtoCollapseState(this CollapseState state)
	{
		return state switch
		{
			CollapseState.Collapsed => LowerRightTimersCollapse.Types.State.Collapsed, 
			CollapseState.Expanded => LowerRightTimersCollapse.Types.State.Expanded, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static LowerRightTimersEdit.Types.Field ToProtoField(this EditField field)
	{
		return field switch
		{
			EditField.Name => LowerRightTimersEdit.Types.Field.Name, 
			EditField.Overrun => LowerRightTimersEdit.Types.Field.Overrun, 
			EditField.Type => LowerRightTimersEdit.Types.Field.Type, 
			EditField.Value => LowerRightTimersEdit.Types.Field.Value, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static LowerRightTimersState.Types.State ToProtoState(this TimerEventState state)
	{
		return state switch
		{
			TimerEventState.Reset => LowerRightTimersState.Types.State.Reset, 
			TimerEventState.Start => LowerRightTimersState.Types.State.Start, 
			TimerEventState.Stop => LowerRightTimersState.Types.State.Stop, 
			_ => throw new NotSupportedException(), 
		};
	}
}
