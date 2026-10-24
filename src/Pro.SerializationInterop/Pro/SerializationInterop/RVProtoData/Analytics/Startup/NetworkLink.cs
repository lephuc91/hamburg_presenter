using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NetworkLink : IMessage<NetworkLink>, IMessage, IEquatable<NetworkLink>, IDeepCloneable<NetworkLink>
{
	private static readonly MessageParser<NetworkLink> _parser = new MessageParser<NetworkLink>(() => new NetworkLink());

	private UnknownFieldSet _unknownFields;

	public const int EnabledFieldNumber = 1;

	private bool enabled_;

	public const int MemberCountFieldNumber = 2;

	private uint memberCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NetworkLink> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[15];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Enabled
	{
		get
		{
			return enabled_;
		}
		set
		{
			enabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint MemberCount
	{
		get
		{
			return memberCount_;
		}
		set
		{
			memberCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLink()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLink(NetworkLink other)
		: this()
	{
		enabled_ = other.enabled_;
		memberCount_ = other.memberCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLink Clone()
	{
		return new NetworkLink(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NetworkLink);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NetworkLink other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Enabled != other.Enabled)
		{
			return false;
		}
		if (MemberCount != other.MemberCount)
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
		if (Enabled)
		{
			num ^= Enabled.GetHashCode();
		}
		if (MemberCount != 0)
		{
			num ^= MemberCount.GetHashCode();
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
		if (Enabled)
		{
			output.WriteRawTag(8);
			output.WriteBool(Enabled);
		}
		if (MemberCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(MemberCount);
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
		if (Enabled)
		{
			num += 2;
		}
		if (MemberCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(MemberCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(NetworkLink other)
	{
		if (other != null)
		{
			if (other.Enabled)
			{
				Enabled = other.Enabled;
			}
			if (other.MemberCount != 0)
			{
				MemberCount = other.MemberCount;
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
				Enabled = input.ReadBool();
				break;
			case 16u:
				MemberCount = input.ReadUInt32();
				break;
			}
		}
	}
}
