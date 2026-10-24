using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Effect : IMessage<Effect>, IMessage, IEquatable<Effect>, IDeepCloneable<Effect>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EffectVariable : IMessage<EffectVariable>, IMessage, IEquatable<EffectVariable>, IDeepCloneable<EffectVariable>
		{
			public enum TypeOneofCase
			{
				None = 0,
				Int = 3,
				Float = 4,
				Color = 5,
				Direction = 6,
				Double = 7
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class EffectInt : IMessage<EffectInt>, IMessage, IEquatable<EffectInt>, IDeepCloneable<EffectInt>
				{
					private static readonly MessageParser<EffectInt> _parser = new MessageParser<EffectInt>(() => new EffectInt());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private int value_;

					public const int DefaultValueFieldNumber = 2;

					private int defaultValue_;

					public const int MinFieldNumber = 3;

					private int min_;

					public const int MaxFieldNumber = 4;

					private int max_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<EffectInt> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => EffectVariable.Descriptor.NestedTypes[0];

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
					public int DefaultValue
					{
						get
						{
							return defaultValue_;
						}
						set
						{
							defaultValue_ = value;
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
					public EffectInt()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectInt(EffectInt other)
						: this()
					{
						value_ = other.value_;
						defaultValue_ = other.defaultValue_;
						min_ = other.min_;
						max_ = other.max_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectInt Clone()
					{
						return new EffectInt(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as EffectInt);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(EffectInt other)
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
						if (DefaultValue != other.DefaultValue)
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
						if (DefaultValue != 0)
						{
							num ^= DefaultValue.GetHashCode();
						}
						if (Min != 0)
						{
							num ^= Min.GetHashCode();
						}
						if (Max != 0)
						{
							num ^= Max.GetHashCode();
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
						if (DefaultValue != 0)
						{
							output.WriteRawTag(16);
							output.WriteInt32(DefaultValue);
						}
						if (Min != 0)
						{
							output.WriteRawTag(24);
							output.WriteInt32(Min);
						}
						if (Max != 0)
						{
							output.WriteRawTag(32);
							output.WriteInt32(Max);
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
						if (DefaultValue != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(DefaultValue);
						}
						if (Min != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(Min);
						}
						if (Max != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(Max);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(EffectInt other)
					{
						if (other != null)
						{
							if (other.Value != 0)
							{
								Value = other.Value;
							}
							if (other.DefaultValue != 0)
							{
								DefaultValue = other.DefaultValue;
							}
							if (other.Min != 0)
							{
								Min = other.Min;
							}
							if (other.Max != 0)
							{
								Max = other.Max;
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
								DefaultValue = input.ReadInt32();
								break;
							case 24u:
								Min = input.ReadInt32();
								break;
							case 32u:
								Max = input.ReadInt32();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class EffectFloat : IMessage<EffectFloat>, IMessage, IEquatable<EffectFloat>, IDeepCloneable<EffectFloat>
				{
					private static readonly MessageParser<EffectFloat> _parser = new MessageParser<EffectFloat>(() => new EffectFloat());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private float value_;

					public const int DefaultValueFieldNumber = 2;

					private float defaultValue_;

					public const int MinFieldNumber = 3;

					private float min_;

					public const int MaxFieldNumber = 4;

					private float max_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<EffectFloat> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => EffectVariable.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public float Value
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
					public float DefaultValue
					{
						get
						{
							return defaultValue_;
						}
						set
						{
							defaultValue_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public float Min
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
					public float Max
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
					public EffectFloat()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectFloat(EffectFloat other)
						: this()
					{
						value_ = other.value_;
						defaultValue_ = other.defaultValue_;
						min_ = other.min_;
						max_ = other.max_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectFloat Clone()
					{
						return new EffectFloat(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as EffectFloat);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(EffectFloat other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Value, other.Value))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(DefaultValue, other.DefaultValue))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Min, other.Min))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Max, other.Max))
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
						if (Value != 0f)
						{
							num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Value);
						}
						if (DefaultValue != 0f)
						{
							num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(DefaultValue);
						}
						if (Min != 0f)
						{
							num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Min);
						}
						if (Max != 0f)
						{
							num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Max);
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
						if (Value != 0f)
						{
							output.WriteRawTag(13);
							output.WriteFloat(Value);
						}
						if (DefaultValue != 0f)
						{
							output.WriteRawTag(21);
							output.WriteFloat(DefaultValue);
						}
						if (Min != 0f)
						{
							output.WriteRawTag(29);
							output.WriteFloat(Min);
						}
						if (Max != 0f)
						{
							output.WriteRawTag(37);
							output.WriteFloat(Max);
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
						if (Value != 0f)
						{
							num += 5;
						}
						if (DefaultValue != 0f)
						{
							num += 5;
						}
						if (Min != 0f)
						{
							num += 5;
						}
						if (Max != 0f)
						{
							num += 5;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(EffectFloat other)
					{
						if (other != null)
						{
							if (other.Value != 0f)
							{
								Value = other.Value;
							}
							if (other.DefaultValue != 0f)
							{
								DefaultValue = other.DefaultValue;
							}
							if (other.Min != 0f)
							{
								Min = other.Min;
							}
							if (other.Max != 0f)
							{
								Max = other.Max;
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
							case 13u:
								Value = input.ReadFloat();
								break;
							case 21u:
								DefaultValue = input.ReadFloat();
								break;
							case 29u:
								Min = input.ReadFloat();
								break;
							case 37u:
								Max = input.ReadFloat();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class EffectDouble : IMessage<EffectDouble>, IMessage, IEquatable<EffectDouble>, IDeepCloneable<EffectDouble>
				{
					private static readonly MessageParser<EffectDouble> _parser = new MessageParser<EffectDouble>(() => new EffectDouble());

					private UnknownFieldSet _unknownFields;

					public const int ValueFieldNumber = 1;

					private double value_;

					public const int DefaultValueFieldNumber = 2;

					private double defaultValue_;

					public const int MinFieldNumber = 3;

					private double min_;

					public const int MaxFieldNumber = 4;

					private double max_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<EffectDouble> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => EffectVariable.Descriptor.NestedTypes[2];

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
					public double DefaultValue
					{
						get
						{
							return defaultValue_;
						}
						set
						{
							defaultValue_ = value;
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
					public EffectDouble()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectDouble(EffectDouble other)
						: this()
					{
						value_ = other.value_;
						defaultValue_ = other.defaultValue_;
						min_ = other.min_;
						max_ = other.max_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectDouble Clone()
					{
						return new EffectDouble(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as EffectDouble);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(EffectDouble other)
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
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DefaultValue, other.DefaultValue))
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
						if (DefaultValue != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DefaultValue);
						}
						if (Min != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Min);
						}
						if (Max != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Max);
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
						if (DefaultValue != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(DefaultValue);
						}
						if (Min != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(Min);
						}
						if (Max != 0.0)
						{
							output.WriteRawTag(33);
							output.WriteDouble(Max);
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
						if (DefaultValue != 0.0)
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
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(EffectDouble other)
					{
						if (other != null)
						{
							if (other.Value != 0.0)
							{
								Value = other.Value;
							}
							if (other.DefaultValue != 0.0)
							{
								DefaultValue = other.DefaultValue;
							}
							if (other.Min != 0.0)
							{
								Min = other.Min;
							}
							if (other.Max != 0.0)
							{
								Max = other.Max;
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
								DefaultValue = input.ReadDouble();
								break;
							case 25u:
								Min = input.ReadDouble();
								break;
							case 33u:
								Max = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class EffectColor : IMessage<EffectColor>, IMessage, IEquatable<EffectColor>, IDeepCloneable<EffectColor>
				{
					private static readonly MessageParser<EffectColor> _parser = new MessageParser<EffectColor>(() => new EffectColor());

					private UnknownFieldSet _unknownFields;

					public const int ColorFieldNumber = 1;

					private Color color_;

					public const int DefaultColorFieldNumber = 2;

					private Color defaultColor_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<EffectColor> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => EffectVariable.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Color Color
					{
						get
						{
							return color_;
						}
						set
						{
							color_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Color DefaultColor
					{
						get
						{
							return defaultColor_;
						}
						set
						{
							defaultColor_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectColor()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectColor(EffectColor other)
						: this()
					{
						color_ = ((other.color_ != null) ? other.color_.Clone() : null);
						defaultColor_ = ((other.defaultColor_ != null) ? other.defaultColor_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectColor Clone()
					{
						return new EffectColor(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as EffectColor);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(EffectColor other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Color, other.Color))
						{
							return false;
						}
						if (!object.Equals(DefaultColor, other.DefaultColor))
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
						if (color_ != null)
						{
							num ^= Color.GetHashCode();
						}
						if (defaultColor_ != null)
						{
							num ^= DefaultColor.GetHashCode();
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
						if (color_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Color);
						}
						if (defaultColor_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(DefaultColor);
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
						if (color_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Color);
						}
						if (defaultColor_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(DefaultColor);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(EffectColor other)
					{
						if (other == null)
						{
							return;
						}
						if (other.color_ != null)
						{
							if (color_ == null)
							{
								Color = new Color();
							}
							Color.MergeFrom(other.Color);
						}
						if (other.defaultColor_ != null)
						{
							if (defaultColor_ == null)
							{
								DefaultColor = new Color();
							}
							DefaultColor.MergeFrom(other.DefaultColor);
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
								if (color_ == null)
								{
									Color = new Color();
								}
								input.ReadMessage(Color);
								break;
							case 18u:
								if (defaultColor_ == null)
								{
									DefaultColor = new Color();
								}
								input.ReadMessage(DefaultColor);
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class EffectDirection : IMessage<EffectDirection>, IMessage, IEquatable<EffectDirection>, IDeepCloneable<EffectDirection>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum EffectDirection
						{
							[OriginalName("EFFECT_DIRECTION_NONE")]
							None = 0,
							[OriginalName("EFFECT_DIRECTION_TOP_LEFT")]
							TopLeft = 1,
							[OriginalName("EFFECT_DIRECTION_TOP")]
							Top = 2,
							[OriginalName("EFFECT_DIRECTION_TOP_RIGHT")]
							TopRight = 4,
							[OriginalName("EFFECT_DIRECTION_LEFT")]
							Left = 8,
							[OriginalName("EFFECT_DIRECTION_CENTER")]
							Center = 0x10,
							[OriginalName("EFFECT_DIRECTION_RIGHT")]
							Right = 0x20,
							[OriginalName("EFFECT_DIRECTION_BOTTOM_LEFT")]
							BottomLeft = 0x40,
							[OriginalName("EFFECT_DIRECTION_BOTTOM")]
							Bottom = 0x80,
							[OriginalName("EFFECT_DIRECTION_BOTTOM_RIGHT")]
							BottomRight = 0x100
						}
					}

					private static readonly MessageParser<EffectDirection> _parser = new MessageParser<EffectDirection>(() => new EffectDirection());

					private UnknownFieldSet _unknownFields;

					public const int DirectionFieldNumber = 1;

					private Types.EffectDirection direction_;

					public const int DefaultDirectionFieldNumber = 2;

					private Types.EffectDirection defaultDirection_;

					public const int AvailableDirectionsFieldNumber = 3;

					private uint availableDirections_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<EffectDirection> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => EffectVariable.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.EffectDirection Direction
					{
						get
						{
							return direction_;
						}
						set
						{
							direction_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.EffectDirection DefaultDirection
					{
						get
						{
							return defaultDirection_;
						}
						set
						{
							defaultDirection_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint AvailableDirections
					{
						get
						{
							return availableDirections_;
						}
						set
						{
							availableDirections_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectDirection()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectDirection(EffectDirection other)
						: this()
					{
						direction_ = other.direction_;
						defaultDirection_ = other.defaultDirection_;
						availableDirections_ = other.availableDirections_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EffectDirection Clone()
					{
						return new EffectDirection(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as EffectDirection);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(EffectDirection other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Direction != other.Direction)
						{
							return false;
						}
						if (DefaultDirection != other.DefaultDirection)
						{
							return false;
						}
						if (AvailableDirections != other.AvailableDirections)
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
						if (Direction != 0)
						{
							num ^= Direction.GetHashCode();
						}
						if (DefaultDirection != 0)
						{
							num ^= DefaultDirection.GetHashCode();
						}
						if (AvailableDirections != 0)
						{
							num ^= AvailableDirections.GetHashCode();
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
						if (Direction != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Direction);
						}
						if (DefaultDirection != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)DefaultDirection);
						}
						if (AvailableDirections != 0)
						{
							output.WriteRawTag(24);
							output.WriteUInt32(AvailableDirections);
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
						if (Direction != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Direction);
						}
						if (DefaultDirection != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)DefaultDirection);
						}
						if (AvailableDirections != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(AvailableDirections);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(EffectDirection other)
					{
						if (other != null)
						{
							if (other.Direction != 0)
							{
								Direction = other.Direction;
							}
							if (other.DefaultDirection != 0)
							{
								DefaultDirection = other.DefaultDirection;
							}
							if (other.AvailableDirections != 0)
							{
								AvailableDirections = other.AvailableDirections;
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
								Direction = (Types.EffectDirection)input.ReadEnum();
								break;
							case 16u:
								DefaultDirection = (Types.EffectDirection)input.ReadEnum();
								break;
							case 24u:
								AvailableDirections = input.ReadUInt32();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<EffectVariable> _parser = new MessageParser<EffectVariable>(() => new EffectVariable());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int DescriptionFieldNumber = 2;

			private string description_ = "";

			public const int IntFieldNumber = 3;

			public const int FloatFieldNumber = 4;

			public const int ColorFieldNumber = 5;

			public const int DirectionFieldNumber = 6;

			public const int DoubleFieldNumber = 7;

			private object type_;

			private TypeOneofCase typeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EffectVariable> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Effect.Descriptor.NestedTypes[0];

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
			public Types.EffectInt Int
			{
				get
				{
					if (typeCase_ != TypeOneofCase.Int)
					{
						return null;
					}
					return (Types.EffectInt)type_;
				}
				set
				{
					type_ = value;
					typeCase_ = ((value != null) ? TypeOneofCase.Int : TypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.EffectFloat Float
			{
				get
				{
					if (typeCase_ != TypeOneofCase.Float)
					{
						return null;
					}
					return (Types.EffectFloat)type_;
				}
				set
				{
					type_ = value;
					typeCase_ = ((value != null) ? TypeOneofCase.Float : TypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.EffectColor Color
			{
				get
				{
					if (typeCase_ != TypeOneofCase.Color)
					{
						return null;
					}
					return (Types.EffectColor)type_;
				}
				set
				{
					type_ = value;
					typeCase_ = ((value != null) ? TypeOneofCase.Color : TypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.EffectDirection Direction
			{
				get
				{
					if (typeCase_ != TypeOneofCase.Direction)
					{
						return null;
					}
					return (Types.EffectDirection)type_;
				}
				set
				{
					type_ = value;
					typeCase_ = ((value != null) ? TypeOneofCase.Direction : TypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.EffectDouble Double
			{
				get
				{
					if (typeCase_ != TypeOneofCase.Double)
					{
						return null;
					}
					return (Types.EffectDouble)type_;
				}
				set
				{
					type_ = value;
					typeCase_ = ((value != null) ? TypeOneofCase.Double : TypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TypeOneofCase TypeCase => typeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EffectVariable()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EffectVariable(EffectVariable other)
				: this()
			{
				name_ = other.name_;
				description_ = other.description_;
				switch (other.TypeCase)
				{
				case TypeOneofCase.Int:
					Int = other.Int.Clone();
					break;
				case TypeOneofCase.Float:
					Float = other.Float.Clone();
					break;
				case TypeOneofCase.Color:
					Color = other.Color.Clone();
					break;
				case TypeOneofCase.Direction:
					Direction = other.Direction.Clone();
					break;
				case TypeOneofCase.Double:
					Double = other.Double.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EffectVariable Clone()
			{
				return new EffectVariable(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearType()
			{
				typeCase_ = TypeOneofCase.None;
				type_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EffectVariable);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EffectVariable other)
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
				if (Description != other.Description)
				{
					return false;
				}
				if (!object.Equals(Int, other.Int))
				{
					return false;
				}
				if (!object.Equals(Float, other.Float))
				{
					return false;
				}
				if (!object.Equals(Color, other.Color))
				{
					return false;
				}
				if (!object.Equals(Direction, other.Direction))
				{
					return false;
				}
				if (!object.Equals(Double, other.Double))
				{
					return false;
				}
				if (TypeCase != other.TypeCase)
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
				if (Description.Length != 0)
				{
					num ^= Description.GetHashCode();
				}
				if (typeCase_ == TypeOneofCase.Int)
				{
					num ^= Int.GetHashCode();
				}
				if (typeCase_ == TypeOneofCase.Float)
				{
					num ^= Float.GetHashCode();
				}
				if (typeCase_ == TypeOneofCase.Color)
				{
					num ^= Color.GetHashCode();
				}
				if (typeCase_ == TypeOneofCase.Direction)
				{
					num ^= Direction.GetHashCode();
				}
				if (typeCase_ == TypeOneofCase.Double)
				{
					num ^= Double.GetHashCode();
				}
				num ^= (int)typeCase_;
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
				if (Description.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Description);
				}
				if (typeCase_ == TypeOneofCase.Int)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Int);
				}
				if (typeCase_ == TypeOneofCase.Float)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Float);
				}
				if (typeCase_ == TypeOneofCase.Color)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Color);
				}
				if (typeCase_ == TypeOneofCase.Direction)
				{
					output.WriteRawTag(50);
					output.WriteMessage(Direction);
				}
				if (typeCase_ == TypeOneofCase.Double)
				{
					output.WriteRawTag(58);
					output.WriteMessage(Double);
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
				if (Description.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Description);
				}
				if (typeCase_ == TypeOneofCase.Int)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Int);
				}
				if (typeCase_ == TypeOneofCase.Float)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Float);
				}
				if (typeCase_ == TypeOneofCase.Color)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				if (typeCase_ == TypeOneofCase.Direction)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Direction);
				}
				if (typeCase_ == TypeOneofCase.Double)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Double);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(EffectVariable other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.Description.Length != 0)
				{
					Description = other.Description;
				}
				switch (other.TypeCase)
				{
				case TypeOneofCase.Int:
					if (Int == null)
					{
						Int = new Types.EffectInt();
					}
					Int.MergeFrom(other.Int);
					break;
				case TypeOneofCase.Float:
					if (Float == null)
					{
						Float = new Types.EffectFloat();
					}
					Float.MergeFrom(other.Float);
					break;
				case TypeOneofCase.Color:
					if (Color == null)
					{
						Color = new Types.EffectColor();
					}
					Color.MergeFrom(other.Color);
					break;
				case TypeOneofCase.Direction:
					if (Direction == null)
					{
						Direction = new Types.EffectDirection();
					}
					Direction.MergeFrom(other.Direction);
					break;
				case TypeOneofCase.Double:
					if (Double == null)
					{
						Double = new Types.EffectDouble();
					}
					Double.MergeFrom(other.Double);
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
						Name = input.ReadString();
						break;
					case 18u:
						Description = input.ReadString();
						break;
					case 26u:
					{
						Types.EffectInt effectInt = new Types.EffectInt();
						if (typeCase_ == TypeOneofCase.Int)
						{
							effectInt.MergeFrom(Int);
						}
						input.ReadMessage(effectInt);
						Int = effectInt;
						break;
					}
					case 34u:
					{
						Types.EffectFloat effectFloat = new Types.EffectFloat();
						if (typeCase_ == TypeOneofCase.Float)
						{
							effectFloat.MergeFrom(Float);
						}
						input.ReadMessage(effectFloat);
						Float = effectFloat;
						break;
					}
					case 42u:
					{
						Types.EffectColor effectColor = new Types.EffectColor();
						if (typeCase_ == TypeOneofCase.Color)
						{
							effectColor.MergeFrom(Color);
						}
						input.ReadMessage(effectColor);
						Color = effectColor;
						break;
					}
					case 50u:
					{
						Types.EffectDirection effectDirection = new Types.EffectDirection();
						if (typeCase_ == TypeOneofCase.Direction)
						{
							effectDirection.MergeFrom(Direction);
						}
						input.ReadMessage(effectDirection);
						Direction = effectDirection;
						break;
					}
					case 58u:
					{
						Types.EffectDouble effectDouble = new Types.EffectDouble();
						if (typeCase_ == TypeOneofCase.Double)
						{
							effectDouble.MergeFrom(Double);
						}
						input.ReadMessage(effectDouble);
						Double = effectDouble;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Preset : IMessage<Preset>, IMessage, IEquatable<Preset>, IDeepCloneable<Preset>
		{
			private static readonly MessageParser<Preset> _parser = new MessageParser<Preset>(() => new Preset());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int EffectsFieldNumber = 3;

			private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(26u, Effect.Parser);

			private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Preset> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Effect.Descriptor.NestedTypes[1];

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
			public RepeatedField<Effect> Effects => effects_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset(Preset other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				effects_ = other.effects_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset Clone()
			{
				return new Preset(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Preset);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Preset other)
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
				if (Name != other.Name)
				{
					return false;
				}
				if (!effects_.Equals(other.effects_))
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= effects_.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				effects_.WriteTo(output, _repeated_effects_codec);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += effects_.CalculateSize(_repeated_effects_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Preset other)
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
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				effects_.Add(other.effects_);
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
						Name = input.ReadString();
						break;
					case 26u:
						effects_.AddEntriesFrom(input, _repeated_effects_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Effect> _parser = new MessageParser<Effect>(() => new Effect());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int EnabledFieldNumber = 2;

	private bool enabled_;

	public const int NameFieldNumber = 3;

	private string name_ = "";

	public const int RenderIdFieldNumber = 4;

	private string renderId_ = "";

	public const int BehaviorDescriptionFieldNumber = 5;

	private string behaviorDescription_ = "";

	public const int CategoryFieldNumber = 6;

	private string category_ = "";

	public const int VariablesFieldNumber = 7;

	private static readonly FieldCodec<Types.EffectVariable> _repeated_variables_codec = FieldCodec.ForMessage(58u, Types.EffectVariable.Parser);

	private readonly RepeatedField<Types.EffectVariable> variables_ = new RepeatedField<Types.EffectVariable>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Effect> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => EffectsReflection.Descriptor.MessageTypes[0];

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
	public bool Enabled
	{
		get
		{
			return enabled_;
		}
		set
		{
			enabled_ = value;
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
	public string RenderId
	{
		get
		{
			return renderId_;
		}
		set
		{
			renderId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string BehaviorDescription
	{
		get
		{
			return behaviorDescription_;
		}
		set
		{
			behaviorDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Category
	{
		get
		{
			return category_;
		}
		set
		{
			category_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.EffectVariable> Variables => variables_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Effect()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Effect(Effect other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		enabled_ = other.enabled_;
		name_ = other.name_;
		renderId_ = other.renderId_;
		behaviorDescription_ = other.behaviorDescription_;
		category_ = other.category_;
		variables_ = other.variables_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Effect Clone()
	{
		return new Effect(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Effect);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Effect other)
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
		if (Enabled != other.Enabled)
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (RenderId != other.RenderId)
		{
			return false;
		}
		if (BehaviorDescription != other.BehaviorDescription)
		{
			return false;
		}
		if (Category != other.Category)
		{
			return false;
		}
		if (!variables_.Equals(other.variables_))
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
		if (Enabled)
		{
			num ^= Enabled.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (RenderId.Length != 0)
		{
			num ^= RenderId.GetHashCode();
		}
		if (BehaviorDescription.Length != 0)
		{
			num ^= BehaviorDescription.GetHashCode();
		}
		if (Category.Length != 0)
		{
			num ^= Category.GetHashCode();
		}
		num ^= variables_.GetHashCode();
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
		if (Enabled)
		{
			output.WriteRawTag(16);
			output.WriteBool(Enabled);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Name);
		}
		if (RenderId.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(RenderId);
		}
		if (BehaviorDescription.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(BehaviorDescription);
		}
		if (Category.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(Category);
		}
		variables_.WriteTo(output, _repeated_variables_codec);
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
		if (Enabled)
		{
			num += 2;
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (RenderId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RenderId);
		}
		if (BehaviorDescription.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BehaviorDescription);
		}
		if (Category.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Category);
		}
		num += variables_.CalculateSize(_repeated_variables_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Effect other)
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
		if (other.Enabled)
		{
			Enabled = other.Enabled;
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.RenderId.Length != 0)
		{
			RenderId = other.RenderId;
		}
		if (other.BehaviorDescription.Length != 0)
		{
			BehaviorDescription = other.BehaviorDescription;
		}
		if (other.Category.Length != 0)
		{
			Category = other.Category;
		}
		variables_.Add(other.variables_);
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
			case 16u:
				Enabled = input.ReadBool();
				break;
			case 26u:
				Name = input.ReadString();
				break;
			case 34u:
				RenderId = input.ReadString();
				break;
			case 42u:
				BehaviorDescription = input.ReadString();
				break;
			case 50u:
				Category = input.ReadString();
				break;
			case 58u:
				variables_.AddEntriesFrom(input, _repeated_variables_codec);
				break;
			}
		}
	}
}
