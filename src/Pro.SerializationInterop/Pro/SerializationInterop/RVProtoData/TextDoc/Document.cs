using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.TextDoc;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Document : IMessage<Document>, IMessage, IEquatable<Document>, IDeepCloneable<Document>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ParagraphAlignment
		{
			[OriginalName("ParagraphAlignment_Left")]
			Left,
			[OriginalName("ParagraphAlignment_Center")]
			Center,
			[OriginalName("ParagraphAlignment_Right")]
			Right,
			[OriginalName("ParagraphAlignment_Justified")]
			Justified
		}

		public enum LineSpacingMode
		{
			[OriginalName("LineSpacingMode_Absolute")]
			Absolute,
			[OriginalName("LineSpacingMode_Relative")]
			Relative,
			[OriginalName("LineSpacingMode_Multiple")]
			Multiple
		}

		public enum RightIndentMode
		{
			[OriginalName("RightIndentMode_FromRight")]
			FromRight,
			[OriginalName("RightIndentMode_FromLeft")]
			FromLeft
		}

		public enum TabStopType
		{
			[OriginalName("TabStopType_Left")]
			Left,
			[OriginalName("TabStopType_Right")]
			Right,
			[OriginalName("TabStopType_Center")]
			Center,
			[OriginalName("TabStopType_Decimal")]
			Decimal
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Color : IMessage<Color>, IMessage, IEquatable<Color>, IDeepCloneable<Color>
		{
			private static readonly MessageParser<Color> _parser = new MessageParser<Color>(() => new Color());

			private UnknownFieldSet _unknownFields;

			public const int RedFieldNumber = 1;

			private double red_;

			public const int GreenFieldNumber = 2;

			private double green_;

			public const int BlueFieldNumber = 3;

			private double blue_;

			public const int AlphaFieldNumber = 4;

			private double alpha_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Color> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Red
			{
				get
				{
					return red_;
				}
				set
				{
					red_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Green
			{
				get
				{
					return green_;
				}
				set
				{
					green_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Blue
			{
				get
				{
					return blue_;
				}
				set
				{
					blue_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Alpha
			{
				get
				{
					return alpha_;
				}
				set
				{
					alpha_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color(Color other)
				: this()
			{
				red_ = other.red_;
				green_ = other.green_;
				blue_ = other.blue_;
				alpha_ = other.alpha_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color Clone()
			{
				return new Color(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Color);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Color other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Red, other.Red))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Green, other.Green))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Blue, other.Blue))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Alpha, other.Alpha))
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
				if (Red != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Red);
				}
				if (Green != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Green);
				}
				if (Blue != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Blue);
				}
				if (Alpha != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Alpha);
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
				if (Red != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Red);
				}
				if (Green != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Green);
				}
				if (Blue != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(Blue);
				}
				if (Alpha != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(Alpha);
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
				if (Red != 0.0)
				{
					num += 9;
				}
				if (Green != 0.0)
				{
					num += 9;
				}
				if (Blue != 0.0)
				{
					num += 9;
				}
				if (Alpha != 0.0)
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
			public void MergeFrom(Color other)
			{
				if (other != null)
				{
					if (other.Red != 0.0)
					{
						Red = other.Red;
					}
					if (other.Green != 0.0)
					{
						Green = other.Green;
					}
					if (other.Blue != 0.0)
					{
						Blue = other.Blue;
					}
					if (other.Alpha != 0.0)
					{
						Alpha = other.Alpha;
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
						Red = input.ReadDouble();
						break;
					case 17u:
						Green = input.ReadDouble();
						break;
					case 25u:
						Blue = input.ReadDouble();
						break;
					case 33u:
						Alpha = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DocumentSettings : IMessage<DocumentSettings>, IMessage, IEquatable<DocumentSettings>, IDeepCloneable<DocumentSettings>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum DocumentAlignment
				{
					[OriginalName("DocumentAlignment_Top")]
					Top,
					[OriginalName("DocumentAlignment_Middle")]
					Middle,
					[OriginalName("DocumentAlignment_Bottom")]
					Bottom
				}

				public enum TextTransform
				{
					[OriginalName("TextTransform_None")]
					None,
					[OriginalName("TextTransform_RemoveLineReturns")]
					RemoveLineReturns,
					[OriginalName("TextTransform_ReplaceLineReturns")]
					ReplaceLineReturns,
					[OriginalName("TextTransform_SingleWordPerLine")]
					SingleWordPerLine,
					[OriginalName("TextTransform_SingleCharacterPerLine")]
					SingleCharacterPerLine
				}

				public enum ScaleMode
				{
					[OriginalName("ScaleMode_None")]
					None,
					[OriginalName("ScaleMode_AdjustContainerHeight")]
					AdjustContainerHeight,
					[OriginalName("ScaleMode_Up")]
					Up,
					[OriginalName("ScaleMode_Down")]
					Down,
					[OriginalName("ScaleMode_UpOrDown")]
					UpOrDown
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Margins : IMessage<Margins>, IMessage, IEquatable<Margins>, IDeepCloneable<Margins>
				{
					private static readonly MessageParser<Margins> _parser = new MessageParser<Margins>(() => new Margins());

					private UnknownFieldSet _unknownFields;

					public const int LeftFieldNumber = 1;

					private double left_;

					public const int TopFieldNumber = 2;

					private double top_;

					public const int RightFieldNumber = 3;

					private double right_;

					public const int BottomFieldNumber = 4;

					private double bottom_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Margins> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => DocumentSettings.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Left
					{
						get
						{
							return left_;
						}
						set
						{
							left_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Top
					{
						get
						{
							return top_;
						}
						set
						{
							top_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Right
					{
						get
						{
							return right_;
						}
						set
						{
							right_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Bottom
					{
						get
						{
							return bottom_;
						}
						set
						{
							bottom_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Margins()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Margins(Margins other)
						: this()
					{
						left_ = other.left_;
						top_ = other.top_;
						right_ = other.right_;
						bottom_ = other.bottom_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Margins Clone()
					{
						return new Margins(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Margins);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Margins other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Left, other.Left))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Top, other.Top))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Right, other.Right))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Bottom, other.Bottom))
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
						if (Left != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Left);
						}
						if (Top != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Top);
						}
						if (Right != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Right);
						}
						if (Bottom != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Bottom);
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
						if (Left != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Left);
						}
						if (Top != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(Top);
						}
						if (Right != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(Right);
						}
						if (Bottom != 0.0)
						{
							output.WriteRawTag(33);
							output.WriteDouble(Bottom);
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
						if (Left != 0.0)
						{
							num += 9;
						}
						if (Top != 0.0)
						{
							num += 9;
						}
						if (Right != 0.0)
						{
							num += 9;
						}
						if (Bottom != 0.0)
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
					public void MergeFrom(Margins other)
					{
						if (other != null)
						{
							if (other.Left != 0.0)
							{
								Left = other.Left;
							}
							if (other.Top != 0.0)
							{
								Top = other.Top;
							}
							if (other.Right != 0.0)
							{
								Right = other.Right;
							}
							if (other.Bottom != 0.0)
							{
								Bottom = other.Bottom;
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
								Left = input.ReadDouble();
								break;
							case 17u:
								Top = input.ReadDouble();
								break;
							case 25u:
								Right = input.ReadDouble();
								break;
							case 33u:
								Bottom = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Shadow : IMessage<Shadow>, IMessage, IEquatable<Shadow>, IDeepCloneable<Shadow>
				{
					private static readonly MessageParser<Shadow> _parser = new MessageParser<Shadow>(() => new Shadow());

					private UnknownFieldSet _unknownFields;

					public const int EnabledFieldNumber = 1;

					private bool enabled_;

					public const int BlurRadiusFieldNumber = 2;

					private double blurRadius_;

					public const int OpacityFieldNumber = 3;

					private double opacity_;

					public const int ColorFieldNumber = 4;

					private Color color_;

					public const int AngleFieldNumber = 5;

					private double angle_;

					public const int OffsetFieldNumber = 6;

					private double offset_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Shadow> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => DocumentSettings.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
					public double BlurRadius
					{
						get
						{
							return blurRadius_;
						}
						set
						{
							blurRadius_ = value;
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
					public double Angle
					{
						get
						{
							return angle_;
						}
						set
						{
							angle_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Offset
					{
						get
						{
							return offset_;
						}
						set
						{
							offset_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Shadow()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Shadow(Shadow other)
						: this()
					{
						enabled_ = other.enabled_;
						blurRadius_ = other.blurRadius_;
						opacity_ = other.opacity_;
						color_ = ((other.color_ != null) ? other.color_.Clone() : null);
						angle_ = other.angle_;
						offset_ = other.offset_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Shadow Clone()
					{
						return new Shadow(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Shadow);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Shadow other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Enabled != other.Enabled)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlurRadius, other.BlurRadius))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Opacity, other.Opacity))
						{
							return false;
						}
						if (!object.Equals(Color, other.Color))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Angle, other.Angle))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Offset, other.Offset))
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
						if (Enabled)
						{
							num ^= Enabled.GetHashCode();
						}
						if (BlurRadius != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlurRadius);
						}
						if (Opacity != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Opacity);
						}
						if (color_ != null)
						{
							num ^= Color.GetHashCode();
						}
						if (Angle != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Angle);
						}
						if (Offset != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Offset);
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
						if (Enabled)
						{
							output.WriteRawTag(8);
							output.WriteBool(Enabled);
						}
						if (BlurRadius != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(BlurRadius);
						}
						if (Opacity != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(Opacity);
						}
						if (color_ != null)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Color);
						}
						if (Angle != 0.0)
						{
							output.WriteRawTag(41);
							output.WriteDouble(Angle);
						}
						if (Offset != 0.0)
						{
							output.WriteRawTag(49);
							output.WriteDouble(Offset);
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
						if (Enabled)
						{
							num += 2;
						}
						if (BlurRadius != 0.0)
						{
							num += 9;
						}
						if (Opacity != 0.0)
						{
							num += 9;
						}
						if (color_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Color);
						}
						if (Angle != 0.0)
						{
							num += 9;
						}
						if (Offset != 0.0)
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
					public void MergeFrom(Shadow other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Enabled)
						{
							Enabled = other.Enabled;
						}
						if (other.BlurRadius != 0.0)
						{
							BlurRadius = other.BlurRadius;
						}
						if (other.Opacity != 0.0)
						{
							Opacity = other.Opacity;
						}
						if (other.color_ != null)
						{
							if (color_ == null)
							{
								Color = new Color();
							}
							Color.MergeFrom(other.Color);
						}
						if (other.Angle != 0.0)
						{
							Angle = other.Angle;
						}
						if (other.Offset != 0.0)
						{
							Offset = other.Offset;
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
								Enabled = input.ReadBool();
								break;
							case 17u:
								BlurRadius = input.ReadDouble();
								break;
							case 25u:
								Opacity = input.ReadDouble();
								break;
							case 34u:
								if (color_ == null)
								{
									Color = new Color();
								}
								input.ReadMessage(Color);
								break;
							case 41u:
								Angle = input.ReadDouble();
								break;
							case 49u:
								Offset = input.ReadDouble();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<DocumentSettings> _parser = new MessageParser<DocumentSettings>(() => new DocumentSettings());

			private UnknownFieldSet _unknownFields;

			public const int AlignmentFieldNumber = 1;

			private Types.DocumentAlignment alignment_;

			public const int TransformFieldNumber = 2;

			private Types.TextTransform transform_;

			public const int DelimiterFieldNumber = 3;

			private string delimiter_ = "";

			public const int ScaleModeFieldNumber = 4;

			private Types.ScaleMode scaleMode_;

			public const int LayoutWidthFieldNumber = 5;

			private double layoutWidth_;

			public const int MarginsFieldNumber = 6;

			private Types.Margins margins_;

			public const int ShadowFieldNumber = 7;

			private Types.Shadow shadow_;

			public const int HasExplicitMarginsFieldNumber = 8;

			private bool hasExplicitMargins_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DocumentSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.DocumentAlignment Alignment
			{
				get
				{
					return alignment_;
				}
				set
				{
					alignment_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TextTransform Transform
			{
				get
				{
					return transform_;
				}
				set
				{
					transform_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Delimiter
			{
				get
				{
					return delimiter_;
				}
				set
				{
					delimiter_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ScaleMode ScaleMode
			{
				get
				{
					return scaleMode_;
				}
				set
				{
					scaleMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double LayoutWidth
			{
				get
				{
					return layoutWidth_;
				}
				set
				{
					layoutWidth_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Margins Margins
			{
				get
				{
					return margins_;
				}
				set
				{
					margins_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Shadow Shadow
			{
				get
				{
					return shadow_;
				}
				set
				{
					shadow_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasExplicitMargins
			{
				get
				{
					return hasExplicitMargins_;
				}
				set
				{
					hasExplicitMargins_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentSettings(DocumentSettings other)
				: this()
			{
				alignment_ = other.alignment_;
				transform_ = other.transform_;
				delimiter_ = other.delimiter_;
				scaleMode_ = other.scaleMode_;
				layoutWidth_ = other.layoutWidth_;
				margins_ = ((other.margins_ != null) ? other.margins_.Clone() : null);
				shadow_ = ((other.shadow_ != null) ? other.shadow_.Clone() : null);
				hasExplicitMargins_ = other.hasExplicitMargins_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentSettings Clone()
			{
				return new DocumentSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DocumentSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DocumentSettings other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Alignment != other.Alignment)
				{
					return false;
				}
				if (Transform != other.Transform)
				{
					return false;
				}
				if (Delimiter != other.Delimiter)
				{
					return false;
				}
				if (ScaleMode != other.ScaleMode)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LayoutWidth, other.LayoutWidth))
				{
					return false;
				}
				if (!object.Equals(Margins, other.Margins))
				{
					return false;
				}
				if (!object.Equals(Shadow, other.Shadow))
				{
					return false;
				}
				if (HasExplicitMargins != other.HasExplicitMargins)
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
				if (Alignment != 0)
				{
					num ^= Alignment.GetHashCode();
				}
				if (Transform != 0)
				{
					num ^= Transform.GetHashCode();
				}
				if (Delimiter.Length != 0)
				{
					num ^= Delimiter.GetHashCode();
				}
				if (ScaleMode != 0)
				{
					num ^= ScaleMode.GetHashCode();
				}
				if (LayoutWidth != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LayoutWidth);
				}
				if (margins_ != null)
				{
					num ^= Margins.GetHashCode();
				}
				if (shadow_ != null)
				{
					num ^= Shadow.GetHashCode();
				}
				if (HasExplicitMargins)
				{
					num ^= HasExplicitMargins.GetHashCode();
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
				if (Alignment != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Alignment);
				}
				if (Transform != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Transform);
				}
				if (Delimiter.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Delimiter);
				}
				if (ScaleMode != 0)
				{
					output.WriteRawTag(32);
					output.WriteEnum((int)ScaleMode);
				}
				if (LayoutWidth != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(LayoutWidth);
				}
				if (margins_ != null)
				{
					output.WriteRawTag(50);
					output.WriteMessage(Margins);
				}
				if (shadow_ != null)
				{
					output.WriteRawTag(58);
					output.WriteMessage(Shadow);
				}
				if (HasExplicitMargins)
				{
					output.WriteRawTag(64);
					output.WriteBool(HasExplicitMargins);
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
				if (Alignment != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Alignment);
				}
				if (Transform != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Transform);
				}
				if (Delimiter.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Delimiter);
				}
				if (ScaleMode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ScaleMode);
				}
				if (LayoutWidth != 0.0)
				{
					num += 9;
				}
				if (margins_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Margins);
				}
				if (shadow_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Shadow);
				}
				if (HasExplicitMargins)
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
			public void MergeFrom(DocumentSettings other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Alignment != 0)
				{
					Alignment = other.Alignment;
				}
				if (other.Transform != 0)
				{
					Transform = other.Transform;
				}
				if (other.Delimiter.Length != 0)
				{
					Delimiter = other.Delimiter;
				}
				if (other.ScaleMode != 0)
				{
					ScaleMode = other.ScaleMode;
				}
				if (other.LayoutWidth != 0.0)
				{
					LayoutWidth = other.LayoutWidth;
				}
				if (other.margins_ != null)
				{
					if (margins_ == null)
					{
						Margins = new Types.Margins();
					}
					Margins.MergeFrom(other.Margins);
				}
				if (other.shadow_ != null)
				{
					if (shadow_ == null)
					{
						Shadow = new Types.Shadow();
					}
					Shadow.MergeFrom(other.Shadow);
				}
				if (other.HasExplicitMargins)
				{
					HasExplicitMargins = other.HasExplicitMargins;
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
						Alignment = (Types.DocumentAlignment)input.ReadEnum();
						break;
					case 16u:
						Transform = (Types.TextTransform)input.ReadEnum();
						break;
					case 26u:
						Delimiter = input.ReadString();
						break;
					case 32u:
						ScaleMode = (Types.ScaleMode)input.ReadEnum();
						break;
					case 41u:
						LayoutWidth = input.ReadDouble();
						break;
					case 50u:
						if (margins_ == null)
						{
							Margins = new Types.Margins();
						}
						input.ReadMessage(Margins);
						break;
					case 58u:
						if (shadow_ == null)
						{
							Shadow = new Types.Shadow();
						}
						input.ReadMessage(Shadow);
						break;
					case 64u:
						HasExplicitMargins = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class LevelSettings : IMessage<LevelSettings>, IMessage, IEquatable<LevelSettings>, IDeepCloneable<LevelSettings>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum FollowType
				{
					[OriginalName("FollowType_Nothing")]
					Nothing,
					[OriginalName("FollowType_Space")]
					Space,
					[OriginalName("FollowType_Tab")]
					Tab
				}

				public enum NumberingScheme
				{
					[OriginalName("NumberingScheme_Arabic")]
					Arabic,
					[OriginalName("NumberingScheme_ArabicWithLeadingZero")]
					ArabicWithLeadingZero,
					[OriginalName("NumberingScheme_OrdinalNumber")]
					OrdinalNumber,
					[OriginalName("NumberingScheme_UppercaseRomanNumeral")]
					UppercaseRomanNumeral,
					[OriginalName("NumberingScheme_LowercaseRomanNumeral")]
					LowercaseRomanNumeral,
					[OriginalName("NumberingScheme_UppercaseLetter")]
					UppercaseLetter,
					[OriginalName("NumberingScheme_LowercaseLetter")]
					LowercaseLetter,
					[OriginalName("NumberingScheme_LowercaseRussianAlphabet")]
					LowercaseRussianAlphabet,
					[OriginalName("NumberingScheme_UppercaseRussianAlphabet")]
					UppercaseRussianAlphabet,
					[OriginalName("NumberingScheme_LowercaseGreekNumerals")]
					LowercaseGreekNumerals,
					[OriginalName("NumberingScheme_UppercaseGreekNumerals")]
					UppercaseGreekNumerals
				}

				public enum BulletType
				{
					[OriginalName("BulletType_Dash")]
					Dash,
					[OriginalName("BulletType_HyphenDash")]
					HyphenDash,
					[OriginalName("BulletType_SmallCircle")]
					SmallCircle,
					[OriginalName("BulletType_Circle")]
					Circle,
					[OriginalName("BulletType_SmallOpenCircle")]
					SmallOpenCircle,
					[OriginalName("BulletType_OpenCircle")]
					OpenCircle,
					[OriginalName("BulletType_SmallSquare")]
					SmallSquare,
					[OriginalName("BulletType_Square")]
					Square,
					[OriginalName("BulletType_SmallOpenSquare")]
					SmallOpenSquare,
					[OriginalName("BulletType_OpenSquare")]
					OpenSquare,
					[OriginalName("BulletType_Checkmark")]
					Checkmark,
					[OriginalName("BulletType_HeavyCheckmark")]
					HeavyCheckmark,
					[OriginalName("BulletType_Diamond")]
					Diamond,
					[OriginalName("BulletType_OpenDiamond")]
					OpenDiamond
				}
			}

			private static readonly MessageParser<LevelSettings> _parser = new MessageParser<LevelSettings>(() => new LevelSettings());

			private UnknownFieldSet _unknownFields;

			public const int FollowTypeFieldNumber = 1;

			private Types.FollowType followType_;

			public const int NumberingSchemeFieldNumber = 2;

			private Types.NumberingScheme numberingScheme_;

			public const int BulletTypeFieldNumber = 3;

			private Types.BulletType bulletType_;

			public const int IsBulletFieldNumber = 4;

			private bool isBullet_;

			public const int PrefixFieldNumber = 5;

			private string prefix_ = "";

			public const int SuffixFieldNumber = 6;

			private string suffix_ = "";

			public const int NumberingFormatFieldNumber = 7;

			private string numberingFormat_ = "";

			public const int StartNumberFieldNumber = 8;

			private int startNumber_;

			public const int LevelIndexFieldNumber = 9;

			private int levelIndex_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<LevelSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.FollowType FollowType
			{
				get
				{
					return followType_;
				}
				set
				{
					followType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.NumberingScheme NumberingScheme
			{
				get
				{
					return numberingScheme_;
				}
				set
				{
					numberingScheme_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.BulletType BulletType
			{
				get
				{
					return bulletType_;
				}
				set
				{
					bulletType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsBullet
			{
				get
				{
					return isBullet_;
				}
				set
				{
					isBullet_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Prefix
			{
				get
				{
					return prefix_;
				}
				set
				{
					prefix_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Suffix
			{
				get
				{
					return suffix_;
				}
				set
				{
					suffix_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string NumberingFormat
			{
				get
				{
					return numberingFormat_;
				}
				set
				{
					numberingFormat_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int StartNumber
			{
				get
				{
					return startNumber_;
				}
				set
				{
					startNumber_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int LevelIndex
			{
				get
				{
					return levelIndex_;
				}
				set
				{
					levelIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LevelSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LevelSettings(LevelSettings other)
				: this()
			{
				followType_ = other.followType_;
				numberingScheme_ = other.numberingScheme_;
				bulletType_ = other.bulletType_;
				isBullet_ = other.isBullet_;
				prefix_ = other.prefix_;
				suffix_ = other.suffix_;
				numberingFormat_ = other.numberingFormat_;
				startNumber_ = other.startNumber_;
				levelIndex_ = other.levelIndex_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LevelSettings Clone()
			{
				return new LevelSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as LevelSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(LevelSettings other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (FollowType != other.FollowType)
				{
					return false;
				}
				if (NumberingScheme != other.NumberingScheme)
				{
					return false;
				}
				if (BulletType != other.BulletType)
				{
					return false;
				}
				if (IsBullet != other.IsBullet)
				{
					return false;
				}
				if (Prefix != other.Prefix)
				{
					return false;
				}
				if (Suffix != other.Suffix)
				{
					return false;
				}
				if (NumberingFormat != other.NumberingFormat)
				{
					return false;
				}
				if (StartNumber != other.StartNumber)
				{
					return false;
				}
				if (LevelIndex != other.LevelIndex)
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
				if (FollowType != 0)
				{
					num ^= FollowType.GetHashCode();
				}
				if (NumberingScheme != 0)
				{
					num ^= NumberingScheme.GetHashCode();
				}
				if (BulletType != 0)
				{
					num ^= BulletType.GetHashCode();
				}
				if (IsBullet)
				{
					num ^= IsBullet.GetHashCode();
				}
				if (Prefix.Length != 0)
				{
					num ^= Prefix.GetHashCode();
				}
				if (Suffix.Length != 0)
				{
					num ^= Suffix.GetHashCode();
				}
				if (NumberingFormat.Length != 0)
				{
					num ^= NumberingFormat.GetHashCode();
				}
				if (StartNumber != 0)
				{
					num ^= StartNumber.GetHashCode();
				}
				if (LevelIndex != 0)
				{
					num ^= LevelIndex.GetHashCode();
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
				if (FollowType != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)FollowType);
				}
				if (NumberingScheme != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)NumberingScheme);
				}
				if (BulletType != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)BulletType);
				}
				if (IsBullet)
				{
					output.WriteRawTag(32);
					output.WriteBool(IsBullet);
				}
				if (Prefix.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(Prefix);
				}
				if (Suffix.Length != 0)
				{
					output.WriteRawTag(50);
					output.WriteString(Suffix);
				}
				if (NumberingFormat.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteString(NumberingFormat);
				}
				if (StartNumber != 0)
				{
					output.WriteRawTag(64);
					output.WriteInt32(StartNumber);
				}
				if (LevelIndex != 0)
				{
					output.WriteRawTag(72);
					output.WriteInt32(LevelIndex);
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
				if (FollowType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)FollowType);
				}
				if (NumberingScheme != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)NumberingScheme);
				}
				if (BulletType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)BulletType);
				}
				if (IsBullet)
				{
					num += 2;
				}
				if (Prefix.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Prefix);
				}
				if (Suffix.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Suffix);
				}
				if (NumberingFormat.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(NumberingFormat);
				}
				if (StartNumber != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(StartNumber);
				}
				if (LevelIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(LevelIndex);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(LevelSettings other)
			{
				if (other != null)
				{
					if (other.FollowType != 0)
					{
						FollowType = other.FollowType;
					}
					if (other.NumberingScheme != 0)
					{
						NumberingScheme = other.NumberingScheme;
					}
					if (other.BulletType != 0)
					{
						BulletType = other.BulletType;
					}
					if (other.IsBullet)
					{
						IsBullet = other.IsBullet;
					}
					if (other.Prefix.Length != 0)
					{
						Prefix = other.Prefix;
					}
					if (other.Suffix.Length != 0)
					{
						Suffix = other.Suffix;
					}
					if (other.NumberingFormat.Length != 0)
					{
						NumberingFormat = other.NumberingFormat;
					}
					if (other.StartNumber != 0)
					{
						StartNumber = other.StartNumber;
					}
					if (other.LevelIndex != 0)
					{
						LevelIndex = other.LevelIndex;
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
						FollowType = (Types.FollowType)input.ReadEnum();
						break;
					case 16u:
						NumberingScheme = (Types.NumberingScheme)input.ReadEnum();
						break;
					case 24u:
						BulletType = (Types.BulletType)input.ReadEnum();
						break;
					case 32u:
						IsBullet = input.ReadBool();
						break;
					case 42u:
						Prefix = input.ReadString();
						break;
					case 50u:
						Suffix = input.ReadString();
						break;
					case 58u:
						NumberingFormat = input.ReadString();
						break;
					case 64u:
						StartNumber = input.ReadInt32();
						break;
					case 72u:
						LevelIndex = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ListSettings : IMessage<ListSettings>, IMessage, IEquatable<ListSettings>, IDeepCloneable<ListSettings>
		{
			private static readonly MessageParser<ListSettings> _parser = new MessageParser<ListSettings>(() => new ListSettings());

			private UnknownFieldSet _unknownFields;

			public const int LevelSettingsFieldNumber = 1;

			private static readonly FieldCodec<LevelSettings> _repeated_levelSettings_codec = FieldCodec.ForMessage(10u, Types.LevelSettings.Parser);

			private readonly RepeatedField<LevelSettings> levelSettings_ = new RepeatedField<LevelSettings>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ListSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<LevelSettings> LevelSettings => levelSettings_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ListSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ListSettings(ListSettings other)
				: this()
			{
				levelSettings_ = other.levelSettings_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ListSettings Clone()
			{
				return new ListSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ListSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ListSettings other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!levelSettings_.Equals(other.levelSettings_))
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
				num ^= levelSettings_.GetHashCode();
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
				levelSettings_.WriteTo(output, _repeated_levelSettings_codec);
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
				num += levelSettings_.CalculateSize(_repeated_levelSettings_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ListSettings other)
			{
				if (other != null)
				{
					levelSettings_.Add(other.levelSettings_);
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
						levelSettings_.AddEntriesFrom(input, _repeated_levelSettings_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TableSettings : IMessage<TableSettings>, IMessage, IEquatable<TableSettings>, IDeepCloneable<TableSettings>
		{
			private static readonly MessageParser<TableSettings> _parser = new MessageParser<TableSettings>(() => new TableSettings());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TableSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TableSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TableSettings(TableSettings other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TableSettings Clone()
			{
				return new TableSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TableSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TableSettings other)
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
			public void MergeFrom(TableSettings other)
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
		public sealed class TabStop : IMessage<TabStop>, IMessage, IEquatable<TabStop>, IDeepCloneable<TabStop>
		{
			private static readonly MessageParser<TabStop> _parser = new MessageParser<TabStop>(() => new TabStop());

			private UnknownFieldSet _unknownFields;

			public const int PositionFieldNumber = 1;

			private double position_;

			public const int TypeFieldNumber = 2;

			private TabStopType type_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TabStop> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Position
			{
				get
				{
					return position_;
				}
				set
				{
					position_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TabStopType Type
			{
				get
				{
					return type_;
				}
				set
				{
					type_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TabStop()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TabStop(TabStop other)
				: this()
			{
				position_ = other.position_;
				type_ = other.type_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TabStop Clone()
			{
				return new TabStop(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TabStop);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TabStop other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Position, other.Position))
				{
					return false;
				}
				if (Type != other.Type)
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
				if (Position != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Position);
				}
				if (Type != 0)
				{
					num ^= Type.GetHashCode();
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
				if (Position != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Position);
				}
				if (Type != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Type);
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
				if (Position != 0.0)
				{
					num += 9;
				}
				if (Type != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TabStop other)
			{
				if (other != null)
				{
					if (other.Position != 0.0)
					{
						Position = other.Position;
					}
					if (other.Type != 0)
					{
						Type = other.Type;
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
						Position = input.ReadDouble();
						break;
					case 16u:
						Type = (TabStopType)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ParagraphSettings : IMessage<ParagraphSettings>, IMessage, IEquatable<ParagraphSettings>, IDeepCloneable<ParagraphSettings>
		{
			private static readonly MessageParser<ParagraphSettings> _parser = new MessageParser<ParagraphSettings>(() => new ParagraphSettings());

			private UnknownFieldSet _unknownFields;

			public const int AlignmentFieldNumber = 1;

			private ParagraphAlignment alignment_;

			public const int SpacingModeFieldNumber = 2;

			private LineSpacingMode spacingMode_;

			public const int LineSpacingFieldNumber = 3;

			private double lineSpacing_;

			public const int AdditionalLineSpacingFieldNumber = 4;

			private double additionalLineSpacing_;

			public const int BeforeParagraphFieldNumber = 5;

			private double beforeParagraph_;

			public const int AfterParagraphFieldNumber = 6;

			private double afterParagraph_;

			public const int LeftIndentFieldNumber = 7;

			private double leftIndent_;

			public const int RightIndentFieldNumber = 8;

			private double rightIndent_;

			public const int RightIndentModeFieldNumber = 9;

			private RightIndentMode rightIndentMode_;

			public const int FirstLineIndentFieldNumber = 10;

			private double firstLineIndent_;

			public const int ListIndexFieldNumber = 11;

			private int listIndex_;

			public const int LevelIndexFieldNumber = 12;

			private int levelIndex_;

			public const int BulletColorFieldNumber = 13;

			private Color bulletColor_;

			public const int BulletScaleFieldNumber = 14;

			private double bulletScale_;

			public const int TabStopsFieldNumber = 15;

			private static readonly FieldCodec<TabStop> _repeated_tabStops_codec = FieldCodec.ForMessage(122u, TabStop.Parser);

			private readonly RepeatedField<TabStop> tabStops_ = new RepeatedField<TabStop>();

			public const int ListOverrideTextFieldNumber = 16;

			private string listOverrideText_ = "";

			public const int DefaultTabStopFieldNumber = 17;

			private double defaultTabStop_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ParagraphSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ParagraphAlignment Alignment
			{
				get
				{
					return alignment_;
				}
				set
				{
					alignment_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public LineSpacingMode SpacingMode
			{
				get
				{
					return spacingMode_;
				}
				set
				{
					spacingMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double LineSpacing
			{
				get
				{
					return lineSpacing_;
				}
				set
				{
					lineSpacing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double AdditionalLineSpacing
			{
				get
				{
					return additionalLineSpacing_;
				}
				set
				{
					additionalLineSpacing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double BeforeParagraph
			{
				get
				{
					return beforeParagraph_;
				}
				set
				{
					beforeParagraph_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double AfterParagraph
			{
				get
				{
					return afterParagraph_;
				}
				set
				{
					afterParagraph_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double LeftIndent
			{
				get
				{
					return leftIndent_;
				}
				set
				{
					leftIndent_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double RightIndent
			{
				get
				{
					return rightIndent_;
				}
				set
				{
					rightIndent_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RightIndentMode RightIndentMode
			{
				get
				{
					return rightIndentMode_;
				}
				set
				{
					rightIndentMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double FirstLineIndent
			{
				get
				{
					return firstLineIndent_;
				}
				set
				{
					firstLineIndent_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int ListIndex
			{
				get
				{
					return listIndex_;
				}
				set
				{
					listIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int LevelIndex
			{
				get
				{
					return levelIndex_;
				}
				set
				{
					levelIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color BulletColor
			{
				get
				{
					return bulletColor_;
				}
				set
				{
					bulletColor_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double BulletScale
			{
				get
				{
					return bulletScale_;
				}
				set
				{
					bulletScale_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<TabStop> TabStops => tabStops_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ListOverrideText
			{
				get
				{
					return listOverrideText_;
				}
				set
				{
					listOverrideText_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double DefaultTabStop
			{
				get
				{
					return defaultTabStop_;
				}
				set
				{
					defaultTabStop_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ParagraphSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ParagraphSettings(ParagraphSettings other)
				: this()
			{
				alignment_ = other.alignment_;
				spacingMode_ = other.spacingMode_;
				lineSpacing_ = other.lineSpacing_;
				additionalLineSpacing_ = other.additionalLineSpacing_;
				beforeParagraph_ = other.beforeParagraph_;
				afterParagraph_ = other.afterParagraph_;
				leftIndent_ = other.leftIndent_;
				rightIndent_ = other.rightIndent_;
				rightIndentMode_ = other.rightIndentMode_;
				firstLineIndent_ = other.firstLineIndent_;
				listIndex_ = other.listIndex_;
				levelIndex_ = other.levelIndex_;
				bulletColor_ = ((other.bulletColor_ != null) ? other.bulletColor_.Clone() : null);
				bulletScale_ = other.bulletScale_;
				tabStops_ = other.tabStops_.Clone();
				listOverrideText_ = other.listOverrideText_;
				defaultTabStop_ = other.defaultTabStop_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ParagraphSettings Clone()
			{
				return new ParagraphSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ParagraphSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ParagraphSettings other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Alignment != other.Alignment)
				{
					return false;
				}
				if (SpacingMode != other.SpacingMode)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LineSpacing, other.LineSpacing))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AdditionalLineSpacing, other.AdditionalLineSpacing))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BeforeParagraph, other.BeforeParagraph))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AfterParagraph, other.AfterParagraph))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LeftIndent, other.LeftIndent))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(RightIndent, other.RightIndent))
				{
					return false;
				}
				if (RightIndentMode != other.RightIndentMode)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FirstLineIndent, other.FirstLineIndent))
				{
					return false;
				}
				if (ListIndex != other.ListIndex)
				{
					return false;
				}
				if (LevelIndex != other.LevelIndex)
				{
					return false;
				}
				if (!object.Equals(BulletColor, other.BulletColor))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BulletScale, other.BulletScale))
				{
					return false;
				}
				if (!tabStops_.Equals(other.tabStops_))
				{
					return false;
				}
				if (ListOverrideText != other.ListOverrideText)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DefaultTabStop, other.DefaultTabStop))
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
				if (Alignment != 0)
				{
					num ^= Alignment.GetHashCode();
				}
				if (SpacingMode != 0)
				{
					num ^= SpacingMode.GetHashCode();
				}
				if (LineSpacing != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LineSpacing);
				}
				if (AdditionalLineSpacing != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AdditionalLineSpacing);
				}
				if (BeforeParagraph != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BeforeParagraph);
				}
				if (AfterParagraph != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AfterParagraph);
				}
				if (LeftIndent != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LeftIndent);
				}
				if (RightIndent != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(RightIndent);
				}
				if (RightIndentMode != 0)
				{
					num ^= RightIndentMode.GetHashCode();
				}
				if (FirstLineIndent != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FirstLineIndent);
				}
				if (ListIndex != 0)
				{
					num ^= ListIndex.GetHashCode();
				}
				if (LevelIndex != 0)
				{
					num ^= LevelIndex.GetHashCode();
				}
				if (bulletColor_ != null)
				{
					num ^= BulletColor.GetHashCode();
				}
				if (BulletScale != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BulletScale);
				}
				num ^= tabStops_.GetHashCode();
				if (ListOverrideText.Length != 0)
				{
					num ^= ListOverrideText.GetHashCode();
				}
				if (DefaultTabStop != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DefaultTabStop);
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
				if (Alignment != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Alignment);
				}
				if (SpacingMode != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)SpacingMode);
				}
				if (LineSpacing != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(LineSpacing);
				}
				if (AdditionalLineSpacing != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(AdditionalLineSpacing);
				}
				if (BeforeParagraph != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(BeforeParagraph);
				}
				if (AfterParagraph != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(AfterParagraph);
				}
				if (LeftIndent != 0.0)
				{
					output.WriteRawTag(57);
					output.WriteDouble(LeftIndent);
				}
				if (RightIndent != 0.0)
				{
					output.WriteRawTag(65);
					output.WriteDouble(RightIndent);
				}
				if (RightIndentMode != 0)
				{
					output.WriteRawTag(72);
					output.WriteEnum((int)RightIndentMode);
				}
				if (FirstLineIndent != 0.0)
				{
					output.WriteRawTag(81);
					output.WriteDouble(FirstLineIndent);
				}
				if (ListIndex != 0)
				{
					output.WriteRawTag(88);
					output.WriteInt32(ListIndex);
				}
				if (LevelIndex != 0)
				{
					output.WriteRawTag(96);
					output.WriteInt32(LevelIndex);
				}
				if (bulletColor_ != null)
				{
					output.WriteRawTag(106);
					output.WriteMessage(BulletColor);
				}
				if (BulletScale != 0.0)
				{
					output.WriteRawTag(113);
					output.WriteDouble(BulletScale);
				}
				tabStops_.WriteTo(output, _repeated_tabStops_codec);
				if (ListOverrideText.Length != 0)
				{
					output.WriteRawTag(130, 1);
					output.WriteString(ListOverrideText);
				}
				if (DefaultTabStop != 0.0)
				{
					output.WriteRawTag(137, 1);
					output.WriteDouble(DefaultTabStop);
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
				if (Alignment != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Alignment);
				}
				if (SpacingMode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)SpacingMode);
				}
				if (LineSpacing != 0.0)
				{
					num += 9;
				}
				if (AdditionalLineSpacing != 0.0)
				{
					num += 9;
				}
				if (BeforeParagraph != 0.0)
				{
					num += 9;
				}
				if (AfterParagraph != 0.0)
				{
					num += 9;
				}
				if (LeftIndent != 0.0)
				{
					num += 9;
				}
				if (RightIndent != 0.0)
				{
					num += 9;
				}
				if (RightIndentMode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)RightIndentMode);
				}
				if (FirstLineIndent != 0.0)
				{
					num += 9;
				}
				if (ListIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(ListIndex);
				}
				if (LevelIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(LevelIndex);
				}
				if (bulletColor_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BulletColor);
				}
				if (BulletScale != 0.0)
				{
					num += 9;
				}
				num += tabStops_.CalculateSize(_repeated_tabStops_codec);
				if (ListOverrideText.Length != 0)
				{
					num += 2 + CodedOutputStream.ComputeStringSize(ListOverrideText);
				}
				if (DefaultTabStop != 0.0)
				{
					num += 10;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ParagraphSettings other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Alignment != 0)
				{
					Alignment = other.Alignment;
				}
				if (other.SpacingMode != 0)
				{
					SpacingMode = other.SpacingMode;
				}
				if (other.LineSpacing != 0.0)
				{
					LineSpacing = other.LineSpacing;
				}
				if (other.AdditionalLineSpacing != 0.0)
				{
					AdditionalLineSpacing = other.AdditionalLineSpacing;
				}
				if (other.BeforeParagraph != 0.0)
				{
					BeforeParagraph = other.BeforeParagraph;
				}
				if (other.AfterParagraph != 0.0)
				{
					AfterParagraph = other.AfterParagraph;
				}
				if (other.LeftIndent != 0.0)
				{
					LeftIndent = other.LeftIndent;
				}
				if (other.RightIndent != 0.0)
				{
					RightIndent = other.RightIndent;
				}
				if (other.RightIndentMode != 0)
				{
					RightIndentMode = other.RightIndentMode;
				}
				if (other.FirstLineIndent != 0.0)
				{
					FirstLineIndent = other.FirstLineIndent;
				}
				if (other.ListIndex != 0)
				{
					ListIndex = other.ListIndex;
				}
				if (other.LevelIndex != 0)
				{
					LevelIndex = other.LevelIndex;
				}
				if (other.bulletColor_ != null)
				{
					if (bulletColor_ == null)
					{
						BulletColor = new Color();
					}
					BulletColor.MergeFrom(other.BulletColor);
				}
				if (other.BulletScale != 0.0)
				{
					BulletScale = other.BulletScale;
				}
				tabStops_.Add(other.tabStops_);
				if (other.ListOverrideText.Length != 0)
				{
					ListOverrideText = other.ListOverrideText;
				}
				if (other.DefaultTabStop != 0.0)
				{
					DefaultTabStop = other.DefaultTabStop;
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
						Alignment = (ParagraphAlignment)input.ReadEnum();
						break;
					case 16u:
						SpacingMode = (LineSpacingMode)input.ReadEnum();
						break;
					case 25u:
						LineSpacing = input.ReadDouble();
						break;
					case 33u:
						AdditionalLineSpacing = input.ReadDouble();
						break;
					case 41u:
						BeforeParagraph = input.ReadDouble();
						break;
					case 49u:
						AfterParagraph = input.ReadDouble();
						break;
					case 57u:
						LeftIndent = input.ReadDouble();
						break;
					case 65u:
						RightIndent = input.ReadDouble();
						break;
					case 72u:
						RightIndentMode = (RightIndentMode)input.ReadEnum();
						break;
					case 81u:
						FirstLineIndent = input.ReadDouble();
						break;
					case 88u:
						ListIndex = input.ReadInt32();
						break;
					case 96u:
						LevelIndex = input.ReadInt32();
						break;
					case 106u:
						if (bulletColor_ == null)
						{
							BulletColor = new Color();
						}
						input.ReadMessage(BulletColor);
						break;
					case 113u:
						BulletScale = input.ReadDouble();
						break;
					case 122u:
						tabStops_.AddEntriesFrom(input, _repeated_tabStops_codec);
						break;
					case 130u:
						ListOverrideText = input.ReadString();
						break;
					case 137u:
						DefaultTabStop = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class FontInfo : IMessage<FontInfo>, IMessage, IEquatable<FontInfo>, IDeepCloneable<FontInfo>
		{
			private static readonly MessageParser<FontInfo> _parser = new MessageParser<FontInfo>(() => new FontInfo());

			private UnknownFieldSet _unknownFields;

			public const int SystemFamilyNameFieldNumber = 1;

			private string systemFamilyName_ = "";

			public const int SystemFaceNameFieldNumber = 2;

			private string systemFaceName_ = "";

			public const int DisplayFamilyNameFieldNumber = 3;

			private string displayFamilyName_ = "";

			public const int DisplayFaceNameFieldNumber = 4;

			private string displayFaceName_ = "";

			public const int FullNameFieldNumber = 5;

			private string fullName_ = "";

			public const int PostscriptNameFieldNumber = 6;

			private string postscriptName_ = "";

			public const int AlternatePostscriptNamesFieldNumber = 7;

			private static readonly FieldCodec<string> _repeated_alternatePostscriptNames_codec = FieldCodec.ForString(58u);

			private readonly RepeatedField<string> alternatePostscriptNames_ = new RepeatedField<string>();

			public const int WeightFieldNumber = 8;

			private uint weight_;

			public const int WidthFieldNumber = 9;

			private uint width_;

			public const int IsItalicFieldNumber = 10;

			private bool isItalic_;

			public const int VariantIndexFieldNumber = 11;

			private uint variantIndex_;

			public const int OtherPropertiesFieldNumber = 12;

			private static readonly FieldCodec<string> _repeated_otherProperties_codec = FieldCodec.ForString(98u);

			private readonly RepeatedField<string> otherProperties_ = new RepeatedField<string>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FontInfo> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string SystemFamilyName
			{
				get
				{
					return systemFamilyName_;
				}
				set
				{
					systemFamilyName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string SystemFaceName
			{
				get
				{
					return systemFaceName_;
				}
				set
				{
					systemFaceName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string DisplayFamilyName
			{
				get
				{
					return displayFamilyName_;
				}
				set
				{
					displayFamilyName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string DisplayFaceName
			{
				get
				{
					return displayFaceName_;
				}
				set
				{
					displayFaceName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string FullName
			{
				get
				{
					return fullName_;
				}
				set
				{
					fullName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PostscriptName
			{
				get
				{
					return postscriptName_;
				}
				set
				{
					postscriptName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<string> AlternatePostscriptNames => alternatePostscriptNames_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Weight
			{
				get
				{
					return weight_;
				}
				set
				{
					weight_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Width
			{
				get
				{
					return width_;
				}
				set
				{
					width_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsItalic
			{
				get
				{
					return isItalic_;
				}
				set
				{
					isItalic_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint VariantIndex
			{
				get
				{
					return variantIndex_;
				}
				set
				{
					variantIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<string> OtherProperties => otherProperties_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FontInfo()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FontInfo(FontInfo other)
				: this()
			{
				systemFamilyName_ = other.systemFamilyName_;
				systemFaceName_ = other.systemFaceName_;
				displayFamilyName_ = other.displayFamilyName_;
				displayFaceName_ = other.displayFaceName_;
				fullName_ = other.fullName_;
				postscriptName_ = other.postscriptName_;
				alternatePostscriptNames_ = other.alternatePostscriptNames_.Clone();
				weight_ = other.weight_;
				width_ = other.width_;
				isItalic_ = other.isItalic_;
				variantIndex_ = other.variantIndex_;
				otherProperties_ = other.otherProperties_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FontInfo Clone()
			{
				return new FontInfo(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FontInfo);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FontInfo other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (SystemFamilyName != other.SystemFamilyName)
				{
					return false;
				}
				if (SystemFaceName != other.SystemFaceName)
				{
					return false;
				}
				if (DisplayFamilyName != other.DisplayFamilyName)
				{
					return false;
				}
				if (DisplayFaceName != other.DisplayFaceName)
				{
					return false;
				}
				if (FullName != other.FullName)
				{
					return false;
				}
				if (PostscriptName != other.PostscriptName)
				{
					return false;
				}
				if (!alternatePostscriptNames_.Equals(other.alternatePostscriptNames_))
				{
					return false;
				}
				if (Weight != other.Weight)
				{
					return false;
				}
				if (Width != other.Width)
				{
					return false;
				}
				if (IsItalic != other.IsItalic)
				{
					return false;
				}
				if (VariantIndex != other.VariantIndex)
				{
					return false;
				}
				if (!otherProperties_.Equals(other.otherProperties_))
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
				if (SystemFamilyName.Length != 0)
				{
					num ^= SystemFamilyName.GetHashCode();
				}
				if (SystemFaceName.Length != 0)
				{
					num ^= SystemFaceName.GetHashCode();
				}
				if (DisplayFamilyName.Length != 0)
				{
					num ^= DisplayFamilyName.GetHashCode();
				}
				if (DisplayFaceName.Length != 0)
				{
					num ^= DisplayFaceName.GetHashCode();
				}
				if (FullName.Length != 0)
				{
					num ^= FullName.GetHashCode();
				}
				if (PostscriptName.Length != 0)
				{
					num ^= PostscriptName.GetHashCode();
				}
				num ^= alternatePostscriptNames_.GetHashCode();
				if (Weight != 0)
				{
					num ^= Weight.GetHashCode();
				}
				if (Width != 0)
				{
					num ^= Width.GetHashCode();
				}
				if (IsItalic)
				{
					num ^= IsItalic.GetHashCode();
				}
				if (VariantIndex != 0)
				{
					num ^= VariantIndex.GetHashCode();
				}
				num ^= otherProperties_.GetHashCode();
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
				if (SystemFamilyName.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(SystemFamilyName);
				}
				if (SystemFaceName.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(SystemFaceName);
				}
				if (DisplayFamilyName.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(DisplayFamilyName);
				}
				if (DisplayFaceName.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(DisplayFaceName);
				}
				if (FullName.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(FullName);
				}
				if (PostscriptName.Length != 0)
				{
					output.WriteRawTag(50);
					output.WriteString(PostscriptName);
				}
				alternatePostscriptNames_.WriteTo(output, _repeated_alternatePostscriptNames_codec);
				if (Weight != 0)
				{
					output.WriteRawTag(64);
					output.WriteUInt32(Weight);
				}
				if (Width != 0)
				{
					output.WriteRawTag(72);
					output.WriteUInt32(Width);
				}
				if (IsItalic)
				{
					output.WriteRawTag(80);
					output.WriteBool(IsItalic);
				}
				if (VariantIndex != 0)
				{
					output.WriteRawTag(88);
					output.WriteUInt32(VariantIndex);
				}
				otherProperties_.WriteTo(output, _repeated_otherProperties_codec);
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
				if (SystemFamilyName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(SystemFamilyName);
				}
				if (SystemFaceName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(SystemFaceName);
				}
				if (DisplayFamilyName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(DisplayFamilyName);
				}
				if (DisplayFaceName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(DisplayFaceName);
				}
				if (FullName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(FullName);
				}
				if (PostscriptName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PostscriptName);
				}
				num += alternatePostscriptNames_.CalculateSize(_repeated_alternatePostscriptNames_codec);
				if (Weight != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Weight);
				}
				if (Width != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Width);
				}
				if (IsItalic)
				{
					num += 2;
				}
				if (VariantIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(VariantIndex);
				}
				num += otherProperties_.CalculateSize(_repeated_otherProperties_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(FontInfo other)
			{
				if (other != null)
				{
					if (other.SystemFamilyName.Length != 0)
					{
						SystemFamilyName = other.SystemFamilyName;
					}
					if (other.SystemFaceName.Length != 0)
					{
						SystemFaceName = other.SystemFaceName;
					}
					if (other.DisplayFamilyName.Length != 0)
					{
						DisplayFamilyName = other.DisplayFamilyName;
					}
					if (other.DisplayFaceName.Length != 0)
					{
						DisplayFaceName = other.DisplayFaceName;
					}
					if (other.FullName.Length != 0)
					{
						FullName = other.FullName;
					}
					if (other.PostscriptName.Length != 0)
					{
						PostscriptName = other.PostscriptName;
					}
					alternatePostscriptNames_.Add(other.alternatePostscriptNames_);
					if (other.Weight != 0)
					{
						Weight = other.Weight;
					}
					if (other.Width != 0)
					{
						Width = other.Width;
					}
					if (other.IsItalic)
					{
						IsItalic = other.IsItalic;
					}
					if (other.VariantIndex != 0)
					{
						VariantIndex = other.VariantIndex;
					}
					otherProperties_.Add(other.otherProperties_);
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
						SystemFamilyName = input.ReadString();
						break;
					case 18u:
						SystemFaceName = input.ReadString();
						break;
					case 26u:
						DisplayFamilyName = input.ReadString();
						break;
					case 34u:
						DisplayFaceName = input.ReadString();
						break;
					case 42u:
						FullName = input.ReadString();
						break;
					case 50u:
						PostscriptName = input.ReadString();
						break;
					case 58u:
						alternatePostscriptNames_.AddEntriesFrom(input, _repeated_alternatePostscriptNames_codec);
						break;
					case 64u:
						Weight = input.ReadUInt32();
						break;
					case 72u:
						Width = input.ReadUInt32();
						break;
					case 80u:
						IsItalic = input.ReadBool();
						break;
					case 88u:
						VariantIndex = input.ReadUInt32();
						break;
					case 98u:
						otherProperties_.AddEntriesFrom(input, _repeated_otherProperties_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SolidFill : IMessage<SolidFill>, IMessage, IEquatable<SolidFill>, IDeepCloneable<SolidFill>
		{
			private static readonly MessageParser<SolidFill> _parser = new MessageParser<SolidFill>(() => new SolidFill());

			private UnknownFieldSet _unknownFields;

			public const int ColorFieldNumber = 1;

			private Color color_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SolidFill> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[8];

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
			public SolidFill()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SolidFill(SolidFill other)
				: this()
			{
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SolidFill Clone()
			{
				return new SolidFill(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SolidFill);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SolidFill other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SolidFill other)
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
					if (color_ == null)
					{
						Color = new Color();
					}
					input.ReadMessage(Color);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GradientFill : IMessage<GradientFill>, IMessage, IEquatable<GradientFill>, IDeepCloneable<GradientFill>
		{
			private static readonly MessageParser<GradientFill> _parser = new MessageParser<GradientFill>(() => new GradientFill());

			private UnknownFieldSet _unknownFields;

			public const int AngleFieldNumber = 1;

			private double angle_;

			public const int StretchToDocumentBoundsFieldNumber = 2;

			private bool stretchToDocumentBounds_;

			public const int ColorsFieldNumber = 3;

			private static readonly FieldCodec<Color> _repeated_colors_codec = FieldCodec.ForMessage(26u, Color.Parser);

			private readonly RepeatedField<Color> colors_ = new RepeatedField<Color>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GradientFill> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Angle
			{
				get
				{
					return angle_;
				}
				set
				{
					angle_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool StretchToDocumentBounds
			{
				get
				{
					return stretchToDocumentBounds_;
				}
				set
				{
					stretchToDocumentBounds_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Color> Colors => colors_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GradientFill()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GradientFill(GradientFill other)
				: this()
			{
				angle_ = other.angle_;
				stretchToDocumentBounds_ = other.stretchToDocumentBounds_;
				colors_ = other.colors_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GradientFill Clone()
			{
				return new GradientFill(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GradientFill);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GradientFill other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Angle, other.Angle))
				{
					return false;
				}
				if (StretchToDocumentBounds != other.StretchToDocumentBounds)
				{
					return false;
				}
				if (!colors_.Equals(other.colors_))
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
				if (Angle != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Angle);
				}
				if (StretchToDocumentBounds)
				{
					num ^= StretchToDocumentBounds.GetHashCode();
				}
				num ^= colors_.GetHashCode();
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
				if (Angle != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Angle);
				}
				if (StretchToDocumentBounds)
				{
					output.WriteRawTag(16);
					output.WriteBool(StretchToDocumentBounds);
				}
				colors_.WriteTo(output, _repeated_colors_codec);
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
				if (Angle != 0.0)
				{
					num += 9;
				}
				if (StretchToDocumentBounds)
				{
					num += 2;
				}
				num += colors_.CalculateSize(_repeated_colors_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GradientFill other)
			{
				if (other != null)
				{
					if (other.Angle != 0.0)
					{
						Angle = other.Angle;
					}
					if (other.StretchToDocumentBounds)
					{
						StretchToDocumentBounds = other.StretchToDocumentBounds;
					}
					colors_.Add(other.colors_);
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
						Angle = input.ReadDouble();
						break;
					case 16u:
						StretchToDocumentBounds = input.ReadBool();
						break;
					case 26u:
						colors_.AddEntriesFrom(input, _repeated_colors_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CutOutFill : IMessage<CutOutFill>, IMessage, IEquatable<CutOutFill>, IDeepCloneable<CutOutFill>
		{
			private static readonly MessageParser<CutOutFill> _parser = new MessageParser<CutOutFill>(() => new CutOutFill());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CutOutFill> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CutOutFill()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CutOutFill(CutOutFill other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CutOutFill Clone()
			{
				return new CutOutFill(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CutOutFill);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CutOutFill other)
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
			public void MergeFrom(CutOutFill other)
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
		public sealed class Media : IMessage<Media>, IMessage, IEquatable<Media>, IDeepCloneable<Media>
		{
			private static readonly MessageParser<Media> _parser = new MessageParser<Media>(() => new Media());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Media> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(Media other)
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
		public sealed class MediaFill : IMessage<MediaFill>, IMessage, IEquatable<MediaFill>, IDeepCloneable<MediaFill>
		{
			private static readonly MessageParser<MediaFill> _parser = new MessageParser<MediaFill>(() => new MediaFill());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			public const int StretchToDocumentBoundsFieldNumber = 2;

			private bool stretchToDocumentBounds_;

			public const int MediaFieldNumber = 3;

			private Media media_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MediaFill> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool StretchToDocumentBounds
			{
				get
				{
					return stretchToDocumentBounds_;
				}
				set
				{
					stretchToDocumentBounds_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media Media
			{
				get
				{
					return media_;
				}
				set
				{
					media_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaFill()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaFill(MediaFill other)
				: this()
			{
				uuid_ = other.uuid_;
				stretchToDocumentBounds_ = other.stretchToDocumentBounds_;
				media_ = ((other.media_ != null) ? other.media_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaFill Clone()
			{
				return new MediaFill(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MediaFill);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MediaFill other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Uuid != other.Uuid)
				{
					return false;
				}
				if (StretchToDocumentBounds != other.StretchToDocumentBounds)
				{
					return false;
				}
				if (!object.Equals(Media, other.Media))
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
				if (Uuid.Length != 0)
				{
					num ^= Uuid.GetHashCode();
				}
				if (StretchToDocumentBounds)
				{
					num ^= StretchToDocumentBounds.GetHashCode();
				}
				if (media_ != null)
				{
					num ^= Media.GetHashCode();
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
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Uuid);
				}
				if (StretchToDocumentBounds)
				{
					output.WriteRawTag(16);
					output.WriteBool(StretchToDocumentBounds);
				}
				if (media_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Media);
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
				if (Uuid.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
				}
				if (StretchToDocumentBounds)
				{
					num += 2;
				}
				if (media_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Media);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MediaFill other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Uuid.Length != 0)
				{
					Uuid = other.Uuid;
				}
				if (other.StretchToDocumentBounds)
				{
					StretchToDocumentBounds = other.StretchToDocumentBounds;
				}
				if (other.media_ != null)
				{
					if (media_ == null)
					{
						Media = new Media();
					}
					Media.MergeFrom(other.Media);
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
						Uuid = input.ReadString();
						break;
					case 16u:
						StretchToDocumentBounds = input.ReadBool();
						break;
					case 26u:
						if (media_ == null)
						{
							Media = new Media();
						}
						input.ReadMessage(Media);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BackgroundBlurFill : IMessage<BackgroundBlurFill>, IMessage, IEquatable<BackgroundBlurFill>, IDeepCloneable<BackgroundBlurFill>
		{
			private static readonly MessageParser<BackgroundBlurFill> _parser = new MessageParser<BackgroundBlurFill>(() => new BackgroundBlurFill());

			private UnknownFieldSet _unknownFields;

			public const int BlurFieldNumber = 1;

			private double blur_;

			public const int SaturationFieldNumber = 2;

			private double saturation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BackgroundBlurFill> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Blur
			{
				get
				{
					return blur_;
				}
				set
				{
					blur_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Saturation
			{
				get
				{
					return saturation_;
				}
				set
				{
					saturation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundBlurFill()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundBlurFill(BackgroundBlurFill other)
				: this()
			{
				blur_ = other.blur_;
				saturation_ = other.saturation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundBlurFill Clone()
			{
				return new BackgroundBlurFill(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BackgroundBlurFill);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BackgroundBlurFill other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Blur, other.Blur))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Saturation, other.Saturation))
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
				if (Blur != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Blur);
				}
				if (Saturation != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Saturation);
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
				if (Blur != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Blur);
				}
				if (Saturation != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Saturation);
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
				if (Blur != 0.0)
				{
					num += 9;
				}
				if (Saturation != 0.0)
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
			public void MergeFrom(BackgroundBlurFill other)
			{
				if (other != null)
				{
					if (other.Blur != 0.0)
					{
						Blur = other.Blur;
					}
					if (other.Saturation != 0.0)
					{
						Saturation = other.Saturation;
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
						Blur = input.ReadDouble();
						break;
					case 17u:
						Saturation = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BackgroundInvertFill : IMessage<BackgroundInvertFill>, IMessage, IEquatable<BackgroundInvertFill>, IDeepCloneable<BackgroundInvertFill>
		{
			private static readonly MessageParser<BackgroundInvertFill> _parser = new MessageParser<BackgroundInvertFill>(() => new BackgroundInvertFill());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BackgroundInvertFill> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[14];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundInvertFill()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundInvertFill(BackgroundInvertFill other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundInvertFill Clone()
			{
				return new BackgroundInvertFill(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BackgroundInvertFill);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BackgroundInvertFill other)
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
			public void MergeFrom(BackgroundInvertFill other)
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
		public sealed class RunSettings : IMessage<RunSettings>, IMessage, IEquatable<RunSettings>, IDeepCloneable<RunSettings>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum CharacterSizeMode
				{
					[OriginalName("CharacterSizeMode_Normal")]
					Normal,
					[OriginalName("CharacterSizeMode_ScaledByDocumentHeight")]
					ScaledByDocumentHeight,
					[OriginalName("CharacterSizeMode_ScaledByDocumentWidth")]
					ScaledByDocumentWidth
				}

				public enum CapitalizationType
				{
					[OriginalName("CapitalizationType_None")]
					None,
					[OriginalName("CapitalizationType_AllCaps")]
					AllCaps,
					[OriginalName("CapitalizationType_LowerCase")]
					LowerCase,
					[OriginalName("CapitalizationType_SmallCaps")]
					SmallCaps,
					[OriginalName("CapitalizationType_TitleCase")]
					TitleCase,
					[OriginalName("CapitalizationType_StartCase")]
					StartCase
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class TextFill : IMessage<TextFill>, IMessage, IEquatable<TextFill>, IDeepCloneable<TextFill>
				{
					public enum FillOneofCase
					{
						None,
						SolidFill,
						GradientFill,
						CutOutFill,
						MediaFill,
						BackgroundBlurFill,
						BackgroundInvertFill
					}

					private static readonly MessageParser<TextFill> _parser = new MessageParser<TextFill>(() => new TextFill());

					private UnknownFieldSet _unknownFields;

					public const int SolidFillFieldNumber = 1;

					public const int GradientFillFieldNumber = 2;

					public const int CutOutFillFieldNumber = 3;

					public const int MediaFillFieldNumber = 4;

					public const int BackgroundBlurFillFieldNumber = 5;

					public const int BackgroundInvertFillFieldNumber = 6;

					private object fill_;

					private FillOneofCase fillCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<TextFill> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => RunSettings.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SolidFill SolidFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.SolidFill)
							{
								return null;
							}
							return (SolidFill)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.SolidFill : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GradientFill GradientFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.GradientFill)
							{
								return null;
							}
							return (GradientFill)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.GradientFill : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public CutOutFill CutOutFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.CutOutFill)
							{
								return null;
							}
							return (CutOutFill)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.CutOutFill : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MediaFill MediaFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.MediaFill)
							{
								return null;
							}
							return (MediaFill)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.MediaFill : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundBlurFill BackgroundBlurFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.BackgroundBlurFill)
							{
								return null;
							}
							return (BackgroundBlurFill)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.BackgroundBlurFill : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundInvertFill BackgroundInvertFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.BackgroundInvertFill)
							{
								return null;
							}
							return (BackgroundInvertFill)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.BackgroundInvertFill : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public FillOneofCase FillCase => fillCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TextFill()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TextFill(TextFill other)
						: this()
					{
						switch (other.FillCase)
						{
						case FillOneofCase.SolidFill:
							SolidFill = other.SolidFill.Clone();
							break;
						case FillOneofCase.GradientFill:
							GradientFill = other.GradientFill.Clone();
							break;
						case FillOneofCase.CutOutFill:
							CutOutFill = other.CutOutFill.Clone();
							break;
						case FillOneofCase.MediaFill:
							MediaFill = other.MediaFill.Clone();
							break;
						case FillOneofCase.BackgroundBlurFill:
							BackgroundBlurFill = other.BackgroundBlurFill.Clone();
							break;
						case FillOneofCase.BackgroundInvertFill:
							BackgroundInvertFill = other.BackgroundInvertFill.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public TextFill Clone()
					{
						return new TextFill(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearFill()
					{
						fillCase_ = FillOneofCase.None;
						fill_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as TextFill);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(TextFill other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(SolidFill, other.SolidFill))
						{
							return false;
						}
						if (!object.Equals(GradientFill, other.GradientFill))
						{
							return false;
						}
						if (!object.Equals(CutOutFill, other.CutOutFill))
						{
							return false;
						}
						if (!object.Equals(MediaFill, other.MediaFill))
						{
							return false;
						}
						if (!object.Equals(BackgroundBlurFill, other.BackgroundBlurFill))
						{
							return false;
						}
						if (!object.Equals(BackgroundInvertFill, other.BackgroundInvertFill))
						{
							return false;
						}
						if (FillCase != other.FillCase)
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
						if (fillCase_ == FillOneofCase.SolidFill)
						{
							num ^= SolidFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.GradientFill)
						{
							num ^= GradientFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.CutOutFill)
						{
							num ^= CutOutFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.MediaFill)
						{
							num ^= MediaFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.BackgroundBlurFill)
						{
							num ^= BackgroundBlurFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.BackgroundInvertFill)
						{
							num ^= BackgroundInvertFill.GetHashCode();
						}
						num ^= (int)fillCase_;
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
						if (fillCase_ == FillOneofCase.SolidFill)
						{
							output.WriteRawTag(10);
							output.WriteMessage(SolidFill);
						}
						if (fillCase_ == FillOneofCase.GradientFill)
						{
							output.WriteRawTag(18);
							output.WriteMessage(GradientFill);
						}
						if (fillCase_ == FillOneofCase.CutOutFill)
						{
							output.WriteRawTag(26);
							output.WriteMessage(CutOutFill);
						}
						if (fillCase_ == FillOneofCase.MediaFill)
						{
							output.WriteRawTag(34);
							output.WriteMessage(MediaFill);
						}
						if (fillCase_ == FillOneofCase.BackgroundBlurFill)
						{
							output.WriteRawTag(42);
							output.WriteMessage(BackgroundBlurFill);
						}
						if (fillCase_ == FillOneofCase.BackgroundInvertFill)
						{
							output.WriteRawTag(50);
							output.WriteMessage(BackgroundInvertFill);
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
						if (fillCase_ == FillOneofCase.SolidFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(SolidFill);
						}
						if (fillCase_ == FillOneofCase.GradientFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(GradientFill);
						}
						if (fillCase_ == FillOneofCase.CutOutFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(CutOutFill);
						}
						if (fillCase_ == FillOneofCase.MediaFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(MediaFill);
						}
						if (fillCase_ == FillOneofCase.BackgroundBlurFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundBlurFill);
						}
						if (fillCase_ == FillOneofCase.BackgroundInvertFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundInvertFill);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(TextFill other)
					{
						if (other == null)
						{
							return;
						}
						switch (other.FillCase)
						{
						case FillOneofCase.SolidFill:
							if (SolidFill == null)
							{
								SolidFill = new SolidFill();
							}
							SolidFill.MergeFrom(other.SolidFill);
							break;
						case FillOneofCase.GradientFill:
							if (GradientFill == null)
							{
								GradientFill = new GradientFill();
							}
							GradientFill.MergeFrom(other.GradientFill);
							break;
						case FillOneofCase.CutOutFill:
							if (CutOutFill == null)
							{
								CutOutFill = new CutOutFill();
							}
							CutOutFill.MergeFrom(other.CutOutFill);
							break;
						case FillOneofCase.MediaFill:
							if (MediaFill == null)
							{
								MediaFill = new MediaFill();
							}
							MediaFill.MergeFrom(other.MediaFill);
							break;
						case FillOneofCase.BackgroundBlurFill:
							if (BackgroundBlurFill == null)
							{
								BackgroundBlurFill = new BackgroundBlurFill();
							}
							BackgroundBlurFill.MergeFrom(other.BackgroundBlurFill);
							break;
						case FillOneofCase.BackgroundInvertFill:
							if (BackgroundInvertFill == null)
							{
								BackgroundInvertFill = new BackgroundInvertFill();
							}
							BackgroundInvertFill.MergeFrom(other.BackgroundInvertFill);
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
								SolidFill solidFill = new SolidFill();
								if (fillCase_ == FillOneofCase.SolidFill)
								{
									solidFill.MergeFrom(SolidFill);
								}
								input.ReadMessage(solidFill);
								SolidFill = solidFill;
								break;
							}
							case 18u:
							{
								GradientFill gradientFill = new GradientFill();
								if (fillCase_ == FillOneofCase.GradientFill)
								{
									gradientFill.MergeFrom(GradientFill);
								}
								input.ReadMessage(gradientFill);
								GradientFill = gradientFill;
								break;
							}
							case 26u:
							{
								CutOutFill cutOutFill = new CutOutFill();
								if (fillCase_ == FillOneofCase.CutOutFill)
								{
									cutOutFill.MergeFrom(CutOutFill);
								}
								input.ReadMessage(cutOutFill);
								CutOutFill = cutOutFill;
								break;
							}
							case 34u:
							{
								MediaFill mediaFill = new MediaFill();
								if (fillCase_ == FillOneofCase.MediaFill)
								{
									mediaFill.MergeFrom(MediaFill);
								}
								input.ReadMessage(mediaFill);
								MediaFill = mediaFill;
								break;
							}
							case 42u:
							{
								BackgroundBlurFill backgroundBlurFill = new BackgroundBlurFill();
								if (fillCase_ == FillOneofCase.BackgroundBlurFill)
								{
									backgroundBlurFill.MergeFrom(BackgroundBlurFill);
								}
								input.ReadMessage(backgroundBlurFill);
								BackgroundBlurFill = backgroundBlurFill;
								break;
							}
							case 50u:
							{
								BackgroundInvertFill backgroundInvertFill = new BackgroundInvertFill();
								if (fillCase_ == FillOneofCase.BackgroundInvertFill)
								{
									backgroundInvertFill.MergeFrom(BackgroundInvertFill);
								}
								input.ReadMessage(backgroundInvertFill);
								BackgroundInvertFill = backgroundInvertFill;
								break;
							}
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Stroke : IMessage<Stroke>, IMessage, IEquatable<Stroke>, IDeepCloneable<Stroke>
				{
					private static readonly MessageParser<Stroke> _parser = new MessageParser<Stroke>(() => new Stroke());

					private UnknownFieldSet _unknownFields;

					public const int ThicknessFieldNumber = 1;

					private double thickness_;

					public const int ColorFieldNumber = 2;

					private Color color_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Stroke> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => RunSettings.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Thickness
					{
						get
						{
							return thickness_;
						}
						set
						{
							thickness_ = value;
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
					public Stroke()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Stroke(Stroke other)
						: this()
					{
						thickness_ = other.thickness_;
						color_ = ((other.color_ != null) ? other.color_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Stroke Clone()
					{
						return new Stroke(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Stroke);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Stroke other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Thickness, other.Thickness))
						{
							return false;
						}
						if (!object.Equals(Color, other.Color))
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
						if (Thickness != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Thickness);
						}
						if (color_ != null)
						{
							num ^= Color.GetHashCode();
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
						if (Thickness != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Thickness);
						}
						if (color_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Color);
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
						if (Thickness != 0.0)
						{
							num += 9;
						}
						if (color_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Color);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Stroke other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Thickness != 0.0)
						{
							Thickness = other.Thickness;
						}
						if (other.color_ != null)
						{
							if (color_ == null)
							{
								Color = new Color();
							}
							Color.MergeFrom(other.Color);
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
							case 9u:
								Thickness = input.ReadDouble();
								break;
							case 18u:
								if (color_ == null)
								{
									Color = new Color();
								}
								input.ReadMessage(Color);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<RunSettings> _parser = new MessageParser<RunSettings>(() => new RunSettings());

			private UnknownFieldSet _unknownFields;

			public const int FontFieldNumber = 1;

			private FontInfo font_;

			public const int CharacterSizeFieldNumber = 2;

			private double characterSize_;

			public const int CharacterSizeModeFieldNumber = 3;

			private Types.CharacterSizeMode characterSizeMode_;

			public const int CharacterSpacingFieldNumber = 4;

			private double characterSpacing_;

			public const int ScriptLevelFieldNumber = 5;

			private int scriptLevel_;

			public const int TextFillFieldNumber = 6;

			private Types.TextFill textFill_;

			public const int HighlightColorFieldNumber = 7;

			private Color highlightColor_;

			public const int StrokeFieldNumber = 8;

			private Types.Stroke stroke_;

			public const int UnderlineFieldNumber = 9;

			private bool underline_;

			public const int UnderlineColorFieldNumber = 10;

			private Color underlineColor_;

			public const int StrikeThroughFieldNumber = 11;

			private bool strikeThrough_;

			public const int CapitalizationTypeFieldNumber = 12;

			private Types.CapitalizationType capitalizationType_;

			public const int TabularNumbersFieldNumber = 13;

			private bool tabularNumbers_;

			public const int PreserveFillColorFieldNumber = 14;

			private bool preserveFillColor_;

			public const int KerningFieldNumber = 15;

			private bool kerning_;

			public const int LigaturesFieldNumber = 16;

			private bool ligatures_;

			public const int FontScaleFactorFieldNumber = 17;

			private double fontScaleFactor_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<RunSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[15];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FontInfo Font
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
			public double CharacterSize
			{
				get
				{
					return characterSize_;
				}
				set
				{
					characterSize_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.CharacterSizeMode CharacterSizeMode
			{
				get
				{
					return characterSizeMode_;
				}
				set
				{
					characterSizeMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double CharacterSpacing
			{
				get
				{
					return characterSpacing_;
				}
				set
				{
					characterSpacing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int ScriptLevel
			{
				get
				{
					return scriptLevel_;
				}
				set
				{
					scriptLevel_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TextFill TextFill
			{
				get
				{
					return textFill_;
				}
				set
				{
					textFill_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color HighlightColor
			{
				get
				{
					return highlightColor_;
				}
				set
				{
					highlightColor_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Stroke Stroke
			{
				get
				{
					return stroke_;
				}
				set
				{
					stroke_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Underline
			{
				get
				{
					return underline_;
				}
				set
				{
					underline_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color UnderlineColor
			{
				get
				{
					return underlineColor_;
				}
				set
				{
					underlineColor_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool StrikeThrough
			{
				get
				{
					return strikeThrough_;
				}
				set
				{
					strikeThrough_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.CapitalizationType CapitalizationType
			{
				get
				{
					return capitalizationType_;
				}
				set
				{
					capitalizationType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool TabularNumbers
			{
				get
				{
					return tabularNumbers_;
				}
				set
				{
					tabularNumbers_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool PreserveFillColor
			{
				get
				{
					return preserveFillColor_;
				}
				set
				{
					preserveFillColor_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Kerning
			{
				get
				{
					return kerning_;
				}
				set
				{
					kerning_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Ligatures
			{
				get
				{
					return ligatures_;
				}
				set
				{
					ligatures_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double FontScaleFactor
			{
				get
				{
					return fontScaleFactor_;
				}
				set
				{
					fontScaleFactor_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RunSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RunSettings(RunSettings other)
				: this()
			{
				font_ = ((other.font_ != null) ? other.font_.Clone() : null);
				characterSize_ = other.characterSize_;
				characterSizeMode_ = other.characterSizeMode_;
				characterSpacing_ = other.characterSpacing_;
				scriptLevel_ = other.scriptLevel_;
				textFill_ = ((other.textFill_ != null) ? other.textFill_.Clone() : null);
				highlightColor_ = ((other.highlightColor_ != null) ? other.highlightColor_.Clone() : null);
				stroke_ = ((other.stroke_ != null) ? other.stroke_.Clone() : null);
				underline_ = other.underline_;
				underlineColor_ = ((other.underlineColor_ != null) ? other.underlineColor_.Clone() : null);
				strikeThrough_ = other.strikeThrough_;
				capitalizationType_ = other.capitalizationType_;
				tabularNumbers_ = other.tabularNumbers_;
				preserveFillColor_ = other.preserveFillColor_;
				kerning_ = other.kerning_;
				ligatures_ = other.ligatures_;
				fontScaleFactor_ = other.fontScaleFactor_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RunSettings Clone()
			{
				return new RunSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as RunSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(RunSettings other)
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
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CharacterSize, other.CharacterSize))
				{
					return false;
				}
				if (CharacterSizeMode != other.CharacterSizeMode)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(CharacterSpacing, other.CharacterSpacing))
				{
					return false;
				}
				if (ScriptLevel != other.ScriptLevel)
				{
					return false;
				}
				if (!object.Equals(TextFill, other.TextFill))
				{
					return false;
				}
				if (!object.Equals(HighlightColor, other.HighlightColor))
				{
					return false;
				}
				if (!object.Equals(Stroke, other.Stroke))
				{
					return false;
				}
				if (Underline != other.Underline)
				{
					return false;
				}
				if (!object.Equals(UnderlineColor, other.UnderlineColor))
				{
					return false;
				}
				if (StrikeThrough != other.StrikeThrough)
				{
					return false;
				}
				if (CapitalizationType != other.CapitalizationType)
				{
					return false;
				}
				if (TabularNumbers != other.TabularNumbers)
				{
					return false;
				}
				if (PreserveFillColor != other.PreserveFillColor)
				{
					return false;
				}
				if (Kerning != other.Kerning)
				{
					return false;
				}
				if (Ligatures != other.Ligatures)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FontScaleFactor, other.FontScaleFactor))
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
				if (CharacterSize != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CharacterSize);
				}
				if (CharacterSizeMode != 0)
				{
					num ^= CharacterSizeMode.GetHashCode();
				}
				if (CharacterSpacing != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(CharacterSpacing);
				}
				if (ScriptLevel != 0)
				{
					num ^= ScriptLevel.GetHashCode();
				}
				if (textFill_ != null)
				{
					num ^= TextFill.GetHashCode();
				}
				if (highlightColor_ != null)
				{
					num ^= HighlightColor.GetHashCode();
				}
				if (stroke_ != null)
				{
					num ^= Stroke.GetHashCode();
				}
				if (Underline)
				{
					num ^= Underline.GetHashCode();
				}
				if (underlineColor_ != null)
				{
					num ^= UnderlineColor.GetHashCode();
				}
				if (StrikeThrough)
				{
					num ^= StrikeThrough.GetHashCode();
				}
				if (CapitalizationType != 0)
				{
					num ^= CapitalizationType.GetHashCode();
				}
				if (TabularNumbers)
				{
					num ^= TabularNumbers.GetHashCode();
				}
				if (PreserveFillColor)
				{
					num ^= PreserveFillColor.GetHashCode();
				}
				if (Kerning)
				{
					num ^= Kerning.GetHashCode();
				}
				if (Ligatures)
				{
					num ^= Ligatures.GetHashCode();
				}
				if (FontScaleFactor != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FontScaleFactor);
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
				if (CharacterSize != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(CharacterSize);
				}
				if (CharacterSizeMode != 0)
				{
					output.WriteRawTag(24);
					output.WriteEnum((int)CharacterSizeMode);
				}
				if (CharacterSpacing != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(CharacterSpacing);
				}
				if (ScriptLevel != 0)
				{
					output.WriteRawTag(40);
					output.WriteInt32(ScriptLevel);
				}
				if (textFill_ != null)
				{
					output.WriteRawTag(50);
					output.WriteMessage(TextFill);
				}
				if (highlightColor_ != null)
				{
					output.WriteRawTag(58);
					output.WriteMessage(HighlightColor);
				}
				if (stroke_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Stroke);
				}
				if (Underline)
				{
					output.WriteRawTag(72);
					output.WriteBool(Underline);
				}
				if (underlineColor_ != null)
				{
					output.WriteRawTag(82);
					output.WriteMessage(UnderlineColor);
				}
				if (StrikeThrough)
				{
					output.WriteRawTag(88);
					output.WriteBool(StrikeThrough);
				}
				if (CapitalizationType != 0)
				{
					output.WriteRawTag(96);
					output.WriteEnum((int)CapitalizationType);
				}
				if (TabularNumbers)
				{
					output.WriteRawTag(104);
					output.WriteBool(TabularNumbers);
				}
				if (PreserveFillColor)
				{
					output.WriteRawTag(112);
					output.WriteBool(PreserveFillColor);
				}
				if (Kerning)
				{
					output.WriteRawTag(120);
					output.WriteBool(Kerning);
				}
				if (Ligatures)
				{
					output.WriteRawTag(128, 1);
					output.WriteBool(Ligatures);
				}
				if (FontScaleFactor != 0.0)
				{
					output.WriteRawTag(137, 1);
					output.WriteDouble(FontScaleFactor);
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
				if (CharacterSize != 0.0)
				{
					num += 9;
				}
				if (CharacterSizeMode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)CharacterSizeMode);
				}
				if (CharacterSpacing != 0.0)
				{
					num += 9;
				}
				if (ScriptLevel != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(ScriptLevel);
				}
				if (textFill_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TextFill);
				}
				if (highlightColor_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(HighlightColor);
				}
				if (stroke_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Stroke);
				}
				if (Underline)
				{
					num += 2;
				}
				if (underlineColor_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UnderlineColor);
				}
				if (StrikeThrough)
				{
					num += 2;
				}
				if (CapitalizationType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)CapitalizationType);
				}
				if (TabularNumbers)
				{
					num += 2;
				}
				if (PreserveFillColor)
				{
					num += 2;
				}
				if (Kerning)
				{
					num += 2;
				}
				if (Ligatures)
				{
					num += 3;
				}
				if (FontScaleFactor != 0.0)
				{
					num += 10;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(RunSettings other)
			{
				if (other == null)
				{
					return;
				}
				if (other.font_ != null)
				{
					if (font_ == null)
					{
						Font = new FontInfo();
					}
					Font.MergeFrom(other.Font);
				}
				if (other.CharacterSize != 0.0)
				{
					CharacterSize = other.CharacterSize;
				}
				if (other.CharacterSizeMode != 0)
				{
					CharacterSizeMode = other.CharacterSizeMode;
				}
				if (other.CharacterSpacing != 0.0)
				{
					CharacterSpacing = other.CharacterSpacing;
				}
				if (other.ScriptLevel != 0)
				{
					ScriptLevel = other.ScriptLevel;
				}
				if (other.textFill_ != null)
				{
					if (textFill_ == null)
					{
						TextFill = new Types.TextFill();
					}
					TextFill.MergeFrom(other.TextFill);
				}
				if (other.highlightColor_ != null)
				{
					if (highlightColor_ == null)
					{
						HighlightColor = new Color();
					}
					HighlightColor.MergeFrom(other.HighlightColor);
				}
				if (other.stroke_ != null)
				{
					if (stroke_ == null)
					{
						Stroke = new Types.Stroke();
					}
					Stroke.MergeFrom(other.Stroke);
				}
				if (other.Underline)
				{
					Underline = other.Underline;
				}
				if (other.underlineColor_ != null)
				{
					if (underlineColor_ == null)
					{
						UnderlineColor = new Color();
					}
					UnderlineColor.MergeFrom(other.UnderlineColor);
				}
				if (other.StrikeThrough)
				{
					StrikeThrough = other.StrikeThrough;
				}
				if (other.CapitalizationType != 0)
				{
					CapitalizationType = other.CapitalizationType;
				}
				if (other.TabularNumbers)
				{
					TabularNumbers = other.TabularNumbers;
				}
				if (other.PreserveFillColor)
				{
					PreserveFillColor = other.PreserveFillColor;
				}
				if (other.Kerning)
				{
					Kerning = other.Kerning;
				}
				if (other.Ligatures)
				{
					Ligatures = other.Ligatures;
				}
				if (other.FontScaleFactor != 0.0)
				{
					FontScaleFactor = other.FontScaleFactor;
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
						if (font_ == null)
						{
							Font = new FontInfo();
						}
						input.ReadMessage(Font);
						break;
					case 17u:
						CharacterSize = input.ReadDouble();
						break;
					case 24u:
						CharacterSizeMode = (Types.CharacterSizeMode)input.ReadEnum();
						break;
					case 33u:
						CharacterSpacing = input.ReadDouble();
						break;
					case 40u:
						ScriptLevel = input.ReadInt32();
						break;
					case 50u:
						if (textFill_ == null)
						{
							TextFill = new Types.TextFill();
						}
						input.ReadMessage(TextFill);
						break;
					case 58u:
						if (highlightColor_ == null)
						{
							HighlightColor = new Color();
						}
						input.ReadMessage(HighlightColor);
						break;
					case 66u:
						if (stroke_ == null)
						{
							Stroke = new Types.Stroke();
						}
						input.ReadMessage(Stroke);
						break;
					case 72u:
						Underline = input.ReadBool();
						break;
					case 82u:
						if (underlineColor_ == null)
						{
							UnderlineColor = new Color();
						}
						input.ReadMessage(UnderlineColor);
						break;
					case 88u:
						StrikeThrough = input.ReadBool();
						break;
					case 96u:
						CapitalizationType = (Types.CapitalizationType)input.ReadEnum();
						break;
					case 104u:
						TabularNumbers = input.ReadBool();
						break;
					case 112u:
						PreserveFillColor = input.ReadBool();
						break;
					case 120u:
						Kerning = input.ReadBool();
						break;
					case 128u:
						Ligatures = input.ReadBool();
						break;
					case 137u:
						FontScaleFactor = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Run : IMessage<Run>, IMessage, IEquatable<Run>, IDeepCloneable<Run>
		{
			private static readonly MessageParser<Run> _parser = new MessageParser<Run>(() => new Run());

			private UnknownFieldSet _unknownFields;

			public const int RunSettingsFieldNumber = 1;

			private RunSettings runSettings_;

			public const int TextFieldNumber = 2;

			private string text_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Run> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[16];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RunSettings RunSettings
			{
				get
				{
					return runSettings_;
				}
				set
				{
					runSettings_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Text
			{
				get
				{
					return text_;
				}
				set
				{
					text_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Run()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Run(Run other)
				: this()
			{
				runSettings_ = ((other.runSettings_ != null) ? other.runSettings_.Clone() : null);
				text_ = other.text_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Run Clone()
			{
				return new Run(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Run);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Run other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(RunSettings, other.RunSettings))
				{
					return false;
				}
				if (Text != other.Text)
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
				if (runSettings_ != null)
				{
					num ^= RunSettings.GetHashCode();
				}
				if (Text.Length != 0)
				{
					num ^= Text.GetHashCode();
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
				if (runSettings_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(RunSettings);
				}
				if (Text.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Text);
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
				if (runSettings_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(RunSettings);
				}
				if (Text.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Text);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Run other)
			{
				if (other == null)
				{
					return;
				}
				if (other.runSettings_ != null)
				{
					if (runSettings_ == null)
					{
						RunSettings = new RunSettings();
					}
					RunSettings.MergeFrom(other.RunSettings);
				}
				if (other.Text.Length != 0)
				{
					Text = other.Text;
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
						if (runSettings_ == null)
						{
							RunSettings = new RunSettings();
						}
						input.ReadMessage(RunSettings);
						break;
					case 18u:
						Text = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Paragraph : IMessage<Paragraph>, IMessage, IEquatable<Paragraph>, IDeepCloneable<Paragraph>
		{
			private static readonly MessageParser<Paragraph> _parser = new MessageParser<Paragraph>(() => new Paragraph());

			private UnknownFieldSet _unknownFields;

			public const int ParagraphSettingsFieldNumber = 1;

			private ParagraphSettings paragraphSettings_;

			public const int RunsFieldNumber = 2;

			private static readonly FieldCodec<Run> _repeated_runs_codec = FieldCodec.ForMessage(18u, Run.Parser);

			private readonly RepeatedField<Run> runs_ = new RepeatedField<Run>();

			public const int DefaultRunSettingsFieldNumber = 3;

			private RunSettings defaultRunSettings_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Paragraph> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[17];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ParagraphSettings ParagraphSettings
			{
				get
				{
					return paragraphSettings_;
				}
				set
				{
					paragraphSettings_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Run> Runs => runs_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RunSettings DefaultRunSettings
			{
				get
				{
					return defaultRunSettings_;
				}
				set
				{
					defaultRunSettings_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Paragraph()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Paragraph(Paragraph other)
				: this()
			{
				paragraphSettings_ = ((other.paragraphSettings_ != null) ? other.paragraphSettings_.Clone() : null);
				runs_ = other.runs_.Clone();
				defaultRunSettings_ = ((other.defaultRunSettings_ != null) ? other.defaultRunSettings_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Paragraph Clone()
			{
				return new Paragraph(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Paragraph);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Paragraph other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(ParagraphSettings, other.ParagraphSettings))
				{
					return false;
				}
				if (!runs_.Equals(other.runs_))
				{
					return false;
				}
				if (!object.Equals(DefaultRunSettings, other.DefaultRunSettings))
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
				if (paragraphSettings_ != null)
				{
					num ^= ParagraphSettings.GetHashCode();
				}
				num ^= runs_.GetHashCode();
				if (defaultRunSettings_ != null)
				{
					num ^= DefaultRunSettings.GetHashCode();
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
				if (paragraphSettings_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(ParagraphSettings);
				}
				runs_.WriteTo(output, _repeated_runs_codec);
				if (defaultRunSettings_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(DefaultRunSettings);
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
				if (paragraphSettings_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ParagraphSettings);
				}
				num += runs_.CalculateSize(_repeated_runs_codec);
				if (defaultRunSettings_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(DefaultRunSettings);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Paragraph other)
			{
				if (other == null)
				{
					return;
				}
				if (other.paragraphSettings_ != null)
				{
					if (paragraphSettings_ == null)
					{
						ParagraphSettings = new ParagraphSettings();
					}
					ParagraphSettings.MergeFrom(other.ParagraphSettings);
				}
				runs_.Add(other.runs_);
				if (other.defaultRunSettings_ != null)
				{
					if (defaultRunSettings_ == null)
					{
						DefaultRunSettings = new RunSettings();
					}
					DefaultRunSettings.MergeFrom(other.DefaultRunSettings);
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
						if (paragraphSettings_ == null)
						{
							ParagraphSettings = new ParagraphSettings();
						}
						input.ReadMessage(ParagraphSettings);
						break;
					case 18u:
						runs_.AddEntriesFrom(input, _repeated_runs_codec);
						break;
					case 26u:
						if (defaultRunSettings_ == null)
						{
							DefaultRunSettings = new RunSettings();
						}
						input.ReadMessage(DefaultRunSettings);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DocumentAttributes : IMessage<DocumentAttributes>, IMessage, IEquatable<DocumentAttributes>, IDeepCloneable<DocumentAttributes>
		{
			private static readonly MessageParser<DocumentAttributes> _parser = new MessageParser<DocumentAttributes>(() => new DocumentAttributes());

			private UnknownFieldSet _unknownFields;

			public const int ParagraphSettingsFieldNumber = 1;

			private ParagraphSettings paragraphSettings_;

			public const int RunSettingsFieldNumber = 2;

			private RunSettings runSettings_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DocumentAttributes> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Document.Descriptor.NestedTypes[18];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ParagraphSettings ParagraphSettings
			{
				get
				{
					return paragraphSettings_;
				}
				set
				{
					paragraphSettings_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RunSettings RunSettings
			{
				get
				{
					return runSettings_;
				}
				set
				{
					runSettings_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentAttributes()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentAttributes(DocumentAttributes other)
				: this()
			{
				paragraphSettings_ = ((other.paragraphSettings_ != null) ? other.paragraphSettings_.Clone() : null);
				runSettings_ = ((other.runSettings_ != null) ? other.runSettings_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DocumentAttributes Clone()
			{
				return new DocumentAttributes(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DocumentAttributes);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DocumentAttributes other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(ParagraphSettings, other.ParagraphSettings))
				{
					return false;
				}
				if (!object.Equals(RunSettings, other.RunSettings))
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
				if (paragraphSettings_ != null)
				{
					num ^= ParagraphSettings.GetHashCode();
				}
				if (runSettings_ != null)
				{
					num ^= RunSettings.GetHashCode();
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
				if (paragraphSettings_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(ParagraphSettings);
				}
				if (runSettings_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(RunSettings);
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
				if (paragraphSettings_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ParagraphSettings);
				}
				if (runSettings_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(RunSettings);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DocumentAttributes other)
			{
				if (other == null)
				{
					return;
				}
				if (other.paragraphSettings_ != null)
				{
					if (paragraphSettings_ == null)
					{
						ParagraphSettings = new ParagraphSettings();
					}
					ParagraphSettings.MergeFrom(other.ParagraphSettings);
				}
				if (other.runSettings_ != null)
				{
					if (runSettings_ == null)
					{
						RunSettings = new RunSettings();
					}
					RunSettings.MergeFrom(other.RunSettings);
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
						if (paragraphSettings_ == null)
						{
							ParagraphSettings = new ParagraphSettings();
						}
						input.ReadMessage(ParagraphSettings);
						break;
					case 18u:
						if (runSettings_ == null)
						{
							RunSettings = new RunSettings();
						}
						input.ReadMessage(RunSettings);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Document> _parser = new MessageParser<Document>(() => new Document());

	private UnknownFieldSet _unknownFields;

	public const int DocumentSettingsFieldNumber = 1;

	private Types.DocumentSettings documentSettings_;

	public const int DocumentAttributesFieldNumber = 2;

	private Types.DocumentAttributes documentAttributes_;

	public const int ListSettingsFieldNumber = 3;

	private static readonly FieldCodec<Types.ListSettings> _repeated_listSettings_codec = FieldCodec.ForMessage(26u, Types.ListSettings.Parser);

	private readonly RepeatedField<Types.ListSettings> listSettings_ = new RepeatedField<Types.ListSettings>();

	public const int TableSettingsFieldNumber = 4;

	private Types.TableSettings tableSettings_;

	public const int ParagraphsFieldNumber = 5;

	private static readonly FieldCodec<Types.Paragraph> _repeated_paragraphs_codec = FieldCodec.ForMessage(42u, Types.Paragraph.Parser);

	private readonly RepeatedField<Types.Paragraph> paragraphs_ = new RepeatedField<Types.Paragraph>();

	public const int WidthFieldNumber = 6;

	private double width_;

	public const int HeightFieldNumber = 7;

	private double height_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Document> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TextdocReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DocumentSettings DocumentSettings
	{
		get
		{
			return documentSettings_;
		}
		set
		{
			documentSettings_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DocumentAttributes DocumentAttributes
	{
		get
		{
			return documentAttributes_;
		}
		set
		{
			documentAttributes_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.ListSettings> ListSettings => listSettings_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TableSettings TableSettings
	{
		get
		{
			return tableSettings_;
		}
		set
		{
			tableSettings_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Paragraph> Paragraphs => paragraphs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Width
	{
		get
		{
			return width_;
		}
		set
		{
			width_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Height
	{
		get
		{
			return height_;
		}
		set
		{
			height_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Document()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Document(Document other)
		: this()
	{
		documentSettings_ = ((other.documentSettings_ != null) ? other.documentSettings_.Clone() : null);
		documentAttributes_ = ((other.documentAttributes_ != null) ? other.documentAttributes_.Clone() : null);
		listSettings_ = other.listSettings_.Clone();
		tableSettings_ = ((other.tableSettings_ != null) ? other.tableSettings_.Clone() : null);
		paragraphs_ = other.paragraphs_.Clone();
		width_ = other.width_;
		height_ = other.height_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Document Clone()
	{
		return new Document(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Document);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Document other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(DocumentSettings, other.DocumentSettings))
		{
			return false;
		}
		if (!object.Equals(DocumentAttributes, other.DocumentAttributes))
		{
			return false;
		}
		if (!listSettings_.Equals(other.listSettings_))
		{
			return false;
		}
		if (!object.Equals(TableSettings, other.TableSettings))
		{
			return false;
		}
		if (!paragraphs_.Equals(other.paragraphs_))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Width, other.Width))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Height, other.Height))
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
		if (documentSettings_ != null)
		{
			num ^= DocumentSettings.GetHashCode();
		}
		if (documentAttributes_ != null)
		{
			num ^= DocumentAttributes.GetHashCode();
		}
		num ^= listSettings_.GetHashCode();
		if (tableSettings_ != null)
		{
			num ^= TableSettings.GetHashCode();
		}
		num ^= paragraphs_.GetHashCode();
		if (Width != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Width);
		}
		if (Height != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Height);
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
		if (documentSettings_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(DocumentSettings);
		}
		if (documentAttributes_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(DocumentAttributes);
		}
		listSettings_.WriteTo(output, _repeated_listSettings_codec);
		if (tableSettings_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(TableSettings);
		}
		paragraphs_.WriteTo(output, _repeated_paragraphs_codec);
		if (Width != 0.0)
		{
			output.WriteRawTag(49);
			output.WriteDouble(Width);
		}
		if (Height != 0.0)
		{
			output.WriteRawTag(57);
			output.WriteDouble(Height);
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
		if (documentSettings_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DocumentSettings);
		}
		if (documentAttributes_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DocumentAttributes);
		}
		num += listSettings_.CalculateSize(_repeated_listSettings_codec);
		if (tableSettings_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TableSettings);
		}
		num += paragraphs_.CalculateSize(_repeated_paragraphs_codec);
		if (Width != 0.0)
		{
			num += 9;
		}
		if (Height != 0.0)
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
	public void MergeFrom(Document other)
	{
		if (other == null)
		{
			return;
		}
		if (other.documentSettings_ != null)
		{
			if (documentSettings_ == null)
			{
				DocumentSettings = new Types.DocumentSettings();
			}
			DocumentSettings.MergeFrom(other.DocumentSettings);
		}
		if (other.documentAttributes_ != null)
		{
			if (documentAttributes_ == null)
			{
				DocumentAttributes = new Types.DocumentAttributes();
			}
			DocumentAttributes.MergeFrom(other.DocumentAttributes);
		}
		listSettings_.Add(other.listSettings_);
		if (other.tableSettings_ != null)
		{
			if (tableSettings_ == null)
			{
				TableSettings = new Types.TableSettings();
			}
			TableSettings.MergeFrom(other.TableSettings);
		}
		paragraphs_.Add(other.paragraphs_);
		if (other.Width != 0.0)
		{
			Width = other.Width;
		}
		if (other.Height != 0.0)
		{
			Height = other.Height;
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
				if (documentSettings_ == null)
				{
					DocumentSettings = new Types.DocumentSettings();
				}
				input.ReadMessage(DocumentSettings);
				break;
			case 18u:
				if (documentAttributes_ == null)
				{
					DocumentAttributes = new Types.DocumentAttributes();
				}
				input.ReadMessage(DocumentAttributes);
				break;
			case 26u:
				listSettings_.AddEntriesFrom(input, _repeated_listSettings_codec);
				break;
			case 34u:
				if (tableSettings_ == null)
				{
					TableSettings = new Types.TableSettings();
				}
				input.ReadMessage(TableSettings);
				break;
			case 42u:
				paragraphs_.AddEntriesFrom(input, _repeated_paragraphs_codec);
				break;
			case 49u:
				Width = input.ReadDouble();
				break;
			case 57u:
				Height = input.ReadDouble();
				break;
			}
		}
	}
}
