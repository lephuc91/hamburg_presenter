using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Pro.SerializationInterop.RVProtoData.MediaService.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Notification : IMessage<Notification>, IMessage, IEquatable<Notification>, IDeepCloneable<Notification>
{
	public enum NotificationOneofCase
	{
		None,
		MediaReference,
		UnsubscribeComplete,
		Connected,
		Disconnected,
		Unresponsive,
		AssetImported
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
		public sealed class Disconnected : IMessage<Disconnected>, IMessage, IEquatable<Disconnected>, IDeepCloneable<Disconnected>
		{
			private static readonly MessageParser<Disconnected> _parser = new MessageParser<Disconnected>(() => new Disconnected());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Disconnected> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Disconnected()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Disconnected(Disconnected other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Disconnected Clone()
			{
				return new Disconnected(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Disconnected);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Disconnected other)
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
			public void MergeFrom(Disconnected other)
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
		public sealed class Connected : IMessage<Connected>, IMessage, IEquatable<Connected>, IDeepCloneable<Connected>
		{
			private static readonly MessageParser<Connected> _parser = new MessageParser<Connected>(() => new Connected());

			private UnknownFieldSet _unknownFields;

			public const int VersionFieldNumber = 1;

			private Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Version version_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Connected> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Version Version
			{
				get
				{
					return version_;
				}
				set
				{
					version_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Connected()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Connected(Connected other)
				: this()
			{
				version_ = ((other.version_ != null) ? other.version_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Connected Clone()
			{
				return new Connected(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Connected);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Connected other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Version, other.Version))
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
				if (version_ != null)
				{
					num ^= Version.GetHashCode();
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
				if (version_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Version);
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
				if (version_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Version);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Connected other)
			{
				if (other == null)
				{
					return;
				}
				if (other.version_ != null)
				{
					if (version_ == null)
					{
						Version = new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Version();
					}
					Version.MergeFrom(other.Version);
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
					if (version_ == null)
					{
						Version = new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.Version();
					}
					input.ReadMessage(Version);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Unresponsive : IMessage<Unresponsive>, IMessage, IEquatable<Unresponsive>, IDeepCloneable<Unresponsive>
		{
			private static readonly MessageParser<Unresponsive> _parser = new MessageParser<Unresponsive>(() => new Unresponsive());

			private UnknownFieldSet _unknownFields;

			public const int RequestFieldNumber = 1;

			private RequestEnvelope request_;

			public const int SecondsFieldNumber = 2;

			private uint seconds_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Unresponsive> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Notification.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RequestEnvelope Request
			{
				get
				{
					return request_;
				}
				set
				{
					request_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Seconds
			{
				get
				{
					return seconds_;
				}
				set
				{
					seconds_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Unresponsive()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Unresponsive(Unresponsive other)
				: this()
			{
				request_ = ((other.request_ != null) ? other.request_.Clone() : null);
				seconds_ = other.seconds_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Unresponsive Clone()
			{
				return new Unresponsive(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Unresponsive);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Unresponsive other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Request, other.Request))
				{
					return false;
				}
				if (Seconds != other.Seconds)
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
				if (request_ != null)
				{
					num ^= Request.GetHashCode();
				}
				if (Seconds != 0)
				{
					num ^= Seconds.GetHashCode();
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
				if (request_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Request);
				}
				if (Seconds != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Seconds);
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
				if (request_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Request);
				}
				if (Seconds != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Seconds);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Unresponsive other)
			{
				if (other == null)
				{
					return;
				}
				if (other.request_ != null)
				{
					if (request_ == null)
					{
						Request = new RequestEnvelope();
					}
					Request.MergeFrom(other.Request);
				}
				if (other.Seconds != 0)
				{
					Seconds = other.Seconds;
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
						if (request_ == null)
						{
							Request = new RequestEnvelope();
						}
						input.ReadMessage(Request);
						break;
					case 16u:
						Seconds = input.ReadUInt32();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Notification> _parser = new MessageParser<Notification>(() => new Notification());

	private UnknownFieldSet _unknownFields;

	public const int MediaReferenceFieldNumber = 1;

	public const int UnsubscribeCompleteFieldNumber = 2;

	public const int ConnectedFieldNumber = 3;

	public const int DisconnectedFieldNumber = 4;

	public const int UnresponsiveFieldNumber = 5;

	public const int AssetImportedFieldNumber = 6;

	private object notification_;

	private NotificationOneofCase notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Notification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2MediaReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReference MediaReference
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.MediaReference)
			{
				return null;
			}
			return (MediaReference)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.MediaReference : NotificationOneofCase.None);
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
	public Types.Connected Connected
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Connected)
			{
				return null;
			}
			return (Types.Connected)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Connected : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Disconnected Disconnected
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Disconnected)
			{
				return null;
			}
			return (Types.Disconnected)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Disconnected : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Unresponsive Unresponsive
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.Unresponsive)
			{
				return null;
			}
			return (Types.Unresponsive)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.Unresponsive : NotificationOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AssetImported AssetImported
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.AssetImported)
			{
				return null;
			}
			return (AssetImported)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.AssetImported : NotificationOneofCase.None);
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
		case NotificationOneofCase.MediaReference:
			MediaReference = other.MediaReference.Clone();
			break;
		case NotificationOneofCase.UnsubscribeComplete:
			UnsubscribeComplete = other.UnsubscribeComplete.Clone();
			break;
		case NotificationOneofCase.Connected:
			Connected = other.Connected.Clone();
			break;
		case NotificationOneofCase.Disconnected:
			Disconnected = other.Disconnected.Clone();
			break;
		case NotificationOneofCase.Unresponsive:
			Unresponsive = other.Unresponsive.Clone();
			break;
		case NotificationOneofCase.AssetImported:
			AssetImported = other.AssetImported.Clone();
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
		if (!object.Equals(MediaReference, other.MediaReference))
		{
			return false;
		}
		if (!object.Equals(UnsubscribeComplete, other.UnsubscribeComplete))
		{
			return false;
		}
		if (!object.Equals(Connected, other.Connected))
		{
			return false;
		}
		if (!object.Equals(Disconnected, other.Disconnected))
		{
			return false;
		}
		if (!object.Equals(Unresponsive, other.Unresponsive))
		{
			return false;
		}
		if (!object.Equals(AssetImported, other.AssetImported))
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
		if (notificationCase_ == NotificationOneofCase.MediaReference)
		{
			num ^= MediaReference.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.UnsubscribeComplete)
		{
			num ^= UnsubscribeComplete.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Connected)
		{
			num ^= Connected.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Disconnected)
		{
			num ^= Disconnected.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.Unresponsive)
		{
			num ^= Unresponsive.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.AssetImported)
		{
			num ^= AssetImported.GetHashCode();
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
		if (notificationCase_ == NotificationOneofCase.MediaReference)
		{
			output.WriteRawTag(10);
			output.WriteMessage(MediaReference);
		}
		if (notificationCase_ == NotificationOneofCase.UnsubscribeComplete)
		{
			output.WriteRawTag(18);
			output.WriteMessage(UnsubscribeComplete);
		}
		if (notificationCase_ == NotificationOneofCase.Connected)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Connected);
		}
		if (notificationCase_ == NotificationOneofCase.Disconnected)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Disconnected);
		}
		if (notificationCase_ == NotificationOneofCase.Unresponsive)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Unresponsive);
		}
		if (notificationCase_ == NotificationOneofCase.AssetImported)
		{
			output.WriteRawTag(50);
			output.WriteMessage(AssetImported);
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
		if (notificationCase_ == NotificationOneofCase.MediaReference)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaReference);
		}
		if (notificationCase_ == NotificationOneofCase.UnsubscribeComplete)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UnsubscribeComplete);
		}
		if (notificationCase_ == NotificationOneofCase.Connected)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Connected);
		}
		if (notificationCase_ == NotificationOneofCase.Disconnected)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Disconnected);
		}
		if (notificationCase_ == NotificationOneofCase.Unresponsive)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Unresponsive);
		}
		if (notificationCase_ == NotificationOneofCase.AssetImported)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AssetImported);
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
		case NotificationOneofCase.MediaReference:
			if (MediaReference == null)
			{
				MediaReference = new MediaReference();
			}
			MediaReference.MergeFrom(other.MediaReference);
			break;
		case NotificationOneofCase.UnsubscribeComplete:
			if (UnsubscribeComplete == null)
			{
				UnsubscribeComplete = new Types.UnsubscribeComplete();
			}
			UnsubscribeComplete.MergeFrom(other.UnsubscribeComplete);
			break;
		case NotificationOneofCase.Connected:
			if (Connected == null)
			{
				Connected = new Types.Connected();
			}
			Connected.MergeFrom(other.Connected);
			break;
		case NotificationOneofCase.Disconnected:
			if (Disconnected == null)
			{
				Disconnected = new Types.Disconnected();
			}
			Disconnected.MergeFrom(other.Disconnected);
			break;
		case NotificationOneofCase.Unresponsive:
			if (Unresponsive == null)
			{
				Unresponsive = new Types.Unresponsive();
			}
			Unresponsive.MergeFrom(other.Unresponsive);
			break;
		case NotificationOneofCase.AssetImported:
			if (AssetImported == null)
			{
				AssetImported = new AssetImported();
			}
			AssetImported.MergeFrom(other.AssetImported);
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
				MediaReference mediaReference = new MediaReference();
				if (notificationCase_ == NotificationOneofCase.MediaReference)
				{
					mediaReference.MergeFrom(MediaReference);
				}
				input.ReadMessage(mediaReference);
				MediaReference = mediaReference;
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
			case 26u:
			{
				Types.Connected connected = new Types.Connected();
				if (notificationCase_ == NotificationOneofCase.Connected)
				{
					connected.MergeFrom(Connected);
				}
				input.ReadMessage(connected);
				Connected = connected;
				break;
			}
			case 34u:
			{
				Types.Disconnected disconnected = new Types.Disconnected();
				if (notificationCase_ == NotificationOneofCase.Disconnected)
				{
					disconnected.MergeFrom(Disconnected);
				}
				input.ReadMessage(disconnected);
				Disconnected = disconnected;
				break;
			}
			case 42u:
			{
				Types.Unresponsive unresponsive = new Types.Unresponsive();
				if (notificationCase_ == NotificationOneofCase.Unresponsive)
				{
					unresponsive.MergeFrom(Unresponsive);
				}
				input.ReadMessage(unresponsive);
				Unresponsive = unresponsive;
				break;
			}
			case 50u:
			{
				AssetImported assetImported = new AssetImported();
				if (notificationCase_ == NotificationOneofCase.AssetImported)
				{
					assetImported.MergeFrom(AssetImported);
				}
				input.ReadMessage(assetImported);
				AssetImported = assetImported;
				break;
			}
			}
		}
	}
}
