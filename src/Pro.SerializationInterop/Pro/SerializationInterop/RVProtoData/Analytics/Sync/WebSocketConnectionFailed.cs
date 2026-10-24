using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Sync;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class WebSocketConnectionFailed : IMessage<WebSocketConnectionFailed>, IMessage, IEquatable<WebSocketConnectionFailed>, IDeepCloneable<WebSocketConnectionFailed>
{
	private static readonly MessageParser<WebSocketConnectionFailed> _parser = new MessageParser<WebSocketConnectionFailed>(() => new WebSocketConnectionFailed());

	private UnknownFieldSet _unknownFields;

	public const int ReasonFieldNumber = 1;

	private WebSocketFailureReason reason_;

	public const int UrlFieldNumber = 2;

	private string url_ = "";

	public const int ErrorDescriptionFieldNumber = 3;

	private string errorDescription_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<WebSocketConnectionFailed> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsSyncReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebSocketFailureReason Reason
	{
		get
		{
			return reason_;
		}
		set
		{
			reason_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Url
	{
		get
		{
			return url_;
		}
		set
		{
			url_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ErrorDescription
	{
		get
		{
			return errorDescription_;
		}
		set
		{
			errorDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebSocketConnectionFailed()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebSocketConnectionFailed(WebSocketConnectionFailed other)
		: this()
	{
		reason_ = other.reason_;
		url_ = other.url_;
		errorDescription_ = other.errorDescription_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebSocketConnectionFailed Clone()
	{
		return new WebSocketConnectionFailed(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as WebSocketConnectionFailed);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(WebSocketConnectionFailed other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Reason != other.Reason)
		{
			return false;
		}
		if (Url != other.Url)
		{
			return false;
		}
		if (ErrorDescription != other.ErrorDescription)
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
		if (Reason != 0)
		{
			num ^= Reason.GetHashCode();
		}
		if (Url.Length != 0)
		{
			num ^= Url.GetHashCode();
		}
		if (ErrorDescription.Length != 0)
		{
			num ^= ErrorDescription.GetHashCode();
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
		if (Reason != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Reason);
		}
		if (Url.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Url);
		}
		if (ErrorDescription.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ErrorDescription);
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
		if (Reason != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Reason);
		}
		if (Url.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Url);
		}
		if (ErrorDescription.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ErrorDescription);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(WebSocketConnectionFailed other)
	{
		if (other != null)
		{
			if (other.Reason != 0)
			{
				Reason = other.Reason;
			}
			if (other.Url.Length != 0)
			{
				Url = other.Url;
			}
			if (other.ErrorDescription.Length != 0)
			{
				ErrorDescription = other.ErrorDescription;
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
			case 8u:
				Reason = (WebSocketFailureReason)input.ReadEnum();
				break;
			case 18u:
				Url = input.ReadString();
				break;
			case 26u:
				ErrorDescription = input.ReadString();
				break;
			}
		}
	}
}
