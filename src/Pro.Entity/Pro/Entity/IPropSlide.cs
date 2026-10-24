using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IPropSlide : IEntity, IDisposable
{
	IComplexObservableProperty<ISlide> BaseSlide { get; }

	IComplexObservableProperty<ITransition?> Transition { get; }

	IObservableProperty<bool> AutoClearEnabled { get; }

	IObservableProperty<double> AutoClearDuration { get; }
}
