using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaGenerator;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ResponseEnvelope : IMessage<ResponseEnvelope>, IMessage, IEquatable<ResponseEnvelope>, IDeepCloneable<ResponseEnvelope>
{
	public enum ResultOneofCase
	{
		None,
		Response,
		Error
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Response : IMessage<Response>, IMessage, IEquatable<Response>, IDeepCloneable<Response>
		{
			private static readonly MessageParser<Response> _parser = new MessageParser<Response>(() => new Response());

			private UnknownFieldSet _unknownFields;

			public const int MetadataFieldNumber = 1;

			private MediaInfo metadata_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Response> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ResponseEnvelope.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaInfo Metadata
			{
				get
				{
					return metadata_;
				}
				set
				{
					metadata_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Response()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Response(Response other)
				: this()
			{
				metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Response Clone()
			{
				return new Response(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Response);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Response other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Metadata, other.Metadata))
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
				if (metadata_ != null)
				{
					num ^= Metadata.GetHashCode();
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
				if (metadata_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Metadata);
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
				if (metadata_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Metadata);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Response other)
			{
				if (other == null)
				{
					return;
				}
				if (other.metadata_ != null)
				{
					if (metadata_ == null)
					{
						Metadata = new MediaInfo();
					}
					Metadata.MergeFrom(other.Metadata);
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
					if (metadata_ == null)
					{
						Metadata = new MediaInfo();
					}
					input.ReadMessage(Metadata);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Error : IMessage<Error>, IMessage, IEquatable<Error>, IDeepCloneable<Error>
		{
			private static readonly MessageParser<Error> _parser = new MessageParser<Error>(() => new Error());

			private UnknownFieldSet _unknownFields;

			public const int MessageFieldNumber = 1;

			private string message_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Error> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ResponseEnvelope.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Message
			{
				get
				{
					return message_;
				}
				set
				{
					message_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error(Error other)
				: this()
			{
				message_ = other.message_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error Clone()
			{
				return new Error(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Error);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Error other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Message != other.Message)
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
				if (Message.Length != 0)
				{
					num ^= Message.GetHashCode();
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
				if (Message.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Message);
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
				if (Message.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Message);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Error other)
			{
				if (other != null)
				{
					if (other.Message.Length != 0)
					{
						Message = other.Message;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Message = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<ResponseEnvelope> _parser = new MessageParser<ResponseEnvelope>(() => new ResponseEnvelope());

	private UnknownFieldSet _unknownFields;

	public const int ResponseFieldNumber = 1;

	public const int ErrorFieldNumber = 2;

	private object result_;

	private ResultOneofCase resultCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ResponseEnvelope> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => HelperSnapshotReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Response Response
	{
		get
		{
			if (resultCase_ != ResultOneofCase.Response)
			{
				return null;
			}
			return (Types.Response)result_;
		}
		set
		{
			result_ = value;
			resultCase_ = ((value != null) ? ResultOneofCase.Response : ResultOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Error Error
	{
		get
		{
			if (resultCase_ != ResultOneofCase.Error)
			{
				return null;
			}
			return (Types.Error)result_;
		}
		set
		{
			result_ = value;
			resultCase_ = ((value != null) ? ResultOneofCase.Error : ResultOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResultOneofCase ResultCase => resultCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseEnvelope()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseEnvelope(ResponseEnvelope other)
		: this()
	{
		switch (other.ResultCase)
		{
		case ResultOneofCase.Response:
			Response = other.Response.Clone();
			break;
		case ResultOneofCase.Error:
			Error = other.Error.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseEnvelope Clone()
	{
		return new ResponseEnvelope(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResult()
	{
		resultCase_ = ResultOneofCase.None;
		result_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ResponseEnvelope);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ResponseEnvelope other)
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
		if (!object.Equals(Error, other.Error))
		{
			return false;
		}
		if (ResultCase != other.ResultCase)
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
		if (resultCase_ == ResultOneofCase.Response)
		{
			num ^= Response.GetHashCode();
		}
		if (resultCase_ == ResultOneofCase.Error)
		{
			num ^= Error.GetHashCode();
		}
		num ^= (int)resultCase_;
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
		if (resultCase_ == ResultOneofCase.Response)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Response);
		}
		if (resultCase_ == ResultOneofCase.Error)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Error);
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
		if (resultCase_ == ResultOneofCase.Response)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Response);
		}
		if (resultCase_ == ResultOneofCase.Error)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Error);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ResponseEnvelope other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResultCase)
		{
		case ResultOneofCase.Response:
			if (Response == null)
			{
				Response = new Types.Response();
			}
			Response.MergeFrom(other.Response);
			break;
		case ResultOneofCase.Error:
			if (Error == null)
			{
				Error = new Types.Error();
			}
			Error.MergeFrom(other.Error);
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
				Types.Response response = new Types.Response();
				if (resultCase_ == ResultOneofCase.Response)
				{
					response.MergeFrom(Response);
				}
				input.ReadMessage(response);
				Response = response;
				break;
			}
			case 18u:
			{
				Types.Error error = new Types.Error();
				if (resultCase_ == ResultOneofCase.Error)
				{
					error.MergeFrom(Error);
				}
				input.ReadMessage(error);
				Error = error;
				break;
			}
			}
		}
	}
}
