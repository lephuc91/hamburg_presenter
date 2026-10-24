using System;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Token;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Messages;

public class TimerToken : MessageTokenBase
{
	private TimerFormatData? _format;

	public override string Content => Timer.Name;

	public TimerData Timer { get; }

	public TimerType SelectedTimerType
	{
		get
		{
			return Timer.Source?.TimerType ?? TimerType.Countdown;
		}
		set
		{
			TimerType? timerType = Timer.Source?.TimerType;
			Timer.UpdateSource(value);
			base.UndoStack?.Commit(UndoActionTypes.TimerType.ToAction(), this, "SelectedTimerType", timerType, value);
			OnPropertyChanged("Timer");
			OnPropertyChanged("SelectedTimerType");
		}
	}

	public TimerFormatData? Format
	{
		get
		{
			return _format;
		}
		private set
		{
			SetValue("Format", ref _format, value, base.OnDataModified);
		}
	}

	public override ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> BindValue(IUiScheduler scheduler, IEntityFactory entityFactory, IMessage.Types.ITokenValue right)
	{
		IMessage.Types.ITokenValue.Types.ITokenValueType.ITimer timer = right.TokenValueType.Value as IMessage.Types.ITokenValue.Types.ITokenValueType.ITimer;
		if (timer == null)
		{
			timer = entityFactory.Create<IMessage.Types.ITokenValue.Types.ITokenValueType.ITimer>();
			right.TokenValueType.Set(timer);
		}
		ObjectBinder<TimerBase, ITimer.Types.IConfiguration> timerSourceBinder = null;
		ObjectBinder<TimerData, IMessage.Types.ITokenValue.Types.ITokenValueTimer> timerConfigurationBinder = new ObjectBinder<TimerData, IMessage.Types.ITokenValue.Types.ITokenValueTimer>(Timer, timer.Value);
		timerConfigurationBinder.Bind((TimerData l) => l.WhenPropertyChanges("Source"), (IMessage.Types.ITokenValue.Types.ITokenValueTimer r) => r.Configuration.WhenValueChanges, delegate(TimerData l, IMessage.Types.ITokenValue.Types.ITokenValueTimer r)
		{
			ITimer.Types.IConfiguration configuration = entityFactory.Create<ITimer.Types.IConfiguration>();
			r.Configuration.Set(configuration);
			ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder = l.Source.Bind(scheduler, entityFactory, configuration);
			objectBinder.InitializeRightFromLeft();
			configuration.RegisterLinkedDisposable(objectBinder);
		}, delegate(IMessage.Types.ITokenValue.Types.ITokenValueTimer r, TimerData l)
		{
			ITimer.Types.IConfiguration.Types.ITimerType value = r.Configuration.Value.TimerType.Value;
			TimerBase timerBase;
			if (!(value is ITimer.Types.IConfiguration.Types.ITimerType.ICountdown))
			{
				if (!(value is ITimer.Types.IConfiguration.Types.ITimerType.ICountdownToTime))
				{
					if (!(value is ITimer.Types.IConfiguration.Types.ITimerType.IElapsedTime))
					{
						throw new NotSupportedException();
					}
					timerBase = new ElapsedTime();
				}
				else
				{
					timerBase = new CountdownToTime();
				}
			}
			else
			{
				timerBase = new CountdownTimer();
			}
			TimerBase timerBase3 = (l.Source = timerBase);
			ObjectBinder<TimerBase, ITimer.Types.IConfiguration> objectBinder2 = timerBase3.Bind(scheduler, entityFactory, r.Configuration.Value);
			objectBinder2.InitializeLeftFromRight();
			r.Configuration.Value.RegisterLinkedDisposable(objectBinder2);
		}).RegisterChildDisposable(() => timerSourceBinder);
		ObjectBinder<TimerToken, IMessage.Types.ITokenValue.Types.ITokenValueTimer> timerFormatBinder = new ObjectBinder<TimerToken, IMessage.Types.ITokenValue.Types.ITokenValueTimer>(this, timer.Value);
		timerFormatBinder.Bind((TimerToken l) => l.WhenPropertyChanges("Format"), (IMessage.Types.ITokenValue.Types.ITokenValueTimer r) => r.Format.WhenValueChanges, delegate(TimerToken l, IMessage.Types.ITokenValue.Types.ITokenValueTimer r)
		{
			ITimer.Types.IFormat format = entityFactory.Create<ITimer.Types.IFormat>();
			r.Format.Set(format);
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder3 = TimerFormatData.CreateBinder(l.Format, r.Format.Value);
			objectBinder3.InitializeRightFromLeft();
			format.RegisterLinkedDisposable(objectBinder3);
		}, delegate(IMessage.Types.ITokenValue.Types.ITokenValueTimer r, TimerToken l)
		{
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder4 = TimerFormatData.CreateBinder(l.Format, r.Format.Value);
			objectBinder4.InitializeLeftFromRight();
			r.Format.Value.RegisterLinkedDisposable(objectBinder4);
		});
		ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> objectBinder5 = base.BindValue(scheduler, entityFactory, right);
		objectBinder5.DoOnInitializeRightFromLeft(delegate
		{
			timerConfigurationBinder.InitializeRightFromLeft();
			timerFormatBinder.InitializeRightFromLeft();
		}).DoOnInitializeLeftFromRight(delegate
		{
			timerConfigurationBinder.InitializeLeftFromRight();
			timerFormatBinder.InitializeLeftFromRight();
		}).RegisterChildDisposable(() => new global::_003C_003Ez__ReadOnlyArray<IDisposable>(new IDisposable[2] { timerConfigurationBinder, timerFormatBinder }));
		return objectBinder5;
	}

	public TimerToken(TimerData timer, TimerFormatData? format = null)
	{
		Timer = timer;
		Timer.DataModified += Timer_DataModified;
		Format = format ?? new TimerFormatData();
		Format.DataModified += base.OnDataModified;
	}

	public TimerToken(Guid timerID, string timerName)
		: this(new TimerData(new CountdownTimer(), timerID)
		{
			Name = timerName
		})
	{
	}

	public override TokenBase Clone()
	{
		return CopyProperties(new TimerToken(Timer.Clone(), Format?.Clone())
		{
			ID = base.ID
		});
	}

	private void Timer_DataModified(TimerSourceBase<TimerBase> timer)
	{
		OnDataModified();
	}

	protected override void OnSerializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
		token.Timer = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeTimer
		{
			Name = Timer.Name,
			TimerUuid = Timer.ID.ToUUID()
		};
	}

	protected override void OnDeserializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
	}

	protected override void OnSerializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		tokenValue.Timer = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueTimer
		{
			Configuration = Timer.Source?.Serialize(),
			Format = Format?.Serialize()
		};
	}

	protected override void OnDeserializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		Pro.SerializationInterop.RVProtoData.Timer timer = new Pro.SerializationInterop.RVProtoData.Timer
		{
			Uuid = Timer.ID.ToUUID(),
			Name = (Timer.Name ?? string.Empty),
			Configuration = tokenValue.Timer.Configuration
		};
		Timer.Deserialize(timer);
		Format?.Deserialize(tokenValue.Timer.Format);
	}

	protected override void OnUndoStackChanged(UndoStack? value)
	{
		if (Timer != null)
		{
			Timer.UndoStack = value;
		}
	}
}
