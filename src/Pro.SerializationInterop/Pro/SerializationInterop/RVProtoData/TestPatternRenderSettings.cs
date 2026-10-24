using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TestPatternRenderSettings : IMessage<TestPatternRenderSettings>, IMessage, IEquatable<TestPatternRenderSettings>, IDeepCloneable<TestPatternRenderSettings>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Output : IMessage<Output>, IMessage, IEquatable<Output>, IDeepCloneable<Output>
		{
			private static readonly MessageParser<Output> _parser = new MessageParser<Output>(() => new Output());

			private UnknownFieldSet _unknownFields;

			public const int XFieldNumber = 1;

			private int x_;

			public const int YFieldNumber = 2;

			private int y_;

			public const int WidthFieldNumber = 3;

			private int width_;

			public const int HeightFieldNumber = 4;

			private int height_;

			public const int NameFieldNumber = 5;

			private string name_ = "";

			public const int FrameRateFieldNumber = 6;

			private double frameRate_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Output> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TestPatternRenderSettings.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int X
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
			public int Y
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
			public int Width
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
			public int Height
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
			public double FrameRate
			{
				get
				{
					return frameRate_;
				}
				set
				{
					frameRate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Output()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Output(Output other)
				: this()
			{
				x_ = other.x_;
				y_ = other.y_;
				width_ = other.width_;
				height_ = other.height_;
				name_ = other.name_;
				frameRate_ = other.frameRate_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Output Clone()
			{
				return new Output(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Output);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Output other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (X != other.X)
				{
					return false;
				}
				if (Y != other.Y)
				{
					return false;
				}
				if (Width != other.Width)
				{
					return false;
				}
				if (Height != other.Height)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FrameRate, other.FrameRate))
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
				if (X != 0)
				{
					num ^= X.GetHashCode();
				}
				if (Y != 0)
				{
					num ^= Y.GetHashCode();
				}
				if (Width != 0)
				{
					num ^= Width.GetHashCode();
				}
				if (Height != 0)
				{
					num ^= Height.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (FrameRate != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FrameRate);
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
				if (X != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(X);
				}
				if (Y != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Y);
				}
				if (Width != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(Width);
				}
				if (Height != 0)
				{
					output.WriteRawTag(32);
					output.WriteInt32(Height);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(42);
					output.WriteString(Name);
				}
				if (FrameRate != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(FrameRate);
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
				if (X != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(X);
				}
				if (Y != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Y);
				}
				if (Width != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Width);
				}
				if (Height != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Height);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (FrameRate != 0.0)
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
			public void MergeFrom(Output other)
			{
				if (other != null)
				{
					if (other.X != 0)
					{
						X = other.X;
					}
					if (other.Y != 0)
					{
						Y = other.Y;
					}
					if (other.Width != 0)
					{
						Width = other.Width;
					}
					if (other.Height != 0)
					{
						Height = other.Height;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.FrameRate != 0.0)
					{
						FrameRate = other.FrameRate;
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
						X = input.ReadInt32();
						break;
					case 16u:
						Y = input.ReadInt32();
						break;
					case 24u:
						Width = input.ReadInt32();
						break;
					case 32u:
						Height = input.ReadInt32();
						break;
					case 42u:
						Name = input.ReadString();
						break;
					case 49u:
						FrameRate = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TestPatternRenderSettings> _parser = new MessageParser<TestPatternRenderSettings>(() => new TestPatternRenderSettings());

	private UnknownFieldSet _unknownFields;

	public const int PatternFieldNumber = 1;

	private TestPatternDefinition pattern_;

	public const int ScreenNameFieldNumber = 3;

	private string screenName_ = "";

	public const int OutputsFieldNumber = 4;

	private static readonly FieldCodec<Types.Output> _repeated_outputs_codec = FieldCodec.ForMessage(34u, Types.Output.Parser);

	private readonly RepeatedField<Types.Output> outputs_ = new RepeatedField<Types.Output>();

	public const int LogoTypeFieldNumber = 5;

	private LogoType logoType_;

	public const int LogoFileFieldNumber = 6;

	private string logoFile_ = "";

	public const int RenderWidthFieldNumber = 7;

	private int renderWidth_;

	public const int RenderHeightFieldNumber = 8;

	private int renderHeight_;

	public const int EnableAudioFieldNumber = 9;

	private bool enableAudio_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TestPatternRenderSettings> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TestPatternReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternDefinition Pattern
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
	public string ScreenName
	{
		get
		{
			return screenName_;
		}
		set
		{
			screenName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Output> Outputs => outputs_;

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
	public string LogoFile
	{
		get
		{
			return logoFile_;
		}
		set
		{
			logoFile_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int RenderWidth
	{
		get
		{
			return renderWidth_;
		}
		set
		{
			renderWidth_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int RenderHeight
	{
		get
		{
			return renderHeight_;
		}
		set
		{
			renderHeight_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool EnableAudio
	{
		get
		{
			return enableAudio_;
		}
		set
		{
			enableAudio_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternRenderSettings()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternRenderSettings(TestPatternRenderSettings other)
		: this()
	{
		pattern_ = ((other.pattern_ != null) ? other.pattern_.Clone() : null);
		screenName_ = other.screenName_;
		outputs_ = other.outputs_.Clone();
		logoType_ = other.logoType_;
		logoFile_ = other.logoFile_;
		renderWidth_ = other.renderWidth_;
		renderHeight_ = other.renderHeight_;
		enableAudio_ = other.enableAudio_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternRenderSettings Clone()
	{
		return new TestPatternRenderSettings(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TestPatternRenderSettings);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TestPatternRenderSettings other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Pattern, other.Pattern))
		{
			return false;
		}
		if (ScreenName != other.ScreenName)
		{
			return false;
		}
		if (!outputs_.Equals(other.outputs_))
		{
			return false;
		}
		if (LogoType != other.LogoType)
		{
			return false;
		}
		if (LogoFile != other.LogoFile)
		{
			return false;
		}
		if (RenderWidth != other.RenderWidth)
		{
			return false;
		}
		if (RenderHeight != other.RenderHeight)
		{
			return false;
		}
		if (EnableAudio != other.EnableAudio)
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
		if (pattern_ != null)
		{
			num ^= Pattern.GetHashCode();
		}
		if (ScreenName.Length != 0)
		{
			num ^= ScreenName.GetHashCode();
		}
		num ^= outputs_.GetHashCode();
		if (LogoType != 0)
		{
			num ^= LogoType.GetHashCode();
		}
		if (LogoFile.Length != 0)
		{
			num ^= LogoFile.GetHashCode();
		}
		if (RenderWidth != 0)
		{
			num ^= RenderWidth.GetHashCode();
		}
		if (RenderHeight != 0)
		{
			num ^= RenderHeight.GetHashCode();
		}
		if (EnableAudio)
		{
			num ^= EnableAudio.GetHashCode();
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
		if (pattern_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Pattern);
		}
		if (ScreenName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ScreenName);
		}
		outputs_.WriteTo(output, _repeated_outputs_codec);
		if (LogoType != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)LogoType);
		}
		if (LogoFile.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(LogoFile);
		}
		if (RenderWidth != 0)
		{
			output.WriteRawTag(56);
			output.WriteInt32(RenderWidth);
		}
		if (RenderHeight != 0)
		{
			output.WriteRawTag(64);
			output.WriteInt32(RenderHeight);
		}
		if (EnableAudio)
		{
			output.WriteRawTag(72);
			output.WriteBool(EnableAudio);
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
		if (pattern_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Pattern);
		}
		if (ScreenName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ScreenName);
		}
		num += outputs_.CalculateSize(_repeated_outputs_codec);
		if (LogoType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LogoType);
		}
		if (LogoFile.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(LogoFile);
		}
		if (RenderWidth != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(RenderWidth);
		}
		if (RenderHeight != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(RenderHeight);
		}
		if (EnableAudio)
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
	public void MergeFrom(TestPatternRenderSettings other)
	{
		if (other == null)
		{
			return;
		}
		if (other.pattern_ != null)
		{
			if (pattern_ == null)
			{
				Pattern = new TestPatternDefinition();
			}
			Pattern.MergeFrom(other.Pattern);
		}
		if (other.ScreenName.Length != 0)
		{
			ScreenName = other.ScreenName;
		}
		outputs_.Add(other.outputs_);
		if (other.LogoType != 0)
		{
			LogoType = other.LogoType;
		}
		if (other.LogoFile.Length != 0)
		{
			LogoFile = other.LogoFile;
		}
		if (other.RenderWidth != 0)
		{
			RenderWidth = other.RenderWidth;
		}
		if (other.RenderHeight != 0)
		{
			RenderHeight = other.RenderHeight;
		}
		if (other.EnableAudio)
		{
			EnableAudio = other.EnableAudio;
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
				if (pattern_ == null)
				{
					Pattern = new TestPatternDefinition();
				}
				input.ReadMessage(Pattern);
				break;
			case 26u:
				ScreenName = input.ReadString();
				break;
			case 34u:
				outputs_.AddEntriesFrom(input, _repeated_outputs_codec);
				break;
			case 40u:
				LogoType = (LogoType)input.ReadEnum();
				break;
			case 50u:
				LogoFile = input.ReadString();
				break;
			case 56u:
				RenderWidth = input.ReadInt32();
				break;
			case 64u:
				RenderHeight = input.ReadInt32();
				break;
			case 72u:
				EnableAudio = input.ReadBool();
				break;
			}
		}
	}
}
