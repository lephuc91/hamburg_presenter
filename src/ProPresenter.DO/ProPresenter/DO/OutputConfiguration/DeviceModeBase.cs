using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public abstract class DeviceModeBase : NotifyPropertyChangedBase, IDeviceMode, INotifyPropertyChanged
{
	public abstract string Name { get; }

	public abstract Vector2<int> Size { get; }

	public abstract double RefreshRate { get; }

	public abstract bool Interlaced { get; }

	public abstract ObjectBinder<IDeviceMode, IDisplayMode> Bind(IEntityFactory entityFactory, IDisplayMode right);

	protected internal virtual Pro.SerializationInterop.RVProtoData.DisplayMode Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.DisplayMode
		{
			Name = Name,
			Width = (uint)Size.X,
			Height = (uint)Size.Y,
			RefreshRate = RefreshRate,
			Interlaced = Interlaced
		};
	}

	protected internal abstract void Deserialize(Pro.SerializationInterop.RVProtoData.DisplayMode mode, int modeIndex);
}
