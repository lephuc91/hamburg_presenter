using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaMetadataRequestInfo : IMessage<MediaMetadataRequestInfo>, IMessage, IEquatable<MediaMetadataRequestInfo>, IDeepCloneable<MediaMetadataRequestInfo>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum BufferFormat
		{
			[OriginalName("BUFFER_FORMAT_RAW")]
			Raw,
			[OriginalName("BUFFER_FORMAT_PNG")]
			Png,
			[OriginalName("BUFFER_FORMAT_NONE")]
			None
		}
	}

	private static readonly MessageParser<MediaMetadataRequestInfo> _parser = new MessageParser<MediaMetadataRequestInfo>(() => new MediaMetadataRequestInfo());

	private UnknownFieldSet _unknownFields;

	public const int FilePathFieldNumber = 1;

	private string filePath_ = "";

	public const int TimeFieldNumber = 2;

	private float time_;

	public const int WidthFieldNumber = 3;

	private uint width_;

	public const int HeightFieldNumber = 4;

	private uint height_;

	public const int EffectsFieldNumber = 5;

	private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(42u, Effect.Parser);

	private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

	public const int CropInsetsFieldNumber = 6;

	private Graphics.Types.EdgeInsets cropInsets_;

	public const int NativeRotationFieldNumber = 7;

	private Media.Types.DrawingProperties.Types.NativeRotationType nativeRotation_;

	public const int FlippedHorizontallyFieldNumber = 8;

	private bool flippedHorizontally_;

	public const int FlippedVerticallyFieldNumber = 9;

	private bool flippedVertically_;

	public const int AlphaTypeFieldNumber = 10;

	private AlphaType alphaType_;

	public const int BufferFormatFieldNumber = 11;

	private Types.BufferFormat bufferFormat_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaMetadataRequestInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => MediaMetadataReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string FilePath
	{
		get
		{
			return filePath_;
		}
		set
		{
			filePath_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Time
	{
		get
		{
			return time_;
		}
		set
		{
			time_ = value;
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
	public RepeatedField<Effect> Effects => effects_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.EdgeInsets CropInsets
	{
		get
		{
			return cropInsets_;
		}
		set
		{
			cropInsets_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media.Types.DrawingProperties.Types.NativeRotationType NativeRotation
	{
		get
		{
			return nativeRotation_;
		}
		set
		{
			nativeRotation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool FlippedHorizontally
	{
		get
		{
			return flippedHorizontally_;
		}
		set
		{
			flippedHorizontally_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool FlippedVertically
	{
		get
		{
			return flippedVertically_;
		}
		set
		{
			flippedVertically_ = value;
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
	public Types.BufferFormat BufferFormat
	{
		get
		{
			return bufferFormat_;
		}
		set
		{
			bufferFormat_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaMetadataRequestInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaMetadataRequestInfo(MediaMetadataRequestInfo other)
		: this()
	{
		filePath_ = other.filePath_;
		time_ = other.time_;
		width_ = other.width_;
		height_ = other.height_;
		effects_ = other.effects_.Clone();
		cropInsets_ = ((other.cropInsets_ != null) ? other.cropInsets_.Clone() : null);
		nativeRotation_ = other.nativeRotation_;
		flippedHorizontally_ = other.flippedHorizontally_;
		flippedVertically_ = other.flippedVertically_;
		alphaType_ = other.alphaType_;
		bufferFormat_ = other.bufferFormat_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaMetadataRequestInfo Clone()
	{
		return new MediaMetadataRequestInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaMetadataRequestInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaMetadataRequestInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (FilePath != other.FilePath)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Time, other.Time))
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
		if (!effects_.Equals(other.effects_))
		{
			return false;
		}
		if (!object.Equals(CropInsets, other.CropInsets))
		{
			return false;
		}
		if (NativeRotation != other.NativeRotation)
		{
			return false;
		}
		if (FlippedHorizontally != other.FlippedHorizontally)
		{
			return false;
		}
		if (FlippedVertically != other.FlippedVertically)
		{
			return false;
		}
		if (AlphaType != other.AlphaType)
		{
			return false;
		}
		if (BufferFormat != other.BufferFormat)
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
		if (FilePath.Length != 0)
		{
			num ^= FilePath.GetHashCode();
		}
		if (Time != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Time);
		}
		if (Width != 0)
		{
			num ^= Width.GetHashCode();
		}
		if (Height != 0)
		{
			num ^= Height.GetHashCode();
		}
		num ^= effects_.GetHashCode();
		if (cropInsets_ != null)
		{
			num ^= CropInsets.GetHashCode();
		}
		if (NativeRotation != 0)
		{
			num ^= NativeRotation.GetHashCode();
		}
		if (FlippedHorizontally)
		{
			num ^= FlippedHorizontally.GetHashCode();
		}
		if (FlippedVertically)
		{
			num ^= FlippedVertically.GetHashCode();
		}
		if (AlphaType != 0)
		{
			num ^= AlphaType.GetHashCode();
		}
		if (BufferFormat != 0)
		{
			num ^= BufferFormat.GetHashCode();
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
		if (FilePath.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(FilePath);
		}
		if (Time != 0f)
		{
			output.WriteRawTag(21);
			output.WriteFloat(Time);
		}
		if (Width != 0)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(Width);
		}
		if (Height != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(Height);
		}
		effects_.WriteTo(output, _repeated_effects_codec);
		if (cropInsets_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(CropInsets);
		}
		if (NativeRotation != 0)
		{
			output.WriteRawTag(56);
			output.WriteEnum((int)NativeRotation);
		}
		if (FlippedHorizontally)
		{
			output.WriteRawTag(64);
			output.WriteBool(FlippedHorizontally);
		}
		if (FlippedVertically)
		{
			output.WriteRawTag(72);
			output.WriteBool(FlippedVertically);
		}
		if (AlphaType != 0)
		{
			output.WriteRawTag(80);
			output.WriteEnum((int)AlphaType);
		}
		if (BufferFormat != 0)
		{
			output.WriteRawTag(88);
			output.WriteEnum((int)BufferFormat);
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
		if (FilePath.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(FilePath);
		}
		if (Time != 0f)
		{
			num += 5;
		}
		if (Width != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Width);
		}
		if (Height != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Height);
		}
		num += effects_.CalculateSize(_repeated_effects_codec);
		if (cropInsets_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CropInsets);
		}
		if (NativeRotation != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)NativeRotation);
		}
		if (FlippedHorizontally)
		{
			num += 2;
		}
		if (FlippedVertically)
		{
			num += 2;
		}
		if (AlphaType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AlphaType);
		}
		if (BufferFormat != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)BufferFormat);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaMetadataRequestInfo other)
	{
		if (other == null)
		{
			return;
		}
		if (other.FilePath.Length != 0)
		{
			FilePath = other.FilePath;
		}
		if (other.Time != 0f)
		{
			Time = other.Time;
		}
		if (other.Width != 0)
		{
			Width = other.Width;
		}
		if (other.Height != 0)
		{
			Height = other.Height;
		}
		effects_.Add(other.effects_);
		if (other.cropInsets_ != null)
		{
			if (cropInsets_ == null)
			{
				CropInsets = new Graphics.Types.EdgeInsets();
			}
			CropInsets.MergeFrom(other.CropInsets);
		}
		if (other.NativeRotation != 0)
		{
			NativeRotation = other.NativeRotation;
		}
		if (other.FlippedHorizontally)
		{
			FlippedHorizontally = other.FlippedHorizontally;
		}
		if (other.FlippedVertically)
		{
			FlippedVertically = other.FlippedVertically;
		}
		if (other.AlphaType != 0)
		{
			AlphaType = other.AlphaType;
		}
		if (other.BufferFormat != 0)
		{
			BufferFormat = other.BufferFormat;
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
				FilePath = input.ReadString();
				break;
			case 21u:
				Time = input.ReadFloat();
				break;
			case 24u:
				Width = input.ReadUInt32();
				break;
			case 32u:
				Height = input.ReadUInt32();
				break;
			case 42u:
				effects_.AddEntriesFrom(input, _repeated_effects_codec);
				break;
			case 50u:
				if (cropInsets_ == null)
				{
					CropInsets = new Graphics.Types.EdgeInsets();
				}
				input.ReadMessage(CropInsets);
				break;
			case 56u:
				NativeRotation = (Media.Types.DrawingProperties.Types.NativeRotationType)input.ReadEnum();
				break;
			case 64u:
				FlippedHorizontally = input.ReadBool();
				break;
			case 72u:
				FlippedVertically = input.ReadBool();
				break;
			case 80u:
				AlphaType = (AlphaType)input.ReadEnum();
				break;
			case 88u:
				BufferFormat = (Types.BufferFormat)input.ReadEnum();
				break;
			}
		}
	}
}
