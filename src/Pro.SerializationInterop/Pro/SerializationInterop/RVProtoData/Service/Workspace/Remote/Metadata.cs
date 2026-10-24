using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Metadata : IMessage<Metadata>, IMessage, IEquatable<Metadata>, IDeepCloneable<Metadata>
{
	private static readonly MessageParser<Metadata> _parser = new MessageParser<Metadata>(() => new Metadata());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private string uuid_ = "";

	public const int ProVersionFieldNumber = 2;

	private string proVersion_ = "";

	public const int NameFieldNumber = 3;

	private string name_ = "";

	public const int SizeFieldNumber = 10;

	private ulong size_;

	public const int CreatedFieldNumber = 11;

	private ulong created_;

	public const int UpdatedFieldNumber = 12;

	private ulong updated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Metadata> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => WorkspaceEntitiesRemoteReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ProVersion
	{
		get
		{
			return proVersion_;
		}
		set
		{
			proVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong Size
	{
		get
		{
			return size_;
		}
		set
		{
			size_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong Created
	{
		get
		{
			return created_;
		}
		set
		{
			created_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong Updated
	{
		get
		{
			return updated_;
		}
		set
		{
			updated_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Metadata()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Metadata(Metadata other)
		: this()
	{
		uuid_ = other.uuid_;
		proVersion_ = other.proVersion_;
		name_ = other.name_;
		size_ = other.size_;
		created_ = other.created_;
		updated_ = other.updated_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Metadata Clone()
	{
		return new Metadata(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Metadata);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Metadata other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Uuid != other.Uuid)
		{
			return false;
		}
		if (ProVersion != other.ProVersion)
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (Size != other.Size)
		{
			return false;
		}
		if (Created != other.Created)
		{
			return false;
		}
		if (Updated != other.Updated)
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
		if (Uuid.Length != 0)
		{
			num ^= Uuid.GetHashCode();
		}
		if (ProVersion.Length != 0)
		{
			num ^= ProVersion.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (Size != 0L)
		{
			num ^= Size.GetHashCode();
		}
		if (Created != 0L)
		{
			num ^= Created.GetHashCode();
		}
		if (Updated != 0L)
		{
			num ^= Updated.GetHashCode();
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
		if (Uuid.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Uuid);
		}
		if (ProVersion.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(ProVersion);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Name);
		}
		if (Size != 0L)
		{
			output.WriteRawTag(80);
			output.WriteUInt64(Size);
		}
		if (Created != 0L)
		{
			output.WriteRawTag(88);
			output.WriteUInt64(Created);
		}
		if (Updated != 0L)
		{
			output.WriteRawTag(96);
			output.WriteUInt64(Updated);
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
		if (Uuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
		}
		if (ProVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ProVersion);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (Size != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(Size);
		}
		if (Created != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(Created);
		}
		if (Updated != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(Updated);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Metadata other)
	{
		if (other != null)
		{
			if (other.Uuid.Length != 0)
			{
				Uuid = other.Uuid;
			}
			if (other.ProVersion.Length != 0)
			{
				ProVersion = other.ProVersion;
			}
			if (other.Name.Length != 0)
			{
				Name = other.Name;
			}
			if (other.Size != 0L)
			{
				Size = other.Size;
			}
			if (other.Created != 0L)
			{
				Created = other.Created;
			}
			if (other.Updated != 0L)
			{
				Updated = other.Updated;
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
				Uuid = input.ReadString();
				break;
			case 18u:
				ProVersion = input.ReadString();
				break;
			case 26u:
				Name = input.ReadString();
				break;
			case 80u:
				Size = input.ReadUInt64();
				break;
			case 88u:
				Created = input.ReadUInt64();
				break;
			case 96u:
				Updated = input.ReadUInt64();
				break;
			}
		}
	}
}
