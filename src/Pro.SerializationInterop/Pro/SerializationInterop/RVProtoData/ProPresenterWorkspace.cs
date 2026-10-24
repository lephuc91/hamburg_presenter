using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProPresenterWorkspace : IMessage<ProPresenterWorkspace>, IMessage, IEquatable<ProPresenterWorkspace>, IDeepCloneable<ProPresenterWorkspace>
{
	private static readonly MessageParser<ProPresenterWorkspace> _parser = new MessageParser<ProPresenterWorkspace>(() => new ProPresenterWorkspace());

	private UnknownFieldSet _unknownFields;

	public const int ProScreensFieldNumber = 1;

	private static readonly FieldCodec<ProPresenterScreen> _repeated_proScreens_codec = FieldCodec.ForMessage(10u, ProPresenterScreen.Parser);

	private readonly RepeatedField<ProPresenterScreen> proScreens_ = new RepeatedField<ProPresenterScreen>();

	public const int AudienceLooksFieldNumber = 2;

	private static readonly FieldCodec<ProAudienceLook> _repeated_audienceLooks_codec = FieldCodec.ForMessage(18u, ProAudienceLook.Parser);

	private readonly RepeatedField<ProAudienceLook> audienceLooks_ = new RepeatedField<ProAudienceLook>();

	public const int LiveAudienceLookFieldNumber = 3;

	private ProAudienceLook liveAudienceLook_;

	public const int MasksFieldNumber = 4;

	private static readonly FieldCodec<ProMask> _repeated_masks_codec = FieldCodec.ForMessage(34u, ProMask.Parser);

	private readonly RepeatedField<ProMask> masks_ = new RepeatedField<ProMask>();

	public const int VideoInputsFieldNumber = 5;

	private static readonly FieldCodec<VideoInput> _repeated_videoInputs_codec = FieldCodec.ForMessage(42u, VideoInput.Parser);

	private readonly RepeatedField<VideoInput> videoInputs_ = new RepeatedField<VideoInput>();

	public const int StageLayoutMappingsFieldNumber = 6;

	private static readonly FieldCodec<Stage.Types.ScreenAssignment> _repeated_stageLayoutMappings_codec = FieldCodec.ForMessage(50u, Stage.Types.ScreenAssignment.Parser);

	private readonly RepeatedField<Stage.Types.ScreenAssignment> stageLayoutMappings_ = new RepeatedField<Stage.Types.ScreenAssignment>();

	public const int AudioSettingsFieldNumber = 7;

	private Audio.Types.SettingsDocument audioSettings_;

	public const int SelectedLibraryNameFieldNumber = 8;

	private string selectedLibraryName_ = "";

	public const int RecordSettingsFieldNumber = 9;

	private Recording.Types.SettingsDocument recordSettings_;

	public const int DigitalAudioSetupFieldNumber = 10;

	private DigitalAudio.Types.Setup digitalAudioSetup_;

	public const int AudioInputsFieldNumber = 11;

	private static readonly FieldCodec<AudioInput> _repeated_audioInputs_codec = FieldCodec.ForMessage(90u, AudioInput.Parser);

	private readonly RepeatedField<AudioInput> audioInputs_ = new RepeatedField<AudioInput>();

	public const int AudioInputTransitionTimeFieldNumber = 12;

	private double audioInputTransitionTime_;

	public const int CloudOutputScreensFieldNumber = 13;

	private static readonly FieldCodec<CloudProPresenterScreen> _repeated_cloudOutputScreens_codec = FieldCodec.ForMessage(106u, CloudProPresenterScreen.Parser);

	private readonly RepeatedField<CloudProPresenterScreen> cloudOutputScreens_ = new RepeatedField<CloudProPresenterScreen>();

	public const int CloudVideoInputsFieldNumber = 14;

	private static readonly FieldCodec<CloudVideoInput> _repeated_cloudVideoInputs_codec = FieldCodec.ForMessage(114u, CloudVideoInput.Parser);

	private readonly RepeatedField<CloudVideoInput> cloudVideoInputs_ = new RepeatedField<CloudVideoInput>();

	public const int CloudAudioInputsFieldNumber = 15;

	private static readonly FieldCodec<CloudAudioInput> _repeated_cloudAudioInputs_codec = FieldCodec.ForMessage(122u, CloudAudioInput.Parser);

	private readonly RepeatedField<CloudAudioInput> cloudAudioInputs_ = new RepeatedField<CloudAudioInput>();

	public const int AudioChannelCountFieldNumber = 16;

	private uint audioChannelCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProPresenterWorkspace> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProworkspaceReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<ProPresenterScreen> ProScreens => proScreens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<ProAudienceLook> AudienceLooks => audienceLooks_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProAudienceLook LiveAudienceLook
	{
		get
		{
			return liveAudienceLook_;
		}
		set
		{
			liveAudienceLook_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<ProMask> Masks => masks_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<VideoInput> VideoInputs => videoInputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Stage.Types.ScreenAssignment> StageLayoutMappings => stageLayoutMappings_;

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Audio.Types.SettingsDocument AudioSettings
	{
		get
		{
			return audioSettings_;
		}
		set
		{
			audioSettings_ = value;
		}
	}

	[Obsolete]
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string SelectedLibraryName
	{
		get
		{
			return selectedLibraryName_;
		}
		set
		{
			selectedLibraryName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Recording.Types.SettingsDocument RecordSettings
	{
		get
		{
			return recordSettings_;
		}
		set
		{
			recordSettings_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DigitalAudio.Types.Setup DigitalAudioSetup
	{
		get
		{
			return digitalAudioSetup_;
		}
		set
		{
			digitalAudioSetup_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AudioInput> AudioInputs => audioInputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double AudioInputTransitionTime
	{
		get
		{
			return audioInputTransitionTime_;
		}
		set
		{
			audioInputTransitionTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<CloudProPresenterScreen> CloudOutputScreens => cloudOutputScreens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<CloudVideoInput> CloudVideoInputs => cloudVideoInputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<CloudAudioInput> CloudAudioInputs => cloudAudioInputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint AudioChannelCount
	{
		get
		{
			return audioChannelCount_;
		}
		set
		{
			audioChannelCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterWorkspace()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterWorkspace(ProPresenterWorkspace other)
		: this()
	{
		proScreens_ = other.proScreens_.Clone();
		audienceLooks_ = other.audienceLooks_.Clone();
		liveAudienceLook_ = ((other.liveAudienceLook_ != null) ? other.liveAudienceLook_.Clone() : null);
		masks_ = other.masks_.Clone();
		videoInputs_ = other.videoInputs_.Clone();
		stageLayoutMappings_ = other.stageLayoutMappings_.Clone();
		audioSettings_ = ((other.audioSettings_ != null) ? other.audioSettings_.Clone() : null);
		selectedLibraryName_ = other.selectedLibraryName_;
		recordSettings_ = ((other.recordSettings_ != null) ? other.recordSettings_.Clone() : null);
		digitalAudioSetup_ = ((other.digitalAudioSetup_ != null) ? other.digitalAudioSetup_.Clone() : null);
		audioInputs_ = other.audioInputs_.Clone();
		audioInputTransitionTime_ = other.audioInputTransitionTime_;
		cloudOutputScreens_ = other.cloudOutputScreens_.Clone();
		cloudVideoInputs_ = other.cloudVideoInputs_.Clone();
		cloudAudioInputs_ = other.cloudAudioInputs_.Clone();
		audioChannelCount_ = other.audioChannelCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterWorkspace Clone()
	{
		return new ProPresenterWorkspace(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProPresenterWorkspace);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProPresenterWorkspace other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!proScreens_.Equals(other.proScreens_))
		{
			return false;
		}
		if (!audienceLooks_.Equals(other.audienceLooks_))
		{
			return false;
		}
		if (!object.Equals(LiveAudienceLook, other.LiveAudienceLook))
		{
			return false;
		}
		if (!masks_.Equals(other.masks_))
		{
			return false;
		}
		if (!videoInputs_.Equals(other.videoInputs_))
		{
			return false;
		}
		if (!stageLayoutMappings_.Equals(other.stageLayoutMappings_))
		{
			return false;
		}
		if (!object.Equals(AudioSettings, other.AudioSettings))
		{
			return false;
		}
		if (SelectedLibraryName != other.SelectedLibraryName)
		{
			return false;
		}
		if (!object.Equals(RecordSettings, other.RecordSettings))
		{
			return false;
		}
		if (!object.Equals(DigitalAudioSetup, other.DigitalAudioSetup))
		{
			return false;
		}
		if (!audioInputs_.Equals(other.audioInputs_))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AudioInputTransitionTime, other.AudioInputTransitionTime))
		{
			return false;
		}
		if (!cloudOutputScreens_.Equals(other.cloudOutputScreens_))
		{
			return false;
		}
		if (!cloudVideoInputs_.Equals(other.cloudVideoInputs_))
		{
			return false;
		}
		if (!cloudAudioInputs_.Equals(other.cloudAudioInputs_))
		{
			return false;
		}
		if (AudioChannelCount != other.AudioChannelCount)
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
		num ^= proScreens_.GetHashCode();
		num ^= audienceLooks_.GetHashCode();
		if (liveAudienceLook_ != null)
		{
			num ^= LiveAudienceLook.GetHashCode();
		}
		num ^= masks_.GetHashCode();
		num ^= videoInputs_.GetHashCode();
		num ^= stageLayoutMappings_.GetHashCode();
		if (audioSettings_ != null)
		{
			num ^= AudioSettings.GetHashCode();
		}
		if (SelectedLibraryName.Length != 0)
		{
			num ^= SelectedLibraryName.GetHashCode();
		}
		if (recordSettings_ != null)
		{
			num ^= RecordSettings.GetHashCode();
		}
		if (digitalAudioSetup_ != null)
		{
			num ^= DigitalAudioSetup.GetHashCode();
		}
		num ^= audioInputs_.GetHashCode();
		if (AudioInputTransitionTime != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AudioInputTransitionTime);
		}
		num ^= cloudOutputScreens_.GetHashCode();
		num ^= cloudVideoInputs_.GetHashCode();
		num ^= cloudAudioInputs_.GetHashCode();
		if (AudioChannelCount != 0)
		{
			num ^= AudioChannelCount.GetHashCode();
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
		proScreens_.WriteTo(output, _repeated_proScreens_codec);
		audienceLooks_.WriteTo(output, _repeated_audienceLooks_codec);
		if (liveAudienceLook_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(LiveAudienceLook);
		}
		masks_.WriteTo(output, _repeated_masks_codec);
		videoInputs_.WriteTo(output, _repeated_videoInputs_codec);
		stageLayoutMappings_.WriteTo(output, _repeated_stageLayoutMappings_codec);
		if (audioSettings_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(AudioSettings);
		}
		if (SelectedLibraryName.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(SelectedLibraryName);
		}
		if (recordSettings_ != null)
		{
			output.WriteRawTag(74);
			output.WriteMessage(RecordSettings);
		}
		if (digitalAudioSetup_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(DigitalAudioSetup);
		}
		audioInputs_.WriteTo(output, _repeated_audioInputs_codec);
		if (AudioInputTransitionTime != 0.0)
		{
			output.WriteRawTag(97);
			output.WriteDouble(AudioInputTransitionTime);
		}
		cloudOutputScreens_.WriteTo(output, _repeated_cloudOutputScreens_codec);
		cloudVideoInputs_.WriteTo(output, _repeated_cloudVideoInputs_codec);
		cloudAudioInputs_.WriteTo(output, _repeated_cloudAudioInputs_codec);
		if (AudioChannelCount != 0)
		{
			output.WriteRawTag(128, 1);
			output.WriteUInt32(AudioChannelCount);
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
		num += proScreens_.CalculateSize(_repeated_proScreens_codec);
		num += audienceLooks_.CalculateSize(_repeated_audienceLooks_codec);
		if (liveAudienceLook_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LiveAudienceLook);
		}
		num += masks_.CalculateSize(_repeated_masks_codec);
		num += videoInputs_.CalculateSize(_repeated_videoInputs_codec);
		num += stageLayoutMappings_.CalculateSize(_repeated_stageLayoutMappings_codec);
		if (audioSettings_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioSettings);
		}
		if (SelectedLibraryName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(SelectedLibraryName);
		}
		if (recordSettings_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RecordSettings);
		}
		if (digitalAudioSetup_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DigitalAudioSetup);
		}
		num += audioInputs_.CalculateSize(_repeated_audioInputs_codec);
		if (AudioInputTransitionTime != 0.0)
		{
			num += 9;
		}
		num += cloudOutputScreens_.CalculateSize(_repeated_cloudOutputScreens_codec);
		num += cloudVideoInputs_.CalculateSize(_repeated_cloudVideoInputs_codec);
		num += cloudAudioInputs_.CalculateSize(_repeated_cloudAudioInputs_codec);
		if (AudioChannelCount != 0)
		{
			num += 2 + CodedOutputStream.ComputeUInt32Size(AudioChannelCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProPresenterWorkspace other)
	{
		if (other == null)
		{
			return;
		}
		proScreens_.Add(other.proScreens_);
		audienceLooks_.Add(other.audienceLooks_);
		if (other.liveAudienceLook_ != null)
		{
			if (liveAudienceLook_ == null)
			{
				LiveAudienceLook = new ProAudienceLook();
			}
			LiveAudienceLook.MergeFrom(other.LiveAudienceLook);
		}
		masks_.Add(other.masks_);
		videoInputs_.Add(other.videoInputs_);
		stageLayoutMappings_.Add(other.stageLayoutMappings_);
		if (other.audioSettings_ != null)
		{
			if (audioSettings_ == null)
			{
				AudioSettings = new Audio.Types.SettingsDocument();
			}
			AudioSettings.MergeFrom(other.AudioSettings);
		}
		if (other.SelectedLibraryName.Length != 0)
		{
			SelectedLibraryName = other.SelectedLibraryName;
		}
		if (other.recordSettings_ != null)
		{
			if (recordSettings_ == null)
			{
				RecordSettings = new Recording.Types.SettingsDocument();
			}
			RecordSettings.MergeFrom(other.RecordSettings);
		}
		if (other.digitalAudioSetup_ != null)
		{
			if (digitalAudioSetup_ == null)
			{
				DigitalAudioSetup = new DigitalAudio.Types.Setup();
			}
			DigitalAudioSetup.MergeFrom(other.DigitalAudioSetup);
		}
		audioInputs_.Add(other.audioInputs_);
		if (other.AudioInputTransitionTime != 0.0)
		{
			AudioInputTransitionTime = other.AudioInputTransitionTime;
		}
		cloudOutputScreens_.Add(other.cloudOutputScreens_);
		cloudVideoInputs_.Add(other.cloudVideoInputs_);
		cloudAudioInputs_.Add(other.cloudAudioInputs_);
		if (other.AudioChannelCount != 0)
		{
			AudioChannelCount = other.AudioChannelCount;
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
				proScreens_.AddEntriesFrom(input, _repeated_proScreens_codec);
				break;
			case 18u:
				audienceLooks_.AddEntriesFrom(input, _repeated_audienceLooks_codec);
				break;
			case 26u:
				if (liveAudienceLook_ == null)
				{
					LiveAudienceLook = new ProAudienceLook();
				}
				input.ReadMessage(LiveAudienceLook);
				break;
			case 34u:
				masks_.AddEntriesFrom(input, _repeated_masks_codec);
				break;
			case 42u:
				videoInputs_.AddEntriesFrom(input, _repeated_videoInputs_codec);
				break;
			case 50u:
				stageLayoutMappings_.AddEntriesFrom(input, _repeated_stageLayoutMappings_codec);
				break;
			case 58u:
				if (audioSettings_ == null)
				{
					AudioSettings = new Audio.Types.SettingsDocument();
				}
				input.ReadMessage(AudioSettings);
				break;
			case 66u:
				SelectedLibraryName = input.ReadString();
				break;
			case 74u:
				if (recordSettings_ == null)
				{
					RecordSettings = new Recording.Types.SettingsDocument();
				}
				input.ReadMessage(RecordSettings);
				break;
			case 82u:
				if (digitalAudioSetup_ == null)
				{
					DigitalAudioSetup = new DigitalAudio.Types.Setup();
				}
				input.ReadMessage(DigitalAudioSetup);
				break;
			case 90u:
				audioInputs_.AddEntriesFrom(input, _repeated_audioInputs_codec);
				break;
			case 97u:
				AudioInputTransitionTime = input.ReadDouble();
				break;
			case 106u:
				cloudOutputScreens_.AddEntriesFrom(input, _repeated_cloudOutputScreens_codec);
				break;
			case 114u:
				cloudVideoInputs_.AddEntriesFrom(input, _repeated_cloudVideoInputs_codec);
				break;
			case 122u:
				cloudAudioInputs_.AddEntriesFrom(input, _repeated_cloudAudioInputs_codec);
				break;
			case 128u:
				AudioChannelCount = input.ReadUInt32();
				break;
			}
		}
	}
}
