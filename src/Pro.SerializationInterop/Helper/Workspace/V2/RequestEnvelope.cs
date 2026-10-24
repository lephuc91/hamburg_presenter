using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Helper.Workspace.V2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RequestEnvelope : IMessage<RequestEnvelope>, IMessage, IEquatable<RequestEnvelope>, IDeepCloneable<RequestEnvelope>
{
	public enum RequestOneofCase
	{
		None = 0,
		Start = 2,
		ChangeShowDirectory = 3,
		Add = 4,
		Duplicate = 5,
		Apply = 6,
		Remove = 7,
		Trigger = 8,
		Ping = 9,
		UpdateWorkspaces = 10,
		PauseSync = 12,
		ResumeSync = 13,
		UpdatePrefs = 14,
		UpdateSmartPlaylists = 15,
		AddProContentReference = 16,
		MarkAsCloud = 17,
		MarkAsLocal = 18,
		RemoveContainer = 19,
		UpdateWebToken = 20,
		ImportUnmanagedMedia = 21
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Start : IMessage<Start>, IMessage, IEquatable<Start>, IDeepCloneable<Start>
		{
			private static readonly MessageParser<Start> _parser = new MessageParser<Start>(() => new Start());

			private UnknownFieldSet _unknownFields;

			private int _hasBits0;

			public const int ProductInfoFieldNumber = 1;

			private ProductInformation productInfo_;

			public const int ShowDirectoryFieldNumber = 2;

			private string showDirectory_ = "";

			public const int PreferencesFieldNumber = 3;

			private Preferences preferences_;

			public const int FeatureFlagsFieldNumber = 4;

			private FeatureFlags featureFlags_;

			public const int WorkspaceIdFieldNumber = 5;

			private static readonly string WorkspaceIdDefaultValue = "";

			private string workspaceId_;

			public const int PeerIdFieldNumber = 6;

			private static readonly ulong PeerIdDefaultValue = 0uL;

			private ulong peerId_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Start> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProductInformation ProductInfo
			{
				get
				{
					return productInfo_;
				}
				set
				{
					productInfo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ShowDirectory
			{
				get
				{
					return showDirectory_;
				}
				set
				{
					showDirectory_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preferences Preferences
			{
				get
				{
					return preferences_;
				}
				set
				{
					preferences_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FeatureFlags FeatureFlags
			{
				get
				{
					return featureFlags_;
				}
				set
				{
					featureFlags_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string WorkspaceId
			{
				get
				{
					return workspaceId_ ?? WorkspaceIdDefaultValue;
				}
				set
				{
					workspaceId_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasWorkspaceId => workspaceId_ != null;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong PeerId
			{
				get
				{
					if ((_hasBits0 & 1) != 0)
					{
						return peerId_;
					}
					return PeerIdDefaultValue;
				}
				set
				{
					_hasBits0 |= 1;
					peerId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasPeerId => (_hasBits0 & 1) != 0;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Start()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Start(Start other)
				: this()
			{
				_hasBits0 = other._hasBits0;
				productInfo_ = ((other.productInfo_ != null) ? other.productInfo_.Clone() : null);
				showDirectory_ = other.showDirectory_;
				preferences_ = ((other.preferences_ != null) ? other.preferences_.Clone() : null);
				featureFlags_ = ((other.featureFlags_ != null) ? other.featureFlags_.Clone() : null);
				workspaceId_ = other.workspaceId_;
				peerId_ = other.peerId_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Start Clone()
			{
				return new Start(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearWorkspaceId()
			{
				workspaceId_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearPeerId()
			{
				_hasBits0 &= -2;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Start);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Start other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(ProductInfo, other.ProductInfo))
				{
					return false;
				}
				if (ShowDirectory != other.ShowDirectory)
				{
					return false;
				}
				if (!object.Equals(Preferences, other.Preferences))
				{
					return false;
				}
				if (!object.Equals(FeatureFlags, other.FeatureFlags))
				{
					return false;
				}
				if (WorkspaceId != other.WorkspaceId)
				{
					return false;
				}
				if (PeerId != other.PeerId)
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
				if (productInfo_ != null)
				{
					num ^= ProductInfo.GetHashCode();
				}
				if (ShowDirectory.Length != 0)
				{
					num ^= ShowDirectory.GetHashCode();
				}
				if (preferences_ != null)
				{
					num ^= Preferences.GetHashCode();
				}
				if (featureFlags_ != null)
				{
					num ^= FeatureFlags.GetHashCode();
				}
				if (HasWorkspaceId)
				{
					num ^= WorkspaceId.GetHashCode();
				}
				if (HasPeerId)
				{
					num ^= PeerId.GetHashCode();
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
				if (productInfo_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(ProductInfo);
				}
				if (ShowDirectory.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ShowDirectory);
				}
				if (preferences_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Preferences);
				}
				if (featureFlags_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(FeatureFlags);
				}
				if (HasWorkspaceId)
				{
					output.WriteRawTag(42);
					output.WriteString(WorkspaceId);
				}
				if (HasPeerId)
				{
					output.WriteRawTag(48);
					output.WriteUInt64(PeerId);
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
				if (productInfo_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ProductInfo);
				}
				if (ShowDirectory.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ShowDirectory);
				}
				if (preferences_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Preferences);
				}
				if (featureFlags_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(FeatureFlags);
				}
				if (HasWorkspaceId)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(WorkspaceId);
				}
				if (HasPeerId)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(PeerId);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Start other)
			{
				if (other == null)
				{
					return;
				}
				if (other.productInfo_ != null)
				{
					if (productInfo_ == null)
					{
						ProductInfo = new ProductInformation();
					}
					ProductInfo.MergeFrom(other.ProductInfo);
				}
				if (other.ShowDirectory.Length != 0)
				{
					ShowDirectory = other.ShowDirectory;
				}
				if (other.preferences_ != null)
				{
					if (preferences_ == null)
					{
						Preferences = new Preferences();
					}
					Preferences.MergeFrom(other.Preferences);
				}
				if (other.featureFlags_ != null)
				{
					if (featureFlags_ == null)
					{
						FeatureFlags = new FeatureFlags();
					}
					FeatureFlags.MergeFrom(other.FeatureFlags);
				}
				if (other.HasWorkspaceId)
				{
					WorkspaceId = other.WorkspaceId;
				}
				if (other.HasPeerId)
				{
					PeerId = other.PeerId;
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
						if (productInfo_ == null)
						{
							ProductInfo = new ProductInformation();
						}
						input.ReadMessage(ProductInfo);
						break;
					case 18u:
						ShowDirectory = input.ReadString();
						break;
					case 26u:
						if (preferences_ == null)
						{
							Preferences = new Preferences();
						}
						input.ReadMessage(Preferences);
						break;
					case 34u:
						if (featureFlags_ == null)
						{
							FeatureFlags = new FeatureFlags();
						}
						input.ReadMessage(FeatureFlags);
						break;
					case 42u:
						WorkspaceId = input.ReadString();
						break;
					case 48u:
						PeerId = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Header : IMessage<Header>, IMessage, IEquatable<Header>, IDeepCloneable<Header>
		{
			private static readonly MessageParser<Header> _parser = new MessageParser<Header>(() => new Header());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Header> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header(Header other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header Clone()
			{
				return new Header(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Header);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Header other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Header other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Channel : IMessage<Channel>, IMessage, IEquatable<Channel>, IDeepCloneable<Channel>
		{
			private static readonly MessageParser<Channel> _parser = new MessageParser<Channel>(() => new Channel());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int PermissionFieldNumber = 2;

			private string permission_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Channel> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public string Permission
			{
				get
				{
					return permission_;
				}
				set
				{
					permission_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Channel()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Channel(Channel other)
				: this()
			{
				name_ = other.name_;
				permission_ = other.permission_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Channel Clone()
			{
				return new Channel(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Channel);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Channel other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Permission != other.Permission)
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Permission.Length != 0)
				{
					num ^= Permission.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				if (Permission.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Permission);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Permission.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Permission);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Channel other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Permission.Length != 0)
					{
						Permission = other.Permission;
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
						Name = input.ReadString();
						break;
					case 18u:
						Permission = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class RemoteChannelInfo : IMessage<RemoteChannelInfo>, IMessage, IEquatable<RemoteChannelInfo>, IDeepCloneable<RemoteChannelInfo>
		{
			private static readonly MessageParser<RemoteChannelInfo> _parser = new MessageParser<RemoteChannelInfo>(() => new RemoteChannelInfo());

			private UnknownFieldSet _unknownFields;

			public const int ChannelsFieldNumber = 1;

			private static readonly FieldCodec<Channel> _repeated_channels_codec = FieldCodec.ForMessage(10u, Channel.Parser);

			private readonly RepeatedField<Channel> channels_ = new RepeatedField<Channel>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<RemoteChannelInfo> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Channel> Channels => channels_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoteChannelInfo()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoteChannelInfo(RemoteChannelInfo other)
				: this()
			{
				channels_ = other.channels_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoteChannelInfo Clone()
			{
				return new RemoteChannelInfo(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as RemoteChannelInfo);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(RemoteChannelInfo other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!channels_.Equals(other.channels_))
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
				num ^= channels_.GetHashCode();
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
				channels_.WriteTo(output, _repeated_channels_codec);
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
				num += channels_.CalculateSize(_repeated_channels_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(RemoteChannelInfo other)
			{
				if (other != null)
				{
					channels_.Add(other.channels_);
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
						channels_.AddEntriesFrom(input, _repeated_channels_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TokenMetadata : IMessage<TokenMetadata>, IMessage, IEquatable<TokenMetadata>, IDeepCloneable<TokenMetadata>
		{
			private static readonly MessageParser<TokenMetadata> _parser = new MessageParser<TokenMetadata>(() => new TokenMetadata());

			private UnknownFieldSet _unknownFields;

			public const int AccessFieldNumber = 1;

			private string access_ = "";

			public const int ExpiresAtFieldNumber = 2;

			private ulong expiresAt_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TokenMetadata> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Access
			{
				get
				{
					return access_;
				}
				set
				{
					access_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong ExpiresAt
			{
				get
				{
					return expiresAt_;
				}
				set
				{
					expiresAt_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenMetadata()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenMetadata(TokenMetadata other)
				: this()
			{
				access_ = other.access_;
				expiresAt_ = other.expiresAt_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenMetadata Clone()
			{
				return new TokenMetadata(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TokenMetadata);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TokenMetadata other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Access != other.Access)
				{
					return false;
				}
				if (ExpiresAt != other.ExpiresAt)
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
				if (Access.Length != 0)
				{
					num ^= Access.GetHashCode();
				}
				if (ExpiresAt != 0L)
				{
					num ^= ExpiresAt.GetHashCode();
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
				if (Access.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Access);
				}
				if (ExpiresAt != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(ExpiresAt);
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
				if (Access.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Access);
				}
				if (ExpiresAt != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(ExpiresAt);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TokenMetadata other)
			{
				if (other != null)
				{
					if (other.Access.Length != 0)
					{
						Access = other.Access;
					}
					if (other.ExpiresAt != 0L)
					{
						ExpiresAt = other.ExpiresAt;
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
						Access = input.ReadString();
						break;
					case 16u:
						ExpiresAt = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class UpdateWebToken : IMessage<UpdateWebToken>, IMessage, IEquatable<UpdateWebToken>, IDeepCloneable<UpdateWebToken>
		{
			private static readonly MessageParser<UpdateWebToken> _parser = new MessageParser<UpdateWebToken>(() => new UpdateWebToken());

			private UnknownFieldSet _unknownFields;

			public const int TokenFieldNumber = 1;

			private TokenMetadata token_;

			public const int PubnubTokenFieldNumber = 2;

			private string pubnubToken_ = "";

			public const int ActivationKeyFieldNumber = 3;

			private static readonly string ActivationKeyDefaultValue = "";

			private string activationKey_;

			public const int ChannelInfoFieldNumber = 4;

			private RemoteChannelInfo channelInfo_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<UpdateWebToken> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TokenMetadata Token
			{
				get
				{
					return token_;
				}
				set
				{
					token_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PubnubToken
			{
				get
				{
					return pubnubToken_;
				}
				set
				{
					pubnubToken_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ActivationKey
			{
				get
				{
					return activationKey_ ?? ActivationKeyDefaultValue;
				}
				set
				{
					activationKey_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasActivationKey => activationKey_ != null;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoteChannelInfo ChannelInfo
			{
				get
				{
					return channelInfo_;
				}
				set
				{
					channelInfo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateWebToken()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateWebToken(UpdateWebToken other)
				: this()
			{
				token_ = ((other.token_ != null) ? other.token_.Clone() : null);
				pubnubToken_ = other.pubnubToken_;
				activationKey_ = other.activationKey_;
				channelInfo_ = ((other.channelInfo_ != null) ? other.channelInfo_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateWebToken Clone()
			{
				return new UpdateWebToken(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearActivationKey()
			{
				activationKey_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as UpdateWebToken);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(UpdateWebToken other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Token, other.Token))
				{
					return false;
				}
				if (PubnubToken != other.PubnubToken)
				{
					return false;
				}
				if (ActivationKey != other.ActivationKey)
				{
					return false;
				}
				if (!object.Equals(ChannelInfo, other.ChannelInfo))
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
				if (token_ != null)
				{
					num ^= Token.GetHashCode();
				}
				if (PubnubToken.Length != 0)
				{
					num ^= PubnubToken.GetHashCode();
				}
				if (HasActivationKey)
				{
					num ^= ActivationKey.GetHashCode();
				}
				if (channelInfo_ != null)
				{
					num ^= ChannelInfo.GetHashCode();
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
				if (token_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Token);
				}
				if (PubnubToken.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(PubnubToken);
				}
				if (HasActivationKey)
				{
					output.WriteRawTag(26);
					output.WriteString(ActivationKey);
				}
				if (channelInfo_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(ChannelInfo);
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
				if (token_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Token);
				}
				if (PubnubToken.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PubnubToken);
				}
				if (HasActivationKey)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ActivationKey);
				}
				if (channelInfo_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ChannelInfo);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(UpdateWebToken other)
			{
				if (other == null)
				{
					return;
				}
				if (other.token_ != null)
				{
					if (token_ == null)
					{
						Token = new TokenMetadata();
					}
					Token.MergeFrom(other.Token);
				}
				if (other.PubnubToken.Length != 0)
				{
					PubnubToken = other.PubnubToken;
				}
				if (other.HasActivationKey)
				{
					ActivationKey = other.ActivationKey;
				}
				if (other.channelInfo_ != null)
				{
					if (channelInfo_ == null)
					{
						ChannelInfo = new RemoteChannelInfo();
					}
					ChannelInfo.MergeFrom(other.ChannelInfo);
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
						if (token_ == null)
						{
							Token = new TokenMetadata();
						}
						input.ReadMessage(Token);
						break;
					case 18u:
						PubnubToken = input.ReadString();
						break;
					case 26u:
						ActivationKey = input.ReadString();
						break;
					case 34u:
						if (channelInfo_ == null)
						{
							ChannelInfo = new RemoteChannelInfo();
						}
						input.ReadMessage(ChannelInfo);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<RequestEnvelope> _parser = new MessageParser<RequestEnvelope>(() => new RequestEnvelope());

	private UnknownFieldSet _unknownFields;

	public const int HeaderFieldNumber = 1;

	private Types.Header header_;

	public const int StartFieldNumber = 2;

	public const int ChangeShowDirectoryFieldNumber = 3;

	public const int AddFieldNumber = 4;

	public const int DuplicateFieldNumber = 5;

	public const int ApplyFieldNumber = 6;

	public const int RemoveFieldNumber = 7;

	public const int TriggerFieldNumber = 8;

	public const int PingFieldNumber = 9;

	public const int UpdateWorkspacesFieldNumber = 10;

	public const int PauseSyncFieldNumber = 12;

	public const int ResumeSyncFieldNumber = 13;

	public const int UpdatePrefsFieldNumber = 14;

	public const int UpdateSmartPlaylistsFieldNumber = 15;

	public const int AddProContentReferenceFieldNumber = 16;

	public const int MarkAsCloudFieldNumber = 17;

	public const int MarkAsLocalFieldNumber = 18;

	public const int RemoveContainerFieldNumber = 19;

	public const int UpdateWebTokenFieldNumber = 20;

	public const int ImportUnmanagedMediaFieldNumber = 21;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RequestEnvelope> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperWorkspaceReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Header Header
	{
		get
		{
			return header_;
		}
		set
		{
			header_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Start Start
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Start)
			{
				return null;
			}
			return (Types.Start)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Start : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeShowDirectory ChangeShowDirectory
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ChangeShowDirectory)
			{
				return null;
			}
			return (ChangeShowDirectory)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ChangeShowDirectory : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference Add
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Add)
			{
				return null;
			}
			return (AddMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Add : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference Duplicate
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Duplicate)
			{
				return null;
			}
			return (DuplicateMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Duplicate : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplyTransformation Apply
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Apply)
			{
				return null;
			}
			return (ApplyTransformation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Apply : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveMediaReferences Remove
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Remove)
			{
				return null;
			}
			return (RemoveMediaReferences)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Remove : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerMediaReference Trigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Trigger)
			{
				return null;
			}
			return (TriggerMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Trigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Ping Ping
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Ping)
			{
				return null;
			}
			return (Ping)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Ping : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateWorkspaces UpdateWorkspaces
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdateWorkspaces)
			{
				return null;
			}
			return (UpdateWorkspaces)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdateWorkspaces : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseSync PauseSync
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PauseSync)
			{
				return null;
			}
			return (PauseSync)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PauseSync : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResumeSync ResumeSync
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ResumeSync)
			{
				return null;
			}
			return (ResumeSync)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ResumeSync : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdatePrefs UpdatePrefs
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdatePrefs)
			{
				return null;
			}
			return (UpdatePrefs)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdatePrefs : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateSmartPlaylists UpdateSmartPlaylists
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdateSmartPlaylists)
			{
				return null;
			}
			return (UpdateSmartPlaylists)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdateSmartPlaylists : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddProContentReference AddProContentReference
	{
		get
		{
			if (requestCase_ != RequestOneofCase.AddProContentReference)
			{
				return null;
			}
			return (AddProContentReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.AddProContentReference : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MarkWorkspaceAsCloud MarkAsCloud
	{
		get
		{
			if (requestCase_ != RequestOneofCase.MarkAsCloud)
			{
				return null;
			}
			return (MarkWorkspaceAsCloud)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.MarkAsCloud : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MarkWorkspaceAsLocal MarkAsLocal
	{
		get
		{
			if (requestCase_ != RequestOneofCase.MarkAsLocal)
			{
				return null;
			}
			return (MarkWorkspaceAsLocal)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.MarkAsLocal : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveContainer RemoveContainer
	{
		get
		{
			if (requestCase_ != RequestOneofCase.RemoveContainer)
			{
				return null;
			}
			return (RemoveContainer)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.RemoveContainer : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UpdateWebToken UpdateWebToken
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdateWebToken)
			{
				return null;
			}
			return (Types.UpdateWebToken)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdateWebToken : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ImportUnmanagedMedia ImportUnmanagedMedia
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ImportUnmanagedMedia)
			{
				return null;
			}
			return (ImportUnmanagedMedia)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ImportUnmanagedMedia : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestEnvelope()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestEnvelope(RequestEnvelope other)
		: this()
	{
		header_ = ((other.header_ != null) ? other.header_.Clone() : null);
		switch (other.RequestCase)
		{
		case RequestOneofCase.Start:
			Start = other.Start.Clone();
			break;
		case RequestOneofCase.ChangeShowDirectory:
			ChangeShowDirectory = other.ChangeShowDirectory.Clone();
			break;
		case RequestOneofCase.Add:
			Add = other.Add.Clone();
			break;
		case RequestOneofCase.Duplicate:
			Duplicate = other.Duplicate.Clone();
			break;
		case RequestOneofCase.Apply:
			Apply = other.Apply.Clone();
			break;
		case RequestOneofCase.Remove:
			Remove = other.Remove.Clone();
			break;
		case RequestOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		case RequestOneofCase.Ping:
			Ping = other.Ping.Clone();
			break;
		case RequestOneofCase.UpdateWorkspaces:
			UpdateWorkspaces = other.UpdateWorkspaces.Clone();
			break;
		case RequestOneofCase.PauseSync:
			PauseSync = other.PauseSync.Clone();
			break;
		case RequestOneofCase.ResumeSync:
			ResumeSync = other.ResumeSync.Clone();
			break;
		case RequestOneofCase.UpdatePrefs:
			UpdatePrefs = other.UpdatePrefs.Clone();
			break;
		case RequestOneofCase.UpdateSmartPlaylists:
			UpdateSmartPlaylists = other.UpdateSmartPlaylists.Clone();
			break;
		case RequestOneofCase.AddProContentReference:
			AddProContentReference = other.AddProContentReference.Clone();
			break;
		case RequestOneofCase.MarkAsCloud:
			MarkAsCloud = other.MarkAsCloud.Clone();
			break;
		case RequestOneofCase.MarkAsLocal:
			MarkAsLocal = other.MarkAsLocal.Clone();
			break;
		case RequestOneofCase.RemoveContainer:
			RemoveContainer = other.RemoveContainer.Clone();
			break;
		case RequestOneofCase.UpdateWebToken:
			UpdateWebToken = other.UpdateWebToken.Clone();
			break;
		case RequestOneofCase.ImportUnmanagedMedia:
			ImportUnmanagedMedia = other.ImportUnmanagedMedia.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestEnvelope Clone()
	{
		return new RequestEnvelope(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RequestEnvelope);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RequestEnvelope other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Header, other.Header))
		{
			return false;
		}
		if (!object.Equals(Start, other.Start))
		{
			return false;
		}
		if (!object.Equals(ChangeShowDirectory, other.ChangeShowDirectory))
		{
			return false;
		}
		if (!object.Equals(Add, other.Add))
		{
			return false;
		}
		if (!object.Equals(Duplicate, other.Duplicate))
		{
			return false;
		}
		if (!object.Equals(Apply, other.Apply))
		{
			return false;
		}
		if (!object.Equals(Remove, other.Remove))
		{
			return false;
		}
		if (!object.Equals(Trigger, other.Trigger))
		{
			return false;
		}
		if (!object.Equals(Ping, other.Ping))
		{
			return false;
		}
		if (!object.Equals(UpdateWorkspaces, other.UpdateWorkspaces))
		{
			return false;
		}
		if (!object.Equals(PauseSync, other.PauseSync))
		{
			return false;
		}
		if (!object.Equals(ResumeSync, other.ResumeSync))
		{
			return false;
		}
		if (!object.Equals(UpdatePrefs, other.UpdatePrefs))
		{
			return false;
		}
		if (!object.Equals(UpdateSmartPlaylists, other.UpdateSmartPlaylists))
		{
			return false;
		}
		if (!object.Equals(AddProContentReference, other.AddProContentReference))
		{
			return false;
		}
		if (!object.Equals(MarkAsCloud, other.MarkAsCloud))
		{
			return false;
		}
		if (!object.Equals(MarkAsLocal, other.MarkAsLocal))
		{
			return false;
		}
		if (!object.Equals(RemoveContainer, other.RemoveContainer))
		{
			return false;
		}
		if (!object.Equals(UpdateWebToken, other.UpdateWebToken))
		{
			return false;
		}
		if (!object.Equals(ImportUnmanagedMedia, other.ImportUnmanagedMedia))
		{
			return false;
		}
		if (RequestCase != other.RequestCase)
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
		if (header_ != null)
		{
			num ^= Header.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Start)
		{
			num ^= Start.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			num ^= ChangeShowDirectory.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Add)
		{
			num ^= Add.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Duplicate)
		{
			num ^= Duplicate.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Apply)
		{
			num ^= Apply.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Remove)
		{
			num ^= Remove.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num ^= Trigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Ping)
		{
			num ^= Ping.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
		{
			num ^= UpdateWorkspaces.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PauseSync)
		{
			num ^= PauseSync.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ResumeSync)
		{
			num ^= ResumeSync.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdatePrefs)
		{
			num ^= UpdatePrefs.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
		{
			num ^= UpdateSmartPlaylists.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.AddProContentReference)
		{
			num ^= AddProContentReference.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.MarkAsCloud)
		{
			num ^= MarkAsCloud.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.MarkAsLocal)
		{
			num ^= MarkAsLocal.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.RemoveContainer)
		{
			num ^= RemoveContainer.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdateWebToken)
		{
			num ^= UpdateWebToken.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
		{
			num ^= ImportUnmanagedMedia.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (header_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Header);
		}
		if (requestCase_ == RequestOneofCase.Start)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Start);
		}
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ChangeShowDirectory);
		}
		if (requestCase_ == RequestOneofCase.Add)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Add);
		}
		if (requestCase_ == RequestOneofCase.Duplicate)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Duplicate);
		}
		if (requestCase_ == RequestOneofCase.Apply)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Apply);
		}
		if (requestCase_ == RequestOneofCase.Remove)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Remove);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Trigger);
		}
		if (requestCase_ == RequestOneofCase.Ping)
		{
			output.WriteRawTag(74);
			output.WriteMessage(Ping);
		}
		if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
		{
			output.WriteRawTag(82);
			output.WriteMessage(UpdateWorkspaces);
		}
		if (requestCase_ == RequestOneofCase.PauseSync)
		{
			output.WriteRawTag(98);
			output.WriteMessage(PauseSync);
		}
		if (requestCase_ == RequestOneofCase.ResumeSync)
		{
			output.WriteRawTag(106);
			output.WriteMessage(ResumeSync);
		}
		if (requestCase_ == RequestOneofCase.UpdatePrefs)
		{
			output.WriteRawTag(114);
			output.WriteMessage(UpdatePrefs);
		}
		if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
		{
			output.WriteRawTag(122);
			output.WriteMessage(UpdateSmartPlaylists);
		}
		if (requestCase_ == RequestOneofCase.AddProContentReference)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(AddProContentReference);
		}
		if (requestCase_ == RequestOneofCase.MarkAsCloud)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(MarkAsCloud);
		}
		if (requestCase_ == RequestOneofCase.MarkAsLocal)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(MarkAsLocal);
		}
		if (requestCase_ == RequestOneofCase.RemoveContainer)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(RemoveContainer);
		}
		if (requestCase_ == RequestOneofCase.UpdateWebToken)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(UpdateWebToken);
		}
		if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(ImportUnmanagedMedia);
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
		if (header_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Header);
		}
		if (requestCase_ == RequestOneofCase.Start)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Start);
		}
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChangeShowDirectory);
		}
		if (requestCase_ == RequestOneofCase.Add)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Add);
		}
		if (requestCase_ == RequestOneofCase.Duplicate)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Duplicate);
		}
		if (requestCase_ == RequestOneofCase.Apply)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Apply);
		}
		if (requestCase_ == RequestOneofCase.Remove)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Remove);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
		}
		if (requestCase_ == RequestOneofCase.Ping)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Ping);
		}
		if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdateWorkspaces);
		}
		if (requestCase_ == RequestOneofCase.PauseSync)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PauseSync);
		}
		if (requestCase_ == RequestOneofCase.ResumeSync)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ResumeSync);
		}
		if (requestCase_ == RequestOneofCase.UpdatePrefs)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdatePrefs);
		}
		if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdateSmartPlaylists);
		}
		if (requestCase_ == RequestOneofCase.AddProContentReference)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AddProContentReference);
		}
		if (requestCase_ == RequestOneofCase.MarkAsCloud)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MarkAsCloud);
		}
		if (requestCase_ == RequestOneofCase.MarkAsLocal)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MarkAsLocal);
		}
		if (requestCase_ == RequestOneofCase.RemoveContainer)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(RemoveContainer);
		}
		if (requestCase_ == RequestOneofCase.UpdateWebToken)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UpdateWebToken);
		}
		if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ImportUnmanagedMedia);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RequestEnvelope other)
	{
		if (other == null)
		{
			return;
		}
		if (other.header_ != null)
		{
			if (header_ == null)
			{
				Header = new Types.Header();
			}
			Header.MergeFrom(other.Header);
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Start:
			if (Start == null)
			{
				Start = new Types.Start();
			}
			Start.MergeFrom(other.Start);
			break;
		case RequestOneofCase.ChangeShowDirectory:
			if (ChangeShowDirectory == null)
			{
				ChangeShowDirectory = new ChangeShowDirectory();
			}
			ChangeShowDirectory.MergeFrom(other.ChangeShowDirectory);
			break;
		case RequestOneofCase.Add:
			if (Add == null)
			{
				Add = new AddMediaReference();
			}
			Add.MergeFrom(other.Add);
			break;
		case RequestOneofCase.Duplicate:
			if (Duplicate == null)
			{
				Duplicate = new DuplicateMediaReference();
			}
			Duplicate.MergeFrom(other.Duplicate);
			break;
		case RequestOneofCase.Apply:
			if (Apply == null)
			{
				Apply = new ApplyTransformation();
			}
			Apply.MergeFrom(other.Apply);
			break;
		case RequestOneofCase.Remove:
			if (Remove == null)
			{
				Remove = new RemoveMediaReferences();
			}
			Remove.MergeFrom(other.Remove);
			break;
		case RequestOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new TriggerMediaReference();
			}
			Trigger.MergeFrom(other.Trigger);
			break;
		case RequestOneofCase.Ping:
			if (Ping == null)
			{
				Ping = new Ping();
			}
			Ping.MergeFrom(other.Ping);
			break;
		case RequestOneofCase.UpdateWorkspaces:
			if (UpdateWorkspaces == null)
			{
				UpdateWorkspaces = new UpdateWorkspaces();
			}
			UpdateWorkspaces.MergeFrom(other.UpdateWorkspaces);
			break;
		case RequestOneofCase.PauseSync:
			if (PauseSync == null)
			{
				PauseSync = new PauseSync();
			}
			PauseSync.MergeFrom(other.PauseSync);
			break;
		case RequestOneofCase.ResumeSync:
			if (ResumeSync == null)
			{
				ResumeSync = new ResumeSync();
			}
			ResumeSync.MergeFrom(other.ResumeSync);
			break;
		case RequestOneofCase.UpdatePrefs:
			if (UpdatePrefs == null)
			{
				UpdatePrefs = new UpdatePrefs();
			}
			UpdatePrefs.MergeFrom(other.UpdatePrefs);
			break;
		case RequestOneofCase.UpdateSmartPlaylists:
			if (UpdateSmartPlaylists == null)
			{
				UpdateSmartPlaylists = new UpdateSmartPlaylists();
			}
			UpdateSmartPlaylists.MergeFrom(other.UpdateSmartPlaylists);
			break;
		case RequestOneofCase.AddProContentReference:
			if (AddProContentReference == null)
			{
				AddProContentReference = new AddProContentReference();
			}
			AddProContentReference.MergeFrom(other.AddProContentReference);
			break;
		case RequestOneofCase.MarkAsCloud:
			if (MarkAsCloud == null)
			{
				MarkAsCloud = new MarkWorkspaceAsCloud();
			}
			MarkAsCloud.MergeFrom(other.MarkAsCloud);
			break;
		case RequestOneofCase.MarkAsLocal:
			if (MarkAsLocal == null)
			{
				MarkAsLocal = new MarkWorkspaceAsLocal();
			}
			MarkAsLocal.MergeFrom(other.MarkAsLocal);
			break;
		case RequestOneofCase.RemoveContainer:
			if (RemoveContainer == null)
			{
				RemoveContainer = new RemoveContainer();
			}
			RemoveContainer.MergeFrom(other.RemoveContainer);
			break;
		case RequestOneofCase.UpdateWebToken:
			if (UpdateWebToken == null)
			{
				UpdateWebToken = new Types.UpdateWebToken();
			}
			UpdateWebToken.MergeFrom(other.UpdateWebToken);
			break;
		case RequestOneofCase.ImportUnmanagedMedia:
			if (ImportUnmanagedMedia == null)
			{
				ImportUnmanagedMedia = new ImportUnmanagedMedia();
			}
			ImportUnmanagedMedia.MergeFrom(other.ImportUnmanagedMedia);
			break;
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
				if (header_ == null)
				{
					Header = new Types.Header();
				}
				input.ReadMessage(Header);
				break;
			case 18u:
			{
				Types.Start start = new Types.Start();
				if (requestCase_ == RequestOneofCase.Start)
				{
					start.MergeFrom(Start);
				}
				input.ReadMessage(start);
				Start = start;
				break;
			}
			case 26u:
			{
				ChangeShowDirectory changeShowDirectory = new ChangeShowDirectory();
				if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
				{
					changeShowDirectory.MergeFrom(ChangeShowDirectory);
				}
				input.ReadMessage(changeShowDirectory);
				ChangeShowDirectory = changeShowDirectory;
				break;
			}
			case 34u:
			{
				AddMediaReference addMediaReference = new AddMediaReference();
				if (requestCase_ == RequestOneofCase.Add)
				{
					addMediaReference.MergeFrom(Add);
				}
				input.ReadMessage(addMediaReference);
				Add = addMediaReference;
				break;
			}
			case 42u:
			{
				DuplicateMediaReference duplicateMediaReference = new DuplicateMediaReference();
				if (requestCase_ == RequestOneofCase.Duplicate)
				{
					duplicateMediaReference.MergeFrom(Duplicate);
				}
				input.ReadMessage(duplicateMediaReference);
				Duplicate = duplicateMediaReference;
				break;
			}
			case 50u:
			{
				ApplyTransformation applyTransformation = new ApplyTransformation();
				if (requestCase_ == RequestOneofCase.Apply)
				{
					applyTransformation.MergeFrom(Apply);
				}
				input.ReadMessage(applyTransformation);
				Apply = applyTransformation;
				break;
			}
			case 58u:
			{
				RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
				if (requestCase_ == RequestOneofCase.Remove)
				{
					removeMediaReferences.MergeFrom(Remove);
				}
				input.ReadMessage(removeMediaReferences);
				Remove = removeMediaReferences;
				break;
			}
			case 66u:
			{
				TriggerMediaReference triggerMediaReference = new TriggerMediaReference();
				if (requestCase_ == RequestOneofCase.Trigger)
				{
					triggerMediaReference.MergeFrom(Trigger);
				}
				input.ReadMessage(triggerMediaReference);
				Trigger = triggerMediaReference;
				break;
			}
			case 74u:
			{
				Ping ping = new Ping();
				if (requestCase_ == RequestOneofCase.Ping)
				{
					ping.MergeFrom(Ping);
				}
				input.ReadMessage(ping);
				Ping = ping;
				break;
			}
			case 82u:
			{
				UpdateWorkspaces updateWorkspaces = new UpdateWorkspaces();
				if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
				{
					updateWorkspaces.MergeFrom(UpdateWorkspaces);
				}
				input.ReadMessage(updateWorkspaces);
				UpdateWorkspaces = updateWorkspaces;
				break;
			}
			case 98u:
			{
				PauseSync pauseSync = new PauseSync();
				if (requestCase_ == RequestOneofCase.PauseSync)
				{
					pauseSync.MergeFrom(PauseSync);
				}
				input.ReadMessage(pauseSync);
				PauseSync = pauseSync;
				break;
			}
			case 106u:
			{
				ResumeSync resumeSync = new ResumeSync();
				if (requestCase_ == RequestOneofCase.ResumeSync)
				{
					resumeSync.MergeFrom(ResumeSync);
				}
				input.ReadMessage(resumeSync);
				ResumeSync = resumeSync;
				break;
			}
			case 114u:
			{
				UpdatePrefs updatePrefs = new UpdatePrefs();
				if (requestCase_ == RequestOneofCase.UpdatePrefs)
				{
					updatePrefs.MergeFrom(UpdatePrefs);
				}
				input.ReadMessage(updatePrefs);
				UpdatePrefs = updatePrefs;
				break;
			}
			case 122u:
			{
				UpdateSmartPlaylists updateSmartPlaylists = new UpdateSmartPlaylists();
				if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
				{
					updateSmartPlaylists.MergeFrom(UpdateSmartPlaylists);
				}
				input.ReadMessage(updateSmartPlaylists);
				UpdateSmartPlaylists = updateSmartPlaylists;
				break;
			}
			case 130u:
			{
				AddProContentReference addProContentReference = new AddProContentReference();
				if (requestCase_ == RequestOneofCase.AddProContentReference)
				{
					addProContentReference.MergeFrom(AddProContentReference);
				}
				input.ReadMessage(addProContentReference);
				AddProContentReference = addProContentReference;
				break;
			}
			case 138u:
			{
				MarkWorkspaceAsCloud markWorkspaceAsCloud = new MarkWorkspaceAsCloud();
				if (requestCase_ == RequestOneofCase.MarkAsCloud)
				{
					markWorkspaceAsCloud.MergeFrom(MarkAsCloud);
				}
				input.ReadMessage(markWorkspaceAsCloud);
				MarkAsCloud = markWorkspaceAsCloud;
				break;
			}
			case 146u:
			{
				MarkWorkspaceAsLocal markWorkspaceAsLocal = new MarkWorkspaceAsLocal();
				if (requestCase_ == RequestOneofCase.MarkAsLocal)
				{
					markWorkspaceAsLocal.MergeFrom(MarkAsLocal);
				}
				input.ReadMessage(markWorkspaceAsLocal);
				MarkAsLocal = markWorkspaceAsLocal;
				break;
			}
			case 154u:
			{
				RemoveContainer removeContainer = new RemoveContainer();
				if (requestCase_ == RequestOneofCase.RemoveContainer)
				{
					removeContainer.MergeFrom(RemoveContainer);
				}
				input.ReadMessage(removeContainer);
				RemoveContainer = removeContainer;
				break;
			}
			case 162u:
			{
				Types.UpdateWebToken updateWebToken = new Types.UpdateWebToken();
				if (requestCase_ == RequestOneofCase.UpdateWebToken)
				{
					updateWebToken.MergeFrom(UpdateWebToken);
				}
				input.ReadMessage(updateWebToken);
				UpdateWebToken = updateWebToken;
				break;
			}
			case 170u:
			{
				ImportUnmanagedMedia importUnmanagedMedia = new ImportUnmanagedMedia();
				if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
				{
					importUnmanagedMedia.MergeFrom(ImportUnmanagedMedia);
				}
				input.ReadMessage(importUnmanagedMedia);
				ImportUnmanagedMedia = importUnmanagedMedia;
				break;
			}
			}
		}
	}
}
