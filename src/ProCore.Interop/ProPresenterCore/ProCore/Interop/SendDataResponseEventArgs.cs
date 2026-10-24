using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenterCore.ProCore.Interop;

public class SendDataResponseEventArgs : EventArgs
{
	public SendDataResponse ProtoSendDataResponse { get; }

	public SendDataResponseEventArgs(SendDataResponse protoSendDataResponse)
	{
		ProtoSendDataResponse = protoSendDataResponse;
	}
}
