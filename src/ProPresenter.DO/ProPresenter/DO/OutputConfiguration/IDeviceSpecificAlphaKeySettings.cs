using System;
using System.ComponentModel;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public interface IDeviceSpecificAlphaKeySettings : INotifyPropertyChanged
{
	event System.Action DataModified;

	void Deserialize(OutputDisplay settings);

	void Serialize(OutputDisplay settings);

	ObjectBinder<IDeviceSpecificAlphaKeySettings, IOutputDisplay.Types.IBlackmagic> Bind(IOutputDisplay.Types.IBlackmagic entity);
}
