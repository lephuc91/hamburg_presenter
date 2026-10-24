using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Font : IMessage<Font>, IMessage, IEquatable<Font>, IDeepCloneable<Font>
{
	private static readonly MessageParser<Font> _parser = new MessageParser<Font>(() => new Font());

	private UnknownFieldSet _unknownFields;

	public const int NameFieldNumber = 1;

	private string name_ = "";

	public const int SizeFieldNumber = 2;

	private double size_;

	public const int ItalicFieldNumber = 4;

	private bool italic_;

	public const int BoldFieldNumber = 8;

	private bool bold_;

	public const int FamilyFieldNumber = 9;

	private string family_ = "";

	public const int FaceFieldNumber = 10;

	private string face_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Font> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => FontReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public double Size
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
	public bool Italic
	{
		get
		{
			return italic_;
		}
		set
		{
			italic_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Bold
	{
		get
		{
			return bold_;
		}
		set
		{
			bold_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Family
	{
		get
		{
			return family_;
		}
		set
		{
			family_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Face
	{
		get
		{
			return face_;
		}
		set
		{
			face_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Font()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Font(Font other)
		: this()
	{
		name_ = other.name_;
		size_ = other.size_;
		italic_ = other.italic_;
		bold_ = other.bold_;
		family_ = other.family_;
		face_ = other.face_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Font Clone()
	{
		return new Font(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Font);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Font other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Size, other.Size))
		{
			return false;
		}
		if (Italic != other.Italic)
		{
			return false;
		}
		if (Bold != other.Bold)
		{
			return false;
		}
		if (Family != other.Family)
		{
			return false;
		}
		if (Face != other.Face)
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
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (Size != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Size);
		}
		if (Italic)
		{
			num ^= Italic.GetHashCode();
		}
		if (Bold)
		{
			num ^= Bold.GetHashCode();
		}
		if (Family.Length != 0)
		{
			num ^= Family.GetHashCode();
		}
		if (Face.Length != 0)
		{
			num ^= Face.GetHashCode();
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
		if (Name.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Name);
		}
		if (Size != 0.0)
		{
			output.WriteRawTag(17);
			output.WriteDouble(Size);
		}
		if (Italic)
		{
			output.WriteRawTag(32);
			output.WriteBool(Italic);
		}
		if (Bold)
		{
			output.WriteRawTag(64);
			output.WriteBool(Bold);
		}
		if (Family.Length != 0)
		{
			output.WriteRawTag(74);
			output.WriteString(Family);
		}
		if (Face.Length != 0)
		{
			output.WriteRawTag(82);
			output.WriteString(Face);
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
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (Size != 0.0)
		{
			num += 9;
		}
		if (Italic)
		{
			num += 2;
		}
		if (Bold)
		{
			num += 2;
		}
		if (Family.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Family);
		}
		if (Face.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Face);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Font other)
	{
		if (other != null)
		{
			if (other.Name.Length != 0)
			{
				Name = other.Name;
			}
			if (other.Size != 0.0)
			{
				Size = other.Size;
			}
			if (other.Italic)
			{
				Italic = other.Italic;
			}
			if (other.Bold)
			{
				Bold = other.Bold;
			}
			if (other.Family.Length != 0)
			{
				Family = other.Family;
			}
			if (other.Face.Length != 0)
			{
				Face = other.Face;
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
				Name = input.ReadString();
				break;
			case 17u:
				Size = input.ReadDouble();
				break;
			case 32u:
				Italic = input.ReadBool();
				break;
			case 64u:
				Bold = input.ReadBool();
				break;
			case 74u:
				Family = input.ReadString();
				break;
			case 82u:
				Face = input.ReadString();
				break;
			}
		}
	}
}
