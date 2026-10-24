using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Helper.Workspace.V2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ServerMessage : IMessage<ServerMessage>, IMessage, IEquatable<ServerMessage>, IDeepCloneable<ServerMessage>
{
	public enum PayloadOneofCase
	{
		None,
		Response,
		Notification
	}

	private static readonly MessageParser<ServerMessage> _parser = new MessageParser<ServerMessage>(() => new ServerMessage());

	private UnknownFieldSet _unknownFields;

	public const int ResponseFieldNumber = 1;

	public const int NotificationFieldNumber = 2;

	private object payload_;

	private PayloadOneofCase payloadCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ServerMessage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperWorkspaceReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseEnvelope Response
	{
		get
		{
			if (payloadCase_ != PayloadOneofCase.Response)
			{
				return null;
			}
			return (ResponseEnvelope)payload_;
		}
		set
		{
			payload_ = value;
			payloadCase_ = ((value != null) ? PayloadOneofCase.Response : PayloadOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification Notification
	{
		get
		{
			if (payloadCase_ != PayloadOneofCase.Notification)
			{
				return null;
			}
			return (Notification)payload_;
		}
		set
		{
			payload_ = value;
			payloadCase_ = ((value != null) ? PayloadOneofCase.Notification : PayloadOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PayloadOneofCase PayloadCase => payloadCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ServerMessage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ServerMessage(ServerMessage other)
		: this()
	{
		switch (other.PayloadCase)
		{
		case PayloadOneofCase.Response:
			Response = other.Response.Clone();
			break;
		case PayloadOneofCase.Notification:
			Notification = other.Notification.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ServerMessage Clone()
	{
		return new ServerMessage(this);
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
		return Equals(other as ServerMessage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ServerMessage other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Response, other.Response))
		{
			return false;
		}
		if (!object.Equals(Notification, other.Notification))
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
		if (payloadCase_ == PayloadOneofCase.Response)
		{
			num ^= Response.GetHashCode();
		}
		if (payloadCase_ == PayloadOneofCase.Notification)
		{
			num ^= Notification.GetHashCode();
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
		if (payloadCase_ == PayloadOneofCase.Response)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Response);
		}
		if (payloadCase_ == PayloadOneofCase.Notification)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Notification);
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
		if (payloadCase_ == PayloadOneofCase.Response)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Response);
		}
		if (payloadCase_ == PayloadOneofCase.Notification)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Notification);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ServerMessage other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.PayloadCase)
		{
		case PayloadOneofCase.Response:
			if (Response == null)
			{
				Response = new ResponseEnvelope();
			}
			Response.MergeFrom(other.Response);
			break;
		case PayloadOneofCase.Notification:
			if (Notification == null)
			{
				Notification = new Notification();
			}
			Notification.MergeFrom(other.Notification);
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
				ResponseEnvelope responseEnvelope = new ResponseEnvelope();
				if (payloadCase_ == PayloadOneofCase.Response)
				{
					responseEnvelope.MergeFrom(Response);
				}
				input.ReadMessage(responseEnvelope);
				Response = responseEnvelope;
				break;
			}
			case 18u:
			{
				Notification notification = new Notification();
				if (payloadCase_ == PayloadOneofCase.Notification)
				{
					notification.MergeFrom(Notification);
				}
				input.ReadMessage(notification);
				Notification = notification;
				break;
			}
			}
		}
	}
}
