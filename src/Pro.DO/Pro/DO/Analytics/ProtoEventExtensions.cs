using System;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Create;
using Pro.SerializationInterop.RVProtoData.Analytics.ProContent;
using Pro.SerializationInterop.RVProtoData.Analytics.Sync;
using Pro.SerializationInterop.RVProtoData.Analytics.Timecode;
using Pro.SerializationInterop.RVProtoData.Analytics.Timeline;

namespace Pro.DO.Analytics;

public static class ProtoEventExtensions
{
	public static Library CreateLibrary(this Event protoEvent)
	{
		return protoEvent.CreateLibrary = new Library();
	}

	public static Playlist CreatePlaylist(this Event protoEvent)
	{
		return protoEvent.CreatePlaylist = new Playlist();
	}

	public static Presentation CreatePresentation(this Event protoEvent)
	{
		return protoEvent.CreatePresentation = new Presentation();
	}

	public static TemplatePlaylist CreateTemplatePlaylist(this Event protoEvent)
	{
		return protoEvent.CreateFromTemplatePlaylist = new TemplatePlaylist();
	}

	public static Pro.SerializationInterop.RVProtoData.Analytics.Timeline.Action TimelineAction(this Event protoEvent)
	{
		return protoEvent.TimelineAction = new Pro.SerializationInterop.RVProtoData.Analytics.Timeline.Action();
	}

	public static CueTrigger TimelineCueTrigger(this Event protoEvent)
	{
		return protoEvent.TimelineCueTrigger = new CueTrigger();
	}

	public static RecordCue TimelineRecordCue(this Event protoEvent)
	{
		return protoEvent.TimelineRecordCue = new RecordCue();
	}

	public static Local Sync(this Event protoEvent)
	{
		return protoEvent.SyncLocal = new Local();
	}

	public static Startup TimecodeStartup(this Event protoEvent)
	{
		return protoEvent.TimecodeStartup = new Startup();
	}

	public static Activate TimeCodeActivate(this Event protoEvent)
	{
		return protoEvent.TimecodeActivate = new Activate();
	}

	public static MediaBinView ProcontentMediabinView(this Event protoEvent)
	{
		return protoEvent.ProcontentMediabinView = new MediaBinView();
	}

	public static Download ProcontentDownload(this Event protoEvent)
	{
		return protoEvent.ProcontentDownload = new Download();
	}

	public static DownloadRetry ProcontentDownloadRetry(this Event protoEvent)
	{
		return protoEvent.ProcontentDownloadRetry = new DownloadRetry();
	}

	public static Event Build(Action<Event> action)
	{
		Event @event = new Event();
		action(@event);
		return @event;
	}
}
