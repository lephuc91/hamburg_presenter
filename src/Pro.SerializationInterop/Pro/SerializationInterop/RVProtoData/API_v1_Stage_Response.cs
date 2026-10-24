using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Stage_Response : IMessage<API_v1_Stage_Response>, IMessage, IEquatable<API_v1_Stage_Response>, IDeepCloneable<API_v1_Stage_Response>
{
	public enum ResponseOneofCase
	{
		None,
		GetLayoutMap,
		SetLayoutMap,
		GetMessage,
		PutMessage,
		DeleteMessage,
		GetScreens,
		GetScreenLayout,
		SetScreenLayout,
		GetLayouts,
		DeleteLayout,
		GetLayoutThumbnail
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetLayoutMap : IMessage<GetLayoutMap>, IMessage, IEquatable<GetLayoutMap>, IDeepCloneable<GetLayoutMap>
		{
			private static readonly MessageParser<GetLayoutMap> _parser = new MessageParser<GetLayoutMap>(() => new GetLayoutMap());

			private UnknownFieldSet _unknownFields;

			public const int MapFieldNumber = 1;

			private API_v1_StageLayoutMap map_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayoutMap> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_StageLayoutMap Map
			{
				get
				{
					return map_;
				}
				set
				{
					map_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayoutMap()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayoutMap(GetLayoutMap other)
				: this()
			{
				map_ = ((other.map_ != null) ? other.map_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayoutMap Clone()
			{
				return new GetLayoutMap(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetLayoutMap);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetLayoutMap other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Map, other.Map))
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
				if (map_ != null)
				{
					num ^= Map.GetHashCode();
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
				if (map_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Map);
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
				if (map_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Map);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetLayoutMap other)
			{
				if (other == null)
				{
					return;
				}
				if (other.map_ != null)
				{
					if (map_ == null)
					{
						Map = new API_v1_StageLayoutMap();
					}
					Map.MergeFrom(other.Map);
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
					if (map_ == null)
					{
						Map = new API_v1_StageLayoutMap();
					}
					input.ReadMessage(Map);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetLayoutMap : IMessage<SetLayoutMap>, IMessage, IEquatable<SetLayoutMap>, IDeepCloneable<SetLayoutMap>
		{
			private static readonly MessageParser<SetLayoutMap> _parser = new MessageParser<SetLayoutMap>(() => new SetLayoutMap());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetLayoutMap> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetLayoutMap()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetLayoutMap(SetLayoutMap other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetLayoutMap Clone()
			{
				return new SetLayoutMap(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetLayoutMap);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetLayoutMap other)
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
			public void MergeFrom(SetLayoutMap other)
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
		public sealed class GetMessage : IMessage<GetMessage>, IMessage, IEquatable<GetMessage>, IDeepCloneable<GetMessage>
		{
			private static readonly MessageParser<GetMessage> _parser = new MessageParser<GetMessage>(() => new GetMessage());

			private UnknownFieldSet _unknownFields;

			public const int MessageFieldNumber = 1;

			private string message_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[2];

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
			public GetMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMessage(GetMessage other)
				: this()
			{
				message_ = other.message_;
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
			public void MergeFrom(GetMessage other)
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

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutMessage : IMessage<PutMessage>, IMessage, IEquatable<PutMessage>, IDeepCloneable<PutMessage>
		{
			private static readonly MessageParser<PutMessage> _parser = new MessageParser<PutMessage>(() => new PutMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(PutMessage other)
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
		public sealed class DeleteMessage : IMessage<DeleteMessage>, IMessage, IEquatable<DeleteMessage>, IDeepCloneable<DeleteMessage>
		{
			private static readonly MessageParser<DeleteMessage> _parser = new MessageParser<DeleteMessage>(() => new DeleteMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[4];

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
		public sealed class GetScreens : IMessage<GetScreens>, IMessage, IEquatable<GetScreens>, IDeepCloneable<GetScreens>
		{
			private static readonly MessageParser<GetScreens> _parser = new MessageParser<GetScreens>(() => new GetScreens());

			private UnknownFieldSet _unknownFields;

			public const int ScreensFieldNumber = 1;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_screens_codec = FieldCodec.ForMessage(10u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> screens_ = new RepeatedField<API_v1_Identifier>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Screens => screens_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens(GetScreens other)
				: this()
			{
				screens_ = other.screens_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreens Clone()
			{
				return new GetScreens(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetScreens);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetScreens other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!screens_.Equals(other.screens_))
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
				num ^= screens_.GetHashCode();
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
				screens_.WriteTo(output, _repeated_screens_codec);
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
				num += screens_.CalculateSize(_repeated_screens_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetScreens other)
			{
				if (other != null)
				{
					screens_.Add(other.screens_);
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
						screens_.AddEntriesFrom(input, _repeated_screens_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetScreenLayout : IMessage<GetScreenLayout>, IMessage, IEquatable<GetScreenLayout>, IDeepCloneable<GetScreenLayout>
		{
			private static readonly MessageParser<GetScreenLayout> _parser = new MessageParser<GetScreenLayout>(() => new GetScreenLayout());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetScreenLayout> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreenLayout()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreenLayout(GetScreenLayout other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreenLayout Clone()
			{
				return new GetScreenLayout(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetScreenLayout);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetScreenLayout other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Id, other.Id))
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
				if (id_ != null)
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
				if (id_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Id);
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
				if (id_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetScreenLayout other)
			{
				if (other == null)
				{
					return;
				}
				if (other.id_ != null)
				{
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					Id.MergeFrom(other.Id);
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
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					input.ReadMessage(Id);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetScreenLayout : IMessage<SetScreenLayout>, IMessage, IEquatable<SetScreenLayout>, IDeepCloneable<SetScreenLayout>
		{
			private static readonly MessageParser<SetScreenLayout> _parser = new MessageParser<SetScreenLayout>(() => new SetScreenLayout());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetScreenLayout> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetScreenLayout()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetScreenLayout(SetScreenLayout other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetScreenLayout Clone()
			{
				return new SetScreenLayout(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetScreenLayout);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetScreenLayout other)
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
			public void MergeFrom(SetScreenLayout other)
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
		public sealed class GetLayouts : IMessage<GetLayouts>, IMessage, IEquatable<GetLayouts>, IDeepCloneable<GetLayouts>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Layout : IMessage<Layout>, IMessage, IEquatable<Layout>, IDeepCloneable<Layout>
				{
					private static readonly MessageParser<Layout> _parser = new MessageParser<Layout>(() => new Layout());

					private UnknownFieldSet _unknownFields;

					public const int IdFieldNumber = 1;

					private API_v1_Identifier id_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Layout> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => GetLayouts.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public API_v1_Identifier Id
					{
						get
						{
							return id_;
						}
						set
						{
							id_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Layout()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Layout(Layout other)
						: this()
					{
						id_ = ((other.id_ != null) ? other.id_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Layout Clone()
					{
						return new Layout(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Layout);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Layout other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Id, other.Id))
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
						if (id_ != null)
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
						if (id_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Id);
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
						if (id_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Id);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Layout other)
					{
						if (other == null)
						{
							return;
						}
						if (other.id_ != null)
						{
							if (id_ == null)
							{
								Id = new API_v1_Identifier();
							}
							Id.MergeFrom(other.Id);
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
							if (id_ == null)
							{
								Id = new API_v1_Identifier();
							}
							input.ReadMessage(Id);
						}
					}
				}
			}

			private static readonly MessageParser<GetLayouts> _parser = new MessageParser<GetLayouts>(() => new GetLayouts());

			private UnknownFieldSet _unknownFields;

			public const int LayoutsFieldNumber = 1;

			private static readonly FieldCodec<Types.Layout> _repeated_layouts_codec = FieldCodec.ForMessage(10u, Types.Layout.Parser);

			private readonly RepeatedField<Types.Layout> layouts_ = new RepeatedField<Types.Layout>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayouts> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Layout> Layouts => layouts_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayouts()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayouts(GetLayouts other)
				: this()
			{
				layouts_ = other.layouts_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayouts Clone()
			{
				return new GetLayouts(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetLayouts);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetLayouts other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!layouts_.Equals(other.layouts_))
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
				num ^= layouts_.GetHashCode();
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
				layouts_.WriteTo(output, _repeated_layouts_codec);
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
				num += layouts_.CalculateSize(_repeated_layouts_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetLayouts other)
			{
				if (other != null)
				{
					layouts_.Add(other.layouts_);
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
						layouts_.AddEntriesFrom(input, _repeated_layouts_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteLayout : IMessage<DeleteLayout>, IMessage, IEquatable<DeleteLayout>, IDeepCloneable<DeleteLayout>
		{
			private static readonly MessageParser<DeleteLayout> _parser = new MessageParser<DeleteLayout>(() => new DeleteLayout());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteLayout> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteLayout()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteLayout(DeleteLayout other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteLayout Clone()
			{
				return new DeleteLayout(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteLayout);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteLayout other)
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
			public void MergeFrom(DeleteLayout other)
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
		public sealed class GetLayoutThumbnail : IMessage<GetLayoutThumbnail>, IMessage, IEquatable<GetLayoutThumbnail>, IDeepCloneable<GetLayoutThumbnail>
		{
			private static readonly MessageParser<GetLayoutThumbnail> _parser = new MessageParser<GetLayoutThumbnail>(() => new GetLayoutThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int DataFieldNumber = 1;

			private ByteString data_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayoutThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Response.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Data
			{
				get
				{
					return data_;
				}
				set
				{
					data_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayoutThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayoutThumbnail(GetLayoutThumbnail other)
				: this()
			{
				data_ = other.data_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLayoutThumbnail Clone()
			{
				return new GetLayoutThumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetLayoutThumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetLayoutThumbnail other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Data != other.Data)
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
				if (Data.Length != 0)
				{
					num ^= Data.GetHashCode();
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
				if (Data.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteBytes(Data);
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
				if (Data.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Data);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetLayoutThumbnail other)
			{
				if (other != null)
				{
					if (other.Data.Length != 0)
					{
						Data = other.Data;
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
						Data = input.ReadBytes();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Stage_Response> _parser = new MessageParser<API_v1_Stage_Response>(() => new API_v1_Stage_Response());

	private UnknownFieldSet _unknownFields;

	public const int GetLayoutMapFieldNumber = 1;

	public const int SetLayoutMapFieldNumber = 2;

	public const int GetMessageFieldNumber = 3;

	public const int PutMessageFieldNumber = 4;

	public const int DeleteMessageFieldNumber = 5;

	public const int GetScreensFieldNumber = 6;

	public const int GetScreenLayoutFieldNumber = 7;

	public const int SetScreenLayoutFieldNumber = 8;

	public const int GetLayoutsFieldNumber = 9;

	public const int DeleteLayoutFieldNumber = 10;

	public const int GetLayoutThumbnailFieldNumber = 11;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Stage_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1StageReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayoutMap GetLayoutMap
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetLayoutMap)
			{
				return null;
			}
			return (Types.GetLayoutMap)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetLayoutMap : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetLayoutMap SetLayoutMap
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.SetLayoutMap)
			{
				return null;
			}
			return (Types.SetLayoutMap)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.SetLayoutMap : ResponseOneofCase.None);
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
	public Types.GetScreens GetScreens
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetScreens)
			{
				return null;
			}
			return (Types.GetScreens)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetScreens : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetScreenLayout GetScreenLayout
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetScreenLayout)
			{
				return null;
			}
			return (Types.GetScreenLayout)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetScreenLayout : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetScreenLayout SetScreenLayout
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.SetScreenLayout)
			{
				return null;
			}
			return (Types.SetScreenLayout)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.SetScreenLayout : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayouts GetLayouts
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetLayouts)
			{
				return null;
			}
			return (Types.GetLayouts)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetLayouts : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteLayout DeleteLayout
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteLayout)
			{
				return null;
			}
			return (Types.DeleteLayout)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteLayout : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayoutThumbnail GetLayoutThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetLayoutThumbnail)
			{
				return null;
			}
			return (Types.GetLayoutThumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetLayoutThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Stage_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Stage_Response(API_v1_Stage_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetLayoutMap:
			GetLayoutMap = other.GetLayoutMap.Clone();
			break;
		case ResponseOneofCase.SetLayoutMap:
			SetLayoutMap = other.SetLayoutMap.Clone();
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
		case ResponseOneofCase.GetScreens:
			GetScreens = other.GetScreens.Clone();
			break;
		case ResponseOneofCase.GetScreenLayout:
			GetScreenLayout = other.GetScreenLayout.Clone();
			break;
		case ResponseOneofCase.SetScreenLayout:
			SetScreenLayout = other.SetScreenLayout.Clone();
			break;
		case ResponseOneofCase.GetLayouts:
			GetLayouts = other.GetLayouts.Clone();
			break;
		case ResponseOneofCase.DeleteLayout:
			DeleteLayout = other.DeleteLayout.Clone();
			break;
		case ResponseOneofCase.GetLayoutThumbnail:
			GetLayoutThumbnail = other.GetLayoutThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Stage_Response Clone()
	{
		return new API_v1_Stage_Response(this);
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
		return Equals(other as API_v1_Stage_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Stage_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetLayoutMap, other.GetLayoutMap))
		{
			return false;
		}
		if (!object.Equals(SetLayoutMap, other.SetLayoutMap))
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
		if (!object.Equals(GetScreens, other.GetScreens))
		{
			return false;
		}
		if (!object.Equals(GetScreenLayout, other.GetScreenLayout))
		{
			return false;
		}
		if (!object.Equals(SetScreenLayout, other.SetScreenLayout))
		{
			return false;
		}
		if (!object.Equals(GetLayouts, other.GetLayouts))
		{
			return false;
		}
		if (!object.Equals(DeleteLayout, other.DeleteLayout))
		{
			return false;
		}
		if (!object.Equals(GetLayoutThumbnail, other.GetLayoutThumbnail))
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
		if (responseCase_ == ResponseOneofCase.GetLayoutMap)
		{
			num ^= GetLayoutMap.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.SetLayoutMap)
		{
			num ^= SetLayoutMap.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.GetScreens)
		{
			num ^= GetScreens.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetScreenLayout)
		{
			num ^= GetScreenLayout.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.SetScreenLayout)
		{
			num ^= SetScreenLayout.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetLayouts)
		{
			num ^= GetLayouts.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteLayout)
		{
			num ^= DeleteLayout.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetLayoutThumbnail)
		{
			num ^= GetLayoutThumbnail.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.GetLayoutMap)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetLayoutMap);
		}
		if (responseCase_ == ResponseOneofCase.SetLayoutMap)
		{
			output.WriteRawTag(18);
			output.WriteMessage(SetLayoutMap);
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
		if (responseCase_ == ResponseOneofCase.GetScreens)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetScreenLayout)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetScreenLayout);
		}
		if (responseCase_ == ResponseOneofCase.SetScreenLayout)
		{
			output.WriteRawTag(66);
			output.WriteMessage(SetScreenLayout);
		}
		if (responseCase_ == ResponseOneofCase.GetLayouts)
		{
			output.WriteRawTag(74);
			output.WriteMessage(GetLayouts);
		}
		if (responseCase_ == ResponseOneofCase.DeleteLayout)
		{
			output.WriteRawTag(82);
			output.WriteMessage(DeleteLayout);
		}
		if (responseCase_ == ResponseOneofCase.GetLayoutThumbnail)
		{
			output.WriteRawTag(90);
			output.WriteMessage(GetLayoutThumbnail);
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
		if (responseCase_ == ResponseOneofCase.GetLayoutMap)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLayoutMap);
		}
		if (responseCase_ == ResponseOneofCase.SetLayoutMap)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetLayoutMap);
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
		if (responseCase_ == ResponseOneofCase.GetScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetScreens);
		}
		if (responseCase_ == ResponseOneofCase.GetScreenLayout)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetScreenLayout);
		}
		if (responseCase_ == ResponseOneofCase.SetScreenLayout)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetScreenLayout);
		}
		if (responseCase_ == ResponseOneofCase.GetLayouts)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLayouts);
		}
		if (responseCase_ == ResponseOneofCase.DeleteLayout)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteLayout);
		}
		if (responseCase_ == ResponseOneofCase.GetLayoutThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLayoutThumbnail);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Stage_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetLayoutMap:
			if (GetLayoutMap == null)
			{
				GetLayoutMap = new Types.GetLayoutMap();
			}
			GetLayoutMap.MergeFrom(other.GetLayoutMap);
			break;
		case ResponseOneofCase.SetLayoutMap:
			if (SetLayoutMap == null)
			{
				SetLayoutMap = new Types.SetLayoutMap();
			}
			SetLayoutMap.MergeFrom(other.SetLayoutMap);
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
		case ResponseOneofCase.GetScreens:
			if (GetScreens == null)
			{
				GetScreens = new Types.GetScreens();
			}
			GetScreens.MergeFrom(other.GetScreens);
			break;
		case ResponseOneofCase.GetScreenLayout:
			if (GetScreenLayout == null)
			{
				GetScreenLayout = new Types.GetScreenLayout();
			}
			GetScreenLayout.MergeFrom(other.GetScreenLayout);
			break;
		case ResponseOneofCase.SetScreenLayout:
			if (SetScreenLayout == null)
			{
				SetScreenLayout = new Types.SetScreenLayout();
			}
			SetScreenLayout.MergeFrom(other.SetScreenLayout);
			break;
		case ResponseOneofCase.GetLayouts:
			if (GetLayouts == null)
			{
				GetLayouts = new Types.GetLayouts();
			}
			GetLayouts.MergeFrom(other.GetLayouts);
			break;
		case ResponseOneofCase.DeleteLayout:
			if (DeleteLayout == null)
			{
				DeleteLayout = new Types.DeleteLayout();
			}
			DeleteLayout.MergeFrom(other.DeleteLayout);
			break;
		case ResponseOneofCase.GetLayoutThumbnail:
			if (GetLayoutThumbnail == null)
			{
				GetLayoutThumbnail = new Types.GetLayoutThumbnail();
			}
			GetLayoutThumbnail.MergeFrom(other.GetLayoutThumbnail);
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
				Types.GetLayoutMap getLayoutMap = new Types.GetLayoutMap();
				if (responseCase_ == ResponseOneofCase.GetLayoutMap)
				{
					getLayoutMap.MergeFrom(GetLayoutMap);
				}
				input.ReadMessage(getLayoutMap);
				GetLayoutMap = getLayoutMap;
				break;
			}
			case 18u:
			{
				Types.SetLayoutMap setLayoutMap = new Types.SetLayoutMap();
				if (responseCase_ == ResponseOneofCase.SetLayoutMap)
				{
					setLayoutMap.MergeFrom(SetLayoutMap);
				}
				input.ReadMessage(setLayoutMap);
				SetLayoutMap = setLayoutMap;
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
				Types.GetScreens getScreens = new Types.GetScreens();
				if (responseCase_ == ResponseOneofCase.GetScreens)
				{
					getScreens.MergeFrom(GetScreens);
				}
				input.ReadMessage(getScreens);
				GetScreens = getScreens;
				break;
			}
			case 58u:
			{
				Types.GetScreenLayout getScreenLayout = new Types.GetScreenLayout();
				if (responseCase_ == ResponseOneofCase.GetScreenLayout)
				{
					getScreenLayout.MergeFrom(GetScreenLayout);
				}
				input.ReadMessage(getScreenLayout);
				GetScreenLayout = getScreenLayout;
				break;
			}
			case 66u:
			{
				Types.SetScreenLayout setScreenLayout = new Types.SetScreenLayout();
				if (responseCase_ == ResponseOneofCase.SetScreenLayout)
				{
					setScreenLayout.MergeFrom(SetScreenLayout);
				}
				input.ReadMessage(setScreenLayout);
				SetScreenLayout = setScreenLayout;
				break;
			}
			case 74u:
			{
				Types.GetLayouts getLayouts = new Types.GetLayouts();
				if (responseCase_ == ResponseOneofCase.GetLayouts)
				{
					getLayouts.MergeFrom(GetLayouts);
				}
				input.ReadMessage(getLayouts);
				GetLayouts = getLayouts;
				break;
			}
			case 82u:
			{
				Types.DeleteLayout deleteLayout = new Types.DeleteLayout();
				if (responseCase_ == ResponseOneofCase.DeleteLayout)
				{
					deleteLayout.MergeFrom(DeleteLayout);
				}
				input.ReadMessage(deleteLayout);
				DeleteLayout = deleteLayout;
				break;
			}
			case 90u:
			{
				Types.GetLayoutThumbnail getLayoutThumbnail = new Types.GetLayoutThumbnail();
				if (responseCase_ == ResponseOneofCase.GetLayoutThumbnail)
				{
					getLayoutThumbnail.MergeFrom(GetLayoutThumbnail);
				}
				input.ReadMessage(getLayoutThumbnail);
				GetLayoutThumbnail = getLayoutThumbnail;
				break;
			}
			}
		}
	}
}
