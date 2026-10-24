using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Groups_Response : IMessage<API_v1_Groups_Response>, IMessage, IEquatable<API_v1_Groups_Response>, IDeepCloneable<API_v1_Groups_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Groups,
		TriggerGroup
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GroupsRequest : IMessage<GroupsRequest>, IMessage, IEquatable<GroupsRequest>, IDeepCloneable<GroupsRequest>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Group : IMessage<Group>, IMessage, IEquatable<Group>, IDeepCloneable<Group>
				{
					private static readonly MessageParser<Group> _parser = new MessageParser<Group>(() => new Group());

					private UnknownFieldSet _unknownFields;

					public const int IdFieldNumber = 1;

					private API_v1_Identifier id_;

					public const int ColorFieldNumber = 2;

					private API_v1_Color color_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Group> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => GroupsRequest.Descriptor.NestedTypes[0];

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
					public API_v1_Color Color
					{
						get
						{
							return color_;
						}
						set
						{
							color_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Group()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Group(Group other)
						: this()
					{
						id_ = ((other.id_ != null) ? other.id_.Clone() : null);
						color_ = ((other.color_ != null) ? other.color_.Clone() : null);
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Group Clone()
					{
						return new Group(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Group);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Group other)
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
						if (!object.Equals(Color, other.Color))
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
						if (color_ != null)
						{
							num ^= Color.GetHashCode();
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
						if (color_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Color);
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
						if (color_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Color);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Group other)
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
						if (other.color_ != null)
						{
							if (color_ == null)
							{
								Color = new API_v1_Color();
							}
							Color.MergeFrom(other.Color);
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
								if (id_ == null)
								{
									Id = new API_v1_Identifier();
								}
								input.ReadMessage(Id);
								break;
							case 18u:
								if (color_ == null)
								{
									Color = new API_v1_Color();
								}
								input.ReadMessage(Color);
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<GroupsRequest> _parser = new MessageParser<GroupsRequest>(() => new GroupsRequest());

			private UnknownFieldSet _unknownFields;

			public const int GroupsFieldNumber = 1;

			private static readonly FieldCodec<Types.Group> _repeated_groups_codec = FieldCodec.ForMessage(10u, Types.Group.Parser);

			private readonly RepeatedField<Types.Group> groups_ = new RepeatedField<Types.Group>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GroupsRequest> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Groups_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.Group> Groups => groups_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupsRequest()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupsRequest(GroupsRequest other)
				: this()
			{
				groups_ = other.groups_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GroupsRequest Clone()
			{
				return new GroupsRequest(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GroupsRequest);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GroupsRequest other)
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
			public void MergeFrom(GroupsRequest other)
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
		public sealed class TriggerGroup : IMessage<TriggerGroup>, IMessage, IEquatable<TriggerGroup>, IDeepCloneable<TriggerGroup>
		{
			private static readonly MessageParser<TriggerGroup> _parser = new MessageParser<TriggerGroup>(() => new TriggerGroup());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerGroup> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Groups_Response.Descriptor.NestedTypes[1];

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
	}

	private static readonly MessageParser<API_v1_Groups_Response> _parser = new MessageParser<API_v1_Groups_Response>(() => new API_v1_Groups_Response());

	private UnknownFieldSet _unknownFields;

	public const int GroupsFieldNumber = 1;

	public const int TriggerGroupFieldNumber = 2;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Groups_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1GroupsReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GroupsRequest Groups
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Groups)
			{
				return null;
			}
			return (Types.GroupsRequest)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Groups : ResponseOneofCase.None);
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
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Groups_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Groups_Response(API_v1_Groups_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Groups:
			Groups = other.Groups.Clone();
			break;
		case ResponseOneofCase.TriggerGroup:
			TriggerGroup = other.TriggerGroup.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Groups_Response Clone()
	{
		return new API_v1_Groups_Response(this);
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
		return Equals(other as API_v1_Groups_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Groups_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Groups, other.Groups))
		{
			return false;
		}
		if (!object.Equals(TriggerGroup, other.TriggerGroup))
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
		if (responseCase_ == ResponseOneofCase.Groups)
		{
			num ^= Groups.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerGroup)
		{
			num ^= TriggerGroup.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Groups)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Groups);
		}
		if (responseCase_ == ResponseOneofCase.TriggerGroup)
		{
			output.WriteRawTag(18);
			output.WriteMessage(TriggerGroup);
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
		if (responseCase_ == ResponseOneofCase.Groups)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Groups);
		}
		if (responseCase_ == ResponseOneofCase.TriggerGroup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerGroup);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Groups_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Groups:
			if (Groups == null)
			{
				Groups = new Types.GroupsRequest();
			}
			Groups.MergeFrom(other.Groups);
			break;
		case ResponseOneofCase.TriggerGroup:
			if (TriggerGroup == null)
			{
				TriggerGroup = new Types.TriggerGroup();
			}
			TriggerGroup.MergeFrom(other.TriggerGroup);
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
				Types.GroupsRequest groupsRequest = new Types.GroupsRequest();
				if (responseCase_ == ResponseOneofCase.Groups)
				{
					groupsRequest.MergeFrom(Groups);
				}
				input.ReadMessage(groupsRequest);
				Groups = groupsRequest;
				break;
			}
			case 18u:
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
			}
		}
	}
}
