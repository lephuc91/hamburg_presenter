using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Layer : IMessage<Layer>, IMessage, IEquatable<Layer>, IDeepCloneable<Layer>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum BlendMode
		{
			[OriginalName("BLEND_MODE_NORMAL")]
			Normal,
			[OriginalName("BLEND_MODE_DISSOLVE")]
			Dissolve,
			[OriginalName("BLEND_MODE_DARKEN")]
			Darken,
			[OriginalName("BLEND_MODE_MULTIPLY")]
			Multiply,
			[OriginalName("BLEND_MODE_COLOR_BURN")]
			ColorBurn,
			[OriginalName("BLEND_MODE_LINEAR_BURN")]
			LinearBurn,
			[OriginalName("BLEND_MODE_DARKER_COLOR")]
			DarkerColor,
			[OriginalName("BLEND_MODE_LIGHTEN")]
			Lighten,
			[OriginalName("BLEND_MODE_SCREEN")]
			Screen,
			[OriginalName("BLEND_MODE_COLOR_DODGE")]
			ColorDodge,
			[OriginalName("BLEND_MODE_LINEAR_DODGE")]
			LinearDodge,
			[OriginalName("BLEND_MODE_LIGHTER_COLOR")]
			LighterColor,
			[OriginalName("BLEND_MODE_OVERLAY")]
			Overlay,
			[OriginalName("BLEND_MODE_SOFT_LIGHT")]
			SoftLight,
			[OriginalName("BLEND_MODE_HARD_LIGHT")]
			HardLight,
			[OriginalName("BLEND_MODE_VIVID_LIGHT")]
			VividLight,
			[OriginalName("BLEND_MODE_LINEAR_LIGHT")]
			LinearLight,
			[OriginalName("BLEND_MODE_PIN_LIGHT")]
			PinLight,
			[OriginalName("BLEND_MODE_HARD_MIX")]
			HardMix,
			[OriginalName("BLEND_MODE_DIFFERENCE")]
			Difference,
			[OriginalName("BLEND_MODE_EXCLUSION")]
			Exclusion,
			[OriginalName("BLEND_MODE_SUBTRACT")]
			Subtract,
			[OriginalName("BLEND_MODE_DIVIDE")]
			Divide,
			[OriginalName("BLEND_MODE_HUE")]
			Hue,
			[OriginalName("BLEND_MODE_SATURATION")]
			Saturation,
			[OriginalName("BLEND_MODE_COLOR")]
			Color,
			[OriginalName("BLEND_MODE_LUMINOSITY")]
			Luminosity
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

			public const int LayerFieldNumber = 3;

			private Layer layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Preset> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Layer.Descriptor.NestedTypes[0];

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
			public Layer Layer
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
				layer_ = ((other.layer_ != null) ? other.layer_.Clone() : null);
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
				if (!object.Equals(Layer, other.Layer))
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
				if (layer_ != null)
				{
					num ^= Layer.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (layer_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Layer);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (layer_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Layer);
				}
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
				if (other.layer_ != null)
				{
					if (layer_ == null)
					{
						Layer = new Layer();
					}
					Layer.MergeFrom(other.Layer);
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
						Name = input.ReadString();
						break;
					case 26u:
						if (layer_ == null)
						{
							Layer = new Layer();
						}
						input.ReadMessage(Layer);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Blending : IMessage<Blending>, IMessage, IEquatable<Blending>, IDeepCloneable<Blending>
		{
			public enum BlendingTypeOneofCase
			{
				None,
				Standard,
				Matte
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Standard : IMessage<Standard>, IMessage, IEquatable<Standard>, IDeepCloneable<Standard>
				{
					private static readonly MessageParser<Standard> _parser = new MessageParser<Standard>(() => new Standard());

					private UnknownFieldSet _unknownFields;

					public const int ModeFieldNumber = 1;

					private BlendMode mode_;

					public const int OpacityFieldNumber = 2;

					private double opacity_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Standard> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Blending.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BlendMode Mode
					{
						get
						{
							return mode_;
						}
						set
						{
							mode_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Opacity
					{
						get
						{
							return opacity_;
						}
						set
						{
							opacity_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Standard()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Standard(Standard other)
						: this()
					{
						mode_ = other.mode_;
						opacity_ = other.opacity_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Standard Clone()
					{
						return new Standard(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Standard);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Standard other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Mode != other.Mode)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Opacity, other.Opacity))
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
						if (Mode != 0)
						{
							num ^= Mode.GetHashCode();
						}
						if (Opacity != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Opacity);
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
						if (Mode != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Mode);
						}
						if (Opacity != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(Opacity);
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
						if (Mode != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
						}
						if (Opacity != 0.0)
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
					public void MergeFrom(Standard other)
					{
						if (other != null)
						{
							if (other.Mode != 0)
							{
								Mode = other.Mode;
							}
							if (other.Opacity != 0.0)
							{
								Opacity = other.Opacity;
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
								Mode = (BlendMode)input.ReadEnum();
								break;
							case 17u:
								Opacity = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Matte : IMessage<Matte>, IMessage, IEquatable<Matte>, IDeepCloneable<Matte>
				{
					public enum MatteTypeOneofCase
					{
						None = 0,
						Alpha = 1,
						Luma = 2,
						White = 4
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Alpha : IMessage<Alpha>, IMessage, IEquatable<Alpha>, IDeepCloneable<Alpha>
						{
							private static readonly MessageParser<Alpha> _parser = new MessageParser<Alpha>(() => new Alpha());

							private UnknownFieldSet _unknownFields;

							public const int InvertedFieldNumber = 1;

							private bool inverted_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Alpha> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Matte.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Inverted
							{
								get
								{
									return inverted_;
								}
								set
								{
									inverted_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Alpha()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Alpha(Alpha other)
								: this()
							{
								inverted_ = other.inverted_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Alpha Clone()
							{
								return new Alpha(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Alpha);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Alpha other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Inverted != other.Inverted)
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
								if (Inverted)
								{
									num ^= Inverted.GetHashCode();
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
								if (Inverted)
								{
									output.WriteRawTag(8);
									output.WriteBool(Inverted);
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
								if (Inverted)
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
							public void MergeFrom(Alpha other)
							{
								if (other != null)
								{
									if (other.Inverted)
									{
										Inverted = other.Inverted;
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
										Inverted = input.ReadBool();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Luma : IMessage<Luma>, IMessage, IEquatable<Luma>, IDeepCloneable<Luma>
						{
							private static readonly MessageParser<Luma> _parser = new MessageParser<Luma>(() => new Luma());

							private UnknownFieldSet _unknownFields;

							public const int InvertedFieldNumber = 1;

							private bool inverted_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Luma> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Matte.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Inverted
							{
								get
								{
									return inverted_;
								}
								set
								{
									inverted_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Luma()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Luma(Luma other)
								: this()
							{
								inverted_ = other.inverted_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Luma Clone()
							{
								return new Luma(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Luma);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Luma other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Inverted != other.Inverted)
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
								if (Inverted)
								{
									num ^= Inverted.GetHashCode();
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
								if (Inverted)
								{
									output.WriteRawTag(8);
									output.WriteBool(Inverted);
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
								if (Inverted)
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
							public void MergeFrom(Luma other)
							{
								if (other != null)
								{
									if (other.Inverted)
									{
										Inverted = other.Inverted;
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
										Inverted = input.ReadBool();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class White : IMessage<White>, IMessage, IEquatable<White>, IDeepCloneable<White>
						{
							private static readonly MessageParser<White> _parser = new MessageParser<White>(() => new White());

							private UnknownFieldSet _unknownFields;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<White> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Matte.Descriptor.NestedTypes[2];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public White()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public White(White other)
								: this()
							{
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public White Clone()
							{
								return new White(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as White);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(White other)
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
							public void MergeFrom(White other)
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

					private static readonly MessageParser<Matte> _parser = new MessageParser<Matte>(() => new Matte());

					private UnknownFieldSet _unknownFields;

					public const int AlphaFieldNumber = 1;

					public const int LumaFieldNumber = 2;

					public const int WhiteFieldNumber = 4;

					private object matteType_;

					private MatteTypeOneofCase matteTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Matte> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Blending.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Alpha Alpha
					{
						get
						{
							if (matteTypeCase_ != MatteTypeOneofCase.Alpha)
							{
								return null;
							}
							return (Types.Alpha)matteType_;
						}
						set
						{
							matteType_ = value;
							matteTypeCase_ = ((value != null) ? MatteTypeOneofCase.Alpha : MatteTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Luma Luma
					{
						get
						{
							if (matteTypeCase_ != MatteTypeOneofCase.Luma)
							{
								return null;
							}
							return (Types.Luma)matteType_;
						}
						set
						{
							matteType_ = value;
							matteTypeCase_ = ((value != null) ? MatteTypeOneofCase.Luma : MatteTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.White White
					{
						get
						{
							if (matteTypeCase_ != MatteTypeOneofCase.White)
							{
								return null;
							}
							return (Types.White)matteType_;
						}
						set
						{
							matteType_ = value;
							matteTypeCase_ = ((value != null) ? MatteTypeOneofCase.White : MatteTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MatteTypeOneofCase MatteTypeCase => matteTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Matte()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Matte(Matte other)
						: this()
					{
						switch (other.MatteTypeCase)
						{
						case MatteTypeOneofCase.Alpha:
							Alpha = other.Alpha.Clone();
							break;
						case MatteTypeOneofCase.Luma:
							Luma = other.Luma.Clone();
							break;
						case MatteTypeOneofCase.White:
							White = other.White.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Matte Clone()
					{
						return new Matte(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearMatteType()
					{
						matteTypeCase_ = MatteTypeOneofCase.None;
						matteType_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Matte);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Matte other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Alpha, other.Alpha))
						{
							return false;
						}
						if (!object.Equals(Luma, other.Luma))
						{
							return false;
						}
						if (!object.Equals(White, other.White))
						{
							return false;
						}
						if (MatteTypeCase != other.MatteTypeCase)
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
						if (matteTypeCase_ == MatteTypeOneofCase.Alpha)
						{
							num ^= Alpha.GetHashCode();
						}
						if (matteTypeCase_ == MatteTypeOneofCase.Luma)
						{
							num ^= Luma.GetHashCode();
						}
						if (matteTypeCase_ == MatteTypeOneofCase.White)
						{
							num ^= White.GetHashCode();
						}
						num ^= (int)matteTypeCase_;
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
						if (matteTypeCase_ == MatteTypeOneofCase.Alpha)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Alpha);
						}
						if (matteTypeCase_ == MatteTypeOneofCase.Luma)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Luma);
						}
						if (matteTypeCase_ == MatteTypeOneofCase.White)
						{
							output.WriteRawTag(34);
							output.WriteMessage(White);
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
						if (matteTypeCase_ == MatteTypeOneofCase.Alpha)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Alpha);
						}
						if (matteTypeCase_ == MatteTypeOneofCase.Luma)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Luma);
						}
						if (matteTypeCase_ == MatteTypeOneofCase.White)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(White);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Matte other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.MatteTypeCase)
						{
						case MatteTypeOneofCase.Alpha:
							if (Alpha == null)
							{
								Alpha = new Types.Alpha();
							}
							Alpha.MergeFrom(other.Alpha);
							break;
						case MatteTypeOneofCase.Luma:
							if (Luma == null)
							{
								Luma = new Types.Luma();
							}
							Luma.MergeFrom(other.Luma);
							break;
						case MatteTypeOneofCase.White:
							if (White == null)
							{
								White = new Types.White();
							}
							White.MergeFrom(other.White);
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
								Types.Alpha alpha = new Types.Alpha();
								if (matteTypeCase_ == MatteTypeOneofCase.Alpha)
								{
									alpha.MergeFrom(Alpha);
								}
								input.ReadMessage(alpha);
								Alpha = alpha;
								break;
							}
							case 18u:
							{
								Types.Luma luma = new Types.Luma();
								if (matteTypeCase_ == MatteTypeOneofCase.Luma)
								{
									luma.MergeFrom(Luma);
								}
								input.ReadMessage(luma);
								Luma = luma;
								break;
							}
							case 34u:
							{
								Types.White white = new Types.White();
								if (matteTypeCase_ == MatteTypeOneofCase.White)
								{
									white.MergeFrom(White);
								}
								input.ReadMessage(white);
								White = white;
								break;
							}
							}
						}
					}
				}
			}

			private static readonly MessageParser<Blending> _parser = new MessageParser<Blending>(() => new Blending());

			private UnknownFieldSet _unknownFields;

			public const int StandardFieldNumber = 1;

			public const int MatteFieldNumber = 2;

			private object blendingType_;

			private BlendingTypeOneofCase blendingTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Blending> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Layer.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Standard Standard
			{
				get
				{
					if (blendingTypeCase_ != BlendingTypeOneofCase.Standard)
					{
						return null;
					}
					return (Types.Standard)blendingType_;
				}
				set
				{
					blendingType_ = value;
					blendingTypeCase_ = ((value != null) ? BlendingTypeOneofCase.Standard : BlendingTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Matte Matte
			{
				get
				{
					if (blendingTypeCase_ != BlendingTypeOneofCase.Matte)
					{
						return null;
					}
					return (Types.Matte)blendingType_;
				}
				set
				{
					blendingType_ = value;
					blendingTypeCase_ = ((value != null) ? BlendingTypeOneofCase.Matte : BlendingTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendingTypeOneofCase BlendingTypeCase => blendingTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Blending()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Blending(Blending other)
				: this()
			{
				switch (other.BlendingTypeCase)
				{
				case BlendingTypeOneofCase.Standard:
					Standard = other.Standard.Clone();
					break;
				case BlendingTypeOneofCase.Matte:
					Matte = other.Matte.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Blending Clone()
			{
				return new Blending(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearBlendingType()
			{
				blendingTypeCase_ = BlendingTypeOneofCase.None;
				blendingType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Blending);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Blending other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Standard, other.Standard))
				{
					return false;
				}
				if (!object.Equals(Matte, other.Matte))
				{
					return false;
				}
				if (BlendingTypeCase != other.BlendingTypeCase)
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
				if (blendingTypeCase_ == BlendingTypeOneofCase.Standard)
				{
					num ^= Standard.GetHashCode();
				}
				if (blendingTypeCase_ == BlendingTypeOneofCase.Matte)
				{
					num ^= Matte.GetHashCode();
				}
				num ^= (int)blendingTypeCase_;
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
				if (blendingTypeCase_ == BlendingTypeOneofCase.Standard)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Standard);
				}
				if (blendingTypeCase_ == BlendingTypeOneofCase.Matte)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Matte);
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
				if (blendingTypeCase_ == BlendingTypeOneofCase.Standard)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Standard);
				}
				if (blendingTypeCase_ == BlendingTypeOneofCase.Matte)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Matte);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Blending other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.BlendingTypeCase)
				{
				case BlendingTypeOneofCase.Standard:
					if (Standard == null)
					{
						Standard = new Types.Standard();
					}
					Standard.MergeFrom(other.Standard);
					break;
				case BlendingTypeOneofCase.Matte:
					if (Matte == null)
					{
						Matte = new Types.Matte();
					}
					Matte.MergeFrom(other.Matte);
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
						Types.Standard standard = new Types.Standard();
						if (blendingTypeCase_ == BlendingTypeOneofCase.Standard)
						{
							standard.MergeFrom(Standard);
						}
						input.ReadMessage(standard);
						Standard = standard;
						break;
					}
					case 18u:
					{
						Types.Matte matte = new Types.Matte();
						if (blendingTypeCase_ == BlendingTypeOneofCase.Matte)
						{
							matte.MergeFrom(Matte);
						}
						input.ReadMessage(matte);
						Matte = matte;
						break;
					}
					}
				}
			}
		}
	}

	private static readonly MessageParser<Layer> _parser = new MessageParser<Layer>(() => new Layer());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int ColorFieldNumber = 3;

	private Color color_;

	public const int MutedFieldNumber = 4;

	private bool muted_;

	public const int HiddenFieldNumber = 5;

	private bool hidden_;

	public const int BlendModeFieldNumber = 6;

	private Types.BlendMode blendMode_;

	public const int OpacityFieldNumber = 7;

	private double opacity_;

	public const int SelectedTargetSetUuidFieldNumber = 8;

	private UUID selectedTargetSetUuid_;

	public const int EffectsPresetUuidFieldNumber = 9;

	private UUID effectsPresetUuid_;

	public const int EffectsBuildDurationFieldNumber = 10;

	private double effectsBuildDuration_;

	public const int LayerPresetUuidFieldNumber = 11;

	private UUID layerPresetUuid_;

	public const int HotKeyFieldNumber = 12;

	private HotKey hotKey_;

	public const int TransitionFieldNumber = 13;

	private Transition transition_;

	public const int EffectsFieldNumber = 14;

	private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(114u, Effect.Parser);

	private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

	public const int BlendFieldNumber = 15;

	private Types.Blending blend_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Layer> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => LayersReflection.Descriptor.MessageTypes[0];

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
	public bool Muted
	{
		get
		{
			return muted_;
		}
		set
		{
			muted_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Hidden
	{
		get
		{
			return hidden_;
		}
		set
		{
			hidden_ = value;
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BlendMode BlendMode
	{
		get
		{
			return blendMode_;
		}
		set
		{
			blendMode_ = value;
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Opacity
	{
		get
		{
			return opacity_;
		}
		set
		{
			opacity_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID SelectedTargetSetUuid
	{
		get
		{
			return selectedTargetSetUuid_;
		}
		set
		{
			selectedTargetSetUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID EffectsPresetUuid
	{
		get
		{
			return effectsPresetUuid_;
		}
		set
		{
			effectsPresetUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double EffectsBuildDuration
	{
		get
		{
			return effectsBuildDuration_;
		}
		set
		{
			effectsBuildDuration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID LayerPresetUuid
	{
		get
		{
			return layerPresetUuid_;
		}
		set
		{
			layerPresetUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HotKey HotKey
	{
		get
		{
			return hotKey_;
		}
		set
		{
			hotKey_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Effect> Effects => effects_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Blending Blend
	{
		get
		{
			return blend_;
		}
		set
		{
			blend_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Layer()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Layer(Layer other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		color_ = ((other.color_ != null) ? other.color_.Clone() : null);
		muted_ = other.muted_;
		hidden_ = other.hidden_;
		blendMode_ = other.blendMode_;
		opacity_ = other.opacity_;
		selectedTargetSetUuid_ = ((other.selectedTargetSetUuid_ != null) ? other.selectedTargetSetUuid_.Clone() : null);
		effectsPresetUuid_ = ((other.effectsPresetUuid_ != null) ? other.effectsPresetUuid_.Clone() : null);
		effectsBuildDuration_ = other.effectsBuildDuration_;
		layerPresetUuid_ = ((other.layerPresetUuid_ != null) ? other.layerPresetUuid_.Clone() : null);
		hotKey_ = ((other.hotKey_ != null) ? other.hotKey_.Clone() : null);
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		effects_ = other.effects_.Clone();
		blend_ = ((other.blend_ != null) ? other.blend_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Layer Clone()
	{
		return new Layer(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Layer);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Layer other)
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
		if (!object.Equals(Color, other.Color))
		{
			return false;
		}
		if (Muted != other.Muted)
		{
			return false;
		}
		if (Hidden != other.Hidden)
		{
			return false;
		}
		if (BlendMode != other.BlendMode)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Opacity, other.Opacity))
		{
			return false;
		}
		if (!object.Equals(SelectedTargetSetUuid, other.SelectedTargetSetUuid))
		{
			return false;
		}
		if (!object.Equals(EffectsPresetUuid, other.EffectsPresetUuid))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(EffectsBuildDuration, other.EffectsBuildDuration))
		{
			return false;
		}
		if (!object.Equals(LayerPresetUuid, other.LayerPresetUuid))
		{
			return false;
		}
		if (!object.Equals(HotKey, other.HotKey))
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
		{
			return false;
		}
		if (!effects_.Equals(other.effects_))
		{
			return false;
		}
		if (!object.Equals(Blend, other.Blend))
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
		if (color_ != null)
		{
			num ^= Color.GetHashCode();
		}
		if (Muted)
		{
			num ^= Muted.GetHashCode();
		}
		if (Hidden)
		{
			num ^= Hidden.GetHashCode();
		}
		if (BlendMode != 0)
		{
			num ^= BlendMode.GetHashCode();
		}
		if (Opacity != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Opacity);
		}
		if (selectedTargetSetUuid_ != null)
		{
			num ^= SelectedTargetSetUuid.GetHashCode();
		}
		if (effectsPresetUuid_ != null)
		{
			num ^= EffectsPresetUuid.GetHashCode();
		}
		if (EffectsBuildDuration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(EffectsBuildDuration);
		}
		if (layerPresetUuid_ != null)
		{
			num ^= LayerPresetUuid.GetHashCode();
		}
		if (hotKey_ != null)
		{
			num ^= HotKey.GetHashCode();
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
		}
		num ^= effects_.GetHashCode();
		if (blend_ != null)
		{
			num ^= Blend.GetHashCode();
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
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (color_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Color);
		}
		if (Muted)
		{
			output.WriteRawTag(32);
			output.WriteBool(Muted);
		}
		if (Hidden)
		{
			output.WriteRawTag(40);
			output.WriteBool(Hidden);
		}
		if (BlendMode != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)BlendMode);
		}
		if (Opacity != 0.0)
		{
			output.WriteRawTag(57);
			output.WriteDouble(Opacity);
		}
		if (selectedTargetSetUuid_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(SelectedTargetSetUuid);
		}
		if (effectsPresetUuid_ != null)
		{
			output.WriteRawTag(74);
			output.WriteMessage(EffectsPresetUuid);
		}
		if (EffectsBuildDuration != 0.0)
		{
			output.WriteRawTag(81);
			output.WriteDouble(EffectsBuildDuration);
		}
		if (layerPresetUuid_ != null)
		{
			output.WriteRawTag(90);
			output.WriteMessage(LayerPresetUuid);
		}
		if (hotKey_ != null)
		{
			output.WriteRawTag(98);
			output.WriteMessage(HotKey);
		}
		if (transition_ != null)
		{
			output.WriteRawTag(106);
			output.WriteMessage(Transition);
		}
		effects_.WriteTo(output, _repeated_effects_codec);
		if (blend_ != null)
		{
			output.WriteRawTag(122);
			output.WriteMessage(Blend);
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
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (color_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Color);
		}
		if (Muted)
		{
			num += 2;
		}
		if (Hidden)
		{
			num += 2;
		}
		if (BlendMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)BlendMode);
		}
		if (Opacity != 0.0)
		{
			num += 9;
		}
		if (selectedTargetSetUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SelectedTargetSetUuid);
		}
		if (effectsPresetUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(EffectsPresetUuid);
		}
		if (EffectsBuildDuration != 0.0)
		{
			num += 9;
		}
		if (layerPresetUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LayerPresetUuid);
		}
		if (hotKey_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HotKey);
		}
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		num += effects_.CalculateSize(_repeated_effects_codec);
		if (blend_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Blend);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Layer other)
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
		if (other.color_ != null)
		{
			if (color_ == null)
			{
				Color = new Color();
			}
			Color.MergeFrom(other.Color);
		}
		if (other.Muted)
		{
			Muted = other.Muted;
		}
		if (other.Hidden)
		{
			Hidden = other.Hidden;
		}
		if (other.BlendMode != 0)
		{
			BlendMode = other.BlendMode;
		}
		if (other.Opacity != 0.0)
		{
			Opacity = other.Opacity;
		}
		if (other.selectedTargetSetUuid_ != null)
		{
			if (selectedTargetSetUuid_ == null)
			{
				SelectedTargetSetUuid = new UUID();
			}
			SelectedTargetSetUuid.MergeFrom(other.SelectedTargetSetUuid);
		}
		if (other.effectsPresetUuid_ != null)
		{
			if (effectsPresetUuid_ == null)
			{
				EffectsPresetUuid = new UUID();
			}
			EffectsPresetUuid.MergeFrom(other.EffectsPresetUuid);
		}
		if (other.EffectsBuildDuration != 0.0)
		{
			EffectsBuildDuration = other.EffectsBuildDuration;
		}
		if (other.layerPresetUuid_ != null)
		{
			if (layerPresetUuid_ == null)
			{
				LayerPresetUuid = new UUID();
			}
			LayerPresetUuid.MergeFrom(other.LayerPresetUuid);
		}
		if (other.hotKey_ != null)
		{
			if (hotKey_ == null)
			{
				HotKey = new HotKey();
			}
			HotKey.MergeFrom(other.HotKey);
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
		}
		effects_.Add(other.effects_);
		if (other.blend_ != null)
		{
			if (blend_ == null)
			{
				Blend = new Types.Blending();
			}
			Blend.MergeFrom(other.Blend);
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
				Name = input.ReadString();
				break;
			case 26u:
				if (color_ == null)
				{
					Color = new Color();
				}
				input.ReadMessage(Color);
				break;
			case 32u:
				Muted = input.ReadBool();
				break;
			case 40u:
				Hidden = input.ReadBool();
				break;
			case 48u:
				BlendMode = (Types.BlendMode)input.ReadEnum();
				break;
			case 57u:
				Opacity = input.ReadDouble();
				break;
			case 66u:
				if (selectedTargetSetUuid_ == null)
				{
					SelectedTargetSetUuid = new UUID();
				}
				input.ReadMessage(SelectedTargetSetUuid);
				break;
			case 74u:
				if (effectsPresetUuid_ == null)
				{
					EffectsPresetUuid = new UUID();
				}
				input.ReadMessage(EffectsPresetUuid);
				break;
			case 81u:
				EffectsBuildDuration = input.ReadDouble();
				break;
			case 90u:
				if (layerPresetUuid_ == null)
				{
					LayerPresetUuid = new UUID();
				}
				input.ReadMessage(LayerPresetUuid);
				break;
			case 98u:
				if (hotKey_ == null)
				{
					HotKey = new HotKey();
				}
				input.ReadMessage(HotKey);
				break;
			case 106u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			case 114u:
				effects_.AddEntriesFrom(input, _repeated_effects_codec);
				break;
			case 122u:
				if (blend_ == null)
				{
					Blend = new Types.Blending();
				}
				input.ReadMessage(Blend);
				break;
			}
		}
	}
}
