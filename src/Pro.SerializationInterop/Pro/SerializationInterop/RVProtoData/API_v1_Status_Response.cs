using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Status_Response : IMessage<API_v1_Status_Response>, IMessage, IEquatable<API_v1_Status_Response>, IDeepCloneable<API_v1_Status_Response>
{
	public enum ResponseOneofCase
	{
		None,
		GetLayers,
		GetStageScreens,
		PutStageScreens,
		GetAudienceScreens,
		PutAudienceScreens,
		GetScreens,
		GetSlide
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetLayers : IMessage<GetLayers>, IMessage, IEquatable<GetLayers>, IDeepCloneable<GetLayers>
		{
			private static readonly MessageParser<GetLayers> _parser = new MessageParser<GetLayers>(() => new GetLayers());

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

			public const int AudioFieldNumber = 7;

			private bool audio_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayers> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Response.Descriptor.NestedTypes[0];

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
			public bool Audio
			{
				get
				{
					return audio_;
				}
				set
				{
					audio_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayers()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayers(GetLayers other)
				: this()
			{
				videoInput_ = other.videoInput_;
				media_ = other.media_;
				slide_ = other.slide_;
				announcements_ = other.announcements_;
				props_ = other.props_;
				messages_ = other.messages_;
				audio_ = other.audio_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayers Clone()
			{
				return new GetLayers(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetLayers);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetLayers other)
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
				if (Audio != other.Audio)
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
				if (Audio)
				{
					num ^= Audio.GetHashCode();
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
				if (Audio)
				{
					output.WriteRawTag(56);
					output.WriteBool(Audio);
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
				if (Audio)
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
			public void MergeFrom(GetLayers other)
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
					if (other.Audio)
					{
						Audio = other.Audio;
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
					case 56u:
						Audio = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetStageScreens : IMessage<GetStageScreens>, IMessage, IEquatable<GetStageScreens>, IDeepCloneable<GetStageScreens>
		{
			private static readonly MessageParser<GetStageScreens> _parser = new MessageParser<GetStageScreens>(() => new GetStageScreens());

			private UnknownFieldSet _unknownFields;

			public const int EnabledFieldNumber = 1;

			private bool enabled_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetStageScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enabled
			{
				get
				{
					return enabled_;
				}
				set
				{
					enabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStageScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStageScreens(GetStageScreens other)
				: this()
			{
				enabled_ = other.enabled_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStageScreens Clone()
			{
				return new GetStageScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetStageScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetStageScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Enabled != other.Enabled)
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
				if (Enabled)
				{
					num ^= Enabled.GetHashCode();
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
				if (Enabled)
				{
					output.WriteRawTag(8);
					output.WriteBool(Enabled);
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
				if (Enabled)
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
			public void MergeFrom(GetStageScreens other)
			{
				if (other != null)
				{
					if (other.Enabled)
					{
						Enabled = other.Enabled;
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
						Enabled = input.ReadBool();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutStageScreens : IMessage<PutStageScreens>, IMessage, IEquatable<PutStageScreens>, IDeepCloneable<PutStageScreens>
		{
			private static readonly MessageParser<PutStageScreens> _parser = new MessageParser<PutStageScreens>(() => new PutStageScreens());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutStageScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutStageScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutStageScreens(PutStageScreens other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutStageScreens Clone()
			{
				return new PutStageScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutStageScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutStageScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutStageScreens other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetAudienceScreens : IMessage<GetAudienceScreens>, IMessage, IEquatable<GetAudienceScreens>, IDeepCloneable<GetAudienceScreens>
		{
			private static readonly MessageParser<GetAudienceScreens> _parser = new MessageParser<GetAudienceScreens>(() => new GetAudienceScreens());

			private UnknownFieldSet _unknownFields;

			public const int EnabledFieldNumber = 1;

			private bool enabled_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetAudienceScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enabled
			{
				get
				{
					return enabled_;
				}
				set
				{
					enabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAudienceScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAudienceScreens(GetAudienceScreens other)
				: this()
			{
				enabled_ = other.enabled_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAudienceScreens Clone()
			{
				return new GetAudienceScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetAudienceScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetAudienceScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Enabled != other.Enabled)
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
				if (Enabled)
				{
					num ^= Enabled.GetHashCode();
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
				if (Enabled)
				{
					output.WriteRawTag(8);
					output.WriteBool(Enabled);
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
				if (Enabled)
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
			public void MergeFrom(GetAudienceScreens other)
			{
				if (other != null)
				{
					if (other.Enabled)
					{
						Enabled = other.Enabled;
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
						Enabled = input.ReadBool();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutAudienceScreens : IMessage<PutAudienceScreens>, IMessage, IEquatable<PutAudienceScreens>, IDeepCloneable<PutAudienceScreens>
		{
			private static readonly MessageParser<PutAudienceScreens> _parser = new MessageParser<PutAudienceScreens>(() => new PutAudienceScreens());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutAudienceScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutAudienceScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutAudienceScreens(PutAudienceScreens other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutAudienceScreens Clone()
			{
				return new PutAudienceScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutAudienceScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutAudienceScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutAudienceScreens other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetScreens : IMessage<GetScreens>, IMessage, IEquatable<GetScreens>, IDeepCloneable<GetScreens>
		{
			private static readonly MessageParser<GetScreens> _parser = new MessageParser<GetScreens>(() => new GetScreens());

			private UnknownFieldSet _unknownFields;

			public const int ScreensFieldNumber = 1;

			private static readonly FieldCodec<API_v1_ScreenConfig> _repeated_screens_codec = FieldCodec.ForMessage(10u, API_v1_ScreenConfig.Parser);

			private readonly RepeatedField<API_v1_ScreenConfig> screens_ = new RepeatedField<API_v1_ScreenConfig>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_ScreenConfig> Screens => screens_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens(GetScreens other)
				: this()
			{
				screens_ = other.screens_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens Clone()
			{
				return new GetScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!screens_.Equals(other.screens_))
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
				num ^= screens_.GetHashCode();
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
				screens_.WriteTo(output, _repeated_screens_codec);
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
				num += screens_.CalculateSize(_repeated_screens_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetScreens other)
			{
				if (other != null)
				{
					screens_.Add(other.screens_);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						screens_.AddEntriesFrom(input, _repeated_screens_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetSlide : IMessage<GetSlide>, IMessage, IEquatable<GetSlide>, IDeepCloneable<GetSlide>
		{
			private static readonly MessageParser<GetSlide> _parser = new MessageParser<GetSlide>(() => new GetSlide());

			private UnknownFieldSet _unknownFields;

			public const int CurrentFieldNumber = 1;

			private API_v1_SlideDisplayDetails current_;

			public const int NextFieldNumber = 2;

			private API_v1_SlideDisplayDetails next_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetSlide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Status_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_SlideDisplayDetails Current
			{
				get
				{
					return current_;
				}
				set
				{
					current_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_SlideDisplayDetails Next
			{
				get
				{
					return next_;
				}
				set
				{
					next_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSlide()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSlide(GetSlide other)
				: this()
			{
				current_ = ((other.current_ != null) ? other.current_.Clone() : null);
				next_ = ((other.next_ != null) ? other.next_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSlide Clone()
			{
				return new GetSlide(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetSlide);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetSlide other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Current, other.Current))
				{
					return false;
				}
				if (!object.Equals(Next, other.Next))
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
				if (current_ != null)
				{
					num ^= Current.GetHashCode();
				}
				if (next_ != null)
				{
					num ^= Next.GetHashCode();
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
				if (current_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Current);
				}
				if (next_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Next);
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
				if (current_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Current);
				}
				if (next_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Next);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetSlide other)
			{
				if (other == null)
				{
					return;
				}
				if (other.current_ != null)
				{
					if (current_ == null)
					{
						Current = new API_v1_SlideDisplayDetails();
					}
					Current.MergeFrom(other.Current);
				}
				if (other.next_ != null)
				{
					if (next_ == null)
					{
						Next = new API_v1_SlideDisplayDetails();
					}
					Next.MergeFrom(other.Next);
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
						if (current_ == null)
						{
							Current = new API_v1_SlideDisplayDetails();
						}
						input.ReadMessage(Current);
						break;
					case 18u:
						if (next_ == null)
						{
							Next = new API_v1_SlideDisplayDetails();
						}
						input.ReadMessage(Next);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Status_Response> _parser = new MessageParser<API_v1_Status_Response>(() => new API_v1_Status_Response());

	private UnknownFieldSet _unknownFields;

	public const int GetLayersFieldNumber = 1;

	public const int GetStageScreensFieldNumber = 2;

	public const int PutStageScreensFieldNumber = 3;

	public const int GetAudienceScreensFieldNumber = 4;

	public const int PutAudienceScreensFieldNumber = 5;

	public const int GetScreensFieldNumber = 6;

	public const int GetSlideFieldNumber = 7;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Status_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1StatusReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayers GetLayers
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetLayers)
			{
				return null;
			}
			return (Types.GetLayers)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetLayers : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetStageScreens GetStageScreens
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetStageScreens)
			{
				return null;
			}
			return (Types.GetStageScreens)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetStageScreens : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutStageScreens PutStageScreens
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutStageScreens)
			{
				return null;
			}
			return (Types.PutStageScreens)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutStageScreens : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetAudienceScreens GetAudienceScreens
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetAudienceScreens)
			{
				return null;
			}
			return (Types.GetAudienceScreens)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetAudienceScreens : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutAudienceScreens PutAudienceScreens
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutAudienceScreens)
			{
				return null;
			}
			return (Types.PutAudienceScreens)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutAudienceScreens : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetScreens GetScreens
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetScreens)
			{
				return null;
			}
			return (Types.GetScreens)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetScreens : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetSlide GetSlide
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetSlide)
			{
				return null;
			}
			return (Types.GetSlide)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetSlide : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Status_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Status_Response(API_v1_Status_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetLayers:
			GetLayers = other.GetLayers.Clone();
			break;
		case ResponseOneofCase.GetStageScreens:
			GetStageScreens = other.GetStageScreens.Clone();
			break;
		case ResponseOneofCase.PutStageScreens:
			PutStageScreens = other.PutStageScreens.Clone();
			break;
		case ResponseOneofCase.GetAudienceScreens:
			GetAudienceScreens = other.GetAudienceScreens.Clone();
			break;
		case ResponseOneofCase.PutAudienceScreens:
			PutAudienceScreens = other.PutAudienceScreens.Clone();
			break;
		case ResponseOneofCase.GetScreens:
			GetScreens = other.GetScreens.Clone();
			break;
		case ResponseOneofCase.GetSlide:
			GetSlide = other.GetSlide.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Status_Response Clone()
	{
		return new API_v1_Status_Response(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponse()
	{
		responseCase_ = ResponseOneofCase.None;
		response_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Status_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Status_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetLayers, other.GetLayers))
		{
			return false;
		}
		if (!object.Equals(GetStageScreens, other.GetStageScreens))
		{
			return false;
		}
		if (!object.Equals(PutStageScreens, other.PutStageScreens))
		{
			return false;
		}
		if (!object.Equals(GetAudienceScreens, other.GetAudienceScreens))
		{
			return false;
		}
		if (!object.Equals(PutAudienceScreens, other.PutAudienceScreens))
		{
			return false;
		}
		if (!object.Equals(GetScreens, other.GetScreens))
		{
			return false;
		}
		if (!object.Equals(GetSlide, other.GetSlide))
		{
			return false;
		}
		if (ResponseCase != other.ResponseCase)
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
		if (responseCase_ == ResponseOneofCase.GetLayers)
		{
			num ^= GetLayers.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetStageScreens)
		{
			num ^= GetStageScreens.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutStageScreens)
		{
			num ^= PutStageScreens.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetAudienceScreens)
		{
			num ^= GetAudienceScreens.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutAudienceScreens)
		{
			num ^= PutAudienceScreens.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetScreens)
		{
			num ^= GetScreens.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetSlide)
		{
			num ^= GetSlide.GetHashCode();
		}
		num ^= (int)responseCase_;
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
		if (responseCase_ == ResponseOneofCase.GetLayers)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetLayers);
		}
		if (responseCase_ == ResponseOneofCase.GetStageScreens)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetStageScreens);
		}
		if (responseCase_ == ResponseOneofCase.PutStageScreens)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PutStageScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetAudienceScreens)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetAudienceScreens);
		}
		if (responseCase_ == ResponseOneofCase.PutAudienceScreens)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PutAudienceScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetScreens)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetSlide)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetSlide);
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
		if (responseCase_ == ResponseOneofCase.GetLayers)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLayers);
		}
		if (responseCase_ == ResponseOneofCase.GetStageScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetStageScreens);
		}
		if (responseCase_ == ResponseOneofCase.PutStageScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutStageScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetAudienceScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetAudienceScreens);
		}
		if (responseCase_ == ResponseOneofCase.PutAudienceScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutAudienceScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetSlide)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetSlide);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Status_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetLayers:
			if (GetLayers == null)
			{
				GetLayers = new Types.GetLayers();
			}
			GetLayers.MergeFrom(other.GetLayers);
			break;
		case ResponseOneofCase.GetStageScreens:
			if (GetStageScreens == null)
			{
				GetStageScreens = new Types.GetStageScreens();
			}
			GetStageScreens.MergeFrom(other.GetStageScreens);
			break;
		case ResponseOneofCase.PutStageScreens:
			if (PutStageScreens == null)
			{
				PutStageScreens = new Types.PutStageScreens();
			}
			PutStageScreens.MergeFrom(other.PutStageScreens);
			break;
		case ResponseOneofCase.GetAudienceScreens:
			if (GetAudienceScreens == null)
			{
				GetAudienceScreens = new Types.GetAudienceScreens();
			}
			GetAudienceScreens.MergeFrom(other.GetAudienceScreens);
			break;
		case ResponseOneofCase.PutAudienceScreens:
			if (PutAudienceScreens == null)
			{
				PutAudienceScreens = new Types.PutAudienceScreens();
			}
			PutAudienceScreens.MergeFrom(other.PutAudienceScreens);
			break;
		case ResponseOneofCase.GetScreens:
			if (GetScreens == null)
			{
				GetScreens = new Types.GetScreens();
			}
			GetScreens.MergeFrom(other.GetScreens);
			break;
		case ResponseOneofCase.GetSlide:
			if (GetSlide == null)
			{
				GetSlide = new Types.GetSlide();
			}
			GetSlide.MergeFrom(other.GetSlide);
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
				Types.GetLayers getLayers = new Types.GetLayers();
				if (responseCase_ == ResponseOneofCase.GetLayers)
				{
					getLayers.MergeFrom(GetLayers);
				}
				input.ReadMessage(getLayers);
				GetLayers = getLayers;
				break;
			}
			case 18u:
			{
				Types.GetStageScreens getStageScreens = new Types.GetStageScreens();
				if (responseCase_ == ResponseOneofCase.GetStageScreens)
				{
					getStageScreens.MergeFrom(GetStageScreens);
				}
				input.ReadMessage(getStageScreens);
				GetStageScreens = getStageScreens;
				break;
			}
			case 26u:
			{
				Types.PutStageScreens putStageScreens = new Types.PutStageScreens();
				if (responseCase_ == ResponseOneofCase.PutStageScreens)
				{
					putStageScreens.MergeFrom(PutStageScreens);
				}
				input.ReadMessage(putStageScreens);
				PutStageScreens = putStageScreens;
				break;
			}
			case 34u:
			{
				Types.GetAudienceScreens getAudienceScreens = new Types.GetAudienceScreens();
				if (responseCase_ == ResponseOneofCase.GetAudienceScreens)
				{
					getAudienceScreens.MergeFrom(GetAudienceScreens);
				}
				input.ReadMessage(getAudienceScreens);
				GetAudienceScreens = getAudienceScreens;
				break;
			}
			case 42u:
			{
				Types.PutAudienceScreens putAudienceScreens = new Types.PutAudienceScreens();
				if (responseCase_ == ResponseOneofCase.PutAudienceScreens)
				{
					putAudienceScreens.MergeFrom(PutAudienceScreens);
				}
				input.ReadMessage(putAudienceScreens);
				PutAudienceScreens = putAudienceScreens;
				break;
			}
			case 50u:
			{
				Types.GetScreens getScreens = new Types.GetScreens();
				if (responseCase_ == ResponseOneofCase.GetScreens)
				{
					getScreens.MergeFrom(GetScreens);
				}
				input.ReadMessage(getScreens);
				GetScreens = getScreens;
				break;
			}
			case 58u:
			{
				Types.GetSlide getSlide = new Types.GetSlide();
				if (responseCase_ == ResponseOneofCase.GetSlide)
				{
					getSlide.MergeFrom(GetSlide);
				}
				input.ReadMessage(getSlide);
				GetSlide = getSlide;
				break;
			}
			}
		}
	}
}
