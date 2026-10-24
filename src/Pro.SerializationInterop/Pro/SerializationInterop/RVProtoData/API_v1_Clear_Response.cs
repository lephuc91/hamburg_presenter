using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Clear_Response : IMessage<API_v1_Clear_Response>, IMessage, IEquatable<API_v1_Clear_Response>, IDeepCloneable<API_v1_Clear_Response>
{
	public enum ResponseOneofCase
	{
		None,
		ClearLayer,
		CreateGroup,
		GetGroup,
		PutGroup,
		DeleteGroup,
		TriggerGroup,
		GetGroups,
		GetGroupIcon,
		PutGroupIcon
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearLayer> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(ClearLayer other)
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
		public sealed class PutGroup : IMessage<PutGroup>, IMessage, IEquatable<PutGroup>, IDeepCloneable<PutGroup>
		{
			private static readonly MessageParser<PutGroup> _parser = new MessageParser<PutGroup>(() => new PutGroup());

			private UnknownFieldSet _unknownFields;

			public const int GroupFieldNumber = 1;

			private API_v1_ClearGroup group_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[1];

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
			public PutGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutGroup(PutGroup other)
				: this()
			{
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
			public void MergeFrom(PutGroup other)
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
		public sealed class DeleteGroup : IMessage<DeleteGroup>, IMessage, IEquatable<DeleteGroup>, IDeepCloneable<DeleteGroup>
		{
			private static readonly MessageParser<DeleteGroup> _parser = new MessageParser<DeleteGroup>(() => new DeleteGroup());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(DeleteGroup other)
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
		public sealed class TriggerGroup : IMessage<TriggerGroup>, IMessage, IEquatable<TriggerGroup>, IDeepCloneable<TriggerGroup>
		{
			private static readonly MessageParser<TriggerGroup> _parser = new MessageParser<TriggerGroup>(() => new TriggerGroup());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(TriggerGroup other)
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
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[4];

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

			public const int GroupFieldNumber = 1;

			private API_v1_ClearGroup group_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[5];

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
			public GetGroup()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroup(GetGroup other)
				: this()
			{
				group_ = ((other.group_ != null) ? other.group_.Clone() : null);
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
			public void MergeFrom(GetGroup other)
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
		public sealed class GetGroups : IMessage<GetGroups>, IMessage, IEquatable<GetGroups>, IDeepCloneable<GetGroups>
		{
			private static readonly MessageParser<GetGroups> _parser = new MessageParser<GetGroups>(() => new GetGroups());

			private UnknownFieldSet _unknownFields;

			public const int GroupsFieldNumber = 1;

			private static readonly FieldCodec<API_v1_ClearGroup> _repeated_groups_codec = FieldCodec.ForMessage(10u, API_v1_ClearGroup.Parser);

			private readonly RepeatedField<API_v1_ClearGroup> groups_ = new RepeatedField<API_v1_ClearGroup>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetGroups> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_ClearGroup> Groups => groups_;

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
				groups_ = other.groups_.Clone();
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
				if (!groups_.Equals(other.groups_))
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
				num ^= groups_.GetHashCode();
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
				groups_.WriteTo(output, _repeated_groups_codec);
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
				num += groups_.CalculateSize(_repeated_groups_codec);
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
					groups_.Add(other.groups_);
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
						groups_.AddEntriesFrom(input, _repeated_groups_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetGroupIcon : IMessage<GetGroupIcon>, IMessage, IEquatable<GetGroupIcon>, IDeepCloneable<GetGroupIcon>
		{
			private static readonly MessageParser<GetGroupIcon> _parser = new MessageParser<GetGroupIcon>(() => new GetGroupIcon());

			private UnknownFieldSet _unknownFields;

			public const int ContentTypeFieldNumber = 1;

			private string contentType_ = "";

			public const int IconFieldNumber = 2;

			private ByteString icon_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetGroupIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public GetGroupIcon()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetGroupIcon(GetGroupIcon other)
				: this()
			{
				contentType_ = other.contentType_;
				icon_ = other.icon_;
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
				if (ContentType.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(ContentType);
				}
				if (Icon.Length != 0)
				{
					output.WriteRawTag(18);
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
			public void MergeFrom(GetGroupIcon other)
			{
				if (other != null)
				{
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
						ContentType = input.ReadString();
						break;
					case 18u:
						Icon = input.ReadBytes();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutGroupIcon : IMessage<PutGroupIcon>, IMessage, IEquatable<PutGroupIcon>, IDeepCloneable<PutGroupIcon>
		{
			private static readonly MessageParser<PutGroupIcon> _parser = new MessageParser<PutGroupIcon>(() => new PutGroupIcon());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutGroupIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Clear_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(PutGroupIcon other)
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

	private static readonly MessageParser<API_v1_Clear_Response> _parser = new MessageParser<API_v1_Clear_Response>(() => new API_v1_Clear_Response());

	private UnknownFieldSet _unknownFields;

	public const int ClearLayerFieldNumber = 1;

	public const int CreateGroupFieldNumber = 2;

	public const int GetGroupFieldNumber = 3;

	public const int PutGroupFieldNumber = 4;

	public const int DeleteGroupFieldNumber = 5;

	public const int TriggerGroupFieldNumber = 6;

	public const int GetGroupsFieldNumber = 7;

	public const int GetGroupIconFieldNumber = 8;

	public const int PutGroupIconFieldNumber = 9;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Clear_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1ClearReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearLayer ClearLayer
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ClearLayer)
			{
				return null;
			}
			return (Types.ClearLayer)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ClearLayer : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateGroup CreateGroup
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.CreateGroup)
			{
				return null;
			}
			return (Types.CreateGroup)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.CreateGroup : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetGroup GetGroup
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetGroup)
			{
				return null;
			}
			return (Types.GetGroup)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetGroup : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutGroup PutGroup
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutGroup)
			{
				return null;
			}
			return (Types.PutGroup)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutGroup : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteGroup DeleteGroup
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteGroup)
			{
				return null;
			}
			return (Types.DeleteGroup)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteGroup : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerGroup TriggerGroup
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TriggerGroup)
			{
				return null;
			}
			return (Types.TriggerGroup)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TriggerGroup : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetGroups GetGroups
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetGroups)
			{
				return null;
			}
			return (Types.GetGroups)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetGroups : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetGroupIcon GetGroupIcon
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetGroupIcon)
			{
				return null;
			}
			return (Types.GetGroupIcon)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetGroupIcon : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutGroupIcon PutGroupIcon
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutGroupIcon)
			{
				return null;
			}
			return (Types.PutGroupIcon)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutGroupIcon : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Clear_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Clear_Response(API_v1_Clear_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.ClearLayer:
			ClearLayer = other.ClearLayer.Clone();
			break;
		case ResponseOneofCase.CreateGroup:
			CreateGroup = other.CreateGroup.Clone();
			break;
		case ResponseOneofCase.GetGroup:
			GetGroup = other.GetGroup.Clone();
			break;
		case ResponseOneofCase.PutGroup:
			PutGroup = other.PutGroup.Clone();
			break;
		case ResponseOneofCase.DeleteGroup:
			DeleteGroup = other.DeleteGroup.Clone();
			break;
		case ResponseOneofCase.TriggerGroup:
			TriggerGroup = other.TriggerGroup.Clone();
			break;
		case ResponseOneofCase.GetGroups:
			GetGroups = other.GetGroups.Clone();
			break;
		case ResponseOneofCase.GetGroupIcon:
			GetGroupIcon = other.GetGroupIcon.Clone();
			break;
		case ResponseOneofCase.PutGroupIcon:
			PutGroupIcon = other.PutGroupIcon.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Clear_Response Clone()
	{
		return new API_v1_Clear_Response(this);
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
		return Equals(other as API_v1_Clear_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Clear_Response other)
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
		if (!object.Equals(GetGroupIcon, other.GetGroupIcon))
		{
			return false;
		}
		if (!object.Equals(PutGroupIcon, other.PutGroupIcon))
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
		if (responseCase_ == ResponseOneofCase.ClearLayer)
		{
			num ^= ClearLayer.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.CreateGroup)
		{
			num ^= CreateGroup.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetGroup)
		{
			num ^= GetGroup.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutGroup)
		{
			num ^= PutGroup.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteGroup)
		{
			num ^= DeleteGroup.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerGroup)
		{
			num ^= TriggerGroup.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetGroups)
		{
			num ^= GetGroups.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetGroupIcon)
		{
			num ^= GetGroupIcon.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutGroupIcon)
		{
			num ^= PutGroupIcon.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.ClearLayer)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ClearLayer);
		}
		if (responseCase_ == ResponseOneofCase.CreateGroup)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateGroup);
		}
		if (responseCase_ == ResponseOneofCase.GetGroup)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetGroup);
		}
		if (responseCase_ == ResponseOneofCase.PutGroup)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutGroup);
		}
		if (responseCase_ == ResponseOneofCase.DeleteGroup)
		{
			output.WriteRawTag(42);
			output.WriteMessage(DeleteGroup);
		}
		if (responseCase_ == ResponseOneofCase.TriggerGroup)
		{
			output.WriteRawTag(50);
			output.WriteMessage(TriggerGroup);
		}
		if (responseCase_ == ResponseOneofCase.GetGroups)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetGroups);
		}
		if (responseCase_ == ResponseOneofCase.GetGroupIcon)
		{
			output.WriteRawTag(66);
			output.WriteMessage(GetGroupIcon);
		}
		if (responseCase_ == ResponseOneofCase.PutGroupIcon)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PutGroupIcon);
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
		if (responseCase_ == ResponseOneofCase.ClearLayer)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ClearLayer);
		}
		if (responseCase_ == ResponseOneofCase.CreateGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateGroup);
		}
		if (responseCase_ == ResponseOneofCase.GetGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetGroup);
		}
		if (responseCase_ == ResponseOneofCase.PutGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutGroup);
		}
		if (responseCase_ == ResponseOneofCase.DeleteGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteGroup);
		}
		if (responseCase_ == ResponseOneofCase.TriggerGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerGroup);
		}
		if (responseCase_ == ResponseOneofCase.GetGroups)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetGroups);
		}
		if (responseCase_ == ResponseOneofCase.GetGroupIcon)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetGroupIcon);
		}
		if (responseCase_ == ResponseOneofCase.PutGroupIcon)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutGroupIcon);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Clear_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.ClearLayer:
			if (ClearLayer == null)
			{
				ClearLayer = new Types.ClearLayer();
			}
			ClearLayer.MergeFrom(other.ClearLayer);
			break;
		case ResponseOneofCase.CreateGroup:
			if (CreateGroup == null)
			{
				CreateGroup = new Types.CreateGroup();
			}
			CreateGroup.MergeFrom(other.CreateGroup);
			break;
		case ResponseOneofCase.GetGroup:
			if (GetGroup == null)
			{
				GetGroup = new Types.GetGroup();
			}
			GetGroup.MergeFrom(other.GetGroup);
			break;
		case ResponseOneofCase.PutGroup:
			if (PutGroup == null)
			{
				PutGroup = new Types.PutGroup();
			}
			PutGroup.MergeFrom(other.PutGroup);
			break;
		case ResponseOneofCase.DeleteGroup:
			if (DeleteGroup == null)
			{
				DeleteGroup = new Types.DeleteGroup();
			}
			DeleteGroup.MergeFrom(other.DeleteGroup);
			break;
		case ResponseOneofCase.TriggerGroup:
			if (TriggerGroup == null)
			{
				TriggerGroup = new Types.TriggerGroup();
			}
			TriggerGroup.MergeFrom(other.TriggerGroup);
			break;
		case ResponseOneofCase.GetGroups:
			if (GetGroups == null)
			{
				GetGroups = new Types.GetGroups();
			}
			GetGroups.MergeFrom(other.GetGroups);
			break;
		case ResponseOneofCase.GetGroupIcon:
			if (GetGroupIcon == null)
			{
				GetGroupIcon = new Types.GetGroupIcon();
			}
			GetGroupIcon.MergeFrom(other.GetGroupIcon);
			break;
		case ResponseOneofCase.PutGroupIcon:
			if (PutGroupIcon == null)
			{
				PutGroupIcon = new Types.PutGroupIcon();
			}
			PutGroupIcon.MergeFrom(other.PutGroupIcon);
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
				if (responseCase_ == ResponseOneofCase.ClearLayer)
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
				if (responseCase_ == ResponseOneofCase.CreateGroup)
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
				if (responseCase_ == ResponseOneofCase.GetGroup)
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
				if (responseCase_ == ResponseOneofCase.PutGroup)
				{
					putGroup.MergeFrom(PutGroup);
				}
				input.ReadMessage(putGroup);
				PutGroup = putGroup;
				break;
			}
			case 42u:
			{
				Types.DeleteGroup deleteGroup = new Types.DeleteGroup();
				if (responseCase_ == ResponseOneofCase.DeleteGroup)
				{
					deleteGroup.MergeFrom(DeleteGroup);
				}
				input.ReadMessage(deleteGroup);
				DeleteGroup = deleteGroup;
				break;
			}
			case 50u:
			{
				Types.TriggerGroup triggerGroup = new Types.TriggerGroup();
				if (responseCase_ == ResponseOneofCase.TriggerGroup)
				{
					triggerGroup.MergeFrom(TriggerGroup);
				}
				input.ReadMessage(triggerGroup);
				TriggerGroup = triggerGroup;
				break;
			}
			case 58u:
			{
				Types.GetGroups getGroups = new Types.GetGroups();
				if (responseCase_ == ResponseOneofCase.GetGroups)
				{
					getGroups.MergeFrom(GetGroups);
				}
				input.ReadMessage(getGroups);
				GetGroups = getGroups;
				break;
			}
			case 66u:
			{
				Types.GetGroupIcon getGroupIcon = new Types.GetGroupIcon();
				if (responseCase_ == ResponseOneofCase.GetGroupIcon)
				{
					getGroupIcon.MergeFrom(GetGroupIcon);
				}
				input.ReadMessage(getGroupIcon);
				GetGroupIcon = getGroupIcon;
				break;
			}
			case 74u:
			{
				Types.PutGroupIcon putGroupIcon = new Types.PutGroupIcon();
				if (responseCase_ == ResponseOneofCase.PutGroupIcon)
				{
					putGroupIcon.MergeFrom(PutGroupIcon);
				}
				input.ReadMessage(putGroupIcon);
				PutGroupIcon = putGroupIcon;
				break;
			}
			}
		}
	}
}
