using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TextInspectorLineTransform : IMessage<TextInspectorLineTransform>, IMessage, IEquatable<TextInspectorLineTransform>, IDeepCloneable<TextInspectorLineTransform>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum TransformType
		{
			[OriginalName("TRANSFORM_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("NONE")]
			None,
			[OriginalName("REMOVE_LINE_RETURNS")]
			RemoveLineReturns,
			[OriginalName("REPLACE_LINE_RETURNS")]
			ReplaceLineReturns,
			[OriginalName("ONE_WORD_PER_LINE")]
			OneWordPerLine,
			[OriginalName("ONE_CHARACTER_PER_LINE")]
			OneCharacterPerLine
		}
	}

	private static readonly MessageParser<TextInspectorLineTransform> _parser = new MessageParser<TextInspectorLineTransform>(() => new TextInspectorLineTransform());

	private UnknownFieldSet _unknownFields;

	public const int TransformTypeFieldNumber = 1;

	private Types.TransformType transformType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TextInspectorLineTransform> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[53];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TransformType TransformType
	{
		get
		{
			return transformType_;
		}
		set
		{
			transformType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorLineTransform()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorLineTransform(TextInspectorLineTransform other)
		: this()
	{
		transformType_ = other.transformType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorLineTransform Clone()
	{
		return new TextInspectorLineTransform(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TextInspectorLineTransform);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TextInspectorLineTransform other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TransformType != other.TransformType)
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
		if (TransformType != 0)
		{
			num ^= TransformType.GetHashCode();
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
		if (TransformType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)TransformType);
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
		if (TransformType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)TransformType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TextInspectorLineTransform other)
	{
		if (other != null)
		{
			if (other.TransformType != 0)
			{
				TransformType = other.TransformType;
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
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				TransformType = (Types.TransformType)input.ReadEnum();
			}
		}
	}
}
