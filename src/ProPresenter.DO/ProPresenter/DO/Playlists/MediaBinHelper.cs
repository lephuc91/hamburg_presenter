using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.DO.Application;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

internal static class MediaBinHelper
{
	private static EffectsPresetCollection? _presets;

	public static void SetEffectsPreset(EffectsPresetCollection presets)
	{
		if (presets == null)
		{
			throw new ArgumentNullException();
		}
		if (_presets != null)
		{
			throw new InvalidOperationException();
		}
		_presets = presets;
	}

	internal static void DeserializePlaylists(ObservableCollection<IPlaylist<MediaCue>> collection, IEnumerable<Playlist> protoPlaylists, System.Action dataModified, UndoStack? undoStack, VisualGroupPlaylist? parent, ApplicationData? applicationData, IApp app, IMediaImportService mediaImportService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, bool removeExisting = true)
	{
		int index = 0;
		collection.DeserializeCollection(protoPlaylists, (IPlaylist<MediaCue> p, Playlist d) => p.ID == d.Uuid.ToGuid(), (Playlist d) => ConstructVisualPlaylist(d, undoStack, app, mediaImportService, mediaFactory, transitionDescriptions, flagService), delegate(IPlaylist<MediaCue> p)
		{
			p.PlaylistParent = parent;
			collection.Insert(index++, p);
		}, delegate(IPlaylist<MediaCue> p)
		{
			if (removeExisting)
			{
				p.DataModified -= dataModified;
				collection.Remove(p);
			}
		}, delegate(IPlaylist<MediaCue> p, Playlist d)
		{
			p.DataModified -= dataModified;
			if (p is VisualPlaylist visualPlaylist)
			{
				visualPlaylist.OnDeserializeVisualPlaylist(d, applicationData);
			}
			else if (p is VisualGroupPlaylist visualGroupPlaylist)
			{
				visualGroupPlaylist.OnDeserializeVisualPlaylist(d, applicationData);
			}
			p.DataModified += dataModified;
		});
	}

	internal static void DeserializePlaylistItems(ObservableCollection<MediaCue> collection, IEnumerable<PlaylistItem> protoPlaylistItems, Action<Pro.DO.Triggering.Cue> dataModified, ApplicationData? applicationData, string containerId)
	{
		collection.DeserializeCollection(protoPlaylistItems, (MediaCue m, PlaylistItem p) => m?.ID == p.Uuid.ToGuid(), (PlaylistItem p) => p.ToMediaCue(containerId), delegate(MediaCue m)
		{
			if (m != null)
			{
				collection.Add(m);
			}
		}, delegate(MediaCue m)
		{
			if (m != null)
			{
				m.DataModified -= dataModified;
				collection.Remove(m);
			}
		}, delegate(MediaCue m, PlaylistItem p)
		{
			if (m != null)
			{
				m.DataModified -= dataModified;
				m.OnDeserializeMediaPlaylistItem(p, applicationData, containerId);
				m.DataModified += dataModified;
			}
		});
	}

	public static IPlaylist<MediaCue> ConstructVisualPlaylist(Playlist protoPlaylist, UndoStack? undoStack, IApp app, IMediaImportService mediaImportService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
	{
		if (protoPlaylist.SmartDirectory != null)
		{
			return new SmartPlaylist(undoStack, app, mediaImportService, mediaFactory, transitionDescriptions, flagService);
		}
		if (protoPlaylist.Items != null)
		{
			return new VisualPlaylist(app, mediaImportService, mediaFactory, transitionDescriptions, flagService, undoStack, protoPlaylist.Name);
		}
		if (protoPlaylist.Playlists != null)
		{
			return new VisualGroupPlaylist(app, mediaImportService, mediaFactory, undoStack, transitionDescriptions, flagService);
		}
		throw new NotSupportedException();
	}

	internal static void CheckEffectsPresetHasChanges(EffectsCollection effects)
	{
		EffectsCollection effectsCollection = _presets?.FirstOrDefault((EffectsCollection p) => p.ID == effects.ID);
		if (effectsCollection != null)
		{
			effects.Name = effectsCollection.Name;
			effects.HasChanges = CompareEffectsValues(effectsCollection, effects);
		}
	}

	private static bool CompareEffectsValues(EffectsCollection preset, EffectsCollection itemEffects)
	{
		if (preset.Count != itemEffects.Count)
		{
			return true;
		}
		for (int i = 0; i < preset.Count; i++)
		{
			EffectParameters effectParameters = preset[i];
			EffectParameters effectParameters2 = itemEffects[i];
			if (effectParameters.EffectDescription != effectParameters2.EffectDescription || effectParameters.IsEnabled != effectParameters2.IsEnabled)
			{
				return true;
			}
			if (!(effectParameters.EffectDescription != null))
			{
				continue;
			}
			ParameterDescriptionBase[] parameters = effectParameters.EffectDescription.Parameters;
			for (int j = 0; j < parameters.Length; j++)
			{
				_ = parameters[j];
				if (effectParameters2 != effectParameters)
				{
					return true;
				}
			}
		}
		return false;
	}
}
