using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProPresenterLocalCommunications : IMessage<ProPresenterLocalCommunications>, IMessage, IEquatable<ProPresenterLocalCommunications>, IDeepCloneable<ProPresenterLocalCommunications>
{
	private static readonly MessageParser<ProPresenterLocalCommunications> _parser = new MessageParser<ProPresenterLocalCommunications>(() => new ProPresenterLocalCommunications());

	private UnknownFieldSet _unknownFields;

	public const int DevicesFieldNumber = 1;

	private static readonly FieldCodec<CommunicationDeviceLocal> _repeated_devices_codec = FieldCodec.ForMessage(10u, CommunicationDeviceLocal.Parser);

	private readonly RepeatedField<CommunicationDeviceLocal> devices_ = new RepeatedField<CommunicationDeviceLocal>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProPresenterLocalCommunications> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CommunicationsReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<CommunicationDeviceLocal> Devices => devices_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterLocalCommunications()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterLocalCommunications(ProPresenterLocalCommunications other)
		: this()
	{
		devices_ = other.devices_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProPresenterLocalCommunications Clone()
	{
		return new ProPresenterLocalCommunications(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProPresenterLocalCommunications);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProPresenterLocalCommunications other)
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
	public void MergeFrom(ProPresenterLocalCommunications other)
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
