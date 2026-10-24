using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Clear_Request : IMessage<API_v1_Clear_Request>, IMessage, IEquatable<API_v1_Clear_Request>, IDeepCloneable<API_v1_Clear_Request>
{
	public enum RequestOneofCase
	{
		None,
		ClearLayer,
		CreateGroup,
		GetGroup,
		PutGroup,
		GetGroupIcon,
		PutGroupIcon,
		DeleteGroup,
		TriggerGroup,
		GetGroups
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ClearLayer : IMessage<ClearLayer>, IMessage, IEquatable<ClearLayer>, IDeepCloneable<ClearLayer>
		{
			private static readonly MessageParser<ClearLayer> _parser = new MessageParser<ClearLayer>(() => new ClearLayer());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearLayer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearLayer()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearLayer(ClearLayer other)
				: this()
			{
				layer_ = other.layer_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearLayer Clone()
			{
				return new ClearLayer(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClearLayer);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClearLayer other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Layer != other.Layer)
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ClearLayer other)
			{
				if (other != null)
				{
					if (other.Layer != 0)
					{
						Layer = other.Layer;
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
					if (num != 8)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Layer = (API_v1_LayerType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CreateGroup : IMessage<CreateGroup>, IMessage, IEquatable<CreateGroup>, IDeepCloneable<CreateGroup>
		{
			private static readonly MessageParser<CreateGroup> _parser = new MessageParser<CreateGroup>(() => new CreateGroup());

			private UnknownFieldSet _unknownFields;

			public const int GroupFieldNumber = 1;

			private API_v1_ClearGroup group_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CreateGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_ClearGroup Group
			{
				get
				{
					return group_;
				}
				set
				{
					group_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateGroup(CreateGroup other)
				: this()
			{
				group_ = ((other.group_ != null) ? other.group_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateGroup Clone()
			{
				return new CreateGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CreateGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CreateGroup other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Group, other.Group))
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
				if (group_ != null)
				{
					num ^= Group.GetHashCode();
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
				if (group_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Group);
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
				if (group_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Group);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CreateGroup other)
			{
				if (other == null)
				{
					return;
				}
				if (other.group_ != null)
				{
					if (group_ == null)
					{
						Group = new API_v1_ClearGroup();
					}
					Group.MergeFrom(other.Group);
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
					if (group_ == null)
					{
						Group = new API_v1_ClearGroup();
					}
					input.ReadMessage(Group);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetGroup : IMessage<GetGroup>, IMessage, IEquatable<GetGroup>, IDeepCloneable<GetGroup>
		{
			private static readonly MessageParser<GetGroup> _parser = new MessageParser<GetGroup>(() => new GetGroup());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[2];

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
			public GetGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroup(GetGroup other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroup Clone()
			{
				return new GetGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetGroup other)
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
			public void MergeFrom(GetGroup other)
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
		public sealed class PutGroup : IMessage<PutGroup>, IMessage, IEquatable<PutGroup>, IDeepCloneable<PutGroup>
		{
			private static readonly MessageParser<PutGroup> _parser = new MessageParser<PutGroup>(() => new PutGroup());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int GroupFieldNumber = 2;

			private API_v1_ClearGroup group_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[3];

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
			public API_v1_ClearGroup Group
			{
				get
				{
					return group_;
				}
				set
				{
					group_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutGroup(PutGroup other)
				: this()
			{
				id_ = other.id_;
				group_ = ((other.group_ != null) ? other.group_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutGroup Clone()
			{
				return new PutGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutGroup other)
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
				if (!object.Equals(Group, other.Group))
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
				if (group_ != null)
				{
					num ^= Group.GetHashCode();
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
				if (group_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Group);
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
				if (group_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Group);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutGroup other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.group_ != null)
				{
					if (group_ == null)
					{
						Group = new API_v1_ClearGroup();
					}
					Group.MergeFrom(other.Group);
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
						if (group_ == null)
						{
							Group = new API_v1_ClearGroup();
						}
						input.ReadMessage(Group);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetGroupIcon : IMessage<GetGroupIcon>, IMessage, IEquatable<GetGroupIcon>, IDeepCloneable<GetGroupIcon>
		{
			private static readonly MessageParser<GetGroupIcon> _parser = new MessageParser<GetGroupIcon>(() => new GetGroupIcon());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetGroupIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[4];

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
			public GetGroupIcon()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroupIcon(GetGroupIcon other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroupIcon Clone()
			{
				return new GetGroupIcon(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetGroupIcon);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetGroupIcon other)
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
			public void MergeFrom(GetGroupIcon other)
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
		public sealed class PutGroupIcon : IMessage<PutGroupIcon>, IMessage, IEquatable<PutGroupIcon>, IDeepCloneable<PutGroupIcon>
		{
			private static readonly MessageParser<PutGroupIcon> _parser = new MessageParser<PutGroupIcon>(() => new PutGroupIcon());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ContentTypeFieldNumber = 2;

			private string contentType_ = "";

			public const int IconFieldNumber = 3;

			private ByteString icon_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutGroupIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[5];

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
			public string ContentType
			{
				get
				{
					return contentType_;
				}
				set
				{
					contentType_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Icon
			{
				get
				{
					return icon_;
				}
				set
				{
					icon_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutGroupIcon()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutGroupIcon(PutGroupIcon other)
				: this()
			{
				id_ = other.id_;
				contentType_ = other.contentType_;
				icon_ = other.icon_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutGroupIcon Clone()
			{
				return new PutGroupIcon(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutGroupIcon);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutGroupIcon other)
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
				if (ContentType != other.ContentType)
				{
					return false;
				}
				if (Icon != other.Icon)
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
				if (ContentType.Length != 0)
				{
					num ^= ContentType.GetHashCode();
				}
				if (Icon.Length != 0)
				{
					num ^= Icon.GetHashCode();
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
				if (ContentType.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ContentType);
				}
				if (Icon.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteBytes(Icon);
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
				if (ContentType.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ContentType);
				}
				if (Icon.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Icon);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutGroupIcon other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.ContentType.Length != 0)
					{
						ContentType = other.ContentType;
					}
					if (other.Icon.Length != 0)
					{
						Icon = other.Icon;
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
						ContentType = input.ReadString();
						break;
					case 26u:
						Icon = input.ReadBytes();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteGroup : IMessage<DeleteGroup>, IMessage, IEquatable<DeleteGroup>, IDeepCloneable<DeleteGroup>
		{
			private static readonly MessageParser<DeleteGroup> _parser = new MessageParser<DeleteGroup>(() => new DeleteGroup());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[6];

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
			public DeleteGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteGroup(DeleteGroup other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteGroup Clone()
			{
				return new DeleteGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteGroup other)
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
			public void MergeFrom(DeleteGroup other)
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
		public sealed class TriggerGroup : IMessage<TriggerGroup>, IMessage, IEquatable<TriggerGroup>, IDeepCloneable<TriggerGroup>
		{
			private static readonly MessageParser<TriggerGroup> _parser = new MessageParser<TriggerGroup>(() => new TriggerGroup());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[7];

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
			public TriggerGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerGroup(TriggerGroup other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerGroup Clone()
			{
				return new TriggerGroup(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerGroup);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerGroup other)
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
			public void MergeFrom(TriggerGroup other)
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
		public sealed class GetGroups : IMessage<GetGroups>, IMessage, IEquatable<GetGroups>, IDeepCloneable<GetGroups>
		{
			private static readonly MessageParser<GetGroups> _parser = new MessageParser<GetGroups>(() => new GetGroups());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetGroups> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroups()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroups(GetGroups other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroups Clone()
			{
				return new GetGroups(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetGroups);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetGroups other)
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
			public void MergeFrom(GetGroups other)
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

	private static readonly MessageParser<API_v1_Clear_Request> _parser = new MessageParser<API_v1_Clear_Request>(() => new API_v1_Clear_Request());

	private UnknownFieldSet _unknownFields;

	public const int ClearLayerFieldNumber = 1;

	public const int CreateGroupFieldNumber = 2;

	public const int GetGroupFieldNumber = 3;

	public const int PutGroupFieldNumber = 4;

	public const int GetGroupIconFieldNumber = 5;

	public const int PutGroupIconFieldNumber = 6;

	public const int DeleteGroupFieldNumber = 7;

	public const int TriggerGroupFieldNumber = 8;

	public const int GetGroupsFieldNumber = 9;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Clear_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1ClearReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearLayer ClearLayer
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ClearLayer)
			{
				return null;
			}
			return (Types.ClearLayer)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ClearLayer : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateGroup CreateGroup
	{
		get
		{
			if (requestCase_ != RequestOneofCase.CreateGroup)
			{
				return null;
			}
			return (Types.CreateGroup)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.CreateGroup : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetGroup GetGroup
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetGroup)
			{
				return null;
			}
			return (Types.GetGroup)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetGroup : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutGroup PutGroup
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutGroup)
			{
				return null;
			}
			return (Types.PutGroup)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutGroup : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetGroupIcon GetGroupIcon
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetGroupIcon)
			{
				return null;
			}
			return (Types.GetGroupIcon)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetGroupIcon : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutGroupIcon PutGroupIcon
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutGroupIcon)
			{
				return null;
			}
			return (Types.PutGroupIcon)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutGroupIcon : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteGroup DeleteGroup
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteGroup)
			{
				return null;
			}
			return (Types.DeleteGroup)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteGroup : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerGroup TriggerGroup
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TriggerGroup)
			{
				return null;
			}
			return (Types.TriggerGroup)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TriggerGroup : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetGroups GetGroups
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetGroups)
			{
				return null;
			}
			return (Types.GetGroups)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetGroups : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Clear_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Clear_Request(API_v1_Clear_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.ClearLayer:
			ClearLayer = other.ClearLayer.Clone();
			break;
		case RequestOneofCase.CreateGroup:
			CreateGroup = other.CreateGroup.Clone();
			break;
		case RequestOneofCase.GetGroup:
			GetGroup = other.GetGroup.Clone();
			break;
		case RequestOneofCase.PutGroup:
			PutGroup = other.PutGroup.Clone();
			break;
		case RequestOneofCase.GetGroupIcon:
			GetGroupIcon = other.GetGroupIcon.Clone();
			break;
		case RequestOneofCase.PutGroupIcon:
			PutGroupIcon = other.PutGroupIcon.Clone();
			break;
		case RequestOneofCase.DeleteGroup:
			DeleteGroup = other.DeleteGroup.Clone();
			break;
		case RequestOneofCase.TriggerGroup:
			TriggerGroup = other.TriggerGroup.Clone();
			break;
		case RequestOneofCase.GetGroups:
			GetGroups = other.GetGroups.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Clear_Request Clone()
	{
		return new API_v1_Clear_Request(this);
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
		return Equals(other as API_v1_Clear_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Clear_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ClearLayer, other.ClearLayer))
		{
			return false;
		}
		if (!object.Equals(CreateGroup, other.CreateGroup))
		{
			return false;
		}
		if (!object.Equals(GetGroup, other.GetGroup))
		{
			return false;
		}
		if (!object.Equals(PutGroup, other.PutGroup))
		{
			return false;
		}
		if (!object.Equals(GetGroupIcon, other.GetGroupIcon))
		{
			return false;
		}
		if (!object.Equals(PutGroupIcon, other.PutGroupIcon))
		{
			return false;
		}
		if (!object.Equals(DeleteGroup, other.DeleteGroup))
		{
			return false;
		}
		if (!object.Equals(TriggerGroup, other.TriggerGroup))
		{
			return false;
		}
		if (!object.Equals(GetGroups, other.GetGroups))
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
		if (requestCase_ == RequestOneofCase.ClearLayer)
		{
			num ^= ClearLayer.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.CreateGroup)
		{
			num ^= CreateGroup.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetGroup)
		{
			num ^= GetGroup.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutGroup)
		{
			num ^= PutGroup.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetGroupIcon)
		{
			num ^= GetGroupIcon.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutGroupIcon)
		{
			num ^= PutGroupIcon.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteGroup)
		{
			num ^= DeleteGroup.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TriggerGroup)
		{
			num ^= TriggerGroup.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetGroups)
		{
			num ^= GetGroups.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.ClearLayer)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ClearLayer);
		}
		if (requestCase_ == RequestOneofCase.CreateGroup)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateGroup);
		}
		if (requestCase_ == RequestOneofCase.GetGroup)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetGroup);
		}
		if (requestCase_ == RequestOneofCase.PutGroup)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutGroup);
		}
		if (requestCase_ == RequestOneofCase.GetGroupIcon)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GetGroupIcon);
		}
		if (requestCase_ == RequestOneofCase.PutGroupIcon)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PutGroupIcon);
		}
		if (requestCase_ == RequestOneofCase.DeleteGroup)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DeleteGroup);
		}
		if (requestCase_ == RequestOneofCase.TriggerGroup)
		{
			output.WriteRawTag(66);
			output.WriteMessage(TriggerGroup);
		}
		if (requestCase_ == RequestOneofCase.GetGroups)
		{
			output.WriteRawTag(74);
			output.WriteMessage(GetGroups);
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
		if (requestCase_ == RequestOneofCase.ClearLayer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ClearLayer);
		}
		if (requestCase_ == RequestOneofCase.CreateGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateGroup);
		}
		if (requestCase_ == RequestOneofCase.GetGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetGroup);
		}
		if (requestCase_ == RequestOneofCase.PutGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutGroup);
		}
		if (requestCase_ == RequestOneofCase.GetGroupIcon)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetGroupIcon);
		}
		if (requestCase_ == RequestOneofCase.PutGroupIcon)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutGroupIcon);
		}
		if (requestCase_ == RequestOneofCase.DeleteGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteGroup);
		}
		if (requestCase_ == RequestOneofCase.TriggerGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerGroup);
		}
		if (requestCase_ == RequestOneofCase.GetGroups)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetGroups);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Clear_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.ClearLayer:
			if (ClearLayer == null)
			{
				ClearLayer = new Types.ClearLayer();
			}
			ClearLayer.MergeFrom(other.ClearLayer);
			break;
		case RequestOneofCase.CreateGroup:
			if (CreateGroup == null)
			{
				CreateGroup = new Types.CreateGroup();
			}
			CreateGroup.MergeFrom(other.CreateGroup);
			break;
		case RequestOneofCase.GetGroup:
			if (GetGroup == null)
			{
				GetGroup = new Types.GetGroup();
			}
			GetGroup.MergeFrom(other.GetGroup);
			break;
		case RequestOneofCase.PutGroup:
			if (PutGroup == null)
			{
				PutGroup = new Types.PutGroup();
			}
			PutGroup.MergeFrom(other.PutGroup);
			break;
		case RequestOneofCase.GetGroupIcon:
			if (GetGroupIcon == null)
			{
				GetGroupIcon = new Types.GetGroupIcon();
			}
			GetGroupIcon.MergeFrom(other.GetGroupIcon);
			break;
		case RequestOneofCase.PutGroupIcon:
			if (PutGroupIcon == null)
			{
				PutGroupIcon = new Types.PutGroupIcon();
			}
			PutGroupIcon.MergeFrom(other.PutGroupIcon);
			break;
		case RequestOneofCase.DeleteGroup:
			if (DeleteGroup == null)
			{
				DeleteGroup = new Types.DeleteGroup();
			}
			DeleteGroup.MergeFrom(other.DeleteGroup);
			break;
		case RequestOneofCase.TriggerGroup:
			if (TriggerGroup == null)
			{
				TriggerGroup = new Types.TriggerGroup();
			}
			TriggerGroup.MergeFrom(other.TriggerGroup);
			break;
		case RequestOneofCase.GetGroups:
			if (GetGroups == null)
			{
				GetGroups = new Types.GetGroups();
			}
			GetGroups.MergeFrom(other.GetGroups);
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
				Types.ClearLayer clearLayer = new Types.ClearLayer();
				if (requestCase_ == RequestOneofCase.ClearLayer)
				{
					clearLayer.MergeFrom(ClearLayer);
				}
				input.ReadMessage(clearLayer);
				ClearLayer = clearLayer;
				break;
			}
			case 18u:
			{
				Types.CreateGroup createGroup = new Types.CreateGroup();
				if (requestCase_ == RequestOneofCase.CreateGroup)
				{
					createGroup.MergeFrom(CreateGroup);
				}
				input.ReadMessage(createGroup);
				CreateGroup = createGroup;
				break;
			}
			case 26u:
			{
				Types.GetGroup getGroup = new Types.GetGroup();
				if (requestCase_ == RequestOneofCase.GetGroup)
				{
					getGroup.MergeFrom(GetGroup);
				}
				input.ReadMessage(getGroup);
				GetGroup = getGroup;
				break;
			}
			case 34u:
			{
				Types.PutGroup putGroup = new Types.PutGroup();
				if (requestCase_ == RequestOneofCase.PutGroup)
				{
					putGroup.MergeFrom(PutGroup);
				}
				input.ReadMessage(putGroup);
				PutGroup = putGroup;
				break;
			}
			case 42u:
			{
				Types.GetGroupIcon getGroupIcon = new Types.GetGroupIcon();
				if (requestCase_ == RequestOneofCase.GetGroupIcon)
				{
					getGroupIcon.MergeFrom(GetGroupIcon);
				}
				input.ReadMessage(getGroupIcon);
				GetGroupIcon = getGroupIcon;
				break;
			}
			case 50u:
			{
				Types.PutGroupIcon putGroupIcon = new Types.PutGroupIcon();
				if (requestCase_ == RequestOneofCase.PutGroupIcon)
				{
					putGroupIcon.MergeFrom(PutGroupIcon);
				}
				input.ReadMessage(putGroupIcon);
				PutGroupIcon = putGroupIcon;
				break;
			}
			case 58u:
			{
				Types.DeleteGroup deleteGroup = new Types.DeleteGroup();
				if (requestCase_ == RequestOneofCase.DeleteGroup)
				{
					deleteGroup.MergeFrom(DeleteGroup);
				}
				input.ReadMessage(deleteGroup);
				DeleteGroup = deleteGroup;
				break;
			}
			case 66u:
			{
				Types.TriggerGroup triggerGroup = new Types.TriggerGroup();
				if (requestCase_ == RequestOneofCase.TriggerGroup)
				{
					triggerGroup.MergeFrom(TriggerGroup);
				}
				input.ReadMessage(triggerGroup);
				TriggerGroup = triggerGroup;
				break;
			}
			case 74u:
			{
				Types.GetGroups getGroups = new Types.GetGroups();
				if (requestCase_ == RequestOneofCase.GetGroups)
				{
					getGroups.MergeFrom(GetGroups);
				}
				input.ReadMessage(getGroups);
				GetGroups = getGroups;
				break;
			}
			}
		}
	}
}
