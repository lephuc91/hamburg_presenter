using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Communication;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.Communication;

namespace ProPresenter.DO.Actions;

public class CommunicationAction : ActionBase, IScrimSource, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private Guid? _deviceID;

	private DeviceType _deviceType;

	private MIDICommand _command;

	private int _channel = 1;

	private int _note;

	private int _intensity;

	private readonly ICommunicationDeviceProvider _communicationStore;

	public Guid? DeviceID
	{
		get
		{
			return _deviceID;
		}
		set
		{
			SetValue("DeviceID", ref _deviceID, value, delegate(Guid? o, Guid? n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionCommunicationSetDevice.ToAction(), this, "DeviceID", o, n);
				DeviceType = (n.HasValue ? DeviceType.MIDI : DeviceType.Unknown);
				OnDataModified();
				OnPropertyChanged("IsValid");
			});
		}
	}

	public override bool IsValid
	{
		get
		{
			if (DeviceType != 0)
			{
				return _communicationStore?.Devices?.Any((IDevice d) => d.Type == DeviceType && d.IsConnected) == true;
			}
			return false;
		}
	}

	public DeviceType DeviceType
	{
		get
		{
			return _deviceType;
		}
		set
		{
			SetValue("DeviceType", ref _deviceType, value, delegate(DeviceType o, DeviceType n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionCommunicationSetDevice.ToAction(), this, "DeviceType", o, n);
				OnDataModified();
			});
		}
	}

	public MIDICommand Command
	{
		get
		{
			return _command;
		}
		set
		{
			SetValue("Command", ref _command, value, delegate(MIDICommand o, MIDICommand n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionCommunicationSettings.ToAction(), this, "Command", o, n);
				OnDataModified();
				base.Name = LocalizedStrings.Get(n);
			});
		}
	}

	public int Channel
	{
		get
		{
			return _channel;
		}
		set
		{
			SetValue("Channel", ref _channel, value, delegate(int o, int n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionCommunicationSettings.ToAction(), this, "Channel", o, n);
				OnDataModified();
			});
		}
	}

	public int Note
	{
		get
		{
			return _note;
		}
		set
		{
			SetValue("Note", ref _note, value, delegate(int o, int n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionCommunicationSettings.ToAction(), this, "Note", o, n);
				OnDataModified();
			});
		}
	}

	public int Intensity
	{
		get
		{
			return _intensity;
		}
		set
		{
			SetValue("Intensity", ref _intensity, value, delegate(int o, int n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionCommunicationSettings.ToAction(), this, "Intensity", o, n);
				OnDataModified();
			});
		}
	}

	public override ActionType ActionType => ActionType.Communication;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, CommunicationAction left, Pro.Entity.IAction right, Action<Pro.DO.Triggering.IAction, Pro.Entity.IAction> onEntityActionTypeChanged)
	{
		Pro.Entity.IAction.Types.IActionTypeData.ICommunication communication = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.ICommunication;
		if (communication == null)
		{
			communication = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.ICommunication>();
			right.ActionTypeData.Set(communication);
		}
		Pro.Entity.IAction.Types.ICommunicationType.Types.ICommandTypeData.IMidiCommand midiCommand = communication.Value.CommandTypeData.Value as Pro.Entity.IAction.Types.ICommunicationType.Types.ICommandTypeData.IMidiCommand;
		if (midiCommand == null)
		{
			midiCommand = entityFactory.Create<Pro.Entity.IAction.Types.ICommunicationType.Types.ICommandTypeData.IMidiCommand>();
			communication.Value.CommandTypeData.Set(midiCommand);
		}
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, onEntityActionTypeChanged);
		ObjectBinder<CommunicationAction, Pro.Entity.IAction.Types.ICommunicationType> deviceBinder = new ObjectBinder<CommunicationAction, Pro.Entity.IAction.Types.ICommunicationType>(left, communication.Value).Bind((CommunicationAction l) => l.WhenPropertyChanges("DeviceID"), (Pro.Entity.IAction.Types.ICommunicationType r) => r.DeviceIdentification.WhenAnyValueChanges, delegate(CommunicationAction l, Pro.Entity.IAction.Types.ICommunicationType r)
		{
			r.DeviceIdentification.Value.ParameterUuid.Set(l.DeviceID);
		}, delegate(Pro.Entity.IAction.Types.ICommunicationType r, CommunicationAction l)
		{
			l.DeviceID = r.DeviceIdentification.Value.ParameterUuid.Value;
		}, null, scheduler.Scheduler);
		ObjectBinder<CommunicationAction, Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand> midiCommandBinder = new ObjectBinder<CommunicationAction, Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand>(left, midiCommand.Value).Bind((CommunicationAction l) => l.WhenPropertyChanges("Command"), (Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r) => r.State.WhenValueChanges, delegate(CommunicationAction l, Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r)
		{
			r.State.Set((l.Command != 0) ? Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand.Types.State.Off : Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand.Types.State.On);
		}, delegate(Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r, CommunicationAction l)
		{
			l.Command = ((r.State.Value != 0) ? MIDICommand.NoteOff : MIDICommand.NoteOn);
		}).Bind((CommunicationAction l) => l.WhenPropertyChanges("Channel"), (Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r) => r.Channel.WhenValueChanges, delegate(CommunicationAction l, Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r)
		{
			r.Channel.Set((uint)l.Channel);
		}, delegate(Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r, CommunicationAction l)
		{
			l.Channel = (int)r.Channel.Value;
		}).Bind((CommunicationAction l) => l.WhenPropertyChanges("Note"), (Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r) => r.Note.WhenValueChanges, delegate(CommunicationAction l, Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r)
		{
			r.Note.Set((uint)l.Note);
		}, delegate(Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r, CommunicationAction l)
		{
			l.Note = (int)r.Note.Value;
		})
			.Bind((CommunicationAction l) => l.WhenPropertyChanges("Intensity"), (Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r) => r.Intensity.WhenValueChanges, delegate(CommunicationAction l, Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r)
			{
				r.Intensity.Set((uint)l.Intensity);
			}, delegate(Pro.Entity.IAction.Types.ICommunicationType.Types.IMidiCommand r, CommunicationAction l)
			{
				l.Intensity = (int)r.Intensity.Value;
			});
		objectBinder.DoOnInitializeRightFromLeft(delegate
		{
			deviceBinder.InitializeRightFromLeft();
			midiCommandBinder.InitializeRightFromLeft();
		}).DoOnInitializeLeftFromRight(delegate
		{
			deviceBinder.InitializeLeftFromRight();
			midiCommandBinder.InitializeLeftFromRight();
		}).RegisterChildDisposable(() => new global::_003C_003Ez__ReadOnlyArray<IDisposable>(new IDisposable[2] { deviceBinder, midiCommandBinder }));
		return objectBinder;
	}

	public CommunicationAction()
		: this(Communications.Settings)
	{
	}

	public CommunicationAction(ICommunicationDeviceProvider communicationStore)
	{
		_communicationStore = communicationStore;
		if (communicationStore != null)
		{
			DeviceID = communicationStore.Devices?.FirstOrDefault()?.ID;
			LinkProperties("IsConnected", "IsValid");
			communicationStore.DevicesChanged += CommunicationStore_DevicesChanged;
			communicationStore.Devices?.ForEach(delegate(IDevice d)
			{
				d.PropertyChanged += base.RaiseLinkedValues;
			});
		}
		base.Name = LocalizedStrings.Get(Command);
	}

	private void CommunicationStore_DevicesChanged(IEnumerable<IDevice>? oldDevices, IEnumerable<IDevice>? newDevices)
	{
		oldDevices?.ForEach(delegate(IDevice d)
		{
			d.PropertyChanged -= base.RaiseLinkedValues;
		});
		newDevices?.ForEach(delegate(IDevice d)
		{
			d.PropertyChanged += base.RaiseLinkedValues;
		});
		IDevice device = newDevices?.FirstOrDefault((IDevice d) => d.Type == DeviceType.MIDI);
		if (device != null)
		{
			Guid iD = device.ID;
			Guid? deviceID = DeviceID;
			if (iD != deviceID)
			{
				DeviceID = device.ID;
			}
		}
		OnPropertyChanged("IsValid");
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new CommunicationAction(_communicationStore));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is CommunicationAction communicationAction)
		{
			communicationAction.DeviceID = DeviceID;
			communicationAction.DeviceType = DeviceType;
			communicationAction.Command = Command;
			communicationAction.Channel = Channel;
			communicationAction.Note = Note;
			communicationAction.Intensity = Intensity;
		}
		return base.CopyProperties(action);
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Communication = new Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType
		{
			DeviceIdentification = new CollectionElementType
			{
				ParameterName = string.Empty,
				ParameterUuid = DeviceID?.ToUUID()
			},
			MidiCommand = new Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType.Types.MIDICommand
			{
				State = ((Command != 0) ? Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType.Types.MIDICommand.Types.State.Off : Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType.Types.MIDICommand.Types.State.On),
				Channel = (uint)Channel,
				Note = (uint)Note,
				Intensity = (uint)Intensity
			}
		};
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		if (data?.Communication != null)
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.CommunicationType communication = data.Communication;
			DeviceID = communication.DeviceIdentification.ParameterUuid?.ToGuid();
			if (communication.MidiCommand != null)
			{
				Command = ((communication.MidiCommand.State != 0) ? MIDICommand.NoteOff : MIDICommand.NoteOn);
				Channel = (int)communication.MidiCommand.Channel;
				Note = (int)communication.MidiCommand.Note;
				Intensity = (int)communication.MidiCommand.Intensity;
			}
		}
	}
}
