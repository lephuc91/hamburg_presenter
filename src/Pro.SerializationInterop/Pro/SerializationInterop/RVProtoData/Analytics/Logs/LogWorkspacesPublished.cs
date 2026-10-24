using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogWorkspacesPublished : IMessage<LogWorkspacesPublished>, IMessage, IEquatable<LogWorkspacesPublished>, IDeepCloneable<LogWorkspacesPublished>
{
	private static readonly MessageParser<LogWorkspacesPublished> _parser = new MessageParser<LogWorkspacesPublished>(() => new LogWorkspacesPublished());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private LogMetadata metadata_;

	public const int WorkspaceIdentifiersFieldNumber = 2;

	private static readonly FieldCodec<string> _repeated_workspaceIdentifiers_codec = FieldCodec.ForString(18u);

	private readonly RepeatedField<string> workspaceIdentifiers_ = new RepeatedField<string>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogWorkspacesPublished> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[1];

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
	public RepeatedField<string> WorkspaceIdentifiers => workspaceIdentifiers_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspacesPublished()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspacesPublished(LogWorkspacesPublished other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		workspaceIdentifiers_ = other.workspaceIdentifiers_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogWorkspacesPublished Clone()
	{
		return new LogWorkspacesPublished(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogWorkspacesPublished);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogWorkspacesPublished other)
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
		if (!workspaceIdentifiers_.Equals(other.workspaceIdentifiers_))
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
		num ^= workspaceIdentifiers_.GetHashCode();
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
		workspaceIdentifiers_.WriteTo(output, _repeated_workspaceIdentifiers_codec);
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
		num += workspaceIdentifiers_.CalculateSize(_repeated_workspaceIdentifiers_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogWorkspacesPublished other)
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
		workspaceIdentifiers_.Add(other.workspaceIdentifiers_);
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
				workspaceIdentifiers_.AddEntriesFrom(input, _repeated_workspaceIdentifiers_codec);
				break;
			}
		}
	}
}
