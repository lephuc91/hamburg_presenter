using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Storage;
using ProPresenter.Controller.Monitors;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public class MonitorController
{
	private sealed class ElementIdentifier : IEquatable<ElementIdentifier?>
	{
		public TriggerHandle Handle { get; }

		public Guid SlideID { get; }

		public Guid ElementID { get; }

		public ElementIdentifier(TriggerHandle handle, Guid slideID, Guid elementID)
		{
			Handle = handle;
			SlideID = slideID;
			ElementID = elementID;
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.GenerateHashCode(SlideID, ElementID);
		}

		public override bool Equals(object? obj)
		{
			if (obj is ElementIdentifier other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ElementIdentifier? other)
		{
			if (other == null)
			{
				return false;
			}
			if (Handle == other.Handle && SlideID == other.SlideID)
			{
				return ElementID == other.ElementID;
			}
			return false;
		}

		public static bool operator ==(ElementIdentifier? lhs, ElementIdentifier? rhs)
		{
			return lhs.NullableEquals(rhs);
		}

		public static bool operator !=(ElementIdentifier? lhs, ElementIdentifier? rhs)
		{
			return !lhs.NullableEquals(rhs);
		}
	}

	private readonly ssAPIOutput _ssAPIOutput;

	private readonly IUiDispatcher _dispatcher;

	private readonly ITimerFactory _timerFactory;

	private readonly IRestClientFactory _restClientFactory;

	private readonly Dictionary<MonitorBase, List<ElementIdentifier>> _monitors = new Dictionary<MonitorBase, List<ElementIdentifier>>();

	private readonly Lock _monitorLock = new Lock();

	public MonitorController(ssAPIOutput ssAPIOutput, IUiDispatcher dispatcher, ITimerFactory timerFactory, IRestClientFactory restClientFactory)
	{
		_ssAPIOutput = ssAPIOutput;
		_dispatcher = dispatcher;
		_timerFactory = timerFactory;
		_restClientFactory = restClientFactory;
	}

	public void StartMonitoring(TriggerHandle handle, Guid slideID, Guid elementID, BezierPath element)
	{
		ElementIdentifier identifier = new ElementIdentifier(handle, slideID, elementID);
		if (!(element is ClosedBezierPath closedBezierPath) || closedBezierPath.TextLink?.LinkedObject == null)
		{
			return;
		}
		switch (closedBezierPath.TextLink.LinkedObject.LinkedTextType)
		{
		case LinkedTextType.FileFeed:
		{
			RelativePath relativePath = (closedBezierPath.TextLink.LinkedObject as FileFeedLinkedObject)?.SourceFile;
			if ((object)relativePath != null && !relativePath.IsEmpty && File.Exists(relativePath))
			{
				AddFileMonitor(identifier, relativePath);
			}
			break;
		}
		case LinkedTextType.RssFeed:
		{
			RssFeedLinkedObject rssFeedLinkedObject = (RssFeedLinkedObject)closedBezierPath.TextLink.LinkedObject;
			AddRSSMonitor(identifier, rssFeedLinkedObject.Url, rssFeedLinkedObject.ContentMode);
			break;
		}
		}
	}

	public void StopMonitoring(TriggerHandle handle, Guid slideID, Guid elementID)
	{
		ElementIdentifier identifier = new ElementIdentifier(handle, slideID, elementID);
		using (_monitorLock.EnterScope())
		{
			foreach (KeyValuePair<MonitorBase, List<ElementIdentifier>> monitor in _monitors)
			{
				monitor.Value.RemoveIf((ElementIdentifier i) => i == identifier);
			}
			foreach (MonitorBase item in from m in _monitors
				where m.Value.Empty()
				select m.Key)
			{
				item.ResourceChanged -= OnResourceChanged;
				item.StopMonitoring();
				_monitors.Remove(item);
			}
		}
	}

	private void AddFileMonitor(ElementIdentifier identifier, RelativePath path)
	{
		AddMonitor(identifier, (FileMonitor m) => m.Filepath == path, () => new FileMonitor(_dispatcher, path));
	}

	private void AddRSSMonitor(ElementIdentifier identifier, string url, RssFeedContentMode contentMode)
	{
		AddMonitor(identifier, (RSSMonitor m) => m.Url == url, () => new RSSMonitor(_timerFactory, _restClientFactory, url, contentMode));
	}

	private void AddMonitor<T>(ElementIdentifier identifier, Predicate<T> equalPredicate, Func<T> ctor) where T : MonitorBase
	{
		using (_monitorLock.EnterScope())
		{
			foreach (KeyValuePair<MonitorBase, List<ElementIdentifier>> item in _monitors.Where<KeyValuePair<MonitorBase, List<ElementIdentifier>>>((KeyValuePair<MonitorBase, List<ElementIdentifier>> m) => m.Key is T))
			{
				T obj = (T)item.Key;
				if (equalPredicate(obj))
				{
					item.Value.Add(identifier);
					return;
				}
			}
			T val = ctor();
			val.ResourceChanged += OnResourceChanged;
			_monitors.Add(val, new List<ElementIdentifier> { identifier });
		}
	}

	private void OnResourceChanged(MonitorBase monitor)
	{
		using (_monitorLock.EnterScope())
		{
			if (_monitors.TryGetValue(monitor, out List<ElementIdentifier> value))
			{
				value.ForEach(delegate(ElementIdentifier i)
				{
					_ssAPIOutput.UpdateElement(i.Handle, i.SlideID, i.ElementID);
				});
			}
		}
	}
}
