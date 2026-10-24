using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProPresenterCommunications : IMessage<ProPresenterCommunications>, IMessage, IEquatable<ProPresenterCommunications>, IDeepCloneable<ProPresenterCommunications>
{
	private static readonly MessageParser<ProPresenterCommunications> _parser = new MessageParser<ProPresenterCommunications>(() => new ProPresenterCommunications());

	private UnknownFieldSet _unknownFields;

	public const int DevicesFieldNumber = 1;

	private static readonly FieldCodec<CommunicationDeviceCloud> _repeated_devices_codec = FieldCodec.ForMessage(10u, CommunicationDeviceCloud.Parser);

	private readonly RepeatedField<CommunicationDeviceCloud> devices_ = new RepeatedField<CommunicationDeviceCloud>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProPresenterCommunications> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CommunicationsReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<CommunicationDeviceCloud> Devices => devices_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterCommunications()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterCommunications(ProPresenterCommunications other)
		: this()
	{
		devices_ = other.devices_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterCommunications Clone()
	{
		return new ProPresenterCommunications(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProPresenterCommunications);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProPresenterCommunications other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!devices_.Equals(other.devices_))
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
		num ^= devices_.GetHashCode();
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
		devices_.WriteTo(output, _repeated_devices_codec);
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
		num += devices_.CalculateSize(_repeated_devices_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProPresenterCommunications other)
	{
		if (other != null)
		{
			devices_.Add(other.devices_);
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
				devices_.AddEntriesFrom(input, _repeated_devices_codec);
			}
		}
	}
}
