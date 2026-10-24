using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Stage : IMessage<Stage>, IMessage, IEquatable<Stage>, IDeepCloneable<Stage>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Layout : IMessage<Layout>, IMessage, IEquatable<Layout>, IDeepCloneable<Layout>
		{
			private static readonly MessageParser<Layout> _parser = new MessageParser<Layout>(() => new Layout());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int SlideFieldNumber = 3;

			private Slide slide_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Layout> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Stage.Descriptor.NestedTypes[0];

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
			public Slide Slide
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
			public Layout()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Layout(Layout other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				slide_ = ((other.slide_ != null) ? other.slide_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Layout Clone()
			{
				return new Layout(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Layout);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Layout other)
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
				if (!object.Equals(Slide, other.Slide))
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
				if (slide_ != null)
				{
					num ^= Slide.GetHashCode();
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
				if (slide_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Slide);
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
				if (slide_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Slide);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Layout other)
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
				if (other.slide_ != null)
				{
					if (slide_ == null)
					{
						Slide = new Slide();
					}
					Slide.MergeFrom(other.Slide);
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
						if (slide_ == null)
						{
							Slide = new Slide();
						}
						input.ReadMessage(Slide);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Document : IMessage<Document>, IMessage, IEquatable<Document>, IDeepCloneable<Document>
		{
			private static readonly MessageParser<Document> _parser = new MessageParser<Document>(() => new Document());

			private UnknownFieldSet _unknownFields;

			public const int ApplicationInfoFieldNumber = 1;

			private ApplicationInfo applicationInfo_;

			public const int LayoutsFieldNumber = 2;

			private static readonly FieldCodec<Layout> _repeated_layouts_codec = FieldCodec.ForMessage(18u, Layout.Parser);

			private readonly RepeatedField<Layout> layouts_ = new RepeatedField<Layout>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Document> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Stage.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ApplicationInfo ApplicationInfo
			{
				get
				{
					return applicationInfo_;
				}
				set
				{
					applicationInfo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Layout> Layouts => layouts_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Document()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Document(Document other)
				: this()
			{
				applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
				layouts_ = other.layouts_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Document Clone()
			{
				return new Document(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Document);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Document other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
				{
					return false;
				}
				if (!layouts_.Equals(other.layouts_))
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
				if (applicationInfo_ != null)
				{
					num ^= ApplicationInfo.GetHashCode();
				}
				num ^= layouts_.GetHashCode();
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
				if (applicationInfo_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(ApplicationInfo);
				}
				layouts_.WriteTo(output, _repeated_layouts_codec);
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
				if (applicationInfo_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
				}
				num += layouts_.CalculateSize(_repeated_layouts_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Document other)
			{
				if (other == null)
				{
					return;
				}
				if (other.applicationInfo_ != null)
				{
					if (applicationInfo_ == null)
					{
						ApplicationInfo = new ApplicationInfo();
					}
					ApplicationInfo.MergeFrom(other.ApplicationInfo);
				}
				layouts_.Add(other.layouts_);
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
						if (applicationInfo_ == null)
						{
							ApplicationInfo = new ApplicationInfo();
						}
						input.ReadMessage(ApplicationInfo);
						break;
					case 18u:
						layouts_.AddEntriesFrom(input, _repeated_layouts_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ScreenAssignment : IMessage<ScreenAssignment>, IMessage, IEquatable<ScreenAssignment>, IDeepCloneable<ScreenAssignment>
		{
			private static readonly MessageParser<ScreenAssignment> _parser = new MessageParser<ScreenAssignment>(() => new ScreenAssignment());

			private UnknownFieldSet _unknownFields;

			public const int ScreenFieldNumber = 1;

			private CollectionElementType screen_;

			public const int LayoutFieldNumber = 2;

			private CollectionElementType layout_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ScreenAssignment> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Stage.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Screen
			{
				get
				{
					return screen_;
				}
				set
				{
					screen_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CollectionElementType Layout
			{
				get
				{
					return layout_;
				}
				set
				{
					layout_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScreenAssignment()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScreenAssignment(ScreenAssignment other)
				: this()
			{
				screen_ = ((other.screen_ != null) ? other.screen_.Clone() : null);
				layout_ = ((other.layout_ != null) ? other.layout_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScreenAssignment Clone()
			{
				return new ScreenAssignment(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ScreenAssignment);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ScreenAssignment other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Screen, other.Screen))
				{
					return false;
				}
				if (!object.Equals(Layout, other.Layout))
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
				if (screen_ != null)
				{
					num ^= Screen.GetHashCode();
				}
				if (layout_ != null)
				{
					num ^= Layout.GetHashCode();
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
				if (screen_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Screen);
				}
				if (layout_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Layout);
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
				if (screen_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Screen);
				}
				if (layout_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Layout);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ScreenAssignment other)
			{
				if (other == null)
				{
					return;
				}
				if (other.screen_ != null)
				{
					if (screen_ == null)
					{
						Screen = new CollectionElementType();
					}
					Screen.MergeFrom(other.Screen);
				}
				if (other.layout_ != null)
				{
					if (layout_ == null)
					{
						Layout = new CollectionElementType();
					}
					Layout.MergeFrom(other.Layout);
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
						if (screen_ == null)
						{
							Screen = new CollectionElementType();
						}
						input.ReadMessage(Screen);
						break;
					case 18u:
						if (layout_ == null)
						{
							Layout = new CollectionElementType();
						}
						input.ReadMessage(Layout);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Stage> _parser = new MessageParser<Stage>(() => new Stage());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Stage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => StageReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Stage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Stage(Stage other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Stage Clone()
	{
		return new Stage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Stage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Stage other)
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
	public void MergeFrom(Stage other)
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
