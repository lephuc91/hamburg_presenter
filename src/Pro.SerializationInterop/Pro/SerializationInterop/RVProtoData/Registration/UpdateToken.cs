using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class UpdateToken : IMessage<UpdateToken>, IMessage, IEquatable<UpdateToken>, IDeepCloneable<UpdateToken>
{
	private static readonly MessageParser<UpdateToken> _parser = new MessageParser<UpdateToken>(() => new UpdateToken());

	private UnknownFieldSet _unknownFields;

	public const int TokenMetadataFieldNumber = 1;

	private TokenMetadata tokenMetadata_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<UpdateToken> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[16];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TokenMetadata TokenMetadata
	{
		get
		{
			return tokenMetadata_;
		}
		set
		{
			tokenMetadata_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateToken()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateToken(UpdateToken other)
		: this()
	{
		tokenMetadata_ = ((other.tokenMetadata_ != null) ? other.tokenMetadata_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateToken Clone()
	{
		return new UpdateToken(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as UpdateToken);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(UpdateToken other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(TokenMetadata, other.TokenMetadata))
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
		if (tokenMetadata_ != null)
		{
			num ^= TokenMetadata.GetHashCode();
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
		if (tokenMetadata_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(TokenMetadata);
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
		if (tokenMetadata_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TokenMetadata);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(UpdateToken other)
	{
		if (other == null)
		{
			return;
		}
		if (other.tokenMetadata_ != null)
		{
			if (tokenMetadata_ == null)
			{
				TokenMetadata = new TokenMetadata();
			}
			TokenMetadata.MergeFrom(other.TokenMetadata);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				continue;
			}
			if (tokenMetadata_ == null)
			{
				TokenMetadata = new TokenMetadata();
			}
			input.ReadMessage(TokenMetadata);
		}
	}
}
