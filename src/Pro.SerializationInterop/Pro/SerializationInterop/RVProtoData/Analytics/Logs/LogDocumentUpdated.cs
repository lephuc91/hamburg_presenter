using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogDocumentUpdated : IMessage<LogDocumentUpdated>, IMessage, IEquatable<LogDocumentUpdated>, IDeepCloneable<LogDocumentUpdated>
{
	private static readonly MessageParser<LogDocumentUpdated> _parser = new MessageParser<LogDocumentUpdated>(() => new LogDocumentUpdated());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private LogMetadata metadata_;

	public const int DocumentIdentifierFieldNumber = 2;

	private string documentIdentifier_ = "";

	public const int PreviousDocumentNameFieldNumber = 3;

	private string previousDocumentName_ = "";

	public const int UpdatedDocumentNameFieldNumber = 4;

	private string updatedDocumentName_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogDocumentUpdated> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[15];

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
	public string DocumentIdentifier
	{
		get
		{
			return documentIdentifier_;
		}
		set
		{
			documentIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PreviousDocumentName
	{
		get
		{
			return previousDocumentName_;
		}
		set
		{
			previousDocumentName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string UpdatedDocumentName
	{
		get
		{
			return updatedDocumentName_;
		}
		set
		{
			updatedDocumentName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentUpdated()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentUpdated(LogDocumentUpdated other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		documentIdentifier_ = other.documentIdentifier_;
		previousDocumentName_ = other.previousDocumentName_;
		updatedDocumentName_ = other.updatedDocumentName_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentUpdated Clone()
	{
		return new LogDocumentUpdated(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogDocumentUpdated);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogDocumentUpdated other)
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
		if (DocumentIdentifier != other.DocumentIdentifier)
		{
			return false;
		}
		if (PreviousDocumentName != other.PreviousDocumentName)
		{
			return false;
		}
		if (UpdatedDocumentName != other.UpdatedDocumentName)
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
		if (DocumentIdentifier.Length != 0)
		{
			num ^= DocumentIdentifier.GetHashCode();
		}
		if (PreviousDocumentName.Length != 0)
		{
			num ^= PreviousDocumentName.GetHashCode();
		}
		if (UpdatedDocumentName.Length != 0)
		{
			num ^= UpdatedDocumentName.GetHashCode();
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
		if (DocumentIdentifier.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(DocumentIdentifier);
		}
		if (PreviousDocumentName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(PreviousDocumentName);
		}
		if (UpdatedDocumentName.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(UpdatedDocumentName);
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
		if (DocumentIdentifier.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DocumentIdentifier);
		}
		if (PreviousDocumentName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PreviousDocumentName);
		}
		if (UpdatedDocumentName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(UpdatedDocumentName);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogDocumentUpdated other)
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
		if (other.DocumentIdentifier.Length != 0)
		{
			DocumentIdentifier = other.DocumentIdentifier;
		}
		if (other.PreviousDocumentName.Length != 0)
		{
			PreviousDocumentName = other.PreviousDocumentName;
		}
		if (other.UpdatedDocumentName.Length != 0)
		{
			UpdatedDocumentName = other.UpdatedDocumentName;
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
				DocumentIdentifier = input.ReadString();
				break;
			case 26u:
				PreviousDocumentName = input.ReadString();
				break;
			case 34u:
				UpdatedDocumentName = input.ReadString();
				break;
			}
		}
	}
}
