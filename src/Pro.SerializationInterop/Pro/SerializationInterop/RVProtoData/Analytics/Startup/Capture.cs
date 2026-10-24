using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Capture : IMessage<Capture>, IMessage, IEquatable<Capture>, IDeepCloneable<Capture>
{
	private static readonly MessageParser<Capture> _parser = new MessageParser<Capture>(() => new Capture());

	private UnknownFieldSet _unknownFields;

	public const int PresetsCountFieldNumber = 1;

	private int presetsCount_;

	public const int DiskPresetsCountFieldNumber = 2;

	private int diskPresetsCount_;

	public const int RtmpPresetsCountFieldNumber = 3;

	private int rtmpPresetsCount_;

	public const int ResiPresetsCountFieldNumber = 4;

	private int resiPresetsCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Capture> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[16];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PresetsCount
	{
		get
		{
			return presetsCount_;
		}
		set
		{
			presetsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int DiskPresetsCount
	{
		get
		{
			return diskPresetsCount_;
		}
		set
		{
			diskPresetsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int RtmpPresetsCount
	{
		get
		{
			return rtmpPresetsCount_;
		}
		set
		{
			rtmpPresetsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ResiPresetsCount
	{
		get
		{
			return resiPresetsCount_;
		}
		set
		{
			resiPresetsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Capture()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Capture(Capture other)
		: this()
	{
		presetsCount_ = other.presetsCount_;
		diskPresetsCount_ = other.diskPresetsCount_;
		rtmpPresetsCount_ = other.rtmpPresetsCount_;
		resiPresetsCount_ = other.resiPresetsCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Capture Clone()
	{
		return new Capture(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Capture);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Capture other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PresetsCount != other.PresetsCount)
		{
			return false;
		}
		if (DiskPresetsCount != other.DiskPresetsCount)
		{
			return false;
		}
		if (RtmpPresetsCount != other.RtmpPresetsCount)
		{
			return false;
		}
		if (ResiPresetsCount != other.ResiPresetsCount)
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
		if (PresetsCount != 0)
		{
			num ^= PresetsCount.GetHashCode();
		}
		if (DiskPresetsCount != 0)
		{
			num ^= DiskPresetsCount.GetHashCode();
		}
		if (RtmpPresetsCount != 0)
		{
			num ^= RtmpPresetsCount.GetHashCode();
		}
		if (ResiPresetsCount != 0)
		{
			num ^= ResiPresetsCount.GetHashCode();
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
		if (PresetsCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(PresetsCount);
		}
		if (DiskPresetsCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(DiskPresetsCount);
		}
		if (RtmpPresetsCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(RtmpPresetsCount);
		}
		if (ResiPresetsCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(ResiPresetsCount);
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
		if (PresetsCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(PresetsCount);
		}
		if (DiskPresetsCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(DiskPresetsCount);
		}
		if (RtmpPresetsCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(RtmpPresetsCount);
		}
		if (ResiPresetsCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ResiPresetsCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Capture other)
	{
		if (other != null)
		{
			if (other.PresetsCount != 0)
			{
				PresetsCount = other.PresetsCount;
			}
			if (other.DiskPresetsCount != 0)
			{
				DiskPresetsCount = other.DiskPresetsCount;
			}
			if (other.RtmpPresetsCount != 0)
			{
				RtmpPresetsCount = other.RtmpPresetsCount;
			}
			if (other.ResiPresetsCount != 0)
			{
				ResiPresetsCount = other.ResiPresetsCount;
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
				PresetsCount = input.ReadInt32();
				break;
			case 16u:
				DiskPresetsCount = input.ReadInt32();
				break;
			case 24u:
				RtmpPresetsCount = input.ReadInt32();
				break;
			case 32u:
				ResiPresetsCount = input.ReadInt32();
				break;
			}
		}
	}
}
