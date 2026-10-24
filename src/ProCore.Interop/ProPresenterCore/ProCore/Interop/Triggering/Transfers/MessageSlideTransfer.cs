using System.IO;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class MessageSlideTransfer : TriggerTransfer
{
	private unsafe ProMessageSlideTransfer.__Internal* _native;

	public override ProTriggerTransferType TransferType => ProTriggerTransferType.MessageSlide;

	public Action.Types.MessageType MessageAction { get; } = new Action.Types.MessageType();

	public Slide? Slide { get; set; }

	public Message? Message { get; set; }

	internal unsafe MessageSlideTransfer(ProMessageSlideTransfer.__Internal* native)
	{
		_native = native;
		UnmanagedMemoryStream input = new UnmanagedMemoryStream((byte*)native->messageAction, native->messageSize);
		((IMessage)MessageAction).MergeFrom((Stream)input);
	}

	internal unsafe override void Apply()
	{
		if (Slide != null)
		{
			int num = Slide.CalculateSize();
			_native->slide = ProCore.DataTransferAlloc((uint)num);
			_native->slideSize = (uint)num;
			UnmanagedMemoryStream output = new UnmanagedMemoryStream((byte*)_native->slide, num, num, FileAccess.Write);
			((IMessage)Slide).WriteTo((Stream)output);
		}
		if (Message != null)
		{
			int num2 = Message.CalculateSize();
			_native->messageData = ProCore.DataTransferAlloc((uint)num2);
			_native->messageDataSize = (uint)num2;
			UnmanagedMemoryStream output2 = new UnmanagedMemoryStream((byte*)_native->messageData, num2, num2, FileAccess.Write);
			((IMessage)Message).WriteTo((Stream)output2);
		}
	}
}
