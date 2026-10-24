using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Notification : IMessage<Notification>, IMessage, IEquatable<Notification>, IDeepCloneable<Notification>
{
	private static readonly MessageParser<Notification> _parser = new MessageParser<Notification>(() => new Notification());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private string id_ = "";

	public const int HeaderFieldNumber = 2;

	private string header_ = "";

	public const int BodyFieldNumber = 3;

	private string body_ = "";

	public const int UrlFieldNumber = 4;

	private string url_ = "";

	public const int UrlDisplayTextFieldNumber = 5;

	private string urlDisplayText_ = "";

	public const int CreatedAtFieldNumber = 6;

	private ulong createdAt_;

	public const int ExpiresAtFieldNumber = 7;

	private ulong expiresAt_;

	public const int IsReadFieldNumber = 8;

	private bool isRead_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Notification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[59];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Header
	{
		get
		{
			return header_;
		}
		set
		{
			header_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Body
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
	public string Url
	{
		get
		{
			return url_;
		}
		set
		{
			url_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string UrlDisplayText
	{
		get
		{
			return urlDisplayText_;
		}
		set
		{
			urlDisplayText_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong CreatedAt
	{
		get
		{
			return createdAt_;
		}
		set
		{
			createdAt_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong ExpiresAt
	{
		get
		{
			return expiresAt_;
		}
		set
		{
			expiresAt_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsRead
	{
		get
		{
			return isRead_;
		}
		set
		{
			isRead_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification(Notification other)
		: this()
	{
		id_ = other.id_;
		header_ = other.header_;
		body_ = other.body_;
		url_ = other.url_;
		urlDisplayText_ = other.urlDisplayText_;
		createdAt_ = other.createdAt_;
		expiresAt_ = other.expiresAt_;
		isRead_ = other.isRead_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification Clone()
	{
		return new Notification(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Notification);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Notification other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Id != other.Id)
		{
			return false;
		}
		if (Header != other.Header)
		{
			return false;
		}
		if (Body != other.Body)
		{
			return false;
		}
		if (Url != other.Url)
		{
			return false;
		}
		if (UrlDisplayText != other.UrlDisplayText)
		{
			return false;
		}
		if (CreatedAt != other.CreatedAt)
		{
			return false;
		}
		if (ExpiresAt != other.ExpiresAt)
		{
			return false;
		}
		if (IsRead != other.IsRead)
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
		if (Id.Length != 0)
		{
			num ^= Id.GetHashCode();
		}
		if (Header.Length != 0)
		{
			num ^= Header.GetHashCode();
		}
		if (Body.Length != 0)
		{
			num ^= Body.GetHashCode();
		}
		if (Url.Length != 0)
		{
			num ^= Url.GetHashCode();
		}
		if (UrlDisplayText.Length != 0)
		{
			num ^= UrlDisplayText.GetHashCode();
		}
		if (CreatedAt != 0L)
		{
			num ^= CreatedAt.GetHashCode();
		}
		if (ExpiresAt != 0L)
		{
			num ^= ExpiresAt.GetHashCode();
		}
		if (IsRead)
		{
			num ^= IsRead.GetHashCode();
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
		if (Id.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Id);
		}
		if (Header.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Header);
		}
		if (Body.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Body);
		}
		if (Url.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Url);
		}
		if (UrlDisplayText.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(UrlDisplayText);
		}
		if (CreatedAt != 0L)
		{
			output.WriteRawTag(48);
			output.WriteUInt64(CreatedAt);
		}
		if (ExpiresAt != 0L)
		{
			output.WriteRawTag(56);
			output.WriteUInt64(ExpiresAt);
		}
		if (IsRead)
		{
			output.WriteRawTag(64);
			output.WriteBool(IsRead);
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
		if (Id.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Id);
		}
		if (Header.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Header);
		}
		if (Body.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Body);
		}
		if (Url.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Url);
		}
		if (UrlDisplayText.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(UrlDisplayText);
		}
		if (CreatedAt != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(CreatedAt);
		}
		if (ExpiresAt != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(ExpiresAt);
		}
		if (IsRead)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Notification other)
	{
		if (other != null)
		{
			if (other.Id.Length != 0)
			{
				Id = other.Id;
			}
			if (other.Header.Length != 0)
			{
				Header = other.Header;
			}
			if (other.Body.Length != 0)
			{
				Body = other.Body;
			}
			if (other.Url.Length != 0)
			{
				Url = other.Url;
			}
			if (other.UrlDisplayText.Length != 0)
			{
				UrlDisplayText = other.UrlDisplayText;
			}
			if (other.CreatedAt != 0L)
			{
				CreatedAt = other.CreatedAt;
			}
			if (other.ExpiresAt != 0L)
			{
				ExpiresAt = other.ExpiresAt;
			}
			if (other.IsRead)
			{
				IsRead = other.IsRead;
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
				Id = input.ReadString();
				break;
			case 18u:
				Header = input.ReadString();
				break;
			case 26u:
				Body = input.ReadString();
				break;
			case 34u:
				Url = input.ReadString();
				break;
			case 42u:
				UrlDisplayText = input.ReadString();
				break;
			case 48u:
				CreatedAt = input.ReadUInt64();
				break;
			case 56u:
				ExpiresAt = input.ReadUInt64();
				break;
			case 64u:
				IsRead = input.ReadBool();
				break;
			}
		}
	}
}
