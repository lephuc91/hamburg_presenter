using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

internal static class AudioBinHelper
{
	internal static void DeserializePlaylists(ObservableCollection<IPlaylist<MediaCue>> collection, IEnumerable<Playlist> protoPlaylists, System.Action dataModified, UndoStack? undoStack, AudioGroupPlaylist? parent, ApplicationData? applicationData, IApp app, IAsyncFileImporter importer, IMediaFactory mediaFactory, ITransitionDescriptionCollection outputRepository, IFlagService flagService, bool removeExisting = true)
	{
		collection.DeserializeCollection(protoPlaylists, (IPlaylist<MediaCue> p, Playlist n) => p.ID == n.Uuid.ToGuid(), (Playlist n) => ConstructAudioPlaylist(n, undoStack, app, importer, mediaFactory, outputRepository, flagService), delegate(IPlaylist<MediaCue> p)
		{
			AddAudioPlaylist(collection, p, parent);
		}, delegate(IPlaylist<MediaCue> p)
		{
			if (removeExisting)
			{
				RemoveAudioPlaylist(collection, p, dataModified);
			}
		}, delegate(IPlaylist<MediaCue> p, Playlist n)
		{
			DeserializeAudioPlaylist(p, n, dataModified, applicationData);
		});
	}

	internal static void DeserializePlaylistItems(ObservableCollection<MediaCue> collection, IEnumerable<PlaylistItem> protoPlaylistItems, Action<Pro.DO.Triggering.Cue> dataModified, ApplicationData? applicationData, string containerId)
	{
		collection.DeserializeCollection(protoPlaylistItems, (MediaCue a, PlaylistItem i) => a?.ID == i.Uuid.ToGuid(), (PlaylistItem p) => p.ToMediaCue(containerId), delegate(MediaCue a)
		{
			if (a != null)
			{
				collection.Add(a);
			}
		}, delegate(MediaCue a)
		{
			if (a != null)
			{
				a.DataModified -= dataModified;
				collection.Remove(a);
			}
		}, delegate(MediaCue a, PlaylistItem i)
		{
			if (a != null)
			{
				a.DataModified -= dataModified;
				a.ProtoDeserializePlaylistItem(i, applicationData, containerId);
				a.DataModified += dataModified;
			}
		});
	}

	public static IPlaylist<MediaCue> ConstructAudioPlaylist(Playlist protoPlaylist, UndoStack? undoStack, IApp app, IAsyncFileImporter importer, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
	{
		if (protoPlaylist.Items != null)
		{
			return new AudioPlaylist(app, importer, mediaFactory, transitionDescriptions, flagService, undoStack, protoPlaylist.Name);
		}
		if (protoPlaylist.Playlists != null)
		{
			return new AudioGroupPlaylist(undoStack, app, importer, mediaFactory, transitionDescriptions, flagService);
		}
		throw new NotSupportedException();
	}

	private static void AddAudioPlaylist(ObservableCollection<IPlaylist<MediaCue>> collection, IPlaylist<MediaCue> playlist, IPlaylist<MediaCue>? parent)
	{
		playlist.PlaylistParent = parent;
		collection.Add(playlist);
	}

	private static void RemoveAudioPlaylist(ObservableCollection<IPlaylist<MediaCue>> collection, IPlaylist<MediaCue> playlist, System.Action dataModified)
	{
		playlist.DataModified -= dataModified;
		collection.Remove(playlist);
	}

	private static void DeserializeAudioPlaylist(IPlaylist<MediaCue> playlist, Playlist protoPlaylist, System.Action dataModified, ApplicationData? applicationData)
	{
		playlist.DataModified -= dataModified;
		playlist.ProtoDeserialize(protoPlaylist, applicationData);
		playlist.DataModified += dataModified;
	}
}
