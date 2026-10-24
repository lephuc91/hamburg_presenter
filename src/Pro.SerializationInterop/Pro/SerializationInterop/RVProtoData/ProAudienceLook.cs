using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProAudienceLook : IMessage<ProAudienceLook>, IMessage, IEquatable<ProAudienceLook>, IDeepCloneable<ProAudienceLook>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ProScreenLook : IMessage<ProScreenLook>, IMessage, IEquatable<ProScreenLook>, IDeepCloneable<ProScreenLook>
		{
			private static readonly MessageParser<ProScreenLook> _parser = new MessageParser<ProScreenLook>(() => new ProScreenLook());

			private UnknownFieldSet _unknownFields;

			public const int ProScreenUuidFieldNumber = 1;

			private UUID proScreenUuid_;

			public const int PropsEnabledFieldNumber = 2;

			private bool propsEnabled_;

			public const int LiveVideoEnabledFieldNumber = 3;

			private bool liveVideoEnabled_;

			public const int PresentationBackgroundEnabledFieldNumber = 4;

			private bool presentationBackgroundEnabled_;

			public const int TemplateDocumentFilePathFieldNumber = 5;

			private URL templateDocumentFilePath_;

			public const int TemplateSlideUuidFieldNumber = 6;

			private UUID templateSlideUuid_;

			public const int PresentationForegroundEnabledFieldNumber = 7;

			private bool presentationForegroundEnabled_;

			public const int MaskUuidFieldNumber = 8;

			private UUID maskUuid_;

			public const int AnnouncementsEnabledFieldNumber = 9;

			private bool announcementsEnabled_;

			public const int PropsLayerEnabledFieldNumber = 10;

			private bool propsLayerEnabled_;

			public const int MessagesLayerEnabledFieldNumber = 11;

			private bool messagesLayerEnabled_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ProScreenLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProAudienceLook.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID ProScreenUuid
			{
				get
				{
					return proScreenUuid_;
				}
				set
				{
					proScreenUuid_ = value;
				}
			}

			[Obsolete]
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool PropsEnabled
			{
				get
				{
					return propsEnabled_;
				}
				set
				{
					propsEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool LiveVideoEnabled
			{
				get
				{
					return liveVideoEnabled_;
				}
				set
				{
					liveVideoEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool PresentationBackgroundEnabled
			{
				get
				{
					return presentationBackgroundEnabled_;
				}
				set
				{
					presentationBackgroundEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public URL TemplateDocumentFilePath
			{
				get
				{
					return templateDocumentFilePath_;
				}
				set
				{
					templateDocumentFilePath_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID TemplateSlideUuid
			{
				get
				{
					return templateSlideUuid_;
				}
				set
				{
					templateSlideUuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool PresentationForegroundEnabled
			{
				get
				{
					return presentationForegroundEnabled_;
				}
				set
				{
					presentationForegroundEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID MaskUuid
			{
				get
				{
					return maskUuid_;
				}
				set
				{
					maskUuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool AnnouncementsEnabled
			{
				get
				{
					return announcementsEnabled_;
				}
				set
				{
					announcementsEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool PropsLayerEnabled
			{
				get
				{
					return propsLayerEnabled_;
				}
				set
				{
					propsLayerEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool MessagesLayerEnabled
			{
				get
				{
					return messagesLayerEnabled_;
				}
				set
				{
					messagesLayerEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProScreenLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProScreenLook(ProScreenLook other)
				: this()
			{
				proScreenUuid_ = ((other.proScreenUuid_ != null) ? other.proScreenUuid_.Clone() : null);
				propsEnabled_ = other.propsEnabled_;
				liveVideoEnabled_ = other.liveVideoEnabled_;
				presentationBackgroundEnabled_ = other.presentationBackgroundEnabled_;
				templateDocumentFilePath_ = ((other.templateDocumentFilePath_ != null) ? other.templateDocumentFilePath_.Clone() : null);
				templateSlideUuid_ = ((other.templateSlideUuid_ != null) ? other.templateSlideUuid_.Clone() : null);
				presentationForegroundEnabled_ = other.presentationForegroundEnabled_;
				maskUuid_ = ((other.maskUuid_ != null) ? other.maskUuid_.Clone() : null);
				announcementsEnabled_ = other.announcementsEnabled_;
				propsLayerEnabled_ = other.propsLayerEnabled_;
				messagesLayerEnabled_ = other.messagesLayerEnabled_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProScreenLook Clone()
			{
				return new ProScreenLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ProScreenLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ProScreenLook other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(ProScreenUuid, other.ProScreenUuid))
				{
					return false;
				}
				if (PropsEnabled != other.PropsEnabled)
				{
					return false;
				}
				if (LiveVideoEnabled != other.LiveVideoEnabled)
				{
					return false;
				}
				if (PresentationBackgroundEnabled != other.PresentationBackgroundEnabled)
				{
					return false;
				}
				if (!object.Equals(TemplateDocumentFilePath, other.TemplateDocumentFilePath))
				{
					return false;
				}
				if (!object.Equals(TemplateSlideUuid, other.TemplateSlideUuid))
				{
					return false;
				}
				if (PresentationForegroundEnabled != other.PresentationForegroundEnabled)
				{
					return false;
				}
				if (!object.Equals(MaskUuid, other.MaskUuid))
				{
					return false;
				}
				if (AnnouncementsEnabled != other.AnnouncementsEnabled)
				{
					return false;
				}
				if (PropsLayerEnabled != other.PropsLayerEnabled)
				{
					return false;
				}
				if (MessagesLayerEnabled != other.MessagesLayerEnabled)
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
				if (proScreenUuid_ != null)
				{
					num ^= ProScreenUuid.GetHashCode();
				}
				if (PropsEnabled)
				{
					num ^= PropsEnabled.GetHashCode();
				}
				if (LiveVideoEnabled)
				{
					num ^= LiveVideoEnabled.GetHashCode();
				}
				if (PresentationBackgroundEnabled)
				{
					num ^= PresentationBackgroundEnabled.GetHashCode();
				}
				if (templateDocumentFilePath_ != null)
				{
					num ^= TemplateDocumentFilePath.GetHashCode();
				}
				if (templateSlideUuid_ != null)
				{
					num ^= TemplateSlideUuid.GetHashCode();
				}
				if (PresentationForegroundEnabled)
				{
					num ^= PresentationForegroundEnabled.GetHashCode();
				}
				if (maskUuid_ != null)
				{
					num ^= MaskUuid.GetHashCode();
				}
				if (AnnouncementsEnabled)
				{
					num ^= AnnouncementsEnabled.GetHashCode();
				}
				if (PropsLayerEnabled)
				{
					num ^= PropsLayerEnabled.GetHashCode();
				}
				if (MessagesLayerEnabled)
				{
					num ^= MessagesLayerEnabled.GetHashCode();
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
				if (proScreenUuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(ProScreenUuid);
				}
				if (PropsEnabled)
				{
					output.WriteRawTag(16);
					output.WriteBool(PropsEnabled);
				}
				if (LiveVideoEnabled)
				{
					output.WriteRawTag(24);
					output.WriteBool(LiveVideoEnabled);
				}
				if (PresentationBackgroundEnabled)
				{
					output.WriteRawTag(32);
					output.WriteBool(PresentationBackgroundEnabled);
				}
				if (templateDocumentFilePath_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(TemplateDocumentFilePath);
				}
				if (templateSlideUuid_ != null)
				{
					output.WriteRawTag(50);
					output.WriteMessage(TemplateSlideUuid);
				}
				if (PresentationForegroundEnabled)
				{
					output.WriteRawTag(56);
					output.WriteBool(PresentationForegroundEnabled);
				}
				if (maskUuid_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(MaskUuid);
				}
				if (AnnouncementsEnabled)
				{
					output.WriteRawTag(72);
					output.WriteBool(AnnouncementsEnabled);
				}
				if (PropsLayerEnabled)
				{
					output.WriteRawTag(80);
					output.WriteBool(PropsLayerEnabled);
				}
				if (MessagesLayerEnabled)
				{
					output.WriteRawTag(88);
					output.WriteBool(MessagesLayerEnabled);
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
				if (proScreenUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ProScreenUuid);
				}
				if (PropsEnabled)
				{
					num += 2;
				}
				if (LiveVideoEnabled)
				{
					num += 2;
				}
				if (PresentationBackgroundEnabled)
				{
					num += 2;
				}
				if (templateDocumentFilePath_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TemplateDocumentFilePath);
				}
				if (templateSlideUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TemplateSlideUuid);
				}
				if (PresentationForegroundEnabled)
				{
					num += 2;
				}
				if (maskUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MaskUuid);
				}
				if (AnnouncementsEnabled)
				{
					num += 2;
				}
				if (PropsLayerEnabled)
				{
					num += 2;
				}
				if (MessagesLayerEnabled)
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
			public void MergeFrom(ProScreenLook other)
			{
				if (other == null)
				{
					return;
				}
				if (other.proScreenUuid_ != null)
				{
					if (proScreenUuid_ == null)
					{
						ProScreenUuid = new UUID();
					}
					ProScreenUuid.MergeFrom(other.ProScreenUuid);
				}
				if (other.PropsEnabled)
				{
					PropsEnabled = other.PropsEnabled;
				}
				if (other.LiveVideoEnabled)
				{
					LiveVideoEnabled = other.LiveVideoEnabled;
				}
				if (other.PresentationBackgroundEnabled)
				{
					PresentationBackgroundEnabled = other.PresentationBackgroundEnabled;
				}
				if (other.templateDocumentFilePath_ != null)
				{
					if (templateDocumentFilePath_ == null)
					{
						TemplateDocumentFilePath = new URL();
					}
					TemplateDocumentFilePath.MergeFrom(other.TemplateDocumentFilePath);
				}
				if (other.templateSlideUuid_ != null)
				{
					if (templateSlideUuid_ == null)
					{
						TemplateSlideUuid = new UUID();
					}
					TemplateSlideUuid.MergeFrom(other.TemplateSlideUuid);
				}
				if (other.PresentationForegroundEnabled)
				{
					PresentationForegroundEnabled = other.PresentationForegroundEnabled;
				}
				if (other.maskUuid_ != null)
				{
					if (maskUuid_ == null)
					{
						MaskUuid = new UUID();
					}
					MaskUuid.MergeFrom(other.MaskUuid);
				}
				if (other.AnnouncementsEnabled)
				{
					AnnouncementsEnabled = other.AnnouncementsEnabled;
				}
				if (other.PropsLayerEnabled)
				{
					PropsLayerEnabled = other.PropsLayerEnabled;
				}
				if (other.MessagesLayerEnabled)
				{
					MessagesLayerEnabled = other.MessagesLayerEnabled;
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
						if (proScreenUuid_ == null)
						{
							ProScreenUuid = new UUID();
						}
						input.ReadMessage(ProScreenUuid);
						break;
					case 16u:
						PropsEnabled = input.ReadBool();
						break;
					case 24u:
						LiveVideoEnabled = input.ReadBool();
						break;
					case 32u:
						PresentationBackgroundEnabled = input.ReadBool();
						break;
					case 42u:
						if (templateDocumentFilePath_ == null)
						{
							TemplateDocumentFilePath = new URL();
						}
						input.ReadMessage(TemplateDocumentFilePath);
						break;
					case 50u:
						if (templateSlideUuid_ == null)
						{
							TemplateSlideUuid = new UUID();
						}
						input.ReadMessage(TemplateSlideUuid);
						break;
					case 56u:
						PresentationForegroundEnabled = input.ReadBool();
						break;
					case 66u:
						if (maskUuid_ == null)
						{
							MaskUuid = new UUID();
						}
						input.ReadMessage(MaskUuid);
						break;
					case 72u:
						AnnouncementsEnabled = input.ReadBool();
						break;
					case 80u:
						PropsLayerEnabled = input.ReadBool();
						break;
					case 88u:
						MessagesLayerEnabled = input.ReadBool();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<ProAudienceLook> _parser = new MessageParser<ProAudienceLook>(() => new ProAudienceLook());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int ScreenLooksFieldNumber = 3;

	private static readonly FieldCodec<Types.ProScreenLook> _repeated_screenLooks_codec = FieldCodec.ForMessage(26u, Types.ProScreenLook.Parser);

	private readonly RepeatedField<Types.ProScreenLook> screenLooks_ = new RepeatedField<Types.ProScreenLook>();

	public const int OriginalLookUuidFieldNumber = 4;

	private UUID originalLookUuid_;

	public const int TransitionDurationFieldNumber = 5;

	private double transitionDuration_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProAudienceLook> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProAudienceLookReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.ProScreenLook> ScreenLooks => screenLooks_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID OriginalLookUuid
	{
		get
		{
			return originalLookUuid_;
		}
		set
		{
			originalLookUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double TransitionDuration
	{
		get
		{
			return transitionDuration_;
		}
		set
		{
			transitionDuration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProAudienceLook()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProAudienceLook(ProAudienceLook other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		screenLooks_ = other.screenLooks_.Clone();
		originalLookUuid_ = ((other.originalLookUuid_ != null) ? other.originalLookUuid_.Clone() : null);
		transitionDuration_ = other.transitionDuration_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProAudienceLook Clone()
	{
		return new ProAudienceLook(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProAudienceLook);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProAudienceLook other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (!screenLooks_.Equals(other.screenLooks_))
		{
			return false;
		}
		if (!object.Equals(OriginalLookUuid, other.OriginalLookUuid))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TransitionDuration, other.TransitionDuration))
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		num ^= screenLooks_.GetHashCode();
		if (originalLookUuid_ != null)
		{
			num ^= OriginalLookUuid.GetHashCode();
		}
		if (TransitionDuration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TransitionDuration);
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		screenLooks_.WriteTo(output, _repeated_screenLooks_codec);
		if (originalLookUuid_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(OriginalLookUuid);
		}
		if (TransitionDuration != 0.0)
		{
			output.WriteRawTag(41);
			output.WriteDouble(TransitionDuration);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		num += screenLooks_.CalculateSize(_repeated_screenLooks_codec);
		if (originalLookUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(OriginalLookUuid);
		}
		if (TransitionDuration != 0.0)
		{
			num += 9;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProAudienceLook other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		screenLooks_.Add(other.screenLooks_);
		if (other.originalLookUuid_ != null)
		{
			if (originalLookUuid_ == null)
			{
				OriginalLookUuid = new UUID();
			}
			OriginalLookUuid.MergeFrom(other.OriginalLookUuid);
		}
		if (other.TransitionDuration != 0.0)
		{
			TransitionDuration = other.TransitionDuration;
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				Name = input.ReadString();
				break;
			case 26u:
				screenLooks_.AddEntriesFrom(input, _repeated_screenLooks_codec);
				break;
			case 34u:
				if (originalLookUuid_ == null)
				{
					OriginalLookUuid = new UUID();
				}
				input.ReadMessage(OriginalLookUuid);
				break;
			case 41u:
				TransitionDuration = input.ReadDouble();
				break;
			}
		}
	}
}
