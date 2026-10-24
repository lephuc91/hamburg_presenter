using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NetworkLinkStatus : IMessage<NetworkLinkStatus>, IMessage, IEquatable<NetworkLinkStatus>, IDeepCloneable<NetworkLinkStatus>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LinkedClientInformation : IMessage<LinkedClientInformation>, IMessage, IEquatable<LinkedClientInformation>, IDeepCloneable<LinkedClientInformation>
		{
			private static readonly MessageParser<LinkedClientInformation> _parser = new MessageParser<LinkedClientInformation>(() => new LinkedClientInformation());

			private UnknownFieldSet _unknownFields;

			public const int PlatformFieldNumber = 1;

			private ApplicationInfo.Types.Platform platform_;

			public const int OsVersionFieldNumber = 2;

			private string osVersion_ = "";

			public const int VersionFieldNumber = 3;

			private string version_ = "";

			public const int DescriptionFieldNumber = 4;

			private string description_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LinkedClientInformation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkLinkStatus.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ApplicationInfo.Types.Platform Platform
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
			public LinkedClientInformation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LinkedClientInformation(LinkedClientInformation other)
				: this()
			{
				platform_ = other.platform_;
				osVersion_ = other.osVersion_;
				version_ = other.version_;
				description_ = other.description_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LinkedClientInformation Clone()
			{
				return new LinkedClientInformation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LinkedClientInformation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LinkedClientInformation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Platform != other.Platform)
				{
					return false;
				}
				if (OsVersion != other.OsVersion)
				{
					return false;
				}
				if (Version != other.Version)
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
				if (Platform != 0)
				{
					num ^= Platform.GetHashCode();
				}
				if (OsVersion.Length != 0)
				{
					num ^= OsVersion.GetHashCode();
				}
				if (Version.Length != 0)
				{
					num ^= Version.GetHashCode();
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
				if (Platform != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Platform);
				}
				if (OsVersion.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(OsVersion);
				}
				if (Version.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Version);
				}
				if (Description.Length != 0)
				{
					output.WriteRawTag(34);
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
				if (Platform != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Platform);
				}
				if (OsVersion.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(OsVersion);
				}
				if (Version.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Version);
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
			public void MergeFrom(LinkedClientInformation other)
			{
				if (other != null)
				{
					if (other.Platform != 0)
					{
						Platform = other.Platform;
					}
					if (other.OsVersion.Length != 0)
					{
						OsVersion = other.OsVersion;
					}
					if (other.Version.Length != 0)
					{
						Version = other.Version;
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
						Platform = (ApplicationInfo.Types.Platform)input.ReadEnum();
						break;
					case 18u:
						OsVersion = input.ReadString();
						break;
					case 26u:
						Version = input.ReadString();
						break;
					case 34u:
						Description = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class StatusPair : IMessage<StatusPair>, IMessage, IEquatable<StatusPair>, IDeepCloneable<StatusPair>
		{
			private static readonly MessageParser<StatusPair> _parser = new MessageParser<StatusPair>(() => new StatusPair());

			private UnknownFieldSet _unknownFields;

			public const int IpAddressFieldNumber = 1;

			private string ipAddress_ = "";

			public const int PortFieldNumber = 2;

			private int port_;

			public const int LinkedClientInformationFieldNumber = 3;

			private LinkedClientInformation linkedClientInformation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StatusPair> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkLinkStatus.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string IpAddress
			{
				get
				{
					return ipAddress_;
				}
				set
				{
					ipAddress_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Port
			{
				get
				{
					return port_;
				}
				set
				{
					port_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LinkedClientInformation LinkedClientInformation
			{
				get
				{
					return linkedClientInformation_;
				}
				set
				{
					linkedClientInformation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StatusPair()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StatusPair(StatusPair other)
				: this()
			{
				ipAddress_ = other.ipAddress_;
				port_ = other.port_;
				linkedClientInformation_ = ((other.linkedClientInformation_ != null) ? other.linkedClientInformation_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StatusPair Clone()
			{
				return new StatusPair(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as StatusPair);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(StatusPair other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (IpAddress != other.IpAddress)
				{
					return false;
				}
				if (Port != other.Port)
				{
					return false;
				}
				if (!object.Equals(LinkedClientInformation, other.LinkedClientInformation))
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
				if (IpAddress.Length != 0)
				{
					num ^= IpAddress.GetHashCode();
				}
				if (Port != 0)
				{
					num ^= Port.GetHashCode();
				}
				if (linkedClientInformation_ != null)
				{
					num ^= LinkedClientInformation.GetHashCode();
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
				if (IpAddress.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(IpAddress);
				}
				if (Port != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Port);
				}
				if (linkedClientInformation_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(LinkedClientInformation);
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
				if (IpAddress.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(IpAddress);
				}
				if (Port != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Port);
				}
				if (linkedClientInformation_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LinkedClientInformation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(StatusPair other)
			{
				if (other == null)
				{
					return;
				}
				if (other.IpAddress.Length != 0)
				{
					IpAddress = other.IpAddress;
				}
				if (other.Port != 0)
				{
					Port = other.Port;
				}
				if (other.linkedClientInformation_ != null)
				{
					if (linkedClientInformation_ == null)
					{
						LinkedClientInformation = new LinkedClientInformation();
					}
					LinkedClientInformation.MergeFrom(other.LinkedClientInformation);
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
						IpAddress = input.ReadString();
						break;
					case 16u:
						Port = input.ReadInt32();
						break;
					case 26u:
						if (linkedClientInformation_ == null)
						{
							LinkedClientInformation = new LinkedClientInformation();
						}
						input.ReadMessage(LinkedClientInformation);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<NetworkLinkStatus> _parser = new MessageParser<NetworkLinkStatus>(() => new NetworkLinkStatus());

	private UnknownFieldSet _unknownFields;

	public const int StatusPairsFieldNumber = 1;

	private static readonly FieldCodec<Types.StatusPair> _repeated_statusPairs_codec = FieldCodec.ForMessage(10u, Types.StatusPair.Parser);

	private readonly RepeatedField<Types.StatusPair> statusPairs_ = new RepeatedField<Types.StatusPair>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NetworkLinkStatus> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => NetworklinkReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.StatusPair> StatusPairs => statusPairs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLinkStatus()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLinkStatus(NetworkLinkStatus other)
		: this()
	{
		statusPairs_ = other.statusPairs_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkLinkStatus Clone()
	{
		return new NetworkLinkStatus(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NetworkLinkStatus);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NetworkLinkStatus other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!statusPairs_.Equals(other.statusPairs_))
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
		num ^= statusPairs_.GetHashCode();
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
		statusPairs_.WriteTo(output, _repeated_statusPairs_codec);
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
		num += statusPairs_.CalculateSize(_repeated_statusPairs_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(NetworkLinkStatus other)
	{
		if (other != null)
		{
			statusPairs_.Add(other.statusPairs_);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				statusPairs_.AddEntriesFrom(input, _repeated_statusPairs_codec);
			}
		}
	}
}
