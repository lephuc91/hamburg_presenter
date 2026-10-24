using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogDocumentConflict : IMessage<LogDocumentConflict>, IMessage, IEquatable<LogDocumentConflict>, IDeepCloneable<LogDocumentConflict>
{
	private static readonly MessageParser<LogDocumentConflict> _parser = new MessageParser<LogDocumentConflict>(() => new LogDocumentConflict());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private LogMetadata metadata_;

	public const int DocumentIdentifierFieldNumber = 2;

	private string documentIdentifier_ = "";

	public const int DocumentNameFieldNumber = 3;

	private string documentName_ = "";

	public const int FieldFieldNumber = 4;

	private Field field_;

	public const int ConflictTypeFieldNumber = 5;

	private ConflictType conflictType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogDocumentConflict> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[17];

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
	public Field Field
	{
		get
		{
			return field_;
		}
		set
		{
			field_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ConflictType ConflictType
	{
		get
		{
			return conflictType_;
		}
		set
		{
			conflictType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentConflict()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentConflict(LogDocumentConflict other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		documentIdentifier_ = other.documentIdentifier_;
		documentName_ = other.documentName_;
		field_ = other.field_;
		conflictType_ = other.conflictType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogDocumentConflict Clone()
	{
		return new LogDocumentConflict(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogDocumentConflict);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogDocumentConflict other)
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
		if (Field != other.Field)
		{
			return false;
		}
		if (ConflictType != other.ConflictType)
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
		if (Field != 0)
		{
			num ^= Field.GetHashCode();
		}
		if (ConflictType != 0)
		{
			num ^= ConflictType.GetHashCode();
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
		if (Field != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Field);
		}
		if (ConflictType != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)ConflictType);
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
		if (Field != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Field);
		}
		if (ConflictType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ConflictType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LogDocumentConflict other)
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
		if (other.Field != 0)
		{
			Field = other.Field;
		}
		if (other.ConflictType != 0)
		{
			ConflictType = other.ConflictType;
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
			case 32u:
				Field = (Field)input.ReadEnum();
				break;
			case 40u:
				ConflictType = (ConflictType)input.ReadEnum();
				break;
			}
		}
	}
}
