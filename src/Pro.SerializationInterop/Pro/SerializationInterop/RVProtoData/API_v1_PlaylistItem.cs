using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_PlaylistItem : IMessage<API_v1_PlaylistItem>, IMessage, IEquatable<API_v1_PlaylistItem>, IDeepCloneable<API_v1_PlaylistItem>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum API_v1_PlaylistItemType
		{
			[OriginalName("presentation")]
			Presentation,
			[OriginalName("placeholder")]
			Placeholder,
			[OriginalName("header")]
			Header,
			[OriginalName("media")]
			Media,
			[OriginalName("audio")]
			Audio,
			[OriginalName("livevideo")]
			Livevideo
		}
	}

	private static readonly MessageParser<API_v1_PlaylistItem> _parser = new MessageParser<API_v1_PlaylistItem>(() => new API_v1_PlaylistItem());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int TypeFieldNumber = 2;

	private Types.API_v1_PlaylistItemType type_;

	public const int IsHiddenFieldNumber = 3;

	private bool isHidden_;

	public const int IsPcoFieldNumber = 4;

	private bool isPco_;

	public const int HeaderColorFieldNumber = 5;

	private API_v1_Color headerColor_;

	public const int DurationFieldNumber = 6;

	private static readonly FieldCodec<uint?> _single_duration_codec = FieldCodec.ForStructWrapper<uint>(50u);

	private uint? duration_;

	public const int PresentationInfoFieldNumber = 7;

	private API_v1_PlaylistPresentationItem presentationInfo_;

	public const int TargetUuidFieldNumber = 8;

	private string targetUuid_ = "";

	public const int DestinationFieldNumber = 9;

	private API_v1_Presentation.Types.Destination destination_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_PlaylistItem> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PlaylistReflection.Descriptor.MessageTypes[2];

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
	public Types.API_v1_PlaylistItemType Type
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
	public bool IsHidden
	{
		get
		{
			return isHidden_;
		}
		set
		{
			isHidden_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsPco
	{
		get
		{
			return isPco_;
		}
		set
		{
			isPco_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Color HeaderColor
	{
		get
		{
			return headerColor_;
		}
		set
		{
			headerColor_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint? Duration
	{
		get
		{
			return duration_;
		}
		set
		{
			duration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistPresentationItem PresentationInfo
	{
		get
		{
			return presentationInfo_;
		}
		set
		{
			presentationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string TargetUuid
	{
		get
		{
			return targetUuid_;
		}
		set
		{
			targetUuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation.Types.Destination Destination
	{
		get
		{
			return destination_;
		}
		set
		{
			destination_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistItem()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistItem(API_v1_PlaylistItem other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		type_ = other.type_;
		isHidden_ = other.isHidden_;
		isPco_ = other.isPco_;
		headerColor_ = ((other.headerColor_ != null) ? other.headerColor_.Clone() : null);
		Duration = other.Duration;
		presentationInfo_ = ((other.presentationInfo_ != null) ? other.presentationInfo_.Clone() : null);
		targetUuid_ = other.targetUuid_;
		destination_ = other.destination_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PlaylistItem Clone()
	{
		return new API_v1_PlaylistItem(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_PlaylistItem);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_PlaylistItem other)
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
		if (Type != other.Type)
		{
			return false;
		}
		if (IsHidden != other.IsHidden)
		{
			return false;
		}
		if (IsPco != other.IsPco)
		{
			return false;
		}
		if (!object.Equals(HeaderColor, other.HeaderColor))
		{
			return false;
		}
		if (Duration != other.Duration)
		{
			return false;
		}
		if (!object.Equals(PresentationInfo, other.PresentationInfo))
		{
			return false;
		}
		if (TargetUuid != other.TargetUuid)
		{
			return false;
		}
		if (Destination != other.Destination)
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
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (IsHidden)
		{
			num ^= IsHidden.GetHashCode();
		}
		if (IsPco)
		{
			num ^= IsPco.GetHashCode();
		}
		if (headerColor_ != null)
		{
			num ^= HeaderColor.GetHashCode();
		}
		if (duration_.HasValue)
		{
			num ^= Duration.GetHashCode();
		}
		if (presentationInfo_ != null)
		{
			num ^= PresentationInfo.GetHashCode();
		}
		if (TargetUuid.Length != 0)
		{
			num ^= TargetUuid.GetHashCode();
		}
		if (Destination != 0)
		{
			num ^= Destination.GetHashCode();
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
		if (Type != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Type);
		}
		if (IsHidden)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsHidden);
		}
		if (IsPco)
		{
			output.WriteRawTag(32);
			output.WriteBool(IsPco);
		}
		if (headerColor_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(HeaderColor);
		}
		if (duration_.HasValue)
		{
			_single_duration_codec.WriteTagAndValue(output, Duration);
		}
		if (presentationInfo_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PresentationInfo);
		}
		if (TargetUuid.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(TargetUuid);
		}
		if (Destination != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)Destination);
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
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (IsHidden)
		{
			num += 2;
		}
		if (IsPco)
		{
			num += 2;
		}
		if (headerColor_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HeaderColor);
		}
		if (duration_.HasValue)
		{
			num += _single_duration_codec.CalculateSizeWithTag(Duration);
		}
		if (presentationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PresentationInfo);
		}
		if (TargetUuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(TargetUuid);
		}
		if (Destination != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Destination);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_PlaylistItem other)
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
		if (other.Type != 0)
		{
			Type = other.Type;
		}
		if (other.IsHidden)
		{
			IsHidden = other.IsHidden;
		}
		if (other.IsPco)
		{
			IsPco = other.IsPco;
		}
		if (other.headerColor_ != null)
		{
			if (headerColor_ == null)
			{
				HeaderColor = new API_v1_Color();
			}
			HeaderColor.MergeFrom(other.HeaderColor);
		}
		if (other.duration_.HasValue && (!duration_.HasValue || other.Duration != 0))
		{
			Duration = other.Duration;
		}
		if (other.presentationInfo_ != null)
		{
			if (presentationInfo_ == null)
			{
				PresentationInfo = new API_v1_PlaylistPresentationItem();
			}
			PresentationInfo.MergeFrom(other.PresentationInfo);
		}
		if (other.TargetUuid.Length != 0)
		{
			TargetUuid = other.TargetUuid;
		}
		if (other.Destination != 0)
		{
			Destination = other.Destination;
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
			case 16u:
				Type = (Types.API_v1_PlaylistItemType)input.ReadEnum();
				break;
			case 24u:
				IsHidden = input.ReadBool();
				break;
			case 32u:
				IsPco = input.ReadBool();
				break;
			case 42u:
				if (headerColor_ == null)
				{
					HeaderColor = new API_v1_Color();
				}
				input.ReadMessage(HeaderColor);
				break;
			case 50u:
			{
				uint? num2 = _single_duration_codec.Read(input);
				if (!duration_.HasValue || num2 != 0)
				{
					Duration = num2;
				}
				break;
			}
			case 58u:
				if (presentationInfo_ == null)
				{
					PresentationInfo = new API_v1_PlaylistPresentationItem();
				}
				input.ReadMessage(PresentationInfo);
				break;
			case 66u:
				TargetUuid = input.ReadString();
				break;
			case 72u:
				Destination = (API_v1_Presentation.Types.Destination)input.ReadEnum();
				break;
			}
		}
	}
}
