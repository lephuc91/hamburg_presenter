using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IGroup : IEntity, IDisposable
{
	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string> Name { get; }

	IObservableProperty<Color?> Color { get; }

	IComplexObservableProperty<IHotKey> HotKey { get; }

	IObservableProperty<Guid?> ApplicationGroupIdentifier { get; }
}
