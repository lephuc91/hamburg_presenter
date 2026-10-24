using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RegistrationInfo : IMessage<RegistrationInfo>, IMessage, IEquatable<RegistrationInfo>, IDeepCloneable<RegistrationInfo>
{
	private static readonly MessageParser<RegistrationInfo> _parser = new MessageParser<RegistrationInfo>(() => new RegistrationInfo());

	private UnknownFieldSet _unknownFields;

	public const int UserNameFieldNumber = 1;

	private string userName_ = "";

	public const int DisplayKeyFieldNumber = 2;

	private string displayKey_ = "";

	public const int DisplayNameFieldNumber = 3;

	private string displayName_ = "";

	public const int ExpirationDateFieldNumber = 4;

	private long expirationDate_;

	public const int ActivationKeyFieldNumber = 5;

	private string activationKey_ = "";

	public const int LicenseTypeFieldNumber = 6;

	private LicenseType licenseType_;

	public const int RegistrationDateFieldNumber = 7;

	private long registrationDate_;

	public const int SeatTypeFieldNumber = 8;

	private SeatType seatType_;

	public const int LatestAvailableBuildNumberFieldNumber = 9;

	private uint latestAvailableBuildNumber_;

	public const int LatestAvailableVersionFieldNumber = 10;

	private string latestAvailableVersion_ = "";

	public const int HasWorshipHouseMediaSubscriptionFieldNumber = 11;

	private bool hasWorshipHouseMediaSubscription_;

	public const int MaintenanceExpirationDateFieldNumber = 12;

	private long maintenanceExpirationDate_;

	public const int NonExtendedMaintenanceExpirationDateFieldNumber = 13;

	private long nonExtendedMaintenanceExpirationDate_;

	public const int IsAutoRenewalActiveFieldNumber = 14;

	private bool isAutoRenewalActive_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RegistrationInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[52];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string UserName
	{
		get
		{
			return userName_;
		}
		set
		{
			userName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DisplayKey
	{
		get
		{
			return displayKey_;
		}
		set
		{
			displayKey_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DisplayName
	{
		get
		{
			return displayName_;
		}
		set
		{
			displayName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long ExpirationDate
	{
		get
		{
			return expirationDate_;
		}
		set
		{
			expirationDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ActivationKey
	{
		get
		{
			return activationKey_;
		}
		set
		{
			activationKey_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseType LicenseType
	{
		get
		{
			return licenseType_;
		}
		set
		{
			licenseType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long RegistrationDate
	{
		get
		{
			return registrationDate_;
		}
		set
		{
			registrationDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SeatType SeatType
	{
		get
		{
			return seatType_;
		}
		set
		{
			seatType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint LatestAvailableBuildNumber
	{
		get
		{
			return latestAvailableBuildNumber_;
		}
		set
		{
			latestAvailableBuildNumber_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string LatestAvailableVersion
	{
		get
		{
			return latestAvailableVersion_;
		}
		set
		{
			latestAvailableVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasWorshipHouseMediaSubscription
	{
		get
		{
			return hasWorshipHouseMediaSubscription_;
		}
		set
		{
			hasWorshipHouseMediaSubscription_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long MaintenanceExpirationDate
	{
		get
		{
			return maintenanceExpirationDate_;
		}
		set
		{
			maintenanceExpirationDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long NonExtendedMaintenanceExpirationDate
	{
		get
		{
			return nonExtendedMaintenanceExpirationDate_;
		}
		set
		{
			nonExtendedMaintenanceExpirationDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsAutoRenewalActive
	{
		get
		{
			return isAutoRenewalActive_;
		}
		set
		{
			isAutoRenewalActive_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationInfo(RegistrationInfo other)
		: this()
	{
		userName_ = other.userName_;
		displayKey_ = other.displayKey_;
		displayName_ = other.displayName_;
		expirationDate_ = other.expirationDate_;
		activationKey_ = other.activationKey_;
		licenseType_ = other.licenseType_;
		registrationDate_ = other.registrationDate_;
		seatType_ = other.seatType_;
		latestAvailableBuildNumber_ = other.latestAvailableBuildNumber_;
		latestAvailableVersion_ = other.latestAvailableVersion_;
		hasWorshipHouseMediaSubscription_ = other.hasWorshipHouseMediaSubscription_;
		maintenanceExpirationDate_ = other.maintenanceExpirationDate_;
		nonExtendedMaintenanceExpirationDate_ = other.nonExtendedMaintenanceExpirationDate_;
		isAutoRenewalActive_ = other.isAutoRenewalActive_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationInfo Clone()
	{
		return new RegistrationInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RegistrationInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RegistrationInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (UserName != other.UserName)
		{
			return false;
		}
		if (DisplayKey != other.DisplayKey)
		{
			return false;
		}
		if (DisplayName != other.DisplayName)
		{
			return false;
		}
		if (ExpirationDate != other.ExpirationDate)
		{
			return false;
		}
		if (ActivationKey != other.ActivationKey)
		{
			return false;
		}
		if (LicenseType != other.LicenseType)
		{
			return false;
		}
		if (RegistrationDate != other.RegistrationDate)
		{
			return false;
		}
		if (SeatType != other.SeatType)
		{
			return false;
		}
		if (LatestAvailableBuildNumber != other.LatestAvailableBuildNumber)
		{
			return false;
		}
		if (LatestAvailableVersion != other.LatestAvailableVersion)
		{
			return false;
		}
		if (HasWorshipHouseMediaSubscription != other.HasWorshipHouseMediaSubscription)
		{
			return false;
		}
		if (MaintenanceExpirationDate != other.MaintenanceExpirationDate)
		{
			return false;
		}
		if (NonExtendedMaintenanceExpirationDate != other.NonExtendedMaintenanceExpirationDate)
		{
			return false;
		}
		if (IsAutoRenewalActive != other.IsAutoRenewalActive)
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
		if (UserName.Length != 0)
		{
			num ^= UserName.GetHashCode();
		}
		if (DisplayKey.Length != 0)
		{
			num ^= DisplayKey.GetHashCode();
		}
		if (DisplayName.Length != 0)
		{
			num ^= DisplayName.GetHashCode();
		}
		if (ExpirationDate != 0L)
		{
			num ^= ExpirationDate.GetHashCode();
		}
		if (ActivationKey.Length != 0)
		{
			num ^= ActivationKey.GetHashCode();
		}
		if (LicenseType != 0)
		{
			num ^= LicenseType.GetHashCode();
		}
		if (RegistrationDate != 0L)
		{
			num ^= RegistrationDate.GetHashCode();
		}
		if (SeatType != 0)
		{
			num ^= SeatType.GetHashCode();
		}
		if (LatestAvailableBuildNumber != 0)
		{
			num ^= LatestAvailableBuildNumber.GetHashCode();
		}
		if (LatestAvailableVersion.Length != 0)
		{
			num ^= LatestAvailableVersion.GetHashCode();
		}
		if (HasWorshipHouseMediaSubscription)
		{
			num ^= HasWorshipHouseMediaSubscription.GetHashCode();
		}
		if (MaintenanceExpirationDate != 0L)
		{
			num ^= MaintenanceExpirationDate.GetHashCode();
		}
		if (NonExtendedMaintenanceExpirationDate != 0L)
		{
			num ^= NonExtendedMaintenanceExpirationDate.GetHashCode();
		}
		if (IsAutoRenewalActive)
		{
			num ^= IsAutoRenewalActive.GetHashCode();
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
		if (UserName.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(UserName);
		}
		if (DisplayKey.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(DisplayKey);
		}
		if (DisplayName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(DisplayName);
		}
		if (ExpirationDate != 0L)
		{
			output.WriteRawTag(32);
			output.WriteInt64(ExpirationDate);
		}
		if (ActivationKey.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(ActivationKey);
		}
		if (LicenseType != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)LicenseType);
		}
		if (RegistrationDate != 0L)
		{
			output.WriteRawTag(56);
			output.WriteInt64(RegistrationDate);
		}
		if (SeatType != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)SeatType);
		}
		if (LatestAvailableBuildNumber != 0)
		{
			output.WriteRawTag(72);
			output.WriteUInt32(LatestAvailableBuildNumber);
		}
		if (LatestAvailableVersion.Length != 0)
		{
			output.WriteRawTag(82);
			output.WriteString(LatestAvailableVersion);
		}
		if (HasWorshipHouseMediaSubscription)
		{
			output.WriteRawTag(88);
			output.WriteBool(HasWorshipHouseMediaSubscription);
		}
		if (MaintenanceExpirationDate != 0L)
		{
			output.WriteRawTag(96);
			output.WriteInt64(MaintenanceExpirationDate);
		}
		if (NonExtendedMaintenanceExpirationDate != 0L)
		{
			output.WriteRawTag(104);
			output.WriteInt64(NonExtendedMaintenanceExpirationDate);
		}
		if (IsAutoRenewalActive)
		{
			output.WriteRawTag(112);
			output.WriteBool(IsAutoRenewalActive);
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
		if (UserName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(UserName);
		}
		if (DisplayKey.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DisplayKey);
		}
		if (DisplayName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DisplayName);
		}
		if (ExpirationDate != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(ExpirationDate);
		}
		if (ActivationKey.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ActivationKey);
		}
		if (LicenseType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LicenseType);
		}
		if (RegistrationDate != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(RegistrationDate);
		}
		if (SeatType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SeatType);
		}
		if (LatestAvailableBuildNumber != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(LatestAvailableBuildNumber);
		}
		if (LatestAvailableVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(LatestAvailableVersion);
		}
		if (HasWorshipHouseMediaSubscription)
		{
			num += 2;
		}
		if (MaintenanceExpirationDate != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(MaintenanceExpirationDate);
		}
		if (NonExtendedMaintenanceExpirationDate != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(NonExtendedMaintenanceExpirationDate);
		}
		if (IsAutoRenewalActive)
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
	public void MergeFrom(RegistrationInfo other)
	{
		if (other != null)
		{
			if (other.UserName.Length != 0)
			{
				UserName = other.UserName;
			}
			if (other.DisplayKey.Length != 0)
			{
				DisplayKey = other.DisplayKey;
			}
			if (other.DisplayName.Length != 0)
			{
				DisplayName = other.DisplayName;
			}
			if (other.ExpirationDate != 0L)
			{
				ExpirationDate = other.ExpirationDate;
			}
			if (other.ActivationKey.Length != 0)
			{
				ActivationKey = other.ActivationKey;
			}
			if (other.LicenseType != 0)
			{
				LicenseType = other.LicenseType;
			}
			if (other.RegistrationDate != 0L)
			{
				RegistrationDate = other.RegistrationDate;
			}
			if (other.SeatType != 0)
			{
				SeatType = other.SeatType;
			}
			if (other.LatestAvailableBuildNumber != 0)
			{
				LatestAvailableBuildNumber = other.LatestAvailableBuildNumber;
			}
			if (other.LatestAvailableVersion.Length != 0)
			{
				LatestAvailableVersion = other.LatestAvailableVersion;
			}
			if (other.HasWorshipHouseMediaSubscription)
			{
				HasWorshipHouseMediaSubscription = other.HasWorshipHouseMediaSubscription;
			}
			if (other.MaintenanceExpirationDate != 0L)
			{
				MaintenanceExpirationDate = other.MaintenanceExpirationDate;
			}
			if (other.NonExtendedMaintenanceExpirationDate != 0L)
			{
				NonExtendedMaintenanceExpirationDate = other.NonExtendedMaintenanceExpirationDate;
			}
			if (other.IsAutoRenewalActive)
			{
				IsAutoRenewalActive = other.IsAutoRenewalActive;
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
				UserName = input.ReadString();
				break;
			case 18u:
				DisplayKey = input.ReadString();
				break;
			case 26u:
				DisplayName = input.ReadString();
				break;
			case 32u:
				ExpirationDate = input.ReadInt64();
				break;
			case 42u:
				ActivationKey = input.ReadString();
				break;
			case 48u:
				LicenseType = (LicenseType)input.ReadEnum();
				break;
			case 56u:
				RegistrationDate = input.ReadInt64();
				break;
			case 64u:
				SeatType = (SeatType)input.ReadEnum();
				break;
			case 72u:
				LatestAvailableBuildNumber = input.ReadUInt32();
				break;
			case 82u:
				LatestAvailableVersion = input.ReadString();
				break;
			case 88u:
				HasWorshipHouseMediaSubscription = input.ReadBool();
				break;
			case 96u:
				MaintenanceExpirationDate = input.ReadInt64();
				break;
			case 104u:
				NonExtendedMaintenanceExpirationDate = input.ReadInt64();
				break;
			case 112u:
				IsAutoRenewalActive = input.ReadBool();
				break;
			}
		}
	}
}
