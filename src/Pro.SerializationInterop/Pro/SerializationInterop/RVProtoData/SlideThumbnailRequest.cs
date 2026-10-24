using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SlideThumbnailRequest : IMessage<SlideThumbnailRequest>, IMessage, IEquatable<SlideThumbnailRequest>, IDeepCloneable<SlideThumbnailRequest>
{
	private static readonly MessageParser<SlideThumbnailRequest> _parser = new MessageParser<SlideThumbnailRequest>(() => new SlideThumbnailRequest());

	private UnknownFieldSet _unknownFields;

	public const int CueFieldNumber = 1;

	private Cue cue_;

	public const int BackgroundFieldNumber = 2;

	private Color background_;

	public const int WidthFieldNumber = 3;

	private int width_;

	public const int HeightFieldNumber = 4;

	private int height_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SlideThumbnailRequest> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[21];

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
	public int Width
	{
		get
		{
			return width_;
		}
		set
		{
			width_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Height
	{
		get
		{
			return height_;
		}
		set
		{
			height_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideThumbnailRequest()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideThumbnailRequest(SlideThumbnailRequest other)
		: this()
	{
		cue_ = ((other.cue_ != null) ? other.cue_.Clone() : null);
		background_ = ((other.background_ != null) ? other.background_.Clone() : null);
		width_ = other.width_;
		height_ = other.height_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideThumbnailRequest Clone()
	{
		return new SlideThumbnailRequest(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SlideThumbnailRequest);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SlideThumbnailRequest other)
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
		if (!object.Equals(Background, other.Background))
		{
			return false;
		}
		if (Width != other.Width)
		{
			return false;
		}
		if (Height != other.Height)
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
		if (background_ != null)
		{
			num ^= Background.GetHashCode();
		}
		if (Width != 0)
		{
			num ^= Width.GetHashCode();
		}
		if (Height != 0)
		{
			num ^= Height.GetHashCode();
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
		if (background_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Background);
		}
		if (Width != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(Width);
		}
		if (Height != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(Height);
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
		if (background_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Background);
		}
		if (Width != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Width);
		}
		if (Height != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Height);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SlideThumbnailRequest other)
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
		if (other.background_ != null)
		{
			if (background_ == null)
			{
				Background = new Color();
			}
			Background.MergeFrom(other.Background);
		}
		if (other.Width != 0)
		{
			Width = other.Width;
		}
		if (other.Height != 0)
		{
			Height = other.Height;
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
				if (background_ == null)
				{
					Background = new Color();
				}
				input.ReadMessage(Background);
				break;
			case 24u:
				Width = input.ReadInt32();
				break;
			case 32u:
				Height = input.ReadInt32();
				break;
			}
		}
	}
}
