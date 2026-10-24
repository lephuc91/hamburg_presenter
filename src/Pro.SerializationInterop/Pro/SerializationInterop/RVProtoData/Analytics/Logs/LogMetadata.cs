using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogMetadata : IMessage<LogMetadata>, IMessage, IEquatable<LogMetadata>, IDeepCloneable<LogMetadata>
{
	private static readonly MessageParser<LogMetadata> _parser = new MessageParser<LogMetadata>(() => new LogMetadata());

	private UnknownFieldSet _unknownFields;

	public const int PeerIdFieldNumber = 1;

	private string peerId_ = "";

	public const int LogMessageFieldNumber = 2;

	private string logMessage_ = "";

	public const int WorkspaceIdentifierFieldNumber = 3;

	private string workspaceIdentifier_ = "";

	public const int LogSourceFieldNumber = 4;

	private LogSource logSource_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogMetadata> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[20];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PeerId
	{
		get
		{
			return peerId_;
		}
		set
		{
			peerId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string LogMessage
	{
		get
		{
			return logMessage_;
		}
		set
		{
			logMessage_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string WorkspaceIdentifier
	{
		get
		{
			return workspaceIdentifier_;
		}
		set
		{
			workspaceIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogSource LogSource
	{
		get
		{
			return logSource_;
		}
		set
		{
			logSource_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogMetadata()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogMetadata(LogMetadata other)
		: this()
	{
		peerId_ = other.peerId_;
		logMessage_ = other.logMessage_;
		workspaceIdentifier_ = other.workspaceIdentifier_;
		logSource_ = other.logSource_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogMetadata Clone()
	{
		return new LogMetadata(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogMetadata);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogMetadata other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PeerId != other.PeerId)
		{
			return false;
		}
		if (LogMessage != other.LogMessage)
		{
			return false;
		}
		if (WorkspaceIdentifier != other.WorkspaceIdentifier)
		{
			return false;
		}
		if (LogSource != other.LogSource)
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
		if (PeerId.Length != 0)
		{
			num ^= PeerId.GetHashCode();
		}
		if (LogMessage.Length != 0)
		{
			num ^= LogMessage.GetHashCode();
		}
		if (WorkspaceIdentifier.Length != 0)
		{
			num ^= WorkspaceIdentifier.GetHashCode();
		}
		if (LogSource != 0)
		{
			num ^= LogSource.GetHashCode();
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
		if (PeerId.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(PeerId);
		}
		if (LogMessage.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(LogMessage);
		}
		if (WorkspaceIdentifier.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(WorkspaceIdentifier);
		}
		if (LogSource != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)LogSource);
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
		if (PeerId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PeerId);
		}
		if (LogMessage.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(LogMessage);
		}
		if (WorkspaceIdentifier.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(WorkspaceIdentifier);
		}
		if (LogSource != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LogSource);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogMetadata other)
	{
		if (other != null)
		{
			if (other.PeerId.Length != 0)
			{
				PeerId = other.PeerId;
			}
			if (other.LogMessage.Length != 0)
			{
				LogMessage = other.LogMessage;
			}
			if (other.WorkspaceIdentifier.Length != 0)
			{
				WorkspaceIdentifier = other.WorkspaceIdentifier;
			}
			if (other.LogSource != 0)
			{
				LogSource = other.LogSource;
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
			case 10u:
				PeerId = input.ReadString();
				break;
			case 18u:
				LogMessage = input.ReadString();
				break;
			case 26u:
				WorkspaceIdentifier = input.ReadString();
				break;
			case 32u:
				LogSource = (LogSource)input.ReadEnum();
				break;
			}
		}
	}
}
