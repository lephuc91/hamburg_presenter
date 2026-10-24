using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ClearGroupsChangeIcon : IMessage<ClearGroupsChangeIcon>, IMessage, IEquatable<ClearGroupsChangeIcon>, IDeepCloneable<ClearGroupsChangeIcon>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum IconType
		{
			[OriginalName("ICON_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("DEFAULT")]
			Default,
			[OriginalName("CUSTOM")]
			Custom
		}
	}

	private static readonly MessageParser<ClearGroupsChangeIcon> _parser = new MessageParser<ClearGroupsChangeIcon>(() => new ClearGroupsChangeIcon());

	private UnknownFieldSet _unknownFields;

	public const int IconTypeFieldNumber = 1;

	private Types.IconType iconType_;

	public const int IsTintedFieldNumber = 2;

	private bool isTinted_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ClearGroupsChangeIcon> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[63];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IconType IconType
	{
		get
		{
			return iconType_;
		}
		set
		{
			iconType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsTinted
	{
		get
		{
			return isTinted_;
		}
		set
		{
			isTinted_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeIcon()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeIcon(ClearGroupsChangeIcon other)
		: this()
	{
		iconType_ = other.iconType_;
		isTinted_ = other.isTinted_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClearGroupsChangeIcon Clone()
	{
		return new ClearGroupsChangeIcon(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ClearGroupsChangeIcon);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ClearGroupsChangeIcon other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (IconType != other.IconType)
		{
			return false;
		}
		if (IsTinted != other.IsTinted)
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
		if (IconType != 0)
		{
			num ^= IconType.GetHashCode();
		}
		if (IsTinted)
		{
			num ^= IsTinted.GetHashCode();
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
		if (IconType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)IconType);
		}
		if (IsTinted)
		{
			output.WriteRawTag(16);
			output.WriteBool(IsTinted);
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
		if (IconType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)IconType);
		}
		if (IsTinted)
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
	public void MergeFrom(ClearGroupsChangeIcon other)
	{
		if (other != null)
		{
			if (other.IconType != 0)
			{
				IconType = other.IconType;
			}
			if (other.IsTinted)
			{
				IsTinted = other.IsTinted;
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
				IconType = (Types.IconType)input.ReadEnum();
				break;
			case 16u:
				IsTinted = input.ReadBool();
				break;
			}
		}
	}
}
