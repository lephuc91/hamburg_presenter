using System;
using Pro.Common.Utility;
using Pro.MIDI.Interop;

namespace Pro.MIDI;

public struct DeviceInfo : IEquatable<DeviceInfo>
{
	public string Name { get; }

	public ushort ManufacturerID { get; }

	public ushort ProductID { get; }

	public uint DriverVersion { get; }

	internal DeviceInfo(MIDIINCAPS caps)
	{
		Name = caps.Name;
		ManufacturerID = caps.ManufacturerID;
		ProductID = caps.ProductID;
		DriverVersion = caps.DriverVersion;
	}

	internal DeviceInfo(MIDIOUTCAPS caps)
	{
		Name = caps.Name;
		ManufacturerID = caps.ManufacturerID;
		ProductID = caps.ProductID;
		DriverVersion = caps.DriverVersion;
	}

	public DeviceInfo(string name, ushort manufacturerID, ushort productID, uint driverVersion)
	{
		Name = name;
		ManufacturerID = manufacturerID;
		ProductID = productID;
		DriverVersion = driverVersion;
	}

	public override bool Equals(object? obj)
	{
		if (obj is DeviceInfo)
		{
			return Equals((DeviceInfo)obj);
		}
		return false;
	}

	public bool Equals(DeviceInfo other)
	{
		if (Name == other.Name && ManufacturerID == other.ManufacturerID && ProductID == other.ProductID)
		{
			return DriverVersion == other.DriverVersion;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(Name, ManufacturerID, ProductID, DriverVersion);
	}

	public static bool operator ==(DeviceInfo lhs, DeviceInfo rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(DeviceInfo lhs, DeviceInfo rhs)
	{
		return !lhs.Equals(rhs);
	}
}
