using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PropPauseResponse : IMessage<PropPauseResponse>, IMessage, IEquatable<PropPauseResponse>, IDeepCloneable<PropPauseResponse>
{
	public enum ResponseTypeOneofCase
	{
		None = 0,
		Status = 2
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Status : IMessage<Status>, IMessage, IEquatable<Status>, IDeepCloneable<Status>
		{
			private static readonly MessageParser<Status> _parser = new MessageParser<Status>(() => new Status());

			private UnknownFieldSet _unknownFields;

			public const int PausedFieldNumber = 1;

			private bool paused_;

			public const int TimeRemainingFieldNumber = 2;

			private double timeRemaining_;

			public const int PercentageCompleteFieldNumber = 3;

			private double percentageComplete_;

			public const int TotalTimeFieldNumber = 4;

			private double totalTime_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Status> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PropPauseResponse.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Paused
			{
				get
				{
					return paused_;
				}
				set
				{
					paused_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double TimeRemaining
			{
				get
				{
					return timeRemaining_;
				}
				set
				{
					timeRemaining_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double PercentageComplete
			{
				get
				{
					return percentageComplete_;
				}
				set
				{
					percentageComplete_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double TotalTime
			{
				get
				{
					return totalTime_;
				}
				set
				{
					totalTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status(Status other)
				: this()
			{
				paused_ = other.paused_;
				timeRemaining_ = other.timeRemaining_;
				percentageComplete_ = other.percentageComplete_;
				totalTime_ = other.totalTime_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status Clone()
			{
				return new Status(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Status);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Status other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Paused != other.Paused)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TimeRemaining, other.TimeRemaining))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(PercentageComplete, other.PercentageComplete))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TotalTime, other.TotalTime))
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
				if (Paused)
				{
					num ^= Paused.GetHashCode();
				}
				if (TimeRemaining != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TimeRemaining);
				}
				if (PercentageComplete != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(PercentageComplete);
				}
				if (TotalTime != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TotalTime);
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
				if (Paused)
				{
					output.WriteRawTag(8);
					output.WriteBool(Paused);
				}
				if (TimeRemaining != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(TimeRemaining);
				}
				if (PercentageComplete != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(PercentageComplete);
				}
				if (TotalTime != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(TotalTime);
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
				if (Paused)
				{
					num += 2;
				}
				if (TimeRemaining != 0.0)
				{
					num += 9;
				}
				if (PercentageComplete != 0.0)
				{
					num += 9;
				}
				if (TotalTime != 0.0)
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
			public void MergeFrom(Status other)
			{
				if (other != null)
				{
					if (other.Paused)
					{
						Paused = other.Paused;
					}
					if (other.TimeRemaining != 0.0)
					{
						TimeRemaining = other.TimeRemaining;
					}
					if (other.PercentageComplete != 0.0)
					{
						PercentageComplete = other.PercentageComplete;
					}
					if (other.TotalTime != 0.0)
					{
						TotalTime = other.TotalTime;
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
						Paused = input.ReadBool();
						break;
					case 17u:
						TimeRemaining = input.ReadDouble();
						break;
					case 25u:
						PercentageComplete = input.ReadDouble();
						break;
					case 33u:
						TotalTime = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<PropPauseResponse> _parser = new MessageParser<PropPauseResponse>(() => new PropPauseResponse());

	private UnknownFieldSet _unknownFields;

	public const int PropIdFieldNumber = 1;

	private UUID propId_;

	public const int StatusFieldNumber = 2;

	private object responseType_;

	private ResponseTypeOneofCase responseTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PropPauseResponse> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[27];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID PropId
	{
		get
		{
			return propId_;
		}
		set
		{
			propId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Status Status
	{
		get
		{
			if (responseTypeCase_ != ResponseTypeOneofCase.Status)
			{
				return null;
			}
			return (Types.Status)responseType_;
		}
		set
		{
			responseType_ = value;
			responseTypeCase_ = ((value != null) ? ResponseTypeOneofCase.Status : ResponseTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseTypeOneofCase ResponseTypeCase => responseTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropPauseResponse()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropPauseResponse(PropPauseResponse other)
		: this()
	{
		propId_ = ((other.propId_ != null) ? other.propId_.Clone() : null);
		if (other.ResponseTypeCase == ResponseTypeOneofCase.Status)
		{
			Status = other.Status.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropPauseResponse Clone()
	{
		return new PropPauseResponse(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponseType()
	{
		responseTypeCase_ = ResponseTypeOneofCase.None;
		responseType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PropPauseResponse);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PropPauseResponse other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(PropId, other.PropId))
		{
			return false;
		}
		if (!object.Equals(Status, other.Status))
		{
			return false;
		}
		if (ResponseTypeCase != other.ResponseTypeCase)
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
		if (propId_ != null)
		{
			num ^= PropId.GetHashCode();
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.Status)
		{
			num ^= Status.GetHashCode();
		}
		num ^= (int)responseTypeCase_;
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
		if (propId_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(PropId);
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.Status)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Status);
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
		if (propId_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PropId);
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.Status)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Status);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PropPauseResponse other)
	{
		if (other == null)
		{
			return;
		}
		if (other.propId_ != null)
		{
			if (propId_ == null)
			{
				PropId = new UUID();
			}
			PropId.MergeFrom(other.PropId);
		}
		if (other.ResponseTypeCase == ResponseTypeOneofCase.Status)
		{
			if (Status == null)
			{
				Status = new Types.Status();
			}
			Status.MergeFrom(other.Status);
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
				if (propId_ == null)
				{
					PropId = new UUID();
				}
				input.ReadMessage(PropId);
				break;
			case 18u:
			{
				Types.Status status = new Types.Status();
				if (responseTypeCase_ == ResponseTypeOneofCase.Status)
				{
					status.MergeFrom(Status);
				}
				input.ReadMessage(status);
				Status = status;
				break;
			}
			}
		}
	}
}
