using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaThumbnail : IMessage<MediaThumbnail>, IMessage, IEquatable<MediaThumbnail>, IDeepCloneable<MediaThumbnail>
{
	private static readonly MessageParser<MediaThumbnail> _parser = new MessageParser<MediaThumbnail>(() => new MediaThumbnail());

	private UnknownFieldSet _unknownFields;

	public const int WidthFieldNumber = 1;

	private int width_;

	public const int HeightFieldNumber = 2;

	private int height_;

	public const int DataFieldNumber = 3;

	private ByteString data_ = ByteString.Empty;

	public const int StrideFieldNumber = 4;

	private ulong stride_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaThumbnail> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[17];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public ByteString Data
	{
		get
		{
			return data_;
		}
		set
		{
			data_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong Stride
	{
		get
		{
			return stride_;
		}
		set
		{
			stride_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaThumbnail()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaThumbnail(MediaThumbnail other)
		: this()
	{
		width_ = other.width_;
		height_ = other.height_;
		data_ = other.data_;
		stride_ = other.stride_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaThumbnail Clone()
	{
		return new MediaThumbnail(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaThumbnail);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaThumbnail other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Width != other.Width)
		{
			return false;
		}
		if (Height != other.Height)
		{
			return false;
		}
		if (Data != other.Data)
		{
			return false;
		}
		if (Stride != other.Stride)
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
		if (Width != 0)
		{
			num ^= Width.GetHashCode();
		}
		if (Height != 0)
		{
			num ^= Height.GetHashCode();
		}
		if (Data.Length != 0)
		{
			num ^= Data.GetHashCode();
		}
		if (Stride != 0L)
		{
			num ^= Stride.GetHashCode();
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
		if (Width != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Width);
		}
		if (Height != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Height);
		}
		if (Data.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteBytes(Data);
		}
		if (Stride != 0L)
		{
			output.WriteRawTag(32);
			output.WriteUInt64(Stride);
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
		if (Width != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Width);
		}
		if (Height != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Height);
		}
		if (Data.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeBytesSize(Data);
		}
		if (Stride != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(Stride);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaThumbnail other)
	{
		if (other != null)
		{
			if (other.Width != 0)
			{
				Width = other.Width;
			}
			if (other.Height != 0)
			{
				Height = other.Height;
			}
			if (other.Data.Length != 0)
			{
				Data = other.Data;
			}
			if (other.Stride != 0L)
			{
				Stride = other.Stride;
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
				Width = input.ReadInt32();
				break;
			case 16u:
				Height = input.ReadInt32();
				break;
			case 26u:
				Data = input.ReadBytes();
				break;
			case 32u:
				Stride = input.ReadUInt64();
				break;
			}
		}
	}
}
