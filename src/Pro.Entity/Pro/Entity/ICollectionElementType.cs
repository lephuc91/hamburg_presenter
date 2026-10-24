using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICollectionElementType : IEntity, IDisposable
{
	IObservableProperty<Guid?> ParameterUuid { get; }

	IObservableProperty<string?> ParameterName { get; }

	IComplexObservableProperty<ICollectionElementType?> ParentCollection { get; }
}
