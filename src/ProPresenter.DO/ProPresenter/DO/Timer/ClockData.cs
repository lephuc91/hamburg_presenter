using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Timer;

public class ClockData : NotifyPropertyChangedBase, IEquatable<ClockData>
{
	public static readonly DateTime SampleDate = DateTime.Today.AddHours(13.0).AddMinutes(23.0).AddSeconds(45.0)
		.AddMilliseconds(678.0);

	private FormatLength _dateFormatLength;

	private FormatLength _timeFormatLength = FormatLength.Short;

	private bool _use24HourFormat;

	public UndoStack? UndoStack { get; set; }

	public FormatLength DateFormatLength
	{
		get
		{
			return _dateFormatLength;
		}
		set
		{
			SetValue("DateFormatLength", ref _dateFormatLength, value, delegate(FormatLength o, FormatLength n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.DateFormat), this, "DateFormatLength", o, n, null, null, autoFinalize: true);
				this.DataModified?.Invoke();
			});
		}
	}

	public FormatLength TimeFormatLength
	{
		get
		{
			return _timeFormatLength;
		}
		set
		{
			SetValue("TimeFormatLength", ref _timeFormatLength, value, delegate(FormatLength o, FormatLength n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TimeFormat), this, "TimeFormatLength", o, n, null, null, autoFinalize: true);
				this.DataModified?.Invoke();
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
				this.DataModified?.Invoke();
			});
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<ClockData, IClock.Types.IFormat> CreateBinder(ClockData left, IClock.Types.IFormat right)
	{
		ObjectBinder<ClockData, IClock.Types.IFormat> objectBinder = new ObjectBinder<ClockData, IClock.Types.IFormat>(left, right);
		objectBinder.Bind((ClockData l) => l.WhenPropertyChanges("DateFormatLength"), (IClock.Types.IFormat r) => r.DateType.WhenValueChanges, delegate(ClockData l, IClock.Types.IFormat r)
		{
			r.DateType.Set(l.DateFormatLength.ToEntityFormatterStyle());
		}, delegate(IClock.Types.IFormat r, ClockData l)
		{
			l.DateFormatLength = r.DateType.Value.ToFormatLength();
		}).Bind((ClockData l) => l.WhenPropertyChanges("TimeFormatLength"), (IClock.Types.IFormat r) => r.TimeFormat.WhenValueChanges, delegate(ClockData l, IClock.Types.IFormat r)
		{
			r.TimeFormat.Set(l.TimeFormatLength.ToEntityFormatterStyle());
		}, delegate(IClock.Types.IFormat r, ClockData l)
		{
			l.TimeFormatLength = r.TimeFormat.Value.ToFormatLength();
		}).Bind((ClockData l) => l.WhenPropertyChanges("Use24HourFormat"), (IClock.Types.IFormat r) => r.MilitaryTimeEnabled.WhenValueChanges, delegate(ClockData l, IClock.Types.IFormat r)
		{
			r.MilitaryTimeEnabled.Set(l.Use24HourFormat);
		}, delegate(IClock.Types.IFormat r, ClockData l)
		{
			l.Use24HourFormat = r.MilitaryTimeEnabled.Value;
		});
		return objectBinder;
	}

	public ClockData()
	{
		DateFormatLength = FormatLength.None;
		TimeFormatLength = FormatLength.Short;
		Use24HourFormat = false;
	}

	protected internal Clock.Types.Format Serialize()
	{
		return new Clock.Types.Format
		{
			DateType = DateFormatLength.ToProtoFormatterStyle(),
			TimeFormat = TimeFormatLength.ToProtoFormatterStyle(),
			MilitaryTimeEnabled = Use24HourFormat
		};
	}

	protected internal void Deserialize(Clock.Types.Format? clock)
	{
		if (clock != null)
		{
			DateFormatLength = clock.DateType.ToFormatLength();
			TimeFormatLength = clock.TimeFormat.ToFormatLength();
			Use24HourFormat = clock.MilitaryTimeEnabled;
		}
	}

	public string FormatDateTime(DateTime time)
	{
		return DateTimeFormatter.FormatDateTime(time, DateFormatLength, TimeFormatLength, Use24HourFormat);
	}

	public string GetSampleText()
	{
		return FormatDateTime(SampleDate);
	}

	public bool Equals(ClockData? other)
	{
		if ((object)other != null && DateFormatLength == other.DateFormatLength && TimeFormatLength == other.TimeFormatLength)
		{
			return Use24HourFormat == other.Use24HourFormat;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is ClockData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(DateFormatLength, TimeFormatLength, Use24HourFormat);
	}

	public static bool operator ==(ClockData? lhs, ClockData? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(ClockData? lhs, ClockData? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
