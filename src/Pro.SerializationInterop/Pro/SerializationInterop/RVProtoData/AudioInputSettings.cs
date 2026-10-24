using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AudioInputSettings : IMessage<AudioInputSettings>, IMessage, IEquatable<AudioInputSettings>, IDeepCloneable<AudioInputSettings>
{
	private static readonly MessageParser<AudioInputSettings> _parser = new MessageParser<AudioInputSettings>(() => new AudioInputSettings());

	private UnknownFieldSet _unknownFields;

	public const int InputsFieldNumber = 1;

	private static readonly FieldCodec<AudioInput> _repeated_inputs_codec = FieldCodec.ForMessage(10u, AudioInput.Parser);

	private readonly RepeatedField<AudioInput> inputs_ = new RepeatedField<AudioInput>();

	public const int TransitionTimeFieldNumber = 2;

	private double transitionTime_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AudioInputSettings> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AudioInput> Inputs => inputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double TransitionTime
	{
		get
		{
			return transitionTime_;
		}
		set
		{
			transitionTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputSettings()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputSettings(AudioInputSettings other)
		: this()
	{
		inputs_ = other.inputs_.Clone();
		transitionTime_ = other.transitionTime_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudioInputSettings Clone()
	{
		return new AudioInputSettings(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AudioInputSettings);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AudioInputSettings other)
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
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(TransitionTime, other.TransitionTime))
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
		if (TransitionTime != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(TransitionTime);
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
		inputs_.WriteTo(output, _repeated_inputs_codec);
		if (TransitionTime != 0.0)
		{
			output.WriteRawTag(17);
			output.WriteDouble(TransitionTime);
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
		num += inputs_.CalculateSize(_repeated_inputs_codec);
		if (TransitionTime != 0.0)
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
	public void MergeFrom(AudioInputSettings other)
	{
		if (other != null)
		{
			inputs_.Add(other.inputs_);
			if (other.TransitionTime != 0.0)
			{
				TransitionTime = other.TransitionTime;
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
			case 10u:
				inputs_.AddEntriesFrom(input, _repeated_inputs_codec);
				break;
			case 17u:
				TransitionTime = input.ReadDouble();
				break;
			}
		}
	}
}
