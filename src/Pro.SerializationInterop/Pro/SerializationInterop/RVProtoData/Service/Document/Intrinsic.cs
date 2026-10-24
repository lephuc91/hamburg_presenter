using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Document;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Intrinsic : IMessage<Intrinsic>, IMessage, IEquatable<Intrinsic>, IDeepCloneable<Intrinsic>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Kind
		{
			[OriginalName("Calendar")]
			Calendar,
			[OriginalName("CCLI")]
			Ccli,
			[OriginalName("ClearGroups")]
			ClearGroups,
			[OriginalName("Groups")]
			Groups,
			[OriginalName("KeyMappings")]
			KeyMappings,
			[OriginalName("Labels")]
			Labels,
			[OriginalName("Macros")]
			Macros,
			[OriginalName("Messages")]
			Messages,
			[OriginalName("Props")]
			Props,
			[OriginalName("Stage")]
			Stage,
			[OriginalName("Timers")]
			Timers,
			[OriginalName("Workspace")]
			Workspace,
			[OriginalName("LibraryData")]
			LibraryData,
			[OriginalName("PlaylistAudio")]
			PlaylistAudio,
			[OriginalName("PlaylistLibrary")]
			PlaylistLibrary,
			[OriginalName("PlaylistMedia")]
			PlaylistMedia,
			[OriginalName("PlaylistTemplates")]
			PlaylistTemplates
		}
	}

	private static readonly MessageParser<Intrinsic> _parser = new MessageParser<Intrinsic>(() => new Intrinsic());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private string uuid_ = "";

	public const int KindFieldNumber = 2;

	private Types.Kind kind_;

	public const int BodyFieldNumber = 3;

	private ByteString body_ = ByteString.Empty;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Intrinsic> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => DocumentEntitiesReflection.Descriptor.MessageTypes[3];

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
	public Types.Kind Kind
	{
		get
		{
			return kind_;
		}
		set
		{
			kind_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ByteString Body
	{
		get
		{
			return body_;
		}
		set
		{
			body_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Intrinsic()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Intrinsic(Intrinsic other)
		: this()
	{
		uuid_ = other.uuid_;
		kind_ = other.kind_;
		body_ = other.body_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Intrinsic Clone()
	{
		return new Intrinsic(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Intrinsic);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Intrinsic other)
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
		if (Kind != other.Kind)
		{
			return false;
		}
		if (Body != other.Body)
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
		if (Kind != 0)
		{
			num ^= Kind.GetHashCode();
		}
		if (Body.Length != 0)
		{
			num ^= Body.GetHashCode();
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
		if (Kind != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Kind);
		}
		if (Body.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteBytes(Body);
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
		if (Kind != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Kind);
		}
		if (Body.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeBytesSize(Body);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Intrinsic other)
	{
		if (other != null)
		{
			if (other.Uuid.Length != 0)
			{
				Uuid = other.Uuid;
			}
			if (other.Kind != 0)
			{
				Kind = other.Kind;
			}
			if (other.Body.Length != 0)
			{
				Body = other.Body;
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
			case 16u:
				Kind = (Types.Kind)input.ReadEnum();
				break;
			case 26u:
				Body = input.ReadBytes();
				break;
			}
		}
	}
}
