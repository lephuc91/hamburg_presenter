using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActionLook : IMessage<ActionLook>, IMessage, IEquatable<ActionLook>, IDeepCloneable<ActionLook>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Setting
		{
			[OriginalName("NONE")]
			None,
			[OriginalName("SOME")]
			Some,
			[OriginalName("ALL")]
			All
		}
	}

	private static readonly MessageParser<ActionLook> _parser = new MessageParser<ActionLook>(() => new ActionLook());

	private UnknownFieldSet _unknownFields;

	public const int TotalScreenCountFieldNumber = 1;

	private int totalScreenCount_;

	public const int MaskFieldNumber = 2;

	private Types.Setting mask_;

	public const int MessagesFieldNumber = 3;

	private Types.Setting messages_;

	public const int PropsFieldNumber = 4;

	private Types.Setting props_;

	public const int AnnouncementsFieldNumber = 5;

	private Types.Setting announcements_;

	public const int PresentationThemeFieldNumber = 6;

	private Types.Setting presentationTheme_;

	public const int SlideFieldNumber = 7;

	private Types.Setting slide_;

	public const int MediaFieldNumber = 8;

	private Types.Setting media_;

	public const int VideoInputFieldNumber = 9;

	private Types.Setting videoInput_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActionLook> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalScreenCount
	{
		get
		{
			return totalScreenCount_;
		}
		set
		{
			totalScreenCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Setting Mask
	{
		get
		{
			return mask_;
		}
		set
		{
			mask_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Setting Messages
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
	public Types.Setting Props
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
	public Types.Setting Announcements
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
	public Types.Setting PresentationTheme
	{
		get
		{
			return presentationTheme_;
		}
		set
		{
			presentationTheme_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Setting Slide
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
	public Types.Setting Media
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
	public Types.Setting VideoInput
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
	public ActionLook()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionLook(ActionLook other)
		: this()
	{
		totalScreenCount_ = other.totalScreenCount_;
		mask_ = other.mask_;
		messages_ = other.messages_;
		props_ = other.props_;
		announcements_ = other.announcements_;
		presentationTheme_ = other.presentationTheme_;
		slide_ = other.slide_;
		media_ = other.media_;
		videoInput_ = other.videoInput_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActionLook Clone()
	{
		return new ActionLook(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActionLook);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActionLook other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TotalScreenCount != other.TotalScreenCount)
		{
			return false;
		}
		if (Mask != other.Mask)
		{
			return false;
		}
		if (Messages != other.Messages)
		{
			return false;
		}
		if (Props != other.Props)
		{
			return false;
		}
		if (Announcements != other.Announcements)
		{
			return false;
		}
		if (PresentationTheme != other.PresentationTheme)
		{
			return false;
		}
		if (Slide != other.Slide)
		{
			return false;
		}
		if (Media != other.Media)
		{
			return false;
		}
		if (VideoInput != other.VideoInput)
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
		if (TotalScreenCount != 0)
		{
			num ^= TotalScreenCount.GetHashCode();
		}
		if (Mask != 0)
		{
			num ^= Mask.GetHashCode();
		}
		if (Messages != 0)
		{
			num ^= Messages.GetHashCode();
		}
		if (Props != 0)
		{
			num ^= Props.GetHashCode();
		}
		if (Announcements != 0)
		{
			num ^= Announcements.GetHashCode();
		}
		if (PresentationTheme != 0)
		{
			num ^= PresentationTheme.GetHashCode();
		}
		if (Slide != 0)
		{
			num ^= Slide.GetHashCode();
		}
		if (Media != 0)
		{
			num ^= Media.GetHashCode();
		}
		if (VideoInput != 0)
		{
			num ^= VideoInput.GetHashCode();
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
		if (TotalScreenCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TotalScreenCount);
		}
		if (Mask != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Mask);
		}
		if (Messages != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Messages);
		}
		if (Props != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Props);
		}
		if (Announcements != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)Announcements);
		}
		if (PresentationTheme != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)PresentationTheme);
		}
		if (Slide != 0)
		{
			output.WriteRawTag(56);
			output.WriteEnum((int)Slide);
		}
		if (Media != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)Media);
		}
		if (VideoInput != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)VideoInput);
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
		if (TotalScreenCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalScreenCount);
		}
		if (Mask != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Mask);
		}
		if (Messages != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Messages);
		}
		if (Props != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Props);
		}
		if (Announcements != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Announcements);
		}
		if (PresentationTheme != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)PresentationTheme);
		}
		if (Slide != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Slide);
		}
		if (Media != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Media);
		}
		if (VideoInput != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)VideoInput);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActionLook other)
	{
		if (other != null)
		{
			if (other.TotalScreenCount != 0)
			{
				TotalScreenCount = other.TotalScreenCount;
			}
			if (other.Mask != 0)
			{
				Mask = other.Mask;
			}
			if (other.Messages != 0)
			{
				Messages = other.Messages;
			}
			if (other.Props != 0)
			{
				Props = other.Props;
			}
			if (other.Announcements != 0)
			{
				Announcements = other.Announcements;
			}
			if (other.PresentationTheme != 0)
			{
				PresentationTheme = other.PresentationTheme;
			}
			if (other.Slide != 0)
			{
				Slide = other.Slide;
			}
			if (other.Media != 0)
			{
				Media = other.Media;
			}
			if (other.VideoInput != 0)
			{
				VideoInput = other.VideoInput;
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
				TotalScreenCount = input.ReadInt32();
				break;
			case 16u:
				Mask = (Types.Setting)input.ReadEnum();
				break;
			case 24u:
				Messages = (Types.Setting)input.ReadEnum();
				break;
			case 32u:
				Props = (Types.Setting)input.ReadEnum();
				break;
			case 40u:
				Announcements = (Types.Setting)input.ReadEnum();
				break;
			case 48u:
				PresentationTheme = (Types.Setting)input.ReadEnum();
				break;
			case 56u:
				Slide = (Types.Setting)input.ReadEnum();
				break;
			case 64u:
				Media = (Types.Setting)input.ReadEnum();
				break;
			case 72u:
				VideoInput = (Types.Setting)input.ReadEnum();
				break;
			}
		}
	}
}
