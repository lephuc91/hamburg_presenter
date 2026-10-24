using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Document;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Document : IMessage<Document>, IMessage, IEquatable<Document>, IDeepCloneable<Document>
{
	public enum BodyOneofCase
	{
		None = 0,
		Ready = 10,
		Local = 11,
		Remote = 12
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Kind
		{
			[OriginalName("PRESENTATION")]
			Presentation,
			[OriginalName("THEME")]
			Theme
		}
	}

	private static readonly MessageParser<Document> _parser = new MessageParser<Document>(() => new Document());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private string uuid_ = "";

	public const int PathFieldNumber = 2;

	private string path_ = "";

	public const int ReadyFieldNumber = 10;

	public const int LocalFieldNumber = 11;

	public const int RemoteFieldNumber = 12;

	private object body_;

	private BodyOneofCase bodyCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Document> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => DocumentEntitiesReflection.Descriptor.MessageTypes[4];

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
	public Ready Ready
	{
		get
		{
			if (bodyCase_ != BodyOneofCase.Ready)
			{
				return null;
			}
			return (Ready)body_;
		}
		set
		{
			body_ = value;
			bodyCase_ = ((value != null) ? BodyOneofCase.Ready : BodyOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Local Local
	{
		get
		{
			if (bodyCase_ != BodyOneofCase.Local)
			{
				return null;
			}
			return (Local)body_;
		}
		set
		{
			body_ = value;
			bodyCase_ = ((value != null) ? BodyOneofCase.Local : BodyOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Remote Remote
	{
		get
		{
			if (bodyCase_ != BodyOneofCase.Remote)
			{
				return null;
			}
			return (Remote)body_;
		}
		set
		{
			body_ = value;
			bodyCase_ = ((value != null) ? BodyOneofCase.Remote : BodyOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BodyOneofCase BodyCase => bodyCase_;

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
		uuid_ = other.uuid_;
		path_ = other.path_;
		switch (other.BodyCase)
		{
		case BodyOneofCase.Ready:
			Ready = other.Ready.Clone();
			break;
		case BodyOneofCase.Local:
			Local = other.Local.Clone();
			break;
		case BodyOneofCase.Remote:
			Remote = other.Remote.Clone();
			break;
		}
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
	public void ClearBody()
	{
		bodyCase_ = BodyOneofCase.None;
		body_ = null;
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
		if (Uuid != other.Uuid)
		{
			return false;
		}
		if (Path != other.Path)
		{
			return false;
		}
		if (!object.Equals(Ready, other.Ready))
		{
			return false;
		}
		if (!object.Equals(Local, other.Local))
		{
			return false;
		}
		if (!object.Equals(Remote, other.Remote))
		{
			return false;
		}
		if (BodyCase != other.BodyCase)
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
		if (Path.Length != 0)
		{
			num ^= Path.GetHashCode();
		}
		if (bodyCase_ == BodyOneofCase.Ready)
		{
			num ^= Ready.GetHashCode();
		}
		if (bodyCase_ == BodyOneofCase.Local)
		{
			num ^= Local.GetHashCode();
		}
		if (bodyCase_ == BodyOneofCase.Remote)
		{
			num ^= Remote.GetHashCode();
		}
		num ^= (int)bodyCase_;
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
		if (Path.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Path);
		}
		if (bodyCase_ == BodyOneofCase.Ready)
		{
			output.WriteRawTag(82);
			output.WriteMessage(Ready);
		}
		if (bodyCase_ == BodyOneofCase.Local)
		{
			output.WriteRawTag(90);
			output.WriteMessage(Local);
		}
		if (bodyCase_ == BodyOneofCase.Remote)
		{
			output.WriteRawTag(98);
			output.WriteMessage(Remote);
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
		if (Path.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Path);
		}
		if (bodyCase_ == BodyOneofCase.Ready)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Ready);
		}
		if (bodyCase_ == BodyOneofCase.Local)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Local);
		}
		if (bodyCase_ == BodyOneofCase.Remote)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Remote);
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
		if (other.Uuid.Length != 0)
		{
			Uuid = other.Uuid;
		}
		if (other.Path.Length != 0)
		{
			Path = other.Path;
		}
		switch (other.BodyCase)
		{
		case BodyOneofCase.Ready:
			if (Ready == null)
			{
				Ready = new Ready();
			}
			Ready.MergeFrom(other.Ready);
			break;
		case BodyOneofCase.Local:
			if (Local == null)
			{
				Local = new Local();
			}
			Local.MergeFrom(other.Local);
			break;
		case BodyOneofCase.Remote:
			if (Remote == null)
			{
				Remote = new Remote();
			}
			Remote.MergeFrom(other.Remote);
			break;
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
				Uuid = input.ReadString();
				break;
			case 18u:
				Path = input.ReadString();
				break;
			case 82u:
			{
				Ready ready = new Ready();
				if (bodyCase_ == BodyOneofCase.Ready)
				{
					ready.MergeFrom(Ready);
				}
				input.ReadMessage(ready);
				Ready = ready;
				break;
			}
			case 90u:
			{
				Local local = new Local();
				if (bodyCase_ == BodyOneofCase.Local)
				{
					local.MergeFrom(Local);
				}
				input.ReadMessage(local);
				Local = local;
				break;
			}
			case 98u:
			{
				Remote remote = new Remote();
				if (bodyCase_ == BodyOneofCase.Remote)
				{
					remote.MergeFrom(Remote);
				}
				input.ReadMessage(remote);
				Remote = remote;
				break;
			}
			}
		}
	}
}
