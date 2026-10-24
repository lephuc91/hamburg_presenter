using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AudioInputStartUp : IMessage<AudioInputStartUp>, IMessage, IEquatable<AudioInputStartUp>, IDeepCloneable<AudioInputStartUp>
{
	private static readonly MessageParser<AudioInputStartUp> _parser = new MessageParser<AudioInputStartUp>(() => new AudioInputStartUp());

	private UnknownFieldSet _unknownFields;

	public const int TotalInputCountFieldNumber = 1;

	private uint totalInputCount_;

	public const int OnInputCountFieldNumber = 2;

	private uint onInputCount_;

	public const int OffInputCountFieldNumber = 3;

	private uint offInputCount_;

	public const int AutoOnInputCountFieldNumber = 4;

	private uint autoOnInputCount_;

	public const int AutoOffInputCountFieldNumber = 5;

	private uint autoOffInputCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AudioInputStartUp> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[12];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint TotalInputCount
	{
		get
		{
			return totalInputCount_;
		}
		set
		{
			totalInputCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint OnInputCount
	{
		get
		{
			return onInputCount_;
		}
		set
		{
			onInputCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint OffInputCount
	{
		get
		{
			return offInputCount_;
		}
		set
		{
			offInputCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint AutoOnInputCount
	{
		get
		{
			return autoOnInputCount_;
		}
		set
		{
			autoOnInputCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint AutoOffInputCount
	{
		get
		{
			return autoOffInputCount_;
		}
		set
		{
			autoOffInputCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputStartUp()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputStartUp(AudioInputStartUp other)
		: this()
	{
		totalInputCount_ = other.totalInputCount_;
		onInputCount_ = other.onInputCount_;
		offInputCount_ = other.offInputCount_;
		autoOnInputCount_ = other.autoOnInputCount_;
		autoOffInputCount_ = other.autoOffInputCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputStartUp Clone()
	{
		return new AudioInputStartUp(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AudioInputStartUp);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AudioInputStartUp other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TotalInputCount != other.TotalInputCount)
		{
			return false;
		}
		if (OnInputCount != other.OnInputCount)
		{
			return false;
		}
		if (OffInputCount != other.OffInputCount)
		{
			return false;
		}
		if (AutoOnInputCount != other.AutoOnInputCount)
		{
			return false;
		}
		if (AutoOffInputCount != other.AutoOffInputCount)
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
		if (TotalInputCount != 0)
		{
			num ^= TotalInputCount.GetHashCode();
		}
		if (OnInputCount != 0)
		{
			num ^= OnInputCount.GetHashCode();
		}
		if (OffInputCount != 0)
		{
			num ^= OffInputCount.GetHashCode();
		}
		if (AutoOnInputCount != 0)
		{
			num ^= AutoOnInputCount.GetHashCode();
		}
		if (AutoOffInputCount != 0)
		{
			num ^= AutoOffInputCount.GetHashCode();
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
		if (TotalInputCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteUInt32(TotalInputCount);
		}
		if (OnInputCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(OnInputCount);
		}
		if (OffInputCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(OffInputCount);
		}
		if (AutoOnInputCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(AutoOnInputCount);
		}
		if (AutoOffInputCount != 0)
		{
			output.WriteRawTag(40);
			output.WriteUInt32(AutoOffInputCount);
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
		if (TotalInputCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(TotalInputCount);
		}
		if (OnInputCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(OnInputCount);
		}
		if (OffInputCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(OffInputCount);
		}
		if (AutoOnInputCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(AutoOnInputCount);
		}
		if (AutoOffInputCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(AutoOffInputCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AudioInputStartUp other)
	{
		if (other != null)
		{
			if (other.TotalInputCount != 0)
			{
				TotalInputCount = other.TotalInputCount;
			}
			if (other.OnInputCount != 0)
			{
				OnInputCount = other.OnInputCount;
			}
			if (other.OffInputCount != 0)
			{
				OffInputCount = other.OffInputCount;
			}
			if (other.AutoOnInputCount != 0)
			{
				AutoOnInputCount = other.AutoOnInputCount;
			}
			if (other.AutoOffInputCount != 0)
			{
				AutoOffInputCount = other.AutoOffInputCount;
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
				TotalInputCount = input.ReadUInt32();
				break;
			case 16u:
				OnInputCount = input.ReadUInt32();
				break;
			case 24u:
				OffInputCount = input.ReadUInt32();
				break;
			case 32u:
				AutoOnInputCount = input.ReadUInt32();
				break;
			case 40u:
				AutoOffInputCount = input.ReadUInt32();
				break;
			}
		}
	}
}
