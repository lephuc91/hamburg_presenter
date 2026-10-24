using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Timer_Request : IMessage<API_v1_Timer_Request>, IMessage, IEquatable<API_v1_Timer_Request>, IDeepCloneable<API_v1_Timer_Request>
{
	public enum RequestOneofCase
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Timers> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(Timers other)
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
		public sealed class CreateTimer : IMessage<CreateTimer>, IMessage, IEquatable<CreateTimer>, IDeepCloneable<CreateTimer>
		{
			private static readonly MessageParser<CreateTimer> _parser = new MessageParser<CreateTimer>(() => new CreateTimer());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int AllowsOverrunFieldNumber = 2;

			private bool allowsOverrun_;

			public const int CountdownFieldNumber = 3;

			private API_v1_Timer.Types.API_v1_Timer_Countdown countdown_;

			public const int CountDownToTimeFieldNumber = 4;

			private API_v1_Timer.Types.API_v1_Timer_CountdownToTime countDownToTime_;

			public const int ElapsedFieldNumber = 5;

			private API_v1_Timer.Types.API_v1_Timer_Elapsed elapsed_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CreateTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public API_v1_Timer.Types.API_v1_Timer_Countdown Countdown
			{
				get
				{
					return countdown_;
				}
				set
				{
					countdown_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer.Types.API_v1_Timer_CountdownToTime CountDownToTime
			{
				get
				{
					return countDownToTime_;
				}
				set
				{
					countDownToTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer.Types.API_v1_Timer_Elapsed Elapsed
			{
				get
				{
					return elapsed_;
				}
				set
				{
					elapsed_ = value;
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
				name_ = other.name_;
				allowsOverrun_ = other.allowsOverrun_;
				countdown_ = ((other.countdown_ != null) ? other.countdown_.Clone() : null);
				countDownToTime_ = ((other.countDownToTime_ != null) ? other.countDownToTime_.Clone() : null);
				elapsed_ = ((other.elapsed_ != null) ? other.elapsed_.Clone() : null);
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
				if (Name != other.Name)
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
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (AllowsOverrun)
				{
					num ^= AllowsOverrun.GetHashCode();
				}
				if (countdown_ != null)
				{
					num ^= Countdown.GetHashCode();
				}
				if (countDownToTime_ != null)
				{
					num ^= CountDownToTime.GetHashCode();
				}
				if (elapsed_ != null)
				{
					num ^= Elapsed.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				if (AllowsOverrun)
				{
					output.WriteRawTag(16);
					output.WriteBool(AllowsOverrun);
				}
				if (countdown_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Countdown);
				}
				if (countDownToTime_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(CountDownToTime);
				}
				if (elapsed_ != null)
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (AllowsOverrun)
				{
					num += 2;
				}
				if (countdown_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Countdown);
				}
				if (countDownToTime_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CountDownToTime);
				}
				if (elapsed_ != null)
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
			public void MergeFrom(CreateTimer other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.AllowsOverrun)
				{
					AllowsOverrun = other.AllowsOverrun;
				}
				if (other.countdown_ != null)
				{
					if (countdown_ == null)
					{
						Countdown = new API_v1_Timer.Types.API_v1_Timer_Countdown();
					}
					Countdown.MergeFrom(other.Countdown);
				}
				if (other.countDownToTime_ != null)
				{
					if (countDownToTime_ == null)
					{
						CountDownToTime = new API_v1_Timer.Types.API_v1_Timer_CountdownToTime();
					}
					CountDownToTime.MergeFrom(other.CountDownToTime);
				}
				if (other.elapsed_ != null)
				{
					if (elapsed_ == null)
					{
						Elapsed = new API_v1_Timer.Types.API_v1_Timer_Elapsed();
					}
					Elapsed.MergeFrom(other.Elapsed);
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
						Name = input.ReadString();
						break;
					case 16u:
						AllowsOverrun = input.ReadBool();
						break;
					case 26u:
						if (countdown_ == null)
						{
							Countdown = new API_v1_Timer.Types.API_v1_Timer_Countdown();
						}
						input.ReadMessage(Countdown);
						break;
					case 34u:
						if (countDownToTime_ == null)
						{
							CountDownToTime = new API_v1_Timer.Types.API_v1_Timer_CountdownToTime();
						}
						input.ReadMessage(CountDownToTime);
						break;
					case 42u:
						if (elapsed_ == null)
						{
							Elapsed = new API_v1_Timer.Types.API_v1_Timer_Elapsed();
						}
						input.ReadMessage(Elapsed);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CurrentTimes : IMessage<CurrentTimes>, IMessage, IEquatable<CurrentTimes>, IDeepCloneable<CurrentTimes>
		{
			private static readonly MessageParser<CurrentTimes> _parser = new MessageParser<CurrentTimes>(() => new CurrentTimes());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CurrentTimes> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(CurrentTimes other)
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
		public sealed class AllTimersOperation : IMessage<AllTimersOperation>, IMessage, IEquatable<AllTimersOperation>, IDeepCloneable<AllTimersOperation>
		{
			private static readonly MessageParser<AllTimersOperation> _parser = new MessageParser<AllTimersOperation>(() => new AllTimersOperation());

			private UnknownFieldSet _unknownFields;

			public const int OperationFieldNumber = 1;

			private API_v1_TimerOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AllTimersOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_TimerOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

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
				operation_ = other.operation_;
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
				if (Operation != other.Operation)
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
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
				if (Operation != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Operation);
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
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
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
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
						Operation = (API_v1_TimerOperation)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetTimer : IMessage<GetTimer>, IMessage, IEquatable<GetTimer>, IDeepCloneable<GetTimer>
		{
			private static readonly MessageParser<GetTimer> _parser = new MessageParser<GetTimer>(() => new GetTimer());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				id_ = other.id_;
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
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
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
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutTimer : IMessage<PutTimer>, IMessage, IEquatable<PutTimer>, IDeepCloneable<PutTimer>
		{
			private static readonly MessageParser<PutTimer> _parser = new MessageParser<PutTimer>(() => new PutTimer());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int TimerFieldNumber = 2;

			private API_v1_Timer timer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				id_ = other.id_;
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
				if (Id != other.Id)
				{
					return false;
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (timer_ != null)
				{
					output.WriteRawTag(18);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
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
				if (other.Id.Length != 0)
				{
					Id = other.Id;
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 10u:
						Id = input.ReadString();
						break;
					case 18u:
						if (timer_ == null)
						{
							Timer = new API_v1_Timer();
						}
						input.ReadMessage(Timer);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteTimer : IMessage<DeleteTimer>, IMessage, IEquatable<DeleteTimer>, IDeepCloneable<DeleteTimer>
		{
			private static readonly MessageParser<DeleteTimer> _parser = new MessageParser<DeleteTimer>(() => new DeleteTimer());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteTimer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				id_ = other.id_;
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
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
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
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimerOperation : IMessage<TimerOperation>, IMessage, IEquatable<TimerOperation>, IDeepCloneable<TimerOperation>
		{
			private static readonly MessageParser<TimerOperation> _parser = new MessageParser<TimerOperation>(() => new TimerOperation());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int OperationFieldNumber = 2;

			private API_v1_TimerOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimerOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_TimerOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

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
				id_ = other.id_;
				operation_ = other.operation_;
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
				if (Id != other.Id)
				{
					return false;
				}
				if (Operation != other.Operation)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (Operation != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Operation);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
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
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
					case 10u:
						Id = input.ReadString();
						break;
					case 16u:
						Operation = (API_v1_TimerOperation)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutTimerOperation : IMessage<PutTimerOperation>, IMessage, IEquatable<PutTimerOperation>, IDeepCloneable<PutTimerOperation>
		{
			private static readonly MessageParser<PutTimerOperation> _parser = new MessageParser<PutTimerOperation>(() => new PutTimerOperation());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int OperationFieldNumber = 2;

			private API_v1_TimerOperation operation_;

			public const int TimerFieldNumber = 3;

			private API_v1_Timer timer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutTimerOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_TimerOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

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
				id_ = other.id_;
				operation_ = other.operation_;
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
				if (Id != other.Id)
				{
					return false;
				}
				if (Operation != other.Operation)
				{
					return false;
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
				}
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (Operation != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Operation);
				}
				if (timer_ != null)
				{
					output.WriteRawTag(26);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
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
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.Operation != 0)
				{
					Operation = other.Operation;
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 10u:
						Id = input.ReadString();
						break;
					case 16u:
						Operation = (API_v1_TimerOperation)input.ReadEnum();
						break;
					case 26u:
						if (timer_ == null)
						{
							Timer = new API_v1_Timer();
						}
						input.ReadMessage(Timer);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimerIncrement : IMessage<TimerIncrement>, IMessage, IEquatable<TimerIncrement>, IDeepCloneable<TimerIncrement>
		{
			private static readonly MessageParser<TimerIncrement> _parser = new MessageParser<TimerIncrement>(() => new TimerIncrement());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int AmountFieldNumber = 2;

			private double amount_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimerIncrement> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Amount
			{
				get
				{
					return amount_;
				}
				set
				{
					amount_ = value;
				}
			}

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
				id_ = other.id_;
				amount_ = other.amount_;
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
				if (Id != other.Id)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Amount, other.Amount))
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (Amount != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Amount);
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (Amount != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Amount);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (Amount != 0.0)
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
			public void MergeFrom(TimerIncrement other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Amount != 0.0)
					{
						Amount = other.Amount;
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
					case 10u:
						Id = input.ReadString();
						break;
					case 17u:
						Amount = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SystemTime : IMessage<SystemTime>, IMessage, IEquatable<SystemTime>, IDeepCloneable<SystemTime>
		{
			private static readonly MessageParser<SystemTime> _parser = new MessageParser<SystemTime>(() => new SystemTime());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SystemTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(SystemTime other)
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
		public sealed class VideoCountdown : IMessage<VideoCountdown>, IMessage, IEquatable<VideoCountdown>, IDeepCloneable<VideoCountdown>
		{
			private static readonly MessageParser<VideoCountdown> _parser = new MessageParser<VideoCountdown>(() => new VideoCountdown());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<VideoCountdown> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Timer_Request.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(VideoCountdown other)
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
	}

	private static readonly MessageParser<API_v1_Timer_Request> _parser = new MessageParser<API_v1_Timer_Request>(() => new API_v1_Timer_Request());

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

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Timer_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TimerReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Timers Timers
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Timers)
			{
				return null;
			}
			return (Types.Timers)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Timers : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateTimer CreateTimer
	{
		get
		{
			if (requestCase_ != RequestOneofCase.CreateTimer)
			{
				return null;
			}
			return (Types.CreateTimer)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.CreateTimer : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CurrentTimes CurrentTimes
	{
		get
		{
			if (requestCase_ != RequestOneofCase.CurrentTimes)
			{
				return null;
			}
			return (Types.CurrentTimes)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.CurrentTimes : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AllTimersOperation AllTimersOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.AllTimersOperation)
			{
				return null;
			}
			return (Types.AllTimersOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.AllTimersOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetTimer GetTimer
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetTimer)
			{
				return null;
			}
			return (Types.GetTimer)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetTimer : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutTimer PutTimer
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutTimer)
			{
				return null;
			}
			return (Types.PutTimer)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutTimer : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteTimer DeleteTimer
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteTimer)
			{
				return null;
			}
			return (Types.DeleteTimer)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteTimer : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimerOperation TimerOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TimerOperation)
			{
				return null;
			}
			return (Types.TimerOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TimerOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutTimerOperation PutTimerOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutTimerOperation)
			{
				return null;
			}
			return (Types.PutTimerOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutTimerOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimerIncrement TimerIncrement
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TimerIncrement)
			{
				return null;
			}
			return (Types.TimerIncrement)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TimerIncrement : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SystemTime SystemTime
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SystemTime)
			{
				return null;
			}
			return (Types.SystemTime)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SystemTime : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.VideoCountdown VideoCountdown
	{
		get
		{
			if (requestCase_ != RequestOneofCase.VideoCountdown)
			{
				return null;
			}
			return (Types.VideoCountdown)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.VideoCountdown : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer_Request(API_v1_Timer_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Timers:
			Timers = other.Timers.Clone();
			break;
		case RequestOneofCase.CreateTimer:
			CreateTimer = other.CreateTimer.Clone();
			break;
		case RequestOneofCase.CurrentTimes:
			CurrentTimes = other.CurrentTimes.Clone();
			break;
		case RequestOneofCase.AllTimersOperation:
			AllTimersOperation = other.AllTimersOperation.Clone();
			break;
		case RequestOneofCase.GetTimer:
			GetTimer = other.GetTimer.Clone();
			break;
		case RequestOneofCase.PutTimer:
			PutTimer = other.PutTimer.Clone();
			break;
		case RequestOneofCase.DeleteTimer:
			DeleteTimer = other.DeleteTimer.Clone();
			break;
		case RequestOneofCase.TimerOperation:
			TimerOperation = other.TimerOperation.Clone();
			break;
		case RequestOneofCase.PutTimerOperation:
			PutTimerOperation = other.PutTimerOperation.Clone();
			break;
		case RequestOneofCase.TimerIncrement:
			TimerIncrement = other.TimerIncrement.Clone();
			break;
		case RequestOneofCase.SystemTime:
			SystemTime = other.SystemTime.Clone();
			break;
		case RequestOneofCase.VideoCountdown:
			VideoCountdown = other.VideoCountdown.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Timer_Request Clone()
	{
		return new API_v1_Timer_Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Timer_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Timer_Request other)
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
		if (RequestCase != other.RequestCase)
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
		if (requestCase_ == RequestOneofCase.Timers)
		{
			num ^= Timers.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.CreateTimer)
		{
			num ^= CreateTimer.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.CurrentTimes)
		{
			num ^= CurrentTimes.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.AllTimersOperation)
		{
			num ^= AllTimersOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetTimer)
		{
			num ^= GetTimer.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutTimer)
		{
			num ^= PutTimer.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteTimer)
		{
			num ^= DeleteTimer.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TimerOperation)
		{
			num ^= TimerOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutTimerOperation)
		{
			num ^= PutTimerOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TimerIncrement)
		{
			num ^= TimerIncrement.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SystemTime)
		{
			num ^= SystemTime.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.VideoCountdown)
		{
			num ^= VideoCountdown.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (requestCase_ == RequestOneofCase.Timers)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Timers);
		}
		if (requestCase_ == RequestOneofCase.CreateTimer)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateTimer);
		}
		if (requestCase_ == RequestOneofCase.CurrentTimes)
		{
			output.WriteRawTag(26);
			output.WriteMessage(CurrentTimes);
		}
		if (requestCase_ == RequestOneofCase.AllTimersOperation)
		{
			output.WriteRawTag(34);
			output.WriteMessage(AllTimersOperation);
		}
		if (requestCase_ == RequestOneofCase.GetTimer)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GetTimer);
		}
		if (requestCase_ == RequestOneofCase.PutTimer)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PutTimer);
		}
		if (requestCase_ == RequestOneofCase.DeleteTimer)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DeleteTimer);
		}
		if (requestCase_ == RequestOneofCase.TimerOperation)
		{
			output.WriteRawTag(66);
			output.WriteMessage(TimerOperation);
		}
		if (requestCase_ == RequestOneofCase.PutTimerOperation)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PutTimerOperation);
		}
		if (requestCase_ == RequestOneofCase.TimerIncrement)
		{
			output.WriteRawTag(82);
			output.WriteMessage(TimerIncrement);
		}
		if (requestCase_ == RequestOneofCase.SystemTime)
		{
			output.WriteRawTag(90);
			output.WriteMessage(SystemTime);
		}
		if (requestCase_ == RequestOneofCase.VideoCountdown)
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
		if (requestCase_ == RequestOneofCase.Timers)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Timers);
		}
		if (requestCase_ == RequestOneofCase.CreateTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateTimer);
		}
		if (requestCase_ == RequestOneofCase.CurrentTimes)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CurrentTimes);
		}
		if (requestCase_ == RequestOneofCase.AllTimersOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AllTimersOperation);
		}
		if (requestCase_ == RequestOneofCase.GetTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetTimer);
		}
		if (requestCase_ == RequestOneofCase.PutTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutTimer);
		}
		if (requestCase_ == RequestOneofCase.DeleteTimer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteTimer);
		}
		if (requestCase_ == RequestOneofCase.TimerOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimerOperation);
		}
		if (requestCase_ == RequestOneofCase.PutTimerOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutTimerOperation);
		}
		if (requestCase_ == RequestOneofCase.TimerIncrement)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimerIncrement);
		}
		if (requestCase_ == RequestOneofCase.SystemTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SystemTime);
		}
		if (requestCase_ == RequestOneofCase.VideoCountdown)
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
	public void MergeFrom(API_v1_Timer_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Timers:
			if (Timers == null)
			{
				Timers = new Types.Timers();
			}
			Timers.MergeFrom(other.Timers);
			break;
		case RequestOneofCase.CreateTimer:
			if (CreateTimer == null)
			{
				CreateTimer = new Types.CreateTimer();
			}
			CreateTimer.MergeFrom(other.CreateTimer);
			break;
		case RequestOneofCase.CurrentTimes:
			if (CurrentTimes == null)
			{
				CurrentTimes = new Types.CurrentTimes();
			}
			CurrentTimes.MergeFrom(other.CurrentTimes);
			break;
		case RequestOneofCase.AllTimersOperation:
			if (AllTimersOperation == null)
			{
				AllTimersOperation = new Types.AllTimersOperation();
			}
			AllTimersOperation.MergeFrom(other.AllTimersOperation);
			break;
		case RequestOneofCase.GetTimer:
			if (GetTimer == null)
			{
				GetTimer = new Types.GetTimer();
			}
			GetTimer.MergeFrom(other.GetTimer);
			break;
		case RequestOneofCase.PutTimer:
			if (PutTimer == null)
			{
				PutTimer = new Types.PutTimer();
			}
			PutTimer.MergeFrom(other.PutTimer);
			break;
		case RequestOneofCase.DeleteTimer:
			if (DeleteTimer == null)
			{
				DeleteTimer = new Types.DeleteTimer();
			}
			DeleteTimer.MergeFrom(other.DeleteTimer);
			break;
		case RequestOneofCase.TimerOperation:
			if (TimerOperation == null)
			{
				TimerOperation = new Types.TimerOperation();
			}
			TimerOperation.MergeFrom(other.TimerOperation);
			break;
		case RequestOneofCase.PutTimerOperation:
			if (PutTimerOperation == null)
			{
				PutTimerOperation = new Types.PutTimerOperation();
			}
			PutTimerOperation.MergeFrom(other.PutTimerOperation);
			break;
		case RequestOneofCase.TimerIncrement:
			if (TimerIncrement == null)
			{
				TimerIncrement = new Types.TimerIncrement();
			}
			TimerIncrement.MergeFrom(other.TimerIncrement);
			break;
		case RequestOneofCase.SystemTime:
			if (SystemTime == null)
			{
				SystemTime = new Types.SystemTime();
			}
			SystemTime.MergeFrom(other.SystemTime);
			break;
		case RequestOneofCase.VideoCountdown:
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
				if (requestCase_ == RequestOneofCase.Timers)
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
				if (requestCase_ == RequestOneofCase.CreateTimer)
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
				if (requestCase_ == RequestOneofCase.CurrentTimes)
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
				if (requestCase_ == RequestOneofCase.AllTimersOperation)
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
				if (requestCase_ == RequestOneofCase.GetTimer)
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
				if (requestCase_ == RequestOneofCase.PutTimer)
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
				if (requestCase_ == RequestOneofCase.DeleteTimer)
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
				if (requestCase_ == RequestOneofCase.TimerOperation)
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
				if (requestCase_ == RequestOneofCase.PutTimerOperation)
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
				if (requestCase_ == RequestOneofCase.TimerIncrement)
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
				if (requestCase_ == RequestOneofCase.SystemTime)
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
				if (requestCase_ == RequestOneofCase.VideoCountdown)
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
