using System;
using System.Collections.Generic;
using System.Linq;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Communication;

namespace ProPresenter.ViewModels.Actions;

public class CommunicationDialogVM : ActionDialogContentVM
{
	private const int ChannelCount = 16;

	private const int NoteCount = 128;

	private const int IntensityCount = 128;

	private readonly int[] _channels = new int[16];

	private readonly int[] _notes = new int[128];

	private readonly int[] _intensity = new int[128];

	public IEnumerable<int> Channels => _channels;

	public IEnumerable<int> Notes => _notes;

	public IEnumerable<int> Intensity => _intensity;

	public IEnumerable<IDevice> Devices { get; }

	public IDevice? Device
	{
		get
		{
			IAction action = base.Action;
			CommunicationAction communicationAction = action as CommunicationAction;
			if (communicationAction == null)
			{
				return null;
			}
			return Devices.FirstOrDefault(delegate(IDevice d)
			{
				Guid iD = d.ID;
				Guid? deviceID = communicationAction.DeviceID;
				return iD == deviceID;
			});
		}
		private set
		{
			if (base.Action is CommunicationAction { DeviceID: var deviceID } communicationAction && deviceID != value?.ID)
			{
				communicationAction.DeviceID = value?.ID;
				OnPropertyChanged("Device");
			}
		}
	}

	public ICommand<IDevice> SetDeviceCommand => new RelayCommand<IDevice>(delegate(IDevice d)
	{
		Device = d;
	}, (IDevice d) => d != null);

	public CommunicationDialogVM(IEnumerable<IDevice> devices)
	{
		Devices = devices;
		for (int i = 0; i < _channels.Length; i++)
		{
			_channels[i] = i + 1;
		}
		for (int j = 0; j < _notes.Length; j++)
		{
			_notes[j] = j;
			_intensity[j] = j;
		}
	}
}
