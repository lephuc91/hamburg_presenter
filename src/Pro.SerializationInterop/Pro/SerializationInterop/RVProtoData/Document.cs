using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Document : IMessage<Document>, IMessage, IEquatable<Document>, IDeepCloneable<Document>
{
	private static readonly MessageParser<Document> _parser = new MessageParser<Document>(() => new Document());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int UuidFieldNumber = 2;

	private UUID uuid_;

	public const int UsesRelativeUrlsFieldNumber = 3;

	private bool usesRelativeUrls_;

	public const int WorkspaceFieldNumber = 10;

	private Workspace workspace_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Document> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => BaseDocumentReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool UsesRelativeUrls
	{
		get
		{
			return usesRelativeUrls_;
		}
		set
		{
			usesRelativeUrls_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Workspace Workspace
	{
		get
		{
			return workspace_;
		}
		set
		{
			workspace_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Document()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Document(Document other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		usesRelativeUrls_ = other.usesRelativeUrls_;
		workspace_ = ((other.workspace_ != null) ? other.workspace_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Document Clone()
	{
		return new Document(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Document);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Document other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (UsesRelativeUrls != other.UsesRelativeUrls)
		{
			return false;
		}
		if (!object.Equals(Workspace, other.Workspace))
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (UsesRelativeUrls)
		{
			num ^= UsesRelativeUrls.GetHashCode();
		}
		if (workspace_ != null)
		{
			num ^= Workspace.GetHashCode();
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		if (uuid_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Uuid);
		}
		if (UsesRelativeUrls)
		{
			output.WriteRawTag(24);
			output.WriteBool(UsesRelativeUrls);
		}
		if (workspace_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(Workspace);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (UsesRelativeUrls)
		{
			num += 2;
		}
		if (workspace_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Workspace);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Document other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.UsesRelativeUrls)
		{
			UsesRelativeUrls = other.UsesRelativeUrls;
		}
		if (other.workspace_ != null)
		{
			if (workspace_ == null)
			{
				Workspace = new Workspace();
			}
			Workspace.MergeFrom(other.Workspace);
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 18u:
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 24u:
				UsesRelativeUrls = input.ReadBool();
				break;
			case 82u:
				if (workspace_ == null)
				{
					Workspace = new Workspace();
				}
				input.ReadMessage(Workspace);
				break;
			}
		}
	}
}
