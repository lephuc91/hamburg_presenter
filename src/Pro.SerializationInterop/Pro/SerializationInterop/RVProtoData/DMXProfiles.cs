using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DMXProfiles : IMessage<DMXProfiles>, IMessage, IEquatable<DMXProfiles>, IDeepCloneable<DMXProfiles>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DMXProfile : IMessage<DMXProfile>, IMessage, IEquatable<DMXProfile>, IDeepCloneable<DMXProfile>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ProfileType
				{
					[OriginalName("BASIC")]
					Basic,
					[OriginalName("ADVANCED")]
					Advanced,
					[OriginalName("CUSTOM")]
					Custom
				}

				public enum FixtureType
				{
					[OriginalName("WORKSPACE")]
					Workspace,
					[OriginalName("LAYER")]
					Layer
				}

				public enum CommandType
				{
					[OriginalName("OPACITY")]
					Opacity,
					[OriginalName("BLEND_MODE")]
					BlendMode,
					[OriginalName("SELECT_CUE")]
					SelectCue,
					[OriginalName("CONTROL_TYPE")]
					ControlType,
					[OriginalName("CONTROL_VALUE")]
					ControlValue,
					[OriginalName("TRANSITION_DURATION")]
					TransitionDuration,
					[OriginalName("SELECT_PLAYLIST")]
					SelectPlaylist,
					[OriginalName("TARGETED_LAYER")]
					TargetedLayer
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Profile : IMessage<Profile>, IMessage, IEquatable<Profile>, IDeepCloneable<Profile>
				{
					public enum StartingChannelOneofOneofCase
					{
						None = 0,
						StartingChannel = 2
					}

					private static readonly MessageParser<Profile> _parser = new MessageParser<Profile>(() => new Profile());

					private UnknownFieldSet _unknownFields;

					public const int ProfileTypeFieldNumber = 1;

					private ProfileType profileType_;

					public const int StartingChannelFieldNumber = 2;

					private object startingChannelOneof_;

					private StartingChannelOneofOneofCase startingChannelOneofCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Profile> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => DMXProfile.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProfileType ProfileType
					{
						get
						{
							return profileType_;
						}
						set
						{
							profileType_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint StartingChannel
					{
						get
						{
							if (!HasStartingChannel)
							{
								return 0u;
							}
							return (uint)startingChannelOneof_;
						}
						set
						{
							startingChannelOneof_ = value;
							startingChannelOneofCase_ = StartingChannelOneofOneofCase.StartingChannel;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool HasStartingChannel => startingChannelOneofCase_ == StartingChannelOneofOneofCase.StartingChannel;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StartingChannelOneofOneofCase StartingChannelOneofCase => startingChannelOneofCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Profile()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Profile(Profile other)
						: this()
					{
						profileType_ = other.profileType_;
						if (other.StartingChannelOneofCase == StartingChannelOneofOneofCase.StartingChannel)
						{
							StartingChannel = other.StartingChannel;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Profile Clone()
					{
						return new Profile(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearStartingChannel()
					{
						if (HasStartingChannel)
						{
							ClearStartingChannelOneof();
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearStartingChannelOneof()
					{
						startingChannelOneofCase_ = StartingChannelOneofOneofCase.None;
						startingChannelOneof_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Profile);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Profile other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (ProfileType != other.ProfileType)
						{
							return false;
						}
						if (StartingChannel != other.StartingChannel)
						{
							return false;
						}
						if (StartingChannelOneofCase != other.StartingChannelOneofCase)
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
						if (ProfileType != 0)
						{
							num ^= ProfileType.GetHashCode();
						}
						if (HasStartingChannel)
						{
							num ^= StartingChannel.GetHashCode();
						}
						num ^= (int)startingChannelOneofCase_;
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
						if (ProfileType != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)ProfileType);
						}
						if (HasStartingChannel)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(StartingChannel);
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
						if (ProfileType != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)ProfileType);
						}
						if (HasStartingChannel)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(StartingChannel);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Profile other)
					{
						if (other != null)
						{
							if (other.ProfileType != 0)
							{
								ProfileType = other.ProfileType;
							}
							if (other.StartingChannelOneofCase == StartingChannelOneofOneofCase.StartingChannel)
							{
								StartingChannel = other.StartingChannel;
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
								ProfileType = (ProfileType)input.ReadEnum();
								break;
							case 16u:
								StartingChannel = input.ReadUInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ChannelMapping : IMessage<ChannelMapping>, IMessage, IEquatable<ChannelMapping>, IDeepCloneable<ChannelMapping>
				{
					private static readonly MessageParser<ChannelMapping> _parser = new MessageParser<ChannelMapping>(() => new ChannelMapping());

					private UnknownFieldSet _unknownFields;

					public const int ChannelIndexFieldNumber = 1;

					private uint channelIndex_;

					public const int CommandFieldNumber = 2;

					private CommandType command_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ChannelMapping> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => DMXProfile.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint ChannelIndex
					{
						get
						{
							return channelIndex_;
						}
						set
						{
							channelIndex_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CommandType Command
					{
						get
						{
							return command_;
						}
						set
						{
							command_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChannelMapping()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChannelMapping(ChannelMapping other)
						: this()
					{
						channelIndex_ = other.channelIndex_;
						command_ = other.command_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChannelMapping Clone()
					{
						return new ChannelMapping(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ChannelMapping);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ChannelMapping other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (ChannelIndex != other.ChannelIndex)
						{
							return false;
						}
						if (Command != other.Command)
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
						if (ChannelIndex != 0)
						{
							num ^= ChannelIndex.GetHashCode();
						}
						if (Command != 0)
						{
							num ^= Command.GetHashCode();
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
						if (ChannelIndex != 0)
						{
							output.WriteRawTag(8);
							output.WriteUInt32(ChannelIndex);
						}
						if (Command != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)Command);
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
						if (ChannelIndex != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(ChannelIndex);
						}
						if (Command != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Command);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(ChannelMapping other)
					{
						if (other != null)
						{
							if (other.ChannelIndex != 0)
							{
								ChannelIndex = other.ChannelIndex;
							}
							if (other.Command != 0)
							{
								Command = other.Command;
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
								ChannelIndex = input.ReadUInt32();
								break;
							case 16u:
								Command = (CommandType)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Fixture : IMessage<Fixture>, IMessage, IEquatable<Fixture>, IDeepCloneable<Fixture>
				{
					public enum LayerIndexOneofOneofCase
					{
						None = 0,
						LayerIndex = 2
					}

					private static readonly MessageParser<Fixture> _parser = new MessageParser<Fixture>(() => new Fixture());

					private UnknownFieldSet _unknownFields;

					public const int FixtureTypeFieldNumber = 1;

					private FixtureType fixtureType_;

					public const int LayerIndexFieldNumber = 2;

					private object layerIndexOneof_;

					private LayerIndexOneofOneofCase layerIndexOneofCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Fixture> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => DMXProfile.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public FixtureType FixtureType
					{
						get
						{
							return fixtureType_;
						}
						set
						{
							fixtureType_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint LayerIndex
					{
						get
						{
							if (!HasLayerIndex)
							{
								return 0u;
							}
							return (uint)layerIndexOneof_;
						}
						set
						{
							layerIndexOneof_ = value;
							layerIndexOneofCase_ = LayerIndexOneofOneofCase.LayerIndex;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool HasLayerIndex => layerIndexOneofCase_ == LayerIndexOneofOneofCase.LayerIndex;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LayerIndexOneofOneofCase LayerIndexOneofCase => layerIndexOneofCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Fixture()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Fixture(Fixture other)
						: this()
					{
						fixtureType_ = other.fixtureType_;
						if (other.LayerIndexOneofCase == LayerIndexOneofOneofCase.LayerIndex)
						{
							LayerIndex = other.LayerIndex;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Fixture Clone()
					{
						return new Fixture(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearLayerIndex()
					{
						if (HasLayerIndex)
						{
							ClearLayerIndexOneof();
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearLayerIndexOneof()
					{
						layerIndexOneofCase_ = LayerIndexOneofOneofCase.None;
						layerIndexOneof_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Fixture);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Fixture other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (FixtureType != other.FixtureType)
						{
							return false;
						}
						if (LayerIndex != other.LayerIndex)
						{
							return false;
						}
						if (LayerIndexOneofCase != other.LayerIndexOneofCase)
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
						if (FixtureType != 0)
						{
							num ^= FixtureType.GetHashCode();
						}
						if (HasLayerIndex)
						{
							num ^= LayerIndex.GetHashCode();
						}
						num ^= (int)layerIndexOneofCase_;
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
						if (FixtureType != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)FixtureType);
						}
						if (HasLayerIndex)
						{
							output.WriteRawTag(16);
							output.WriteUInt32(LayerIndex);
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
						if (FixtureType != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)FixtureType);
						}
						if (HasLayerIndex)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(LayerIndex);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Fixture other)
					{
						if (other != null)
						{
							if (other.FixtureType != 0)
							{
								FixtureType = other.FixtureType;
							}
							if (other.LayerIndexOneofCase == LayerIndexOneofOneofCase.LayerIndex)
							{
								LayerIndex = other.LayerIndex;
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
								FixtureType = (FixtureType)input.ReadEnum();
								break;
							case 16u:
								LayerIndex = input.ReadUInt32();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<DMXProfile> _parser = new MessageParser<DMXProfile>(() => new DMXProfile());

			private UnknownFieldSet _unknownFields;

			public const int ProfileFieldNumber = 1;

			private Types.Profile profile_;

			public const int FixtureFieldNumber = 2;

			private Types.Fixture fixture_;

			public const int IsEnabledFieldNumber = 3;

			private bool isEnabled_;

			public const int CustomMappingsFieldNumber = 4;

			private static readonly FieldCodec<Types.ChannelMapping> _repeated_customMappings_codec = FieldCodec.ForMessage(34u, Types.ChannelMapping.Parser);

			private readonly RepeatedField<Types.ChannelMapping> customMappings_ = new RepeatedField<Types.ChannelMapping>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DMXProfile> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => DMXProfiles.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Profile Profile
			{
				get
				{
					return profile_;
				}
				set
				{
					profile_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Fixture Fixture
			{
				get
				{
					return fixture_;
				}
				set
				{
					fixture_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsEnabled
			{
				get
				{
					return isEnabled_;
				}
				set
				{
					isEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.ChannelMapping> CustomMappings => customMappings_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DMXProfile()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DMXProfile(DMXProfile other)
				: this()
			{
				profile_ = ((other.profile_ != null) ? other.profile_.Clone() : null);
				fixture_ = ((other.fixture_ != null) ? other.fixture_.Clone() : null);
				isEnabled_ = other.isEnabled_;
				customMappings_ = other.customMappings_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DMXProfile Clone()
			{
				return new DMXProfile(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DMXProfile);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DMXProfile other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Profile, other.Profile))
				{
					return false;
				}
				if (!object.Equals(Fixture, other.Fixture))
				{
					return false;
				}
				if (IsEnabled != other.IsEnabled)
				{
					return false;
				}
				if (!customMappings_.Equals(other.customMappings_))
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
				if (profile_ != null)
				{
					num ^= Profile.GetHashCode();
				}
				if (fixture_ != null)
				{
					num ^= Fixture.GetHashCode();
				}
				if (IsEnabled)
				{
					num ^= IsEnabled.GetHashCode();
				}
				num ^= customMappings_.GetHashCode();
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
				if (profile_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Profile);
				}
				if (fixture_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Fixture);
				}
				if (IsEnabled)
				{
					output.WriteRawTag(24);
					output.WriteBool(IsEnabled);
				}
				customMappings_.WriteTo(output, _repeated_customMappings_codec);
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
				if (profile_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Profile);
				}
				if (fixture_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Fixture);
				}
				if (IsEnabled)
				{
					num += 2;
				}
				num += customMappings_.CalculateSize(_repeated_customMappings_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DMXProfile other)
			{
				if (other == null)
				{
					return;
				}
				if (other.profile_ != null)
				{
					if (profile_ == null)
					{
						Profile = new Types.Profile();
					}
					Profile.MergeFrom(other.Profile);
				}
				if (other.fixture_ != null)
				{
					if (fixture_ == null)
					{
						Fixture = new Types.Fixture();
					}
					Fixture.MergeFrom(other.Fixture);
				}
				if (other.IsEnabled)
				{
					IsEnabled = other.IsEnabled;
				}
				customMappings_.Add(other.customMappings_);
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
						if (profile_ == null)
						{
							Profile = new Types.Profile();
						}
						input.ReadMessage(Profile);
						break;
					case 18u:
						if (fixture_ == null)
						{
							Fixture = new Types.Fixture();
						}
						input.ReadMessage(Fixture);
						break;
					case 24u:
						IsEnabled = input.ReadBool();
						break;
					case 34u:
						customMappings_.AddEntriesFrom(input, _repeated_customMappings_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<DMXProfiles> _parser = new MessageParser<DMXProfiles>(() => new DMXProfiles());

	private UnknownFieldSet _unknownFields;

	public const int WorkspaceProfileFieldNumber = 1;

	private Types.DMXProfile workspaceProfile_;

	public const int LayerProfilesFieldNumber = 2;

	private static readonly FieldCodec<Types.DMXProfile> _repeated_layerProfiles_codec = FieldCodec.ForMessage(18u, Types.DMXProfile.Parser);

	private readonly RepeatedField<Types.DMXProfile> layerProfiles_ = new RepeatedField<Types.DMXProfile>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DMXProfiles> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => DmxProfilesReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DMXProfile WorkspaceProfile
	{
		get
		{
			return workspaceProfile_;
		}
		set
		{
			workspaceProfile_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.DMXProfile> LayerProfiles => layerProfiles_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DMXProfiles()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DMXProfiles(DMXProfiles other)
		: this()
	{
		workspaceProfile_ = ((other.workspaceProfile_ != null) ? other.workspaceProfile_.Clone() : null);
		layerProfiles_ = other.layerProfiles_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DMXProfiles Clone()
	{
		return new DMXProfiles(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DMXProfiles);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DMXProfiles other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(WorkspaceProfile, other.WorkspaceProfile))
		{
			return false;
		}
		if (!layerProfiles_.Equals(other.layerProfiles_))
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
		if (workspaceProfile_ != null)
		{
			num ^= WorkspaceProfile.GetHashCode();
		}
		num ^= layerProfiles_.GetHashCode();
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
		if (workspaceProfile_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(WorkspaceProfile);
		}
		layerProfiles_.WriteTo(output, _repeated_layerProfiles_codec);
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
		if (workspaceProfile_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(WorkspaceProfile);
		}
		num += layerProfiles_.CalculateSize(_repeated_layerProfiles_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(DMXProfiles other)
	{
		if (other == null)
		{
			return;
		}
		if (other.workspaceProfile_ != null)
		{
			if (workspaceProfile_ == null)
			{
				WorkspaceProfile = new Types.DMXProfile();
			}
			WorkspaceProfile.MergeFrom(other.WorkspaceProfile);
		}
		layerProfiles_.Add(other.layerProfiles_);
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
				if (workspaceProfile_ == null)
				{
					WorkspaceProfile = new Types.DMXProfile();
				}
				input.ReadMessage(WorkspaceProfile);
				break;
			case 18u:
				layerProfiles_.AddEntriesFrom(input, _repeated_layerProfiles_codec);
				break;
			}
		}
	}
}
