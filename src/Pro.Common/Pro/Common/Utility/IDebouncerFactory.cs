using System;

namespace Pro.Common.Utility;

public interface IDebouncerFactory
{
	IDebouncer Create(Action action, double interval = 100.0);

	IDebouncer<T> Create<T>(Action<T> action, double interval = 100.0);

	IDebouncer CreateDispatched(Action action, double interval = 100.0);

	IDebouncer<T> CreateDispatched<T>(Action<T> action, double interval = 100.0);
}
