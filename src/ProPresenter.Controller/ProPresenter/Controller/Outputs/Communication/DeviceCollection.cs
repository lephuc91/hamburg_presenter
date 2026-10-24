using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using ProPresenter.DO;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Communication.Devices;

namespace ProPresenter.Controller.Outputs.Communication;

public class DeviceCollection : ImmutableObservableCollection<IDevice>
{
	public bool CanAddMIDIDevice => !base.Collection.Any((IDevice d) => d.Type == DeviceType.MIDI);

	public UndoStack UndoStack { get; } = new UndoStack();

	public MIDIDevice AddMIDIDevice()
	{
		if (!CanAddMIDIDevice)
		{
			throw new InvalidOperationException();
		}
		MIDIDevice mIDIDevice = new MIDIDevice();
		OnAddDevice(mIDIDevice);
		return mIDIDevice;
	}

	private void OnAddDevice(IDevice device)
	{
		bool isConnected = device.IsConnected;
		OnAdd(device, isConnected);
		UndoStack.Commit(UndoActionTypes.AddDevice.ToAction(), delegate
		{
			RemoveDevice(device);
		}, delegate
		{
			OnAdd(device, isConnected);
		}, null, null, autoFinalize: true);
	}

	private void OnAdd(IDevice device, bool isConnected)
	{
		if (isConnected)
		{
			device.Connect();
		}
		device.UndoStack = UndoStack;
		base.Collection.Add(device);
		NotifyCanAdd();
	}

	public void RemoveDevice(IDevice device)
	{
		if (device != null)
		{
			bool isConnected = device.IsConnected;
			OnRemove(device);
			UndoStack.Commit(UndoActionTypes.RemoveDevice.ToAction(), delegate
			{
				OnAdd(device, isConnected);
			}, delegate
			{
				OnRemove(device);
			}, null, null, autoFinalize: true);
		}
	}

	private void OnRemove(IDevice device)
	{
		device.Disconnect();
		base.Collection.Remove(device);
		NotifyCanAdd();
	}

	private void NotifyCanAdd()
	{
		OnPropertyChanged("CanAddMIDIDevice");
	}

	public void LoadDevices(IEnumerable<IDevice> devices)
	{
		foreach (IDevice device in devices)
		{
			if (Contains(device))
			{
				throw new InvalidOperationException();
			}
			if (device.Type == DeviceType.MIDI)
			{
				if (!CanAddMIDIDevice)
				{
					throw new InvalidOperationException();
				}
				base.Collection.Add(device);
				continue;
			}
			throw new NotSupportedException();
		}
		NotifyCanAdd();
	}
}
