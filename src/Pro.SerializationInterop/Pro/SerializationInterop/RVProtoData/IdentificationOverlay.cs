using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class IdentificationOverlay : IMessage<IdentificationOverlay>, IMessage, IEquatable<IdentificationOverlay>, IDeepCloneable<IdentificationOverlay>
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
			public static MessageDescriptor Descriptor => IdentificationOverlay.Descriptor.NestedTypes[0];

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

	private static readonly MessageParser<IdentificationOverlay> _parser = new MessageParser<IdentificationOverlay>(() => new IdentificationOverlay());

	private UnknownFieldSet _unknownFields;

	public const int ScreenNameFieldNumber = 3;

	private string screenName_ = "";

	public const int OutputsFieldNumber = 1;

	private static readonly FieldCodec<Types.Output> _repeated_outputs_codec = FieldCodec.ForMessage(10u, Types.Output.Parser);

	private readonly RepeatedField<Types.Output> outputs_ = new RepeatedField<Types.Output>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<IdentificationOverlay> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => Rv2DReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public IdentificationOverlay()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public IdentificationOverlay(IdentificationOverlay other)
		: this()
	{
		screenName_ = other.screenName_;
		outputs_ = other.outputs_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public IdentificationOverlay Clone()
	{
		return new IdentificationOverlay(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as IdentificationOverlay);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(IdentificationOverlay other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ScreenName != other.ScreenName)
		{
			return false;
		}
		if (!outputs_.Equals(other.outputs_))
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
		if (ScreenName.Length != 0)
		{
			num ^= ScreenName.GetHashCode();
		}
		num ^= outputs_.GetHashCode();
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
		outputs_.WriteTo(output, _repeated_outputs_codec);
		if (ScreenName.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ScreenName);
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
		if (ScreenName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ScreenName);
		}
		num += outputs_.CalculateSize(_repeated_outputs_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(IdentificationOverlay other)
	{
		if (other != null)
		{
			if (other.ScreenName.Length != 0)
			{
				ScreenName = other.ScreenName;
			}
			outputs_.Add(other.outputs_);
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
				outputs_.AddEntriesFrom(input, _repeated_outputs_codec);
				break;
			case 26u:
				ScreenName = input.ReadString();
				break;
			}
		}
	}
}
