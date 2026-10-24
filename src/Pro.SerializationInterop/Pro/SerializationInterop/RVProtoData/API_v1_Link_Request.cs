using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Link_Request : IMessage<API_v1_Link_Request>, IMessage, IEquatable<API_v1_Link_Request>, IDeepCloneable<API_v1_Link_Request>
{
	public enum RequestOneofCase
	{
		None,
		Heartbeat,
		Status,
		AddMember,
		RemoveMember
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Heartbeat : IMessage<Heartbeat>, IMessage, IEquatable<Heartbeat>, IDeepCloneable<Heartbeat>
		{
			private static readonly MessageParser<Heartbeat> _parser = new MessageParser<Heartbeat>(() => new Heartbeat());

			private UnknownFieldSet _unknownFields;

			public const int PortFieldNumber = 1;

			private uint port_;

			public const int IfModifiedSinceFieldNumber = 2;

			private string ifModifiedSince_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Heartbeat> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Port
			{
				get
				{
					return port_;
				}
				set
				{
					port_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string IfModifiedSince
			{
				get
				{
					return ifModifiedSince_;
				}
				set
				{
					ifModifiedSince_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Heartbeat()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Heartbeat(Heartbeat other)
				: this()
			{
				port_ = other.port_;
				ifModifiedSince_ = other.ifModifiedSince_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Heartbeat Clone()
			{
				return new Heartbeat(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Heartbeat);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Heartbeat other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Port != other.Port)
				{
					return false;
				}
				if (IfModifiedSince != other.IfModifiedSince)
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
				if (Port != 0)
				{
					num ^= Port.GetHashCode();
				}
				if (IfModifiedSince.Length != 0)
				{
					num ^= IfModifiedSince.GetHashCode();
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
				if (Port != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Port);
				}
				if (IfModifiedSince.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(IfModifiedSince);
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
				if (Port != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Port);
				}
				if (IfModifiedSince.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(IfModifiedSince);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Heartbeat other)
			{
				if (other != null)
				{
					if (other.Port != 0)
					{
						Port = other.Port;
					}
					if (other.IfModifiedSince.Length != 0)
					{
						IfModifiedSince = other.IfModifiedSince;
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
						Port = input.ReadUInt32();
						break;
					case 18u:
						IfModifiedSince = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Status : IMessage<Status>, IMessage, IEquatable<Status>, IDeepCloneable<Status>
		{
			private static readonly MessageParser<Status> _parser = new MessageParser<Status>(() => new Status());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Status> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status(Status other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status Clone()
			{
				return new Status(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Status);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Status other)
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
			public void MergeFrom(Status other)
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
		public sealed class AddMember : IMessage<AddMember>, IMessage, IEquatable<AddMember>, IDeepCloneable<AddMember>
		{
			public enum AddTypeOneofCase
			{
				None,
				GroupDefinition,
				MemberDetails
			}

			private static readonly MessageParser<AddMember> _parser = new MessageParser<AddMember>(() => new AddMember());

			private UnknownFieldSet _unknownFields;

			public const int GroupDefinitionFieldNumber = 1;

			public const int MemberDetailsFieldNumber = 2;

			private object addType_;

			private AddTypeOneofCase addTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AddMember> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_GroupDefinition GroupDefinition
			{
				get
				{
					if (addTypeCase_ != AddTypeOneofCase.GroupDefinition)
					{
						return null;
					}
					return (API_v1_GroupDefinition)addType_;
				}
				set
				{
					addType_ = value;
					addTypeCase_ = ((value != null) ? AddTypeOneofCase.GroupDefinition : AddTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_GroupMember MemberDetails
			{
				get
				{
					if (addTypeCase_ != AddTypeOneofCase.MemberDetails)
					{
						return null;
					}
					return (API_v1_GroupMember)addType_;
				}
				set
				{
					addType_ = value;
					addTypeCase_ = ((value != null) ? AddTypeOneofCase.MemberDetails : AddTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AddTypeOneofCase AddTypeCase => addTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AddMember()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AddMember(AddMember other)
				: this()
			{
				switch (other.AddTypeCase)
				{
				case AddTypeOneofCase.GroupDefinition:
					GroupDefinition = other.GroupDefinition.Clone();
					break;
				case AddTypeOneofCase.MemberDetails:
					MemberDetails = other.MemberDetails.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AddMember Clone()
			{
				return new AddMember(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearAddType()
			{
				addTypeCase_ = AddTypeOneofCase.None;
				addType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AddMember);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AddMember other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(GroupDefinition, other.GroupDefinition))
				{
					return false;
				}
				if (!object.Equals(MemberDetails, other.MemberDetails))
				{
					return false;
				}
				if (AddTypeCase != other.AddTypeCase)
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
				if (addTypeCase_ == AddTypeOneofCase.GroupDefinition)
				{
					num ^= GroupDefinition.GetHashCode();
				}
				if (addTypeCase_ == AddTypeOneofCase.MemberDetails)
				{
					num ^= MemberDetails.GetHashCode();
				}
				num ^= (int)addTypeCase_;
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
				if (addTypeCase_ == AddTypeOneofCase.GroupDefinition)
				{
					output.WriteRawTag(10);
					output.WriteMessage(GroupDefinition);
				}
				if (addTypeCase_ == AddTypeOneofCase.MemberDetails)
				{
					output.WriteRawTag(18);
					output.WriteMessage(MemberDetails);
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
				if (addTypeCase_ == AddTypeOneofCase.GroupDefinition)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
				}
				if (addTypeCase_ == AddTypeOneofCase.MemberDetails)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MemberDetails);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AddMember other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.AddTypeCase)
				{
				case AddTypeOneofCase.GroupDefinition:
					if (GroupDefinition == null)
					{
						GroupDefinition = new API_v1_GroupDefinition();
					}
					GroupDefinition.MergeFrom(other.GroupDefinition);
					break;
				case AddTypeOneofCase.MemberDetails:
					if (MemberDetails == null)
					{
						MemberDetails = new API_v1_GroupMember();
					}
					MemberDetails.MergeFrom(other.MemberDetails);
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
						API_v1_GroupDefinition aPI_v1_GroupDefinition = new API_v1_GroupDefinition();
						if (addTypeCase_ == AddTypeOneofCase.GroupDefinition)
						{
							aPI_v1_GroupDefinition.MergeFrom(GroupDefinition);
						}
						input.ReadMessage(aPI_v1_GroupDefinition);
						GroupDefinition = aPI_v1_GroupDefinition;
						break;
					}
					case 18u:
					{
						API_v1_GroupMember aPI_v1_GroupMember = new API_v1_GroupMember();
						if (addTypeCase_ == AddTypeOneofCase.MemberDetails)
						{
							aPI_v1_GroupMember.MergeFrom(MemberDetails);
						}
						input.ReadMessage(aPI_v1_GroupMember);
						MemberDetails = aPI_v1_GroupMember;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class RemoveMember : IMessage<RemoveMember>, IMessage, IEquatable<RemoveMember>, IDeepCloneable<RemoveMember>
		{
			private static readonly MessageParser<RemoveMember> _parser = new MessageParser<RemoveMember>(() => new RemoveMember());

			private UnknownFieldSet _unknownFields;

			public const int MemberDetailsFieldNumber = 1;

			private API_v1_GroupMember memberDetails_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<RemoveMember> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_GroupMember MemberDetails
			{
				get
				{
					return memberDetails_;
				}
				set
				{
					memberDetails_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoveMember()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoveMember(RemoveMember other)
				: this()
			{
				memberDetails_ = ((other.memberDetails_ != null) ? other.memberDetails_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoveMember Clone()
			{
				return new RemoveMember(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as RemoveMember);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(RemoveMember other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(MemberDetails, other.MemberDetails))
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
				if (memberDetails_ != null)
				{
					num ^= MemberDetails.GetHashCode();
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
				if (memberDetails_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(MemberDetails);
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
				if (memberDetails_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MemberDetails);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(RemoveMember other)
			{
				if (other == null)
				{
					return;
				}
				if (other.memberDetails_ != null)
				{
					if (memberDetails_ == null)
					{
						MemberDetails = new API_v1_GroupMember();
					}
					MemberDetails.MergeFrom(other.MemberDetails);
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
					if (memberDetails_ == null)
					{
						MemberDetails = new API_v1_GroupMember();
					}
					input.ReadMessage(MemberDetails);
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Link_Request> _parser = new MessageParser<API_v1_Link_Request>(() => new API_v1_Link_Request());

	private UnknownFieldSet _unknownFields;

	public const int HeartbeatFieldNumber = 1;

	public const int StatusFieldNumber = 2;

	public const int AddMemberFieldNumber = 3;

	public const int RemoveMemberFieldNumber = 4;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Link_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LinkReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Heartbeat Heartbeat
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Heartbeat)
			{
				return null;
			}
			return (Types.Heartbeat)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Heartbeat : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Status Status
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Status)
			{
				return null;
			}
			return (Types.Status)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Status : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AddMember AddMember
	{
		get
		{
			if (requestCase_ != RequestOneofCase.AddMember)
			{
				return null;
			}
			return (Types.AddMember)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.AddMember : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.RemoveMember RemoveMember
	{
		get
		{
			if (requestCase_ != RequestOneofCase.RemoveMember)
			{
				return null;
			}
			return (Types.RemoveMember)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.RemoveMember : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Link_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Link_Request(API_v1_Link_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Heartbeat:
			Heartbeat = other.Heartbeat.Clone();
			break;
		case RequestOneofCase.Status:
			Status = other.Status.Clone();
			break;
		case RequestOneofCase.AddMember:
			AddMember = other.AddMember.Clone();
			break;
		case RequestOneofCase.RemoveMember:
			RemoveMember = other.RemoveMember.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Link_Request Clone()
	{
		return new API_v1_Link_Request(this);
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
		return Equals(other as API_v1_Link_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Link_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Heartbeat, other.Heartbeat))
		{
			return false;
		}
		if (!object.Equals(Status, other.Status))
		{
			return false;
		}
		if (!object.Equals(AddMember, other.AddMember))
		{
			return false;
		}
		if (!object.Equals(RemoveMember, other.RemoveMember))
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
		if (requestCase_ == RequestOneofCase.Heartbeat)
		{
			num ^= Heartbeat.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Status)
		{
			num ^= Status.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.AddMember)
		{
			num ^= AddMember.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.RemoveMember)
		{
			num ^= RemoveMember.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.Heartbeat)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Heartbeat);
		}
		if (requestCase_ == RequestOneofCase.Status)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Status);
		}
		if (requestCase_ == RequestOneofCase.AddMember)
		{
			output.WriteRawTag(26);
			output.WriteMessage(AddMember);
		}
		if (requestCase_ == RequestOneofCase.RemoveMember)
		{
			output.WriteRawTag(34);
			output.WriteMessage(RemoveMember);
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
		if (requestCase_ == RequestOneofCase.Heartbeat)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Heartbeat);
		}
		if (requestCase_ == RequestOneofCase.Status)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Status);
		}
		if (requestCase_ == RequestOneofCase.AddMember)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AddMember);
		}
		if (requestCase_ == RequestOneofCase.RemoveMember)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RemoveMember);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Link_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Heartbeat:
			if (Heartbeat == null)
			{
				Heartbeat = new Types.Heartbeat();
			}
			Heartbeat.MergeFrom(other.Heartbeat);
			break;
		case RequestOneofCase.Status:
			if (Status == null)
			{
				Status = new Types.Status();
			}
			Status.MergeFrom(other.Status);
			break;
		case RequestOneofCase.AddMember:
			if (AddMember == null)
			{
				AddMember = new Types.AddMember();
			}
			AddMember.MergeFrom(other.AddMember);
			break;
		case RequestOneofCase.RemoveMember:
			if (RemoveMember == null)
			{
				RemoveMember = new Types.RemoveMember();
			}
			RemoveMember.MergeFrom(other.RemoveMember);
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
				Types.Heartbeat heartbeat = new Types.Heartbeat();
				if (requestCase_ == RequestOneofCase.Heartbeat)
				{
					heartbeat.MergeFrom(Heartbeat);
				}
				input.ReadMessage(heartbeat);
				Heartbeat = heartbeat;
				break;
			}
			case 18u:
			{
				Types.Status status = new Types.Status();
				if (requestCase_ == RequestOneofCase.Status)
				{
					status.MergeFrom(Status);
				}
				input.ReadMessage(status);
				Status = status;
				break;
			}
			case 26u:
			{
				Types.AddMember addMember = new Types.AddMember();
				if (requestCase_ == RequestOneofCase.AddMember)
				{
					addMember.MergeFrom(AddMember);
				}
				input.ReadMessage(addMember);
				AddMember = addMember;
				break;
			}
			case 34u:
			{
				Types.RemoveMember removeMember = new Types.RemoveMember();
				if (requestCase_ == RequestOneofCase.RemoveMember)
				{
					removeMember.MergeFrom(RemoveMember);
				}
				input.ReadMessage(removeMember);
				RemoveMember = removeMember;
				break;
			}
			}
		}
	}
}
