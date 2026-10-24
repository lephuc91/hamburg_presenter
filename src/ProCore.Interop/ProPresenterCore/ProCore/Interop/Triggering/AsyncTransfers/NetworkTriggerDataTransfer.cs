using System;
using System.IO;
using System.Runtime.InteropServices;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop.Triggering.AsyncTransfers;

public class NetworkTriggerDataTransfer : AsyncTriggerTransfer
{
	public override ProTriggerTransferType TransferType => ProTriggerTransferType.GetNetworkTriggerData;

	public TriggerHandle NewTriggerHandle { get; }

	public ProTriggerDataRequestType DataRequestType { get; }

	public NetworkIdentifier NetworkIdentifier { get; }

	public unsafe NetworkTriggerDataTransfer(ProAsyncNetworkTriggerDataTransferRequest.__Internal* native)
		: base(&native->header)
	{
		NewTriggerHandle = new TriggerHandle(native->triggerHandle);
		DataRequestType = native->dataType;
		NetworkIdentifier = new NetworkIdentifier();
		UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)((IntPtr*)(&native->data))->ToPointer(), native->dataLength);
		((IMessage)NetworkIdentifier).MergeFrom((Stream)input);
	}

	private unsafe void Send(ProAsyncNetworkTriggerDataTransferResponse.__Internal* native)
	{
		Send((ProAsyncTriggerTransferResponse.__Internal*)native);
	}

	public unsafe void SendFailure(ProResult result)
	{
		ProAsyncNetworkTriggerDataTransferResponse.__Internal _Internal = default(ProAsyncNetworkTriggerDataTransferResponse.__Internal);
		_Internal.header.result = result;
		Send(&_Internal);
	}

	public unsafe void SendItem(NetworkTriggerDataItem? dataItem, object clientObject)
	{
		ProAsyncNetworkTriggerDataTransferResponse.__Internal _Internal = default(ProAsyncNetworkTriggerDataTransferResponse.__Internal);
		if (dataItem == null)
		{
			_Internal.header.result = ProResult.NotFound;
			Send(&_Internal);
			return;
		}
		_Internal.header.result = ProResult.Success;
		_Internal.clientData = ((clientObject != null) ? GCHandle.ToIntPtr(GCHandle.Alloc(clientObject)) : IntPtr.Zero);
		byte[] array = dataItem.ToByteArray();
		fixed (byte* data = array)
		{
			_Internal.data = (nint)data;
			_Internal.dataLength = (uint)array.Length;
			Send(&_Internal);
		}
	}
}
