using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Link_Response : IMessage<API_v1_Link_Response>, IMessage, IEquatable<API_v1_Link_Response>, IDeepCloneable<API_v1_Link_Response>
{
	public enum ResponseOneofCase
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

			public const int GroupDefinitionFieldNumber = 1;

			private API_v1_GroupDefinition groupDefinition_;

			public const int StatusFieldNumber = 2;

			private API_v1_GroupMemberStatus status_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Heartbeat> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_GroupDefinition GroupDefinition
			{
				get
				{
					return groupDefinition_;
				}
				set
				{
					groupDefinition_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_GroupMemberStatus Status
			{
				get
				{
					return status_;
				}
				set
				{
					status_ = value;
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
				groupDefinition_ = ((other.groupDefinition_ != null) ? other.groupDefinition_.Clone() : null);
				status_ = ((other.status_ != null) ? other.status_.Clone() : null);
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
				if (!object.Equals(GroupDefinition, other.GroupDefinition))
				{
					return false;
				}
				if (!object.Equals(Status, other.Status))
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
				if (groupDefinition_ != null)
				{
					num ^= GroupDefinition.GetHashCode();
				}
				if (status_ != null)
				{
					num ^= Status.GetHashCode();
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
				if (groupDefinition_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(GroupDefinition);
				}
				if (status_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Status);
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
				if (groupDefinition_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
				}
				if (status_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Status);
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
				if (other == null)
				{
					return;
				}
				if (other.groupDefinition_ != null)
				{
					if (groupDefinition_ == null)
					{
						GroupDefinition = new API_v1_GroupDefinition();
					}
					GroupDefinition.MergeFrom(other.GroupDefinition);
				}
				if (other.status_ != null)
				{
					if (status_ == null)
					{
						Status = new API_v1_GroupMemberStatus();
					}
					Status.MergeFrom(other.Status);
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
						if (groupDefinition_ == null)
						{
							GroupDefinition = new API_v1_GroupDefinition();
						}
						input.ReadMessage(GroupDefinition);
						break;
					case 18u:
						if (status_ == null)
						{
							Status = new API_v1_GroupMemberStatus();
						}
						input.ReadMessage(Status);
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

			public const int GroupDefinitionFieldNumber = 1;

			private API_v1_GroupDefinition groupDefinition_;

			public const int MemberNameFieldNumber = 2;

			private string memberName_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Status> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_GroupDefinition GroupDefinition
			{
				get
				{
					return groupDefinition_;
				}
				set
				{
					groupDefinition_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string MemberName
			{
				get
				{
					return memberName_;
				}
				set
				{
					memberName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				groupDefinition_ = ((other.groupDefinition_ != null) ? other.groupDefinition_.Clone() : null);
				memberName_ = other.memberName_;
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
				if (!object.Equals(GroupDefinition, other.GroupDefinition))
				{
					return false;
				}
				if (MemberName != other.MemberName)
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
				if (groupDefinition_ != null)
				{
					num ^= GroupDefinition.GetHashCode();
				}
				if (MemberName.Length != 0)
				{
					num ^= MemberName.GetHashCode();
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
				if (groupDefinition_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(GroupDefinition);
				}
				if (MemberName.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(MemberName);
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
				if (groupDefinition_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
				}
				if (MemberName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(MemberName);
				}
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
				if (other == null)
				{
					return;
				}
				if (other.groupDefinition_ != null)
				{
					if (groupDefinition_ == null)
					{
						GroupDefinition = new API_v1_GroupDefinition();
					}
					GroupDefinition.MergeFrom(other.GroupDefinition);
				}
				if (other.MemberName.Length != 0)
				{
					MemberName = other.MemberName;
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
						if (groupDefinition_ == null)
						{
							GroupDefinition = new API_v1_GroupDefinition();
						}
						input.ReadMessage(GroupDefinition);
						break;
					case 18u:
						MemberName = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AddMember : IMessage<AddMember>, IMessage, IEquatable<AddMember>, IDeepCloneable<AddMember>
		{
			public enum ResultOneofCase
			{
				None,
				GroupDefinition,
				Accept,
				Decline
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class RemoteMachineAccepts : IMessage<RemoteMachineAccepts>, IMessage, IEquatable<RemoteMachineAccepts>, IDeepCloneable<RemoteMachineAccepts>
				{
					private static readonly MessageParser<RemoteMachineAccepts> _parser = new MessageParser<RemoteMachineAccepts>(() => new RemoteMachineAccepts());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<RemoteMachineAccepts> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => AddMember.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoteMachineAccepts()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoteMachineAccepts(RemoteMachineAccepts other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoteMachineAccepts Clone()
					{
						return new RemoteMachineAccepts(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as RemoteMachineAccepts);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(RemoteMachineAccepts other)
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
					public void MergeFrom(RemoteMachineAccepts other)
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
				public sealed class RemoteMachineDecline : IMessage<RemoteMachineDecline>, IMessage, IEquatable<RemoteMachineDecline>, IDeepCloneable<RemoteMachineDecline>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum DeclineReason
						{
							[OriginalName("ALREADY_IN_GROUP")]
							AlreadyInGroup,
							[OriginalName("USER_DECLINED")]
							UserDeclined
						}
					}

					private static readonly MessageParser<RemoteMachineDecline> _parser = new MessageParser<RemoteMachineDecline>(() => new RemoteMachineDecline());

					private UnknownFieldSet _unknownFields;

					public const int ReasonFieldNumber = 1;

					private Types.DeclineReason reason_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<RemoteMachineDecline> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => AddMember.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.DeclineReason Reason
					{
						get
						{
							return reason_;
						}
						set
						{
							reason_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoteMachineDecline()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoteMachineDecline(RemoteMachineDecline other)
						: this()
					{
						reason_ = other.reason_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RemoteMachineDecline Clone()
					{
						return new RemoteMachineDecline(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as RemoteMachineDecline);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(RemoteMachineDecline other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Reason != other.Reason)
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
						if (Reason != 0)
						{
							num ^= Reason.GetHashCode();
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
						if (Reason != 0)
						{
							output.WriteRawTag(8);
							output.WriteEnum((int)Reason);
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
						if (Reason != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Reason);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(RemoteMachineDecline other)
					{
						if (other != null)
						{
							if (other.Reason != 0)
							{
								Reason = other.Reason;
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
								Reason = (Types.DeclineReason)input.ReadEnum();
							}
						}
					}
				}
			}

			private static readonly MessageParser<AddMember> _parser = new MessageParser<AddMember>(() => new AddMember());

			private UnknownFieldSet _unknownFields;

			public const int GroupDefinitionFieldNumber = 1;

			public const int AcceptFieldNumber = 2;

			public const int DeclineFieldNumber = 3;

			private object result_;

			private ResultOneofCase resultCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AddMember> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_GroupDefinition GroupDefinition
			{
				get
				{
					if (resultCase_ != ResultOneofCase.GroupDefinition)
					{
						return null;
					}
					return (API_v1_GroupDefinition)result_;
				}
				set
				{
					result_ = value;
					resultCase_ = ((value != null) ? ResultOneofCase.GroupDefinition : ResultOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.RemoteMachineAccepts Accept
			{
				get
				{
					if (resultCase_ != ResultOneofCase.Accept)
					{
						return null;
					}
					return (Types.RemoteMachineAccepts)result_;
				}
				set
				{
					result_ = value;
					resultCase_ = ((value != null) ? ResultOneofCase.Accept : ResultOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.RemoteMachineDecline Decline
			{
				get
				{
					if (resultCase_ != ResultOneofCase.Decline)
					{
						return null;
					}
					return (Types.RemoteMachineDecline)result_;
				}
				set
				{
					result_ = value;
					resultCase_ = ((value != null) ? ResultOneofCase.Decline : ResultOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResultOneofCase ResultCase => resultCase_;

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
				switch (other.ResultCase)
				{
				case ResultOneofCase.GroupDefinition:
					GroupDefinition = other.GroupDefinition.Clone();
					break;
				case ResultOneofCase.Accept:
					Accept = other.Accept.Clone();
					break;
				case ResultOneofCase.Decline:
					Decline = other.Decline.Clone();
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
			public void ClearResult()
			{
				resultCase_ = ResultOneofCase.None;
				result_ = null;
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
				if (!object.Equals(Accept, other.Accept))
				{
					return false;
				}
				if (!object.Equals(Decline, other.Decline))
				{
					return false;
				}
				if (ResultCase != other.ResultCase)
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
				if (resultCase_ == ResultOneofCase.GroupDefinition)
				{
					num ^= GroupDefinition.GetHashCode();
				}
				if (resultCase_ == ResultOneofCase.Accept)
				{
					num ^= Accept.GetHashCode();
				}
				if (resultCase_ == ResultOneofCase.Decline)
				{
					num ^= Decline.GetHashCode();
				}
				num ^= (int)resultCase_;
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
				if (resultCase_ == ResultOneofCase.GroupDefinition)
				{
					output.WriteRawTag(10);
					output.WriteMessage(GroupDefinition);
				}
				if (resultCase_ == ResultOneofCase.Accept)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Accept);
				}
				if (resultCase_ == ResultOneofCase.Decline)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Decline);
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
				if (resultCase_ == ResultOneofCase.GroupDefinition)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupDefinition);
				}
				if (resultCase_ == ResultOneofCase.Accept)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Accept);
				}
				if (resultCase_ == ResultOneofCase.Decline)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Decline);
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
				switch (other.ResultCase)
				{
				case ResultOneofCase.GroupDefinition:
					if (GroupDefinition == null)
					{
						GroupDefinition = new API_v1_GroupDefinition();
					}
					GroupDefinition.MergeFrom(other.GroupDefinition);
					break;
				case ResultOneofCase.Accept:
					if (Accept == null)
					{
						Accept = new Types.RemoteMachineAccepts();
					}
					Accept.MergeFrom(other.Accept);
					break;
				case ResultOneofCase.Decline:
					if (Decline == null)
					{
						Decline = new Types.RemoteMachineDecline();
					}
					Decline.MergeFrom(other.Decline);
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
						if (resultCase_ == ResultOneofCase.GroupDefinition)
						{
							aPI_v1_GroupDefinition.MergeFrom(GroupDefinition);
						}
						input.ReadMessage(aPI_v1_GroupDefinition);
						GroupDefinition = aPI_v1_GroupDefinition;
						break;
					}
					case 18u:
					{
						Types.RemoteMachineAccepts remoteMachineAccepts = new Types.RemoteMachineAccepts();
						if (resultCase_ == ResultOneofCase.Accept)
						{
							remoteMachineAccepts.MergeFrom(Accept);
						}
						input.ReadMessage(remoteMachineAccepts);
						Accept = remoteMachineAccepts;
						break;
					}
					case 26u:
					{
						Types.RemoteMachineDecline remoteMachineDecline = new Types.RemoteMachineDecline();
						if (resultCase_ == ResultOneofCase.Decline)
						{
							remoteMachineDecline.MergeFrom(Decline);
						}
						input.ReadMessage(remoteMachineDecline);
						Decline = remoteMachineDecline;
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<RemoveMember> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Link_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(RemoveMember other)
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

	private static readonly MessageParser<API_v1_Link_Response> _parser = new MessageParser<API_v1_Link_Response>(() => new API_v1_Link_Response());

	private UnknownFieldSet _unknownFields;

	public const int HeartbeatFieldNumber = 1;

	public const int StatusFieldNumber = 2;

	public const int AddMemberFieldNumber = 3;

	public const int RemoveMemberFieldNumber = 4;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Link_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LinkReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Heartbeat Heartbeat
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Heartbeat)
			{
				return null;
			}
			return (Types.Heartbeat)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Heartbeat : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Status Status
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Status)
			{
				return null;
			}
			return (Types.Status)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Status : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AddMember AddMember
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.AddMember)
			{
				return null;
			}
			return (Types.AddMember)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.AddMember : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.RemoveMember RemoveMember
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.RemoveMember)
			{
				return null;
			}
			return (Types.RemoveMember)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.RemoveMember : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Link_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Link_Response(API_v1_Link_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Heartbeat:
			Heartbeat = other.Heartbeat.Clone();
			break;
		case ResponseOneofCase.Status:
			Status = other.Status.Clone();
			break;
		case ResponseOneofCase.AddMember:
			AddMember = other.AddMember.Clone();
			break;
		case ResponseOneofCase.RemoveMember:
			RemoveMember = other.RemoveMember.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Link_Response Clone()
	{
		return new API_v1_Link_Response(this);
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
		return Equals(other as API_v1_Link_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Link_Response other)
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
		if (responseCase_ == ResponseOneofCase.Heartbeat)
		{
			num ^= Heartbeat.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Status)
		{
			num ^= Status.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.AddMember)
		{
			num ^= AddMember.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.RemoveMember)
		{
			num ^= RemoveMember.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Heartbeat)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Heartbeat);
		}
		if (responseCase_ == ResponseOneofCase.Status)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Status);
		}
		if (responseCase_ == ResponseOneofCase.AddMember)
		{
			output.WriteRawTag(26);
			output.WriteMessage(AddMember);
		}
		if (responseCase_ == ResponseOneofCase.RemoveMember)
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
		if (responseCase_ == ResponseOneofCase.Heartbeat)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Heartbeat);
		}
		if (responseCase_ == ResponseOneofCase.Status)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Status);
		}
		if (responseCase_ == ResponseOneofCase.AddMember)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AddMember);
		}
		if (responseCase_ == ResponseOneofCase.RemoveMember)
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
	public void MergeFrom(API_v1_Link_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Heartbeat:
			if (Heartbeat == null)
			{
				Heartbeat = new Types.Heartbeat();
			}
			Heartbeat.MergeFrom(other.Heartbeat);
			break;
		case ResponseOneofCase.Status:
			if (Status == null)
			{
				Status = new Types.Status();
			}
			Status.MergeFrom(other.Status);
			break;
		case ResponseOneofCase.AddMember:
			if (AddMember == null)
			{
				AddMember = new Types.AddMember();
			}
			AddMember.MergeFrom(other.AddMember);
			break;
		case ResponseOneofCase.RemoveMember:
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
				if (responseCase_ == ResponseOneofCase.Heartbeat)
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
				if (responseCase_ == ResponseOneofCase.Status)
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
				if (responseCase_ == ResponseOneofCase.AddMember)
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
				if (responseCase_ == ResponseOneofCase.RemoveMember)
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
