using System;
using System.Threading;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

public static class ActionFactory
{
	private sealed class ActionFactoryResetter : IDisposable
	{
		public void Dispose()
		{
			Interlocked.Exchange(ref _actionFactoryImplementation, null);
		}
	}

	private static IActionFactoryService? _actionFactoryImplementation;

	public static IDisposable SetFactory(IActionFactoryService actionFactoryImplementation)
	{
		if (Interlocked.CompareExchange(ref _actionFactoryImplementation, actionFactoryImplementation, null) != null)
		{
			throw new InvalidOperationException("ActionFactory is already initialized.");
		}
		return new ActionFactoryResetter();
	}

	public static void RegisterActionType(this ActionType type, Func<Pro.SerializationInterop.RVProtoData.Action?, string, ActionBase> factory)
	{
		ExecuteActionWithFactory(delegate(IActionFactoryService x)
		{
			x.RegisterActionType(type, factory);
		});
	}

	public static void RegisterActionType<T>(this ActionType type) where T : ActionBase, new()
	{
		ExecuteActionWithFactory(delegate(IActionFactoryService x)
		{
			x.RegisterActionType<T>(type);
		});
	}

	public static void RegisterActionType<T>(this ActionType type, Action<T> callback) where T : ActionBase, new()
	{
		ExecuteActionWithFactory(delegate(IActionFactoryService x)
		{
			x.RegisterActionType(type, callback);
		});
	}

	public static IAction ConstructAction(this ActionType type, Pro.SerializationInterop.RVProtoData.Action? data, string containerId)
	{
		return ExecuteFuncWithFactory((IActionFactoryService x) => x.ConstructAction(type, data, containerId));
	}

	public static void UnRegisterActionType(this ActionType type)
	{
		ExecuteActionWithFactory(delegate(IActionFactoryService x)
		{
			x.UnRegisterActionType(type);
		});
	}

	private static void ExecuteActionWithFactory(Action<IActionFactoryService> action)
	{
		if (_actionFactoryImplementation == null)
		{
			throw new NotSupportedException("ActionFactory not initialized.");
		}
		action(_actionFactoryImplementation);
	}

	private static U ExecuteFuncWithFactory<U>(Func<IActionFactoryService, U> func)
	{
		if (_actionFactoryImplementation == null)
		{
			throw new NotSupportedException("ActionFactory not initialized.");
		}
		return func(_actionFactoryImplementation);
	}
}
