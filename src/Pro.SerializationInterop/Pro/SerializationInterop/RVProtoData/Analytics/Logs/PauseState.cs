using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PauseState : IMessage<PauseState>, IMessage, IEquatable<PauseState>, IDeepCloneable<PauseState>
{
	private static readonly MessageParser<PauseState> _parser = new MessageParser<PauseState>(() => new PauseState());

	private UnknownFieldSet _unknownFields;

	public const int UntilTimeUtcFieldNumber = 1;

	private ulong untilTimeUtc_;

	public const int PausedAtUtcFieldNumber = 2;

	private ulong pausedAtUtc_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PauseState> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[11];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong UntilTimeUtc
	{
		get
		{
			return untilTimeUtc_;
		}
		set
		{
			untilTimeUtc_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong PausedAtUtc
	{
		get
		{
			return pausedAtUtc_;
		}
		set
		{
			pausedAtUtc_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseState()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseState(PauseState other)
		: this()
	{
		untilTimeUtc_ = other.untilTimeUtc_;
		pausedAtUtc_ = other.pausedAtUtc_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseState Clone()
	{
		return new PauseState(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PauseState);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PauseState other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (UntilTimeUtc != other.UntilTimeUtc)
		{
			return false;
		}
		if (PausedAtUtc != other.PausedAtUtc)
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
		if (UntilTimeUtc != 0L)
		{
			num ^= UntilTimeUtc.GetHashCode();
		}
		if (PausedAtUtc != 0L)
		{
			num ^= PausedAtUtc.GetHashCode();
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
		if (UntilTimeUtc != 0L)
		{
			output.WriteRawTag(8);
			output.WriteUInt64(UntilTimeUtc);
		}
		if (PausedAtUtc != 0L)
		{
			output.WriteRawTag(16);
			output.WriteUInt64(PausedAtUtc);
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
		if (UntilTimeUtc != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(UntilTimeUtc);
		}
		if (PausedAtUtc != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(PausedAtUtc);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PauseState other)
	{
		if (other != null)
		{
			if (other.UntilTimeUtc != 0L)
			{
				UntilTimeUtc = other.UntilTimeUtc;
			}
			if (other.PausedAtUtc != 0L)
			{
				PausedAtUtc = other.PausedAtUtc;
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
				UntilTimeUtc = input.ReadUInt64();
				break;
			case 16u:
				PausedAtUtc = input.ReadUInt64();
				break;
			}
		}
	}
}
