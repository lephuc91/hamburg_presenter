using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionClearGroup : IMessage<ActionClearGroup>, IMessage, IEquatable<ActionClearGroup>, IDeepCloneable<ActionClearGroup>
{
	private static readonly MessageParser<ActionClearGroup> _parser = new MessageParser<ActionClearGroup>(() => new ActionClearGroup());

	private UnknownFieldSet _unknownFields;

	public const int LayerAudioFieldNumber = 1;

	private bool layerAudio_;

	public const int LayerMessagesFieldNumber = 2;

	private bool layerMessages_;

	public const int LayerPropsFieldNumber = 3;

	private bool layerProps_;

	public const int LayerAnnouncementFieldNumber = 4;

	private bool layerAnnouncement_;

	public const int LayerSlideFieldNumber = 5;

	private bool layerSlide_;

	public const int LayerMediaFieldNumber = 6;

	private bool layerMedia_;

	public const int LayerVideoInputFieldNumber = 7;

	private bool layerVideoInput_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionClearGroup> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LayerAudio
	{
		get
		{
			return layerAudio_;
		}
		set
		{
			layerAudio_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LayerMessages
	{
		get
		{
			return layerMessages_;
		}
		set
		{
			layerMessages_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LayerProps
	{
		get
		{
			return layerProps_;
		}
		set
		{
			layerProps_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LayerAnnouncement
	{
		get
		{
			return layerAnnouncement_;
		}
		set
		{
			layerAnnouncement_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LayerSlide
	{
		get
		{
			return layerSlide_;
		}
		set
		{
			layerSlide_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LayerMedia
	{
		get
		{
			return layerMedia_;
		}
		set
		{
			layerMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LayerVideoInput
	{
		get
		{
			return layerVideoInput_;
		}
		set
		{
			layerVideoInput_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionClearGroup()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionClearGroup(ActionClearGroup other)
		: this()
	{
		layerAudio_ = other.layerAudio_;
		layerMessages_ = other.layerMessages_;
		layerProps_ = other.layerProps_;
		layerAnnouncement_ = other.layerAnnouncement_;
		layerSlide_ = other.layerSlide_;
		layerMedia_ = other.layerMedia_;
		layerVideoInput_ = other.layerVideoInput_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionClearGroup Clone()
	{
		return new ActionClearGroup(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionClearGroup);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionClearGroup other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (LayerAudio != other.LayerAudio)
		{
			return false;
		}
		if (LayerMessages != other.LayerMessages)
		{
			return false;
		}
		if (LayerProps != other.LayerProps)
		{
			return false;
		}
		if (LayerAnnouncement != other.LayerAnnouncement)
		{
			return false;
		}
		if (LayerSlide != other.LayerSlide)
		{
			return false;
		}
		if (LayerMedia != other.LayerMedia)
		{
			return false;
		}
		if (LayerVideoInput != other.LayerVideoInput)
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
		if (LayerAudio)
		{
			num ^= LayerAudio.GetHashCode();
		}
		if (LayerMessages)
		{
			num ^= LayerMessages.GetHashCode();
		}
		if (LayerProps)
		{
			num ^= LayerProps.GetHashCode();
		}
		if (LayerAnnouncement)
		{
			num ^= LayerAnnouncement.GetHashCode();
		}
		if (LayerSlide)
		{
			num ^= LayerSlide.GetHashCode();
		}
		if (LayerMedia)
		{
			num ^= LayerMedia.GetHashCode();
		}
		if (LayerVideoInput)
		{
			num ^= LayerVideoInput.GetHashCode();
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
		if (LayerAudio)
		{
			output.WriteRawTag(8);
			output.WriteBool(LayerAudio);
		}
		if (LayerMessages)
		{
			output.WriteRawTag(16);
			output.WriteBool(LayerMessages);
		}
		if (LayerProps)
		{
			output.WriteRawTag(24);
			output.WriteBool(LayerProps);
		}
		if (LayerAnnouncement)
		{
			output.WriteRawTag(32);
			output.WriteBool(LayerAnnouncement);
		}
		if (LayerSlide)
		{
			output.WriteRawTag(40);
			output.WriteBool(LayerSlide);
		}
		if (LayerMedia)
		{
			output.WriteRawTag(48);
			output.WriteBool(LayerMedia);
		}
		if (LayerVideoInput)
		{
			output.WriteRawTag(56);
			output.WriteBool(LayerVideoInput);
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
		if (LayerAudio)
		{
			num += 2;
		}
		if (LayerMessages)
		{
			num += 2;
		}
		if (LayerProps)
		{
			num += 2;
		}
		if (LayerAnnouncement)
		{
			num += 2;
		}
		if (LayerSlide)
		{
			num += 2;
		}
		if (LayerMedia)
		{
			num += 2;
		}
		if (LayerVideoInput)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionClearGroup other)
	{
		if (other != null)
		{
			if (other.LayerAudio)
			{
				LayerAudio = other.LayerAudio;
			}
			if (other.LayerMessages)
			{
				LayerMessages = other.LayerMessages;
			}
			if (other.LayerProps)
			{
				LayerProps = other.LayerProps;
			}
			if (other.LayerAnnouncement)
			{
				LayerAnnouncement = other.LayerAnnouncement;
			}
			if (other.LayerSlide)
			{
				LayerSlide = other.LayerSlide;
			}
			if (other.LayerMedia)
			{
				LayerMedia = other.LayerMedia;
			}
			if (other.LayerVideoInput)
			{
				LayerVideoInput = other.LayerVideoInput;
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
				LayerAudio = input.ReadBool();
				break;
			case 16u:
				LayerMessages = input.ReadBool();
				break;
			case 24u:
				LayerProps = input.ReadBool();
				break;
			case 32u:
				LayerAnnouncement = input.ReadBool();
				break;
			case 40u:
				LayerSlide = input.ReadBool();
				break;
			case 48u:
				LayerMedia = input.ReadBool();
				break;
			case 56u:
				LayerVideoInput = input.ReadBool();
				break;
			}
		}
	}
}
