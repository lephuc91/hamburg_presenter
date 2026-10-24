using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPatternDocument : IMessage<TestPatternDocument>, IMessage, IEquatable<TestPatternDocument>, IDeepCloneable<TestPatternDocument>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TestPatternStateData : IMessage<TestPatternStateData>, IMessage, IEquatable<TestPatternStateData>, IDeepCloneable<TestPatternStateData>
		{
			private static readonly MessageParser<TestPatternStateData> _parser = new MessageParser<TestPatternStateData>(() => new TestPatternStateData());

			private UnknownFieldSet _unknownFields;

			public const int TestPatternIdFieldNumber = 1;

			private UUID testPatternId_;

			public const int TestPatternNameLocalizationKeyFieldNumber = 2;

			private string testPatternNameLocalizationKey_ = "";

			public const int DisplayLocationFieldNumber = 3;

			private TestPatternState.Types.DisplayLocation displayLocation_;

			public const int SpecificScreenFieldNumber = 4;

			private UUID specificScreen_;

			public const int IdentifyScreensFieldNumber = 5;

			private bool identifyScreens_;

			public const int LogoTypeFieldNumber = 6;

			private LogoType logoType_;

			public const int UserLogoLocationFieldNumber = 7;

			private URL userLogoLocation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TestPatternStateData> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDocument.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID TestPatternId
			{
				get
				{
					return testPatternId_;
				}
				set
				{
					testPatternId_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string TestPatternNameLocalizationKey
			{
				get
				{
					return testPatternNameLocalizationKey_;
				}
				set
				{
					testPatternNameLocalizationKey_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternState.Types.DisplayLocation DisplayLocation
			{
				get
				{
					return displayLocation_;
				}
				set
				{
					displayLocation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID SpecificScreen
			{
				get
				{
					return specificScreen_;
				}
				set
				{
					specificScreen_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IdentifyScreens
			{
				get
				{
					return identifyScreens_;
				}
				set
				{
					identifyScreens_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LogoType LogoType
			{
				get
				{
					return logoType_;
				}
				set
				{
					logoType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public URL UserLogoLocation
			{
				get
				{
					return userLogoLocation_;
				}
				set
				{
					userLogoLocation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternStateData()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternStateData(TestPatternStateData other)
				: this()
			{
				testPatternId_ = ((other.testPatternId_ != null) ? other.testPatternId_.Clone() : null);
				testPatternNameLocalizationKey_ = other.testPatternNameLocalizationKey_;
				displayLocation_ = other.displayLocation_;
				specificScreen_ = ((other.specificScreen_ != null) ? other.specificScreen_.Clone() : null);
				identifyScreens_ = other.identifyScreens_;
				logoType_ = other.logoType_;
				userLogoLocation_ = ((other.userLogoLocation_ != null) ? other.userLogoLocation_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternStateData Clone()
			{
				return new TestPatternStateData(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TestPatternStateData);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TestPatternStateData other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(TestPatternId, other.TestPatternId))
				{
					return false;
				}
				if (TestPatternNameLocalizationKey != other.TestPatternNameLocalizationKey)
				{
					return false;
				}
				if (DisplayLocation != other.DisplayLocation)
				{
					return false;
				}
				if (!object.Equals(SpecificScreen, other.SpecificScreen))
				{
					return false;
				}
				if (IdentifyScreens != other.IdentifyScreens)
				{
					return false;
				}
				if (LogoType != other.LogoType)
				{
					return false;
				}
				if (!object.Equals(UserLogoLocation, other.UserLogoLocation))
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
				if (testPatternId_ != null)
				{
					num ^= TestPatternId.GetHashCode();
				}
				if (TestPatternNameLocalizationKey.Length != 0)
				{
					num ^= TestPatternNameLocalizationKey.GetHashCode();
				}
				if (DisplayLocation != 0)
				{
					num ^= DisplayLocation.GetHashCode();
				}
				if (specificScreen_ != null)
				{
					num ^= SpecificScreen.GetHashCode();
				}
				if (IdentifyScreens)
				{
					num ^= IdentifyScreens.GetHashCode();
				}
				if (LogoType != 0)
				{
					num ^= LogoType.GetHashCode();
				}
				if (userLogoLocation_ != null)
				{
					num ^= UserLogoLocation.GetHashCode();
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
				if (testPatternId_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(TestPatternId);
				}
				if (TestPatternNameLocalizationKey.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(TestPatternNameLocalizationKey);
				}
				if (DisplayLocation != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)DisplayLocation);
				}
				if (specificScreen_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(SpecificScreen);
				}
				if (IdentifyScreens)
				{
					output.WriteRawTag(40);
					output.WriteBool(IdentifyScreens);
				}
				if (LogoType != 0)
				{
					output.WriteRawTag(48);
					output.WriteEnum((int)LogoType);
				}
				if (userLogoLocation_ != null)
				{
					output.WriteRawTag(58);
					output.WriteMessage(UserLogoLocation);
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
				if (testPatternId_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TestPatternId);
				}
				if (TestPatternNameLocalizationKey.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(TestPatternNameLocalizationKey);
				}
				if (DisplayLocation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)DisplayLocation);
				}
				if (specificScreen_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SpecificScreen);
				}
				if (IdentifyScreens)
				{
					num += 2;
				}
				if (LogoType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)LogoType);
				}
				if (userLogoLocation_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UserLogoLocation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TestPatternStateData other)
			{
				if (other == null)
				{
					return;
				}
				if (other.testPatternId_ != null)
				{
					if (testPatternId_ == null)
					{
						TestPatternId = new UUID();
					}
					TestPatternId.MergeFrom(other.TestPatternId);
				}
				if (other.TestPatternNameLocalizationKey.Length != 0)
				{
					TestPatternNameLocalizationKey = other.TestPatternNameLocalizationKey;
				}
				if (other.DisplayLocation != 0)
				{
					DisplayLocation = other.DisplayLocation;
				}
				if (other.specificScreen_ != null)
				{
					if (specificScreen_ == null)
					{
						SpecificScreen = new UUID();
					}
					SpecificScreen.MergeFrom(other.SpecificScreen);
				}
				if (other.IdentifyScreens)
				{
					IdentifyScreens = other.IdentifyScreens;
				}
				if (other.LogoType != 0)
				{
					LogoType = other.LogoType;
				}
				if (other.userLogoLocation_ != null)
				{
					if (userLogoLocation_ == null)
					{
						UserLogoLocation = new URL();
					}
					UserLogoLocation.MergeFrom(other.UserLogoLocation);
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
						if (testPatternId_ == null)
						{
							TestPatternId = new UUID();
						}
						input.ReadMessage(TestPatternId);
						break;
					case 18u:
						TestPatternNameLocalizationKey = input.ReadString();
						break;
					case 24u:
						DisplayLocation = (TestPatternState.Types.DisplayLocation)input.ReadEnum();
						break;
					case 34u:
						if (specificScreen_ == null)
						{
							SpecificScreen = new UUID();
						}
						input.ReadMessage(SpecificScreen);
						break;
					case 40u:
						IdentifyScreens = input.ReadBool();
						break;
					case 48u:
						LogoType = (LogoType)input.ReadEnum();
						break;
					case 58u:
						if (userLogoLocation_ == null)
						{
							UserLogoLocation = new URL();
						}
						input.ReadMessage(UserLogoLocation);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TestPatternData : IMessage<TestPatternData>, IMessage, IEquatable<TestPatternData>, IDeepCloneable<TestPatternData>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ColorProperty : IMessage<ColorProperty>, IMessage, IEquatable<ColorProperty>, IDeepCloneable<ColorProperty>
				{
					private static readonly MessageParser<ColorProperty> _parser = new MessageParser<ColorProperty>(() => new ColorProperty());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private Color value_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ColorProperty> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Color Value
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
					public ColorProperty()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ColorProperty(ColorProperty other)
						: this()
					{
						value_ = ((other.value_ != null) ? other.value_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ColorProperty Clone()
					{
						return new ColorProperty(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ColorProperty);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ColorProperty other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
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
						if (value_ != null)
						{
							output.WriteRawTag(10);
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
					public void MergeFrom(ColorProperty other)
					{
						if (other == null)
						{
							return;
						}
						if (other.value_ != null)
						{
							if (value_ == null)
							{
								Value = new Color();
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								continue;
							}
							if (value_ == null)
							{
								Value = new Color();
							}
							input.ReadMessage(Value);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class DoubleProperty : IMessage<DoubleProperty>, IMessage, IEquatable<DoubleProperty>, IDeepCloneable<DoubleProperty>
				{
					private static readonly MessageParser<DoubleProperty> _parser = new MessageParser<DoubleProperty>(() => new DoubleProperty());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private double value_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<DoubleProperty> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Value
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
					public DoubleProperty()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DoubleProperty(DoubleProperty other)
						: this()
					{
						value_ = other.value_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DoubleProperty Clone()
					{
						return new DoubleProperty(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as DoubleProperty);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(DoubleProperty other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Value, other.Value))
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
						if (Value != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Value);
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
						if (Value != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Value);
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
						if (Value != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(DoubleProperty other)
					{
						if (other != null)
						{
							if (other.Value != 0.0)
							{
								Value = other.Value;
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
							if (num != 9)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Value = input.ReadDouble();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class IntProperty : IMessage<IntProperty>, IMessage, IEquatable<IntProperty>, IDeepCloneable<IntProperty>
				{
					private static readonly MessageParser<IntProperty> _parser = new MessageParser<IntProperty>(() => new IntProperty());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private int value_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<IntProperty> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public int Value
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
					public IntProperty()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public IntProperty(IntProperty other)
						: this()
					{
						value_ = other.value_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public IntProperty Clone()
					{
						return new IntProperty(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as IntProperty);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(IntProperty other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Value != other.Value)
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
						if (Value != 0)
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
						if (Value != 0)
						{
							output.WriteRawTag(8);
							output.WriteInt32(Value);
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
						if (Value != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(Value);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(IntProperty other)
					{
						if (other != null)
						{
							if (other.Value != 0)
							{
								Value = other.Value;
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
								Value = input.ReadInt32();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class BoolProperty : IMessage<BoolProperty>, IMessage, IEquatable<BoolProperty>, IDeepCloneable<BoolProperty>
				{
					private static readonly MessageParser<BoolProperty> _parser = new MessageParser<BoolProperty>(() => new BoolProperty());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private bool value_;

					public const int DependentPropertiesFieldNumber = 2;

					private static readonly FieldCodec<Property> _repeated_dependentProperties_codec = FieldCodec.ForMessage(18u, Property.Parser);

					private readonly RepeatedField<Property> dependentProperties_ = new RepeatedField<Property>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<BoolProperty> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Value
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
					public RepeatedField<Property> DependentProperties => dependentProperties_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BoolProperty()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BoolProperty(BoolProperty other)
						: this()
					{
						value_ = other.value_;
						dependentProperties_ = other.dependentProperties_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BoolProperty Clone()
					{
						return new BoolProperty(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as BoolProperty);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(BoolProperty other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Value != other.Value)
						{
							return false;
						}
						if (!dependentProperties_.Equals(other.dependentProperties_))
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
						if (Value)
						{
							num ^= Value.GetHashCode();
						}
						num ^= dependentProperties_.GetHashCode();
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
						if (Value)
						{
							output.WriteRawTag(8);
							output.WriteBool(Value);
						}
						dependentProperties_.WriteTo(output, _repeated_dependentProperties_codec);
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
						if (Value)
						{
							num += 2;
						}
						num += dependentProperties_.CalculateSize(_repeated_dependentProperties_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(BoolProperty other)
					{
						if (other != null)
						{
							if (other.Value)
							{
								Value = other.Value;
							}
							dependentProperties_.Add(other.dependentProperties_);
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
								Value = input.ReadBool();
								break;
							case 18u:
								dependentProperties_.AddEntriesFrom(input, _repeated_dependentProperties_codec);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class StringProperty : IMessage<StringProperty>, IMessage, IEquatable<StringProperty>, IDeepCloneable<StringProperty>
				{
					private static readonly MessageParser<StringProperty> _parser = new MessageParser<StringProperty>(() => new StringProperty());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private string value_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<StringProperty> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Value
					{
						get
						{
							return value_;
						}
						set
						{
							value_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StringProperty()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StringProperty(StringProperty other)
						: this()
					{
						value_ = other.value_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StringProperty Clone()
					{
						return new StringProperty(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as StringProperty);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(StringProperty other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Value != other.Value)
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
						if (Value.Length != 0)
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
						if (Value.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Value);
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
						if (Value.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Value);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(StringProperty other)
					{
						if (other != null)
						{
							if (other.Value.Length != 0)
							{
								Value = other.Value;
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
								Value = input.ReadString();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class FontProperty : IMessage<FontProperty>, IMessage, IEquatable<FontProperty>, IDeepCloneable<FontProperty>
				{
					private static readonly MessageParser<FontProperty> _parser = new MessageParser<FontProperty>(() => new FontProperty());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private Font value_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<FontProperty> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[5];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Font Value
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
					public FontProperty()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public FontProperty(FontProperty other)
						: this()
					{
						value_ = ((other.value_ != null) ? other.value_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public FontProperty Clone()
					{
						return new FontProperty(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as FontProperty);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(FontProperty other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
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
						if (value_ != null)
						{
							output.WriteRawTag(10);
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
					public void MergeFrom(FontProperty other)
					{
						if (other == null)
						{
							return;
						}
						if (other.value_ != null)
						{
							if (value_ == null)
							{
								Value = new Font();
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								continue;
							}
							if (value_ == null)
							{
								Value = new Font();
							}
							input.ReadMessage(Value);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class SelectorProperty : IMessage<SelectorProperty>, IMessage, IEquatable<SelectorProperty>, IDeepCloneable<SelectorProperty>
				{
					private static readonly MessageParser<SelectorProperty> _parser = new MessageParser<SelectorProperty>(() => new SelectorProperty());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private int value_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<SelectorProperty> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[6];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public int Value
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
					public SelectorProperty()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SelectorProperty(SelectorProperty other)
						: this()
					{
						value_ = other.value_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SelectorProperty Clone()
					{
						return new SelectorProperty(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as SelectorProperty);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(SelectorProperty other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Value != other.Value)
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
						if (Value != 0)
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
						if (Value != 0)
						{
							output.WriteRawTag(8);
							output.WriteInt32(Value);
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
						if (Value != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(Value);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(SelectorProperty other)
					{
						if (other != null)
						{
							if (other.Value != 0)
							{
								Value = other.Value;
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
								Value = input.ReadInt32();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Property : IMessage<Property>, IMessage, IEquatable<Property>, IDeepCloneable<Property>
				{
					public enum PropertyTypeOneofCase
					{
						None = 0,
						ColorProperty = 2,
						DoubleProperty = 3,
						IntProperty = 4,
						BoolProperty = 5,
						StringProperty = 6,
						FontProperty = 7,
						SelectorProperty = 8
					}

					private static readonly MessageParser<Property> _parser = new MessageParser<Property>(() => new Property());

					private UnknownFieldSet _unknownFields;

					public const int NameLocalizationKeyFieldNumber = 1;

					private string nameLocalizationKey_ = "";

					public const int ColorPropertyFieldNumber = 2;

					public const int DoublePropertyFieldNumber = 3;

					public const int IntPropertyFieldNumber = 4;

					public const int BoolPropertyFieldNumber = 5;

					public const int StringPropertyFieldNumber = 6;

					public const int FontPropertyFieldNumber = 7;

					public const int SelectorPropertyFieldNumber = 8;

					private object propertyType_;

					private PropertyTypeOneofCase propertyTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Property> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => TestPatternData.Descriptor.NestedTypes[7];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string NameLocalizationKey
					{
						get
						{
							return nameLocalizationKey_;
						}
						set
						{
							nameLocalizationKey_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ColorProperty ColorProperty
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.ColorProperty)
							{
								return null;
							}
							return (ColorProperty)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.ColorProperty : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public DoubleProperty DoubleProperty
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.DoubleProperty)
							{
								return null;
							}
							return (DoubleProperty)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.DoubleProperty : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public IntProperty IntProperty
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.IntProperty)
							{
								return null;
							}
							return (IntProperty)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.IntProperty : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BoolProperty BoolProperty
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.BoolProperty)
							{
								return null;
							}
							return (BoolProperty)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.BoolProperty : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StringProperty StringProperty
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.StringProperty)
							{
								return null;
							}
							return (StringProperty)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.StringProperty : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public FontProperty FontProperty
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.FontProperty)
							{
								return null;
							}
							return (FontProperty)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.FontProperty : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SelectorProperty SelectorProperty
					{
						get
						{
							if (propertyTypeCase_ != PropertyTypeOneofCase.SelectorProperty)
							{
								return null;
							}
							return (SelectorProperty)propertyType_;
						}
						set
						{
							propertyType_ = value;
							propertyTypeCase_ = ((value != null) ? PropertyTypeOneofCase.SelectorProperty : PropertyTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public PropertyTypeOneofCase PropertyTypeCase => propertyTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Property()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Property(Property other)
						: this()
					{
						nameLocalizationKey_ = other.nameLocalizationKey_;
						switch (other.PropertyTypeCase)
						{
						case PropertyTypeOneofCase.ColorProperty:
							ColorProperty = other.ColorProperty.Clone();
							break;
						case PropertyTypeOneofCase.DoubleProperty:
							DoubleProperty = other.DoubleProperty.Clone();
							break;
						case PropertyTypeOneofCase.IntProperty:
							IntProperty = other.IntProperty.Clone();
							break;
						case PropertyTypeOneofCase.BoolProperty:
							BoolProperty = other.BoolProperty.Clone();
							break;
						case PropertyTypeOneofCase.StringProperty:
							StringProperty = other.StringProperty.Clone();
							break;
						case PropertyTypeOneofCase.FontProperty:
							FontProperty = other.FontProperty.Clone();
							break;
						case PropertyTypeOneofCase.SelectorProperty:
							SelectorProperty = other.SelectorProperty.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Property Clone()
					{
						return new Property(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearPropertyType()
					{
						propertyTypeCase_ = PropertyTypeOneofCase.None;
						propertyType_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Property);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Property other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (NameLocalizationKey != other.NameLocalizationKey)
						{
							return false;
						}
						if (!object.Equals(ColorProperty, other.ColorProperty))
						{
							return false;
						}
						if (!object.Equals(DoubleProperty, other.DoubleProperty))
						{
							return false;
						}
						if (!object.Equals(IntProperty, other.IntProperty))
						{
							return false;
						}
						if (!object.Equals(BoolProperty, other.BoolProperty))
						{
							return false;
						}
						if (!object.Equals(StringProperty, other.StringProperty))
						{
							return false;
						}
						if (!object.Equals(FontProperty, other.FontProperty))
						{
							return false;
						}
						if (!object.Equals(SelectorProperty, other.SelectorProperty))
						{
							return false;
						}
						if (PropertyTypeCase != other.PropertyTypeCase)
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
						if (NameLocalizationKey.Length != 0)
						{
							num ^= NameLocalizationKey.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ColorProperty)
						{
							num ^= ColorProperty.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.DoubleProperty)
						{
							num ^= DoubleProperty.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.IntProperty)
						{
							num ^= IntProperty.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.BoolProperty)
						{
							num ^= BoolProperty.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.StringProperty)
						{
							num ^= StringProperty.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.FontProperty)
						{
							num ^= FontProperty.GetHashCode();
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SelectorProperty)
						{
							num ^= SelectorProperty.GetHashCode();
						}
						num ^= (int)propertyTypeCase_;
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
						if (NameLocalizationKey.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(NameLocalizationKey);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ColorProperty)
						{
							output.WriteRawTag(18);
							output.WriteMessage(ColorProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.DoubleProperty)
						{
							output.WriteRawTag(26);
							output.WriteMessage(DoubleProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.IntProperty)
						{
							output.WriteRawTag(34);
							output.WriteMessage(IntProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.BoolProperty)
						{
							output.WriteRawTag(42);
							output.WriteMessage(BoolProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.StringProperty)
						{
							output.WriteRawTag(50);
							output.WriteMessage(StringProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.FontProperty)
						{
							output.WriteRawTag(58);
							output.WriteMessage(FontProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SelectorProperty)
						{
							output.WriteRawTag(66);
							output.WriteMessage(SelectorProperty);
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
						if (NameLocalizationKey.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(NameLocalizationKey);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.ColorProperty)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ColorProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.DoubleProperty)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(DoubleProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.IntProperty)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(IntProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.BoolProperty)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(BoolProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.StringProperty)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(StringProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.FontProperty)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(FontProperty);
						}
						if (propertyTypeCase_ == PropertyTypeOneofCase.SelectorProperty)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(SelectorProperty);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Property other)
					{
						if (other == null)
						{
							return;
						}
						if (other.NameLocalizationKey.Length != 0)
						{
							NameLocalizationKey = other.NameLocalizationKey;
						}
						switch (other.PropertyTypeCase)
						{
						case PropertyTypeOneofCase.ColorProperty:
							if (ColorProperty == null)
							{
								ColorProperty = new ColorProperty();
							}
							ColorProperty.MergeFrom(other.ColorProperty);
							break;
						case PropertyTypeOneofCase.DoubleProperty:
							if (DoubleProperty == null)
							{
								DoubleProperty = new DoubleProperty();
							}
							DoubleProperty.MergeFrom(other.DoubleProperty);
							break;
						case PropertyTypeOneofCase.IntProperty:
							if (IntProperty == null)
							{
								IntProperty = new IntProperty();
							}
							IntProperty.MergeFrom(other.IntProperty);
							break;
						case PropertyTypeOneofCase.BoolProperty:
							if (BoolProperty == null)
							{
								BoolProperty = new BoolProperty();
							}
							BoolProperty.MergeFrom(other.BoolProperty);
							break;
						case PropertyTypeOneofCase.StringProperty:
							if (StringProperty == null)
							{
								StringProperty = new StringProperty();
							}
							StringProperty.MergeFrom(other.StringProperty);
							break;
						case PropertyTypeOneofCase.FontProperty:
							if (FontProperty == null)
							{
								FontProperty = new FontProperty();
							}
							FontProperty.MergeFrom(other.FontProperty);
							break;
						case PropertyTypeOneofCase.SelectorProperty:
							if (SelectorProperty == null)
							{
								SelectorProperty = new SelectorProperty();
							}
							SelectorProperty.MergeFrom(other.SelectorProperty);
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
								NameLocalizationKey = input.ReadString();
								break;
							case 18u:
							{
								ColorProperty colorProperty = new ColorProperty();
								if (propertyTypeCase_ == PropertyTypeOneofCase.ColorProperty)
								{
									colorProperty.MergeFrom(ColorProperty);
								}
								input.ReadMessage(colorProperty);
								ColorProperty = colorProperty;
								break;
							}
							case 26u:
							{
								DoubleProperty doubleProperty = new DoubleProperty();
								if (propertyTypeCase_ == PropertyTypeOneofCase.DoubleProperty)
								{
									doubleProperty.MergeFrom(DoubleProperty);
								}
								input.ReadMessage(doubleProperty);
								DoubleProperty = doubleProperty;
								break;
							}
							case 34u:
							{
								IntProperty intProperty = new IntProperty();
								if (propertyTypeCase_ == PropertyTypeOneofCase.IntProperty)
								{
									intProperty.MergeFrom(IntProperty);
								}
								input.ReadMessage(intProperty);
								IntProperty = intProperty;
								break;
							}
							case 42u:
							{
								BoolProperty boolProperty = new BoolProperty();
								if (propertyTypeCase_ == PropertyTypeOneofCase.BoolProperty)
								{
									boolProperty.MergeFrom(BoolProperty);
								}
								input.ReadMessage(boolProperty);
								BoolProperty = boolProperty;
								break;
							}
							case 50u:
							{
								StringProperty stringProperty = new StringProperty();
								if (propertyTypeCase_ == PropertyTypeOneofCase.StringProperty)
								{
									stringProperty.MergeFrom(StringProperty);
								}
								input.ReadMessage(stringProperty);
								StringProperty = stringProperty;
								break;
							}
							case 58u:
							{
								FontProperty fontProperty = new FontProperty();
								if (propertyTypeCase_ == PropertyTypeOneofCase.FontProperty)
								{
									fontProperty.MergeFrom(FontProperty);
								}
								input.ReadMessage(fontProperty);
								FontProperty = fontProperty;
								break;
							}
							case 66u:
							{
								SelectorProperty selectorProperty = new SelectorProperty();
								if (propertyTypeCase_ == PropertyTypeOneofCase.SelectorProperty)
								{
									selectorProperty.MergeFrom(SelectorProperty);
								}
								input.ReadMessage(selectorProperty);
								SelectorProperty = selectorProperty;
								break;
							}
							}
						}
					}
				}
			}

			private static readonly MessageParser<TestPatternData> _parser = new MessageParser<TestPatternData>(() => new TestPatternData());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameLocalizationKeyFieldNumber = 2;

			private string nameLocalizationKey_ = "";

			public const int PropertiesFieldNumber = 3;

			private static readonly FieldCodec<Types.Property> _repeated_properties_codec = FieldCodec.ForMessage(26u, Types.Property.Parser);

			private readonly RepeatedField<Types.Property> properties_ = new RepeatedField<Types.Property>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TestPatternData> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDocument.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string NameLocalizationKey
			{
				get
				{
					return nameLocalizationKey_;
				}
				set
				{
					nameLocalizationKey_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Property> Properties => properties_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternData()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternData(TestPatternData other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				nameLocalizationKey_ = other.nameLocalizationKey_;
				properties_ = other.properties_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TestPatternData Clone()
			{
				return new TestPatternData(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TestPatternData);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TestPatternData other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (NameLocalizationKey != other.NameLocalizationKey)
				{
					return false;
				}
				if (!properties_.Equals(other.properties_))
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (NameLocalizationKey.Length != 0)
				{
					num ^= NameLocalizationKey.GetHashCode();
				}
				num ^= properties_.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (NameLocalizationKey.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(NameLocalizationKey);
				}
				properties_.WriteTo(output, _repeated_properties_codec);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (NameLocalizationKey.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(NameLocalizationKey);
				}
				num += properties_.CalculateSize(_repeated_properties_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TestPatternData other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				if (other.NameLocalizationKey.Length != 0)
				{
					NameLocalizationKey = other.NameLocalizationKey;
				}
				properties_.Add(other.properties_);
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 18u:
						NameLocalizationKey = input.ReadString();
						break;
					case 26u:
						properties_.AddEntriesFrom(input, _repeated_properties_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TestPatternDocument> _parser = new MessageParser<TestPatternDocument>(() => new TestPatternDocument());

	private UnknownFieldSet _unknownFields;

	public const int StateFieldNumber = 1;

	private Types.TestPatternStateData state_;

	public const int PatternsFieldNumber = 2;

	private static readonly FieldCodec<Types.TestPatternData> _repeated_patterns_codec = FieldCodec.ForMessage(18u, Types.TestPatternData.Parser);

	private readonly RepeatedField<Types.TestPatternData> patterns_ = new RepeatedField<Types.TestPatternData>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPatternDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TestPatternReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TestPatternStateData State
	{
		get
		{
			return state_;
		}
		set
		{
			state_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.TestPatternData> Patterns => patterns_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDocument(TestPatternDocument other)
		: this()
	{
		state_ = ((other.state_ != null) ? other.state_.Clone() : null);
		patterns_ = other.patterns_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDocument Clone()
	{
		return new TestPatternDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TestPatternDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPatternDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(State, other.State))
		{
			return false;
		}
		if (!patterns_.Equals(other.patterns_))
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
		if (state_ != null)
		{
			num ^= State.GetHashCode();
		}
		num ^= patterns_.GetHashCode();
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
		if (state_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(State);
		}
		patterns_.WriteTo(output, _repeated_patterns_codec);
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
		if (state_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(State);
		}
		num += patterns_.CalculateSize(_repeated_patterns_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TestPatternDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.state_ != null)
		{
			if (state_ == null)
			{
				State = new Types.TestPatternStateData();
			}
			State.MergeFrom(other.State);
		}
		patterns_.Add(other.patterns_);
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
				if (state_ == null)
				{
					State = new Types.TestPatternStateData();
				}
				input.ReadMessage(State);
				break;
			case 18u:
				patterns_.AddEntriesFrom(input, _repeated_patterns_codec);
				break;
			}
		}
	}
}
