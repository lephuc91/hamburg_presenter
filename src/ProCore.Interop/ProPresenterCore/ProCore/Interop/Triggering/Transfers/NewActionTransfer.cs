using System.IO;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class NewActionTransfer : TriggerTransfer
{
	private unsafe readonly ProNewActionTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.NewAction;

	public Action Action { get; }

	public unsafe NewActionTransfer(ProNewActionTransfer.__Internal* native)
	{
		_native = native;
		Action = new Action();
		using UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)native->newActionData, native->newActionDataSize);
		((IMessage)Action).MergeFrom((Stream)input);
	}

	internal override void Apply()
	{
	}
}
