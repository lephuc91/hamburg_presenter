using System;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public interface IMergedScreen : ICloudProPresenterScreen, IEntity, IDisposable, IProPresenterScreen
{
	new IObservableProperty<Guid> Uuid { get; }

	new IObservableProperty<string> Name { get; }

	new IObservableProperty<Types.ScreenType> ScreenType { get; }

	internal ICloudProPresenterScreen Remote { get; }

	internal IProPresenterScreen Local { get; }
}
