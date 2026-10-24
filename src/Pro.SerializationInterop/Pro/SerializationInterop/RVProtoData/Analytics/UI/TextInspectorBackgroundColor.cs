using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TextInspectorBackgroundColor : IMessage<TextInspectorBackgroundColor>, IMessage, IEquatable<TextInspectorBackgroundColor>, IDeepCloneable<TextInspectorBackgroundColor>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ColorType
		{
			[OriginalName("COLOR_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("CLEAR")]
			Clear,
			[OriginalName("OTHER")]
			Other
		}
	}

	private static readonly MessageParser<TextInspectorBackgroundColor> _parser = new MessageParser<TextInspectorBackgroundColor>(() => new TextInspectorBackgroundColor());

	private UnknownFieldSet _unknownFields;

	public const int ColorTypeFieldNumber = 1;

	private Types.ColorType colorType_;

	public const int SelectionModeFieldNumber = 2;

	private SelectionMode selectionMode_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TextInspectorBackgroundColor> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[52];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ColorType ColorType
	{
		get
		{
			return colorType_;
		}
		set
		{
			colorType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SelectionMode SelectionMode
	{
		get
		{
			return selectionMode_;
		}
		set
		{
			selectionMode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorBackgroundColor()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorBackgroundColor(TextInspectorBackgroundColor other)
		: this()
	{
		colorType_ = other.colorType_;
		selectionMode_ = other.selectionMode_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorBackgroundColor Clone()
	{
		return new TextInspectorBackgroundColor(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TextInspectorBackgroundColor);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TextInspectorBackgroundColor other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ColorType != other.ColorType)
		{
			return false;
		}
		if (SelectionMode != other.SelectionMode)
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
		if (ColorType != 0)
		{
			num ^= ColorType.GetHashCode();
		}
		if (SelectionMode != 0)
		{
			num ^= SelectionMode.GetHashCode();
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
		if (ColorType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ColorType);
		}
		if (SelectionMode != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)SelectionMode);
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
		if (ColorType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ColorType);
		}
		if (SelectionMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SelectionMode);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TextInspectorBackgroundColor other)
	{
		if (other != null)
		{
			if (other.ColorType != 0)
			{
				ColorType = other.ColorType;
			}
			if (other.SelectionMode != 0)
			{
				SelectionMode = other.SelectionMode;
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
				ColorType = (Types.ColorType)input.ReadEnum();
				break;
			case 16u:
				SelectionMode = (SelectionMode)input.ReadEnum();
				break;
			}
		}
	}
}
