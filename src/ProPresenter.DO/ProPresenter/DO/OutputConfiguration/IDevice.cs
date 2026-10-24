using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public interface IDevice : INotifyPropertyChanged
{
	DeviceType DeviceType { get; }

	string Name { get; }

	Rect<double> Bounds { get; }

	string Model { get; }

	string Serial { get; }

	string DeviceName { get; }

	string Vendor { get; }

	string DeviceID { get; }

	int ModeIndex { get; }

	IDeviceMode DeviceMode { get; }

	bool IsAttached { get; }

	bool CanChangeModes { get; }

	bool IsPrimaryMonitor { get; }

	bool SupportsAlphaBlending { get; }

	IReadOnlyList<HdrFormats> AvailableHdrFormats { get; }

	HdrFormats SelectedHdrFormat { get; set; }

	double HdrMaxNitsOffset { get; set; }

	bool SupportsHdrRendering { get; }

	int VideoDelay { get; set; }

	(string ErrorTitle, string ErrorContent)? ValidationError { get; set; }

	event System.Action DataChanged;

	OutputDisplay Serialize();

	void ChangeMode(DeviceMode mode);

	ObjectBinder<IDevice, IOutputDisplay> Bind(IEntityFactory entityFactory, IOutputDisplay entity);
}
