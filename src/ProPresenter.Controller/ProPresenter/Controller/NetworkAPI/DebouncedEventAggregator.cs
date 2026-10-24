using System;
using System.CodeDom.Compiler;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;

namespace ProPresenter.Controller.NetworkAPI;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_regularlyTimedEventSender", "_libraryPlaylistsUpdateEventHandler", "_layersStatusEventHandler", "_audioPlaylistFocusedEventsHandler", "_visualPlaylistFocusedEventsHandler", "_libraryPlaylistEventHandler", "_slideTriggeredEventHandler", "_presentationFocusChangedEventHandler", "_chordChartEventHandler", "_libraryPlaylistFocusedEventsHandler" })]
internal class DebouncedEventAggregator : EventSender, IDisposable
{
	private readonly CaptureStatusEventHandler _captureStatusEventHandler = new CaptureStatusEventHandler();

	private readonly LayersStatusEventHandler _layersStatusEventHandler = new LayersStatusEventHandler();

	private readonly LibraryPlaylistActiveItemEventHandler _libraryPlaylistActiveItemEventHandler;

	private readonly PlaylistAndItemEventsHandler<ProPresenterCue, ILibraryPlaylistEvent, IPlaylistFocusedEvent, API_v1_Playlist_Response.Types.GetFocusedPlaylist> _libraryPlaylistFocusedEventsHandler;

	private readonly PlaylistAndItemEventsHandler<MediaCue, IAudioPlaylistEvent, IPlaylistFocusedEvent, API_v1_Audio_Response.Types.FocusedPlaylist> _audioPlaylistFocusedEventsHandler;

	private readonly PlaylistAndItemEventsHandler<MediaCue, IVisualPlaylistEvent, IPlaylistFocusedEvent, API_v1_Media_Response.Types.GetFocusedPlaylist> _visualPlaylistFocusedEventsHandler;

	private readonly PlaylistUpdatedEventHandler<LibraryPlaylistCollectionUpdated, ProPresenterCue> _libraryPlaylistEventHandler;

	private readonly RegularlyTimedEventSender _regularlyTimedEventSender;

	private readonly SlideTriggeredEventHandler _slideTriggeredEventHandler;

	private readonly PresentationFocusChangedEventHandler _presentationFocusChangedEventHandler;

	private readonly ChordChartEventHandler _chordChartEventHandler = new ChordChartEventHandler();

	private readonly LibraryPlaylistCollectionUpdateEventHandler _libraryPlaylistsUpdateEventHandler;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public DebouncedEventAggregator(IAPIv1Service service)
	{
		DebouncedEventAggregator @object = this;
		_libraryPlaylistFocusedEventsHandler = new PlaylistAndItemEventsHandler<ProPresenterCue, ILibraryPlaylistEvent, IPlaylistFocusedEvent, API_v1_Playlist_Response.Types.GetFocusedPlaylist>(service.LibraryPlaylists, LibraryPlaylistHandler.CreateFocusedPlaylistProto, LibraryPlaylistHandler.FocusedPlaylistProtoEqual, (API_v1_Playlist_Response.Types.GetFocusedPlaylist p) => LibraryPlaylistHandler.FocusedPlaylistUpdated(p, service), itemRequired: false);
		_audioPlaylistFocusedEventsHandler = new PlaylistAndItemEventsHandler<MediaCue, IAudioPlaylistEvent, IPlaylistFocusedEvent, API_v1_Audio_Response.Types.FocusedPlaylist>(service.AudioPlaylists, AudioHandler.CreateFocusedPlaylistProto, AudioHandler.FocusedPlaylistProtoEqual, AudioHandler.FocusedPlaylistUpdated, itemRequired: false);
		_visualPlaylistFocusedEventsHandler = new PlaylistAndItemEventsHandler<MediaCue, IVisualPlaylistEvent, IPlaylistFocusedEvent, API_v1_Media_Response.Types.GetFocusedPlaylist>(service.VisualPlaylists, MediaHandler.CreateFocusedPlaylistProto, MediaHandler.FocusedPlaylistProtoEqual, MediaHandler.FocusedPlaylistUpdated, itemRequired: false);
		_libraryPlaylistEventHandler = new PlaylistUpdatedEventHandler<LibraryPlaylistCollectionUpdated, ProPresenterCue>(DataVault.LibraryPlaylistCollection, (Guid id, string name, uint index) => LibraryPlaylistHandler.PlaylistUpdate(id, name, index, service));
		_libraryPlaylistActiveItemEventHandler = new LibraryPlaylistActiveItemEventHandler(service);
		_libraryPlaylistsUpdateEventHandler = new LibraryPlaylistCollectionUpdateEventHandler(DataVault.LibraryPlaylistCollection, service);
		_regularlyTimedEventSender = new RegularlyTimedEventSender(service);
		_slideTriggeredEventHandler = new SlideTriggeredEventHandler(service);
		_presentationFocusChangedEventHandler = new PresentationFocusChangedEventHandler(service);
		setup(new IEventSender[11]
		{
			_captureStatusEventHandler, _layersStatusEventHandler, _libraryPlaylistFocusedEventsHandler, _regularlyTimedEventSender, _audioPlaylistFocusedEventsHandler, _visualPlaylistFocusedEventsHandler, _libraryPlaylistEventHandler, _slideTriggeredEventHandler, _chordChartEventHandler, _presentationFocusChangedEventHandler,
			_libraryPlaylistsUpdateEventHandler
		});
		void setup(IEventSender[] senders)
		{
			senders.ForEach(delegate(IEventSender s)
			{
				s.Send += @object.OnSend;
			});
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_regularlyTimedEventSender.Dispose();
			_libraryPlaylistsUpdateEventHandler.Dispose();
			_layersStatusEventHandler.Dispose();
			_audioPlaylistFocusedEventsHandler.Dispose();
			_visualPlaylistFocusedEventsHandler.Dispose();
			_libraryPlaylistEventHandler.Dispose();
			_slideTriggeredEventHandler.Dispose();
			_presentationFocusChangedEventHandler.Dispose();
			_chordChartEventHandler.Dispose();
			_libraryPlaylistFocusedEventsHandler.Dispose();
		}
	}
}
