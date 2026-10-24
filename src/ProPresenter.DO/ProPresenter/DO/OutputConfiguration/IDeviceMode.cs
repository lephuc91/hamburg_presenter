using System.ComponentModel;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Entity;

namespace ProPresenter.DO.OutputConfiguration;

public interface IDeviceMode : INotifyPropertyChanged
{
	string Name { get; }

	Vector2<int> Size { get; }

	double RefreshRate { get; }

	bool Interlaced { get; }

	ObjectBinder<IDeviceMode, IDisplayMode> Bind(IEntityFactory entityFactory, IDisplayMode right);
}
