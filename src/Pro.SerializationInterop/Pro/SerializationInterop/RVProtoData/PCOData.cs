using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PCOData : IMessage<PCOData>, IMessage, IEquatable<PCOData>, IDeepCloneable<PCOData>
{
	private static readonly MessageParser<PCOData> _parser = new MessageParser<PCOData>(() => new PCOData());

	private UnknownFieldSet _unknownFields;

	public const int ServiceTypeIdFieldNumber = 2;

	private string serviceTypeId_ = "";

	public const int PlanIdFieldNumber = 3;

	private string planId_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PCOData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[18];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ServiceTypeId
	{
		get
		{
			return serviceTypeId_;
		}
		set
		{
			serviceTypeId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PlanId
	{
		get
		{
			return planId_;
		}
		set
		{
			planId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PCOData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PCOData(PCOData other)
		: this()
	{
		serviceTypeId_ = other.serviceTypeId_;
		planId_ = other.planId_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PCOData Clone()
	{
		return new PCOData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PCOData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PCOData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ServiceTypeId != other.ServiceTypeId)
		{
			return false;
		}
		if (PlanId != other.PlanId)
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
		if (ServiceTypeId.Length != 0)
		{
			num ^= ServiceTypeId.GetHashCode();
		}
		if (PlanId.Length != 0)
		{
			num ^= PlanId.GetHashCode();
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
		if (ServiceTypeId.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(ServiceTypeId);
		}
		if (PlanId.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(PlanId);
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
		if (ServiceTypeId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ServiceTypeId);
		}
		if (PlanId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PlanId);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PCOData other)
	{
		if (other != null)
		{
			if (other.ServiceTypeId.Length != 0)
			{
				ServiceTypeId = other.ServiceTypeId;
			}
			if (other.PlanId.Length != 0)
			{
				PlanId = other.PlanId;
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
			case 18u:
				ServiceTypeId = input.ReadString();
				break;
			case 26u:
				PlanId = input.ReadString();
				break;
			}
		}
	}
}
