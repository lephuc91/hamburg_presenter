using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ITemplateIdentification : IEntity, IDisposable
{
	IObservableProperty<Guid?> Uuid { get; }

	IObservableProperty<string> Name { get; }

	IObservableProperty<Guid> SlideUuid { get; }

	IObservableProperty<string> SlideName { get; }

	IObservableProperty<uint> SlideIndex { get; }
}
