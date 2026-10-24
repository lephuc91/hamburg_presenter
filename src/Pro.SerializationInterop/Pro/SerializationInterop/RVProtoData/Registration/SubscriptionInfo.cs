using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SubscriptionInfo : IMessage<SubscriptionInfo>, IMessage, IEquatable<SubscriptionInfo>, IDeepCloneable<SubscriptionInfo>
{
	private static readonly MessageParser<SubscriptionInfo> _parser = new MessageParser<SubscriptionInfo>(() => new SubscriptionInfo());

	private UnknownFieldSet _unknownFields;

	public const int OrganizationNameFieldNumber = 1;

	private string organizationName_ = "";

	public const int ProcontentLicenseTypeFieldNumber = 2;

	private ProContentLicenseType procontentLicenseType_;

	public const int ProcontentLicenseExpirationFieldNumber = 3;

	private long procontentLicenseExpiration_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SubscriptionInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[56];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string OrganizationName
	{
		get
		{
			return organizationName_;
		}
		set
		{
			organizationName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProContentLicenseType ProcontentLicenseType
	{
		get
		{
			return procontentLicenseType_;
		}
		set
		{
			procontentLicenseType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long ProcontentLicenseExpiration
	{
		get
		{
			return procontentLicenseExpiration_;
		}
		set
		{
			procontentLicenseExpiration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SubscriptionInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SubscriptionInfo(SubscriptionInfo other)
		: this()
	{
		organizationName_ = other.organizationName_;
		procontentLicenseType_ = other.procontentLicenseType_;
		procontentLicenseExpiration_ = other.procontentLicenseExpiration_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SubscriptionInfo Clone()
	{
		return new SubscriptionInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SubscriptionInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SubscriptionInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (OrganizationName != other.OrganizationName)
		{
			return false;
		}
		if (ProcontentLicenseType != other.ProcontentLicenseType)
		{
			return false;
		}
		if (ProcontentLicenseExpiration != other.ProcontentLicenseExpiration)
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
		if (OrganizationName.Length != 0)
		{
			num ^= OrganizationName.GetHashCode();
		}
		if (ProcontentLicenseType != 0)
		{
			num ^= ProcontentLicenseType.GetHashCode();
		}
		if (ProcontentLicenseExpiration != 0L)
		{
			num ^= ProcontentLicenseExpiration.GetHashCode();
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
		if (OrganizationName.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(OrganizationName);
		}
		if (ProcontentLicenseType != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)ProcontentLicenseType);
		}
		if (ProcontentLicenseExpiration != 0L)
		{
			output.WriteRawTag(24);
			output.WriteInt64(ProcontentLicenseExpiration);
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
		if (OrganizationName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(OrganizationName);
		}
		if (ProcontentLicenseType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ProcontentLicenseType);
		}
		if (ProcontentLicenseExpiration != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(ProcontentLicenseExpiration);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SubscriptionInfo other)
	{
		if (other != null)
		{
			if (other.OrganizationName.Length != 0)
			{
				OrganizationName = other.OrganizationName;
			}
			if (other.ProcontentLicenseType != 0)
			{
				ProcontentLicenseType = other.ProcontentLicenseType;
			}
			if (other.ProcontentLicenseExpiration != 0L)
			{
				ProcontentLicenseExpiration = other.ProcontentLicenseExpiration;
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
				OrganizationName = input.ReadString();
				break;
			case 16u:
				ProcontentLicenseType = (ProContentLicenseType)input.ReadEnum();
				break;
			case 24u:
				ProcontentLicenseExpiration = input.ReadInt64();
				break;
			}
		}
	}
}
