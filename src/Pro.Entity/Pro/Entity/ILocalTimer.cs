using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ILocalTimer : IEntity, IDisposable
{
	IObservableProperty<Guid> Uuid { get; }

	IComplexObservableProperty<ITimer.Types.IConfiguration> Configuration { get; }
}
