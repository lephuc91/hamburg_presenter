using Pro.Common.Components;

namespace Pro.ssAPI.Devices;

internal abstract class VideoDevice : NotifyPropertyChangedBase
{
	public string UUID { get; protected set; }

	public string Name { get; protected set; }

	public string DeviceName { get; protected set; }

	public string VendorID { get; }

	public string ModelName { get; protected set; }

	public override string ToString()
	{
		return Name;
	}

	protected VideoDevice(string uuid, string name, string deviceName, string vendorID, string modelName)
	{
		UUID = uuid;
		Name = name;
		DeviceName = deviceName;
		VendorID = vendorID;
		ModelName = modelName;
	}
}
