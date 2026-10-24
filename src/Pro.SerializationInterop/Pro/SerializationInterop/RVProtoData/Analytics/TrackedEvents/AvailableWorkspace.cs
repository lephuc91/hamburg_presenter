using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AvailableWorkspace : IMessage<AvailableWorkspace>, IMessage, IEquatable<AvailableWorkspace>, IDeepCloneable<AvailableWorkspace>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum WorkspaceType
		{
			[OriginalName("LOCAL")]
			Local,
			[OriginalName("CLOUD_UNDOWNLOADED")]
			CloudUndownloaded,
			[OriginalName("CLOUD_DOWNLOADED")]
			CloudDownloaded
		}
	}

	private static readonly MessageParser<AvailableWorkspace> _parser = new MessageParser<AvailableWorkspace>(() => new AvailableWorkspace());

	private UnknownFieldSet _unknownFields;

	public const int TypeFieldNumber = 1;

	private Types.WorkspaceType type_;

	public const int SizeInBytesFieldNumber = 2;

	private ulong sizeInBytes_;

	public const int IsCurrentFieldNumber = 3;

	private bool isCurrent_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AvailableWorkspace> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[37];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.WorkspaceType Type
	{
		get
		{
			return type_;
		}
		set
		{
			type_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong SizeInBytes
	{
		get
		{
			return sizeInBytes_;
		}
		set
		{
			sizeInBytes_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsCurrent
	{
		get
		{
			return isCurrent_;
		}
		set
		{
			isCurrent_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AvailableWorkspace()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AvailableWorkspace(AvailableWorkspace other)
		: this()
	{
		type_ = other.type_;
		sizeInBytes_ = other.sizeInBytes_;
		isCurrent_ = other.isCurrent_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AvailableWorkspace Clone()
	{
		return new AvailableWorkspace(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AvailableWorkspace);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AvailableWorkspace other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (SizeInBytes != other.SizeInBytes)
		{
			return false;
		}
		if (IsCurrent != other.IsCurrent)
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
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (SizeInBytes != 0L)
		{
			num ^= SizeInBytes.GetHashCode();
		}
		if (IsCurrent)
		{
			num ^= IsCurrent.GetHashCode();
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
		if (Type != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Type);
		}
		if (SizeInBytes != 0L)
		{
			output.WriteRawTag(16);
			output.WriteUInt64(SizeInBytes);
		}
		if (IsCurrent)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsCurrent);
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
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (SizeInBytes != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(SizeInBytes);
		}
		if (IsCurrent)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AvailableWorkspace other)
	{
		if (other != null)
		{
			if (other.Type != 0)
			{
				Type = other.Type;
			}
			if (other.SizeInBytes != 0L)
			{
				SizeInBytes = other.SizeInBytes;
			}
			if (other.IsCurrent)
			{
				IsCurrent = other.IsCurrent;
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
				Type = (Types.WorkspaceType)input.ReadEnum();
				break;
			case 16u:
				SizeInBytes = input.ReadUInt64();
				break;
			case 24u:
				IsCurrent = input.ReadBool();
				break;
			}
		}
	}
}
