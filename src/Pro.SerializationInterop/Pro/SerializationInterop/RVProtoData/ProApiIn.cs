using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProApiIn : IMessage<ProApiIn>, IMessage, IEquatable<ProApiIn>, IDeepCloneable<ProApiIn>
{
	public enum MessageTypeOneofCase
	{
		None,
		HandlerIn,
		NetworkApi,
		NetworkApiV1
	}

	private static readonly MessageParser<ProApiIn> _parser = new MessageParser<ProApiIn>(() => new ProApiIn());

	private UnknownFieldSet _unknownFields;

	public const int HandlerInFieldNumber = 1;

	public const int NetworkApiFieldNumber = 2;

	public const int NetworkApiV1FieldNumber = 3;

	private object messageType_;

	private MessageTypeOneofCase messageTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProApiIn> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLink.Types.HandlerIn HandlerIn
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.HandlerIn)
			{
				return null;
			}
			return (ProLink.Types.HandlerIn)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.HandlerIn : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI NetworkApi
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.NetworkApi)
			{
				return null;
			}
			return (NetworkAPI)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.NetworkApi : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI_v1 NetworkApiV1
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.NetworkApiV1)
			{
				return null;
			}
			return (NetworkAPI_v1)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.NetworkApiV1 : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageTypeOneofCase MessageTypeCase => messageTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiIn()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiIn(ProApiIn other)
		: this()
	{
		switch (other.MessageTypeCase)
		{
		case MessageTypeOneofCase.HandlerIn:
			HandlerIn = other.HandlerIn.Clone();
			break;
		case MessageTypeOneofCase.NetworkApi:
			NetworkApi = other.NetworkApi.Clone();
			break;
		case MessageTypeOneofCase.NetworkApiV1:
			NetworkApiV1 = other.NetworkApiV1.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiIn Clone()
	{
		return new ProApiIn(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearMessageType()
	{
		messageTypeCase_ = MessageTypeOneofCase.None;
		messageType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProApiIn);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProApiIn other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(HandlerIn, other.HandlerIn))
		{
			return false;
		}
		if (!object.Equals(NetworkApi, other.NetworkApi))
		{
			return false;
		}
		if (!object.Equals(NetworkApiV1, other.NetworkApiV1))
		{
			return false;
		}
		if (MessageTypeCase != other.MessageTypeCase)
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
		if (messageTypeCase_ == MessageTypeOneofCase.HandlerIn)
		{
			num ^= HandlerIn.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApi)
		{
			num ^= NetworkApi.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApiV1)
		{
			num ^= NetworkApiV1.GetHashCode();
		}
		num ^= (int)messageTypeCase_;
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
		if (messageTypeCase_ == MessageTypeOneofCase.HandlerIn)
		{
			output.WriteRawTag(10);
			output.WriteMessage(HandlerIn);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApi)
		{
			output.WriteRawTag(18);
			output.WriteMessage(NetworkApi);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApiV1)
		{
			output.WriteRawTag(26);
			output.WriteMessage(NetworkApiV1);
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
		if (messageTypeCase_ == MessageTypeOneofCase.HandlerIn)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HandlerIn);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApi)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(NetworkApi);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApiV1)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(NetworkApiV1);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProApiIn other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.MessageTypeCase)
		{
		case MessageTypeOneofCase.HandlerIn:
			if (HandlerIn == null)
			{
				HandlerIn = new ProLink.Types.HandlerIn();
			}
			HandlerIn.MergeFrom(other.HandlerIn);
			break;
		case MessageTypeOneofCase.NetworkApi:
			if (NetworkApi == null)
			{
				NetworkApi = new NetworkAPI();
			}
			NetworkApi.MergeFrom(other.NetworkApi);
			break;
		case MessageTypeOneofCase.NetworkApiV1:
			if (NetworkApiV1 == null)
			{
				NetworkApiV1 = new NetworkAPI_v1();
			}
			NetworkApiV1.MergeFrom(other.NetworkApiV1);
			break;
		}
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
			{
				ProLink.Types.HandlerIn handlerIn = new ProLink.Types.HandlerIn();
				if (messageTypeCase_ == MessageTypeOneofCase.HandlerIn)
				{
					handlerIn.MergeFrom(HandlerIn);
				}
				input.ReadMessage(handlerIn);
				HandlerIn = handlerIn;
				break;
			}
			case 18u:
			{
				NetworkAPI networkAPI = new NetworkAPI();
				if (messageTypeCase_ == MessageTypeOneofCase.NetworkApi)
				{
					networkAPI.MergeFrom(NetworkApi);
				}
				input.ReadMessage(networkAPI);
				NetworkApi = networkAPI;
				break;
			}
			case 26u:
			{
				NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
				if (messageTypeCase_ == MessageTypeOneofCase.NetworkApiV1)
				{
					networkAPI_v.MergeFrom(NetworkApiV1);
				}
				input.ReadMessage(networkAPI_v);
				NetworkApiV1 = networkAPI_v;
				break;
			}
			}
		}
	}
}
