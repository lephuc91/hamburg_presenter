using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Application;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Shutdown : IMessage<Shutdown>, IMessage, IEquatable<Shutdown>, IDeepCloneable<Shutdown>
{
	public enum ResultOneofCase
	{
		None,
		Ok,
		Error
	}

	private static readonly MessageParser<Shutdown> _parser = new MessageParser<Shutdown>(() => new Shutdown());

	private UnknownFieldSet _unknownFields;

	public const int OkFieldNumber = 1;

	public const int ErrorFieldNumber = 2;

	private object result_;

	private ResultOneofCase resultCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Shutdown> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ParamsReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Ok
	{
		get
		{
			if (!HasOk)
			{
				return "";
			}
			return (string)result_;
		}
		set
		{
			result_ = ProtoPreconditions.CheckNotNull(value, "value");
			resultCase_ = ResultOneofCase.Ok;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasOk => resultCase_ == ResultOneofCase.Ok;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Error
	{
		get
		{
			if (!HasError)
			{
				return "";
			}
			return (string)result_;
		}
		set
		{
			result_ = ProtoPreconditions.CheckNotNull(value, "value");
			resultCase_ = ResultOneofCase.Error;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasError => resultCase_ == ResultOneofCase.Error;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResultOneofCase ResultCase => resultCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Shutdown()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Shutdown(Shutdown other)
		: this()
	{
		switch (other.ResultCase)
		{
		case ResultOneofCase.Ok:
			Ok = other.Ok;
			break;
		case ResultOneofCase.Error:
			Error = other.Error;
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Shutdown Clone()
	{
		return new Shutdown(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearOk()
	{
		if (HasOk)
		{
			ClearResult();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearError()
	{
		if (HasError)
		{
			ClearResult();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResult()
	{
		resultCase_ = ResultOneofCase.None;
		result_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Shutdown);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Shutdown other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Ok != other.Ok)
		{
			return false;
		}
		if (Error != other.Error)
		{
			return false;
		}
		if (ResultCase != other.ResultCase)
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
		if (HasOk)
		{
			num ^= Ok.GetHashCode();
		}
		if (HasError)
		{
			num ^= Error.GetHashCode();
		}
		num ^= (int)resultCase_;
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
		if (HasOk)
		{
			output.WriteRawTag(10);
			output.WriteString(Ok);
		}
		if (HasError)
		{
			output.WriteRawTag(18);
			output.WriteString(Error);
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
		if (HasOk)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Ok);
		}
		if (HasError)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Error);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Shutdown other)
	{
		if (other != null)
		{
			switch (other.ResultCase)
			{
			case ResultOneofCase.Ok:
				Ok = other.Ok;
				break;
			case ResultOneofCase.Error:
				Error = other.Error;
				break;
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
				Ok = input.ReadString();
				break;
			case 18u:
				Error = input.ReadString();
				break;
			}
		}
	}
}
