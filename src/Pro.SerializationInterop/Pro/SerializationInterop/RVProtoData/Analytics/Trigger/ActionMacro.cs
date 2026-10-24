using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionMacro : IMessage<ActionMacro>, IMessage, IEquatable<ActionMacro>, IDeepCloneable<ActionMacro>
{
	private static readonly MessageParser<ActionMacro> _parser = new MessageParser<ActionMacro>(() => new ActionMacro());

	private UnknownFieldSet _unknownFields;

	public const int ActionCountFieldNumber = 1;

	private int actionCount_;

	public const int CueActionCountFieldNumber = 2;

	private int cueActionCount_;

	public const int TotalActionCountFieldNumber = 3;

	private int totalActionCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionMacro> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ActionCount
	{
		get
		{
			return actionCount_;
		}
		set
		{
			actionCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CueActionCount
	{
		get
		{
			return cueActionCount_;
		}
		set
		{
			cueActionCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalActionCount
	{
		get
		{
			return totalActionCount_;
		}
		set
		{
			totalActionCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMacro()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMacro(ActionMacro other)
		: this()
	{
		actionCount_ = other.actionCount_;
		cueActionCount_ = other.cueActionCount_;
		totalActionCount_ = other.totalActionCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionMacro Clone()
	{
		return new ActionMacro(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionMacro);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionMacro other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ActionCount != other.ActionCount)
		{
			return false;
		}
		if (CueActionCount != other.CueActionCount)
		{
			return false;
		}
		if (TotalActionCount != other.TotalActionCount)
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
		if (ActionCount != 0)
		{
			num ^= ActionCount.GetHashCode();
		}
		if (CueActionCount != 0)
		{
			num ^= CueActionCount.GetHashCode();
		}
		if (TotalActionCount != 0)
		{
			num ^= TotalActionCount.GetHashCode();
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
		if (ActionCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(ActionCount);
		}
		if (CueActionCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(CueActionCount);
		}
		if (TotalActionCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(TotalActionCount);
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
		if (ActionCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ActionCount);
		}
		if (CueActionCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(CueActionCount);
		}
		if (TotalActionCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalActionCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionMacro other)
	{
		if (other != null)
		{
			if (other.ActionCount != 0)
			{
				ActionCount = other.ActionCount;
			}
			if (other.CueActionCount != 0)
			{
				CueActionCount = other.CueActionCount;
			}
			if (other.TotalActionCount != 0)
			{
				TotalActionCount = other.TotalActionCount;
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
				ActionCount = input.ReadInt32();
				break;
			case 16u:
				CueActionCount = input.ReadInt32();
				break;
			case 24u:
				TotalActionCount = input.ReadInt32();
				break;
			}
		}
	}
}
