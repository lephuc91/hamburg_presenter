using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionSlideDestination : IMessage<ActionSlideDestination>, IMessage, IEquatable<ActionSlideDestination>, IDeepCloneable<ActionSlideDestination>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ChangeSlideDestination
		{
			[OriginalName("UNKNOWN")]
			Unknown,
			[OriginalName("NO_CHANGE")]
			NoChange,
			[OriginalName("STAGE_ONLY")]
			StageOnly,
			[OriginalName("STAGE_AUDIENCE")]
			StageAudience
		}
	}

	private static readonly MessageParser<ActionSlideDestination> _parser = new MessageParser<ActionSlideDestination>(() => new ActionSlideDestination());

	private UnknownFieldSet _unknownFields;

	public const int ChangeSlideDestinationFieldNumber = 1;

	private Types.ChangeSlideDestination changeSlideDestination_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionSlideDestination> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[9];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ChangeSlideDestination ChangeSlideDestination
	{
		get
		{
			return changeSlideDestination_;
		}
		set
		{
			changeSlideDestination_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionSlideDestination()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionSlideDestination(ActionSlideDestination other)
		: this()
	{
		changeSlideDestination_ = other.changeSlideDestination_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionSlideDestination Clone()
	{
		return new ActionSlideDestination(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionSlideDestination);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionSlideDestination other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ChangeSlideDestination != other.ChangeSlideDestination)
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
		if (ChangeSlideDestination != 0)
		{
			num ^= ChangeSlideDestination.GetHashCode();
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
		if (ChangeSlideDestination != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ChangeSlideDestination);
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
		if (ChangeSlideDestination != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ChangeSlideDestination);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionSlideDestination other)
	{
		if (other != null)
		{
			if (other.ChangeSlideDestination != 0)
			{
				ChangeSlideDestination = other.ChangeSlideDestination;
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
				ChangeSlideDestination = (Types.ChangeSlideDestination)input.ReadEnum();
			}
		}
	}
}
