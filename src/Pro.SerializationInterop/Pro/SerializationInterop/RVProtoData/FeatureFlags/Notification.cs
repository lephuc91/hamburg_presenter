using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.FeatureFlags;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Notification : IMessage<Notification>, IMessage, IEquatable<Notification>, IDeepCloneable<Notification>
{
	public enum NotificationOneofCase
	{
		None,
		AllFlags,
		UnsubscribeComplete
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
	}

	private static readonly MessageParser<Notification> _parser = new MessageParser<Notification>(() => new Notification());

	private UnknownFieldSet _unknownFields;

	public const int AllFlagsFieldNumber = 1;

	public const int UnsubscribeCompleteFieldNumber = 2;

	private object notification_;

	private NotificationOneofCase notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Notification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => FeatureFlagsReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AllFlags AllFlags
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.AllFlags)
			{
				return null;
			}
			return (AllFlags)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.AllFlags : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UnsubscribeComplete UnsubscribeComplete
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.UnsubscribeComplete)
			{
				return null;
			}
			return (Types.UnsubscribeComplete)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.UnsubscribeComplete : NotificationOneofCase.None);
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
		case NotificationOneofCase.AllFlags:
			AllFlags = other.AllFlags.Clone();
			break;
		case NotificationOneofCase.UnsubscribeComplete:
			UnsubscribeComplete = other.UnsubscribeComplete.Clone();
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
		if (!object.Equals(AllFlags, other.AllFlags))
		{
			return false;
		}
		if (!object.Equals(UnsubscribeComplete, other.UnsubscribeComplete))
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
		if (notificationCase_ == NotificationOneofCase.AllFlags)
		{
			num ^= AllFlags.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.UnsubscribeComplete)
		{
			num ^= UnsubscribeComplete.GetHashCode();
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
		if (notificationCase_ == NotificationOneofCase.AllFlags)
		{
			output.WriteRawTag(10);
			output.WriteMessage(AllFlags);
		}
		if (notificationCase_ == NotificationOneofCase.UnsubscribeComplete)
		{
			output.WriteRawTag(18);
			output.WriteMessage(UnsubscribeComplete);
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
		if (notificationCase_ == NotificationOneofCase.AllFlags)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AllFlags);
		}
		if (notificationCase_ == NotificationOneofCase.UnsubscribeComplete)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UnsubscribeComplete);
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
		case NotificationOneofCase.AllFlags:
			if (AllFlags == null)
			{
				AllFlags = new AllFlags();
			}
			AllFlags.MergeFrom(other.AllFlags);
			break;
		case NotificationOneofCase.UnsubscribeComplete:
			if (UnsubscribeComplete == null)
			{
				UnsubscribeComplete = new Types.UnsubscribeComplete();
			}
			UnsubscribeComplete.MergeFrom(other.UnsubscribeComplete);
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
				AllFlags allFlags = new AllFlags();
				if (notificationCase_ == NotificationOneofCase.AllFlags)
				{
					allFlags.MergeFrom(AllFlags);
				}
				input.ReadMessage(allFlags);
				AllFlags = allFlags;
				break;
			}
			case 18u:
			{
				Types.UnsubscribeComplete unsubscribeComplete = new Types.UnsubscribeComplete();
				if (notificationCase_ == NotificationOneofCase.UnsubscribeComplete)
				{
					unsubscribeComplete.MergeFrom(UnsubscribeComplete);
				}
				input.ReadMessage(unsubscribeComplete);
				UnsubscribeComplete = unsubscribeComplete;
				break;
			}
			}
		}
	}
}
