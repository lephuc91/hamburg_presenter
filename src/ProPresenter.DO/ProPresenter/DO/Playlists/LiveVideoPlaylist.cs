using System;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

public class LiveVideoPlaylist : VisualPlaylist
{
	public override PlaylistType Type => PlaylistType.LiveVideo;

	public LiveVideoPlaylist(IApp app, IMediaImportService mediaImportService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, UndoStack? undoStack)
		: base(app, mediaImportService, mediaFactory, transitionDescriptions, flagService, undoStack)
	{
		Name = LocalizedStrings.Get("LIBRARY_PLAYLIST_VIDEO_INPUT_PLAYLIST_title");
	}

	public override IPlaylist<MediaCue> Clone()
	{
		throw new NotSupportedException("LiveVideoPlaylist cannot be cloned");
	}

	public override void ProtoDeserialize(Playlist? data, ApplicationData? applicationData, bool removeExisting = true)
	{
		if (data != null)
		{
			base.ProtoDeserialize(data, applicationData, removeExisting);
			MediaBinHelper.DeserializePlaylistItems(base.Collection, data.Items.Items, base.CueChanged, applicationData, "");
		}
	}
}
