using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ReadRegistrationData : IMessage<ReadRegistrationData>, IMessage, IEquatable<ReadRegistrationData>, IDeepCloneable<ReadRegistrationData>
{
	private static readonly MessageParser<ReadRegistrationData> _parser = new MessageParser<ReadRegistrationData>(() => new ReadRegistrationData());

	private UnknownFieldSet _unknownFields;

	public const int FingerprintFieldNumber = 1;

	private string fingerprint_ = "";

	public const int IdentifierFieldNumber = 2;

	private string identifier_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ReadRegistrationData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[29];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Fingerprint
	{
		get
		{
			return fingerprint_;
		}
		set
		{
			fingerprint_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Identifier
	{
		get
		{
			return identifier_;
		}
		set
		{
			identifier_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReadRegistrationData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReadRegistrationData(ReadRegistrationData other)
		: this()
	{
		fingerprint_ = other.fingerprint_;
		identifier_ = other.identifier_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReadRegistrationData Clone()
	{
		return new ReadRegistrationData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ReadRegistrationData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ReadRegistrationData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Fingerprint != other.Fingerprint)
		{
			return false;
		}
		if (Identifier != other.Identifier)
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
		if (Fingerprint.Length != 0)
		{
			num ^= Fingerprint.GetHashCode();
		}
		if (Identifier.Length != 0)
		{
			num ^= Identifier.GetHashCode();
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
		if (Fingerprint.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Fingerprint);
		}
		if (Identifier.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Identifier);
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
		if (Fingerprint.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Fingerprint);
		}
		if (Identifier.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Identifier);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ReadRegistrationData other)
	{
		if (other != null)
		{
			if (other.Fingerprint.Length != 0)
			{
				Fingerprint = other.Fingerprint;
			}
			if (other.Identifier.Length != 0)
			{
				Identifier = other.Identifier;
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
				Fingerprint = input.ReadString();
				break;
			case 18u:
				Identifier = input.ReadString();
				break;
			}
		}
	}
}
