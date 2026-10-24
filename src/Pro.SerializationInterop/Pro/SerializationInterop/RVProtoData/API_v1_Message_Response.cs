using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Message_Response : IMessage<API_v1_Message_Response>, IMessage, IEquatable<API_v1_Message_Response>, IDeepCloneable<API_v1_Message_Response>
{
	public enum ResponseOneofCase
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

			public const int Messages_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_Message> _repeated_messages_codec = FieldCodec.ForMessage(10u, API_v1_Message.Parser);

			private readonly RepeatedField<API_v1_Message> messages_ = new RepeatedField<API_v1_Message>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Messages> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Message> Messages_ => messages_;

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
				messages_ = other.messages_.Clone();
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
				if (!messages_.Equals(other.messages_))
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
				num ^= messages_.GetHashCode();
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
				messages_.WriteTo(output, _repeated_messages_codec);
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
				num += messages_.CalculateSize(_repeated_messages_codec);
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
					messages_.Add(other.messages_);
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
						messages_.AddEntriesFrom(input, _repeated_messages_codec);
					}
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
			public static MessageDescriptor Descriptor => API_v1_Message_Response.Descriptor.NestedTypes[1];

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

			public const int MessageFieldNumber = 1;

			private API_v1_Message message_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Response.Descriptor.NestedTypes[2];

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
			public GetMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMessage(GetMessage other)
				: this()
			{
				message_ = ((other.message_ != null) ? other.message_.Clone() : null);
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
			public void MergeFrom(GetMessage other)
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
		public sealed class PutMessage : IMessage<PutMessage>, IMessage, IEquatable<PutMessage>, IDeepCloneable<PutMessage>
		{
			private static readonly MessageParser<PutMessage> _parser = new MessageParser<PutMessage>(() => new PutMessage());

			private UnknownFieldSet _unknownFields;

			public const int MessageFieldNumber = 1;

			private API_v1_Message message_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Response.Descriptor.NestedTypes[3];

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
			public PutMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMessage(PutMessage other)
				: this()
			{
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
			public void MergeFrom(PutMessage other)
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
		public sealed class DeleteMessage : IMessage<DeleteMessage>, IMessage, IEquatable<DeleteMessage>, IDeepCloneable<DeleteMessage>
		{
			private static readonly MessageParser<DeleteMessage> _parser = new MessageParser<DeleteMessage>(() => new DeleteMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(DeleteMessage other)
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
		public sealed class TriggerMessage : IMessage<TriggerMessage>, IMessage, IEquatable<TriggerMessage>, IDeepCloneable<TriggerMessage>
		{
			private static readonly MessageParser<TriggerMessage> _parser = new MessageParser<TriggerMessage>(() => new TriggerMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(TriggerMessage other)
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
		public sealed class ClearMessage : IMessage<ClearMessage>, IMessage, IEquatable<ClearMessage>, IDeepCloneable<ClearMessage>
		{
			private static readonly MessageParser<ClearMessage> _parser = new MessageParser<ClearMessage>(() => new ClearMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Message_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(ClearMessage other)
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
	}

	private static readonly MessageParser<API_v1_Message_Response> _parser = new MessageParser<API_v1_Message_Response>(() => new API_v1_Message_Response());

	private UnknownFieldSet _unknownFields;

	public const int MessagesFieldNumber = 1;

	public const int CreateMessageFieldNumber = 2;

	public const int GetMessageFieldNumber = 3;

	public const int PutMessageFieldNumber = 4;

	public const int DeleteMessageFieldNumber = 5;

	public const int TriggerMessageFieldNumber = 6;

	public const int ClearMessageFieldNumber = 7;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Message_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MessageReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Messages Messages
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Messages)
			{
				return null;
			}
			return (Types.Messages)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Messages : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateMessage CreateMessage
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.CreateMessage)
			{
				return null;
			}
			return (Types.CreateMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.CreateMessage : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetMessage GetMessage
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetMessage)
			{
				return null;
			}
			return (Types.GetMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetMessage : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMessage PutMessage
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutMessage)
			{
				return null;
			}
			return (Types.PutMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutMessage : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteMessage DeleteMessage
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteMessage)
			{
				return null;
			}
			return (Types.DeleteMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteMessage : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerMessage TriggerMessage
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TriggerMessage)
			{
				return null;
			}
			return (Types.TriggerMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TriggerMessage : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearMessage ClearMessage
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ClearMessage)
			{
				return null;
			}
			return (Types.ClearMessage)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ClearMessage : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message_Response(API_v1_Message_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Messages:
			Messages = other.Messages.Clone();
			break;
		case ResponseOneofCase.CreateMessage:
			CreateMessage = other.CreateMessage.Clone();
			break;
		case ResponseOneofCase.GetMessage:
			GetMessage = other.GetMessage.Clone();
			break;
		case ResponseOneofCase.PutMessage:
			PutMessage = other.PutMessage.Clone();
			break;
		case ResponseOneofCase.DeleteMessage:
			DeleteMessage = other.DeleteMessage.Clone();
			break;
		case ResponseOneofCase.TriggerMessage:
			TriggerMessage = other.TriggerMessage.Clone();
			break;
		case ResponseOneofCase.ClearMessage:
			ClearMessage = other.ClearMessage.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Message_Response Clone()
	{
		return new API_v1_Message_Response(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponse()
	{
		responseCase_ = ResponseOneofCase.None;
		response_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Message_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Message_Response other)
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
		if (ResponseCase != other.ResponseCase)
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
		if (responseCase_ == ResponseOneofCase.Messages)
		{
			num ^= Messages.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.CreateMessage)
		{
			num ^= CreateMessage.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetMessage)
		{
			num ^= GetMessage.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutMessage)
		{
			num ^= PutMessage.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteMessage)
		{
			num ^= DeleteMessage.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerMessage)
		{
			num ^= TriggerMessage.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ClearMessage)
		{
			num ^= ClearMessage.GetHashCode();
		}
		num ^= (int)responseCase_;
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
		if (responseCase_ == ResponseOneofCase.Messages)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Messages);
		}
		if (responseCase_ == ResponseOneofCase.CreateMessage)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateMessage);
		}
		if (responseCase_ == ResponseOneofCase.GetMessage)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetMessage);
		}
		if (responseCase_ == ResponseOneofCase.PutMessage)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutMessage);
		}
		if (responseCase_ == ResponseOneofCase.DeleteMessage)
		{
			output.WriteRawTag(42);
			output.WriteMessage(DeleteMessage);
		}
		if (responseCase_ == ResponseOneofCase.TriggerMessage)
		{
			output.WriteRawTag(50);
			output.WriteMessage(TriggerMessage);
		}
		if (responseCase_ == ResponseOneofCase.ClearMessage)
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
		if (responseCase_ == ResponseOneofCase.Messages)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Messages);
		}
		if (responseCase_ == ResponseOneofCase.CreateMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateMessage);
		}
		if (responseCase_ == ResponseOneofCase.GetMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMessage);
		}
		if (responseCase_ == ResponseOneofCase.PutMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutMessage);
		}
		if (responseCase_ == ResponseOneofCase.DeleteMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteMessage);
		}
		if (responseCase_ == ResponseOneofCase.TriggerMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerMessage);
		}
		if (responseCase_ == ResponseOneofCase.ClearMessage)
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
	public void MergeFrom(API_v1_Message_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Messages:
			if (Messages == null)
			{
				Messages = new Types.Messages();
			}
			Messages.MergeFrom(other.Messages);
			break;
		case ResponseOneofCase.CreateMessage:
			if (CreateMessage == null)
			{
				CreateMessage = new Types.CreateMessage();
			}
			CreateMessage.MergeFrom(other.CreateMessage);
			break;
		case ResponseOneofCase.GetMessage:
			if (GetMessage == null)
			{
				GetMessage = new Types.GetMessage();
			}
			GetMessage.MergeFrom(other.GetMessage);
			break;
		case ResponseOneofCase.PutMessage:
			if (PutMessage == null)
			{
				PutMessage = new Types.PutMessage();
			}
			PutMessage.MergeFrom(other.PutMessage);
			break;
		case ResponseOneofCase.DeleteMessage:
			if (DeleteMessage == null)
			{
				DeleteMessage = new Types.DeleteMessage();
			}
			DeleteMessage.MergeFrom(other.DeleteMessage);
			break;
		case ResponseOneofCase.TriggerMessage:
			if (TriggerMessage == null)
			{
				TriggerMessage = new Types.TriggerMessage();
			}
			TriggerMessage.MergeFrom(other.TriggerMessage);
			break;
		case ResponseOneofCase.ClearMessage:
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
				if (responseCase_ == ResponseOneofCase.Messages)
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
				if (responseCase_ == ResponseOneofCase.CreateMessage)
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
				if (responseCase_ == ResponseOneofCase.GetMessage)
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
				if (responseCase_ == ResponseOneofCase.PutMessage)
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
				if (responseCase_ == ResponseOneofCase.DeleteMessage)
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
				if (responseCase_ == ResponseOneofCase.TriggerMessage)
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
				if (responseCase_ == ResponseOneofCase.ClearMessage)
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
