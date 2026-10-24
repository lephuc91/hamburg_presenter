using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TextInspectorUnderlineColor : IMessage<TextInspectorUnderlineColor>, IMessage, IEquatable<TextInspectorUnderlineColor>, IDeepCloneable<TextInspectorUnderlineColor>
{
	private static readonly MessageParser<TextInspectorUnderlineColor> _parser = new MessageParser<TextInspectorUnderlineColor>(() => new TextInspectorUnderlineColor());

	private UnknownFieldSet _unknownFields;

	public const int IsEnabledFieldNumber = 1;

	private bool isEnabled_;

	public const int SelectionModeFieldNumber = 2;

	private SelectionMode selectionMode_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TextInspectorUnderlineColor> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[51];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsEnabled
	{
		get
		{
			return isEnabled_;
		}
		set
		{
			isEnabled_ = value;
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
	public TextInspectorUnderlineColor()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorUnderlineColor(TextInspectorUnderlineColor other)
		: this()
	{
		isEnabled_ = other.isEnabled_;
		selectionMode_ = other.selectionMode_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextInspectorUnderlineColor Clone()
	{
		return new TextInspectorUnderlineColor(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TextInspectorUnderlineColor);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TextInspectorUnderlineColor other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (IsEnabled != other.IsEnabled)
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
		if (IsEnabled)
		{
			num ^= IsEnabled.GetHashCode();
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
		if (IsEnabled)
		{
			output.WriteRawTag(8);
			output.WriteBool(IsEnabled);
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
		if (IsEnabled)
		{
			num += 2;
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
	public void MergeFrom(TextInspectorUnderlineColor other)
	{
		if (other != null)
		{
			if (other.IsEnabled)
			{
				IsEnabled = other.IsEnabled;
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
				IsEnabled = input.ReadBool();
				break;
			case 16u:
				SelectionMode = (SelectionMode)input.ReadEnum();
				break;
			}
		}
	}
}
