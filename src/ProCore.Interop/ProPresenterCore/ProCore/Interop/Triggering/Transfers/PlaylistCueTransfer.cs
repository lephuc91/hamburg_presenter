using System;
using System.IO;
using System.Runtime.InteropServices;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;
using ProPresenterCore.ProCore.Interop.Utility;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class PlaylistCueTransfer : TriggerTransfer
{
	private unsafe readonly ProPlaylistCueTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.PlaylistCue;

	public ProPlaylistSourceType PlaylistSource { get; }

	public Guid PlaylistID { get; }

	public string PlaylistName { get; }

	public bool AlwaysRetrigger { get; }

	public TriggerHandle CueHandle { get; }

	public Cue? Cue { get; set; }

	public object? ClientObject { get; set; }

	public unsafe PlaylistCueTransfer(ProPlaylistCueTransfer.__Internal* native)
	{
		_native = native;
		PlaylistID = *(Guid*)native->playlistID;
		PlaylistName = ProPresenterCore.ProCore.Interop.Utility.StringMarshalling.StringFromCString(native->playlistName);
		PlaylistSource = native->playlistSource;
		CueHandle = new TriggerHandle(native->cueHandle);
		AlwaysRetrigger = native->alwaysRetrigger != 0;
	}

	internal unsafe override void Apply()
	{
		if (Cue != null)
		{
			int num = Cue.CalculateSize();
			_native->cue = ProCore.DataTransferAlloc((uint)num);
			_native->cueSize = (uint)num;
			UnmanagedMemoryStream output = new UnmanagedMemoryStream((byte*)_native->cue, num, num, FileAccess.Write);
			((IMessage)Cue).WriteTo((Stream)output);
			_native->clientData = ((ClientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(ClientObject)) : IntPtr.Zero);
		}
	}
}
