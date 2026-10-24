using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Alert : IMessage<Alert>, IMessage, IEquatable<Alert>, IDeepCloneable<Alert>
{
	private static readonly MessageParser<Alert> _parser = new MessageParser<Alert>(() => new Alert());

	private UnknownFieldSet _unknownFields;

	public const int AlertTypeFieldNumber = 1;

	private AlertType alertType_;

	public const int TitleFieldNumber = 2;

	private string title_ = "";

	public const int ContentTypeFieldNumber = 3;

	private AlertContentType contentType_;

	public const int ContentFieldNumber = 4;

	private string content_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Alert> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[54];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AlertType AlertType
	{
		get
		{
			return alertType_;
		}
		set
		{
			alertType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Title
	{
		get
		{
			return title_;
		}
		set
		{
			title_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AlertContentType ContentType
	{
		get
		{
			return contentType_;
		}
		set
		{
			contentType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Content
	{
		get
		{
			return content_;
		}
		set
		{
			content_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Alert()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Alert(Alert other)
		: this()
	{
		alertType_ = other.alertType_;
		title_ = other.title_;
		contentType_ = other.contentType_;
		content_ = other.content_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Alert Clone()
	{
		return new Alert(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Alert);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Alert other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (AlertType != other.AlertType)
		{
			return false;
		}
		if (Title != other.Title)
		{
			return false;
		}
		if (ContentType != other.ContentType)
		{
			return false;
		}
		if (Content != other.Content)
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
		if (AlertType != 0)
		{
			num ^= AlertType.GetHashCode();
		}
		if (Title.Length != 0)
		{
			num ^= Title.GetHashCode();
		}
		if (ContentType != 0)
		{
			num ^= ContentType.GetHashCode();
		}
		if (Content.Length != 0)
		{
			num ^= Content.GetHashCode();
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
		if (AlertType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)AlertType);
		}
		if (Title.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Title);
		}
		if (ContentType != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)ContentType);
		}
		if (Content.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Content);
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
		if (AlertType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AlertType);
		}
		if (Title.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Title);
		}
		if (ContentType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentType);
		}
		if (Content.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Content);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Alert other)
	{
		if (other != null)
		{
			if (other.AlertType != 0)
			{
				AlertType = other.AlertType;
			}
			if (other.Title.Length != 0)
			{
				Title = other.Title;
			}
			if (other.ContentType != 0)
			{
				ContentType = other.ContentType;
			}
			if (other.Content.Length != 0)
			{
				Content = other.Content;
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
			case 8u:
				AlertType = (AlertType)input.ReadEnum();
				break;
			case 18u:
				Title = input.ReadString();
				break;
			case 24u:
				ContentType = (AlertContentType)input.ReadEnum();
				break;
			case 34u:
				Content = input.ReadString();
				break;
			}
		}
	}
}
