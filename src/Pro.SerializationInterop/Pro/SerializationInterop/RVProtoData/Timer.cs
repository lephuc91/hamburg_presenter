using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Timer : IMessage<Timer>, IMessage, IEquatable<Timer>, IDeepCloneable<Timer>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Format : IMessage<Format>, IMessage, IEquatable<Format>, IDeepCloneable<Format>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Style
				{
					[OriginalName("STYLE_NONE")]
					None,
					[OriginalName("STYLE_SHORT")]
					Short,
					[OriginalName("STYLE_LONG")]
					Long,
					[OriginalName("STYLE_REMOVE_SHORT")]
					RemoveShort,
					[OriginalName("STYLE_REMOVE_LONG")]
					RemoveLong
				}
			}

			private static readonly MessageParser<Format> _parser = new MessageParser<Format>(() => new Format());

			private UnknownFieldSet _unknownFields;

			public const int HourFieldNumber = 1;

			private Types.Style hour_;

			public const int MinuteFieldNumber = 2;

			private Types.Style minute_;

			public const int SecondFieldNumber = 3;

			private Types.Style second_;

			public const int MillisecondFieldNumber = 4;

			private Types.Style millisecond_;

			public const int IsWallClockTimeFieldNumber = 5;

			private bool isWallClockTime_;

			public const int Is24HourTimeFieldNumber = 6;

			private bool is24HourTime_;

			public const int ShowMillisecondsUnderMinuteOnlyFieldNumber = 7;

			private bool showMillisecondsUnderMinuteOnly_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Format> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Timer.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Style Hour
			{
				get
				{
					return hour_;
				}
				set
				{
					hour_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Style Minute
			{
				get
				{
					return minute_;
				}
				set
				{
					minute_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Style Second
			{
				get
				{
					return second_;
				}
				set
				{
					second_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Style Millisecond
			{
				get
				{
					return millisecond_;
				}
				set
				{
					millisecond_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsWallClockTime
			{
				get
				{
					return isWallClockTime_;
				}
				set
				{
					isWallClockTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Is24HourTime
			{
				get
				{
					return is24HourTime_;
				}
				set
				{
					is24HourTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ShowMillisecondsUnderMinuteOnly
			{
				get
				{
					return showMillisecondsUnderMinuteOnly_;
				}
				set
				{
					showMillisecondsUnderMinuteOnly_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Format()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Format(Format other)
				: this()
			{
				hour_ = other.hour_;
				minute_ = other.minute_;
				second_ = other.second_;
				millisecond_ = other.millisecond_;
				isWallClockTime_ = other.isWallClockTime_;
				is24HourTime_ = other.is24HourTime_;
				showMillisecondsUnderMinuteOnly_ = other.showMillisecondsUnderMinuteOnly_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Format Clone()
			{
				return new Format(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Format);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Format other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Hour != other.Hour)
				{
					return false;
				}
				if (Minute != other.Minute)
				{
					return false;
				}
				if (Second != other.Second)
				{
					return false;
				}
				if (Millisecond != other.Millisecond)
				{
					return false;
				}
				if (IsWallClockTime != other.IsWallClockTime)
				{
					return false;
				}
				if (Is24HourTime != other.Is24HourTime)
				{
					return false;
				}
				if (ShowMillisecondsUnderMinuteOnly != other.ShowMillisecondsUnderMinuteOnly)
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
				if (Hour != 0)
				{
					num ^= Hour.GetHashCode();
				}
				if (Minute != 0)
				{
					num ^= Minute.GetHashCode();
				}
				if (Second != 0)
				{
					num ^= Second.GetHashCode();
				}
				if (Millisecond != 0)
				{
					num ^= Millisecond.GetHashCode();
				}
				if (IsWallClockTime)
				{
					num ^= IsWallClockTime.GetHashCode();
				}
				if (Is24HourTime)
				{
					num ^= Is24HourTime.GetHashCode();
				}
				if (ShowMillisecondsUnderMinuteOnly)
				{
					num ^= ShowMillisecondsUnderMinuteOnly.GetHashCode();
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
				if (Hour != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Hour);
				}
				if (Minute != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Minute);
				}
				if (Second != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)Second);
				}
				if (Millisecond != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)Millisecond);
				}
				if (IsWallClockTime)
				{
					output.WriteRawTag(40);
					output.WriteBool(IsWallClockTime);
				}
				if (Is24HourTime)
				{
					output.WriteRawTag(48);
					output.WriteBool(Is24HourTime);
				}
				if (ShowMillisecondsUnderMinuteOnly)
				{
					output.WriteRawTag(56);
					output.WriteBool(ShowMillisecondsUnderMinuteOnly);
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
				if (Hour != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Hour);
				}
				if (Minute != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Minute);
				}
				if (Second != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Second);
				}
				if (Millisecond != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Millisecond);
				}
				if (IsWallClockTime)
				{
					num += 2;
				}
				if (Is24HourTime)
				{
					num += 2;
				}
				if (ShowMillisecondsUnderMinuteOnly)
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
			public void MergeFrom(Format other)
			{
				if (other != null)
				{
					if (other.Hour != 0)
					{
						Hour = other.Hour;
					}
					if (other.Minute != 0)
					{
						Minute = other.Minute;
					}
					if (other.Second != 0)
					{
						Second = other.Second;
					}
					if (other.Millisecond != 0)
					{
						Millisecond = other.Millisecond;
					}
					if (other.IsWallClockTime)
					{
						IsWallClockTime = other.IsWallClockTime;
					}
					if (other.Is24HourTime)
					{
						Is24HourTime = other.Is24HourTime;
					}
					if (other.ShowMillisecondsUnderMinuteOnly)
					{
						ShowMillisecondsUnderMinuteOnly = other.ShowMillisecondsUnderMinuteOnly;
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
						Hour = (Types.Style)input.ReadEnum();
						break;
					case 16u:
						Minute = (Types.Style)input.ReadEnum();
						break;
					case 24u:
						Second = (Types.Style)input.ReadEnum();
						break;
					case 32u:
						Millisecond = (Types.Style)input.ReadEnum();
						break;
					case 40u:
						IsWallClockTime = input.ReadBool();
						break;
					case 48u:
						Is24HourTime = input.ReadBool();
						break;
					case 56u:
						ShowMillisecondsUnderMinuteOnly = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Configuration : IMessage<Configuration>, IMessage, IEquatable<Configuration>, IDeepCloneable<Configuration>
		{
			public enum TimerTypeOneofCase
			{
				None,
				Countdown,
				CountdownToTime,
				ElapsedTime
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TimerTypeCountdown : IMessage<TimerTypeCountdown>, IMessage, IEquatable<TimerTypeCountdown>, IDeepCloneable<TimerTypeCountdown>
				{
					private static readonly MessageParser<TimerTypeCountdown> _parser = new MessageParser<TimerTypeCountdown>(() => new TimerTypeCountdown());

					private UnknownFieldSet _unknownFields;

					public const int DurationFieldNumber = 1;

					private double duration_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TimerTypeCountdown> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Configuration.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Duration
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
					public TimerTypeCountdown()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TimerTypeCountdown(TimerTypeCountdown other)
						: this()
					{
						duration_ = other.duration_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TimerTypeCountdown Clone()
					{
						return new TimerTypeCountdown(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TimerTypeCountdown);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TimerTypeCountdown other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration, other.Duration))
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
						if (Duration != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration);
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
						if (Duration != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Duration);
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
						if (Duration != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TimerTypeCountdown other)
					{
						if (other != null)
						{
							if (other.Duration != 0.0)
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
							if (num != 9)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Duration = input.ReadDouble();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TimerTypeCountdownToTime : IMessage<TimerTypeCountdownToTime>, IMessage, IEquatable<TimerTypeCountdownToTime>, IDeepCloneable<TimerTypeCountdownToTime>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum TimePeriod
						{
							[OriginalName("TIME_PERIOD_AM")]
							Am,
							[OriginalName("TIME_PERIOD_PM")]
							Pm,
							[OriginalName("TIME_PERIOD_24")]
							_24
						}
					}

					private static readonly MessageParser<TimerTypeCountdownToTime> _parser = new MessageParser<TimerTypeCountdownToTime>(() => new TimerTypeCountdownToTime());

					private UnknownFieldSet _unknownFields;

					public const int TimeOfDayFieldNumber = 1;

					private double timeOfDay_;

					public const int PeriodFieldNumber = 2;

					private Types.TimePeriod period_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TimerTypeCountdownToTime> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Configuration.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double TimeOfDay
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
					public Types.TimePeriod Period
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
					public TimerTypeCountdownToTime()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TimerTypeCountdownToTime(TimerTypeCountdownToTime other)
						: this()
					{
						timeOfDay_ = other.timeOfDay_;
						period_ = other.period_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TimerTypeCountdownToTime Clone()
					{
						return new TimerTypeCountdownToTime(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TimerTypeCountdownToTime);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TimerTypeCountdownToTime other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TimeOfDay, other.TimeOfDay))
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
						if (TimeOfDay != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TimeOfDay);
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
						if (TimeOfDay != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(TimeOfDay);
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
						if (TimeOfDay != 0.0)
						{
							num += 9;
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
					public void MergeFrom(TimerTypeCountdownToTime other)
					{
						if (other != null)
						{
							if (other.TimeOfDay != 0.0)
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
							case 9u:
								TimeOfDay = input.ReadDouble();
								break;
							case 16u:
								Period = (Types.TimePeriod)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TimerTypeElapsedTime : IMessage<TimerTypeElapsedTime>, IMessage, IEquatable<TimerTypeElapsedTime>, IDeepCloneable<TimerTypeElapsedTime>
				{
					private static readonly MessageParser<TimerTypeElapsedTime> _parser = new MessageParser<TimerTypeElapsedTime>(() => new TimerTypeElapsedTime());

					private UnknownFieldSet _unknownFields;

					public const int StartTimeFieldNumber = 1;

					private double startTime_;

					public const int EndTimeFieldNumber = 2;

					private double endTime_;

					public const int HasEndTimeFieldNumber = 3;

					private bool hasEndTime_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TimerTypeElapsedTime> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Configuration.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double StartTime
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
					public double EndTime
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
					public TimerTypeElapsedTime()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TimerTypeElapsedTime(TimerTypeElapsedTime other)
						: this()
					{
						startTime_ = other.startTime_;
						endTime_ = other.endTime_;
						hasEndTime_ = other.hasEndTime_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TimerTypeElapsedTime Clone()
					{
						return new TimerTypeElapsedTime(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TimerTypeElapsedTime);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TimerTypeElapsedTime other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(StartTime, other.StartTime))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(EndTime, other.EndTime))
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
						if (StartTime != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(StartTime);
						}
						if (EndTime != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(EndTime);
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
						if (StartTime != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(StartTime);
						}
						if (EndTime != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(EndTime);
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
						if (StartTime != 0.0)
						{
							num += 9;
						}
						if (EndTime != 0.0)
						{
							num += 9;
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
					public void MergeFrom(TimerTypeElapsedTime other)
					{
						if (other != null)
						{
							if (other.StartTime != 0.0)
							{
								StartTime = other.StartTime;
							}
							if (other.EndTime != 0.0)
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
							case 9u:
								StartTime = input.ReadDouble();
								break;
							case 17u:
								EndTime = input.ReadDouble();
								break;
							case 24u:
								HasEndTime = input.ReadBool();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Configuration> _parser = new MessageParser<Configuration>(() => new Configuration());

			private UnknownFieldSet _unknownFields;

			public const int CountdownFieldNumber = 1;

			public const int CountdownToTimeFieldNumber = 2;

			public const int ElapsedTimeFieldNumber = 3;

			public const int AllowsOverrunFieldNumber = 4;

			private bool allowsOverrun_;

			private object timerType_;

			private TimerTypeOneofCase timerTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Configuration> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Timer.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TimerTypeCountdown Countdown
			{
				get
				{
					if (timerTypeCase_ != TimerTypeOneofCase.Countdown)
					{
						return null;
					}
					return (Types.TimerTypeCountdown)timerType_;
				}
				set
				{
					timerType_ = value;
					timerTypeCase_ = ((value != null) ? TimerTypeOneofCase.Countdown : TimerTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TimerTypeCountdownToTime CountdownToTime
			{
				get
				{
					if (timerTypeCase_ != TimerTypeOneofCase.CountdownToTime)
					{
						return null;
					}
					return (Types.TimerTypeCountdownToTime)timerType_;
				}
				set
				{
					timerType_ = value;
					timerTypeCase_ = ((value != null) ? TimerTypeOneofCase.CountdownToTime : TimerTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TimerTypeElapsedTime ElapsedTime
			{
				get
				{
					if (timerTypeCase_ != TimerTypeOneofCase.ElapsedTime)
					{
						return null;
					}
					return (Types.TimerTypeElapsedTime)timerType_;
				}
				set
				{
					timerType_ = value;
					timerTypeCase_ = ((value != null) ? TimerTypeOneofCase.ElapsedTime : TimerTypeOneofCase.None);
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
			public TimerTypeOneofCase TimerTypeCase => timerTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Configuration()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Configuration(Configuration other)
				: this()
			{
				allowsOverrun_ = other.allowsOverrun_;
				switch (other.TimerTypeCase)
				{
				case TimerTypeOneofCase.Countdown:
					Countdown = other.Countdown.Clone();
					break;
				case TimerTypeOneofCase.CountdownToTime:
					CountdownToTime = other.CountdownToTime.Clone();
					break;
				case TimerTypeOneofCase.ElapsedTime:
					ElapsedTime = other.ElapsedTime.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Configuration Clone()
			{
				return new Configuration(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearTimerType()
			{
				timerTypeCase_ = TimerTypeOneofCase.None;
				timerType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Configuration);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Configuration other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Countdown, other.Countdown))
				{
					return false;
				}
				if (!object.Equals(CountdownToTime, other.CountdownToTime))
				{
					return false;
				}
				if (!object.Equals(ElapsedTime, other.ElapsedTime))
				{
					return false;
				}
				if (AllowsOverrun != other.AllowsOverrun)
				{
					return false;
				}
				if (TimerTypeCase != other.TimerTypeCase)
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
				if (timerTypeCase_ == TimerTypeOneofCase.Countdown)
				{
					num ^= Countdown.GetHashCode();
				}
				if (timerTypeCase_ == TimerTypeOneofCase.CountdownToTime)
				{
					num ^= CountdownToTime.GetHashCode();
				}
				if (timerTypeCase_ == TimerTypeOneofCase.ElapsedTime)
				{
					num ^= ElapsedTime.GetHashCode();
				}
				if (AllowsOverrun)
				{
					num ^= AllowsOverrun.GetHashCode();
				}
				num ^= (int)timerTypeCase_;
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
				if (timerTypeCase_ == TimerTypeOneofCase.Countdown)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Countdown);
				}
				if (timerTypeCase_ == TimerTypeOneofCase.CountdownToTime)
				{
					output.WriteRawTag(18);
					output.WriteMessage(CountdownToTime);
				}
				if (timerTypeCase_ == TimerTypeOneofCase.ElapsedTime)
				{
					output.WriteRawTag(26);
					output.WriteMessage(ElapsedTime);
				}
				if (AllowsOverrun)
				{
					output.WriteRawTag(32);
					output.WriteBool(AllowsOverrun);
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
				if (timerTypeCase_ == TimerTypeOneofCase.Countdown)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Countdown);
				}
				if (timerTypeCase_ == TimerTypeOneofCase.CountdownToTime)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CountdownToTime);
				}
				if (timerTypeCase_ == TimerTypeOneofCase.ElapsedTime)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ElapsedTime);
				}
				if (AllowsOverrun)
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
			public void MergeFrom(Configuration other)
			{
				if (other == null)
				{
					return;
				}
				if (other.AllowsOverrun)
				{
					AllowsOverrun = other.AllowsOverrun;
				}
				switch (other.TimerTypeCase)
				{
				case TimerTypeOneofCase.Countdown:
					if (Countdown == null)
					{
						Countdown = new Types.TimerTypeCountdown();
					}
					Countdown.MergeFrom(other.Countdown);
					break;
				case TimerTypeOneofCase.CountdownToTime:
					if (CountdownToTime == null)
					{
						CountdownToTime = new Types.TimerTypeCountdownToTime();
					}
					CountdownToTime.MergeFrom(other.CountdownToTime);
					break;
				case TimerTypeOneofCase.ElapsedTime:
					if (ElapsedTime == null)
					{
						ElapsedTime = new Types.TimerTypeElapsedTime();
					}
					ElapsedTime.MergeFrom(other.ElapsedTime);
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
					{
						Types.TimerTypeCountdown timerTypeCountdown = new Types.TimerTypeCountdown();
						if (timerTypeCase_ == TimerTypeOneofCase.Countdown)
						{
							timerTypeCountdown.MergeFrom(Countdown);
						}
						input.ReadMessage(timerTypeCountdown);
						Countdown = timerTypeCountdown;
						break;
					}
					case 18u:
					{
						Types.TimerTypeCountdownToTime timerTypeCountdownToTime = new Types.TimerTypeCountdownToTime();
						if (timerTypeCase_ == TimerTypeOneofCase.CountdownToTime)
						{
							timerTypeCountdownToTime.MergeFrom(CountdownToTime);
						}
						input.ReadMessage(timerTypeCountdownToTime);
						CountdownToTime = timerTypeCountdownToTime;
						break;
					}
					case 26u:
					{
						Types.TimerTypeElapsedTime timerTypeElapsedTime = new Types.TimerTypeElapsedTime();
						if (timerTypeCase_ == TimerTypeOneofCase.ElapsedTime)
						{
							timerTypeElapsedTime.MergeFrom(ElapsedTime);
						}
						input.ReadMessage(timerTypeElapsedTime);
						ElapsedTime = timerTypeElapsedTime;
						break;
					}
					case 32u:
						AllowsOverrun = input.ReadBool();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Timer> _parser = new MessageParser<Timer>(() => new Timer());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int ConfigurationFieldNumber = 10;

	private Types.Configuration configuration_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Timer> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TimersReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Configuration Configuration
	{
		get
		{
			return configuration_;
		}
		set
		{
			configuration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timer()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timer(Timer other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		configuration_ = ((other.configuration_ != null) ? other.configuration_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timer Clone()
	{
		return new Timer(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Timer);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Timer other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (!object.Equals(Configuration, other.Configuration))
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (configuration_ != null)
		{
			num ^= Configuration.GetHashCode();
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (configuration_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(Configuration);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (configuration_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Configuration);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Timer other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.configuration_ != null)
		{
			if (configuration_ == null)
			{
				Configuration = new Types.Configuration();
			}
			Configuration.MergeFrom(other.Configuration);
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				Name = input.ReadString();
				break;
			case 82u:
				if (configuration_ == null)
				{
					Configuration = new Types.Configuration();
				}
				input.ReadMessage(Configuration);
				break;
			}
		}
	}
}
