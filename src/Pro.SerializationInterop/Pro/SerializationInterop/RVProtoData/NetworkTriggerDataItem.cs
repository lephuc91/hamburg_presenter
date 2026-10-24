using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NetworkTriggerDataItem : IMessage<NetworkTriggerDataItem>, IMessage, IEquatable<NetworkTriggerDataItem>, IDeepCloneable<NetworkTriggerDataItem>
{
	public enum TypeOneofCase
	{
		None,
		Action,
		Cue
	}

	private static readonly MessageParser<NetworkTriggerDataItem> _parser = new MessageParser<NetworkTriggerDataItem>(() => new NetworkTriggerDataItem());

	private UnknownFieldSet _unknownFields;

	public const int ActionFieldNumber = 1;

	public const int CueFieldNumber = 2;

	public const int TriggerOptionsFieldNumber = 3;

	private TriggerOptions triggerOptions_;

	public const int TriggerCueFieldNumber = 4;

	private TriggerCue triggerCue_;

	private object type_;

	private TypeOneofCase typeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NetworkTriggerDataItem> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[8];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action Action
	{
		get
		{
			if (typeCase_ != TypeOneofCase.Action)
			{
				return null;
			}
			return (Action)type_;
		}
		set
		{
			type_ = value;
			typeCase_ = ((value != null) ? TypeOneofCase.Action : TypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Cue Cue
	{
		get
		{
			if (typeCase_ != TypeOneofCase.Cue)
			{
				return null;
			}
			return (Cue)type_;
		}
		set
		{
			type_ = value;
			typeCase_ = ((value != null) ? TypeOneofCase.Cue : TypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerOptions TriggerOptions
	{
		get
		{
			return triggerOptions_;
		}
		set
		{
			triggerOptions_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerCue TriggerCue
	{
		get
		{
			return triggerCue_;
		}
		set
		{
			triggerCue_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TypeOneofCase TypeCase => typeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkTriggerDataItem()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkTriggerDataItem(NetworkTriggerDataItem other)
		: this()
	{
		triggerOptions_ = ((other.triggerOptions_ != null) ? other.triggerOptions_.Clone() : null);
		triggerCue_ = ((other.triggerCue_ != null) ? other.triggerCue_.Clone() : null);
		switch (other.TypeCase)
		{
		case TypeOneofCase.Action:
			Action = other.Action.Clone();
			break;
		case TypeOneofCase.Cue:
			Cue = other.Cue.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkTriggerDataItem Clone()
	{
		return new NetworkTriggerDataItem(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearType()
	{
		typeCase_ = TypeOneofCase.None;
		type_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NetworkTriggerDataItem);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NetworkTriggerDataItem other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Action, other.Action))
		{
			return false;
		}
		if (!object.Equals(Cue, other.Cue))
		{
			return false;
		}
		if (!object.Equals(TriggerOptions, other.TriggerOptions))
		{
			return false;
		}
		if (!object.Equals(TriggerCue, other.TriggerCue))
		{
			return false;
		}
		if (TypeCase != other.TypeCase)
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
		if (typeCase_ == TypeOneofCase.Action)
		{
			num ^= Action.GetHashCode();
		}
		if (typeCase_ == TypeOneofCase.Cue)
		{
			num ^= Cue.GetHashCode();
		}
		if (triggerOptions_ != null)
		{
			num ^= TriggerOptions.GetHashCode();
		}
		if (triggerCue_ != null)
		{
			num ^= TriggerCue.GetHashCode();
		}
		num ^= (int)typeCase_;
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
		if (typeCase_ == TypeOneofCase.Action)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Action);
		}
		if (typeCase_ == TypeOneofCase.Cue)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Cue);
		}
		if (triggerOptions_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(TriggerOptions);
		}
		if (triggerCue_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(TriggerCue);
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
		if (typeCase_ == TypeOneofCase.Action)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Action);
		}
		if (typeCase_ == TypeOneofCase.Cue)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Cue);
		}
		if (triggerOptions_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerOptions);
		}
		if (triggerCue_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerCue);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(NetworkTriggerDataItem other)
	{
		if (other == null)
		{
			return;
		}
		if (other.triggerOptions_ != null)
		{
			if (triggerOptions_ == null)
			{
				TriggerOptions = new TriggerOptions();
			}
			TriggerOptions.MergeFrom(other.TriggerOptions);
		}
		if (other.triggerCue_ != null)
		{
			if (triggerCue_ == null)
			{
				TriggerCue = new TriggerCue();
			}
			TriggerCue.MergeFrom(other.TriggerCue);
		}
		switch (other.TypeCase)
		{
		case TypeOneofCase.Action:
			if (Action == null)
			{
				Action = new Action();
			}
			Action.MergeFrom(other.Action);
			break;
		case TypeOneofCase.Cue:
			if (Cue == null)
			{
				Cue = new Cue();
			}
			Cue.MergeFrom(other.Cue);
			break;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
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
			{
				Action action = new Action();
				if (typeCase_ == TypeOneofCase.Action)
				{
					action.MergeFrom(Action);
				}
				input.ReadMessage(action);
				Action = action;
				break;
			}
			case 18u:
			{
				Cue cue = new Cue();
				if (typeCase_ == TypeOneofCase.Cue)
				{
					cue.MergeFrom(Cue);
				}
				input.ReadMessage(cue);
				Cue = cue;
				break;
			}
			case 26u:
				if (triggerOptions_ == null)
				{
					TriggerOptions = new TriggerOptions();
				}
				input.ReadMessage(TriggerOptions);
				break;
			case 34u:
				if (triggerCue_ == null)
				{
					TriggerCue = new TriggerCue();
				}
				input.ReadMessage(TriggerCue);
				break;
			}
		}
	}
}
