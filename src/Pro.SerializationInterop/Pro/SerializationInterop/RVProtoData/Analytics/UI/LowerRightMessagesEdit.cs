using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LowerRightMessagesEdit : IMessage<LowerRightMessagesEdit>, IMessage, IEquatable<LowerRightMessagesEdit>, IDeepCloneable<LowerRightMessagesEdit>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Action
		{
			[OriginalName("ACTION_UNKNOWN")]
			Unknown,
			[OriginalName("ADD_TEXT_TOKEN")]
			AddTextToken,
			[OriginalName("ADD_TIMER_TOKEN")]
			AddTimerToken,
			[OriginalName("ADD_CUSTOM_TOKEN")]
			AddCustomToken,
			[OriginalName("SET_THEME")]
			SetTheme,
			[OriginalName("SET_TEXT")]
			SetText,
			[OriginalName("SET_WEB_NOTIFICATION")]
			SetWebNotification,
			[OriginalName("SET_DISMISS_BEHAVIOR")]
			SetDismissBehavior
		}
	}

	private static readonly MessageParser<LowerRightMessagesEdit> _parser = new MessageParser<LowerRightMessagesEdit>(() => new LowerRightMessagesEdit());

	private UnknownFieldSet _unknownFields;

	public const int ActionFieldNumber = 1;

	private Types.Action action_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LowerRightMessagesEdit> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[30];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Action Action
	{
		get
		{
			return action_;
		}
		set
		{
			action_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessagesEdit()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessagesEdit(LowerRightMessagesEdit other)
		: this()
	{
		action_ = other.action_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LowerRightMessagesEdit Clone()
	{
		return new LowerRightMessagesEdit(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LowerRightMessagesEdit);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LowerRightMessagesEdit other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Action != other.Action)
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
		if (Action != 0)
		{
			num ^= Action.GetHashCode();
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
		if (Action != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Action);
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
		if (Action != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Action);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LowerRightMessagesEdit other)
	{
		if (other != null)
		{
			if (other.Action != 0)
			{
				Action = other.Action;
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
				Action = (Types.Action)input.ReadEnum();
			}
		}
	}
}
