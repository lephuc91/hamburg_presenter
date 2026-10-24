using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class WebFillTokenAndCookies : IMessage<WebFillTokenAndCookies>, IMessage, IEquatable<WebFillTokenAndCookies>, IDeepCloneable<WebFillTokenAndCookies>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Cookie : IMessage<Cookie>, IMessage, IEquatable<Cookie>, IDeepCloneable<Cookie>
		{
			private static readonly MessageParser<Cookie> _parser = new MessageParser<Cookie>(() => new Cookie());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int ValueFieldNumber = 2;

			private string value_ = "";

			public const int DomainFieldNumber = 3;

			private string domain_ = "";

			public const int ExpiryFieldNumber = 4;

			private ulong expiry_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Cookie> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => WebFillTokenAndCookies.Descriptor.NestedTypes[0];

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
			public string Value
			{
				get
				{
					return value_;
				}
				set
				{
					value_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Domain
			{
				get
				{
					return domain_;
				}
				set
				{
					domain_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong Expiry
			{
				get
				{
					return expiry_;
				}
				set
				{
					expiry_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Cookie()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Cookie(Cookie other)
				: this()
			{
				name_ = other.name_;
				value_ = other.value_;
				domain_ = other.domain_;
				expiry_ = other.expiry_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Cookie Clone()
			{
				return new Cookie(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Cookie);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Cookie other)
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
				if (Value != other.Value)
				{
					return false;
				}
				if (Domain != other.Domain)
				{
					return false;
				}
				if (Expiry != other.Expiry)
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
				if (Value.Length != 0)
				{
					num ^= Value.GetHashCode();
				}
				if (Domain.Length != 0)
				{
					num ^= Domain.GetHashCode();
				}
				if (Expiry != 0L)
				{
					num ^= Expiry.GetHashCode();
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
				if (Value.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Value);
				}
				if (Domain.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Domain);
				}
				if (Expiry != 0L)
				{
					output.WriteRawTag(32);
					output.WriteUInt64(Expiry);
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
				if (Value.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Value);
				}
				if (Domain.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Domain);
				}
				if (Expiry != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Expiry);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Cookie other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Value.Length != 0)
					{
						Value = other.Value;
					}
					if (other.Domain.Length != 0)
					{
						Domain = other.Domain;
					}
					if (other.Expiry != 0L)
					{
						Expiry = other.Expiry;
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
					case 18u:
						Value = input.ReadString();
						break;
					case 26u:
						Domain = input.ReadString();
						break;
					case 32u:
						Expiry = input.ReadUInt64();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<WebFillTokenAndCookies> _parser = new MessageParser<WebFillTokenAndCookies>(() => new WebFillTokenAndCookies());

	private UnknownFieldSet _unknownFields;

	public const int CookiesFieldNumber = 1;

	private static readonly FieldCodec<Types.Cookie> _repeated_cookies_codec = FieldCodec.ForMessage(10u, Types.Cookie.Parser);

	private readonly RepeatedField<Types.Cookie> cookies_ = new RepeatedField<Types.Cookie>();

	public const int TokenFieldNumber = 2;

	private string token_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<WebFillTokenAndCookies> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[19];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Cookie> Cookies => cookies_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Token
	{
		get
		{
			return token_;
		}
		set
		{
			token_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebFillTokenAndCookies()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebFillTokenAndCookies(WebFillTokenAndCookies other)
		: this()
	{
		cookies_ = other.cookies_.Clone();
		token_ = other.token_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebFillTokenAndCookies Clone()
	{
		return new WebFillTokenAndCookies(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as WebFillTokenAndCookies);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(WebFillTokenAndCookies other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!cookies_.Equals(other.cookies_))
		{
			return false;
		}
		if (Token != other.Token)
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
		num ^= cookies_.GetHashCode();
		if (Token.Length != 0)
		{
			num ^= Token.GetHashCode();
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
		cookies_.WriteTo(output, _repeated_cookies_codec);
		if (Token.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Token);
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
		num += cookies_.CalculateSize(_repeated_cookies_codec);
		if (Token.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Token);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(WebFillTokenAndCookies other)
	{
		if (other != null)
		{
			cookies_.Add(other.cookies_);
			if (other.Token.Length != 0)
			{
				Token = other.Token;
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
				cookies_.AddEntriesFrom(input, _repeated_cookies_codec);
				break;
			case 18u:
				Token = input.ReadString();
				break;
			}
		}
	}
}
