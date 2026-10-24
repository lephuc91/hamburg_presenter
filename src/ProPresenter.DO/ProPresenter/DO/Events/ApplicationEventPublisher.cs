using System;
using System.Collections.Generic;
using Pro.Common.Logging;
using Pro.Reporting;

namespace ProPresenter.DO.Events;

public static class ApplicationEventPublisher
{
	private static readonly List<IApplicationEventHandler> _handlers = new List<IApplicationEventHandler>();

	public static void AddHandler(IApplicationEventHandler handler)
	{
		_handlers.Add(handler);
	}

	public static void Publish(IApplicationEvent @event)
	{
		if (@event == null)
		{
			return;
		}
		_handlers.ForEach(delegate(IApplicationEventHandler h)
		{
			try
			{
				h.Handle(@event);
			}
			catch (Exception ex)
			{
				Log.Error("{0} failed handling {1} - {2}", h.GetType().Name, @event.GetType().Name, ex);
				Stargazer.ReportError(ex, ("Handler", h.GetType().Name), ("Event", @event.GetType().Name));
			}
		});
	}
}
