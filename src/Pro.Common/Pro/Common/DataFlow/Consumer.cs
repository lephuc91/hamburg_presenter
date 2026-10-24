using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Pro.Common.DataFlow;

public class Consumer<TData>
{
	private readonly ChannelReader<TData> _reader;

	private readonly IDataProcessor<TData> _dataProcessor;

	public Consumer(ChannelReader<TData> reader, IDataProcessor<TData> dataProcessor, CancellationToken token)
	{
		_reader = reader;
		_dataProcessor = dataProcessor;
	}

	public async Task BeginConsumeAsync(CancellationToken token)
	{
		await Task.Run<Task>((Func<Task>)async delegate
		{
			await DoConsume(token);
		}, token);
	}

	private async Task DoConsume(CancellationToken token)
	{
		_ = 1;
		try
		{
			while (await _reader.WaitToReadAsync(token))
			{
				TData data = await _reader.ReadAsync(token);
				if (token.IsCancellationRequested)
				{
					break;
				}
				_dataProcessor.Process(data);
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex2)
		{
			throw new AggregateException(ex2);
		}
	}
}
