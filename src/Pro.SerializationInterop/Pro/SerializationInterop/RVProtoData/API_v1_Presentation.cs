using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Presentation : IMessage<API_v1_Presentation>, IMessage, IEquatable<API_v1_Presentation>, IDeepCloneable<API_v1_Presentation>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Destination
		{
			[OriginalName("presentation")]
			Presentation,
			[OriginalName("announcements")]
			Announcements
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SlideGroup : IMessage<SlideGroup>, IMessage, IEquatable<SlideGroup>, IDeepCloneable<SlideGroup>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Slide : IMessage<Slide>, IMessage, IEquatable<Slide>, IDeepCloneable<Slide>
				{
					private static readonly MessageParser<Slide> _parser = new MessageParser<Slide>(() => new Slide());

					private UnknownFieldSet _unknownFields;

					public const int EnabledFieldNumber = 1;

					private bool enabled_;

					public const int NotesFieldNumber = 2;

					private string notes_ = "";

					public const int TextFieldNumber = 3;

					private string text_ = "";

					public const int LabelFieldNumber = 5;

					private string label_ = "";

					public const int SizeFieldNumber = 6;

					private API_v1_Size size_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Slide> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => SlideGroup.Descriptor.NestedTypes[0];

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
					public string Notes
					{
						get
						{
							return notes_;
						}
						set
						{
							notes_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Text
					{
						get
						{
							return text_;
						}
						set
						{
							text_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Label
					{
						get
						{
							return label_;
						}
						set
						{
							label_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_Size Size
					{
						get
						{
							return size_;
						}
						set
						{
							size_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Slide()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Slide(Slide other)
						: this()
					{
						enabled_ = other.enabled_;
						notes_ = other.notes_;
						text_ = other.text_;
						label_ = other.label_;
						size_ = ((other.size_ != null) ? other.size_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Slide Clone()
					{
						return new Slide(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Slide);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Slide other)
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
						if (Notes != other.Notes)
						{
							return false;
						}
						if (Text != other.Text)
						{
							return false;
						}
						if (Label != other.Label)
						{
							return false;
						}
						if (!object.Equals(Size, other.Size))
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
						if (Notes.Length != 0)
						{
							num ^= Notes.GetHashCode();
						}
						if (Text.Length != 0)
						{
							num ^= Text.GetHashCode();
						}
						if (Label.Length != 0)
						{
							num ^= Label.GetHashCode();
						}
						if (size_ != null)
						{
							num ^= Size.GetHashCode();
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
						if (Notes.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(Notes);
						}
						if (Text.Length != 0)
						{
							output.WriteRawTag(26);
							output.WriteString(Text);
						}
						if (Label.Length != 0)
						{
							output.WriteRawTag(42);
							output.WriteString(Label);
						}
						if (size_ != null)
						{
							output.WriteRawTag(50);
							output.WriteMessage(Size);
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
						if (Notes.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Notes);
						}
						if (Text.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Text);
						}
						if (Label.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Label);
						}
						if (size_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Size);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Slide other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Enabled)
						{
							Enabled = other.Enabled;
						}
						if (other.Notes.Length != 0)
						{
							Notes = other.Notes;
						}
						if (other.Text.Length != 0)
						{
							Text = other.Text;
						}
						if (other.Label.Length != 0)
						{
							Label = other.Label;
						}
						if (other.size_ != null)
						{
							if (size_ == null)
							{
								Size = new API_v1_Size();
							}
							Size.MergeFrom(other.Size);
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
							case 8u:
								Enabled = input.ReadBool();
								break;
							case 18u:
								Notes = input.ReadString();
								break;
							case 26u:
								Text = input.ReadString();
								break;
							case 42u:
								Label = input.ReadString();
								break;
							case 50u:
								if (size_ == null)
								{
									Size = new API_v1_Size();
								}
								input.ReadMessage(Size);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<SlideGroup> _parser = new MessageParser<SlideGroup>(() => new SlideGroup());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int ColorFieldNumber = 2;

			private API_v1_Color color_;

			public const int SlidesFieldNumber = 3;

			private static readonly FieldCodec<Types.Slide> _repeated_slides_codec = FieldCodec.ForMessage(26u, Types.Slide.Parser);

			private readonly RepeatedField<Types.Slide> slides_ = new RepeatedField<Types.Slide>();

			public const int UuidFieldNumber = 4;

			private string uuid_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SlideGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public API_v1_Color Color
			{
				get
				{
					return color_;
				}
				set
				{
					color_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Slide> Slides => slides_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideGroup(SlideGroup other)
				: this()
			{
				name_ = other.name_;
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				slides_ = other.slides_.Clone();
				uuid_ = other.uuid_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideGroup Clone()
			{
				return new SlideGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SlideGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SlideGroup other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!object.Equals(Color, other.Color))
				{
					return false;
				}
				if (!slides_.Equals(other.slides_))
				{
					return false;
				}
				if (Uuid != other.Uuid)
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (color_ != null)
				{
					num ^= Color.GetHashCode();
				}
				num ^= slides_.GetHashCode();
				if (Uuid.Length != 0)
				{
					num ^= Uuid.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				if (color_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Color);
				}
				slides_.WriteTo(output, _repeated_slides_codec);
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(Uuid);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (color_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				num += slides_.CalculateSize(_repeated_slides_codec);
				if (Uuid.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SlideGroup other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.color_ != null)
				{
					if (color_ == null)
					{
						Color = new API_v1_Color();
					}
					Color.MergeFrom(other.Color);
				}
				slides_.Add(other.slides_);
				if (other.Uuid.Length != 0)
				{
					Uuid = other.Uuid;
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
						Name = input.ReadString();
						break;
					case 18u:
						if (color_ == null)
						{
							Color = new API_v1_Color();
						}
						input.ReadMessage(Color);
						break;
					case 26u:
						slides_.AddEntriesFrom(input, _repeated_slides_codec);
						break;
					case 34u:
						Uuid = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Arrangement : IMessage<Arrangement>, IMessage, IEquatable<Arrangement>, IDeepCloneable<Arrangement>
		{
			private static readonly MessageParser<Arrangement> _parser = new MessageParser<Arrangement>(() => new Arrangement());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			public const int GroupsFieldNumber = 2;

			private static readonly FieldCodec<string> _repeated_groups_codec = FieldCodec.ForString(18u);

			private readonly RepeatedField<string> groups_ = new RepeatedField<string>();

			public const int TotalCuesFieldNumber = 3;

			private uint totalCues_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Arrangement> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Presentation.Descriptor.NestedTypes[1];

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
			public RepeatedField<string> Groups => groups_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint TotalCues
			{
				get
				{
					return totalCues_;
				}
				set
				{
					totalCues_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Arrangement()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Arrangement(Arrangement other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				groups_ = other.groups_.Clone();
				totalCues_ = other.totalCues_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Arrangement Clone()
			{
				return new Arrangement(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Arrangement);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Arrangement other)
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
				if (!groups_.Equals(other.groups_))
				{
					return false;
				}
				if (TotalCues != other.TotalCues)
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
				num ^= groups_.GetHashCode();
				if (TotalCues != 0)
				{
					num ^= TotalCues.GetHashCode();
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
				groups_.WriteTo(output, _repeated_groups_codec);
				if (TotalCues != 0)
				{
					output.WriteRawTag(24);
					output.WriteUInt32(TotalCues);
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
				num += groups_.CalculateSize(_repeated_groups_codec);
				if (TotalCues != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(TotalCues);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Arrangement other)
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
				groups_.Add(other.groups_);
				if (other.TotalCues != 0)
				{
					TotalCues = other.TotalCues;
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
						groups_.AddEntriesFrom(input, _repeated_groups_codec);
						break;
					case 24u:
						TotalCues = input.ReadUInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Presentation> _parser = new MessageParser<API_v1_Presentation>(() => new API_v1_Presentation());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int GroupsFieldNumber = 2;

	private static readonly FieldCodec<Types.SlideGroup> _repeated_groups_codec = FieldCodec.ForMessage(18u, Types.SlideGroup.Parser);

	private readonly RepeatedField<Types.SlideGroup> groups_ = new RepeatedField<Types.SlideGroup>();

	public const int HasTimelineFieldNumber = 3;

	private bool hasTimeline_;

	public const int PresentationPathFieldNumber = 4;

	private string presentationPath_ = "";

	public const int DestinationFieldNumber = 5;

	private Types.Destination destination_;

	public const int ArrangementsFieldNumber = 6;

	private static readonly FieldCodec<Types.Arrangement> _repeated_arrangements_codec = FieldCodec.ForMessage(50u, Types.Arrangement.Parser);

	private readonly RepeatedField<Types.Arrangement> arrangements_ = new RepeatedField<Types.Arrangement>();

	public const int CurrentArrangementFieldNumber = 7;

	private string currentArrangement_ = "";

	public const int TypeFieldNumber = 8;

	private string type_ = "";

	public const int IsAuthorizedFieldNumber = 9;

	private bool isAuthorized_;

	public const int TotalCuesFieldNumber = 10;

	private uint totalCues_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Presentation> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PresentationReflection.Descriptor.MessageTypes[1];

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
	public RepeatedField<Types.SlideGroup> Groups => groups_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasTimeline
	{
		get
		{
			return hasTimeline_;
		}
		set
		{
			hasTimeline_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PresentationPath
	{
		get
		{
			return presentationPath_;
		}
		set
		{
			presentationPath_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Destination Destination
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
	public RepeatedField<Types.Arrangement> Arrangements => arrangements_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string CurrentArrangement
	{
		get
		{
			return currentArrangement_;
		}
		set
		{
			currentArrangement_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Type
	{
		get
		{
			return type_;
		}
		set
		{
			type_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsAuthorized
	{
		get
		{
			return isAuthorized_;
		}
		set
		{
			isAuthorized_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint TotalCues
	{
		get
		{
			return totalCues_;
		}
		set
		{
			totalCues_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation(API_v1_Presentation other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		groups_ = other.groups_.Clone();
		hasTimeline_ = other.hasTimeline_;
		presentationPath_ = other.presentationPath_;
		destination_ = other.destination_;
		arrangements_ = other.arrangements_.Clone();
		currentArrangement_ = other.currentArrangement_;
		type_ = other.type_;
		isAuthorized_ = other.isAuthorized_;
		totalCues_ = other.totalCues_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Presentation Clone()
	{
		return new API_v1_Presentation(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Presentation);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Presentation other)
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
		if (!groups_.Equals(other.groups_))
		{
			return false;
		}
		if (HasTimeline != other.HasTimeline)
		{
			return false;
		}
		if (PresentationPath != other.PresentationPath)
		{
			return false;
		}
		if (Destination != other.Destination)
		{
			return false;
		}
		if (!arrangements_.Equals(other.arrangements_))
		{
			return false;
		}
		if (CurrentArrangement != other.CurrentArrangement)
		{
			return false;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (IsAuthorized != other.IsAuthorized)
		{
			return false;
		}
		if (TotalCues != other.TotalCues)
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
		num ^= groups_.GetHashCode();
		if (HasTimeline)
		{
			num ^= HasTimeline.GetHashCode();
		}
		if (PresentationPath.Length != 0)
		{
			num ^= PresentationPath.GetHashCode();
		}
		if (Destination != 0)
		{
			num ^= Destination.GetHashCode();
		}
		num ^= arrangements_.GetHashCode();
		if (CurrentArrangement.Length != 0)
		{
			num ^= CurrentArrangement.GetHashCode();
		}
		if (Type.Length != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (IsAuthorized)
		{
			num ^= IsAuthorized.GetHashCode();
		}
		if (TotalCues != 0)
		{
			num ^= TotalCues.GetHashCode();
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
		groups_.WriteTo(output, _repeated_groups_codec);
		if (HasTimeline)
		{
			output.WriteRawTag(24);
			output.WriteBool(HasTimeline);
		}
		if (PresentationPath.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(PresentationPath);
		}
		if (Destination != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)Destination);
		}
		arrangements_.WriteTo(output, _repeated_arrangements_codec);
		if (CurrentArrangement.Length != 0)
		{
			output.WriteRawTag(58);
			output.WriteString(CurrentArrangement);
		}
		if (Type.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(Type);
		}
		if (IsAuthorized)
		{
			output.WriteRawTag(72);
			output.WriteBool(IsAuthorized);
		}
		if (TotalCues != 0)
		{
			output.WriteRawTag(80);
			output.WriteUInt32(TotalCues);
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
		num += groups_.CalculateSize(_repeated_groups_codec);
		if (HasTimeline)
		{
			num += 2;
		}
		if (PresentationPath.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PresentationPath);
		}
		if (Destination != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Destination);
		}
		num += arrangements_.CalculateSize(_repeated_arrangements_codec);
		if (CurrentArrangement.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(CurrentArrangement);
		}
		if (Type.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Type);
		}
		if (IsAuthorized)
		{
			num += 2;
		}
		if (TotalCues != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(TotalCues);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Presentation other)
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
		groups_.Add(other.groups_);
		if (other.HasTimeline)
		{
			HasTimeline = other.HasTimeline;
		}
		if (other.PresentationPath.Length != 0)
		{
			PresentationPath = other.PresentationPath;
		}
		if (other.Destination != 0)
		{
			Destination = other.Destination;
		}
		arrangements_.Add(other.arrangements_);
		if (other.CurrentArrangement.Length != 0)
		{
			CurrentArrangement = other.CurrentArrangement;
		}
		if (other.Type.Length != 0)
		{
			Type = other.Type;
		}
		if (other.IsAuthorized)
		{
			IsAuthorized = other.IsAuthorized;
		}
		if (other.TotalCues != 0)
		{
			TotalCues = other.TotalCues;
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
				groups_.AddEntriesFrom(input, _repeated_groups_codec);
				break;
			case 24u:
				HasTimeline = input.ReadBool();
				break;
			case 34u:
				PresentationPath = input.ReadString();
				break;
			case 40u:
				Destination = (Types.Destination)input.ReadEnum();
				break;
			case 50u:
				arrangements_.AddEntriesFrom(input, _repeated_arrangements_codec);
				break;
			case 58u:
				CurrentArrangement = input.ReadString();
				break;
			case 66u:
				Type = input.ReadString();
				break;
			case 72u:
				IsAuthorized = input.ReadBool();
				break;
			case 80u:
				TotalCues = input.ReadUInt32();
				break;
			}
		}
	}
}
