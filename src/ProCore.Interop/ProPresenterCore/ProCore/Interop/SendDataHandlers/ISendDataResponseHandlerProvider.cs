using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenterCore.ProCore.Interop.SendDataHandlers;

public interface ISendDataResponseHandlerProvider
{
	IEnumerable<ISendDataResponseHandler> GetHandlers(SendDataResponse.MessageTypeOneofCase sendDataResponseType);
}
