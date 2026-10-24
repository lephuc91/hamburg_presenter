using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DuplicateMediaReference : IMessage<DuplicateMediaReference>, IMessage, IEquatable<DuplicateMediaReference>, IDeepCloneable<DuplicateMediaReference>
{
	private static readonly MessageParser<DuplicateMediaReference> _parser = new MessageParser<DuplicateMediaReference>(() => new DuplicateMediaReference());

	private UnknownFieldSet _unknownFields;

	public const int SourceUuidFieldNumber = 1;

	private string sourceUuid_ = "";

	public const int DestUuidFieldNumber = 2;

	private string destUuid_ = "";

	public const int PriorityFieldNumber = 3;

	private Priority priority_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DuplicateMediaReference> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[13];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string SourceUuid
	{
		get
		{
			return sourceUuid_;
		}
		set
		{
			sourceUuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DestUuid
	{
		get
		{
			return destUuid_;
		}
		set
		{
			destUuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Priority Priority
	{
		get
		{
			return priority_;
		}
		set
		{
			priority_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference(DuplicateMediaReference other)
		: this()
	{
		sourceUuid_ = other.sourceUuid_;
		destUuid_ = other.destUuid_;
		priority_ = other.priority_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference Clone()
	{
		return new DuplicateMediaReference(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DuplicateMediaReference);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DuplicateMediaReference other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (SourceUuid != other.SourceUuid)
		{
			return false;
		}
		if (DestUuid != other.DestUuid)
		{
			return false;
		}
		if (Priority != other.Priority)
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
		if (SourceUuid.Length != 0)
		{
			num ^= SourceUuid.GetHashCode();
		}
		if (DestUuid.Length != 0)
		{
			num ^= DestUuid.GetHashCode();
		}
		if (Priority != 0)
		{
			num ^= Priority.GetHashCode();
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
		if (SourceUuid.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(SourceUuid);
		}
		if (DestUuid.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(DestUuid);
		}
		if (Priority != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Priority);
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
		if (SourceUuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(SourceUuid);
		}
		if (DestUuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DestUuid);
		}
		if (Priority != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Priority);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(DuplicateMediaReference other)
	{
		if (other != null)
		{
			if (other.SourceUuid.Length != 0)
			{
				SourceUuid = other.SourceUuid;
			}
			if (other.DestUuid.Length != 0)
			{
				DestUuid = other.DestUuid;
			}
			if (other.Priority != 0)
			{
				Priority = other.Priority;
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
				SourceUuid = input.ReadString();
				break;
			case 18u:
				DestUuid = input.ReadString();
				break;
			case 24u:
				Priority = (Priority)input.ReadEnum();
				break;
			}
		}
	}
}
