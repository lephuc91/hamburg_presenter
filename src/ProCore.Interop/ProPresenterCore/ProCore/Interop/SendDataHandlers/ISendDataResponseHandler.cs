using System.Threading.Tasks;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenterCore.ProCore.Interop.SendDataHandlers;

public interface ISendDataResponseHandler
{
	bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType);

	Task Handle(SendDataResponse sendDataResponse);
}
