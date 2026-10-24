using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Graphics : IMessage<Graphics>, IMessage, IEquatable<Graphics>, IDeepCloneable<Graphics>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Element : IMessage<Element>, IMessage, IEquatable<Element>, IDeepCloneable<Element>
		{
			public enum MaskOneofCase
			{
				None = 0,
				TextLineMask = 14
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum FlipMode
				{
					[OriginalName("FLIP_MODE_NONE")]
					None,
					[OriginalName("FLIP_MODE_VERTICAL")]
					Vertical,
					[OriginalName("FLIP_MODE_HORIZONTAL")]
					Horizontal,
					[OriginalName("FLIP_MODE_BOTH")]
					Both
				}
			}

			private static readonly MessageParser<Element> _parser = new MessageParser<Element>(() => new Element());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int BoundsFieldNumber = 3;

			private Rect bounds_;

			public const int RotationFieldNumber = 4;

			private double rotation_;

			public const int OpacityFieldNumber = 5;

			private double opacity_;

			public const int LockedFieldNumber = 6;

			private bool locked_;

			public const int AspectRatioLockedFieldNumber = 7;

			private bool aspectRatioLocked_;

			public const int PathFieldNumber = 8;

			private Path path_;

			public const int FillFieldNumber = 9;

			private Fill fill_;

			public const int StrokeFieldNumber = 10;

			private Stroke stroke_;

			public const int ShadowFieldNumber = 11;

			private Shadow shadow_;

			public const int FeatherFieldNumber = 12;

			private Feather feather_;

			public const int TextFieldNumber = 13;

			private Text text_;

			public const int TextLineMaskFieldNumber = 14;

			public const int FlipModeFieldNumber = 15;

			private Types.FlipMode flipMode_;

			public const int HiddenFieldNumber = 16;

			private bool hidden_;

			private object mask_;

			private MaskOneofCase maskCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Element> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[0];

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
			public Rect Bounds
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
			public bool Locked
			{
				get
				{
					return locked_;
				}
				set
				{
					locked_ = value;
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
			public Path Path
			{
				get
				{
					return path_;
				}
				set
				{
					path_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Fill Fill
			{
				get
				{
					return fill_;
				}
				set
				{
					fill_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Stroke Stroke
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
			public Shadow Shadow
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
			public Feather Feather
			{
				get
				{
					return feather_;
				}
				set
				{
					feather_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Text Text
			{
				get
				{
					return text_;
				}
				set
				{
					text_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Text.Types.LineFillMask TextLineMask
			{
				get
				{
					if (maskCase_ != MaskOneofCase.TextLineMask)
					{
						return null;
					}
					return (Text.Types.LineFillMask)mask_;
				}
				set
				{
					mask_ = value;
					maskCase_ = ((value != null) ? MaskOneofCase.TextLineMask : MaskOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.FlipMode FlipMode
			{
				get
				{
					return flipMode_;
				}
				set
				{
					flipMode_ = value;
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MaskOneofCase MaskCase => maskCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Element()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Element(Element other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				bounds_ = ((other.bounds_ != null) ? other.bounds_.Clone() : null);
				rotation_ = other.rotation_;
				opacity_ = other.opacity_;
				locked_ = other.locked_;
				aspectRatioLocked_ = other.aspectRatioLocked_;
				path_ = ((other.path_ != null) ? other.path_.Clone() : null);
				fill_ = ((other.fill_ != null) ? other.fill_.Clone() : null);
				stroke_ = ((other.stroke_ != null) ? other.stroke_.Clone() : null);
				shadow_ = ((other.shadow_ != null) ? other.shadow_.Clone() : null);
				feather_ = ((other.feather_ != null) ? other.feather_.Clone() : null);
				text_ = ((other.text_ != null) ? other.text_.Clone() : null);
				flipMode_ = other.flipMode_;
				hidden_ = other.hidden_;
				if (other.MaskCase == MaskOneofCase.TextLineMask)
				{
					TextLineMask = other.TextLineMask.Clone();
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Element Clone()
			{
				return new Element(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearMask()
			{
				maskCase_ = MaskOneofCase.None;
				mask_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Element);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Element other)
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
				if (!object.Equals(Bounds, other.Bounds))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Rotation, other.Rotation))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Opacity, other.Opacity))
				{
					return false;
				}
				if (Locked != other.Locked)
				{
					return false;
				}
				if (AspectRatioLocked != other.AspectRatioLocked)
				{
					return false;
				}
				if (!object.Equals(Path, other.Path))
				{
					return false;
				}
				if (!object.Equals(Fill, other.Fill))
				{
					return false;
				}
				if (!object.Equals(Stroke, other.Stroke))
				{
					return false;
				}
				if (!object.Equals(Shadow, other.Shadow))
				{
					return false;
				}
				if (!object.Equals(Feather, other.Feather))
				{
					return false;
				}
				if (!object.Equals(Text, other.Text))
				{
					return false;
				}
				if (!object.Equals(TextLineMask, other.TextLineMask))
				{
					return false;
				}
				if (FlipMode != other.FlipMode)
				{
					return false;
				}
				if (Hidden != other.Hidden)
				{
					return false;
				}
				if (MaskCase != other.MaskCase)
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
				if (bounds_ != null)
				{
					num ^= Bounds.GetHashCode();
				}
				if (Rotation != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Rotation);
				}
				if (Opacity != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Opacity);
				}
				if (Locked)
				{
					num ^= Locked.GetHashCode();
				}
				if (AspectRatioLocked)
				{
					num ^= AspectRatioLocked.GetHashCode();
				}
				if (path_ != null)
				{
					num ^= Path.GetHashCode();
				}
				if (fill_ != null)
				{
					num ^= Fill.GetHashCode();
				}
				if (stroke_ != null)
				{
					num ^= Stroke.GetHashCode();
				}
				if (shadow_ != null)
				{
					num ^= Shadow.GetHashCode();
				}
				if (feather_ != null)
				{
					num ^= Feather.GetHashCode();
				}
				if (text_ != null)
				{
					num ^= Text.GetHashCode();
				}
				if (maskCase_ == MaskOneofCase.TextLineMask)
				{
					num ^= TextLineMask.GetHashCode();
				}
				if (FlipMode != 0)
				{
					num ^= FlipMode.GetHashCode();
				}
				if (Hidden)
				{
					num ^= Hidden.GetHashCode();
				}
				num ^= (int)maskCase_;
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
				if (bounds_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Bounds);
				}
				if (Rotation != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(Rotation);
				}
				if (Opacity != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(Opacity);
				}
				if (Locked)
				{
					output.WriteRawTag(48);
					output.WriteBool(Locked);
				}
				if (AspectRatioLocked)
				{
					output.WriteRawTag(56);
					output.WriteBool(AspectRatioLocked);
				}
				if (path_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Path);
				}
				if (fill_ != null)
				{
					output.WriteRawTag(74);
					output.WriteMessage(Fill);
				}
				if (stroke_ != null)
				{
					output.WriteRawTag(82);
					output.WriteMessage(Stroke);
				}
				if (shadow_ != null)
				{
					output.WriteRawTag(90);
					output.WriteMessage(Shadow);
				}
				if (feather_ != null)
				{
					output.WriteRawTag(98);
					output.WriteMessage(Feather);
				}
				if (text_ != null)
				{
					output.WriteRawTag(106);
					output.WriteMessage(Text);
				}
				if (maskCase_ == MaskOneofCase.TextLineMask)
				{
					output.WriteRawTag(114);
					output.WriteMessage(TextLineMask);
				}
				if (FlipMode != 0)
				{
					output.WriteRawTag(120);
					output.WriteEnum((int)FlipMode);
				}
				if (Hidden)
				{
					output.WriteRawTag(128, 1);
					output.WriteBool(Hidden);
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
				if (bounds_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Bounds);
				}
				if (Rotation != 0.0)
				{
					num += 9;
				}
				if (Opacity != 0.0)
				{
					num += 9;
				}
				if (Locked)
				{
					num += 2;
				}
				if (AspectRatioLocked)
				{
					num += 2;
				}
				if (path_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Path);
				}
				if (fill_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Fill);
				}
				if (stroke_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Stroke);
				}
				if (shadow_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Shadow);
				}
				if (feather_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Feather);
				}
				if (text_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Text);
				}
				if (maskCase_ == MaskOneofCase.TextLineMask)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TextLineMask);
				}
				if (FlipMode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)FlipMode);
				}
				if (Hidden)
				{
					num += 3;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Element other)
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
				if (other.bounds_ != null)
				{
					if (bounds_ == null)
					{
						Bounds = new Rect();
					}
					Bounds.MergeFrom(other.Bounds);
				}
				if (other.Rotation != 0.0)
				{
					Rotation = other.Rotation;
				}
				if (other.Opacity != 0.0)
				{
					Opacity = other.Opacity;
				}
				if (other.Locked)
				{
					Locked = other.Locked;
				}
				if (other.AspectRatioLocked)
				{
					AspectRatioLocked = other.AspectRatioLocked;
				}
				if (other.path_ != null)
				{
					if (path_ == null)
					{
						Path = new Path();
					}
					Path.MergeFrom(other.Path);
				}
				if (other.fill_ != null)
				{
					if (fill_ == null)
					{
						Fill = new Fill();
					}
					Fill.MergeFrom(other.Fill);
				}
				if (other.stroke_ != null)
				{
					if (stroke_ == null)
					{
						Stroke = new Stroke();
					}
					Stroke.MergeFrom(other.Stroke);
				}
				if (other.shadow_ != null)
				{
					if (shadow_ == null)
					{
						Shadow = new Shadow();
					}
					Shadow.MergeFrom(other.Shadow);
				}
				if (other.feather_ != null)
				{
					if (feather_ == null)
					{
						Feather = new Feather();
					}
					Feather.MergeFrom(other.Feather);
				}
				if (other.text_ != null)
				{
					if (text_ == null)
					{
						Text = new Text();
					}
					Text.MergeFrom(other.Text);
				}
				if (other.FlipMode != 0)
				{
					FlipMode = other.FlipMode;
				}
				if (other.Hidden)
				{
					Hidden = other.Hidden;
				}
				if (other.MaskCase == MaskOneofCase.TextLineMask)
				{
					if (TextLineMask == null)
					{
						TextLineMask = new Text.Types.LineFillMask();
					}
					TextLineMask.MergeFrom(other.TextLineMask);
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
						if (bounds_ == null)
						{
							Bounds = new Rect();
						}
						input.ReadMessage(Bounds);
						break;
					case 33u:
						Rotation = input.ReadDouble();
						break;
					case 41u:
						Opacity = input.ReadDouble();
						break;
					case 48u:
						Locked = input.ReadBool();
						break;
					case 56u:
						AspectRatioLocked = input.ReadBool();
						break;
					case 66u:
						if (path_ == null)
						{
							Path = new Path();
						}
						input.ReadMessage(Path);
						break;
					case 74u:
						if (fill_ == null)
						{
							Fill = new Fill();
						}
						input.ReadMessage(Fill);
						break;
					case 82u:
						if (stroke_ == null)
						{
							Stroke = new Stroke();
						}
						input.ReadMessage(Stroke);
						break;
					case 90u:
						if (shadow_ == null)
						{
							Shadow = new Shadow();
						}
						input.ReadMessage(Shadow);
						break;
					case 98u:
						if (feather_ == null)
						{
							Feather = new Feather();
						}
						input.ReadMessage(Feather);
						break;
					case 106u:
						if (text_ == null)
						{
							Text = new Text();
						}
						input.ReadMessage(Text);
						break;
					case 114u:
					{
						Text.Types.LineFillMask lineFillMask = new Text.Types.LineFillMask();
						if (maskCase_ == MaskOneofCase.TextLineMask)
						{
							lineFillMask.MergeFrom(TextLineMask);
						}
						input.ReadMessage(lineFillMask);
						TextLineMask = lineFillMask;
						break;
					}
					case 120u:
						FlipMode = (Types.FlipMode)input.ReadEnum();
						break;
					case 128u:
						Hidden = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Rect : IMessage<Rect>, IMessage, IEquatable<Rect>, IDeepCloneable<Rect>
		{
			private static readonly MessageParser<Rect> _parser = new MessageParser<Rect>(() => new Rect());

			private UnknownFieldSet _unknownFields;

			public const int OriginFieldNumber = 1;

			private Point origin_;

			public const int SizeFieldNumber = 2;

			private Size size_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Rect> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Point Origin
			{
				get
				{
					return origin_;
				}
				set
				{
					origin_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Size Size
			{
				get
				{
					return size_;
				}
				set
				{
					size_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Rect()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Rect(Rect other)
				: this()
			{
				origin_ = ((other.origin_ != null) ? other.origin_.Clone() : null);
				size_ = ((other.size_ != null) ? other.size_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Rect Clone()
			{
				return new Rect(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Rect);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Rect other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Origin, other.Origin))
				{
					return false;
				}
				if (!object.Equals(Size, other.Size))
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
				if (origin_ != null)
				{
					num ^= Origin.GetHashCode();
				}
				if (size_ != null)
				{
					num ^= Size.GetHashCode();
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
				if (origin_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Origin);
				}
				if (size_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Size);
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
				if (origin_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Origin);
				}
				if (size_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Size);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Rect other)
			{
				if (other == null)
				{
					return;
				}
				if (other.origin_ != null)
				{
					if (origin_ == null)
					{
						Origin = new Point();
					}
					Origin.MergeFrom(other.Origin);
				}
				if (other.size_ != null)
				{
					if (size_ == null)
					{
						Size = new Size();
					}
					Size.MergeFrom(other.Size);
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
						if (origin_ == null)
						{
							Origin = new Point();
						}
						input.ReadMessage(Origin);
						break;
					case 18u:
						if (size_ == null)
						{
							Size = new Size();
						}
						input.ReadMessage(Size);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Point : IMessage<Point>, IMessage, IEquatable<Point>, IDeepCloneable<Point>
		{
			private static readonly MessageParser<Point> _parser = new MessageParser<Point>(() => new Point());

			private UnknownFieldSet _unknownFields;

			public const int XFieldNumber = 1;

			private double x_;

			public const int YFieldNumber = 2;

			private double y_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Point> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double X
			{
				get
				{
					return x_;
				}
				set
				{
					x_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Y
			{
				get
				{
					return y_;
				}
				set
				{
					y_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Point()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Point(Point other)
				: this()
			{
				x_ = other.x_;
				y_ = other.y_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Point Clone()
			{
				return new Point(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Point);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Point other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(X, other.X))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Y, other.Y))
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
				if (X != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(X);
				}
				if (Y != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Y);
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
				if (X != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(X);
				}
				if (Y != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Y);
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
				if (X != 0.0)
				{
					num += 9;
				}
				if (Y != 0.0)
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
			public void MergeFrom(Point other)
			{
				if (other != null)
				{
					if (other.X != 0.0)
					{
						X = other.X;
					}
					if (other.Y != 0.0)
					{
						Y = other.Y;
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
						X = input.ReadDouble();
						break;
					case 17u:
						Y = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Size : IMessage<Size>, IMessage, IEquatable<Size>, IDeepCloneable<Size>
		{
			private static readonly MessageParser<Size> _parser = new MessageParser<Size>(() => new Size());

			private UnknownFieldSet _unknownFields;

			public const int WidthFieldNumber = 1;

			private double width_;

			public const int HeightFieldNumber = 2;

			private double height_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Size> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public Size()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Size(Size other)
				: this()
			{
				width_ = other.width_;
				height_ = other.height_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Size Clone()
			{
				return new Size(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Size);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Size other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
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
				if (Width != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Width);
				}
				if (Height != 0.0)
				{
					output.WriteRawTag(17);
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
			public void MergeFrom(Size other)
			{
				if (other != null)
				{
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
						Width = input.ReadDouble();
						break;
					case 17u:
						Height = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EdgeInsets : IMessage<EdgeInsets>, IMessage, IEquatable<EdgeInsets>, IDeepCloneable<EdgeInsets>
		{
			private static readonly MessageParser<EdgeInsets> _parser = new MessageParser<EdgeInsets>(() => new EdgeInsets());

			private UnknownFieldSet _unknownFields;

			public const int LeftFieldNumber = 1;

			private double left_;

			public const int RightFieldNumber = 2;

			private double right_;

			public const int TopFieldNumber = 3;

			private double top_;

			public const int BottomFieldNumber = 4;

			private double bottom_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EdgeInsets> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[4];

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
			public EdgeInsets()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EdgeInsets(EdgeInsets other)
				: this()
			{
				left_ = other.left_;
				right_ = other.right_;
				top_ = other.top_;
				bottom_ = other.bottom_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EdgeInsets Clone()
			{
				return new EdgeInsets(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EdgeInsets);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EdgeInsets other)
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
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Right, other.Right))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Top, other.Top))
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
				if (Right != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Right);
				}
				if (Top != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Top);
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
				if (Right != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Right);
				}
				if (Top != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(Top);
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
				if (Right != 0.0)
				{
					num += 9;
				}
				if (Top != 0.0)
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
			public void MergeFrom(EdgeInsets other)
			{
				if (other != null)
				{
					if (other.Left != 0.0)
					{
						Left = other.Left;
					}
					if (other.Right != 0.0)
					{
						Right = other.Right;
					}
					if (other.Top != 0.0)
					{
						Top = other.Top;
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
						Right = input.ReadDouble();
						break;
					case 25u:
						Top = input.ReadDouble();
						break;
					case 33u:
						Bottom = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Path : IMessage<Path>, IMessage, IEquatable<Path>, IDeepCloneable<Path>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class BezierPoint : IMessage<BezierPoint>, IMessage, IEquatable<BezierPoint>, IDeepCloneable<BezierPoint>
				{
					private static readonly MessageParser<BezierPoint> _parser = new MessageParser<BezierPoint>(() => new BezierPoint());

					private UnknownFieldSet _unknownFields;

					public const int PointFieldNumber = 1;

					private Point point_;

					public const int Q0FieldNumber = 2;

					private Point q0_;

					public const int Q1FieldNumber = 3;

					private Point q1_;

					public const int CurvedFieldNumber = 4;

					private bool curved_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<BezierPoint> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Path.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Point Point
					{
						get
						{
							return point_;
						}
						set
						{
							point_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Point Q0
					{
						get
						{
							return q0_;
						}
						set
						{
							q0_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Point Q1
					{
						get
						{
							return q1_;
						}
						set
						{
							q1_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Curved
					{
						get
						{
							return curved_;
						}
						set
						{
							curved_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BezierPoint()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BezierPoint(BezierPoint other)
						: this()
					{
						point_ = ((other.point_ != null) ? other.point_.Clone() : null);
						q0_ = ((other.q0_ != null) ? other.q0_.Clone() : null);
						q1_ = ((other.q1_ != null) ? other.q1_.Clone() : null);
						curved_ = other.curved_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BezierPoint Clone()
					{
						return new BezierPoint(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as BezierPoint);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(BezierPoint other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Point, other.Point))
						{
							return false;
						}
						if (!object.Equals(Q0, other.Q0))
						{
							return false;
						}
						if (!object.Equals(Q1, other.Q1))
						{
							return false;
						}
						if (Curved != other.Curved)
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
						if (point_ != null)
						{
							num ^= Point.GetHashCode();
						}
						if (q0_ != null)
						{
							num ^= Q0.GetHashCode();
						}
						if (q1_ != null)
						{
							num ^= Q1.GetHashCode();
						}
						if (Curved)
						{
							num ^= Curved.GetHashCode();
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
						if (point_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Point);
						}
						if (q0_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Q0);
						}
						if (q1_ != null)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Q1);
						}
						if (Curved)
						{
							output.WriteRawTag(32);
							output.WriteBool(Curved);
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
						if (point_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Point);
						}
						if (q0_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Q0);
						}
						if (q1_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Q1);
						}
						if (Curved)
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
					public void MergeFrom(BezierPoint other)
					{
						if (other == null)
						{
							return;
						}
						if (other.point_ != null)
						{
							if (point_ == null)
							{
								Point = new Point();
							}
							Point.MergeFrom(other.Point);
						}
						if (other.q0_ != null)
						{
							if (q0_ == null)
							{
								Q0 = new Point();
							}
							Q0.MergeFrom(other.Q0);
						}
						if (other.q1_ != null)
						{
							if (q1_ == null)
							{
								Q1 = new Point();
							}
							Q1.MergeFrom(other.Q1);
						}
						if (other.Curved)
						{
							Curved = other.Curved;
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
								if (point_ == null)
								{
									Point = new Point();
								}
								input.ReadMessage(Point);
								break;
							case 18u:
								if (q0_ == null)
								{
									Q0 = new Point();
								}
								input.ReadMessage(Q0);
								break;
							case 26u:
								if (q1_ == null)
								{
									Q1 = new Point();
								}
								input.ReadMessage(Q1);
								break;
							case 32u:
								Curved = input.ReadBool();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Shape : IMessage<Shape>, IMessage, IEquatable<Shape>, IDeepCloneable<Shape>
				{
					public enum AdditionalDataOneofCase
					{
						None = 0,
						RoundedRectangle = 2,
						Polygon = 3,
						Star = 4,
						Arrow = 5
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Type
						{
							[OriginalName("TYPE_UNKNOWN")]
							Unknown,
							[OriginalName("TYPE_RECTANGLE")]
							Rectangle,
							[OriginalName("TYPE_ELLIPSE")]
							Ellipse,
							[OriginalName("TYPE_ISOSCELES_TRIANGLE")]
							IsoscelesTriangle,
							[OriginalName("TYPE_RIGHT_TRIANGLE")]
							RightTriangle,
							[OriginalName("TYPE_RHOMBUS")]
							Rhombus,
							[OriginalName("TYPE_STAR")]
							Star,
							[OriginalName("TYPE_POLYGON")]
							Polygon,
							[OriginalName("TYPE_CUSTOM")]
							Custom,
							[OriginalName("TYPE_RIGHT_ARROW")]
							RightArrow,
							[OriginalName("TYPE_DOUBLE_ARROW")]
							DoubleArrow,
							[OriginalName("TYPE_ROUNDED_RECTANGLE")]
							RoundedRectangle
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class RoundedRectangle : IMessage<RoundedRectangle>, IMessage, IEquatable<RoundedRectangle>, IDeepCloneable<RoundedRectangle>
						{
							private static readonly MessageParser<RoundedRectangle> _parser = new MessageParser<RoundedRectangle>(() => new RoundedRectangle());

							private UnknownFieldSet _unknownFields;

							public const int RoundnessFieldNumber = 1;

							private double roundness_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<RoundedRectangle> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Shape.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double Roundness
							{
								get
								{
									return roundness_;
								}
								set
								{
									roundness_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RoundedRectangle()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RoundedRectangle(RoundedRectangle other)
								: this()
							{
								roundness_ = other.roundness_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RoundedRectangle Clone()
							{
								return new RoundedRectangle(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as RoundedRectangle);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(RoundedRectangle other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Roundness, other.Roundness))
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
								if (Roundness != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Roundness);
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
								if (Roundness != 0.0)
								{
									output.WriteRawTag(9);
									output.WriteDouble(Roundness);
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
								if (Roundness != 0.0)
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
							public void MergeFrom(RoundedRectangle other)
							{
								if (other != null)
								{
									if (other.Roundness != 0.0)
									{
										Roundness = other.Roundness;
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
										Roundness = input.ReadDouble();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Arrow : IMessage<Arrow>, IMessage, IEquatable<Arrow>, IDeepCloneable<Arrow>
						{
							private static readonly MessageParser<Arrow> _parser = new MessageParser<Arrow>(() => new Arrow());

							private UnknownFieldSet _unknownFields;

							public const int CornerFieldNumber = 1;

							private Point corner_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Arrow> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Shape.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Point Corner
							{
								get
								{
									return corner_;
								}
								set
								{
									corner_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Arrow()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Arrow(Arrow other)
								: this()
							{
								corner_ = ((other.corner_ != null) ? other.corner_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Arrow Clone()
							{
								return new Arrow(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Arrow);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Arrow other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Corner, other.Corner))
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
								if (corner_ != null)
								{
									num ^= Corner.GetHashCode();
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
								if (corner_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Corner);
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
								if (corner_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Corner);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Arrow other)
							{
								if (other == null)
								{
									return;
								}
								if (other.corner_ != null)
								{
									if (corner_ == null)
									{
										Corner = new Point();
									}
									Corner.MergeFrom(other.Corner);
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
									if (corner_ == null)
									{
										Corner = new Point();
									}
									input.ReadMessage(Corner);
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Polygon : IMessage<Polygon>, IMessage, IEquatable<Polygon>, IDeepCloneable<Polygon>
						{
							private static readonly MessageParser<Polygon> _parser = new MessageParser<Polygon>(() => new Polygon());

							private UnknownFieldSet _unknownFields;

							public const int NumberSidesFieldNumber = 1;

							private uint numberSides_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Polygon> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Shape.Descriptor.NestedTypes[2];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public uint NumberSides
							{
								get
								{
									return numberSides_;
								}
								set
								{
									numberSides_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Polygon()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Polygon(Polygon other)
								: this()
							{
								numberSides_ = other.numberSides_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Polygon Clone()
							{
								return new Polygon(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Polygon);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Polygon other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (NumberSides != other.NumberSides)
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
								if (NumberSides != 0)
								{
									num ^= NumberSides.GetHashCode();
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
								if (NumberSides != 0)
								{
									output.WriteRawTag(8);
									output.WriteUInt32(NumberSides);
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
								if (NumberSides != 0)
								{
									num += 1 + CodedOutputStream.ComputeUInt32Size(NumberSides);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Polygon other)
							{
								if (other != null)
								{
									if (other.NumberSides != 0)
									{
										NumberSides = other.NumberSides;
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
										NumberSides = input.ReadUInt32();
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Star : IMessage<Star>, IMessage, IEquatable<Star>, IDeepCloneable<Star>
						{
							private static readonly MessageParser<Star> _parser = new MessageParser<Star>(() => new Star());

							private UnknownFieldSet _unknownFields;

							public const int InnerRadiusFieldNumber = 1;

							private double innerRadius_;

							public const int NumberPointsFieldNumber = 2;

							private uint numberPoints_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Star> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Shape.Descriptor.NestedTypes[3];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double InnerRadius
							{
								get
								{
									return innerRadius_;
								}
								set
								{
									innerRadius_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public uint NumberPoints
							{
								get
								{
									return numberPoints_;
								}
								set
								{
									numberPoints_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Star()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Star(Star other)
								: this()
							{
								innerRadius_ = other.innerRadius_;
								numberPoints_ = other.numberPoints_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Star Clone()
							{
								return new Star(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Star);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Star other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(InnerRadius, other.InnerRadius))
								{
									return false;
								}
								if (NumberPoints != other.NumberPoints)
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
								if (InnerRadius != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(InnerRadius);
								}
								if (NumberPoints != 0)
								{
									num ^= NumberPoints.GetHashCode();
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
								if (InnerRadius != 0.0)
								{
									output.WriteRawTag(9);
									output.WriteDouble(InnerRadius);
								}
								if (NumberPoints != 0)
								{
									output.WriteRawTag(16);
									output.WriteUInt32(NumberPoints);
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
								if (InnerRadius != 0.0)
								{
									num += 9;
								}
								if (NumberPoints != 0)
								{
									num += 1 + CodedOutputStream.ComputeUInt32Size(NumberPoints);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Star other)
							{
								if (other != null)
								{
									if (other.InnerRadius != 0.0)
									{
										InnerRadius = other.InnerRadius;
									}
									if (other.NumberPoints != 0)
									{
										NumberPoints = other.NumberPoints;
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
										InnerRadius = input.ReadDouble();
										break;
									case 16u:
										NumberPoints = input.ReadUInt32();
										break;
									}
								}
							}
						}
					}

					private static readonly MessageParser<Shape> _parser = new MessageParser<Shape>(() => new Shape());

					private UnknownFieldSet _unknownFields;

					public const int TypeFieldNumber = 1;

					private Types.Type type_;

					public const int RoundedRectangleFieldNumber = 2;

					public const int PolygonFieldNumber = 3;

					public const int StarFieldNumber = 4;

					public const int ArrowFieldNumber = 5;

					private object additionalData_;

					private AdditionalDataOneofCase additionalDataCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Shape> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Path.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Type Type
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
					public Types.RoundedRectangle RoundedRectangle
					{
						get
						{
							if (additionalDataCase_ != AdditionalDataOneofCase.RoundedRectangle)
							{
								return null;
							}
							return (Types.RoundedRectangle)additionalData_;
						}
						set
						{
							additionalData_ = value;
							additionalDataCase_ = ((value != null) ? AdditionalDataOneofCase.RoundedRectangle : AdditionalDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Polygon Polygon
					{
						get
						{
							if (additionalDataCase_ != AdditionalDataOneofCase.Polygon)
							{
								return null;
							}
							return (Types.Polygon)additionalData_;
						}
						set
						{
							additionalData_ = value;
							additionalDataCase_ = ((value != null) ? AdditionalDataOneofCase.Polygon : AdditionalDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Star Star
					{
						get
						{
							if (additionalDataCase_ != AdditionalDataOneofCase.Star)
							{
								return null;
							}
							return (Types.Star)additionalData_;
						}
						set
						{
							additionalData_ = value;
							additionalDataCase_ = ((value != null) ? AdditionalDataOneofCase.Star : AdditionalDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Arrow Arrow
					{
						get
						{
							if (additionalDataCase_ != AdditionalDataOneofCase.Arrow)
							{
								return null;
							}
							return (Types.Arrow)additionalData_;
						}
						set
						{
							additionalData_ = value;
							additionalDataCase_ = ((value != null) ? AdditionalDataOneofCase.Arrow : AdditionalDataOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AdditionalDataOneofCase AdditionalDataCase => additionalDataCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Shape()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Shape(Shape other)
						: this()
					{
						type_ = other.type_;
						switch (other.AdditionalDataCase)
						{
						case AdditionalDataOneofCase.RoundedRectangle:
							RoundedRectangle = other.RoundedRectangle.Clone();
							break;
						case AdditionalDataOneofCase.Polygon:
							Polygon = other.Polygon.Clone();
							break;
						case AdditionalDataOneofCase.Star:
							Star = other.Star.Clone();
							break;
						case AdditionalDataOneofCase.Arrow:
							Arrow = other.Arrow.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Shape Clone()
					{
						return new Shape(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearAdditionalData()
					{
						additionalDataCase_ = AdditionalDataOneofCase.None;
						additionalData_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Shape);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Shape other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Type != other.Type)
						{
							return false;
						}
						if (!object.Equals(RoundedRectangle, other.RoundedRectangle))
						{
							return false;
						}
						if (!object.Equals(Polygon, other.Polygon))
						{
							return false;
						}
						if (!object.Equals(Star, other.Star))
						{
							return false;
						}
						if (!object.Equals(Arrow, other.Arrow))
						{
							return false;
						}
						if (AdditionalDataCase != other.AdditionalDataCase)
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
						if (Type != 0)
						{
							num ^= Type.GetHashCode();
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.RoundedRectangle)
						{
							num ^= RoundedRectangle.GetHashCode();
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Polygon)
						{
							num ^= Polygon.GetHashCode();
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Star)
						{
							num ^= Star.GetHashCode();
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Arrow)
						{
							num ^= Arrow.GetHashCode();
						}
						num ^= (int)additionalDataCase_;
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
						if (Type != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Type);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.RoundedRectangle)
						{
							output.WriteRawTag(18);
							output.WriteMessage(RoundedRectangle);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Polygon)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Polygon);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Star)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Star);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Arrow)
						{
							output.WriteRawTag(42);
							output.WriteMessage(Arrow);
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
						if (Type != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.RoundedRectangle)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(RoundedRectangle);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Polygon)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Polygon);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Star)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Star);
						}
						if (additionalDataCase_ == AdditionalDataOneofCase.Arrow)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Arrow);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Shape other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Type != 0)
						{
							Type = other.Type;
						}
						switch (other.AdditionalDataCase)
						{
						case AdditionalDataOneofCase.RoundedRectangle:
							if (RoundedRectangle == null)
							{
								RoundedRectangle = new Types.RoundedRectangle();
							}
							RoundedRectangle.MergeFrom(other.RoundedRectangle);
							break;
						case AdditionalDataOneofCase.Polygon:
							if (Polygon == null)
							{
								Polygon = new Types.Polygon();
							}
							Polygon.MergeFrom(other.Polygon);
							break;
						case AdditionalDataOneofCase.Star:
							if (Star == null)
							{
								Star = new Types.Star();
							}
							Star.MergeFrom(other.Star);
							break;
						case AdditionalDataOneofCase.Arrow:
							if (Arrow == null)
							{
								Arrow = new Types.Arrow();
							}
							Arrow.MergeFrom(other.Arrow);
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
								Type = (Types.Type)input.ReadEnum();
								break;
							case 18u:
							{
								Types.RoundedRectangle roundedRectangle = new Types.RoundedRectangle();
								if (additionalDataCase_ == AdditionalDataOneofCase.RoundedRectangle)
								{
									roundedRectangle.MergeFrom(RoundedRectangle);
								}
								input.ReadMessage(roundedRectangle);
								RoundedRectangle = roundedRectangle;
								break;
							}
							case 26u:
							{
								Types.Polygon polygon = new Types.Polygon();
								if (additionalDataCase_ == AdditionalDataOneofCase.Polygon)
								{
									polygon.MergeFrom(Polygon);
								}
								input.ReadMessage(polygon);
								Polygon = polygon;
								break;
							}
							case 34u:
							{
								Types.Star star = new Types.Star();
								if (additionalDataCase_ == AdditionalDataOneofCase.Star)
								{
									star.MergeFrom(Star);
								}
								input.ReadMessage(star);
								Star = star;
								break;
							}
							case 42u:
							{
								Types.Arrow arrow = new Types.Arrow();
								if (additionalDataCase_ == AdditionalDataOneofCase.Arrow)
								{
									arrow.MergeFrom(Arrow);
								}
								input.ReadMessage(arrow);
								Arrow = arrow;
								break;
							}
							}
						}
					}
				}
			}

			private static readonly MessageParser<Path> _parser = new MessageParser<Path>(() => new Path());

			private UnknownFieldSet _unknownFields;

			public const int ClosedFieldNumber = 1;

			private bool closed_;

			public const int PointsFieldNumber = 2;

			private static readonly FieldCodec<Types.BezierPoint> _repeated_points_codec = FieldCodec.ForMessage(18u, Types.BezierPoint.Parser);

			private readonly RepeatedField<Types.BezierPoint> points_ = new RepeatedField<Types.BezierPoint>();

			public const int ShapeFieldNumber = 3;

			private Types.Shape shape_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Path> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Closed
			{
				get
				{
					return closed_;
				}
				set
				{
					closed_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.BezierPoint> Points => points_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Shape Shape
			{
				get
				{
					return shape_;
				}
				set
				{
					shape_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Path()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Path(Path other)
				: this()
			{
				closed_ = other.closed_;
				points_ = other.points_.Clone();
				shape_ = ((other.shape_ != null) ? other.shape_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Path Clone()
			{
				return new Path(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Path);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Path other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Closed != other.Closed)
				{
					return false;
				}
				if (!points_.Equals(other.points_))
				{
					return false;
				}
				if (!object.Equals(Shape, other.Shape))
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
				if (Closed)
				{
					num ^= Closed.GetHashCode();
				}
				num ^= points_.GetHashCode();
				if (shape_ != null)
				{
					num ^= Shape.GetHashCode();
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
				if (Closed)
				{
					output.WriteRawTag(8);
					output.WriteBool(Closed);
				}
				points_.WriteTo(output, _repeated_points_codec);
				if (shape_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Shape);
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
				if (Closed)
				{
					num += 2;
				}
				num += points_.CalculateSize(_repeated_points_codec);
				if (shape_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Shape);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Path other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Closed)
				{
					Closed = other.Closed;
				}
				points_.Add(other.points_);
				if (other.shape_ != null)
				{
					if (shape_ == null)
					{
						Shape = new Types.Shape();
					}
					Shape.MergeFrom(other.Shape);
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
						Closed = input.ReadBool();
						break;
					case 18u:
						points_.AddEntriesFrom(input, _repeated_points_codec);
						break;
					case 26u:
						if (shape_ == null)
						{
							Shape = new Types.Shape();
						}
						input.ReadMessage(Shape);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Fill : IMessage<Fill>, IMessage, IEquatable<Fill>, IDeepCloneable<Fill>
		{
			public enum FillTypeOneofCase
			{
				None = 0,
				Color = 1,
				Gradient = 2,
				Media = 3,
				BackgroundEffect = 5
			}

			private static readonly MessageParser<Fill> _parser = new MessageParser<Fill>(() => new Fill());

			private UnknownFieldSet _unknownFields;

			public const int ColorFieldNumber = 1;

			public const int GradientFieldNumber = 2;

			public const int MediaFieldNumber = 3;

			public const int BackgroundEffectFieldNumber = 5;

			public const int EnableFieldNumber = 4;

			private bool enable_;

			private object fillType_;

			private FillTypeOneofCase fillTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Fill> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Color Color
			{
				get
				{
					if (fillTypeCase_ != FillTypeOneofCase.Color)
					{
						return null;
					}
					return (Color)fillType_;
				}
				set
				{
					fillType_ = value;
					fillTypeCase_ = ((value != null) ? FillTypeOneofCase.Color : FillTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Gradient Gradient
			{
				get
				{
					if (fillTypeCase_ != FillTypeOneofCase.Gradient)
					{
						return null;
					}
					return (Gradient)fillType_;
				}
				set
				{
					fillType_ = value;
					fillTypeCase_ = ((value != null) ? FillTypeOneofCase.Gradient : FillTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media Media
			{
				get
				{
					if (fillTypeCase_ != FillTypeOneofCase.Media)
					{
						return null;
					}
					return (Media)fillType_;
				}
				set
				{
					fillType_ = value;
					fillTypeCase_ = ((value != null) ? FillTypeOneofCase.Media : FillTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundEffect BackgroundEffect
			{
				get
				{
					if (fillTypeCase_ != FillTypeOneofCase.BackgroundEffect)
					{
						return null;
					}
					return (BackgroundEffect)fillType_;
				}
				set
				{
					fillType_ = value;
					fillTypeCase_ = ((value != null) ? FillTypeOneofCase.BackgroundEffect : FillTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enable
			{
				get
				{
					return enable_;
				}
				set
				{
					enable_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FillTypeOneofCase FillTypeCase => fillTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Fill()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Fill(Fill other)
				: this()
			{
				enable_ = other.enable_;
				switch (other.FillTypeCase)
				{
				case FillTypeOneofCase.Color:
					Color = other.Color.Clone();
					break;
				case FillTypeOneofCase.Gradient:
					Gradient = other.Gradient.Clone();
					break;
				case FillTypeOneofCase.Media:
					Media = other.Media.Clone();
					break;
				case FillTypeOneofCase.BackgroundEffect:
					BackgroundEffect = other.BackgroundEffect.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Fill Clone()
			{
				return new Fill(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearFillType()
			{
				fillTypeCase_ = FillTypeOneofCase.None;
				fillType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Fill);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Fill other)
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
				if (!object.Equals(Gradient, other.Gradient))
				{
					return false;
				}
				if (!object.Equals(Media, other.Media))
				{
					return false;
				}
				if (!object.Equals(BackgroundEffect, other.BackgroundEffect))
				{
					return false;
				}
				if (Enable != other.Enable)
				{
					return false;
				}
				if (FillTypeCase != other.FillTypeCase)
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
				if (fillTypeCase_ == FillTypeOneofCase.Color)
				{
					num ^= Color.GetHashCode();
				}
				if (fillTypeCase_ == FillTypeOneofCase.Gradient)
				{
					num ^= Gradient.GetHashCode();
				}
				if (fillTypeCase_ == FillTypeOneofCase.Media)
				{
					num ^= Media.GetHashCode();
				}
				if (fillTypeCase_ == FillTypeOneofCase.BackgroundEffect)
				{
					num ^= BackgroundEffect.GetHashCode();
				}
				if (Enable)
				{
					num ^= Enable.GetHashCode();
				}
				num ^= (int)fillTypeCase_;
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
				if (fillTypeCase_ == FillTypeOneofCase.Color)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Color);
				}
				if (fillTypeCase_ == FillTypeOneofCase.Gradient)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Gradient);
				}
				if (fillTypeCase_ == FillTypeOneofCase.Media)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Media);
				}
				if (Enable)
				{
					output.WriteRawTag(32);
					output.WriteBool(Enable);
				}
				if (fillTypeCase_ == FillTypeOneofCase.BackgroundEffect)
				{
					output.WriteRawTag(42);
					output.WriteMessage(BackgroundEffect);
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
				if (fillTypeCase_ == FillTypeOneofCase.Color)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				if (fillTypeCase_ == FillTypeOneofCase.Gradient)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Gradient);
				}
				if (fillTypeCase_ == FillTypeOneofCase.Media)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Media);
				}
				if (fillTypeCase_ == FillTypeOneofCase.BackgroundEffect)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundEffect);
				}
				if (Enable)
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
			public void MergeFrom(Fill other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Enable)
				{
					Enable = other.Enable;
				}
				switch (other.FillTypeCase)
				{
				case FillTypeOneofCase.Color:
					if (Color == null)
					{
						Color = new Color();
					}
					Color.MergeFrom(other.Color);
					break;
				case FillTypeOneofCase.Gradient:
					if (Gradient == null)
					{
						Gradient = new Gradient();
					}
					Gradient.MergeFrom(other.Gradient);
					break;
				case FillTypeOneofCase.Media:
					if (Media == null)
					{
						Media = new Media();
					}
					Media.MergeFrom(other.Media);
					break;
				case FillTypeOneofCase.BackgroundEffect:
					if (BackgroundEffect == null)
					{
						BackgroundEffect = new BackgroundEffect();
					}
					BackgroundEffect.MergeFrom(other.BackgroundEffect);
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
						Color color = new Color();
						if (fillTypeCase_ == FillTypeOneofCase.Color)
						{
							color.MergeFrom(Color);
						}
						input.ReadMessage(color);
						Color = color;
						break;
					}
					case 18u:
					{
						Gradient gradient = new Gradient();
						if (fillTypeCase_ == FillTypeOneofCase.Gradient)
						{
							gradient.MergeFrom(Gradient);
						}
						input.ReadMessage(gradient);
						Gradient = gradient;
						break;
					}
					case 26u:
					{
						Media media = new Media();
						if (fillTypeCase_ == FillTypeOneofCase.Media)
						{
							media.MergeFrom(Media);
						}
						input.ReadMessage(media);
						Media = media;
						break;
					}
					case 32u:
						Enable = input.ReadBool();
						break;
					case 42u:
					{
						BackgroundEffect backgroundEffect = new BackgroundEffect();
						if (fillTypeCase_ == FillTypeOneofCase.BackgroundEffect)
						{
							backgroundEffect.MergeFrom(BackgroundEffect);
						}
						input.ReadMessage(backgroundEffect);
						BackgroundEffect = backgroundEffect;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BackgroundEffect : IMessage<BackgroundEffect>, IMessage, IEquatable<BackgroundEffect>, IDeepCloneable<BackgroundEffect>
		{
			public enum EffectTypeOneofCase
			{
				None = 0,
				BackgroundBlur = 2,
				BackgroundInvert = 3
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class BackgroundEffectBlur : IMessage<BackgroundEffectBlur>, IMessage, IEquatable<BackgroundEffectBlur>, IDeepCloneable<BackgroundEffectBlur>
				{
					private static readonly MessageParser<BackgroundEffectBlur> _parser = new MessageParser<BackgroundEffectBlur>(() => new BackgroundEffectBlur());

					private UnknownFieldSet _unknownFields;

					public const int SaturationFieldNumber = 1;

					private double saturation_;

					public const int BlurAmountFieldNumber = 2;

					private double blurAmount_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<BackgroundEffectBlur> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => BackgroundEffect.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
					public double BlurAmount
					{
						get
						{
							return blurAmount_;
						}
						set
						{
							blurAmount_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundEffectBlur()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundEffectBlur(BackgroundEffectBlur other)
						: this()
					{
						saturation_ = other.saturation_;
						blurAmount_ = other.blurAmount_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundEffectBlur Clone()
					{
						return new BackgroundEffectBlur(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as BackgroundEffectBlur);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(BackgroundEffectBlur other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Saturation, other.Saturation))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlurAmount, other.BlurAmount))
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
						if (Saturation != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Saturation);
						}
						if (BlurAmount != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlurAmount);
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
						if (Saturation != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Saturation);
						}
						if (BlurAmount != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(BlurAmount);
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
						if (Saturation != 0.0)
						{
							num += 9;
						}
						if (BlurAmount != 0.0)
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
					public void MergeFrom(BackgroundEffectBlur other)
					{
						if (other != null)
						{
							if (other.Saturation != 0.0)
							{
								Saturation = other.Saturation;
							}
							if (other.BlurAmount != 0.0)
							{
								BlurAmount = other.BlurAmount;
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
								Saturation = input.ReadDouble();
								break;
							case 17u:
								BlurAmount = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class BackgroundEffectInvert : IMessage<BackgroundEffectInvert>, IMessage, IEquatable<BackgroundEffectInvert>, IDeepCloneable<BackgroundEffectInvert>
				{
					private static readonly MessageParser<BackgroundEffectInvert> _parser = new MessageParser<BackgroundEffectInvert>(() => new BackgroundEffectInvert());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<BackgroundEffectInvert> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => BackgroundEffect.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundEffectInvert()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundEffectInvert(BackgroundEffectInvert other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public BackgroundEffectInvert Clone()
					{
						return new BackgroundEffectInvert(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as BackgroundEffectInvert);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(BackgroundEffectInvert other)
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
					public void MergeFrom(BackgroundEffectInvert other)
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

			private static readonly MessageParser<BackgroundEffect> _parser = new MessageParser<BackgroundEffect>(() => new BackgroundEffect());

			private UnknownFieldSet _unknownFields;

			public const int BackgroundBlurFieldNumber = 2;

			public const int BackgroundInvertFieldNumber = 3;

			private object effectType_;

			private EffectTypeOneofCase effectTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BackgroundEffect> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.BackgroundEffectBlur BackgroundBlur
			{
				get
				{
					if (effectTypeCase_ != EffectTypeOneofCase.BackgroundBlur)
					{
						return null;
					}
					return (Types.BackgroundEffectBlur)effectType_;
				}
				set
				{
					effectType_ = value;
					effectTypeCase_ = ((value != null) ? EffectTypeOneofCase.BackgroundBlur : EffectTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.BackgroundEffectInvert BackgroundInvert
			{
				get
				{
					if (effectTypeCase_ != EffectTypeOneofCase.BackgroundInvert)
					{
						return null;
					}
					return (Types.BackgroundEffectInvert)effectType_;
				}
				set
				{
					effectType_ = value;
					effectTypeCase_ = ((value != null) ? EffectTypeOneofCase.BackgroundInvert : EffectTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EffectTypeOneofCase EffectTypeCase => effectTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundEffect()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundEffect(BackgroundEffect other)
				: this()
			{
				switch (other.EffectTypeCase)
				{
				case EffectTypeOneofCase.BackgroundBlur:
					BackgroundBlur = other.BackgroundBlur.Clone();
					break;
				case EffectTypeOneofCase.BackgroundInvert:
					BackgroundInvert = other.BackgroundInvert.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BackgroundEffect Clone()
			{
				return new BackgroundEffect(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearEffectType()
			{
				effectTypeCase_ = EffectTypeOneofCase.None;
				effectType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BackgroundEffect);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BackgroundEffect other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(BackgroundBlur, other.BackgroundBlur))
				{
					return false;
				}
				if (!object.Equals(BackgroundInvert, other.BackgroundInvert))
				{
					return false;
				}
				if (EffectTypeCase != other.EffectTypeCase)
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
				if (effectTypeCase_ == EffectTypeOneofCase.BackgroundBlur)
				{
					num ^= BackgroundBlur.GetHashCode();
				}
				if (effectTypeCase_ == EffectTypeOneofCase.BackgroundInvert)
				{
					num ^= BackgroundInvert.GetHashCode();
				}
				num ^= (int)effectTypeCase_;
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
				if (effectTypeCase_ == EffectTypeOneofCase.BackgroundBlur)
				{
					output.WriteRawTag(18);
					output.WriteMessage(BackgroundBlur);
				}
				if (effectTypeCase_ == EffectTypeOneofCase.BackgroundInvert)
				{
					output.WriteRawTag(26);
					output.WriteMessage(BackgroundInvert);
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
				if (effectTypeCase_ == EffectTypeOneofCase.BackgroundBlur)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundBlur);
				}
				if (effectTypeCase_ == EffectTypeOneofCase.BackgroundInvert)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundInvert);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(BackgroundEffect other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.EffectTypeCase)
				{
				case EffectTypeOneofCase.BackgroundBlur:
					if (BackgroundBlur == null)
					{
						BackgroundBlur = new Types.BackgroundEffectBlur();
					}
					BackgroundBlur.MergeFrom(other.BackgroundBlur);
					break;
				case EffectTypeOneofCase.BackgroundInvert:
					if (BackgroundInvert == null)
					{
						BackgroundInvert = new Types.BackgroundEffectInvert();
					}
					BackgroundInvert.MergeFrom(other.BackgroundInvert);
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
						Types.BackgroundEffectBlur backgroundEffectBlur = new Types.BackgroundEffectBlur();
						if (effectTypeCase_ == EffectTypeOneofCase.BackgroundBlur)
						{
							backgroundEffectBlur.MergeFrom(BackgroundBlur);
						}
						input.ReadMessage(backgroundEffectBlur);
						BackgroundBlur = backgroundEffectBlur;
						break;
					}
					case 26u:
					{
						Types.BackgroundEffectInvert backgroundEffectInvert = new Types.BackgroundEffectInvert();
						if (effectTypeCase_ == EffectTypeOneofCase.BackgroundInvert)
						{
							backgroundEffectInvert.MergeFrom(BackgroundInvert);
						}
						input.ReadMessage(backgroundEffectInvert);
						BackgroundInvert = backgroundEffectInvert;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Gradient : IMessage<Gradient>, IMessage, IEquatable<Gradient>, IDeepCloneable<Gradient>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Type
				{
					[OriginalName("TYPE_LINEAR")]
					Linear,
					[OriginalName("TYPE_RADIAL")]
					Radial,
					[OriginalName("TYPE_ANGLE")]
					Angle
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ColorStop : IMessage<ColorStop>, IMessage, IEquatable<ColorStop>, IDeepCloneable<ColorStop>
				{
					private static readonly MessageParser<ColorStop> _parser = new MessageParser<ColorStop>(() => new ColorStop());

					private UnknownFieldSet _unknownFields;

					public const int ColorFieldNumber = 1;

					private Color color_;

					public const int PositionFieldNumber = 2;

					private double position_;

					public const int BlendPointFieldNumber = 3;

					private double blendPoint_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ColorStop> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Gradient.Descriptor.NestedTypes[0];

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
					public double BlendPoint
					{
						get
						{
							return blendPoint_;
						}
						set
						{
							blendPoint_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ColorStop()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ColorStop(ColorStop other)
						: this()
					{
						color_ = ((other.color_ != null) ? other.color_.Clone() : null);
						position_ = other.position_;
						blendPoint_ = other.blendPoint_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ColorStop Clone()
					{
						return new ColorStop(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ColorStop);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ColorStop other)
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
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Position, other.Position))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlendPoint, other.BlendPoint))
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
						if (Position != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Position);
						}
						if (BlendPoint != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlendPoint);
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
						if (Position != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(Position);
						}
						if (BlendPoint != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(BlendPoint);
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
						if (Position != 0.0)
						{
							num += 9;
						}
						if (BlendPoint != 0.0)
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
					public void MergeFrom(ColorStop other)
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
						if (other.Position != 0.0)
						{
							Position = other.Position;
						}
						if (other.BlendPoint != 0.0)
						{
							BlendPoint = other.BlendPoint;
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
							case 17u:
								Position = input.ReadDouble();
								break;
							case 25u:
								BlendPoint = input.ReadDouble();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Gradient> _parser = new MessageParser<Gradient>(() => new Gradient());

			private UnknownFieldSet _unknownFields;

			public const int TypeFieldNumber = 1;

			private Types.Type type_;

			public const int AngleFieldNumber = 2;

			private double angle_;

			public const int LengthFieldNumber = 3;

			private double length_;

			public const int StopsFieldNumber = 4;

			private static readonly FieldCodec<Types.ColorStop> _repeated_stops_codec = FieldCodec.ForMessage(34u, Types.ColorStop.Parser);

			private readonly RepeatedField<Types.ColorStop> stops_ = new RepeatedField<Types.ColorStop>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Gradient> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Type Type
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
			public double Length
			{
				get
				{
					return length_;
				}
				set
				{
					length_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.ColorStop> Stops => stops_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Gradient()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Gradient(Gradient other)
				: this()
			{
				type_ = other.type_;
				angle_ = other.angle_;
				length_ = other.length_;
				stops_ = other.stops_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Gradient Clone()
			{
				return new Gradient(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Gradient);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Gradient other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Type != other.Type)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Angle, other.Angle))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Length, other.Length))
				{
					return false;
				}
				if (!stops_.Equals(other.stops_))
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
				if (Type != 0)
				{
					num ^= Type.GetHashCode();
				}
				if (Angle != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Angle);
				}
				if (Length != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Length);
				}
				num ^= stops_.GetHashCode();
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
				if (Type != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Type);
				}
				if (Angle != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Angle);
				}
				if (Length != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(Length);
				}
				stops_.WriteTo(output, _repeated_stops_codec);
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
				if (Type != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
				}
				if (Angle != 0.0)
				{
					num += 9;
				}
				if (Length != 0.0)
				{
					num += 9;
				}
				num += stops_.CalculateSize(_repeated_stops_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Gradient other)
			{
				if (other != null)
				{
					if (other.Type != 0)
					{
						Type = other.Type;
					}
					if (other.Angle != 0.0)
					{
						Angle = other.Angle;
					}
					if (other.Length != 0.0)
					{
						Length = other.Length;
					}
					stops_.Add(other.stops_);
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
						Type = (Types.Type)input.ReadEnum();
						break;
					case 17u:
						Angle = input.ReadDouble();
						break;
					case 25u:
						Length = input.ReadDouble();
						break;
					case 34u:
						stops_.AddEntriesFrom(input, _repeated_stops_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Shadow : IMessage<Shadow>, IMessage, IEquatable<Shadow>, IDeepCloneable<Shadow>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Style
				{
					[OriginalName("STYLE_DROP")]
					Drop
				}
			}

			private static readonly MessageParser<Shadow> _parser = new MessageParser<Shadow>(() => new Shadow());

			private UnknownFieldSet _unknownFields;

			public const int StyleFieldNumber = 1;

			private Types.Style style_;

			public const int AngleFieldNumber = 2;

			private double angle_;

			public const int OffsetFieldNumber = 3;

			private double offset_;

			public const int RadiusFieldNumber = 4;

			private double radius_;

			public const int ColorFieldNumber = 5;

			private Color color_;

			public const int OpacityFieldNumber = 6;

			private double opacity_;

			public const int EnableFieldNumber = 7;

			private bool enable_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Shadow> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Style Style
			{
				get
				{
					return style_;
				}
				set
				{
					style_ = value;
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
			public double Radius
			{
				get
				{
					return radius_;
				}
				set
				{
					radius_ = value;
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
			public bool Enable
			{
				get
				{
					return enable_;
				}
				set
				{
					enable_ = value;
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
				style_ = other.style_;
				angle_ = other.angle_;
				offset_ = other.offset_;
				radius_ = other.radius_;
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				opacity_ = other.opacity_;
				enable_ = other.enable_;
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
				if (Style != other.Style)
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
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Radius, other.Radius))
				{
					return false;
				}
				if (!object.Equals(Color, other.Color))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Opacity, other.Opacity))
				{
					return false;
				}
				if (Enable != other.Enable)
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
				if (Style != 0)
				{
					num ^= Style.GetHashCode();
				}
				if (Angle != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Angle);
				}
				if (Offset != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Offset);
				}
				if (Radius != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Radius);
				}
				if (color_ != null)
				{
					num ^= Color.GetHashCode();
				}
				if (Opacity != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Opacity);
				}
				if (Enable)
				{
					num ^= Enable.GetHashCode();
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
				if (Style != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Style);
				}
				if (Angle != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Angle);
				}
				if (Offset != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(Offset);
				}
				if (Radius != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(Radius);
				}
				if (color_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Color);
				}
				if (Opacity != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(Opacity);
				}
				if (Enable)
				{
					output.WriteRawTag(56);
					output.WriteBool(Enable);
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
				if (Style != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Style);
				}
				if (Angle != 0.0)
				{
					num += 9;
				}
				if (Offset != 0.0)
				{
					num += 9;
				}
				if (Radius != 0.0)
				{
					num += 9;
				}
				if (color_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				if (Opacity != 0.0)
				{
					num += 9;
				}
				if (Enable)
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
			public void MergeFrom(Shadow other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Style != 0)
				{
					Style = other.Style;
				}
				if (other.Angle != 0.0)
				{
					Angle = other.Angle;
				}
				if (other.Offset != 0.0)
				{
					Offset = other.Offset;
				}
				if (other.Radius != 0.0)
				{
					Radius = other.Radius;
				}
				if (other.color_ != null)
				{
					if (color_ == null)
					{
						Color = new Color();
					}
					Color.MergeFrom(other.Color);
				}
				if (other.Opacity != 0.0)
				{
					Opacity = other.Opacity;
				}
				if (other.Enable)
				{
					Enable = other.Enable;
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
						Style = (Types.Style)input.ReadEnum();
						break;
					case 17u:
						Angle = input.ReadDouble();
						break;
					case 25u:
						Offset = input.ReadDouble();
						break;
					case 33u:
						Radius = input.ReadDouble();
						break;
					case 42u:
						if (color_ == null)
						{
							Color = new Color();
						}
						input.ReadMessage(Color);
						break;
					case 49u:
						Opacity = input.ReadDouble();
						break;
					case 56u:
						Enable = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Stroke : IMessage<Stroke>, IMessage, IEquatable<Stroke>, IDeepCloneable<Stroke>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Style
				{
					[OriginalName("STYLE_SOLID_LINE")]
					SolidLine,
					[OriginalName("STYLE_SQUARE_DASH")]
					SquareDash,
					[OriginalName("STYLE_SHORT_DASH")]
					ShortDash,
					[OriginalName("STYLE_LONG_DASH")]
					LongDash
				}
			}

			private static readonly MessageParser<Stroke> _parser = new MessageParser<Stroke>(() => new Stroke());

			private UnknownFieldSet _unknownFields;

			public const int StyleFieldNumber = 1;

			private Types.Style style_;

			public const int WidthFieldNumber = 2;

			private double width_;

			public const int ColorFieldNumber = 3;

			private Color color_;

			public const int PatternFieldNumber = 4;

			private static readonly FieldCodec<double> _repeated_pattern_codec = FieldCodec.ForDouble(34u);

			private readonly RepeatedField<double> pattern_ = new RepeatedField<double>();

			public const int EnableFieldNumber = 5;

			private bool enable_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Stroke> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Style Style
			{
				get
				{
					return style_;
				}
				set
				{
					style_ = value;
				}
			}

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
			public RepeatedField<double> Pattern => pattern_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enable
			{
				get
				{
					return enable_;
				}
				set
				{
					enable_ = value;
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
				style_ = other.style_;
				width_ = other.width_;
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				pattern_ = other.pattern_.Clone();
				enable_ = other.enable_;
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
				if (Style != other.Style)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Width, other.Width))
				{
					return false;
				}
				if (!object.Equals(Color, other.Color))
				{
					return false;
				}
				if (!pattern_.Equals(other.pattern_))
				{
					return false;
				}
				if (Enable != other.Enable)
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
				if (Style != 0)
				{
					num ^= Style.GetHashCode();
				}
				if (Width != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Width);
				}
				if (color_ != null)
				{
					num ^= Color.GetHashCode();
				}
				num ^= pattern_.GetHashCode();
				if (Enable)
				{
					num ^= Enable.GetHashCode();
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
				if (Style != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Style);
				}
				if (Width != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Width);
				}
				if (color_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Color);
				}
				pattern_.WriteTo(output, _repeated_pattern_codec);
				if (Enable)
				{
					output.WriteRawTag(40);
					output.WriteBool(Enable);
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
				if (Style != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Style);
				}
				if (Width != 0.0)
				{
					num += 9;
				}
				if (color_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Color);
				}
				num += pattern_.CalculateSize(_repeated_pattern_codec);
				if (Enable)
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
			public void MergeFrom(Stroke other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Style != 0)
				{
					Style = other.Style;
				}
				if (other.Width != 0.0)
				{
					Width = other.Width;
				}
				if (other.color_ != null)
				{
					if (color_ == null)
					{
						Color = new Color();
					}
					Color.MergeFrom(other.Color);
				}
				pattern_.Add(other.pattern_);
				if (other.Enable)
				{
					Enable = other.Enable;
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
						Style = (Types.Style)input.ReadEnum();
						break;
					case 17u:
						Width = input.ReadDouble();
						break;
					case 26u:
						if (color_ == null)
						{
							Color = new Color();
						}
						input.ReadMessage(Color);
						break;
					case 33u:
					case 34u:
						pattern_.AddEntriesFrom(input, _repeated_pattern_codec);
						break;
					case 40u:
						Enable = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Feather : IMessage<Feather>, IMessage, IEquatable<Feather>, IDeepCloneable<Feather>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Style
				{
					[OriginalName("STYLE_INSIDE")]
					Inside,
					[OriginalName("STYLE_CENTER")]
					Center,
					[OriginalName("STYLE_OUTSIDE")]
					Outside
				}
			}

			private static readonly MessageParser<Feather> _parser = new MessageParser<Feather>(() => new Feather());

			private UnknownFieldSet _unknownFields;

			public const int StyleFieldNumber = 1;

			private Types.Style style_;

			public const int RadiusFieldNumber = 2;

			private double radius_;

			public const int EnableFieldNumber = 3;

			private bool enable_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Feather> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Style Style
			{
				get
				{
					return style_;
				}
				set
				{
					style_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Radius
			{
				get
				{
					return radius_;
				}
				set
				{
					radius_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Enable
			{
				get
				{
					return enable_;
				}
				set
				{
					enable_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Feather()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Feather(Feather other)
				: this()
			{
				style_ = other.style_;
				radius_ = other.radius_;
				enable_ = other.enable_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Feather Clone()
			{
				return new Feather(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Feather);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Feather other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Style != other.Style)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Radius, other.Radius))
				{
					return false;
				}
				if (Enable != other.Enable)
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
				if (Style != 0)
				{
					num ^= Style.GetHashCode();
				}
				if (Radius != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Radius);
				}
				if (Enable)
				{
					num ^= Enable.GetHashCode();
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
				if (Style != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Style);
				}
				if (Radius != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Radius);
				}
				if (Enable)
				{
					output.WriteRawTag(24);
					output.WriteBool(Enable);
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
				if (Style != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Style);
				}
				if (Radius != 0.0)
				{
					num += 9;
				}
				if (Enable)
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
			public void MergeFrom(Feather other)
			{
				if (other != null)
				{
					if (other.Style != 0)
					{
						Style = other.Style;
					}
					if (other.Radius != 0.0)
					{
						Radius = other.Radius;
					}
					if (other.Enable)
					{
						Enable = other.Enable;
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
						Style = (Types.Style)input.ReadEnum();
						break;
					case 17u:
						Radius = input.ReadDouble();
						break;
					case 24u:
						Enable = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Text : IMessage<Text>, IMessage, IEquatable<Text>, IDeepCloneable<Text>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum VerticalAlignment
				{
					[OriginalName("VERTICAL_ALIGNMENT_TOP")]
					Top,
					[OriginalName("VERTICAL_ALIGNMENT_MIDDLE")]
					Middle,
					[OriginalName("VERTICAL_ALIGNMENT_BOTTOM")]
					Bottom
				}

				public enum ScaleBehavior
				{
					[OriginalName("SCALE_BEHAVIOR_NONE")]
					None,
					[OriginalName("SCALE_BEHAVIOR_ADJUST_CONTAINER_HEIGHT")]
					AdjustContainerHeight,
					[OriginalName("SCALE_BEHAVIOR_SCALE_FONT_DOWN")]
					ScaleFontDown,
					[OriginalName("SCALE_BEHAVIOR_SCALE_FONT_UP")]
					ScaleFontUp,
					[OriginalName("SCALE_BEHAVIOR_SCALE_FONT_UP_DOWN")]
					ScaleFontUpDown
				}

				public enum Transform
				{
					[OriginalName("TRANSFORM_NONE")]
					None,
					[OriginalName("TRANSFORM_SINGLE_LINE")]
					SingleLine,
					[OriginalName("TRANSFORM_ONE_WORD_PER_LINE")]
					OneWordPerLine,
					[OriginalName("TRANSFORM_ONE_CHARACTER_PER_LINE")]
					OneCharacterPerLine,
					[OriginalName("TRANSFORM_REPLACE_LINE_RETURNS")]
					ReplaceLineReturns
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class LineFillMask : IMessage<LineFillMask>, IMessage, IEquatable<LineFillMask>, IDeepCloneable<LineFillMask>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum LineMaskStyle
						{
							[OriginalName("LINE_MASK_STYLE_FULL_WIDTH")]
							FullWidth,
							[OriginalName("LINE_MASK_STYLE_LINE_WIDTH")]
							LineWidth,
							[OriginalName("LINE_MASK_STYLE_MAX_LINE_WIDTH")]
							MaxLineWidth
						}
					}

					private static readonly MessageParser<LineFillMask> _parser = new MessageParser<LineFillMask>(() => new LineFillMask());

					private UnknownFieldSet _unknownFields;

					public const int EnabledFieldNumber = 1;

					private bool enabled_;

					public const int HeightOffsetFieldNumber = 2;

					private double heightOffset_;

					public const int VerticalOffsetFieldNumber = 3;

					private double verticalOffset_;

					public const int MaskStyleFieldNumber = 4;

					private Types.LineMaskStyle maskStyle_;

					public const int WidthOffsetFieldNumber = 5;

					private double widthOffset_;

					public const int HorizontalOffsetFieldNumber = 6;

					private double horizontalOffset_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<LineFillMask> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Text.Descriptor.NestedTypes[0];

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
					public double HeightOffset
					{
						get
						{
							return heightOffset_;
						}
						set
						{
							heightOffset_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double VerticalOffset
					{
						get
						{
							return verticalOffset_;
						}
						set
						{
							verticalOffset_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.LineMaskStyle MaskStyle
					{
						get
						{
							return maskStyle_;
						}
						set
						{
							maskStyle_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double WidthOffset
					{
						get
						{
							return widthOffset_;
						}
						set
						{
							widthOffset_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double HorizontalOffset
					{
						get
						{
							return horizontalOffset_;
						}
						set
						{
							horizontalOffset_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LineFillMask()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LineFillMask(LineFillMask other)
						: this()
					{
						enabled_ = other.enabled_;
						heightOffset_ = other.heightOffset_;
						verticalOffset_ = other.verticalOffset_;
						maskStyle_ = other.maskStyle_;
						widthOffset_ = other.widthOffset_;
						horizontalOffset_ = other.horizontalOffset_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LineFillMask Clone()
					{
						return new LineFillMask(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as LineFillMask);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(LineFillMask other)
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
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(HeightOffset, other.HeightOffset))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(VerticalOffset, other.VerticalOffset))
						{
							return false;
						}
						if (MaskStyle != other.MaskStyle)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(WidthOffset, other.WidthOffset))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(HorizontalOffset, other.HorizontalOffset))
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
						if (HeightOffset != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(HeightOffset);
						}
						if (VerticalOffset != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(VerticalOffset);
						}
						if (MaskStyle != 0)
						{
							num ^= MaskStyle.GetHashCode();
						}
						if (WidthOffset != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(WidthOffset);
						}
						if (HorizontalOffset != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(HorizontalOffset);
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
						if (HeightOffset != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(HeightOffset);
						}
						if (VerticalOffset != 0.0)
						{
							output.WriteRawTag(25);
							output.WriteDouble(VerticalOffset);
						}
						if (MaskStyle != 0)
						{
							output.WriteRawTag(32);
							output.WriteEnum((int)MaskStyle);
						}
						if (WidthOffset != 0.0)
						{
							output.WriteRawTag(41);
							output.WriteDouble(WidthOffset);
						}
						if (HorizontalOffset != 0.0)
						{
							output.WriteRawTag(49);
							output.WriteDouble(HorizontalOffset);
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
						if (HeightOffset != 0.0)
						{
							num += 9;
						}
						if (VerticalOffset != 0.0)
						{
							num += 9;
						}
						if (MaskStyle != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)MaskStyle);
						}
						if (WidthOffset != 0.0)
						{
							num += 9;
						}
						if (HorizontalOffset != 0.0)
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
					public void MergeFrom(LineFillMask other)
					{
						if (other != null)
						{
							if (other.Enabled)
							{
								Enabled = other.Enabled;
							}
							if (other.HeightOffset != 0.0)
							{
								HeightOffset = other.HeightOffset;
							}
							if (other.VerticalOffset != 0.0)
							{
								VerticalOffset = other.VerticalOffset;
							}
							if (other.MaskStyle != 0)
							{
								MaskStyle = other.MaskStyle;
							}
							if (other.WidthOffset != 0.0)
							{
								WidthOffset = other.WidthOffset;
							}
							if (other.HorizontalOffset != 0.0)
							{
								HorizontalOffset = other.HorizontalOffset;
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
								Enabled = input.ReadBool();
								break;
							case 17u:
								HeightOffset = input.ReadDouble();
								break;
							case 25u:
								VerticalOffset = input.ReadDouble();
								break;
							case 32u:
								MaskStyle = (Types.LineMaskStyle)input.ReadEnum();
								break;
							case 41u:
								WidthOffset = input.ReadDouble();
								break;
							case 49u:
								HorizontalOffset = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class GradientFill : IMessage<GradientFill>, IMessage, IEquatable<GradientFill>, IDeepCloneable<GradientFill>
				{
					private static readonly MessageParser<GradientFill> _parser = new MessageParser<GradientFill>(() => new GradientFill());

					private UnknownFieldSet _unknownFields;

					public const int GradientFieldNumber = 1;

					private Gradient gradient_;

					public const int StretchToDocumentBoundsFieldNumber = 2;

					private bool stretchToDocumentBounds_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GradientFill> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Text.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Gradient Gradient
					{
						get
						{
							return gradient_;
						}
						set
						{
							gradient_ = value;
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
					public GradientFill()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GradientFill(GradientFill other)
						: this()
					{
						gradient_ = ((other.gradient_ != null) ? other.gradient_.Clone() : null);
						stretchToDocumentBounds_ = other.stretchToDocumentBounds_;
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
						if (!object.Equals(Gradient, other.Gradient))
						{
							return false;
						}
						if (StretchToDocumentBounds != other.StretchToDocumentBounds)
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
						if (gradient_ != null)
						{
							num ^= Gradient.GetHashCode();
						}
						if (StretchToDocumentBounds)
						{
							num ^= StretchToDocumentBounds.GetHashCode();
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
						if (gradient_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Gradient);
						}
						if (StretchToDocumentBounds)
						{
							output.WriteRawTag(16);
							output.WriteBool(StretchToDocumentBounds);
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
						if (gradient_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Gradient);
						}
						if (StretchToDocumentBounds)
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
					public void MergeFrom(GradientFill other)
					{
						if (other == null)
						{
							return;
						}
						if (other.gradient_ != null)
						{
							if (gradient_ == null)
							{
								Gradient = new Gradient();
							}
							Gradient.MergeFrom(other.Gradient);
						}
						if (other.StretchToDocumentBounds)
						{
							StretchToDocumentBounds = other.StretchToDocumentBounds;
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
								if (gradient_ == null)
								{
									Gradient = new Gradient();
								}
								input.ReadMessage(Gradient);
								break;
							case 16u:
								StretchToDocumentBounds = input.ReadBool();
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
					public static MessageDescriptor Descriptor => Text.Descriptor.NestedTypes[2];

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
				public sealed class MediaFill : IMessage<MediaFill>, IMessage, IEquatable<MediaFill>, IDeepCloneable<MediaFill>
				{
					private static readonly MessageParser<MediaFill> _parser = new MessageParser<MediaFill>(() => new MediaFill());

					private UnknownFieldSet _unknownFields;

					public const int MediaFieldNumber = 1;

					private Media media_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<MediaFill> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Text.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
						if (media_ != null)
						{
							output.WriteRawTag(10);
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
								continue;
							}
							if (media_ == null)
							{
								Media = new Media();
							}
							input.ReadMessage(Media);
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ChordPro : IMessage<ChordPro>, IMessage, IEquatable<ChordPro>, IDeepCloneable<ChordPro>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Notation
						{
							[OriginalName("NOTATION_CHORDS")]
							Chords,
							[OriginalName("NOTATION_NUMBERS")]
							Numbers,
							[OriginalName("NOTATION_NUMERALS")]
							Numerals,
							[OriginalName("NOTATION_DO_RE_MI")]
							DoReMi
						}
					}

					private static readonly MessageParser<ChordPro> _parser = new MessageParser<ChordPro>(() => new ChordPro());

					private UnknownFieldSet _unknownFields;

					public const int EnabledFieldNumber = 1;

					private bool enabled_;

					public const int NotationFieldNumber = 2;

					private Types.Notation notation_;

					public const int ColorFieldNumber = 3;

					private Color color_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ChordPro> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Text.Descriptor.NestedTypes[4];

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
					public Types.Notation Notation
					{
						get
						{
							return notation_;
						}
						set
						{
							notation_ = value;
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
					public ChordPro()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChordPro(ChordPro other)
						: this()
					{
						enabled_ = other.enabled_;
						notation_ = other.notation_;
						color_ = ((other.color_ != null) ? other.color_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ChordPro Clone()
					{
						return new ChordPro(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ChordPro);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ChordPro other)
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
						if (Notation != other.Notation)
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
						if (Enabled)
						{
							num ^= Enabled.GetHashCode();
						}
						if (Notation != 0)
						{
							num ^= Notation.GetHashCode();
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
						if (Enabled)
						{
							output.WriteRawTag(8);
							output.WriteBool(Enabled);
						}
						if (Notation != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)Notation);
						}
						if (color_ != null)
						{
							output.WriteRawTag(26);
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
						if (Enabled)
						{
							num += 2;
						}
						if (Notation != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Notation);
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
					public void MergeFrom(ChordPro other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Enabled)
						{
							Enabled = other.Enabled;
						}
						if (other.Notation != 0)
						{
							Notation = other.Notation;
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
							case 8u:
								Enabled = input.ReadBool();
								break;
							case 16u:
								Notation = (Types.Notation)input.ReadEnum();
								break;
							case 26u:
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

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Attributes : IMessage<Attributes>, IMessage, IEquatable<Attributes>, IDeepCloneable<Attributes>
				{
					public enum FillOneofCase
					{
						None = 0,
						TextSolidFill = 3,
						TextGradientFill = 14,
						CutOutFill = 16,
						MediaFill = 17,
						BackgroundEffect = 18
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Capitalization
						{
							[OriginalName("CAPITALIZATION_NONE")]
							None,
							[OriginalName("CAPITALIZATION_ALL_CAPS")]
							AllCaps,
							[OriginalName("CAPITALIZATION_SMALL_CAPS")]
							SmallCaps,
							[OriginalName("CAPITALIZATION_TITLE_CASE")]
							TitleCase,
							[OriginalName("CAPITALIZATION_START_CASE")]
							StartCase
						}

						public enum Alignment
						{
							[OriginalName("ALIGNMENT_LEFT")]
							Left,
							[OriginalName("ALIGNMENT_RIGHT")]
							Right,
							[OriginalName("ALIGNMENT_CENTER")]
							Center,
							[OriginalName("ALIGNMENT_JUSTIFIED")]
							Justified,
							[OriginalName("ALIGNMENT_NATURAL")]
							Natural
						}

						public enum CharacterSizeMode
						{
							[OriginalName("CHARACTER_SIZE_MODE_NORMAL")]
							Normal,
							[OriginalName("CHARACTER_SIZE_MODE_SCALED_BY_DOCUMENT_HEIGHT")]
							ScaledByDocumentHeight,
							[OriginalName("CHARACTER_SIZE_MODE_SCALED_BY_DOCUMENT_WIDTH")]
							ScaledByDocumentWidth
						}

						public enum LigatureStyle
						{
							[OriginalName("LIGATURE_STYLE_DEFAULT")]
							Default,
							[OriginalName("LIGATURE_STYLE_NONE")]
							None
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Underline : IMessage<Underline>, IMessage, IEquatable<Underline>, IDeepCloneable<Underline>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								public enum Style
								{
									[OriginalName("STYLE_NONE")]
									None,
									[OriginalName("STYLE_SINGLE")]
									Single,
									[OriginalName("STYLE_THICK")]
									Thick,
									[OriginalName("STYLE_DOUBLE")]
									Double
								}

								public enum Pattern
								{
									[OriginalName("PATTERN_SOLID")]
									Solid,
									[OriginalName("PATTERN_DOT")]
									Dot,
									[OriginalName("PATTERN_DASH")]
									Dash,
									[OriginalName("PATTERN_DASH_DOT")]
									DashDot,
									[OriginalName("PATTERN_DASH_DOT_DOT")]
									DashDotDot
								}
							}

							private static readonly MessageParser<Underline> _parser = new MessageParser<Underline>(() => new Underline());

							private UnknownFieldSet _unknownFields;

							public const int StyleFieldNumber = 1;

							private Types.Style style_;

							public const int PatternFieldNumber = 2;

							private Types.Pattern pattern_;

							public const int ByWordFieldNumber = 3;

							private bool byWord_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Underline> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Attributes.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Style Style
							{
								get
								{
									return style_;
								}
								set
								{
									style_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.Pattern Pattern
							{
								get
								{
									return pattern_;
								}
								set
								{
									pattern_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool ByWord
							{
								get
								{
									return byWord_;
								}
								set
								{
									byWord_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Underline()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Underline(Underline other)
								: this()
							{
								style_ = other.style_;
								pattern_ = other.pattern_;
								byWord_ = other.byWord_;
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Underline Clone()
							{
								return new Underline(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Underline);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Underline other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (Style != other.Style)
								{
									return false;
								}
								if (Pattern != other.Pattern)
								{
									return false;
								}
								if (ByWord != other.ByWord)
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
								if (Style != 0)
								{
									num ^= Style.GetHashCode();
								}
								if (Pattern != 0)
								{
									num ^= Pattern.GetHashCode();
								}
								if (ByWord)
								{
									num ^= ByWord.GetHashCode();
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
								if (Style != 0)
								{
									output.WriteRawTag(8);
									output.WriteEnum((int)Style);
								}
								if (Pattern != 0)
								{
									output.WriteRawTag(16);
									output.WriteEnum((int)Pattern);
								}
								if (ByWord)
								{
									output.WriteRawTag(24);
									output.WriteBool(ByWord);
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
								if (Style != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)Style);
								}
								if (Pattern != 0)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)Pattern);
								}
								if (ByWord)
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
							public void MergeFrom(Underline other)
							{
								if (other != null)
								{
									if (other.Style != 0)
									{
										Style = other.Style;
									}
									if (other.Pattern != 0)
									{
										Pattern = other.Pattern;
									}
									if (other.ByWord)
									{
										ByWord = other.ByWord;
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
										Style = (Types.Style)input.ReadEnum();
										break;
									case 16u:
										Pattern = (Types.Pattern)input.ReadEnum();
										break;
									case 24u:
										ByWord = input.ReadBool();
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Paragraph : IMessage<Paragraph>, IMessage, IEquatable<Paragraph>, IDeepCloneable<Paragraph>
						{
							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static class Types
							{
								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class TabStop : IMessage<TabStop>, IMessage, IEquatable<TabStop>, IDeepCloneable<TabStop>
								{
									private static readonly MessageParser<TabStop> _parser = new MessageParser<TabStop>(() => new TabStop());

									private UnknownFieldSet _unknownFields;

									public const int LocationFieldNumber = 1;

									private double location_;

									public const int AlignmentFieldNumber = 2;

									private Alignment alignment_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<TabStop> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Paragraph.Descriptor.NestedTypes[0];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public double Location
									{
										get
										{
											return location_;
										}
										set
										{
											location_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public Alignment Alignment
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
									public TabStop()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public TabStop(TabStop other)
										: this()
									{
										location_ = other.location_;
										alignment_ = other.alignment_;
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
										if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Location, other.Location))
										{
											return false;
										}
										if (Alignment != other.Alignment)
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
										if (Location != 0.0)
										{
											num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Location);
										}
										if (Alignment != 0)
										{
											num ^= Alignment.GetHashCode();
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
										if (Location != 0.0)
										{
											output.WriteRawTag(9);
											output.WriteDouble(Location);
										}
										if (Alignment != 0)
										{
											output.WriteRawTag(16);
											output.WriteEnum((int)Alignment);
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
										if (Location != 0.0)
										{
											num += 9;
										}
										if (Alignment != 0)
										{
											num += 1 + CodedOutputStream.ComputeEnumSize((int)Alignment);
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
											if (other.Location != 0.0)
											{
												Location = other.Location;
											}
											if (other.Alignment != 0)
											{
												Alignment = other.Alignment;
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
												Location = input.ReadDouble();
												break;
											case 16u:
												Alignment = (Alignment)input.ReadEnum();
												break;
											}
										}
									}
								}

								[DebuggerDisplay("{ToString(),nq}")]
								public sealed class TextList : IMessage<TextList>, IMessage, IEquatable<TextList>, IDeepCloneable<TextList>
								{
									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static class Types
									{
										public enum NumberType
										{
											[OriginalName("NUMBER_TYPE_BOX")]
											Box,
											[OriginalName("NUMBER_TYPE_CHECK")]
											Check,
											[OriginalName("NUMBER_TYPE_CIRCLE")]
											Circle,
											[OriginalName("NUMBER_TYPE_DIAMOND")]
											Diamond,
											[OriginalName("NUMBER_TYPE_DISC")]
											Disc,
											[OriginalName("NUMBER_TYPE_HYPHEN")]
											Hyphen,
											[OriginalName("NUMBER_TYPE_SQUARE")]
											Square,
											[OriginalName("NUMBER_TYPE_DECIMAL")]
											Decimal,
											[OriginalName("NUMBER_TYPE_LOWERCASE_ALPHA")]
											LowercaseAlpha,
											[OriginalName("NUMBER_TYPE_UPPERCASE_ALPHA")]
											UppercaseAlpha,
											[OriginalName("NUMBER_TYPE_LOWERCASE_ROMAN")]
											LowercaseRoman,
											[OriginalName("NUMBER_TYPE_UPPERCASE_ROMAN")]
											UppercaseRoman
										}
									}

									private static readonly MessageParser<TextList> _parser = new MessageParser<TextList>(() => new TextList());

									private UnknownFieldSet _unknownFields;

									public const int IsEnabledFieldNumber = 1;

									private bool isEnabled_;

									public const int NumberTypeFieldNumber = 2;

									private Types.NumberType numberType_;

									public const int PrefixFieldNumber = 3;

									private string prefix_ = "";

									public const int PostfixFieldNumber = 4;

									private string postfix_ = "";

									public const int StartingNumberFieldNumber = 5;

									private int startingNumber_;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageParser<TextList> Parser => _parser;

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public static MessageDescriptor Descriptor => Paragraph.Descriptor.NestedTypes[1];

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									MessageDescriptor IMessage.Descriptor => Descriptor;

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
									public Types.NumberType NumberType
									{
										get
										{
											return numberType_;
										}
										set
										{
											numberType_ = value;
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
									public string Postfix
									{
										get
										{
											return postfix_;
										}
										set
										{
											postfix_ = ProtoPreconditions.CheckNotNull(value, "value");
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public int StartingNumber
									{
										get
										{
											return startingNumber_;
										}
										set
										{
											startingNumber_ = value;
										}
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public TextList()
									{
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public TextList(TextList other)
										: this()
									{
										isEnabled_ = other.isEnabled_;
										numberType_ = other.numberType_;
										prefix_ = other.prefix_;
										postfix_ = other.postfix_;
										startingNumber_ = other.startingNumber_;
										_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public TextList Clone()
									{
										return new TextList(this);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public override bool Equals(object other)
									{
										return Equals(other as TextList);
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public bool Equals(TextList other)
									{
										if (other == null)
										{
											return false;
										}
										if (other == this)
										{
											return true;
										}
										if (IsEnabled != other.IsEnabled)
										{
											return false;
										}
										if (NumberType != other.NumberType)
										{
											return false;
										}
										if (Prefix != other.Prefix)
										{
											return false;
										}
										if (Postfix != other.Postfix)
										{
											return false;
										}
										if (StartingNumber != other.StartingNumber)
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
										if (IsEnabled)
										{
											num ^= IsEnabled.GetHashCode();
										}
										if (NumberType != 0)
										{
											num ^= NumberType.GetHashCode();
										}
										if (Prefix.Length != 0)
										{
											num ^= Prefix.GetHashCode();
										}
										if (Postfix.Length != 0)
										{
											num ^= Postfix.GetHashCode();
										}
										if (StartingNumber != 0)
										{
											num ^= StartingNumber.GetHashCode();
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
										if (IsEnabled)
										{
											output.WriteRawTag(8);
											output.WriteBool(IsEnabled);
										}
										if (NumberType != 0)
										{
											output.WriteRawTag(16);
											output.WriteEnum((int)NumberType);
										}
										if (Prefix.Length != 0)
										{
											output.WriteRawTag(26);
											output.WriteString(Prefix);
										}
										if (Postfix.Length != 0)
										{
											output.WriteRawTag(34);
											output.WriteString(Postfix);
										}
										if (StartingNumber != 0)
										{
											output.WriteRawTag(40);
											output.WriteInt32(StartingNumber);
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
										if (IsEnabled)
										{
											num += 2;
										}
										if (NumberType != 0)
										{
											num += 1 + CodedOutputStream.ComputeEnumSize((int)NumberType);
										}
										if (Prefix.Length != 0)
										{
											num += 1 + CodedOutputStream.ComputeStringSize(Prefix);
										}
										if (Postfix.Length != 0)
										{
											num += 1 + CodedOutputStream.ComputeStringSize(Postfix);
										}
										if (StartingNumber != 0)
										{
											num += 1 + CodedOutputStream.ComputeInt32Size(StartingNumber);
										}
										if (_unknownFields != null)
										{
											num += _unknownFields.CalculateSize();
										}
										return num;
									}

									[DebuggerNonUserCode]
									[GeneratedCode("protoc", null)]
									public void MergeFrom(TextList other)
									{
										if (other != null)
										{
											if (other.IsEnabled)
											{
												IsEnabled = other.IsEnabled;
											}
											if (other.NumberType != 0)
											{
												NumberType = other.NumberType;
											}
											if (other.Prefix.Length != 0)
											{
												Prefix = other.Prefix;
											}
											if (other.Postfix.Length != 0)
											{
												Postfix = other.Postfix;
											}
											if (other.StartingNumber != 0)
											{
												StartingNumber = other.StartingNumber;
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
												IsEnabled = input.ReadBool();
												break;
											case 16u:
												NumberType = (Types.NumberType)input.ReadEnum();
												break;
											case 26u:
												Prefix = input.ReadString();
												break;
											case 34u:
												Postfix = input.ReadString();
												break;
											case 40u:
												StartingNumber = input.ReadInt32();
												break;
											}
										}
									}
								}
							}

							private static readonly MessageParser<Paragraph> _parser = new MessageParser<Paragraph>(() => new Paragraph());

							private UnknownFieldSet _unknownFields;

							public const int AlignmentFieldNumber = 1;

							private Alignment alignment_;

							public const int FirstLineHeadIndentFieldNumber = 2;

							private double firstLineHeadIndent_;

							public const int HeadIndentFieldNumber = 3;

							private double headIndent_;

							public const int TailIndentFieldNumber = 4;

							private double tailIndent_;

							public const int LineHeightMultipleFieldNumber = 5;

							private double lineHeightMultiple_;

							public const int MaximumLineHeightFieldNumber = 6;

							private double maximumLineHeight_;

							public const int MinimumLineHeightFieldNumber = 7;

							private double minimumLineHeight_;

							public const int LineSpacingFieldNumber = 8;

							private double lineSpacing_;

							public const int ParagraphSpacingFieldNumber = 9;

							private double paragraphSpacing_;

							public const int ParagraphSpacingBeforeFieldNumber = 10;

							private double paragraphSpacingBefore_;

							public const int TabStopsFieldNumber = 11;

							private static readonly FieldCodec<Types.TabStop> _repeated_tabStops_codec = FieldCodec.ForMessage(90u, Types.TabStop.Parser);

							private readonly RepeatedField<Types.TabStop> tabStops_ = new RepeatedField<Types.TabStop>();

							public const int DefaultTabIntervalFieldNumber = 12;

							private double defaultTabInterval_;

							public const int TextListFieldNumber = 13;

							private Types.TextList textList_;

							public const int TextListsFieldNumber = 14;

							private static readonly FieldCodec<Types.TextList> _repeated_textLists_codec = FieldCodec.ForMessage(114u, Types.TextList.Parser);

							private readonly RepeatedField<Types.TextList> textLists_ = new RepeatedField<Types.TextList>();

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Paragraph> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Attributes.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Alignment Alignment
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
							public double FirstLineHeadIndent
							{
								get
								{
									return firstLineHeadIndent_;
								}
								set
								{
									firstLineHeadIndent_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double HeadIndent
							{
								get
								{
									return headIndent_;
								}
								set
								{
									headIndent_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double TailIndent
							{
								get
								{
									return tailIndent_;
								}
								set
								{
									tailIndent_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double LineHeightMultiple
							{
								get
								{
									return lineHeightMultiple_;
								}
								set
								{
									lineHeightMultiple_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double MaximumLineHeight
							{
								get
								{
									return maximumLineHeight_;
								}
								set
								{
									maximumLineHeight_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double MinimumLineHeight
							{
								get
								{
									return minimumLineHeight_;
								}
								set
								{
									minimumLineHeight_ = value;
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
							public double ParagraphSpacing
							{
								get
								{
									return paragraphSpacing_;
								}
								set
								{
									paragraphSpacing_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double ParagraphSpacingBefore
							{
								get
								{
									return paragraphSpacingBefore_;
								}
								set
								{
									paragraphSpacingBefore_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<Types.TabStop> TabStops => tabStops_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double DefaultTabInterval
							{
								get
								{
									return defaultTabInterval_;
								}
								set
								{
									defaultTabInterval_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Types.TextList TextList
							{
								get
								{
									return textList_;
								}
								set
								{
									textList_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public RepeatedField<Types.TextList> TextLists => textLists_;

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
								alignment_ = other.alignment_;
								firstLineHeadIndent_ = other.firstLineHeadIndent_;
								headIndent_ = other.headIndent_;
								tailIndent_ = other.tailIndent_;
								lineHeightMultiple_ = other.lineHeightMultiple_;
								maximumLineHeight_ = other.maximumLineHeight_;
								minimumLineHeight_ = other.minimumLineHeight_;
								lineSpacing_ = other.lineSpacing_;
								paragraphSpacing_ = other.paragraphSpacing_;
								paragraphSpacingBefore_ = other.paragraphSpacingBefore_;
								tabStops_ = other.tabStops_.Clone();
								defaultTabInterval_ = other.defaultTabInterval_;
								textList_ = ((other.textList_ != null) ? other.textList_.Clone() : null);
								textLists_ = other.textLists_.Clone();
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
								if (Alignment != other.Alignment)
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FirstLineHeadIndent, other.FirstLineHeadIndent))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(HeadIndent, other.HeadIndent))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TailIndent, other.TailIndent))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LineHeightMultiple, other.LineHeightMultiple))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(MaximumLineHeight, other.MaximumLineHeight))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(MinimumLineHeight, other.MinimumLineHeight))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(LineSpacing, other.LineSpacing))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(ParagraphSpacing, other.ParagraphSpacing))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(ParagraphSpacingBefore, other.ParagraphSpacingBefore))
								{
									return false;
								}
								if (!tabStops_.Equals(other.tabStops_))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(DefaultTabInterval, other.DefaultTabInterval))
								{
									return false;
								}
								if (!object.Equals(TextList, other.TextList))
								{
									return false;
								}
								if (!textLists_.Equals(other.textLists_))
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
								if (FirstLineHeadIndent != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FirstLineHeadIndent);
								}
								if (HeadIndent != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(HeadIndent);
								}
								if (TailIndent != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TailIndent);
								}
								if (LineHeightMultiple != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LineHeightMultiple);
								}
								if (MaximumLineHeight != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(MaximumLineHeight);
								}
								if (MinimumLineHeight != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(MinimumLineHeight);
								}
								if (LineSpacing != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(LineSpacing);
								}
								if (ParagraphSpacing != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(ParagraphSpacing);
								}
								if (ParagraphSpacingBefore != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(ParagraphSpacingBefore);
								}
								num ^= tabStops_.GetHashCode();
								if (DefaultTabInterval != 0.0)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(DefaultTabInterval);
								}
								if (textList_ != null)
								{
									num ^= TextList.GetHashCode();
								}
								num ^= textLists_.GetHashCode();
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
								if (FirstLineHeadIndent != 0.0)
								{
									output.WriteRawTag(17);
									output.WriteDouble(FirstLineHeadIndent);
								}
								if (HeadIndent != 0.0)
								{
									output.WriteRawTag(25);
									output.WriteDouble(HeadIndent);
								}
								if (TailIndent != 0.0)
								{
									output.WriteRawTag(33);
									output.WriteDouble(TailIndent);
								}
								if (LineHeightMultiple != 0.0)
								{
									output.WriteRawTag(41);
									output.WriteDouble(LineHeightMultiple);
								}
								if (MaximumLineHeight != 0.0)
								{
									output.WriteRawTag(49);
									output.WriteDouble(MaximumLineHeight);
								}
								if (MinimumLineHeight != 0.0)
								{
									output.WriteRawTag(57);
									output.WriteDouble(MinimumLineHeight);
								}
								if (LineSpacing != 0.0)
								{
									output.WriteRawTag(65);
									output.WriteDouble(LineSpacing);
								}
								if (ParagraphSpacing != 0.0)
								{
									output.WriteRawTag(73);
									output.WriteDouble(ParagraphSpacing);
								}
								if (ParagraphSpacingBefore != 0.0)
								{
									output.WriteRawTag(81);
									output.WriteDouble(ParagraphSpacingBefore);
								}
								tabStops_.WriteTo(output, _repeated_tabStops_codec);
								if (DefaultTabInterval != 0.0)
								{
									output.WriteRawTag(97);
									output.WriteDouble(DefaultTabInterval);
								}
								if (textList_ != null)
								{
									output.WriteRawTag(106);
									output.WriteMessage(TextList);
								}
								textLists_.WriteTo(output, _repeated_textLists_codec);
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
								if (FirstLineHeadIndent != 0.0)
								{
									num += 9;
								}
								if (HeadIndent != 0.0)
								{
									num += 9;
								}
								if (TailIndent != 0.0)
								{
									num += 9;
								}
								if (LineHeightMultiple != 0.0)
								{
									num += 9;
								}
								if (MaximumLineHeight != 0.0)
								{
									num += 9;
								}
								if (MinimumLineHeight != 0.0)
								{
									num += 9;
								}
								if (LineSpacing != 0.0)
								{
									num += 9;
								}
								if (ParagraphSpacing != 0.0)
								{
									num += 9;
								}
								if (ParagraphSpacingBefore != 0.0)
								{
									num += 9;
								}
								num += tabStops_.CalculateSize(_repeated_tabStops_codec);
								if (DefaultTabInterval != 0.0)
								{
									num += 9;
								}
								if (textList_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TextList);
								}
								num += textLists_.CalculateSize(_repeated_textLists_codec);
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
								if (other.Alignment != 0)
								{
									Alignment = other.Alignment;
								}
								if (other.FirstLineHeadIndent != 0.0)
								{
									FirstLineHeadIndent = other.FirstLineHeadIndent;
								}
								if (other.HeadIndent != 0.0)
								{
									HeadIndent = other.HeadIndent;
								}
								if (other.TailIndent != 0.0)
								{
									TailIndent = other.TailIndent;
								}
								if (other.LineHeightMultiple != 0.0)
								{
									LineHeightMultiple = other.LineHeightMultiple;
								}
								if (other.MaximumLineHeight != 0.0)
								{
									MaximumLineHeight = other.MaximumLineHeight;
								}
								if (other.MinimumLineHeight != 0.0)
								{
									MinimumLineHeight = other.MinimumLineHeight;
								}
								if (other.LineSpacing != 0.0)
								{
									LineSpacing = other.LineSpacing;
								}
								if (other.ParagraphSpacing != 0.0)
								{
									ParagraphSpacing = other.ParagraphSpacing;
								}
								if (other.ParagraphSpacingBefore != 0.0)
								{
									ParagraphSpacingBefore = other.ParagraphSpacingBefore;
								}
								tabStops_.Add(other.tabStops_);
								if (other.DefaultTabInterval != 0.0)
								{
									DefaultTabInterval = other.DefaultTabInterval;
								}
								if (other.textList_ != null)
								{
									if (textList_ == null)
									{
										TextList = new Types.TextList();
									}
									TextList.MergeFrom(other.TextList);
								}
								textLists_.Add(other.textLists_);
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
										Alignment = (Alignment)input.ReadEnum();
										break;
									case 17u:
										FirstLineHeadIndent = input.ReadDouble();
										break;
									case 25u:
										HeadIndent = input.ReadDouble();
										break;
									case 33u:
										TailIndent = input.ReadDouble();
										break;
									case 41u:
										LineHeightMultiple = input.ReadDouble();
										break;
									case 49u:
										MaximumLineHeight = input.ReadDouble();
										break;
									case 57u:
										MinimumLineHeight = input.ReadDouble();
										break;
									case 65u:
										LineSpacing = input.ReadDouble();
										break;
									case 73u:
										ParagraphSpacing = input.ReadDouble();
										break;
									case 81u:
										ParagraphSpacingBefore = input.ReadDouble();
										break;
									case 90u:
										tabStops_.AddEntriesFrom(input, _repeated_tabStops_codec);
										break;
									case 97u:
										DefaultTabInterval = input.ReadDouble();
										break;
									case 106u:
										if (textList_ == null)
										{
											TextList = new Types.TextList();
										}
										input.ReadMessage(TextList);
										break;
									case 114u:
										textLists_.AddEntriesFrom(input, _repeated_textLists_codec);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class CustomAttribute : IMessage<CustomAttribute>, IMessage, IEquatable<CustomAttribute>, IDeepCloneable<CustomAttribute>
						{
							public enum AttributeOneofCase
							{
								None = 0,
								Capitalization = 2,
								OriginalFontSize = 3,
								FontScaleFactor = 4,
								TextGradientFill = 5,
								ShouldPreserveForegroundColor = 6,
								Chord = 7,
								CutOutFill = 8,
								MediaFill = 9,
								BackgroundEffect = 10,
								CharacterSizeMode = 11,
								OriginalFont = 12
							}

							private static readonly MessageParser<CustomAttribute> _parser = new MessageParser<CustomAttribute>(() => new CustomAttribute());

							private UnknownFieldSet _unknownFields;

							public const int RangeFieldNumber = 1;

							private IntRange range_;

							public const int CapitalizationFieldNumber = 2;

							public const int OriginalFontSizeFieldNumber = 3;

							public const int FontScaleFactorFieldNumber = 4;

							public const int TextGradientFillFieldNumber = 5;

							public const int ShouldPreserveForegroundColorFieldNumber = 6;

							public const int ChordFieldNumber = 7;

							public const int CutOutFillFieldNumber = 8;

							public const int MediaFillFieldNumber = 9;

							public const int BackgroundEffectFieldNumber = 10;

							public const int CharacterSizeModeFieldNumber = 11;

							public const int OriginalFontFieldNumber = 12;

							private object attribute_;

							private AttributeOneofCase attributeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<CustomAttribute> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Attributes.Descriptor.NestedTypes[2];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public IntRange Range
							{
								get
								{
									return range_;
								}
								set
								{
									range_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Capitalization Capitalization
							{
								get
								{
									if (!HasCapitalization)
									{
										return Capitalization.None;
									}
									return (Capitalization)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = AttributeOneofCase.Capitalization;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool HasCapitalization => attributeCase_ == AttributeOneofCase.Capitalization;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double OriginalFontSize
							{
								get
								{
									if (!HasOriginalFontSize)
									{
										return 0.0;
									}
									return (double)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = AttributeOneofCase.OriginalFontSize;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool HasOriginalFontSize => attributeCase_ == AttributeOneofCase.OriginalFontSize;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public double FontScaleFactor
							{
								get
								{
									if (!HasFontScaleFactor)
									{
										return 0.0;
									}
									return (double)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = AttributeOneofCase.FontScaleFactor;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool HasFontScaleFactor => attributeCase_ == AttributeOneofCase.FontScaleFactor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public GradientFill TextGradientFill
							{
								get
								{
									if (attributeCase_ != AttributeOneofCase.TextGradientFill)
									{
										return null;
									}
									return (GradientFill)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = ((value != null) ? AttributeOneofCase.TextGradientFill : AttributeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool ShouldPreserveForegroundColor
							{
								get
								{
									if (!HasShouldPreserveForegroundColor)
									{
										return false;
									}
									return (bool)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = AttributeOneofCase.ShouldPreserveForegroundColor;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool HasShouldPreserveForegroundColor => attributeCase_ == AttributeOneofCase.ShouldPreserveForegroundColor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public string Chord
							{
								get
								{
									if (!HasChord)
									{
										return "";
									}
									return (string)attribute_;
								}
								set
								{
									attribute_ = ProtoPreconditions.CheckNotNull(value, "value");
									attributeCase_ = AttributeOneofCase.Chord;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool HasChord => attributeCase_ == AttributeOneofCase.Chord;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CutOutFill CutOutFill
							{
								get
								{
									if (attributeCase_ != AttributeOneofCase.CutOutFill)
									{
										return null;
									}
									return (CutOutFill)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = ((value != null) ? AttributeOneofCase.CutOutFill : AttributeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public MediaFill MediaFill
							{
								get
								{
									if (attributeCase_ != AttributeOneofCase.MediaFill)
									{
										return null;
									}
									return (MediaFill)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = ((value != null) ? AttributeOneofCase.MediaFill : AttributeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public BackgroundEffect BackgroundEffect
							{
								get
								{
									if (attributeCase_ != AttributeOneofCase.BackgroundEffect)
									{
										return null;
									}
									return (BackgroundEffect)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = ((value != null) ? AttributeOneofCase.BackgroundEffect : AttributeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CharacterSizeMode CharacterSizeMode
							{
								get
								{
									if (!HasCharacterSizeMode)
									{
										return CharacterSizeMode.Normal;
									}
									return (CharacterSizeMode)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = AttributeOneofCase.CharacterSizeMode;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool HasCharacterSizeMode => attributeCase_ == AttributeOneofCase.CharacterSizeMode;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Font OriginalFont
							{
								get
								{
									if (attributeCase_ != AttributeOneofCase.OriginalFont)
									{
										return null;
									}
									return (Font)attribute_;
								}
								set
								{
									attribute_ = value;
									attributeCase_ = ((value != null) ? AttributeOneofCase.OriginalFont : AttributeOneofCase.None);
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public AttributeOneofCase AttributeCase => attributeCase_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CustomAttribute()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CustomAttribute(CustomAttribute other)
								: this()
							{
								range_ = ((other.range_ != null) ? other.range_.Clone() : null);
								switch (other.AttributeCase)
								{
								case AttributeOneofCase.Capitalization:
									Capitalization = other.Capitalization;
									break;
								case AttributeOneofCase.OriginalFontSize:
									OriginalFontSize = other.OriginalFontSize;
									break;
								case AttributeOneofCase.FontScaleFactor:
									FontScaleFactor = other.FontScaleFactor;
									break;
								case AttributeOneofCase.TextGradientFill:
									TextGradientFill = other.TextGradientFill.Clone();
									break;
								case AttributeOneofCase.ShouldPreserveForegroundColor:
									ShouldPreserveForegroundColor = other.ShouldPreserveForegroundColor;
									break;
								case AttributeOneofCase.Chord:
									Chord = other.Chord;
									break;
								case AttributeOneofCase.CutOutFill:
									CutOutFill = other.CutOutFill.Clone();
									break;
								case AttributeOneofCase.MediaFill:
									MediaFill = other.MediaFill.Clone();
									break;
								case AttributeOneofCase.BackgroundEffect:
									BackgroundEffect = other.BackgroundEffect.Clone();
									break;
								case AttributeOneofCase.CharacterSizeMode:
									CharacterSizeMode = other.CharacterSizeMode;
									break;
								case AttributeOneofCase.OriginalFont:
									OriginalFont = other.OriginalFont.Clone();
									break;
								}
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CustomAttribute Clone()
							{
								return new CustomAttribute(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearCapitalization()
							{
								if (HasCapitalization)
								{
									ClearAttribute();
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearOriginalFontSize()
							{
								if (HasOriginalFontSize)
								{
									ClearAttribute();
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearFontScaleFactor()
							{
								if (HasFontScaleFactor)
								{
									ClearAttribute();
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearShouldPreserveForegroundColor()
							{
								if (HasShouldPreserveForegroundColor)
								{
									ClearAttribute();
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearChord()
							{
								if (HasChord)
								{
									ClearAttribute();
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearCharacterSizeMode()
							{
								if (HasCharacterSizeMode)
								{
									ClearAttribute();
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void ClearAttribute()
							{
								attributeCase_ = AttributeOneofCase.None;
								attribute_ = null;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as CustomAttribute);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(CustomAttribute other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Range, other.Range))
								{
									return false;
								}
								if (Capitalization != other.Capitalization)
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(OriginalFontSize, other.OriginalFontSize))
								{
									return false;
								}
								if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FontScaleFactor, other.FontScaleFactor))
								{
									return false;
								}
								if (!object.Equals(TextGradientFill, other.TextGradientFill))
								{
									return false;
								}
								if (ShouldPreserveForegroundColor != other.ShouldPreserveForegroundColor)
								{
									return false;
								}
								if (Chord != other.Chord)
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
								if (!object.Equals(BackgroundEffect, other.BackgroundEffect))
								{
									return false;
								}
								if (CharacterSizeMode != other.CharacterSizeMode)
								{
									return false;
								}
								if (!object.Equals(OriginalFont, other.OriginalFont))
								{
									return false;
								}
								if (AttributeCase != other.AttributeCase)
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
								if (range_ != null)
								{
									num ^= Range.GetHashCode();
								}
								if (HasCapitalization)
								{
									num ^= Capitalization.GetHashCode();
								}
								if (HasOriginalFontSize)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(OriginalFontSize);
								}
								if (HasFontScaleFactor)
								{
									num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FontScaleFactor);
								}
								if (attributeCase_ == AttributeOneofCase.TextGradientFill)
								{
									num ^= TextGradientFill.GetHashCode();
								}
								if (HasShouldPreserveForegroundColor)
								{
									num ^= ShouldPreserveForegroundColor.GetHashCode();
								}
								if (HasChord)
								{
									num ^= Chord.GetHashCode();
								}
								if (attributeCase_ == AttributeOneofCase.CutOutFill)
								{
									num ^= CutOutFill.GetHashCode();
								}
								if (attributeCase_ == AttributeOneofCase.MediaFill)
								{
									num ^= MediaFill.GetHashCode();
								}
								if (attributeCase_ == AttributeOneofCase.BackgroundEffect)
								{
									num ^= BackgroundEffect.GetHashCode();
								}
								if (HasCharacterSizeMode)
								{
									num ^= CharacterSizeMode.GetHashCode();
								}
								if (attributeCase_ == AttributeOneofCase.OriginalFont)
								{
									num ^= OriginalFont.GetHashCode();
								}
								num ^= (int)attributeCase_;
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
								if (range_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Range);
								}
								if (HasCapitalization)
								{
									output.WriteRawTag(16);
									output.WriteEnum((int)Capitalization);
								}
								if (HasOriginalFontSize)
								{
									output.WriteRawTag(25);
									output.WriteDouble(OriginalFontSize);
								}
								if (HasFontScaleFactor)
								{
									output.WriteRawTag(33);
									output.WriteDouble(FontScaleFactor);
								}
								if (attributeCase_ == AttributeOneofCase.TextGradientFill)
								{
									output.WriteRawTag(42);
									output.WriteMessage(TextGradientFill);
								}
								if (HasShouldPreserveForegroundColor)
								{
									output.WriteRawTag(48);
									output.WriteBool(ShouldPreserveForegroundColor);
								}
								if (HasChord)
								{
									output.WriteRawTag(58);
									output.WriteString(Chord);
								}
								if (attributeCase_ == AttributeOneofCase.CutOutFill)
								{
									output.WriteRawTag(66);
									output.WriteMessage(CutOutFill);
								}
								if (attributeCase_ == AttributeOneofCase.MediaFill)
								{
									output.WriteRawTag(74);
									output.WriteMessage(MediaFill);
								}
								if (attributeCase_ == AttributeOneofCase.BackgroundEffect)
								{
									output.WriteRawTag(82);
									output.WriteMessage(BackgroundEffect);
								}
								if (HasCharacterSizeMode)
								{
									output.WriteRawTag(88);
									output.WriteEnum((int)CharacterSizeMode);
								}
								if (attributeCase_ == AttributeOneofCase.OriginalFont)
								{
									output.WriteRawTag(98);
									output.WriteMessage(OriginalFont);
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
								if (range_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Range);
								}
								if (HasCapitalization)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)Capitalization);
								}
								if (HasOriginalFontSize)
								{
									num += 9;
								}
								if (HasFontScaleFactor)
								{
									num += 9;
								}
								if (attributeCase_ == AttributeOneofCase.TextGradientFill)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(TextGradientFill);
								}
								if (HasShouldPreserveForegroundColor)
								{
									num += 2;
								}
								if (HasChord)
								{
									num += 1 + CodedOutputStream.ComputeStringSize(Chord);
								}
								if (attributeCase_ == AttributeOneofCase.CutOutFill)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(CutOutFill);
								}
								if (attributeCase_ == AttributeOneofCase.MediaFill)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(MediaFill);
								}
								if (attributeCase_ == AttributeOneofCase.BackgroundEffect)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundEffect);
								}
								if (HasCharacterSizeMode)
								{
									num += 1 + CodedOutputStream.ComputeEnumSize((int)CharacterSizeMode);
								}
								if (attributeCase_ == AttributeOneofCase.OriginalFont)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(OriginalFont);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(CustomAttribute other)
							{
								if (other == null)
								{
									return;
								}
								if (other.range_ != null)
								{
									if (range_ == null)
									{
										Range = new IntRange();
									}
									Range.MergeFrom(other.Range);
								}
								switch (other.AttributeCase)
								{
								case AttributeOneofCase.Capitalization:
									Capitalization = other.Capitalization;
									break;
								case AttributeOneofCase.OriginalFontSize:
									OriginalFontSize = other.OriginalFontSize;
									break;
								case AttributeOneofCase.FontScaleFactor:
									FontScaleFactor = other.FontScaleFactor;
									break;
								case AttributeOneofCase.TextGradientFill:
									if (TextGradientFill == null)
									{
										TextGradientFill = new GradientFill();
									}
									TextGradientFill.MergeFrom(other.TextGradientFill);
									break;
								case AttributeOneofCase.ShouldPreserveForegroundColor:
									ShouldPreserveForegroundColor = other.ShouldPreserveForegroundColor;
									break;
								case AttributeOneofCase.Chord:
									Chord = other.Chord;
									break;
								case AttributeOneofCase.CutOutFill:
									if (CutOutFill == null)
									{
										CutOutFill = new CutOutFill();
									}
									CutOutFill.MergeFrom(other.CutOutFill);
									break;
								case AttributeOneofCase.MediaFill:
									if (MediaFill == null)
									{
										MediaFill = new MediaFill();
									}
									MediaFill.MergeFrom(other.MediaFill);
									break;
								case AttributeOneofCase.BackgroundEffect:
									if (BackgroundEffect == null)
									{
										BackgroundEffect = new BackgroundEffect();
									}
									BackgroundEffect.MergeFrom(other.BackgroundEffect);
									break;
								case AttributeOneofCase.CharacterSizeMode:
									CharacterSizeMode = other.CharacterSizeMode;
									break;
								case AttributeOneofCase.OriginalFont:
									if (OriginalFont == null)
									{
										OriginalFont = new Font();
									}
									OriginalFont.MergeFrom(other.OriginalFont);
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
										if (range_ == null)
										{
											Range = new IntRange();
										}
										input.ReadMessage(Range);
										break;
									case 16u:
										attribute_ = input.ReadEnum();
										attributeCase_ = AttributeOneofCase.Capitalization;
										break;
									case 25u:
										OriginalFontSize = input.ReadDouble();
										break;
									case 33u:
										FontScaleFactor = input.ReadDouble();
										break;
									case 42u:
									{
										GradientFill gradientFill = new GradientFill();
										if (attributeCase_ == AttributeOneofCase.TextGradientFill)
										{
											gradientFill.MergeFrom(TextGradientFill);
										}
										input.ReadMessage(gradientFill);
										TextGradientFill = gradientFill;
										break;
									}
									case 48u:
										ShouldPreserveForegroundColor = input.ReadBool();
										break;
									case 58u:
										Chord = input.ReadString();
										break;
									case 66u:
									{
										CutOutFill cutOutFill = new CutOutFill();
										if (attributeCase_ == AttributeOneofCase.CutOutFill)
										{
											cutOutFill.MergeFrom(CutOutFill);
										}
										input.ReadMessage(cutOutFill);
										CutOutFill = cutOutFill;
										break;
									}
									case 74u:
									{
										MediaFill mediaFill = new MediaFill();
										if (attributeCase_ == AttributeOneofCase.MediaFill)
										{
											mediaFill.MergeFrom(MediaFill);
										}
										input.ReadMessage(mediaFill);
										MediaFill = mediaFill;
										break;
									}
									case 82u:
									{
										BackgroundEffect backgroundEffect = new BackgroundEffect();
										if (attributeCase_ == AttributeOneofCase.BackgroundEffect)
										{
											backgroundEffect.MergeFrom(BackgroundEffect);
										}
										input.ReadMessage(backgroundEffect);
										BackgroundEffect = backgroundEffect;
										break;
									}
									case 88u:
										attribute_ = input.ReadEnum();
										attributeCase_ = AttributeOneofCase.CharacterSizeMode;
										break;
									case 98u:
									{
										Font font = new Font();
										if (attributeCase_ == AttributeOneofCase.OriginalFont)
										{
											font.MergeFrom(OriginalFont);
										}
										input.ReadMessage(font);
										OriginalFont = font;
										break;
									}
									}
								}
							}
						}
					}

					private static readonly MessageParser<Attributes> _parser = new MessageParser<Attributes>(() => new Attributes());

					private UnknownFieldSet _unknownFields;

					public const int FontFieldNumber = 1;

					private Font font_;

					public const int CapitalizationFieldNumber = 2;

					private Types.Capitalization capitalization_;

					public const int TextSolidFillFieldNumber = 3;

					public const int TextGradientFillFieldNumber = 14;

					public const int CutOutFillFieldNumber = 16;

					public const int MediaFillFieldNumber = 17;

					public const int BackgroundEffectFieldNumber = 18;

					public const int UnderlineStyleFieldNumber = 4;

					private Types.Underline underlineStyle_;

					public const int UnderlineColorFieldNumber = 5;

					private Color underlineColor_;

					public const int ParagraphStyleFieldNumber = 6;

					private Types.Paragraph paragraphStyle_;

					public const int KerningFieldNumber = 7;

					private double kerning_;

					public const int SuperscriptFieldNumber = 8;

					private int superscript_;

					public const int StrikethroughStyleFieldNumber = 9;

					private Types.Underline strikethroughStyle_;

					public const int StrikethroughColorFieldNumber = 10;

					private Color strikethroughColor_;

					public const int StrokeWidthFieldNumber = 11;

					private double strokeWidth_;

					public const int StrokeColorFieldNumber = 12;

					private Color strokeColor_;

					public const int CustomAttributesFieldNumber = 13;

					private static readonly FieldCodec<Types.CustomAttribute> _repeated_customAttributes_codec = FieldCodec.ForMessage(106u, Types.CustomAttribute.Parser);

					private readonly RepeatedField<Types.CustomAttribute> customAttributes_ = new RepeatedField<Types.CustomAttribute>();

					public const int BackgroundColorFieldNumber = 15;

					private Color backgroundColor_;

					public const int LigatureStyleFieldNumber = 19;

					private Types.LigatureStyle ligatureStyle_;

					private object fill_;

					private FillOneofCase fillCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Attributes> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Text.Descriptor.NestedTypes[5];

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
					public Types.Capitalization Capitalization
					{
						get
						{
							return capitalization_;
						}
						set
						{
							capitalization_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Color TextSolidFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.TextSolidFill)
							{
								return null;
							}
							return (Color)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.TextSolidFill : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GradientFill TextGradientFill
					{
						get
						{
							if (fillCase_ != FillOneofCase.TextGradientFill)
							{
								return null;
							}
							return (GradientFill)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.TextGradientFill : FillOneofCase.None);
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
					public BackgroundEffect BackgroundEffect
					{
						get
						{
							if (fillCase_ != FillOneofCase.BackgroundEffect)
							{
								return null;
							}
							return (BackgroundEffect)fill_;
						}
						set
						{
							fill_ = value;
							fillCase_ = ((value != null) ? FillOneofCase.BackgroundEffect : FillOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Underline UnderlineStyle
					{
						get
						{
							return underlineStyle_;
						}
						set
						{
							underlineStyle_ = value;
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
					public Types.Paragraph ParagraphStyle
					{
						get
						{
							return paragraphStyle_;
						}
						set
						{
							paragraphStyle_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Kerning
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
					public int Superscript
					{
						get
						{
							return superscript_;
						}
						set
						{
							superscript_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Underline StrikethroughStyle
					{
						get
						{
							return strikethroughStyle_;
						}
						set
						{
							strikethroughStyle_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Color StrikethroughColor
					{
						get
						{
							return strikethroughColor_;
						}
						set
						{
							strikethroughColor_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double StrokeWidth
					{
						get
						{
							return strokeWidth_;
						}
						set
						{
							strokeWidth_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Color StrokeColor
					{
						get
						{
							return strokeColor_;
						}
						set
						{
							strokeColor_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<Types.CustomAttribute> CustomAttributes => customAttributes_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Color BackgroundColor
					{
						get
						{
							return backgroundColor_;
						}
						set
						{
							backgroundColor_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.LigatureStyle LigatureStyle
					{
						get
						{
							return ligatureStyle_;
						}
						set
						{
							ligatureStyle_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public FillOneofCase FillCase => fillCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Attributes()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Attributes(Attributes other)
						: this()
					{
						font_ = ((other.font_ != null) ? other.font_.Clone() : null);
						capitalization_ = other.capitalization_;
						underlineStyle_ = ((other.underlineStyle_ != null) ? other.underlineStyle_.Clone() : null);
						underlineColor_ = ((other.underlineColor_ != null) ? other.underlineColor_.Clone() : null);
						paragraphStyle_ = ((other.paragraphStyle_ != null) ? other.paragraphStyle_.Clone() : null);
						kerning_ = other.kerning_;
						superscript_ = other.superscript_;
						strikethroughStyle_ = ((other.strikethroughStyle_ != null) ? other.strikethroughStyle_.Clone() : null);
						strikethroughColor_ = ((other.strikethroughColor_ != null) ? other.strikethroughColor_.Clone() : null);
						strokeWidth_ = other.strokeWidth_;
						strokeColor_ = ((other.strokeColor_ != null) ? other.strokeColor_.Clone() : null);
						customAttributes_ = other.customAttributes_.Clone();
						backgroundColor_ = ((other.backgroundColor_ != null) ? other.backgroundColor_.Clone() : null);
						ligatureStyle_ = other.ligatureStyle_;
						switch (other.FillCase)
						{
						case FillOneofCase.TextSolidFill:
							TextSolidFill = other.TextSolidFill.Clone();
							break;
						case FillOneofCase.TextGradientFill:
							TextGradientFill = other.TextGradientFill.Clone();
							break;
						case FillOneofCase.CutOutFill:
							CutOutFill = other.CutOutFill.Clone();
							break;
						case FillOneofCase.MediaFill:
							MediaFill = other.MediaFill.Clone();
							break;
						case FillOneofCase.BackgroundEffect:
							BackgroundEffect = other.BackgroundEffect.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Attributes Clone()
					{
						return new Attributes(this);
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
						return Equals(other as Attributes);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Attributes other)
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
						if (Capitalization != other.Capitalization)
						{
							return false;
						}
						if (!object.Equals(TextSolidFill, other.TextSolidFill))
						{
							return false;
						}
						if (!object.Equals(TextGradientFill, other.TextGradientFill))
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
						if (!object.Equals(BackgroundEffect, other.BackgroundEffect))
						{
							return false;
						}
						if (!object.Equals(UnderlineStyle, other.UnderlineStyle))
						{
							return false;
						}
						if (!object.Equals(UnderlineColor, other.UnderlineColor))
						{
							return false;
						}
						if (!object.Equals(ParagraphStyle, other.ParagraphStyle))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Kerning, other.Kerning))
						{
							return false;
						}
						if (Superscript != other.Superscript)
						{
							return false;
						}
						if (!object.Equals(StrikethroughStyle, other.StrikethroughStyle))
						{
							return false;
						}
						if (!object.Equals(StrikethroughColor, other.StrikethroughColor))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(StrokeWidth, other.StrokeWidth))
						{
							return false;
						}
						if (!object.Equals(StrokeColor, other.StrokeColor))
						{
							return false;
						}
						if (!customAttributes_.Equals(other.customAttributes_))
						{
							return false;
						}
						if (!object.Equals(BackgroundColor, other.BackgroundColor))
						{
							return false;
						}
						if (LigatureStyle != other.LigatureStyle)
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
						if (font_ != null)
						{
							num ^= Font.GetHashCode();
						}
						if (Capitalization != 0)
						{
							num ^= Capitalization.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.TextSolidFill)
						{
							num ^= TextSolidFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.TextGradientFill)
						{
							num ^= TextGradientFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.CutOutFill)
						{
							num ^= CutOutFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.MediaFill)
						{
							num ^= MediaFill.GetHashCode();
						}
						if (fillCase_ == FillOneofCase.BackgroundEffect)
						{
							num ^= BackgroundEffect.GetHashCode();
						}
						if (underlineStyle_ != null)
						{
							num ^= UnderlineStyle.GetHashCode();
						}
						if (underlineColor_ != null)
						{
							num ^= UnderlineColor.GetHashCode();
						}
						if (paragraphStyle_ != null)
						{
							num ^= ParagraphStyle.GetHashCode();
						}
						if (Kerning != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Kerning);
						}
						if (Superscript != 0)
						{
							num ^= Superscript.GetHashCode();
						}
						if (strikethroughStyle_ != null)
						{
							num ^= StrikethroughStyle.GetHashCode();
						}
						if (strikethroughColor_ != null)
						{
							num ^= StrikethroughColor.GetHashCode();
						}
						if (StrokeWidth != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(StrokeWidth);
						}
						if (strokeColor_ != null)
						{
							num ^= StrokeColor.GetHashCode();
						}
						num ^= customAttributes_.GetHashCode();
						if (backgroundColor_ != null)
						{
							num ^= BackgroundColor.GetHashCode();
						}
						if (LigatureStyle != 0)
						{
							num ^= LigatureStyle.GetHashCode();
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
						if (font_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Font);
						}
						if (Capitalization != 0)
						{
							output.WriteRawTag(16);
							output.WriteEnum((int)Capitalization);
						}
						if (fillCase_ == FillOneofCase.TextSolidFill)
						{
							output.WriteRawTag(26);
							output.WriteMessage(TextSolidFill);
						}
						if (underlineStyle_ != null)
						{
							output.WriteRawTag(34);
							output.WriteMessage(UnderlineStyle);
						}
						if (underlineColor_ != null)
						{
							output.WriteRawTag(42);
							output.WriteMessage(UnderlineColor);
						}
						if (paragraphStyle_ != null)
						{
							output.WriteRawTag(50);
							output.WriteMessage(ParagraphStyle);
						}
						if (Kerning != 0.0)
						{
							output.WriteRawTag(57);
							output.WriteDouble(Kerning);
						}
						if (Superscript != 0)
						{
							output.WriteRawTag(64);
							output.WriteInt32(Superscript);
						}
						if (strikethroughStyle_ != null)
						{
							output.WriteRawTag(74);
							output.WriteMessage(StrikethroughStyle);
						}
						if (strikethroughColor_ != null)
						{
							output.WriteRawTag(82);
							output.WriteMessage(StrikethroughColor);
						}
						if (StrokeWidth != 0.0)
						{
							output.WriteRawTag(89);
							output.WriteDouble(StrokeWidth);
						}
						if (strokeColor_ != null)
						{
							output.WriteRawTag(98);
							output.WriteMessage(StrokeColor);
						}
						customAttributes_.WriteTo(output, _repeated_customAttributes_codec);
						if (fillCase_ == FillOneofCase.TextGradientFill)
						{
							output.WriteRawTag(114);
							output.WriteMessage(TextGradientFill);
						}
						if (backgroundColor_ != null)
						{
							output.WriteRawTag(122);
							output.WriteMessage(BackgroundColor);
						}
						if (fillCase_ == FillOneofCase.CutOutFill)
						{
							output.WriteRawTag(130, 1);
							output.WriteMessage(CutOutFill);
						}
						if (fillCase_ == FillOneofCase.MediaFill)
						{
							output.WriteRawTag(138, 1);
							output.WriteMessage(MediaFill);
						}
						if (fillCase_ == FillOneofCase.BackgroundEffect)
						{
							output.WriteRawTag(146, 1);
							output.WriteMessage(BackgroundEffect);
						}
						if (LigatureStyle != 0)
						{
							output.WriteRawTag(152, 1);
							output.WriteEnum((int)LigatureStyle);
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
						if (Capitalization != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Capitalization);
						}
						if (fillCase_ == FillOneofCase.TextSolidFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(TextSolidFill);
						}
						if (fillCase_ == FillOneofCase.TextGradientFill)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(TextGradientFill);
						}
						if (fillCase_ == FillOneofCase.CutOutFill)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(CutOutFill);
						}
						if (fillCase_ == FillOneofCase.MediaFill)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(MediaFill);
						}
						if (fillCase_ == FillOneofCase.BackgroundEffect)
						{
							num += 2 + CodedOutputStream.ComputeMessageSize(BackgroundEffect);
						}
						if (underlineStyle_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(UnderlineStyle);
						}
						if (underlineColor_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(UnderlineColor);
						}
						if (paragraphStyle_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(ParagraphStyle);
						}
						if (Kerning != 0.0)
						{
							num += 9;
						}
						if (Superscript != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(Superscript);
						}
						if (strikethroughStyle_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(StrikethroughStyle);
						}
						if (strikethroughColor_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(StrikethroughColor);
						}
						if (StrokeWidth != 0.0)
						{
							num += 9;
						}
						if (strokeColor_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(StrokeColor);
						}
						num += customAttributes_.CalculateSize(_repeated_customAttributes_codec);
						if (backgroundColor_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(BackgroundColor);
						}
						if (LigatureStyle != 0)
						{
							num += 2 + CodedOutputStream.ComputeEnumSize((int)LigatureStyle);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Attributes other)
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
						if (other.Capitalization != 0)
						{
							Capitalization = other.Capitalization;
						}
						if (other.underlineStyle_ != null)
						{
							if (underlineStyle_ == null)
							{
								UnderlineStyle = new Types.Underline();
							}
							UnderlineStyle.MergeFrom(other.UnderlineStyle);
						}
						if (other.underlineColor_ != null)
						{
							if (underlineColor_ == null)
							{
								UnderlineColor = new Color();
							}
							UnderlineColor.MergeFrom(other.UnderlineColor);
						}
						if (other.paragraphStyle_ != null)
						{
							if (paragraphStyle_ == null)
							{
								ParagraphStyle = new Types.Paragraph();
							}
							ParagraphStyle.MergeFrom(other.ParagraphStyle);
						}
						if (other.Kerning != 0.0)
						{
							Kerning = other.Kerning;
						}
						if (other.Superscript != 0)
						{
							Superscript = other.Superscript;
						}
						if (other.strikethroughStyle_ != null)
						{
							if (strikethroughStyle_ == null)
							{
								StrikethroughStyle = new Types.Underline();
							}
							StrikethroughStyle.MergeFrom(other.StrikethroughStyle);
						}
						if (other.strikethroughColor_ != null)
						{
							if (strikethroughColor_ == null)
							{
								StrikethroughColor = new Color();
							}
							StrikethroughColor.MergeFrom(other.StrikethroughColor);
						}
						if (other.StrokeWidth != 0.0)
						{
							StrokeWidth = other.StrokeWidth;
						}
						if (other.strokeColor_ != null)
						{
							if (strokeColor_ == null)
							{
								StrokeColor = new Color();
							}
							StrokeColor.MergeFrom(other.StrokeColor);
						}
						customAttributes_.Add(other.customAttributes_);
						if (other.backgroundColor_ != null)
						{
							if (backgroundColor_ == null)
							{
								BackgroundColor = new Color();
							}
							BackgroundColor.MergeFrom(other.BackgroundColor);
						}
						if (other.LigatureStyle != 0)
						{
							LigatureStyle = other.LigatureStyle;
						}
						switch (other.FillCase)
						{
						case FillOneofCase.TextSolidFill:
							if (TextSolidFill == null)
							{
								TextSolidFill = new Color();
							}
							TextSolidFill.MergeFrom(other.TextSolidFill);
							break;
						case FillOneofCase.TextGradientFill:
							if (TextGradientFill == null)
							{
								TextGradientFill = new GradientFill();
							}
							TextGradientFill.MergeFrom(other.TextGradientFill);
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
						case FillOneofCase.BackgroundEffect:
							if (BackgroundEffect == null)
							{
								BackgroundEffect = new BackgroundEffect();
							}
							BackgroundEffect.MergeFrom(other.BackgroundEffect);
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
								if (font_ == null)
								{
									Font = new Font();
								}
								input.ReadMessage(Font);
								break;
							case 16u:
								Capitalization = (Types.Capitalization)input.ReadEnum();
								break;
							case 26u:
							{
								Color color = new Color();
								if (fillCase_ == FillOneofCase.TextSolidFill)
								{
									color.MergeFrom(TextSolidFill);
								}
								input.ReadMessage(color);
								TextSolidFill = color;
								break;
							}
							case 34u:
								if (underlineStyle_ == null)
								{
									UnderlineStyle = new Types.Underline();
								}
								input.ReadMessage(UnderlineStyle);
								break;
							case 42u:
								if (underlineColor_ == null)
								{
									UnderlineColor = new Color();
								}
								input.ReadMessage(UnderlineColor);
								break;
							case 50u:
								if (paragraphStyle_ == null)
								{
									ParagraphStyle = new Types.Paragraph();
								}
								input.ReadMessage(ParagraphStyle);
								break;
							case 57u:
								Kerning = input.ReadDouble();
								break;
							case 64u:
								Superscript = input.ReadInt32();
								break;
							case 74u:
								if (strikethroughStyle_ == null)
								{
									StrikethroughStyle = new Types.Underline();
								}
								input.ReadMessage(StrikethroughStyle);
								break;
							case 82u:
								if (strikethroughColor_ == null)
								{
									StrikethroughColor = new Color();
								}
								input.ReadMessage(StrikethroughColor);
								break;
							case 89u:
								StrokeWidth = input.ReadDouble();
								break;
							case 98u:
								if (strokeColor_ == null)
								{
									StrokeColor = new Color();
								}
								input.ReadMessage(StrokeColor);
								break;
							case 106u:
								customAttributes_.AddEntriesFrom(input, _repeated_customAttributes_codec);
								break;
							case 114u:
							{
								GradientFill gradientFill = new GradientFill();
								if (fillCase_ == FillOneofCase.TextGradientFill)
								{
									gradientFill.MergeFrom(TextGradientFill);
								}
								input.ReadMessage(gradientFill);
								TextGradientFill = gradientFill;
								break;
							}
							case 122u:
								if (backgroundColor_ == null)
								{
									BackgroundColor = new Color();
								}
								input.ReadMessage(BackgroundColor);
								break;
							case 130u:
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
							case 138u:
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
							case 146u:
							{
								BackgroundEffect backgroundEffect = new BackgroundEffect();
								if (fillCase_ == FillOneofCase.BackgroundEffect)
								{
									backgroundEffect.MergeFrom(BackgroundEffect);
								}
								input.ReadMessage(backgroundEffect);
								BackgroundEffect = backgroundEffect;
								break;
							}
							case 152u:
								LigatureStyle = (Types.LigatureStyle)input.ReadEnum();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class AlternateText : IMessage<AlternateText>, IMessage, IEquatable<AlternateText>, IDeepCloneable<AlternateText>
				{
					public enum ContentTypeOneofCase
					{
						None = 0,
						PlainText = 2
					}

					private static readonly MessageParser<AlternateText> _parser = new MessageParser<AlternateText>(() => new AlternateText());

					private UnknownFieldSet _unknownFields;

					public const int KeyFieldNumber = 1;

					private string key_ = "";

					public const int PlainTextFieldNumber = 2;

					private object contentType_;

					private ContentTypeOneofCase contentTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<AlternateText> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Text.Descriptor.NestedTypes[6];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string Key
					{
						get
						{
							return key_;
						}
						set
						{
							key_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string PlainText
					{
						get
						{
							if (!HasPlainText)
							{
								return "";
							}
							return (string)contentType_;
						}
						set
						{
							contentType_ = ProtoPreconditions.CheckNotNull(value, "value");
							contentTypeCase_ = ContentTypeOneofCase.PlainText;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool HasPlainText => contentTypeCase_ == ContentTypeOneofCase.PlainText;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ContentTypeOneofCase ContentTypeCase => contentTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AlternateText()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AlternateText(AlternateText other)
						: this()
					{
						key_ = other.key_;
						if (other.ContentTypeCase == ContentTypeOneofCase.PlainText)
						{
							PlainText = other.PlainText;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public AlternateText Clone()
					{
						return new AlternateText(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearPlainText()
					{
						if (HasPlainText)
						{
							ClearContentType();
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearContentType()
					{
						contentTypeCase_ = ContentTypeOneofCase.None;
						contentType_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as AlternateText);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(AlternateText other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Key != other.Key)
						{
							return false;
						}
						if (PlainText != other.PlainText)
						{
							return false;
						}
						if (ContentTypeCase != other.ContentTypeCase)
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
						if (Key.Length != 0)
						{
							num ^= Key.GetHashCode();
						}
						if (HasPlainText)
						{
							num ^= PlainText.GetHashCode();
						}
						num ^= (int)contentTypeCase_;
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
						if (Key.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(Key);
						}
						if (HasPlainText)
						{
							output.WriteRawTag(18);
							output.WriteString(PlainText);
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
						if (Key.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(Key);
						}
						if (HasPlainText)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(PlainText);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(AlternateText other)
					{
						if (other != null)
						{
							if (other.Key.Length != 0)
							{
								Key = other.Key;
							}
							if (other.ContentTypeCase == ContentTypeOneofCase.PlainText)
							{
								PlainText = other.PlainText;
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
								Key = input.ReadString();
								break;
							case 18u:
								PlainText = input.ReadString();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Text> _parser = new MessageParser<Text>(() => new Text());

			private UnknownFieldSet _unknownFields;

			public const int AttributesFieldNumber = 3;

			private Types.Attributes attributes_;

			public const int ShadowFieldNumber = 4;

			private Shadow shadow_;

			public const int RtfDataFieldNumber = 5;

			private ByteString rtfData_ = ByteString.Empty;

			public const int VerticalAlignmentFieldNumber = 6;

			private Types.VerticalAlignment verticalAlignment_;

			public const int ScaleBehaviorFieldNumber = 7;

			private Types.ScaleBehavior scaleBehavior_;

			public const int MarginsFieldNumber = 8;

			private EdgeInsets margins_;

			public const int IsSuperscriptStandardizedFieldNumber = 9;

			private bool isSuperscriptStandardized_;

			public const int TransformFieldNumber = 10;

			private Types.Transform transform_;

			public const int TransformDelimiterFieldNumber = 11;

			private string transformDelimiter_ = "";

			public const int ChordProFieldNumber = 12;

			private Types.ChordPro chordPro_;

			public const int AlternateTextsFieldNumber = 13;

			private static readonly FieldCodec<Types.AlternateText> _repeated_alternateTexts_codec = FieldCodec.ForMessage(106u, Types.AlternateText.Parser);

			private readonly RepeatedField<Types.AlternateText> alternateTexts_ = new RepeatedField<Types.AlternateText>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Text> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Attributes Attributes
			{
				get
				{
					return attributes_;
				}
				set
				{
					attributes_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Shadow Shadow
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
			public ByteString RtfData
			{
				get
				{
					return rtfData_;
				}
				set
				{
					rtfData_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.VerticalAlignment VerticalAlignment
			{
				get
				{
					return verticalAlignment_;
				}
				set
				{
					verticalAlignment_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ScaleBehavior ScaleBehavior
			{
				get
				{
					return scaleBehavior_;
				}
				set
				{
					scaleBehavior_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EdgeInsets Margins
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
			public bool IsSuperscriptStandardized
			{
				get
				{
					return isSuperscriptStandardized_;
				}
				set
				{
					isSuperscriptStandardized_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Transform Transform
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
			public string TransformDelimiter
			{
				get
				{
					return transformDelimiter_;
				}
				set
				{
					transformDelimiter_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ChordPro ChordPro
			{
				get
				{
					return chordPro_;
				}
				set
				{
					chordPro_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.AlternateText> AlternateTexts => alternateTexts_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Text()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Text(Text other)
				: this()
			{
				attributes_ = ((other.attributes_ != null) ? other.attributes_.Clone() : null);
				shadow_ = ((other.shadow_ != null) ? other.shadow_.Clone() : null);
				rtfData_ = other.rtfData_;
				verticalAlignment_ = other.verticalAlignment_;
				scaleBehavior_ = other.scaleBehavior_;
				margins_ = ((other.margins_ != null) ? other.margins_.Clone() : null);
				isSuperscriptStandardized_ = other.isSuperscriptStandardized_;
				transform_ = other.transform_;
				transformDelimiter_ = other.transformDelimiter_;
				chordPro_ = ((other.chordPro_ != null) ? other.chordPro_.Clone() : null);
				alternateTexts_ = other.alternateTexts_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Text Clone()
			{
				return new Text(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Text);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Text other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Attributes, other.Attributes))
				{
					return false;
				}
				if (!object.Equals(Shadow, other.Shadow))
				{
					return false;
				}
				if (RtfData != other.RtfData)
				{
					return false;
				}
				if (VerticalAlignment != other.VerticalAlignment)
				{
					return false;
				}
				if (ScaleBehavior != other.ScaleBehavior)
				{
					return false;
				}
				if (!object.Equals(Margins, other.Margins))
				{
					return false;
				}
				if (IsSuperscriptStandardized != other.IsSuperscriptStandardized)
				{
					return false;
				}
				if (Transform != other.Transform)
				{
					return false;
				}
				if (TransformDelimiter != other.TransformDelimiter)
				{
					return false;
				}
				if (!object.Equals(ChordPro, other.ChordPro))
				{
					return false;
				}
				if (!alternateTexts_.Equals(other.alternateTexts_))
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
				if (attributes_ != null)
				{
					num ^= Attributes.GetHashCode();
				}
				if (shadow_ != null)
				{
					num ^= Shadow.GetHashCode();
				}
				if (RtfData.Length != 0)
				{
					num ^= RtfData.GetHashCode();
				}
				if (VerticalAlignment != 0)
				{
					num ^= VerticalAlignment.GetHashCode();
				}
				if (ScaleBehavior != 0)
				{
					num ^= ScaleBehavior.GetHashCode();
				}
				if (margins_ != null)
				{
					num ^= Margins.GetHashCode();
				}
				if (IsSuperscriptStandardized)
				{
					num ^= IsSuperscriptStandardized.GetHashCode();
				}
				if (Transform != 0)
				{
					num ^= Transform.GetHashCode();
				}
				if (TransformDelimiter.Length != 0)
				{
					num ^= TransformDelimiter.GetHashCode();
				}
				if (chordPro_ != null)
				{
					num ^= ChordPro.GetHashCode();
				}
				num ^= alternateTexts_.GetHashCode();
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
				if (attributes_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Attributes);
				}
				if (shadow_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Shadow);
				}
				if (RtfData.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteBytes(RtfData);
				}
				if (VerticalAlignment != 0)
				{
					output.WriteRawTag(48);
					output.WriteEnum((int)VerticalAlignment);
				}
				if (ScaleBehavior != 0)
				{
					output.WriteRawTag(56);
					output.WriteEnum((int)ScaleBehavior);
				}
				if (margins_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Margins);
				}
				if (IsSuperscriptStandardized)
				{
					output.WriteRawTag(72);
					output.WriteBool(IsSuperscriptStandardized);
				}
				if (Transform != 0)
				{
					output.WriteRawTag(80);
					output.WriteEnum((int)Transform);
				}
				if (TransformDelimiter.Length != 0)
				{
					output.WriteRawTag(90);
					output.WriteString(TransformDelimiter);
				}
				if (chordPro_ != null)
				{
					output.WriteRawTag(98);
					output.WriteMessage(ChordPro);
				}
				alternateTexts_.WriteTo(output, _repeated_alternateTexts_codec);
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
				if (attributes_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Attributes);
				}
				if (shadow_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Shadow);
				}
				if (RtfData.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(RtfData);
				}
				if (VerticalAlignment != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)VerticalAlignment);
				}
				if (ScaleBehavior != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ScaleBehavior);
				}
				if (margins_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Margins);
				}
				if (IsSuperscriptStandardized)
				{
					num += 2;
				}
				if (Transform != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Transform);
				}
				if (TransformDelimiter.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(TransformDelimiter);
				}
				if (chordPro_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ChordPro);
				}
				num += alternateTexts_.CalculateSize(_repeated_alternateTexts_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Text other)
			{
				if (other == null)
				{
					return;
				}
				if (other.attributes_ != null)
				{
					if (attributes_ == null)
					{
						Attributes = new Types.Attributes();
					}
					Attributes.MergeFrom(other.Attributes);
				}
				if (other.shadow_ != null)
				{
					if (shadow_ == null)
					{
						Shadow = new Shadow();
					}
					Shadow.MergeFrom(other.Shadow);
				}
				if (other.RtfData.Length != 0)
				{
					RtfData = other.RtfData;
				}
				if (other.VerticalAlignment != 0)
				{
					VerticalAlignment = other.VerticalAlignment;
				}
				if (other.ScaleBehavior != 0)
				{
					ScaleBehavior = other.ScaleBehavior;
				}
				if (other.margins_ != null)
				{
					if (margins_ == null)
					{
						Margins = new EdgeInsets();
					}
					Margins.MergeFrom(other.Margins);
				}
				if (other.IsSuperscriptStandardized)
				{
					IsSuperscriptStandardized = other.IsSuperscriptStandardized;
				}
				if (other.Transform != 0)
				{
					Transform = other.Transform;
				}
				if (other.TransformDelimiter.Length != 0)
				{
					TransformDelimiter = other.TransformDelimiter;
				}
				if (other.chordPro_ != null)
				{
					if (chordPro_ == null)
					{
						ChordPro = new Types.ChordPro();
					}
					ChordPro.MergeFrom(other.ChordPro);
				}
				alternateTexts_.Add(other.alternateTexts_);
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
					case 26u:
						if (attributes_ == null)
						{
							Attributes = new Types.Attributes();
						}
						input.ReadMessage(Attributes);
						break;
					case 34u:
						if (shadow_ == null)
						{
							Shadow = new Shadow();
						}
						input.ReadMessage(Shadow);
						break;
					case 42u:
						RtfData = input.ReadBytes();
						break;
					case 48u:
						VerticalAlignment = (Types.VerticalAlignment)input.ReadEnum();
						break;
					case 56u:
						ScaleBehavior = (Types.ScaleBehavior)input.ReadEnum();
						break;
					case 66u:
						if (margins_ == null)
						{
							Margins = new EdgeInsets();
						}
						input.ReadMessage(Margins);
						break;
					case 72u:
						IsSuperscriptStandardized = input.ReadBool();
						break;
					case 80u:
						Transform = (Types.Transform)input.ReadEnum();
						break;
					case 90u:
						TransformDelimiter = input.ReadString();
						break;
					case 98u:
						if (chordPro_ == null)
						{
							ChordPro = new Types.ChordPro();
						}
						input.ReadMessage(ChordPro);
						break;
					case 106u:
						alternateTexts_.AddEntriesFrom(input, _repeated_alternateTexts_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PowerPointImport : IMessage<PowerPointImport>, IMessage, IEquatable<PowerPointImport>, IDeepCloneable<PowerPointImport>
		{
			private static readonly MessageParser<PowerPointImport> _parser = new MessageParser<PowerPointImport>(() => new PowerPointImport());

			private UnknownFieldSet _unknownFields;

			public const int TextFieldNumber = 1;

			private Text text_;

			public const int WidthFieldNumber = 2;

			private double width_;

			public const int HeightFieldNumber = 3;

			private double height_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PowerPointImport> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Graphics.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Text Text
			{
				get
				{
					return text_;
				}
				set
				{
					text_ = value;
				}
			}

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
			public PowerPointImport()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PowerPointImport(PowerPointImport other)
				: this()
			{
				text_ = ((other.text_ != null) ? other.text_.Clone() : null);
				width_ = other.width_;
				height_ = other.height_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PowerPointImport Clone()
			{
				return new PowerPointImport(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PowerPointImport);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PowerPointImport other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Text, other.Text))
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
				if (text_ != null)
				{
					num ^= Text.GetHashCode();
				}
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
				if (text_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Text);
				}
				if (Width != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Width);
				}
				if (Height != 0.0)
				{
					output.WriteRawTag(25);
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
				if (text_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Text);
				}
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
			public void MergeFrom(PowerPointImport other)
			{
				if (other == null)
				{
					return;
				}
				if (other.text_ != null)
				{
					if (text_ == null)
					{
						Text = new Text();
					}
					Text.MergeFrom(other.Text);
				}
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
						if (text_ == null)
						{
							Text = new Text();
						}
						input.ReadMessage(Text);
						break;
					case 17u:
						Width = input.ReadDouble();
						break;
					case 25u:
						Height = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Graphics> _parser = new MessageParser<Graphics>(() => new Graphics());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Graphics> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => GraphicsDataReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics(Graphics other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics Clone()
	{
		return new Graphics(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Graphics);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Graphics other)
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
	public void MergeFrom(Graphics other)
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
