using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionCaptureStart : IMessage<ActionCaptureStart>, IMessage, IEquatable<ActionCaptureStart>, IDeepCloneable<ActionCaptureStart>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum PresetType
		{
			[OriginalName("UNKNOWN")]
			Unknown,
			[OriginalName("ACTIVE_SETTINGS")]
			ActiveSettings,
			[OriginalName("CAPTURE_PRESET")]
			CapturePreset
		}
	}

	private static readonly MessageParser<ActionCaptureStart> _parser = new MessageParser<ActionCaptureStart>(() => new ActionCaptureStart());

	private UnknownFieldSet _unknownFields;

	public const int PresetTypeFieldNumber = 1;

	private Types.PresetType presetType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionCaptureStart> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PresetType PresetType
	{
		get
		{
			return presetType_;
		}
		set
		{
			presetType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionCaptureStart()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionCaptureStart(ActionCaptureStart other)
		: this()
	{
		presetType_ = other.presetType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionCaptureStart Clone()
	{
		return new ActionCaptureStart(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionCaptureStart);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionCaptureStart other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PresetType != other.PresetType)
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
		if (PresetType != 0)
		{
			num ^= PresetType.GetHashCode();
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
		if (PresetType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)PresetType);
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
		if (PresetType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)PresetType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionCaptureStart other)
	{
		if (other != null)
		{
			if (other.PresetType != 0)
			{
				PresetType = other.PresetType;
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
				PresetType = (Types.PresetType)input.ReadEnum();
			}
		}
	}
}
