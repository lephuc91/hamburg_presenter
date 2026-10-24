using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace.Local;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Metadata : IMessage<Metadata>, IMessage, IEquatable<Metadata>, IDeepCloneable<Metadata>
{
	private static readonly MessageParser<Metadata> _parser = new MessageParser<Metadata>(() => new Metadata());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private static readonly string UuidDefaultValue = "";

	private string uuid_;

	public const int ProVersionFieldNumber = 2;

	private string proVersion_ = "";

	public const int NameFieldNumber = 3;

	private string name_ = "";

	public const int PathFieldNumber = 4;

	private string path_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Metadata> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => WorkspaceEntitiesLocalReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Uuid
	{
		get
		{
			return uuid_ ?? UuidDefaultValue;
		}
		set
		{
			uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasUuid => uuid_ != null;

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
	public string Path
	{
		get
		{
			return path_;
		}
		set
		{
			path_ = ProtoPreconditions.CheckNotNull(value, "value");
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
		path_ = other.path_;
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
	public void ClearUuid()
	{
		uuid_ = null;
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
		if (Path != other.Path)
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
		if (HasUuid)
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
		if (Path.Length != 0)
		{
			num ^= Path.GetHashCode();
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
		if (HasUuid)
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
		if (Path.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Path);
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
		if (HasUuid)
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
		if (Path.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Path);
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
			if (other.HasUuid)
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
			if (other.Path.Length != 0)
			{
				Path = other.Path;
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
			case 34u:
				Path = input.ReadString();
				break;
			}
		}
	}
}
