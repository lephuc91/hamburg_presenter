using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AirplayConfiguration : IMessage<AirplayConfiguration>, IMessage, IEquatable<AirplayConfiguration>, IDeepCloneable<AirplayConfiguration>
{
	private static readonly MessageParser<AirplayConfiguration> _parser = new MessageParser<AirplayConfiguration>(() => new AirplayConfiguration());

	private UnknownFieldSet _unknownFields;

	public const int EnableFieldNumber = 1;

	private bool enable_;

	public const int FairplayPathFieldNumber = 2;

	private string fairplayPath_ = "";

	public const int ServiceNameFieldNumber = 3;

	private string serviceName_ = "";

	public const int PasswordFieldNumber = 4;

	private string password_ = "";

	public const int PasswordEnabledFieldNumber = 5;

	private bool passwordEnabled_;

	public const int UuidFieldNumber = 6;

	private string uuid_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AirplayConfiguration> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Enable
	{
		get
		{
			return enable_;
		}
		set
		{
			enable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string FairplayPath
	{
		get
		{
			return fairplayPath_;
		}
		set
		{
			fairplayPath_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ServiceName
	{
		get
		{
			return serviceName_;
		}
		set
		{
			serviceName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Password
	{
		get
		{
			return password_;
		}
		set
		{
			password_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool PasswordEnabled
	{
		get
		{
			return passwordEnabled_;
		}
		set
		{
			passwordEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirplayConfiguration()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirplayConfiguration(AirplayConfiguration other)
		: this()
	{
		enable_ = other.enable_;
		fairplayPath_ = other.fairplayPath_;
		serviceName_ = other.serviceName_;
		password_ = other.password_;
		passwordEnabled_ = other.passwordEnabled_;
		uuid_ = other.uuid_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AirplayConfiguration Clone()
	{
		return new AirplayConfiguration(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AirplayConfiguration);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AirplayConfiguration other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Enable != other.Enable)
		{
			return false;
		}
		if (FairplayPath != other.FairplayPath)
		{
			return false;
		}
		if (ServiceName != other.ServiceName)
		{
			return false;
		}
		if (Password != other.Password)
		{
			return false;
		}
		if (PasswordEnabled != other.PasswordEnabled)
		{
			return false;
		}
		if (Uuid != other.Uuid)
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
		if (Enable)
		{
			num ^= Enable.GetHashCode();
		}
		if (FairplayPath.Length != 0)
		{
			num ^= FairplayPath.GetHashCode();
		}
		if (ServiceName.Length != 0)
		{
			num ^= ServiceName.GetHashCode();
		}
		if (Password.Length != 0)
		{
			num ^= Password.GetHashCode();
		}
		if (PasswordEnabled)
		{
			num ^= PasswordEnabled.GetHashCode();
		}
		if (Uuid.Length != 0)
		{
			num ^= Uuid.GetHashCode();
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
		if (Enable)
		{
			output.WriteRawTag(8);
			output.WriteBool(Enable);
		}
		if (FairplayPath.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(FairplayPath);
		}
		if (ServiceName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ServiceName);
		}
		if (Password.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Password);
		}
		if (PasswordEnabled)
		{
			output.WriteRawTag(40);
			output.WriteBool(PasswordEnabled);
		}
		if (Uuid.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(Uuid);
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
		if (Enable)
		{
			num += 2;
		}
		if (FairplayPath.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(FairplayPath);
		}
		if (ServiceName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ServiceName);
		}
		if (Password.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Password);
		}
		if (PasswordEnabled)
		{
			num += 2;
		}
		if (Uuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AirplayConfiguration other)
	{
		if (other != null)
		{
			if (other.Enable)
			{
				Enable = other.Enable;
			}
			if (other.FairplayPath.Length != 0)
			{
				FairplayPath = other.FairplayPath;
			}
			if (other.ServiceName.Length != 0)
			{
				ServiceName = other.ServiceName;
			}
			if (other.Password.Length != 0)
			{
				Password = other.Password;
			}
			if (other.PasswordEnabled)
			{
				PasswordEnabled = other.PasswordEnabled;
			}
			if (other.Uuid.Length != 0)
			{
				Uuid = other.Uuid;
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
				Enable = input.ReadBool();
				break;
			case 18u:
				FairplayPath = input.ReadString();
				break;
			case 26u:
				ServiceName = input.ReadString();
				break;
			case 34u:
				Password = input.ReadString();
				break;
			case 40u:
				PasswordEnabled = input.ReadBool();
				break;
			case 50u:
				Uuid = input.ReadString();
				break;
			}
		}
	}
}
