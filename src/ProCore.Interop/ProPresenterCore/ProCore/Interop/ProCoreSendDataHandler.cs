using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.DataFlow;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenterCore.ProCore.Interop;

public class ProCoreSendDataHandler
{
	private readonly ProducerConsumer<SendDataResponse> _dataHandler;

	public ProCoreSendDataHandler(IProCoreInstance proCoreInstance, IDataProcessor<SendDataResponse> dataProcessor, CancellationToken token)
	{
		_dataHandler = new ProducerConsumer<SendDataResponse>(dataProcessor, int.MaxValue, token);
		proCoreInstance.SendDataResponseReceived += ProCoreInstance_SendDataResponseReceived;
	}

	private void ProCoreInstance_SendDataResponseReceived(object? sender, SendDataResponseEventArgs e)
	{
		_dataHandler.ProduceAsync(e.ProtoSendDataResponse).ExecuteAsync();
	}

	public async Task RunAsync()
	{
		await _dataHandler.RunAsync();
	}
}
