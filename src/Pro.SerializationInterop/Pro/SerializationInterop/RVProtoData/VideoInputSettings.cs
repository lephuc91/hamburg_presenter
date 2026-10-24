using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class VideoInputSettings : IMessage<VideoInputSettings>, IMessage, IEquatable<VideoInputSettings>, IDeepCloneable<VideoInputSettings>
{
	private static readonly MessageParser<VideoInputSettings> _parser = new MessageParser<VideoInputSettings>(() => new VideoInputSettings());

	private UnknownFieldSet _unknownFields;

	public const int InputsFieldNumber = 1;

	private static readonly FieldCodec<VideoInput> _repeated_inputs_codec = FieldCodec.ForMessage(10u, VideoInput.Parser);

	private readonly RepeatedField<VideoInput> inputs_ = new RepeatedField<VideoInput>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<VideoInputSettings> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<VideoInput> Inputs => inputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputSettings()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputSettings(VideoInputSettings other)
		: this()
	{
		inputs_ = other.inputs_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputSettings Clone()
	{
		return new VideoInputSettings(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as VideoInputSettings);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(VideoInputSettings other)
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
	public void MergeFrom(VideoInputSettings other)
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
