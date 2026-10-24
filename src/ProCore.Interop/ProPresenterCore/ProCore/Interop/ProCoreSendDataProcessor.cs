using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.DataFlow;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenterCore.ProCore.Interop;

public class ProCoreSendDataProcessor : IDataProcessor<SendDataResponse>
{
	private readonly ISendDataResponseHandlerProvider _handlerProvider;

	private readonly IAsyncExecutor _asyncExecutor;

	public ProCoreSendDataProcessor(ISendDataResponseHandlerProvider handlerFactory, IAsyncExecutor asyncExecutor)
	{
		_handlerProvider = handlerFactory;
		_asyncExecutor = asyncExecutor;
	}

	public void Process(SendDataResponse data)
	{
		_handlerProvider.GetHandlers(data.MessageTypeCase).ForEach(delegate(ISendDataResponseHandler h)
		{
			_asyncExecutor.ExecuteAsync(async delegate
			{
				await h.Handle(data);
			});
		});
	}
}
