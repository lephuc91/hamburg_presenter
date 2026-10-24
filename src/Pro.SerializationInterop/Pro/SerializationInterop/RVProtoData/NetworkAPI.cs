using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NetworkAPI : IMessage<NetworkAPI>, IMessage, IEquatable<NetworkAPI>, IDeepCloneable<NetworkAPI>
{
	public enum CommandOneofCase
	{
		None = 0,
		Action = 1,
		ServerState = 2,
		GroupChange = 5,
		GroupResponse = 6
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LinkStatus : IMessage<LinkStatus>, IMessage, IEquatable<LinkStatus>, IDeepCloneable<LinkStatus>
		{
			private static readonly MessageParser<LinkStatus> _parser = new MessageParser<LinkStatus>(() => new LinkStatus());

			private UnknownFieldSet _unknownFields;

			public const int PlatformFieldNumber = 1;

			private ApplicationInfo.Types.Platform platform_;

			public const int OsVersionFieldNumber = 2;

			private string osVersion_ = "";

			public const int VersionFieldNumber = 3;

			private string version_ = "";

			public const int DescriptionFieldNumber = 4;

			private string description_ = "";

			public const int GroupInfoFieldNumber = 5;

			private Group groupInfo_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LinkStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[0];

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
			public Group GroupInfo
			{
				get
				{
					return groupInfo_;
				}
				set
				{
					groupInfo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LinkStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LinkStatus(LinkStatus other)
				: this()
			{
				platform_ = other.platform_;
				osVersion_ = other.osVersion_;
				version_ = other.version_;
				description_ = other.description_;
				groupInfo_ = ((other.groupInfo_ != null) ? other.groupInfo_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LinkStatus Clone()
			{
				return new LinkStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LinkStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LinkStatus other)
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
				if (!object.Equals(GroupInfo, other.GroupInfo))
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
				if (groupInfo_ != null)
				{
					num ^= GroupInfo.GetHashCode();
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
				if (groupInfo_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(GroupInfo);
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
				if (groupInfo_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupInfo);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(LinkStatus other)
			{
				if (other == null)
				{
					return;
				}
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
				if (other.groupInfo_ != null)
				{
					if (groupInfo_ == null)
					{
						GroupInfo = new Group();
					}
					GroupInfo.MergeFrom(other.GroupInfo);
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
					case 42u:
						if (groupInfo_ == null)
						{
							GroupInfo = new Group();
						}
						input.ReadMessage(GroupInfo);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Group : IMessage<Group>, IMessage, IEquatable<Group>, IDeepCloneable<Group>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Member : IMessage<Member>, IMessage, IEquatable<Member>, IDeepCloneable<Member>
				{
					private static readonly MessageParser<Member> _parser = new MessageParser<Member>(() => new Member());

					private UnknownFieldSet _unknownFields;

					public const int IpAddressFieldNumber = 1;

					private string ipAddress_ = "";

					public const int PortFieldNumber = 2;

					private int port_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Member> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Group.Descriptor.NestedTypes[0];

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
					public Member()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Member(Member other)
						: this()
					{
						ipAddress_ = other.ipAddress_;
						port_ = other.port_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Member Clone()
					{
						return new Member(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Member);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Member other)
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Member other)
					{
						if (other != null)
						{
							if (other.IpAddress.Length != 0)
							{
								IpAddress = other.IpAddress;
							}
							if (other.Port != 0)
							{
								Port = other.Port;
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
								IpAddress = input.ReadString();
								break;
							case 16u:
								Port = input.ReadInt32();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Group> _parser = new MessageParser<Group>(() => new Group());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int MembersFieldNumber = 2;

			private static readonly FieldCodec<Types.Member> _repeated_members_codec = FieldCodec.ForMessage(18u, Types.Member.Parser);

			private readonly RepeatedField<Types.Member> members_ = new RepeatedField<Types.Member>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Group> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[1];

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
			public RepeatedField<Types.Member> Members => members_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group(Group other)
				: this()
			{
				name_ = other.name_;
				members_ = other.members_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group Clone()
			{
				return new Group(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Group);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Group other)
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
				if (!members_.Equals(other.members_))
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
				num ^= members_.GetHashCode();
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
				members_.WriteTo(output, _repeated_members_codec);
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
				num += members_.CalculateSize(_repeated_members_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Group other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					members_.Add(other.members_);
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
						members_.AddEntriesFrom(input, _repeated_members_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupChange : IMessage<GroupChange>, IMessage, IEquatable<GroupChange>, IDeepCloneable<GroupChange>
		{
			public enum ChangeOneofCase
			{
				None,
				Invite,
				Join,
				Kick,
				Status
			}

			private static readonly MessageParser<GroupChange> _parser = new MessageParser<GroupChange>(() => new GroupChange());

			private UnknownFieldSet _unknownFields;

			public const int InviteFieldNumber = 1;

			public const int JoinFieldNumber = 2;

			public const int KickFieldNumber = 3;

			public const int StatusFieldNumber = 4;

			private object change_;

			private ChangeOneofCase changeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupChange> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupInvite Invite
			{
				get
				{
					if (changeCase_ != ChangeOneofCase.Invite)
					{
						return null;
					}
					return (GroupInvite)change_;
				}
				set
				{
					change_ = value;
					changeCase_ = ((value != null) ? ChangeOneofCase.Invite : ChangeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupJoin Join
			{
				get
				{
					if (changeCase_ != ChangeOneofCase.Join)
					{
						return null;
					}
					return (GroupJoin)change_;
				}
				set
				{
					change_ = value;
					changeCase_ = ((value != null) ? ChangeOneofCase.Join : ChangeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupKick Kick
			{
				get
				{
					if (changeCase_ != ChangeOneofCase.Kick)
					{
						return null;
					}
					return (GroupKick)change_;
				}
				set
				{
					change_ = value;
					changeCase_ = ((value != null) ? ChangeOneofCase.Kick : ChangeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupStatus Status
			{
				get
				{
					if (changeCase_ != ChangeOneofCase.Status)
					{
						return null;
					}
					return (GroupStatus)change_;
				}
				set
				{
					change_ = value;
					changeCase_ = ((value != null) ? ChangeOneofCase.Status : ChangeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChangeOneofCase ChangeCase => changeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupChange()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupChange(GroupChange other)
				: this()
			{
				switch (other.ChangeCase)
				{
				case ChangeOneofCase.Invite:
					Invite = other.Invite.Clone();
					break;
				case ChangeOneofCase.Join:
					Join = other.Join.Clone();
					break;
				case ChangeOneofCase.Kick:
					Kick = other.Kick.Clone();
					break;
				case ChangeOneofCase.Status:
					Status = other.Status.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupChange Clone()
			{
				return new GroupChange(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearChange()
			{
				changeCase_ = ChangeOneofCase.None;
				change_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupChange);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupChange other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Invite, other.Invite))
				{
					return false;
				}
				if (!object.Equals(Join, other.Join))
				{
					return false;
				}
				if (!object.Equals(Kick, other.Kick))
				{
					return false;
				}
				if (!object.Equals(Status, other.Status))
				{
					return false;
				}
				if (ChangeCase != other.ChangeCase)
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
				if (changeCase_ == ChangeOneofCase.Invite)
				{
					num ^= Invite.GetHashCode();
				}
				if (changeCase_ == ChangeOneofCase.Join)
				{
					num ^= Join.GetHashCode();
				}
				if (changeCase_ == ChangeOneofCase.Kick)
				{
					num ^= Kick.GetHashCode();
				}
				if (changeCase_ == ChangeOneofCase.Status)
				{
					num ^= Status.GetHashCode();
				}
				num ^= (int)changeCase_;
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
				if (changeCase_ == ChangeOneofCase.Invite)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Invite);
				}
				if (changeCase_ == ChangeOneofCase.Join)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Join);
				}
				if (changeCase_ == ChangeOneofCase.Kick)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Kick);
				}
				if (changeCase_ == ChangeOneofCase.Status)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Status);
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
				if (changeCase_ == ChangeOneofCase.Invite)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Invite);
				}
				if (changeCase_ == ChangeOneofCase.Join)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Join);
				}
				if (changeCase_ == ChangeOneofCase.Kick)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Kick);
				}
				if (changeCase_ == ChangeOneofCase.Status)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Status);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GroupChange other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ChangeCase)
				{
				case ChangeOneofCase.Invite:
					if (Invite == null)
					{
						Invite = new GroupInvite();
					}
					Invite.MergeFrom(other.Invite);
					break;
				case ChangeOneofCase.Join:
					if (Join == null)
					{
						Join = new GroupJoin();
					}
					Join.MergeFrom(other.Join);
					break;
				case ChangeOneofCase.Kick:
					if (Kick == null)
					{
						Kick = new GroupKick();
					}
					Kick.MergeFrom(other.Kick);
					break;
				case ChangeOneofCase.Status:
					if (Status == null)
					{
						Status = new GroupStatus();
					}
					Status.MergeFrom(other.Status);
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
					{
						GroupInvite groupInvite = new GroupInvite();
						if (changeCase_ == ChangeOneofCase.Invite)
						{
							groupInvite.MergeFrom(Invite);
						}
						input.ReadMessage(groupInvite);
						Invite = groupInvite;
						break;
					}
					case 18u:
					{
						GroupJoin groupJoin = new GroupJoin();
						if (changeCase_ == ChangeOneofCase.Join)
						{
							groupJoin.MergeFrom(Join);
						}
						input.ReadMessage(groupJoin);
						Join = groupJoin;
						break;
					}
					case 26u:
					{
						GroupKick groupKick = new GroupKick();
						if (changeCase_ == ChangeOneofCase.Kick)
						{
							groupKick.MergeFrom(Kick);
						}
						input.ReadMessage(groupKick);
						Kick = groupKick;
						break;
					}
					case 34u:
					{
						GroupStatus groupStatus = new GroupStatus();
						if (changeCase_ == ChangeOneofCase.Status)
						{
							groupStatus.MergeFrom(Status);
						}
						input.ReadMessage(groupStatus);
						Status = groupStatus;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupResponse : IMessage<GroupResponse>, IMessage, IEquatable<GroupResponse>, IDeepCloneable<GroupResponse>
		{
			public enum ResponseOneofCase
			{
				None,
				Success,
				Status
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Success : IMessage<Success>, IMessage, IEquatable<Success>, IDeepCloneable<Success>
				{
					private static readonly MessageParser<Success> _parser = new MessageParser<Success>(() => new Success());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Success> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => GroupResponse.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Success()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Success(Success other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Success Clone()
					{
						return new Success(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Success);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Success other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Success other)
					{
						if (other != null)
						{
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
							_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Status : IMessage<Status>, IMessage, IEquatable<Status>, IDeepCloneable<Status>
				{
					private static readonly MessageParser<Status> _parser = new MessageParser<Status>(() => new Status());

					private UnknownFieldSet _unknownFields;

					public const int MemberNameFieldNumber = 1;

					private string memberName_ = "";

					public const int GroupNameFieldNumber = 2;

					private string groupName_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Status> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => GroupResponse.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string MemberName
					{
						get
						{
							return memberName_;
						}
						set
						{
							memberName_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string GroupName
					{
						get
						{
							return groupName_;
						}
						set
						{
							groupName_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Status()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Status(Status other)
						: this()
					{
						memberName_ = other.memberName_;
						groupName_ = other.groupName_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Status Clone()
					{
						return new Status(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Status);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Status other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (MemberName != other.MemberName)
						{
							return false;
						}
						if (GroupName != other.GroupName)
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
						if (MemberName.Length != 0)
						{
							num ^= MemberName.GetHashCode();
						}
						if (GroupName.Length != 0)
						{
							num ^= GroupName.GetHashCode();
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
						if (MemberName.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(MemberName);
						}
						if (GroupName.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(GroupName);
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
						if (MemberName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(MemberName);
						}
						if (GroupName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(GroupName);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Status other)
					{
						if (other != null)
						{
							if (other.MemberName.Length != 0)
							{
								MemberName = other.MemberName;
							}
							if (other.GroupName.Length != 0)
							{
								GroupName = other.GroupName;
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
								MemberName = input.ReadString();
								break;
							case 18u:
								GroupName = input.ReadString();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<GroupResponse> _parser = new MessageParser<GroupResponse>(() => new GroupResponse());

			private UnknownFieldSet _unknownFields;

			public const int SuccessFieldNumber = 1;

			public const int StatusFieldNumber = 2;

			private object response_;

			private ResponseOneofCase responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupResponse> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Success Success
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Success)
					{
						return null;
					}
					return (Types.Success)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Success : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Status Status
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Status)
					{
						return null;
					}
					return (Types.Status)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Status : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResponseOneofCase ResponseCase => responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupResponse()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupResponse(GroupResponse other)
				: this()
			{
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.Success:
					Success = other.Success.Clone();
					break;
				case ResponseOneofCase.Status:
					Status = other.Status.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupResponse Clone()
			{
				return new GroupResponse(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearResponse()
			{
				responseCase_ = ResponseOneofCase.None;
				response_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupResponse);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupResponse other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Success, other.Success))
				{
					return false;
				}
				if (!object.Equals(Status, other.Status))
				{
					return false;
				}
				if (ResponseCase != other.ResponseCase)
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
				if (responseCase_ == ResponseOneofCase.Success)
				{
					num ^= Success.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Status)
				{
					num ^= Status.GetHashCode();
				}
				num ^= (int)responseCase_;
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
				if (responseCase_ == ResponseOneofCase.Success)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Success);
				}
				if (responseCase_ == ResponseOneofCase.Status)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Status);
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
				if (responseCase_ == ResponseOneofCase.Success)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Success);
				}
				if (responseCase_ == ResponseOneofCase.Status)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Status);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GroupResponse other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.Success:
					if (Success == null)
					{
						Success = new Types.Success();
					}
					Success.MergeFrom(other.Success);
					break;
				case ResponseOneofCase.Status:
					if (Status == null)
					{
						Status = new Types.Status();
					}
					Status.MergeFrom(other.Status);
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
					{
						Types.Success success = new Types.Success();
						if (responseCase_ == ResponseOneofCase.Success)
						{
							success.MergeFrom(Success);
						}
						input.ReadMessage(success);
						Success = success;
						break;
					}
					case 18u:
					{
						Types.Status status = new Types.Status();
						if (responseCase_ == ResponseOneofCase.Status)
						{
							status.MergeFrom(Status);
						}
						input.ReadMessage(status);
						Status = status;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupStatus : IMessage<GroupStatus>, IMessage, IEquatable<GroupStatus>, IDeepCloneable<GroupStatus>
		{
			private static readonly MessageParser<GroupStatus> _parser = new MessageParser<GroupStatus>(() => new GroupStatus());

			private UnknownFieldSet _unknownFields;

			public const int MemberFieldNumber = 1;

			private Group.Types.Member member_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group.Types.Member Member
			{
				get
				{
					return member_;
				}
				set
				{
					member_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupStatus(GroupStatus other)
				: this()
			{
				member_ = ((other.member_ != null) ? other.member_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupStatus Clone()
			{
				return new GroupStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupStatus other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Member, other.Member))
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
				if (member_ != null)
				{
					num ^= Member.GetHashCode();
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
				if (member_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Member);
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
				if (member_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Member);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GroupStatus other)
			{
				if (other == null)
				{
					return;
				}
				if (other.member_ != null)
				{
					if (member_ == null)
					{
						Member = new Group.Types.Member();
					}
					Member.MergeFrom(other.Member);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (member_ == null)
					{
						Member = new Group.Types.Member();
					}
					input.ReadMessage(Member);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupInvite : IMessage<GroupInvite>, IMessage, IEquatable<GroupInvite>, IDeepCloneable<GroupInvite>
		{
			private static readonly MessageParser<GroupInvite> _parser = new MessageParser<GroupInvite>(() => new GroupInvite());

			private UnknownFieldSet _unknownFields;

			public const int GroupInfoFieldNumber = 1;

			private Group groupInfo_;

			public const int SecretFieldNumber = 2;

			private string secret_ = "";

			public const int ProspectFieldNumber = 3;

			private Group.Types.Member prospect_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupInvite> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group GroupInfo
			{
				get
				{
					return groupInfo_;
				}
				set
				{
					groupInfo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Secret
			{
				get
				{
					return secret_;
				}
				set
				{
					secret_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group.Types.Member Prospect
			{
				get
				{
					return prospect_;
				}
				set
				{
					prospect_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupInvite()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupInvite(GroupInvite other)
				: this()
			{
				groupInfo_ = ((other.groupInfo_ != null) ? other.groupInfo_.Clone() : null);
				secret_ = other.secret_;
				prospect_ = ((other.prospect_ != null) ? other.prospect_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupInvite Clone()
			{
				return new GroupInvite(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupInvite);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupInvite other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(GroupInfo, other.GroupInfo))
				{
					return false;
				}
				if (Secret != other.Secret)
				{
					return false;
				}
				if (!object.Equals(Prospect, other.Prospect))
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
				if (groupInfo_ != null)
				{
					num ^= GroupInfo.GetHashCode();
				}
				if (Secret.Length != 0)
				{
					num ^= Secret.GetHashCode();
				}
				if (prospect_ != null)
				{
					num ^= Prospect.GetHashCode();
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
				if (groupInfo_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(GroupInfo);
				}
				if (Secret.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Secret);
				}
				if (prospect_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Prospect);
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
				if (groupInfo_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupInfo);
				}
				if (Secret.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Secret);
				}
				if (prospect_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Prospect);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GroupInvite other)
			{
				if (other == null)
				{
					return;
				}
				if (other.groupInfo_ != null)
				{
					if (groupInfo_ == null)
					{
						GroupInfo = new Group();
					}
					GroupInfo.MergeFrom(other.GroupInfo);
				}
				if (other.Secret.Length != 0)
				{
					Secret = other.Secret;
				}
				if (other.prospect_ != null)
				{
					if (prospect_ == null)
					{
						Prospect = new Group.Types.Member();
					}
					Prospect.MergeFrom(other.Prospect);
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
						if (groupInfo_ == null)
						{
							GroupInfo = new Group();
						}
						input.ReadMessage(GroupInfo);
						break;
					case 18u:
						Secret = input.ReadString();
						break;
					case 26u:
						if (prospect_ == null)
						{
							Prospect = new Group.Types.Member();
						}
						input.ReadMessage(Prospect);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupJoin : IMessage<GroupJoin>, IMessage, IEquatable<GroupJoin>, IDeepCloneable<GroupJoin>
		{
			private static readonly MessageParser<GroupJoin> _parser = new MessageParser<GroupJoin>(() => new GroupJoin());

			private UnknownFieldSet _unknownFields;

			public const int SponsorFieldNumber = 1;

			private Group.Types.Member sponsor_;

			public const int ProspectFieldNumber = 2;

			private Group.Types.Member prospect_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupJoin> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group.Types.Member Sponsor
			{
				get
				{
					return sponsor_;
				}
				set
				{
					sponsor_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group.Types.Member Prospect
			{
				get
				{
					return prospect_;
				}
				set
				{
					prospect_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupJoin()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupJoin(GroupJoin other)
				: this()
			{
				sponsor_ = ((other.sponsor_ != null) ? other.sponsor_.Clone() : null);
				prospect_ = ((other.prospect_ != null) ? other.prospect_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupJoin Clone()
			{
				return new GroupJoin(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupJoin);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupJoin other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Sponsor, other.Sponsor))
				{
					return false;
				}
				if (!object.Equals(Prospect, other.Prospect))
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
				if (sponsor_ != null)
				{
					num ^= Sponsor.GetHashCode();
				}
				if (prospect_ != null)
				{
					num ^= Prospect.GetHashCode();
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
				if (sponsor_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Sponsor);
				}
				if (prospect_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Prospect);
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
				if (sponsor_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Sponsor);
				}
				if (prospect_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Prospect);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GroupJoin other)
			{
				if (other == null)
				{
					return;
				}
				if (other.sponsor_ != null)
				{
					if (sponsor_ == null)
					{
						Sponsor = new Group.Types.Member();
					}
					Sponsor.MergeFrom(other.Sponsor);
				}
				if (other.prospect_ != null)
				{
					if (prospect_ == null)
					{
						Prospect = new Group.Types.Member();
					}
					Prospect.MergeFrom(other.Prospect);
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
						if (sponsor_ == null)
						{
							Sponsor = new Group.Types.Member();
						}
						input.ReadMessage(Sponsor);
						break;
					case 18u:
						if (prospect_ == null)
						{
							Prospect = new Group.Types.Member();
						}
						input.ReadMessage(Prospect);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupKick : IMessage<GroupKick>, IMessage, IEquatable<GroupKick>, IDeepCloneable<GroupKick>
		{
			private static readonly MessageParser<GroupKick> _parser = new MessageParser<GroupKick>(() => new GroupKick());

			private UnknownFieldSet _unknownFields;

			public const int MemberFieldNumber = 1;

			private Group.Types.Member member_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupKick> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Group.Types.Member Member
			{
				get
				{
					return member_;
				}
				set
				{
					member_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupKick()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupKick(GroupKick other)
				: this()
			{
				member_ = ((other.member_ != null) ? other.member_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupKick Clone()
			{
				return new GroupKick(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupKick);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupKick other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Member, other.Member))
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
				if (member_ != null)
				{
					num ^= Member.GetHashCode();
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
				if (member_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Member);
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
				if (member_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Member);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GroupKick other)
			{
				if (other == null)
				{
					return;
				}
				if (other.member_ != null)
				{
					if (member_ == null)
					{
						Member = new Group.Types.Member();
					}
					Member.MergeFrom(other.Member);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (member_ == null)
					{
						Member = new Group.Types.Member();
					}
					input.ReadMessage(Member);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ServerState : IMessage<ServerState>, IMessage, IEquatable<ServerState>, IDeepCloneable<ServerState>
		{
			private static readonly MessageParser<ServerState> _parser = new MessageParser<ServerState>(() => new ServerState());

			private UnknownFieldSet _unknownFields;

			public const int LocalIpFieldNumber = 1;

			private string localIp_ = "";

			public const int PublicIpFieldNumber = 2;

			private string publicIp_ = "";

			public const int PortFieldNumber = 3;

			private int port_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ServerState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string LocalIp
			{
				get
				{
					return localIp_;
				}
				set
				{
					localIp_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PublicIp
			{
				get
				{
					return publicIp_;
				}
				set
				{
					publicIp_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public ServerState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ServerState(ServerState other)
				: this()
			{
				localIp_ = other.localIp_;
				publicIp_ = other.publicIp_;
				port_ = other.port_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ServerState Clone()
			{
				return new ServerState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ServerState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ServerState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (LocalIp != other.LocalIp)
				{
					return false;
				}
				if (PublicIp != other.PublicIp)
				{
					return false;
				}
				if (Port != other.Port)
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
				if (LocalIp.Length != 0)
				{
					num ^= LocalIp.GetHashCode();
				}
				if (PublicIp.Length != 0)
				{
					num ^= PublicIp.GetHashCode();
				}
				if (Port != 0)
				{
					num ^= Port.GetHashCode();
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
				if (LocalIp.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(LocalIp);
				}
				if (PublicIp.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(PublicIp);
				}
				if (Port != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Port);
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
				if (LocalIp.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(LocalIp);
				}
				if (PublicIp.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PublicIp);
				}
				if (Port != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Port);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ServerState other)
			{
				if (other != null)
				{
					if (other.LocalIp.Length != 0)
					{
						LocalIp = other.LocalIp;
					}
					if (other.PublicIp.Length != 0)
					{
						PublicIp = other.PublicIp;
					}
					if (other.Port != 0)
					{
						Port = other.Port;
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
						LocalIp = input.ReadString();
						break;
					case 18u:
						PublicIp = input.ReadString();
						break;
					case 24u:
						Port = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Action : IMessage<Action>, IMessage, IEquatable<Action>, IDeepCloneable<Action>
		{
			public enum CommandOneofCase
			{
				None,
				Clear,
				Trigger,
				Transport,
				Prop,
				Timer,
				Message,
				Macro,
				Look,
				Stage,
				Status,
				StatusResponse,
				TwoStepTrigger,
				PrerollComplete
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Clear : IMessage<API_Clear>, IMessage, IEquatable<API_Clear>, IDeepCloneable<API_Clear>
				{
					public enum ClearInfoOneofCase
					{
						None,
						Layer,
						GroupIdentifier
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Layer
						{
							[OriginalName("LAYER_UNKNOWN")]
							Unknown,
							[OriginalName("LAYER_VIDEO_INPUT")]
							VideoInput,
							[OriginalName("LAYER_MEDIA")]
							Media,
							[OriginalName("LAYER_PRESENTATION")]
							Presentation,
							[OriginalName("LAYER_ANNOUNCEMENT")]
							Announcement,
							[OriginalName("LAYER_PROP")]
							Prop,
							[OriginalName("LAYER_MESSAGE")]
							Message,
							[OriginalName("LAYER_AUDIO")]
							Audio
						}
					}

					private static readonly MessageParser<API_Clear> _parser = new MessageParser<API_Clear>(() => new API_Clear());

					private UnknownFieldSet _unknownFields;

					public const int LayerFieldNumber = 1;

					public const int GroupIdentifierFieldNumber = 2;

					private object clearInfo_;

					private ClearInfoOneofCase clearInfoCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Clear> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Layer Layer
					{
						get
						{
							if (!HasLayer)
							{
								return Types.Layer.Unknown;
							}
							return (Types.Layer)clearInfo_;
						}
						set
						{
							clearInfo_ = value;
							clearInfoCase_ = ClearInfoOneofCase.Layer;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool HasLayer => clearInfoCase_ == ClearInfoOneofCase.Layer;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public IndexOrNameIdentifier GroupIdentifier
					{
						get
						{
							if (clearInfoCase_ != ClearInfoOneofCase.GroupIdentifier)
							{
								return null;
							}
							return (IndexOrNameIdentifier)clearInfo_;
						}
						set
						{
							clearInfo_ = value;
							clearInfoCase_ = ((value != null) ? ClearInfoOneofCase.GroupIdentifier : ClearInfoOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ClearInfoOneofCase ClearInfoCase => clearInfoCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Clear()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Clear(API_Clear other)
						: this()
					{
						switch (other.ClearInfoCase)
						{
						case ClearInfoOneofCase.Layer:
							Layer = other.Layer;
							break;
						case ClearInfoOneofCase.GroupIdentifier:
							GroupIdentifier = other.GroupIdentifier.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Clear Clone()
					{
						return new API_Clear(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearLayer()
					{
						if (HasLayer)
						{
							ClearClearInfo();
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearClearInfo()
					{
						clearInfoCase_ = ClearInfoOneofCase.None;
						clearInfo_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Clear);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Clear other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Layer != other.Layer)
						{
							return false;
						}
						if (!object.Equals(GroupIdentifier, other.GroupIdentifier))
						{
							return false;
						}
						if (ClearInfoCase != other.ClearInfoCase)
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
						if (HasLayer)
						{
							num ^= Layer.GetHashCode();
						}
						if (clearInfoCase_ == ClearInfoOneofCase.GroupIdentifier)
						{
							num ^= GroupIdentifier.GetHashCode();
						}
						num ^= (int)clearInfoCase_;
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
						if (HasLayer)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Layer);
						}
						if (clearInfoCase_ == ClearInfoOneofCase.GroupIdentifier)
						{
							output.WriteRawTag(18);
							output.WriteMessage(GroupIdentifier);
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
						if (HasLayer)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
						}
						if (clearInfoCase_ == ClearInfoOneofCase.GroupIdentifier)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GroupIdentifier);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Clear other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.ClearInfoCase)
						{
						case ClearInfoOneofCase.Layer:
							Layer = other.Layer;
							break;
						case ClearInfoOneofCase.GroupIdentifier:
							if (GroupIdentifier == null)
							{
								GroupIdentifier = new IndexOrNameIdentifier();
							}
							GroupIdentifier.MergeFrom(other.GroupIdentifier);
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
							case 8u:
								clearInfo_ = input.ReadEnum();
								clearInfoCase_ = ClearInfoOneofCase.Layer;
								break;
							case 18u:
							{
								IndexOrNameIdentifier indexOrNameIdentifier = new IndexOrNameIdentifier();
								if (clearInfoCase_ == ClearInfoOneofCase.GroupIdentifier)
								{
									indexOrNameIdentifier.MergeFrom(GroupIdentifier);
								}
								input.ReadMessage(indexOrNameIdentifier);
								GroupIdentifier = indexOrNameIdentifier;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_TwoStepTrigger : IMessage<API_TwoStepTrigger>, IMessage, IEquatable<API_TwoStepTrigger>, IDeepCloneable<API_TwoStepTrigger>
				{
					public enum TriggerDataOneofCase
					{
						None = 0,
						Presentation = 4,
						Media = 5,
						VideoInput = 6,
						Audio = 7,
						Prop = 8,
						Message = 9
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Operation
						{
							[OriginalName("OPERATION_PREROLL")]
							Preroll,
							[OriginalName("OPERATION_ACTIVATE")]
							Activate
						}
					}

					private static readonly MessageParser<API_TwoStepTrigger> _parser = new MessageParser<API_TwoStepTrigger>(() => new API_TwoStepTrigger());

					private UnknownFieldSet _unknownFields;

					public const int IdFieldNumber = 1;

					private ulong id_;

					public const int OperationFieldNumber = 2;

					private Types.Operation operation_;

					public const int RenderTimeFieldNumber = 3;

					private ulong renderTime_;

					public const int PresentationFieldNumber = 4;

					public const int MediaFieldNumber = 5;

					public const int VideoInputFieldNumber = 6;

					public const int AudioFieldNumber = 7;

					public const int PropFieldNumber = 8;

					public const int MessageFieldNumber = 9;

					private object triggerData_;

					private TriggerDataOneofCase triggerDataCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_TwoStepTrigger> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ulong Id
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
					public Types.Operation Operation
					{
						get
						{
							return operation_;
						}
						set
						{
							operation_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ulong RenderTime
					{
						get
						{
							return renderTime_;
						}
						set
						{
							renderTime_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Trigger.Types.Presentation Presentation
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Presentation)
							{
								return null;
							}
							return (API_Trigger.Types.Presentation)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Presentation : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Trigger.Types.Media Media
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Media)
							{
								return null;
							}
							return (API_Trigger.Types.Media)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Media : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Trigger.Types.VideoInput VideoInput
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.VideoInput)
							{
								return null;
							}
							return (API_Trigger.Types.VideoInput)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.VideoInput : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Trigger.Types.Audio Audio
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Audio)
							{
								return null;
							}
							return (API_Trigger.Types.Audio)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Audio : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Prop.Types.TriggerProp Prop
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Prop)
							{
								return null;
							}
							return (API_Prop.Types.TriggerProp)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Prop : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Message.Types.TriggerMessage Message
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Message)
							{
								return null;
							}
							return (API_Message.Types.TriggerMessage)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Message : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TriggerDataOneofCase TriggerDataCase => triggerDataCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_TwoStepTrigger()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_TwoStepTrigger(API_TwoStepTrigger other)
						: this()
					{
						id_ = other.id_;
						operation_ = other.operation_;
						renderTime_ = other.renderTime_;
						switch (other.TriggerDataCase)
						{
						case TriggerDataOneofCase.Presentation:
							Presentation = other.Presentation.Clone();
							break;
						case TriggerDataOneofCase.Media:
							Media = other.Media.Clone();
							break;
						case TriggerDataOneofCase.VideoInput:
							VideoInput = other.VideoInput.Clone();
							break;
						case TriggerDataOneofCase.Audio:
							Audio = other.Audio.Clone();
							break;
						case TriggerDataOneofCase.Prop:
							Prop = other.Prop.Clone();
							break;
						case TriggerDataOneofCase.Message:
							Message = other.Message.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_TwoStepTrigger Clone()
					{
						return new API_TwoStepTrigger(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearTriggerData()
					{
						triggerDataCase_ = TriggerDataOneofCase.None;
						triggerData_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_TwoStepTrigger);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_TwoStepTrigger other)
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
						if (Operation != other.Operation)
						{
							return false;
						}
						if (RenderTime != other.RenderTime)
						{
							return false;
						}
						if (!object.Equals(Presentation, other.Presentation))
						{
							return false;
						}
						if (!object.Equals(Media, other.Media))
						{
							return false;
						}
						if (!object.Equals(VideoInput, other.VideoInput))
						{
							return false;
						}
						if (!object.Equals(Audio, other.Audio))
						{
							return false;
						}
						if (!object.Equals(Prop, other.Prop))
						{
							return false;
						}
						if (!object.Equals(Message, other.Message))
						{
							return false;
						}
						if (TriggerDataCase != other.TriggerDataCase)
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
						if (Id != 0L)
						{
							num ^= Id.GetHashCode();
						}
						if (Operation != 0)
						{
							num ^= Operation.GetHashCode();
						}
						if (RenderTime != 0L)
						{
							num ^= RenderTime.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
						{
							num ^= Presentation.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Media)
						{
							num ^= Media.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
						{
							num ^= VideoInput.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Audio)
						{
							num ^= Audio.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Prop)
						{
							num ^= Prop.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Message)
						{
							num ^= Message.GetHashCode();
						}
						num ^= (int)triggerDataCase_;
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
						if (Id != 0L)
						{
							output.WriteRawTag(8);
							output.WriteUInt64(Id);
						}
						if (Operation != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)Operation);
						}
						if (RenderTime != 0L)
						{
							output.WriteRawTag(24);
							output.WriteUInt64(RenderTime);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Presentation);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Media)
						{
							output.WriteRawTag(42);
							output.WriteMessage(Media);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
						{
							output.WriteRawTag(50);
							output.WriteMessage(VideoInput);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Audio)
						{
							output.WriteRawTag(58);
							output.WriteMessage(Audio);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Prop)
						{
							output.WriteRawTag(66);
							output.WriteMessage(Prop);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Message)
						{
							output.WriteRawTag(74);
							output.WriteMessage(Message);
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
						if (Id != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(Id);
						}
						if (Operation != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
						}
						if (RenderTime != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(RenderTime);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Media)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Media);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(VideoInput);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Audio)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Prop)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Prop);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Message)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Message);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_TwoStepTrigger other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Id != 0L)
						{
							Id = other.Id;
						}
						if (other.Operation != 0)
						{
							Operation = other.Operation;
						}
						if (other.RenderTime != 0L)
						{
							RenderTime = other.RenderTime;
						}
						switch (other.TriggerDataCase)
						{
						case TriggerDataOneofCase.Presentation:
							if (Presentation == null)
							{
								Presentation = new API_Trigger.Types.Presentation();
							}
							Presentation.MergeFrom(other.Presentation);
							break;
						case TriggerDataOneofCase.Media:
							if (Media == null)
							{
								Media = new API_Trigger.Types.Media();
							}
							Media.MergeFrom(other.Media);
							break;
						case TriggerDataOneofCase.VideoInput:
							if (VideoInput == null)
							{
								VideoInput = new API_Trigger.Types.VideoInput();
							}
							VideoInput.MergeFrom(other.VideoInput);
							break;
						case TriggerDataOneofCase.Audio:
							if (Audio == null)
							{
								Audio = new API_Trigger.Types.Audio();
							}
							Audio.MergeFrom(other.Audio);
							break;
						case TriggerDataOneofCase.Prop:
							if (Prop == null)
							{
								Prop = new API_Prop.Types.TriggerProp();
							}
							Prop.MergeFrom(other.Prop);
							break;
						case TriggerDataOneofCase.Message:
							if (Message == null)
							{
								Message = new API_Message.Types.TriggerMessage();
							}
							Message.MergeFrom(other.Message);
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
							case 8u:
								Id = input.ReadUInt64();
								break;
							case 16u:
								Operation = (Types.Operation)input.ReadEnum();
								break;
							case 24u:
								RenderTime = input.ReadUInt64();
								break;
							case 34u:
							{
								API_Trigger.Types.Presentation presentation = new API_Trigger.Types.Presentation();
								if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
								{
									presentation.MergeFrom(Presentation);
								}
								input.ReadMessage(presentation);
								Presentation = presentation;
								break;
							}
							case 42u:
							{
								API_Trigger.Types.Media media = new API_Trigger.Types.Media();
								if (triggerDataCase_ == TriggerDataOneofCase.Media)
								{
									media.MergeFrom(Media);
								}
								input.ReadMessage(media);
								Media = media;
								break;
							}
							case 50u:
							{
								API_Trigger.Types.VideoInput videoInput = new API_Trigger.Types.VideoInput();
								if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
								{
									videoInput.MergeFrom(VideoInput);
								}
								input.ReadMessage(videoInput);
								VideoInput = videoInput;
								break;
							}
							case 58u:
							{
								API_Trigger.Types.Audio audio = new API_Trigger.Types.Audio();
								if (triggerDataCase_ == TriggerDataOneofCase.Audio)
								{
									audio.MergeFrom(Audio);
								}
								input.ReadMessage(audio);
								Audio = audio;
								break;
							}
							case 66u:
							{
								API_Prop.Types.TriggerProp triggerProp = new API_Prop.Types.TriggerProp();
								if (triggerDataCase_ == TriggerDataOneofCase.Prop)
								{
									triggerProp.MergeFrom(Prop);
								}
								input.ReadMessage(triggerProp);
								Prop = triggerProp;
								break;
							}
							case 74u:
							{
								API_Message.Types.TriggerMessage triggerMessage = new API_Message.Types.TriggerMessage();
								if (triggerDataCase_ == TriggerDataOneofCase.Message)
								{
									triggerMessage.MergeFrom(Message);
								}
								input.ReadMessage(triggerMessage);
								Message = triggerMessage;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_PrerollComplete : IMessage<API_PrerollComplete>, IMessage, IEquatable<API_PrerollComplete>, IDeepCloneable<API_PrerollComplete>
				{
					private static readonly MessageParser<API_PrerollComplete> _parser = new MessageParser<API_PrerollComplete>(() => new API_PrerollComplete());

					private UnknownFieldSet _unknownFields;

					public const int IdFieldNumber = 1;

					private ulong id_;

					public const int FailedFieldNumber = 2;

					private bool failed_;

					public const int LatencyFieldNumber = 3;

					private ulong latency_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_PrerollComplete> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ulong Id
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
					public bool Failed
					{
						get
						{
							return failed_;
						}
						set
						{
							failed_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ulong Latency
					{
						get
						{
							return latency_;
						}
						set
						{
							latency_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_PrerollComplete()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_PrerollComplete(API_PrerollComplete other)
						: this()
					{
						id_ = other.id_;
						failed_ = other.failed_;
						latency_ = other.latency_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_PrerollComplete Clone()
					{
						return new API_PrerollComplete(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_PrerollComplete);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_PrerollComplete other)
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
						if (Failed != other.Failed)
						{
							return false;
						}
						if (Latency != other.Latency)
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
						if (Id != 0L)
						{
							num ^= Id.GetHashCode();
						}
						if (Failed)
						{
							num ^= Failed.GetHashCode();
						}
						if (Latency != 0L)
						{
							num ^= Latency.GetHashCode();
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
						if (Id != 0L)
						{
							output.WriteRawTag(8);
							output.WriteUInt64(Id);
						}
						if (Failed)
						{
							output.WriteRawTag(16);
							output.WriteBool(Failed);
						}
						if (Latency != 0L)
						{
							output.WriteRawTag(24);
							output.WriteUInt64(Latency);
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
						if (Id != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(Id);
						}
						if (Failed)
						{
							num += 2;
						}
						if (Latency != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(Latency);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_PrerollComplete other)
					{
						if (other != null)
						{
							if (other.Id != 0L)
							{
								Id = other.Id;
							}
							if (other.Failed)
							{
								Failed = other.Failed;
							}
							if (other.Latency != 0L)
							{
								Latency = other.Latency;
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
								Id = input.ReadUInt64();
								break;
							case 16u:
								Failed = input.ReadBool();
								break;
							case 24u:
								Latency = input.ReadUInt64();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Trigger : IMessage<API_Trigger>, IMessage, IEquatable<API_Trigger>, IDeepCloneable<API_Trigger>
				{
					public enum TriggerDataOneofCase
					{
						None,
						Presentation,
						Media,
						VideoInput,
						Audio
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Presentation : IMessage<Presentation>, IMessage, IEquatable<Presentation>, IDeepCloneable<Presentation>
						{
							public enum PresentationSourceOneofCase
							{
								None = 0,
								PlaylistIndexPath = 2,
								LibraryIndexPath = 3
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class PlaylistPresentation : IMessage<PlaylistPresentation>, IMessage, IEquatable<PlaylistPresentation>, IDeepCloneable<PlaylistPresentation>
								{
									private static readonly MessageParser<PlaylistPresentation> _parser = new MessageParser<PlaylistPresentation>(() => new PlaylistPresentation());

									private UnknownFieldSet _unknownFields;

									public const int IndexPathComponentsFieldNumber = 1;

									private static readonly FieldCodec<IndexOrNameIdentifier> _repeated_indexPathComponents_codec = FieldCodec.ForMessage(10u, IndexOrNameIdentifier.Parser);

									private readonly RepeatedField<IndexOrNameIdentifier> indexPathComponents_ = new RepeatedField<IndexOrNameIdentifier>();

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<PlaylistPresentation> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public RepeatedField<IndexOrNameIdentifier> IndexPathComponents => indexPathComponents_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public PlaylistPresentation()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public PlaylistPresentation(PlaylistPresentation other)
										: this()
									{
										indexPathComponents_ = other.indexPathComponents_.Clone();
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public PlaylistPresentation Clone()
									{
										return new PlaylistPresentation(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as PlaylistPresentation);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(PlaylistPresentation other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!indexPathComponents_.Equals(other.indexPathComponents_))
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
										num ^= indexPathComponents_.GetHashCode();
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
										indexPathComponents_.WriteTo(output, _repeated_indexPathComponents_codec);
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
										num += indexPathComponents_.CalculateSize(_repeated_indexPathComponents_codec);
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(PlaylistPresentation other)
									{
										if (other != null)
										{
											indexPathComponents_.Add(other.indexPathComponents_);
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
												indexPathComponents_.AddEntriesFrom(input, _repeated_indexPathComponents_codec);
											}
										}
									}
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class LibraryPresentation : IMessage<LibraryPresentation>, IMessage, IEquatable<LibraryPresentation>, IDeepCloneable<LibraryPresentation>
								{
									private static readonly MessageParser<LibraryPresentation> _parser = new MessageParser<LibraryPresentation>(() => new LibraryPresentation());

									private UnknownFieldSet _unknownFields;

									public const int LibraryComponentFieldNumber = 1;

									private IndexOrNameIdentifier libraryComponent_;

									public const int PresentationComponentFieldNumber = 2;

									private IndexOrNameIdentifier presentationComponent_;

									public const int CueComponentFieldNumber = 3;

									private IndexOrNameIdentifier cueComponent_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<LibraryPresentation> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Presentation.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public IndexOrNameIdentifier LibraryComponent
									{
										get
										{
											return libraryComponent_;
										}
										set
										{
											libraryComponent_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public IndexOrNameIdentifier PresentationComponent
									{
										get
										{
											return presentationComponent_;
										}
										set
										{
											presentationComponent_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public IndexOrNameIdentifier CueComponent
									{
										get
										{
											return cueComponent_;
										}
										set
										{
											cueComponent_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public LibraryPresentation()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public LibraryPresentation(LibraryPresentation other)
										: this()
									{
										libraryComponent_ = ((other.libraryComponent_ != null) ? other.libraryComponent_.Clone() : null);
										presentationComponent_ = ((other.presentationComponent_ != null) ? other.presentationComponent_.Clone() : null);
										cueComponent_ = ((other.cueComponent_ != null) ? other.cueComponent_.Clone() : null);
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public LibraryPresentation Clone()
									{
										return new LibraryPresentation(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as LibraryPresentation);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(LibraryPresentation other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (!object.Equals(LibraryComponent, other.LibraryComponent))
										{
											return false;
										}
										if (!object.Equals(PresentationComponent, other.PresentationComponent))
										{
											return false;
										}
										if (!object.Equals(CueComponent, other.CueComponent))
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
										if (libraryComponent_ != null)
										{
											num ^= LibraryComponent.GetHashCode();
										}
										if (presentationComponent_ != null)
										{
											num ^= PresentationComponent.GetHashCode();
										}
										if (cueComponent_ != null)
										{
											num ^= CueComponent.GetHashCode();
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
										if (libraryComponent_ != null)
										{
											output.WriteRawTag(10);
											output.WriteMessage(LibraryComponent);
										}
										if (presentationComponent_ != null)
										{
											output.WriteRawTag(18);
											output.WriteMessage(PresentationComponent);
										}
										if (cueComponent_ != null)
										{
											output.WriteRawTag(26);
											output.WriteMessage(CueComponent);
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
										if (libraryComponent_ != null)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(LibraryComponent);
										}
										if (presentationComponent_ != null)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(PresentationComponent);
										}
										if (cueComponent_ != null)
										{
											num += 1 + CodedOutputStream.ComputeMessageSize(CueComponent);
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(LibraryPresentation other)
									{
										if (other == null)
										{
											return;
										}
										if (other.libraryComponent_ != null)
										{
											if (libraryComponent_ == null)
											{
												LibraryComponent = new IndexOrNameIdentifier();
											}
											LibraryComponent.MergeFrom(other.LibraryComponent);
										}
										if (other.presentationComponent_ != null)
										{
											if (presentationComponent_ == null)
											{
												PresentationComponent = new IndexOrNameIdentifier();
											}
											PresentationComponent.MergeFrom(other.PresentationComponent);
										}
										if (other.cueComponent_ != null)
										{
											if (cueComponent_ == null)
											{
												CueComponent = new IndexOrNameIdentifier();
											}
											CueComponent.MergeFrom(other.CueComponent);
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
												if (libraryComponent_ == null)
												{
													LibraryComponent = new IndexOrNameIdentifier();
												}
												input.ReadMessage(LibraryComponent);
												break;
											case 18u:
												if (presentationComponent_ == null)
												{
													PresentationComponent = new IndexOrNameIdentifier();
												}
												input.ReadMessage(PresentationComponent);
												break;
											case 26u:
												if (cueComponent_ == null)
												{
													CueComponent = new IndexOrNameIdentifier();
												}
												input.ReadMessage(CueComponent);
												break;
											}
										}
									}
								}
							}

							private static readonly MessageParser<Presentation> _parser = new MessageParser<Presentation>(() => new Presentation());

							private UnknownFieldSet _unknownFields;

							public const int PlaylistIndexPathFieldNumber = 2;

							public const int LibraryIndexPathFieldNumber = 3;

							private object presentationSource_;

							private PresentationSourceOneofCase presentationSourceCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Presentation> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Trigger.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.PlaylistPresentation PlaylistIndexPath
							{
								get
								{
									if (presentationSourceCase_ != PresentationSourceOneofCase.PlaylistIndexPath)
									{
										return null;
									}
									return (Types.PlaylistPresentation)presentationSource_;
								}
								set
								{
									presentationSource_ = value;
									presentationSourceCase_ = ((value != null) ? PresentationSourceOneofCase.PlaylistIndexPath : PresentationSourceOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.LibraryPresentation LibraryIndexPath
							{
								get
								{
									if (presentationSourceCase_ != PresentationSourceOneofCase.LibraryIndexPath)
									{
										return null;
									}
									return (Types.LibraryPresentation)presentationSource_;
								}
								set
								{
									presentationSource_ = value;
									presentationSourceCase_ = ((value != null) ? PresentationSourceOneofCase.LibraryIndexPath : PresentationSourceOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public PresentationSourceOneofCase PresentationSourceCase => presentationSourceCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Presentation()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Presentation(Presentation other)
								: this()
							{
								switch (other.PresentationSourceCase)
								{
								case PresentationSourceOneofCase.PlaylistIndexPath:
									PlaylistIndexPath = other.PlaylistIndexPath.Clone();
									break;
								case PresentationSourceOneofCase.LibraryIndexPath:
									LibraryIndexPath = other.LibraryIndexPath.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Presentation Clone()
							{
								return new Presentation(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearPresentationSource()
							{
								presentationSourceCase_ = PresentationSourceOneofCase.None;
								presentationSource_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Presentation);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Presentation other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(PlaylistIndexPath, other.PlaylistIndexPath))
								{
									return false;
								}
								if (!object.Equals(LibraryIndexPath, other.LibraryIndexPath))
								{
									return false;
								}
								if (PresentationSourceCase != other.PresentationSourceCase)
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
								if (presentationSourceCase_ == PresentationSourceOneofCase.PlaylistIndexPath)
								{
									num ^= PlaylistIndexPath.GetHashCode();
								}
								if (presentationSourceCase_ == PresentationSourceOneofCase.LibraryIndexPath)
								{
									num ^= LibraryIndexPath.GetHashCode();
								}
								num ^= (int)presentationSourceCase_;
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
								if (presentationSourceCase_ == PresentationSourceOneofCase.PlaylistIndexPath)
								{
									output.WriteRawTag(18);
									output.WriteMessage(PlaylistIndexPath);
								}
								if (presentationSourceCase_ == PresentationSourceOneofCase.LibraryIndexPath)
								{
									output.WriteRawTag(26);
									output.WriteMessage(LibraryIndexPath);
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
								if (presentationSourceCase_ == PresentationSourceOneofCase.PlaylistIndexPath)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistIndexPath);
								}
								if (presentationSourceCase_ == PresentationSourceOneofCase.LibraryIndexPath)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(LibraryIndexPath);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Presentation other)
							{
								if (other == null)
								{
									return;
								}
								switch (other.PresentationSourceCase)
								{
								case PresentationSourceOneofCase.PlaylistIndexPath:
									if (PlaylistIndexPath == null)
									{
										PlaylistIndexPath = new Types.PlaylistPresentation();
									}
									PlaylistIndexPath.MergeFrom(other.PlaylistIndexPath);
									break;
								case PresentationSourceOneofCase.LibraryIndexPath:
									if (LibraryIndexPath == null)
									{
										LibraryIndexPath = new Types.LibraryPresentation();
									}
									LibraryIndexPath.MergeFrom(other.LibraryIndexPath);
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
									case 18u:
									{
										Types.PlaylistPresentation playlistPresentation = new Types.PlaylistPresentation();
										if (presentationSourceCase_ == PresentationSourceOneofCase.PlaylistIndexPath)
										{
											playlistPresentation.MergeFrom(PlaylistIndexPath);
										}
										input.ReadMessage(playlistPresentation);
										PlaylistIndexPath = playlistPresentation;
										break;
									}
									case 26u:
									{
										Types.LibraryPresentation libraryPresentation = new Types.LibraryPresentation();
										if (presentationSourceCase_ == PresentationSourceOneofCase.LibraryIndexPath)
										{
											libraryPresentation.MergeFrom(LibraryIndexPath);
										}
										input.ReadMessage(libraryPresentation);
										LibraryIndexPath = libraryPresentation;
										break;
									}
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Media : IMessage<Media>, IMessage, IEquatable<Media>, IDeepCloneable<Media>
						{
							private static readonly MessageParser<Media> _parser = new MessageParser<Media>(() => new Media());

							private UnknownFieldSet _unknownFields;

							public const int IndexPathComponentsFieldNumber = 1;

							private static readonly FieldCodec<IndexOrNameIdentifier> _repeated_indexPathComponents_codec = FieldCodec.ForMessage(10u, IndexOrNameIdentifier.Parser);

							private readonly RepeatedField<IndexOrNameIdentifier> indexPathComponents_ = new RepeatedField<IndexOrNameIdentifier>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Media> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Trigger.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<IndexOrNameIdentifier> IndexPathComponents => indexPathComponents_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Media()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Media(Media other)
								: this()
							{
								indexPathComponents_ = other.indexPathComponents_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Media Clone()
							{
								return new Media(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Media);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Media other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!indexPathComponents_.Equals(other.indexPathComponents_))
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
								num ^= indexPathComponents_.GetHashCode();
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
								indexPathComponents_.WriteTo(output, _repeated_indexPathComponents_codec);
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
								num += indexPathComponents_.CalculateSize(_repeated_indexPathComponents_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Media other)
							{
								if (other != null)
								{
									indexPathComponents_.Add(other.indexPathComponents_);
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
										indexPathComponents_.AddEntriesFrom(input, _repeated_indexPathComponents_codec);
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class VideoInput : IMessage<VideoInput>, IMessage, IEquatable<VideoInput>, IDeepCloneable<VideoInput>
						{
							private static readonly MessageParser<VideoInput> _parser = new MessageParser<VideoInput>(() => new VideoInput());

							private UnknownFieldSet _unknownFields;

							public const int VideoInputIdFieldNumber = 1;

							private IndexOrNameIdentifier videoInputId_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<VideoInput> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Trigger.Descriptor.NestedTypes[2];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier VideoInputId
							{
								get
								{
									return videoInputId_;
								}
								set
								{
									videoInputId_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VideoInput()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VideoInput(VideoInput other)
								: this()
							{
								videoInputId_ = ((other.videoInputId_ != null) ? other.videoInputId_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public VideoInput Clone()
							{
								return new VideoInput(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as VideoInput);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(VideoInput other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(VideoInputId, other.VideoInputId))
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
								if (videoInputId_ != null)
								{
									num ^= VideoInputId.GetHashCode();
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
								if (videoInputId_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(VideoInputId);
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
								if (videoInputId_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(VideoInputId);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(VideoInput other)
							{
								if (other == null)
								{
									return;
								}
								if (other.videoInputId_ != null)
								{
									if (videoInputId_ == null)
									{
										VideoInputId = new IndexOrNameIdentifier();
									}
									VideoInputId.MergeFrom(other.VideoInputId);
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
									if (num != 10)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										continue;
									}
									if (videoInputId_ == null)
									{
										VideoInputId = new IndexOrNameIdentifier();
									}
									input.ReadMessage(VideoInputId);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Audio : IMessage<Audio>, IMessage, IEquatable<Audio>, IDeepCloneable<Audio>
						{
							private static readonly MessageParser<Audio> _parser = new MessageParser<Audio>(() => new Audio());

							private UnknownFieldSet _unknownFields;

							public const int IndexPathComponentsFieldNumber = 1;

							private static readonly FieldCodec<IndexOrNameIdentifier> _repeated_indexPathComponents_codec = FieldCodec.ForMessage(10u, IndexOrNameIdentifier.Parser);

							private readonly RepeatedField<IndexOrNameIdentifier> indexPathComponents_ = new RepeatedField<IndexOrNameIdentifier>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Audio> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Trigger.Descriptor.NestedTypes[3];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<IndexOrNameIdentifier> IndexPathComponents => indexPathComponents_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Audio()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Audio(Audio other)
								: this()
							{
								indexPathComponents_ = other.indexPathComponents_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Audio Clone()
							{
								return new Audio(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Audio);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Audio other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!indexPathComponents_.Equals(other.indexPathComponents_))
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
								num ^= indexPathComponents_.GetHashCode();
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
								indexPathComponents_.WriteTo(output, _repeated_indexPathComponents_codec);
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
								num += indexPathComponents_.CalculateSize(_repeated_indexPathComponents_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Audio other)
							{
								if (other != null)
								{
									indexPathComponents_.Add(other.indexPathComponents_);
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
										indexPathComponents_.AddEntriesFrom(input, _repeated_indexPathComponents_codec);
									}
								}
							}
						}
					}

					private static readonly MessageParser<API_Trigger> _parser = new MessageParser<API_Trigger>(() => new API_Trigger());

					private UnknownFieldSet _unknownFields;

					public const int PresentationFieldNumber = 1;

					public const int MediaFieldNumber = 2;

					public const int VideoInputFieldNumber = 3;

					public const int AudioFieldNumber = 4;

					private object triggerData_;

					private TriggerDataOneofCase triggerDataCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Trigger> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Presentation Presentation
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Presentation)
							{
								return null;
							}
							return (Types.Presentation)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Presentation : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Media Media
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Media)
							{
								return null;
							}
							return (Types.Media)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Media : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.VideoInput VideoInput
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.VideoInput)
							{
								return null;
							}
							return (Types.VideoInput)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.VideoInput : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Audio Audio
					{
						get
						{
							if (triggerDataCase_ != TriggerDataOneofCase.Audio)
							{
								return null;
							}
							return (Types.Audio)triggerData_;
						}
						set
						{
							triggerData_ = value;
							triggerDataCase_ = ((value != null) ? TriggerDataOneofCase.Audio : TriggerDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TriggerDataOneofCase TriggerDataCase => triggerDataCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Trigger()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Trigger(API_Trigger other)
						: this()
					{
						switch (other.TriggerDataCase)
						{
						case TriggerDataOneofCase.Presentation:
							Presentation = other.Presentation.Clone();
							break;
						case TriggerDataOneofCase.Media:
							Media = other.Media.Clone();
							break;
						case TriggerDataOneofCase.VideoInput:
							VideoInput = other.VideoInput.Clone();
							break;
						case TriggerDataOneofCase.Audio:
							Audio = other.Audio.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Trigger Clone()
					{
						return new API_Trigger(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearTriggerData()
					{
						triggerDataCase_ = TriggerDataOneofCase.None;
						triggerData_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Trigger);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Trigger other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Presentation, other.Presentation))
						{
							return false;
						}
						if (!object.Equals(Media, other.Media))
						{
							return false;
						}
						if (!object.Equals(VideoInput, other.VideoInput))
						{
							return false;
						}
						if (!object.Equals(Audio, other.Audio))
						{
							return false;
						}
						if (TriggerDataCase != other.TriggerDataCase)
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
						if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
						{
							num ^= Presentation.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Media)
						{
							num ^= Media.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
						{
							num ^= VideoInput.GetHashCode();
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Audio)
						{
							num ^= Audio.GetHashCode();
						}
						num ^= (int)triggerDataCase_;
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
						if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Presentation);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Media)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Media);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
						{
							output.WriteRawTag(26);
							output.WriteMessage(VideoInput);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Audio)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Audio);
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
						if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Media)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Media);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(VideoInput);
						}
						if (triggerDataCase_ == TriggerDataOneofCase.Audio)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Audio);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Trigger other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.TriggerDataCase)
						{
						case TriggerDataOneofCase.Presentation:
							if (Presentation == null)
							{
								Presentation = new Types.Presentation();
							}
							Presentation.MergeFrom(other.Presentation);
							break;
						case TriggerDataOneofCase.Media:
							if (Media == null)
							{
								Media = new Types.Media();
							}
							Media.MergeFrom(other.Media);
							break;
						case TriggerDataOneofCase.VideoInput:
							if (VideoInput == null)
							{
								VideoInput = new Types.VideoInput();
							}
							VideoInput.MergeFrom(other.VideoInput);
							break;
						case TriggerDataOneofCase.Audio:
							if (Audio == null)
							{
								Audio = new Types.Audio();
							}
							Audio.MergeFrom(other.Audio);
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
							{
								Types.Presentation presentation = new Types.Presentation();
								if (triggerDataCase_ == TriggerDataOneofCase.Presentation)
								{
									presentation.MergeFrom(Presentation);
								}
								input.ReadMessage(presentation);
								Presentation = presentation;
								break;
							}
							case 18u:
							{
								Types.Media media = new Types.Media();
								if (triggerDataCase_ == TriggerDataOneofCase.Media)
								{
									media.MergeFrom(Media);
								}
								input.ReadMessage(media);
								Media = media;
								break;
							}
							case 26u:
							{
								Types.VideoInput videoInput = new Types.VideoInput();
								if (triggerDataCase_ == TriggerDataOneofCase.VideoInput)
								{
									videoInput.MergeFrom(VideoInput);
								}
								input.ReadMessage(videoInput);
								VideoInput = videoInput;
								break;
							}
							case 34u:
							{
								Types.Audio audio = new Types.Audio();
								if (triggerDataCase_ == TriggerDataOneofCase.Audio)
								{
									audio.MergeFrom(Audio);
								}
								input.ReadMessage(audio);
								Audio = audio;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Transport : IMessage<API_Transport>, IMessage, IEquatable<API_Transport>, IDeepCloneable<API_Transport>
				{
					public enum TransportActionOneofCase
					{
						None = 0,
						Play = 2,
						Pause = 3,
						SkipBackward = 4,
						SkipForward = 5,
						GoToEnd = 6
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum TransportLayer
						{
							[OriginalName("TRANSPORT_LAYER_UNKNOWN")]
							Unknown,
							[OriginalName("TRANSPORT_LAYER_PRESENTATION")]
							Presentation,
							[OriginalName("TRANSPORT_LAYER_ANNOUNCEMENT")]
							Announcement,
							[OriginalName("TRANSPORT_LAYER_AUDIO")]
							Audio
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Play : IMessage<Play>, IMessage, IEquatable<Play>, IDeepCloneable<Play>
						{
							private static readonly MessageParser<Play> _parser = new MessageParser<Play>(() => new Play());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Play> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Transport.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Play()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Play(Play other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Play Clone()
							{
								return new Play(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Play);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Play other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								return object.Equals(_unknownFields, other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override int GetHashCode()
							{
								int num = 1;
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
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Play other)
							{
								if (other != null)
								{
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
									_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Pause : IMessage<Pause>, IMessage, IEquatable<Pause>, IDeepCloneable<Pause>
						{
							private static readonly MessageParser<Pause> _parser = new MessageParser<Pause>(() => new Pause());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Pause> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Transport.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Pause()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Pause(Pause other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Pause Clone()
							{
								return new Pause(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Pause);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Pause other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								return object.Equals(_unknownFields, other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override int GetHashCode()
							{
								int num = 1;
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
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Pause other)
							{
								if (other != null)
								{
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
									_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class SkipBackward : IMessage<SkipBackward>, IMessage, IEquatable<SkipBackward>, IDeepCloneable<SkipBackward>
						{
							private static readonly MessageParser<SkipBackward> _parser = new MessageParser<SkipBackward>(() => new SkipBackward());

							private UnknownFieldSet _unknownFields;

							public const int SecondsFieldNumber = 1;

							private int seconds_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<SkipBackward> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Transport.Descriptor.NestedTypes[2];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public int Seconds
							{
								get
								{
									return seconds_;
								}
								set
								{
									seconds_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SkipBackward()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SkipBackward(SkipBackward other)
								: this()
							{
								seconds_ = other.seconds_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SkipBackward Clone()
							{
								return new SkipBackward(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as SkipBackward);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(SkipBackward other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Seconds != other.Seconds)
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
								if (Seconds != 0)
								{
									num ^= Seconds.GetHashCode();
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
								if (Seconds != 0)
								{
									output.WriteRawTag(8);
									output.WriteInt32(Seconds);
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
								if (Seconds != 0)
								{
									num += 1 + CodedOutputStream.ComputeInt32Size(Seconds);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(SkipBackward other)
							{
								if (other != null)
								{
									if (other.Seconds != 0)
									{
										Seconds = other.Seconds;
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
									if (num != 8)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
									}
									else
									{
										Seconds = input.ReadInt32();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class SkipForward : IMessage<SkipForward>, IMessage, IEquatable<SkipForward>, IDeepCloneable<SkipForward>
						{
							private static readonly MessageParser<SkipForward> _parser = new MessageParser<SkipForward>(() => new SkipForward());

							private UnknownFieldSet _unknownFields;

							public const int SecondsFieldNumber = 1;

							private int seconds_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<SkipForward> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Transport.Descriptor.NestedTypes[3];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public int Seconds
							{
								get
								{
									return seconds_;
								}
								set
								{
									seconds_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SkipForward()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SkipForward(SkipForward other)
								: this()
							{
								seconds_ = other.seconds_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public SkipForward Clone()
							{
								return new SkipForward(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as SkipForward);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(SkipForward other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Seconds != other.Seconds)
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
								if (Seconds != 0)
								{
									num ^= Seconds.GetHashCode();
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
								if (Seconds != 0)
								{
									output.WriteRawTag(8);
									output.WriteInt32(Seconds);
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
								if (Seconds != 0)
								{
									num += 1 + CodedOutputStream.ComputeInt32Size(Seconds);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(SkipForward other)
							{
								if (other != null)
								{
									if (other.Seconds != 0)
									{
										Seconds = other.Seconds;
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
									if (num != 8)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
									}
									else
									{
										Seconds = input.ReadInt32();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class GoToEnd : IMessage<GoToEnd>, IMessage, IEquatable<GoToEnd>, IDeepCloneable<GoToEnd>
						{
							private static readonly MessageParser<GoToEnd> _parser = new MessageParser<GoToEnd>(() => new GoToEnd());

							private UnknownFieldSet _unknownFields;

							public const int SecondsToEndFieldNumber = 1;

							private int secondsToEnd_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<GoToEnd> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Transport.Descriptor.NestedTypes[4];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public int SecondsToEnd
							{
								get
								{
									return secondsToEnd_;
								}
								set
								{
									secondsToEnd_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GoToEnd()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GoToEnd(GoToEnd other)
								: this()
							{
								secondsToEnd_ = other.secondsToEnd_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GoToEnd Clone()
							{
								return new GoToEnd(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as GoToEnd);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(GoToEnd other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (SecondsToEnd != other.SecondsToEnd)
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
								if (SecondsToEnd != 0)
								{
									num ^= SecondsToEnd.GetHashCode();
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
								if (SecondsToEnd != 0)
								{
									output.WriteRawTag(8);
									output.WriteInt32(SecondsToEnd);
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
								if (SecondsToEnd != 0)
								{
									num += 1 + CodedOutputStream.ComputeInt32Size(SecondsToEnd);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(GoToEnd other)
							{
								if (other != null)
								{
									if (other.SecondsToEnd != 0)
									{
										SecondsToEnd = other.SecondsToEnd;
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
									if (num != 8)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
									}
									else
									{
										SecondsToEnd = input.ReadInt32();
									}
								}
							}
						}
					}

					private static readonly MessageParser<API_Transport> _parser = new MessageParser<API_Transport>(() => new API_Transport());

					private UnknownFieldSet _unknownFields;

					public const int LayerFieldNumber = 1;

					private Types.TransportLayer layer_;

					public const int PlayFieldNumber = 2;

					public const int PauseFieldNumber = 3;

					public const int SkipBackwardFieldNumber = 4;

					public const int SkipForwardFieldNumber = 5;

					public const int GoToEndFieldNumber = 6;

					private object transportAction_;

					private TransportActionOneofCase transportActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Transport> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.TransportLayer Layer
					{
						get
						{
							return layer_;
						}
						set
						{
							layer_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Play Play
					{
						get
						{
							if (transportActionCase_ != TransportActionOneofCase.Play)
							{
								return null;
							}
							return (Types.Play)transportAction_;
						}
						set
						{
							transportAction_ = value;
							transportActionCase_ = ((value != null) ? TransportActionOneofCase.Play : TransportActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Pause Pause
					{
						get
						{
							if (transportActionCase_ != TransportActionOneofCase.Pause)
							{
								return null;
							}
							return (Types.Pause)transportAction_;
						}
						set
						{
							transportAction_ = value;
							transportActionCase_ = ((value != null) ? TransportActionOneofCase.Pause : TransportActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.SkipBackward SkipBackward
					{
						get
						{
							if (transportActionCase_ != TransportActionOneofCase.SkipBackward)
							{
								return null;
							}
							return (Types.SkipBackward)transportAction_;
						}
						set
						{
							transportAction_ = value;
							transportActionCase_ = ((value != null) ? TransportActionOneofCase.SkipBackward : TransportActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.SkipForward SkipForward
					{
						get
						{
							if (transportActionCase_ != TransportActionOneofCase.SkipForward)
							{
								return null;
							}
							return (Types.SkipForward)transportAction_;
						}
						set
						{
							transportAction_ = value;
							transportActionCase_ = ((value != null) ? TransportActionOneofCase.SkipForward : TransportActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.GoToEnd GoToEnd
					{
						get
						{
							if (transportActionCase_ != TransportActionOneofCase.GoToEnd)
							{
								return null;
							}
							return (Types.GoToEnd)transportAction_;
						}
						set
						{
							transportAction_ = value;
							transportActionCase_ = ((value != null) ? TransportActionOneofCase.GoToEnd : TransportActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TransportActionOneofCase TransportActionCase => transportActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Transport()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Transport(API_Transport other)
						: this()
					{
						layer_ = other.layer_;
						switch (other.TransportActionCase)
						{
						case TransportActionOneofCase.Play:
							Play = other.Play.Clone();
							break;
						case TransportActionOneofCase.Pause:
							Pause = other.Pause.Clone();
							break;
						case TransportActionOneofCase.SkipBackward:
							SkipBackward = other.SkipBackward.Clone();
							break;
						case TransportActionOneofCase.SkipForward:
							SkipForward = other.SkipForward.Clone();
							break;
						case TransportActionOneofCase.GoToEnd:
							GoToEnd = other.GoToEnd.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Transport Clone()
					{
						return new API_Transport(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearTransportAction()
					{
						transportActionCase_ = TransportActionOneofCase.None;
						transportAction_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Transport);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Transport other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Layer != other.Layer)
						{
							return false;
						}
						if (!object.Equals(Play, other.Play))
						{
							return false;
						}
						if (!object.Equals(Pause, other.Pause))
						{
							return false;
						}
						if (!object.Equals(SkipBackward, other.SkipBackward))
						{
							return false;
						}
						if (!object.Equals(SkipForward, other.SkipForward))
						{
							return false;
						}
						if (!object.Equals(GoToEnd, other.GoToEnd))
						{
							return false;
						}
						if (TransportActionCase != other.TransportActionCase)
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
						if (Layer != 0)
						{
							num ^= Layer.GetHashCode();
						}
						if (transportActionCase_ == TransportActionOneofCase.Play)
						{
							num ^= Play.GetHashCode();
						}
						if (transportActionCase_ == TransportActionOneofCase.Pause)
						{
							num ^= Pause.GetHashCode();
						}
						if (transportActionCase_ == TransportActionOneofCase.SkipBackward)
						{
							num ^= SkipBackward.GetHashCode();
						}
						if (transportActionCase_ == TransportActionOneofCase.SkipForward)
						{
							num ^= SkipForward.GetHashCode();
						}
						if (transportActionCase_ == TransportActionOneofCase.GoToEnd)
						{
							num ^= GoToEnd.GetHashCode();
						}
						num ^= (int)transportActionCase_;
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
						if (Layer != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Layer);
						}
						if (transportActionCase_ == TransportActionOneofCase.Play)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Play);
						}
						if (transportActionCase_ == TransportActionOneofCase.Pause)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Pause);
						}
						if (transportActionCase_ == TransportActionOneofCase.SkipBackward)
						{
							output.WriteRawTag(34);
							output.WriteMessage(SkipBackward);
						}
						if (transportActionCase_ == TransportActionOneofCase.SkipForward)
						{
							output.WriteRawTag(42);
							output.WriteMessage(SkipForward);
						}
						if (transportActionCase_ == TransportActionOneofCase.GoToEnd)
						{
							output.WriteRawTag(50);
							output.WriteMessage(GoToEnd);
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
						if (Layer != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
						}
						if (transportActionCase_ == TransportActionOneofCase.Play)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Play);
						}
						if (transportActionCase_ == TransportActionOneofCase.Pause)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
						}
						if (transportActionCase_ == TransportActionOneofCase.SkipBackward)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(SkipBackward);
						}
						if (transportActionCase_ == TransportActionOneofCase.SkipForward)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(SkipForward);
						}
						if (transportActionCase_ == TransportActionOneofCase.GoToEnd)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GoToEnd);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Transport other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Layer != 0)
						{
							Layer = other.Layer;
						}
						switch (other.TransportActionCase)
						{
						case TransportActionOneofCase.Play:
							if (Play == null)
							{
								Play = new Types.Play();
							}
							Play.MergeFrom(other.Play);
							break;
						case TransportActionOneofCase.Pause:
							if (Pause == null)
							{
								Pause = new Types.Pause();
							}
							Pause.MergeFrom(other.Pause);
							break;
						case TransportActionOneofCase.SkipBackward:
							if (SkipBackward == null)
							{
								SkipBackward = new Types.SkipBackward();
							}
							SkipBackward.MergeFrom(other.SkipBackward);
							break;
						case TransportActionOneofCase.SkipForward:
							if (SkipForward == null)
							{
								SkipForward = new Types.SkipForward();
							}
							SkipForward.MergeFrom(other.SkipForward);
							break;
						case TransportActionOneofCase.GoToEnd:
							if (GoToEnd == null)
							{
								GoToEnd = new Types.GoToEnd();
							}
							GoToEnd.MergeFrom(other.GoToEnd);
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
							case 8u:
								Layer = (Types.TransportLayer)input.ReadEnum();
								break;
							case 18u:
							{
								Types.Play play = new Types.Play();
								if (transportActionCase_ == TransportActionOneofCase.Play)
								{
									play.MergeFrom(Play);
								}
								input.ReadMessage(play);
								Play = play;
								break;
							}
							case 26u:
							{
								Types.Pause pause = new Types.Pause();
								if (transportActionCase_ == TransportActionOneofCase.Pause)
								{
									pause.MergeFrom(Pause);
								}
								input.ReadMessage(pause);
								Pause = pause;
								break;
							}
							case 34u:
							{
								Types.SkipBackward skipBackward = new Types.SkipBackward();
								if (transportActionCase_ == TransportActionOneofCase.SkipBackward)
								{
									skipBackward.MergeFrom(SkipBackward);
								}
								input.ReadMessage(skipBackward);
								SkipBackward = skipBackward;
								break;
							}
							case 42u:
							{
								Types.SkipForward skipForward = new Types.SkipForward();
								if (transportActionCase_ == TransportActionOneofCase.SkipForward)
								{
									skipForward.MergeFrom(SkipForward);
								}
								input.ReadMessage(skipForward);
								SkipForward = skipForward;
								break;
							}
							case 50u:
							{
								Types.GoToEnd goToEnd = new Types.GoToEnd();
								if (transportActionCase_ == TransportActionOneofCase.GoToEnd)
								{
									goToEnd.MergeFrom(GoToEnd);
								}
								input.ReadMessage(goToEnd);
								GoToEnd = goToEnd;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Prop : IMessage<API_Prop>, IMessage, IEquatable<API_Prop>, IDeepCloneable<API_Prop>
				{
					public enum PropActionOneofCase
					{
						None,
						Trigger,
						Clear
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class TriggerProp : IMessage<TriggerProp>, IMessage, IEquatable<TriggerProp>, IDeepCloneable<TriggerProp>
						{
							private static readonly MessageParser<TriggerProp> _parser = new MessageParser<TriggerProp>(() => new TriggerProp());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							public const int IndexPathComponentsFieldNumber = 2;

							private static readonly FieldCodec<IndexOrNameIdentifier> _repeated_indexPathComponents_codec = FieldCodec.ForMessage(18u, IndexOrNameIdentifier.Parser);

							private readonly RepeatedField<IndexOrNameIdentifier> indexPathComponents_ = new RepeatedField<IndexOrNameIdentifier>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<TriggerProp> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Prop.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<IndexOrNameIdentifier> IndexPathComponents => indexPathComponents_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TriggerProp()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TriggerProp(TriggerProp other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								indexPathComponents_ = other.indexPathComponents_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TriggerProp Clone()
							{
								return new TriggerProp(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as TriggerProp);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(TriggerProp other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
								{
									return false;
								}
								if (!indexPathComponents_.Equals(other.indexPathComponents_))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
								}
								num ^= indexPathComponents_.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
								}
								indexPathComponents_.WriteTo(output, _repeated_indexPathComponents_codec);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								num += indexPathComponents_.CalculateSize(_repeated_indexPathComponents_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(TriggerProp other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
								}
								indexPathComponents_.Add(other.indexPathComponents_);
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
										if (identifier_ == null)
										{
											Identifier = new IndexOrNameIdentifier();
										}
										input.ReadMessage(Identifier);
										break;
									case 18u:
										indexPathComponents_.AddEntriesFrom(input, _repeated_indexPathComponents_codec);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ClearProp : IMessage<ClearProp>, IMessage, IEquatable<ClearProp>, IDeepCloneable<ClearProp>
						{
							private static readonly MessageParser<ClearProp> _parser = new MessageParser<ClearProp>(() => new ClearProp());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							public const int IndexPathComponentsFieldNumber = 2;

							private static readonly FieldCodec<IndexOrNameIdentifier> _repeated_indexPathComponents_codec = FieldCodec.ForMessage(18u, IndexOrNameIdentifier.Parser);

							private readonly RepeatedField<IndexOrNameIdentifier> indexPathComponents_ = new RepeatedField<IndexOrNameIdentifier>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ClearProp> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Prop.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<IndexOrNameIdentifier> IndexPathComponents => indexPathComponents_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClearProp()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClearProp(ClearProp other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								indexPathComponents_ = other.indexPathComponents_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClearProp Clone()
							{
								return new ClearProp(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ClearProp);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ClearProp other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
								{
									return false;
								}
								if (!indexPathComponents_.Equals(other.indexPathComponents_))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
								}
								num ^= indexPathComponents_.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
								}
								indexPathComponents_.WriteTo(output, _repeated_indexPathComponents_codec);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								num += indexPathComponents_.CalculateSize(_repeated_indexPathComponents_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(ClearProp other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
								}
								indexPathComponents_.Add(other.indexPathComponents_);
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
										if (identifier_ == null)
										{
											Identifier = new IndexOrNameIdentifier();
										}
										input.ReadMessage(Identifier);
										break;
									case 18u:
										indexPathComponents_.AddEntriesFrom(input, _repeated_indexPathComponents_codec);
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<API_Prop> _parser = new MessageParser<API_Prop>(() => new API_Prop());

					private UnknownFieldSet _unknownFields;

					public const int TriggerFieldNumber = 1;

					public const int ClearFieldNumber = 2;

					private object propAction_;

					private PropActionOneofCase propActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Prop> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[5];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.TriggerProp Trigger
					{
						get
						{
							if (propActionCase_ != PropActionOneofCase.Trigger)
							{
								return null;
							}
							return (Types.TriggerProp)propAction_;
						}
						set
						{
							propAction_ = value;
							propActionCase_ = ((value != null) ? PropActionOneofCase.Trigger : PropActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ClearProp Clear
					{
						get
						{
							if (propActionCase_ != PropActionOneofCase.Clear)
							{
								return null;
							}
							return (Types.ClearProp)propAction_;
						}
						set
						{
							propAction_ = value;
							propActionCase_ = ((value != null) ? PropActionOneofCase.Clear : PropActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropActionOneofCase PropActionCase => propActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Prop()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Prop(API_Prop other)
						: this()
					{
						switch (other.PropActionCase)
						{
						case PropActionOneofCase.Trigger:
							Trigger = other.Trigger.Clone();
							break;
						case PropActionOneofCase.Clear:
							Clear = other.Clear.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Prop Clone()
					{
						return new API_Prop(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearPropAction()
					{
						propActionCase_ = PropActionOneofCase.None;
						propAction_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Prop);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Prop other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Trigger, other.Trigger))
						{
							return false;
						}
						if (!object.Equals(Clear, other.Clear))
						{
							return false;
						}
						if (PropActionCase != other.PropActionCase)
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
						if (propActionCase_ == PropActionOneofCase.Trigger)
						{
							num ^= Trigger.GetHashCode();
						}
						if (propActionCase_ == PropActionOneofCase.Clear)
						{
							num ^= Clear.GetHashCode();
						}
						num ^= (int)propActionCase_;
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
						if (propActionCase_ == PropActionOneofCase.Trigger)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Trigger);
						}
						if (propActionCase_ == PropActionOneofCase.Clear)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Clear);
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
						if (propActionCase_ == PropActionOneofCase.Trigger)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
						}
						if (propActionCase_ == PropActionOneofCase.Clear)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Clear);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Prop other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.PropActionCase)
						{
						case PropActionOneofCase.Trigger:
							if (Trigger == null)
							{
								Trigger = new Types.TriggerProp();
							}
							Trigger.MergeFrom(other.Trigger);
							break;
						case PropActionOneofCase.Clear:
							if (Clear == null)
							{
								Clear = new Types.ClearProp();
							}
							Clear.MergeFrom(other.Clear);
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
							{
								Types.TriggerProp triggerProp = new Types.TriggerProp();
								if (propActionCase_ == PropActionOneofCase.Trigger)
								{
									triggerProp.MergeFrom(Trigger);
								}
								input.ReadMessage(triggerProp);
								Trigger = triggerProp;
								break;
							}
							case 18u:
							{
								Types.ClearProp clearProp = new Types.ClearProp();
								if (propActionCase_ == PropActionOneofCase.Clear)
								{
									clearProp.MergeFrom(Clear);
								}
								input.ReadMessage(clearProp);
								Clear = clearProp;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Timer : IMessage<API_Timer>, IMessage, IEquatable<API_Timer>, IDeepCloneable<API_Timer>
				{
					public enum TimerActionOneofCase
					{
						None,
						Start,
						Stop,
						Reset,
						Configure
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class StartTimer : IMessage<StartTimer>, IMessage, IEquatable<StartTimer>, IDeepCloneable<StartTimer>
						{
							private static readonly MessageParser<StartTimer> _parser = new MessageParser<StartTimer>(() => new StartTimer());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<StartTimer> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Timer.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StartTimer()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StartTimer(StartTimer other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StartTimer Clone()
							{
								return new StartTimer(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as StartTimer);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(StartTimer other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(StartTimer other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
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
									if (num != 10)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										continue;
									}
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									input.ReadMessage(Identifier);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class StopTimer : IMessage<StopTimer>, IMessage, IEquatable<StopTimer>, IDeepCloneable<StopTimer>
						{
							private static readonly MessageParser<StopTimer> _parser = new MessageParser<StopTimer>(() => new StopTimer());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<StopTimer> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Timer.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StopTimer()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StopTimer(StopTimer other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StopTimer Clone()
							{
								return new StopTimer(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as StopTimer);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(StopTimer other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(StopTimer other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
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
									if (num != 10)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										continue;
									}
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									input.ReadMessage(Identifier);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ResetTimer : IMessage<ResetTimer>, IMessage, IEquatable<ResetTimer>, IDeepCloneable<ResetTimer>
						{
							private static readonly MessageParser<ResetTimer> _parser = new MessageParser<ResetTimer>(() => new ResetTimer());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ResetTimer> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Timer.Descriptor.NestedTypes[2];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ResetTimer()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ResetTimer(ResetTimer other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ResetTimer Clone()
							{
								return new ResetTimer(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ResetTimer);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ResetTimer other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(ResetTimer other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
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
									if (num != 10)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										continue;
									}
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									input.ReadMessage(Identifier);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ConfigureTimer : IMessage<ConfigureTimer>, IMessage, IEquatable<ConfigureTimer>, IDeepCloneable<ConfigureTimer>
						{
							private static readonly MessageParser<ConfigureTimer> _parser = new MessageParser<ConfigureTimer>(() => new ConfigureTimer());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							public const int ConfigurationFieldNumber = 2;

							private Timer.Types.Configuration configuration_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ConfigureTimer> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Timer.Descriptor.NestedTypes[3];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Timer.Types.Configuration Configuration
							{
								get
								{
									return configuration_;
								}
								set
								{
									configuration_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ConfigureTimer()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ConfigureTimer(ConfigureTimer other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								configuration_ = ((other.configuration_ != null) ? other.configuration_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ConfigureTimer Clone()
							{
								return new ConfigureTimer(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ConfigureTimer);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ConfigureTimer other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
								{
									return false;
								}
								if (!object.Equals(Configuration, other.Configuration))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
								}
								if (configuration_ != null)
								{
									num ^= Configuration.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
								}
								if (configuration_ != null)
								{
									output.WriteRawTag(18);
									output.WriteMessage(Configuration);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								if (configuration_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Configuration);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(ConfigureTimer other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
								}
								if (other.configuration_ != null)
								{
									if (configuration_ == null)
									{
										Configuration = new Timer.Types.Configuration();
									}
									Configuration.MergeFrom(other.Configuration);
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
										if (identifier_ == null)
										{
											Identifier = new IndexOrNameIdentifier();
										}
										input.ReadMessage(Identifier);
										break;
									case 18u:
										if (configuration_ == null)
										{
											Configuration = new Timer.Types.Configuration();
										}
										input.ReadMessage(Configuration);
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<API_Timer> _parser = new MessageParser<API_Timer>(() => new API_Timer());

					private UnknownFieldSet _unknownFields;

					public const int StartFieldNumber = 1;

					public const int StopFieldNumber = 2;

					public const int ResetFieldNumber = 3;

					public const int ConfigureFieldNumber = 4;

					private object timerAction_;

					private TimerActionOneofCase timerActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Timer> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[6];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.StartTimer Start
					{
						get
						{
							if (timerActionCase_ != TimerActionOneofCase.Start)
							{
								return null;
							}
							return (Types.StartTimer)timerAction_;
						}
						set
						{
							timerAction_ = value;
							timerActionCase_ = ((value != null) ? TimerActionOneofCase.Start : TimerActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.StopTimer Stop
					{
						get
						{
							if (timerActionCase_ != TimerActionOneofCase.Stop)
							{
								return null;
							}
							return (Types.StopTimer)timerAction_;
						}
						set
						{
							timerAction_ = value;
							timerActionCase_ = ((value != null) ? TimerActionOneofCase.Stop : TimerActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ResetTimer Reset
					{
						get
						{
							if (timerActionCase_ != TimerActionOneofCase.Reset)
							{
								return null;
							}
							return (Types.ResetTimer)timerAction_;
						}
						set
						{
							timerAction_ = value;
							timerActionCase_ = ((value != null) ? TimerActionOneofCase.Reset : TimerActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ConfigureTimer Configure
					{
						get
						{
							if (timerActionCase_ != TimerActionOneofCase.Configure)
							{
								return null;
							}
							return (Types.ConfigureTimer)timerAction_;
						}
						set
						{
							timerAction_ = value;
							timerActionCase_ = ((value != null) ? TimerActionOneofCase.Configure : TimerActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TimerActionOneofCase TimerActionCase => timerActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Timer()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Timer(API_Timer other)
						: this()
					{
						switch (other.TimerActionCase)
						{
						case TimerActionOneofCase.Start:
							Start = other.Start.Clone();
							break;
						case TimerActionOneofCase.Stop:
							Stop = other.Stop.Clone();
							break;
						case TimerActionOneofCase.Reset:
							Reset = other.Reset.Clone();
							break;
						case TimerActionOneofCase.Configure:
							Configure = other.Configure.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Timer Clone()
					{
						return new API_Timer(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearTimerAction()
					{
						timerActionCase_ = TimerActionOneofCase.None;
						timerAction_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Timer);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Timer other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Start, other.Start))
						{
							return false;
						}
						if (!object.Equals(Stop, other.Stop))
						{
							return false;
						}
						if (!object.Equals(Reset, other.Reset))
						{
							return false;
						}
						if (!object.Equals(Configure, other.Configure))
						{
							return false;
						}
						if (TimerActionCase != other.TimerActionCase)
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
						if (timerActionCase_ == TimerActionOneofCase.Start)
						{
							num ^= Start.GetHashCode();
						}
						if (timerActionCase_ == TimerActionOneofCase.Stop)
						{
							num ^= Stop.GetHashCode();
						}
						if (timerActionCase_ == TimerActionOneofCase.Reset)
						{
							num ^= Reset.GetHashCode();
						}
						if (timerActionCase_ == TimerActionOneofCase.Configure)
						{
							num ^= Configure.GetHashCode();
						}
						num ^= (int)timerActionCase_;
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
						if (timerActionCase_ == TimerActionOneofCase.Start)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Start);
						}
						if (timerActionCase_ == TimerActionOneofCase.Stop)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Stop);
						}
						if (timerActionCase_ == TimerActionOneofCase.Reset)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Reset);
						}
						if (timerActionCase_ == TimerActionOneofCase.Configure)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Configure);
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
						if (timerActionCase_ == TimerActionOneofCase.Start)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Start);
						}
						if (timerActionCase_ == TimerActionOneofCase.Stop)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Stop);
						}
						if (timerActionCase_ == TimerActionOneofCase.Reset)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Reset);
						}
						if (timerActionCase_ == TimerActionOneofCase.Configure)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Configure);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Timer other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.TimerActionCase)
						{
						case TimerActionOneofCase.Start:
							if (Start == null)
							{
								Start = new Types.StartTimer();
							}
							Start.MergeFrom(other.Start);
							break;
						case TimerActionOneofCase.Stop:
							if (Stop == null)
							{
								Stop = new Types.StopTimer();
							}
							Stop.MergeFrom(other.Stop);
							break;
						case TimerActionOneofCase.Reset:
							if (Reset == null)
							{
								Reset = new Types.ResetTimer();
							}
							Reset.MergeFrom(other.Reset);
							break;
						case TimerActionOneofCase.Configure:
							if (Configure == null)
							{
								Configure = new Types.ConfigureTimer();
							}
							Configure.MergeFrom(other.Configure);
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
							{
								Types.StartTimer startTimer = new Types.StartTimer();
								if (timerActionCase_ == TimerActionOneofCase.Start)
								{
									startTimer.MergeFrom(Start);
								}
								input.ReadMessage(startTimer);
								Start = startTimer;
								break;
							}
							case 18u:
							{
								Types.StopTimer stopTimer = new Types.StopTimer();
								if (timerActionCase_ == TimerActionOneofCase.Stop)
								{
									stopTimer.MergeFrom(Stop);
								}
								input.ReadMessage(stopTimer);
								Stop = stopTimer;
								break;
							}
							case 26u:
							{
								Types.ResetTimer resetTimer = new Types.ResetTimer();
								if (timerActionCase_ == TimerActionOneofCase.Reset)
								{
									resetTimer.MergeFrom(Reset);
								}
								input.ReadMessage(resetTimer);
								Reset = resetTimer;
								break;
							}
							case 34u:
							{
								Types.ConfigureTimer configureTimer = new Types.ConfigureTimer();
								if (timerActionCase_ == TimerActionOneofCase.Configure)
								{
									configureTimer.MergeFrom(Configure);
								}
								input.ReadMessage(configureTimer);
								Configure = configureTimer;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Message : IMessage<API_Message>, IMessage, IEquatable<API_Message>, IDeepCloneable<API_Message>
				{
					public enum MessageActionOneofCase
					{
						None,
						Trigger,
						Clear
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class TriggerMessage : IMessage<TriggerMessage>, IMessage, IEquatable<TriggerMessage>, IDeepCloneable<TriggerMessage>
						{
							private static readonly MessageParser<TriggerMessage> _parser = new MessageParser<TriggerMessage>(() => new TriggerMessage());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							public const int TokenValuesFieldNumber = 2;

							private static readonly FieldCodec<Message.Types.TokenValue> _repeated_tokenValues_codec = FieldCodec.ForMessage(18u, Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Parser);

							private readonly RepeatedField<Message.Types.TokenValue> tokenValues_ = new RepeatedField<Message.Types.TokenValue>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<TriggerMessage> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Message.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<Message.Types.TokenValue> TokenValues => tokenValues_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TriggerMessage()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TriggerMessage(TriggerMessage other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								tokenValues_ = other.tokenValues_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public TriggerMessage Clone()
							{
								return new TriggerMessage(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as TriggerMessage);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(TriggerMessage other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
								{
									return false;
								}
								if (!tokenValues_.Equals(other.tokenValues_))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
								}
								num ^= tokenValues_.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
								}
								tokenValues_.WriteTo(output, _repeated_tokenValues_codec);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								num += tokenValues_.CalculateSize(_repeated_tokenValues_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(TriggerMessage other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
								}
								tokenValues_.Add(other.tokenValues_);
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
										if (identifier_ == null)
										{
											Identifier = new IndexOrNameIdentifier();
										}
										input.ReadMessage(Identifier);
										break;
									case 18u:
										tokenValues_.AddEntriesFrom(input, _repeated_tokenValues_codec);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class ClearMessage : IMessage<ClearMessage>, IMessage, IEquatable<ClearMessage>, IDeepCloneable<ClearMessage>
						{
							private static readonly MessageParser<ClearMessage> _parser = new MessageParser<ClearMessage>(() => new ClearMessage());

							private UnknownFieldSet _unknownFields;

							public const int IdentifierFieldNumber = 1;

							private IndexOrNameIdentifier identifier_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<ClearMessage> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Message.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IndexOrNameIdentifier Identifier
							{
								get
								{
									return identifier_;
								}
								set
								{
									identifier_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClearMessage()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClearMessage(ClearMessage other)
								: this()
							{
								identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ClearMessage Clone()
							{
								return new ClearMessage(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as ClearMessage);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(ClearMessage other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identifier, other.Identifier))
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
								if (identifier_ != null)
								{
									num ^= Identifier.GetHashCode();
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
								if (identifier_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identifier);
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
								if (identifier_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(ClearMessage other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identifier_ != null)
								{
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									Identifier.MergeFrom(other.Identifier);
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
									if (num != 10)
									{
										_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										continue;
									}
									if (identifier_ == null)
									{
										Identifier = new IndexOrNameIdentifier();
									}
									input.ReadMessage(Identifier);
								}
							}
						}
					}

					private static readonly MessageParser<API_Message> _parser = new MessageParser<API_Message>(() => new API_Message());

					private UnknownFieldSet _unknownFields;

					public const int TriggerFieldNumber = 1;

					public const int ClearFieldNumber = 2;

					private object messageAction_;

					private MessageActionOneofCase messageActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Message> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[7];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.TriggerMessage Trigger
					{
						get
						{
							if (messageActionCase_ != MessageActionOneofCase.Trigger)
							{
								return null;
							}
							return (Types.TriggerMessage)messageAction_;
						}
						set
						{
							messageAction_ = value;
							messageActionCase_ = ((value != null) ? MessageActionOneofCase.Trigger : MessageActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.ClearMessage Clear
					{
						get
						{
							if (messageActionCase_ != MessageActionOneofCase.Clear)
							{
								return null;
							}
							return (Types.ClearMessage)messageAction_;
						}
						set
						{
							messageAction_ = value;
							messageActionCase_ = ((value != null) ? MessageActionOneofCase.Clear : MessageActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MessageActionOneofCase MessageActionCase => messageActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Message()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Message(API_Message other)
						: this()
					{
						switch (other.MessageActionCase)
						{
						case MessageActionOneofCase.Trigger:
							Trigger = other.Trigger.Clone();
							break;
						case MessageActionOneofCase.Clear:
							Clear = other.Clear.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Message Clone()
					{
						return new API_Message(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearMessageAction()
					{
						messageActionCase_ = MessageActionOneofCase.None;
						messageAction_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Message);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Message other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Trigger, other.Trigger))
						{
							return false;
						}
						if (!object.Equals(Clear, other.Clear))
						{
							return false;
						}
						if (MessageActionCase != other.MessageActionCase)
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
						if (messageActionCase_ == MessageActionOneofCase.Trigger)
						{
							num ^= Trigger.GetHashCode();
						}
						if (messageActionCase_ == MessageActionOneofCase.Clear)
						{
							num ^= Clear.GetHashCode();
						}
						num ^= (int)messageActionCase_;
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
						if (messageActionCase_ == MessageActionOneofCase.Trigger)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Trigger);
						}
						if (messageActionCase_ == MessageActionOneofCase.Clear)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Clear);
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
						if (messageActionCase_ == MessageActionOneofCase.Trigger)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
						}
						if (messageActionCase_ == MessageActionOneofCase.Clear)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Clear);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Message other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.MessageActionCase)
						{
						case MessageActionOneofCase.Trigger:
							if (Trigger == null)
							{
								Trigger = new Types.TriggerMessage();
							}
							Trigger.MergeFrom(other.Trigger);
							break;
						case MessageActionOneofCase.Clear:
							if (Clear == null)
							{
								Clear = new Types.ClearMessage();
							}
							Clear.MergeFrom(other.Clear);
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
							{
								Types.TriggerMessage triggerMessage = new Types.TriggerMessage();
								if (messageActionCase_ == MessageActionOneofCase.Trigger)
								{
									triggerMessage.MergeFrom(Trigger);
								}
								input.ReadMessage(triggerMessage);
								Trigger = triggerMessage;
								break;
							}
							case 18u:
							{
								Types.ClearMessage clearMessage = new Types.ClearMessage();
								if (messageActionCase_ == MessageActionOneofCase.Clear)
								{
									clearMessage.MergeFrom(Clear);
								}
								input.ReadMessage(clearMessage);
								Clear = clearMessage;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Macro : IMessage<API_Macro>, IMessage, IEquatable<API_Macro>, IDeepCloneable<API_Macro>
				{
					private static readonly MessageParser<API_Macro> _parser = new MessageParser<API_Macro>(() => new API_Macro());

					private UnknownFieldSet _unknownFields;

					public const int IdentifierFieldNumber = 1;

					private IndexOrNameIdentifier identifier_;

					public const int IndexPathComponentsFieldNumber = 2;

					private static readonly FieldCodec<IndexOrNameIdentifier> _repeated_indexPathComponents_codec = FieldCodec.ForMessage(18u, IndexOrNameIdentifier.Parser);

					private readonly RepeatedField<IndexOrNameIdentifier> indexPathComponents_ = new RepeatedField<IndexOrNameIdentifier>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Macro> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[8];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public IndexOrNameIdentifier Identifier
					{
						get
						{
							return identifier_;
						}
						set
						{
							identifier_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<IndexOrNameIdentifier> IndexPathComponents => indexPathComponents_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Macro()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Macro(API_Macro other)
						: this()
					{
						identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
						indexPathComponents_ = other.indexPathComponents_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Macro Clone()
					{
						return new API_Macro(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Macro);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Macro other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Identifier, other.Identifier))
						{
							return false;
						}
						if (!indexPathComponents_.Equals(other.indexPathComponents_))
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
						if (identifier_ != null)
						{
							num ^= Identifier.GetHashCode();
						}
						num ^= indexPathComponents_.GetHashCode();
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
						if (identifier_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Identifier);
						}
						indexPathComponents_.WriteTo(output, _repeated_indexPathComponents_codec);
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
						if (identifier_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
						}
						num += indexPathComponents_.CalculateSize(_repeated_indexPathComponents_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Macro other)
					{
						if (other == null)
						{
							return;
						}
						if (other.identifier_ != null)
						{
							if (identifier_ == null)
							{
								Identifier = new IndexOrNameIdentifier();
							}
							Identifier.MergeFrom(other.Identifier);
						}
						indexPathComponents_.Add(other.indexPathComponents_);
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
								if (identifier_ == null)
								{
									Identifier = new IndexOrNameIdentifier();
								}
								input.ReadMessage(Identifier);
								break;
							case 18u:
								indexPathComponents_.AddEntriesFrom(input, _repeated_indexPathComponents_codec);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Look : IMessage<API_Look>, IMessage, IEquatable<API_Look>, IDeepCloneable<API_Look>
				{
					private static readonly MessageParser<API_Look> _parser = new MessageParser<API_Look>(() => new API_Look());

					private UnknownFieldSet _unknownFields;

					public const int IdentifierFieldNumber = 1;

					private IndexOrNameIdentifier identifier_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Look> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[9];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public IndexOrNameIdentifier Identifier
					{
						get
						{
							return identifier_;
						}
						set
						{
							identifier_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Look()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Look(API_Look other)
						: this()
					{
						identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Look Clone()
					{
						return new API_Look(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Look);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Look other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Identifier, other.Identifier))
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
						if (identifier_ != null)
						{
							num ^= Identifier.GetHashCode();
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
						if (identifier_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Identifier);
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
						if (identifier_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Look other)
					{
						if (other == null)
						{
							return;
						}
						if (other.identifier_ != null)
						{
							if (identifier_ == null)
							{
								Identifier = new IndexOrNameIdentifier();
							}
							Identifier.MergeFrom(other.Identifier);
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								continue;
							}
							if (identifier_ == null)
							{
								Identifier = new IndexOrNameIdentifier();
							}
							input.ReadMessage(Identifier);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Stage : IMessage<API_Stage>, IMessage, IEquatable<API_Stage>, IDeepCloneable<API_Stage>
				{
					public enum StageActionOneofCase
					{
						None,
						Layouts,
						Message
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class StageLayouts : IMessage<StageLayouts>, IMessage, IEquatable<StageLayouts>, IDeepCloneable<StageLayouts>
						{
							private static readonly MessageParser<StageLayouts> _parser = new MessageParser<StageLayouts>(() => new StageLayouts());

							private UnknownFieldSet _unknownFields;

							public const int LayoutsFieldNumber = 1;

							private static readonly FieldCodec<IndexOrNameIdentifierPair> _repeated_layouts_codec = FieldCodec.ForMessage(10u, IndexOrNameIdentifierPair.Parser);

							private readonly RepeatedField<IndexOrNameIdentifierPair> layouts_ = new RepeatedField<IndexOrNameIdentifierPair>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<StageLayouts> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Stage.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<IndexOrNameIdentifierPair> Layouts => layouts_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageLayouts()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageLayouts(StageLayouts other)
								: this()
							{
								layouts_ = other.layouts_.Clone();
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageLayouts Clone()
							{
								return new StageLayouts(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as StageLayouts);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(StageLayouts other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!layouts_.Equals(other.layouts_))
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
								num ^= layouts_.GetHashCode();
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
								layouts_.WriteTo(output, _repeated_layouts_codec);
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
								num += layouts_.CalculateSize(_repeated_layouts_codec);
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(StageLayouts other)
							{
								if (other != null)
								{
									layouts_.Add(other.layouts_);
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
										layouts_.AddEntriesFrom(input, _repeated_layouts_codec);
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class StageMessage : IMessage<StageMessage>, IMessage, IEquatable<StageMessage>, IDeepCloneable<StageMessage>
						{
							public enum ActionOneofCase
							{
								None,
								ShowMessage,
								ClearMessage,
								HideMessage
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class ShowMessage : IMessage<ShowMessage>, IMessage, IEquatable<ShowMessage>, IDeepCloneable<ShowMessage>
								{
									private static readonly MessageParser<ShowMessage> _parser = new MessageParser<ShowMessage>(() => new ShowMessage());

									private UnknownFieldSet _unknownFields;

									public const int MessageFieldNumber = 1;

									private string message_ = "";

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<ShowMessage> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => StageMessage.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public string Message
									{
										get
										{
											return message_;
										}
										set
										{
											message_ = ProtoPreconditions.CheckNotNull(value, "value");
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ShowMessage()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ShowMessage(ShowMessage other)
										: this()
									{
										message_ = other.message_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ShowMessage Clone()
									{
										return new ShowMessage(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as ShowMessage);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(ShowMessage other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (Message != other.Message)
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
										if (Message.Length != 0)
										{
											num ^= Message.GetHashCode();
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
										if (Message.Length != 0)
										{
											output.WriteRawTag(10);
											output.WriteString(Message);
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
										if (Message.Length != 0)
										{
											num += 1 + CodedOutputStream.ComputeStringSize(Message);
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(ShowMessage other)
									{
										if (other != null)
										{
											if (other.Message.Length != 0)
											{
												Message = other.Message;
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
												Message = input.ReadString();
											}
										}
									}
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class ClearMessage : IMessage<ClearMessage>, IMessage, IEquatable<ClearMessage>, IDeepCloneable<ClearMessage>
								{
									private static readonly MessageParser<ClearMessage> _parser = new MessageParser<ClearMessage>(() => new ClearMessage());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<ClearMessage> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => StageMessage.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ClearMessage()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ClearMessage(ClearMessage other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public ClearMessage Clone()
									{
										return new ClearMessage(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as ClearMessage);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(ClearMessage other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										return object.Equals(_unknownFields, other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override int GetHashCode()
									{
										int num = 1;
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
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(ClearMessage other)
									{
										if (other != null)
										{
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
											_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										}
									}
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class HideMessage : IMessage<HideMessage>, IMessage, IEquatable<HideMessage>, IDeepCloneable<HideMessage>
								{
									private static readonly MessageParser<HideMessage> _parser = new MessageParser<HideMessage>(() => new HideMessage());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<HideMessage> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => StageMessage.Descriptor.NestedTypes[2];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public HideMessage()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public HideMessage(HideMessage other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public HideMessage Clone()
									{
										return new HideMessage(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as HideMessage);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(HideMessage other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										return object.Equals(_unknownFields, other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override int GetHashCode()
									{
										int num = 1;
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
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(HideMessage other)
									{
										if (other != null)
										{
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
											_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
										}
									}
								}
							}

							private static readonly MessageParser<StageMessage> _parser = new MessageParser<StageMessage>(() => new StageMessage());

							private UnknownFieldSet _unknownFields;

							public const int ShowMessageFieldNumber = 1;

							public const int ClearMessageFieldNumber = 2;

							public const int HideMessageFieldNumber = 3;

							private object action_;

							private ActionOneofCase actionCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<StageMessage> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => API_Stage.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.ShowMessage ShowMessage
							{
								get
								{
									if (actionCase_ != ActionOneofCase.ShowMessage)
									{
										return null;
									}
									return (Types.ShowMessage)action_;
								}
								set
								{
									action_ = value;
									actionCase_ = ((value != null) ? ActionOneofCase.ShowMessage : ActionOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.ClearMessage ClearMessage
							{
								get
								{
									if (actionCase_ != ActionOneofCase.ClearMessage)
									{
										return null;
									}
									return (Types.ClearMessage)action_;
								}
								set
								{
									action_ = value;
									actionCase_ = ((value != null) ? ActionOneofCase.ClearMessage : ActionOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.HideMessage HideMessage
							{
								get
								{
									if (actionCase_ != ActionOneofCase.HideMessage)
									{
										return null;
									}
									return (Types.HideMessage)action_;
								}
								set
								{
									action_ = value;
									actionCase_ = ((value != null) ? ActionOneofCase.HideMessage : ActionOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ActionOneofCase ActionCase => actionCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageMessage()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageMessage(StageMessage other)
								: this()
							{
								switch (other.ActionCase)
								{
								case ActionOneofCase.ShowMessage:
									ShowMessage = other.ShowMessage.Clone();
									break;
								case ActionOneofCase.ClearMessage:
									ClearMessage = other.ClearMessage.Clone();
									break;
								case ActionOneofCase.HideMessage:
									HideMessage = other.HideMessage.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public StageMessage Clone()
							{
								return new StageMessage(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearAction()
							{
								actionCase_ = ActionOneofCase.None;
								action_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as StageMessage);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(StageMessage other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(ShowMessage, other.ShowMessage))
								{
									return false;
								}
								if (!object.Equals(ClearMessage, other.ClearMessage))
								{
									return false;
								}
								if (!object.Equals(HideMessage, other.HideMessage))
								{
									return false;
								}
								if (ActionCase != other.ActionCase)
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
								if (actionCase_ == ActionOneofCase.ShowMessage)
								{
									num ^= ShowMessage.GetHashCode();
								}
								if (actionCase_ == ActionOneofCase.ClearMessage)
								{
									num ^= ClearMessage.GetHashCode();
								}
								if (actionCase_ == ActionOneofCase.HideMessage)
								{
									num ^= HideMessage.GetHashCode();
								}
								num ^= (int)actionCase_;
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
								if (actionCase_ == ActionOneofCase.ShowMessage)
								{
									output.WriteRawTag(10);
									output.WriteMessage(ShowMessage);
								}
								if (actionCase_ == ActionOneofCase.ClearMessage)
								{
									output.WriteRawTag(18);
									output.WriteMessage(ClearMessage);
								}
								if (actionCase_ == ActionOneofCase.HideMessage)
								{
									output.WriteRawTag(26);
									output.WriteMessage(HideMessage);
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
								if (actionCase_ == ActionOneofCase.ShowMessage)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(ShowMessage);
								}
								if (actionCase_ == ActionOneofCase.ClearMessage)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(ClearMessage);
								}
								if (actionCase_ == ActionOneofCase.HideMessage)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(HideMessage);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(StageMessage other)
							{
								if (other == null)
								{
									return;
								}
								switch (other.ActionCase)
								{
								case ActionOneofCase.ShowMessage:
									if (ShowMessage == null)
									{
										ShowMessage = new Types.ShowMessage();
									}
									ShowMessage.MergeFrom(other.ShowMessage);
									break;
								case ActionOneofCase.ClearMessage:
									if (ClearMessage == null)
									{
										ClearMessage = new Types.ClearMessage();
									}
									ClearMessage.MergeFrom(other.ClearMessage);
									break;
								case ActionOneofCase.HideMessage:
									if (HideMessage == null)
									{
										HideMessage = new Types.HideMessage();
									}
									HideMessage.MergeFrom(other.HideMessage);
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
									{
										Types.ShowMessage showMessage = new Types.ShowMessage();
										if (actionCase_ == ActionOneofCase.ShowMessage)
										{
											showMessage.MergeFrom(ShowMessage);
										}
										input.ReadMessage(showMessage);
										ShowMessage = showMessage;
										break;
									}
									case 18u:
									{
										Types.ClearMessage clearMessage = new Types.ClearMessage();
										if (actionCase_ == ActionOneofCase.ClearMessage)
										{
											clearMessage.MergeFrom(ClearMessage);
										}
										input.ReadMessage(clearMessage);
										ClearMessage = clearMessage;
										break;
									}
									case 26u:
									{
										Types.HideMessage hideMessage = new Types.HideMessage();
										if (actionCase_ == ActionOneofCase.HideMessage)
										{
											hideMessage.MergeFrom(HideMessage);
										}
										input.ReadMessage(hideMessage);
										HideMessage = hideMessage;
										break;
									}
									}
								}
							}
						}
					}

					private static readonly MessageParser<API_Stage> _parser = new MessageParser<API_Stage>(() => new API_Stage());

					private UnknownFieldSet _unknownFields;

					public const int LayoutsFieldNumber = 1;

					public const int MessageFieldNumber = 2;

					private object stageAction_;

					private StageActionOneofCase stageActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Stage> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[10];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.StageLayouts Layouts
					{
						get
						{
							if (stageActionCase_ != StageActionOneofCase.Layouts)
							{
								return null;
							}
							return (Types.StageLayouts)stageAction_;
						}
						set
						{
							stageAction_ = value;
							stageActionCase_ = ((value != null) ? StageActionOneofCase.Layouts : StageActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.StageMessage Message
					{
						get
						{
							if (stageActionCase_ != StageActionOneofCase.Message)
							{
								return null;
							}
							return (Types.StageMessage)stageAction_;
						}
						set
						{
							stageAction_ = value;
							stageActionCase_ = ((value != null) ? StageActionOneofCase.Message : StageActionOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StageActionOneofCase StageActionCase => stageActionCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Stage()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Stage(API_Stage other)
						: this()
					{
						switch (other.StageActionCase)
						{
						case StageActionOneofCase.Layouts:
							Layouts = other.Layouts.Clone();
							break;
						case StageActionOneofCase.Message:
							Message = other.Message.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Stage Clone()
					{
						return new API_Stage(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearStageAction()
					{
						stageActionCase_ = StageActionOneofCase.None;
						stageAction_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Stage);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Stage other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Layouts, other.Layouts))
						{
							return false;
						}
						if (!object.Equals(Message, other.Message))
						{
							return false;
						}
						if (StageActionCase != other.StageActionCase)
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
						if (stageActionCase_ == StageActionOneofCase.Layouts)
						{
							num ^= Layouts.GetHashCode();
						}
						if (stageActionCase_ == StageActionOneofCase.Message)
						{
							num ^= Message.GetHashCode();
						}
						num ^= (int)stageActionCase_;
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
						if (stageActionCase_ == StageActionOneofCase.Layouts)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Layouts);
						}
						if (stageActionCase_ == StageActionOneofCase.Message)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Message);
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
						if (stageActionCase_ == StageActionOneofCase.Layouts)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Layouts);
						}
						if (stageActionCase_ == StageActionOneofCase.Message)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Message);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Stage other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.StageActionCase)
						{
						case StageActionOneofCase.Layouts:
							if (Layouts == null)
							{
								Layouts = new Types.StageLayouts();
							}
							Layouts.MergeFrom(other.Layouts);
							break;
						case StageActionOneofCase.Message:
							if (Message == null)
							{
								Message = new Types.StageMessage();
							}
							Message.MergeFrom(other.Message);
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
							{
								Types.StageLayouts stageLayouts = new Types.StageLayouts();
								if (stageActionCase_ == StageActionOneofCase.Layouts)
								{
									stageLayouts.MergeFrom(Layouts);
								}
								input.ReadMessage(stageLayouts);
								Layouts = stageLayouts;
								break;
							}
							case 18u:
							{
								Types.StageMessage stageMessage = new Types.StageMessage();
								if (stageActionCase_ == StageActionOneofCase.Message)
								{
									stageMessage.MergeFrom(Message);
								}
								input.ReadMessage(stageMessage);
								Message = stageMessage;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class StatusRequest : IMessage<StatusRequest>, IMessage, IEquatable<StatusRequest>, IDeepCloneable<StatusRequest>
				{
					private static readonly MessageParser<StatusRequest> _parser = new MessageParser<StatusRequest>(() => new StatusRequest());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<StatusRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[11];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StatusRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StatusRequest(StatusRequest other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StatusRequest Clone()
					{
						return new StatusRequest(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as StatusRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(StatusRequest other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(StatusRequest other)
					{
						if (other != null)
						{
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
							_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_Status : IMessage<API_Status>, IMessage, IEquatable<API_Status>, IDeepCloneable<API_Status>
				{
					private static readonly MessageParser<API_Status> _parser = new MessageParser<API_Status>(() => new API_Status());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_Status> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[12];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Status()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Status(API_Status other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_Status Clone()
					{
						return new API_Status(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_Status);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_Status other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						return object.Equals(_unknownFields, other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override int GetHashCode()
					{
						int num = 1;
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_Status other)
					{
						if (other != null)
						{
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
							_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class API_StatusResponse : IMessage<API_StatusResponse>, IMessage, IEquatable<API_StatusResponse>, IDeepCloneable<API_StatusResponse>
				{
					private static readonly MessageParser<API_StatusResponse> _parser = new MessageParser<API_StatusResponse>(() => new API_StatusResponse());

					private UnknownFieldSet _unknownFields;

					public const int GroupDefinitionFieldNumber = 1;

					private ProLink.Types.GroupDefinition groupDefinition_;

					public const int StatusFieldNumber = 2;

					private ProLink.Types.MemberStatus status_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<API_StatusResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[13];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProLink.Types.GroupDefinition GroupDefinition
					{
						get
						{
							return groupDefinition_;
						}
						set
						{
							groupDefinition_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProLink.Types.MemberStatus Status
					{
						get
						{
							return status_;
						}
						set
						{
							status_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_StatusResponse()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_StatusResponse(API_StatusResponse other)
						: this()
					{
						groupDefinition_ = ((other.groupDefinition_ != null) ? other.groupDefinition_.Clone() : null);
						status_ = ((other.status_ != null) ? other.status_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_StatusResponse Clone()
					{
						return new API_StatusResponse(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as API_StatusResponse);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(API_StatusResponse other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(GroupDefinition, other.GroupDefinition))
						{
							return false;
						}
						if (!object.Equals(Status, other.Status))
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
						if (groupDefinition_ != null)
						{
							num ^= GroupDefinition.GetHashCode();
						}
						if (status_ != null)
						{
							num ^= Status.GetHashCode();
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
						if (groupDefinition_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(GroupDefinition);
						}
						if (status_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Status);
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
						if (groupDefinition_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
						}
						if (status_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Status);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(API_StatusResponse other)
					{
						if (other == null)
						{
							return;
						}
						if (other.groupDefinition_ != null)
						{
							if (groupDefinition_ == null)
							{
								GroupDefinition = new ProLink.Types.GroupDefinition();
							}
							GroupDefinition.MergeFrom(other.GroupDefinition);
						}
						if (other.status_ != null)
						{
							if (status_ == null)
							{
								Status = new ProLink.Types.MemberStatus();
							}
							Status.MergeFrom(other.Status);
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
								if (groupDefinition_ == null)
								{
									GroupDefinition = new ProLink.Types.GroupDefinition();
								}
								input.ReadMessage(GroupDefinition);
								break;
							case 18u:
								if (status_ == null)
								{
									Status = new ProLink.Types.MemberStatus();
								}
								input.ReadMessage(Status);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Action> _parser = new MessageParser<Action>(() => new Action());

			private UnknownFieldSet _unknownFields;

			public const int ClearFieldNumber = 1;

			public const int TriggerFieldNumber = 2;

			public const int TransportFieldNumber = 3;

			public const int PropFieldNumber = 4;

			public const int TimerFieldNumber = 5;

			public const int MessageFieldNumber = 6;

			public const int MacroFieldNumber = 7;

			public const int LookFieldNumber = 8;

			public const int StageFieldNumber = 9;

			public const int StatusFieldNumber = 10;

			public const int StatusResponseFieldNumber = 11;

			public const int TwoStepTriggerFieldNumber = 12;

			public const int PrerollCompleteFieldNumber = 13;

			private object command_;

			private CommandOneofCase commandCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Action> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Clear Clear
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Clear)
					{
						return null;
					}
					return (Types.API_Clear)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Clear : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Trigger Trigger
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Trigger)
					{
						return null;
					}
					return (Types.API_Trigger)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Trigger : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Transport Transport
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Transport)
					{
						return null;
					}
					return (Types.API_Transport)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Transport : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Prop Prop
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Prop)
					{
						return null;
					}
					return (Types.API_Prop)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Prop : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Timer Timer
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Timer)
					{
						return null;
					}
					return (Types.API_Timer)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Timer : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Message Message
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Message)
					{
						return null;
					}
					return (Types.API_Message)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Message : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Macro Macro
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Macro)
					{
						return null;
					}
					return (Types.API_Macro)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Macro : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Look Look
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Look)
					{
						return null;
					}
					return (Types.API_Look)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Look : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Stage Stage
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Stage)
					{
						return null;
					}
					return (Types.API_Stage)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Stage : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_Status Status
			{
				get
				{
					if (commandCase_ != CommandOneofCase.Status)
					{
						return null;
					}
					return (Types.API_Status)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.Status : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_StatusResponse StatusResponse
			{
				get
				{
					if (commandCase_ != CommandOneofCase.StatusResponse)
					{
						return null;
					}
					return (Types.API_StatusResponse)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.StatusResponse : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_TwoStepTrigger TwoStepTrigger
			{
				get
				{
					if (commandCase_ != CommandOneofCase.TwoStepTrigger)
					{
						return null;
					}
					return (Types.API_TwoStepTrigger)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.TwoStepTrigger : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.API_PrerollComplete PrerollComplete
			{
				get
				{
					if (commandCase_ != CommandOneofCase.PrerollComplete)
					{
						return null;
					}
					return (Types.API_PrerollComplete)command_;
				}
				set
				{
					command_ = value;
					commandCase_ = ((value != null) ? CommandOneofCase.PrerollComplete : CommandOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CommandOneofCase CommandCase => commandCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action(Action other)
				: this()
			{
				switch (other.CommandCase)
				{
				case CommandOneofCase.Clear:
					Clear = other.Clear.Clone();
					break;
				case CommandOneofCase.Trigger:
					Trigger = other.Trigger.Clone();
					break;
				case CommandOneofCase.Transport:
					Transport = other.Transport.Clone();
					break;
				case CommandOneofCase.Prop:
					Prop = other.Prop.Clone();
					break;
				case CommandOneofCase.Timer:
					Timer = other.Timer.Clone();
					break;
				case CommandOneofCase.Message:
					Message = other.Message.Clone();
					break;
				case CommandOneofCase.Macro:
					Macro = other.Macro.Clone();
					break;
				case CommandOneofCase.Look:
					Look = other.Look.Clone();
					break;
				case CommandOneofCase.Stage:
					Stage = other.Stage.Clone();
					break;
				case CommandOneofCase.Status:
					Status = other.Status.Clone();
					break;
				case CommandOneofCase.StatusResponse:
					StatusResponse = other.StatusResponse.Clone();
					break;
				case CommandOneofCase.TwoStepTrigger:
					TwoStepTrigger = other.TwoStepTrigger.Clone();
					break;
				case CommandOneofCase.PrerollComplete:
					PrerollComplete = other.PrerollComplete.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action Clone()
			{
				return new Action(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearCommand()
			{
				commandCase_ = CommandOneofCase.None;
				command_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Action);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Action other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Clear, other.Clear))
				{
					return false;
				}
				if (!object.Equals(Trigger, other.Trigger))
				{
					return false;
				}
				if (!object.Equals(Transport, other.Transport))
				{
					return false;
				}
				if (!object.Equals(Prop, other.Prop))
				{
					return false;
				}
				if (!object.Equals(Timer, other.Timer))
				{
					return false;
				}
				if (!object.Equals(Message, other.Message))
				{
					return false;
				}
				if (!object.Equals(Macro, other.Macro))
				{
					return false;
				}
				if (!object.Equals(Look, other.Look))
				{
					return false;
				}
				if (!object.Equals(Stage, other.Stage))
				{
					return false;
				}
				if (!object.Equals(Status, other.Status))
				{
					return false;
				}
				if (!object.Equals(StatusResponse, other.StatusResponse))
				{
					return false;
				}
				if (!object.Equals(TwoStepTrigger, other.TwoStepTrigger))
				{
					return false;
				}
				if (!object.Equals(PrerollComplete, other.PrerollComplete))
				{
					return false;
				}
				if (CommandCase != other.CommandCase)
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
				if (commandCase_ == CommandOneofCase.Clear)
				{
					num ^= Clear.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Trigger)
				{
					num ^= Trigger.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Transport)
				{
					num ^= Transport.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Prop)
				{
					num ^= Prop.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Timer)
				{
					num ^= Timer.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Message)
				{
					num ^= Message.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Macro)
				{
					num ^= Macro.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Look)
				{
					num ^= Look.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Stage)
				{
					num ^= Stage.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.Status)
				{
					num ^= Status.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.StatusResponse)
				{
					num ^= StatusResponse.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.TwoStepTrigger)
				{
					num ^= TwoStepTrigger.GetHashCode();
				}
				if (commandCase_ == CommandOneofCase.PrerollComplete)
				{
					num ^= PrerollComplete.GetHashCode();
				}
				num ^= (int)commandCase_;
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
				if (commandCase_ == CommandOneofCase.Clear)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Clear);
				}
				if (commandCase_ == CommandOneofCase.Trigger)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Trigger);
				}
				if (commandCase_ == CommandOneofCase.Transport)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Transport);
				}
				if (commandCase_ == CommandOneofCase.Prop)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Prop);
				}
				if (commandCase_ == CommandOneofCase.Timer)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Timer);
				}
				if (commandCase_ == CommandOneofCase.Message)
				{
					output.WriteRawTag(50);
					output.WriteMessage(Message);
				}
				if (commandCase_ == CommandOneofCase.Macro)
				{
					output.WriteRawTag(58);
					output.WriteMessage(Macro);
				}
				if (commandCase_ == CommandOneofCase.Look)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Look);
				}
				if (commandCase_ == CommandOneofCase.Stage)
				{
					output.WriteRawTag(74);
					output.WriteMessage(Stage);
				}
				if (commandCase_ == CommandOneofCase.Status)
				{
					output.WriteRawTag(82);
					output.WriteMessage(Status);
				}
				if (commandCase_ == CommandOneofCase.StatusResponse)
				{
					output.WriteRawTag(90);
					output.WriteMessage(StatusResponse);
				}
				if (commandCase_ == CommandOneofCase.TwoStepTrigger)
				{
					output.WriteRawTag(98);
					output.WriteMessage(TwoStepTrigger);
				}
				if (commandCase_ == CommandOneofCase.PrerollComplete)
				{
					output.WriteRawTag(106);
					output.WriteMessage(PrerollComplete);
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
				if (commandCase_ == CommandOneofCase.Clear)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Clear);
				}
				if (commandCase_ == CommandOneofCase.Trigger)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
				}
				if (commandCase_ == CommandOneofCase.Transport)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Transport);
				}
				if (commandCase_ == CommandOneofCase.Prop)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Prop);
				}
				if (commandCase_ == CommandOneofCase.Timer)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (commandCase_ == CommandOneofCase.Message)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Message);
				}
				if (commandCase_ == CommandOneofCase.Macro)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Macro);
				}
				if (commandCase_ == CommandOneofCase.Look)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Look);
				}
				if (commandCase_ == CommandOneofCase.Stage)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Stage);
				}
				if (commandCase_ == CommandOneofCase.Status)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Status);
				}
				if (commandCase_ == CommandOneofCase.StatusResponse)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(StatusResponse);
				}
				if (commandCase_ == CommandOneofCase.TwoStepTrigger)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TwoStepTrigger);
				}
				if (commandCase_ == CommandOneofCase.PrerollComplete)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PrerollComplete);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Action other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.CommandCase)
				{
				case CommandOneofCase.Clear:
					if (Clear == null)
					{
						Clear = new Types.API_Clear();
					}
					Clear.MergeFrom(other.Clear);
					break;
				case CommandOneofCase.Trigger:
					if (Trigger == null)
					{
						Trigger = new Types.API_Trigger();
					}
					Trigger.MergeFrom(other.Trigger);
					break;
				case CommandOneofCase.Transport:
					if (Transport == null)
					{
						Transport = new Types.API_Transport();
					}
					Transport.MergeFrom(other.Transport);
					break;
				case CommandOneofCase.Prop:
					if (Prop == null)
					{
						Prop = new Types.API_Prop();
					}
					Prop.MergeFrom(other.Prop);
					break;
				case CommandOneofCase.Timer:
					if (Timer == null)
					{
						Timer = new Types.API_Timer();
					}
					Timer.MergeFrom(other.Timer);
					break;
				case CommandOneofCase.Message:
					if (Message == null)
					{
						Message = new Types.API_Message();
					}
					Message.MergeFrom(other.Message);
					break;
				case CommandOneofCase.Macro:
					if (Macro == null)
					{
						Macro = new Types.API_Macro();
					}
					Macro.MergeFrom(other.Macro);
					break;
				case CommandOneofCase.Look:
					if (Look == null)
					{
						Look = new Types.API_Look();
					}
					Look.MergeFrom(other.Look);
					break;
				case CommandOneofCase.Stage:
					if (Stage == null)
					{
						Stage = new Types.API_Stage();
					}
					Stage.MergeFrom(other.Stage);
					break;
				case CommandOneofCase.Status:
					if (Status == null)
					{
						Status = new Types.API_Status();
					}
					Status.MergeFrom(other.Status);
					break;
				case CommandOneofCase.StatusResponse:
					if (StatusResponse == null)
					{
						StatusResponse = new Types.API_StatusResponse();
					}
					StatusResponse.MergeFrom(other.StatusResponse);
					break;
				case CommandOneofCase.TwoStepTrigger:
					if (TwoStepTrigger == null)
					{
						TwoStepTrigger = new Types.API_TwoStepTrigger();
					}
					TwoStepTrigger.MergeFrom(other.TwoStepTrigger);
					break;
				case CommandOneofCase.PrerollComplete:
					if (PrerollComplete == null)
					{
						PrerollComplete = new Types.API_PrerollComplete();
					}
					PrerollComplete.MergeFrom(other.PrerollComplete);
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
					{
						Types.API_Clear aPI_Clear = new Types.API_Clear();
						if (commandCase_ == CommandOneofCase.Clear)
						{
							aPI_Clear.MergeFrom(Clear);
						}
						input.ReadMessage(aPI_Clear);
						Clear = aPI_Clear;
						break;
					}
					case 18u:
					{
						Types.API_Trigger aPI_Trigger = new Types.API_Trigger();
						if (commandCase_ == CommandOneofCase.Trigger)
						{
							aPI_Trigger.MergeFrom(Trigger);
						}
						input.ReadMessage(aPI_Trigger);
						Trigger = aPI_Trigger;
						break;
					}
					case 26u:
					{
						Types.API_Transport aPI_Transport = new Types.API_Transport();
						if (commandCase_ == CommandOneofCase.Transport)
						{
							aPI_Transport.MergeFrom(Transport);
						}
						input.ReadMessage(aPI_Transport);
						Transport = aPI_Transport;
						break;
					}
					case 34u:
					{
						Types.API_Prop aPI_Prop = new Types.API_Prop();
						if (commandCase_ == CommandOneofCase.Prop)
						{
							aPI_Prop.MergeFrom(Prop);
						}
						input.ReadMessage(aPI_Prop);
						Prop = aPI_Prop;
						break;
					}
					case 42u:
					{
						Types.API_Timer aPI_Timer = new Types.API_Timer();
						if (commandCase_ == CommandOneofCase.Timer)
						{
							aPI_Timer.MergeFrom(Timer);
						}
						input.ReadMessage(aPI_Timer);
						Timer = aPI_Timer;
						break;
					}
					case 50u:
					{
						Types.API_Message aPI_Message = new Types.API_Message();
						if (commandCase_ == CommandOneofCase.Message)
						{
							aPI_Message.MergeFrom(Message);
						}
						input.ReadMessage(aPI_Message);
						Message = aPI_Message;
						break;
					}
					case 58u:
					{
						Types.API_Macro aPI_Macro = new Types.API_Macro();
						if (commandCase_ == CommandOneofCase.Macro)
						{
							aPI_Macro.MergeFrom(Macro);
						}
						input.ReadMessage(aPI_Macro);
						Macro = aPI_Macro;
						break;
					}
					case 66u:
					{
						Types.API_Look aPI_Look = new Types.API_Look();
						if (commandCase_ == CommandOneofCase.Look)
						{
							aPI_Look.MergeFrom(Look);
						}
						input.ReadMessage(aPI_Look);
						Look = aPI_Look;
						break;
					}
					case 74u:
					{
						Types.API_Stage aPI_Stage = new Types.API_Stage();
						if (commandCase_ == CommandOneofCase.Stage)
						{
							aPI_Stage.MergeFrom(Stage);
						}
						input.ReadMessage(aPI_Stage);
						Stage = aPI_Stage;
						break;
					}
					case 82u:
					{
						Types.API_Status aPI_Status = new Types.API_Status();
						if (commandCase_ == CommandOneofCase.Status)
						{
							aPI_Status.MergeFrom(Status);
						}
						input.ReadMessage(aPI_Status);
						Status = aPI_Status;
						break;
					}
					case 90u:
					{
						Types.API_StatusResponse aPI_StatusResponse = new Types.API_StatusResponse();
						if (commandCase_ == CommandOneofCase.StatusResponse)
						{
							aPI_StatusResponse.MergeFrom(StatusResponse);
						}
						input.ReadMessage(aPI_StatusResponse);
						StatusResponse = aPI_StatusResponse;
						break;
					}
					case 98u:
					{
						Types.API_TwoStepTrigger aPI_TwoStepTrigger = new Types.API_TwoStepTrigger();
						if (commandCase_ == CommandOneofCase.TwoStepTrigger)
						{
							aPI_TwoStepTrigger.MergeFrom(TwoStepTrigger);
						}
						input.ReadMessage(aPI_TwoStepTrigger);
						TwoStepTrigger = aPI_TwoStepTrigger;
						break;
					}
					case 106u:
					{
						Types.API_PrerollComplete aPI_PrerollComplete = new Types.API_PrerollComplete();
						if (commandCase_ == CommandOneofCase.PrerollComplete)
						{
							aPI_PrerollComplete.MergeFrom(PrerollComplete);
						}
						input.ReadMessage(aPI_PrerollComplete);
						PrerollComplete = aPI_PrerollComplete;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class IndexOrNameIdentifier : IMessage<IndexOrNameIdentifier>, IMessage, IEquatable<IndexOrNameIdentifier>, IDeepCloneable<IndexOrNameIdentifier>
		{
			public enum ComponentOneofCase
			{
				None,
				Index,
				Name
			}

			private static readonly MessageParser<IndexOrNameIdentifier> _parser = new MessageParser<IndexOrNameIdentifier>(() => new IndexOrNameIdentifier());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			public const int NameFieldNumber = 2;

			private object component_;

			private ComponentOneofCase componentCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IndexOrNameIdentifier> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Index
			{
				get
				{
					if (!HasIndex)
					{
						return 0;
					}
					return (int)component_;
				}
				set
				{
					component_ = value;
					componentCase_ = ComponentOneofCase.Index;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasIndex => componentCase_ == ComponentOneofCase.Index;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Name
			{
				get
				{
					if (!HasName)
					{
						return "";
					}
					return (string)component_;
				}
				set
				{
					component_ = ProtoPreconditions.CheckNotNull(value, "value");
					componentCase_ = ComponentOneofCase.Name;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasName => componentCase_ == ComponentOneofCase.Name;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ComponentOneofCase ComponentCase => componentCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifier()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifier(IndexOrNameIdentifier other)
				: this()
			{
				switch (other.ComponentCase)
				{
				case ComponentOneofCase.Index:
					Index = other.Index;
					break;
				case ComponentOneofCase.Name:
					Name = other.Name;
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifier Clone()
			{
				return new IndexOrNameIdentifier(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearIndex()
			{
				if (HasIndex)
				{
					ClearComponent();
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearName()
			{
				if (HasName)
				{
					ClearComponent();
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearComponent()
			{
				componentCase_ = ComponentOneofCase.None;
				component_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IndexOrNameIdentifier);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IndexOrNameIdentifier other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Index != other.Index)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (ComponentCase != other.ComponentCase)
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
				if (HasIndex)
				{
					num ^= Index.GetHashCode();
				}
				if (HasName)
				{
					num ^= Name.GetHashCode();
				}
				num ^= (int)componentCase_;
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
				if (HasIndex)
				{
					output.WriteRawTag(8);
					output.WriteInt32(Index);
				}
				if (HasName)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
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
				if (HasIndex)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Index);
				}
				if (HasName)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(IndexOrNameIdentifier other)
			{
				if (other != null)
				{
					switch (other.ComponentCase)
					{
					case ComponentOneofCase.Index:
						Index = other.Index;
						break;
					case ComponentOneofCase.Name:
						Name = other.Name;
						break;
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
						Index = input.ReadInt32();
						break;
					case 18u:
						Name = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class IndexOrNameIdentifierPair : IMessage<IndexOrNameIdentifierPair>, IMessage, IEquatable<IndexOrNameIdentifierPair>, IDeepCloneable<IndexOrNameIdentifierPair>
		{
			private static readonly MessageParser<IndexOrNameIdentifierPair> _parser = new MessageParser<IndexOrNameIdentifierPair>(() => new IndexOrNameIdentifierPair());

			private UnknownFieldSet _unknownFields;

			public const int KeyFieldNumber = 1;

			private IndexOrNameIdentifier key_;

			public const int ValueFieldNumber = 2;

			private IndexOrNameIdentifier value_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IndexOrNameIdentifierPair> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifier Key
			{
				get
				{
					return key_;
				}
				set
				{
					key_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifier Value
			{
				get
				{
					return value_;
				}
				set
				{
					value_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifierPair()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifierPair(IndexOrNameIdentifierPair other)
				: this()
			{
				key_ = ((other.key_ != null) ? other.key_.Clone() : null);
				value_ = ((other.value_ != null) ? other.value_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IndexOrNameIdentifierPair Clone()
			{
				return new IndexOrNameIdentifierPair(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IndexOrNameIdentifierPair);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IndexOrNameIdentifierPair other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Key, other.Key))
				{
					return false;
				}
				if (!object.Equals(Value, other.Value))
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
				if (key_ != null)
				{
					num ^= Key.GetHashCode();
				}
				if (value_ != null)
				{
					num ^= Value.GetHashCode();
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
				if (key_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Key);
				}
				if (value_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Value);
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
				if (key_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Key);
				}
				if (value_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Value);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(IndexOrNameIdentifierPair other)
			{
				if (other == null)
				{
					return;
				}
				if (other.key_ != null)
				{
					if (key_ == null)
					{
						Key = new IndexOrNameIdentifier();
					}
					Key.MergeFrom(other.Key);
				}
				if (other.value_ != null)
				{
					if (value_ == null)
					{
						Value = new IndexOrNameIdentifier();
					}
					Value.MergeFrom(other.Value);
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
						if (key_ == null)
						{
							Key = new IndexOrNameIdentifier();
						}
						input.ReadMessage(Key);
						break;
					case 18u:
						if (value_ == null)
						{
							Value = new IndexOrNameIdentifier();
						}
						input.ReadMessage(Value);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<NetworkAPI> _parser = new MessageParser<NetworkAPI>(() => new NetworkAPI());

	private UnknownFieldSet _unknownFields;

	public const int ActionFieldNumber = 1;

	public const int ServerStateFieldNumber = 2;

	public const int GroupChangeFieldNumber = 5;

	public const int GroupResponseFieldNumber = 6;

	private object command_;

	private CommandOneofCase commandCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NetworkAPI> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Action Action
	{
		get
		{
			if (commandCase_ != CommandOneofCase.Action)
			{
				return null;
			}
			return (Types.Action)command_;
		}
		set
		{
			command_ = value;
			commandCase_ = ((value != null) ? CommandOneofCase.Action : CommandOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ServerState ServerState
	{
		get
		{
			if (commandCase_ != CommandOneofCase.ServerState)
			{
				return null;
			}
			return (Types.ServerState)command_;
		}
		set
		{
			command_ = value;
			commandCase_ = ((value != null) ? CommandOneofCase.ServerState : CommandOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GroupChange GroupChange
	{
		get
		{
			if (commandCase_ != CommandOneofCase.GroupChange)
			{
				return null;
			}
			return (Types.GroupChange)command_;
		}
		set
		{
			command_ = value;
			commandCase_ = ((value != null) ? CommandOneofCase.GroupChange : CommandOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GroupResponse GroupResponse
	{
		get
		{
			if (commandCase_ != CommandOneofCase.GroupResponse)
			{
				return null;
			}
			return (Types.GroupResponse)command_;
		}
		set
		{
			command_ = value;
			commandCase_ = ((value != null) ? CommandOneofCase.GroupResponse : CommandOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommandOneofCase CommandCase => commandCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI(NetworkAPI other)
		: this()
	{
		switch (other.CommandCase)
		{
		case CommandOneofCase.Action:
			Action = other.Action.Clone();
			break;
		case CommandOneofCase.ServerState:
			ServerState = other.ServerState.Clone();
			break;
		case CommandOneofCase.GroupChange:
			GroupChange = other.GroupChange.Clone();
			break;
		case CommandOneofCase.GroupResponse:
			GroupResponse = other.GroupResponse.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI Clone()
	{
		return new NetworkAPI(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearCommand()
	{
		commandCase_ = CommandOneofCase.None;
		command_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NetworkAPI);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NetworkAPI other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Action, other.Action))
		{
			return false;
		}
		if (!object.Equals(ServerState, other.ServerState))
		{
			return false;
		}
		if (!object.Equals(GroupChange, other.GroupChange))
		{
			return false;
		}
		if (!object.Equals(GroupResponse, other.GroupResponse))
		{
			return false;
		}
		if (CommandCase != other.CommandCase)
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
		if (commandCase_ == CommandOneofCase.Action)
		{
			num ^= Action.GetHashCode();
		}
		if (commandCase_ == CommandOneofCase.ServerState)
		{
			num ^= ServerState.GetHashCode();
		}
		if (commandCase_ == CommandOneofCase.GroupChange)
		{
			num ^= GroupChange.GetHashCode();
		}
		if (commandCase_ == CommandOneofCase.GroupResponse)
		{
			num ^= GroupResponse.GetHashCode();
		}
		num ^= (int)commandCase_;
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
		if (commandCase_ == CommandOneofCase.Action)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Action);
		}
		if (commandCase_ == CommandOneofCase.ServerState)
		{
			output.WriteRawTag(18);
			output.WriteMessage(ServerState);
		}
		if (commandCase_ == CommandOneofCase.GroupChange)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GroupChange);
		}
		if (commandCase_ == CommandOneofCase.GroupResponse)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GroupResponse);
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
		if (commandCase_ == CommandOneofCase.Action)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Action);
		}
		if (commandCase_ == CommandOneofCase.ServerState)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ServerState);
		}
		if (commandCase_ == CommandOneofCase.GroupChange)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GroupChange);
		}
		if (commandCase_ == CommandOneofCase.GroupResponse)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GroupResponse);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(NetworkAPI other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.CommandCase)
		{
		case CommandOneofCase.Action:
			if (Action == null)
			{
				Action = new Types.Action();
			}
			Action.MergeFrom(other.Action);
			break;
		case CommandOneofCase.ServerState:
			if (ServerState == null)
			{
				ServerState = new Types.ServerState();
			}
			ServerState.MergeFrom(other.ServerState);
			break;
		case CommandOneofCase.GroupChange:
			if (GroupChange == null)
			{
				GroupChange = new Types.GroupChange();
			}
			GroupChange.MergeFrom(other.GroupChange);
			break;
		case CommandOneofCase.GroupResponse:
			if (GroupResponse == null)
			{
				GroupResponse = new Types.GroupResponse();
			}
			GroupResponse.MergeFrom(other.GroupResponse);
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
			{
				Types.Action action = new Types.Action();
				if (commandCase_ == CommandOneofCase.Action)
				{
					action.MergeFrom(Action);
				}
				input.ReadMessage(action);
				Action = action;
				break;
			}
			case 18u:
			{
				Types.ServerState serverState = new Types.ServerState();
				if (commandCase_ == CommandOneofCase.ServerState)
				{
					serverState.MergeFrom(ServerState);
				}
				input.ReadMessage(serverState);
				ServerState = serverState;
				break;
			}
			case 42u:
			{
				Types.GroupChange groupChange = new Types.GroupChange();
				if (commandCase_ == CommandOneofCase.GroupChange)
				{
					groupChange.MergeFrom(GroupChange);
				}
				input.ReadMessage(groupChange);
				GroupChange = groupChange;
				break;
			}
			case 50u:
			{
				Types.GroupResponse groupResponse = new Types.GroupResponse();
				if (commandCase_ == CommandOneofCase.GroupResponse)
				{
					groupResponse.MergeFrom(GroupResponse);
				}
				input.ReadMessage(groupResponse);
				GroupResponse = groupResponse;
				break;
			}
			}
		}
	}
}
