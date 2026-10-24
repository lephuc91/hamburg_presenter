using System.Diagnostics.CodeAnalysis;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Localization;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Controller.Links;

public class PlaylistItemInfo : IPlaylistItemInfo
{
	private sealed record PlaylistItemInfoData(string CurrentPlaylistItemArrangement, string NextPlaylistItemArrangement, string CurrentHeader, string NextHeader, string? Playlist, string? CurrentPlaylistItem, string? NextPlaylistItem);

	private readonly CueInfo? _activePlaylistItem;

	private readonly ITimelineManager _timelineManager;

	private readonly IUiDispatcher _dispatcher;

	private readonly Optional<PlaylistItemInfoData> _data = new Optional<PlaylistItemInfoData>();

	private PlaylistItemInfoData Data
	{
		get
		{
			lock (_data)
			{
				if (!_data.HasValue)
				{
					_dispatcher.Invoke(CollectInformation);
				}
			}
			return _data.Value;
		}
	}

	public string Playlist => Data.Playlist ?? string.Empty;

	public string CurrentPlaylistItem => Data.CurrentPlaylistItem ?? string.Empty;

	public string CurrentPlaylistItemArrangement => Data.CurrentPlaylistItemArrangement ?? string.Empty;

	public string NextPlaylistItem => Data.NextPlaylistItem ?? string.Empty;

	public string NextPlaylistItemArrangement => Data.NextPlaylistItemArrangement;

	public string CurrentHeader => Data.CurrentHeader;

	public string NextHeader => Data.NextHeader;

	public PlaylistItemInfo(IUiDispatcher dispatcher, CueInfo? activePlaylistItem, ITimelineManager timelineManager)
	{
		_dispatcher = dispatcher;
		_activePlaylistItem = activePlaylistItem;
		_timelineManager = timelineManager;
	}

	private void CollectInformation()
	{
		ProPresenterCue proPresenterCue = ((_activePlaylistItem as SlideCueInfo)?.OriginalDocumentCue as ProPresenterCue) ?? (_activePlaylistItem as MediaCueInfo<ProPresenterCue>)?.OriginalMedia;
		Playlist<ProPresenterCue> playlist = (_activePlaylistItem as SlideCueInfo)?.OriginalPlaylist ?? (_activePlaylistItem as MediaCueInfo<ProPresenterCue>)?.OriginalPlaylist;
		ProPresenterCue proPresenterCue2 = playlist?.GetNext(proPresenterCue, (ProPresenterCue c) => !(c is IHeaderCue) && !c.IsHidden);
		_data.Value = new PlaylistItemInfoData(GetArrangementName(proPresenterCue, _timelineManager), GetArrangementName(proPresenterCue2, _timelineManager), GetHeaderName(playlist, proPresenterCue), GetHeaderName(playlist, proPresenterCue2), playlist?.Name, proPresenterCue?.Name, proPresenterCue2?.Name);
	}

	private static bool TryGetTimelineArrangementName(ProPresenterCue? cue, ITimelineManager timelineManager, [NotNullWhen(true)] out string? name)
	{
		name = null;
		if (cue is IDocumentCue cue2)
		{
			(bool, bool, TimeSlice) info = timelineManager.GetInfo(cue2);
			(bool, bool, TimeSlice) tuple = info;
			if ((tuple.Item1 || tuple.Item2 || tuple.Item3 != default(TimeSlice)) && info.Item1)
			{
				name = LocalizedStrings.Get("PRESENTATION_HEADER_TIMELINE_tooltip");
				return true;
			}
		}
		return false;
	}

	private static string GetArrangementName(ProPresenterCue? cue, ITimelineManager timelineManager)
	{
		if (TryGetTimelineArrangementName(cue, timelineManager, out string name))
		{
			return name;
		}
		if (!(cue is IDocumentCue doc))
		{
			return string.Empty;
		}
		return GetArrangementName(doc);
	}

	private static string GetArrangementName(IDocumentCue doc)
	{
		IArrangement arrangement = doc?.DocumentAction?.ActiveArrangement;
		if (arrangement != null && !arrangement.IsMaster)
		{
			return arrangement.Name;
		}
		return string.Empty;
	}

	private static string GetHeaderName(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue)
	{
		return playlist?.GetPrevious(cue, (ProPresenterCue c) => c is IHeaderCue)?.Name ?? string.Empty;
	}
}
