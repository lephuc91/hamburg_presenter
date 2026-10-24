using ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.AsyncTransfers;

namespace ProPresenter.Controller.AsyncTransferHandlers;

public class NetworkTriggerDataTransferFactory : INetworkTriggerDataTransferFactory
{
	private readonly ClearGroupCollection _clearGroups;

	private readonly LibraryCollection _libraries;

	private readonly LibraryPlaylistCollection _playlists;

	private readonly VisualPlaylistCollection _visualPlaylists;

	private readonly AudioPlaylistCollection _audioPlaylists;

	private readonly IPropSource _props;

	private readonly TimerCollection _timers;

	private readonly MessageCollection _messages;

	private readonly IMacroSource _macroSource;

	private readonly IAudienceLookCollection _looks;

	public NetworkTriggerDataTransferFactory(ClearGroupCollection clearGroups, LibraryCollection libraries, LibraryPlaylistCollection playlists, VisualPlaylistCollection visualPlaylists, AudioPlaylistCollection audioPlaylists, IPropSource props, TimerCollection timers, MessageCollection messages, IMacroSource macroSource, IAudienceLookCollection looks)
	{
		_clearGroups = clearGroups;
		_libraries = libraries;
		_playlists = playlists;
		_visualPlaylists = visualPlaylists;
		_audioPlaylists = audioPlaylists;
		_props = props;
		_timers = timers;
		_messages = messages;
		_macroSource = macroSource;
		_looks = looks;
	}

	public void Handle(ICoreManager manager, NetworkTriggerDataTransfer networkTriggerDataTransfer, ITriggerOperation op)
	{
		INetworkTriggerDataHandler networkTriggerDataHandler = networkTriggerDataTransfer.DataRequestType switch
		{
			ProTriggerDataRequestType.AudienceLook => new AudienceLookNetworkTriggerDataHandler(_looks), 
			ProTriggerDataRequestType.Audio => new AudioNetworkTriggerDataHandler(_audioPlaylists), 
			ProTriggerDataRequestType.ClearGroup => new ClearGroupNetworkTriggerDataHandler(_clearGroups), 
			ProTriggerDataRequestType.Macro => new MacroNetworkTriggerDataHandler(_macroSource), 
			ProTriggerDataRequestType.Media => new MediaNetworkTriggerDataHandler(_visualPlaylists), 
			ProTriggerDataRequestType.Message => new MessageNetworkTriggerDataHandler(_messages), 
			ProTriggerDataRequestType.PresentationLibrary => new PresentationLibraryNetworkTriggerDataHandler(manager, _libraries), 
			ProTriggerDataRequestType.PresentationPlaylist => new PresentationPlaylistNetworkTriggerDataHandler(manager, _playlists), 
			ProTriggerDataRequestType.Prop => new PropNetworkTriggerDataHandler(_props), 
			ProTriggerDataRequestType.Timer => new TimerNetworkTriggerDataHandler(_timers), 
			ProTriggerDataRequestType.VideoInput => new VideoInputNetworkTriggerDataHandler(_visualPlaylists.LiveVideoPlaylist), 
			_ => null, 
		};
		if (networkTriggerDataHandler != null)
		{
			networkTriggerDataTransfer.SendItem(networkTriggerDataHandler.Handle(networkTriggerDataTransfer.NetworkIdentifier, op), op);
		}
		else
		{
			networkTriggerDataTransfer.SendFailure(ProResult.InvalidArgument);
		}
	}
}
