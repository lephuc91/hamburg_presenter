using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.Common.Time;
using Pro.Localization;
using Pro.MIDI;

namespace ProPresenter.DO.Communication.Devices;

public class MIDIDevice : NotifyPropertyChangedBase, IDevice, INotifyPropertyChanged
{
	public class ActiveDevices : IEnumerable<DeviceInfo>, IEnumerable
	{
		private readonly List<DeviceInfo> _activeDevices = new List<DeviceInfo>();

		public bool this[DeviceInfo deviceInfo]
		{
			get
			{
				return _activeDevices.Contains(deviceInfo);
			}
			set
			{
				if (value && !this[deviceInfo])
				{
					_activeDevices.Add(deviceInfo);
				}
				else if (!value)
				{
					_activeDevices.Remove(deviceInfo);
				}
				this.DevicesChanged?.Invoke();
			}
		}

		public event Action? DevicesChanged;

		public IEnumerator<DeviceInfo> GetEnumerator()
		{
			return _activeDevices.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _activeDevices.GetEnumerator();
		}
	}

	public delegate void NoteReceivedDelegate(int noteValue, int intensity, Pitch pitch);

	private const string DefaultLabel = "MIDI";

	private Guid _id;

	private string _label = "MIDI";

	private bool _isConnected;

	private bool _reconnect = true;

	private readonly Dictionary<DeviceInfo, Input> _connectedInputs = new Dictionary<DeviceInfo, Input>();

	private readonly Dictionary<DeviceInfo, Output> _connectedOutputs = new Dictionary<DeviceInfo, Output>();

	public DeviceType Type => DeviceType.MIDI;

	public Guid ID => _id;

	public string Status => LocalizedStrings.Get("SETTINGS_DEVICE_DEVICE_STATUS_label", new object[4]
	{
		_connectedInputs.Count,
		ActiveInputs.Count(),
		_connectedOutputs.Count,
		ActiveOutputs.Count()
	});

	public string Label
	{
		get
		{
			return _label;
		}
		set
		{
			SetValue("Label", ref _label, value, delegate(string o, string n)
			{
				UndoStack?.Commit(UndoActionTypes.RenameDevice.ToAction(), this, "Label", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public bool IsConnected
	{
		get
		{
			return _isConnected;
		}
		private set
		{
			SetValue("IsConnected", ref _isConnected, value, NotifyStatusChanged);
		}
	}

	public bool Reconnect
	{
		get
		{
			return _reconnect;
		}
		set
		{
			SetValue("Reconnect", ref _reconnect, value);
		}
	}

	public ActiveDevices ActiveInputs { get; } = new ActiveDevices();

	public ActiveDevices ActiveOutputs { get; } = new ActiveDevices();

	public UndoStack? UndoStack { get; set; }

	public event NoteReceivedDelegate? NoteReceived;

	public MIDIDevice()
		: this(Guid.NewGuid())
	{
	}

	public MIDIDevice(Guid id)
	{
		_id = id;
		ActiveInputs.DevicesChanged += delegate
		{
			OnPropertyChanged("ActiveInputs");
			NotifyStatusChanged();
		};
		ActiveOutputs.DevicesChanged += delegate
		{
			OnPropertyChanged("ActiveOutputs");
			NotifyStatusChanged();
		};
	}

	private void NotifyStatusChanged()
	{
		OnPropertyChanged("Status");
	}

	public void Connect()
	{
		if (!IsConnected)
		{
			ActiveInputs.ForEach(TryConnectInput);
			ActiveOutputs.ForEach(TryConnectOutput);
			IsConnected = true;
		}
	}

	public void SendNote(bool state, int channel, int note, int intensity)
	{
		foreach (DeviceInfo activeOutput in ActiveOutputs)
		{
			if (!_connectedOutputs.TryGetValue(activeOutput, out Output value))
			{
				continue;
			}
			try
			{
				if (state)
				{
					value.SendNoteOn(channel, note, intensity);
				}
				else
				{
					value.SendNoteOff(channel, note, intensity);
				}
			}
			catch (Exception ex)
			{
				Log.Error("Failed to send midi note - {0}", ex);
			}
		}
	}

	private void TryConnectInput(DeviceInfo deviceInfo)
	{
		if (DeviceList.InputDevices.TryFindMatchingDevice(deviceInfo, out InputDevice device))
		{
			Input input;
			try
			{
				input = device.Open();
			}
			catch (Exception ex)
			{
				Log.Error("Failed to connect midi input - {0}", ex);
				return;
			}
			SetupInput(input);
			_connectedInputs.Add(deviceInfo, input);
			NotifyStatusChanged();
		}
	}

	private void TryConnectOutput(DeviceInfo deviceInfo)
	{
		if (DeviceList.OutputDevices.TryFindMatchingDevice(deviceInfo, out OutputDevice device))
		{
			Output output;
			try
			{
				output = device.Open();
			}
			catch (Exception ex)
			{
				Log.Error("Failed to connect midi output - {0}", ex);
				return;
			}
			SetupOutput(output);
			_connectedOutputs.Add(deviceInfo, output);
			NotifyStatusChanged();
		}
	}

	public void Disconnect()
	{
		if (IsConnected)
		{
			_connectedInputs.Values.ForEach(TeardownInput);
			_connectedInputs.Clear();
			_connectedOutputs.Values.ForEach(TeardownOutput);
			_connectedOutputs.Clear();
			IsConnected = false;
			NotifyStatusChanged();
		}
	}

	private void SetupInput(Input input)
	{
		input.Closed += OnInputClosed;
		input.NoteOn += OnInputNoteOn;
	}

	private void TeardownInput(Input input)
	{
		input.Closed -= OnInputClosed;
		input.NoteOn -= OnInputNoteOn;
		input.Dispose();
	}

	private void SetupOutput(Output output)
	{
		output.Closed += OnOutputClosed;
	}

	private void TeardownOutput(Output output)
	{
		output.Closed -= OnOutputClosed;
		output.Dispose();
	}

	private void OnInputClosed(Input input)
	{
		DeviceInfo deviceInfo = input.DeviceInfo;
		TeardownInput(input);
		_connectedInputs.Remove(deviceInfo);
		if (Reconnect)
		{
			TryConnectInput(deviceInfo);
		}
		NotifyStatusChanged();
	}

	private void OnOutputClosed(Output output)
	{
		DeviceInfo deviceInfo = output.DeviceInfo;
		TeardownOutput(output);
		_connectedOutputs.Remove(deviceInfo);
		if (Reconnect)
		{
			TryConnectOutput(deviceInfo);
		}
		NotifyStatusChanged();
	}

	private void OnInputNoteOn(Input sender, TimeSlice timestamp, int channel, int noteValue, int intensity)
	{
		this.NoteReceived?.Invoke(noteValue, intensity, new Pitch(noteValue));
	}
}
