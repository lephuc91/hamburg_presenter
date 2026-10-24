using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IDisplayMode : IEntity, IDisposable
{
	IObservableProperty<string> Name { get; }

	IObservableProperty<uint> Width { get; }

	IObservableProperty<uint> Height { get; }

	IObservableProperty<double> RefreshRate { get; }

	IObservableProperty<bool> Interlaced { get; }
}
