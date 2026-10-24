using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop.Triggering.AsyncTransfers;

public abstract class AsyncTriggerTransfer
{
	public abstract ProTriggerTransferType TransferType { get; }

	private ProAsyncTriggerTransferRequestCallback Callback { get; }

	private nint UserData { get; }

	protected unsafe AsyncTriggerTransfer(ProAsyncTriggerTransferRequest.__Internal* native)
	{
		Callback = Marshal.GetDelegateForFunctionPointer<ProAsyncTriggerTransferRequestCallback>(native->callback);
		UserData = native->callbackUserData;
	}

	protected unsafe void Send(ProAsyncTriggerTransferResponse.__Internal* native)
	{
		Callback?.Invoke((nint)native, UserData);
	}

	public unsafe static AsyncTriggerTransfer? FromNative(ProAsyncTriggerTransferRequest.__Internal* native)
	{
		if (native->type == ProTriggerTransferType.GetNetworkTriggerData)
		{
			return new NetworkTriggerDataTransfer((ProAsyncNetworkTriggerDataTransferRequest.__Internal*)native);
		}
		return null;
	}
}
