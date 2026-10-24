using System.Collections.Generic;
using Pro.Common.Utility;

namespace Pro.DO.Analytics;

public static class EventPublisher
{
	private static readonly List<IAnalyticEventHandler> _handlers = new List<IAnalyticEventHandler>();

	public static void AddDefaultHandler()
	{
		AddHandler(new ProCoreAnalyticEventHandler());
	}

	public static void AddHandler(IAnalyticEventHandler handler)
	{
		_handlers.Add(handler);
	}

	public static void RemoveHandler(IAnalyticEventHandler handler)
	{
		_handlers.Remove(handler);
	}

	public static void Publish(IAnalyticEvent? @event)
	{
		(@event != null).Then(delegate
		{
			_handlers.ForEach(delegate(IAnalyticEventHandler h)
			{
				h.Execute(@event);
			});
		});
	}
}
