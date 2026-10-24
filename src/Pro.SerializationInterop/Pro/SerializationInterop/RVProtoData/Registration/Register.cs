using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Register : IMessage<Register>, IMessage, IEquatable<Register>, IDeepCloneable<Register>
{
	private static readonly MessageParser<Register> _parser = new MessageParser<Register>(() => new Register());

	private UnknownFieldSet _unknownFields;

	public const int UserNameFieldNumber = 1;

	private string userName_ = "";

	public const int RegistrationKeyFieldNumber = 2;

	private string registrationKey_ = "";

	public const int DisplayNameFieldNumber = 3;

	private string displayName_ = "";

	public const int SeatTypeFieldNumber = 4;

	private SeatType seatType_;

	public const int ChannelFieldNumber = 5;

	private UpdateChannel channel_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Register> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string UserName
	{
		get
		{
			return userName_;
		}
		set
		{
			userName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string RegistrationKey
	{
		get
		{
			return registrationKey_;
		}
		set
		{
			registrationKey_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DisplayName
	{
		get
		{
			return displayName_;
		}
		set
		{
			displayName_ = ProtoPreconditions.CheckNotNull(value, "value");
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
	public Register()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Register(Register other)
		: this()
	{
		userName_ = other.userName_;
		registrationKey_ = other.registrationKey_;
		displayName_ = other.displayName_;
		seatType_ = other.seatType_;
		channel_ = other.channel_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Register Clone()
	{
		return new Register(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Register);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Register other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (UserName != other.UserName)
		{
			return false;
		}
		if (RegistrationKey != other.RegistrationKey)
		{
			return false;
		}
		if (DisplayName != other.DisplayName)
		{
			return false;
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
		if (UserName.Length != 0)
		{
			num ^= UserName.GetHashCode();
		}
		if (RegistrationKey.Length != 0)
		{
			num ^= RegistrationKey.GetHashCode();
		}
		if (DisplayName.Length != 0)
		{
			num ^= DisplayName.GetHashCode();
		}
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
		if (UserName.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(UserName);
		}
		if (RegistrationKey.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(RegistrationKey);
		}
		if (DisplayName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(DisplayName);
		}
		if (SeatType != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)SeatType);
		}
		if (Channel != 0)
		{
			output.WriteRawTag(40);
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
		if (UserName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(UserName);
		}
		if (RegistrationKey.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RegistrationKey);
		}
		if (DisplayName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DisplayName);
		}
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
	public void MergeFrom(Register other)
	{
		if (other != null)
		{
			if (other.UserName.Length != 0)
			{
				UserName = other.UserName;
			}
			if (other.RegistrationKey.Length != 0)
			{
				RegistrationKey = other.RegistrationKey;
			}
			if (other.DisplayName.Length != 0)
			{
				DisplayName = other.DisplayName;
			}
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
			case 10u:
				UserName = input.ReadString();
				break;
			case 18u:
				RegistrationKey = input.ReadString();
				break;
			case 26u:
				DisplayName = input.ReadString();
				break;
			case 32u:
				SeatType = (SeatType)input.ReadEnum();
				break;
			case 40u:
				Channel = (UpdateChannel)input.ReadEnum();
				break;
			}
		}
	}
}
