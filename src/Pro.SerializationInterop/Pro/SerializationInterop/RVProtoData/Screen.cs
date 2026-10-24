using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Screen : IMessage<Screen>, IMessage, IEquatable<Screen>, IDeepCloneable<Screen>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ColorAdjustment : IMessage<ColorAdjustment>, IMessage, IEquatable<ColorAdjustment>, IDeepCloneable<ColorAdjustment>
		{
			private static readonly MessageParser<ColorAdjustment> _parser = new MessageParser<ColorAdjustment>(() => new ColorAdjustment());

			private UnknownFieldSet _unknownFields;

			public const int GammaFieldNumber = 1;

			private double gamma_;

			public const int BlackLevelFieldNumber = 2;

			private double blackLevel_;

			public const int RedLevelFieldNumber = 3;

			private double redLevel_;

			public const int GreenLevelFieldNumber = 4;

			private double greenLevel_;

			public const int BlueLevelFieldNumber = 5;

			private double blueLevel_;

			public const int BrightnessFieldNumber = 6;

			private double brightness_;

			public const int ContrastFieldNumber = 7;

			private double contrast_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ColorAdjustment> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Screen.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Gamma
			{
				get
				{
					return gamma_;
				}
				set
				{
					gamma_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double BlackLevel
			{
				get
				{
					return blackLevel_;
				}
				set
				{
					blackLevel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double RedLevel
			{
				get
				{
					return redLevel_;
				}
				set
				{
					redLevel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double GreenLevel
			{
				get
				{
					return greenLevel_;
				}
				set
				{
					greenLevel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double BlueLevel
			{
				get
				{
					return blueLevel_;
				}
				set
				{
					blueLevel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Brightness
			{
				get
				{
					return brightness_;
				}
				set
				{
					brightness_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Contrast
			{
				get
				{
					return contrast_;
				}
				set
				{
					contrast_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ColorAdjustment()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ColorAdjustment(ColorAdjustment other)
				: this()
			{
				gamma_ = other.gamma_;
				blackLevel_ = other.blackLevel_;
				redLevel_ = other.redLevel_;
				greenLevel_ = other.greenLevel_;
				blueLevel_ = other.blueLevel_;
				brightness_ = other.brightness_;
				contrast_ = other.contrast_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ColorAdjustment Clone()
			{
				return new ColorAdjustment(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ColorAdjustment);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ColorAdjustment other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Gamma, other.Gamma))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlackLevel, other.BlackLevel))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(RedLevel, other.RedLevel))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(GreenLevel, other.GreenLevel))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlueLevel, other.BlueLevel))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Brightness, other.Brightness))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Contrast, other.Contrast))
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
				if (Gamma != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Gamma);
				}
				if (BlackLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlackLevel);
				}
				if (RedLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(RedLevel);
				}
				if (GreenLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(GreenLevel);
				}
				if (BlueLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlueLevel);
				}
				if (Brightness != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Brightness);
				}
				if (Contrast != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Contrast);
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
				if (Gamma != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Gamma);
				}
				if (BlackLevel != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(BlackLevel);
				}
				if (RedLevel != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(RedLevel);
				}
				if (GreenLevel != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(GreenLevel);
				}
				if (BlueLevel != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(BlueLevel);
				}
				if (Brightness != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(Brightness);
				}
				if (Contrast != 0.0)
				{
					output.WriteRawTag(57);
					output.WriteDouble(Contrast);
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
				if (Gamma != 0.0)
				{
					num += 9;
				}
				if (BlackLevel != 0.0)
				{
					num += 9;
				}
				if (RedLevel != 0.0)
				{
					num += 9;
				}
				if (GreenLevel != 0.0)
				{
					num += 9;
				}
				if (BlueLevel != 0.0)
				{
					num += 9;
				}
				if (Brightness != 0.0)
				{
					num += 9;
				}
				if (Contrast != 0.0)
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
			public void MergeFrom(ColorAdjustment other)
			{
				if (other != null)
				{
					if (other.Gamma != 0.0)
					{
						Gamma = other.Gamma;
					}
					if (other.BlackLevel != 0.0)
					{
						BlackLevel = other.BlackLevel;
					}
					if (other.RedLevel != 0.0)
					{
						RedLevel = other.RedLevel;
					}
					if (other.GreenLevel != 0.0)
					{
						GreenLevel = other.GreenLevel;
					}
					if (other.BlueLevel != 0.0)
					{
						BlueLevel = other.BlueLevel;
					}
					if (other.Brightness != 0.0)
					{
						Brightness = other.Brightness;
					}
					if (other.Contrast != 0.0)
					{
						Contrast = other.Contrast;
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
						Gamma = input.ReadDouble();
						break;
					case 17u:
						BlackLevel = input.ReadDouble();
						break;
					case 25u:
						RedLevel = input.ReadDouble();
						break;
					case 33u:
						GreenLevel = input.ReadDouble();
						break;
					case 41u:
						BlueLevel = input.ReadDouble();
						break;
					case 49u:
						Brightness = input.ReadDouble();
						break;
					case 57u:
						Contrast = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BlendCompensation : IMessage<BlendCompensation>, IMessage, IEquatable<BlendCompensation>, IDeepCloneable<BlendCompensation>
		{
			private static readonly MessageParser<BlendCompensation> _parser = new MessageParser<BlendCompensation>(() => new BlendCompensation());

			private UnknownFieldSet _unknownFields;

			public const int BlackLevelFieldNumber = 1;

			private double blackLevel_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BlendCompensation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Screen.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double BlackLevel
			{
				get
				{
					return blackLevel_;
				}
				set
				{
					blackLevel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendCompensation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendCompensation(BlendCompensation other)
				: this()
			{
				blackLevel_ = other.blackLevel_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendCompensation Clone()
			{
				return new BlendCompensation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BlendCompensation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BlendCompensation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlackLevel, other.BlackLevel))
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
				if (BlackLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlackLevel);
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
				if (BlackLevel != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(BlackLevel);
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
				if (BlackLevel != 0.0)
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
			public void MergeFrom(BlendCompensation other)
			{
				if (other != null)
				{
					if (other.BlackLevel != 0.0)
					{
						BlackLevel = other.BlackLevel;
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
						BlackLevel = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AlphaSettings : IMessage<AlphaSettings>, IMessage, IEquatable<AlphaSettings>, IDeepCloneable<AlphaSettings>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Mode
				{
					[OriginalName("MODE_UNKNOWN")]
					Unknown,
					[OriginalName("MODE_DISABLED")]
					Disabled,
					[OriginalName("MODE_PREMULTIPLIED")]
					Premultiplied,
					[OriginalName("MODE_STRAIGHT")]
					Straight
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class AlphaDevice : IMessage<AlphaDevice>, IMessage, IEquatable<AlphaDevice>, IDeepCloneable<AlphaDevice>
				{
					private static readonly MessageParser<AlphaDevice> _parser = new MessageParser<AlphaDevice>(() => new AlphaDevice());

					private UnknownFieldSet _unknownFields;

					public const int DisplayFieldNumber = 1;

					private OutputDisplay display_;

					public const int SubscreenUnitRectFieldNumber = 2;

					private Graphics.Types.Rect subscreenUnitRect_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AlphaDevice> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => AlphaSettings.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public OutputDisplay Display
					{
						get
						{
							return display_;
						}
						set
						{
							display_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Graphics.Types.Rect SubscreenUnitRect
					{
						get
						{
							return subscreenUnitRect_;
						}
						set
						{
							subscreenUnitRect_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AlphaDevice()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AlphaDevice(AlphaDevice other)
						: this()
					{
						display_ = ((other.display_ != null) ? other.display_.Clone() : null);
						subscreenUnitRect_ = ((other.subscreenUnitRect_ != null) ? other.subscreenUnitRect_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AlphaDevice Clone()
					{
						return new AlphaDevice(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AlphaDevice);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AlphaDevice other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Display, other.Display))
						{
							return false;
						}
						if (!object.Equals(SubscreenUnitRect, other.SubscreenUnitRect))
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
						if (display_ != null)
						{
							num ^= Display.GetHashCode();
						}
						if (subscreenUnitRect_ != null)
						{
							num ^= SubscreenUnitRect.GetHashCode();
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
						if (display_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Display);
						}
						if (subscreenUnitRect_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(SubscreenUnitRect);
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
						if (display_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Display);
						}
						if (subscreenUnitRect_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(SubscreenUnitRect);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(AlphaDevice other)
					{
						if (other == null)
						{
							return;
						}
						if (other.display_ != null)
						{
							if (display_ == null)
							{
								Display = new OutputDisplay();
							}
							Display.MergeFrom(other.Display);
						}
						if (other.subscreenUnitRect_ != null)
						{
							if (subscreenUnitRect_ == null)
							{
								SubscreenUnitRect = new Graphics.Types.Rect();
							}
							SubscreenUnitRect.MergeFrom(other.SubscreenUnitRect);
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
								if (display_ == null)
								{
									Display = new OutputDisplay();
								}
								input.ReadMessage(Display);
								break;
							case 18u:
								if (subscreenUnitRect_ == null)
								{
									SubscreenUnitRect = new Graphics.Types.Rect();
								}
								input.ReadMessage(SubscreenUnitRect);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<AlphaSettings> _parser = new MessageParser<AlphaSettings>(() => new AlphaSettings());

			private UnknownFieldSet _unknownFields;

			public const int ModeFieldNumber = 1;

			private Types.Mode mode_;

			public const int AlphaDeviceFieldNumber = 2;

			private Types.AlphaDevice alphaDevice_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AlphaSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Screen.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Mode Mode
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
			public Types.AlphaDevice AlphaDevice
			{
				get
				{
					return alphaDevice_;
				}
				set
				{
					alphaDevice_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AlphaSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AlphaSettings(AlphaSettings other)
				: this()
			{
				mode_ = other.mode_;
				alphaDevice_ = ((other.alphaDevice_ != null) ? other.alphaDevice_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AlphaSettings Clone()
			{
				return new AlphaSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AlphaSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AlphaSettings other)
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
				if (!object.Equals(AlphaDevice, other.AlphaDevice))
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
				if (alphaDevice_ != null)
				{
					num ^= AlphaDevice.GetHashCode();
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
				if (alphaDevice_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(AlphaDevice);
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
				if (alphaDevice_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AlphaDevice);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AlphaSettings other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Mode != 0)
				{
					Mode = other.Mode;
				}
				if (other.alphaDevice_ != null)
				{
					if (alphaDevice_ == null)
					{
						AlphaDevice = new Types.AlphaDevice();
					}
					AlphaDevice.MergeFrom(other.AlphaDevice);
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
						Mode = (Types.Mode)input.ReadEnum();
						break;
					case 18u:
						if (alphaDevice_ == null)
						{
							AlphaDevice = new Types.AlphaDevice();
						}
						input.ReadMessage(AlphaDevice);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Screen> _parser = new MessageParser<Screen>(() => new Screen());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int ColorFieldNumber = 3;

	private Color color_;

	public const int BoundsFieldNumber = 4;

	private Graphics.Types.Rect bounds_;

	public const int AspectRatioLockedFieldNumber = 5;

	private bool aspectRatioLocked_;

	public const int OutputBoundsAspectRatioLockedFieldNumber = 6;

	private bool outputBoundsAspectRatioLocked_;

	public const int CornerPinningEnabledFieldNumber = 7;

	private bool cornerPinningEnabled_;

	public const int SubscreenUnitRectFieldNumber = 8;

	private Graphics.Types.Rect subscreenUnitRect_;

	public const int RotationFieldNumber = 9;

	private double rotation_;

	public const int GammaFieldNumber = 10;

	private double gamma_;

	public const int BlackLevelFieldNumber = 11;

	private double blackLevel_;

	public const int BlendedEdgesFieldNumber = 12;

	private uint blendedEdges_;

	public const int CornerValuesFieldNumber = 13;

	private CornerValues cornerValues_;

	public const int OutputDisplayFieldNumber = 14;

	private OutputDisplay outputDisplay_;

	public const int ColorEnabledFieldNumber = 15;

	private bool colorEnabled_;

	public const int ColorAdjustmentFieldNumber = 16;

	private Types.ColorAdjustment colorAdjustment_;

	public const int BlendCompensationFieldNumber = 17;

	private Types.BlendCompensation blendCompensation_;

	public const int AlphaSettingsFieldNumber = 18;

	private Types.AlphaSettings alphaSettings_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Screen> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ScreensReflection.Descriptor.MessageTypes[0];

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
	public Graphics.Types.Rect Bounds
	{
		get
		{
			return bounds_;
		}
		set
		{
			bounds_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool AspectRatioLocked
	{
		get
		{
			return aspectRatioLocked_;
		}
		set
		{
			aspectRatioLocked_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool OutputBoundsAspectRatioLocked
	{
		get
		{
			return outputBoundsAspectRatioLocked_;
		}
		set
		{
			outputBoundsAspectRatioLocked_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool CornerPinningEnabled
	{
		get
		{
			return cornerPinningEnabled_;
		}
		set
		{
			cornerPinningEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Rect SubscreenUnitRect
	{
		get
		{
			return subscreenUnitRect_;
		}
		set
		{
			subscreenUnitRect_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Rotation
	{
		get
		{
			return rotation_;
		}
		set
		{
			rotation_ = value;
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Gamma
	{
		get
		{
			return gamma_;
		}
		set
		{
			gamma_ = value;
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double BlackLevel
	{
		get
		{
			return blackLevel_;
		}
		set
		{
			blackLevel_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint BlendedEdges
	{
		get
		{
			return blendedEdges_;
		}
		set
		{
			blendedEdges_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CornerValues CornerValues
	{
		get
		{
			return cornerValues_;
		}
		set
		{
			cornerValues_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OutputDisplay OutputDisplay
	{
		get
		{
			return outputDisplay_;
		}
		set
		{
			outputDisplay_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ColorEnabled
	{
		get
		{
			return colorEnabled_;
		}
		set
		{
			colorEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ColorAdjustment ColorAdjustment
	{
		get
		{
			return colorAdjustment_;
		}
		set
		{
			colorAdjustment_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BlendCompensation BlendCompensation
	{
		get
		{
			return blendCompensation_;
		}
		set
		{
			blendCompensation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AlphaSettings AlphaSettings
	{
		get
		{
			return alphaSettings_;
		}
		set
		{
			alphaSettings_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Screen()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Screen(Screen other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		color_ = ((other.color_ != null) ? other.color_.Clone() : null);
		bounds_ = ((other.bounds_ != null) ? other.bounds_.Clone() : null);
		aspectRatioLocked_ = other.aspectRatioLocked_;
		outputBoundsAspectRatioLocked_ = other.outputBoundsAspectRatioLocked_;
		cornerPinningEnabled_ = other.cornerPinningEnabled_;
		subscreenUnitRect_ = ((other.subscreenUnitRect_ != null) ? other.subscreenUnitRect_.Clone() : null);
		rotation_ = other.rotation_;
		gamma_ = other.gamma_;
		blackLevel_ = other.blackLevel_;
		blendedEdges_ = other.blendedEdges_;
		cornerValues_ = ((other.cornerValues_ != null) ? other.cornerValues_.Clone() : null);
		outputDisplay_ = ((other.outputDisplay_ != null) ? other.outputDisplay_.Clone() : null);
		colorEnabled_ = other.colorEnabled_;
		colorAdjustment_ = ((other.colorAdjustment_ != null) ? other.colorAdjustment_.Clone() : null);
		blendCompensation_ = ((other.blendCompensation_ != null) ? other.blendCompensation_.Clone() : null);
		alphaSettings_ = ((other.alphaSettings_ != null) ? other.alphaSettings_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Screen Clone()
	{
		return new Screen(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Screen);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Screen other)
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
		if (!object.Equals(Bounds, other.Bounds))
		{
			return false;
		}
		if (AspectRatioLocked != other.AspectRatioLocked)
		{
			return false;
		}
		if (OutputBoundsAspectRatioLocked != other.OutputBoundsAspectRatioLocked)
		{
			return false;
		}
		if (CornerPinningEnabled != other.CornerPinningEnabled)
		{
			return false;
		}
		if (!object.Equals(SubscreenUnitRect, other.SubscreenUnitRect))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Rotation, other.Rotation))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Gamma, other.Gamma))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlackLevel, other.BlackLevel))
		{
			return false;
		}
		if (BlendedEdges != other.BlendedEdges)
		{
			return false;
		}
		if (!object.Equals(CornerValues, other.CornerValues))
		{
			return false;
		}
		if (!object.Equals(OutputDisplay, other.OutputDisplay))
		{
			return false;
		}
		if (ColorEnabled != other.ColorEnabled)
		{
			return false;
		}
		if (!object.Equals(ColorAdjustment, other.ColorAdjustment))
		{
			return false;
		}
		if (!object.Equals(BlendCompensation, other.BlendCompensation))
		{
			return false;
		}
		if (!object.Equals(AlphaSettings, other.AlphaSettings))
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
		if (bounds_ != null)
		{
			num ^= Bounds.GetHashCode();
		}
		if (AspectRatioLocked)
		{
			num ^= AspectRatioLocked.GetHashCode();
		}
		if (OutputBoundsAspectRatioLocked)
		{
			num ^= OutputBoundsAspectRatioLocked.GetHashCode();
		}
		if (CornerPinningEnabled)
		{
			num ^= CornerPinningEnabled.GetHashCode();
		}
		if (subscreenUnitRect_ != null)
		{
			num ^= SubscreenUnitRect.GetHashCode();
		}
		if (Rotation != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Rotation);
		}
		if (Gamma != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Gamma);
		}
		if (BlackLevel != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlackLevel);
		}
		if (BlendedEdges != 0)
		{
			num ^= BlendedEdges.GetHashCode();
		}
		if (cornerValues_ != null)
		{
			num ^= CornerValues.GetHashCode();
		}
		if (outputDisplay_ != null)
		{
			num ^= OutputDisplay.GetHashCode();
		}
		if (ColorEnabled)
		{
			num ^= ColorEnabled.GetHashCode();
		}
		if (colorAdjustment_ != null)
		{
			num ^= ColorAdjustment.GetHashCode();
		}
		if (blendCompensation_ != null)
		{
			num ^= BlendCompensation.GetHashCode();
		}
		if (alphaSettings_ != null)
		{
			num ^= AlphaSettings.GetHashCode();
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
		if (bounds_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Bounds);
		}
		if (AspectRatioLocked)
		{
			output.WriteRawTag(40);
			output.WriteBool(AspectRatioLocked);
		}
		if (OutputBoundsAspectRatioLocked)
		{
			output.WriteRawTag(48);
			output.WriteBool(OutputBoundsAspectRatioLocked);
		}
		if (CornerPinningEnabled)
		{
			output.WriteRawTag(56);
			output.WriteBool(CornerPinningEnabled);
		}
		if (subscreenUnitRect_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(SubscreenUnitRect);
		}
		if (Rotation != 0.0)
		{
			output.WriteRawTag(73);
			output.WriteDouble(Rotation);
		}
		if (Gamma != 0.0)
		{
			output.WriteRawTag(81);
			output.WriteDouble(Gamma);
		}
		if (BlackLevel != 0.0)
		{
			output.WriteRawTag(89);
			output.WriteDouble(BlackLevel);
		}
		if (BlendedEdges != 0)
		{
			output.WriteRawTag(96);
			output.WriteUInt32(BlendedEdges);
		}
		if (cornerValues_ != null)
		{
			output.WriteRawTag(106);
			output.WriteMessage(CornerValues);
		}
		if (outputDisplay_ != null)
		{
			output.WriteRawTag(114);
			output.WriteMessage(OutputDisplay);
		}
		if (ColorEnabled)
		{
			output.WriteRawTag(120);
			output.WriteBool(ColorEnabled);
		}
		if (colorAdjustment_ != null)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(ColorAdjustment);
		}
		if (blendCompensation_ != null)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(BlendCompensation);
		}
		if (alphaSettings_ != null)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(AlphaSettings);
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
		if (bounds_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Bounds);
		}
		if (AspectRatioLocked)
		{
			num += 2;
		}
		if (OutputBoundsAspectRatioLocked)
		{
			num += 2;
		}
		if (CornerPinningEnabled)
		{
			num += 2;
		}
		if (subscreenUnitRect_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SubscreenUnitRect);
		}
		if (Rotation != 0.0)
		{
			num += 9;
		}
		if (Gamma != 0.0)
		{
			num += 9;
		}
		if (BlackLevel != 0.0)
		{
			num += 9;
		}
		if (BlendedEdges != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(BlendedEdges);
		}
		if (cornerValues_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CornerValues);
		}
		if (outputDisplay_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(OutputDisplay);
		}
		if (ColorEnabled)
		{
			num += 2;
		}
		if (colorAdjustment_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ColorAdjustment);
		}
		if (blendCompensation_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BlendCompensation);
		}
		if (alphaSettings_ != null)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AlphaSettings);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Screen other)
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
		if (other.bounds_ != null)
		{
			if (bounds_ == null)
			{
				Bounds = new Graphics.Types.Rect();
			}
			Bounds.MergeFrom(other.Bounds);
		}
		if (other.AspectRatioLocked)
		{
			AspectRatioLocked = other.AspectRatioLocked;
		}
		if (other.OutputBoundsAspectRatioLocked)
		{
			OutputBoundsAspectRatioLocked = other.OutputBoundsAspectRatioLocked;
		}
		if (other.CornerPinningEnabled)
		{
			CornerPinningEnabled = other.CornerPinningEnabled;
		}
		if (other.subscreenUnitRect_ != null)
		{
			if (subscreenUnitRect_ == null)
			{
				SubscreenUnitRect = new Graphics.Types.Rect();
			}
			SubscreenUnitRect.MergeFrom(other.SubscreenUnitRect);
		}
		if (other.Rotation != 0.0)
		{
			Rotation = other.Rotation;
		}
		if (other.Gamma != 0.0)
		{
			Gamma = other.Gamma;
		}
		if (other.BlackLevel != 0.0)
		{
			BlackLevel = other.BlackLevel;
		}
		if (other.BlendedEdges != 0)
		{
			BlendedEdges = other.BlendedEdges;
		}
		if (other.cornerValues_ != null)
		{
			if (cornerValues_ == null)
			{
				CornerValues = new CornerValues();
			}
			CornerValues.MergeFrom(other.CornerValues);
		}
		if (other.outputDisplay_ != null)
		{
			if (outputDisplay_ == null)
			{
				OutputDisplay = new OutputDisplay();
			}
			OutputDisplay.MergeFrom(other.OutputDisplay);
		}
		if (other.ColorEnabled)
		{
			ColorEnabled = other.ColorEnabled;
		}
		if (other.colorAdjustment_ != null)
		{
			if (colorAdjustment_ == null)
			{
				ColorAdjustment = new Types.ColorAdjustment();
			}
			ColorAdjustment.MergeFrom(other.ColorAdjustment);
		}
		if (other.blendCompensation_ != null)
		{
			if (blendCompensation_ == null)
			{
				BlendCompensation = new Types.BlendCompensation();
			}
			BlendCompensation.MergeFrom(other.BlendCompensation);
		}
		if (other.alphaSettings_ != null)
		{
			if (alphaSettings_ == null)
			{
				AlphaSettings = new Types.AlphaSettings();
			}
			AlphaSettings.MergeFrom(other.AlphaSettings);
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
			case 34u:
				if (bounds_ == null)
				{
					Bounds = new Graphics.Types.Rect();
				}
				input.ReadMessage(Bounds);
				break;
			case 40u:
				AspectRatioLocked = input.ReadBool();
				break;
			case 48u:
				OutputBoundsAspectRatioLocked = input.ReadBool();
				break;
			case 56u:
				CornerPinningEnabled = input.ReadBool();
				break;
			case 66u:
				if (subscreenUnitRect_ == null)
				{
					SubscreenUnitRect = new Graphics.Types.Rect();
				}
				input.ReadMessage(SubscreenUnitRect);
				break;
			case 73u:
				Rotation = input.ReadDouble();
				break;
			case 81u:
				Gamma = input.ReadDouble();
				break;
			case 89u:
				BlackLevel = input.ReadDouble();
				break;
			case 96u:
				BlendedEdges = input.ReadUInt32();
				break;
			case 106u:
				if (cornerValues_ == null)
				{
					CornerValues = new CornerValues();
				}
				input.ReadMessage(CornerValues);
				break;
			case 114u:
				if (outputDisplay_ == null)
				{
					OutputDisplay = new OutputDisplay();
				}
				input.ReadMessage(OutputDisplay);
				break;
			case 120u:
				ColorEnabled = input.ReadBool();
				break;
			case 130u:
				if (colorAdjustment_ == null)
				{
					ColorAdjustment = new Types.ColorAdjustment();
				}
				input.ReadMessage(ColorAdjustment);
				break;
			case 138u:
				if (blendCompensation_ == null)
				{
					BlendCompensation = new Types.BlendCompensation();
				}
				input.ReadMessage(BlendCompensation);
				break;
			case 146u:
				if (alphaSettings_ == null)
				{
					AlphaSettings = new Types.AlphaSettings();
				}
				input.ReadMessage(AlphaSettings);
				break;
			}
		}
	}
}
