using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

public class ActiveTimeline : DisposableBase
{
	private readonly IDebouncer<IDocumentCue?> _timelineUpdateDebouncer;

	public TriggerHandle Handle { get; }

	public Timeline? Timeline { get; }

	public IDocumentCue? DocumentCue { get; }

	public bool IsRecording { get; internal set; }

	public event Action<IDocumentCue?>? TimelineItemsUpdated;

	public event Action<IDocumentCue?>? TimelineDurationUpdated;

	public event Action<IDocumentCue?>? TimelineLoopUpdated;

	public ActiveTimeline(TriggerHandle handle, IDocumentCue documentCue, IDebouncerFactory debouncerFactory)
	{
		Timeline = documentCue.GetTimeline();
		Handle = handle;
		DocumentCue = documentCue;
		if (DocumentCue?.DocumentAction != null)
		{
			DocumentCue.DocumentAction.PropertyChanged += DocumentAction_PropertyChanged;
			if (DocumentCue.DocumentAction.Presentation != null)
			{
				DocumentCue.DocumentAction.Presentation.DataModified += Presentation_DataModified;
			}
		}
		_timelineUpdateDebouncer = debouncerFactory.CreateDispatched(delegate(IDocumentCue? t)
		{
			this.TimelineItemsUpdated?.Invoke(t);
		}, 200.0);
		if (Timeline != null)
		{
			Timeline.PropertyChanged += Timeline_PropertyChanged;
			Timeline.CollectionChanged += Timeline_CollectionChanged;
			Timeline.ForEach(SetupItem);
		}
	}

	private void Presentation_DataModified(IPresentation _)
	{
		OnUpdate();
	}

	private void DocumentAction_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Destination" || propertyName == "TargetKey")
		{
			OnUpdate();
		}
	}

	private void Timeline_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnUpdate();
		e.OldItems?.OfType<TimelineItemInfo>().ForEach(TeardownItem);
		e.NewItems?.OfType<TimelineItemInfo>().ForEach(SetupItem);
	}

	private void TeardownItem(TimelineItemInfo item)
	{
		item.PropertyChanged -= Item_PropertyChanged;
		if (item.Item is IAction action)
		{
			action.DataModified -= OnUpdate;
		}
	}

	private void SetupItem(TimelineItemInfo item)
	{
		item.PropertyChanged += Item_PropertyChanged;
		if (item.Item is IAction action)
		{
			action.DataModified += OnUpdate;
		}
	}

	private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SlideTime")
		{
			OnUpdate();
		}
	}

	private void Timeline_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Duration")
		{
			this.TimelineDurationUpdated?.Invoke(DocumentCue);
		}
		else if (e.PropertyName == "IsSetToLoop")
		{
			this.TimelineLoopUpdated?.Invoke(DocumentCue);
		}
	}

	private void OnUpdate()
	{
		_timelineUpdateDebouncer.Invoke(DocumentCue);
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (DocumentCue?.DocumentAction != null)
		{
			DocumentCue.DocumentAction.PropertyChanged -= DocumentAction_PropertyChanged;
			if (DocumentCue.DocumentAction.Presentation != null)
			{
				DocumentCue.DocumentAction.Presentation.DataModified -= Presentation_DataModified;
			}
		}
		if (Timeline != null)
		{
			Timeline.PropertyChanged -= Timeline_PropertyChanged;
			Timeline.CollectionChanged -= Timeline_CollectionChanged;
			Timeline.ForEach(TeardownItem);
		}
	}
}
