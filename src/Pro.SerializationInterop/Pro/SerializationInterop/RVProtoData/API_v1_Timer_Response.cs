using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Timer_Response : IMessage<API_v1_Timer_Response>, IMessage, IEquatable<API_v1_Timer_Response>, IDeepCloneable<API_v1_Timer_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Timers,
		CreateTimer,
		CurrentTimes,
		AllTimersOperation,
		GetTimer,
		PutTimer,
		DeleteTimer,
		TimerOperation,
		PutTimerOperation,
		TimerIncrement,
		SystemTime,
		VideoCountdown
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Timers : IMessage<Timers>, IMessage, IEquatable<Timers>, IDeepCloneable<Timers>
		{
			private static readonly MessageParser<Timers> _parser = new MessageParser<Timers>(() => new Timers());

			private UnknownFieldSet _unknownFields;

			public const int Timers_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_Timer> _repeated_timers_codec = FieldCodec.ForMessage(10u, API_v1_Timer.Parser);

			private readonly RepeatedField<API_v1_Timer> timers_ = new RepeatedField<API_v1_Timer>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Timers> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Timer> Timers_ => timers_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timers()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timers(Timers other)
				: this()
			{
				timers_ = other.timers_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timers Clone()
			{
				return new Timers(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Timers);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Timers other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!timers_.Equals(other.timers_))
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
				num ^= timers_.GetHashCode();
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
				timers_.WriteTo(output, _repeated_timers_codec);
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
				num += timers_.CalculateSize(_repeated_timers_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Timers other)
			{
				if (other != null)
				{
					timers_.Add(other.timers_);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						timers_.AddEntriesFrom(input, _repeated_timers_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CreateTimer : IMessage<CreateTimer>, IMessage, IEquatable<CreateTimer>, IDeepCloneable<CreateTimer>
		{
			private static readonly MessageParser<CreateTimer> _parser = new MessageParser<CreateTimer>(() => new CreateTimer());

			private UnknownFieldSet _unknownFields;

			public const int TimerFieldNumber = 1;

			private API_v1_Timer timer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CreateTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer Timer
			{
				get
				{
					return timer_;
				}
				set
				{
					timer_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateTimer()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateTimer(CreateTimer other)
				: this()
			{
				timer_ = ((other.timer_ != null) ? other.timer_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateTimer Clone()
			{
				return new CreateTimer(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CreateTimer);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CreateTimer other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Timer, other.Timer))
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
				if (timer_ != null)
				{
					num ^= Timer.GetHashCode();
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
				if (timer_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Timer);
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
				if (timer_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CreateTimer other)
			{
				if (other == null)
				{
					return;
				}
				if (other.timer_ != null)
				{
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					Timer.MergeFrom(other.Timer);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					input.ReadMessage(Timer);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CurrentTimes : IMessage<CurrentTimes>, IMessage, IEquatable<CurrentTimes>, IDeepCloneable<CurrentTimes>
		{
			private static readonly MessageParser<CurrentTimes> _parser = new MessageParser<CurrentTimes>(() => new CurrentTimes());

			private UnknownFieldSet _unknownFields;

			public const int TimersFieldNumber = 1;

			private static readonly FieldCodec<API_v1_TimerValue> _repeated_timers_codec = FieldCodec.ForMessage(10u, API_v1_TimerValue.Parser);

			private readonly RepeatedField<API_v1_TimerValue> timers_ = new RepeatedField<API_v1_TimerValue>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CurrentTimes> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_TimerValue> Timers => timers_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CurrentTimes()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CurrentTimes(CurrentTimes other)
				: this()
			{
				timers_ = other.timers_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CurrentTimes Clone()
			{
				return new CurrentTimes(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CurrentTimes);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CurrentTimes other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!timers_.Equals(other.timers_))
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
				num ^= timers_.GetHashCode();
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
				timers_.WriteTo(output, _repeated_timers_codec);
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
				num += timers_.CalculateSize(_repeated_timers_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CurrentTimes other)
			{
				if (other != null)
				{
					timers_.Add(other.timers_);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						timers_.AddEntriesFrom(input, _repeated_timers_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AllTimersOperation : IMessage<AllTimersOperation>, IMessage, IEquatable<AllTimersOperation>, IDeepCloneable<AllTimersOperation>
		{
			private static readonly MessageParser<AllTimersOperation> _parser = new MessageParser<AllTimersOperation>(() => new AllTimersOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AllTimersOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AllTimersOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AllTimersOperation(AllTimersOperation other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AllTimersOperation Clone()
			{
				return new AllTimersOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AllTimersOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AllTimersOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AllTimersOperation other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetTimer : IMessage<GetTimer>, IMessage, IEquatable<GetTimer>, IDeepCloneable<GetTimer>
		{
			private static readonly MessageParser<GetTimer> _parser = new MessageParser<GetTimer>(() => new GetTimer());

			private UnknownFieldSet _unknownFields;

			public const int TimerFieldNumber = 1;

			private API_v1_Timer timer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer Timer
			{
				get
				{
					return timer_;
				}
				set
				{
					timer_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTimer()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTimer(GetTimer other)
				: this()
			{
				timer_ = ((other.timer_ != null) ? other.timer_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTimer Clone()
			{
				return new GetTimer(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetTimer);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetTimer other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Timer, other.Timer))
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
				if (timer_ != null)
				{
					num ^= Timer.GetHashCode();
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
				if (timer_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Timer);
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
				if (timer_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetTimer other)
			{
				if (other == null)
				{
					return;
				}
				if (other.timer_ != null)
				{
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					Timer.MergeFrom(other.Timer);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					input.ReadMessage(Timer);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutTimer : IMessage<PutTimer>, IMessage, IEquatable<PutTimer>, IDeepCloneable<PutTimer>
		{
			private static readonly MessageParser<PutTimer> _parser = new MessageParser<PutTimer>(() => new PutTimer());

			private UnknownFieldSet _unknownFields;

			public const int TimerFieldNumber = 1;

			private API_v1_Timer timer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer Timer
			{
				get
				{
					return timer_;
				}
				set
				{
					timer_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTimer()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTimer(PutTimer other)
				: this()
			{
				timer_ = ((other.timer_ != null) ? other.timer_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTimer Clone()
			{
				return new PutTimer(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutTimer);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutTimer other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Timer, other.Timer))
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
				if (timer_ != null)
				{
					num ^= Timer.GetHashCode();
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
				if (timer_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Timer);
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
				if (timer_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutTimer other)
			{
				if (other == null)
				{
					return;
				}
				if (other.timer_ != null)
				{
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					Timer.MergeFrom(other.Timer);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					input.ReadMessage(Timer);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteTimer : IMessage<DeleteTimer>, IMessage, IEquatable<DeleteTimer>, IDeepCloneable<DeleteTimer>
		{
			private static readonly MessageParser<DeleteTimer> _parser = new MessageParser<DeleteTimer>(() => new DeleteTimer());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteTimer()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteTimer(DeleteTimer other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteTimer Clone()
			{
				return new DeleteTimer(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteTimer);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteTimer other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DeleteTimer other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimerOperation : IMessage<TimerOperation>, IMessage, IEquatable<TimerOperation>, IDeepCloneable<TimerOperation>
		{
			private static readonly MessageParser<TimerOperation> _parser = new MessageParser<TimerOperation>(() => new TimerOperation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimerOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerOperation(TimerOperation other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerOperation Clone()
			{
				return new TimerOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimerOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimerOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimerOperation other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutTimerOperation : IMessage<PutTimerOperation>, IMessage, IEquatable<PutTimerOperation>, IDeepCloneable<PutTimerOperation>
		{
			private static readonly MessageParser<PutTimerOperation> _parser = new MessageParser<PutTimerOperation>(() => new PutTimerOperation());

			private UnknownFieldSet _unknownFields;

			public const int TimerFieldNumber = 1;

			private API_v1_Timer timer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutTimerOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer Timer
			{
				get
				{
					return timer_;
				}
				set
				{
					timer_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTimerOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTimerOperation(PutTimerOperation other)
				: this()
			{
				timer_ = ((other.timer_ != null) ? other.timer_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTimerOperation Clone()
			{
				return new PutTimerOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutTimerOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutTimerOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Timer, other.Timer))
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
				if (timer_ != null)
				{
					num ^= Timer.GetHashCode();
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
				if (timer_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Timer);
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
				if (timer_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutTimerOperation other)
			{
				if (other == null)
				{
					return;
				}
				if (other.timer_ != null)
				{
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					Timer.MergeFrom(other.Timer);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (timer_ == null)
					{
						Timer = new API_v1_Timer();
					}
					input.ReadMessage(Timer);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimerIncrement : IMessage<TimerIncrement>, IMessage, IEquatable<TimerIncrement>, IDeepCloneable<TimerIncrement>
		{
			private static readonly MessageParser<TimerIncrement> _parser = new MessageParser<TimerIncrement>(() => new TimerIncrement());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimerIncrement> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerIncrement()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerIncrement(TimerIncrement other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerIncrement Clone()
			{
				return new TimerIncrement(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimerIncrement);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimerIncrement other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimerIncrement other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SystemTime : IMessage<SystemTime>, IMessage, IEquatable<SystemTime>, IDeepCloneable<SystemTime>
		{
			private static readonly MessageParser<SystemTime> _parser = new MessageParser<SystemTime>(() => new SystemTime());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private ulong time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SystemTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SystemTime()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SystemTime(SystemTime other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SystemTime Clone()
			{
				return new SystemTime(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SystemTime);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SystemTime other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Time != other.Time)
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
				if (Time != 0L)
				{
					num ^= Time.GetHashCode();
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
				if (Time != 0L)
				{
					output.WriteRawTag(8);
					output.WriteUInt64(Time);
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
				if (Time != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Time);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SystemTime other)
			{
				if (other != null)
				{
					if (other.Time != 0L)
					{
						Time = other.Time;
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
						Time = input.ReadUInt64();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class VideoCountdown : IMessage<VideoCountdown>, IMessage, IEquatable<VideoCountdown>, IDeepCloneable<VideoCountdown>
		{
			private static readonly MessageParser<VideoCountdown> _parser = new MessageParser<VideoCountdown>(() => new VideoCountdown());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private string time_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<VideoCountdown> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Response.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoCountdown()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoCountdown(VideoCountdown other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public VideoCountdown Clone()
			{
				return new VideoCountdown(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as VideoCountdown);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(VideoCountdown other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Time != other.Time)
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
				if (Time.Length != 0)
				{
					num ^= Time.GetHashCode();
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
				if (Time.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Time);
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
				if (Time.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Time);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(VideoCountdown other)
			{
				if (other != null)
				{
					if (other.Time.Length != 0)
					{
						Time = other.Time;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Timer_Response> _parser = new MessageParser<API_v1_Timer_Response>(() => new API_v1_Timer_Response());

	private UnknownFieldSet _unknownFields;

	public const int TimersFieldNumber = 1;

	public const int CreateTimerFieldNumber = 2;

	public const int CurrentTimesFieldNumber = 3;

	public const int AllTimersOperationFieldNumber = 4;

	public const int GetTimerFieldNumber = 5;

	public const int PutTimerFieldNumber = 6;

	public const int DeleteTimerFieldNumber = 7;

	public const int TimerOperationFieldNumber = 8;

	public const int PutTimerOperationFieldNumber = 9;

	public const int TimerIncrementFieldNumber = 10;

	public const int SystemTimeFieldNumber = 11;

	public const int VideoCountdownFieldNumber = 12;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Timer_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TimerReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Timers Timers
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Timers)
			{
				return null;
			}
			return (Types.Timers)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Timers : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateTimer CreateTimer
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.CreateTimer)
			{
				return null;
			}
			return (Types.CreateTimer)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.CreateTimer : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CurrentTimes CurrentTimes
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.CurrentTimes)
			{
				return null;
			}
			return (Types.CurrentTimes)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.CurrentTimes : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AllTimersOperation AllTimersOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.AllTimersOperation)
			{
				return null;
			}
			return (Types.AllTimersOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.AllTimersOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetTimer GetTimer
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetTimer)
			{
				return null;
			}
			return (Types.GetTimer)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetTimer : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutTimer PutTimer
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutTimer)
			{
				return null;
			}
			return (Types.PutTimer)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutTimer : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteTimer DeleteTimer
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteTimer)
			{
				return null;
			}
			return (Types.DeleteTimer)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteTimer : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimerOperation TimerOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TimerOperation)
			{
				return null;
			}
			return (Types.TimerOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TimerOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutTimerOperation PutTimerOperation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutTimerOperation)
			{
				return null;
			}
			return (Types.PutTimerOperation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutTimerOperation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimerIncrement TimerIncrement
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TimerIncrement)
			{
				return null;
			}
			return (Types.TimerIncrement)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TimerIncrement : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SystemTime SystemTime
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.SystemTime)
			{
				return null;
			}
			return (Types.SystemTime)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.SystemTime : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.VideoCountdown VideoCountdown
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.VideoCountdown)
			{
				return null;
			}
			return (Types.VideoCountdown)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.VideoCountdown : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer_Response(API_v1_Timer_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Timers:
			Timers = other.Timers.Clone();
			break;
		case ResponseOneofCase.CreateTimer:
			CreateTimer = other.CreateTimer.Clone();
			break;
		case ResponseOneofCase.CurrentTimes:
			CurrentTimes = other.CurrentTimes.Clone();
			break;
		case ResponseOneofCase.AllTimersOperation:
			AllTimersOperation = other.AllTimersOperation.Clone();
			break;
		case ResponseOneofCase.GetTimer:
			GetTimer = other.GetTimer.Clone();
			break;
		case ResponseOneofCase.PutTimer:
			PutTimer = other.PutTimer.Clone();
			break;
		case ResponseOneofCase.DeleteTimer:
			DeleteTimer = other.DeleteTimer.Clone();
			break;
		case ResponseOneofCase.TimerOperation:
			TimerOperation = other.TimerOperation.Clone();
			break;
		case ResponseOneofCase.PutTimerOperation:
			PutTimerOperation = other.PutTimerOperation.Clone();
			break;
		case ResponseOneofCase.TimerIncrement:
			TimerIncrement = other.TimerIncrement.Clone();
			break;
		case ResponseOneofCase.SystemTime:
			SystemTime = other.SystemTime.Clone();
			break;
		case ResponseOneofCase.VideoCountdown:
			VideoCountdown = other.VideoCountdown.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer_Response Clone()
	{
		return new API_v1_Timer_Response(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponse()
	{
		responseCase_ = ResponseOneofCase.None;
		response_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Timer_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Timer_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Timers, other.Timers))
		{
			return false;
		}
		if (!object.Equals(CreateTimer, other.CreateTimer))
		{
			return false;
		}
		if (!object.Equals(CurrentTimes, other.CurrentTimes))
		{
			return false;
		}
		if (!object.Equals(AllTimersOperation, other.AllTimersOperation))
		{
			return false;
		}
		if (!object.Equals(GetTimer, other.GetTimer))
		{
			return false;
		}
		if (!object.Equals(PutTimer, other.PutTimer))
		{
			return false;
		}
		if (!object.Equals(DeleteTimer, other.DeleteTimer))
		{
			return false;
		}
		if (!object.Equals(TimerOperation, other.TimerOperation))
		{
			return false;
		}
		if (!object.Equals(PutTimerOperation, other.PutTimerOperation))
		{
			return false;
		}
		if (!object.Equals(TimerIncrement, other.TimerIncrement))
		{
			return false;
		}
		if (!object.Equals(SystemTime, other.SystemTime))
		{
			return false;
		}
		if (!object.Equals(VideoCountdown, other.VideoCountdown))
		{
			return false;
		}
		if (ResponseCase != other.ResponseCase)
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
		if (responseCase_ == ResponseOneofCase.Timers)
		{
			num ^= Timers.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.CreateTimer)
		{
			num ^= CreateTimer.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.CurrentTimes)
		{
			num ^= CurrentTimes.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.AllTimersOperation)
		{
			num ^= AllTimersOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetTimer)
		{
			num ^= GetTimer.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutTimer)
		{
			num ^= PutTimer.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteTimer)
		{
			num ^= DeleteTimer.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TimerOperation)
		{
			num ^= TimerOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutTimerOperation)
		{
			num ^= PutTimerOperation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TimerIncrement)
		{
			num ^= TimerIncrement.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.SystemTime)
		{
			num ^= SystemTime.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.VideoCountdown)
		{
			num ^= VideoCountdown.GetHashCode();
		}
		num ^= (int)responseCase_;
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
		if (responseCase_ == ResponseOneofCase.Timers)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Timers);
		}
		if (responseCase_ == ResponseOneofCase.CreateTimer)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateTimer);
		}
		if (responseCase_ == ResponseOneofCase.CurrentTimes)
		{
			output.WriteRawTag(26);
			output.WriteMessage(CurrentTimes);
		}
		if (responseCase_ == ResponseOneofCase.AllTimersOperation)
		{
			output.WriteRawTag(34);
			output.WriteMessage(AllTimersOperation);
		}
		if (responseCase_ == ResponseOneofCase.GetTimer)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GetTimer);
		}
		if (responseCase_ == ResponseOneofCase.PutTimer)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PutTimer);
		}
		if (responseCase_ == ResponseOneofCase.DeleteTimer)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DeleteTimer);
		}
		if (responseCase_ == ResponseOneofCase.TimerOperation)
		{
			output.WriteRawTag(66);
			output.WriteMessage(TimerOperation);
		}
		if (responseCase_ == ResponseOneofCase.PutTimerOperation)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PutTimerOperation);
		}
		if (responseCase_ == ResponseOneofCase.TimerIncrement)
		{
			output.WriteRawTag(82);
			output.WriteMessage(TimerIncrement);
		}
		if (responseCase_ == ResponseOneofCase.SystemTime)
		{
			output.WriteRawTag(90);
			output.WriteMessage(SystemTime);
		}
		if (responseCase_ == ResponseOneofCase.VideoCountdown)
		{
			output.WriteRawTag(98);
			output.WriteMessage(VideoCountdown);
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
		if (responseCase_ == ResponseOneofCase.Timers)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Timers);
		}
		if (responseCase_ == ResponseOneofCase.CreateTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateTimer);
		}
		if (responseCase_ == ResponseOneofCase.CurrentTimes)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CurrentTimes);
		}
		if (responseCase_ == ResponseOneofCase.AllTimersOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AllTimersOperation);
		}
		if (responseCase_ == ResponseOneofCase.GetTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetTimer);
		}
		if (responseCase_ == ResponseOneofCase.PutTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutTimer);
		}
		if (responseCase_ == ResponseOneofCase.DeleteTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteTimer);
		}
		if (responseCase_ == ResponseOneofCase.TimerOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimerOperation);
		}
		if (responseCase_ == ResponseOneofCase.PutTimerOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutTimerOperation);
		}
		if (responseCase_ == ResponseOneofCase.TimerIncrement)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimerIncrement);
		}
		if (responseCase_ == ResponseOneofCase.SystemTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SystemTime);
		}
		if (responseCase_ == ResponseOneofCase.VideoCountdown)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VideoCountdown);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Timer_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Timers:
			if (Timers == null)
			{
				Timers = new Types.Timers();
			}
			Timers.MergeFrom(other.Timers);
			break;
		case ResponseOneofCase.CreateTimer:
			if (CreateTimer == null)
			{
				CreateTimer = new Types.CreateTimer();
			}
			CreateTimer.MergeFrom(other.CreateTimer);
			break;
		case ResponseOneofCase.CurrentTimes:
			if (CurrentTimes == null)
			{
				CurrentTimes = new Types.CurrentTimes();
			}
			CurrentTimes.MergeFrom(other.CurrentTimes);
			break;
		case ResponseOneofCase.AllTimersOperation:
			if (AllTimersOperation == null)
			{
				AllTimersOperation = new Types.AllTimersOperation();
			}
			AllTimersOperation.MergeFrom(other.AllTimersOperation);
			break;
		case ResponseOneofCase.GetTimer:
			if (GetTimer == null)
			{
				GetTimer = new Types.GetTimer();
			}
			GetTimer.MergeFrom(other.GetTimer);
			break;
		case ResponseOneofCase.PutTimer:
			if (PutTimer == null)
			{
				PutTimer = new Types.PutTimer();
			}
			PutTimer.MergeFrom(other.PutTimer);
			break;
		case ResponseOneofCase.DeleteTimer:
			if (DeleteTimer == null)
			{
				DeleteTimer = new Types.DeleteTimer();
			}
			DeleteTimer.MergeFrom(other.DeleteTimer);
			break;
		case ResponseOneofCase.TimerOperation:
			if (TimerOperation == null)
			{
				TimerOperation = new Types.TimerOperation();
			}
			TimerOperation.MergeFrom(other.TimerOperation);
			break;
		case ResponseOneofCase.PutTimerOperation:
			if (PutTimerOperation == null)
			{
				PutTimerOperation = new Types.PutTimerOperation();
			}
			PutTimerOperation.MergeFrom(other.PutTimerOperation);
			break;
		case ResponseOneofCase.TimerIncrement:
			if (TimerIncrement == null)
			{
				TimerIncrement = new Types.TimerIncrement();
			}
			TimerIncrement.MergeFrom(other.TimerIncrement);
			break;
		case ResponseOneofCase.SystemTime:
			if (SystemTime == null)
			{
				SystemTime = new Types.SystemTime();
			}
			SystemTime.MergeFrom(other.SystemTime);
			break;
		case ResponseOneofCase.VideoCountdown:
			if (VideoCountdown == null)
			{
				VideoCountdown = new Types.VideoCountdown();
			}
			VideoCountdown.MergeFrom(other.VideoCountdown);
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
				Types.Timers timers = new Types.Timers();
				if (responseCase_ == ResponseOneofCase.Timers)
				{
					timers.MergeFrom(Timers);
				}
				input.ReadMessage(timers);
				Timers = timers;
				break;
			}
			case 18u:
			{
				Types.CreateTimer createTimer = new Types.CreateTimer();
				if (responseCase_ == ResponseOneofCase.CreateTimer)
				{
					createTimer.MergeFrom(CreateTimer);
				}
				input.ReadMessage(createTimer);
				CreateTimer = createTimer;
				break;
			}
			case 26u:
			{
				Types.CurrentTimes currentTimes = new Types.CurrentTimes();
				if (responseCase_ == ResponseOneofCase.CurrentTimes)
				{
					currentTimes.MergeFrom(CurrentTimes);
				}
				input.ReadMessage(currentTimes);
				CurrentTimes = currentTimes;
				break;
			}
			case 34u:
			{
				Types.AllTimersOperation allTimersOperation = new Types.AllTimersOperation();
				if (responseCase_ == ResponseOneofCase.AllTimersOperation)
				{
					allTimersOperation.MergeFrom(AllTimersOperation);
				}
				input.ReadMessage(allTimersOperation);
				AllTimersOperation = allTimersOperation;
				break;
			}
			case 42u:
			{
				Types.GetTimer getTimer = new Types.GetTimer();
				if (responseCase_ == ResponseOneofCase.GetTimer)
				{
					getTimer.MergeFrom(GetTimer);
				}
				input.ReadMessage(getTimer);
				GetTimer = getTimer;
				break;
			}
			case 50u:
			{
				Types.PutTimer putTimer = new Types.PutTimer();
				if (responseCase_ == ResponseOneofCase.PutTimer)
				{
					putTimer.MergeFrom(PutTimer);
				}
				input.ReadMessage(putTimer);
				PutTimer = putTimer;
				break;
			}
			case 58u:
			{
				Types.DeleteTimer deleteTimer = new Types.DeleteTimer();
				if (responseCase_ == ResponseOneofCase.DeleteTimer)
				{
					deleteTimer.MergeFrom(DeleteTimer);
				}
				input.ReadMessage(deleteTimer);
				DeleteTimer = deleteTimer;
				break;
			}
			case 66u:
			{
				Types.TimerOperation timerOperation = new Types.TimerOperation();
				if (responseCase_ == ResponseOneofCase.TimerOperation)
				{
					timerOperation.MergeFrom(TimerOperation);
				}
				input.ReadMessage(timerOperation);
				TimerOperation = timerOperation;
				break;
			}
			case 74u:
			{
				Types.PutTimerOperation putTimerOperation = new Types.PutTimerOperation();
				if (responseCase_ == ResponseOneofCase.PutTimerOperation)
				{
					putTimerOperation.MergeFrom(PutTimerOperation);
				}
				input.ReadMessage(putTimerOperation);
				PutTimerOperation = putTimerOperation;
				break;
			}
			case 82u:
			{
				Types.TimerIncrement timerIncrement = new Types.TimerIncrement();
				if (responseCase_ == ResponseOneofCase.TimerIncrement)
				{
					timerIncrement.MergeFrom(TimerIncrement);
				}
				input.ReadMessage(timerIncrement);
				TimerIncrement = timerIncrement;
				break;
			}
			case 90u:
			{
				Types.SystemTime systemTime = new Types.SystemTime();
				if (responseCase_ == ResponseOneofCase.SystemTime)
				{
					systemTime.MergeFrom(SystemTime);
				}
				input.ReadMessage(systemTime);
				SystemTime = systemTime;
				break;
			}
			case 98u:
			{
				Types.VideoCountdown videoCountdown = new Types.VideoCountdown();
				if (responseCase_ == ResponseOneofCase.VideoCountdown)
				{
					videoCountdown.MergeFrom(VideoCountdown);
				}
				input.ReadMessage(videoCountdown);
				VideoCountdown = videoCountdown;
				break;
			}
			}
		}
	}
}
