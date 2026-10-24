using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PresentationSlide : IMessage<PresentationSlide>, IMessage, IEquatable<PresentationSlide>, IDeepCloneable<PresentationSlide>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Notes : IMessage<Notes>, IMessage, IEquatable<Notes>, IDeepCloneable<Notes>
		{
			private static readonly MessageParser<Notes> _parser = new MessageParser<Notes>(() => new Notes());

			private UnknownFieldSet _unknownFields;

			public const int RtfDataFieldNumber = 1;

			private ByteString rtfData_ = ByteString.Empty;

			public const int AttributesFieldNumber = 2;

			private Graphics.Types.Text.Types.Attributes attributes_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Notes> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PresentationSlide.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString RtfData
			{
				get
				{
					return rtfData_;
				}
				set
				{
					rtfData_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Graphics.Types.Text.Types.Attributes Attributes
			{
				get
				{
					return attributes_;
				}
				set
				{
					attributes_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Notes()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Notes(Notes other)
				: this()
			{
				rtfData_ = other.rtfData_;
				attributes_ = ((other.attributes_ != null) ? other.attributes_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Notes Clone()
			{
				return new Notes(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Notes);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Notes other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (RtfData != other.RtfData)
				{
					return false;
				}
				if (!object.Equals(Attributes, other.Attributes))
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
				if (RtfData.Length != 0)
				{
					num ^= RtfData.GetHashCode();
				}
				if (attributes_ != null)
				{
					num ^= Attributes.GetHashCode();
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
				if (RtfData.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteBytes(RtfData);
				}
				if (attributes_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Attributes);
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
				if (RtfData.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(RtfData);
				}
				if (attributes_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Attributes);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Notes other)
			{
				if (other == null)
				{
					return;
				}
				if (other.RtfData.Length != 0)
				{
					RtfData = other.RtfData;
				}
				if (other.attributes_ != null)
				{
					if (attributes_ == null)
					{
						Attributes = new Graphics.Types.Text.Types.Attributes();
					}
					Attributes.MergeFrom(other.Attributes);
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
						RtfData = input.ReadBytes();
						break;
					case 18u:
						if (attributes_ == null)
						{
							Attributes = new Graphics.Types.Text.Types.Attributes();
						}
						input.ReadMessage(Attributes);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<PresentationSlide> _parser = new MessageParser<PresentationSlide>(() => new PresentationSlide());

	private UnknownFieldSet _unknownFields;

	public const int BaseSlideFieldNumber = 1;

	private Slide baseSlide_;

	public const int NotesFieldNumber = 2;

	private Types.Notes notes_;

	public const int TemplateGuidelinesFieldNumber = 3;

	private static readonly FieldCodec<AlignmentGuide> _repeated_templateGuidelines_codec = FieldCodec.ForMessage(26u, AlignmentGuide.Parser);

	private readonly RepeatedField<AlignmentGuide> templateGuidelines_ = new RepeatedField<AlignmentGuide>();

	public const int ChordChartFieldNumber = 4;

	private URL chordChart_;

	public const int TransitionFieldNumber = 5;

	private Transition transition_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PresentationSlide> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PresentationSlideReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide BaseSlide
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
	public Types.Notes Notes
	{
		get
		{
			return notes_;
		}
		set
		{
			notes_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AlignmentGuide> TemplateGuidelines => templateGuidelines_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL ChordChart
	{
		get
		{
			return chordChart_;
		}
		set
		{
			chordChart_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PresentationSlide()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PresentationSlide(PresentationSlide other)
		: this()
	{
		baseSlide_ = ((other.baseSlide_ != null) ? other.baseSlide_.Clone() : null);
		notes_ = ((other.notes_ != null) ? other.notes_.Clone() : null);
		templateGuidelines_ = other.templateGuidelines_.Clone();
		chordChart_ = ((other.chordChart_ != null) ? other.chordChart_.Clone() : null);
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PresentationSlide Clone()
	{
		return new PresentationSlide(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PresentationSlide);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PresentationSlide other)
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
		if (!object.Equals(Notes, other.Notes))
		{
			return false;
		}
		if (!templateGuidelines_.Equals(other.templateGuidelines_))
		{
			return false;
		}
		if (!object.Equals(ChordChart, other.ChordChart))
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
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
		if (notes_ != null)
		{
			num ^= Notes.GetHashCode();
		}
		num ^= templateGuidelines_.GetHashCode();
		if (chordChart_ != null)
		{
			num ^= ChordChart.GetHashCode();
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
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
		if (baseSlide_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(BaseSlide);
		}
		if (notes_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Notes);
		}
		templateGuidelines_.WriteTo(output, _repeated_templateGuidelines_codec);
		if (chordChart_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(ChordChart);
		}
		if (transition_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Transition);
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
		if (baseSlide_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BaseSlide);
		}
		if (notes_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Notes);
		}
		num += templateGuidelines_.CalculateSize(_repeated_templateGuidelines_codec);
		if (chordChart_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChordChart);
		}
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PresentationSlide other)
	{
		if (other == null)
		{
			return;
		}
		if (other.baseSlide_ != null)
		{
			if (baseSlide_ == null)
			{
				BaseSlide = new Slide();
			}
			BaseSlide.MergeFrom(other.BaseSlide);
		}
		if (other.notes_ != null)
		{
			if (notes_ == null)
			{
				Notes = new Types.Notes();
			}
			Notes.MergeFrom(other.Notes);
		}
		templateGuidelines_.Add(other.templateGuidelines_);
		if (other.chordChart_ != null)
		{
			if (chordChart_ == null)
			{
				ChordChart = new URL();
			}
			ChordChart.MergeFrom(other.ChordChart);
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
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
				if (baseSlide_ == null)
				{
					BaseSlide = new Slide();
				}
				input.ReadMessage(BaseSlide);
				break;
			case 18u:
				if (notes_ == null)
				{
					Notes = new Types.Notes();
				}
				input.ReadMessage(Notes);
				break;
			case 26u:
				templateGuidelines_.AddEntriesFrom(input, _repeated_templateGuidelines_codec);
				break;
			case 34u:
				if (chordChart_ == null)
				{
					ChordChart = new URL();
				}
				input.ReadMessage(ChordChart);
				break;
			case 42u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			}
		}
	}
}
