using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

public class ActionFactoryService : IActionFactoryService
{
	private readonly ConcurrentDictionary<ActionType, Func<Pro.SerializationInterop.RVProtoData.Action?, string, ActionBase>> _factoryMap = new ConcurrentDictionary<ActionType, Func<Pro.SerializationInterop.RVProtoData.Action, string, ActionBase>>();

	public void RegisterActionType(ActionType type, Func<Pro.SerializationInterop.RVProtoData.Action?, string, ActionBase> factory)
	{
		_factoryMap.AddOrUpdate(type, factory, delegate(ActionType key, Func<Pro.SerializationInterop.RVProtoData.Action?, string, ActionBase> oldValue)
		{
			throw new InvalidOperationException($"Factory already registered for action type: {key}.");
		});
	}

	public void RegisterActionType<T>(ActionType type) where T : ActionBase, new()
	{
		RegisterActionType(type, (Pro.SerializationInterop.RVProtoData.Action? p, string _) => new T());
	}

	public void RegisterActionType<T>(ActionType type, Action<T> callback) where T : ActionBase, new()
	{
		RegisterActionType(type, delegate
		{
			T val = new T();
			callback(val);
			return val;
		});
	}

	public IAction ConstructAction(ActionType type, Pro.SerializationInterop.RVProtoData.Action? data, string containerId)
	{
		if (!_factoryMap.TryGetValue(type, out Func<Pro.SerializationInterop.RVProtoData.Action, string, ActionBase> value))
		{
			throw new NotSupportedException();
		}
		return value(data, containerId);
	}

	public void UnRegisterActionType(ActionType type)
	{
		_factoryMap.Remove<ActionType, Func<Pro.SerializationInterop.RVProtoData.Action, string, ActionBase>>(type, out var _);
	}
}
