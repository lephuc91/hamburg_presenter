using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Stage_Request : IMessage<API_v1_Stage_Request>, IMessage, IEquatable<API_v1_Stage_Request>, IDeepCloneable<API_v1_Stage_Request>
{
	public enum RequestOneofCase
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayoutMap> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(GetLayoutMap other)
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
		public sealed class SetLayoutMap : IMessage<SetLayoutMap>, IMessage, IEquatable<SetLayoutMap>, IDeepCloneable<SetLayoutMap>
		{
			private static readonly MessageParser<SetLayoutMap> _parser = new MessageParser<SetLayoutMap>(() => new SetLayoutMap());

			private UnknownFieldSet _unknownFields;

			public const int MapFieldNumber = 1;

			private API_v1_StageLayoutMap map_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetLayoutMap> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[1];

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
			public SetLayoutMap()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetLayoutMap(SetLayoutMap other)
				: this()
			{
				map_ = ((other.map_ != null) ? other.map_.Clone() : null);
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
			public void MergeFrom(SetLayoutMap other)
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
		public sealed class GetMessage : IMessage<GetMessage>, IMessage, IEquatable<GetMessage>, IDeepCloneable<GetMessage>
		{
			private static readonly MessageParser<GetMessage> _parser = new MessageParser<GetMessage>(() => new GetMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(GetMessage other)
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
		public sealed class PutMessage : IMessage<PutMessage>, IMessage, IEquatable<PutMessage>, IDeepCloneable<PutMessage>
		{
			private static readonly MessageParser<PutMessage> _parser = new MessageParser<PutMessage>(() => new PutMessage());

			private UnknownFieldSet _unknownFields;

			public const int MessageFieldNumber = 1;

			private string message_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[3];

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
			public PutMessage()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMessage(PutMessage other)
				: this()
			{
				message_ = other.message_;
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
			public void MergeFrom(PutMessage other)
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
		public sealed class DeleteMessage : IMessage<DeleteMessage>, IMessage, IEquatable<DeleteMessage>, IDeepCloneable<DeleteMessage>
		{
			private static readonly MessageParser<DeleteMessage> _parser = new MessageParser<DeleteMessage>(() => new DeleteMessage());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMessage> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[4];

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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetScreens> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(GetScreens other)
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
		public sealed class GetScreenLayout : IMessage<GetScreenLayout>, IMessage, IEquatable<GetScreenLayout>, IDeepCloneable<GetScreenLayout>
		{
			private static readonly MessageParser<GetScreenLayout> _parser = new MessageParser<GetScreenLayout>(() => new GetScreenLayout());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetScreenLayout> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[6];

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
			public GetScreenLayout()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetScreenLayout(GetScreenLayout other)
				: this()
			{
				id_ = other.id_;
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
			public void MergeFrom(GetScreenLayout other)
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
		public sealed class SetScreenLayout : IMessage<SetScreenLayout>, IMessage, IEquatable<SetScreenLayout>, IDeepCloneable<SetScreenLayout>
		{
			private static readonly MessageParser<SetScreenLayout> _parser = new MessageParser<SetScreenLayout>(() => new SetScreenLayout());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int LayoutFieldNumber = 2;

			private string layout_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetScreenLayout> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[7];

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
			public string Layout
			{
				get
				{
					return layout_;
				}
				set
				{
					layout_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				id_ = other.id_;
				layout_ = other.layout_;
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
				if (Id != other.Id)
				{
					return false;
				}
				if (Layout != other.Layout)
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
				if (Layout.Length != 0)
				{
					num ^= Layout.GetHashCode();
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
				if (Layout.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Layout);
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
				if (Layout.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Layout);
				}
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
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Layout.Length != 0)
					{
						Layout = other.Layout;
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
						Layout = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetLayouts : IMessage<GetLayouts>, IMessage, IEquatable<GetLayouts>, IDeepCloneable<GetLayouts>
		{
			private static readonly MessageParser<GetLayouts> _parser = new MessageParser<GetLayouts>(() => new GetLayouts());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayouts> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(GetLayouts other)
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
		public sealed class DeleteLayout : IMessage<DeleteLayout>, IMessage, IEquatable<DeleteLayout>, IDeepCloneable<DeleteLayout>
		{
			private static readonly MessageParser<DeleteLayout> _parser = new MessageParser<DeleteLayout>(() => new DeleteLayout());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteLayout> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[9];

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
			public DeleteLayout()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteLayout(DeleteLayout other)
				: this()
			{
				id_ = other.id_;
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
			public void MergeFrom(DeleteLayout other)
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
		public sealed class GetLayoutThumbnail : IMessage<GetLayoutThumbnail>, IMessage, IEquatable<GetLayoutThumbnail>, IDeepCloneable<GetLayoutThumbnail>
		{
			private static readonly MessageParser<GetLayoutThumbnail> _parser = new MessageParser<GetLayoutThumbnail>(() => new GetLayoutThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int QualityFieldNumber = 2;

			private int quality_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLayoutThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Stage_Request.Descriptor.NestedTypes[10];

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
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
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
				id_ = other.id_;
				quality_ = other.quality_;
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
				if (Id != other.Id)
				{
					return false;
				}
				if (Quality != other.Quality)
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
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
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
				if (Quality != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Quality);
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
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
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
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Quality != 0)
					{
						Quality = other.Quality;
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
					case 16u:
						Quality = input.ReadInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Stage_Request> _parser = new MessageParser<API_v1_Stage_Request>(() => new API_v1_Stage_Request());

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

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Stage_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1StageReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayoutMap GetLayoutMap
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetLayoutMap)
			{
				return null;
			}
			return (Types.GetLayoutMap)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetLayoutMap : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetLayoutMap SetLayoutMap
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SetLayoutMap)
			{
				return null;
			}
			return (Types.SetLayoutMap)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SetLayoutMap : RequestOneofCase.None);
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
	public Types.GetScreens GetScreens
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetScreens)
			{
				return null;
			}
			return (Types.GetScreens)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetScreens : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetScreenLayout GetScreenLayout
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetScreenLayout)
			{
				return null;
			}
			return (Types.GetScreenLayout)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetScreenLayout : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetScreenLayout SetScreenLayout
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SetScreenLayout)
			{
				return null;
			}
			return (Types.SetScreenLayout)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SetScreenLayout : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayouts GetLayouts
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetLayouts)
			{
				return null;
			}
			return (Types.GetLayouts)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetLayouts : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteLayout DeleteLayout
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteLayout)
			{
				return null;
			}
			return (Types.DeleteLayout)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteLayout : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLayoutThumbnail GetLayoutThumbnail
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetLayoutThumbnail)
			{
				return null;
			}
			return (Types.GetLayoutThumbnail)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetLayoutThumbnail : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Stage_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Stage_Request(API_v1_Stage_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetLayoutMap:
			GetLayoutMap = other.GetLayoutMap.Clone();
			break;
		case RequestOneofCase.SetLayoutMap:
			SetLayoutMap = other.SetLayoutMap.Clone();
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
		case RequestOneofCase.GetScreens:
			GetScreens = other.GetScreens.Clone();
			break;
		case RequestOneofCase.GetScreenLayout:
			GetScreenLayout = other.GetScreenLayout.Clone();
			break;
		case RequestOneofCase.SetScreenLayout:
			SetScreenLayout = other.SetScreenLayout.Clone();
			break;
		case RequestOneofCase.GetLayouts:
			GetLayouts = other.GetLayouts.Clone();
			break;
		case RequestOneofCase.DeleteLayout:
			DeleteLayout = other.DeleteLayout.Clone();
			break;
		case RequestOneofCase.GetLayoutThumbnail:
			GetLayoutThumbnail = other.GetLayoutThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Stage_Request Clone()
	{
		return new API_v1_Stage_Request(this);
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
		return Equals(other as API_v1_Stage_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Stage_Request other)
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
		if (requestCase_ == RequestOneofCase.GetLayoutMap)
		{
			num ^= GetLayoutMap.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SetLayoutMap)
		{
			num ^= SetLayoutMap.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetScreens)
		{
			num ^= GetScreens.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetScreenLayout)
		{
			num ^= GetScreenLayout.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SetScreenLayout)
		{
			num ^= SetScreenLayout.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetLayouts)
		{
			num ^= GetLayouts.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteLayout)
		{
			num ^= DeleteLayout.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetLayoutThumbnail)
		{
			num ^= GetLayoutThumbnail.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetLayoutMap)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetLayoutMap);
		}
		if (requestCase_ == RequestOneofCase.SetLayoutMap)
		{
			output.WriteRawTag(18);
			output.WriteMessage(SetLayoutMap);
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
		if (requestCase_ == RequestOneofCase.GetScreens)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetScreens);
		}
		if (requestCase_ == RequestOneofCase.GetScreenLayout)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetScreenLayout);
		}
		if (requestCase_ == RequestOneofCase.SetScreenLayout)
		{
			output.WriteRawTag(66);
			output.WriteMessage(SetScreenLayout);
		}
		if (requestCase_ == RequestOneofCase.GetLayouts)
		{
			output.WriteRawTag(74);
			output.WriteMessage(GetLayouts);
		}
		if (requestCase_ == RequestOneofCase.DeleteLayout)
		{
			output.WriteRawTag(82);
			output.WriteMessage(DeleteLayout);
		}
		if (requestCase_ == RequestOneofCase.GetLayoutThumbnail)
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
		if (requestCase_ == RequestOneofCase.GetLayoutMap)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLayoutMap);
		}
		if (requestCase_ == RequestOneofCase.SetLayoutMap)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetLayoutMap);
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
		if (requestCase_ == RequestOneofCase.GetScreens)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetScreens);
		}
		if (requestCase_ == RequestOneofCase.GetScreenLayout)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetScreenLayout);
		}
		if (requestCase_ == RequestOneofCase.SetScreenLayout)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetScreenLayout);
		}
		if (requestCase_ == RequestOneofCase.GetLayouts)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLayouts);
		}
		if (requestCase_ == RequestOneofCase.DeleteLayout)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteLayout);
		}
		if (requestCase_ == RequestOneofCase.GetLayoutThumbnail)
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
	public void MergeFrom(API_v1_Stage_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetLayoutMap:
			if (GetLayoutMap == null)
			{
				GetLayoutMap = new Types.GetLayoutMap();
			}
			GetLayoutMap.MergeFrom(other.GetLayoutMap);
			break;
		case RequestOneofCase.SetLayoutMap:
			if (SetLayoutMap == null)
			{
				SetLayoutMap = new Types.SetLayoutMap();
			}
			SetLayoutMap.MergeFrom(other.SetLayoutMap);
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
		case RequestOneofCase.GetScreens:
			if (GetScreens == null)
			{
				GetScreens = new Types.GetScreens();
			}
			GetScreens.MergeFrom(other.GetScreens);
			break;
		case RequestOneofCase.GetScreenLayout:
			if (GetScreenLayout == null)
			{
				GetScreenLayout = new Types.GetScreenLayout();
			}
			GetScreenLayout.MergeFrom(other.GetScreenLayout);
			break;
		case RequestOneofCase.SetScreenLayout:
			if (SetScreenLayout == null)
			{
				SetScreenLayout = new Types.SetScreenLayout();
			}
			SetScreenLayout.MergeFrom(other.SetScreenLayout);
			break;
		case RequestOneofCase.GetLayouts:
			if (GetLayouts == null)
			{
				GetLayouts = new Types.GetLayouts();
			}
			GetLayouts.MergeFrom(other.GetLayouts);
			break;
		case RequestOneofCase.DeleteLayout:
			if (DeleteLayout == null)
			{
				DeleteLayout = new Types.DeleteLayout();
			}
			DeleteLayout.MergeFrom(other.DeleteLayout);
			break;
		case RequestOneofCase.GetLayoutThumbnail:
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
				if (requestCase_ == RequestOneofCase.GetLayoutMap)
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
				if (requestCase_ == RequestOneofCase.SetLayoutMap)
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
				Types.GetScreens getScreens = new Types.GetScreens();
				if (requestCase_ == RequestOneofCase.GetScreens)
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
				if (requestCase_ == RequestOneofCase.GetScreenLayout)
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
				if (requestCase_ == RequestOneofCase.SetScreenLayout)
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
				if (requestCase_ == RequestOneofCase.GetLayouts)
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
				if (requestCase_ == RequestOneofCase.DeleteLayout)
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
				if (requestCase_ == RequestOneofCase.GetLayoutThumbnail)
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
