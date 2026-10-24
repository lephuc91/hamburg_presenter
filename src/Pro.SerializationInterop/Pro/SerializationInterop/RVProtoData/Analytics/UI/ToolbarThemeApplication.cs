using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ToolbarThemeApplication : IMessage<ToolbarThemeApplication>, IMessage, IEquatable<ToolbarThemeApplication>, IDeepCloneable<ToolbarThemeApplication>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Target
		{
			[OriginalName("TARGET_UNKNOWN")]
			Unknown,
			[OriginalName("SLIDE_SELECTION")]
			SlideSelection,
			[OriginalName("PRESENTATION_SELECTION")]
			PresentationSelection
		}
	}

	private static readonly MessageParser<ToolbarThemeApplication> _parser = new MessageParser<ToolbarThemeApplication>(() => new ToolbarThemeApplication());

	private UnknownFieldSet _unknownFields;

	public const int TargetFieldNumber = 1;

	private Types.Target target_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ToolbarThemeApplication> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Target Target
	{
		get
		{
			return target_;
		}
		set
		{
			target_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ToolbarThemeApplication()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ToolbarThemeApplication(ToolbarThemeApplication other)
		: this()
	{
		target_ = other.target_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ToolbarThemeApplication Clone()
	{
		return new ToolbarThemeApplication(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ToolbarThemeApplication);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ToolbarThemeApplication other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Target != other.Target)
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
		if (Target != 0)
		{
			num ^= Target.GetHashCode();
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
		if (Target != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Target);
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
		if (Target != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Target);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ToolbarThemeApplication other)
	{
		if (other != null)
		{
			if (other.Target != 0)
			{
				Target = other.Target;
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
				Target = (Types.Target)input.ReadEnum();
			}
		}
	}
}
