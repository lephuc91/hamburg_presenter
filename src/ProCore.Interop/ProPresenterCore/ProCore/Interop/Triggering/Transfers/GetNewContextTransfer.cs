using System;
using System.IO;
using System.Runtime.InteropServices;
using Google.Protobuf;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class GetNewContextTransfer : TriggerTransfer
{
	private unsafe ProGetNewContextTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.GetNewContext;

	public TriggerHandle Handle { get; }

	public object? ClientObject { get; set; }

	public Pro.SerializationInterop.RVProtoData.Action Action { get; set; } = new Pro.SerializationInterop.RVProtoData.Action();

	public TriggerSource TriggerSource { get; } = new TriggerSource();

	public TimeSlice TriggerTime { get; } = TimeSlice.Zero;

	public unsafe GetNewContextTransfer(ProGetNewContextTransfer.__Internal* native)
		: this(new TriggerHandle(native->triggerHandle))
	{
		_native = native;
		if (native->action != IntPtr.Zero)
		{
			UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)native->action, native->actionSize);
			((IMessage)Action).MergeFrom((Stream)input);
		}
		if (native->triggerSourceData != IntPtr.Zero)
		{
			UnmanagedMemoryStream input2 = new UnmanagedMemoryStream((byte*)native->triggerSourceData, native->triggerSourceSize);
			((IMessage)TriggerSource).MergeFrom((Stream)input2);
		}
		ClientObject = ((native->clientContext != IntPtr.Zero) ? GCHandle.FromIntPtr(native->clientContext).Target : null);
		TriggerTime = TimeSlice.FromSeconds(native->activateTime);
	}

	public GetNewContextTransfer(TriggerHandle handle)
	{
		Handle = handle;
	}

	internal unsafe override void Apply()
	{
		_native->clientContext = ((ClientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(ClientObject)) : IntPtr.Zero);
	}
}
