using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ILibraryItem : IEntity, IDisposable
{
	IObservableProperty<Url> Url { get; }
}
