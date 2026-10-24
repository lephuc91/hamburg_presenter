using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SetClientInfo : IMessage<SetClientInfo>, IMessage, IEquatable<SetClientInfo>, IDeepCloneable<SetClientInfo>
{
	private static readonly MessageParser<SetClientInfo> _parser = new MessageParser<SetClientInfo>(() => new SetClientInfo());

	private UnknownFieldSet _unknownFields;

	public const int ClientIdFieldNumber = 1;

	private int clientId_;

	public const int ClientSecretFieldNumber = 2;

	private string clientSecret_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SetClientInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[39];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ClientId
	{
		get
		{
			return clientId_;
		}
		set
		{
			clientId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ClientSecret
	{
		get
		{
			return clientSecret_;
		}
		set
		{
			clientSecret_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetClientInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetClientInfo(SetClientInfo other)
		: this()
	{
		clientId_ = other.clientId_;
		clientSecret_ = other.clientSecret_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetClientInfo Clone()
	{
		return new SetClientInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SetClientInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SetClientInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ClientId != other.ClientId)
		{
			return false;
		}
		if (ClientSecret != other.ClientSecret)
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
		if (ClientId != 0)
		{
			num ^= ClientId.GetHashCode();
		}
		if (ClientSecret.Length != 0)
		{
			num ^= ClientSecret.GetHashCode();
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
		if (ClientId != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(ClientId);
		}
		if (ClientSecret.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(ClientSecret);
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
		if (ClientId != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ClientId);
		}
		if (ClientSecret.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ClientSecret);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SetClientInfo other)
	{
		if (other != null)
		{
			if (other.ClientId != 0)
			{
				ClientId = other.ClientId;
			}
			if (other.ClientSecret.Length != 0)
			{
				ClientSecret = other.ClientSecret;
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
				ClientId = input.ReadInt32();
				break;
			case 18u:
				ClientSecret = input.ReadString();
				break;
			}
		}
	}
}
