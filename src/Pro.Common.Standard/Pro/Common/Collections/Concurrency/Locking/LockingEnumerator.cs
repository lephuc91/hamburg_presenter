using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Collections.Concurrency.Locking;

[Disposable(new string[] { "_unsafeEnumerator" })]
public class LockingEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
{
	private readonly IEnumerator<T> _unsafeEnumerator;

	private readonly ReaderWriterLockSlim _lock;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public T Current => _unsafeEnumerator.Current;

	object IEnumerator.Current => ((IEnumerator)_unsafeEnumerator).Current;

	public LockingEnumerator(IEnumerable<T> unsafeEnumerable, ReaderWriterLockSlim @lock)
	{
		_lock = @lock;
		_lock.EnterReadLock();
		_unsafeEnumerator = unsafeEnumerable.GetEnumerator();
	}

	public bool MoveNext()
	{
		return _unsafeEnumerator.MoveNext();
	}

	public void Reset()
	{
		_unsafeEnumerator.Reset();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_unsafeEnumerator.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_lock.ExitReadLock();
	}
}
