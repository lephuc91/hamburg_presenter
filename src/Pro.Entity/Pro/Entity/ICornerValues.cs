using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICornerValues : IEntity, IDisposable
{
	IObservableProperty<IGraphics.Types.Point> TopLeft { get; }

	IObservableProperty<IGraphics.Types.Point> TopRight { get; }

	IObservableProperty<IGraphics.Types.Point> BottomLeft { get; }

	IObservableProperty<IGraphics.Types.Point> BottomRight { get; }
}
