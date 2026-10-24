using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class BuildInformation : IMessage<BuildInformation>, IMessage, IEquatable<BuildInformation>, IDeepCloneable<BuildInformation>
{
	private static readonly MessageParser<BuildInformation> _parser = new MessageParser<BuildInformation>(() => new BuildInformation());

	private UnknownFieldSet _unknownFields;

	public const int BuildNumberFieldNumber = 1;

	private int buildNumber_;

	public const int VersionFieldNumber = 2;

	private string version_ = "";

	public const int MinOsVersionFieldNumber = 3;

	private string minOsVersion_ = "";

	public const int ReleaseDateFieldNumber = 4;

	private long releaseDate_;

	public const int RegistrationDateFieldNumber = 5;

	private long registrationDate_;

	public const int DownloadSizeFieldNumber = 6;

	private long downloadSize_;

	public const int DownloadUrlFieldNumber = 7;

	private string downloadUrl_ = "";

	public const int ChannelFieldNumber = 8;

	private string channel_ = "";

	public const int IsBetaFieldNumber = 9;

	private bool isBeta_;

	public const int IsAvailableFieldNumber = 10;

	private bool isAvailable_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<BuildInformation> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[53];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int BuildNumber
	{
		get
		{
			return buildNumber_;
		}
		set
		{
			buildNumber_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Version
	{
		get
		{
			return version_;
		}
		set
		{
			version_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MinOsVersion
	{
		get
		{
			return minOsVersion_;
		}
		set
		{
			minOsVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long ReleaseDate
	{
		get
		{
			return releaseDate_;
		}
		set
		{
			releaseDate_ = value;
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
	public long DownloadSize
	{
		get
		{
			return downloadSize_;
		}
		set
		{
			downloadSize_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DownloadUrl
	{
		get
		{
			return downloadUrl_;
		}
		set
		{
			downloadUrl_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Channel
	{
		get
		{
			return channel_;
		}
		set
		{
			channel_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsBeta
	{
		get
		{
			return isBeta_;
		}
		set
		{
			isBeta_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsAvailable
	{
		get
		{
			return isAvailable_;
		}
		set
		{
			isAvailable_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BuildInformation()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BuildInformation(BuildInformation other)
		: this()
	{
		buildNumber_ = other.buildNumber_;
		version_ = other.version_;
		minOsVersion_ = other.minOsVersion_;
		releaseDate_ = other.releaseDate_;
		registrationDate_ = other.registrationDate_;
		downloadSize_ = other.downloadSize_;
		downloadUrl_ = other.downloadUrl_;
		channel_ = other.channel_;
		isBeta_ = other.isBeta_;
		isAvailable_ = other.isAvailable_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BuildInformation Clone()
	{
		return new BuildInformation(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as BuildInformation);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(BuildInformation other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (BuildNumber != other.BuildNumber)
		{
			return false;
		}
		if (Version != other.Version)
		{
			return false;
		}
		if (MinOsVersion != other.MinOsVersion)
		{
			return false;
		}
		if (ReleaseDate != other.ReleaseDate)
		{
			return false;
		}
		if (RegistrationDate != other.RegistrationDate)
		{
			return false;
		}
		if (DownloadSize != other.DownloadSize)
		{
			return false;
		}
		if (DownloadUrl != other.DownloadUrl)
		{
			return false;
		}
		if (Channel != other.Channel)
		{
			return false;
		}
		if (IsBeta != other.IsBeta)
		{
			return false;
		}
		if (IsAvailable != other.IsAvailable)
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
		if (BuildNumber != 0)
		{
			num ^= BuildNumber.GetHashCode();
		}
		if (Version.Length != 0)
		{
			num ^= Version.GetHashCode();
		}
		if (MinOsVersion.Length != 0)
		{
			num ^= MinOsVersion.GetHashCode();
		}
		if (ReleaseDate != 0L)
		{
			num ^= ReleaseDate.GetHashCode();
		}
		if (RegistrationDate != 0L)
		{
			num ^= RegistrationDate.GetHashCode();
		}
		if (DownloadSize != 0L)
		{
			num ^= DownloadSize.GetHashCode();
		}
		if (DownloadUrl.Length != 0)
		{
			num ^= DownloadUrl.GetHashCode();
		}
		if (Channel.Length != 0)
		{
			num ^= Channel.GetHashCode();
		}
		if (IsBeta)
		{
			num ^= IsBeta.GetHashCode();
		}
		if (IsAvailable)
		{
			num ^= IsAvailable.GetHashCode();
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
		if (BuildNumber != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(BuildNumber);
		}
		if (Version.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Version);
		}
		if (MinOsVersion.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(MinOsVersion);
		}
		if (ReleaseDate != 0L)
		{
			output.WriteRawTag(32);
			output.WriteInt64(ReleaseDate);
		}
		if (RegistrationDate != 0L)
		{
			output.WriteRawTag(40);
			output.WriteInt64(RegistrationDate);
		}
		if (DownloadSize != 0L)
		{
			output.WriteRawTag(48);
			output.WriteInt64(DownloadSize);
		}
		if (DownloadUrl.Length != 0)
		{
			output.WriteRawTag(58);
			output.WriteString(DownloadUrl);
		}
		if (Channel.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(Channel);
		}
		if (IsBeta)
		{
			output.WriteRawTag(72);
			output.WriteBool(IsBeta);
		}
		if (IsAvailable)
		{
			output.WriteRawTag(80);
			output.WriteBool(IsAvailable);
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
		if (BuildNumber != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(BuildNumber);
		}
		if (Version.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Version);
		}
		if (MinOsVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(MinOsVersion);
		}
		if (ReleaseDate != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(ReleaseDate);
		}
		if (RegistrationDate != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(RegistrationDate);
		}
		if (DownloadSize != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(DownloadSize);
		}
		if (DownloadUrl.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DownloadUrl);
		}
		if (Channel.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Channel);
		}
		if (IsBeta)
		{
			num += 2;
		}
		if (IsAvailable)
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
	public void MergeFrom(BuildInformation other)
	{
		if (other != null)
		{
			if (other.BuildNumber != 0)
			{
				BuildNumber = other.BuildNumber;
			}
			if (other.Version.Length != 0)
			{
				Version = other.Version;
			}
			if (other.MinOsVersion.Length != 0)
			{
				MinOsVersion = other.MinOsVersion;
			}
			if (other.ReleaseDate != 0L)
			{
				ReleaseDate = other.ReleaseDate;
			}
			if (other.RegistrationDate != 0L)
			{
				RegistrationDate = other.RegistrationDate;
			}
			if (other.DownloadSize != 0L)
			{
				DownloadSize = other.DownloadSize;
			}
			if (other.DownloadUrl.Length != 0)
			{
				DownloadUrl = other.DownloadUrl;
			}
			if (other.Channel.Length != 0)
			{
				Channel = other.Channel;
			}
			if (other.IsBeta)
			{
				IsBeta = other.IsBeta;
			}
			if (other.IsAvailable)
			{
				IsAvailable = other.IsAvailable;
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
				BuildNumber = input.ReadInt32();
				break;
			case 18u:
				Version = input.ReadString();
				break;
			case 26u:
				MinOsVersion = input.ReadString();
				break;
			case 32u:
				ReleaseDate = input.ReadInt64();
				break;
			case 40u:
				RegistrationDate = input.ReadInt64();
				break;
			case 48u:
				DownloadSize = input.ReadInt64();
				break;
			case 58u:
				DownloadUrl = input.ReadString();
				break;
			case 66u:
				Channel = input.ReadString();
				break;
			case 72u:
				IsBeta = input.ReadBool();
				break;
			case 80u:
				IsAvailable = input.ReadBool();
				break;
			}
		}
	}
}
