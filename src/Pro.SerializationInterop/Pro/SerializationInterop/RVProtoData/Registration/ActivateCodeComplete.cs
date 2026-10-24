using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActivateCodeComplete : IMessage<ActivateCodeComplete>, IMessage, IEquatable<ActivateCodeComplete>, IDeepCloneable<ActivateCodeComplete>
{
	public enum StatusOneofCase
	{
		None,
		Error,
		Success
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Error : IMessage<Error>, IMessage, IEquatable<Error>, IDeepCloneable<Error>
		{
			private static readonly MessageParser<Error> _parser = new MessageParser<Error>(() => new Error());

			private UnknownFieldSet _unknownFields;

			public const int Error_FieldNumber = 1;

			private string error_ = "";

			public const int DescriptionFieldNumber = 2;

			private string description_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Error> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ActivateCodeComplete.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Error_
			{
				get
				{
					return error_;
				}
				set
				{
					error_ = ProtoPreconditions.CheckNotNull(value, "value");
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
			public Error()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error(Error other)
				: this()
			{
				error_ = other.error_;
				description_ = other.description_;
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
				if (Error_ != other.Error_)
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
				if (Error_.Length != 0)
				{
					num ^= Error_.GetHashCode();
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
				if (Error_.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Error_);
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
				if (Error_.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Error_);
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
			public void MergeFrom(Error other)
			{
				if (other != null)
				{
					if (other.Error_.Length != 0)
					{
						Error_ = other.Error_;
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
					case 10u:
						Error_ = input.ReadString();
						break;
					case 18u:
						Description = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Success : IMessage<Success>, IMessage, IEquatable<Success>, IDeepCloneable<Success>
		{
			private static readonly MessageParser<Success> _parser = new MessageParser<Success>(() => new Success());

			private UnknownFieldSet _unknownFields;

			public const int ActivationCodeFieldNumber = 2;

			private string activationCode_ = "";

			public const int ExpirationFieldNumber = 3;

			private long expiration_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Success> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ActivateCodeComplete.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ActivationCode
			{
				get
				{
					return activationCode_;
				}
				set
				{
					activationCode_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public long Expiration
			{
				get
				{
					return expiration_;
				}
				set
				{
					expiration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Success()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Success(Success other)
				: this()
			{
				activationCode_ = other.activationCode_;
				expiration_ = other.expiration_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Success Clone()
			{
				return new Success(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Success);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Success other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ActivationCode != other.ActivationCode)
				{
					return false;
				}
				if (Expiration != other.Expiration)
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
				if (ActivationCode.Length != 0)
				{
					num ^= ActivationCode.GetHashCode();
				}
				if (Expiration != 0L)
				{
					num ^= Expiration.GetHashCode();
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
				if (ActivationCode.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ActivationCode);
				}
				if (Expiration != 0L)
				{
					output.WriteRawTag(24);
					output.WriteInt64(Expiration);
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
				if (ActivationCode.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ActivationCode);
				}
				if (Expiration != 0L)
				{
					num += 1 + CodedOutputStream.ComputeInt64Size(Expiration);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Success other)
			{
				if (other != null)
				{
					if (other.ActivationCode.Length != 0)
					{
						ActivationCode = other.ActivationCode;
					}
					if (other.Expiration != 0L)
					{
						Expiration = other.Expiration;
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
					case 18u:
						ActivationCode = input.ReadString();
						break;
					case 24u:
						Expiration = input.ReadInt64();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<ActivateCodeComplete> _parser = new MessageParser<ActivateCodeComplete>(() => new ActivateCodeComplete());

	private UnknownFieldSet _unknownFields;

	public const int ErrorFieldNumber = 1;

	public const int SuccessFieldNumber = 2;

	private object status_;

	private StatusOneofCase statusCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActivateCodeComplete> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[40];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Error Error
	{
		get
		{
			if (statusCase_ != StatusOneofCase.Error)
			{
				return null;
			}
			return (Types.Error)status_;
		}
		set
		{
			status_ = value;
			statusCase_ = ((value != null) ? StatusOneofCase.Error : StatusOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Success Success
	{
		get
		{
			if (statusCase_ != StatusOneofCase.Success)
			{
				return null;
			}
			return (Types.Success)status_;
		}
		set
		{
			status_ = value;
			statusCase_ = ((value != null) ? StatusOneofCase.Success : StatusOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StatusOneofCase StatusCase => statusCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActivateCodeComplete()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActivateCodeComplete(ActivateCodeComplete other)
		: this()
	{
		switch (other.StatusCase)
		{
		case StatusOneofCase.Error:
			Error = other.Error.Clone();
			break;
		case StatusOneofCase.Success:
			Success = other.Success.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActivateCodeComplete Clone()
	{
		return new ActivateCodeComplete(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearStatus()
	{
		statusCase_ = StatusOneofCase.None;
		status_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActivateCodeComplete);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActivateCodeComplete other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Error, other.Error))
		{
			return false;
		}
		if (!object.Equals(Success, other.Success))
		{
			return false;
		}
		if (StatusCase != other.StatusCase)
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
		if (statusCase_ == StatusOneofCase.Error)
		{
			num ^= Error.GetHashCode();
		}
		if (statusCase_ == StatusOneofCase.Success)
		{
			num ^= Success.GetHashCode();
		}
		num ^= (int)statusCase_;
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
		if (statusCase_ == StatusOneofCase.Error)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Error);
		}
		if (statusCase_ == StatusOneofCase.Success)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Success);
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
		if (statusCase_ == StatusOneofCase.Error)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Error);
		}
		if (statusCase_ == StatusOneofCase.Success)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Success);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActivateCodeComplete other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.StatusCase)
		{
		case StatusOneofCase.Error:
			if (Error == null)
			{
				Error = new Types.Error();
			}
			Error.MergeFrom(other.Error);
			break;
		case StatusOneofCase.Success:
			if (Success == null)
			{
				Success = new Types.Success();
			}
			Success.MergeFrom(other.Success);
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
				Types.Error error = new Types.Error();
				if (statusCase_ == StatusOneofCase.Error)
				{
					error.MergeFrom(Error);
				}
				input.ReadMessage(error);
				Error = error;
				break;
			}
			case 18u:
			{
				Types.Success success = new Types.Success();
				if (statusCase_ == StatusOneofCase.Success)
				{
					success.MergeFrom(Success);
				}
				input.ReadMessage(success);
				Success = success;
				break;
			}
			}
		}
	}
}
