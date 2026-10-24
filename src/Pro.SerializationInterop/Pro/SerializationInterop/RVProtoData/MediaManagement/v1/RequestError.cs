using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RequestError : IMessage<RequestError>, IMessage, IEquatable<RequestError>, IDeepCloneable<RequestError>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ErrorCode
		{
			[OriginalName("UNKNOWN")]
			Unknown = 0,
			[OriginalName("CANT_CREATE_MEDIA_FOLDER")]
			CantCreateMediaFolder = 201,
			[OriginalName("CANT_CREATE_META_FOLDER")]
			CantCreateMetaFolder = 202,
			[OriginalName("CANT_CREATE_THUMBNAILS_FOLDER")]
			CantCreateThumbnailsFolder = 203,
			[OriginalName("CANT_DELETE_ACTIVE_WORKSPACE")]
			CantDeleteActiveWorkspace = 204,
			[OriginalName("SERVICE_INTERNAL_ERROR")]
			ServiceInternalError = 300,
			[OriginalName("SERVICE_HANDSHAKE_ERROR")]
			ServiceHandshakeError = 301,
			[OriginalName("SERVICE_VERSION_MISMATCH")]
			ServiceVersionMismatch = 302,
			[OriginalName("SERVICE_CANT_SEND_REQUEST")]
			ServiceCantSendRequest = 303,
			[OriginalName("SERVICE_MISSING_RESPONSE")]
			ServiceMissingResponse = 304,
			[OriginalName("BAD_REQUEST")]
			BadRequest = 400,
			[OriginalName("INVALID_UUID")]
			InvalidUuid = 401,
			[OriginalName("INVALID_REQUEST")]
			InvalidRequest = 402,
			[OriginalName("NOT_FOUND")]
			NotFound = 404,
			[OriginalName("CONFLICT")]
			Conflict = 409,
			[OriginalName("INTERNAL_ERROR")]
			InternalError = 500,
			[OriginalName("NOT_IMPLEMENTED")]
			NotImplemented = 501,
			[OriginalName("GENERATOR_ERROR")]
			GeneratorError = 502
		}
	}

	private static readonly MessageParser<RequestError> _parser = new MessageParser<RequestError>(() => new RequestError());

	private UnknownFieldSet _unknownFields;

	public const int CodeFieldNumber = 1;

	private Types.ErrorCode code_;

	public const int DescriptionFieldNumber = 2;

	private string description_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RequestError> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ErrorCode Code
	{
		get
		{
			return code_;
		}
		set
		{
			code_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Description
	{
		get
		{
			return description_;
		}
		set
		{
			description_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestError()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestError(RequestError other)
		: this()
	{
		code_ = other.code_;
		description_ = other.description_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestError Clone()
	{
		return new RequestError(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RequestError);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RequestError other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Code != other.Code)
		{
			return false;
		}
		if (Description != other.Description)
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
		if (Code != 0)
		{
			num ^= Code.GetHashCode();
		}
		if (Description.Length != 0)
		{
			num ^= Description.GetHashCode();
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
		if (Code != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Code);
		}
		if (Description.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Description);
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
		if (Code != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Code);
		}
		if (Description.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Description);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RequestError other)
	{
		if (other != null)
		{
			if (other.Code != 0)
			{
				Code = other.Code;
			}
			if (other.Description.Length != 0)
			{
				Description = other.Description;
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
				Code = (Types.ErrorCode)input.ReadEnum();
				break;
			case 18u:
				Description = input.ReadString();
				break;
			}
		}
	}
}
