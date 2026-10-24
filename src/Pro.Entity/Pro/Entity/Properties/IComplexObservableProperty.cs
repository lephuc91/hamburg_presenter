using System;

namespace Pro.Entity.Properties;

public interface IComplexObservableProperty<T> : IObservableProperty<T>
{
	IObservable<T> WhenAnyValueChanges { get; }
}
