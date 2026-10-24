using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Summary : IMessage<Summary>, IMessage, IEquatable<Summary>, IDeepCloneable<Summary>
{
	private static readonly MessageParser<Summary> _parser = new MessageParser<Summary>(() => new Summary());

	private UnknownFieldSet _unknownFields;

	public const int TotalScreensFieldNumber = 1;

	private int totalScreens_;

	public const int AudienceScreenCountFieldNumber = 2;

	private int audienceScreenCount_;

	public const int StageScreenCountFieldNumber = 3;

	private int stageScreenCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Summary> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalScreens
	{
		get
		{
			return totalScreens_;
		}
		set
		{
			totalScreens_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int AudienceScreenCount
	{
		get
		{
			return audienceScreenCount_;
		}
		set
		{
			audienceScreenCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int StageScreenCount
	{
		get
		{
			return stageScreenCount_;
		}
		set
		{
			stageScreenCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Summary()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Summary(Summary other)
		: this()
	{
		totalScreens_ = other.totalScreens_;
		audienceScreenCount_ = other.audienceScreenCount_;
		stageScreenCount_ = other.stageScreenCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Summary Clone()
	{
		return new Summary(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Summary);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Summary other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TotalScreens != other.TotalScreens)
		{
			return false;
		}
		if (AudienceScreenCount != other.AudienceScreenCount)
		{
			return false;
		}
		if (StageScreenCount != other.StageScreenCount)
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
		if (TotalScreens != 0)
		{
			num ^= TotalScreens.GetHashCode();
		}
		if (AudienceScreenCount != 0)
		{
			num ^= AudienceScreenCount.GetHashCode();
		}
		if (StageScreenCount != 0)
		{
			num ^= StageScreenCount.GetHashCode();
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
		if (TotalScreens != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TotalScreens);
		}
		if (AudienceScreenCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(AudienceScreenCount);
		}
		if (StageScreenCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(StageScreenCount);
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
		if (TotalScreens != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalScreens);
		}
		if (AudienceScreenCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(AudienceScreenCount);
		}
		if (StageScreenCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(StageScreenCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Summary other)
	{
		if (other != null)
		{
			if (other.TotalScreens != 0)
			{
				TotalScreens = other.TotalScreens;
			}
			if (other.AudienceScreenCount != 0)
			{
				AudienceScreenCount = other.AudienceScreenCount;
			}
			if (other.StageScreenCount != 0)
			{
				StageScreenCount = other.StageScreenCount;
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
				TotalScreens = input.ReadInt32();
				break;
			case 16u:
				AudienceScreenCount = input.ReadInt32();
				break;
			case 24u:
				StageScreenCount = input.ReadInt32();
				break;
			}
		}
	}
}
