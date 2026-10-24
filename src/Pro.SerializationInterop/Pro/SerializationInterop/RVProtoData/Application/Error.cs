using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Application;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Error : IMessage<Error>, IMessage, IEquatable<Error>, IDeepCloneable<Error>
{
	private static readonly MessageParser<Error> _parser = new MessageParser<Error>(() => new Error());

	private UnknownFieldSet _unknownFields;

	public const int ServiceFieldNumber = 1;

	private ServiceID service_;

	public const int CodeFieldNumber = 2;

	private int code_;

	public const int DescriptionFieldNumber = 3;

	private string description_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Error> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ErrorReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ServiceID Service
	{
		get
		{
			return service_;
		}
		set
		{
			service_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Code
	{
		get
		{
			return code_;
		}
		set
		{
			code_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Description
	{
		get
		{
			return description_;
		}
		set
		{
			description_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Error()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Error(Error other)
		: this()
	{
		service_ = other.service_;
		code_ = other.code_;
		description_ = other.description_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Error Clone()
	{
		return new Error(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Error);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Error other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Service != other.Service)
		{
			return false;
		}
		if (Code != other.Code)
		{
			return false;
		}
		if (Description != other.Description)
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
		if (Service != 0)
		{
			num ^= Service.GetHashCode();
		}
		if (Code != 0)
		{
			num ^= Code.GetHashCode();
		}
		if (Description.Length != 0)
		{
			num ^= Description.GetHashCode();
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
		if (Service != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Service);
		}
		if (Code != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Code);
		}
		if (Description.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Description);
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
		if (Service != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Service);
		}
		if (Code != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Code);
		}
		if (Description.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Description);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Error other)
	{
		if (other != null)
		{
			if (other.Service != 0)
			{
				Service = other.Service;
			}
			if (other.Code != 0)
			{
				Code = other.Code;
			}
			if (other.Description.Length != 0)
			{
				Description = other.Description;
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
				Service = (ServiceID)input.ReadEnum();
				break;
			case 16u:
				Code = input.ReadInt32();
				break;
			case 26u:
				Description = input.ReadString();
				break;
			}
		}
	}
}
