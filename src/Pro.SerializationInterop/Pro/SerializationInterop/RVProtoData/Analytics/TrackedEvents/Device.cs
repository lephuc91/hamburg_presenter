using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Device : IMessage<Device>, IMessage, IEquatable<Device>, IDeepCloneable<Device>
{
	private static readonly MessageParser<Device> _parser = new MessageParser<Device>(() => new Device());

	private UnknownFieldSet _unknownFields;

	public const int ProtocolFieldNumber = 1;

	private string protocol_ = "";

	public const int DeviceNameFieldNumber = 2;

	private string deviceName_ = "";

	public const int DeviceProtocolFieldNumber = 3;

	private string deviceProtocol_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Device> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[24];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Protocol
	{
		get
		{
			return protocol_;
		}
		set
		{
			protocol_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DeviceName
	{
		get
		{
			return deviceName_;
		}
		set
		{
			deviceName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DeviceProtocol
	{
		get
		{
			return deviceProtocol_;
		}
		set
		{
			deviceProtocol_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Device()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Device(Device other)
		: this()
	{
		protocol_ = other.protocol_;
		deviceName_ = other.deviceName_;
		deviceProtocol_ = other.deviceProtocol_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Device Clone()
	{
		return new Device(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Device);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Device other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Protocol != other.Protocol)
		{
			return false;
		}
		if (DeviceName != other.DeviceName)
		{
			return false;
		}
		if (DeviceProtocol != other.DeviceProtocol)
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
		if (Protocol.Length != 0)
		{
			num ^= Protocol.GetHashCode();
		}
		if (DeviceName.Length != 0)
		{
			num ^= DeviceName.GetHashCode();
		}
		if (DeviceProtocol.Length != 0)
		{
			num ^= DeviceProtocol.GetHashCode();
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
		if (Protocol.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Protocol);
		}
		if (DeviceName.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(DeviceName);
		}
		if (DeviceProtocol.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(DeviceProtocol);
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
		if (Protocol.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Protocol);
		}
		if (DeviceName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DeviceName);
		}
		if (DeviceProtocol.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DeviceProtocol);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Device other)
	{
		if (other != null)
		{
			if (other.Protocol.Length != 0)
			{
				Protocol = other.Protocol;
			}
			if (other.DeviceName.Length != 0)
			{
				DeviceName = other.DeviceName;
			}
			if (other.DeviceProtocol.Length != 0)
			{
				DeviceProtocol = other.DeviceProtocol;
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
				Protocol = input.ReadString();
				break;
			case 18u:
				DeviceName = input.ReadString();
				break;
			case 26u:
				DeviceProtocol = input.ReadString();
				break;
			}
		}
	}
}
