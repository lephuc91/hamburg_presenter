using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_ResiCapture : IMessage<API_v1_ResiCapture>, IMessage, IEquatable<API_v1_ResiCapture>, IDeepCloneable<API_v1_ResiCapture>
{
	private static readonly MessageParser<API_v1_ResiCapture> _parser = new MessageParser<API_v1_ResiCapture>(() => new API_v1_ResiCapture());

	private UnknownFieldSet _unknownFields;

	public const int EventNameFieldNumber = 1;

	private string eventName_ = "";

	public const int EventDescriptionFieldNumber = 2;

	private string eventDescription_ = "";

	public const int DestinationGroupFieldNumber = 3;

	private string destinationGroup_ = "";

	public const int EncodingFieldNumber = 4;

	private string encoding_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_ResiCapture> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1CaptureReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string EventName
	{
		get
		{
			return eventName_;
		}
		set
		{
			eventName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string EventDescription
	{
		get
		{
			return eventDescription_;
		}
		set
		{
			eventDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DestinationGroup
	{
		get
		{
			return destinationGroup_;
		}
		set
		{
			destinationGroup_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Encoding
	{
		get
		{
			return encoding_;
		}
		set
		{
			encoding_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ResiCapture()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ResiCapture(API_v1_ResiCapture other)
		: this()
	{
		eventName_ = other.eventName_;
		eventDescription_ = other.eventDescription_;
		destinationGroup_ = other.destinationGroup_;
		encoding_ = other.encoding_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ResiCapture Clone()
	{
		return new API_v1_ResiCapture(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_ResiCapture);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_ResiCapture other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (EventName != other.EventName)
		{
			return false;
		}
		if (EventDescription != other.EventDescription)
		{
			return false;
		}
		if (DestinationGroup != other.DestinationGroup)
		{
			return false;
		}
		if (Encoding != other.Encoding)
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
		if (EventName.Length != 0)
		{
			num ^= EventName.GetHashCode();
		}
		if (EventDescription.Length != 0)
		{
			num ^= EventDescription.GetHashCode();
		}
		if (DestinationGroup.Length != 0)
		{
			num ^= DestinationGroup.GetHashCode();
		}
		if (Encoding.Length != 0)
		{
			num ^= Encoding.GetHashCode();
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
		if (EventName.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(EventName);
		}
		if (EventDescription.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(EventDescription);
		}
		if (DestinationGroup.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(DestinationGroup);
		}
		if (Encoding.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Encoding);
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
		if (EventName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(EventName);
		}
		if (EventDescription.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(EventDescription);
		}
		if (DestinationGroup.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DestinationGroup);
		}
		if (Encoding.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Encoding);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_ResiCapture other)
	{
		if (other != null)
		{
			if (other.EventName.Length != 0)
			{
				EventName = other.EventName;
			}
			if (other.EventDescription.Length != 0)
			{
				EventDescription = other.EventDescription;
			}
			if (other.DestinationGroup.Length != 0)
			{
				DestinationGroup = other.DestinationGroup;
			}
			if (other.Encoding.Length != 0)
			{
				Encoding = other.Encoding;
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
				EventName = input.ReadString();
				break;
			case 18u:
				EventDescription = input.ReadString();
				break;
			case 26u:
				DestinationGroup = input.ReadString();
				break;
			case 34u:
				Encoding = input.ReadString();
				break;
			}
		}
	}
}
