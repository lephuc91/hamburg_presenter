using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogWorkspaceResynchronized : IMessage<LogWorkspaceResynchronized>, IMessage, IEquatable<LogWorkspaceResynchronized>, IDeepCloneable<LogWorkspaceResynchronized>
{
	private static readonly MessageParser<LogWorkspaceResynchronized> _parser = new MessageParser<LogWorkspaceResynchronized>(() => new LogWorkspaceResynchronized());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private LogMetadata metadata_;

	public const int CauseFieldNumber = 2;

	private ResyncCause cause_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogWorkspaceResynchronized> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[18];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogMetadata Metadata
	{
		get
		{
			return metadata_;
		}
		set
		{
			metadata_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResyncCause Cause
	{
		get
		{
			return cause_;
		}
		set
		{
			cause_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspaceResynchronized()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspaceResynchronized(LogWorkspaceResynchronized other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		cause_ = other.cause_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspaceResynchronized Clone()
	{
		return new LogWorkspaceResynchronized(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogWorkspaceResynchronized);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogWorkspaceResynchronized other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Metadata, other.Metadata))
		{
			return false;
		}
		if (Cause != other.Cause)
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
		if (metadata_ != null)
		{
			num ^= Metadata.GetHashCode();
		}
		if (Cause != 0)
		{
			num ^= Cause.GetHashCode();
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
		if (metadata_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Metadata);
		}
		if (Cause != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Cause);
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
		if (metadata_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Metadata);
		}
		if (Cause != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Cause);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogWorkspaceResynchronized other)
	{
		if (other == null)
		{
			return;
		}
		if (other.metadata_ != null)
		{
			if (metadata_ == null)
			{
				Metadata = new LogMetadata();
			}
			Metadata.MergeFrom(other.Metadata);
		}
		if (other.Cause != 0)
		{
			Cause = other.Cause;
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
				if (metadata_ == null)
				{
					Metadata = new LogMetadata();
				}
				input.ReadMessage(Metadata);
				break;
			case 16u:
				Cause = (ResyncCause)input.ReadEnum();
				break;
			}
		}
	}
}
