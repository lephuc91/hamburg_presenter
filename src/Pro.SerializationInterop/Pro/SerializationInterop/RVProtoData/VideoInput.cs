using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class VideoInput : IMessage<VideoInput>, IMessage, IEquatable<VideoInput>, IDeepCloneable<VideoInput>
{
	public enum AltAudioSourceOneofCase
	{
		None = 0,
		AudioDevice = 6,
		VideoDevice = 7
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum AudioDeviceType
		{
			[OriginalName("AUDIO_DEVICE_TYPE_DEFAULT")]
			Default,
			[OriginalName("AUDIO_DEVICE_TYPE_NONE")]
			None,
			[OriginalName("AUDIO_DEVICE_TYPE_ALTERNATE")]
			Alternate
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SettingsDocument : IMessage<SettingsDocument>, IMessage, IEquatable<SettingsDocument>, IDeepCloneable<SettingsDocument>
		{
			private static readonly MessageParser<SettingsDocument> _parser = new MessageParser<SettingsDocument>(() => new SettingsDocument());

			private UnknownFieldSet _unknownFields;

			public const int InputsFieldNumber = 1;

			private static readonly FieldCodec<VideoInput> _repeated_inputs_codec = FieldCodec.ForMessage(10u, VideoInput.Parser);

			private readonly RepeatedField<VideoInput> inputs_ = new RepeatedField<VideoInput>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SettingsDocument> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => VideoInput.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<VideoInput> Inputs => inputs_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument(SettingsDocument other)
				: this()
			{
				inputs_ = other.inputs_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SettingsDocument Clone()
			{
				return new SettingsDocument(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SettingsDocument);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SettingsDocument other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!inputs_.Equals(other.inputs_))
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
				num ^= inputs_.GetHashCode();
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
				inputs_.WriteTo(output, _repeated_inputs_codec);
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
				num += inputs_.CalculateSize(_repeated_inputs_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SettingsDocument other)
			{
				if (other != null)
				{
					inputs_.Add(other.inputs_);
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
						inputs_.AddEntriesFrom(input, _repeated_inputs_codec);
					}
				}
			}
		}
	}

	private static readonly MessageParser<VideoInput> _parser = new MessageParser<VideoInput>(() => new VideoInput());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int UserDescriptionFieldNumber = 2;

	private string userDescription_ = "";

	public const int VideoInputDeviceFieldNumber = 3;

	private Media.Types.VideoDevice videoInputDevice_;

	public const int DisplayColorFieldNumber = 4;

	private Color displayColor_;

	public const int ThumbnailPathFieldNumber = 5;

	private URL thumbnailPath_;

	public const int AudioDeviceFieldNumber = 6;

	public const int VideoDeviceFieldNumber = 7;

	public const int AudioTypeFieldNumber = 8;

	private Types.AudioDeviceType audioType_;

	public const int AlphaTypeFieldNumber = 9;

	private AlphaType alphaType_;

	private object altAudioSource_;

	private AltAudioSourceOneofCase altAudioSourceCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<VideoInput> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => InputReflection.Descriptor.MessageTypes[0];

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
	public string UserDescription
	{
		get
		{
			return userDescription_;
		}
		set
		{
			userDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media.Types.VideoDevice VideoInputDevice
	{
		get
		{
			return videoInputDevice_;
		}
		set
		{
			videoInputDevice_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color DisplayColor
	{
		get
		{
			return displayColor_;
		}
		set
		{
			displayColor_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL ThumbnailPath
	{
		get
		{
			return thumbnailPath_;
		}
		set
		{
			thumbnailPath_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DigitalAudio.Types.Device AudioDevice
	{
		get
		{
			if (altAudioSourceCase_ != AltAudioSourceOneofCase.AudioDevice)
			{
				return null;
			}
			return (DigitalAudio.Types.Device)altAudioSource_;
		}
		set
		{
			altAudioSource_ = value;
			altAudioSourceCase_ = ((value != null) ? AltAudioSourceOneofCase.AudioDevice : AltAudioSourceOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media.Types.VideoDevice VideoDevice
	{
		get
		{
			if (altAudioSourceCase_ != AltAudioSourceOneofCase.VideoDevice)
			{
				return null;
			}
			return (Media.Types.VideoDevice)altAudioSource_;
		}
		set
		{
			altAudioSource_ = value;
			altAudioSourceCase_ = ((value != null) ? AltAudioSourceOneofCase.VideoDevice : AltAudioSourceOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AudioDeviceType AudioType
	{
		get
		{
			return audioType_;
		}
		set
		{
			audioType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AlphaType AlphaType
	{
		get
		{
			return alphaType_;
		}
		set
		{
			alphaType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AltAudioSourceOneofCase AltAudioSourceCase => altAudioSourceCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInput()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInput(VideoInput other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		userDescription_ = other.userDescription_;
		videoInputDevice_ = ((other.videoInputDevice_ != null) ? other.videoInputDevice_.Clone() : null);
		displayColor_ = ((other.displayColor_ != null) ? other.displayColor_.Clone() : null);
		thumbnailPath_ = ((other.thumbnailPath_ != null) ? other.thumbnailPath_.Clone() : null);
		audioType_ = other.audioType_;
		alphaType_ = other.alphaType_;
		switch (other.AltAudioSourceCase)
		{
		case AltAudioSourceOneofCase.AudioDevice:
			AudioDevice = other.AudioDevice.Clone();
			break;
		case AltAudioSourceOneofCase.VideoDevice:
			VideoDevice = other.VideoDevice.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInput Clone()
	{
		return new VideoInput(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearAltAudioSource()
	{
		altAudioSourceCase_ = AltAudioSourceOneofCase.None;
		altAudioSource_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as VideoInput);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(VideoInput other)
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
		if (UserDescription != other.UserDescription)
		{
			return false;
		}
		if (!object.Equals(VideoInputDevice, other.VideoInputDevice))
		{
			return false;
		}
		if (!object.Equals(DisplayColor, other.DisplayColor))
		{
			return false;
		}
		if (!object.Equals(ThumbnailPath, other.ThumbnailPath))
		{
			return false;
		}
		if (!object.Equals(AudioDevice, other.AudioDevice))
		{
			return false;
		}
		if (!object.Equals(VideoDevice, other.VideoDevice))
		{
			return false;
		}
		if (AudioType != other.AudioType)
		{
			return false;
		}
		if (AlphaType != other.AlphaType)
		{
			return false;
		}
		if (AltAudioSourceCase != other.AltAudioSourceCase)
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
		if (UserDescription.Length != 0)
		{
			num ^= UserDescription.GetHashCode();
		}
		if (videoInputDevice_ != null)
		{
			num ^= VideoInputDevice.GetHashCode();
		}
		if (displayColor_ != null)
		{
			num ^= DisplayColor.GetHashCode();
		}
		if (thumbnailPath_ != null)
		{
			num ^= ThumbnailPath.GetHashCode();
		}
		if (altAudioSourceCase_ == AltAudioSourceOneofCase.AudioDevice)
		{
			num ^= AudioDevice.GetHashCode();
		}
		if (altAudioSourceCase_ == AltAudioSourceOneofCase.VideoDevice)
		{
			num ^= VideoDevice.GetHashCode();
		}
		if (AudioType != 0)
		{
			num ^= AudioType.GetHashCode();
		}
		if (AlphaType != 0)
		{
			num ^= AlphaType.GetHashCode();
		}
		num ^= (int)altAudioSourceCase_;
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
		if (UserDescription.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(UserDescription);
		}
		if (videoInputDevice_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(VideoInputDevice);
		}
		if (displayColor_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DisplayColor);
		}
		if (thumbnailPath_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ThumbnailPath);
		}
		if (altAudioSourceCase_ == AltAudioSourceOneofCase.AudioDevice)
		{
			output.WriteRawTag(50);
			output.WriteMessage(AudioDevice);
		}
		if (altAudioSourceCase_ == AltAudioSourceOneofCase.VideoDevice)
		{
			output.WriteRawTag(58);
			output.WriteMessage(VideoDevice);
		}
		if (AudioType != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)AudioType);
		}
		if (AlphaType != 0)
		{
			output.WriteRawTag(72);
			output.WriteEnum((int)AlphaType);
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
		if (UserDescription.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(UserDescription);
		}
		if (videoInputDevice_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VideoInputDevice);
		}
		if (displayColor_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DisplayColor);
		}
		if (thumbnailPath_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ThumbnailPath);
		}
		if (altAudioSourceCase_ == AltAudioSourceOneofCase.AudioDevice)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioDevice);
		}
		if (altAudioSourceCase_ == AltAudioSourceOneofCase.VideoDevice)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VideoDevice);
		}
		if (AudioType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AudioType);
		}
		if (AlphaType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AlphaType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(VideoInput other)
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
		if (other.UserDescription.Length != 0)
		{
			UserDescription = other.UserDescription;
		}
		if (other.videoInputDevice_ != null)
		{
			if (videoInputDevice_ == null)
			{
				VideoInputDevice = new Media.Types.VideoDevice();
			}
			VideoInputDevice.MergeFrom(other.VideoInputDevice);
		}
		if (other.displayColor_ != null)
		{
			if (displayColor_ == null)
			{
				DisplayColor = new Color();
			}
			DisplayColor.MergeFrom(other.DisplayColor);
		}
		if (other.thumbnailPath_ != null)
		{
			if (thumbnailPath_ == null)
			{
				ThumbnailPath = new URL();
			}
			ThumbnailPath.MergeFrom(other.ThumbnailPath);
		}
		if (other.AudioType != 0)
		{
			AudioType = other.AudioType;
		}
		if (other.AlphaType != 0)
		{
			AlphaType = other.AlphaType;
		}
		switch (other.AltAudioSourceCase)
		{
		case AltAudioSourceOneofCase.AudioDevice:
			if (AudioDevice == null)
			{
				AudioDevice = new DigitalAudio.Types.Device();
			}
			AudioDevice.MergeFrom(other.AudioDevice);
			break;
		case AltAudioSourceOneofCase.VideoDevice:
			if (VideoDevice == null)
			{
				VideoDevice = new Media.Types.VideoDevice();
			}
			VideoDevice.MergeFrom(other.VideoDevice);
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				UserDescription = input.ReadString();
				break;
			case 26u:
				if (videoInputDevice_ == null)
				{
					VideoInputDevice = new Media.Types.VideoDevice();
				}
				input.ReadMessage(VideoInputDevice);
				break;
			case 34u:
				if (displayColor_ == null)
				{
					DisplayColor = new Color();
				}
				input.ReadMessage(DisplayColor);
				break;
			case 42u:
				if (thumbnailPath_ == null)
				{
					ThumbnailPath = new URL();
				}
				input.ReadMessage(ThumbnailPath);
				break;
			case 50u:
			{
				DigitalAudio.Types.Device device = new DigitalAudio.Types.Device();
				if (altAudioSourceCase_ == AltAudioSourceOneofCase.AudioDevice)
				{
					device.MergeFrom(AudioDevice);
				}
				input.ReadMessage(device);
				AudioDevice = device;
				break;
			}
			case 58u:
			{
				Media.Types.VideoDevice videoDevice = new Media.Types.VideoDevice();
				if (altAudioSourceCase_ == AltAudioSourceOneofCase.VideoDevice)
				{
					videoDevice.MergeFrom(VideoDevice);
				}
				input.ReadMessage(videoDevice);
				VideoDevice = videoDevice;
				break;
			}
			case 64u:
				AudioType = (Types.AudioDeviceType)input.ReadEnum();
				break;
			case 72u:
				AlphaType = (AlphaType)input.ReadEnum();
				break;
			}
		}
	}
}
