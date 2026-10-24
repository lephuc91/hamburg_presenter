using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Screen : IMessage<API_v1_Screen>, IMessage, IEquatable<API_v1_Screen>, IDeepCloneable<API_v1_Screen>
{
	private static readonly MessageParser<API_v1_Screen> _parser = new MessageParser<API_v1_Screen>(() => new API_v1_Screen());

	private UnknownFieldSet _unknownFields;

	public const int VideoInputFieldNumber = 1;

	private bool videoInput_;

	public const int MediaFieldNumber = 2;

	private bool media_;

	public const int SlideFieldNumber = 3;

	private bool slide_;

	public const int AnnouncementsFieldNumber = 4;

	private bool announcements_;

	public const int PropsFieldNumber = 5;

	private bool props_;

	public const int MessagesFieldNumber = 6;

	private bool messages_;

	public const int PresentationFieldNumber = 7;

	private string presentation_ = "";

	public const int MaskFieldNumber = 8;

	private string mask_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Screen> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LooksReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool VideoInput
	{
		get
		{
			return videoInput_;
		}
		set
		{
			videoInput_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Media
	{
		get
		{
			return media_;
		}
		set
		{
			media_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Slide
	{
		get
		{
			return slide_;
		}
		set
		{
			slide_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Announcements
	{
		get
		{
			return announcements_;
		}
		set
		{
			announcements_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Props
	{
		get
		{
			return props_;
		}
		set
		{
			props_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Messages
	{
		get
		{
			return messages_;
		}
		set
		{
			messages_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Presentation
	{
		get
		{
			return presentation_;
		}
		set
		{
			presentation_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Mask
	{
		get
		{
			return mask_;
		}
		set
		{
			mask_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Screen()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Screen(API_v1_Screen other)
		: this()
	{
		videoInput_ = other.videoInput_;
		media_ = other.media_;
		slide_ = other.slide_;
		announcements_ = other.announcements_;
		props_ = other.props_;
		messages_ = other.messages_;
		presentation_ = other.presentation_;
		mask_ = other.mask_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Screen Clone()
	{
		return new API_v1_Screen(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Screen);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Screen other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (VideoInput != other.VideoInput)
		{
			return false;
		}
		if (Media != other.Media)
		{
			return false;
		}
		if (Slide != other.Slide)
		{
			return false;
		}
		if (Announcements != other.Announcements)
		{
			return false;
		}
		if (Props != other.Props)
		{
			return false;
		}
		if (Messages != other.Messages)
		{
			return false;
		}
		if (Presentation != other.Presentation)
		{
			return false;
		}
		if (Mask != other.Mask)
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
		if (VideoInput)
		{
			num ^= VideoInput.GetHashCode();
		}
		if (Media)
		{
			num ^= Media.GetHashCode();
		}
		if (Slide)
		{
			num ^= Slide.GetHashCode();
		}
		if (Announcements)
		{
			num ^= Announcements.GetHashCode();
		}
		if (Props)
		{
			num ^= Props.GetHashCode();
		}
		if (Messages)
		{
			num ^= Messages.GetHashCode();
		}
		if (Presentation.Length != 0)
		{
			num ^= Presentation.GetHashCode();
		}
		if (Mask.Length != 0)
		{
			num ^= Mask.GetHashCode();
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
		if (VideoInput)
		{
			output.WriteRawTag(8);
			output.WriteBool(VideoInput);
		}
		if (Media)
		{
			output.WriteRawTag(16);
			output.WriteBool(Media);
		}
		if (Slide)
		{
			output.WriteRawTag(24);
			output.WriteBool(Slide);
		}
		if (Announcements)
		{
			output.WriteRawTag(32);
			output.WriteBool(Announcements);
		}
		if (Props)
		{
			output.WriteRawTag(40);
			output.WriteBool(Props);
		}
		if (Messages)
		{
			output.WriteRawTag(48);
			output.WriteBool(Messages);
		}
		if (Presentation.Length != 0)
		{
			output.WriteRawTag(58);
			output.WriteString(Presentation);
		}
		if (Mask.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(Mask);
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
		if (VideoInput)
		{
			num += 2;
		}
		if (Media)
		{
			num += 2;
		}
		if (Slide)
		{
			num += 2;
		}
		if (Announcements)
		{
			num += 2;
		}
		if (Props)
		{
			num += 2;
		}
		if (Messages)
		{
			num += 2;
		}
		if (Presentation.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Presentation);
		}
		if (Mask.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Mask);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Screen other)
	{
		if (other != null)
		{
			if (other.VideoInput)
			{
				VideoInput = other.VideoInput;
			}
			if (other.Media)
			{
				Media = other.Media;
			}
			if (other.Slide)
			{
				Slide = other.Slide;
			}
			if (other.Announcements)
			{
				Announcements = other.Announcements;
			}
			if (other.Props)
			{
				Props = other.Props;
			}
			if (other.Messages)
			{
				Messages = other.Messages;
			}
			if (other.Presentation.Length != 0)
			{
				Presentation = other.Presentation;
			}
			if (other.Mask.Length != 0)
			{
				Mask = other.Mask;
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
				VideoInput = input.ReadBool();
				break;
			case 16u:
				Media = input.ReadBool();
				break;
			case 24u:
				Slide = input.ReadBool();
				break;
			case 32u:
				Announcements = input.ReadBool();
				break;
			case 40u:
				Props = input.ReadBool();
				break;
			case 48u:
				Messages = input.ReadBool();
				break;
			case 58u:
				Presentation = input.ReadString();
				break;
			case 66u:
				Mask = input.ReadString();
				break;
			}
		}
	}
}
