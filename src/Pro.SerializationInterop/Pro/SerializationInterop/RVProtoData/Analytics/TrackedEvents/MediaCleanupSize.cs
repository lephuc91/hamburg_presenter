using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaCleanupSize : IMessage<MediaCleanupSize>, IMessage, IEquatable<MediaCleanupSize>, IDeepCloneable<MediaCleanupSize>
{
	private static readonly MessageParser<MediaCleanupSize> _parser = new MessageParser<MediaCleanupSize>(() => new MediaCleanupSize());

	private UnknownFieldSet _unknownFields;

	public const int BytesOfMediaFilesCleanedUpFieldNumber = 1;

	private ulong bytesOfMediaFilesCleanedUp_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaCleanupSize> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[31];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong BytesOfMediaFilesCleanedUp
	{
		get
		{
			return bytesOfMediaFilesCleanedUp_;
		}
		set
		{
			bytesOfMediaFilesCleanedUp_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaCleanupSize()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaCleanupSize(MediaCleanupSize other)
		: this()
	{
		bytesOfMediaFilesCleanedUp_ = other.bytesOfMediaFilesCleanedUp_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaCleanupSize Clone()
	{
		return new MediaCleanupSize(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaCleanupSize);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaCleanupSize other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (BytesOfMediaFilesCleanedUp != other.BytesOfMediaFilesCleanedUp)
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
		if (BytesOfMediaFilesCleanedUp != 0L)
		{
			num ^= BytesOfMediaFilesCleanedUp.GetHashCode();
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
		if (BytesOfMediaFilesCleanedUp != 0L)
		{
			output.WriteRawTag(8);
			output.WriteUInt64(BytesOfMediaFilesCleanedUp);
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
		if (BytesOfMediaFilesCleanedUp != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(BytesOfMediaFilesCleanedUp);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaCleanupSize other)
	{
		if (other != null)
		{
			if (other.BytesOfMediaFilesCleanedUp != 0L)
			{
				BytesOfMediaFilesCleanedUp = other.BytesOfMediaFilesCleanedUp;
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
				BytesOfMediaFilesCleanedUp = input.ReadUInt64();
			}
		}
	}
}
