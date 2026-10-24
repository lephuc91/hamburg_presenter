using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class OutputDisplay : IMessage<OutputDisplay>, IMessage, IEquatable<OutputDisplay>, IDeepCloneable<OutputDisplay>
{
	public enum HardwareOptionsOneofCase
	{
		None = 0,
		Blackmagic = 11
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("TYPE_SCREEN")]
			Screen,
			[OriginalName("TYPE_CARD")]
			Card,
			[OriginalName("TYPE_NDI")]
			Ndi,
			[OriginalName("TYPE_SYPHON")]
			Syphon,
			[OriginalName("TYPE_CUSTOM")]
			Custom
		}

		public enum RenderFormat
		{
			[OriginalName("RENDERFORMAT_SDR")]
			Sdr,
			[OriginalName("RENDERFORMAT_REC_2100_PQ")]
			Rec2100Pq,
			[OriginalName("RENDERFORMAT_REC_2100_HLG")]
			Rec2100Hlg
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Blackmagic : IMessage<Blackmagic>, IMessage, IEquatable<Blackmagic>, IDeepCloneable<Blackmagic>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum KeyMode
				{
					[OriginalName("KEY_MODE_INTERNAL")]
					Internal,
					[OriginalName("KEY_MODE_EXTERNAL")]
					External
				}
			}

			private static readonly MessageParser<Blackmagic> _parser = new MessageParser<Blackmagic>(() => new Blackmagic());

			private UnknownFieldSet _unknownFields;

			public const int EnabledFieldNumber = 1;

			private bool enabled_;

			public const int KeyModeFieldNumber = 2;

			private Types.KeyMode keyMode_;

			public const int BlendValueFieldNumber = 3;

			private double blendValue_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Blackmagic> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => OutputDisplay.Descriptor.NestedTypes[0];

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
			public Types.KeyMode KeyMode
			{
				get
				{
					return keyMode_;
				}
				set
				{
					keyMode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double BlendValue
			{
				get
				{
					return blendValue_;
				}
				set
				{
					blendValue_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Blackmagic()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Blackmagic(Blackmagic other)
				: this()
			{
				enabled_ = other.enabled_;
				keyMode_ = other.keyMode_;
				blendValue_ = other.blendValue_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Blackmagic Clone()
			{
				return new Blackmagic(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Blackmagic);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Blackmagic other)
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
				if (KeyMode != other.KeyMode)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(BlendValue, other.BlendValue))
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
				if (KeyMode != 0)
				{
					num ^= KeyMode.GetHashCode();
				}
				if (BlendValue != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(BlendValue);
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
				if (KeyMode != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)KeyMode);
				}
				if (BlendValue != 0.0)
				{
					output.WriteRawTag(25);
					output.WriteDouble(BlendValue);
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
				if (KeyMode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)KeyMode);
				}
				if (BlendValue != 0.0)
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
			public void MergeFrom(Blackmagic other)
			{
				if (other != null)
				{
					if (other.Enabled)
					{
						Enabled = other.Enabled;
					}
					if (other.KeyMode != 0)
					{
						KeyMode = other.KeyMode;
					}
					if (other.BlendValue != 0.0)
					{
						BlendValue = other.BlendValue;
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
					case 16u:
						KeyMode = (Types.KeyMode)input.ReadEnum();
						break;
					case 25u:
						BlendValue = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<OutputDisplay> _parser = new MessageParser<OutputDisplay>(() => new OutputDisplay());

	private UnknownFieldSet _unknownFields;

	public const int NameFieldNumber = 1;

	private string name_ = "";

	public const int ModelFieldNumber = 2;

	private string model_ = "";

	public const int SerialFieldNumber = 3;

	private string serial_ = "";

	public const int DeviceNameFieldNumber = 4;

	private string deviceName_ = "";

	public const int VendorFieldNumber = 5;

	private string vendor_ = "";

	public const int ModeIndexFieldNumber = 6;

	private uint modeIndex_;

	public const int BoundsFieldNumber = 7;

	private Graphics.Types.Rect bounds_;

	public const int TypeFieldNumber = 8;

	private Types.Type type_;

	public const int ModeFieldNumber = 9;

	private DisplayMode mode_;

	public const int RenderIdFieldNumber = 10;

	private string renderId_ = "";

	public const int BlackmagicFieldNumber = 11;

	public const int VideoDelayFieldNumber = 12;

	private int videoDelay_;

	public const int RenderFormatFieldNumber = 13;

	private Types.RenderFormat renderFormat_;

	public const int HdrMaxNitsOffsetFieldNumber = 14;

	private int hdrMaxNitsOffset_;

	private object hardwareOptions_;

	private HardwareOptionsOneofCase hardwareOptionsCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<OutputDisplay> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ScreensReflection.Descriptor.MessageTypes[3];

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
	public string Model
	{
		get
		{
			return model_;
		}
		set
		{
			model_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Serial
	{
		get
		{
			return serial_;
		}
		set
		{
			serial_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DeviceName
	{
		get
		{
			return deviceName_;
		}
		set
		{
			deviceName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Vendor
	{
		get
		{
			return vendor_;
		}
		set
		{
			vendor_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint ModeIndex
	{
		get
		{
			return modeIndex_;
		}
		set
		{
			modeIndex_ = value;
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
	public DisplayMode Mode
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
	public Types.Blackmagic Blackmagic
	{
		get
		{
			if (hardwareOptionsCase_ != HardwareOptionsOneofCase.Blackmagic)
			{
				return null;
			}
			return (Types.Blackmagic)hardwareOptions_;
		}
		set
		{
			hardwareOptions_ = value;
			hardwareOptionsCase_ = ((value != null) ? HardwareOptionsOneofCase.Blackmagic : HardwareOptionsOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int VideoDelay
	{
		get
		{
			return videoDelay_;
		}
		set
		{
			videoDelay_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.RenderFormat RenderFormat
	{
		get
		{
			return renderFormat_;
		}
		set
		{
			renderFormat_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int HdrMaxNitsOffset
	{
		get
		{
			return hdrMaxNitsOffset_;
		}
		set
		{
			hdrMaxNitsOffset_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HardwareOptionsOneofCase HardwareOptionsCase => hardwareOptionsCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OutputDisplay()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OutputDisplay(OutputDisplay other)
		: this()
	{
		name_ = other.name_;
		model_ = other.model_;
		serial_ = other.serial_;
		deviceName_ = other.deviceName_;
		vendor_ = other.vendor_;
		modeIndex_ = other.modeIndex_;
		bounds_ = ((other.bounds_ != null) ? other.bounds_.Clone() : null);
		type_ = other.type_;
		mode_ = ((other.mode_ != null) ? other.mode_.Clone() : null);
		renderId_ = other.renderId_;
		videoDelay_ = other.videoDelay_;
		renderFormat_ = other.renderFormat_;
		hdrMaxNitsOffset_ = other.hdrMaxNitsOffset_;
		if (other.HardwareOptionsCase == HardwareOptionsOneofCase.Blackmagic)
		{
			Blackmagic = other.Blackmagic.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OutputDisplay Clone()
	{
		return new OutputDisplay(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearHardwareOptions()
	{
		hardwareOptionsCase_ = HardwareOptionsOneofCase.None;
		hardwareOptions_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as OutputDisplay);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(OutputDisplay other)
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
		if (Model != other.Model)
		{
			return false;
		}
		if (Serial != other.Serial)
		{
			return false;
		}
		if (DeviceName != other.DeviceName)
		{
			return false;
		}
		if (Vendor != other.Vendor)
		{
			return false;
		}
		if (ModeIndex != other.ModeIndex)
		{
			return false;
		}
		if (!object.Equals(Bounds, other.Bounds))
		{
			return false;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (!object.Equals(Mode, other.Mode))
		{
			return false;
		}
		if (RenderId != other.RenderId)
		{
			return false;
		}
		if (!object.Equals(Blackmagic, other.Blackmagic))
		{
			return false;
		}
		if (VideoDelay != other.VideoDelay)
		{
			return false;
		}
		if (RenderFormat != other.RenderFormat)
		{
			return false;
		}
		if (HdrMaxNitsOffset != other.HdrMaxNitsOffset)
		{
			return false;
		}
		if (HardwareOptionsCase != other.HardwareOptionsCase)
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
		if (Model.Length != 0)
		{
			num ^= Model.GetHashCode();
		}
		if (Serial.Length != 0)
		{
			num ^= Serial.GetHashCode();
		}
		if (DeviceName.Length != 0)
		{
			num ^= DeviceName.GetHashCode();
		}
		if (Vendor.Length != 0)
		{
			num ^= Vendor.GetHashCode();
		}
		if (ModeIndex != 0)
		{
			num ^= ModeIndex.GetHashCode();
		}
		if (bounds_ != null)
		{
			num ^= Bounds.GetHashCode();
		}
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (mode_ != null)
		{
			num ^= Mode.GetHashCode();
		}
		if (RenderId.Length != 0)
		{
			num ^= RenderId.GetHashCode();
		}
		if (hardwareOptionsCase_ == HardwareOptionsOneofCase.Blackmagic)
		{
			num ^= Blackmagic.GetHashCode();
		}
		if (VideoDelay != 0)
		{
			num ^= VideoDelay.GetHashCode();
		}
		if (RenderFormat != 0)
		{
			num ^= RenderFormat.GetHashCode();
		}
		if (HdrMaxNitsOffset != 0)
		{
			num ^= HdrMaxNitsOffset.GetHashCode();
		}
		num ^= (int)hardwareOptionsCase_;
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
		if (Model.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Model);
		}
		if (Serial.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Serial);
		}
		if (DeviceName.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(DeviceName);
		}
		if (Vendor.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(Vendor);
		}
		if (ModeIndex != 0)
		{
			output.WriteRawTag(48);
			output.WriteUInt32(ModeIndex);
		}
		if (bounds_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Bounds);
		}
		if (Type != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)Type);
		}
		if (mode_ != null)
		{
			output.WriteRawTag(74);
			output.WriteMessage(Mode);
		}
		if (RenderId.Length != 0)
		{
			output.WriteRawTag(82);
			output.WriteString(RenderId);
		}
		if (hardwareOptionsCase_ == HardwareOptionsOneofCase.Blackmagic)
		{
			output.WriteRawTag(90);
			output.WriteMessage(Blackmagic);
		}
		if (VideoDelay != 0)
		{
			output.WriteRawTag(96);
			output.WriteInt32(VideoDelay);
		}
		if (RenderFormat != 0)
		{
			output.WriteRawTag(104);
			output.WriteEnum((int)RenderFormat);
		}
		if (HdrMaxNitsOffset != 0)
		{
			output.WriteRawTag(112);
			output.WriteInt32(HdrMaxNitsOffset);
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
		if (Model.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Model);
		}
		if (Serial.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Serial);
		}
		if (DeviceName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DeviceName);
		}
		if (Vendor.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Vendor);
		}
		if (ModeIndex != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(ModeIndex);
		}
		if (bounds_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Bounds);
		}
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (mode_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Mode);
		}
		if (RenderId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(RenderId);
		}
		if (hardwareOptionsCase_ == HardwareOptionsOneofCase.Blackmagic)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Blackmagic);
		}
		if (VideoDelay != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(VideoDelay);
		}
		if (RenderFormat != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)RenderFormat);
		}
		if (HdrMaxNitsOffset != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(HdrMaxNitsOffset);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(OutputDisplay other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.Model.Length != 0)
		{
			Model = other.Model;
		}
		if (other.Serial.Length != 0)
		{
			Serial = other.Serial;
		}
		if (other.DeviceName.Length != 0)
		{
			DeviceName = other.DeviceName;
		}
		if (other.Vendor.Length != 0)
		{
			Vendor = other.Vendor;
		}
		if (other.ModeIndex != 0)
		{
			ModeIndex = other.ModeIndex;
		}
		if (other.bounds_ != null)
		{
			if (bounds_ == null)
			{
				Bounds = new Graphics.Types.Rect();
			}
			Bounds.MergeFrom(other.Bounds);
		}
		if (other.Type != 0)
		{
			Type = other.Type;
		}
		if (other.mode_ != null)
		{
			if (mode_ == null)
			{
				Mode = new DisplayMode();
			}
			Mode.MergeFrom(other.Mode);
		}
		if (other.RenderId.Length != 0)
		{
			RenderId = other.RenderId;
		}
		if (other.VideoDelay != 0)
		{
			VideoDelay = other.VideoDelay;
		}
		if (other.RenderFormat != 0)
		{
			RenderFormat = other.RenderFormat;
		}
		if (other.HdrMaxNitsOffset != 0)
		{
			HdrMaxNitsOffset = other.HdrMaxNitsOffset;
		}
		if (other.HardwareOptionsCase == HardwareOptionsOneofCase.Blackmagic)
		{
			if (Blackmagic == null)
			{
				Blackmagic = new Types.Blackmagic();
			}
			Blackmagic.MergeFrom(other.Blackmagic);
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
				Model = input.ReadString();
				break;
			case 26u:
				Serial = input.ReadString();
				break;
			case 34u:
				DeviceName = input.ReadString();
				break;
			case 42u:
				Vendor = input.ReadString();
				break;
			case 48u:
				ModeIndex = input.ReadUInt32();
				break;
			case 58u:
				if (bounds_ == null)
				{
					Bounds = new Graphics.Types.Rect();
				}
				input.ReadMessage(Bounds);
				break;
			case 64u:
				Type = (Types.Type)input.ReadEnum();
				break;
			case 74u:
				if (mode_ == null)
				{
					Mode = new DisplayMode();
				}
				input.ReadMessage(Mode);
				break;
			case 82u:
				RenderId = input.ReadString();
				break;
			case 90u:
			{
				Types.Blackmagic blackmagic = new Types.Blackmagic();
				if (hardwareOptionsCase_ == HardwareOptionsOneofCase.Blackmagic)
				{
					blackmagic.MergeFrom(Blackmagic);
				}
				input.ReadMessage(blackmagic);
				Blackmagic = blackmagic;
				break;
			}
			case 96u:
				VideoDelay = input.ReadInt32();
				break;
			case 104u:
				RenderFormat = (Types.RenderFormat)input.ReadEnum();
				break;
			case 112u:
				HdrMaxNitsOffset = input.ReadInt32();
				break;
			}
		}
	}
}
