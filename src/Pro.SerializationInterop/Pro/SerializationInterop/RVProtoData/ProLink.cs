using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProLink : IMessage<ProLink>, IMessage, IEquatable<ProLink>, IDeepCloneable<ProLink>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupDefinition : IMessage<GroupDefinition>, IMessage, IEquatable<GroupDefinition>, IDeepCloneable<GroupDefinition>
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

					public const int IpFieldNumber = 1;

					private string ip_ = "";

					public const int PortFieldNumber = 2;

					private uint port_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Member> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => GroupDefinition.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Ip
					{
						get
						{
							return ip_;
						}
						set
						{
							ip_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Port
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
						ip_ = other.ip_;
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
						if (Ip != other.Ip)
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
						if (Ip.Length != 0)
						{
							num ^= Ip.GetHashCode();
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
						if (Ip.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Ip);
						}
						if (Port != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(Port);
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
						if (Ip.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Ip);
						}
						if (Port != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
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
							if (other.Ip.Length != 0)
							{
								Ip = other.Ip;
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
								Ip = input.ReadString();
								break;
							case 16u:
								Port = input.ReadUInt32();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<GroupDefinition> _parser = new MessageParser<GroupDefinition>(() => new GroupDefinition());

			private UnknownFieldSet _unknownFields;

			public const int TimestampFieldNumber = 1;

			private Timestamp timestamp_;

			public const int SecretFieldNumber = 2;

			private string secret_ = "";

			public const int NameFieldNumber = 3;

			private string name_ = "";

			public const int MembersFieldNumber = 4;

			private static readonly FieldCodec<Types.Member> _repeated_members_codec = FieldCodec.ForMessage(34u, Types.Member.Parser);

			private readonly RepeatedField<Types.Member> members_ = new RepeatedField<Types.Member>();

			public const int GroupIdentifierFieldNumber = 5;

			private UUID groupIdentifier_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupDefinition> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProLink.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timestamp Timestamp
			{
				get
				{
					return timestamp_;
				}
				set
				{
					timestamp_ = value;
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
			public UUID GroupIdentifier
			{
				get
				{
					return groupIdentifier_;
				}
				set
				{
					groupIdentifier_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupDefinition()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupDefinition(GroupDefinition other)
				: this()
			{
				timestamp_ = ((other.timestamp_ != null) ? other.timestamp_.Clone() : null);
				secret_ = other.secret_;
				name_ = other.name_;
				members_ = other.members_.Clone();
				groupIdentifier_ = ((other.groupIdentifier_ != null) ? other.groupIdentifier_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupDefinition Clone()
			{
				return new GroupDefinition(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupDefinition);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupDefinition other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Timestamp, other.Timestamp))
				{
					return false;
				}
				if (Secret != other.Secret)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!members_.Equals(other.members_))
				{
					return false;
				}
				if (!object.Equals(GroupIdentifier, other.GroupIdentifier))
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
				if (timestamp_ != null)
				{
					num ^= Timestamp.GetHashCode();
				}
				if (Secret.Length != 0)
				{
					num ^= Secret.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= members_.GetHashCode();
				if (groupIdentifier_ != null)
				{
					num ^= GroupIdentifier.GetHashCode();
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
				if (timestamp_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Timestamp);
				}
				if (Secret.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Secret);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Name);
				}
				members_.WriteTo(output, _repeated_members_codec);
				if (groupIdentifier_ != null)
				{
					output.WriteRawTag(42);
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
				if (timestamp_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timestamp);
				}
				if (Secret.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Secret);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += members_.CalculateSize(_repeated_members_codec);
				if (groupIdentifier_ != null)
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
			public void MergeFrom(GroupDefinition other)
			{
				if (other == null)
				{
					return;
				}
				if (other.timestamp_ != null)
				{
					if (timestamp_ == null)
					{
						Timestamp = new Timestamp();
					}
					Timestamp.MergeFrom(other.Timestamp);
				}
				if (other.Secret.Length != 0)
				{
					Secret = other.Secret;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				members_.Add(other.members_);
				if (other.groupIdentifier_ != null)
				{
					if (groupIdentifier_ == null)
					{
						GroupIdentifier = new UUID();
					}
					GroupIdentifier.MergeFrom(other.GroupIdentifier);
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
						if (timestamp_ == null)
						{
							Timestamp = new Timestamp();
						}
						input.ReadMessage(Timestamp);
						break;
					case 18u:
						Secret = input.ReadString();
						break;
					case 26u:
						Name = input.ReadString();
						break;
					case 34u:
						members_.AddEntriesFrom(input, _repeated_members_codec);
						break;
					case 42u:
						if (groupIdentifier_ == null)
						{
							GroupIdentifier = new UUID();
						}
						input.ReadMessage(GroupIdentifier);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ZeroConfig : IMessage<ZeroConfig>, IMessage, IEquatable<ZeroConfig>, IDeepCloneable<ZeroConfig>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class NetworkEnvironment : IMessage<NetworkEnvironment>, IMessage, IEquatable<NetworkEnvironment>, IDeepCloneable<NetworkEnvironment>
				{
					private static readonly MessageParser<NetworkEnvironment> _parser = new MessageParser<NetworkEnvironment>(() => new NetworkEnvironment());

					private UnknownFieldSet _unknownFields;

					public const int AvailableGroupsFieldNumber = 1;

					private static readonly FieldCodec<GroupDefinition> _repeated_availableGroups_codec = FieldCodec.ForMessage(10u, GroupDefinition.Parser);

					private readonly RepeatedField<GroupDefinition> availableGroups_ = new RepeatedField<GroupDefinition>();

					public const int AvailableDevicesFieldNumber = 2;

					private static readonly FieldCodec<MemberStatus> _repeated_availableDevices_codec = FieldCodec.ForMessage(18u, MemberStatus.Parser);

					private readonly RepeatedField<MemberStatus> availableDevices_ = new RepeatedField<MemberStatus>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<NetworkEnvironment> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ZeroConfig.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<GroupDefinition> AvailableGroups => availableGroups_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<MemberStatus> AvailableDevices => availableDevices_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public NetworkEnvironment()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public NetworkEnvironment(NetworkEnvironment other)
						: this()
					{
						availableGroups_ = other.availableGroups_.Clone();
						availableDevices_ = other.availableDevices_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public NetworkEnvironment Clone()
					{
						return new NetworkEnvironment(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as NetworkEnvironment);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(NetworkEnvironment other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!availableGroups_.Equals(other.availableGroups_))
						{
							return false;
						}
						if (!availableDevices_.Equals(other.availableDevices_))
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
						num ^= availableGroups_.GetHashCode();
						num ^= availableDevices_.GetHashCode();
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
						availableGroups_.WriteTo(output, _repeated_availableGroups_codec);
						availableDevices_.WriteTo(output, _repeated_availableDevices_codec);
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
						num += availableGroups_.CalculateSize(_repeated_availableGroups_codec);
						num += availableDevices_.CalculateSize(_repeated_availableDevices_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(NetworkEnvironment other)
					{
						if (other != null)
						{
							availableGroups_.Add(other.availableGroups_);
							availableDevices_.Add(other.availableDevices_);
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
								availableGroups_.AddEntriesFrom(input, _repeated_availableGroups_codec);
								break;
							case 18u:
								availableDevices_.AddEntriesFrom(input, _repeated_availableDevices_codec);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class MulticastPacket : IMessage<MulticastPacket>, IMessage, IEquatable<MulticastPacket>, IDeepCloneable<MulticastPacket>
				{
					private static readonly MessageParser<MulticastPacket> _parser = new MessageParser<MulticastPacket>(() => new MulticastPacket());

					private UnknownFieldSet _unknownFields;

					public const int GroupFieldNumber = 1;

					private GroupDefinition group_;

					public const int DeviceFieldNumber = 2;

					private MemberStatus device_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<MulticastPacket> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ZeroConfig.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinition Group
					{
						get
						{
							return group_;
						}
						set
						{
							group_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MemberStatus Device
					{
						get
						{
							return device_;
						}
						set
						{
							device_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MulticastPacket()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MulticastPacket(MulticastPacket other)
						: this()
					{
						group_ = ((other.group_ != null) ? other.group_.Clone() : null);
						device_ = ((other.device_ != null) ? other.device_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MulticastPacket Clone()
					{
						return new MulticastPacket(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as MulticastPacket);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(MulticastPacket other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Group, other.Group))
						{
							return false;
						}
						if (!object.Equals(Device, other.Device))
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
						if (group_ != null)
						{
							num ^= Group.GetHashCode();
						}
						if (device_ != null)
						{
							num ^= Device.GetHashCode();
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
						if (group_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Group);
						}
						if (device_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Device);
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
						if (group_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Group);
						}
						if (device_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Device);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(MulticastPacket other)
					{
						if (other == null)
						{
							return;
						}
						if (other.group_ != null)
						{
							if (group_ == null)
							{
								Group = new GroupDefinition();
							}
							Group.MergeFrom(other.Group);
						}
						if (other.device_ != null)
						{
							if (device_ == null)
							{
								Device = new MemberStatus();
							}
							Device.MergeFrom(other.Device);
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
								if (group_ == null)
								{
									Group = new GroupDefinition();
								}
								input.ReadMessage(Group);
								break;
							case 18u:
								if (device_ == null)
								{
									Device = new MemberStatus();
								}
								input.ReadMessage(Device);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<ZeroConfig> _parser = new MessageParser<ZeroConfig>(() => new ZeroConfig());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ZeroConfig> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProLink.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ZeroConfig()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ZeroConfig(ZeroConfig other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ZeroConfig Clone()
			{
				return new ZeroConfig(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ZeroConfig);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ZeroConfig other)
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
			public void MergeFrom(ZeroConfig other)
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
		public sealed class TowerMessage : IMessage<TowerMessage>, IMessage, IEquatable<TowerMessage>, IDeepCloneable<TowerMessage>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TowerStatusRequest : IMessage<TowerStatusRequest>, IMessage, IEquatable<TowerStatusRequest>, IDeepCloneable<TowerStatusRequest>
				{
					private static readonly MessageParser<TowerStatusRequest> _parser = new MessageParser<TowerStatusRequest>(() => new TowerStatusRequest());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TowerStatusRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TowerMessage.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerStatusRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerStatusRequest(TowerStatusRequest other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerStatusRequest Clone()
					{
						return new TowerStatusRequest(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TowerStatusRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TowerStatusRequest other)
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
					public void MergeFrom(TowerStatusRequest other)
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
				public sealed class TowerStatusResponse : IMessage<TowerStatusResponse>, IMessage, IEquatable<TowerStatusResponse>, IDeepCloneable<TowerStatusResponse>
				{
					public enum ResponseOneofCase
					{
						None,
						GroupDefinition
					}

					private static readonly MessageParser<TowerStatusResponse> _parser = new MessageParser<TowerStatusResponse>(() => new TowerStatusResponse());

					private UnknownFieldSet _unknownFields;

					public const int GroupDefinitionFieldNumber = 1;

					public const int MemberNameFieldNumber = 2;

					private string memberName_ = "";

					private object response_;

					private ResponseOneofCase responseCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TowerStatusResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TowerMessage.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinition GroupDefinition
					{
						get
						{
							if (responseCase_ != ResponseOneofCase.GroupDefinition)
							{
								return null;
							}
							return (GroupDefinition)response_;
						}
						set
						{
							response_ = value;
							responseCase_ = ((value != null) ? ResponseOneofCase.GroupDefinition : ResponseOneofCase.None);
						}
					}

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
					public ResponseOneofCase ResponseCase => responseCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerStatusResponse()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerStatusResponse(TowerStatusResponse other)
						: this()
					{
						memberName_ = other.memberName_;
						if (other.ResponseCase == ResponseOneofCase.GroupDefinition)
						{
							GroupDefinition = other.GroupDefinition.Clone();
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerStatusResponse Clone()
					{
						return new TowerStatusResponse(this);
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
						return Equals(other as TowerStatusResponse);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TowerStatusResponse other)
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
						if (MemberName != other.MemberName)
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
						if (responseCase_ == ResponseOneofCase.GroupDefinition)
						{
							num ^= GroupDefinition.GetHashCode();
						}
						if (MemberName.Length != 0)
						{
							num ^= MemberName.GetHashCode();
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
						if (responseCase_ == ResponseOneofCase.GroupDefinition)
						{
							output.WriteRawTag(10);
							output.WriteMessage(GroupDefinition);
						}
						if (MemberName.Length != 0)
						{
							output.WriteRawTag(18);
							output.WriteString(MemberName);
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
						if (responseCase_ == ResponseOneofCase.GroupDefinition)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
						}
						if (MemberName.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(MemberName);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TowerStatusResponse other)
					{
						if (other == null)
						{
							return;
						}
						if (other.MemberName.Length != 0)
						{
							MemberName = other.MemberName;
						}
						if (other.ResponseCase == ResponseOneofCase.GroupDefinition)
						{
							if (GroupDefinition == null)
							{
								GroupDefinition = new GroupDefinition();
							}
							GroupDefinition.MergeFrom(other.GroupDefinition);
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
								GroupDefinition groupDefinition = new GroupDefinition();
								if (responseCase_ == ResponseOneofCase.GroupDefinition)
								{
									groupDefinition.MergeFrom(GroupDefinition);
								}
								input.ReadMessage(groupDefinition);
								GroupDefinition = groupDefinition;
								break;
							}
							case 18u:
								MemberName = input.ReadString();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TowerAddMemberRequest : IMessage<TowerAddMemberRequest>, IMessage, IEquatable<TowerAddMemberRequest>, IDeepCloneable<TowerAddMemberRequest>
				{
					public enum RequestOneofCase
					{
						None,
						GroupDefinition,
						JoiningMember
					}

					private static readonly MessageParser<TowerAddMemberRequest> _parser = new MessageParser<TowerAddMemberRequest>(() => new TowerAddMemberRequest());

					private UnknownFieldSet _unknownFields;

					public const int GroupDefinitionFieldNumber = 1;

					public const int JoiningMemberFieldNumber = 2;

					private object request_;

					private RequestOneofCase requestCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TowerAddMemberRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TowerMessage.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinition GroupDefinition
					{
						get
						{
							if (requestCase_ != RequestOneofCase.GroupDefinition)
							{
								return null;
							}
							return (GroupDefinition)request_;
						}
						set
						{
							request_ = value;
							requestCase_ = ((value != null) ? RequestOneofCase.GroupDefinition : RequestOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinition.Types.Member JoiningMember
					{
						get
						{
							if (requestCase_ != RequestOneofCase.JoiningMember)
							{
								return null;
							}
							return (GroupDefinition.Types.Member)request_;
						}
						set
						{
							request_ = value;
							requestCase_ = ((value != null) ? RequestOneofCase.JoiningMember : RequestOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RequestOneofCase RequestCase => requestCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerAddMemberRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerAddMemberRequest(TowerAddMemberRequest other)
						: this()
					{
						switch (other.RequestCase)
						{
						case RequestOneofCase.GroupDefinition:
							GroupDefinition = other.GroupDefinition.Clone();
							break;
						case RequestOneofCase.JoiningMember:
							JoiningMember = other.JoiningMember.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerAddMemberRequest Clone()
					{
						return new TowerAddMemberRequest(this);
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
						return Equals(other as TowerAddMemberRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TowerAddMemberRequest other)
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
						if (!object.Equals(JoiningMember, other.JoiningMember))
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
						if (requestCase_ == RequestOneofCase.GroupDefinition)
						{
							num ^= GroupDefinition.GetHashCode();
						}
						if (requestCase_ == RequestOneofCase.JoiningMember)
						{
							num ^= JoiningMember.GetHashCode();
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
						if (requestCase_ == RequestOneofCase.GroupDefinition)
						{
							output.WriteRawTag(10);
							output.WriteMessage(GroupDefinition);
						}
						if (requestCase_ == RequestOneofCase.JoiningMember)
						{
							output.WriteRawTag(18);
							output.WriteMessage(JoiningMember);
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
						if (requestCase_ == RequestOneofCase.GroupDefinition)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
						}
						if (requestCase_ == RequestOneofCase.JoiningMember)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(JoiningMember);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TowerAddMemberRequest other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.RequestCase)
						{
						case RequestOneofCase.GroupDefinition:
							if (GroupDefinition == null)
							{
								GroupDefinition = new GroupDefinition();
							}
							GroupDefinition.MergeFrom(other.GroupDefinition);
							break;
						case RequestOneofCase.JoiningMember:
							if (JoiningMember == null)
							{
								JoiningMember = new GroupDefinition.Types.Member();
							}
							JoiningMember.MergeFrom(other.JoiningMember);
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
								GroupDefinition groupDefinition = new GroupDefinition();
								if (requestCase_ == RequestOneofCase.GroupDefinition)
								{
									groupDefinition.MergeFrom(GroupDefinition);
								}
								input.ReadMessage(groupDefinition);
								GroupDefinition = groupDefinition;
								break;
							}
							case 18u:
							{
								GroupDefinition.Types.Member member = new GroupDefinition.Types.Member();
								if (requestCase_ == RequestOneofCase.JoiningMember)
								{
									member.MergeFrom(JoiningMember);
								}
								input.ReadMessage(member);
								JoiningMember = member;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TowerRemoveMemberRequest : IMessage<TowerRemoveMemberRequest>, IMessage, IEquatable<TowerRemoveMemberRequest>, IDeepCloneable<TowerRemoveMemberRequest>
				{
					private static readonly MessageParser<TowerRemoveMemberRequest> _parser = new MessageParser<TowerRemoveMemberRequest>(() => new TowerRemoveMemberRequest());

					private UnknownFieldSet _unknownFields;

					public const int RemovingMemberFieldNumber = 1;

					private GroupDefinition.Types.Member removingMember_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TowerRemoveMemberRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TowerMessage.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinition.Types.Member RemovingMember
					{
						get
						{
							return removingMember_;
						}
						set
						{
							removingMember_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerRemoveMemberRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerRemoveMemberRequest(TowerRemoveMemberRequest other)
						: this()
					{
						removingMember_ = ((other.removingMember_ != null) ? other.removingMember_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerRemoveMemberRequest Clone()
					{
						return new TowerRemoveMemberRequest(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TowerRemoveMemberRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TowerRemoveMemberRequest other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(RemovingMember, other.RemovingMember))
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
						if (removingMember_ != null)
						{
							num ^= RemovingMember.GetHashCode();
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
						if (removingMember_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(RemovingMember);
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
						if (removingMember_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(RemovingMember);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TowerRemoveMemberRequest other)
					{
						if (other == null)
						{
							return;
						}
						if (other.removingMember_ != null)
						{
							if (removingMember_ == null)
							{
								RemovingMember = new GroupDefinition.Types.Member();
							}
							RemovingMember.MergeFrom(other.RemovingMember);
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
							if (removingMember_ == null)
							{
								RemovingMember = new GroupDefinition.Types.Member();
							}
							input.ReadMessage(RemovingMember);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TowerAddMemberResponse : IMessage<TowerAddMemberResponse>, IMessage, IEquatable<TowerAddMemberResponse>, IDeepCloneable<TowerAddMemberResponse>
				{
					public enum ResponseOneofCase
					{
						None,
						GroupDefinition,
						Accept,
						DeclineReason
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum DeclineReason
						{
							[OriginalName("ALREADY_IN_GROUP")]
							AlreadyInGroup,
							[OriginalName("USER_DECLINED")]
							UserDeclined
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Accept : IMessage<Accept>, IMessage, IEquatable<Accept>, IDeepCloneable<Accept>
						{
							private static readonly MessageParser<Accept> _parser = new MessageParser<Accept>(() => new Accept());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Accept> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => TowerAddMemberResponse.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Accept()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Accept(Accept other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Accept Clone()
							{
								return new Accept(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Accept);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Accept other)
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
							public void MergeFrom(Accept other)
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

					private static readonly MessageParser<TowerAddMemberResponse> _parser = new MessageParser<TowerAddMemberResponse>(() => new TowerAddMemberResponse());

					private UnknownFieldSet _unknownFields;

					public const int GroupDefinitionFieldNumber = 1;

					public const int AcceptFieldNumber = 2;

					public const int DeclineReasonFieldNumber = 3;

					private object response_;

					private ResponseOneofCase responseCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TowerAddMemberResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TowerMessage.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinition GroupDefinition
					{
						get
						{
							if (responseCase_ != ResponseOneofCase.GroupDefinition)
							{
								return null;
							}
							return (GroupDefinition)response_;
						}
						set
						{
							response_ = value;
							responseCase_ = ((value != null) ? ResponseOneofCase.GroupDefinition : ResponseOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Accept Accept
					{
						get
						{
							if (responseCase_ != ResponseOneofCase.Accept)
							{
								return null;
							}
							return (Types.Accept)response_;
						}
						set
						{
							response_ = value;
							responseCase_ = ((value != null) ? ResponseOneofCase.Accept : ResponseOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.DeclineReason DeclineReason
					{
						get
						{
							if (!HasDeclineReason)
							{
								return Types.DeclineReason.AlreadyInGroup;
							}
							return (Types.DeclineReason)response_;
						}
						set
						{
							response_ = value;
							responseCase_ = ResponseOneofCase.DeclineReason;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool HasDeclineReason => responseCase_ == ResponseOneofCase.DeclineReason;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ResponseOneofCase ResponseCase => responseCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerAddMemberResponse()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerAddMemberResponse(TowerAddMemberResponse other)
						: this()
					{
						switch (other.ResponseCase)
						{
						case ResponseOneofCase.GroupDefinition:
							GroupDefinition = other.GroupDefinition.Clone();
							break;
						case ResponseOneofCase.Accept:
							Accept = other.Accept.Clone();
							break;
						case ResponseOneofCase.DeclineReason:
							DeclineReason = other.DeclineReason;
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerAddMemberResponse Clone()
					{
						return new TowerAddMemberResponse(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearDeclineReason()
					{
						if (HasDeclineReason)
						{
							ClearResponse();
						}
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
						return Equals(other as TowerAddMemberResponse);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TowerAddMemberResponse other)
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
						if (!object.Equals(Accept, other.Accept))
						{
							return false;
						}
						if (DeclineReason != other.DeclineReason)
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
						if (responseCase_ == ResponseOneofCase.GroupDefinition)
						{
							num ^= GroupDefinition.GetHashCode();
						}
						if (responseCase_ == ResponseOneofCase.Accept)
						{
							num ^= Accept.GetHashCode();
						}
						if (HasDeclineReason)
						{
							num ^= DeclineReason.GetHashCode();
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
						if (responseCase_ == ResponseOneofCase.GroupDefinition)
						{
							output.WriteRawTag(10);
							output.WriteMessage(GroupDefinition);
						}
						if (responseCase_ == ResponseOneofCase.Accept)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Accept);
						}
						if (HasDeclineReason)
						{
							output.WriteRawTag(24);
							output.WriteEnum((int)DeclineReason);
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
						if (responseCase_ == ResponseOneofCase.GroupDefinition)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
						}
						if (responseCase_ == ResponseOneofCase.Accept)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Accept);
						}
						if (HasDeclineReason)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)DeclineReason);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TowerAddMemberResponse other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.ResponseCase)
						{
						case ResponseOneofCase.GroupDefinition:
							if (GroupDefinition == null)
							{
								GroupDefinition = new GroupDefinition();
							}
							GroupDefinition.MergeFrom(other.GroupDefinition);
							break;
						case ResponseOneofCase.Accept:
							if (Accept == null)
							{
								Accept = new Types.Accept();
							}
							Accept.MergeFrom(other.Accept);
							break;
						case ResponseOneofCase.DeclineReason:
							DeclineReason = other.DeclineReason;
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
								GroupDefinition groupDefinition = new GroupDefinition();
								if (responseCase_ == ResponseOneofCase.GroupDefinition)
								{
									groupDefinition.MergeFrom(GroupDefinition);
								}
								input.ReadMessage(groupDefinition);
								GroupDefinition = groupDefinition;
								break;
							}
							case 18u:
							{
								Types.Accept accept = new Types.Accept();
								if (responseCase_ == ResponseOneofCase.Accept)
								{
									accept.MergeFrom(Accept);
								}
								input.ReadMessage(accept);
								Accept = accept;
								break;
							}
							case 24u:
								response_ = input.ReadEnum();
								responseCase_ = ResponseOneofCase.DeclineReason;
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TowerHeartbeatRequest : IMessage<TowerHeartbeatRequest>, IMessage, IEquatable<TowerHeartbeatRequest>, IDeepCloneable<TowerHeartbeatRequest>
				{
					private static readonly MessageParser<TowerHeartbeatRequest> _parser = new MessageParser<TowerHeartbeatRequest>(() => new TowerHeartbeatRequest());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TowerHeartbeatRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TowerMessage.Descriptor.NestedTypes[5];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerHeartbeatRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerHeartbeatRequest(TowerHeartbeatRequest other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerHeartbeatRequest Clone()
					{
						return new TowerHeartbeatRequest(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TowerHeartbeatRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TowerHeartbeatRequest other)
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
					public void MergeFrom(TowerHeartbeatRequest other)
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
				public sealed class TowerHeartbeatResponse : IMessage<TowerHeartbeatResponse>, IMessage, IEquatable<TowerHeartbeatResponse>, IDeepCloneable<TowerHeartbeatResponse>
				{
					private static readonly MessageParser<TowerHeartbeatResponse> _parser = new MessageParser<TowerHeartbeatResponse>(() => new TowerHeartbeatResponse());

					private UnknownFieldSet _unknownFields;

					public const int GroupDefinitionFieldNumber = 1;

					private GroupDefinition groupDefinition_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TowerHeartbeatResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TowerMessage.Descriptor.NestedTypes[6];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinition GroupDefinition
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
					public TowerHeartbeatResponse()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerHeartbeatResponse(TowerHeartbeatResponse other)
						: this()
					{
						groupDefinition_ = ((other.groupDefinition_ != null) ? other.groupDefinition_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TowerHeartbeatResponse Clone()
					{
						return new TowerHeartbeatResponse(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TowerHeartbeatResponse);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TowerHeartbeatResponse other)
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TowerHeartbeatResponse other)
					{
						if (other == null)
						{
							return;
						}
						if (other.groupDefinition_ != null)
						{
							if (groupDefinition_ == null)
							{
								GroupDefinition = new GroupDefinition();
							}
							GroupDefinition.MergeFrom(other.GroupDefinition);
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
							if (groupDefinition_ == null)
							{
								GroupDefinition = new GroupDefinition();
							}
							input.ReadMessage(GroupDefinition);
						}
					}
				}
			}

			private static readonly MessageParser<TowerMessage> _parser = new MessageParser<TowerMessage>(() => new TowerMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TowerMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProLink.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TowerMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TowerMessage(TowerMessage other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TowerMessage Clone()
			{
				return new TowerMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TowerMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TowerMessage other)
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
			public void MergeFrom(TowerMessage other)
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
		public sealed class MemberStatus : IMessage<MemberStatus>, IMessage, IEquatable<MemberStatus>, IDeepCloneable<MemberStatus>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ConnectionStatus
				{
					[OriginalName("CONNECTION_STATUS_UNKNOWN")]
					Unknown,
					[OriginalName("CONNECTION_STATUS_CONNECTED")]
					Connected,
					[OriginalName("CONNECTION_STATUS_DISCONNECTED")]
					Disconnected
				}
			}

			private static readonly MessageParser<MemberStatus> _parser = new MessageParser<MemberStatus>(() => new MemberStatus());

			private UnknownFieldSet _unknownFields;

			public const int IpFieldNumber = 1;

			private string ip_ = "";

			public const int PortFieldNumber = 2;

			private uint port_;

			public const int NameFieldNumber = 3;

			private string name_ = "";

			public const int PlatformFieldNumber = 4;

			private ApplicationInfo.Types.Platform platform_;

			public const int OsVersionFieldNumber = 5;

			private string osVersion_ = "";

			public const int HostDescriptionFieldNumber = 6;

			private string hostDescription_ = "";

			public const int ApiVersionFieldNumber = 7;

			private string apiVersion_ = "";

			public const int ConnectionStatusFieldNumber = 8;

			private Types.ConnectionStatus connectionStatus_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MemberStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProLink.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Ip
			{
				get
				{
					return ip_;
				}
				set
				{
					ip_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Port
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
			public string HostDescription
			{
				get
				{
					return hostDescription_;
				}
				set
				{
					hostDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ApiVersion
			{
				get
				{
					return apiVersion_;
				}
				set
				{
					apiVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ConnectionStatus ConnectionStatus
			{
				get
				{
					return connectionStatus_;
				}
				set
				{
					connectionStatus_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MemberStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MemberStatus(MemberStatus other)
				: this()
			{
				ip_ = other.ip_;
				port_ = other.port_;
				name_ = other.name_;
				platform_ = other.platform_;
				osVersion_ = other.osVersion_;
				hostDescription_ = other.hostDescription_;
				apiVersion_ = other.apiVersion_;
				connectionStatus_ = other.connectionStatus_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MemberStatus Clone()
			{
				return new MemberStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MemberStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MemberStatus other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Ip != other.Ip)
				{
					return false;
				}
				if (Port != other.Port)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Platform != other.Platform)
				{
					return false;
				}
				if (OsVersion != other.OsVersion)
				{
					return false;
				}
				if (HostDescription != other.HostDescription)
				{
					return false;
				}
				if (ApiVersion != other.ApiVersion)
				{
					return false;
				}
				if (ConnectionStatus != other.ConnectionStatus)
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
				if (Ip.Length != 0)
				{
					num ^= Ip.GetHashCode();
				}
				if (Port != 0)
				{
					num ^= Port.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Platform != 0)
				{
					num ^= Platform.GetHashCode();
				}
				if (OsVersion.Length != 0)
				{
					num ^= OsVersion.GetHashCode();
				}
				if (HostDescription.Length != 0)
				{
					num ^= HostDescription.GetHashCode();
				}
				if (ApiVersion.Length != 0)
				{
					num ^= ApiVersion.GetHashCode();
				}
				if (ConnectionStatus != 0)
				{
					num ^= ConnectionStatus.GetHashCode();
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
				if (Ip.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Ip);
				}
				if (Port != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Port);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Name);
				}
				if (Platform != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)Platform);
				}
				if (OsVersion.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(OsVersion);
				}
				if (HostDescription.Length != 0)
				{
					output.WriteRawTag(50);
					output.WriteString(HostDescription);
				}
				if (ApiVersion.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteString(ApiVersion);
				}
				if (ConnectionStatus != 0)
				{
					output.WriteRawTag(64);
					output.WriteEnum((int)ConnectionStatus);
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
				if (Ip.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Ip);
				}
				if (Port != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Platform != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Platform);
				}
				if (OsVersion.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(OsVersion);
				}
				if (HostDescription.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(HostDescription);
				}
				if (ApiVersion.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ApiVersion);
				}
				if (ConnectionStatus != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ConnectionStatus);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MemberStatus other)
			{
				if (other != null)
				{
					if (other.Ip.Length != 0)
					{
						Ip = other.Ip;
					}
					if (other.Port != 0)
					{
						Port = other.Port;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Platform != 0)
					{
						Platform = other.Platform;
					}
					if (other.OsVersion.Length != 0)
					{
						OsVersion = other.OsVersion;
					}
					if (other.HostDescription.Length != 0)
					{
						HostDescription = other.HostDescription;
					}
					if (other.ApiVersion.Length != 0)
					{
						ApiVersion = other.ApiVersion;
					}
					if (other.ConnectionStatus != 0)
					{
						ConnectionStatus = other.ConnectionStatus;
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
						Ip = input.ReadString();
						break;
					case 16u:
						Port = input.ReadUInt32();
						break;
					case 26u:
						Name = input.ReadString();
						break;
					case 32u:
						Platform = (ApplicationInfo.Types.Platform)input.ReadEnum();
						break;
					case 42u:
						OsVersion = input.ReadString();
						break;
					case 50u:
						HostDescription = input.ReadString();
						break;
					case 58u:
						ApiVersion = input.ReadString();
						break;
					case 64u:
						ConnectionStatus = (Types.ConnectionStatus)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ClientAction : IMessage<ClientAction>, IMessage, IEquatable<ClientAction>, IDeepCloneable<ClientAction>
		{
			public enum ActionTypeOneofCase
			{
				None,
				AddConnection,
				RemoveConnection,
				CancelAction,
				RenderTime
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class AddConnection : IMessage<AddConnection>, IMessage, IEquatable<AddConnection>, IDeepCloneable<AddConnection>
				{
					private static readonly MessageParser<AddConnection> _parser = new MessageParser<AddConnection>(() => new AddConnection());

					private UnknownFieldSet _unknownFields;

					public const int IpFieldNumber = 1;

					private string ip_ = "";

					public const int PortFieldNumber = 2;

					private uint port_;

					public const int GroupNameFieldNumber = 3;

					private string groupName_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AddConnection> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ClientAction.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Ip
					{
						get
						{
							return ip_;
						}
						set
						{
							ip_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Port
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
					public AddConnection()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AddConnection(AddConnection other)
						: this()
					{
						ip_ = other.ip_;
						port_ = other.port_;
						groupName_ = other.groupName_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AddConnection Clone()
					{
						return new AddConnection(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AddConnection);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AddConnection other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Ip != other.Ip)
						{
							return false;
						}
						if (Port != other.Port)
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
						if (Ip.Length != 0)
						{
							num ^= Ip.GetHashCode();
						}
						if (Port != 0)
						{
							num ^= Port.GetHashCode();
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
						if (Ip.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Ip);
						}
						if (Port != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(Port);
						}
						if (GroupName.Length != 0)
						{
							output.WriteRawTag(26);
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
						if (Ip.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Ip);
						}
						if (Port != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
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
					public void MergeFrom(AddConnection other)
					{
						if (other != null)
						{
							if (other.Ip.Length != 0)
							{
								Ip = other.Ip;
							}
							if (other.Port != 0)
							{
								Port = other.Port;
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
								Ip = input.ReadString();
								break;
							case 16u:
								Port = input.ReadUInt32();
								break;
							case 26u:
								GroupName = input.ReadString();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class RemoveConnection : IMessage<RemoveConnection>, IMessage, IEquatable<RemoveConnection>, IDeepCloneable<RemoveConnection>
				{
					private static readonly MessageParser<RemoveConnection> _parser = new MessageParser<RemoveConnection>(() => new RemoveConnection());

					private UnknownFieldSet _unknownFields;

					public const int IpFieldNumber = 1;

					private string ip_ = "";

					public const int PortFieldNumber = 2;

					private uint port_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<RemoveConnection> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ClientAction.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Ip
					{
						get
						{
							return ip_;
						}
						set
						{
							ip_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Port
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
					public RemoveConnection()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoveConnection(RemoveConnection other)
						: this()
					{
						ip_ = other.ip_;
						port_ = other.port_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoveConnection Clone()
					{
						return new RemoveConnection(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as RemoveConnection);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(RemoveConnection other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Ip != other.Ip)
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
						if (Ip.Length != 0)
						{
							num ^= Ip.GetHashCode();
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
						if (Ip.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Ip);
						}
						if (Port != 0)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(Port);
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
						if (Ip.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Ip);
						}
						if (Port != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(RemoveConnection other)
					{
						if (other != null)
						{
							if (other.Ip.Length != 0)
							{
								Ip = other.Ip;
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
								Ip = input.ReadString();
								break;
							case 16u:
								Port = input.ReadUInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class CancelAction : IMessage<CancelAction>, IMessage, IEquatable<CancelAction>, IDeepCloneable<CancelAction>
				{
					private static readonly MessageParser<CancelAction> _parser = new MessageParser<CancelAction>(() => new CancelAction());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<CancelAction> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ClientAction.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CancelAction()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CancelAction(CancelAction other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CancelAction Clone()
					{
						return new CancelAction(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as CancelAction);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(CancelAction other)
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
					public void MergeFrom(CancelAction other)
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
				public sealed class RenderTime : IMessage<RenderTime>, IMessage, IEquatable<RenderTime>, IDeepCloneable<RenderTime>
				{
					private static readonly MessageParser<RenderTime> _parser = new MessageParser<RenderTime>(() => new RenderTime());

					private UnknownFieldSet _unknownFields;

					public const int LatencyFieldNumber = 1;

					private ulong latency_;

					public const int RenderTime_FieldNumber = 2;

					private ulong renderTime_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<RenderTime> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => ClientAction.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
					public ulong RenderTime_
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
					public RenderTime()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RenderTime(RenderTime other)
						: this()
					{
						latency_ = other.latency_;
						renderTime_ = other.renderTime_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RenderTime Clone()
					{
						return new RenderTime(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as RenderTime);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(RenderTime other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Latency != other.Latency)
						{
							return false;
						}
						if (RenderTime_ != other.RenderTime_)
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
						if (Latency != 0L)
						{
							num ^= Latency.GetHashCode();
						}
						if (RenderTime_ != 0L)
						{
							num ^= RenderTime_.GetHashCode();
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
						if (Latency != 0L)
						{
							output.WriteRawTag(8);
							output.WriteUInt64(Latency);
						}
						if (RenderTime_ != 0L)
						{
							output.WriteRawTag(16);
							output.WriteUInt64(RenderTime_);
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
						if (Latency != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(Latency);
						}
						if (RenderTime_ != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(RenderTime_);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(RenderTime other)
					{
						if (other != null)
						{
							if (other.Latency != 0L)
							{
								Latency = other.Latency;
							}
							if (other.RenderTime_ != 0L)
							{
								RenderTime_ = other.RenderTime_;
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
								Latency = input.ReadUInt64();
								break;
							case 16u:
								RenderTime_ = input.ReadUInt64();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<ClientAction> _parser = new MessageParser<ClientAction>(() => new ClientAction());

			private UnknownFieldSet _unknownFields;

			public const int AddConnectionFieldNumber = 1;

			public const int RemoveConnectionFieldNumber = 2;

			public const int CancelActionFieldNumber = 3;

			public const int RenderTimeFieldNumber = 4;

			private object actionType_;

			private ActionTypeOneofCase actionTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClientAction> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProLink.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AddConnection AddConnection
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.AddConnection)
					{
						return null;
					}
					return (Types.AddConnection)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.AddConnection : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.RemoveConnection RemoveConnection
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.RemoveConnection)
					{
						return null;
					}
					return (Types.RemoveConnection)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.RemoveConnection : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.CancelAction CancelAction
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.CancelAction)
					{
						return null;
					}
					return (Types.CancelAction)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.CancelAction : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.RenderTime RenderTime
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.RenderTime)
					{
						return null;
					}
					return (Types.RenderTime)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.RenderTime : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActionTypeOneofCase ActionTypeCase => actionTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClientAction()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClientAction(ClientAction other)
				: this()
			{
				switch (other.ActionTypeCase)
				{
				case ActionTypeOneofCase.AddConnection:
					AddConnection = other.AddConnection.Clone();
					break;
				case ActionTypeOneofCase.RemoveConnection:
					RemoveConnection = other.RemoveConnection.Clone();
					break;
				case ActionTypeOneofCase.CancelAction:
					CancelAction = other.CancelAction.Clone();
					break;
				case ActionTypeOneofCase.RenderTime:
					RenderTime = other.RenderTime.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClientAction Clone()
			{
				return new ClientAction(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearActionType()
			{
				actionTypeCase_ = ActionTypeOneofCase.None;
				actionType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClientAction);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClientAction other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(AddConnection, other.AddConnection))
				{
					return false;
				}
				if (!object.Equals(RemoveConnection, other.RemoveConnection))
				{
					return false;
				}
				if (!object.Equals(CancelAction, other.CancelAction))
				{
					return false;
				}
				if (!object.Equals(RenderTime, other.RenderTime))
				{
					return false;
				}
				if (ActionTypeCase != other.ActionTypeCase)
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
				if (actionTypeCase_ == ActionTypeOneofCase.AddConnection)
				{
					num ^= AddConnection.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.RemoveConnection)
				{
					num ^= RemoveConnection.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.CancelAction)
				{
					num ^= CancelAction.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.RenderTime)
				{
					num ^= RenderTime.GetHashCode();
				}
				num ^= (int)actionTypeCase_;
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
				if (actionTypeCase_ == ActionTypeOneofCase.AddConnection)
				{
					output.WriteRawTag(10);
					output.WriteMessage(AddConnection);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.RemoveConnection)
				{
					output.WriteRawTag(18);
					output.WriteMessage(RemoveConnection);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.CancelAction)
				{
					output.WriteRawTag(26);
					output.WriteMessage(CancelAction);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.RenderTime)
				{
					output.WriteRawTag(34);
					output.WriteMessage(RenderTime);
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
				if (actionTypeCase_ == ActionTypeOneofCase.AddConnection)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AddConnection);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.RemoveConnection)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(RemoveConnection);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.CancelAction)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CancelAction);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.RenderTime)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(RenderTime);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ClientAction other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ActionTypeCase)
				{
				case ActionTypeOneofCase.AddConnection:
					if (AddConnection == null)
					{
						AddConnection = new Types.AddConnection();
					}
					AddConnection.MergeFrom(other.AddConnection);
					break;
				case ActionTypeOneofCase.RemoveConnection:
					if (RemoveConnection == null)
					{
						RemoveConnection = new Types.RemoveConnection();
					}
					RemoveConnection.MergeFrom(other.RemoveConnection);
					break;
				case ActionTypeOneofCase.CancelAction:
					if (CancelAction == null)
					{
						CancelAction = new Types.CancelAction();
					}
					CancelAction.MergeFrom(other.CancelAction);
					break;
				case ActionTypeOneofCase.RenderTime:
					if (RenderTime == null)
					{
						RenderTime = new Types.RenderTime();
					}
					RenderTime.MergeFrom(other.RenderTime);
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
						Types.AddConnection addConnection = new Types.AddConnection();
						if (actionTypeCase_ == ActionTypeOneofCase.AddConnection)
						{
							addConnection.MergeFrom(AddConnection);
						}
						input.ReadMessage(addConnection);
						AddConnection = addConnection;
						break;
					}
					case 18u:
					{
						Types.RemoveConnection removeConnection = new Types.RemoveConnection();
						if (actionTypeCase_ == ActionTypeOneofCase.RemoveConnection)
						{
							removeConnection.MergeFrom(RemoveConnection);
						}
						input.ReadMessage(removeConnection);
						RemoveConnection = removeConnection;
						break;
					}
					case 26u:
					{
						Types.CancelAction cancelAction = new Types.CancelAction();
						if (actionTypeCase_ == ActionTypeOneofCase.CancelAction)
						{
							cancelAction.MergeFrom(CancelAction);
						}
						input.ReadMessage(cancelAction);
						CancelAction = cancelAction;
						break;
					}
					case 34u:
					{
						Types.RenderTime renderTime = new Types.RenderTime();
						if (actionTypeCase_ == ActionTypeOneofCase.RenderTime)
						{
							renderTime.MergeFrom(RenderTime);
						}
						input.ReadMessage(renderTime);
						RenderTime = renderTime;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class HandlerIn : IMessage<HandlerIn>, IMessage, IEquatable<HandlerIn>, IDeepCloneable<HandlerIn>
		{
			public enum RequestOneofCase
			{
				None,
				GroupName,
				GroupDefinitionRequest,
				GroupJoinConfirmation,
				GroupJoinPassword,
				AddConnectionResult,
				GroupUpdate,
				MemberStatusChange,
				PropresenterInfo,
				ServerState,
				ConfigurationRequest,
				ZeroconfigNetworkEnvironmentChange,
				LogRequest
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GroupName : IMessage<GroupName>, IMessage, IEquatable<GroupName>, IDeepCloneable<GroupName>
				{
					private static readonly MessageParser<GroupName> _parser = new MessageParser<GroupName>(() => new GroupName());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GroupName> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupName()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupName(GroupName other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupName Clone()
					{
						return new GroupName(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GroupName);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GroupName other)
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
					public void MergeFrom(GroupName other)
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
				public sealed class GroupDefinitionRequest : IMessage<GroupDefinitionRequest>, IMessage, IEquatable<GroupDefinitionRequest>, IDeepCloneable<GroupDefinitionRequest>
				{
					private static readonly MessageParser<GroupDefinitionRequest> _parser = new MessageParser<GroupDefinitionRequest>(() => new GroupDefinitionRequest());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GroupDefinitionRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinitionRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinitionRequest(GroupDefinitionRequest other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupDefinitionRequest Clone()
					{
						return new GroupDefinitionRequest(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GroupDefinitionRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GroupDefinitionRequest other)
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
					public void MergeFrom(GroupDefinitionRequest other)
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
				public sealed class GroupJoinConfirmation : IMessage<GroupJoinConfirmation>, IMessage, IEquatable<GroupJoinConfirmation>, IDeepCloneable<GroupJoinConfirmation>
				{
					private static readonly MessageParser<GroupJoinConfirmation> _parser = new MessageParser<GroupJoinConfirmation>(() => new GroupJoinConfirmation());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GroupJoinConfirmation> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[2];

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
					public GroupJoinConfirmation()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinConfirmation(GroupJoinConfirmation other)
						: this()
					{
						name_ = other.name_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinConfirmation Clone()
					{
						return new GroupJoinConfirmation(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GroupJoinConfirmation);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GroupJoinConfirmation other)
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(GroupJoinConfirmation other)
					{
						if (other != null)
						{
							if (other.Name.Length != 0)
							{
								Name = other.Name;
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
								Name = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GroupJoinPassword : IMessage<GroupJoinPassword>, IMessage, IEquatable<GroupJoinPassword>, IDeepCloneable<GroupJoinPassword>
				{
					private static readonly MessageParser<GroupJoinPassword> _parser = new MessageParser<GroupJoinPassword>(() => new GroupJoinPassword());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GroupJoinPassword> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[3];

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
					public GroupJoinPassword()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinPassword(GroupJoinPassword other)
						: this()
					{
						name_ = other.name_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinPassword Clone()
					{
						return new GroupJoinPassword(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GroupJoinPassword);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GroupJoinPassword other)
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(GroupJoinPassword other)
					{
						if (other != null)
						{
							if (other.Name.Length != 0)
							{
								Name = other.Name;
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
								Name = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class AddConnectionResult : IMessage<AddConnectionResult>, IMessage, IEquatable<AddConnectionResult>, IDeepCloneable<AddConnectionResult>
				{
					public enum ResultOneofCase
					{
						None,
						Success,
						Failure
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

							public const int NewGroupDefinitionFieldNumber = 1;

							private GroupDefinition newGroupDefinition_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Success> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => AddConnectionResult.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GroupDefinition NewGroupDefinition
							{
								get
								{
									return newGroupDefinition_;
								}
								set
								{
									newGroupDefinition_ = value;
								}
							}

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
								newGroupDefinition_ = ((other.newGroupDefinition_ != null) ? other.newGroupDefinition_.Clone() : null);
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
								if (!object.Equals(NewGroupDefinition, other.NewGroupDefinition))
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
								if (newGroupDefinition_ != null)
								{
									num ^= NewGroupDefinition.GetHashCode();
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
								if (newGroupDefinition_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(NewGroupDefinition);
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
								if (newGroupDefinition_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(NewGroupDefinition);
								}
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
								if (other == null)
								{
									return;
								}
								if (other.newGroupDefinition_ != null)
								{
									if (newGroupDefinition_ == null)
									{
										NewGroupDefinition = new GroupDefinition();
									}
									NewGroupDefinition.MergeFrom(other.NewGroupDefinition);
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
									if (newGroupDefinition_ == null)
									{
										NewGroupDefinition = new GroupDefinition();
									}
									input.ReadMessage(NewGroupDefinition);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Failure : IMessage<Failure>, IMessage, IEquatable<Failure>, IDeepCloneable<Failure>
						{
							public enum ReasonOneofCase
							{
								None,
								Unexpected,
								Declined,
								Timeout,
								LinkDisabled,
								InOtherGroup,
								InvalidIpAddress,
								AlreadyInGroup,
								CouldNotAdd,
								CouldNotJoin
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class Unexpected : IMessage<Unexpected>, IMessage, IEquatable<Unexpected>, IDeepCloneable<Unexpected>
								{
									private static readonly MessageParser<Unexpected> _parser = new MessageParser<Unexpected>(() => new Unexpected());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Unexpected> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Unexpected()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Unexpected(Unexpected other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Unexpected Clone()
									{
										return new Unexpected(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Unexpected);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Unexpected other)
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
									public void MergeFrom(Unexpected other)
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
								public sealed class Declined : IMessage<Declined>, IMessage, IEquatable<Declined>, IDeepCloneable<Declined>
								{
									private static readonly MessageParser<Declined> _parser = new MessageParser<Declined>(() => new Declined());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Declined> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Declined()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Declined(Declined other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Declined Clone()
									{
										return new Declined(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Declined);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Declined other)
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
									public void MergeFrom(Declined other)
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
								public sealed class Timeout : IMessage<Timeout>, IMessage, IEquatable<Timeout>, IDeepCloneable<Timeout>
								{
									private static readonly MessageParser<Timeout> _parser = new MessageParser<Timeout>(() => new Timeout());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<Timeout> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[2];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Timeout()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Timeout(Timeout other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Timeout Clone()
									{
										return new Timeout(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as Timeout);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(Timeout other)
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
									public void MergeFrom(Timeout other)
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
								public sealed class LinkDisabled : IMessage<LinkDisabled>, IMessage, IEquatable<LinkDisabled>, IDeepCloneable<LinkDisabled>
								{
									private static readonly MessageParser<LinkDisabled> _parser = new MessageParser<LinkDisabled>(() => new LinkDisabled());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<LinkDisabled> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[3];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public LinkDisabled()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public LinkDisabled(LinkDisabled other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public LinkDisabled Clone()
									{
										return new LinkDisabled(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as LinkDisabled);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(LinkDisabled other)
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
									public void MergeFrom(LinkDisabled other)
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
								public sealed class InOtherGroup : IMessage<InOtherGroup>, IMessage, IEquatable<InOtherGroup>, IDeepCloneable<InOtherGroup>
								{
									private static readonly MessageParser<InOtherGroup> _parser = new MessageParser<InOtherGroup>(() => new InOtherGroup());

									private UnknownFieldSet _unknownFields;

									public const int MemberNameFieldNumber = 1;

									private string memberName_ = "";

									public const int GroupNameFieldNumber = 2;

									private string groupName_ = "";

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<InOtherGroup> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[4];

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
									public InOtherGroup()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public InOtherGroup(InOtherGroup other)
										: this()
									{
										memberName_ = other.memberName_;
										groupName_ = other.groupName_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public InOtherGroup Clone()
									{
										return new InOtherGroup(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as InOtherGroup);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(InOtherGroup other)
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
									public void MergeFrom(InOtherGroup other)
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

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class InvalidIpAddress : IMessage<InvalidIpAddress>, IMessage, IEquatable<InvalidIpAddress>, IDeepCloneable<InvalidIpAddress>
								{
									private static readonly MessageParser<InvalidIpAddress> _parser = new MessageParser<InvalidIpAddress>(() => new InvalidIpAddress());

									private UnknownFieldSet _unknownFields;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<InvalidIpAddress> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[5];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public InvalidIpAddress()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public InvalidIpAddress(InvalidIpAddress other)
										: this()
									{
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public InvalidIpAddress Clone()
									{
										return new InvalidIpAddress(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as InvalidIpAddress);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(InvalidIpAddress other)
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
									public void MergeFrom(InvalidIpAddress other)
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
								public sealed class AlreadyInGroup : IMessage<AlreadyInGroup>, IMessage, IEquatable<AlreadyInGroup>, IDeepCloneable<AlreadyInGroup>
								{
									private static readonly MessageParser<AlreadyInGroup> _parser = new MessageParser<AlreadyInGroup>(() => new AlreadyInGroup());

									private UnknownFieldSet _unknownFields;

									public const int MemberNameFieldNumber = 1;

									private string memberName_ = "";

									public const int GroupNameFieldNumber = 2;

									private string groupName_ = "";

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<AlreadyInGroup> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[6];

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
									public AlreadyInGroup()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public AlreadyInGroup(AlreadyInGroup other)
										: this()
									{
										memberName_ = other.memberName_;
										groupName_ = other.groupName_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public AlreadyInGroup Clone()
									{
										return new AlreadyInGroup(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as AlreadyInGroup);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(AlreadyInGroup other)
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
									public void MergeFrom(AlreadyInGroup other)
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

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class CouldNotAdd : IMessage<CouldNotAdd>, IMessage, IEquatable<CouldNotAdd>, IDeepCloneable<CouldNotAdd>
								{
									private static readonly MessageParser<CouldNotAdd> _parser = new MessageParser<CouldNotAdd>(() => new CouldNotAdd());

									private UnknownFieldSet _unknownFields;

									public const int MemberNameFieldNumber = 1;

									private string memberName_ = "";

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<CouldNotAdd> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[7];

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
									public CouldNotAdd()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public CouldNotAdd(CouldNotAdd other)
										: this()
									{
										memberName_ = other.memberName_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public CouldNotAdd Clone()
									{
										return new CouldNotAdd(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as CouldNotAdd);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(CouldNotAdd other)
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
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(CouldNotAdd other)
									{
										if (other != null)
										{
											if (other.MemberName.Length != 0)
											{
												MemberName = other.MemberName;
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
												MemberName = input.ReadString();
											}
										}
									}
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class CouldNotJoin : IMessage<CouldNotJoin>, IMessage, IEquatable<CouldNotJoin>, IDeepCloneable<CouldNotJoin>
								{
									private static readonly MessageParser<CouldNotJoin> _parser = new MessageParser<CouldNotJoin>(() => new CouldNotJoin());

									private UnknownFieldSet _unknownFields;

									public const int GroupNameFieldNumber = 1;

									private string groupName_ = "";

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<CouldNotJoin> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Failure.Descriptor.NestedTypes[8];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

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
									public CouldNotJoin()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public CouldNotJoin(CouldNotJoin other)
										: this()
									{
										groupName_ = other.groupName_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public CouldNotJoin Clone()
									{
										return new CouldNotJoin(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as CouldNotJoin);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(CouldNotJoin other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
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
										if (GroupName.Length != 0)
										{
											output.WriteRawTag(10);
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
									public void MergeFrom(CouldNotJoin other)
									{
										if (other != null)
										{
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
											if (num != 10)
											{
												_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
											}
											else
											{
												GroupName = input.ReadString();
											}
										}
									}
								}
							}

							private static readonly MessageParser<Failure> _parser = new MessageParser<Failure>(() => new Failure());

							private UnknownFieldSet _unknownFields;

							public const int UnexpectedFieldNumber = 1;

							public const int DeclinedFieldNumber = 2;

							public const int TimeoutFieldNumber = 3;

							public const int LinkDisabledFieldNumber = 4;

							public const int InOtherGroupFieldNumber = 5;

							public const int InvalidIpAddressFieldNumber = 6;

							public const int AlreadyInGroupFieldNumber = 7;

							public const int CouldNotAddFieldNumber = 8;

							public const int CouldNotJoinFieldNumber = 9;

							private object reason_;

							private ReasonOneofCase reasonCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Failure> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => AddConnectionResult.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Unexpected Unexpected
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.Unexpected)
									{
										return null;
									}
									return (Types.Unexpected)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.Unexpected : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Declined Declined
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.Declined)
									{
										return null;
									}
									return (Types.Declined)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.Declined : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Timeout Timeout
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.Timeout)
									{
										return null;
									}
									return (Types.Timeout)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.Timeout : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.LinkDisabled LinkDisabled
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.LinkDisabled)
									{
										return null;
									}
									return (Types.LinkDisabled)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.LinkDisabled : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.InOtherGroup InOtherGroup
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.InOtherGroup)
									{
										return null;
									}
									return (Types.InOtherGroup)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.InOtherGroup : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.InvalidIpAddress InvalidIpAddress
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.InvalidIpAddress)
									{
										return null;
									}
									return (Types.InvalidIpAddress)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.InvalidIpAddress : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.AlreadyInGroup AlreadyInGroup
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.AlreadyInGroup)
									{
										return null;
									}
									return (Types.AlreadyInGroup)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.AlreadyInGroup : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.CouldNotAdd CouldNotAdd
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.CouldNotAdd)
									{
										return null;
									}
									return (Types.CouldNotAdd)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.CouldNotAdd : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.CouldNotJoin CouldNotJoin
							{
								get
								{
									if (reasonCase_ != ReasonOneofCase.CouldNotJoin)
									{
										return null;
									}
									return (Types.CouldNotJoin)reason_;
								}
								set
								{
									reason_ = value;
									reasonCase_ = ((value != null) ? ReasonOneofCase.CouldNotJoin : ReasonOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public ReasonOneofCase ReasonCase => reasonCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Failure()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Failure(Failure other)
								: this()
							{
								switch (other.ReasonCase)
								{
								case ReasonOneofCase.Unexpected:
									Unexpected = other.Unexpected.Clone();
									break;
								case ReasonOneofCase.Declined:
									Declined = other.Declined.Clone();
									break;
								case ReasonOneofCase.Timeout:
									Timeout = other.Timeout.Clone();
									break;
								case ReasonOneofCase.LinkDisabled:
									LinkDisabled = other.LinkDisabled.Clone();
									break;
								case ReasonOneofCase.InOtherGroup:
									InOtherGroup = other.InOtherGroup.Clone();
									break;
								case ReasonOneofCase.InvalidIpAddress:
									InvalidIpAddress = other.InvalidIpAddress.Clone();
									break;
								case ReasonOneofCase.AlreadyInGroup:
									AlreadyInGroup = other.AlreadyInGroup.Clone();
									break;
								case ReasonOneofCase.CouldNotAdd:
									CouldNotAdd = other.CouldNotAdd.Clone();
									break;
								case ReasonOneofCase.CouldNotJoin:
									CouldNotJoin = other.CouldNotJoin.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Failure Clone()
							{
								return new Failure(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearReason()
							{
								reasonCase_ = ReasonOneofCase.None;
								reason_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Failure);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Failure other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Unexpected, other.Unexpected))
								{
									return false;
								}
								if (!object.Equals(Declined, other.Declined))
								{
									return false;
								}
								if (!object.Equals(Timeout, other.Timeout))
								{
									return false;
								}
								if (!object.Equals(LinkDisabled, other.LinkDisabled))
								{
									return false;
								}
								if (!object.Equals(InOtherGroup, other.InOtherGroup))
								{
									return false;
								}
								if (!object.Equals(InvalidIpAddress, other.InvalidIpAddress))
								{
									return false;
								}
								if (!object.Equals(AlreadyInGroup, other.AlreadyInGroup))
								{
									return false;
								}
								if (!object.Equals(CouldNotAdd, other.CouldNotAdd))
								{
									return false;
								}
								if (!object.Equals(CouldNotJoin, other.CouldNotJoin))
								{
									return false;
								}
								if (ReasonCase != other.ReasonCase)
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
								if (reasonCase_ == ReasonOneofCase.Unexpected)
								{
									num ^= Unexpected.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.Declined)
								{
									num ^= Declined.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.Timeout)
								{
									num ^= Timeout.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.LinkDisabled)
								{
									num ^= LinkDisabled.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.InOtherGroup)
								{
									num ^= InOtherGroup.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.InvalidIpAddress)
								{
									num ^= InvalidIpAddress.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.AlreadyInGroup)
								{
									num ^= AlreadyInGroup.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.CouldNotAdd)
								{
									num ^= CouldNotAdd.GetHashCode();
								}
								if (reasonCase_ == ReasonOneofCase.CouldNotJoin)
								{
									num ^= CouldNotJoin.GetHashCode();
								}
								num ^= (int)reasonCase_;
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
								if (reasonCase_ == ReasonOneofCase.Unexpected)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Unexpected);
								}
								if (reasonCase_ == ReasonOneofCase.Declined)
								{
									output.WriteRawTag(18);
									output.WriteMessage(Declined);
								}
								if (reasonCase_ == ReasonOneofCase.Timeout)
								{
									output.WriteRawTag(26);
									output.WriteMessage(Timeout);
								}
								if (reasonCase_ == ReasonOneofCase.LinkDisabled)
								{
									output.WriteRawTag(34);
									output.WriteMessage(LinkDisabled);
								}
								if (reasonCase_ == ReasonOneofCase.InOtherGroup)
								{
									output.WriteRawTag(42);
									output.WriteMessage(InOtherGroup);
								}
								if (reasonCase_ == ReasonOneofCase.InvalidIpAddress)
								{
									output.WriteRawTag(50);
									output.WriteMessage(InvalidIpAddress);
								}
								if (reasonCase_ == ReasonOneofCase.AlreadyInGroup)
								{
									output.WriteRawTag(58);
									output.WriteMessage(AlreadyInGroup);
								}
								if (reasonCase_ == ReasonOneofCase.CouldNotAdd)
								{
									output.WriteRawTag(66);
									output.WriteMessage(CouldNotAdd);
								}
								if (reasonCase_ == ReasonOneofCase.CouldNotJoin)
								{
									output.WriteRawTag(74);
									output.WriteMessage(CouldNotJoin);
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
								if (reasonCase_ == ReasonOneofCase.Unexpected)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Unexpected);
								}
								if (reasonCase_ == ReasonOneofCase.Declined)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Declined);
								}
								if (reasonCase_ == ReasonOneofCase.Timeout)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Timeout);
								}
								if (reasonCase_ == ReasonOneofCase.LinkDisabled)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(LinkDisabled);
								}
								if (reasonCase_ == ReasonOneofCase.InOtherGroup)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(InOtherGroup);
								}
								if (reasonCase_ == ReasonOneofCase.InvalidIpAddress)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(InvalidIpAddress);
								}
								if (reasonCase_ == ReasonOneofCase.AlreadyInGroup)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(AlreadyInGroup);
								}
								if (reasonCase_ == ReasonOneofCase.CouldNotAdd)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(CouldNotAdd);
								}
								if (reasonCase_ == ReasonOneofCase.CouldNotJoin)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(CouldNotJoin);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Failure other)
							{
								if (other == null)
								{
									return;
								}
								switch (other.ReasonCase)
								{
								case ReasonOneofCase.Unexpected:
									if (Unexpected == null)
									{
										Unexpected = new Types.Unexpected();
									}
									Unexpected.MergeFrom(other.Unexpected);
									break;
								case ReasonOneofCase.Declined:
									if (Declined == null)
									{
										Declined = new Types.Declined();
									}
									Declined.MergeFrom(other.Declined);
									break;
								case ReasonOneofCase.Timeout:
									if (Timeout == null)
									{
										Timeout = new Types.Timeout();
									}
									Timeout.MergeFrom(other.Timeout);
									break;
								case ReasonOneofCase.LinkDisabled:
									if (LinkDisabled == null)
									{
										LinkDisabled = new Types.LinkDisabled();
									}
									LinkDisabled.MergeFrom(other.LinkDisabled);
									break;
								case ReasonOneofCase.InOtherGroup:
									if (InOtherGroup == null)
									{
										InOtherGroup = new Types.InOtherGroup();
									}
									InOtherGroup.MergeFrom(other.InOtherGroup);
									break;
								case ReasonOneofCase.InvalidIpAddress:
									if (InvalidIpAddress == null)
									{
										InvalidIpAddress = new Types.InvalidIpAddress();
									}
									InvalidIpAddress.MergeFrom(other.InvalidIpAddress);
									break;
								case ReasonOneofCase.AlreadyInGroup:
									if (AlreadyInGroup == null)
									{
										AlreadyInGroup = new Types.AlreadyInGroup();
									}
									AlreadyInGroup.MergeFrom(other.AlreadyInGroup);
									break;
								case ReasonOneofCase.CouldNotAdd:
									if (CouldNotAdd == null)
									{
										CouldNotAdd = new Types.CouldNotAdd();
									}
									CouldNotAdd.MergeFrom(other.CouldNotAdd);
									break;
								case ReasonOneofCase.CouldNotJoin:
									if (CouldNotJoin == null)
									{
										CouldNotJoin = new Types.CouldNotJoin();
									}
									CouldNotJoin.MergeFrom(other.CouldNotJoin);
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
										Types.Unexpected unexpected = new Types.Unexpected();
										if (reasonCase_ == ReasonOneofCase.Unexpected)
										{
											unexpected.MergeFrom(Unexpected);
										}
										input.ReadMessage(unexpected);
										Unexpected = unexpected;
										break;
									}
									case 18u:
									{
										Types.Declined declined = new Types.Declined();
										if (reasonCase_ == ReasonOneofCase.Declined)
										{
											declined.MergeFrom(Declined);
										}
										input.ReadMessage(declined);
										Declined = declined;
										break;
									}
									case 26u:
									{
										Types.Timeout timeout = new Types.Timeout();
										if (reasonCase_ == ReasonOneofCase.Timeout)
										{
											timeout.MergeFrom(Timeout);
										}
										input.ReadMessage(timeout);
										Timeout = timeout;
										break;
									}
									case 34u:
									{
										Types.LinkDisabled linkDisabled = new Types.LinkDisabled();
										if (reasonCase_ == ReasonOneofCase.LinkDisabled)
										{
											linkDisabled.MergeFrom(LinkDisabled);
										}
										input.ReadMessage(linkDisabled);
										LinkDisabled = linkDisabled;
										break;
									}
									case 42u:
									{
										Types.InOtherGroup inOtherGroup = new Types.InOtherGroup();
										if (reasonCase_ == ReasonOneofCase.InOtherGroup)
										{
											inOtherGroup.MergeFrom(InOtherGroup);
										}
										input.ReadMessage(inOtherGroup);
										InOtherGroup = inOtherGroup;
										break;
									}
									case 50u:
									{
										Types.InvalidIpAddress invalidIpAddress = new Types.InvalidIpAddress();
										if (reasonCase_ == ReasonOneofCase.InvalidIpAddress)
										{
											invalidIpAddress.MergeFrom(InvalidIpAddress);
										}
										input.ReadMessage(invalidIpAddress);
										InvalidIpAddress = invalidIpAddress;
										break;
									}
									case 58u:
									{
										Types.AlreadyInGroup alreadyInGroup = new Types.AlreadyInGroup();
										if (reasonCase_ == ReasonOneofCase.AlreadyInGroup)
										{
											alreadyInGroup.MergeFrom(AlreadyInGroup);
										}
										input.ReadMessage(alreadyInGroup);
										AlreadyInGroup = alreadyInGroup;
										break;
									}
									case 66u:
									{
										Types.CouldNotAdd couldNotAdd = new Types.CouldNotAdd();
										if (reasonCase_ == ReasonOneofCase.CouldNotAdd)
										{
											couldNotAdd.MergeFrom(CouldNotAdd);
										}
										input.ReadMessage(couldNotAdd);
										CouldNotAdd = couldNotAdd;
										break;
									}
									case 74u:
									{
										Types.CouldNotJoin couldNotJoin = new Types.CouldNotJoin();
										if (reasonCase_ == ReasonOneofCase.CouldNotJoin)
										{
											couldNotJoin.MergeFrom(CouldNotJoin);
										}
										input.ReadMessage(couldNotJoin);
										CouldNotJoin = couldNotJoin;
										break;
									}
									}
								}
							}
						}
					}

					private static readonly MessageParser<AddConnectionResult> _parser = new MessageParser<AddConnectionResult>(() => new AddConnectionResult());

					private UnknownFieldSet _unknownFields;

					public const int SuccessFieldNumber = 1;

					public const int FailureFieldNumber = 2;

					private object result_;

					private ResultOneofCase resultCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AddConnectionResult> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Success Success
					{
						get
						{
							if (resultCase_ != ResultOneofCase.Success)
							{
								return null;
							}
							return (Types.Success)result_;
						}
						set
						{
							result_ = value;
							resultCase_ = ((value != null) ? ResultOneofCase.Success : ResultOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Failure Failure
					{
						get
						{
							if (resultCase_ != ResultOneofCase.Failure)
							{
								return null;
							}
							return (Types.Failure)result_;
						}
						set
						{
							result_ = value;
							resultCase_ = ((value != null) ? ResultOneofCase.Failure : ResultOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ResultOneofCase ResultCase => resultCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AddConnectionResult()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AddConnectionResult(AddConnectionResult other)
						: this()
					{
						switch (other.ResultCase)
						{
						case ResultOneofCase.Success:
							Success = other.Success.Clone();
							break;
						case ResultOneofCase.Failure:
							Failure = other.Failure.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AddConnectionResult Clone()
					{
						return new AddConnectionResult(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearResult()
					{
						resultCase_ = ResultOneofCase.None;
						result_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AddConnectionResult);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AddConnectionResult other)
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
						if (!object.Equals(Failure, other.Failure))
						{
							return false;
						}
						if (ResultCase != other.ResultCase)
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
						if (resultCase_ == ResultOneofCase.Success)
						{
							num ^= Success.GetHashCode();
						}
						if (resultCase_ == ResultOneofCase.Failure)
						{
							num ^= Failure.GetHashCode();
						}
						num ^= (int)resultCase_;
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
						if (resultCase_ == ResultOneofCase.Success)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Success);
						}
						if (resultCase_ == ResultOneofCase.Failure)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Failure);
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
						if (resultCase_ == ResultOneofCase.Success)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Success);
						}
						if (resultCase_ == ResultOneofCase.Failure)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Failure);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(AddConnectionResult other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.ResultCase)
						{
						case ResultOneofCase.Success:
							if (Success == null)
							{
								Success = new Types.Success();
							}
							Success.MergeFrom(other.Success);
							break;
						case ResultOneofCase.Failure:
							if (Failure == null)
							{
								Failure = new Types.Failure();
							}
							Failure.MergeFrom(other.Failure);
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
								if (resultCase_ == ResultOneofCase.Success)
								{
									success.MergeFrom(Success);
								}
								input.ReadMessage(success);
								Success = success;
								break;
							}
							case 18u:
							{
								Types.Failure failure = new Types.Failure();
								if (resultCase_ == ResultOneofCase.Failure)
								{
									failure.MergeFrom(Failure);
								}
								input.ReadMessage(failure);
								Failure = failure;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class MemberStatusChange : IMessage<MemberStatusChange>, IMessage, IEquatable<MemberStatusChange>, IDeepCloneable<MemberStatusChange>
				{
					private static readonly MessageParser<MemberStatusChange> _parser = new MessageParser<MemberStatusChange>(() => new MemberStatusChange());

					private UnknownFieldSet _unknownFields;

					public const int MembersFieldNumber = 1;

					private static readonly FieldCodec<MemberStatus> _repeated_members_codec = FieldCodec.ForMessage(10u, MemberStatus.Parser);

					private readonly RepeatedField<MemberStatus> members_ = new RepeatedField<MemberStatus>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<MemberStatusChange> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[5];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<MemberStatus> Members => members_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MemberStatusChange()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MemberStatusChange(MemberStatusChange other)
						: this()
					{
						members_ = other.members_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MemberStatusChange Clone()
					{
						return new MemberStatusChange(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as MemberStatusChange);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(MemberStatusChange other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
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
						num += members_.CalculateSize(_repeated_members_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(MemberStatusChange other)
					{
						if (other != null)
						{
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								members_.AddEntriesFrom(input, _repeated_members_codec);
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ProPresenterInfo : IMessage<ProPresenterInfo>, IMessage, IEquatable<ProPresenterInfo>, IDeepCloneable<ProPresenterInfo>
				{
					private static readonly MessageParser<ProPresenterInfo> _parser = new MessageParser<ProPresenterInfo>(() => new ProPresenterInfo());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ProPresenterInfo> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[6];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProPresenterInfo()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProPresenterInfo(ProPresenterInfo other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProPresenterInfo Clone()
					{
						return new ProPresenterInfo(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ProPresenterInfo);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ProPresenterInfo other)
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
					public void MergeFrom(ProPresenterInfo other)
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
				public sealed class ServerState : IMessage<ServerState>, IMessage, IEquatable<ServerState>, IDeepCloneable<ServerState>
				{
					private static readonly MessageParser<ServerState> _parser = new MessageParser<ServerState>(() => new ServerState());

					private UnknownFieldSet _unknownFields;

					public const int LocalIpFieldNumber = 1;

					private string localIp_ = "";

					public const int PublicIpFieldNumber = 2;

					private string publicIp_ = "";

					public const int PortFieldNumber = 3;

					private uint port_;

					public const int SuccessFieldNumber = 4;

					private bool success_;

					public const int TcpStreamPortFieldNumber = 5;

					private uint tcpStreamPort_;

					public const int TcpStreamSuccessFieldNumber = 6;

					private bool tcpStreamSuccess_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ServerState> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[7];

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
					public uint Port
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
					public bool Success
					{
						get
						{
							return success_;
						}
						set
						{
							success_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint TcpStreamPort
					{
						get
						{
							return tcpStreamPort_;
						}
						set
						{
							tcpStreamPort_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool TcpStreamSuccess
					{
						get
						{
							return tcpStreamSuccess_;
						}
						set
						{
							tcpStreamSuccess_ = value;
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
						success_ = other.success_;
						tcpStreamPort_ = other.tcpStreamPort_;
						tcpStreamSuccess_ = other.tcpStreamSuccess_;
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
						if (Success != other.Success)
						{
							return false;
						}
						if (TcpStreamPort != other.TcpStreamPort)
						{
							return false;
						}
						if (TcpStreamSuccess != other.TcpStreamSuccess)
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
						if (Success)
						{
							num ^= Success.GetHashCode();
						}
						if (TcpStreamPort != 0)
						{
							num ^= TcpStreamPort.GetHashCode();
						}
						if (TcpStreamSuccess)
						{
							num ^= TcpStreamSuccess.GetHashCode();
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
							output.WriteUInt32(Port);
						}
						if (Success)
						{
							output.WriteRawTag(32);
							output.WriteBool(Success);
						}
						if (TcpStreamPort != 0)
						{
							output.WriteRawTag(40);
							output.WriteUInt32(TcpStreamPort);
						}
						if (TcpStreamSuccess)
						{
							output.WriteRawTag(48);
							output.WriteBool(TcpStreamSuccess);
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
							num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
						}
						if (Success)
						{
							num += 2;
						}
						if (TcpStreamPort != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(TcpStreamPort);
						}
						if (TcpStreamSuccess)
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
							if (other.Success)
							{
								Success = other.Success;
							}
							if (other.TcpStreamPort != 0)
							{
								TcpStreamPort = other.TcpStreamPort;
							}
							if (other.TcpStreamSuccess)
							{
								TcpStreamSuccess = other.TcpStreamSuccess;
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
								Port = input.ReadUInt32();
								break;
							case 32u:
								Success = input.ReadBool();
								break;
							case 40u:
								TcpStreamPort = input.ReadUInt32();
								break;
							case 48u:
								TcpStreamSuccess = input.ReadBool();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ConfigurationRequest : IMessage<ConfigurationRequest>, IMessage, IEquatable<ConfigurationRequest>, IDeepCloneable<ConfigurationRequest>
				{
					private static readonly MessageParser<ConfigurationRequest> _parser = new MessageParser<ConfigurationRequest>(() => new ConfigurationRequest());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ConfigurationRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[8];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ConfigurationRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ConfigurationRequest(ConfigurationRequest other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ConfigurationRequest Clone()
					{
						return new ConfigurationRequest(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ConfigurationRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ConfigurationRequest other)
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
					public void MergeFrom(ConfigurationRequest other)
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
				public sealed class LogRequest : IMessage<LogRequest>, IMessage, IEquatable<LogRequest>, IDeepCloneable<LogRequest>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Severity
						{
							[OriginalName("SEVERITY_DEBUG")]
							Debug,
							[OriginalName("SEVERITY_DEBUG_WARNING")]
							DebugWarning,
							[OriginalName("SEVERITY_INFO")]
							Info,
							[OriginalName("SEVERITY_WARNING")]
							Warning,
							[OriginalName("SEVERITY_ERROR")]
							Error,
							[OriginalName("SEVERITY_FATAL_ERROR")]
							FatalError
						}
					}

					private static readonly MessageParser<LogRequest> _parser = new MessageParser<LogRequest>(() => new LogRequest());

					private UnknownFieldSet _unknownFields;

					public const int SeverityFieldNumber = 1;

					private Types.Severity severity_;

					public const int MessageFieldNumber = 2;

					private string message_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<LogRequest> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerIn.Descriptor.NestedTypes[9];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Severity Severity
					{
						get
						{
							return severity_;
						}
						set
						{
							severity_ = value;
						}
					}

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
					public LogRequest()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LogRequest(LogRequest other)
						: this()
					{
						severity_ = other.severity_;
						message_ = other.message_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LogRequest Clone()
					{
						return new LogRequest(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as LogRequest);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(LogRequest other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Severity != other.Severity)
						{
							return false;
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
						if (Severity != 0)
						{
							num ^= Severity.GetHashCode();
						}
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
						if (Severity != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Severity);
						}
						if (Message.Length != 0)
						{
							output.WriteRawTag(18);
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
						if (Severity != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Severity);
						}
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
					public void MergeFrom(LogRequest other)
					{
						if (other != null)
						{
							if (other.Severity != 0)
							{
								Severity = other.Severity;
							}
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
							switch (num)
							{
							default:
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								break;
							case 8u:
								Severity = (Types.Severity)input.ReadEnum();
								break;
							case 18u:
								Message = input.ReadString();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<HandlerIn> _parser = new MessageParser<HandlerIn>(() => new HandlerIn());

			private UnknownFieldSet _unknownFields;

			public const int GroupNameFieldNumber = 1;

			public const int GroupDefinitionRequestFieldNumber = 2;

			public const int GroupJoinConfirmationFieldNumber = 3;

			public const int GroupJoinPasswordFieldNumber = 4;

			public const int AddConnectionResultFieldNumber = 5;

			public const int GroupUpdateFieldNumber = 6;

			public const int MemberStatusChangeFieldNumber = 7;

			public const int PropresenterInfoFieldNumber = 8;

			public const int ServerStateFieldNumber = 9;

			public const int ConfigurationRequestFieldNumber = 10;

			public const int ZeroconfigNetworkEnvironmentChangeFieldNumber = 11;

			public const int LogRequestFieldNumber = 12;

			private object request_;

			private RequestOneofCase requestCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<HandlerIn> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProLink.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GroupName GroupName
			{
				get
				{
					if (requestCase_ != RequestOneofCase.GroupName)
					{
						return null;
					}
					return (Types.GroupName)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.GroupName : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GroupDefinitionRequest GroupDefinitionRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.GroupDefinitionRequest)
					{
						return null;
					}
					return (Types.GroupDefinitionRequest)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.GroupDefinitionRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GroupJoinConfirmation GroupJoinConfirmation
			{
				get
				{
					if (requestCase_ != RequestOneofCase.GroupJoinConfirmation)
					{
						return null;
					}
					return (Types.GroupJoinConfirmation)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.GroupJoinConfirmation : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GroupJoinPassword GroupJoinPassword
			{
				get
				{
					if (requestCase_ != RequestOneofCase.GroupJoinPassword)
					{
						return null;
					}
					return (Types.GroupJoinPassword)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.GroupJoinPassword : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.AddConnectionResult AddConnectionResult
			{
				get
				{
					if (requestCase_ != RequestOneofCase.AddConnectionResult)
					{
						return null;
					}
					return (Types.AddConnectionResult)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.AddConnectionResult : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupDefinition GroupUpdate
			{
				get
				{
					if (requestCase_ != RequestOneofCase.GroupUpdate)
					{
						return null;
					}
					return (GroupDefinition)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.GroupUpdate : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.MemberStatusChange MemberStatusChange
			{
				get
				{
					if (requestCase_ != RequestOneofCase.MemberStatusChange)
					{
						return null;
					}
					return (Types.MemberStatusChange)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.MemberStatusChange : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ProPresenterInfo PropresenterInfo
			{
				get
				{
					if (requestCase_ != RequestOneofCase.PropresenterInfo)
					{
						return null;
					}
					return (Types.ProPresenterInfo)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.PropresenterInfo : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ServerState ServerState
			{
				get
				{
					if (requestCase_ != RequestOneofCase.ServerState)
					{
						return null;
					}
					return (Types.ServerState)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.ServerState : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ConfigurationRequest ConfigurationRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.ConfigurationRequest)
					{
						return null;
					}
					return (Types.ConfigurationRequest)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.ConfigurationRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ZeroConfig.Types.NetworkEnvironment ZeroconfigNetworkEnvironmentChange
			{
				get
				{
					if (requestCase_ != RequestOneofCase.ZeroconfigNetworkEnvironmentChange)
					{
						return null;
					}
					return (ZeroConfig.Types.NetworkEnvironment)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.ZeroconfigNetworkEnvironmentChange : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.LogRequest LogRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.LogRequest)
					{
						return null;
					}
					return (Types.LogRequest)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.LogRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RequestOneofCase RequestCase => requestCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public HandlerIn()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public HandlerIn(HandlerIn other)
				: this()
			{
				switch (other.RequestCase)
				{
				case RequestOneofCase.GroupName:
					GroupName = other.GroupName.Clone();
					break;
				case RequestOneofCase.GroupDefinitionRequest:
					GroupDefinitionRequest = other.GroupDefinitionRequest.Clone();
					break;
				case RequestOneofCase.GroupJoinConfirmation:
					GroupJoinConfirmation = other.GroupJoinConfirmation.Clone();
					break;
				case RequestOneofCase.GroupJoinPassword:
					GroupJoinPassword = other.GroupJoinPassword.Clone();
					break;
				case RequestOneofCase.AddConnectionResult:
					AddConnectionResult = other.AddConnectionResult.Clone();
					break;
				case RequestOneofCase.GroupUpdate:
					GroupUpdate = other.GroupUpdate.Clone();
					break;
				case RequestOneofCase.MemberStatusChange:
					MemberStatusChange = other.MemberStatusChange.Clone();
					break;
				case RequestOneofCase.PropresenterInfo:
					PropresenterInfo = other.PropresenterInfo.Clone();
					break;
				case RequestOneofCase.ServerState:
					ServerState = other.ServerState.Clone();
					break;
				case RequestOneofCase.ConfigurationRequest:
					ConfigurationRequest = other.ConfigurationRequest.Clone();
					break;
				case RequestOneofCase.ZeroconfigNetworkEnvironmentChange:
					ZeroconfigNetworkEnvironmentChange = other.ZeroconfigNetworkEnvironmentChange.Clone();
					break;
				case RequestOneofCase.LogRequest:
					LogRequest = other.LogRequest.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public HandlerIn Clone()
			{
				return new HandlerIn(this);
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
				return Equals(other as HandlerIn);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(HandlerIn other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(GroupName, other.GroupName))
				{
					return false;
				}
				if (!object.Equals(GroupDefinitionRequest, other.GroupDefinitionRequest))
				{
					return false;
				}
				if (!object.Equals(GroupJoinConfirmation, other.GroupJoinConfirmation))
				{
					return false;
				}
				if (!object.Equals(GroupJoinPassword, other.GroupJoinPassword))
				{
					return false;
				}
				if (!object.Equals(AddConnectionResult, other.AddConnectionResult))
				{
					return false;
				}
				if (!object.Equals(GroupUpdate, other.GroupUpdate))
				{
					return false;
				}
				if (!object.Equals(MemberStatusChange, other.MemberStatusChange))
				{
					return false;
				}
				if (!object.Equals(PropresenterInfo, other.PropresenterInfo))
				{
					return false;
				}
				if (!object.Equals(ServerState, other.ServerState))
				{
					return false;
				}
				if (!object.Equals(ConfigurationRequest, other.ConfigurationRequest))
				{
					return false;
				}
				if (!object.Equals(ZeroconfigNetworkEnvironmentChange, other.ZeroconfigNetworkEnvironmentChange))
				{
					return false;
				}
				if (!object.Equals(LogRequest, other.LogRequest))
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
				if (requestCase_ == RequestOneofCase.GroupName)
				{
					num ^= GroupName.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.GroupDefinitionRequest)
				{
					num ^= GroupDefinitionRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.GroupJoinConfirmation)
				{
					num ^= GroupJoinConfirmation.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.GroupJoinPassword)
				{
					num ^= GroupJoinPassword.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.AddConnectionResult)
				{
					num ^= AddConnectionResult.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.GroupUpdate)
				{
					num ^= GroupUpdate.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.MemberStatusChange)
				{
					num ^= MemberStatusChange.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.PropresenterInfo)
				{
					num ^= PropresenterInfo.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.ServerState)
				{
					num ^= ServerState.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.ConfigurationRequest)
				{
					num ^= ConfigurationRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.ZeroconfigNetworkEnvironmentChange)
				{
					num ^= ZeroconfigNetworkEnvironmentChange.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.LogRequest)
				{
					num ^= LogRequest.GetHashCode();
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
				if (requestCase_ == RequestOneofCase.GroupName)
				{
					output.WriteRawTag(10);
					output.WriteMessage(GroupName);
				}
				if (requestCase_ == RequestOneofCase.GroupDefinitionRequest)
				{
					output.WriteRawTag(18);
					output.WriteMessage(GroupDefinitionRequest);
				}
				if (requestCase_ == RequestOneofCase.GroupJoinConfirmation)
				{
					output.WriteRawTag(26);
					output.WriteMessage(GroupJoinConfirmation);
				}
				if (requestCase_ == RequestOneofCase.GroupJoinPassword)
				{
					output.WriteRawTag(34);
					output.WriteMessage(GroupJoinPassword);
				}
				if (requestCase_ == RequestOneofCase.AddConnectionResult)
				{
					output.WriteRawTag(42);
					output.WriteMessage(AddConnectionResult);
				}
				if (requestCase_ == RequestOneofCase.GroupUpdate)
				{
					output.WriteRawTag(50);
					output.WriteMessage(GroupUpdate);
				}
				if (requestCase_ == RequestOneofCase.MemberStatusChange)
				{
					output.WriteRawTag(58);
					output.WriteMessage(MemberStatusChange);
				}
				if (requestCase_ == RequestOneofCase.PropresenterInfo)
				{
					output.WriteRawTag(66);
					output.WriteMessage(PropresenterInfo);
				}
				if (requestCase_ == RequestOneofCase.ServerState)
				{
					output.WriteRawTag(74);
					output.WriteMessage(ServerState);
				}
				if (requestCase_ == RequestOneofCase.ConfigurationRequest)
				{
					output.WriteRawTag(82);
					output.WriteMessage(ConfigurationRequest);
				}
				if (requestCase_ == RequestOneofCase.ZeroconfigNetworkEnvironmentChange)
				{
					output.WriteRawTag(90);
					output.WriteMessage(ZeroconfigNetworkEnvironmentChange);
				}
				if (requestCase_ == RequestOneofCase.LogRequest)
				{
					output.WriteRawTag(98);
					output.WriteMessage(LogRequest);
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
				if (requestCase_ == RequestOneofCase.GroupName)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupName);
				}
				if (requestCase_ == RequestOneofCase.GroupDefinitionRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinitionRequest);
				}
				if (requestCase_ == RequestOneofCase.GroupJoinConfirmation)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupJoinConfirmation);
				}
				if (requestCase_ == RequestOneofCase.GroupJoinPassword)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupJoinPassword);
				}
				if (requestCase_ == RequestOneofCase.AddConnectionResult)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AddConnectionResult);
				}
				if (requestCase_ == RequestOneofCase.GroupUpdate)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupUpdate);
				}
				if (requestCase_ == RequestOneofCase.MemberStatusChange)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MemberStatusChange);
				}
				if (requestCase_ == RequestOneofCase.PropresenterInfo)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PropresenterInfo);
				}
				if (requestCase_ == RequestOneofCase.ServerState)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ServerState);
				}
				if (requestCase_ == RequestOneofCase.ConfigurationRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ConfigurationRequest);
				}
				if (requestCase_ == RequestOneofCase.ZeroconfigNetworkEnvironmentChange)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ZeroconfigNetworkEnvironmentChange);
				}
				if (requestCase_ == RequestOneofCase.LogRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LogRequest);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(HandlerIn other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.RequestCase)
				{
				case RequestOneofCase.GroupName:
					if (GroupName == null)
					{
						GroupName = new Types.GroupName();
					}
					GroupName.MergeFrom(other.GroupName);
					break;
				case RequestOneofCase.GroupDefinitionRequest:
					if (GroupDefinitionRequest == null)
					{
						GroupDefinitionRequest = new Types.GroupDefinitionRequest();
					}
					GroupDefinitionRequest.MergeFrom(other.GroupDefinitionRequest);
					break;
				case RequestOneofCase.GroupJoinConfirmation:
					if (GroupJoinConfirmation == null)
					{
						GroupJoinConfirmation = new Types.GroupJoinConfirmation();
					}
					GroupJoinConfirmation.MergeFrom(other.GroupJoinConfirmation);
					break;
				case RequestOneofCase.GroupJoinPassword:
					if (GroupJoinPassword == null)
					{
						GroupJoinPassword = new Types.GroupJoinPassword();
					}
					GroupJoinPassword.MergeFrom(other.GroupJoinPassword);
					break;
				case RequestOneofCase.AddConnectionResult:
					if (AddConnectionResult == null)
					{
						AddConnectionResult = new Types.AddConnectionResult();
					}
					AddConnectionResult.MergeFrom(other.AddConnectionResult);
					break;
				case RequestOneofCase.GroupUpdate:
					if (GroupUpdate == null)
					{
						GroupUpdate = new GroupDefinition();
					}
					GroupUpdate.MergeFrom(other.GroupUpdate);
					break;
				case RequestOneofCase.MemberStatusChange:
					if (MemberStatusChange == null)
					{
						MemberStatusChange = new Types.MemberStatusChange();
					}
					MemberStatusChange.MergeFrom(other.MemberStatusChange);
					break;
				case RequestOneofCase.PropresenterInfo:
					if (PropresenterInfo == null)
					{
						PropresenterInfo = new Types.ProPresenterInfo();
					}
					PropresenterInfo.MergeFrom(other.PropresenterInfo);
					break;
				case RequestOneofCase.ServerState:
					if (ServerState == null)
					{
						ServerState = new Types.ServerState();
					}
					ServerState.MergeFrom(other.ServerState);
					break;
				case RequestOneofCase.ConfigurationRequest:
					if (ConfigurationRequest == null)
					{
						ConfigurationRequest = new Types.ConfigurationRequest();
					}
					ConfigurationRequest.MergeFrom(other.ConfigurationRequest);
					break;
				case RequestOneofCase.ZeroconfigNetworkEnvironmentChange:
					if (ZeroconfigNetworkEnvironmentChange == null)
					{
						ZeroconfigNetworkEnvironmentChange = new ZeroConfig.Types.NetworkEnvironment();
					}
					ZeroconfigNetworkEnvironmentChange.MergeFrom(other.ZeroconfigNetworkEnvironmentChange);
					break;
				case RequestOneofCase.LogRequest:
					if (LogRequest == null)
					{
						LogRequest = new Types.LogRequest();
					}
					LogRequest.MergeFrom(other.LogRequest);
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
						Types.GroupName groupName = new Types.GroupName();
						if (requestCase_ == RequestOneofCase.GroupName)
						{
							groupName.MergeFrom(GroupName);
						}
						input.ReadMessage(groupName);
						GroupName = groupName;
						break;
					}
					case 18u:
					{
						Types.GroupDefinitionRequest groupDefinitionRequest = new Types.GroupDefinitionRequest();
						if (requestCase_ == RequestOneofCase.GroupDefinitionRequest)
						{
							groupDefinitionRequest.MergeFrom(GroupDefinitionRequest);
						}
						input.ReadMessage(groupDefinitionRequest);
						GroupDefinitionRequest = groupDefinitionRequest;
						break;
					}
					case 26u:
					{
						Types.GroupJoinConfirmation groupJoinConfirmation = new Types.GroupJoinConfirmation();
						if (requestCase_ == RequestOneofCase.GroupJoinConfirmation)
						{
							groupJoinConfirmation.MergeFrom(GroupJoinConfirmation);
						}
						input.ReadMessage(groupJoinConfirmation);
						GroupJoinConfirmation = groupJoinConfirmation;
						break;
					}
					case 34u:
					{
						Types.GroupJoinPassword groupJoinPassword = new Types.GroupJoinPassword();
						if (requestCase_ == RequestOneofCase.GroupJoinPassword)
						{
							groupJoinPassword.MergeFrom(GroupJoinPassword);
						}
						input.ReadMessage(groupJoinPassword);
						GroupJoinPassword = groupJoinPassword;
						break;
					}
					case 42u:
					{
						Types.AddConnectionResult addConnectionResult = new Types.AddConnectionResult();
						if (requestCase_ == RequestOneofCase.AddConnectionResult)
						{
							addConnectionResult.MergeFrom(AddConnectionResult);
						}
						input.ReadMessage(addConnectionResult);
						AddConnectionResult = addConnectionResult;
						break;
					}
					case 50u:
					{
						GroupDefinition groupDefinition = new GroupDefinition();
						if (requestCase_ == RequestOneofCase.GroupUpdate)
						{
							groupDefinition.MergeFrom(GroupUpdate);
						}
						input.ReadMessage(groupDefinition);
						GroupUpdate = groupDefinition;
						break;
					}
					case 58u:
					{
						Types.MemberStatusChange memberStatusChange = new Types.MemberStatusChange();
						if (requestCase_ == RequestOneofCase.MemberStatusChange)
						{
							memberStatusChange.MergeFrom(MemberStatusChange);
						}
						input.ReadMessage(memberStatusChange);
						MemberStatusChange = memberStatusChange;
						break;
					}
					case 66u:
					{
						Types.ProPresenterInfo proPresenterInfo = new Types.ProPresenterInfo();
						if (requestCase_ == RequestOneofCase.PropresenterInfo)
						{
							proPresenterInfo.MergeFrom(PropresenterInfo);
						}
						input.ReadMessage(proPresenterInfo);
						PropresenterInfo = proPresenterInfo;
						break;
					}
					case 74u:
					{
						Types.ServerState serverState = new Types.ServerState();
						if (requestCase_ == RequestOneofCase.ServerState)
						{
							serverState.MergeFrom(ServerState);
						}
						input.ReadMessage(serverState);
						ServerState = serverState;
						break;
					}
					case 82u:
					{
						Types.ConfigurationRequest configurationRequest = new Types.ConfigurationRequest();
						if (requestCase_ == RequestOneofCase.ConfigurationRequest)
						{
							configurationRequest.MergeFrom(ConfigurationRequest);
						}
						input.ReadMessage(configurationRequest);
						ConfigurationRequest = configurationRequest;
						break;
					}
					case 90u:
					{
						ZeroConfig.Types.NetworkEnvironment networkEnvironment = new ZeroConfig.Types.NetworkEnvironment();
						if (requestCase_ == RequestOneofCase.ZeroconfigNetworkEnvironmentChange)
						{
							networkEnvironment.MergeFrom(ZeroconfigNetworkEnvironmentChange);
						}
						input.ReadMessage(networkEnvironment);
						ZeroconfigNetworkEnvironmentChange = networkEnvironment;
						break;
					}
					case 98u:
					{
						Types.LogRequest logRequest = new Types.LogRequest();
						if (requestCase_ == RequestOneofCase.LogRequest)
						{
							logRequest.MergeFrom(LogRequest);
						}
						input.ReadMessage(logRequest);
						LogRequest = logRequest;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class HandlerOut : IMessage<HandlerOut>, IMessage, IEquatable<HandlerOut>, IDeepCloneable<HandlerOut>
		{
			public enum ResponseOneofCase
			{
				None,
				GroupName,
				GroupDefinition,
				GroupJoinConfirmation,
				GroupJoinPassword,
				PropresenterInfo,
				Configuration
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GroupName : IMessage<GroupName>, IMessage, IEquatable<GroupName>, IDeepCloneable<GroupName>
				{
					private static readonly MessageParser<GroupName> _parser = new MessageParser<GroupName>(() => new GroupName());

					private UnknownFieldSet _unknownFields;

					public const int NameFieldNumber = 1;

					private string name_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GroupName> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerOut.Descriptor.NestedTypes[0];

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
					public GroupName()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupName(GroupName other)
						: this()
					{
						name_ = other.name_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupName Clone()
					{
						return new GroupName(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GroupName);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GroupName other)
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(GroupName other)
					{
						if (other != null)
						{
							if (other.Name.Length != 0)
							{
								Name = other.Name;
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
								Name = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GroupJoinConfirmation : IMessage<GroupJoinConfirmation>, IMessage, IEquatable<GroupJoinConfirmation>, IDeepCloneable<GroupJoinConfirmation>
				{
					private static readonly MessageParser<GroupJoinConfirmation> _parser = new MessageParser<GroupJoinConfirmation>(() => new GroupJoinConfirmation());

					private UnknownFieldSet _unknownFields;

					public const int AcceptFieldNumber = 1;

					private bool accept_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GroupJoinConfirmation> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerOut.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Accept
					{
						get
						{
							return accept_;
						}
						set
						{
							accept_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinConfirmation()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinConfirmation(GroupJoinConfirmation other)
						: this()
					{
						accept_ = other.accept_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinConfirmation Clone()
					{
						return new GroupJoinConfirmation(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GroupJoinConfirmation);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GroupJoinConfirmation other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Accept != other.Accept)
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
						if (Accept)
						{
							num ^= Accept.GetHashCode();
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
						if (Accept)
						{
							output.WriteRawTag(8);
							output.WriteBool(Accept);
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
						if (Accept)
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
					public void MergeFrom(GroupJoinConfirmation other)
					{
						if (other != null)
						{
							if (other.Accept)
							{
								Accept = other.Accept;
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
								Accept = input.ReadBool();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GroupJoinPassword : IMessage<GroupJoinPassword>, IMessage, IEquatable<GroupJoinPassword>, IDeepCloneable<GroupJoinPassword>
				{
					private static readonly MessageParser<GroupJoinPassword> _parser = new MessageParser<GroupJoinPassword>(() => new GroupJoinPassword());

					private UnknownFieldSet _unknownFields;

					public const int PasswordFieldNumber = 1;

					private string password_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GroupJoinPassword> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerOut.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
					public GroupJoinPassword()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinPassword(GroupJoinPassword other)
						: this()
					{
						password_ = other.password_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GroupJoinPassword Clone()
					{
						return new GroupJoinPassword(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GroupJoinPassword);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GroupJoinPassword other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Password != other.Password)
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
						if (Password.Length != 0)
						{
							num ^= Password.GetHashCode();
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
						if (Password.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Password);
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
						if (Password.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Password);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(GroupJoinPassword other)
					{
						if (other != null)
						{
							if (other.Password.Length != 0)
							{
								Password = other.Password;
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
								Password = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ProPresenterInfo : IMessage<ProPresenterInfo>, IMessage, IEquatable<ProPresenterInfo>, IDeepCloneable<ProPresenterInfo>
				{
					private static readonly MessageParser<ProPresenterInfo> _parser = new MessageParser<ProPresenterInfo>(() => new ProPresenterInfo());

					private UnknownFieldSet _unknownFields;

					public const int PlatformFieldNumber = 1;

					private ApplicationInfo.Types.Platform platform_;

					public const int OsVersionFieldNumber = 2;

					private string osVersion_ = "";

					public const int HostDescriptionFieldNumber = 3;

					private string hostDescription_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ProPresenterInfo> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => HandlerOut.Descriptor.NestedTypes[3];

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
					public string HostDescription
					{
						get
						{
							return hostDescription_;
						}
						set
						{
							hostDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProPresenterInfo()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProPresenterInfo(ProPresenterInfo other)
						: this()
					{
						platform_ = other.platform_;
						osVersion_ = other.osVersion_;
						hostDescription_ = other.hostDescription_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProPresenterInfo Clone()
					{
						return new ProPresenterInfo(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ProPresenterInfo);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ProPresenterInfo other)
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
						if (HostDescription != other.HostDescription)
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
						if (HostDescription.Length != 0)
						{
							num ^= HostDescription.GetHashCode();
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
						if (HostDescription.Length != 0)
						{
							output.WriteRawTag(26);
							output.WriteString(HostDescription);
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
						if (HostDescription.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(HostDescription);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(ProPresenterInfo other)
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
							if (other.HostDescription.Length != 0)
							{
								HostDescription = other.HostDescription;
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
								HostDescription = input.ReadString();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<HandlerOut> _parser = new MessageParser<HandlerOut>(() => new HandlerOut());

			private UnknownFieldSet _unknownFields;

			public const int GroupNameFieldNumber = 1;

			public const int GroupDefinitionFieldNumber = 2;

			public const int GroupJoinConfirmationFieldNumber = 3;

			public const int GroupJoinPasswordFieldNumber = 4;

			public const int PropresenterInfoFieldNumber = 5;

			public const int ConfigurationFieldNumber = 6;

			private object response_;

			private ResponseOneofCase responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<HandlerOut> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProLink.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GroupName GroupName
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.GroupName)
					{
						return null;
					}
					return (Types.GroupName)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.GroupName : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupDefinition GroupDefinition
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.GroupDefinition)
					{
						return null;
					}
					return (GroupDefinition)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.GroupDefinition : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GroupJoinConfirmation GroupJoinConfirmation
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.GroupJoinConfirmation)
					{
						return null;
					}
					return (Types.GroupJoinConfirmation)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.GroupJoinConfirmation : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GroupJoinPassword GroupJoinPassword
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.GroupJoinPassword)
					{
						return null;
					}
					return (Types.GroupJoinPassword)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.GroupJoinPassword : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ProPresenterInfo PropresenterInfo
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.PropresenterInfo)
					{
						return null;
					}
					return (Types.ProPresenterInfo)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.PropresenterInfo : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProApiNetworkConfiguration Configuration
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Configuration)
					{
						return null;
					}
					return (ProApiNetworkConfiguration)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Configuration : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResponseOneofCase ResponseCase => responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public HandlerOut()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public HandlerOut(HandlerOut other)
				: this()
			{
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.GroupName:
					GroupName = other.GroupName.Clone();
					break;
				case ResponseOneofCase.GroupDefinition:
					GroupDefinition = other.GroupDefinition.Clone();
					break;
				case ResponseOneofCase.GroupJoinConfirmation:
					GroupJoinConfirmation = other.GroupJoinConfirmation.Clone();
					break;
				case ResponseOneofCase.GroupJoinPassword:
					GroupJoinPassword = other.GroupJoinPassword.Clone();
					break;
				case ResponseOneofCase.PropresenterInfo:
					PropresenterInfo = other.PropresenterInfo.Clone();
					break;
				case ResponseOneofCase.Configuration:
					Configuration = other.Configuration.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public HandlerOut Clone()
			{
				return new HandlerOut(this);
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
				return Equals(other as HandlerOut);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(HandlerOut other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(GroupName, other.GroupName))
				{
					return false;
				}
				if (!object.Equals(GroupDefinition, other.GroupDefinition))
				{
					return false;
				}
				if (!object.Equals(GroupJoinConfirmation, other.GroupJoinConfirmation))
				{
					return false;
				}
				if (!object.Equals(GroupJoinPassword, other.GroupJoinPassword))
				{
					return false;
				}
				if (!object.Equals(PropresenterInfo, other.PropresenterInfo))
				{
					return false;
				}
				if (!object.Equals(Configuration, other.Configuration))
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
				if (responseCase_ == ResponseOneofCase.GroupName)
				{
					num ^= GroupName.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.GroupDefinition)
				{
					num ^= GroupDefinition.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.GroupJoinConfirmation)
				{
					num ^= GroupJoinConfirmation.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.GroupJoinPassword)
				{
					num ^= GroupJoinPassword.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.PropresenterInfo)
				{
					num ^= PropresenterInfo.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Configuration)
				{
					num ^= Configuration.GetHashCode();
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
				if (responseCase_ == ResponseOneofCase.GroupName)
				{
					output.WriteRawTag(10);
					output.WriteMessage(GroupName);
				}
				if (responseCase_ == ResponseOneofCase.GroupDefinition)
				{
					output.WriteRawTag(18);
					output.WriteMessage(GroupDefinition);
				}
				if (responseCase_ == ResponseOneofCase.GroupJoinConfirmation)
				{
					output.WriteRawTag(26);
					output.WriteMessage(GroupJoinConfirmation);
				}
				if (responseCase_ == ResponseOneofCase.GroupJoinPassword)
				{
					output.WriteRawTag(34);
					output.WriteMessage(GroupJoinPassword);
				}
				if (responseCase_ == ResponseOneofCase.PropresenterInfo)
				{
					output.WriteRawTag(42);
					output.WriteMessage(PropresenterInfo);
				}
				if (responseCase_ == ResponseOneofCase.Configuration)
				{
					output.WriteRawTag(50);
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
				if (responseCase_ == ResponseOneofCase.GroupName)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupName);
				}
				if (responseCase_ == ResponseOneofCase.GroupDefinition)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
				}
				if (responseCase_ == ResponseOneofCase.GroupJoinConfirmation)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupJoinConfirmation);
				}
				if (responseCase_ == ResponseOneofCase.GroupJoinPassword)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupJoinPassword);
				}
				if (responseCase_ == ResponseOneofCase.PropresenterInfo)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PropresenterInfo);
				}
				if (responseCase_ == ResponseOneofCase.Configuration)
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
			public void MergeFrom(HandlerOut other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.GroupName:
					if (GroupName == null)
					{
						GroupName = new Types.GroupName();
					}
					GroupName.MergeFrom(other.GroupName);
					break;
				case ResponseOneofCase.GroupDefinition:
					if (GroupDefinition == null)
					{
						GroupDefinition = new GroupDefinition();
					}
					GroupDefinition.MergeFrom(other.GroupDefinition);
					break;
				case ResponseOneofCase.GroupJoinConfirmation:
					if (GroupJoinConfirmation == null)
					{
						GroupJoinConfirmation = new Types.GroupJoinConfirmation();
					}
					GroupJoinConfirmation.MergeFrom(other.GroupJoinConfirmation);
					break;
				case ResponseOneofCase.GroupJoinPassword:
					if (GroupJoinPassword == null)
					{
						GroupJoinPassword = new Types.GroupJoinPassword();
					}
					GroupJoinPassword.MergeFrom(other.GroupJoinPassword);
					break;
				case ResponseOneofCase.PropresenterInfo:
					if (PropresenterInfo == null)
					{
						PropresenterInfo = new Types.ProPresenterInfo();
					}
					PropresenterInfo.MergeFrom(other.PropresenterInfo);
					break;
				case ResponseOneofCase.Configuration:
					if (Configuration == null)
					{
						Configuration = new ProApiNetworkConfiguration();
					}
					Configuration.MergeFrom(other.Configuration);
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
						Types.GroupName groupName = new Types.GroupName();
						if (responseCase_ == ResponseOneofCase.GroupName)
						{
							groupName.MergeFrom(GroupName);
						}
						input.ReadMessage(groupName);
						GroupName = groupName;
						break;
					}
					case 18u:
					{
						GroupDefinition groupDefinition = new GroupDefinition();
						if (responseCase_ == ResponseOneofCase.GroupDefinition)
						{
							groupDefinition.MergeFrom(GroupDefinition);
						}
						input.ReadMessage(groupDefinition);
						GroupDefinition = groupDefinition;
						break;
					}
					case 26u:
					{
						Types.GroupJoinConfirmation groupJoinConfirmation = new Types.GroupJoinConfirmation();
						if (responseCase_ == ResponseOneofCase.GroupJoinConfirmation)
						{
							groupJoinConfirmation.MergeFrom(GroupJoinConfirmation);
						}
						input.ReadMessage(groupJoinConfirmation);
						GroupJoinConfirmation = groupJoinConfirmation;
						break;
					}
					case 34u:
					{
						Types.GroupJoinPassword groupJoinPassword = new Types.GroupJoinPassword();
						if (responseCase_ == ResponseOneofCase.GroupJoinPassword)
						{
							groupJoinPassword.MergeFrom(GroupJoinPassword);
						}
						input.ReadMessage(groupJoinPassword);
						GroupJoinPassword = groupJoinPassword;
						break;
					}
					case 42u:
					{
						Types.ProPresenterInfo proPresenterInfo = new Types.ProPresenterInfo();
						if (responseCase_ == ResponseOneofCase.PropresenterInfo)
						{
							proPresenterInfo.MergeFrom(PropresenterInfo);
						}
						input.ReadMessage(proPresenterInfo);
						PropresenterInfo = proPresenterInfo;
						break;
					}
					case 50u:
					{
						ProApiNetworkConfiguration proApiNetworkConfiguration = new ProApiNetworkConfiguration();
						if (responseCase_ == ResponseOneofCase.Configuration)
						{
							proApiNetworkConfiguration.MergeFrom(Configuration);
						}
						input.ReadMessage(proApiNetworkConfiguration);
						Configuration = proApiNetworkConfiguration;
						break;
					}
					}
				}
			}
		}
	}

	private static readonly MessageParser<ProLink> _parser = new MessageParser<ProLink>(() => new ProLink());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProLink> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLink()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLink(ProLink other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLink Clone()
	{
		return new ProLink(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProLink);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProLink other)
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
	public void MergeFrom(ProLink other)
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
