using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ValidateEncoderRequest : IMessage<ValidateEncoderRequest>, IMessage, IEquatable<ValidateEncoderRequest>, IDeepCloneable<ValidateEncoderRequest>
{
	private static readonly MessageParser<ValidateEncoderRequest> _parser = new MessageParser<ValidateEncoderRequest>(() => new ValidateEncoderRequest());

	private UnknownFieldSet _unknownFields;

	public const int EncoderFieldNumber = 1;

	private Recording.Types.Stream.Types.Encoder encoder_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ValidateEncoderRequest> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Recording.Types.Stream.Types.Encoder Encoder
	{
		get
		{
			return encoder_;
		}
		set
		{
			encoder_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ValidateEncoderRequest()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ValidateEncoderRequest(ValidateEncoderRequest other)
		: this()
	{
		encoder_ = ((other.encoder_ != null) ? other.encoder_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ValidateEncoderRequest Clone()
	{
		return new ValidateEncoderRequest(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ValidateEncoderRequest);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ValidateEncoderRequest other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Encoder, other.Encoder))
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
		if (encoder_ != null)
		{
			num ^= Encoder.GetHashCode();
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
		if (encoder_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Encoder);
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
		if (encoder_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Encoder);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ValidateEncoderRequest other)
	{
		if (other == null)
		{
			return;
		}
		if (other.encoder_ != null)
		{
			if (encoder_ == null)
			{
				Encoder = new Recording.Types.Stream.Types.Encoder();
			}
			Encoder.MergeFrom(other.Encoder);
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
			if (encoder_ == null)
			{
				Encoder = new Recording.Types.Stream.Types.Encoder();
			}
			input.ReadMessage(Encoder);
		}
	}
}
