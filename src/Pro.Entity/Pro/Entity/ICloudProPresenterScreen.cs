using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICloudProPresenterScreen : IEntity, IDisposable
{
	IObservableProperty<string> Name { get; }

	IObservableProperty<IProPresenterScreen.Types.ScreenType> ScreenType { get; }

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<IGraphics.Types.Size> Size { get; }
}
