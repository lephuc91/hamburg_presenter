using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionProp : IMessage<ActionProp>, IMessage, IEquatable<ActionProp>, IDeepCloneable<ActionProp>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("TRIGGER")]
			Trigger,
			[OriginalName("CLEAR")]
			Clear,
			[OriginalName("TRIGGER_FROM_PROP_BIN")]
			TriggerFromPropBin
		}

		public enum AutoClear
		{
			[OriginalName("UNKNOWN")]
			Unknown,
			[OriginalName("DEFAULT_DISABLED")]
			DefaultDisabled,
			[OriginalName("DEFAULT_ENABLED")]
			DefaultEnabled,
			[OriginalName("DISABLED")]
			Disabled,
			[OriginalName("ENABLED")]
			Enabled,
			[OriginalName("DISABLED_OVERRIDE")]
			DisabledOverride,
			[OriginalName("ENABLED_OVERRIDE")]
			EnabledOverride,
			[OriginalName("CLEAR_ACTION")]
			ClearAction
		}
	}

	private static readonly MessageParser<ActionProp> _parser = new MessageParser<ActionProp>(() => new ActionProp());

	private UnknownFieldSet _unknownFields;

	public const int TransitionFieldNumber = 1;

	private string transition_ = "";

	public const int TypeFieldNumber = 2;

	private Types.Type type_;

	public const int AutoClearFieldNumber = 3;

	private Types.AutoClear autoClear_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionProp> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[8];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Type Type
	{
		get
		{
			return type_;
		}
		set
		{
			type_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AutoClear AutoClear
	{
		get
		{
			return autoClear_;
		}
		set
		{
			autoClear_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionProp()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionProp(ActionProp other)
		: this()
	{
		transition_ = other.transition_;
		type_ = other.type_;
		autoClear_ = other.autoClear_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionProp Clone()
	{
		return new ActionProp(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionProp);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionProp other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Transition != other.Transition)
		{
			return false;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (AutoClear != other.AutoClear)
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
		if (Transition.Length != 0)
		{
			num ^= Transition.GetHashCode();
		}
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (AutoClear != 0)
		{
			num ^= AutoClear.GetHashCode();
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
		if (Transition.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Transition);
		}
		if (Type != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Type);
		}
		if (AutoClear != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)AutoClear);
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
		if (Transition.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Transition);
		}
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (AutoClear != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AutoClear);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionProp other)
	{
		if (other != null)
		{
			if (other.Transition.Length != 0)
			{
				Transition = other.Transition;
			}
			if (other.Type != 0)
			{
				Type = other.Type;
			}
			if (other.AutoClear != 0)
			{
				AutoClear = other.AutoClear;
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
			case 10u:
				Transition = input.ReadString();
				break;
			case 16u:
				Type = (Types.Type)input.ReadEnum();
				break;
			case 24u:
				AutoClear = (Types.AutoClear)input.ReadEnum();
				break;
			}
		}
	}
}
