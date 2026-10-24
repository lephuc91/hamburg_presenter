using System;

namespace Pro.Entity.Properties;

public interface IObservableProperty<T>
{
	IObservable<T> WhenValueChanges { get; }

	T Value { get; }

	void Set(T value);
}
