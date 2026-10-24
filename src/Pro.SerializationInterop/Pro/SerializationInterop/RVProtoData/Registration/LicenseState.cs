using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LicenseState : IMessage<LicenseState>, IMessage, IEquatable<LicenseState>, IDeepCloneable<LicenseState>
{
	private static readonly MessageParser<LicenseState> _parser = new MessageParser<LicenseState>(() => new LicenseState());

	private UnknownFieldSet _unknownFields;

	public const int HardwareIdFieldNumber = 1;

	private string hardwareId_ = "";

	public const int FingerprintFieldNumber = 2;

	private string fingerprint_ = "";

	public const int IsRegisteredFieldNumber = 3;

	private bool isRegistered_;

	public const int ActiveSeatFieldNumber = 4;

	private bool activeSeat_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LicenseState> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[44];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string HardwareId
	{
		get
		{
			return hardwareId_;
		}
		set
		{
			hardwareId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

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
	public bool IsRegistered
	{
		get
		{
			return isRegistered_;
		}
		set
		{
			isRegistered_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ActiveSeat
	{
		get
		{
			return activeSeat_;
		}
		set
		{
			activeSeat_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseState()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseState(LicenseState other)
		: this()
	{
		hardwareId_ = other.hardwareId_;
		fingerprint_ = other.fingerprint_;
		isRegistered_ = other.isRegistered_;
		activeSeat_ = other.activeSeat_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseState Clone()
	{
		return new LicenseState(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LicenseState);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LicenseState other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (HardwareId != other.HardwareId)
		{
			return false;
		}
		if (Fingerprint != other.Fingerprint)
		{
			return false;
		}
		if (IsRegistered != other.IsRegistered)
		{
			return false;
		}
		if (ActiveSeat != other.ActiveSeat)
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
		if (HardwareId.Length != 0)
		{
			num ^= HardwareId.GetHashCode();
		}
		if (Fingerprint.Length != 0)
		{
			num ^= Fingerprint.GetHashCode();
		}
		if (IsRegistered)
		{
			num ^= IsRegistered.GetHashCode();
		}
		if (ActiveSeat)
		{
			num ^= ActiveSeat.GetHashCode();
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
		if (HardwareId.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(HardwareId);
		}
		if (Fingerprint.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Fingerprint);
		}
		if (IsRegistered)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsRegistered);
		}
		if (ActiveSeat)
		{
			output.WriteRawTag(32);
			output.WriteBool(ActiveSeat);
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
		if (HardwareId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(HardwareId);
		}
		if (Fingerprint.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Fingerprint);
		}
		if (IsRegistered)
		{
			num += 2;
		}
		if (ActiveSeat)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LicenseState other)
	{
		if (other != null)
		{
			if (other.HardwareId.Length != 0)
			{
				HardwareId = other.HardwareId;
			}
			if (other.Fingerprint.Length != 0)
			{
				Fingerprint = other.Fingerprint;
			}
			if (other.IsRegistered)
			{
				IsRegistered = other.IsRegistered;
			}
			if (other.ActiveSeat)
			{
				ActiveSeat = other.ActiveSeat;
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
				HardwareId = input.ReadString();
				break;
			case 18u:
				Fingerprint = input.ReadString();
				break;
			case 24u:
				IsRegistered = input.ReadBool();
				break;
			case 32u:
				ActiveSeat = input.ReadBool();
				break;
			}
		}
	}
}
