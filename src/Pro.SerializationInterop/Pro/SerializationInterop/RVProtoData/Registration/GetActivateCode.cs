using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class GetActivateCode : IMessage<GetActivateCode>, IMessage, IEquatable<GetActivateCode>, IDeepCloneable<GetActivateCode>
{
	private static readonly MessageParser<GetActivateCode> _parser = new MessageParser<GetActivateCode>(() => new GetActivateCode());

	private UnknownFieldSet _unknownFields;

	public const int SeatBucketIdFieldNumber = 1;

	private string seatBucketId_ = "";

	public const int OrganizationUuidFieldNumber = 2;

	private string organizationUuid_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<GetActivateCode> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[19];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string SeatBucketId
	{
		get
		{
			return seatBucketId_;
		}
		set
		{
			seatBucketId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string OrganizationUuid
	{
		get
		{
			return organizationUuid_;
		}
		set
		{
			organizationUuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetActivateCode()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetActivateCode(GetActivateCode other)
		: this()
	{
		seatBucketId_ = other.seatBucketId_;
		organizationUuid_ = other.organizationUuid_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetActivateCode Clone()
	{
		return new GetActivateCode(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as GetActivateCode);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(GetActivateCode other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (SeatBucketId != other.SeatBucketId)
		{
			return false;
		}
		if (OrganizationUuid != other.OrganizationUuid)
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
		if (SeatBucketId.Length != 0)
		{
			num ^= SeatBucketId.GetHashCode();
		}
		if (OrganizationUuid.Length != 0)
		{
			num ^= OrganizationUuid.GetHashCode();
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
		if (SeatBucketId.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(SeatBucketId);
		}
		if (OrganizationUuid.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(OrganizationUuid);
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
		if (SeatBucketId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(SeatBucketId);
		}
		if (OrganizationUuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(OrganizationUuid);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(GetActivateCode other)
	{
		if (other != null)
		{
			if (other.SeatBucketId.Length != 0)
			{
				SeatBucketId = other.SeatBucketId;
			}
			if (other.OrganizationUuid.Length != 0)
			{
				OrganizationUuid = other.OrganizationUuid;
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
				SeatBucketId = input.ReadString();
				break;
			case 18u:
				OrganizationUuid = input.ReadString();
				break;
			}
		}
	}
}
