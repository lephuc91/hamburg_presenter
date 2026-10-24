using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Helper.Workspace.V1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Notification : IMessage<Notification>, IMessage, IEquatable<Notification>, IDeepCloneable<Notification>
{
	public enum NotificationOneofCase
	{
		None,
		MediaReference,
		GenerationStatus
	}

	private static readonly MessageParser<Notification> _parser = new MessageParser<Notification>(() => new Notification());

	private UnknownFieldSet _unknownFields;

	public const int MediaReferenceFieldNumber = 1;

	public const int GenerationStatusFieldNumber = 2;

	private object notification_;

	private NotificationOneofCase notificationCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Notification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperWorkspaceReflection.Descriptor.MessageTypes[0];

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
	public GenerationStatus GenerationStatus
	{
		get
		{
			if (notificationCase_ != NotificationOneofCase.GenerationStatus)
			{
				return null;
			}
			return (GenerationStatus)notification_;
		}
		set
		{
			notification_ = value;
			notificationCase_ = ((value != null) ? NotificationOneofCase.GenerationStatus : NotificationOneofCase.None);
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
		case NotificationOneofCase.GenerationStatus:
			GenerationStatus = other.GenerationStatus.Clone();
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
		if (!object.Equals(GenerationStatus, other.GenerationStatus))
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
		if (notificationCase_ == NotificationOneofCase.GenerationStatus)
		{
			num ^= GenerationStatus.GetHashCode();
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
		if (notificationCase_ == NotificationOneofCase.GenerationStatus)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GenerationStatus);
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
		if (notificationCase_ == NotificationOneofCase.GenerationStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GenerationStatus);
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
		case NotificationOneofCase.GenerationStatus:
			if (GenerationStatus == null)
			{
				GenerationStatus = new GenerationStatus();
			}
			GenerationStatus.MergeFrom(other.GenerationStatus);
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
				GenerationStatus generationStatus = new GenerationStatus();
				if (notificationCase_ == NotificationOneofCase.GenerationStatus)
				{
					generationStatus.MergeFrom(GenerationStatus);
				}
				input.ReadMessage(generationStatus);
				GenerationStatus = generationStatus;
				break;
			}
			}
		}
	}
}
