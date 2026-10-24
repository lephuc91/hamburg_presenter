using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ClearGroup : IMessage<ClearGroup>, IMessage, IEquatable<ClearGroup>, IDeepCloneable<ClearGroup>
{
	private static readonly MessageParser<ClearGroup> _parser = new MessageParser<ClearGroup>(() => new ClearGroup());

	private UnknownFieldSet _unknownFields;

	public const int ClearGroupCountFieldNumber = 1;

	private int clearGroupCount_;

	public const int HiddenClearGroupCountFieldNumber = 2;

	private int hiddenClearGroupCount_;

	public const int DefaultIconCountFieldNumber = 3;

	private int defaultIconCount_;

	public const int CustomIconCountFieldNumber = 4;

	private int customIconCount_;

	public const int IconTintCountFieldNumber = 5;

	private int iconTintCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ClearGroup> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[13];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ClearGroupCount
	{
		get
		{
			return clearGroupCount_;
		}
		set
		{
			clearGroupCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int HiddenClearGroupCount
	{
		get
		{
			return hiddenClearGroupCount_;
		}
		set
		{
			hiddenClearGroupCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int DefaultIconCount
	{
		get
		{
			return defaultIconCount_;
		}
		set
		{
			defaultIconCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CustomIconCount
	{
		get
		{
			return customIconCount_;
		}
		set
		{
			customIconCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int IconTintCount
	{
		get
		{
			return iconTintCount_;
		}
		set
		{
			iconTintCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroup()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroup(ClearGroup other)
		: this()
	{
		clearGroupCount_ = other.clearGroupCount_;
		hiddenClearGroupCount_ = other.hiddenClearGroupCount_;
		defaultIconCount_ = other.defaultIconCount_;
		customIconCount_ = other.customIconCount_;
		iconTintCount_ = other.iconTintCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroup Clone()
	{
		return new ClearGroup(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ClearGroup);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ClearGroup other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ClearGroupCount != other.ClearGroupCount)
		{
			return false;
		}
		if (HiddenClearGroupCount != other.HiddenClearGroupCount)
		{
			return false;
		}
		if (DefaultIconCount != other.DefaultIconCount)
		{
			return false;
		}
		if (CustomIconCount != other.CustomIconCount)
		{
			return false;
		}
		if (IconTintCount != other.IconTintCount)
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
		if (ClearGroupCount != 0)
		{
			num ^= ClearGroupCount.GetHashCode();
		}
		if (HiddenClearGroupCount != 0)
		{
			num ^= HiddenClearGroupCount.GetHashCode();
		}
		if (DefaultIconCount != 0)
		{
			num ^= DefaultIconCount.GetHashCode();
		}
		if (CustomIconCount != 0)
		{
			num ^= CustomIconCount.GetHashCode();
		}
		if (IconTintCount != 0)
		{
			num ^= IconTintCount.GetHashCode();
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
		if (ClearGroupCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(ClearGroupCount);
		}
		if (HiddenClearGroupCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(HiddenClearGroupCount);
		}
		if (DefaultIconCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(DefaultIconCount);
		}
		if (CustomIconCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(CustomIconCount);
		}
		if (IconTintCount != 0)
		{
			output.WriteRawTag(40);
			output.WriteInt32(IconTintCount);
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
		if (ClearGroupCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ClearGroupCount);
		}
		if (HiddenClearGroupCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(HiddenClearGroupCount);
		}
		if (DefaultIconCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(DefaultIconCount);
		}
		if (CustomIconCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(CustomIconCount);
		}
		if (IconTintCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(IconTintCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ClearGroup other)
	{
		if (other != null)
		{
			if (other.ClearGroupCount != 0)
			{
				ClearGroupCount = other.ClearGroupCount;
			}
			if (other.HiddenClearGroupCount != 0)
			{
				HiddenClearGroupCount = other.HiddenClearGroupCount;
			}
			if (other.DefaultIconCount != 0)
			{
				DefaultIconCount = other.DefaultIconCount;
			}
			if (other.CustomIconCount != 0)
			{
				CustomIconCount = other.CustomIconCount;
			}
			if (other.IconTintCount != 0)
			{
				IconTintCount = other.IconTintCount;
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
				ClearGroupCount = input.ReadInt32();
				break;
			case 16u:
				HiddenClearGroupCount = input.ReadInt32();
				break;
			case 24u:
				DefaultIconCount = input.ReadInt32();
				break;
			case 32u:
				CustomIconCount = input.ReadInt32();
				break;
			case 40u:
				IconTintCount = input.ReadInt32();
				break;
			}
		}
	}
}
