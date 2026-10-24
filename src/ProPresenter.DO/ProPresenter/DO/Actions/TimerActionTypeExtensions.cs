using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimerActionType), typeof(Action.Types.TimerType.Types.TimerAction), SourceToDestinationMethodName = "ToProtoTimerActionType", DestinationDefaultValue = "ActionStart", DestinationToSourceMethodName = "ToTimerActionType", SourceDefaultValue = "Start", UnmatchedSourceNames = new string[] { "Start", "Stop", "Reset", "ResetAndStart", "ResetAndStop", "Increment" }, UnmatchedDestinationNames = new string[] { "ActionStart", "ActionStop", "ActionReset", "ActionResetAndStart", "ActionStopAndReset", "ActionIncrement" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TimerActionType), typeof(IAction.Types.ITimerType.Types.TimerAction), SourceToDestinationMethodName = "ToEntityTimerActionType", DestinationDefaultValue = "ActionStart", DestinationToSourceMethodName = "ToTimerActionType", SourceDefaultValue = "Start", UnmatchedSourceNames = new string[] { "Start", "Stop", "Reset", "ResetAndStart", "ResetAndStop", "Increment" }, UnmatchedDestinationNames = new string[] { "ActionStart", "ActionStop", "ActionReset", "ActionResetAndStart", "ActionStopAndReset", "ActionIncrement" })]
public static class TimerActionTypeExtensions
{
	public static Action.Types.TimerType.Types.TimerAction ToProtoTimerActionType(this TimerActionType source)
	{
		return source switch
		{
			TimerActionType.Start => Action.Types.TimerType.Types.TimerAction.ActionStart, 
			TimerActionType.Stop => Action.Types.TimerType.Types.TimerAction.ActionStop, 
			TimerActionType.Reset => Action.Types.TimerType.Types.TimerAction.ActionReset, 
			TimerActionType.ResetAndStart => Action.Types.TimerType.Types.TimerAction.ActionResetAndStart, 
			TimerActionType.ResetAndStop => Action.Types.TimerType.Types.TimerAction.ActionStopAndReset, 
			TimerActionType.Increment => Action.Types.TimerType.Types.TimerAction.ActionIncrement, 
			_ => Action.Types.TimerType.Types.TimerAction.ActionStart, 
		};
	}

	public static TimerActionType ToTimerActionType(this Action.Types.TimerType.Types.TimerAction source)
	{
		return source switch
		{
			Action.Types.TimerType.Types.TimerAction.ActionStart => TimerActionType.Start, 
			Action.Types.TimerType.Types.TimerAction.ActionStop => TimerActionType.Stop, 
			Action.Types.TimerType.Types.TimerAction.ActionReset => TimerActionType.Reset, 
			Action.Types.TimerType.Types.TimerAction.ActionResetAndStart => TimerActionType.ResetAndStart, 
			Action.Types.TimerType.Types.TimerAction.ActionStopAndReset => TimerActionType.ResetAndStop, 
			Action.Types.TimerType.Types.TimerAction.ActionIncrement => TimerActionType.Increment, 
			_ => TimerActionType.Start, 
		};
	}

	public static IAction.Types.ITimerType.Types.TimerAction ToEntityTimerActionType(this TimerActionType source)
	{
		return source switch
		{
			TimerActionType.Start => IAction.Types.ITimerType.Types.TimerAction.ActionStart, 
			TimerActionType.Stop => IAction.Types.ITimerType.Types.TimerAction.ActionStop, 
			TimerActionType.Reset => IAction.Types.ITimerType.Types.TimerAction.ActionReset, 
			TimerActionType.ResetAndStart => IAction.Types.ITimerType.Types.TimerAction.ActionResetAndStart, 
			TimerActionType.ResetAndStop => IAction.Types.ITimerType.Types.TimerAction.ActionStopAndReset, 
			TimerActionType.Increment => IAction.Types.ITimerType.Types.TimerAction.ActionIncrement, 
			_ => IAction.Types.ITimerType.Types.TimerAction.ActionStart, 
		};
	}

	public static TimerActionType ToTimerActionType(this IAction.Types.ITimerType.Types.TimerAction source)
	{
		return source switch
		{
			IAction.Types.ITimerType.Types.TimerAction.ActionStart => TimerActionType.Start, 
			IAction.Types.ITimerType.Types.TimerAction.ActionStop => TimerActionType.Stop, 
			IAction.Types.ITimerType.Types.TimerAction.ActionReset => TimerActionType.Reset, 
			IAction.Types.ITimerType.Types.TimerAction.ActionResetAndStart => TimerActionType.ResetAndStart, 
			IAction.Types.ITimerType.Types.TimerAction.ActionStopAndReset => TimerActionType.ResetAndStop, 
			IAction.Types.ITimerType.Types.TimerAction.ActionIncrement => TimerActionType.Increment, 
			_ => TimerActionType.Start, 
		};
	}
}
