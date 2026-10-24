using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IProMask : IEntity, IDisposable
{
	IComplexObservableProperty<ISlide> BaseSlide { get; }

	IObservableProperty<string> Name { get; }
}
