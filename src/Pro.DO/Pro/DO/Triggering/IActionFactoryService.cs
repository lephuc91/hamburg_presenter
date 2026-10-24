using System;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

public interface IActionFactoryService
{
	void RegisterActionType(ActionType type, Func<Pro.SerializationInterop.RVProtoData.Action?, string, ActionBase> factory);

	void RegisterActionType<T>(ActionType type) where T : ActionBase, new();

	void RegisterActionType<T>(ActionType type, Action<T> callback) where T : ActionBase, new();

	IAction ConstructAction(ActionType type, Pro.SerializationInterop.RVProtoData.Action? data, string containerId);

	void UnRegisterActionType(ActionType type);
}
