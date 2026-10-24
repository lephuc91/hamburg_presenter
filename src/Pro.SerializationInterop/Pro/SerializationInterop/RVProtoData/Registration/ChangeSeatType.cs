using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ChangeSeatType : IMessage<ChangeSeatType>, IMessage, IEquatable<ChangeSeatType>, IDeepCloneable<ChangeSeatType>
{
	private static readonly MessageParser<ChangeSeatType> _parser = new MessageParser<ChangeSeatType>(() => new ChangeSeatType());

	private UnknownFieldSet _unknownFields;

	public const int SeatTypeFieldNumber = 1;

	private SeatType seatType_;

	public const int ChannelFieldNumber = 2;

	private UpdateChannel channel_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ChangeSeatType> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public UpdateChannel Channel
	{
		get
		{
			return channel_;
		}
		set
		{
			channel_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeSeatType()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeSeatType(ChangeSeatType other)
		: this()
	{
		seatType_ = other.seatType_;
		channel_ = other.channel_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeSeatType Clone()
	{
		return new ChangeSeatType(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ChangeSeatType);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ChangeSeatType other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (SeatType != other.SeatType)
		{
			return false;
		}
		if (Channel != other.Channel)
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
		if (SeatType != 0)
		{
			num ^= SeatType.GetHashCode();
		}
		if (Channel != 0)
		{
			num ^= Channel.GetHashCode();
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
		if (SeatType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)SeatType);
		}
		if (Channel != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Channel);
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
		if (SeatType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SeatType);
		}
		if (Channel != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Channel);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ChangeSeatType other)
	{
		if (other != null)
		{
			if (other.SeatType != 0)
			{
				SeatType = other.SeatType;
			}
			if (other.Channel != 0)
			{
				Channel = other.Channel;
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
				SeatType = (SeatType)input.ReadEnum();
				break;
			case 16u:
				Channel = (UpdateChannel)input.ReadEnum();
				break;
			}
		}
	}
}
