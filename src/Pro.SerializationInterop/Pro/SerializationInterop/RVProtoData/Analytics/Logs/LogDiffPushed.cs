using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogDiffPushed : IMessage<LogDiffPushed>, IMessage, IEquatable<LogDiffPushed>, IDeepCloneable<LogDiffPushed>
{
	private static readonly MessageParser<LogDiffPushed> _parser = new MessageParser<LogDiffPushed>(() => new LogDiffPushed());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private LogMetadata metadata_;

	public const int DocumentIdentifierFieldNumber = 2;

	private string documentIdentifier_ = "";

	public const int DocumentNameFieldNumber = 3;

	private string documentName_ = "";

	public const int DiffMetadataFieldNumber = 4;

	private DiffMetadata diffMetadata_;

	public const int FromVersionVectorFieldNumber = 5;

	private string fromVersionVector_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogDiffPushed> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[5];

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
	public string DocumentName
	{
		get
		{
			return documentName_;
		}
		set
		{
			documentName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiffMetadata DiffMetadata
	{
		get
		{
			return diffMetadata_;
		}
		set
		{
			diffMetadata_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string FromVersionVector
	{
		get
		{
			return fromVersionVector_;
		}
		set
		{
			fromVersionVector_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDiffPushed()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDiffPushed(LogDiffPushed other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		documentIdentifier_ = other.documentIdentifier_;
		documentName_ = other.documentName_;
		diffMetadata_ = ((other.diffMetadata_ != null) ? other.diffMetadata_.Clone() : null);
		fromVersionVector_ = other.fromVersionVector_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDiffPushed Clone()
	{
		return new LogDiffPushed(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogDiffPushed);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogDiffPushed other)
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
		if (DocumentName != other.DocumentName)
		{
			return false;
		}
		if (!object.Equals(DiffMetadata, other.DiffMetadata))
		{
			return false;
		}
		if (FromVersionVector != other.FromVersionVector)
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
		if (DocumentName.Length != 0)
		{
			num ^= DocumentName.GetHashCode();
		}
		if (diffMetadata_ != null)
		{
			num ^= DiffMetadata.GetHashCode();
		}
		if (FromVersionVector.Length != 0)
		{
			num ^= FromVersionVector.GetHashCode();
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
		if (DocumentName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(DocumentName);
		}
		if (diffMetadata_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DiffMetadata);
		}
		if (FromVersionVector.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(FromVersionVector);
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
		if (DocumentName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DocumentName);
		}
		if (diffMetadata_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DiffMetadata);
		}
		if (FromVersionVector.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(FromVersionVector);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogDiffPushed other)
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
		if (other.DocumentName.Length != 0)
		{
			DocumentName = other.DocumentName;
		}
		if (other.diffMetadata_ != null)
		{
			if (diffMetadata_ == null)
			{
				DiffMetadata = new DiffMetadata();
			}
			DiffMetadata.MergeFrom(other.DiffMetadata);
		}
		if (other.FromVersionVector.Length != 0)
		{
			FromVersionVector = other.FromVersionVector;
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
				DocumentName = input.ReadString();
				break;
			case 34u:
				if (diffMetadata_ == null)
				{
					DiffMetadata = new DiffMetadata();
				}
				input.ReadMessage(DiffMetadata);
				break;
			case 42u:
				FromVersionVector = input.ReadString();
				break;
			}
		}
	}
}
