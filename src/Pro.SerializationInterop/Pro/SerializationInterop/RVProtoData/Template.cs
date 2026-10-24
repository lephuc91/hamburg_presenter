using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Template : IMessage<Template>, IMessage, IEquatable<Template>, IDeepCloneable<Template>
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

			public const int BaseSlideFieldNumber = 1;

			private Pro.SerializationInterop.RVProtoData.Slide baseSlide_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int ActionsFieldNumber = 3;

			private static readonly FieldCodec<Action> _repeated_actions_codec = FieldCodec.ForMessage(26u, Action.Parser);

			private readonly RepeatedField<Action> actions_ = new RepeatedField<Action>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Slide> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Template.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Pro.SerializationInterop.RVProtoData.Slide BaseSlide
			{
				get
				{
					return baseSlide_;
				}
				set
				{
					baseSlide_ = value;
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
			public RepeatedField<Action> Actions => actions_;

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
				baseSlide_ = ((other.baseSlide_ != null) ? other.baseSlide_.Clone() : null);
				name_ = other.name_;
				actions_ = other.actions_.Clone();
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
				if (!object.Equals(BaseSlide, other.BaseSlide))
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!actions_.Equals(other.actions_))
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
				if (baseSlide_ != null)
				{
					num ^= BaseSlide.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= actions_.GetHashCode();
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
				if (baseSlide_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(BaseSlide);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				actions_.WriteTo(output, _repeated_actions_codec);
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
				if (baseSlide_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BaseSlide);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += actions_.CalculateSize(_repeated_actions_codec);
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
				if (other.baseSlide_ != null)
				{
					if (baseSlide_ == null)
					{
						BaseSlide = new Pro.SerializationInterop.RVProtoData.Slide();
					}
					BaseSlide.MergeFrom(other.BaseSlide);
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				actions_.Add(other.actions_);
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
						if (baseSlide_ == null)
						{
							BaseSlide = new Pro.SerializationInterop.RVProtoData.Slide();
						}
						input.ReadMessage(BaseSlide);
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						actions_.AddEntriesFrom(input, _repeated_actions_codec);
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

			public const int SlidesFieldNumber = 3;

			private static readonly FieldCodec<Slide> _repeated_slides_codec = FieldCodec.ForMessage(26u, Slide.Parser);

			private readonly RepeatedField<Slide> slides_ = new RepeatedField<Slide>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Document> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Template.Descriptor.NestedTypes[1];

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
			public RepeatedField<Slide> Slides => slides_;

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
				slides_ = other.slides_.Clone();
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
				if (!slides_.Equals(other.slides_))
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
				num ^= slides_.GetHashCode();
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
				slides_.WriteTo(output, _repeated_slides_codec);
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
				num += slides_.CalculateSize(_repeated_slides_codec);
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
				slides_.Add(other.slides_);
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
					case 26u:
						slides_.AddEntriesFrom(input, _repeated_slides_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Template> _parser = new MessageParser<Template>(() => new Template());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Template> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TemplateReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Template()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Template(Template other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Template Clone()
	{
		return new Template(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Template);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Template other)
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
	public void MergeFrom(Template other)
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
