using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_ClearGroup : IMessage<API_v1_ClearGroup>, IMessage, IEquatable<API_v1_ClearGroup>, IDeepCloneable<API_v1_ClearGroup>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum API_v1_ClearGroupLayerType
		{
			[OriginalName("music")]
			Music,
			[OriginalName("audio_effects")]
			AudioEffects,
			[OriginalName("props")]
			Props,
			[OriginalName("messages")]
			Messages,
			[OriginalName("announcements")]
			Announcements,
			[OriginalName("presentation")]
			Presentation,
			[OriginalName("presentation_media")]
			PresentationMedia,
			[OriginalName("video_input")]
			VideoInput
		}
	}

	private static readonly MessageParser<API_v1_ClearGroup> _parser = new MessageParser<API_v1_ClearGroup>(() => new API_v1_ClearGroup());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int IconFieldNumber = 2;

	private string icon_ = "";

	public const int TintFieldNumber = 3;

	private API_v1_Color tint_;

	public const int LayersFieldNumber = 4;

	private static readonly FieldCodec<Types.API_v1_ClearGroupLayerType> _repeated_layers_codec = FieldCodec.ForEnum(34u, (Types.API_v1_ClearGroupLayerType x) => (int)x, (int x) => (Types.API_v1_ClearGroupLayerType)x);

	private readonly RepeatedField<Types.API_v1_ClearGroupLayerType> layers_ = new RepeatedField<Types.API_v1_ClearGroupLayerType>();

	public const int StopTimelineAnnouncementsFieldNumber = 5;

	private bool stopTimelineAnnouncements_;

	public const int StopTimelinePresentationFieldNumber = 6;

	private bool stopTimelinePresentation_;

	public const int ClearNextPresentationFieldNumber = 7;

	private bool clearNextPresentation_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_ClearGroup> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1ClearReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Icon
	{
		get
		{
			return icon_;
		}
		set
		{
			icon_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Color Tint
	{
		get
		{
			return tint_;
		}
		set
		{
			tint_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.API_v1_ClearGroupLayerType> Layers => layers_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool StopTimelineAnnouncements
	{
		get
		{
			return stopTimelineAnnouncements_;
		}
		set
		{
			stopTimelineAnnouncements_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool StopTimelinePresentation
	{
		get
		{
			return stopTimelinePresentation_;
		}
		set
		{
			stopTimelinePresentation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ClearNextPresentation
	{
		get
		{
			return clearNextPresentation_;
		}
		set
		{
			clearNextPresentation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ClearGroup()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ClearGroup(API_v1_ClearGroup other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		icon_ = other.icon_;
		tint_ = ((other.tint_ != null) ? other.tint_.Clone() : null);
		layers_ = other.layers_.Clone();
		stopTimelineAnnouncements_ = other.stopTimelineAnnouncements_;
		stopTimelinePresentation_ = other.stopTimelinePresentation_;
		clearNextPresentation_ = other.clearNextPresentation_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ClearGroup Clone()
	{
		return new API_v1_ClearGroup(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_ClearGroup);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_ClearGroup other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Id, other.Id))
		{
			return false;
		}
		if (Icon != other.Icon)
		{
			return false;
		}
		if (!object.Equals(Tint, other.Tint))
		{
			return false;
		}
		if (!layers_.Equals(other.layers_))
		{
			return false;
		}
		if (StopTimelineAnnouncements != other.StopTimelineAnnouncements)
		{
			return false;
		}
		if (StopTimelinePresentation != other.StopTimelinePresentation)
		{
			return false;
		}
		if (ClearNextPresentation != other.ClearNextPresentation)
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
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (Icon.Length != 0)
		{
			num ^= Icon.GetHashCode();
		}
		if (tint_ != null)
		{
			num ^= Tint.GetHashCode();
		}
		num ^= layers_.GetHashCode();
		if (StopTimelineAnnouncements)
		{
			num ^= StopTimelineAnnouncements.GetHashCode();
		}
		if (StopTimelinePresentation)
		{
			num ^= StopTimelinePresentation.GetHashCode();
		}
		if (ClearNextPresentation)
		{
			num ^= ClearNextPresentation.GetHashCode();
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (Icon.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Icon);
		}
		if (tint_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Tint);
		}
		layers_.WriteTo(output, _repeated_layers_codec);
		if (StopTimelineAnnouncements)
		{
			output.WriteRawTag(40);
			output.WriteBool(StopTimelineAnnouncements);
		}
		if (StopTimelinePresentation)
		{
			output.WriteRawTag(48);
			output.WriteBool(StopTimelinePresentation);
		}
		if (ClearNextPresentation)
		{
			output.WriteRawTag(56);
			output.WriteBool(ClearNextPresentation);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (Icon.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Icon);
		}
		if (tint_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Tint);
		}
		num += layers_.CalculateSize(_repeated_layers_codec);
		if (StopTimelineAnnouncements)
		{
			num += 2;
		}
		if (StopTimelinePresentation)
		{
			num += 2;
		}
		if (ClearNextPresentation)
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
	public void MergeFrom(API_v1_ClearGroup other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new API_v1_Identifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.Icon.Length != 0)
		{
			Icon = other.Icon;
		}
		if (other.tint_ != null)
		{
			if (tint_ == null)
			{
				Tint = new API_v1_Color();
			}
			Tint.MergeFrom(other.Tint);
		}
		layers_.Add(other.layers_);
		if (other.StopTimelineAnnouncements)
		{
			StopTimelineAnnouncements = other.StopTimelineAnnouncements;
		}
		if (other.StopTimelinePresentation)
		{
			StopTimelinePresentation = other.StopTimelinePresentation;
		}
		if (other.ClearNextPresentation)
		{
			ClearNextPresentation = other.ClearNextPresentation;
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
				if (id_ == null)
				{
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				Icon = input.ReadString();
				break;
			case 26u:
				if (tint_ == null)
				{
					Tint = new API_v1_Color();
				}
				input.ReadMessage(Tint);
				break;
			case 32u:
			case 34u:
				layers_.AddEntriesFrom(input, _repeated_layers_codec);
				break;
			case 40u:
				StopTimelineAnnouncements = input.ReadBool();
				break;
			case 48u:
				StopTimelinePresentation = input.ReadBool();
				break;
			case 56u:
				ClearNextPresentation = input.ReadBool();
				break;
			}
		}
	}
}
