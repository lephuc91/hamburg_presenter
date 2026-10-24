using System;

namespace Pro.Common.Utility;

public interface IDebouncer : IDisposable
{
	void Invoke();

	void Invoke(bool forceImmediate);
}
public interface IDebouncer<in T> : IDisposable
{
	void Invoke(T data);

	void Invoke(T data, bool forceImmediate);
}
