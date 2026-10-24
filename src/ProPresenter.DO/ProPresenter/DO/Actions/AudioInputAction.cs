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
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class AudioInputAction : ActionBase, IScrimSource, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private int _index = -1;

	private bool _overrideMode;

	private BehaviorMode _selectedMode;

	private bool _overrideVolume;

	private double _volume;

	public override ActionType ActionType => ActionType.AudioInput;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public override bool IsValid => AudioInputs?.ElementAtOrDefault(Index) != null;

	protected override bool CanRename => false;

	protected override string DefaultName => AudioInputs?.ElementAtOrDefault(Index)?.LongName ?? LocalizedStrings.Get(ActionType);

	public int Index
	{
		get
		{
			return _index;
		}
		set
		{
			SetValue("Index", ref _index, value, delegate(int o, int n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetAudioInput.ToAction(), this, "Index", o, n);
				ProPresenter.DO.Audio.IAudioInput audioInput = AudioInputs?.ElementAtOrDefault(o);
				if (audioInput != null)
				{
					audioInput.PropertyChanged -= base.RaiseLinkedValues;
				}
				ProPresenter.DO.Audio.IAudioInput audioInput2 = AudioInputs?.ElementAtOrDefault(n);
				if (audioInput2 != null)
				{
					audioInput2.PropertyChanged += base.RaiseLinkedValues;
				}
				OnDataModified();
				OnPropertyChanged("IsValid");
				OnPropertyChanged("DefaultName");
			});
		}
	}

	public LinkedVideoInputs LinkedVideoInputs { get; } = new LinkedVideoInputs();

	public bool OverrideMode
	{
		get
		{
			return _overrideMode;
		}
		set
		{
			SetValue("OverrideMode", ref _overrideMode, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetAudioInputConfigureMode.ToAction(), this, "OverrideMode", o, n);
				OnDataModified();
			});
		}
	}

	public BehaviorMode BehaviorMode
	{
		get
		{
			return _selectedMode;
		}
		set
		{
			SetValue("BehaviorMode", ref _selectedMode, value, delegate(BehaviorMode o, BehaviorMode n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetAudioInputBehaviorMode.ToAction(), this, "BehaviorMode", o, n);
				OnDataModified();
			});
		}
	}

	public bool OverrideVolume
	{
		get
		{
			return _overrideVolume;
		}
		set
		{
			SetValue("OverrideVolume", ref _overrideVolume, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetAudioInputConfigureLevel.ToAction(), this, "OverrideVolume", o, n);
				OnDataModified();
			});
		}
	}

	public double Volume
	{
		get
		{
			return _volume;
		}
		set
		{
			SetValue("Volume", ref _volume, value, delegate(double o, double n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionSetAudioInputLevel.ToAction(), this, "Volume", o, n);
				OnDataModified();
			});
		}
	}

	public IAudioInputCollection AudioInputs { get; }

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudioInputAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IAudioInput audioInput = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IAudioInput;
		if (audioInput == null)
		{
			audioInput = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IAudioInput>();
			right.ActionTypeData.Set(audioInput);
		}
		ObjectBinder<AudioInputAction, Pro.Entity.IAction.Types.IAudioInputType> binder = new ObjectBinder<AudioInputAction, Pro.Entity.IAction.Types.IAudioInputType>(left, audioInput.Value);
		binder.Bind((AudioInputAction l) => l.WhenPropertyChanges("Index"), (Pro.Entity.IAction.Types.IAudioInputType r) => r.Index.WhenValueChanges, delegate(AudioInputAction l, Pro.Entity.IAction.Types.IAudioInputType r)
		{
			r.Index.Set(l.Index);
		}, delegate(Pro.Entity.IAction.Types.IAudioInputType r, AudioInputAction l)
		{
			l.Index = r.Index.Value;
		}).Bind((AudioInputAction l) => l.WhenPropertyChanges("BehaviorMode"), (Pro.Entity.IAction.Types.IAudioInputType r) => r.BehaviorMode.WhenValueChanges, delegate(AudioInputAction l, Pro.Entity.IAction.Types.IAudioInputType r)
		{
			Pro.Entity.IAudioInput.Types.IBehaviorMode behaviorMode = entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode>();
			r.BehaviorMode.Set(behaviorMode);
			switch (l.BehaviorMode)
			{
			case BehaviorMode.On:
				behaviorMode.Mode.Set(entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOn>());
				break;
			case BehaviorMode.Off:
				behaviorMode.Mode.Set(entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOff>());
				break;
			case BehaviorMode.AutoOff:
				behaviorMode.Mode.Set(entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff>());
				break;
			case BehaviorMode.AutoOn:
			{
				Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn autoOn = entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn>();
				l.LinkedVideoInputs.Serialize().ForEach(autoOn.Value.LinkedVideoInputs.Add);
				behaviorMode.Mode.Set(autoOn);
				break;
			}
			}
		}, delegate(Pro.Entity.IAction.Types.IAudioInputType r, AudioInputAction l)
		{
			Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode value = r.BehaviorMode.Value.Mode.Value;
			if (!(value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOn))
			{
				if (!(value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOff))
				{
					if (!(value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff))
					{
						if (value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn autoOn2)
						{
							l.BehaviorMode = BehaviorMode.AutoOn;
							l.LinkedVideoInputs.Deserialize(autoOn2.Value.LinkedVideoInputs.Items.Select((uint i) => (int)i));
						}
					}
					else
					{
						l.BehaviorMode = BehaviorMode.AutoOff;
					}
				}
				else
				{
					l.BehaviorMode = BehaviorMode.Off;
				}
			}
			else
			{
				l.BehaviorMode = BehaviorMode.On;
			}
		}, scheduler.Scheduler).Bind((AudioInputAction l) => l.WhenPropertyChanges("OverrideMode"), (Pro.Entity.IAction.Types.IAudioInputType r) => r.OverrideMode.WhenValueChanges, delegate(AudioInputAction l, Pro.Entity.IAction.Types.IAudioInputType r)
		{
			r.OverrideMode.Set(l.OverrideMode);
		}, delegate(Pro.Entity.IAction.Types.IAudioInputType r, AudioInputAction l)
		{
			l.OverrideMode = r.OverrideMode.Value;
		})
			.Bind((AudioInputAction l) => l.WhenPropertyChanges("OverrideVolume"), (Pro.Entity.IAction.Types.IAudioInputType r) => r.OverrideVolume.WhenValueChanges, delegate(AudioInputAction l, Pro.Entity.IAction.Types.IAudioInputType r)
			{
				r.OverrideVolume.Set(l.OverrideVolume);
			}, delegate(Pro.Entity.IAction.Types.IAudioInputType r, AudioInputAction l)
			{
				l.OverrideVolume = r.OverrideVolume.Value;
			})
			.Bind((AudioInputAction l) => l.WhenPropertyChanges("Volume"), (Pro.Entity.IAction.Types.IAudioInputType r) => r.Volume.WhenValueChanges, delegate(AudioInputAction l, Pro.Entity.IAction.Types.IAudioInputType r)
			{
				r.Volume.Set(l.Volume);
			}, delegate(Pro.Entity.IAction.Types.IAudioInputType r, AudioInputAction l)
			{
				l.Volume = r.Volume.Value;
			});
		objectBinder.DoOnInitializeRightFromLeft(binder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(binder.InitializeLeftFromRight).RegisterChildDisposable(() => binder);
		return objectBinder;
	}

	public AudioInputAction(ProPresenter.DO.Audio.AudioInput audioInput, IAudioInputCollection audioInputs)
		: this(audioInputs)
	{
		_index = AudioInputs.IndexOf(audioInput);
	}

	public AudioInputAction(IAudioInputCollection audioInputs)
	{
		AudioInputs = audioInputs;
		AudioInputs.CollectionChanged += delegate
		{
			OnPropertyChanged("IsValid");
		};
		LinkProperties("LongName", "DefaultName");
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new AudioInputAction(AudioInputs));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is AudioInputAction audioInputAction)
		{
			audioInputAction.Index = Index;
			audioInputAction.OverrideMode = OverrideMode;
			audioInputAction.BehaviorMode = BehaviorMode;
			audioInputAction.OverrideVolume = OverrideVolume;
			audioInputAction.Volume = Volume;
		}
		return base.CopyProperties(action);
	}

	public override Action Serialize()
	{
		Action action = base.Serialize();
		action.AudioInput = new Action.Types.AudioInputType
		{
			Index = Index,
			BehaviorMode = BehaviorMode.ToProtoBehaviorMode(LinkedVideoInputs.Serialize()),
			OverrideMode = OverrideMode,
			OverrideVolume = OverrideVolume,
			Volume = Volume
		};
		return action;
	}

	public override void Deserialize(Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		if (data.AudioInput != null)
		{
			Index = data.AudioInput.Index;
			OverrideMode = data.AudioInput.OverrideMode;
			OverrideVolume = data.AudioInput.OverrideVolume;
			(BehaviorMode behaviorMode, IEnumerable<int>? linkedVideoInputs) tuple = data.AudioInput.BehaviorMode.ToBehaviorMode();
			BehaviorMode item = tuple.behaviorMode;
			IEnumerable<int> item2 = tuple.linkedVideoInputs;
			BehaviorMode = item;
			LinkedVideoInputs.Deserialize(item2);
			Volume = data.AudioInput.Volume;
		}
	}

	public void SetIndex(ProPresenter.DO.Audio.AudioInput audioInput)
	{
		Index = AudioInputs?.IndexOf(audioInput) ?? Index;
	}
}
