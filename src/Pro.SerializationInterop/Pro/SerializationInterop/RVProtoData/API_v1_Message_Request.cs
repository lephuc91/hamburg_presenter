using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Message_Request : IMessage<API_v1_Message_Request>, IMessage, IEquatable<API_v1_Message_Request>, IDeepCloneable<API_v1_Message_Request>
{
	public enum RequestOneofCase
	{
		None,
		Messages,
		CreateMessage,
		GetMessage,
		PutMessage,
		DeleteMessage,
		TriggerMessage,
		ClearMessage
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Messages : IMessage<Messages>, IMessage, IEquatable<Messages>, IDeepCloneable<Messages>
		{
			private static readonly MessageParser<Messages> _parser = new MessageParser<Messages>(() => new Messages());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Messages> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Messages()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Messages(Messages other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Messages Clone()
			{
				return new Messages(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Messages);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Messages other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Messages other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CreateMessage : IMessage<CreateMessage>, IMessage, IEquatable<CreateMessage>, IDeepCloneable<CreateMessage>
		{
			private static readonly MessageParser<CreateMessage> _parser = new MessageParser<CreateMessage>(() => new CreateMessage());

			private UnknownFieldSet _unknownFields;

			public const int MessageFieldNumber = 1;

			private API_v1_Message message_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CreateMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Message Message
			{
				get
				{
					return message_;
				}
				set
				{
					message_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateMessage(CreateMessage other)
				: this()
			{
				message_ = ((other.message_ != null) ? other.message_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateMessage Clone()
			{
				return new CreateMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CreateMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CreateMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Message, other.Message))
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
				if (message_ != null)
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
				if (message_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Message);
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
				if (message_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Message);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CreateMessage other)
			{
				if (other == null)
				{
					return;
				}
				if (other.message_ != null)
				{
					if (message_ == null)
					{
						Message = new API_v1_Message();
					}
					Message.MergeFrom(other.Message);
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
					if (message_ == null)
					{
						Message = new API_v1_Message();
					}
					input.ReadMessage(Message);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetMessage : IMessage<GetMessage>, IMessage, IEquatable<GetMessage>, IDeepCloneable<GetMessage>
		{
			private static readonly MessageParser<GetMessage> _parser = new MessageParser<GetMessage>(() => new GetMessage());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMessage(GetMessage other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMessage Clone()
			{
				return new GetMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetMessage other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutMessage : IMessage<PutMessage>, IMessage, IEquatable<PutMessage>, IDeepCloneable<PutMessage>
		{
			private static readonly MessageParser<PutMessage> _parser = new MessageParser<PutMessage>(() => new PutMessage());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int MessageFieldNumber = 2;

			private API_v1_Message message_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Message Message
			{
				get
				{
					return message_;
				}
				set
				{
					message_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMessage(PutMessage other)
				: this()
			{
				id_ = other.id_;
				message_ = ((other.message_ != null) ? other.message_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMessage Clone()
			{
				return new PutMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
				{
					return false;
				}
				if (!object.Equals(Message, other.Message))
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				if (message_ != null)
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (message_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Message);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (message_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Message);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutMessage other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.message_ != null)
				{
					if (message_ == null)
					{
						Message = new API_v1_Message();
					}
					Message.MergeFrom(other.Message);
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
						Id = input.ReadString();
						break;
					case 18u:
						if (message_ == null)
						{
							Message = new API_v1_Message();
						}
						input.ReadMessage(Message);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteMessage : IMessage<DeleteMessage>, IMessage, IEquatable<DeleteMessage>, IDeepCloneable<DeleteMessage>
		{
			private static readonly MessageParser<DeleteMessage> _parser = new MessageParser<DeleteMessage>(() => new DeleteMessage());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteMessage(DeleteMessage other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteMessage Clone()
			{
				return new DeleteMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(DeleteMessage other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TriggerMessage : IMessage<TriggerMessage>, IMessage, IEquatable<TriggerMessage>, IDeepCloneable<TriggerMessage>
		{
			private static readonly MessageParser<TriggerMessage> _parser = new MessageParser<TriggerMessage>(() => new TriggerMessage());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int TokensFieldNumber = 2;

			private static readonly FieldCodec<API_v1_Message.Types.API_v1_MessageToken> _repeated_tokens_codec = FieldCodec.ForMessage(18u, API_v1_Message.Types.API_v1_MessageToken.Parser);

			private readonly RepeatedField<API_v1_Message.Types.API_v1_MessageToken> tokens_ = new RepeatedField<API_v1_Message.Types.API_v1_MessageToken>();

			public const int RequiresConfirmationFieldNumber = 3;

			private bool requiresConfirmation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Message.Types.API_v1_MessageToken> Tokens => tokens_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool RequiresConfirmation
			{
				get
				{
					return requiresConfirmation_;
				}
				set
				{
					requiresConfirmation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage(TriggerMessage other)
				: this()
			{
				id_ = other.id_;
				tokens_ = other.tokens_.Clone();
				requiresConfirmation_ = other.requiresConfirmation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMessage Clone()
			{
				return new TriggerMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
				{
					return false;
				}
				if (!tokens_.Equals(other.tokens_))
				{
					return false;
				}
				if (RequiresConfirmation != other.RequiresConfirmation)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
				num ^= tokens_.GetHashCode();
				if (RequiresConfirmation)
				{
					num ^= RequiresConfirmation.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				tokens_.WriteTo(output, _repeated_tokens_codec);
				if (RequiresConfirmation)
				{
					output.WriteRawTag(24);
					output.WriteBool(RequiresConfirmation);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				num += tokens_.CalculateSize(_repeated_tokens_codec);
				if (RequiresConfirmation)
				{
					num += 2;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TriggerMessage other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					tokens_.Add(other.tokens_);
					if (other.RequiresConfirmation)
					{
						RequiresConfirmation = other.RequiresConfirmation;
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
						Id = input.ReadString();
						break;
					case 18u:
						tokens_.AddEntriesFrom(input, _repeated_tokens_codec);
						break;
					case 24u:
						RequiresConfirmation = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ClearMessage : IMessage<ClearMessage>, IMessage, IEquatable<ClearMessage>, IDeepCloneable<ClearMessage>
		{
			private static readonly MessageParser<ClearMessage> _parser = new MessageParser<ClearMessage>(() => new ClearMessage());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearMessage(ClearMessage other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearMessage Clone()
			{
				return new ClearMessage(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClearMessage);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClearMessage other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ClearMessage other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Message_Request> _parser = new MessageParser<API_v1_Message_Request>(() => new API_v1_Message_Request());

	private UnknownFieldSet _unknownFields;

	public const int MessagesFieldNumber = 1;

	public const int CreateMessageFieldNumber = 2;

	public const int GetMessageFieldNumber = 3;

	public const int PutMessageFieldNumber = 4;

	public const int DeleteMessageFieldNumber = 5;

	public const int TriggerMessageFieldNumber = 6;

	public const int ClearMessageFieldNumber = 7;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Message_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MessageReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Messages Messages
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Messages)
			{
				return null;
			}
			return (Types.Messages)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Messages : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateMessage CreateMessage
	{
		get
		{
			if (requestCase_ != RequestOneofCase.CreateMessage)
			{
				return null;
			}
			return (Types.CreateMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.CreateMessage : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetMessage GetMessage
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetMessage)
			{
				return null;
			}
			return (Types.GetMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetMessage : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMessage PutMessage
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutMessage)
			{
				return null;
			}
			return (Types.PutMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutMessage : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteMessage DeleteMessage
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteMessage)
			{
				return null;
			}
			return (Types.DeleteMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteMessage : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerMessage TriggerMessage
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TriggerMessage)
			{
				return null;
			}
			return (Types.TriggerMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TriggerMessage : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearMessage ClearMessage
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ClearMessage)
			{
				return null;
			}
			return (Types.ClearMessage)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ClearMessage : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message_Request(API_v1_Message_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Messages:
			Messages = other.Messages.Clone();
			break;
		case RequestOneofCase.CreateMessage:
			CreateMessage = other.CreateMessage.Clone();
			break;
		case RequestOneofCase.GetMessage:
			GetMessage = other.GetMessage.Clone();
			break;
		case RequestOneofCase.PutMessage:
			PutMessage = other.PutMessage.Clone();
			break;
		case RequestOneofCase.DeleteMessage:
			DeleteMessage = other.DeleteMessage.Clone();
			break;
		case RequestOneofCase.TriggerMessage:
			TriggerMessage = other.TriggerMessage.Clone();
			break;
		case RequestOneofCase.ClearMessage:
			ClearMessage = other.ClearMessage.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message_Request Clone()
	{
		return new API_v1_Message_Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Message_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Message_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Messages, other.Messages))
		{
			return false;
		}
		if (!object.Equals(CreateMessage, other.CreateMessage))
		{
			return false;
		}
		if (!object.Equals(GetMessage, other.GetMessage))
		{
			return false;
		}
		if (!object.Equals(PutMessage, other.PutMessage))
		{
			return false;
		}
		if (!object.Equals(DeleteMessage, other.DeleteMessage))
		{
			return false;
		}
		if (!object.Equals(TriggerMessage, other.TriggerMessage))
		{
			return false;
		}
		if (!object.Equals(ClearMessage, other.ClearMessage))
		{
			return false;
		}
		if (RequestCase != other.RequestCase)
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
		if (requestCase_ == RequestOneofCase.Messages)
		{
			num ^= Messages.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.CreateMessage)
		{
			num ^= CreateMessage.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetMessage)
		{
			num ^= GetMessage.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutMessage)
		{
			num ^= PutMessage.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteMessage)
		{
			num ^= DeleteMessage.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TriggerMessage)
		{
			num ^= TriggerMessage.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ClearMessage)
		{
			num ^= ClearMessage.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (requestCase_ == RequestOneofCase.Messages)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Messages);
		}
		if (requestCase_ == RequestOneofCase.CreateMessage)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateMessage);
		}
		if (requestCase_ == RequestOneofCase.GetMessage)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetMessage);
		}
		if (requestCase_ == RequestOneofCase.PutMessage)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutMessage);
		}
		if (requestCase_ == RequestOneofCase.DeleteMessage)
		{
			output.WriteRawTag(42);
			output.WriteMessage(DeleteMessage);
		}
		if (requestCase_ == RequestOneofCase.TriggerMessage)
		{
			output.WriteRawTag(50);
			output.WriteMessage(TriggerMessage);
		}
		if (requestCase_ == RequestOneofCase.ClearMessage)
		{
			output.WriteRawTag(58);
			output.WriteMessage(ClearMessage);
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
		if (requestCase_ == RequestOneofCase.Messages)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Messages);
		}
		if (requestCase_ == RequestOneofCase.CreateMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateMessage);
		}
		if (requestCase_ == RequestOneofCase.GetMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMessage);
		}
		if (requestCase_ == RequestOneofCase.PutMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutMessage);
		}
		if (requestCase_ == RequestOneofCase.DeleteMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteMessage);
		}
		if (requestCase_ == RequestOneofCase.TriggerMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerMessage);
		}
		if (requestCase_ == RequestOneofCase.ClearMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ClearMessage);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Message_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Messages:
			if (Messages == null)
			{
				Messages = new Types.Messages();
			}
			Messages.MergeFrom(other.Messages);
			break;
		case RequestOneofCase.CreateMessage:
			if (CreateMessage == null)
			{
				CreateMessage = new Types.CreateMessage();
			}
			CreateMessage.MergeFrom(other.CreateMessage);
			break;
		case RequestOneofCase.GetMessage:
			if (GetMessage == null)
			{
				GetMessage = new Types.GetMessage();
			}
			GetMessage.MergeFrom(other.GetMessage);
			break;
		case RequestOneofCase.PutMessage:
			if (PutMessage == null)
			{
				PutMessage = new Types.PutMessage();
			}
			PutMessage.MergeFrom(other.PutMessage);
			break;
		case RequestOneofCase.DeleteMessage:
			if (DeleteMessage == null)
			{
				DeleteMessage = new Types.DeleteMessage();
			}
			DeleteMessage.MergeFrom(other.DeleteMessage);
			break;
		case RequestOneofCase.TriggerMessage:
			if (TriggerMessage == null)
			{
				TriggerMessage = new Types.TriggerMessage();
			}
			TriggerMessage.MergeFrom(other.TriggerMessage);
			break;
		case RequestOneofCase.ClearMessage:
			if (ClearMessage == null)
			{
				ClearMessage = new Types.ClearMessage();
			}
			ClearMessage.MergeFrom(other.ClearMessage);
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
				Types.Messages messages = new Types.Messages();
				if (requestCase_ == RequestOneofCase.Messages)
				{
					messages.MergeFrom(Messages);
				}
				input.ReadMessage(messages);
				Messages = messages;
				break;
			}
			case 18u:
			{
				Types.CreateMessage createMessage = new Types.CreateMessage();
				if (requestCase_ == RequestOneofCase.CreateMessage)
				{
					createMessage.MergeFrom(CreateMessage);
				}
				input.ReadMessage(createMessage);
				CreateMessage = createMessage;
				break;
			}
			case 26u:
			{
				Types.GetMessage getMessage = new Types.GetMessage();
				if (requestCase_ == RequestOneofCase.GetMessage)
				{
					getMessage.MergeFrom(GetMessage);
				}
				input.ReadMessage(getMessage);
				GetMessage = getMessage;
				break;
			}
			case 34u:
			{
				Types.PutMessage putMessage = new Types.PutMessage();
				if (requestCase_ == RequestOneofCase.PutMessage)
				{
					putMessage.MergeFrom(PutMessage);
				}
				input.ReadMessage(putMessage);
				PutMessage = putMessage;
				break;
			}
			case 42u:
			{
				Types.DeleteMessage deleteMessage = new Types.DeleteMessage();
				if (requestCase_ == RequestOneofCase.DeleteMessage)
				{
					deleteMessage.MergeFrom(DeleteMessage);
				}
				input.ReadMessage(deleteMessage);
				DeleteMessage = deleteMessage;
				break;
			}
			case 50u:
			{
				Types.TriggerMessage triggerMessage = new Types.TriggerMessage();
				if (requestCase_ == RequestOneofCase.TriggerMessage)
				{
					triggerMessage.MergeFrom(TriggerMessage);
				}
				input.ReadMessage(triggerMessage);
				TriggerMessage = triggerMessage;
				break;
			}
			case 58u:
			{
				Types.ClearMessage clearMessage = new Types.ClearMessage();
				if (requestCase_ == RequestOneofCase.ClearMessage)
				{
					clearMessage.MergeFrom(ClearMessage);
				}
				input.ReadMessage(clearMessage);
				ClearMessage = clearMessage;
				break;
			}
			}
		}
	}
}
