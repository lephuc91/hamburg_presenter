using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Announcement_Request : IMessage<API_v1_Announcement_Request>, IMessage, IEquatable<API_v1_Announcement_Request>, IDeepCloneable<API_v1_Announcement_Request>
{
	public enum RequestOneofCase
	{
		None,
		ActiveTimelineOperation,
		ActiveTimelineStatus,
		Active,
		SlideIndex,
		ActiveFocus,
		ActiveTrigger,
		ActiveNextTrigger,
		ActivePreviousTrigger,
		ActiveIndexTrigger
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActiveTimelineOperation : IMessage<ActiveTimelineOperation>, IMessage, IEquatable<ActiveTimelineOperation>, IDeepCloneable<ActiveTimelineOperation>
		{
			private static readonly MessageParser<ActiveTimelineOperation> _parser = new MessageParser<ActiveTimelineOperation>(() => new ActiveTimelineOperation());

			private UnknownFieldSet _unknownFields;

			public const int OperationFieldNumber = 1;

			private API_v1_TimelineOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActiveTimelineOperation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_TimelineOperation Operation
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTimelineOperation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTimelineOperation(ActiveTimelineOperation other)
				: this()
			{
				operation_ = other.operation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTimelineOperation Clone()
			{
				return new ActiveTimelineOperation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActiveTimelineOperation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActiveTimelineOperation other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Operation != other.Operation)
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
				if (Operation != 0)
				{
					num ^= Operation.GetHashCode();
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
				if (Operation != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Operation);
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
				if (Operation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ActiveTimelineOperation other)
			{
				if (other != null)
				{
					if (other.Operation != 0)
					{
						Operation = other.Operation;
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
						Operation = (API_v1_TimelineOperation)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActiveTimelineStatus : IMessage<ActiveTimelineStatus>, IMessage, IEquatable<ActiveTimelineStatus>, IDeepCloneable<ActiveTimelineStatus>
		{
			private static readonly MessageParser<ActiveTimelineStatus> _parser = new MessageParser<ActiveTimelineStatus>(() => new ActiveTimelineStatus());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActiveTimelineStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTimelineStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTimelineStatus(ActiveTimelineStatus other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTimelineStatus Clone()
			{
				return new ActiveTimelineStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActiveTimelineStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActiveTimelineStatus other)
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
			public void MergeFrom(ActiveTimelineStatus other)
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
		public sealed class Active : IMessage<Active>, IMessage, IEquatable<Active>, IDeepCloneable<Active>
		{
			private static readonly MessageParser<Active> _parser = new MessageParser<Active>(() => new Active());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Active> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Active()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Active(Active other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Active Clone()
			{
				return new Active(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Active);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Active other)
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
			public void MergeFrom(Active other)
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
		public sealed class AnnouncementIndex : IMessage<AnnouncementIndex>, IMessage, IEquatable<AnnouncementIndex>, IDeepCloneable<AnnouncementIndex>
		{
			private static readonly MessageParser<AnnouncementIndex> _parser = new MessageParser<AnnouncementIndex>(() => new AnnouncementIndex());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AnnouncementIndex> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AnnouncementIndex()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AnnouncementIndex(AnnouncementIndex other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AnnouncementIndex Clone()
			{
				return new AnnouncementIndex(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AnnouncementIndex);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AnnouncementIndex other)
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
			public void MergeFrom(AnnouncementIndex other)
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
		public sealed class ActiveFocus : IMessage<ActiveFocus>, IMessage, IEquatable<ActiveFocus>, IDeepCloneable<ActiveFocus>
		{
			private static readonly MessageParser<ActiveFocus> _parser = new MessageParser<ActiveFocus>(() => new ActiveFocus());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActiveFocus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveFocus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveFocus(ActiveFocus other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveFocus Clone()
			{
				return new ActiveFocus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActiveFocus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActiveFocus other)
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
			public void MergeFrom(ActiveFocus other)
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
		public sealed class ActiveTrigger : IMessage<ActiveTrigger>, IMessage, IEquatable<ActiveTrigger>, IDeepCloneable<ActiveTrigger>
		{
			private static readonly MessageParser<ActiveTrigger> _parser = new MessageParser<ActiveTrigger>(() => new ActiveTrigger());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActiveTrigger> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTrigger()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTrigger(ActiveTrigger other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveTrigger Clone()
			{
				return new ActiveTrigger(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActiveTrigger);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActiveTrigger other)
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
			public void MergeFrom(ActiveTrigger other)
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
		public sealed class ActiveNextTrigger : IMessage<ActiveNextTrigger>, IMessage, IEquatable<ActiveNextTrigger>, IDeepCloneable<ActiveNextTrigger>
		{
			private static readonly MessageParser<ActiveNextTrigger> _parser = new MessageParser<ActiveNextTrigger>(() => new ActiveNextTrigger());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActiveNextTrigger> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveNextTrigger()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveNextTrigger(ActiveNextTrigger other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveNextTrigger Clone()
			{
				return new ActiveNextTrigger(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActiveNextTrigger);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActiveNextTrigger other)
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
			public void MergeFrom(ActiveNextTrigger other)
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
		public sealed class ActivePreviousTrigger : IMessage<ActivePreviousTrigger>, IMessage, IEquatable<ActivePreviousTrigger>, IDeepCloneable<ActivePreviousTrigger>
		{
			private static readonly MessageParser<ActivePreviousTrigger> _parser = new MessageParser<ActivePreviousTrigger>(() => new ActivePreviousTrigger());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivePreviousTrigger> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePreviousTrigger()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePreviousTrigger(ActivePreviousTrigger other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivePreviousTrigger Clone()
			{
				return new ActivePreviousTrigger(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivePreviousTrigger);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivePreviousTrigger other)
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
			public void MergeFrom(ActivePreviousTrigger other)
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
		public sealed class ActiveIndexTrigger : IMessage<ActiveIndexTrigger>, IMessage, IEquatable<ActiveIndexTrigger>, IDeepCloneable<ActiveIndexTrigger>
		{
			private static readonly MessageParser<ActiveIndexTrigger> _parser = new MessageParser<ActiveIndexTrigger>(() => new ActiveIndexTrigger());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActiveIndexTrigger> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Announcement_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Index
			{
				get
				{
					return index_;
				}
				set
				{
					index_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveIndexTrigger()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveIndexTrigger(ActiveIndexTrigger other)
				: this()
			{
				index_ = other.index_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActiveIndexTrigger Clone()
			{
				return new ActiveIndexTrigger(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActiveIndexTrigger);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActiveIndexTrigger other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Index != other.Index)
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
				if (Index != 0)
				{
					num ^= Index.GetHashCode();
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
				if (Index != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Index);
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
				if (Index != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ActiveIndexTrigger other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
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
						Index = input.ReadUInt32();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Announcement_Request> _parser = new MessageParser<API_v1_Announcement_Request>(() => new API_v1_Announcement_Request());

	private UnknownFieldSet _unknownFields;

	public const int ActiveTimelineOperationFieldNumber = 1;

	public const int ActiveTimelineStatusFieldNumber = 2;

	public const int ActiveFieldNumber = 3;

	public const int SlideIndexFieldNumber = 4;

	public const int ActiveFocusFieldNumber = 5;

	public const int ActiveTriggerFieldNumber = 6;

	public const int ActiveNextTriggerFieldNumber = 7;

	public const int ActivePreviousTriggerFieldNumber = 8;

	public const int ActiveIndexTriggerFieldNumber = 9;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Announcement_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1AnnouncementReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActiveTimelineOperation ActiveTimelineOperation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveTimelineOperation)
			{
				return null;
			}
			return (Types.ActiveTimelineOperation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveTimelineOperation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActiveTimelineStatus ActiveTimelineStatus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveTimelineStatus)
			{
				return null;
			}
			return (Types.ActiveTimelineStatus)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveTimelineStatus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Active Active
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Active)
			{
				return null;
			}
			return (Types.Active)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Active : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.AnnouncementIndex SlideIndex
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SlideIndex)
			{
				return null;
			}
			return (Types.AnnouncementIndex)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SlideIndex : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActiveFocus ActiveFocus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveFocus)
			{
				return null;
			}
			return (Types.ActiveFocus)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveFocus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActiveTrigger ActiveTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveTrigger)
			{
				return null;
			}
			return (Types.ActiveTrigger)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActiveNextTrigger ActiveNextTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveNextTrigger)
			{
				return null;
			}
			return (Types.ActiveNextTrigger)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveNextTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivePreviousTrigger ActivePreviousTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivePreviousTrigger)
			{
				return null;
			}
			return (Types.ActivePreviousTrigger)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivePreviousTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActiveIndexTrigger ActiveIndexTrigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActiveIndexTrigger)
			{
				return null;
			}
			return (Types.ActiveIndexTrigger)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActiveIndexTrigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Announcement_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Announcement_Request(API_v1_Announcement_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.ActiveTimelineOperation:
			ActiveTimelineOperation = other.ActiveTimelineOperation.Clone();
			break;
		case RequestOneofCase.ActiveTimelineStatus:
			ActiveTimelineStatus = other.ActiveTimelineStatus.Clone();
			break;
		case RequestOneofCase.Active:
			Active = other.Active.Clone();
			break;
		case RequestOneofCase.SlideIndex:
			SlideIndex = other.SlideIndex.Clone();
			break;
		case RequestOneofCase.ActiveFocus:
			ActiveFocus = other.ActiveFocus.Clone();
			break;
		case RequestOneofCase.ActiveTrigger:
			ActiveTrigger = other.ActiveTrigger.Clone();
			break;
		case RequestOneofCase.ActiveNextTrigger:
			ActiveNextTrigger = other.ActiveNextTrigger.Clone();
			break;
		case RequestOneofCase.ActivePreviousTrigger:
			ActivePreviousTrigger = other.ActivePreviousTrigger.Clone();
			break;
		case RequestOneofCase.ActiveIndexTrigger:
			ActiveIndexTrigger = other.ActiveIndexTrigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Announcement_Request Clone()
	{
		return new API_v1_Announcement_Request(this);
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
		return Equals(other as API_v1_Announcement_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Announcement_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ActiveTimelineOperation, other.ActiveTimelineOperation))
		{
			return false;
		}
		if (!object.Equals(ActiveTimelineStatus, other.ActiveTimelineStatus))
		{
			return false;
		}
		if (!object.Equals(Active, other.Active))
		{
			return false;
		}
		if (!object.Equals(SlideIndex, other.SlideIndex))
		{
			return false;
		}
		if (!object.Equals(ActiveFocus, other.ActiveFocus))
		{
			return false;
		}
		if (!object.Equals(ActiveTrigger, other.ActiveTrigger))
		{
			return false;
		}
		if (!object.Equals(ActiveNextTrigger, other.ActiveNextTrigger))
		{
			return false;
		}
		if (!object.Equals(ActivePreviousTrigger, other.ActivePreviousTrigger))
		{
			return false;
		}
		if (!object.Equals(ActiveIndexTrigger, other.ActiveIndexTrigger))
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
		if (requestCase_ == RequestOneofCase.ActiveTimelineOperation)
		{
			num ^= ActiveTimelineOperation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveTimelineStatus)
		{
			num ^= ActiveTimelineStatus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Active)
		{
			num ^= Active.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SlideIndex)
		{
			num ^= SlideIndex.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveFocus)
		{
			num ^= ActiveFocus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveTrigger)
		{
			num ^= ActiveTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveNextTrigger)
		{
			num ^= ActiveNextTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivePreviousTrigger)
		{
			num ^= ActivePreviousTrigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActiveIndexTrigger)
		{
			num ^= ActiveIndexTrigger.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.ActiveTimelineOperation)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ActiveTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActiveTimelineStatus)
		{
			output.WriteRawTag(18);
			output.WriteMessage(ActiveTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.Active)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Active);
		}
		if (requestCase_ == RequestOneofCase.SlideIndex)
		{
			output.WriteRawTag(34);
			output.WriteMessage(SlideIndex);
		}
		if (requestCase_ == RequestOneofCase.ActiveFocus)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ActiveFocus);
		}
		if (requestCase_ == RequestOneofCase.ActiveTrigger)
		{
			output.WriteRawTag(50);
			output.WriteMessage(ActiveTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveNextTrigger)
		{
			output.WriteRawTag(58);
			output.WriteMessage(ActiveNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePreviousTrigger)
		{
			output.WriteRawTag(66);
			output.WriteMessage(ActivePreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveIndexTrigger)
		{
			output.WriteRawTag(74);
			output.WriteMessage(ActiveIndexTrigger);
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
		if (requestCase_ == RequestOneofCase.ActiveTimelineOperation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveTimelineOperation);
		}
		if (requestCase_ == RequestOneofCase.ActiveTimelineStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveTimelineStatus);
		}
		if (requestCase_ == RequestOneofCase.Active)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Active);
		}
		if (requestCase_ == RequestOneofCase.SlideIndex)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SlideIndex);
		}
		if (requestCase_ == RequestOneofCase.ActiveFocus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveFocus);
		}
		if (requestCase_ == RequestOneofCase.ActiveTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveNextTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveNextTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActivePreviousTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivePreviousTrigger);
		}
		if (requestCase_ == RequestOneofCase.ActiveIndexTrigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActiveIndexTrigger);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Announcement_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.ActiveTimelineOperation:
			if (ActiveTimelineOperation == null)
			{
				ActiveTimelineOperation = new Types.ActiveTimelineOperation();
			}
			ActiveTimelineOperation.MergeFrom(other.ActiveTimelineOperation);
			break;
		case RequestOneofCase.ActiveTimelineStatus:
			if (ActiveTimelineStatus == null)
			{
				ActiveTimelineStatus = new Types.ActiveTimelineStatus();
			}
			ActiveTimelineStatus.MergeFrom(other.ActiveTimelineStatus);
			break;
		case RequestOneofCase.Active:
			if (Active == null)
			{
				Active = new Types.Active();
			}
			Active.MergeFrom(other.Active);
			break;
		case RequestOneofCase.SlideIndex:
			if (SlideIndex == null)
			{
				SlideIndex = new Types.AnnouncementIndex();
			}
			SlideIndex.MergeFrom(other.SlideIndex);
			break;
		case RequestOneofCase.ActiveFocus:
			if (ActiveFocus == null)
			{
				ActiveFocus = new Types.ActiveFocus();
			}
			ActiveFocus.MergeFrom(other.ActiveFocus);
			break;
		case RequestOneofCase.ActiveTrigger:
			if (ActiveTrigger == null)
			{
				ActiveTrigger = new Types.ActiveTrigger();
			}
			ActiveTrigger.MergeFrom(other.ActiveTrigger);
			break;
		case RequestOneofCase.ActiveNextTrigger:
			if (ActiveNextTrigger == null)
			{
				ActiveNextTrigger = new Types.ActiveNextTrigger();
			}
			ActiveNextTrigger.MergeFrom(other.ActiveNextTrigger);
			break;
		case RequestOneofCase.ActivePreviousTrigger:
			if (ActivePreviousTrigger == null)
			{
				ActivePreviousTrigger = new Types.ActivePreviousTrigger();
			}
			ActivePreviousTrigger.MergeFrom(other.ActivePreviousTrigger);
			break;
		case RequestOneofCase.ActiveIndexTrigger:
			if (ActiveIndexTrigger == null)
			{
				ActiveIndexTrigger = new Types.ActiveIndexTrigger();
			}
			ActiveIndexTrigger.MergeFrom(other.ActiveIndexTrigger);
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
				Types.ActiveTimelineOperation activeTimelineOperation = new Types.ActiveTimelineOperation();
				if (requestCase_ == RequestOneofCase.ActiveTimelineOperation)
				{
					activeTimelineOperation.MergeFrom(ActiveTimelineOperation);
				}
				input.ReadMessage(activeTimelineOperation);
				ActiveTimelineOperation = activeTimelineOperation;
				break;
			}
			case 18u:
			{
				Types.ActiveTimelineStatus activeTimelineStatus = new Types.ActiveTimelineStatus();
				if (requestCase_ == RequestOneofCase.ActiveTimelineStatus)
				{
					activeTimelineStatus.MergeFrom(ActiveTimelineStatus);
				}
				input.ReadMessage(activeTimelineStatus);
				ActiveTimelineStatus = activeTimelineStatus;
				break;
			}
			case 26u:
			{
				Types.Active active = new Types.Active();
				if (requestCase_ == RequestOneofCase.Active)
				{
					active.MergeFrom(Active);
				}
				input.ReadMessage(active);
				Active = active;
				break;
			}
			case 34u:
			{
				Types.AnnouncementIndex announcementIndex = new Types.AnnouncementIndex();
				if (requestCase_ == RequestOneofCase.SlideIndex)
				{
					announcementIndex.MergeFrom(SlideIndex);
				}
				input.ReadMessage(announcementIndex);
				SlideIndex = announcementIndex;
				break;
			}
			case 42u:
			{
				Types.ActiveFocus activeFocus = new Types.ActiveFocus();
				if (requestCase_ == RequestOneofCase.ActiveFocus)
				{
					activeFocus.MergeFrom(ActiveFocus);
				}
				input.ReadMessage(activeFocus);
				ActiveFocus = activeFocus;
				break;
			}
			case 50u:
			{
				Types.ActiveTrigger activeTrigger = new Types.ActiveTrigger();
				if (requestCase_ == RequestOneofCase.ActiveTrigger)
				{
					activeTrigger.MergeFrom(ActiveTrigger);
				}
				input.ReadMessage(activeTrigger);
				ActiveTrigger = activeTrigger;
				break;
			}
			case 58u:
			{
				Types.ActiveNextTrigger activeNextTrigger = new Types.ActiveNextTrigger();
				if (requestCase_ == RequestOneofCase.ActiveNextTrigger)
				{
					activeNextTrigger.MergeFrom(ActiveNextTrigger);
				}
				input.ReadMessage(activeNextTrigger);
				ActiveNextTrigger = activeNextTrigger;
				break;
			}
			case 66u:
			{
				Types.ActivePreviousTrigger activePreviousTrigger = new Types.ActivePreviousTrigger();
				if (requestCase_ == RequestOneofCase.ActivePreviousTrigger)
				{
					activePreviousTrigger.MergeFrom(ActivePreviousTrigger);
				}
				input.ReadMessage(activePreviousTrigger);
				ActivePreviousTrigger = activePreviousTrigger;
				break;
			}
			case 74u:
			{
				Types.ActiveIndexTrigger activeIndexTrigger = new Types.ActiveIndexTrigger();
				if (requestCase_ == RequestOneofCase.ActiveIndexTrigger)
				{
					activeIndexTrigger.MergeFrom(ActiveIndexTrigger);
				}
				input.ReadMessage(activeIndexTrigger);
				ActiveIndexTrigger = activeIndexTrigger;
				break;
			}
			}
		}
	}
}
