using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TokenMetadata : IMessage<TokenMetadata>, IMessage, IEquatable<TokenMetadata>, IDeepCloneable<TokenMetadata>
{
	private static readonly MessageParser<TokenMetadata> _parser = new MessageParser<TokenMetadata>(() => new TokenMetadata());

	private UnknownFieldSet _unknownFields;

	public const int AccessTokenFieldNumber = 1;

	private string accessToken_ = "";

	public const int RefreshTokenFieldNumber = 2;

	private string refreshToken_ = "";

	public const int ExpiresAtFieldNumber = 3;

	private long expiresAt_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TokenMetadata> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[55];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string AccessToken
	{
		get
		{
			return accessToken_;
		}
		set
		{
			accessToken_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string RefreshToken
	{
		get
		{
			return refreshToken_;
		}
		set
		{
			refreshToken_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long ExpiresAt
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
	public TokenMetadata()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TokenMetadata(TokenMetadata other)
		: this()
	{
		accessToken_ = other.accessToken_;
		refreshToken_ = other.refreshToken_;
		expiresAt_ = other.expiresAt_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TokenMetadata Clone()
	{
		return new TokenMetadata(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TokenMetadata);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TokenMetadata other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (AccessToken != other.AccessToken)
		{
			return false;
		}
		if (RefreshToken != other.RefreshToken)
		{
			return false;
		}
		if (ExpiresAt != other.ExpiresAt)
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
		if (AccessToken.Length != 0)
		{
			num ^= AccessToken.GetHashCode();
		}
		if (RefreshToken.Length != 0)
		{
			num ^= RefreshToken.GetHashCode();
		}
		if (ExpiresAt != 0L)
		{
			num ^= ExpiresAt.GetHashCode();
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
		if (AccessToken.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(AccessToken);
		}
		if (RefreshToken.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(RefreshToken);
		}
		if (ExpiresAt != 0L)
		{
			output.WriteRawTag(24);
			output.WriteInt64(ExpiresAt);
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
		if (AccessToken.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(AccessToken);
		}
		if (RefreshToken.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RefreshToken);
		}
		if (ExpiresAt != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(ExpiresAt);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TokenMetadata other)
	{
		if (other != null)
		{
			if (other.AccessToken.Length != 0)
			{
				AccessToken = other.AccessToken;
			}
			if (other.RefreshToken.Length != 0)
			{
				RefreshToken = other.RefreshToken;
			}
			if (other.ExpiresAt != 0L)
			{
				ExpiresAt = other.ExpiresAt;
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
				AccessToken = input.ReadString();
				break;
			case 18u:
				RefreshToken = input.ReadString();
				break;
			case 24u:
				ExpiresAt = input.ReadInt64();
				break;
			}
		}
	}
}
