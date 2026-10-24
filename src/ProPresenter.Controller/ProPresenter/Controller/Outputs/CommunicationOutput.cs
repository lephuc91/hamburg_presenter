using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Utility;
using Pro.MIDI;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Communication.Devices;
using ProPresenter.DO.Communication.MIDI;
using ProPresenter.DO.Settings.Communication;

namespace ProPresenter.Controller.Outputs;

public class CommunicationOutput : NotifyPropertyChangedBase, ICommunicationOutput, INotifyPropertyChanged
{
	private ICoreManager? _manager;

	private int? _lastMIDINote;

	private int? _lastMIDIIntensity;

	private IMIDIActionHandler? _midiActionHandler;

	public DeviceCollection Devices { get; } = new DeviceCollection();

	public IMIDIActionMap MIDIMappings { get; } = new MIDIActionMap();

	public int? LastMIDINote
	{
		get
		{
			return _lastMIDINote;
		}
		private set
		{
			SetValue("LastMIDINote", ref _lastMIDINote, value);
		}
	}

	public int? LastMIDIIntensity
	{
		get
		{
			return _lastMIDIIntensity;
		}
		private set
		{
			SetValue("LastMIDIIntensity", ref _lastMIDIIntensity, value);
		}
	}

	public CommunicationOutput()
	{
		Dictionary<MIDIAction, int> mIDINoteMapping = Communications.Settings.MIDINoteMapping;
		if (mIDINoteMapping != null)
		{
			MIDIMappings.LoadMappings(mIDINoteMapping);
		}
		Devices.LoadDevices(Communications.Settings.Devices);
		Devices.ForEach(SetupDevice);
		Devices.ForEach(delegate(IDevice d)
		{
			if (Communications.Settings.ConnectedDevices != null && Communications.Settings.ConnectedDevices.Contains(d.ID))
			{
				d.Connect();
			}
		});
		Devices.CollectionChanged += OnDeviceCollectionChanged;
		MIDIMappings.CollectionChanged += OnMIDIMappingsCollectionChanged;
	}

	public void AssignManager(ICoreManager manager)
	{
		if (_manager != null || manager == null)
		{
			throw new InvalidOperationException();
		}
		_manager = manager;
		_manager.SendCommunication += OnSendCommunication;
	}

	public void AssignActionHandler(IMIDIActionHandler midiActionHandler)
	{
		_midiActionHandler = midiActionHandler;
	}

	private void OnSendCommunication(Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType communication)
	{
		if (communication?.MidiCommand == null)
		{
			return;
		}
		IDevice device = Devices.FirstOrDefault((IDevice d) => d.ID == communication.DeviceIdentification.ParameterUuid.ToGuid());
		if (device != null)
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType.Types.MIDICommand midiCommand = communication.MidiCommand;
			if (!(device is MIDIDevice mIDIDevice))
			{
				throw new NotSupportedException();
			}
			mIDIDevice.SendNote(midiCommand.State == Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType.Types.MIDICommand.Types.State.On, (int)midiCommand.Channel, (int)midiCommand.Note, (int)midiCommand.Intensity);
		}
	}

	private void OnDeviceCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.NewItems?.Cast<IDevice>().ForEach(SetupDevice);
		e.OldItems?.Cast<IDevice>().ForEach(TeardownDevice);
		SaveDevices();
	}

	private void OnMIDIMappingsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		Communications.Settings.MIDINoteMapping = MIDIMappings.ToDictionary((KeyValuePair<MIDIAction, int> kv) => kv.Key, (KeyValuePair<MIDIAction, int> kv) => kv.Value);
	}

	private void SetupDevice(IDevice device)
	{
		if (device is MIDIDevice mIDIDevice)
		{
			mIDIDevice.NoteReceived += OnMIDINoteReceived;
		}
		device.PropertyChanged += OnDevicePropertyChanged;
	}

	private void OnDevicePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		SaveDevices();
	}

	private void TeardownDevice(IDevice device)
	{
		if (device is MIDIDevice mIDIDevice)
		{
			mIDIDevice.NoteReceived -= OnMIDINoteReceived;
		}
		device.PropertyChanged -= OnDevicePropertyChanged;
	}

	private void SaveDevices()
	{
		Communications.Settings.Devices = Devices.ToList();
		Communications.Settings.ConnectedDevices = (from d in Devices
			where d.IsConnected
			select d.ID).ToList();
	}

	private void OnMIDINoteReceived(int noteValue, int intensity, Pitch pitch)
	{
		LastMIDINote = noteValue;
		LastMIDIIntensity = intensity;
		MIDIMappings.GetActions(noteValue).ForEach(HandleMIDIAction);
	}

	private void HandleMIDIAction(MIDIAction action)
	{
		_midiActionHandler?.Handle(action, LastMIDIIntensity.HasValue ? (LastMIDIIntensity.Value - 1) : (-1));
	}
}
