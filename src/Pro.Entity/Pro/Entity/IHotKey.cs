using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IHotKey : IEntity, IDisposable
{
	IObservableProperty<KeyCode> Code { get; }
}
