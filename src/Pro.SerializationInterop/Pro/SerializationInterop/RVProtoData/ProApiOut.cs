using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProApiOut : IMessage<ProApiOut>, IMessage, IEquatable<ProApiOut>, IDeepCloneable<ProApiOut>
{
	public enum MessageTypeOneofCase
	{
		None,
		HandlerOut,
		ClientAction,
		NetworkApi,
		NetworkApiV1
	}

	private static readonly MessageParser<ProApiOut> _parser = new MessageParser<ProApiOut>(() => new ProApiOut());

	private UnknownFieldSet _unknownFields;

	public const int HandlerOutFieldNumber = 1;

	public const int ClientActionFieldNumber = 2;

	public const int NetworkApiFieldNumber = 3;

	public const int NetworkApiV1FieldNumber = 4;

	private object messageType_;

	private MessageTypeOneofCase messageTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProApiOut> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLink.Types.HandlerOut HandlerOut
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.HandlerOut)
			{
				return null;
			}
			return (ProLink.Types.HandlerOut)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.HandlerOut : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProLink.Types.ClientAction ClientAction
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.ClientAction)
			{
				return null;
			}
			return (ProLink.Types.ClientAction)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.ClientAction : MessageTypeOneofCase.None);
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
	public ProApiOut()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiOut(ProApiOut other)
		: this()
	{
		switch (other.MessageTypeCase)
		{
		case MessageTypeOneofCase.HandlerOut:
			HandlerOut = other.HandlerOut.Clone();
			break;
		case MessageTypeOneofCase.ClientAction:
			ClientAction = other.ClientAction.Clone();
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
	public ProApiOut Clone()
	{
		return new ProApiOut(this);
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
		return Equals(other as ProApiOut);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProApiOut other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(HandlerOut, other.HandlerOut))
		{
			return false;
		}
		if (!object.Equals(ClientAction, other.ClientAction))
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
		if (messageTypeCase_ == MessageTypeOneofCase.HandlerOut)
		{
			num ^= HandlerOut.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ClientAction)
		{
			num ^= ClientAction.GetHashCode();
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
		if (messageTypeCase_ == MessageTypeOneofCase.HandlerOut)
		{
			output.WriteRawTag(10);
			output.WriteMessage(HandlerOut);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ClientAction)
		{
			output.WriteRawTag(18);
			output.WriteMessage(ClientAction);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApi)
		{
			output.WriteRawTag(26);
			output.WriteMessage(NetworkApi);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.NetworkApiV1)
		{
			output.WriteRawTag(34);
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
		if (messageTypeCase_ == MessageTypeOneofCase.HandlerOut)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HandlerOut);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ClientAction)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ClientAction);
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
	public void MergeFrom(ProApiOut other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.MessageTypeCase)
		{
		case MessageTypeOneofCase.HandlerOut:
			if (HandlerOut == null)
			{
				HandlerOut = new ProLink.Types.HandlerOut();
			}
			HandlerOut.MergeFrom(other.HandlerOut);
			break;
		case MessageTypeOneofCase.ClientAction:
			if (ClientAction == null)
			{
				ClientAction = new ProLink.Types.ClientAction();
			}
			ClientAction.MergeFrom(other.ClientAction);
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
				ProLink.Types.HandlerOut handlerOut = new ProLink.Types.HandlerOut();
				if (messageTypeCase_ == MessageTypeOneofCase.HandlerOut)
				{
					handlerOut.MergeFrom(HandlerOut);
				}
				input.ReadMessage(handlerOut);
				HandlerOut = handlerOut;
				break;
			}
			case 18u:
			{
				ProLink.Types.ClientAction clientAction = new ProLink.Types.ClientAction();
				if (messageTypeCase_ == MessageTypeOneofCase.ClientAction)
				{
					clientAction.MergeFrom(ClientAction);
				}
				input.ReadMessage(clientAction);
				ClientAction = clientAction;
				break;
			}
			case 26u:
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
			case 34u:
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
