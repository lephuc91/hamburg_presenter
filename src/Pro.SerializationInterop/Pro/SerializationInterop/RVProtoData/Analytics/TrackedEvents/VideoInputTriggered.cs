using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class VideoInputTriggered : IMessage<VideoInputTriggered>, IMessage, IEquatable<VideoInputTriggered>, IDeepCloneable<VideoInputTriggered>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum AudioSource
		{
			[OriginalName("NONE")]
			None,
			[OriginalName("SELF")]
			Self,
			[OriginalName("OTHER")]
			Other
		}
	}

	private static readonly MessageParser<VideoInputTriggered> _parser = new MessageParser<VideoInputTriggered>(() => new VideoInputTriggered());

	private UnknownFieldSet _unknownFields;

	public const int AudioSourceFieldNumber = 1;

	private Types.AudioSource audioSource_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<VideoInputTriggered> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AudioSource AudioSource
	{
		get
		{
			return audioSource_;
		}
		set
		{
			audioSource_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputTriggered()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputTriggered(VideoInputTriggered other)
		: this()
	{
		audioSource_ = other.audioSource_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VideoInputTriggered Clone()
	{
		return new VideoInputTriggered(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as VideoInputTriggered);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(VideoInputTriggered other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (AudioSource != other.AudioSource)
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
		if (AudioSource != 0)
		{
			num ^= AudioSource.GetHashCode();
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
		if (AudioSource != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)AudioSource);
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
		if (AudioSource != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)AudioSource);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(VideoInputTriggered other)
	{
		if (other != null)
		{
			if (other.AudioSource != 0)
			{
				AudioSource = other.AudioSource;
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
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				AudioSource = (Types.AudioSource)input.ReadEnum();
			}
		}
	}
}
