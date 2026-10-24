using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Helper.Workspace.V2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ClientMessage : IMessage<ClientMessage>, IMessage, IEquatable<ClientMessage>, IDeepCloneable<ClientMessage>
{
	public enum PayloadOneofCase
	{
		None,
		Request
	}

	private static readonly MessageParser<ClientMessage> _parser = new MessageParser<ClientMessage>(() => new ClientMessage());

	private UnknownFieldSet _unknownFields;

	public const int RequestFieldNumber = 1;

	private object payload_;

	private PayloadOneofCase payloadCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ClientMessage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperWorkspaceReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestEnvelope Request
	{
		get
		{
			if (payloadCase_ != PayloadOneofCase.Request)
			{
				return null;
			}
			return (RequestEnvelope)payload_;
		}
		set
		{
			payload_ = value;
			payloadCase_ = ((value != null) ? PayloadOneofCase.Request : PayloadOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PayloadOneofCase PayloadCase => payloadCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClientMessage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClientMessage(ClientMessage other)
		: this()
	{
		if (other.PayloadCase == PayloadOneofCase.Request)
		{
			Request = other.Request.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClientMessage Clone()
	{
		return new ClientMessage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearPayload()
	{
		payloadCase_ = PayloadOneofCase.None;
		payload_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ClientMessage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ClientMessage other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Request, other.Request))
		{
			return false;
		}
		if (PayloadCase != other.PayloadCase)
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
		if (payloadCase_ == PayloadOneofCase.Request)
		{
			num ^= Request.GetHashCode();
		}
		num ^= (int)payloadCase_;
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
		if (payloadCase_ == PayloadOneofCase.Request)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Request);
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
		if (payloadCase_ == PayloadOneofCase.Request)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Request);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ClientMessage other)
	{
		if (other == null)
		{
			return;
		}
		if (other.PayloadCase == PayloadOneofCase.Request)
		{
			if (Request == null)
			{
				Request = new RequestEnvelope();
			}
			Request.MergeFrom(other.Request);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				continue;
			}
			RequestEnvelope requestEnvelope = new RequestEnvelope();
			if (payloadCase_ == PayloadOneofCase.Request)
			{
				requestEnvelope.MergeFrom(Request);
			}
			input.ReadMessage(requestEnvelope);
			Request = requestEnvelope;
		}
	}
}
