using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MessageDocument : IMessage<MessageDocument>, IMessage, IEquatable<MessageDocument>, IDeepCloneable<MessageDocument>
{
	private static readonly MessageParser<MessageDocument> _parser = new MessageParser<MessageDocument>(() => new MessageDocument());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int MessagesFieldNumber = 2;

	private static readonly FieldCodec<Message> _repeated_messages_codec = FieldCodec.ForMessage(18u, Message.Parser);

	private readonly RepeatedField<Message> messages_ = new RepeatedField<Message>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MessageDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => MessagesReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Message> Messages => messages_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageDocument(MessageDocument other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		messages_ = other.messages_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageDocument Clone()
	{
		return new MessageDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MessageDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MessageDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (!messages_.Equals(other.messages_))
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		num ^= messages_.GetHashCode();
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		messages_.WriteTo(output, _repeated_messages_codec);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		num += messages_.CalculateSize(_repeated_messages_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MessageDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		messages_.Add(other.messages_);
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 18u:
				messages_.AddEntriesFrom(input, _repeated_messages_codec);
				break;
			}
		}
	}
}
