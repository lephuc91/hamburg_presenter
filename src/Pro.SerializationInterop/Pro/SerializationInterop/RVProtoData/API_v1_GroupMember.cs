using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_GroupMember : IMessage<API_v1_GroupMember>, IMessage, IEquatable<API_v1_GroupMember>, IDeepCloneable<API_v1_GroupMember>
{
	private static readonly MessageParser<API_v1_GroupMember> _parser = new MessageParser<API_v1_GroupMember>(() => new API_v1_GroupMember());

	private UnknownFieldSet _unknownFields;

	public const int IpFieldNumber = 1;

	private string ip_ = "";

	public const int PortFieldNumber = 2;

	private uint port_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_GroupMember> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LinkReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Ip
	{
		get
		{
			return ip_;
		}
		set
		{
			ip_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Port
	{
		get
		{
			return port_;
		}
		set
		{
			port_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupMember()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupMember(API_v1_GroupMember other)
		: this()
	{
		ip_ = other.ip_;
		port_ = other.port_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupMember Clone()
	{
		return new API_v1_GroupMember(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_GroupMember);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_GroupMember other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Ip != other.Ip)
		{
			return false;
		}
		if (Port != other.Port)
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
		if (Ip.Length != 0)
		{
			num ^= Ip.GetHashCode();
		}
		if (Port != 0)
		{
			num ^= Port.GetHashCode();
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
		if (Ip.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Ip);
		}
		if (Port != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(Port);
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
		if (Ip.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Ip);
		}
		if (Port != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_GroupMember other)
	{
		if (other != null)
		{
			if (other.Ip.Length != 0)
			{
				Ip = other.Ip;
			}
			if (other.Port != 0)
			{
				Port = other.Port;
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
				Ip = input.ReadString();
				break;
			case 16u:
				Port = input.ReadUInt32();
				break;
			}
		}
	}
}
