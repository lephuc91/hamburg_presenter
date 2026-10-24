using System;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public interface IMergedTimer : ITimer, IEntity, IDisposable, ILocalTimer
{
	new IObservableProperty<Guid> Uuid { get; }

	internal ITimer Remote { get; }

	internal ILocalTimer Local { get; }
}
