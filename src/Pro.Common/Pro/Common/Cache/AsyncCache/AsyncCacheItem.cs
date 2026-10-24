using System;
using System.CodeDom.Compiler;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Pro.Common.Concurrency;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Cache.AsyncCache;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_value" })]
public sealed class AsyncCacheItem<TKey, TValue> : IDisposable
{
	private readonly IStopwatch _stopwatch;

	private readonly ReplaySubject<TValue> _value = new ReplaySubject<TValue>(1);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IObservable<TValue> Value => _value;

	public AsyncCacheItem(Func<TKey, Task<TValue>> factory, TKey key, IStopwatch stopwatch)
	{
		_stopwatch = stopwatch;
		Load(factory, key);
	}

	public AsyncCacheItem(TValue value, IStopwatch stopwatch)
	{
		_stopwatch = stopwatch;
		SetValue(value);
	}

	public void SetValue(TValue value)
	{
		_value.OnNext(value);
		_stopwatch.Restart();
	}

	public TimeSpan GetItemTime()
	{
		return _stopwatch.Elapsed;
	}

	private async Task Load(Func<TKey, Task<TValue>> factory, TKey key)
	{
		SetValue(await factory(key));
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_value.Dispose();
		}
	}
}
