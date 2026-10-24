using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPattern : IMessage<TestPattern>, IMessage, IEquatable<TestPattern>, IDeepCloneable<TestPattern>
{
	public enum PatternPropertiesOneofCase
	{
		None = 0,
		BlendGrid = 2,
		CustomColor = 3,
		Intensity = 4
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("TYPE_BLEND_GRID")]
			BlendGrid,
			[OriginalName("TYPE_COLOR_BARS")]
			ColorBars,
			[OriginalName("TYPE_FOCUS")]
			Focus,
			[OriginalName("TYPE_GRAY_SCALE")]
			GrayScale,
			[OriginalName("TYPE_BLACK_COLOR")]
			BlackColor,
			[OriginalName("TYPE_WHITE_COLOR")]
			WhiteColor,
			[OriginalName("TYPE_CUSTOM_COLOR")]
			CustomColor,
			[OriginalName("TYPE_TEXT")]
			Text,
			[OriginalName("TYPE_VIDEO_SYNC")]
			VideoSync
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BlendGrid : IMessage<BlendGrid>, IMessage, IEquatable<BlendGrid>, IDeepCloneable<BlendGrid>
		{
			private static readonly MessageParser<BlendGrid> _parser = new MessageParser<BlendGrid>(() => new BlendGrid());

			private UnknownFieldSet _unknownFields;

			public const int DrawGridFieldNumber = 1;

			private bool drawGrid_;

			public const int DrawCirclesFieldNumber = 2;

			private bool drawCircles_;

			public const int DrawLinesFieldNumber = 3;

			private bool drawLines_;

			public const int InvertColorsFieldNumber = 4;

			private bool invertColors_;

			public const int GridSpacingFieldNumber = 5;

			private double gridSpacing_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BlendGrid> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPattern.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool DrawGrid
			{
				get
				{
					return drawGrid_;
				}
				set
				{
					drawGrid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool DrawCircles
			{
				get
				{
					return drawCircles_;
				}
				set
				{
					drawCircles_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool DrawLines
			{
				get
				{
					return drawLines_;
				}
				set
				{
					drawLines_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool InvertColors
			{
				get
				{
					return invertColors_;
				}
				set
				{
					invertColors_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double GridSpacing
			{
				get
				{
					return gridSpacing_;
				}
				set
				{
					gridSpacing_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendGrid()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendGrid(BlendGrid other)
				: this()
			{
				drawGrid_ = other.drawGrid_;
				drawCircles_ = other.drawCircles_;
				drawLines_ = other.drawLines_;
				invertColors_ = other.invertColors_;
				gridSpacing_ = other.gridSpacing_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BlendGrid Clone()
			{
				return new BlendGrid(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BlendGrid);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BlendGrid other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (DrawGrid != other.DrawGrid)
				{
					return false;
				}
				if (DrawCircles != other.DrawCircles)
				{
					return false;
				}
				if (DrawLines != other.DrawLines)
				{
					return false;
				}
				if (InvertColors != other.InvertColors)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(GridSpacing, other.GridSpacing))
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
				if (DrawGrid)
				{
					num ^= DrawGrid.GetHashCode();
				}
				if (DrawCircles)
				{
					num ^= DrawCircles.GetHashCode();
				}
				if (DrawLines)
				{
					num ^= DrawLines.GetHashCode();
				}
				if (InvertColors)
				{
					num ^= InvertColors.GetHashCode();
				}
				if (GridSpacing != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(GridSpacing);
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
				if (DrawGrid)
				{
					output.WriteRawTag(8);
					output.WriteBool(DrawGrid);
				}
				if (DrawCircles)
				{
					output.WriteRawTag(16);
					output.WriteBool(DrawCircles);
				}
				if (DrawLines)
				{
					output.WriteRawTag(24);
					output.WriteBool(DrawLines);
				}
				if (InvertColors)
				{
					output.WriteRawTag(32);
					output.WriteBool(InvertColors);
				}
				if (GridSpacing != 0.0)
				{
					output.WriteRawTag(41);
					output.WriteDouble(GridSpacing);
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
				if (DrawGrid)
				{
					num += 2;
				}
				if (DrawCircles)
				{
					num += 2;
				}
				if (DrawLines)
				{
					num += 2;
				}
				if (InvertColors)
				{
					num += 2;
				}
				if (GridSpacing != 0.0)
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
			public void MergeFrom(BlendGrid other)
			{
				if (other != null)
				{
					if (other.DrawGrid)
					{
						DrawGrid = other.DrawGrid;
					}
					if (other.DrawCircles)
					{
						DrawCircles = other.DrawCircles;
					}
					if (other.DrawLines)
					{
						DrawLines = other.DrawLines;
					}
					if (other.InvertColors)
					{
						InvertColors = other.InvertColors;
					}
					if (other.GridSpacing != 0.0)
					{
						GridSpacing = other.GridSpacing;
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
						DrawGrid = input.ReadBool();
						break;
					case 16u:
						DrawCircles = input.ReadBool();
						break;
					case 24u:
						DrawLines = input.ReadBool();
						break;
					case 32u:
						InvertColors = input.ReadBool();
						break;
					case 41u:
						GridSpacing = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CustomColor : IMessage<CustomColor>, IMessage, IEquatable<CustomColor>, IDeepCloneable<CustomColor>
		{
			private static readonly MessageParser<CustomColor> _parser = new MessageParser<CustomColor>(() => new CustomColor());

			private UnknownFieldSet _unknownFields;

			public const int ColorFieldNumber = 1;

			private Color color_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CustomColor> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPattern.Descriptor.NestedTypes[1];

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
			public CustomColor()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CustomColor(CustomColor other)
				: this()
			{
				color_ = ((other.color_ != null) ? other.color_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CustomColor Clone()
			{
				return new CustomColor(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CustomColor);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CustomColor other)
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
			public void MergeFrom(CustomColor other)
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
		public sealed class IntensityColor : IMessage<IntensityColor>, IMessage, IEquatable<IntensityColor>, IDeepCloneable<IntensityColor>
		{
			private static readonly MessageParser<IntensityColor> _parser = new MessageParser<IntensityColor>(() => new IntensityColor());

			private UnknownFieldSet _unknownFields;

			public const int IntensityFieldNumber = 1;

			private double intensity_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<IntensityColor> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPattern.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Intensity
			{
				get
				{
					return intensity_;
				}
				set
				{
					intensity_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IntensityColor()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IntensityColor(IntensityColor other)
				: this()
			{
				intensity_ = other.intensity_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public IntensityColor Clone()
			{
				return new IntensityColor(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as IntensityColor);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(IntensityColor other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Intensity, other.Intensity))
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
				if (Intensity != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Intensity);
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
				if (Intensity != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Intensity);
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
				if (Intensity != 0.0)
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
			public void MergeFrom(IntensityColor other)
			{
				if (other != null)
				{
					if (other.Intensity != 0.0)
					{
						Intensity = other.Intensity;
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
						Intensity = input.ReadDouble();
					}
				}
			}
		}
	}

	private static readonly MessageParser<TestPattern> _parser = new MessageParser<TestPattern>(() => new TestPattern());

	private UnknownFieldSet _unknownFields;

	public const int TypeFieldNumber = 1;

	private Types.Type type_;

	public const int BlendGridFieldNumber = 2;

	public const int CustomColorFieldNumber = 3;

	public const int IntensityFieldNumber = 4;

	private object patternProperties_;

	private PatternPropertiesOneofCase patternPropertiesCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPattern> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TestPatternReflection.Descriptor.MessageTypes[0];

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
	public Types.BlendGrid BlendGrid
	{
		get
		{
			if (patternPropertiesCase_ != PatternPropertiesOneofCase.BlendGrid)
			{
				return null;
			}
			return (Types.BlendGrid)patternProperties_;
		}
		set
		{
			patternProperties_ = value;
			patternPropertiesCase_ = ((value != null) ? PatternPropertiesOneofCase.BlendGrid : PatternPropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CustomColor CustomColor
	{
		get
		{
			if (patternPropertiesCase_ != PatternPropertiesOneofCase.CustomColor)
			{
				return null;
			}
			return (Types.CustomColor)patternProperties_;
		}
		set
		{
			patternProperties_ = value;
			patternPropertiesCase_ = ((value != null) ? PatternPropertiesOneofCase.CustomColor : PatternPropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.IntensityColor Intensity
	{
		get
		{
			if (patternPropertiesCase_ != PatternPropertiesOneofCase.Intensity)
			{
				return null;
			}
			return (Types.IntensityColor)patternProperties_;
		}
		set
		{
			patternProperties_ = value;
			patternPropertiesCase_ = ((value != null) ? PatternPropertiesOneofCase.Intensity : PatternPropertiesOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PatternPropertiesOneofCase PatternPropertiesCase => patternPropertiesCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPattern()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPattern(TestPattern other)
		: this()
	{
		type_ = other.type_;
		switch (other.PatternPropertiesCase)
		{
		case PatternPropertiesOneofCase.BlendGrid:
			BlendGrid = other.BlendGrid.Clone();
			break;
		case PatternPropertiesOneofCase.CustomColor:
			CustomColor = other.CustomColor.Clone();
			break;
		case PatternPropertiesOneofCase.Intensity:
			Intensity = other.Intensity.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPattern Clone()
	{
		return new TestPattern(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearPatternProperties()
	{
		patternPropertiesCase_ = PatternPropertiesOneofCase.None;
		patternProperties_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TestPattern);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPattern other)
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
		if (!object.Equals(BlendGrid, other.BlendGrid))
		{
			return false;
		}
		if (!object.Equals(CustomColor, other.CustomColor))
		{
			return false;
		}
		if (!object.Equals(Intensity, other.Intensity))
		{
			return false;
		}
		if (PatternPropertiesCase != other.PatternPropertiesCase)
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
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.BlendGrid)
		{
			num ^= BlendGrid.GetHashCode();
		}
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.CustomColor)
		{
			num ^= CustomColor.GetHashCode();
		}
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.Intensity)
		{
			num ^= Intensity.GetHashCode();
		}
		num ^= (int)patternPropertiesCase_;
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
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.BlendGrid)
		{
			output.WriteRawTag(18);
			output.WriteMessage(BlendGrid);
		}
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.CustomColor)
		{
			output.WriteRawTag(26);
			output.WriteMessage(CustomColor);
		}
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.Intensity)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Intensity);
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
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.BlendGrid)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BlendGrid);
		}
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.CustomColor)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CustomColor);
		}
		if (patternPropertiesCase_ == PatternPropertiesOneofCase.Intensity)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Intensity);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TestPattern other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Type != 0)
		{
			Type = other.Type;
		}
		switch (other.PatternPropertiesCase)
		{
		case PatternPropertiesOneofCase.BlendGrid:
			if (BlendGrid == null)
			{
				BlendGrid = new Types.BlendGrid();
			}
			BlendGrid.MergeFrom(other.BlendGrid);
			break;
		case PatternPropertiesOneofCase.CustomColor:
			if (CustomColor == null)
			{
				CustomColor = new Types.CustomColor();
			}
			CustomColor.MergeFrom(other.CustomColor);
			break;
		case PatternPropertiesOneofCase.Intensity:
			if (Intensity == null)
			{
				Intensity = new Types.IntensityColor();
			}
			Intensity.MergeFrom(other.Intensity);
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
				Types.BlendGrid blendGrid = new Types.BlendGrid();
				if (patternPropertiesCase_ == PatternPropertiesOneofCase.BlendGrid)
				{
					blendGrid.MergeFrom(BlendGrid);
				}
				input.ReadMessage(blendGrid);
				BlendGrid = blendGrid;
				break;
			}
			case 26u:
			{
				Types.CustomColor customColor = new Types.CustomColor();
				if (patternPropertiesCase_ == PatternPropertiesOneofCase.CustomColor)
				{
					customColor.MergeFrom(CustomColor);
				}
				input.ReadMessage(customColor);
				CustomColor = customColor;
				break;
			}
			case 34u:
			{
				Types.IntensityColor intensityColor = new Types.IntensityColor();
				if (patternPropertiesCase_ == PatternPropertiesOneofCase.Intensity)
				{
					intensityColor.MergeFrom(Intensity);
				}
				input.ReadMessage(intensityColor);
				Intensity = intensityColor;
				break;
			}
			}
		}
	}
}
