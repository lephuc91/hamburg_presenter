using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProScoreboardWorkspace : IMessage<ProScoreboardWorkspace>, IMessage, IEquatable<ProScoreboardWorkspace>, IDeepCloneable<ProScoreboardWorkspace>
{
	private static readonly MessageParser<ProScoreboardWorkspace> _parser = new MessageParser<ProScoreboardWorkspace>(() => new ProScoreboardWorkspace());

	private UnknownFieldSet _unknownFields;

	public const int ProScreensFieldNumber = 1;

	private static readonly FieldCodec<ProPresenterScreen> _repeated_proScreens_codec = FieldCodec.ForMessage(10u, ProPresenterScreen.Parser);

	private readonly RepeatedField<ProPresenterScreen> proScreens_ = new RepeatedField<ProPresenterScreen>();

	public const int VideoInputsFieldNumber = 2;

	private static readonly FieldCodec<VideoInput> _repeated_videoInputs_codec = FieldCodec.ForMessage(18u, VideoInput.Parser);

	private readonly RepeatedField<VideoInput> videoInputs_ = new RepeatedField<VideoInput>();

	public const int RecordSettingsFieldNumber = 3;

	private Recording.Types.SettingsDocument recordSettings_;

	public const int DigitalAudioSetupFieldNumber = 4;

	private DigitalAudio.Types.Setup digitalAudioSetup_;

	public const int AudioInputsFieldNumber = 5;

	private static readonly FieldCodec<AudioInput> _repeated_audioInputs_codec = FieldCodec.ForMessage(42u, AudioInput.Parser);

	private readonly RepeatedField<AudioInput> audioInputs_ = new RepeatedField<AudioInput>();

	public const int AudioInputTransitionTimeFieldNumber = 6;

	private double audioInputTransitionTime_;

	public const int ZonesFieldNumber = 7;

	private static readonly FieldCodec<Zone> _repeated_zones_codec = FieldCodec.ForMessage(58u, Zone.Parser);

	private readonly RepeatedField<Zone> zones_ = new RepeatedField<Zone>();

	public const int AdvertisementsFieldNumber = 8;

	private static readonly FieldCodec<AdvertisementGroup> _repeated_advertisements_codec = FieldCodec.ForMessage(66u, AdvertisementGroup.Parser);

	private readonly RepeatedField<AdvertisementGroup> advertisements_ = new RepeatedField<AdvertisementGroup>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProScoreboardWorkspace> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PsbWorkspaceReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<ProPresenterScreen> ProScreens => proScreens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<VideoInput> VideoInputs => videoInputs_;

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
	public RepeatedField<Zone> Zones => zones_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdvertisementGroup> Advertisements => advertisements_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProScoreboardWorkspace()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProScoreboardWorkspace(ProScoreboardWorkspace other)
		: this()
	{
		proScreens_ = other.proScreens_.Clone();
		videoInputs_ = other.videoInputs_.Clone();
		recordSettings_ = ((other.recordSettings_ != null) ? other.recordSettings_.Clone() : null);
		digitalAudioSetup_ = ((other.digitalAudioSetup_ != null) ? other.digitalAudioSetup_.Clone() : null);
		audioInputs_ = other.audioInputs_.Clone();
		audioInputTransitionTime_ = other.audioInputTransitionTime_;
		zones_ = other.zones_.Clone();
		advertisements_ = other.advertisements_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProScoreboardWorkspace Clone()
	{
		return new ProScoreboardWorkspace(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProScoreboardWorkspace);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProScoreboardWorkspace other)
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
		if (!videoInputs_.Equals(other.videoInputs_))
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
		if (!zones_.Equals(other.zones_))
		{
			return false;
		}
		if (!advertisements_.Equals(other.advertisements_))
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
		num ^= videoInputs_.GetHashCode();
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
		num ^= zones_.GetHashCode();
		num ^= advertisements_.GetHashCode();
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
		videoInputs_.WriteTo(output, _repeated_videoInputs_codec);
		if (recordSettings_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(RecordSettings);
		}
		if (digitalAudioSetup_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DigitalAudioSetup);
		}
		audioInputs_.WriteTo(output, _repeated_audioInputs_codec);
		if (AudioInputTransitionTime != 0.0)
		{
			output.WriteRawTag(49);
			output.WriteDouble(AudioInputTransitionTime);
		}
		zones_.WriteTo(output, _repeated_zones_codec);
		advertisements_.WriteTo(output, _repeated_advertisements_codec);
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
		num += videoInputs_.CalculateSize(_repeated_videoInputs_codec);
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
		num += zones_.CalculateSize(_repeated_zones_codec);
		num += advertisements_.CalculateSize(_repeated_advertisements_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProScoreboardWorkspace other)
	{
		if (other == null)
		{
			return;
		}
		proScreens_.Add(other.proScreens_);
		videoInputs_.Add(other.videoInputs_);
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
		zones_.Add(other.zones_);
		advertisements_.Add(other.advertisements_);
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
				videoInputs_.AddEntriesFrom(input, _repeated_videoInputs_codec);
				break;
			case 26u:
				if (recordSettings_ == null)
				{
					RecordSettings = new Recording.Types.SettingsDocument();
				}
				input.ReadMessage(RecordSettings);
				break;
			case 34u:
				if (digitalAudioSetup_ == null)
				{
					DigitalAudioSetup = new DigitalAudio.Types.Setup();
				}
				input.ReadMessage(DigitalAudioSetup);
				break;
			case 42u:
				audioInputs_.AddEntriesFrom(input, _repeated_audioInputs_codec);
				break;
			case 49u:
				AudioInputTransitionTime = input.ReadDouble();
				break;
			case 58u:
				zones_.AddEntriesFrom(input, _repeated_zones_codec);
				break;
			case 66u:
				advertisements_.AddEntriesFrom(input, _repeated_advertisements_codec);
				break;
			}
		}
	}
}
