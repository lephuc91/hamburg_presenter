using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class VisualMedia : IMessage<VisualMedia>, IMessage, IEquatable<VisualMedia>, IDeepCloneable<VisualMedia>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Behavior
		{
			[OriginalName("BACKGROUND")]
			Background,
			[OriginalName("FOREGROUND")]
			Foreground,
			[OriginalName("VIDEO_INPUT")]
			VideoInput
		}

		public enum ScaleMode
		{
			[OriginalName("FIT")]
			Fit,
			[OriginalName("FILL")]
			Fill,
			[OriginalName("STRETCH")]
			Stretch,
			[OriginalName("BLUR")]
			Blur
		}

		public enum FlipMode
		{
			[OriginalName("NONE")]
			None,
			[OriginalName("HORIZONTAL")]
			Horizontal,
			[OriginalName("VERTICAL")]
			Vertical,
			[OriginalName("BOTH")]
			Both
		}

		public enum NativeRotation
		{
			[OriginalName("STANDARD")]
			Standard = 0,
			[OriginalName("_90")]
			_90 = 90,
			[OriginalName("_180")]
			_180 = 180,
			[OriginalName("_270")]
			_270 = 270
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Size : IMessage<Size>, IMessage, IEquatable<Size>, IDeepCloneable<Size>
		{
			private static readonly MessageParser<Size> _parser = new MessageParser<Size>(() => new Size());

			private UnknownFieldSet _unknownFields;

			public const int WidthFieldNumber = 1;

			private uint width_;

			public const int HeightFieldNumber = 2;

			private uint height_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Size> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => VisualMedia.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public uint Height
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
				if (Width != other.Width)
				{
					return false;
				}
				if (Height != other.Height)
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
				if (Width != 0)
				{
					num ^= Width.GetHashCode();
				}
				if (Height != 0)
				{
					num ^= Height.GetHashCode();
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
				if (Width != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Width);
				}
				if (Height != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Height);
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
				if (Width != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Width);
				}
				if (Height != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Height);
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
					if (other.Width != 0)
					{
						Width = other.Width;
					}
					if (other.Height != 0)
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
					case 8u:
						Width = input.ReadUInt32();
						break;
					case 16u:
						Height = input.ReadUInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<VisualMedia> _parser = new MessageParser<VisualMedia>(() => new VisualMedia());

	private UnknownFieldSet _unknownFields;

	public const int BehaviorFieldNumber = 1;

	private Types.Behavior behavior_;

	public const int ScaleModeFieldNumber = 2;

	private Types.ScaleMode scaleMode_;

	public const int FlipModeFieldNumber = 3;

	private Types.FlipMode flipMode_;

	public const int NativeRotationFieldNumber = 4;

	private Types.NativeRotation nativeRotation_;

	public const int ResolutionFieldNumber = 5;

	private Types.Size resolution_;

	public const int EnabledEffectsCountFieldNumber = 6;

	private uint enabledEffectsCount_;

	public const int HasEffectPresetFieldNumber = 7;

	private bool hasEffectPreset_;

	public const int TransitionFieldNumber = 8;

	private Transition transition_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<VisualMedia> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerMediaReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Behavior Behavior
	{
		get
		{
			return behavior_;
		}
		set
		{
			behavior_ = value;
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
	public Types.NativeRotation NativeRotation
	{
		get
		{
			return nativeRotation_;
		}
		set
		{
			nativeRotation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Size Resolution
	{
		get
		{
			return resolution_;
		}
		set
		{
			resolution_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint EnabledEffectsCount
	{
		get
		{
			return enabledEffectsCount_;
		}
		set
		{
			enabledEffectsCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasEffectPreset
	{
		get
		{
			return hasEffectPreset_;
		}
		set
		{
			hasEffectPreset_ = value;
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
	public VisualMedia()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VisualMedia(VisualMedia other)
		: this()
	{
		behavior_ = other.behavior_;
		scaleMode_ = other.scaleMode_;
		flipMode_ = other.flipMode_;
		nativeRotation_ = other.nativeRotation_;
		resolution_ = ((other.resolution_ != null) ? other.resolution_.Clone() : null);
		enabledEffectsCount_ = other.enabledEffectsCount_;
		hasEffectPreset_ = other.hasEffectPreset_;
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VisualMedia Clone()
	{
		return new VisualMedia(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as VisualMedia);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(VisualMedia other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Behavior != other.Behavior)
		{
			return false;
		}
		if (ScaleMode != other.ScaleMode)
		{
			return false;
		}
		if (FlipMode != other.FlipMode)
		{
			return false;
		}
		if (NativeRotation != other.NativeRotation)
		{
			return false;
		}
		if (!object.Equals(Resolution, other.Resolution))
		{
			return false;
		}
		if (EnabledEffectsCount != other.EnabledEffectsCount)
		{
			return false;
		}
		if (HasEffectPreset != other.HasEffectPreset)
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
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
		if (Behavior != 0)
		{
			num ^= Behavior.GetHashCode();
		}
		if (ScaleMode != 0)
		{
			num ^= ScaleMode.GetHashCode();
		}
		if (FlipMode != 0)
		{
			num ^= FlipMode.GetHashCode();
		}
		if (NativeRotation != 0)
		{
			num ^= NativeRotation.GetHashCode();
		}
		if (resolution_ != null)
		{
			num ^= Resolution.GetHashCode();
		}
		if (EnabledEffectsCount != 0)
		{
			num ^= EnabledEffectsCount.GetHashCode();
		}
		if (HasEffectPreset)
		{
			num ^= HasEffectPreset.GetHashCode();
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
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
		if (Behavior != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Behavior);
		}
		if (ScaleMode != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)ScaleMode);
		}
		if (FlipMode != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)FlipMode);
		}
		if (NativeRotation != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)NativeRotation);
		}
		if (resolution_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Resolution);
		}
		if (EnabledEffectsCount != 0)
		{
			output.WriteRawTag(48);
			output.WriteUInt32(EnabledEffectsCount);
		}
		if (HasEffectPreset)
		{
			output.WriteRawTag(56);
			output.WriteBool(HasEffectPreset);
		}
		if (transition_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Transition);
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
		if (Behavior != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Behavior);
		}
		if (ScaleMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ScaleMode);
		}
		if (FlipMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)FlipMode);
		}
		if (NativeRotation != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)NativeRotation);
		}
		if (resolution_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Resolution);
		}
		if (EnabledEffectsCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(EnabledEffectsCount);
		}
		if (HasEffectPreset)
		{
			num += 2;
		}
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(VisualMedia other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Behavior != 0)
		{
			Behavior = other.Behavior;
		}
		if (other.ScaleMode != 0)
		{
			ScaleMode = other.ScaleMode;
		}
		if (other.FlipMode != 0)
		{
			FlipMode = other.FlipMode;
		}
		if (other.NativeRotation != 0)
		{
			NativeRotation = other.NativeRotation;
		}
		if (other.resolution_ != null)
		{
			if (resolution_ == null)
			{
				Resolution = new Types.Size();
			}
			Resolution.MergeFrom(other.Resolution);
		}
		if (other.EnabledEffectsCount != 0)
		{
			EnabledEffectsCount = other.EnabledEffectsCount;
		}
		if (other.HasEffectPreset)
		{
			HasEffectPreset = other.HasEffectPreset;
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
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
				Behavior = (Types.Behavior)input.ReadEnum();
				break;
			case 16u:
				ScaleMode = (Types.ScaleMode)input.ReadEnum();
				break;
			case 24u:
				FlipMode = (Types.FlipMode)input.ReadEnum();
				break;
			case 32u:
				NativeRotation = (Types.NativeRotation)input.ReadEnum();
				break;
			case 42u:
				if (resolution_ == null)
				{
					Resolution = new Types.Size();
				}
				input.ReadMessage(Resolution);
				break;
			case 48u:
				EnabledEffectsCount = input.ReadUInt32();
				break;
			case 56u:
				HasEffectPreset = input.ReadBool();
				break;
			case 66u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			}
		}
	}
}
