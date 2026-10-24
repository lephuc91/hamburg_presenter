using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Helper.Workspace.V2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Notification : IMessage<Notification>, IMessage, IEquatable<Notification>, IDeepCloneable<Notification>
{
	public enum NotificationOneofCase
	{
		None,
		MediaReference,
		AssetImported,
		SyncStatus
	}

	private static readonly MessageParser<Notification> _parser = new MessageParser<Notification>(() => new Notification());

	private UnknownFieldSet _unknownFields;

	public const int MediaReferenceFieldNumber = 1;

	public const int AssetImportedFieldNumber = 2;

	public const int SyncStatusFieldNumber = 3;

	private object notification_;

	private NotificationOneofCase notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Notification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperWorkspaceReflection.Descriptor.MessageTypes[1];

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
	public SyncStatus SyncStatus
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.SyncStatus)
			{
				return null;
			}
			return (SyncStatus)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.SyncStatus : NotificationOneofCase.None);
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
		case NotificationOneofCase.AssetImported:
			AssetImported = other.AssetImported.Clone();
			break;
		case NotificationOneofCase.SyncStatus:
			SyncStatus = other.SyncStatus.Clone();
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
		if (!object.Equals(AssetImported, other.AssetImported))
		{
			return false;
		}
		if (!object.Equals(SyncStatus, other.SyncStatus))
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
		if (notificationCase_ == NotificationOneofCase.AssetImported)
		{
			num ^= AssetImported.GetHashCode();
		}
		if (notificationCase_ == NotificationOneofCase.SyncStatus)
		{
			num ^= SyncStatus.GetHashCode();
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
		if (notificationCase_ == NotificationOneofCase.AssetImported)
		{
			output.WriteRawTag(18);
			output.WriteMessage(AssetImported);
		}
		if (notificationCase_ == NotificationOneofCase.SyncStatus)
		{
			output.WriteRawTag(26);
			output.WriteMessage(SyncStatus);
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
		if (notificationCase_ == NotificationOneofCase.AssetImported)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AssetImported);
		}
		if (notificationCase_ == NotificationOneofCase.SyncStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SyncStatus);
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
		case NotificationOneofCase.AssetImported:
			if (AssetImported == null)
			{
				AssetImported = new AssetImported();
			}
			AssetImported.MergeFrom(other.AssetImported);
			break;
		case NotificationOneofCase.SyncStatus:
			if (SyncStatus == null)
			{
				SyncStatus = new SyncStatus();
			}
			SyncStatus.MergeFrom(other.SyncStatus);
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
				AssetImported assetImported = new AssetImported();
				if (notificationCase_ == NotificationOneofCase.AssetImported)
				{
					assetImported.MergeFrom(AssetImported);
				}
				input.ReadMessage(assetImported);
				AssetImported = assetImported;
				break;
			}
			case 26u:
			{
				SyncStatus syncStatus = new SyncStatus();
				if (notificationCase_ == NotificationOneofCase.SyncStatus)
				{
					syncStatus.MergeFrom(SyncStatus);
				}
				input.ReadMessage(syncStatus);
				SyncStatus = syncStatus;
				break;
			}
			}
		}
	}
}
