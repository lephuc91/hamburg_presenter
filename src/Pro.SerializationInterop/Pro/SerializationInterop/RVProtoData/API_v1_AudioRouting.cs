using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_AudioRouting : IMessage<API_v1_AudioRouting>, IMessage, IEquatable<API_v1_AudioRouting>, IDeepCloneable<API_v1_AudioRouting>
{
	private static readonly MessageParser<API_v1_AudioRouting> _parser = new MessageParser<API_v1_AudioRouting>(() => new API_v1_AudioRouting());

	private UnknownFieldSet _unknownFields;

	public const int MapFieldNumber = 1;

	private static readonly FieldCodec<uint> _repeated_map_codec = FieldCodec.ForUInt32(10u);

	private readonly RepeatedField<uint> map_ = new RepeatedField<uint>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_AudioRouting> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1CaptureReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<uint> Map => map_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_AudioRouting()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_AudioRouting(API_v1_AudioRouting other)
		: this()
	{
		map_ = other.map_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_AudioRouting Clone()
	{
		return new API_v1_AudioRouting(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_AudioRouting);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_AudioRouting other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!map_.Equals(other.map_))
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
		num ^= map_.GetHashCode();
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
		map_.WriteTo(output, _repeated_map_codec);
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
		num += map_.CalculateSize(_repeated_map_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_AudioRouting other)
	{
		if (other != null)
		{
			map_.Add(other.map_);
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
			if (num != 8 && num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				map_.AddEntriesFrom(input, _repeated_map_codec);
			}
		}
	}
}
