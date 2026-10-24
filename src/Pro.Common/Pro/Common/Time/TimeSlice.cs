using System;
using Pro.Common.Mathematics;

namespace Pro.Common.Time;

public struct TimeSlice : IEquatable<TimeSlice>, IComparable<TimeSlice>, IComparable
{
	public static TimeSlice Zero = new TimeSlice(0L);

	public static TimeSlice MaxValue = new TimeSlice(long.MaxValue);

	public static TimeSlice MinValue = new TimeSlice(long.MinValue);

	private readonly long _ticks;

	public double TotalSeconds => (double)_ticks / Clock.Frequency;

	public double TotalMilliseconds => TotalSeconds * 1000.0;

	public double TotalMinutes => TotalSeconds / 60.0;

	public double TotalHours => TotalMinutes / 60.0;

	public double TotalDays => TotalHours / 24.0;

	public long Milliseconds => (long)Math.Round(TotalMilliseconds % 1000.0);

	public long Seconds => (long)(TotalSeconds % 60.0);

	public long Minutes => (long)(TotalMinutes % 60.0);

	public long Hours => (long)(TotalHours % 24.0);

	public long Days => (long)TotalDays;

	public override string ToString()
	{
		return $"{Hours:00}:{Minutes:00}:{Seconds:00}:{Milliseconds:00}";
	}

	internal TimeSlice(long ticks)
	{
		_ticks = ticks;
	}

	public static TimeSlice FromComponents(int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0)
	{
		return FromMilliseconds(((hours * 60 + minutes) * 60 + seconds) * 1000 + milliseconds);
	}

	public static TimeSlice FromTimeSpan(TimeSpan timeSpan)
	{
		return FromMilliseconds(timeSpan.TotalMilliseconds);
	}

	public static TimeSlice FromSeconds(double seconds)
	{
		if (seconds >= 9.223372036854776E+18 / Clock.Frequency)
		{
			return MaxValue;
		}
		return new TimeSlice((long)(seconds * Clock.Frequency));
	}

	public static TimeSlice FromMilliseconds(double milliseconds)
	{
		return FromSeconds(milliseconds / 1000.0);
	}

	public static TimeSlice FromMinutes(double minutes)
	{
		return FromSeconds(minutes * 60.0);
	}

	public static TimeSlice FromHours(double hours)
	{
		return FromMinutes(hours * 60.0);
	}

	public static TimeSlice FromDays(double days)
	{
		return FromHours(days * 24.0);
	}

	public override bool Equals(object? obj)
	{
		if (obj is TimeSlice other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TimeSlice other)
	{
		return _ticks == other._ticks;
	}

	public override int GetHashCode()
	{
		return _ticks.GetHashCode();
	}

	public int CompareTo(TimeSlice other)
	{
		return _ticks.CompareTo(other._ticks);
	}

	public int CompareTo(object? other)
	{
		if (other is TimeSlice other2)
		{
			return CompareTo(other2);
		}
		throw new NotSupportedException("Must compare of type Time");
	}

	public TimeSlice Abs()
	{
		return new TimeSlice(_ticks.Abs());
	}

	public TimeSlice RoundDown(TimeComponents components)
	{
		if (components.HasFlag(TimeComponents.Milliseconds))
		{
			return FromMilliseconds(Math.Floor(TotalMilliseconds));
		}
		if (components.HasFlag(TimeComponents.Seconds))
		{
			return FromSeconds(Math.Floor(TotalSeconds));
		}
		if (components.HasFlag(TimeComponents.Minutes))
		{
			return FromMinutes(Math.Floor(TotalMinutes));
		}
		if (components.HasFlag(TimeComponents.Hours))
		{
			return FromHours(Math.Floor(TotalHours));
		}
		return this;
	}

	public static bool operator ==(TimeSlice lhs, TimeSlice rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(TimeSlice lhs, TimeSlice rhs)
	{
		return !lhs.Equals(rhs);
	}

	public static bool operator <(TimeSlice lhs, TimeSlice rhs)
	{
		return lhs._ticks < rhs._ticks;
	}

	public static bool operator <=(TimeSlice lhs, TimeSlice rhs)
	{
		return lhs._ticks <= rhs._ticks;
	}

	public static bool operator >(TimeSlice lhs, TimeSlice rhs)
	{
		return lhs._ticks > rhs._ticks;
	}

	public static bool operator >=(TimeSlice lhs, TimeSlice rhs)
	{
		return lhs._ticks >= rhs._ticks;
	}

	public static TimeSlice operator +(TimeSlice lhs, TimeSlice rhs)
	{
		return new TimeSlice(lhs._ticks + rhs._ticks);
	}

	public static TimeSlice operator -(TimeSlice lhs, TimeSlice rhs)
	{
		return new TimeSlice(lhs._ticks - rhs._ticks);
	}

	public static TimeSlice operator *(TimeSlice lhs, double rhs)
	{
		return new TimeSlice((long)((double)lhs._ticks * rhs));
	}

	public static TimeSlice operator /(TimeSlice lhs, double rhs)
	{
		if (rhs == 0.0)
		{
			throw new DivideByZeroException();
		}
		return new TimeSlice((long)((double)lhs._ticks / rhs));
	}

	public static double operator /(TimeSlice lhs, TimeSlice rhs)
	{
		return lhs.TotalSeconds / rhs.TotalSeconds;
	}

	public static TimeSlice operator %(TimeSlice lhs, TimeSlice rhs)
	{
		return new TimeSlice(lhs._ticks % rhs._ticks);
	}

	public static implicit operator TimeSpan(TimeSlice t)
	{
		return TimeSpan.FromSeconds(t.TotalSeconds);
	}

	public static explicit operator TimeSlice(TimeSpan t)
	{
		return FromSeconds(t.TotalSeconds);
	}
}
