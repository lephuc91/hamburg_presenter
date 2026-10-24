using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI;

namespace ProPresenter.DO.Media.Properties;

public class TransportProperties : NotifyPropertyChangedBase, ICloneable<TransportProperties>
{
	public static readonly int MAX_LOOP_COUNT = 10000;

	private double _playRate = 1.0;

	private TimeSlice _inPoint = TimeSlice.Zero;

	private TimeSlice _outPoint = TimeSlice.Zero;

	private TimeSlice _fadeIn = TimeSlice.Zero;

	private TimeSlice _fadeOut = TimeSlice.Zero;

	private TimeSlice _endPoint = TimeSlice.Zero;

	private PlaybackBehaviorType _playbackBehaviorType = PlaybackBehaviorType.Loop;

	private TimeSlice _loopTime = TimeSlice.Zero;

	private int loopCount = 1;

	private RetriggerBehavior _retriggerBehavior = RetriggerBehavior.Automatic;

	public double PlayRate
	{
		get
		{
			return _playRate;
		}
		set
		{
			SetValue("PlayRate", ref _playRate, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VideoMediaPlayRate), this, "PlayRate", o, n);
				OnDataModified();
			});
		}
	}

	public TimeSlice InPoint
	{
		get
		{
			return _inPoint;
		}
		set
		{
			SetValue("InPoint", ref _inPoint, value, delegate(TimeSlice o, TimeSlice n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaInPoint), this, "InPoint", o, n);
				OnPropertyChanged("InOutDuration");
				OnDataModified();
			});
		}
	}

	public TimeSlice OutPoint
	{
		get
		{
			return _outPoint;
		}
		set
		{
			SetValue("OutPoint", ref _outPoint, value, delegate(TimeSlice oldValue, TimeSlice newValue)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MediaOutPoint), this, "OutPoint", oldValue, newValue);
				OnPropertyChanged("InOutDuration");
				OnDataModified();
			});
		}
	}

	public TimeSlice InOutDuration => OutPoint - InPoint;

	public TimeSlice FadeIn
	{
		get
		{
			return _fadeIn;
		}
		set
		{
			SetValue("FadeIn", ref _fadeIn, value, OnDataModified);
		}
	}

	public TimeSlice FadeOut
	{
		get
		{
			return _fadeOut;
		}
		set
		{
			SetValue("FadeOut", ref _fadeOut, value, OnDataModified);
		}
	}

	public TimeSlice EndPoint
	{
		get
		{
			return _endPoint;
		}
		set
		{
			SetValue("EndPoint", ref _endPoint, value, delegate(TimeSlice o, TimeSlice n)
			{
				if (_outPoint == TimeSlice.Zero)
				{
					OutPoint = n;
				}
				OnDataModified();
			});
		}
	}

	public PlaybackBehaviorType PlaybackBehaviorType
	{
		get
		{
			return _playbackBehaviorType;
		}
		set
		{
			SetValue("PlaybackBehaviorType", ref _playbackBehaviorType, value, delegate(PlaybackBehaviorType o, PlaybackBehaviorType n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VideoMediaPlaybackBehavior), this, "PlaybackBehaviorType", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public TimeSlice LoopTime
	{
		get
		{
			return _loopTime;
		}
		set
		{
			SetValue("LoopTime", ref _loopTime, value, delegate(TimeSlice o, TimeSlice n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VideoMediaLoopDuration), this, "LoopTime", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public int LoopCount
	{
		get
		{
			return loopCount;
		}
		set
		{
			int value2 = value.Clamp(0, MAX_LOOP_COUNT);
			SetValue("LoopCount", ref loopCount, value2, delegate(int o, int n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.VideoMediaLoopCount), this, "LoopCount", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public RetriggerBehavior RetriggerBehavior
	{
		get
		{
			return _retriggerBehavior;
		}
		set
		{
			SetValue("RetriggerBehavior", ref _retriggerBehavior, value, delegate(RetriggerBehavior o, RetriggerBehavior n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Retrigger), this, "_retriggerBehavior", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public static ObjectBinder<TransportProperties, IMedia.Types.ITransportProperties> CreateBinder(TransportProperties left, IMedia.Types.ITransportProperties right)
	{
		ObjectBinder<TransportProperties, IMedia.Types.ITransportProperties> objectBinder = new ObjectBinder<TransportProperties, IMedia.Types.ITransportProperties>(left, right);
		objectBinder.Bind((TransportProperties l) => l.WhenPropertyChanges("PlayRate"), (IMedia.Types.ITransportProperties r) => r.PlayRate.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
		{
			r.PlayRate.Set(l.PlayRate);
		}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
		{
			l.PlayRate = r.PlayRate.Value;
		}).Bind((TransportProperties l) => l.WhenPropertyChanges("InPoint"), (IMedia.Types.ITransportProperties r) => r.InPoint.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
		{
			r.InPoint.Set(l.InPoint.TotalSeconds);
		}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
		{
			l.InPoint = TimeSlice.FromSeconds(r.InPoint.Value);
		}).Bind((TransportProperties l) => l.WhenPropertyChanges("OutPoint"), (IMedia.Types.ITransportProperties r) => r.OutPoint.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
		{
			r.OutPoint.Set(l.OutPoint.TotalSeconds);
		}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
		{
			l.OutPoint = TimeSlice.FromSeconds(r.OutPoint.Value);
		})
			.Bind((TransportProperties l) => l.WhenPropertyChanges("FadeIn"), (IMedia.Types.ITransportProperties r) => r.FadeInDuration.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
			{
				r.FadeInDuration.Set(l.FadeIn.TotalSeconds);
			}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
			{
				l.FadeIn = TimeSlice.FromSeconds(r.FadeInDuration.Value);
			})
			.Bind((TransportProperties l) => l.WhenPropertyChanges("FadeOut"), (IMedia.Types.ITransportProperties r) => r.FadeOutDuration.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
			{
				r.FadeOutDuration.Set(l.FadeOut.TotalSeconds);
			}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
			{
				l.FadeOut = TimeSlice.FromSeconds(r.FadeOutDuration.Value);
			})
			.Bind((TransportProperties l) => l.WhenPropertyChanges("EndPoint"), (IMedia.Types.ITransportProperties r) => r.EndPoint.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
			{
				r.EndPoint.Set(l.EndPoint.TotalSeconds);
			}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
			{
				l.EndPoint = TimeSlice.FromSeconds(r.EndPoint.Value);
			})
			.Bind((TransportProperties l) => l.WhenPropertyChanges("PlaybackBehaviorType"), (IMedia.Types.ITransportProperties r) => r.PlaybackBehavior.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
			{
				r.PlaybackBehavior.Set(l.PlaybackBehaviorType.ToEntityPlaybackBehavior());
			}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
			{
				l.PlaybackBehaviorType = r.PlaybackBehavior.Value.ToPlaybackBehaviorType();
			})
			.Bind((TransportProperties l) => l.WhenPropertyChanges("LoopTime"), (IMedia.Types.ITransportProperties r) => r.LoopTime.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
			{
				r.LoopTime.Set(l.LoopTime.TotalSeconds);
			}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
			{
				l.LoopTime = TimeSlice.FromSeconds(r.LoopTime.Value);
			})
			.Bind((TransportProperties l) => l.WhenPropertyChanges("LoopCount"), (IMedia.Types.ITransportProperties r) => r.TimesToLoop.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
			{
				r.TimesToLoop.Set((uint)l.LoopCount);
			}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
			{
				l.LoopCount = (int)r.TimesToLoop.Value;
			})
			.Bind((TransportProperties l) => l.WhenPropertyChanges("RetriggerBehavior"), (IMedia.Types.ITransportProperties r) => r.Retrigger.WhenValueChanges, delegate(TransportProperties l, IMedia.Types.ITransportProperties r)
			{
				r.Retrigger.Set(l.RetriggerBehavior.ToEntityRetriggerBehavior());
			}, delegate(IMedia.Types.ITransportProperties r, TransportProperties l)
			{
				l.RetriggerBehavior = r.Retrigger.Value.ToRetriggerBehavior();
			});
		return objectBinder;
	}

	public void SerializeToEntity(IEntityFactory entityFactory, IMedia.Types.ITransportProperties transport)
	{
		transport.PlayRate.Set(PlayRate);
		transport.InPoint.Set(InPoint.TotalSeconds);
		transport.OutPoint.Set(OutPoint.TotalSeconds);
		transport.FadeInDuration.Set(FadeIn.TotalSeconds);
		transport.FadeOutDuration.Set(FadeOut.TotalSeconds);
		transport.EndPoint.Set(EndPoint.TotalSeconds);
		transport.PlaybackBehavior.Set(PlaybackBehaviorType.ToEntityPlaybackBehavior());
		transport.LoopTime.Set(LoopTime.TotalSeconds);
		transport.TimesToLoop.Set((uint)LoopCount);
		transport.Retrigger.Set(RetriggerBehavior.ToEntityRetriggerBehavior());
	}

	public void DeserializeEntity(IMedia.Types.ITransportProperties transport)
	{
		PlayRate = transport.PlayRate.Value;
		InPoint = TimeSlice.FromSeconds(transport.InPoint.Value);
		OutPoint = TimeSlice.FromSeconds(transport.OutPoint.Value);
		FadeIn = TimeSlice.FromSeconds(transport.FadeInDuration.Value);
		FadeOut = TimeSlice.FromSeconds(transport.FadeOutDuration.Value);
		EndPoint = TimeSlice.FromSeconds(transport.EndPoint.Value);
		PlaybackBehaviorType = transport.PlaybackBehavior.Value.ToPlaybackBehaviorType();
		LoopTime = TimeSlice.FromSeconds(transport.LoopTime.Value);
		LoopCount = (int)transport.TimesToLoop.Value;
		RetriggerBehavior = transport.Retrigger.Value.ToRetriggerBehavior();
	}

	internal void TransposeProperties(TransportProperties transport, TimeSlice duration)
	{
		if (transport != null)
		{
			_playRate = transport.PlayRate;
			_inPoint = transport.InPoint.Clamp(TimeSlice.Zero, duration);
			if (transport.OutPoint != transport.EndPoint)
			{
				_outPoint = transport.OutPoint.Clamp(TimeSlice.Zero, duration);
			}
			_fadeIn = transport.FadeIn.Clamp(TimeSlice.Zero, duration);
			_fadeOut = transport.FadeOut.Clamp(TimeSlice.Zero, duration);
			_endPoint = transport.EndPoint.Clamp(TimeSlice.Zero, duration);
			_playbackBehaviorType = transport.PlaybackBehaviorType;
			_loopTime = transport.LoopTime;
			loopCount = transport.loopCount;
			_retriggerBehavior = transport.RetriggerBehavior;
		}
	}

	public TransportProperties Clone()
	{
		return new TransportProperties
		{
			_playRate = _playRate,
			_inPoint = _inPoint,
			_outPoint = _outPoint,
			_fadeIn = _fadeIn,
			_fadeOut = _fadeOut,
			_endPoint = _endPoint,
			_playbackBehaviorType = _playbackBehaviorType,
			_loopTime = _loopTime,
			loopCount = loopCount,
			_retriggerBehavior = _retriggerBehavior
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties
		{
			PlayRate = PlayRate,
			InPoint = InPoint.TotalSeconds,
			OutPoint = OutPoint.TotalSeconds,
			FadeInDuration = FadeIn.TotalSeconds,
			FadeOutDuration = FadeOut.TotalSeconds,
			ShouldFadeIn = true,
			ShouldFadeOut = true,
			EndPoint = EndPoint.TotalSeconds,
			PlaybackBehavior = PlaybackBehaviorType.GetProtoPlaybackBehavior(),
			LoopTime = LoopTime.TotalSeconds,
			TimesToLoop = (uint)LoopCount,
			Retrigger = RetriggerBehavior.GetProtoRetriggerBehavior()
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Media.Types.TransportProperties transport)
	{
		if (transport != null)
		{
			PlayRate = transport.PlayRate;
			EndPoint = TimeSlice.FromSeconds(transport.EndPoint);
			_inPoint = TimeSlice.FromSeconds(transport.InPoint);
			_outPoint = TimeSlice.FromSeconds(transport.OutPoint);
			FadeIn = (transport.ShouldFadeIn ? TimeSlice.FromSeconds(transport.FadeInDuration) : TimeSlice.Zero);
			FadeOut = (transport.ShouldFadeOut ? TimeSlice.FromSeconds(transport.FadeOutDuration) : TimeSlice.Zero);
			PlaybackBehaviorType = transport.PlaybackBehavior.GetPlaybackBehaviorType();
			LoopCount = (int)transport.TimesToLoop;
			LoopTime = TimeSlice.FromSeconds(transport.LoopTime);
			RetriggerBehavior = transport.Retrigger.GetRetriggerBehavior();
		}
	}

	public void UpdateDuration(TimeSlice newDuration, TimeSlice oldDuration)
	{
		if (InPoint >= newDuration)
		{
			InPoint = TimeSlice.FromSeconds(0.0);
		}
		if (oldDuration > TimeSlice.Zero && OutPoint >= oldDuration)
		{
			OutPoint = newDuration;
		}
		else
		{
			OutPoint = ((OutPoint > newDuration) ? newDuration : OutPoint);
		}
	}
}
