using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Notification : IMessage<Notification>, IMessage, IEquatable<Notification>, IDeepCloneable<Notification>
{
	public enum NotificationOneofCase
	{
		None,
		Unsubscribe,
		Workspaces,
		Collaborators,
		Syncing
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class UnsubscribeComplete : IMessage<UnsubscribeComplete>, IMessage, IEquatable<UnsubscribeComplete>, IDeepCloneable<UnsubscribeComplete>
		{
			private static readonly MessageParser<UnsubscribeComplete> _parser = new MessageParser<UnsubscribeComplete>(() => new UnsubscribeComplete());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<UnsubscribeComplete> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnsubscribeComplete()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnsubscribeComplete(UnsubscribeComplete other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UnsubscribeComplete Clone()
			{
				return new UnsubscribeComplete(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as UnsubscribeComplete);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(UnsubscribeComplete other)
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
			public void MergeFrom(UnsubscribeComplete other)
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
		public sealed class Workspaces : IMessage<Workspaces>, IMessage, IEquatable<Workspaces>, IDeepCloneable<Workspaces>
		{
			public enum StateOneofCase
			{
				None,
				Initialized,
				Uninitialized,
				Error
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class WorkspaceList : IMessage<WorkspaceList>, IMessage, IEquatable<WorkspaceList>, IDeepCloneable<WorkspaceList>
				{
					private static readonly MessageParser<WorkspaceList> _parser = new MessageParser<WorkspaceList>(() => new WorkspaceList());

					private UnknownFieldSet _unknownFields;

					public const int WorkspacesFieldNumber = 1;

					private static readonly FieldCodec<Metadata> _repeated_workspaces_codec = FieldCodec.ForMessage(10u, Metadata.Parser);

					private readonly RepeatedField<Metadata> workspaces_ = new RepeatedField<Metadata>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<WorkspaceList> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Notification.Types.Workspaces.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<Metadata> Workspaces => workspaces_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public WorkspaceList()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public WorkspaceList(WorkspaceList other)
						: this()
					{
						workspaces_ = other.workspaces_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public WorkspaceList Clone()
					{
						return new WorkspaceList(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as WorkspaceList);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(WorkspaceList other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!workspaces_.Equals(other.workspaces_))
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
						num ^= workspaces_.GetHashCode();
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
						workspaces_.WriteTo(output, _repeated_workspaces_codec);
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
						num += workspaces_.CalculateSize(_repeated_workspaces_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(WorkspaceList other)
					{
						if (other != null)
						{
							workspaces_.Add(other.workspaces_);
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
								workspaces_.AddEntriesFrom(input, _repeated_workspaces_codec);
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Uninitialized : IMessage<Uninitialized>, IMessage, IEquatable<Uninitialized>, IDeepCloneable<Uninitialized>
				{
					private static readonly MessageParser<Uninitialized> _parser = new MessageParser<Uninitialized>(() => new Uninitialized());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Uninitialized> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Workspaces.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Uninitialized()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Uninitialized(Uninitialized other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Uninitialized Clone()
					{
						return new Uninitialized(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Uninitialized);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Uninitialized other)
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
					public void MergeFrom(Uninitialized other)
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
				public sealed class Error : IMessage<Error>, IMessage, IEquatable<Error>, IDeepCloneable<Error>
				{
					private static readonly MessageParser<Error> _parser = new MessageParser<Error>(() => new Error());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Error> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Workspaces.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

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
					public void MergeFrom(Error other)
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

			private static readonly MessageParser<Workspaces> _parser = new MessageParser<Workspaces>(() => new Workspaces());

			private UnknownFieldSet _unknownFields;

			public const int InitializedFieldNumber = 1;

			public const int UninitializedFieldNumber = 2;

			public const int ErrorFieldNumber = 3;

			private object state_;

			private StateOneofCase stateCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Workspaces> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.WorkspaceList Initialized
			{
				get
				{
					if (stateCase_ != StateOneofCase.Initialized)
					{
						return null;
					}
					return (Types.WorkspaceList)state_;
				}
				set
				{
					state_ = value;
					stateCase_ = ((value != null) ? StateOneofCase.Initialized : StateOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Uninitialized Uninitialized
			{
				get
				{
					if (stateCase_ != StateOneofCase.Uninitialized)
					{
						return null;
					}
					return (Types.Uninitialized)state_;
				}
				set
				{
					state_ = value;
					stateCase_ = ((value != null) ? StateOneofCase.Uninitialized : StateOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Error Error
			{
				get
				{
					if (stateCase_ != StateOneofCase.Error)
					{
						return null;
					}
					return (Types.Error)state_;
				}
				set
				{
					state_ = value;
					stateCase_ = ((value != null) ? StateOneofCase.Error : StateOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StateOneofCase StateCase => stateCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Workspaces()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Workspaces(Workspaces other)
				: this()
			{
				switch (other.StateCase)
				{
				case StateOneofCase.Initialized:
					Initialized = other.Initialized.Clone();
					break;
				case StateOneofCase.Uninitialized:
					Uninitialized = other.Uninitialized.Clone();
					break;
				case StateOneofCase.Error:
					Error = other.Error.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Workspaces Clone()
			{
				return new Workspaces(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearState()
			{
				stateCase_ = StateOneofCase.None;
				state_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Workspaces);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Workspaces other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Initialized, other.Initialized))
				{
					return false;
				}
				if (!object.Equals(Uninitialized, other.Uninitialized))
				{
					return false;
				}
				if (!object.Equals(Error, other.Error))
				{
					return false;
				}
				if (StateCase != other.StateCase)
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
				if (stateCase_ == StateOneofCase.Initialized)
				{
					num ^= Initialized.GetHashCode();
				}
				if (stateCase_ == StateOneofCase.Uninitialized)
				{
					num ^= Uninitialized.GetHashCode();
				}
				if (stateCase_ == StateOneofCase.Error)
				{
					num ^= Error.GetHashCode();
				}
				num ^= (int)stateCase_;
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
				if (stateCase_ == StateOneofCase.Initialized)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Initialized);
				}
				if (stateCase_ == StateOneofCase.Uninitialized)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Uninitialized);
				}
				if (stateCase_ == StateOneofCase.Error)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Error);
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
				if (stateCase_ == StateOneofCase.Initialized)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Initialized);
				}
				if (stateCase_ == StateOneofCase.Uninitialized)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uninitialized);
				}
				if (stateCase_ == StateOneofCase.Error)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Error);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Workspaces other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.StateCase)
				{
				case StateOneofCase.Initialized:
					if (Initialized == null)
					{
						Initialized = new Types.WorkspaceList();
					}
					Initialized.MergeFrom(other.Initialized);
					break;
				case StateOneofCase.Uninitialized:
					if (Uninitialized == null)
					{
						Uninitialized = new Types.Uninitialized();
					}
					Uninitialized.MergeFrom(other.Uninitialized);
					break;
				case StateOneofCase.Error:
					if (Error == null)
					{
						Error = new Types.Error();
					}
					Error.MergeFrom(other.Error);
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
						Types.WorkspaceList workspaceList = new Types.WorkspaceList();
						if (stateCase_ == StateOneofCase.Initialized)
						{
							workspaceList.MergeFrom(Initialized);
						}
						input.ReadMessage(workspaceList);
						Initialized = workspaceList;
						break;
					}
					case 18u:
					{
						Types.Uninitialized uninitialized = new Types.Uninitialized();
						if (stateCase_ == StateOneofCase.Uninitialized)
						{
							uninitialized.MergeFrom(Uninitialized);
						}
						input.ReadMessage(uninitialized);
						Uninitialized = uninitialized;
						break;
					}
					case 26u:
					{
						Types.Error error = new Types.Error();
						if (stateCase_ == StateOneofCase.Error)
						{
							error.MergeFrom(Error);
						}
						input.ReadMessage(error);
						Error = error;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Collaborators : IMessage<Collaborators>, IMessage, IEquatable<Collaborators>, IDeepCloneable<Collaborators>
		{
			private static readonly MessageParser<Collaborators> _parser = new MessageParser<Collaborators>(() => new Collaborators());

			private UnknownFieldSet _unknownFields;

			public const int OnlineFieldNumber = 1;

			private static readonly FieldCodec<string> _repeated_online_codec = FieldCodec.ForString(10u);

			private readonly RepeatedField<string> online_ = new RepeatedField<string>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Collaborators> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<string> Online => online_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Collaborators()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Collaborators(Collaborators other)
				: this()
			{
				online_ = other.online_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Collaborators Clone()
			{
				return new Collaborators(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Collaborators);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Collaborators other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!online_.Equals(other.online_))
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
				num ^= online_.GetHashCode();
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
				online_.WriteTo(output, _repeated_online_codec);
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
				num += online_.CalculateSize(_repeated_online_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Collaborators other)
			{
				if (other != null)
				{
					online_.Add(other.online_);
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
						online_.AddEntriesFrom(input, _repeated_online_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Syncing : IMessage<Syncing>, IMessage, IEquatable<Syncing>, IDeepCloneable<Syncing>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Paused : IMessage<Paused>, IMessage, IEquatable<Paused>, IDeepCloneable<Paused>
				{
					private static readonly MessageParser<Paused> _parser = new MessageParser<Paused>(() => new Paused());

					private UnknownFieldSet _unknownFields;

					public const int UntilTimeUtcFieldNumber = 1;

					private ulong untilTimeUtc_;

					public const int AtTimeUtcFieldNumber = 2;

					private ulong atTimeUtc_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Paused> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Syncing.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ulong UntilTimeUtc
					{
						get
						{
							return untilTimeUtc_;
						}
						set
						{
							untilTimeUtc_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ulong AtTimeUtc
					{
						get
						{
							return atTimeUtc_;
						}
						set
						{
							atTimeUtc_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Paused()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Paused(Paused other)
						: this()
					{
						untilTimeUtc_ = other.untilTimeUtc_;
						atTimeUtc_ = other.atTimeUtc_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Paused Clone()
					{
						return new Paused(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Paused);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Paused other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (UntilTimeUtc != other.UntilTimeUtc)
						{
							return false;
						}
						if (AtTimeUtc != other.AtTimeUtc)
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
						if (UntilTimeUtc != 0L)
						{
							num ^= UntilTimeUtc.GetHashCode();
						}
						if (AtTimeUtc != 0L)
						{
							num ^= AtTimeUtc.GetHashCode();
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
						if (UntilTimeUtc != 0L)
						{
							output.WriteRawTag(8);
							output.WriteUInt64(UntilTimeUtc);
						}
						if (AtTimeUtc != 0L)
						{
							output.WriteRawTag(16);
							output.WriteUInt64(AtTimeUtc);
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
						if (UntilTimeUtc != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(UntilTimeUtc);
						}
						if (AtTimeUtc != 0L)
						{
							num += 1 + CodedOutputStream.ComputeUInt64Size(AtTimeUtc);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Paused other)
					{
						if (other != null)
						{
							if (other.UntilTimeUtc != 0L)
							{
								UntilTimeUtc = other.UntilTimeUtc;
							}
							if (other.AtTimeUtc != 0L)
							{
								AtTimeUtc = other.AtTimeUtc;
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
								UntilTimeUtc = input.ReadUInt64();
								break;
							case 16u:
								AtTimeUtc = input.ReadUInt64();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Syncing> _parser = new MessageParser<Syncing>(() => new Syncing());

			private UnknownFieldSet _unknownFields;

			public const int PausedFieldNumber = 1;

			private Types.Paused paused_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Syncing> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Paused Paused
			{
				get
				{
					return paused_;
				}
				set
				{
					paused_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Syncing()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Syncing(Syncing other)
				: this()
			{
				paused_ = ((other.paused_ != null) ? other.paused_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Syncing Clone()
			{
				return new Syncing(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Syncing);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Syncing other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Paused, other.Paused))
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
				if (paused_ != null)
				{
					num ^= Paused.GetHashCode();
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
				if (paused_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Paused);
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
				if (paused_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Paused);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Syncing other)
			{
				if (other == null)
				{
					return;
				}
				if (other.paused_ != null)
				{
					if (paused_ == null)
					{
						Paused = new Types.Paused();
					}
					Paused.MergeFrom(other.Paused);
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
					if (paused_ == null)
					{
						Paused = new Types.Paused();
					}
					input.ReadMessage(Paused);
				}
			}
		}
	}

	private static readonly MessageParser<Notification> _parser = new MessageParser<Notification>(() => new Notification());

	private UnknownFieldSet _unknownFields;

	public const int UnsubscribeFieldNumber = 1;

	public const int WorkspacesFieldNumber = 2;

	public const int CollaboratorsFieldNumber = 3;

	public const int SyncingFieldNumber = 4;

	private object notification_;

	private NotificationOneofCase notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Notification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => WorkspaceNotificationsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UnsubscribeComplete Unsubscribe
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Unsubscribe)
			{
				return null;
			}
			return (Types.UnsubscribeComplete)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Unsubscribe : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Workspaces Workspaces
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Workspaces)
			{
				return null;
			}
			return (Types.Workspaces)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Workspaces : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Collaborators Collaborators
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Collaborators)
			{
				return null;
			}
			return (Types.Collaborators)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Collaborators : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Syncing Syncing
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Syncing)
			{
				return null;
			}
			return (Types.Syncing)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Syncing : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotificationOneofCase NotificationCase => notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification(Notification other)
		: this()
	{
		switch (other.NotificationCase)
		{
		case NotificationOneofCase.Unsubscribe:
			Unsubscribe = other.Unsubscribe.Clone();
			break;
		case NotificationOneofCase.Workspaces:
			Workspaces = other.Workspaces.Clone();
			break;
		case NotificationOneofCase.Collaborators:
			Collaborators = other.Collaborators.Clone();
			break;
		case NotificationOneofCase.Syncing:
			Syncing = other.Syncing.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Notification Clone()
	{
		return new Notification(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearNotification()
	{
		notificationCase_ = NotificationOneofCase.None;
		notification_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Notification);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Notification other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Unsubscribe, other.Unsubscribe))
		{
			return false;
		}
		if (!object.Equals(Workspaces, other.Workspaces))
		{
			return false;
		}
		if (!object.Equals(Collaborators, other.Collaborators))
		{
			return false;
		}
		if (!object.Equals(Syncing, other.Syncing))
		{
			return false;
		}
		if (NotificationCase != other.NotificationCase)
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
		if (notificationCase_ == NotificationOneofCase.Unsubscribe)
		{
			num ^= Unsubscribe.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Workspaces)
		{
			num ^= Workspaces.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Collaborators)
		{
			num ^= Collaborators.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Syncing)
		{
			num ^= Syncing.GetHashCode();
		}
		num ^= (int)notificationCase_;
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
		if (notificationCase_ == NotificationOneofCase.Unsubscribe)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Unsubscribe);
		}
		if (notificationCase_ == NotificationOneofCase.Workspaces)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Workspaces);
		}
		if (notificationCase_ == NotificationOneofCase.Collaborators)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Collaborators);
		}
		if (notificationCase_ == NotificationOneofCase.Syncing)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Syncing);
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
		if (notificationCase_ == NotificationOneofCase.Unsubscribe)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Unsubscribe);
		}
		if (notificationCase_ == NotificationOneofCase.Workspaces)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Workspaces);
		}
		if (notificationCase_ == NotificationOneofCase.Collaborators)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Collaborators);
		}
		if (notificationCase_ == NotificationOneofCase.Syncing)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Syncing);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Notification other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.NotificationCase)
		{
		case NotificationOneofCase.Unsubscribe:
			if (Unsubscribe == null)
			{
				Unsubscribe = new Types.UnsubscribeComplete();
			}
			Unsubscribe.MergeFrom(other.Unsubscribe);
			break;
		case NotificationOneofCase.Workspaces:
			if (Workspaces == null)
			{
				Workspaces = new Types.Workspaces();
			}
			Workspaces.MergeFrom(other.Workspaces);
			break;
		case NotificationOneofCase.Collaborators:
			if (Collaborators == null)
			{
				Collaborators = new Types.Collaborators();
			}
			Collaborators.MergeFrom(other.Collaborators);
			break;
		case NotificationOneofCase.Syncing:
			if (Syncing == null)
			{
				Syncing = new Types.Syncing();
			}
			Syncing.MergeFrom(other.Syncing);
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
				Types.UnsubscribeComplete unsubscribeComplete = new Types.UnsubscribeComplete();
				if (notificationCase_ == NotificationOneofCase.Unsubscribe)
				{
					unsubscribeComplete.MergeFrom(Unsubscribe);
				}
				input.ReadMessage(unsubscribeComplete);
				Unsubscribe = unsubscribeComplete;
				break;
			}
			case 18u:
			{
				Types.Workspaces workspaces = new Types.Workspaces();
				if (notificationCase_ == NotificationOneofCase.Workspaces)
				{
					workspaces.MergeFrom(Workspaces);
				}
				input.ReadMessage(workspaces);
				Workspaces = workspaces;
				break;
			}
			case 26u:
			{
				Types.Collaborators collaborators = new Types.Collaborators();
				if (notificationCase_ == NotificationOneofCase.Collaborators)
				{
					collaborators.MergeFrom(Collaborators);
				}
				input.ReadMessage(collaborators);
				Collaborators = collaborators;
				break;
			}
			case 34u:
			{
				Types.Syncing syncing = new Types.Syncing();
				if (notificationCase_ == NotificationOneofCase.Syncing)
				{
					syncing.MergeFrom(Syncing);
				}
				input.ReadMessage(syncing);
				Syncing = syncing;
				break;
			}
			}
		}
	}
}
