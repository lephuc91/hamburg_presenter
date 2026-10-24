using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RegistrationData : IMessage<RegistrationData>, IMessage, IEquatable<RegistrationData>, IDeepCloneable<RegistrationData>
{
	private static readonly MessageParser<RegistrationData> _parser = new MessageParser<RegistrationData>(() => new RegistrationData());

	private UnknownFieldSet _unknownFields;

	public const int DataFieldNumber = 1;

	private ByteString data_ = ByteString.Empty;

	public const int ChannelFieldNumber = 2;

	private UpdateChannel channel_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RegistrationData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[11];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ByteString Data
	{
		get
		{
			return data_;
		}
		set
		{
			data_ = ProtoPreconditions.CheckNotNull(value, "value");
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
	public RegistrationData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationData(RegistrationData other)
		: this()
	{
		data_ = other.data_;
		channel_ = other.channel_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationData Clone()
	{
		return new RegistrationData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RegistrationData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RegistrationData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Data != other.Data)
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
		if (Data.Length != 0)
		{
			num ^= Data.GetHashCode();
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
		if (Data.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteBytes(Data);
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
		if (Data.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeBytesSize(Data);
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
	public void MergeFrom(RegistrationData other)
	{
		if (other != null)
		{
			if (other.Data.Length != 0)
			{
				Data = other.Data;
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
				Data = input.ReadBytes();
				break;
			case 16u:
				Channel = (UpdateChannel)input.ReadEnum();
				break;
			}
		}
	}
}
