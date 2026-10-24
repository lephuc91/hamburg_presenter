using System;
using System.Linq;
using System.Runtime.InteropServices;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller.AsyncTransferHandlers;

internal static class ProtoNetworkTriggerDataItemExtensions
{
	private static TriggerCue ToTriggerCue(Pro.SerializationInterop.RVProtoData.Cue protoCue, ITriggerOperation op, TriggerOptions? triggerOptions = null, TriggerCue.Types.PresentationCue? presentation = null, Playlist? playlist = null)
	{
		return new TriggerCue
		{
			TriggerHandle = op.Handle.RawValue,
			TriggerOptions = triggerOptions,
			Cue = protoCue,
			Presentation = presentation,
			Playlist = playlist,
			ClientData = (ulong)((IntPtr)GCHandle.ToIntPtr(GCHandle.Alloc(op))).ToInt64()
		};
	}

	public static NetworkTriggerDataItem? ToTriggerDataItem(this IAction action)
	{
		if (action == null)
		{
			return null;
		}
		return new NetworkTriggerDataItem
		{
			Action = action.Serialize()
		};
	}

	public static NetworkTriggerDataItem? ToTriggerDataItem<T>(this T? cue, ITriggerOperation op, Playlist<T>? playlist) where T : ProPresenterCue
	{
		if (cue == null)
		{
			return null;
		}
		Pro.SerializationInterop.RVProtoData.Cue cue2 = cue.Serialize();
		return new NetworkTriggerDataItem
		{
			Cue = cue2,
			TriggerCue = ToTriggerCue(cue2, op, null, null, playlist?.ProtoSerialize())
		};
	}

	public static NetworkTriggerDataItem? ToTriggerDataItem<T>(this ICoreManager coreManager, ArrangedCue? slide, T documentCue, ITriggerOperation op) where T : ProPresenterCue, IDocumentCue
	{
		if (slide == null)
		{
			return null;
		}
		NetworkTriggerDataItem dataItem = null;
		coreManager.ActivePlaylistItem = documentCue;
		if (coreManager.SetupSlideTrigger(slide, TriggerSource.NetworkAPI, allowBuildSteps: false, op, new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, null, null, documentCue), null, handleActionTrigger, handleCueTrigger))
		{
			return dataItem;
		}
		return null;
		void handleActionTrigger(Pro.SerializationInterop.RVProtoData.Action protoAction, ITriggerOperation op, TriggerOptions triggerOptions)
		{
			dataItem = new NetworkTriggerDataItem
			{
				Action = protoAction,
				TriggerOptions = triggerOptions
			};
		}
		void handleCueTrigger(Pro.SerializationInterop.RVProtoData.Cue protoCue, ITriggerOperation op, TriggerOptions triggerOptions, LibraryCollection libraryCollection)
		{
			IPresentation presentation = slide.Source.ParentPresentation;
			DocumentCue document = libraryCollection.SelectMany((ILibrary l) => l).FirstOrDefault((DocumentCue d) => d.DocumentAction.Presentation == presentation);
			ILibrary library = ((document == null) ? null : libraryCollection.FirstOrDefault((ILibrary l) => l.Contains(document)));
			SlideTriggerOptions slideTriggerOptions = new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, null, null, documentCue);
			Playlist<ProPresenterCue> playlist = ((coreManager.ActivePlaylistItem != null) ? (slideTriggerOptions.Playlist ?? coreManager.ActiveLibraryPlaylist) : null);
			dataItem = new NetworkTriggerDataItem
			{
				Cue = protoCue,
				TriggerOptions = triggerOptions,
				TriggerCue = ToTriggerCue(protoCue, op, triggerOptions, new TriggerCue.Types.PresentationCue
				{
					Presentation = ((presentation == null) ? null : library?.GetPresentationLoadData(presentation)?.ProtoData),
					ArrangementId = presentation?.ActiveArrangement?.ID.ToUUID(),
					CueIndex = slide.Index - 1
				}, playlist?.ProtoSerialize())
			};
		}
	}
}
