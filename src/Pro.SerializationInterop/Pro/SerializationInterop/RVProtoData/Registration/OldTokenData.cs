using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class OldTokenData : IMessage<OldTokenData>, IMessage, IEquatable<OldTokenData>, IDeepCloneable<OldTokenData>
{
	private static readonly MessageParser<OldTokenData> _parser = new MessageParser<OldTokenData>(() => new OldTokenData());

	private UnknownFieldSet _unknownFields;

	public const int StatusFieldNumber = 1;

	private ReadTokenStatus status_;

	public const int TokenFieldNumber = 2;

	private TokenMetadata token_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<OldTokenData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[17];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReadTokenStatus Status
	{
		get
		{
			return status_;
		}
		set
		{
			status_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TokenMetadata Token
	{
		get
		{
			return token_;
		}
		set
		{
			token_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OldTokenData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OldTokenData(OldTokenData other)
		: this()
	{
		status_ = other.status_;
		token_ = ((other.token_ != null) ? other.token_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OldTokenData Clone()
	{
		return new OldTokenData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as OldTokenData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(OldTokenData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Status != other.Status)
		{
			return false;
		}
		if (!object.Equals(Token, other.Token))
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
		if (Status != 0)
		{
			num ^= Status.GetHashCode();
		}
		if (token_ != null)
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
		if (Status != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Status);
		}
		if (token_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Token);
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
		if (Status != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Status);
		}
		if (token_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Token);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(OldTokenData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Status != 0)
		{
			Status = other.Status;
		}
		if (other.token_ != null)
		{
			if (token_ == null)
			{
				Token = new TokenMetadata();
			}
			Token.MergeFrom(other.Token);
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
			case 8u:
				Status = (ReadTokenStatus)input.ReadEnum();
				break;
			case 18u:
				if (token_ == null)
				{
					Token = new TokenMetadata();
				}
				input.ReadMessage(Token);
				break;
			}
		}
	}
}
