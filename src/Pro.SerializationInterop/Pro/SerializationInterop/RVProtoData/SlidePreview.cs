using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SlidePreview : IMessage<SlidePreview>, IMessage, IEquatable<SlidePreview>, IDeepCloneable<SlidePreview>
{
	private static readonly MessageParser<SlidePreview> _parser = new MessageParser<SlidePreview>(() => new SlidePreview());

	private UnknownFieldSet _unknownFields;

	public const int CueFieldNumber = 1;

	private Cue cue_;

	public const int ElementFieldNumber = 2;

	private Slide.Types.Element element_;

	public const int BackgroundFieldNumber = 3;

	private Color background_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SlidePreview> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => Rv2DReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Cue Cue
	{
		get
		{
			return cue_;
		}
		set
		{
			cue_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide.Types.Element Element
	{
		get
		{
			return element_;
		}
		set
		{
			element_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color Background
	{
		get
		{
			return background_;
		}
		set
		{
			background_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlidePreview()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlidePreview(SlidePreview other)
		: this()
	{
		cue_ = ((other.cue_ != null) ? other.cue_.Clone() : null);
		element_ = ((other.element_ != null) ? other.element_.Clone() : null);
		background_ = ((other.background_ != null) ? other.background_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlidePreview Clone()
	{
		return new SlidePreview(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SlidePreview);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SlidePreview other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Cue, other.Cue))
		{
			return false;
		}
		if (!object.Equals(Element, other.Element))
		{
			return false;
		}
		if (!object.Equals(Background, other.Background))
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
		if (cue_ != null)
		{
			num ^= Cue.GetHashCode();
		}
		if (element_ != null)
		{
			num ^= Element.GetHashCode();
		}
		if (background_ != null)
		{
			num ^= Background.GetHashCode();
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
		if (cue_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Cue);
		}
		if (element_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Element);
		}
		if (background_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Background);
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
		if (cue_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Cue);
		}
		if (element_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Element);
		}
		if (background_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Background);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SlidePreview other)
	{
		if (other == null)
		{
			return;
		}
		if (other.cue_ != null)
		{
			if (cue_ == null)
			{
				Cue = new Cue();
			}
			Cue.MergeFrom(other.Cue);
		}
		if (other.element_ != null)
		{
			if (element_ == null)
			{
				Element = new Slide.Types.Element();
			}
			Element.MergeFrom(other.Element);
		}
		if (other.background_ != null)
		{
			if (background_ == null)
			{
				Background = new Color();
			}
			Background.MergeFrom(other.Background);
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
				if (cue_ == null)
				{
					Cue = new Cue();
				}
				input.ReadMessage(Cue);
				break;
			case 18u:
				if (element_ == null)
				{
					Element = new Slide.Types.Element();
				}
				input.ReadMessage(Element);
				break;
			case 26u:
				if (background_ == null)
				{
					Background = new Color();
				}
				input.ReadMessage(Background);
				break;
			}
		}
	}
}
