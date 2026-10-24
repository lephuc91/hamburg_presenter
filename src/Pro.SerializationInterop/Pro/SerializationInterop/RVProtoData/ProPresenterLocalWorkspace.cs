using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProPresenterLocalWorkspace : IMessage<ProPresenterLocalWorkspace>, IMessage, IEquatable<ProPresenterLocalWorkspace>, IDeepCloneable<ProPresenterLocalWorkspace>
{
	private static readonly MessageParser<ProPresenterLocalWorkspace> _parser = new MessageParser<ProPresenterLocalWorkspace>(() => new ProPresenterLocalWorkspace());

	private UnknownFieldSet _unknownFields;

	public const int DigitalAudioSetupFieldNumber = 1;

	private DigitalAudio.Types.Setup digitalAudioSetup_;

	public const int ProScreensFieldNumber = 2;

	private static readonly FieldCodec<ProPresenterScreen> _repeated_proScreens_codec = FieldCodec.ForMessage(18u, ProPresenterScreen.Parser);

	private readonly RepeatedField<ProPresenterScreen> proScreens_ = new RepeatedField<ProPresenterScreen>();

	public const int VideoInputsFieldNumber = 3;

	private static readonly FieldCodec<VideoInput> _repeated_videoInputs_codec = FieldCodec.ForMessage(26u, VideoInput.Parser);

	private readonly RepeatedField<VideoInput> videoInputs_ = new RepeatedField<VideoInput>();

	public const int AudioInputsFieldNumber = 4;

	private static readonly FieldCodec<AudioInput> _repeated_audioInputs_codec = FieldCodec.ForMessage(34u, AudioInput.Parser);

	private readonly RepeatedField<AudioInput> audioInputs_ = new RepeatedField<AudioInput>();

	public const int LiveAudienceLookFieldNumber = 5;

	private ProAudienceLook liveAudienceLook_;

	public const int StageLayoutMappingsFieldNumber = 6;

	private static readonly FieldCodec<Stage.Types.ScreenAssignment> _repeated_stageLayoutMappings_codec = FieldCodec.ForMessage(50u, Stage.Types.ScreenAssignment.Parser);

	private readonly RepeatedField<Stage.Types.ScreenAssignment> stageLayoutMappings_ = new RepeatedField<Stage.Types.ScreenAssignment>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProPresenterLocalWorkspace> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProworkspaceReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public RepeatedField<ProPresenterScreen> ProScreens => proScreens_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<VideoInput> VideoInputs => videoInputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AudioInput> AudioInputs => audioInputs_;

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
	public RepeatedField<Stage.Types.ScreenAssignment> StageLayoutMappings => stageLayoutMappings_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterLocalWorkspace()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterLocalWorkspace(ProPresenterLocalWorkspace other)
		: this()
	{
		digitalAudioSetup_ = ((other.digitalAudioSetup_ != null) ? other.digitalAudioSetup_.Clone() : null);
		proScreens_ = other.proScreens_.Clone();
		videoInputs_ = other.videoInputs_.Clone();
		audioInputs_ = other.audioInputs_.Clone();
		liveAudienceLook_ = ((other.liveAudienceLook_ != null) ? other.liveAudienceLook_.Clone() : null);
		stageLayoutMappings_ = other.stageLayoutMappings_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterLocalWorkspace Clone()
	{
		return new ProPresenterLocalWorkspace(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProPresenterLocalWorkspace);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProPresenterLocalWorkspace other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(DigitalAudioSetup, other.DigitalAudioSetup))
		{
			return false;
		}
		if (!proScreens_.Equals(other.proScreens_))
		{
			return false;
		}
		if (!videoInputs_.Equals(other.videoInputs_))
		{
			return false;
		}
		if (!audioInputs_.Equals(other.audioInputs_))
		{
			return false;
		}
		if (!object.Equals(LiveAudienceLook, other.LiveAudienceLook))
		{
			return false;
		}
		if (!stageLayoutMappings_.Equals(other.stageLayoutMappings_))
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
		if (digitalAudioSetup_ != null)
		{
			num ^= DigitalAudioSetup.GetHashCode();
		}
		num ^= proScreens_.GetHashCode();
		num ^= videoInputs_.GetHashCode();
		num ^= audioInputs_.GetHashCode();
		if (liveAudienceLook_ != null)
		{
			num ^= LiveAudienceLook.GetHashCode();
		}
		num ^= stageLayoutMappings_.GetHashCode();
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
		if (digitalAudioSetup_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(DigitalAudioSetup);
		}
		proScreens_.WriteTo(output, _repeated_proScreens_codec);
		videoInputs_.WriteTo(output, _repeated_videoInputs_codec);
		audioInputs_.WriteTo(output, _repeated_audioInputs_codec);
		if (liveAudienceLook_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(LiveAudienceLook);
		}
		stageLayoutMappings_.WriteTo(output, _repeated_stageLayoutMappings_codec);
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
		if (digitalAudioSetup_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DigitalAudioSetup);
		}
		num += proScreens_.CalculateSize(_repeated_proScreens_codec);
		num += videoInputs_.CalculateSize(_repeated_videoInputs_codec);
		num += audioInputs_.CalculateSize(_repeated_audioInputs_codec);
		if (liveAudienceLook_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LiveAudienceLook);
		}
		num += stageLayoutMappings_.CalculateSize(_repeated_stageLayoutMappings_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProPresenterLocalWorkspace other)
	{
		if (other == null)
		{
			return;
		}
		if (other.digitalAudioSetup_ != null)
		{
			if (digitalAudioSetup_ == null)
			{
				DigitalAudioSetup = new DigitalAudio.Types.Setup();
			}
			DigitalAudioSetup.MergeFrom(other.DigitalAudioSetup);
		}
		proScreens_.Add(other.proScreens_);
		videoInputs_.Add(other.videoInputs_);
		audioInputs_.Add(other.audioInputs_);
		if (other.liveAudienceLook_ != null)
		{
			if (liveAudienceLook_ == null)
			{
				LiveAudienceLook = new ProAudienceLook();
			}
			LiveAudienceLook.MergeFrom(other.LiveAudienceLook);
		}
		stageLayoutMappings_.Add(other.stageLayoutMappings_);
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
				if (digitalAudioSetup_ == null)
				{
					DigitalAudioSetup = new DigitalAudio.Types.Setup();
				}
				input.ReadMessage(DigitalAudioSetup);
				break;
			case 18u:
				proScreens_.AddEntriesFrom(input, _repeated_proScreens_codec);
				break;
			case 26u:
				videoInputs_.AddEntriesFrom(input, _repeated_videoInputs_codec);
				break;
			case 34u:
				audioInputs_.AddEntriesFrom(input, _repeated_audioInputs_codec);
				break;
			case 42u:
				if (liveAudienceLook_ == null)
				{
					LiveAudienceLook = new ProAudienceLook();
				}
				input.ReadMessage(LiveAudienceLook);
				break;
			case 50u:
				stageLayoutMappings_.AddEntriesFrom(input, _repeated_stageLayoutMappings_codec);
				break;
			}
		}
	}
}
