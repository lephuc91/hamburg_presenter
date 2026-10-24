using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Timer : IMessage<API_v1_Timer>, IMessage, IEquatable<API_v1_Timer>, IDeepCloneable<API_v1_Timer>
{
	public enum TimerConfigurationOneofCase
	{
		None = 0,
		Countdown = 3,
		CountDownToTime = 4,
		Elapsed = 5
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum API_v1_TimePeriod
		{
			[OriginalName("am")]
			Am,
			[OriginalName("pm")]
			Pm,
			[OriginalName("is_24_hour")]
			Is24Hour
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class API_v1_Timer_Countdown : IMessage<API_v1_Timer_Countdown>, IMessage, IEquatable<API_v1_Timer_Countdown>, IDeepCloneable<API_v1_Timer_Countdown>
		{
			private static readonly MessageParser<API_v1_Timer_Countdown> _parser = new MessageParser<API_v1_Timer_Countdown>(() => new API_v1_Timer_Countdown());

			private UnknownFieldSet _unknownFields;

			public const int DurationFieldNumber = 1;

			private int duration_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<API_v1_Timer_Countdown> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Duration
			{
				get
				{
					return duration_;
				}
				set
				{
					duration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Countdown()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Countdown(API_v1_Timer_Countdown other)
				: this()
			{
				duration_ = other.duration_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Countdown Clone()
			{
				return new API_v1_Timer_Countdown(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as API_v1_Timer_Countdown);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(API_v1_Timer_Countdown other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Duration != other.Duration)
				{
					return false;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (Duration != 0)
				{
					num ^= Duration.GetHashCode();
				}
				if (_unknownFields != null)
				{
					num ^= _unknownFields.GetHashCode();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override string ToString()
			{
				return JsonFormatter.ToDiagnosticString(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void WriteTo(CodedOutputStream output)
			{
				if (Duration != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(Duration);
				}
				if (_unknownFields != null)
				{
					_unknownFields.WriteTo(output);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CalculateSize()
			{
				int num = 0;
				if (Duration != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Duration);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(API_v1_Timer_Countdown other)
			{
				if (other != null)
				{
					if (other.Duration != 0)
					{
						Duration = other.Duration;
					}
					_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CodedInputStream input)
			{
				uint num;
				while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
				{
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Duration = input.ReadInt32();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class API_v1_Timer_CountdownToTime : IMessage<API_v1_Timer_CountdownToTime>, IMessage, IEquatable<API_v1_Timer_CountdownToTime>, IDeepCloneable<API_v1_Timer_CountdownToTime>
		{
			private static readonly MessageParser<API_v1_Timer_CountdownToTime> _parser = new MessageParser<API_v1_Timer_CountdownToTime>(() => new API_v1_Timer_CountdownToTime());

			private UnknownFieldSet _unknownFields;

			public const int TimeOfDayFieldNumber = 1;

			private int timeOfDay_;

			public const int PeriodFieldNumber = 2;

			private API_v1_TimePeriod period_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<API_v1_Timer_CountdownToTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int TimeOfDay
			{
				get
				{
					return timeOfDay_;
				}
				set
				{
					timeOfDay_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_TimePeriod Period
			{
				get
				{
					return period_;
				}
				set
				{
					period_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_CountdownToTime()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_CountdownToTime(API_v1_Timer_CountdownToTime other)
				: this()
			{
				timeOfDay_ = other.timeOfDay_;
				period_ = other.period_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_CountdownToTime Clone()
			{
				return new API_v1_Timer_CountdownToTime(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as API_v1_Timer_CountdownToTime);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(API_v1_Timer_CountdownToTime other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (TimeOfDay != other.TimeOfDay)
				{
					return false;
				}
				if (Period != other.Period)
				{
					return false;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (TimeOfDay != 0)
				{
					num ^= TimeOfDay.GetHashCode();
				}
				if (Period != 0)
				{
					num ^= Period.GetHashCode();
				}
				if (_unknownFields != null)
				{
					num ^= _unknownFields.GetHashCode();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override string ToString()
			{
				return JsonFormatter.ToDiagnosticString(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void WriteTo(CodedOutputStream output)
			{
				if (TimeOfDay != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(TimeOfDay);
				}
				if (Period != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Period);
				}
				if (_unknownFields != null)
				{
					_unknownFields.WriteTo(output);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CalculateSize()
			{
				int num = 0;
				if (TimeOfDay != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(TimeOfDay);
				}
				if (Period != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Period);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(API_v1_Timer_CountdownToTime other)
			{
				if (other != null)
				{
					if (other.TimeOfDay != 0)
					{
						TimeOfDay = other.TimeOfDay;
					}
					if (other.Period != 0)
					{
						Period = other.Period;
					}
					_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CodedInputStream input)
			{
				uint num;
				while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
				{
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						TimeOfDay = input.ReadInt32();
						break;
					case 16u:
						Period = (API_v1_TimePeriod)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class API_v1_Timer_Elapsed : IMessage<API_v1_Timer_Elapsed>, IMessage, IEquatable<API_v1_Timer_Elapsed>, IDeepCloneable<API_v1_Timer_Elapsed>
		{
			private static readonly MessageParser<API_v1_Timer_Elapsed> _parser = new MessageParser<API_v1_Timer_Elapsed>(() => new API_v1_Timer_Elapsed());

			private UnknownFieldSet _unknownFields;

			public const int StartTimeFieldNumber = 1;

			private int startTime_;

			public const int EndTimeFieldNumber = 2;

			private int endTime_;

			public const int HasEndTimeFieldNumber = 3;

			private bool hasEndTime_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<API_v1_Timer_Elapsed> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int StartTime
			{
				get
				{
					return startTime_;
				}
				set
				{
					startTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int EndTime
			{
				get
				{
					return endTime_;
				}
				set
				{
					endTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasEndTime
			{
				get
				{
					return hasEndTime_;
				}
				set
				{
					hasEndTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Elapsed()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Elapsed(API_v1_Timer_Elapsed other)
				: this()
			{
				startTime_ = other.startTime_;
				endTime_ = other.endTime_;
				hasEndTime_ = other.hasEndTime_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Elapsed Clone()
			{
				return new API_v1_Timer_Elapsed(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as API_v1_Timer_Elapsed);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(API_v1_Timer_Elapsed other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (StartTime != other.StartTime)
				{
					return false;
				}
				if (EndTime != other.EndTime)
				{
					return false;
				}
				if (HasEndTime != other.HasEndTime)
				{
					return false;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (StartTime != 0)
				{
					num ^= StartTime.GetHashCode();
				}
				if (EndTime != 0)
				{
					num ^= EndTime.GetHashCode();
				}
				if (HasEndTime)
				{
					num ^= HasEndTime.GetHashCode();
				}
				if (_unknownFields != null)
				{
					num ^= _unknownFields.GetHashCode();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override string ToString()
			{
				return JsonFormatter.ToDiagnosticString(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void WriteTo(CodedOutputStream output)
			{
				if (StartTime != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(StartTime);
				}
				if (EndTime != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(EndTime);
				}
				if (HasEndTime)
				{
					output.WriteRawTag(24);
					output.WriteBool(HasEndTime);
				}
				if (_unknownFields != null)
				{
					_unknownFields.WriteTo(output);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CalculateSize()
			{
				int num = 0;
				if (StartTime != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(StartTime);
				}
				if (EndTime != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(EndTime);
				}
				if (HasEndTime)
				{
					num += 2;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(API_v1_Timer_Elapsed other)
			{
				if (other != null)
				{
					if (other.StartTime != 0)
					{
						StartTime = other.StartTime;
					}
					if (other.EndTime != 0)
					{
						EndTime = other.EndTime;
					}
					if (other.HasEndTime)
					{
						HasEndTime = other.HasEndTime;
					}
					_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CodedInputStream input)
			{
				uint num;
				while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
				{
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						StartTime = input.ReadInt32();
						break;
					case 16u:
						EndTime = input.ReadInt32();
						break;
					case 24u:
						HasEndTime = input.ReadBool();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Timer> _parser = new MessageParser<API_v1_Timer>(() => new API_v1_Timer());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int AllowsOverrunFieldNumber = 2;

	private bool allowsOverrun_;

	public const int CountdownFieldNumber = 3;

	public const int CountDownToTimeFieldNumber = 4;

	public const int ElapsedFieldNumber = 5;

	private object timerConfiguration_;

	private TimerConfigurationOneofCase timerConfigurationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Timer> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TimerReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool AllowsOverrun
	{
		get
		{
			return allowsOverrun_;
		}
		set
		{
			allowsOverrun_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_Timer_Countdown Countdown
	{
		get
		{
			if (timerConfigurationCase_ != TimerConfigurationOneofCase.Countdown)
			{
				return null;
			}
			return (Types.API_v1_Timer_Countdown)timerConfiguration_;
		}
		set
		{
			timerConfiguration_ = value;
			timerConfigurationCase_ = ((value != null) ? TimerConfigurationOneofCase.Countdown : TimerConfigurationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_Timer_CountdownToTime CountDownToTime
	{
		get
		{
			if (timerConfigurationCase_ != TimerConfigurationOneofCase.CountDownToTime)
			{
				return null;
			}
			return (Types.API_v1_Timer_CountdownToTime)timerConfiguration_;
		}
		set
		{
			timerConfiguration_ = value;
			timerConfigurationCase_ = ((value != null) ? TimerConfigurationOneofCase.CountDownToTime : TimerConfigurationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.API_v1_Timer_Elapsed Elapsed
	{
		get
		{
			if (timerConfigurationCase_ != TimerConfigurationOneofCase.Elapsed)
			{
				return null;
			}
			return (Types.API_v1_Timer_Elapsed)timerConfiguration_;
		}
		set
		{
			timerConfiguration_ = value;
			timerConfigurationCase_ = ((value != null) ? TimerConfigurationOneofCase.Elapsed : TimerConfigurationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerConfigurationOneofCase TimerConfigurationCase => timerConfigurationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer(API_v1_Timer other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		allowsOverrun_ = other.allowsOverrun_;
		switch (other.TimerConfigurationCase)
		{
		case TimerConfigurationOneofCase.Countdown:
			Countdown = other.Countdown.Clone();
			break;
		case TimerConfigurationOneofCase.CountDownToTime:
			CountDownToTime = other.CountDownToTime.Clone();
			break;
		case TimerConfigurationOneofCase.Elapsed:
			Elapsed = other.Elapsed.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer Clone()
	{
		return new API_v1_Timer(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearTimerConfiguration()
	{
		timerConfigurationCase_ = TimerConfigurationOneofCase.None;
		timerConfiguration_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Timer);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Timer other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Id, other.Id))
		{
			return false;
		}
		if (AllowsOverrun != other.AllowsOverrun)
		{
			return false;
		}
		if (!object.Equals(Countdown, other.Countdown))
		{
			return false;
		}
		if (!object.Equals(CountDownToTime, other.CountDownToTime))
		{
			return false;
		}
		if (!object.Equals(Elapsed, other.Elapsed))
		{
			return false;
		}
		if (TimerConfigurationCase != other.TimerConfigurationCase)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (AllowsOverrun)
		{
			num ^= AllowsOverrun.GetHashCode();
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
		{
			num ^= Countdown.GetHashCode();
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
		{
			num ^= CountDownToTime.GetHashCode();
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
		{
			num ^= Elapsed.GetHashCode();
		}
		num ^= (int)timerConfigurationCase_;
		if (_unknownFields != null)
		{
			num ^= _unknownFields.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (AllowsOverrun)
		{
			output.WriteRawTag(16);
			output.WriteBool(AllowsOverrun);
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Countdown);
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
		{
			output.WriteRawTag(34);
			output.WriteMessage(CountDownToTime);
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Elapsed);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int num = 0;
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (AllowsOverrun)
		{
			num += 2;
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Countdown);
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CountDownToTime);
		}
		if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Elapsed);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Timer other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new API_v1_Identifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.AllowsOverrun)
		{
			AllowsOverrun = other.AllowsOverrun;
		}
		switch (other.TimerConfigurationCase)
		{
		case TimerConfigurationOneofCase.Countdown:
			if (Countdown == null)
			{
				Countdown = new Types.API_v1_Timer_Countdown();
			}
			Countdown.MergeFrom(other.Countdown);
			break;
		case TimerConfigurationOneofCase.CountDownToTime:
			if (CountDownToTime == null)
			{
				CountDownToTime = new Types.API_v1_Timer_CountdownToTime();
			}
			CountDownToTime.MergeFrom(other.CountDownToTime);
			break;
		case TimerConfigurationOneofCase.Elapsed:
			if (Elapsed == null)
			{
				Elapsed = new Types.API_v1_Timer_Elapsed();
			}
			Elapsed.MergeFrom(other.Elapsed);
			break;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
		{
			switch (num)
			{
			default:
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				break;
			case 10u:
				if (id_ == null)
				{
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 16u:
				AllowsOverrun = input.ReadBool();
				break;
			case 26u:
			{
				Types.API_v1_Timer_Countdown aPI_v1_Timer_Countdown = new Types.API_v1_Timer_Countdown();
				if (timerConfigurationCase_ == TimerConfigurationOneofCase.Countdown)
				{
					aPI_v1_Timer_Countdown.MergeFrom(Countdown);
				}
				input.ReadMessage(aPI_v1_Timer_Countdown);
				Countdown = aPI_v1_Timer_Countdown;
				break;
			}
			case 34u:
			{
				Types.API_v1_Timer_CountdownToTime aPI_v1_Timer_CountdownToTime = new Types.API_v1_Timer_CountdownToTime();
				if (timerConfigurationCase_ == TimerConfigurationOneofCase.CountDownToTime)
				{
					aPI_v1_Timer_CountdownToTime.MergeFrom(CountDownToTime);
				}
				input.ReadMessage(aPI_v1_Timer_CountdownToTime);
				CountDownToTime = aPI_v1_Timer_CountdownToTime;
				break;
			}
			case 42u:
			{
				Types.API_v1_Timer_Elapsed aPI_v1_Timer_Elapsed = new Types.API_v1_Timer_Elapsed();
				if (timerConfigurationCase_ == TimerConfigurationOneofCase.Elapsed)
				{
					aPI_v1_Timer_Elapsed.MergeFrom(Elapsed);
				}
				input.ReadMessage(aPI_v1_Timer_Elapsed);
				Elapsed = aPI_v1_Timer_Elapsed;
				break;
			}
			}
		}
	}
}
