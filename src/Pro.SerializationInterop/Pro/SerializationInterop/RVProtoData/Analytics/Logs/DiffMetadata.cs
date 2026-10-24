using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DiffMetadata : IMessage<DiffMetadata>, IMessage, IEquatable<DiffMetadata>, IDeepCloneable<DiffMetadata>
{
	private static readonly MessageParser<DiffMetadata> _parser = new MessageParser<DiffMetadata>(() => new DiffMetadata());

	private UnknownFieldSet _unknownFields;

	public const int ChangeNumFieldNumber = 1;

	private uint changeNum_;

	public const int PartialStartVvFieldNumber = 2;

	private string partialStartVv_ = "";

	public const int PartialEndVvFieldNumber = 3;

	private string partialEndVv_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DiffMetadata> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[19];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint ChangeNum
	{
		get
		{
			return changeNum_;
		}
		set
		{
			changeNum_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PartialStartVv
	{
		get
		{
			return partialStartVv_;
		}
		set
		{
			partialStartVv_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PartialEndVv
	{
		get
		{
			return partialEndVv_;
		}
		set
		{
			partialEndVv_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiffMetadata()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiffMetadata(DiffMetadata other)
		: this()
	{
		changeNum_ = other.changeNum_;
		partialStartVv_ = other.partialStartVv_;
		partialEndVv_ = other.partialEndVv_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiffMetadata Clone()
	{
		return new DiffMetadata(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DiffMetadata);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DiffMetadata other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ChangeNum != other.ChangeNum)
		{
			return false;
		}
		if (PartialStartVv != other.PartialStartVv)
		{
			return false;
		}
		if (PartialEndVv != other.PartialEndVv)
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
		if (ChangeNum != 0)
		{
			num ^= ChangeNum.GetHashCode();
		}
		if (PartialStartVv.Length != 0)
		{
			num ^= PartialStartVv.GetHashCode();
		}
		if (PartialEndVv.Length != 0)
		{
			num ^= PartialEndVv.GetHashCode();
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
		if (ChangeNum != 0)
		{
			output.WriteRawTag(8);
			output.WriteUInt32(ChangeNum);
		}
		if (PartialStartVv.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(PartialStartVv);
		}
		if (PartialEndVv.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(PartialEndVv);
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
		if (ChangeNum != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(ChangeNum);
		}
		if (PartialStartVv.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PartialStartVv);
		}
		if (PartialEndVv.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PartialEndVv);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(DiffMetadata other)
	{
		if (other != null)
		{
			if (other.ChangeNum != 0)
			{
				ChangeNum = other.ChangeNum;
			}
			if (other.PartialStartVv.Length != 0)
			{
				PartialStartVv = other.PartialStartVv;
			}
			if (other.PartialEndVv.Length != 0)
			{
				PartialEndVv = other.PartialEndVv;
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
				ChangeNum = input.ReadUInt32();
				break;
			case 18u:
				PartialStartVv = input.ReadString();
				break;
			case 26u:
				PartialEndVv = input.ReadString();
				break;
			}
		}
	}
}
