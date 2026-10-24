using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_DiskCapture : IMessage<API_v1_DiskCapture>, IMessage, IEquatable<API_v1_DiskCapture>, IDeepCloneable<API_v1_DiskCapture>
{
	private static readonly MessageParser<API_v1_DiskCapture> _parser = new MessageParser<API_v1_DiskCapture>(() => new API_v1_DiskCapture());

	private UnknownFieldSet _unknownFields;

	public const int FileLocationFieldNumber = 1;

	private string fileLocation_ = "";

	public const int CodecFieldNumber = 2;

	private string codec_ = "";

	public const int ResolutionFieldNumber = 3;

	private API_v1_Size resolution_;

	public const int FrameRateFieldNumber = 4;

	private double frameRate_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_DiskCapture> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1CaptureReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string FileLocation
	{
		get
		{
			return fileLocation_;
		}
		set
		{
			fileLocation_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Codec
	{
		get
		{
			return codec_;
		}
		set
		{
			codec_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Size Resolution
	{
		get
		{
			return resolution_;
		}
		set
		{
			resolution_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double FrameRate
	{
		get
		{
			return frameRate_;
		}
		set
		{
			frameRate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_DiskCapture()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_DiskCapture(API_v1_DiskCapture other)
		: this()
	{
		fileLocation_ = other.fileLocation_;
		codec_ = other.codec_;
		resolution_ = ((other.resolution_ != null) ? other.resolution_.Clone() : null);
		frameRate_ = other.frameRate_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_DiskCapture Clone()
	{
		return new API_v1_DiskCapture(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_DiskCapture);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_DiskCapture other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (FileLocation != other.FileLocation)
		{
			return false;
		}
		if (Codec != other.Codec)
		{
			return false;
		}
		if (!object.Equals(Resolution, other.Resolution))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FrameRate, other.FrameRate))
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
		if (FileLocation.Length != 0)
		{
			num ^= FileLocation.GetHashCode();
		}
		if (Codec.Length != 0)
		{
			num ^= Codec.GetHashCode();
		}
		if (resolution_ != null)
		{
			num ^= Resolution.GetHashCode();
		}
		if (FrameRate != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FrameRate);
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
		if (FileLocation.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(FileLocation);
		}
		if (Codec.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Codec);
		}
		if (resolution_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Resolution);
		}
		if (FrameRate != 0.0)
		{
			output.WriteRawTag(33);
			output.WriteDouble(FrameRate);
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
		if (FileLocation.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(FileLocation);
		}
		if (Codec.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Codec);
		}
		if (resolution_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Resolution);
		}
		if (FrameRate != 0.0)
		{
			num += 9;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_DiskCapture other)
	{
		if (other == null)
		{
			return;
		}
		if (other.FileLocation.Length != 0)
		{
			FileLocation = other.FileLocation;
		}
		if (other.Codec.Length != 0)
		{
			Codec = other.Codec;
		}
		if (other.resolution_ != null)
		{
			if (resolution_ == null)
			{
				Resolution = new API_v1_Size();
			}
			Resolution.MergeFrom(other.Resolution);
		}
		if (other.FrameRate != 0.0)
		{
			FrameRate = other.FrameRate;
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
				FileLocation = input.ReadString();
				break;
			case 18u:
				Codec = input.ReadString();
				break;
			case 26u:
				if (resolution_ == null)
				{
					Resolution = new API_v1_Size();
				}
				input.ReadMessage(Resolution);
				break;
			case 33u:
				FrameRate = input.ReadDouble();
				break;
			}
		}
	}
}
