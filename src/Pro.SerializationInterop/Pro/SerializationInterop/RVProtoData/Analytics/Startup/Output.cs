using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Output : IMessage<Output>, IMessage, IEquatable<Output>, IDeepCloneable<Output>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ProScreenType
		{
			[OriginalName("PRO_SCREEN_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("SINGLE")]
			Single,
			[OriginalName("MIRRORED")]
			Mirrored,
			[OriginalName("EDGE_BLEND")]
			EdgeBlend,
			[OriginalName("GROUPED")]
			Grouped
		}

		public enum OutputType
		{
			[OriginalName("OUTPUT_TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("SDI")]
			Sdi,
			[OriginalName("NDI")]
			Ndi,
			[OriginalName("SYPHON")]
			Syphon,
			[OriginalName("SYSTEM")]
			System,
			[OriginalName("PLACEHOLDER")]
			Placeholder,
			[OriginalName("DVI")]
			Dvi
		}

		public enum Alignment
		{
			[OriginalName("ALIGNMENT_UNKNOWN")]
			Unknown,
			[OriginalName("FULL")]
			Full,
			[OriginalName("_2X1")]
			_2X1,
			[OriginalName("_3X1")]
			_3X1,
			[OriginalName("_2X2")]
			_2X2,
			[OriginalName("CUSTOM")]
			Custom
		}

		public enum AlphaKeyMode
		{
			[OriginalName("ALPHA_KEY_MODE_NONE")]
			None,
			[OriginalName("PREMULTIPLIED")]
			Premultiplied,
			[OriginalName("STRAIGHT")]
			Straight
		}

		public enum AlphaDevice
		{
			[OriginalName("ALPHA_DEVICE_NONE")]
			None,
			[OriginalName("SELF")]
			Self,
			[OriginalName("OTHER")]
			Other
		}
	}

	private static readonly MessageParser<Output> _parser = new MessageParser<Output>(() => new Output());

	private UnknownFieldSet _unknownFields;

	public const int ProscreenTypeFieldNumber = 1;

	private Types.ProScreenType proscreenType_;

	public const int OutputTypeFieldNumber = 2;

	private Types.OutputType outputType_;

	public const int ColorCorrectionEnabledFieldNumber = 3;

	private bool colorCorrectionEnabled_;

	public const int CornerPinEnabledFieldNumber = 4;

	private bool cornerPinEnabled_;

	public const int AlignmentFieldNumber = 5;

	private Types.Alignment alignment_;

	public const int WidthFieldNumber = 6;

	private int width_;

	public const int HeightFieldNumber = 7;

	private int height_;

	public const int AlphaKeyModeFieldNumber = 8;

	private Types.AlphaKeyMode alphaKeyMode_;

	public const int AlphaDeviceFieldNumber = 9;

	private Types.AlphaDevice alphaDevice_;

	public const int IsDisabledFieldNumber = 10;

	private bool isDisabled_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Output> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ProScreenType ProscreenType
	{
		get
		{
			return proscreenType_;
		}
		set
		{
			proscreenType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.OutputType OutputType
	{
		get
		{
			return outputType_;
		}
		set
		{
			outputType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ColorCorrectionEnabled
	{
		get
		{
			return colorCorrectionEnabled_;
		}
		set
		{
			colorCorrectionEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool CornerPinEnabled
	{
		get
		{
			return cornerPinEnabled_;
		}
		set
		{
			cornerPinEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Alignment Alignment
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
	public Types.AlphaKeyMode AlphaKeyMode
	{
		get
		{
			return alphaKeyMode_;
		}
		set
		{
			alphaKeyMode_ = value;
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
	public bool IsDisabled
	{
		get
		{
			return isDisabled_;
		}
		set
		{
			isDisabled_ = value;
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
		proscreenType_ = other.proscreenType_;
		outputType_ = other.outputType_;
		colorCorrectionEnabled_ = other.colorCorrectionEnabled_;
		cornerPinEnabled_ = other.cornerPinEnabled_;
		alignment_ = other.alignment_;
		width_ = other.width_;
		height_ = other.height_;
		alphaKeyMode_ = other.alphaKeyMode_;
		alphaDevice_ = other.alphaDevice_;
		isDisabled_ = other.isDisabled_;
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
		if (ProscreenType != other.ProscreenType)
		{
			return false;
		}
		if (OutputType != other.OutputType)
		{
			return false;
		}
		if (ColorCorrectionEnabled != other.ColorCorrectionEnabled)
		{
			return false;
		}
		if (CornerPinEnabled != other.CornerPinEnabled)
		{
			return false;
		}
		if (Alignment != other.Alignment)
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
		if (AlphaKeyMode != other.AlphaKeyMode)
		{
			return false;
		}
		if (AlphaDevice != other.AlphaDevice)
		{
			return false;
		}
		if (IsDisabled != other.IsDisabled)
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
		if (ProscreenType != 0)
		{
			num ^= ProscreenType.GetHashCode();
		}
		if (OutputType != 0)
		{
			num ^= OutputType.GetHashCode();
		}
		if (ColorCorrectionEnabled)
		{
			num ^= ColorCorrectionEnabled.GetHashCode();
		}
		if (CornerPinEnabled)
		{
			num ^= CornerPinEnabled.GetHashCode();
		}
		if (Alignment != 0)
		{
			num ^= Alignment.GetHashCode();
		}
		if (Width != 0)
		{
			num ^= Width.GetHashCode();
		}
		if (Height != 0)
		{
			num ^= Height.GetHashCode();
		}
		if (AlphaKeyMode != 0)
		{
			num ^= AlphaKeyMode.GetHashCode();
		}
		if (AlphaDevice != 0)
		{
			num ^= AlphaDevice.GetHashCode();
		}
		if (IsDisabled)
		{
			num ^= IsDisabled.GetHashCode();
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
		if (ProscreenType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ProscreenType);
		}
		if (OutputType != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)OutputType);
		}
		if (ColorCorrectionEnabled)
		{
			output.WriteRawTag(24);
			output.WriteBool(ColorCorrectionEnabled);
		}
		if (CornerPinEnabled)
		{
			output.WriteRawTag(32);
			output.WriteBool(CornerPinEnabled);
		}
		if (Alignment != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)Alignment);
		}
		if (Width != 0)
		{
			output.WriteRawTag(48);
			output.WriteInt32(Width);
		}
		if (Height != 0)
		{
			output.WriteRawTag(56);
			output.WriteInt32(Height);
		}
		if (AlphaKeyMode != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)AlphaKeyMode);
		}
		if (AlphaDevice != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)AlphaDevice);
		}
		if (IsDisabled)
		{
			output.WriteRawTag(80);
			output.WriteBool(IsDisabled);
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
		if (ProscreenType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ProscreenType);
		}
		if (OutputType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)OutputType);
		}
		if (ColorCorrectionEnabled)
		{
			num += 2;
		}
		if (CornerPinEnabled)
		{
			num += 2;
		}
		if (Alignment != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Alignment);
		}
		if (Width != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Width);
		}
		if (Height != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Height);
		}
		if (AlphaKeyMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AlphaKeyMode);
		}
		if (AlphaDevice != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AlphaDevice);
		}
		if (IsDisabled)
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
	public void MergeFrom(Output other)
	{
		if (other != null)
		{
			if (other.ProscreenType != 0)
			{
				ProscreenType = other.ProscreenType;
			}
			if (other.OutputType != 0)
			{
				OutputType = other.OutputType;
			}
			if (other.ColorCorrectionEnabled)
			{
				ColorCorrectionEnabled = other.ColorCorrectionEnabled;
			}
			if (other.CornerPinEnabled)
			{
				CornerPinEnabled = other.CornerPinEnabled;
			}
			if (other.Alignment != 0)
			{
				Alignment = other.Alignment;
			}
			if (other.Width != 0)
			{
				Width = other.Width;
			}
			if (other.Height != 0)
			{
				Height = other.Height;
			}
			if (other.AlphaKeyMode != 0)
			{
				AlphaKeyMode = other.AlphaKeyMode;
			}
			if (other.AlphaDevice != 0)
			{
				AlphaDevice = other.AlphaDevice;
			}
			if (other.IsDisabled)
			{
				IsDisabled = other.IsDisabled;
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
				ProscreenType = (Types.ProScreenType)input.ReadEnum();
				break;
			case 16u:
				OutputType = (Types.OutputType)input.ReadEnum();
				break;
			case 24u:
				ColorCorrectionEnabled = input.ReadBool();
				break;
			case 32u:
				CornerPinEnabled = input.ReadBool();
				break;
			case 40u:
				Alignment = (Types.Alignment)input.ReadEnum();
				break;
			case 48u:
				Width = input.ReadInt32();
				break;
			case 56u:
				Height = input.ReadInt32();
				break;
			case 64u:
				AlphaKeyMode = (Types.AlphaKeyMode)input.ReadEnum();
				break;
			case 72u:
				AlphaDevice = (Types.AlphaDevice)input.ReadEnum();
				break;
			case 80u:
				IsDisabled = input.ReadBool();
				break;
			}
		}
	}
}
