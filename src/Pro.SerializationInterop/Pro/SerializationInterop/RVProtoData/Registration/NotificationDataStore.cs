using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NotificationDataStore : IMessage<NotificationDataStore>, IMessage, IEquatable<NotificationDataStore>, IDeepCloneable<NotificationDataStore>
{
	private static readonly MessageParser<NotificationDataStore> _parser = new MessageParser<NotificationDataStore>(() => new NotificationDataStore());

	private UnknownFieldSet _unknownFields;

	public const int NotificationsFieldNumber = 1;

	private static readonly FieldCodec<Notification> _repeated_notifications_codec = FieldCodec.ForMessage(10u, Notification.Parser);

	private readonly RepeatedField<Notification> notifications_ = new RepeatedField<Notification>();

	public const int ReadIdsFieldNumber = 2;

	private static readonly FieldCodec<string> _repeated_readIds_codec = FieldCodec.ForString(18u);

	private readonly RepeatedField<string> readIds_ = new RepeatedField<string>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NotificationDataStore> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[61];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Notification> Notifications => notifications_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<string> ReadIds => readIds_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotificationDataStore()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotificationDataStore(NotificationDataStore other)
		: this()
	{
		notifications_ = other.notifications_.Clone();
		readIds_ = other.readIds_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotificationDataStore Clone()
	{
		return new NotificationDataStore(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NotificationDataStore);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NotificationDataStore other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!notifications_.Equals(other.notifications_))
		{
			return false;
		}
		if (!readIds_.Equals(other.readIds_))
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
		num ^= notifications_.GetHashCode();
		num ^= readIds_.GetHashCode();
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
		notifications_.WriteTo(output, _repeated_notifications_codec);
		readIds_.WriteTo(output, _repeated_readIds_codec);
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
		num += notifications_.CalculateSize(_repeated_notifications_codec);
		num += readIds_.CalculateSize(_repeated_readIds_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(NotificationDataStore other)
	{
		if (other != null)
		{
			notifications_.Add(other.notifications_);
			readIds_.Add(other.readIds_);
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
				notifications_.AddEntriesFrom(input, _repeated_notifications_codec);
				break;
			case 18u:
				readIds_.AddEntriesFrom(input, _repeated_readIds_codec);
				break;
			}
		}
	}
}
