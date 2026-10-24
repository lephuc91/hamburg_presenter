using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogOpenedWorkspace : IMessage<LogOpenedWorkspace>, IMessage, IEquatable<LogOpenedWorkspace>, IDeepCloneable<LogOpenedWorkspace>
{
	private static readonly MessageParser<LogOpenedWorkspace> _parser = new MessageParser<LogOpenedWorkspace>(() => new LogOpenedWorkspace());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private LogMetadata metadata_;

	public const int WorkspaceIdentifierFieldNumber = 2;

	private string workspaceIdentifier_ = "";

	public const int WorkspaceNameFieldNumber = 3;

	private string workspaceName_ = "";

	public const int IsLocalFieldNumber = 4;

	private bool isLocal_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogOpenedWorkspace> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[8];

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
	public string WorkspaceName
	{
		get
		{
			return workspaceName_;
		}
		set
		{
			workspaceName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsLocal
	{
		get
		{
			return isLocal_;
		}
		set
		{
			isLocal_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogOpenedWorkspace()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogOpenedWorkspace(LogOpenedWorkspace other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		workspaceIdentifier_ = other.workspaceIdentifier_;
		workspaceName_ = other.workspaceName_;
		isLocal_ = other.isLocal_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogOpenedWorkspace Clone()
	{
		return new LogOpenedWorkspace(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogOpenedWorkspace);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogOpenedWorkspace other)
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
		if (WorkspaceIdentifier != other.WorkspaceIdentifier)
		{
			return false;
		}
		if (WorkspaceName != other.WorkspaceName)
		{
			return false;
		}
		if (IsLocal != other.IsLocal)
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
		if (WorkspaceIdentifier.Length != 0)
		{
			num ^= WorkspaceIdentifier.GetHashCode();
		}
		if (WorkspaceName.Length != 0)
		{
			num ^= WorkspaceName.GetHashCode();
		}
		if (IsLocal)
		{
			num ^= IsLocal.GetHashCode();
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
		if (WorkspaceIdentifier.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(WorkspaceIdentifier);
		}
		if (WorkspaceName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(WorkspaceName);
		}
		if (IsLocal)
		{
			output.WriteRawTag(32);
			output.WriteBool(IsLocal);
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
		if (WorkspaceIdentifier.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(WorkspaceIdentifier);
		}
		if (WorkspaceName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(WorkspaceName);
		}
		if (IsLocal)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogOpenedWorkspace other)
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
		if (other.WorkspaceIdentifier.Length != 0)
		{
			WorkspaceIdentifier = other.WorkspaceIdentifier;
		}
		if (other.WorkspaceName.Length != 0)
		{
			WorkspaceName = other.WorkspaceName;
		}
		if (other.IsLocal)
		{
			IsLocal = other.IsLocal;
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
			case 18u:
				WorkspaceIdentifier = input.ReadString();
				break;
			case 26u:
				WorkspaceName = input.ReadString();
				break;
			case 32u:
				IsLocal = input.ReadBool();
				break;
			}
		}
	}
}
