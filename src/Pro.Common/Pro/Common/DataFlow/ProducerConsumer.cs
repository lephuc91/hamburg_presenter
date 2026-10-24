using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Pro.Common.DataFlow;

public class ProducerConsumer<TData>
{
	private readonly Channel<TData> _channel;

	private readonly Producer<TData> _producer;

	private readonly Consumer<TData> _consumer;

	private readonly CancellationToken _token;

	private bool _hasStarted;

	public ProducerConsumer(IDataProcessor<TData> dataProcessor, int dataCapacity = int.MaxValue, CancellationToken token = default(CancellationToken))
	{
		_channel = Channel.CreateBounded<TData>(dataCapacity);
		_producer = new Producer<TData>(_channel.Writer);
		_consumer = new Consumer<TData>(_channel.Reader, dataProcessor, token);
		_token = token;
	}

	public async Task RunAsync()
	{
		if (!_hasStarted)
		{
			await _consumer.BeginConsumeAsync(_token);
			_hasStarted = true;
		}
	}

	public async Task ProduceAsync(TData data)
	{
		if (_hasStarted)
		{
			await _producer.ProduceAsync(data, _token);
		}
	}
}
