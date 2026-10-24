using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Pro.Common.DataFlow;

public class Producer<TData>
{
	private readonly ChannelWriter<TData> _writer;

	public Producer(ChannelWriter<TData> writer)
	{
		_writer = writer;
	}

	public async Task ProduceAsync(TData data, CancellationToken token)
	{
		try
		{
			await _writer.WriteAsync(data, token);
		}
		catch (TaskCanceledException)
		{
		}
		catch (Exception ex2)
		{
			throw new AggregateException(ex2);
		}
	}
}
