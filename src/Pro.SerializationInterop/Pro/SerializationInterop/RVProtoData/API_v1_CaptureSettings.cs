using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_CaptureSettings : IMessage<API_v1_CaptureSettings>, IMessage, IEquatable<API_v1_CaptureSettings>, IDeepCloneable<API_v1_CaptureSettings>
{
	public enum DestinationOneofCase
	{
		None = 0,
		Disk = 3,
		Rtmp = 4,
		Resi = 5
	}

	private static readonly MessageParser<API_v1_CaptureSettings> _parser = new MessageParser<API_v1_CaptureSettings>(() => new API_v1_CaptureSettings());

	private UnknownFieldSet _unknownFields;

	public const int SourceFieldNumber = 1;

	private UUID source_;

	public const int AudioRoutingFieldNumber = 2;

	private static readonly FieldCodec<API_v1_AudioRouting> _repeated_audioRouting_codec = FieldCodec.ForMessage(18u, API_v1_AudioRouting.Parser);

	private readonly RepeatedField<API_v1_AudioRouting> audioRouting_ = new RepeatedField<API_v1_AudioRouting>();

	public const int DiskFieldNumber = 3;

	public const int RtmpFieldNumber = 4;

	public const int ResiFieldNumber = 5;

	private object destination_;

	private DestinationOneofCase destinationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_CaptureSettings> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1CaptureReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Source
	{
		get
		{
			return source_;
		}
		set
		{
			source_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<API_v1_AudioRouting> AudioRouting => audioRouting_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_DiskCapture Disk
	{
		get
		{
			if (destinationCase_ != DestinationOneofCase.Disk)
			{
				return null;
			}
			return (API_v1_DiskCapture)destination_;
		}
		set
		{
			destination_ = value;
			destinationCase_ = ((value != null) ? DestinationOneofCase.Disk : DestinationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_RTMPCapture Rtmp
	{
		get
		{
			if (destinationCase_ != DestinationOneofCase.Rtmp)
			{
				return null;
			}
			return (API_v1_RTMPCapture)destination_;
		}
		set
		{
			destination_ = value;
			destinationCase_ = ((value != null) ? DestinationOneofCase.Rtmp : DestinationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ResiCapture Resi
	{
		get
		{
			if (destinationCase_ != DestinationOneofCase.Resi)
			{
				return null;
			}
			return (API_v1_ResiCapture)destination_;
		}
		set
		{
			destination_ = value;
			destinationCase_ = ((value != null) ? DestinationOneofCase.Resi : DestinationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DestinationOneofCase DestinationCase => destinationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_CaptureSettings()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_CaptureSettings(API_v1_CaptureSettings other)
		: this()
	{
		source_ = ((other.source_ != null) ? other.source_.Clone() : null);
		audioRouting_ = other.audioRouting_.Clone();
		switch (other.DestinationCase)
		{
		case DestinationOneofCase.Disk:
			Disk = other.Disk.Clone();
			break;
		case DestinationOneofCase.Rtmp:
			Rtmp = other.Rtmp.Clone();
			break;
		case DestinationOneofCase.Resi:
			Resi = other.Resi.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_CaptureSettings Clone()
	{
		return new API_v1_CaptureSettings(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearDestination()
	{
		destinationCase_ = DestinationOneofCase.None;
		destination_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_CaptureSettings);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_CaptureSettings other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Source, other.Source))
		{
			return false;
		}
		if (!audioRouting_.Equals(other.audioRouting_))
		{
			return false;
		}
		if (!object.Equals(Disk, other.Disk))
		{
			return false;
		}
		if (!object.Equals(Rtmp, other.Rtmp))
		{
			return false;
		}
		if (!object.Equals(Resi, other.Resi))
		{
			return false;
		}
		if (DestinationCase != other.DestinationCase)
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
		if (source_ != null)
		{
			num ^= Source.GetHashCode();
		}
		num ^= audioRouting_.GetHashCode();
		if (destinationCase_ == DestinationOneofCase.Disk)
		{
			num ^= Disk.GetHashCode();
		}
		if (destinationCase_ == DestinationOneofCase.Rtmp)
		{
			num ^= Rtmp.GetHashCode();
		}
		if (destinationCase_ == DestinationOneofCase.Resi)
		{
			num ^= Resi.GetHashCode();
		}
		num ^= (int)destinationCase_;
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
		if (source_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Source);
		}
		audioRouting_.WriteTo(output, _repeated_audioRouting_codec);
		if (destinationCase_ == DestinationOneofCase.Disk)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Disk);
		}
		if (destinationCase_ == DestinationOneofCase.Rtmp)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Rtmp);
		}
		if (destinationCase_ == DestinationOneofCase.Resi)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Resi);
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
		if (source_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Source);
		}
		num += audioRouting_.CalculateSize(_repeated_audioRouting_codec);
		if (destinationCase_ == DestinationOneofCase.Disk)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Disk);
		}
		if (destinationCase_ == DestinationOneofCase.Rtmp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Rtmp);
		}
		if (destinationCase_ == DestinationOneofCase.Resi)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Resi);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_CaptureSettings other)
	{
		if (other == null)
		{
			return;
		}
		if (other.source_ != null)
		{
			if (source_ == null)
			{
				Source = new UUID();
			}
			Source.MergeFrom(other.Source);
		}
		audioRouting_.Add(other.audioRouting_);
		switch (other.DestinationCase)
		{
		case DestinationOneofCase.Disk:
			if (Disk == null)
			{
				Disk = new API_v1_DiskCapture();
			}
			Disk.MergeFrom(other.Disk);
			break;
		case DestinationOneofCase.Rtmp:
			if (Rtmp == null)
			{
				Rtmp = new API_v1_RTMPCapture();
			}
			Rtmp.MergeFrom(other.Rtmp);
			break;
		case DestinationOneofCase.Resi:
			if (Resi == null)
			{
				Resi = new API_v1_ResiCapture();
			}
			Resi.MergeFrom(other.Resi);
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
				if (source_ == null)
				{
					Source = new UUID();
				}
				input.ReadMessage(Source);
				break;
			case 18u:
				audioRouting_.AddEntriesFrom(input, _repeated_audioRouting_codec);
				break;
			case 26u:
			{
				API_v1_DiskCapture aPI_v1_DiskCapture = new API_v1_DiskCapture();
				if (destinationCase_ == DestinationOneofCase.Disk)
				{
					aPI_v1_DiskCapture.MergeFrom(Disk);
				}
				input.ReadMessage(aPI_v1_DiskCapture);
				Disk = aPI_v1_DiskCapture;
				break;
			}
			case 34u:
			{
				API_v1_RTMPCapture aPI_v1_RTMPCapture = new API_v1_RTMPCapture();
				if (destinationCase_ == DestinationOneofCase.Rtmp)
				{
					aPI_v1_RTMPCapture.MergeFrom(Rtmp);
				}
				input.ReadMessage(aPI_v1_RTMPCapture);
				Rtmp = aPI_v1_RTMPCapture;
				break;
			}
			case 42u:
			{
				API_v1_ResiCapture aPI_v1_ResiCapture = new API_v1_ResiCapture();
				if (destinationCase_ == DestinationOneofCase.Resi)
				{
					aPI_v1_ResiCapture.MergeFrom(Resi);
				}
				input.ReadMessage(aPI_v1_ResiCapture);
				Resi = aPI_v1_ResiCapture;
				break;
			}
			}
		}
	}
}
