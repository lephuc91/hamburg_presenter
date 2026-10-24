using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TextInspectorForeground : IMessage<TextInspectorForeground>, IMessage, IEquatable<TextInspectorForeground>, IDeepCloneable<TextInspectorForeground>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum FillType
		{
			[OriginalName("FILL_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("SOLID")]
			Solid,
			[OriginalName("GRADIENT")]
			Gradient
		}
	}

	private static readonly MessageParser<TextInspectorForeground> _parser = new MessageParser<TextInspectorForeground>(() => new TextInspectorForeground());

	private UnknownFieldSet _unknownFields;

	public const int FillTypeFieldNumber = 1;

	private Types.FillType fillType_;

	public const int SelectionModeFieldNumber = 2;

	private SelectionMode selectionMode_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TextInspectorForeground> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[50];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FillType FillType
	{
		get
		{
			return fillType_;
		}
		set
		{
			fillType_ = value;
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
	public TextInspectorForeground()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorForeground(TextInspectorForeground other)
		: this()
	{
		fillType_ = other.fillType_;
		selectionMode_ = other.selectionMode_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorForeground Clone()
	{
		return new TextInspectorForeground(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TextInspectorForeground);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TextInspectorForeground other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (FillType != other.FillType)
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
		if (FillType != 0)
		{
			num ^= FillType.GetHashCode();
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
		if (FillType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)FillType);
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
		if (FillType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)FillType);
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
	public void MergeFrom(TextInspectorForeground other)
	{
		if (other != null)
		{
			if (other.FillType != 0)
			{
				FillType = other.FillType;
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
				FillType = (Types.FillType)input.ReadEnum();
				break;
			case 16u:
				SelectionMode = (SelectionMode)input.ReadEnum();
				break;
			}
		}
	}
}
