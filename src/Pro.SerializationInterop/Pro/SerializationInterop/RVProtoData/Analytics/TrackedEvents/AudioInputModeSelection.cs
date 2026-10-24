using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AudioInputModeSelection : IMessage<AudioInputModeSelection>, IMessage, IEquatable<AudioInputModeSelection>, IDeepCloneable<AudioInputModeSelection>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ModeType
		{
			[OriginalName("ON")]
			On,
			[OriginalName("OFF")]
			Off,
			[OriginalName("AUTOOFF")]
			Autooff,
			[OriginalName("AUTOON")]
			Autoon
		}
	}

	private static readonly MessageParser<AudioInputModeSelection> _parser = new MessageParser<AudioInputModeSelection>(() => new AudioInputModeSelection());

	private UnknownFieldSet _unknownFields;

	public const int ModeTypeFieldNumber = 1;

	private Types.ModeType modeType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AudioInputModeSelection> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[9];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ModeType ModeType
	{
		get
		{
			return modeType_;
		}
		set
		{
			modeType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputModeSelection()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputModeSelection(AudioInputModeSelection other)
		: this()
	{
		modeType_ = other.modeType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputModeSelection Clone()
	{
		return new AudioInputModeSelection(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AudioInputModeSelection);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AudioInputModeSelection other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ModeType != other.ModeType)
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
		if (ModeType != 0)
		{
			num ^= ModeType.GetHashCode();
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
		if (ModeType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ModeType);
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
		if (ModeType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ModeType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AudioInputModeSelection other)
	{
		if (other != null)
		{
			if (other.ModeType != 0)
			{
				ModeType = other.ModeType;
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
				ModeType = (Types.ModeType)input.ReadEnum();
			}
		}
	}
}
