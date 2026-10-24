using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionStage : IMessage<ActionStage>, IMessage, IEquatable<ActionStage>, IDeepCloneable<ActionStage>
{
	private static readonly MessageParser<ActionStage> _parser = new MessageParser<ActionStage>(() => new ActionStage());

	private UnknownFieldSet _unknownFields;

	public const int LayoutsFieldNumber = 1;

	private int layouts_;

	public const int TotalStageScreensFieldNumber = 2;

	private int totalStageScreens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionStage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Layouts
	{
		get
		{
			return layouts_;
		}
		set
		{
			layouts_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalStageScreens
	{
		get
		{
			return totalStageScreens_;
		}
		set
		{
			totalStageScreens_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionStage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionStage(ActionStage other)
		: this()
	{
		layouts_ = other.layouts_;
		totalStageScreens_ = other.totalStageScreens_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionStage Clone()
	{
		return new ActionStage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionStage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionStage other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Layouts != other.Layouts)
		{
			return false;
		}
		if (TotalStageScreens != other.TotalStageScreens)
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
		if (Layouts != 0)
		{
			num ^= Layouts.GetHashCode();
		}
		if (TotalStageScreens != 0)
		{
			num ^= TotalStageScreens.GetHashCode();
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
		if (Layouts != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Layouts);
		}
		if (TotalStageScreens != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(TotalStageScreens);
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
		if (Layouts != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Layouts);
		}
		if (TotalStageScreens != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalStageScreens);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionStage other)
	{
		if (other != null)
		{
			if (other.Layouts != 0)
			{
				Layouts = other.Layouts;
			}
			if (other.TotalStageScreens != 0)
			{
				TotalStageScreens = other.TotalStageScreens;
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
				Layouts = input.ReadInt32();
				break;
			case 16u:
				TotalStageScreens = input.ReadInt32();
				break;
			}
		}
	}
}
