using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class EdgeBlend : IMessage<EdgeBlend>, IMessage, IEquatable<EdgeBlend>, IDeepCloneable<EdgeBlend>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Mode
		{
			[OriginalName("MODE_LINEAR")]
			Linear,
			[OriginalName("MODE_CUBIC")]
			Cubic,
			[OriginalName("MODE_QUADRATIC")]
			Quadratic
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Screen : IMessage<Screen>, IMessage, IEquatable<Screen>, IDeepCloneable<Screen>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Edge
				{
					[OriginalName("EDGE_UNKNOWN")]
					Unknown,
					[OriginalName("EDGE_LEFT")]
					Left,
					[OriginalName("EDGE_RIGHT")]
					Right,
					[OriginalName("EDGE_TOP")]
					Top,
					[OriginalName("EDGE_BOTTOM")]
					Bottom
				}
			}

			private static readonly MessageParser<Screen> _parser = new MessageParser<Screen>(() => new Screen());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int EdgeFieldNumber = 2;

			private Types.Edge edge_;

			public const int GammaFieldNumber = 3;

			private double gamma_;

			public const int BlackLevelFieldNumber = 4;

			private double blackLevel_;

			public const int ModeFieldNumber = 5;

			private Mode mode_;

			public const int RadiusFieldNumber = 6;

			private double radius_;

			public const int IntensityFieldNumber = 7;

			private double intensity_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Screen> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => EdgeBlend.Descriptor.NestedTypes[0];

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

			[Obsolete]
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Edge Edge
			{
				get
				{
					return edge_;
				}
				set
				{
					edge_ = value;
				}
			}

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
			public Mode Mode
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
			public Screen()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Screen(Screen other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				edge_ = other.edge_;
				gamma_ = other.gamma_;
				blackLevel_ = other.blackLevel_;
				mode_ = other.mode_;
				radius_ = other.radius_;
				intensity_ = other.intensity_;
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
				if (Edge != other.Edge)
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
				if (Mode != other.Mode)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Radius, other.Radius))
				{
					return false;
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (Edge != 0)
				{
					num ^= Edge.GetHashCode();
				}
				if (Gamma != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Gamma);
				}
				if (BlackLevel != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlackLevel);
				}
				if (Mode != 0)
				{
					num ^= Mode.GetHashCode();
				}
				if (Radius != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Radius);
				}
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (Edge != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Edge);
				}
				if (Gamma != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(Gamma);
				}
				if (BlackLevel != 0.0)
				{
					output.WriteRawTag(33);
					output.WriteDouble(BlackLevel);
				}
				if (Mode != 0)
				{
					output.WriteRawTag(40);
					output.WriteEnum((int)Mode);
				}
				if (Radius != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(Radius);
				}
				if (Intensity != 0.0)
				{
					output.WriteRawTag(57);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (Edge != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Edge);
				}
				if (Gamma != 0.0)
				{
					num += 9;
				}
				if (BlackLevel != 0.0)
				{
					num += 9;
				}
				if (Mode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
				}
				if (Radius != 0.0)
				{
					num += 9;
				}
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
				if (other.Edge != 0)
				{
					Edge = other.Edge;
				}
				if (other.Gamma != 0.0)
				{
					Gamma = other.Gamma;
				}
				if (other.BlackLevel != 0.0)
				{
					BlackLevel = other.BlackLevel;
				}
				if (other.Mode != 0)
				{
					Mode = other.Mode;
				}
				if (other.Radius != 0.0)
				{
					Radius = other.Radius;
				}
				if (other.Intensity != 0.0)
				{
					Intensity = other.Intensity;
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
					case 16u:
						Edge = (Types.Edge)input.ReadEnum();
						break;
					case 25u:
						Gamma = input.ReadDouble();
						break;
					case 33u:
						BlackLevel = input.ReadDouble();
						break;
					case 40u:
						Mode = (Mode)input.ReadEnum();
						break;
					case 49u:
						Radius = input.ReadDouble();
						break;
					case 57u:
						Intensity = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<EdgeBlend> _parser = new MessageParser<EdgeBlend>(() => new EdgeBlend());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int RadiusFieldNumber = 2;

	private double radius_;

	public const int IntensityFieldNumber = 3;

	private double intensity_;

	public const int ModeFieldNumber = 4;

	private Types.Mode mode_;

	public const int FirstScreenFieldNumber = 5;

	private Types.Screen firstScreen_;

	public const int SecondScreenFieldNumber = 6;

	private Types.Screen secondScreen_;

	public const int LeftScreenFieldNumber = 7;

	private Types.Screen leftScreen_;

	public const int RightScreenFieldNumber = 8;

	private Types.Screen rightScreen_;

	public const int TopScreenFieldNumber = 9;

	private Types.Screen topScreen_;

	public const int BottomScreenFieldNumber = 10;

	private Types.Screen bottomScreen_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<EdgeBlend> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ScreensReflection.Descriptor.MessageTypes[4];

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

	[Obsolete]
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

	[Obsolete]
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

	[Obsolete]
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

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Screen FirstScreen
	{
		get
		{
			return firstScreen_;
		}
		set
		{
			firstScreen_ = value;
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Screen SecondScreen
	{
		get
		{
			return secondScreen_;
		}
		set
		{
			secondScreen_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Screen LeftScreen
	{
		get
		{
			return leftScreen_;
		}
		set
		{
			leftScreen_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Screen RightScreen
	{
		get
		{
			return rightScreen_;
		}
		set
		{
			rightScreen_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Screen TopScreen
	{
		get
		{
			return topScreen_;
		}
		set
		{
			topScreen_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Screen BottomScreen
	{
		get
		{
			return bottomScreen_;
		}
		set
		{
			bottomScreen_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EdgeBlend()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EdgeBlend(EdgeBlend other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		radius_ = other.radius_;
		intensity_ = other.intensity_;
		mode_ = other.mode_;
		firstScreen_ = ((other.firstScreen_ != null) ? other.firstScreen_.Clone() : null);
		secondScreen_ = ((other.secondScreen_ != null) ? other.secondScreen_.Clone() : null);
		leftScreen_ = ((other.leftScreen_ != null) ? other.leftScreen_.Clone() : null);
		rightScreen_ = ((other.rightScreen_ != null) ? other.rightScreen_.Clone() : null);
		topScreen_ = ((other.topScreen_ != null) ? other.topScreen_.Clone() : null);
		bottomScreen_ = ((other.bottomScreen_ != null) ? other.bottomScreen_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EdgeBlend Clone()
	{
		return new EdgeBlend(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as EdgeBlend);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(EdgeBlend other)
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
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Radius, other.Radius))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Intensity, other.Intensity))
		{
			return false;
		}
		if (Mode != other.Mode)
		{
			return false;
		}
		if (!object.Equals(FirstScreen, other.FirstScreen))
		{
			return false;
		}
		if (!object.Equals(SecondScreen, other.SecondScreen))
		{
			return false;
		}
		if (!object.Equals(LeftScreen, other.LeftScreen))
		{
			return false;
		}
		if (!object.Equals(RightScreen, other.RightScreen))
		{
			return false;
		}
		if (!object.Equals(TopScreen, other.TopScreen))
		{
			return false;
		}
		if (!object.Equals(BottomScreen, other.BottomScreen))
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
		if (Radius != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Radius);
		}
		if (Intensity != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Intensity);
		}
		if (Mode != 0)
		{
			num ^= Mode.GetHashCode();
		}
		if (firstScreen_ != null)
		{
			num ^= FirstScreen.GetHashCode();
		}
		if (secondScreen_ != null)
		{
			num ^= SecondScreen.GetHashCode();
		}
		if (leftScreen_ != null)
		{
			num ^= LeftScreen.GetHashCode();
		}
		if (rightScreen_ != null)
		{
			num ^= RightScreen.GetHashCode();
		}
		if (topScreen_ != null)
		{
			num ^= TopScreen.GetHashCode();
		}
		if (bottomScreen_ != null)
		{
			num ^= BottomScreen.GetHashCode();
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
		if (Radius != 0.0)
		{
			output.WriteRawTag(17);
			output.WriteDouble(Radius);
		}
		if (Intensity != 0.0)
		{
			output.WriteRawTag(25);
			output.WriteDouble(Intensity);
		}
		if (Mode != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Mode);
		}
		if (firstScreen_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(FirstScreen);
		}
		if (secondScreen_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(SecondScreen);
		}
		if (leftScreen_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(LeftScreen);
		}
		if (rightScreen_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(RightScreen);
		}
		if (topScreen_ != null)
		{
			output.WriteRawTag(74);
			output.WriteMessage(TopScreen);
		}
		if (bottomScreen_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(BottomScreen);
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
		if (Radius != 0.0)
		{
			num += 9;
		}
		if (Intensity != 0.0)
		{
			num += 9;
		}
		if (Mode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
		}
		if (firstScreen_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FirstScreen);
		}
		if (secondScreen_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SecondScreen);
		}
		if (leftScreen_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LeftScreen);
		}
		if (rightScreen_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RightScreen);
		}
		if (topScreen_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TopScreen);
		}
		if (bottomScreen_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BottomScreen);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(EdgeBlend other)
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
		if (other.Radius != 0.0)
		{
			Radius = other.Radius;
		}
		if (other.Intensity != 0.0)
		{
			Intensity = other.Intensity;
		}
		if (other.Mode != 0)
		{
			Mode = other.Mode;
		}
		if (other.firstScreen_ != null)
		{
			if (firstScreen_ == null)
			{
				FirstScreen = new Types.Screen();
			}
			FirstScreen.MergeFrom(other.FirstScreen);
		}
		if (other.secondScreen_ != null)
		{
			if (secondScreen_ == null)
			{
				SecondScreen = new Types.Screen();
			}
			SecondScreen.MergeFrom(other.SecondScreen);
		}
		if (other.leftScreen_ != null)
		{
			if (leftScreen_ == null)
			{
				LeftScreen = new Types.Screen();
			}
			LeftScreen.MergeFrom(other.LeftScreen);
		}
		if (other.rightScreen_ != null)
		{
			if (rightScreen_ == null)
			{
				RightScreen = new Types.Screen();
			}
			RightScreen.MergeFrom(other.RightScreen);
		}
		if (other.topScreen_ != null)
		{
			if (topScreen_ == null)
			{
				TopScreen = new Types.Screen();
			}
			TopScreen.MergeFrom(other.TopScreen);
		}
		if (other.bottomScreen_ != null)
		{
			if (bottomScreen_ == null)
			{
				BottomScreen = new Types.Screen();
			}
			BottomScreen.MergeFrom(other.BottomScreen);
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
			case 17u:
				Radius = input.ReadDouble();
				break;
			case 25u:
				Intensity = input.ReadDouble();
				break;
			case 32u:
				Mode = (Types.Mode)input.ReadEnum();
				break;
			case 42u:
				if (firstScreen_ == null)
				{
					FirstScreen = new Types.Screen();
				}
				input.ReadMessage(FirstScreen);
				break;
			case 50u:
				if (secondScreen_ == null)
				{
					SecondScreen = new Types.Screen();
				}
				input.ReadMessage(SecondScreen);
				break;
			case 58u:
				if (leftScreen_ == null)
				{
					LeftScreen = new Types.Screen();
				}
				input.ReadMessage(LeftScreen);
				break;
			case 66u:
				if (rightScreen_ == null)
				{
					RightScreen = new Types.Screen();
				}
				input.ReadMessage(RightScreen);
				break;
			case 74u:
				if (topScreen_ == null)
				{
					TopScreen = new Types.Screen();
				}
				input.ReadMessage(TopScreen);
				break;
			case 82u:
				if (bottomScreen_ == null)
				{
					BottomScreen = new Types.Screen();
				}
				input.ReadMessage(BottomScreen);
				break;
			}
		}
	}
}
