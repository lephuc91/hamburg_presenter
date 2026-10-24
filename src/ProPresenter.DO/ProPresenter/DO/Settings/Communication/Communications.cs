using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Pro.Common.Collections;
using Pro.Common.DataStore;
using Pro.MIDI;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Communication.Devices;
using ProPresenter.DO.Communication.MIDI;
using ProPresenter.DO.Settings.Communication.Model;

namespace ProPresenter.DO.Settings.Communication;

public class Communications : StoreBase, ICommunicationDeviceProvider
{
	private const string SettingsFile = "CommunicationsPreferences.proPref";

	private static Communications _settings = new Communications();

	public static Communications Settings => _settings;

	public int AutoFillStart
	{
		get
		{
			return GetValue("AutoFillStart", 0);
		}
		set
		{
			SetValue("AutoFillStart", value);
			OnPropertyChanged("AutoFillStart");
		}
	}

	public Dictionary<MIDIAction, int>? MIDINoteMapping
	{
		get
		{
			return GetValue("MIDINoteMapping", new Dictionary<MIDIAction, int>());
		}
		set
		{
			SetValue("MIDINoteMapping", value);
			OnPropertyChanged("MIDINoteMapping");
		}
	}

	public List<IDevice>? Devices
	{
		get
		{
			return GetValue("Devices", new List<IDevice>());
		}
		set
		{
			this.DevicesChanged?.Invoke(Devices?.ToArray(), value?.ToArray());
			SetValue("Devices", value);
			OnPropertyChanged("Devices");
		}
	}

	public List<Guid>? ConnectedDevices
	{
		get
		{
			return GetValue("ConnectedDevices", new List<Guid>());
		}
		set
		{
			SetValue("ConnectedDevices", value);
			OnPropertyChanged("ConnectedDevices");
		}
	}

	IEnumerable<IDevice>? ICommunicationDeviceProvider.Devices => Devices;

	public event Action<IEnumerable<IDevice>?, IEnumerable<IDevice>?>? DevicesChanged;

	private Communications()
		: base(Path.Combine(CommonPaths.Preferences, "CommunicationsPreferences.proPref"))
	{
		RegisterEnumType<MIDIAction>();
		RegisterDictionaryType<MIDIAction, int, Dictionary<MIDIAction, int>>();
		RegisterCustomType(OnEncodeDevice, OnDecodeDevice);
		RegisterListType<IDevice, List<IDevice>>();
		RegisterListType(delegate(Guid id, List<Guid> list)
		{
			list.Add(id);
		});
	}

	private static string OnEncodeDevice(IDevice device)
	{
		if (device.Type == DeviceType.MIDI)
		{
			MIDIDevice mIDIDevice = (MIDIDevice)device;
			return JsonSerializer.Serialize(new MidiDeviceInfo(mIDIDevice.ID, mIDIDevice.Label, mIDIDevice.Reconnect, mIDIDevice.ActiveInputs.Select(OnEncodeMidiConnectedDeviceInfo).ToArray(), mIDIDevice.ActiveOutputs.Select(OnEncodeMidiConnectedDeviceInfo).ToArray()), DeviceInfoSerializationSourceGenerationContext.Default.DeviceInfo);
		}
		throw new NotSupportedException();
	}

	private static IDevice OnDecodeDevice(string jsonData)
	{
		if (JsonSerializer.Deserialize(jsonData, DeviceInfoSerializationSourceGenerationContext.Default.DeviceInfo) is MidiDeviceInfo info)
		{
			return CreateMidiDeviceInfo(info);
		}
		throw new NotSupportedException();
	}

	private static MidiConnectedDeviceInfo OnEncodeMidiConnectedDeviceInfo(Pro.MIDI.DeviceInfo info)
	{
		return new MidiConnectedDeviceInfo(info.Name, info.ManufacturerID, info.ProductID, info.DriverVersion);
	}

	private static MIDIDevice CreateMidiDeviceInfo(MidiDeviceInfo info)
	{
		MIDIDevice device = new MIDIDevice(info.Id)
		{
			Label = info.Label,
			Reconnect = info.Reconnect
		};
		info.ActiveInputs.Select(OnCreateMidiConnectedDeviceInfo).ForEach(delegate(Pro.MIDI.DeviceInfo di)
		{
			device.ActiveInputs[di] = true;
		});
		info.ActiveOutputs.Select(OnCreateMidiConnectedDeviceInfo).ForEach(delegate(Pro.MIDI.DeviceInfo di)
		{
			device.ActiveOutputs[di] = true;
		});
		return device;
	}

	private static Pro.MIDI.DeviceInfo OnCreateMidiConnectedDeviceInfo(MidiConnectedDeviceInfo info)
	{
		return new Pro.MIDI.DeviceInfo(info.Name, info.ManufacturerID, info.ProductID, info.DriverVersion);
	}
}
