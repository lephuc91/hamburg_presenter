using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RenderLayer : IMessage<RenderLayer>, IMessage, IEquatable<RenderLayer>, IDeepCloneable<RenderLayer>
{
	public enum LayerTypeOneofCase
	{
		None,
		Composite,
		Media,
		CutOut,
		BackgroundEffect,
		OutputScreen,
		Scrolling,
		SlideImage,
		Zone
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Composite : IMessage<Composite>, IMessage, IEquatable<Composite>, IDeepCloneable<Composite>
		{
			private static readonly MessageParser<Composite> _parser = new MessageParser<Composite>(() => new Composite());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Composite> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RenderLayer.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Composite()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Composite(Composite other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Composite Clone()
			{
				return new Composite(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Composite);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Composite other)
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
			public void MergeFrom(Composite other)
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
		public sealed class Scrolling : IMessage<Scrolling>, IMessage, IEquatable<Scrolling>, IDeepCloneable<Scrolling>
		{
			private static readonly MessageParser<Scrolling> _parser = new MessageParser<Scrolling>(() => new Scrolling());

			private UnknownFieldSet _unknownFields;

			public const int SegmentSizeFieldNumber = 1;

			private int segmentSize_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Scrolling> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RenderLayer.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int SegmentSize
			{
				get
				{
					return segmentSize_;
				}
				set
				{
					segmentSize_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Scrolling()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Scrolling(Scrolling other)
				: this()
			{
				segmentSize_ = other.segmentSize_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Scrolling Clone()
			{
				return new Scrolling(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Scrolling);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Scrolling other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (SegmentSize != other.SegmentSize)
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
				if (SegmentSize != 0)
				{
					num ^= SegmentSize.GetHashCode();
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
				if (SegmentSize != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(SegmentSize);
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
				if (SegmentSize != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(SegmentSize);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Scrolling other)
			{
				if (other != null)
				{
					if (other.SegmentSize != 0)
					{
						SegmentSize = other.SegmentSize;
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
						SegmentSize = input.ReadInt32();
					}
				}
			}
		}
	}

	private static readonly MessageParser<RenderLayer> _parser = new MessageParser<RenderLayer>(() => new RenderLayer());

	private UnknownFieldSet _unknownFields;

	public const int CompositeFieldNumber = 1;

	public const int MediaFieldNumber = 2;

	public const int CutOutFieldNumber = 3;

	public const int BackgroundEffectFieldNumber = 4;

	public const int OutputScreenFieldNumber = 5;

	public const int ScrollingFieldNumber = 6;

	public const int SlideImageFieldNumber = 7;

	public const int ZoneFieldNumber = 8;

	public const int BoundsFieldNumber = 9;

	private Graphics.Types.Rect bounds_;

	public const int FlipModeFieldNumber = 10;

	private Graphics.Types.Element.Types.FlipMode flipMode_;

	public const int RotationFieldNumber = 11;

	private double rotation_;

	public const int BuildIndexFieldNumber = 12;

	private int buildIndex_;

	public const int BuildOutFieldNumber = 13;

	private bool buildOut_;

	public const int BuildOutIndexFieldNumber = 14;

	private int buildOutIndex_;

	private object layerType_;

	private LayerTypeOneofCase layerTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RenderLayer> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => Rv2DReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Composite Composite
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.Composite)
			{
				return null;
			}
			return (Types.Composite)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.Composite : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media Media
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.Media)
			{
				return null;
			}
			return (Media)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.Media : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Text.Types.CutOutFill CutOut
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.CutOut)
			{
				return null;
			}
			return (Graphics.Types.Text.Types.CutOutFill)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.CutOut : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.BackgroundEffect BackgroundEffect
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.BackgroundEffect)
			{
				return null;
			}
			return (Graphics.Types.BackgroundEffect)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.BackgroundEffect : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide.Types.Element.Types.DataLink.Types.OutputScreen OutputScreen
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.OutputScreen)
			{
				return null;
			}
			return (Slide.Types.Element.Types.DataLink.Types.OutputScreen)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.OutputScreen : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Scrolling Scrolling
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.Scrolling)
			{
				return null;
			}
			return (Types.Scrolling)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.Scrolling : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide.Types.Element.Types.DataLink.Types.SlideImage SlideImage
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.SlideImage)
			{
				return null;
			}
			return (Slide.Types.Element.Types.DataLink.Types.SlideImage)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.SlideImage : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide.Types.Element.Types.DataLink.Types.Zone Zone
	{
		get
		{
			if (layerTypeCase_ != LayerTypeOneofCase.Zone)
			{
				return null;
			}
			return (Slide.Types.Element.Types.DataLink.Types.Zone)layerType_;
		}
		set
		{
			layerType_ = value;
			layerTypeCase_ = ((value != null) ? LayerTypeOneofCase.Zone : LayerTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Rect Bounds
	{
		get
		{
			return bounds_;
		}
		set
		{
			bounds_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Element.Types.FlipMode FlipMode
	{
		get
		{
			return flipMode_;
		}
		set
		{
			flipMode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Rotation
	{
		get
		{
			return rotation_;
		}
		set
		{
			rotation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int BuildIndex
	{
		get
		{
			return buildIndex_;
		}
		set
		{
			buildIndex_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool BuildOut
	{
		get
		{
			return buildOut_;
		}
		set
		{
			buildOut_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int BuildOutIndex
	{
		get
		{
			return buildOutIndex_;
		}
		set
		{
			buildOutIndex_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LayerTypeOneofCase LayerTypeCase => layerTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RenderLayer()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RenderLayer(RenderLayer other)
		: this()
	{
		bounds_ = ((other.bounds_ != null) ? other.bounds_.Clone() : null);
		flipMode_ = other.flipMode_;
		rotation_ = other.rotation_;
		buildIndex_ = other.buildIndex_;
		buildOut_ = other.buildOut_;
		buildOutIndex_ = other.buildOutIndex_;
		switch (other.LayerTypeCase)
		{
		case LayerTypeOneofCase.Composite:
			Composite = other.Composite.Clone();
			break;
		case LayerTypeOneofCase.Media:
			Media = other.Media.Clone();
			break;
		case LayerTypeOneofCase.CutOut:
			CutOut = other.CutOut.Clone();
			break;
		case LayerTypeOneofCase.BackgroundEffect:
			BackgroundEffect = other.BackgroundEffect.Clone();
			break;
		case LayerTypeOneofCase.OutputScreen:
			OutputScreen = other.OutputScreen.Clone();
			break;
		case LayerTypeOneofCase.Scrolling:
			Scrolling = other.Scrolling.Clone();
			break;
		case LayerTypeOneofCase.SlideImage:
			SlideImage = other.SlideImage.Clone();
			break;
		case LayerTypeOneofCase.Zone:
			Zone = other.Zone.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RenderLayer Clone()
	{
		return new RenderLayer(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearLayerType()
	{
		layerTypeCase_ = LayerTypeOneofCase.None;
		layerType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RenderLayer);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RenderLayer other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Composite, other.Composite))
		{
			return false;
		}
		if (!object.Equals(Media, other.Media))
		{
			return false;
		}
		if (!object.Equals(CutOut, other.CutOut))
		{
			return false;
		}
		if (!object.Equals(BackgroundEffect, other.BackgroundEffect))
		{
			return false;
		}
		if (!object.Equals(OutputScreen, other.OutputScreen))
		{
			return false;
		}
		if (!object.Equals(Scrolling, other.Scrolling))
		{
			return false;
		}
		if (!object.Equals(SlideImage, other.SlideImage))
		{
			return false;
		}
		if (!object.Equals(Zone, other.Zone))
		{
			return false;
		}
		if (!object.Equals(Bounds, other.Bounds))
		{
			return false;
		}
		if (FlipMode != other.FlipMode)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Rotation, other.Rotation))
		{
			return false;
		}
		if (BuildIndex != other.BuildIndex)
		{
			return false;
		}
		if (BuildOut != other.BuildOut)
		{
			return false;
		}
		if (BuildOutIndex != other.BuildOutIndex)
		{
			return false;
		}
		if (LayerTypeCase != other.LayerTypeCase)
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
		if (layerTypeCase_ == LayerTypeOneofCase.Composite)
		{
			num ^= Composite.GetHashCode();
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Media)
		{
			num ^= Media.GetHashCode();
		}
		if (layerTypeCase_ == LayerTypeOneofCase.CutOut)
		{
			num ^= CutOut.GetHashCode();
		}
		if (layerTypeCase_ == LayerTypeOneofCase.BackgroundEffect)
		{
			num ^= BackgroundEffect.GetHashCode();
		}
		if (layerTypeCase_ == LayerTypeOneofCase.OutputScreen)
		{
			num ^= OutputScreen.GetHashCode();
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Scrolling)
		{
			num ^= Scrolling.GetHashCode();
		}
		if (layerTypeCase_ == LayerTypeOneofCase.SlideImage)
		{
			num ^= SlideImage.GetHashCode();
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Zone)
		{
			num ^= Zone.GetHashCode();
		}
		if (bounds_ != null)
		{
			num ^= Bounds.GetHashCode();
		}
		if (FlipMode != 0)
		{
			num ^= FlipMode.GetHashCode();
		}
		if (Rotation != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Rotation);
		}
		if (BuildIndex != 0)
		{
			num ^= BuildIndex.GetHashCode();
		}
		if (BuildOut)
		{
			num ^= BuildOut.GetHashCode();
		}
		if (BuildOutIndex != 0)
		{
			num ^= BuildOutIndex.GetHashCode();
		}
		num ^= (int)layerTypeCase_;
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
		if (layerTypeCase_ == LayerTypeOneofCase.Composite)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Composite);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Media)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Media);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.CutOut)
		{
			output.WriteRawTag(26);
			output.WriteMessage(CutOut);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.BackgroundEffect)
		{
			output.WriteRawTag(34);
			output.WriteMessage(BackgroundEffect);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.OutputScreen)
		{
			output.WriteRawTag(42);
			output.WriteMessage(OutputScreen);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Scrolling)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Scrolling);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.SlideImage)
		{
			output.WriteRawTag(58);
			output.WriteMessage(SlideImage);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Zone)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Zone);
		}
		if (bounds_ != null)
		{
			output.WriteRawTag(74);
			output.WriteMessage(Bounds);
		}
		if (FlipMode != 0)
		{
			output.WriteRawTag(80);
			output.WriteEnum((int)FlipMode);
		}
		if (Rotation != 0.0)
		{
			output.WriteRawTag(89);
			output.WriteDouble(Rotation);
		}
		if (BuildIndex != 0)
		{
			output.WriteRawTag(96);
			output.WriteInt32(BuildIndex);
		}
		if (BuildOut)
		{
			output.WriteRawTag(104);
			output.WriteBool(BuildOut);
		}
		if (BuildOutIndex != 0)
		{
			output.WriteRawTag(112);
			output.WriteInt32(BuildOutIndex);
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
		if (layerTypeCase_ == LayerTypeOneofCase.Composite)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Composite);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Media)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Media);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.CutOut)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CutOut);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.BackgroundEffect)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundEffect);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.OutputScreen)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(OutputScreen);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Scrolling)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Scrolling);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.SlideImage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SlideImage);
		}
		if (layerTypeCase_ == LayerTypeOneofCase.Zone)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Zone);
		}
		if (bounds_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Bounds);
		}
		if (FlipMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)FlipMode);
		}
		if (Rotation != 0.0)
		{
			num += 9;
		}
		if (BuildIndex != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(BuildIndex);
		}
		if (BuildOut)
		{
			num += 2;
		}
		if (BuildOutIndex != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(BuildOutIndex);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RenderLayer other)
	{
		if (other == null)
		{
			return;
		}
		if (other.bounds_ != null)
		{
			if (bounds_ == null)
			{
				Bounds = new Graphics.Types.Rect();
			}
			Bounds.MergeFrom(other.Bounds);
		}
		if (other.FlipMode != 0)
		{
			FlipMode = other.FlipMode;
		}
		if (other.Rotation != 0.0)
		{
			Rotation = other.Rotation;
		}
		if (other.BuildIndex != 0)
		{
			BuildIndex = other.BuildIndex;
		}
		if (other.BuildOut)
		{
			BuildOut = other.BuildOut;
		}
		if (other.BuildOutIndex != 0)
		{
			BuildOutIndex = other.BuildOutIndex;
		}
		switch (other.LayerTypeCase)
		{
		case LayerTypeOneofCase.Composite:
			if (Composite == null)
			{
				Composite = new Types.Composite();
			}
			Composite.MergeFrom(other.Composite);
			break;
		case LayerTypeOneofCase.Media:
			if (Media == null)
			{
				Media = new Media();
			}
			Media.MergeFrom(other.Media);
			break;
		case LayerTypeOneofCase.CutOut:
			if (CutOut == null)
			{
				CutOut = new Graphics.Types.Text.Types.CutOutFill();
			}
			CutOut.MergeFrom(other.CutOut);
			break;
		case LayerTypeOneofCase.BackgroundEffect:
			if (BackgroundEffect == null)
			{
				BackgroundEffect = new Graphics.Types.BackgroundEffect();
			}
			BackgroundEffect.MergeFrom(other.BackgroundEffect);
			break;
		case LayerTypeOneofCase.OutputScreen:
			if (OutputScreen == null)
			{
				OutputScreen = new Slide.Types.Element.Types.DataLink.Types.OutputScreen();
			}
			OutputScreen.MergeFrom(other.OutputScreen);
			break;
		case LayerTypeOneofCase.Scrolling:
			if (Scrolling == null)
			{
				Scrolling = new Types.Scrolling();
			}
			Scrolling.MergeFrom(other.Scrolling);
			break;
		case LayerTypeOneofCase.SlideImage:
			if (SlideImage == null)
			{
				SlideImage = new Slide.Types.Element.Types.DataLink.Types.SlideImage();
			}
			SlideImage.MergeFrom(other.SlideImage);
			break;
		case LayerTypeOneofCase.Zone:
			if (Zone == null)
			{
				Zone = new Slide.Types.Element.Types.DataLink.Types.Zone();
			}
			Zone.MergeFrom(other.Zone);
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
				Types.Composite composite = new Types.Composite();
				if (layerTypeCase_ == LayerTypeOneofCase.Composite)
				{
					composite.MergeFrom(Composite);
				}
				input.ReadMessage(composite);
				Composite = composite;
				break;
			}
			case 18u:
			{
				Media media = new Media();
				if (layerTypeCase_ == LayerTypeOneofCase.Media)
				{
					media.MergeFrom(Media);
				}
				input.ReadMessage(media);
				Media = media;
				break;
			}
			case 26u:
			{
				Graphics.Types.Text.Types.CutOutFill cutOutFill = new Graphics.Types.Text.Types.CutOutFill();
				if (layerTypeCase_ == LayerTypeOneofCase.CutOut)
				{
					cutOutFill.MergeFrom(CutOut);
				}
				input.ReadMessage(cutOutFill);
				CutOut = cutOutFill;
				break;
			}
			case 34u:
			{
				Graphics.Types.BackgroundEffect backgroundEffect = new Graphics.Types.BackgroundEffect();
				if (layerTypeCase_ == LayerTypeOneofCase.BackgroundEffect)
				{
					backgroundEffect.MergeFrom(BackgroundEffect);
				}
				input.ReadMessage(backgroundEffect);
				BackgroundEffect = backgroundEffect;
				break;
			}
			case 42u:
			{
				Slide.Types.Element.Types.DataLink.Types.OutputScreen outputScreen = new Slide.Types.Element.Types.DataLink.Types.OutputScreen();
				if (layerTypeCase_ == LayerTypeOneofCase.OutputScreen)
				{
					outputScreen.MergeFrom(OutputScreen);
				}
				input.ReadMessage(outputScreen);
				OutputScreen = outputScreen;
				break;
			}
			case 50u:
			{
				Types.Scrolling scrolling = new Types.Scrolling();
				if (layerTypeCase_ == LayerTypeOneofCase.Scrolling)
				{
					scrolling.MergeFrom(Scrolling);
				}
				input.ReadMessage(scrolling);
				Scrolling = scrolling;
				break;
			}
			case 58u:
			{
				Slide.Types.Element.Types.DataLink.Types.SlideImage slideImage = new Slide.Types.Element.Types.DataLink.Types.SlideImage();
				if (layerTypeCase_ == LayerTypeOneofCase.SlideImage)
				{
					slideImage.MergeFrom(SlideImage);
				}
				input.ReadMessage(slideImage);
				SlideImage = slideImage;
				break;
			}
			case 66u:
			{
				Slide.Types.Element.Types.DataLink.Types.Zone zone = new Slide.Types.Element.Types.DataLink.Types.Zone();
				if (layerTypeCase_ == LayerTypeOneofCase.Zone)
				{
					zone.MergeFrom(Zone);
				}
				input.ReadMessage(zone);
				Zone = zone;
				break;
			}
			case 74u:
				if (bounds_ == null)
				{
					Bounds = new Graphics.Types.Rect();
				}
				input.ReadMessage(Bounds);
				break;
			case 80u:
				FlipMode = (Graphics.Types.Element.Types.FlipMode)input.ReadEnum();
				break;
			case 89u:
				Rotation = input.ReadDouble();
				break;
			case 96u:
				BuildIndex = input.ReadInt32();
				break;
			case 104u:
				BuildOut = input.ReadBool();
				break;
			case 112u:
				BuildOutIndex = input.ReadInt32();
				break;
			}
		}
	}
}
