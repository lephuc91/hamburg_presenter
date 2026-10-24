using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPatternDefinition : IMessage<TestPatternDefinition>, IMessage, IEquatable<TestPatternDefinition>, IDeepCloneable<TestPatternDefinition>
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

			public const int AllowAlphaFieldNumber = 2;

			private bool allowAlpha_;

			public const int DefaultColorsFieldNumber = 3;

			private static readonly FieldCodec<Color> _repeated_defaultColors_codec = FieldCodec.ForMessage(26u, Color.Parser);

			private readonly RepeatedField<Color> defaultColors_ = new RepeatedField<Color>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ColorProperty> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[0];

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
			public bool AllowAlpha
			{
				get
				{
					return allowAlpha_;
				}
				set
				{
					allowAlpha_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Color> DefaultColors => defaultColors_;

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
				allowAlpha_ = other.allowAlpha_;
				defaultColors_ = other.defaultColors_.Clone();
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
				if (AllowAlpha != other.AllowAlpha)
				{
					return false;
				}
				if (!defaultColors_.Equals(other.defaultColors_))
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
				if (AllowAlpha)
				{
					num ^= AllowAlpha.GetHashCode();
				}
				num ^= defaultColors_.GetHashCode();
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
				if (AllowAlpha)
				{
					output.WriteRawTag(16);
					output.WriteBool(AllowAlpha);
				}
				defaultColors_.WriteTo(output, _repeated_defaultColors_codec);
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
				if (AllowAlpha)
				{
					num += 2;
				}
				num += defaultColors_.CalculateSize(_repeated_defaultColors_codec);
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
				if (other.AllowAlpha)
				{
					AllowAlpha = other.AllowAlpha;
				}
				defaultColors_.Add(other.defaultColors_);
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
						if (value_ == null)
						{
							Value = new Color();
						}
						input.ReadMessage(Value);
						break;
					case 16u:
						AllowAlpha = input.ReadBool();
						break;
					case 26u:
						defaultColors_.AddEntriesFrom(input, _repeated_defaultColors_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DoubleProperty : IMessage<DoubleProperty>, IMessage, IEquatable<DoubleProperty>, IDeepCloneable<DoubleProperty>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ViewType
				{
					[OriginalName("VIEW_TYPE_STEPPER")]
					Stepper,
					[OriginalName("VIEW_TYPE_SLIDER")]
					Slider,
					[OriginalName("VIEW_TYPE_SPEED_SLIDER")]
					SpeedSlider
				}
			}

			private static readonly MessageParser<DoubleProperty> _parser = new MessageParser<DoubleProperty>(() => new DoubleProperty());

			private UnknownFieldSet _unknownFields;

			public const int ValueFieldNumber = 1;

			private double value_;

			public const int MinFieldNumber = 2;

			private double min_;

			public const int MaxFieldNumber = 3;

			private double max_;

			public const int StepFieldNumber = 4;

			private double step_;

			public const int UnitsFieldNumber = 5;

			private string units_ = "";

			public const int ViewTypeFieldNumber = 6;

			private Types.ViewType viewType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DoubleProperty> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[1];

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
			public double Min
			{
				get
				{
					return min_;
				}
				set
				{
					min_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Max
			{
				get
				{
					return max_;
				}
				set
				{
					max_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Step
			{
				get
				{
					return step_;
				}
				set
				{
					step_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Units
			{
				get
				{
					return units_;
				}
				set
				{
					units_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ViewType ViewType
			{
				get
				{
					return viewType_;
				}
				set
				{
					viewType_ = value;
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
				min_ = other.min_;
				max_ = other.max_;
				step_ = other.step_;
				units_ = other.units_;
				viewType_ = other.viewType_;
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
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Min, other.Min))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Max, other.Max))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Step, other.Step))
				{
					return false;
				}
				if (Units != other.Units)
				{
					return false;
				}
				if (ViewType != other.ViewType)
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
				if (Min != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Min);
				}
				if (Max != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Max);
				}
				if (Step != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Step);
				}
				if (Units.Length != 0)
				{
					num ^= Units.GetHashCode();
				}
				if (ViewType != 0)
				{
					num ^= ViewType.GetHashCode();
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
				if (Min != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Min);
				}
				if (Max != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(Max);
				}
				if (Step != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(Step);
				}
				if (Units.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(Units);
				}
				if (ViewType != 0)
				{
					output.WriteRawTag(48);
					output.WriteEnum((int)ViewType);
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
				if (Min != 0.0)
				{
					num += 9;
				}
				if (Max != 0.0)
				{
					num += 9;
				}
				if (Step != 0.0)
				{
					num += 9;
				}
				if (Units.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Units);
				}
				if (ViewType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ViewType);
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
					if (other.Min != 0.0)
					{
						Min = other.Min;
					}
					if (other.Max != 0.0)
					{
						Max = other.Max;
					}
					if (other.Step != 0.0)
					{
						Step = other.Step;
					}
					if (other.Units.Length != 0)
					{
						Units = other.Units;
					}
					if (other.ViewType != 0)
					{
						ViewType = other.ViewType;
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
					case 9u:
						Value = input.ReadDouble();
						break;
					case 17u:
						Min = input.ReadDouble();
						break;
					case 25u:
						Max = input.ReadDouble();
						break;
					case 33u:
						Step = input.ReadDouble();
						break;
					case 42u:
						Units = input.ReadString();
						break;
					case 48u:
						ViewType = (Types.ViewType)input.ReadEnum();
						break;
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

			public const int MinFieldNumber = 2;

			private int min_;

			public const int MaxFieldNumber = 3;

			private int max_;

			public const int UnitsFieldNumber = 5;

			private string units_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IntProperty> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[2];

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
			public int Min
			{
				get
				{
					return min_;
				}
				set
				{
					min_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int Max
			{
				get
				{
					return max_;
				}
				set
				{
					max_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Units
			{
				get
				{
					return units_;
				}
				set
				{
					units_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				min_ = other.min_;
				max_ = other.max_;
				units_ = other.units_;
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
				if (Min != other.Min)
				{
					return false;
				}
				if (Max != other.Max)
				{
					return false;
				}
				if (Units != other.Units)
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
				if (Min != 0)
				{
					num ^= Min.GetHashCode();
				}
				if (Max != 0)
				{
					num ^= Max.GetHashCode();
				}
				if (Units.Length != 0)
				{
					num ^= Units.GetHashCode();
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
				if (Min != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Min);
				}
				if (Max != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Max);
				}
				if (Units.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(Units);
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
				if (Min != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Min);
				}
				if (Max != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Max);
				}
				if (Units.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Units);
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
					if (other.Min != 0)
					{
						Min = other.Min;
					}
					if (other.Max != 0)
					{
						Max = other.Max;
					}
					if (other.Units.Length != 0)
					{
						Units = other.Units;
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
						Value = input.ReadInt32();
						break;
					case 16u:
						Min = input.ReadInt32();
						break;
					case 24u:
						Max = input.ReadInt32();
						break;
					case 42u:
						Units = input.ReadString();
						break;
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
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[3];

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

			public const int MinCharsFieldNumber = 2;

			private int minChars_;

			public const int MaxCharsFieldNumber = 3;

			private int maxChars_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StringProperty> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[4];

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
			public int MinChars
			{
				get
				{
					return minChars_;
				}
				set
				{
					minChars_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int MaxChars
			{
				get
				{
					return maxChars_;
				}
				set
				{
					maxChars_ = value;
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
				minChars_ = other.minChars_;
				maxChars_ = other.maxChars_;
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
				if (MinChars != other.MinChars)
				{
					return false;
				}
				if (MaxChars != other.MaxChars)
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
				if (MinChars != 0)
				{
					num ^= MinChars.GetHashCode();
				}
				if (MaxChars != 0)
				{
					num ^= MaxChars.GetHashCode();
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
				if (MinChars != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(MinChars);
				}
				if (MaxChars != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(MaxChars);
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
				if (MinChars != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(MinChars);
				}
				if (MaxChars != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(MaxChars);
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
					if (other.MinChars != 0)
					{
						MinChars = other.MinChars;
					}
					if (other.MaxChars != 0)
					{
						MaxChars = other.MaxChars;
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
						Value = input.ReadString();
						break;
					case 16u:
						MinChars = input.ReadInt32();
						break;
					case 24u:
						MaxChars = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FontProperty : IMessage<FontProperty>, IMessage, IEquatable<FontProperty>, IDeepCloneable<FontProperty>
		{
			private static readonly MessageParser<FontProperty> _parser = new MessageParser<FontProperty>(() => new FontProperty());

			private UnknownFieldSet _unknownFields;

			public const int FontFieldNumber = 1;

			private Font font_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FontProperty> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Font Font
			{
				get
				{
					return font_;
				}
				set
				{
					font_ = value;
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
				font_ = ((other.font_ != null) ? other.font_.Clone() : null);
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
				if (!object.Equals(Font, other.Font))
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
				if (font_ != null)
				{
					num ^= Font.GetHashCode();
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
				if (font_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Font);
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
				if (font_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Font);
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
				if (other.font_ != null)
				{
					if (font_ == null)
					{
						Font = new Font();
					}
					Font.MergeFrom(other.Font);
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
					if (font_ == null)
					{
						Font = new Font();
					}
					input.ReadMessage(Font);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SelectorProperty : IMessage<SelectorProperty>, IMessage, IEquatable<SelectorProperty>, IDeepCloneable<SelectorProperty>
		{
			private static readonly MessageParser<SelectorProperty> _parser = new MessageParser<SelectorProperty>(() => new SelectorProperty());

			private UnknownFieldSet _unknownFields;

			public const int SelectedIndexFieldNumber = 1;

			private int selectedIndex_;

			public const int ValueLocalizationKeysFieldNumber = 2;

			private static readonly FieldCodec<string> _repeated_valueLocalizationKeys_codec = FieldCodec.ForString(18u);

			private readonly RepeatedField<string> valueLocalizationKeys_ = new RepeatedField<string>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SelectorProperty> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int SelectedIndex
			{
				get
				{
					return selectedIndex_;
				}
				set
				{
					selectedIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<string> ValueLocalizationKeys => valueLocalizationKeys_;

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
				selectedIndex_ = other.selectedIndex_;
				valueLocalizationKeys_ = other.valueLocalizationKeys_.Clone();
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
				if (SelectedIndex != other.SelectedIndex)
				{
					return false;
				}
				if (!valueLocalizationKeys_.Equals(other.valueLocalizationKeys_))
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
				if (SelectedIndex != 0)
				{
					num ^= SelectedIndex.GetHashCode();
				}
				num ^= valueLocalizationKeys_.GetHashCode();
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
				if (SelectedIndex != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(SelectedIndex);
				}
				valueLocalizationKeys_.WriteTo(output, _repeated_valueLocalizationKeys_codec);
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
				if (SelectedIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(SelectedIndex);
				}
				num += valueLocalizationKeys_.CalculateSize(_repeated_valueLocalizationKeys_codec);
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
					if (other.SelectedIndex != 0)
					{
						SelectedIndex = other.SelectedIndex;
					}
					valueLocalizationKeys_.Add(other.valueLocalizationKeys_);
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
						SelectedIndex = input.ReadInt32();
						break;
					case 18u:
						valueLocalizationKeys_.AddEntriesFrom(input, _repeated_valueLocalizationKeys_codec);
						break;
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
				ColorProperty = 3,
				DoubleProperty = 4,
				IntProperty = 5,
				BoolProperty = 6,
				StringProperty = 7,
				FontProperty = 8,
				SelectorProperty = 9
			}

			private static readonly MessageParser<Property> _parser = new MessageParser<Property>(() => new Property());

			private UnknownFieldSet _unknownFields;

			public const int NameLocalizationKeyFieldNumber = 1;

			private string nameLocalizationKey_ = "";

			public const int ColorPropertyFieldNumber = 3;

			public const int DoublePropertyFieldNumber = 4;

			public const int IntPropertyFieldNumber = 5;

			public const int BoolPropertyFieldNumber = 6;

			public const int StringPropertyFieldNumber = 7;

			public const int FontPropertyFieldNumber = 8;

			public const int SelectorPropertyFieldNumber = 9;

			private object propertyType_;

			private PropertyTypeOneofCase propertyTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Property> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternDefinition.Descriptor.NestedTypes[7];

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
					output.WriteRawTag(26);
					output.WriteMessage(ColorProperty);
				}
				if (propertyTypeCase_ == PropertyTypeOneofCase.DoubleProperty)
				{
					output.WriteRawTag(34);
					output.WriteMessage(DoubleProperty);
				}
				if (propertyTypeCase_ == PropertyTypeOneofCase.IntProperty)
				{
					output.WriteRawTag(42);
					output.WriteMessage(IntProperty);
				}
				if (propertyTypeCase_ == PropertyTypeOneofCase.BoolProperty)
				{
					output.WriteRawTag(50);
					output.WriteMessage(BoolProperty);
				}
				if (propertyTypeCase_ == PropertyTypeOneofCase.StringProperty)
				{
					output.WriteRawTag(58);
					output.WriteMessage(StringProperty);
				}
				if (propertyTypeCase_ == PropertyTypeOneofCase.FontProperty)
				{
					output.WriteRawTag(66);
					output.WriteMessage(FontProperty);
				}
				if (propertyTypeCase_ == PropertyTypeOneofCase.SelectorProperty)
				{
					output.WriteRawTag(74);
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
					case 26u:
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
					case 34u:
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
					case 42u:
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
					case 50u:
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
					case 58u:
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
					case 66u:
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
					case 74u:
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

	private static readonly MessageParser<TestPatternDefinition> _parser = new MessageParser<TestPatternDefinition>(() => new TestPatternDefinition());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameLocalizationKeyFieldNumber = 2;

	private string nameLocalizationKey_ = "";

	public const int PropertiesFieldNumber = 3;

	private static readonly FieldCodec<Types.Property> _repeated_properties_codec = FieldCodec.ForMessage(26u, Types.Property.Parser);

	private readonly RepeatedField<Types.Property> properties_ = new RepeatedField<Types.Property>();

	public const int ShowDelaySettingsFieldNumber = 4;

	private bool showDelaySettings_;

	public const int IsDefaultFieldNumber = 5;

	private bool isDefault_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPatternDefinition> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TestPatternReflection.Descriptor.MessageTypes[1];

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
	public bool ShowDelaySettings
	{
		get
		{
			return showDelaySettings_;
		}
		set
		{
			showDelaySettings_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsDefault
	{
		get
		{
			return isDefault_;
		}
		set
		{
			isDefault_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDefinition()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDefinition(TestPatternDefinition other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		nameLocalizationKey_ = other.nameLocalizationKey_;
		properties_ = other.properties_.Clone();
		showDelaySettings_ = other.showDelaySettings_;
		isDefault_ = other.isDefault_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDefinition Clone()
	{
		return new TestPatternDefinition(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TestPatternDefinition);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPatternDefinition other)
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
		if (ShowDelaySettings != other.ShowDelaySettings)
		{
			return false;
		}
		if (IsDefault != other.IsDefault)
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
		if (ShowDelaySettings)
		{
			num ^= ShowDelaySettings.GetHashCode();
		}
		if (IsDefault)
		{
			num ^= IsDefault.GetHashCode();
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
		if (ShowDelaySettings)
		{
			output.WriteRawTag(32);
			output.WriteBool(ShowDelaySettings);
		}
		if (IsDefault)
		{
			output.WriteRawTag(40);
			output.WriteBool(IsDefault);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (NameLocalizationKey.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(NameLocalizationKey);
		}
		num += properties_.CalculateSize(_repeated_properties_codec);
		if (ShowDelaySettings)
		{
			num += 2;
		}
		if (IsDefault)
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
	public void MergeFrom(TestPatternDefinition other)
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
		if (other.ShowDelaySettings)
		{
			ShowDelaySettings = other.ShowDelaySettings;
		}
		if (other.IsDefault)
		{
			IsDefault = other.IsDefault;
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
			case 32u:
				ShowDelaySettings = input.ReadBool();
				break;
			case 40u:
				IsDefault = input.ReadBool();
				break;
			}
		}
	}
}
