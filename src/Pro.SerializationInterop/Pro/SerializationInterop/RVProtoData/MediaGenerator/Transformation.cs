using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaGenerator;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Transformation : IMessage<Transformation>, IMessage, IEquatable<Transformation>, IDeepCloneable<Transformation>
{
	private static readonly MessageParser<Transformation> _parser = new MessageParser<Transformation>(() => new Transformation());

	private UnknownFieldSet _unknownFields;

	public const int EffectsFieldNumber = 1;

	private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(10u, Effect.Parser);

	private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

	public const int PositionFieldNumber = 2;

	private float position_;

	public const int RotationFieldNumber = 3;

	private int rotation_;

	public const int WidthFieldNumber = 4;

	private uint width_;

	public const int HeightFieldNumber = 5;

	private uint height_;

	public const int InsetsTopFieldNumber = 6;

	private float insetsTop_;

	public const int InsetsLeftFieldNumber = 7;

	private float insetsLeft_;

	public const int InsetsRightFieldNumber = 8;

	private float insetsRight_;

	public const int InsetsBottomFieldNumber = 9;

	private float insetsBottom_;

	public const int FlipHorizontallyFieldNumber = 10;

	private bool flipHorizontally_;

	public const int FlipVerticallyFieldNumber = 11;

	private bool flipVertically_;

	public const int AlphaTypeFieldNumber = 12;

	private AlphaType alphaType_;

	public const int UseDefaultNativeRotationFieldNumber = 13;

	private bool useDefaultNativeRotation_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Transformation> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => HelperSnapshotReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Effect> Effects => effects_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Position
	{
		get
		{
			return position_;
		}
		set
		{
			position_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Rotation
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
	public uint Width
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
	public uint Height
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
	public float InsetsTop
	{
		get
		{
			return insetsTop_;
		}
		set
		{
			insetsTop_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float InsetsLeft
	{
		get
		{
			return insetsLeft_;
		}
		set
		{
			insetsLeft_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float InsetsRight
	{
		get
		{
			return insetsRight_;
		}
		set
		{
			insetsRight_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float InsetsBottom
	{
		get
		{
			return insetsBottom_;
		}
		set
		{
			insetsBottom_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool FlipHorizontally
	{
		get
		{
			return flipHorizontally_;
		}
		set
		{
			flipHorizontally_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool FlipVertically
	{
		get
		{
			return flipVertically_;
		}
		set
		{
			flipVertically_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AlphaType AlphaType
	{
		get
		{
			return alphaType_;
		}
		set
		{
			alphaType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool UseDefaultNativeRotation
	{
		get
		{
			return useDefaultNativeRotation_;
		}
		set
		{
			useDefaultNativeRotation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transformation()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transformation(Transformation other)
		: this()
	{
		effects_ = other.effects_.Clone();
		position_ = other.position_;
		rotation_ = other.rotation_;
		width_ = other.width_;
		height_ = other.height_;
		insetsTop_ = other.insetsTop_;
		insetsLeft_ = other.insetsLeft_;
		insetsRight_ = other.insetsRight_;
		insetsBottom_ = other.insetsBottom_;
		flipHorizontally_ = other.flipHorizontally_;
		flipVertically_ = other.flipVertically_;
		alphaType_ = other.alphaType_;
		useDefaultNativeRotation_ = other.useDefaultNativeRotation_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transformation Clone()
	{
		return new Transformation(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Transformation);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Transformation other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!effects_.Equals(other.effects_))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Position, other.Position))
		{
			return false;
		}
		if (Rotation != other.Rotation)
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
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(InsetsTop, other.InsetsTop))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(InsetsLeft, other.InsetsLeft))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(InsetsRight, other.InsetsRight))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(InsetsBottom, other.InsetsBottom))
		{
			return false;
		}
		if (FlipHorizontally != other.FlipHorizontally)
		{
			return false;
		}
		if (FlipVertically != other.FlipVertically)
		{
			return false;
		}
		if (AlphaType != other.AlphaType)
		{
			return false;
		}
		if (UseDefaultNativeRotation != other.UseDefaultNativeRotation)
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
		num ^= effects_.GetHashCode();
		if (Position != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Position);
		}
		if (Rotation != 0)
		{
			num ^= Rotation.GetHashCode();
		}
		if (Width != 0)
		{
			num ^= Width.GetHashCode();
		}
		if (Height != 0)
		{
			num ^= Height.GetHashCode();
		}
		if (InsetsTop != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(InsetsTop);
		}
		if (InsetsLeft != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(InsetsLeft);
		}
		if (InsetsRight != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(InsetsRight);
		}
		if (InsetsBottom != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(InsetsBottom);
		}
		if (FlipHorizontally)
		{
			num ^= FlipHorizontally.GetHashCode();
		}
		if (FlipVertically)
		{
			num ^= FlipVertically.GetHashCode();
		}
		if (AlphaType != 0)
		{
			num ^= AlphaType.GetHashCode();
		}
		if (UseDefaultNativeRotation)
		{
			num ^= UseDefaultNativeRotation.GetHashCode();
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
		effects_.WriteTo(output, _repeated_effects_codec);
		if (Position != 0f)
		{
			output.WriteRawTag(21);
			output.WriteFloat(Position);
		}
		if (Rotation != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(Rotation);
		}
		if (Width != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(Width);
		}
		if (Height != 0)
		{
			output.WriteRawTag(40);
			output.WriteUInt32(Height);
		}
		if (InsetsTop != 0f)
		{
			output.WriteRawTag(53);
			output.WriteFloat(InsetsTop);
		}
		if (InsetsLeft != 0f)
		{
			output.WriteRawTag(61);
			output.WriteFloat(InsetsLeft);
		}
		if (InsetsRight != 0f)
		{
			output.WriteRawTag(69);
			output.WriteFloat(InsetsRight);
		}
		if (InsetsBottom != 0f)
		{
			output.WriteRawTag(77);
			output.WriteFloat(InsetsBottom);
		}
		if (FlipHorizontally)
		{
			output.WriteRawTag(80);
			output.WriteBool(FlipHorizontally);
		}
		if (FlipVertically)
		{
			output.WriteRawTag(88);
			output.WriteBool(FlipVertically);
		}
		if (AlphaType != 0)
		{
			output.WriteRawTag(96);
			output.WriteEnum((int)AlphaType);
		}
		if (UseDefaultNativeRotation)
		{
			output.WriteRawTag(104);
			output.WriteBool(UseDefaultNativeRotation);
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
		num += effects_.CalculateSize(_repeated_effects_codec);
		if (Position != 0f)
		{
			num += 5;
		}
		if (Rotation != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Rotation);
		}
		if (Width != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Width);
		}
		if (Height != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Height);
		}
		if (InsetsTop != 0f)
		{
			num += 5;
		}
		if (InsetsLeft != 0f)
		{
			num += 5;
		}
		if (InsetsRight != 0f)
		{
			num += 5;
		}
		if (InsetsBottom != 0f)
		{
			num += 5;
		}
		if (FlipHorizontally)
		{
			num += 2;
		}
		if (FlipVertically)
		{
			num += 2;
		}
		if (AlphaType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AlphaType);
		}
		if (UseDefaultNativeRotation)
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
	public void MergeFrom(Transformation other)
	{
		if (other != null)
		{
			effects_.Add(other.effects_);
			if (other.Position != 0f)
			{
				Position = other.Position;
			}
			if (other.Rotation != 0)
			{
				Rotation = other.Rotation;
			}
			if (other.Width != 0)
			{
				Width = other.Width;
			}
			if (other.Height != 0)
			{
				Height = other.Height;
			}
			if (other.InsetsTop != 0f)
			{
				InsetsTop = other.InsetsTop;
			}
			if (other.InsetsLeft != 0f)
			{
				InsetsLeft = other.InsetsLeft;
			}
			if (other.InsetsRight != 0f)
			{
				InsetsRight = other.InsetsRight;
			}
			if (other.InsetsBottom != 0f)
			{
				InsetsBottom = other.InsetsBottom;
			}
			if (other.FlipHorizontally)
			{
				FlipHorizontally = other.FlipHorizontally;
			}
			if (other.FlipVertically)
			{
				FlipVertically = other.FlipVertically;
			}
			if (other.AlphaType != 0)
			{
				AlphaType = other.AlphaType;
			}
			if (other.UseDefaultNativeRotation)
			{
				UseDefaultNativeRotation = other.UseDefaultNativeRotation;
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
			case 10u:
				effects_.AddEntriesFrom(input, _repeated_effects_codec);
				break;
			case 21u:
				Position = input.ReadFloat();
				break;
			case 24u:
				Rotation = input.ReadInt32();
				break;
			case 32u:
				Width = input.ReadUInt32();
				break;
			case 40u:
				Height = input.ReadUInt32();
				break;
			case 53u:
				InsetsTop = input.ReadFloat();
				break;
			case 61u:
				InsetsLeft = input.ReadFloat();
				break;
			case 69u:
				InsetsRight = input.ReadFloat();
				break;
			case 77u:
				InsetsBottom = input.ReadFloat();
				break;
			case 80u:
				FlipHorizontally = input.ReadBool();
				break;
			case 88u:
				FlipVertically = input.ReadBool();
				break;
			case 96u:
				AlphaType = (AlphaType)input.ReadEnum();
				break;
			case 104u:
				UseDefaultNativeRotation = input.ReadBool();
				break;
			}
		}
	}
}
