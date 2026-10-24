using System.ComponentModel;

namespace Pro.ssAPI.Devices;

public interface IDevice : INotifyPropertyChanged
{
	string UUID { get; }

	string Name { get; }
}
