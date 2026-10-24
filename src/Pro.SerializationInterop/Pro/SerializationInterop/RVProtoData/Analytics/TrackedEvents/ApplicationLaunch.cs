using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ApplicationLaunch : IMessage<ApplicationLaunch>, IMessage, IEquatable<ApplicationLaunch>, IDeepCloneable<ApplicationLaunch>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Channel
		{
			[OriginalName("BETA")]
			Beta,
			[OriginalName("RELEASE")]
			Release
		}

		public enum Platform
		{
			[OriginalName("WINDOWS")]
			Windows,
			[OriginalName("MACOS")]
			Macos
		}
	}

	private static readonly MessageParser<ApplicationLaunch> _parser = new MessageParser<ApplicationLaunch>(() => new ApplicationLaunch());

	private UnknownFieldSet _unknownFields;

	public const int HardwareIdFieldNumber = 1;

	private string hardwareId_ = "";

	public const int ChannelFieldNumber = 2;

	private Types.Channel channel_;

	public const int PlatformFieldNumber = 3;

	private Types.Platform platform_;

	public const int AppVersionFieldNumber = 4;

	private string appVersion_ = "";

	public const int OsVersionFieldNumber = 5;

	private string osVersion_ = "";

	public const int BuildNumberFieldNumber = 6;

	private string buildNumber_ = "";

	public const int LocationFieldNumber = 7;

	private string location_ = "";

	public const int LanguageFieldNumber = 8;

	private string language_ = "";

	public const int HardwareModelFieldNumber = 9;

	private string hardwareModel_ = "";

	public const int PhysicalMemoryFieldNumber = 10;

	private ulong physicalMemory_;

	public const int VideoControllerFieldNumber = 11;

	private string videoController_ = "";

	public const int VideoControllerRamFieldNumber = 12;

	private ulong videoControllerRam_;

	public const int BlackmagicDesktopVersionFieldNumber = 13;

	private string blackmagicDesktopVersion_ = "";

	public const int EnabledFeatureFlagsFieldNumber = 14;

	private static readonly FieldCodec<string> _repeated_enabledFeatureFlags_codec = FieldCodec.ForString(114u);

	private readonly RepeatedField<string> enabledFeatureFlags_ = new RepeatedField<string>();

	public const int OrganizationIdFieldNumber = 15;

	private string organizationId_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ApplicationLaunch> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[1];

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
	public Types.Channel Channel
	{
		get
		{
			return channel_;
		}
		set
		{
			channel_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Platform Platform
	{
		get
		{
			return platform_;
		}
		set
		{
			platform_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string AppVersion
	{
		get
		{
			return appVersion_;
		}
		set
		{
			appVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string OsVersion
	{
		get
		{
			return osVersion_;
		}
		set
		{
			osVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string BuildNumber
	{
		get
		{
			return buildNumber_;
		}
		set
		{
			buildNumber_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Location
	{
		get
		{
			return location_;
		}
		set
		{
			location_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Language
	{
		get
		{
			return language_;
		}
		set
		{
			language_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string HardwareModel
	{
		get
		{
			return hardwareModel_;
		}
		set
		{
			hardwareModel_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong PhysicalMemory
	{
		get
		{
			return physicalMemory_;
		}
		set
		{
			physicalMemory_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string VideoController
	{
		get
		{
			return videoController_;
		}
		set
		{
			videoController_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong VideoControllerRam
	{
		get
		{
			return videoControllerRam_;
		}
		set
		{
			videoControllerRam_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string BlackmagicDesktopVersion
	{
		get
		{
			return blackmagicDesktopVersion_;
		}
		set
		{
			blackmagicDesktopVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<string> EnabledFeatureFlags => enabledFeatureFlags_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string OrganizationId
	{
		get
		{
			return organizationId_;
		}
		set
		{
			organizationId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationLaunch()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationLaunch(ApplicationLaunch other)
		: this()
	{
		hardwareId_ = other.hardwareId_;
		channel_ = other.channel_;
		platform_ = other.platform_;
		appVersion_ = other.appVersion_;
		osVersion_ = other.osVersion_;
		buildNumber_ = other.buildNumber_;
		location_ = other.location_;
		language_ = other.language_;
		hardwareModel_ = other.hardwareModel_;
		physicalMemory_ = other.physicalMemory_;
		videoController_ = other.videoController_;
		videoControllerRam_ = other.videoControllerRam_;
		blackmagicDesktopVersion_ = other.blackmagicDesktopVersion_;
		enabledFeatureFlags_ = other.enabledFeatureFlags_.Clone();
		organizationId_ = other.organizationId_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationLaunch Clone()
	{
		return new ApplicationLaunch(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ApplicationLaunch);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ApplicationLaunch other)
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
		if (Channel != other.Channel)
		{
			return false;
		}
		if (Platform != other.Platform)
		{
			return false;
		}
		if (AppVersion != other.AppVersion)
		{
			return false;
		}
		if (OsVersion != other.OsVersion)
		{
			return false;
		}
		if (BuildNumber != other.BuildNumber)
		{
			return false;
		}
		if (Location != other.Location)
		{
			return false;
		}
		if (Language != other.Language)
		{
			return false;
		}
		if (HardwareModel != other.HardwareModel)
		{
			return false;
		}
		if (PhysicalMemory != other.PhysicalMemory)
		{
			return false;
		}
		if (VideoController != other.VideoController)
		{
			return false;
		}
		if (VideoControllerRam != other.VideoControllerRam)
		{
			return false;
		}
		if (BlackmagicDesktopVersion != other.BlackmagicDesktopVersion)
		{
			return false;
		}
		if (!enabledFeatureFlags_.Equals(other.enabledFeatureFlags_))
		{
			return false;
		}
		if (OrganizationId != other.OrganizationId)
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
		if (Channel != 0)
		{
			num ^= Channel.GetHashCode();
		}
		if (Platform != 0)
		{
			num ^= Platform.GetHashCode();
		}
		if (AppVersion.Length != 0)
		{
			num ^= AppVersion.GetHashCode();
		}
		if (OsVersion.Length != 0)
		{
			num ^= OsVersion.GetHashCode();
		}
		if (BuildNumber.Length != 0)
		{
			num ^= BuildNumber.GetHashCode();
		}
		if (Location.Length != 0)
		{
			num ^= Location.GetHashCode();
		}
		if (Language.Length != 0)
		{
			num ^= Language.GetHashCode();
		}
		if (HardwareModel.Length != 0)
		{
			num ^= HardwareModel.GetHashCode();
		}
		if (PhysicalMemory != 0L)
		{
			num ^= PhysicalMemory.GetHashCode();
		}
		if (VideoController.Length != 0)
		{
			num ^= VideoController.GetHashCode();
		}
		if (VideoControllerRam != 0L)
		{
			num ^= VideoControllerRam.GetHashCode();
		}
		if (BlackmagicDesktopVersion.Length != 0)
		{
			num ^= BlackmagicDesktopVersion.GetHashCode();
		}
		num ^= enabledFeatureFlags_.GetHashCode();
		if (OrganizationId.Length != 0)
		{
			num ^= OrganizationId.GetHashCode();
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
		if (Channel != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Channel);
		}
		if (Platform != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Platform);
		}
		if (AppVersion.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(AppVersion);
		}
		if (OsVersion.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(OsVersion);
		}
		if (BuildNumber.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(BuildNumber);
		}
		if (Location.Length != 0)
		{
			output.WriteRawTag(58);
			output.WriteString(Location);
		}
		if (Language.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(Language);
		}
		if (HardwareModel.Length != 0)
		{
			output.WriteRawTag(74);
			output.WriteString(HardwareModel);
		}
		if (PhysicalMemory != 0L)
		{
			output.WriteRawTag(80);
			output.WriteUInt64(PhysicalMemory);
		}
		if (VideoController.Length != 0)
		{
			output.WriteRawTag(90);
			output.WriteString(VideoController);
		}
		if (VideoControllerRam != 0L)
		{
			output.WriteRawTag(96);
			output.WriteUInt64(VideoControllerRam);
		}
		if (BlackmagicDesktopVersion.Length != 0)
		{
			output.WriteRawTag(106);
			output.WriteString(BlackmagicDesktopVersion);
		}
		enabledFeatureFlags_.WriteTo(output, _repeated_enabledFeatureFlags_codec);
		if (OrganizationId.Length != 0)
		{
			output.WriteRawTag(122);
			output.WriteString(OrganizationId);
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
		if (Channel != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Channel);
		}
		if (Platform != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Platform);
		}
		if (AppVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(AppVersion);
		}
		if (OsVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(OsVersion);
		}
		if (BuildNumber.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BuildNumber);
		}
		if (Location.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Location);
		}
		if (Language.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Language);
		}
		if (HardwareModel.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(HardwareModel);
		}
		if (PhysicalMemory != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(PhysicalMemory);
		}
		if (VideoController.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(VideoController);
		}
		if (VideoControllerRam != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(VideoControllerRam);
		}
		if (BlackmagicDesktopVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BlackmagicDesktopVersion);
		}
		num += enabledFeatureFlags_.CalculateSize(_repeated_enabledFeatureFlags_codec);
		if (OrganizationId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(OrganizationId);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ApplicationLaunch other)
	{
		if (other != null)
		{
			if (other.HardwareId.Length != 0)
			{
				HardwareId = other.HardwareId;
			}
			if (other.Channel != 0)
			{
				Channel = other.Channel;
			}
			if (other.Platform != 0)
			{
				Platform = other.Platform;
			}
			if (other.AppVersion.Length != 0)
			{
				AppVersion = other.AppVersion;
			}
			if (other.OsVersion.Length != 0)
			{
				OsVersion = other.OsVersion;
			}
			if (other.BuildNumber.Length != 0)
			{
				BuildNumber = other.BuildNumber;
			}
			if (other.Location.Length != 0)
			{
				Location = other.Location;
			}
			if (other.Language.Length != 0)
			{
				Language = other.Language;
			}
			if (other.HardwareModel.Length != 0)
			{
				HardwareModel = other.HardwareModel;
			}
			if (other.PhysicalMemory != 0L)
			{
				PhysicalMemory = other.PhysicalMemory;
			}
			if (other.VideoController.Length != 0)
			{
				VideoController = other.VideoController;
			}
			if (other.VideoControllerRam != 0L)
			{
				VideoControllerRam = other.VideoControllerRam;
			}
			if (other.BlackmagicDesktopVersion.Length != 0)
			{
				BlackmagicDesktopVersion = other.BlackmagicDesktopVersion;
			}
			enabledFeatureFlags_.Add(other.enabledFeatureFlags_);
			if (other.OrganizationId.Length != 0)
			{
				OrganizationId = other.OrganizationId;
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
			case 16u:
				Channel = (Types.Channel)input.ReadEnum();
				break;
			case 24u:
				Platform = (Types.Platform)input.ReadEnum();
				break;
			case 34u:
				AppVersion = input.ReadString();
				break;
			case 42u:
				OsVersion = input.ReadString();
				break;
			case 50u:
				BuildNumber = input.ReadString();
				break;
			case 58u:
				Location = input.ReadString();
				break;
			case 66u:
				Language = input.ReadString();
				break;
			case 74u:
				HardwareModel = input.ReadString();
				break;
			case 80u:
				PhysicalMemory = input.ReadUInt64();
				break;
			case 90u:
				VideoController = input.ReadString();
				break;
			case 96u:
				VideoControllerRam = input.ReadUInt64();
				break;
			case 106u:
				BlackmagicDesktopVersion = input.ReadString();
				break;
			case 114u:
				enabledFeatureFlags_.AddEntriesFrom(input, _repeated_enabledFeatureFlags_codec);
				break;
			case 122u:
				OrganizationId = input.ReadString();
				break;
			}
		}
	}
}
