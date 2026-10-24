using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_SlideDisplayDetails : IMessage<API_v1_SlideDisplayDetails>, IMessage, IEquatable<API_v1_SlideDisplayDetails>, IDeepCloneable<API_v1_SlideDisplayDetails>
{
	private static readonly MessageParser<API_v1_SlideDisplayDetails> _parser = new MessageParser<API_v1_SlideDisplayDetails>(() => new API_v1_SlideDisplayDetails());

	private UnknownFieldSet _unknownFields;

	public const int TextFieldNumber = 1;

	private string text_ = "";

	public const int NotesFieldNumber = 2;

	private string notes_ = "";

	public const int UuidFieldNumber = 3;

	private string uuid_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_SlideDisplayDetails> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1StatusReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Text
	{
		get
		{
			return text_;
		}
		set
		{
			text_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Notes
	{
		get
		{
			return notes_;
		}
		set
		{
			notes_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

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
	public API_v1_SlideDisplayDetails()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_SlideDisplayDetails(API_v1_SlideDisplayDetails other)
		: this()
	{
		text_ = other.text_;
		notes_ = other.notes_;
		uuid_ = other.uuid_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_SlideDisplayDetails Clone()
	{
		return new API_v1_SlideDisplayDetails(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_SlideDisplayDetails);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_SlideDisplayDetails other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Text != other.Text)
		{
			return false;
		}
		if (Notes != other.Notes)
		{
			return false;
		}
		if (Uuid != other.Uuid)
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
		if (Text.Length != 0)
		{
			num ^= Text.GetHashCode();
		}
		if (Notes.Length != 0)
		{
			num ^= Notes.GetHashCode();
		}
		if (Uuid.Length != 0)
		{
			num ^= Uuid.GetHashCode();
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
		if (Text.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Text);
		}
		if (Notes.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Notes);
		}
		if (Uuid.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Uuid);
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
		if (Text.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Text);
		}
		if (Notes.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Notes);
		}
		if (Uuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_SlideDisplayDetails other)
	{
		if (other != null)
		{
			if (other.Text.Length != 0)
			{
				Text = other.Text;
			}
			if (other.Notes.Length != 0)
			{
				Notes = other.Notes;
			}
			if (other.Uuid.Length != 0)
			{
				Uuid = other.Uuid;
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
				Text = input.ReadString();
				break;
			case 18u:
				Notes = input.ReadString();
				break;
			case 26u:
				Uuid = input.ReadString();
				break;
			}
		}
	}
}
