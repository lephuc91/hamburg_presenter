using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timer;

public class TimerFormatData : NotifyPropertyChangedBase, ICloneable<TimerFormatData>
{
	internal static readonly TimeSlice SampleTime = (TimeSlice)TimeSpan.Parse("12:34:56.780");

	private TimerFormatStyle _hourFormat = TimerFormatStyle.Long;

	private TimerFormatStyle _minuteFormat = TimerFormatStyle.Long;

	private TimerFormatStyle _secondFormat = TimerFormatStyle.Long;

	private TimerFormatStyle _millisecondFormat;

	private bool _useWallClockFormat;

	private bool _use24HourFormat;

	private bool _validationInProgress;

	public UndoStack? UndoStack { get; set; }

	public TimerFormatStyle HourFormat
	{
		get
		{
			return _hourFormat;
		}
		set
		{
			SetValue("HourFormat", ref _hourFormat, value, delegate(TimerFormatStyle o, TimerFormatStyle n)
			{
				UndoStack?.BeginCommit(UndoActionTypes.TimeFormat.ToAction());
				UndoStack?.Commit(this, "HourFormat", o, n);
				ValidateFormats();
				OnPropertyChanged("AvailableMinuteFormats");
				OnPropertyChanged("SecondsAvailable");
				OnDataModified();
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public TimerFormatStyle MinuteFormat
	{
		get
		{
			return _minuteFormat;
		}
		set
		{
			SetValue("MinuteFormat", ref _minuteFormat, value, delegate(TimerFormatStyle o, TimerFormatStyle n)
			{
				UndoStack?.BeginCommit(UndoActionTypes.TimeFormat.ToAction());
				UndoStack?.Commit(this, "MinuteFormat", o, n);
				ValidateFormats();
				OnPropertyChanged("AvailableSecondFormats");
				OnPropertyChanged("AvailableMillisecondFormats");
				OnPropertyChanged("SecondsAvailable");
				OnDataModified();
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public TimerFormatStyle SecondFormat
	{
		get
		{
			return _secondFormat;
		}
		set
		{
			SetValue("SecondFormat", ref _secondFormat, value, delegate(TimerFormatStyle o, TimerFormatStyle n)
			{
				UndoStack?.BeginCommit(UndoActionTypes.TimeFormat.ToAction());
				UndoStack?.Commit(this, "MinuteFormat", o, n);
				ValidateFormats();
				OnPropertyChanged("AvailableMillisecondFormats");
				OnDataModified();
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public TimerFormatStyle MillisecondFormat
	{
		get
		{
			return _millisecondFormat;
		}
		set
		{
			SetValue("MillisecondFormat", ref _millisecondFormat, value, delegate(TimerFormatStyle o, TimerFormatStyle n)
			{
				UndoStack?.BeginCommit(UndoActionTypes.TimeFormat.ToAction());
				UndoStack?.Commit(this, "MinuteFormat", o, n);
				ValidateFormats();
				OnDataModified();
				UndoStack?.EndCommit(null, null, autoFinalize: true);
			});
		}
	}

	public bool UseWallClockFormat
	{
		get
		{
			return _useWallClockFormat;
		}
		set
		{
			SetValue("UseWallClockFormat", ref _useWallClockFormat, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.UseWallClockFormat), this, "UseWallClockFormat", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public bool Use24HourFormat
	{
		get
		{
			return _use24HourFormat;
		}
		set
		{
			SetValue("Use24HourFormat", ref _use24HourFormat, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Use24HourFormat), this, "Use24HourFormat", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public IEnumerable<TimerFormatStyle> AvailableHourFormats => this.GetAvailableHourFormats();

	public IEnumerable<TimerFormatStyle> AvailableMinuteFormats => this.GetAvailableMinuteFormats();

	public IEnumerable<TimerFormatStyle> AvailableSecondFormats => this.GetAvailableSecondFormats();

	public IEnumerable<TimerFormatStyle> AvailableMillisecondFormats => this.GetAvailableMillisecondFormats();

	public bool SecondsAvailable
	{
		get
		{
			if (MinuteFormat == TimerFormatStyle.None)
			{
				if (HourFormat == TimerFormatStyle.None)
				{
					return MinuteFormat == TimerFormatStyle.None;
				}
				return false;
			}
			return true;
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<TimerFormatData, ITimer.Types.IFormat> CreateBinder(TimerFormatData? left, ITimer.Types.IFormat? right)
	{
		ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder = new ObjectBinder<TimerFormatData, ITimer.Types.IFormat>(left, right);
		objectBinder.Bind((TimerFormatData l) => l.WhenPropertyChanges("HourFormat"), (ITimer.Types.IFormat r) => r.Hour.WhenValueChanges, delegate(TimerFormatData l, ITimer.Types.IFormat r)
		{
			r.Hour.Set(l.HourFormat.GetEntityFormatStyle());
		}, delegate(ITimer.Types.IFormat r, TimerFormatData l)
		{
			l.HourFormat = r.Hour.Value.GetFormatStyle();
		}).Bind((TimerFormatData l) => l.WhenPropertyChanges("MinuteFormat"), (ITimer.Types.IFormat r) => r.Minute.WhenValueChanges, delegate(TimerFormatData l, ITimer.Types.IFormat r)
		{
			r.Minute.Set(l.MinuteFormat.GetEntityFormatStyle());
		}, delegate(ITimer.Types.IFormat r, TimerFormatData l)
		{
			l.MinuteFormat = r.Minute.Value.GetFormatStyle();
		}).Bind((TimerFormatData l) => l.WhenPropertyChanges("SecondFormat"), (ITimer.Types.IFormat r) => r.Second.WhenValueChanges, delegate(TimerFormatData l, ITimer.Types.IFormat r)
		{
			r.Second.Set(l.SecondFormat.GetEntityFormatStyle());
		}, delegate(ITimer.Types.IFormat r, TimerFormatData l)
		{
			l.SecondFormat = r.Second.Value.GetFormatStyle();
		})
			.Bind((TimerFormatData l) => l.WhenPropertyChanges("MillisecondFormat"), (ITimer.Types.IFormat r) => r.Millisecond.WhenValueChanges, delegate(TimerFormatData l, ITimer.Types.IFormat r)
			{
				r.Millisecond.Set(l.MillisecondFormat.GetEntityFormatStyle());
			}, delegate(ITimer.Types.IFormat r, TimerFormatData l)
			{
				l.MillisecondFormat = r.Millisecond.Value.GetFormatStyle();
			})
			.Bind((TimerFormatData l) => l.WhenPropertyChanges("Use24HourFormat"), (ITimer.Types.IFormat r) => r.Is24HourTime.WhenValueChanges, delegate(TimerFormatData l, ITimer.Types.IFormat r)
			{
				r.Is24HourTime.Set(l.Use24HourFormat);
			}, delegate(ITimer.Types.IFormat r, TimerFormatData l)
			{
				l.Use24HourFormat = r.Is24HourTime.Value;
			})
			.Bind((TimerFormatData l) => l.WhenPropertyChanges("UseWallClockFormat"), (ITimer.Types.IFormat r) => r.IsWallClockTime.WhenValueChanges, delegate(TimerFormatData l, ITimer.Types.IFormat r)
			{
				r.IsWallClockTime.Set(l.UseWallClockFormat);
			}, delegate(ITimer.Types.IFormat r, TimerFormatData l)
			{
				l.UseWallClockFormat = r.IsWallClockTime.Value;
			});
		return objectBinder;
	}

	public TimerFormatData()
		: this(TimerFormatStyle.Long, TimerFormatStyle.Long, TimerFormatStyle.Long, TimerFormatStyle.None)
	{
	}

	public TimerFormatData(TimerFormatStyle hourFormat, TimerFormatStyle minuteFormat, TimerFormatStyle secondFormat, TimerFormatStyle millisecondFormat)
	{
		_hourFormat = hourFormat;
		_minuteFormat = minuteFormat;
		_secondFormat = secondFormat;
		_millisecondFormat = millisecondFormat;
		ValidateFormats();
	}

	public string FormatTime(TimeSlice time)
	{
		bool num = time < TimeSlice.Zero;
		if (num)
		{
			time = ((MillisecondFormat != 0) ? time.RoundDown(TimeComponents.Milliseconds).Abs() : ((SecondFormat != 0) ? time.RoundDown(TimeComponents.Seconds).Abs() : ((MinuteFormat == TimerFormatStyle.None) ? time.RoundDown(TimeComponents.Hours).Abs() : time.RoundDown(TimeComponents.Minutes).Abs())));
		}
		string text;
		if (HourFormat != 0)
		{
			text = GenerateTimeString(FormatComponent(HourFormat, (long)time.TotalHours, isSignifigantComponent: true), FormatComponent(MinuteFormat, time.Minutes, time.TotalHours < 1.0), FormatComponent(SecondFormat, time.Seconds, time.TotalMinutes < 1.0), FormatComponent(MillisecondFormat, time.Milliseconds, isSignifigantComponent: true, truncate: true));
		}
		else if (MinuteFormat != 0)
		{
			text = GenerateTimeString(string.Empty, FormatComponent(MinuteFormat, (long)time.TotalMinutes, isSignifigantComponent: true), FormatComponent(SecondFormat, time.Seconds, time.TotalMinutes < 1.0), FormatComponent(MillisecondFormat, time.Milliseconds, isSignifigantComponent: true, truncate: true));
		}
		else
		{
			if (SecondFormat == TimerFormatStyle.None)
			{
				throw new NotSupportedException();
			}
			text = GenerateTimeString(string.Empty, string.Empty, FormatComponent(SecondFormat, (long)time.TotalSeconds, isSignifigantComponent: true), FormatComponent(MillisecondFormat, time.Milliseconds, isSignifigantComponent: true, truncate: true));
		}
		return (num ? "-" : string.Empty) + text;
	}

	public string FormatTime(TimeSlice? time, bool returnEmptyWhenNull = false)
	{
		bool hasValue = time.HasValue;
		string text = FormatTime(time ?? TimeSlice.Zero);
		if (!hasValue)
		{
			text = (returnEmptyWhenNull ? string.Empty : text.Replace("0", "–"));
		}
		return text;
	}

	public string GetSampleText()
	{
		return FormatTime(SampleTime);
	}

	private static string GenerateTimeString(string hour, string minute, string second, string millisecond)
	{
		string text = string.Join(":", new string[3] { hour, minute, second }.Where(isValid));
		if (!string.IsNullOrEmpty(millisecond))
		{
			text = string.Join(".", new string[2] { text, millisecond }.Where(isValid));
		}
		return text;
		static bool isValid(string s)
		{
			return !string.IsNullOrEmpty(s);
		}
	}

	private static string FormatComponent(TimerFormatStyle style, long componentValue, bool isSignifigantComponent, bool truncate = false)
	{
		string result = $"{(truncate ? (componentValue / 100) : componentValue):D1}";
		string result2 = $"{(truncate ? (componentValue / 10) : componentValue):D2}";
		switch (style)
		{
		case TimerFormatStyle.None:
			return string.Empty;
		case TimerFormatStyle.Short:
			if (!isSignifigantComponent)
			{
				return result2;
			}
			return result;
		case TimerFormatStyle.Long:
			return result2;
		case TimerFormatStyle.ShortTruncated:
			if (isSignifigantComponent)
			{
				if (componentValue != 0L)
				{
					return result;
				}
				return string.Empty;
			}
			return result2;
		case TimerFormatStyle.LongTruncated:
			if (!(componentValue == 0 && isSignifigantComponent))
			{
				return result2;
			}
			return string.Empty;
		default:
			throw new NotSupportedException();
		}
	}

	public TimerFormatData Clone()
	{
		return new TimerFormatData(HourFormat, MinuteFormat, SecondFormat, MillisecondFormat);
	}

	protected internal Pro.SerializationInterop.RVProtoData.Timer.Types.Format Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Timer.Types.Format
		{
			Hour = HourFormat.GetProtoFormatStyle(),
			Minute = MinuteFormat.GetProtoFormatStyle(),
			Second = SecondFormat.GetProtoFormatStyle(),
			Millisecond = MillisecondFormat.GetProtoFormatStyle(),
			IsWallClockTime = UseWallClockFormat,
			Is24HourTime = Use24HourFormat
		};
	}

	protected internal void Deserialize(Pro.SerializationInterop.RVProtoData.Timer.Types.Format data)
	{
		if (data != null)
		{
			_hourFormat = data.Hour.GetFormatStyle();
			_minuteFormat = data.Minute.GetFormatStyle();
			_secondFormat = data.Second.GetFormatStyle();
			_millisecondFormat = data.Millisecond.GetFormatStyle();
			_useWallClockFormat = data.IsWallClockTime;
			_use24HourFormat = data.Is24HourTime;
			ValidateFormats();
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private void ValidateFormats()
	{
		if (!_validationInProgress)
		{
			_validationInProgress = true;
			EnsureValidFormats();
			ApplyFormatRules();
			_validationInProgress = false;
		}
	}

	private void EnsureValidFormats()
	{
		if (!AvailableMinuteFormats.Contains(MinuteFormat))
		{
			MinuteFormat = AvailableMinuteFormats.FirstOrDefault();
		}
		if (!AvailableSecondFormats.Contains(SecondFormat))
		{
			SecondFormat = AvailableSecondFormats.FirstOrDefault();
		}
		if (!AvailableMillisecondFormats.Contains(MillisecondFormat))
		{
			MillisecondFormat = AvailableMillisecondFormats.FirstOrDefault();
		}
	}

	private void ApplyFormatRules()
	{
		if (HourFormat != 0 && MinuteFormat == TimerFormatStyle.None)
		{
			SecondFormat = TimerFormatStyle.None;
			MillisecondFormat = TimerFormatStyle.None;
		}
		else if (HourFormat != 0 && MinuteFormat != 0 && SecondFormat == TimerFormatStyle.None)
		{
			MillisecondFormat = TimerFormatStyle.None;
		}
		else if (HourFormat == TimerFormatStyle.None && MinuteFormat == TimerFormatStyle.None && SecondFormat == TimerFormatStyle.None)
		{
			SecondFormat = TimerFormatStyle.Long;
		}
	}
}
