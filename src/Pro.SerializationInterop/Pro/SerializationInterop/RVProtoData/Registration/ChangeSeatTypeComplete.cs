using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ChangeSeatTypeComplete : IMessage<ChangeSeatTypeComplete>, IMessage, IEquatable<ChangeSeatTypeComplete>, IDeepCloneable<ChangeSeatTypeComplete>
{
	private static readonly MessageParser<ChangeSeatTypeComplete> _parser = new MessageParser<ChangeSeatTypeComplete>(() => new ChangeSeatTypeComplete());

	private UnknownFieldSet _unknownFields;

	public const int ResultFieldNumber = 1;

	private Status result_;

	public const int AvailableSeatsFieldNumber = 2;

	private Seats availableSeats_;

	public const int TotalSeatsFieldNumber = 3;

	private Seats totalSeats_;

	public const int SeatTypeFieldNumber = 4;

	private SeatType seatType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ChangeSeatTypeComplete> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[26];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Status Result
	{
		get
		{
			return result_;
		}
		set
		{
			result_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Seats AvailableSeats
	{
		get
		{
			return availableSeats_;
		}
		set
		{
			availableSeats_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Seats TotalSeats
	{
		get
		{
			return totalSeats_;
		}
		set
		{
			totalSeats_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SeatType SeatType
	{
		get
		{
			return seatType_;
		}
		set
		{
			seatType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeSeatTypeComplete()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeSeatTypeComplete(ChangeSeatTypeComplete other)
		: this()
	{
		result_ = other.result_;
		availableSeats_ = ((other.availableSeats_ != null) ? other.availableSeats_.Clone() : null);
		totalSeats_ = ((other.totalSeats_ != null) ? other.totalSeats_.Clone() : null);
		seatType_ = other.seatType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeSeatTypeComplete Clone()
	{
		return new ChangeSeatTypeComplete(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ChangeSeatTypeComplete);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ChangeSeatTypeComplete other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Result != other.Result)
		{
			return false;
		}
		if (!object.Equals(AvailableSeats, other.AvailableSeats))
		{
			return false;
		}
		if (!object.Equals(TotalSeats, other.TotalSeats))
		{
			return false;
		}
		if (SeatType != other.SeatType)
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
		if (Result != 0)
		{
			num ^= Result.GetHashCode();
		}
		if (availableSeats_ != null)
		{
			num ^= AvailableSeats.GetHashCode();
		}
		if (totalSeats_ != null)
		{
			num ^= TotalSeats.GetHashCode();
		}
		if (SeatType != 0)
		{
			num ^= SeatType.GetHashCode();
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
		if (Result != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Result);
		}
		if (availableSeats_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(AvailableSeats);
		}
		if (totalSeats_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(TotalSeats);
		}
		if (SeatType != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)SeatType);
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
		if (Result != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Result);
		}
		if (availableSeats_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AvailableSeats);
		}
		if (totalSeats_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TotalSeats);
		}
		if (SeatType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SeatType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ChangeSeatTypeComplete other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Result != 0)
		{
			Result = other.Result;
		}
		if (other.availableSeats_ != null)
		{
			if (availableSeats_ == null)
			{
				AvailableSeats = new Seats();
			}
			AvailableSeats.MergeFrom(other.AvailableSeats);
		}
		if (other.totalSeats_ != null)
		{
			if (totalSeats_ == null)
			{
				TotalSeats = new Seats();
			}
			TotalSeats.MergeFrom(other.TotalSeats);
		}
		if (other.SeatType != 0)
		{
			SeatType = other.SeatType;
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
			case 8u:
				Result = (Status)input.ReadEnum();
				break;
			case 18u:
				if (availableSeats_ == null)
				{
					AvailableSeats = new Seats();
				}
				input.ReadMessage(AvailableSeats);
				break;
			case 26u:
				if (totalSeats_ == null)
				{
					TotalSeats = new Seats();
				}
				input.ReadMessage(TotalSeats);
				break;
			case 32u:
				SeatType = (SeatType)input.ReadEnum();
				break;
			}
		}
	}
}
