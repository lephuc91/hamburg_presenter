using System;
using System.IO;
using System.Runtime.InteropServices;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class NextCueTransfer : TriggerTransfer
{
	private unsafe ProNextCueTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.NextCue;

	public TriggerHandle NextCueHandle { get; }

	public TriggerCue? NextCue { get; set; }

	public TriggerOptions? Options { get; set; }

	public object? ClientObject { get; set; }

	public unsafe NextCueTransfer(ProNextCueTransfer.__Internal* native)
	{
		_native = native;
		NextCueHandle = new TriggerHandle(_native->nextHandle);
	}

	internal unsafe override void Apply()
	{
		if (NextCue != null)
		{
			uint num = (uint)NextCue.CalculateSize();
			_native->nextCueData = ProCore.DataTransferAlloc(num);
			_native->nextCueSize = num;
			NextCue.ToByteArray();
			((IMessage)NextCue).WriteTo((Stream)new UnmanagedMemoryStream((byte*)_native->nextCueData, num, num, FileAccess.Write));
			if (Options != null)
			{
				uint num2 = (uint)Options.CalculateSize();
				_native->triggerOptionsData = ProCore.DataTransferAlloc(num2);
				_native->triggerOptionsSize = num2;
				Options.ToByteArray();
				((IMessage)Options).WriteTo((Stream)new UnmanagedMemoryStream((byte*)_native->triggerOptionsData, num2, num2, FileAccess.Write));
			}
			_native->clientData = ((ClientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(ClientObject)) : IntPtr.Zero);
		}
	}
}
