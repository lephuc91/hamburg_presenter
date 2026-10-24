using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CommunicationDeviceCloud : IMessage<CommunicationDeviceCloud>, IMessage, IEquatable<CommunicationDeviceCloud>, IDeepCloneable<CommunicationDeviceCloud>
{
	private static readonly MessageParser<CommunicationDeviceCloud> _parser = new MessageParser<CommunicationDeviceCloud>(() => new CommunicationDeviceCloud());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private UUID id_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int DeviceTypeFieldNumber = 3;

	private CommunicationDevice.Types.DeviceType deviceType_;

	public const int BehaviorFieldNumber = 4;

	private CommunicationDevice.Types.Behavior behavior_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CommunicationDeviceCloud> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CommunicationsReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

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
	public CommunicationDevice.Types.DeviceType DeviceType
	{
		get
		{
			return deviceType_;
		}
		set
		{
			deviceType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDevice.Types.Behavior Behavior
	{
		get
		{
			return behavior_;
		}
		set
		{
			behavior_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceCloud()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceCloud(CommunicationDeviceCloud other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		name_ = other.name_;
		deviceType_ = other.deviceType_;
		behavior_ = other.behavior_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommunicationDeviceCloud Clone()
	{
		return new CommunicationDeviceCloud(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CommunicationDeviceCloud);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CommunicationDeviceCloud other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Id, other.Id))
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (DeviceType != other.DeviceType)
		{
			return false;
		}
		if (Behavior != other.Behavior)
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
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (DeviceType != 0)
		{
			num ^= DeviceType.GetHashCode();
		}
		if (Behavior != 0)
		{
			num ^= Behavior.GetHashCode();
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (DeviceType != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)DeviceType);
		}
		if (Behavior != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Behavior);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (DeviceType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)DeviceType);
		}
		if (Behavior != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Behavior);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CommunicationDeviceCloud other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new UUID();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.DeviceType != 0)
		{
			DeviceType = other.DeviceType;
		}
		if (other.Behavior != 0)
		{
			Behavior = other.Behavior;
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
			case 10u:
				if (id_ == null)
				{
					Id = new UUID();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				Name = input.ReadString();
				break;
			case 24u:
				DeviceType = (CommunicationDevice.Types.DeviceType)input.ReadEnum();
				break;
			case 32u:
				Behavior = (CommunicationDevice.Types.Behavior)input.ReadEnum();
				break;
			}
		}
	}
}
