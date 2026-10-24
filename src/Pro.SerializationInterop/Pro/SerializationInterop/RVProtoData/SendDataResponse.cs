using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SendDataResponse : IMessage<SendDataResponse>, IMessage, IEquatable<SendDataResponse>, IDeepCloneable<SendDataResponse>
{
	public enum MessageTypeOneofCase
	{
		None = 0,
		ValidateEncoderResponse = 2,
		TimerState = 3,
		CaptureActionRequest = 4,
		TestPattern = 5,
		HandledException = 6,
		AudioPlaylistFocusUuid = 8,
		MediaPlaylistFocusUuid = 9,
		LibraryPlaylistFocusUuid = 10,
		LibraryPlaylistItemFocusUuid = 11,
		PropPause = 12,
		ShowMessage = 13,
		HideMessage = 14,
		GetMediaThumbnail = 15,
		RequestWebfillTokenAndCookies = 16,
		MediaAssetTriggered = 17,
		LeaveBreadcrumb = 18,
		SlideThumbnail = 19
	}

	private static readonly MessageParser<SendDataResponse> _parser = new MessageParser<SendDataResponse>(() => new SendDataResponse());

	private UnknownFieldSet _unknownFields;

	public const int MessageIdFieldNumber = 1;

	private int messageId_;

	public const int ValidateEncoderResponseFieldNumber = 2;

	public const int TimerStateFieldNumber = 3;

	public const int CaptureActionRequestFieldNumber = 4;

	public const int TestPatternFieldNumber = 5;

	public const int HandledExceptionFieldNumber = 6;

	public const int AudioPlaylistFocusUuidFieldNumber = 8;

	public const int MediaPlaylistFocusUuidFieldNumber = 9;

	public const int LibraryPlaylistFocusUuidFieldNumber = 10;

	public const int LibraryPlaylistItemFocusUuidFieldNumber = 11;

	public const int PropPauseFieldNumber = 12;

	public const int ShowMessageFieldNumber = 13;

	public const int HideMessageFieldNumber = 14;

	public const int GetMediaThumbnailFieldNumber = 15;

	public const int RequestWebfillTokenAndCookiesFieldNumber = 16;

	public const int MediaAssetTriggeredFieldNumber = 17;

	public const int LeaveBreadcrumbFieldNumber = 18;

	public const int SlideThumbnailFieldNumber = 19;

	private object messageType_;

	private MessageTypeOneofCase messageTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SendDataResponse> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[33];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MessageId
	{
		get
		{
			return messageId_;
		}
		set
		{
			messageId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ValidateEncoderResponse ValidateEncoderResponse
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.ValidateEncoderResponse)
			{
				return null;
			}
			return (ValidateEncoderResponse)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.ValidateEncoderResponse : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimerStateUpdate TimerState
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.TimerState)
			{
				return null;
			}
			return (TimerStateUpdate)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.TimerState : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionRequest CaptureActionRequest
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.CaptureActionRequest)
			{
				return null;
			}
			return (CaptureActionRequest)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.CaptureActionRequest : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternResponse TestPattern
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.TestPattern)
			{
				return null;
			}
			return (TestPatternResponse)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.TestPattern : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HandledException HandledException
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.HandledException)
			{
				return null;
			}
			return (HandledException)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.HandledException : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID AudioPlaylistFocusUuid
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.AudioPlaylistFocusUuid)
			{
				return null;
			}
			return (UUID)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.AudioPlaylistFocusUuid : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID MediaPlaylistFocusUuid
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.MediaPlaylistFocusUuid)
			{
				return null;
			}
			return (UUID)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.MediaPlaylistFocusUuid : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID LibraryPlaylistFocusUuid
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.LibraryPlaylistFocusUuid)
			{
				return null;
			}
			return (UUID)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.LibraryPlaylistFocusUuid : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID LibraryPlaylistItemFocusUuid
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.LibraryPlaylistItemFocusUuid)
			{
				return null;
			}
			return (UUID)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.LibraryPlaylistItemFocusUuid : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropPauseResponse PropPause
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.PropPause)
			{
				return null;
			}
			return (PropPauseResponse)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.PropPause : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ShowMessage ShowMessage
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.ShowMessage)
			{
				return null;
			}
			return (ShowMessage)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.ShowMessage : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GenericEvent HideMessage
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.HideMessage)
			{
				return null;
			}
			return (GenericEvent)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.HideMessage : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetMediaThumbnail GetMediaThumbnail
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.GetMediaThumbnail)
			{
				return null;
			}
			return (GetMediaThumbnail)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.GetMediaThumbnail : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestWebFillTokenAndCookies RequestWebfillTokenAndCookies
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.RequestWebfillTokenAndCookies)
			{
				return null;
			}
			return (RequestWebFillTokenAndCookies)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.RequestWebfillTokenAndCookies : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaAssetTriggered MediaAssetTriggered
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.MediaAssetTriggered)
			{
				return null;
			}
			return (MediaAssetTriggered)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.MediaAssetTriggered : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LeaveBreadcrumb LeaveBreadcrumb
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.LeaveBreadcrumb)
			{
				return null;
			}
			return (LeaveBreadcrumb)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.LeaveBreadcrumb : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideThumbnailResponse SlideThumbnail
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.SlideThumbnail)
			{
				return null;
			}
			return (SlideThumbnailResponse)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.SlideThumbnail : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageTypeOneofCase MessageTypeCase => messageTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SendDataResponse()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SendDataResponse(SendDataResponse other)
		: this()
	{
		messageId_ = other.messageId_;
		switch (other.MessageTypeCase)
		{
		case MessageTypeOneofCase.ValidateEncoderResponse:
			ValidateEncoderResponse = other.ValidateEncoderResponse.Clone();
			break;
		case MessageTypeOneofCase.TimerState:
			TimerState = other.TimerState.Clone();
			break;
		case MessageTypeOneofCase.CaptureActionRequest:
			CaptureActionRequest = other.CaptureActionRequest.Clone();
			break;
		case MessageTypeOneofCase.TestPattern:
			TestPattern = other.TestPattern.Clone();
			break;
		case MessageTypeOneofCase.HandledException:
			HandledException = other.HandledException.Clone();
			break;
		case MessageTypeOneofCase.AudioPlaylistFocusUuid:
			AudioPlaylistFocusUuid = other.AudioPlaylistFocusUuid.Clone();
			break;
		case MessageTypeOneofCase.MediaPlaylistFocusUuid:
			MediaPlaylistFocusUuid = other.MediaPlaylistFocusUuid.Clone();
			break;
		case MessageTypeOneofCase.LibraryPlaylistFocusUuid:
			LibraryPlaylistFocusUuid = other.LibraryPlaylistFocusUuid.Clone();
			break;
		case MessageTypeOneofCase.LibraryPlaylistItemFocusUuid:
			LibraryPlaylistItemFocusUuid = other.LibraryPlaylistItemFocusUuid.Clone();
			break;
		case MessageTypeOneofCase.PropPause:
			PropPause = other.PropPause.Clone();
			break;
		case MessageTypeOneofCase.ShowMessage:
			ShowMessage = other.ShowMessage.Clone();
			break;
		case MessageTypeOneofCase.HideMessage:
			HideMessage = other.HideMessage.Clone();
			break;
		case MessageTypeOneofCase.GetMediaThumbnail:
			GetMediaThumbnail = other.GetMediaThumbnail.Clone();
			break;
		case MessageTypeOneofCase.RequestWebfillTokenAndCookies:
			RequestWebfillTokenAndCookies = other.RequestWebfillTokenAndCookies.Clone();
			break;
		case MessageTypeOneofCase.MediaAssetTriggered:
			MediaAssetTriggered = other.MediaAssetTriggered.Clone();
			break;
		case MessageTypeOneofCase.LeaveBreadcrumb:
			LeaveBreadcrumb = other.LeaveBreadcrumb.Clone();
			break;
		case MessageTypeOneofCase.SlideThumbnail:
			SlideThumbnail = other.SlideThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SendDataResponse Clone()
	{
		return new SendDataResponse(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearMessageType()
	{
		messageTypeCase_ = MessageTypeOneofCase.None;
		messageType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SendDataResponse);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SendDataResponse other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (MessageId != other.MessageId)
		{
			return false;
		}
		if (!object.Equals(ValidateEncoderResponse, other.ValidateEncoderResponse))
		{
			return false;
		}
		if (!object.Equals(TimerState, other.TimerState))
		{
			return false;
		}
		if (!object.Equals(CaptureActionRequest, other.CaptureActionRequest))
		{
			return false;
		}
		if (!object.Equals(TestPattern, other.TestPattern))
		{
			return false;
		}
		if (!object.Equals(HandledException, other.HandledException))
		{
			return false;
		}
		if (!object.Equals(AudioPlaylistFocusUuid, other.AudioPlaylistFocusUuid))
		{
			return false;
		}
		if (!object.Equals(MediaPlaylistFocusUuid, other.MediaPlaylistFocusUuid))
		{
			return false;
		}
		if (!object.Equals(LibraryPlaylistFocusUuid, other.LibraryPlaylistFocusUuid))
		{
			return false;
		}
		if (!object.Equals(LibraryPlaylistItemFocusUuid, other.LibraryPlaylistItemFocusUuid))
		{
			return false;
		}
		if (!object.Equals(PropPause, other.PropPause))
		{
			return false;
		}
		if (!object.Equals(ShowMessage, other.ShowMessage))
		{
			return false;
		}
		if (!object.Equals(HideMessage, other.HideMessage))
		{
			return false;
		}
		if (!object.Equals(GetMediaThumbnail, other.GetMediaThumbnail))
		{
			return false;
		}
		if (!object.Equals(RequestWebfillTokenAndCookies, other.RequestWebfillTokenAndCookies))
		{
			return false;
		}
		if (!object.Equals(MediaAssetTriggered, other.MediaAssetTriggered))
		{
			return false;
		}
		if (!object.Equals(LeaveBreadcrumb, other.LeaveBreadcrumb))
		{
			return false;
		}
		if (!object.Equals(SlideThumbnail, other.SlideThumbnail))
		{
			return false;
		}
		if (MessageTypeCase != other.MessageTypeCase)
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
		if (MessageId != 0)
		{
			num ^= MessageId.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderResponse)
		{
			num ^= ValidateEncoderResponse.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TimerState)
		{
			num ^= TimerState.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionRequest)
		{
			num ^= CaptureActionRequest.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
		{
			num ^= TestPattern.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.HandledException)
		{
			num ^= HandledException.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistFocusUuid)
		{
			num ^= AudioPlaylistFocusUuid.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaPlaylistFocusUuid)
		{
			num ^= MediaPlaylistFocusUuid.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistFocusUuid)
		{
			num ^= LibraryPlaylistFocusUuid.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistItemFocusUuid)
		{
			num ^= LibraryPlaylistItemFocusUuid.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropPause)
		{
			num ^= PropPause.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ShowMessage)
		{
			num ^= ShowMessage.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.HideMessage)
		{
			num ^= HideMessage.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GetMediaThumbnail)
		{
			num ^= GetMediaThumbnail.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.RequestWebfillTokenAndCookies)
		{
			num ^= RequestWebfillTokenAndCookies.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaAssetTriggered)
		{
			num ^= MediaAssetTriggered.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LeaveBreadcrumb)
		{
			num ^= LeaveBreadcrumb.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.SlideThumbnail)
		{
			num ^= SlideThumbnail.GetHashCode();
		}
		num ^= (int)messageTypeCase_;
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
		if (MessageId != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(MessageId);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderResponse)
		{
			output.WriteRawTag(18);
			output.WriteMessage(ValidateEncoderResponse);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TimerState)
		{
			output.WriteRawTag(26);
			output.WriteMessage(TimerState);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionRequest)
		{
			output.WriteRawTag(34);
			output.WriteMessage(CaptureActionRequest);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
		{
			output.WriteRawTag(42);
			output.WriteMessage(TestPattern);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.HandledException)
		{
			output.WriteRawTag(50);
			output.WriteMessage(HandledException);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistFocusUuid)
		{
			output.WriteRawTag(66);
			output.WriteMessage(AudioPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaPlaylistFocusUuid)
		{
			output.WriteRawTag(74);
			output.WriteMessage(MediaPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistFocusUuid)
		{
			output.WriteRawTag(82);
			output.WriteMessage(LibraryPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistItemFocusUuid)
		{
			output.WriteRawTag(90);
			output.WriteMessage(LibraryPlaylistItemFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropPause)
		{
			output.WriteRawTag(98);
			output.WriteMessage(PropPause);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ShowMessage)
		{
			output.WriteRawTag(106);
			output.WriteMessage(ShowMessage);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.HideMessage)
		{
			output.WriteRawTag(114);
			output.WriteMessage(HideMessage);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GetMediaThumbnail)
		{
			output.WriteRawTag(122);
			output.WriteMessage(GetMediaThumbnail);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.RequestWebfillTokenAndCookies)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(RequestWebfillTokenAndCookies);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaAssetTriggered)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(MediaAssetTriggered);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LeaveBreadcrumb)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(LeaveBreadcrumb);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.SlideThumbnail)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(SlideThumbnail);
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
		if (MessageId != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MessageId);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderResponse)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ValidateEncoderResponse);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TimerState)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimerState);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionRequest)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CaptureActionRequest);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TestPattern);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.HandledException)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HandledException);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistFocusUuid)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaPlaylistFocusUuid)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistFocusUuid)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LibraryPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistItemFocusUuid)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LibraryPlaylistItemFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropPause)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PropPause);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ShowMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ShowMessage);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.HideMessage)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HideMessage);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GetMediaThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMediaThumbnail);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.RequestWebfillTokenAndCookies)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(RequestWebfillTokenAndCookies);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaAssetTriggered)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaAssetTriggered);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LeaveBreadcrumb)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LeaveBreadcrumb);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.SlideThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SlideThumbnail);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SendDataResponse other)
	{
		if (other == null)
		{
			return;
		}
		if (other.MessageId != 0)
		{
			MessageId = other.MessageId;
		}
		switch (other.MessageTypeCase)
		{
		case MessageTypeOneofCase.ValidateEncoderResponse:
			if (ValidateEncoderResponse == null)
			{
				ValidateEncoderResponse = new ValidateEncoderResponse();
			}
			ValidateEncoderResponse.MergeFrom(other.ValidateEncoderResponse);
			break;
		case MessageTypeOneofCase.TimerState:
			if (TimerState == null)
			{
				TimerState = new TimerStateUpdate();
			}
			TimerState.MergeFrom(other.TimerState);
			break;
		case MessageTypeOneofCase.CaptureActionRequest:
			if (CaptureActionRequest == null)
			{
				CaptureActionRequest = new CaptureActionRequest();
			}
			CaptureActionRequest.MergeFrom(other.CaptureActionRequest);
			break;
		case MessageTypeOneofCase.TestPattern:
			if (TestPattern == null)
			{
				TestPattern = new TestPatternResponse();
			}
			TestPattern.MergeFrom(other.TestPattern);
			break;
		case MessageTypeOneofCase.HandledException:
			if (HandledException == null)
			{
				HandledException = new HandledException();
			}
			HandledException.MergeFrom(other.HandledException);
			break;
		case MessageTypeOneofCase.AudioPlaylistFocusUuid:
			if (AudioPlaylistFocusUuid == null)
			{
				AudioPlaylistFocusUuid = new UUID();
			}
			AudioPlaylistFocusUuid.MergeFrom(other.AudioPlaylistFocusUuid);
			break;
		case MessageTypeOneofCase.MediaPlaylistFocusUuid:
			if (MediaPlaylistFocusUuid == null)
			{
				MediaPlaylistFocusUuid = new UUID();
			}
			MediaPlaylistFocusUuid.MergeFrom(other.MediaPlaylistFocusUuid);
			break;
		case MessageTypeOneofCase.LibraryPlaylistFocusUuid:
			if (LibraryPlaylistFocusUuid == null)
			{
				LibraryPlaylistFocusUuid = new UUID();
			}
			LibraryPlaylistFocusUuid.MergeFrom(other.LibraryPlaylistFocusUuid);
			break;
		case MessageTypeOneofCase.LibraryPlaylistItemFocusUuid:
			if (LibraryPlaylistItemFocusUuid == null)
			{
				LibraryPlaylistItemFocusUuid = new UUID();
			}
			LibraryPlaylistItemFocusUuid.MergeFrom(other.LibraryPlaylistItemFocusUuid);
			break;
		case MessageTypeOneofCase.PropPause:
			if (PropPause == null)
			{
				PropPause = new PropPauseResponse();
			}
			PropPause.MergeFrom(other.PropPause);
			break;
		case MessageTypeOneofCase.ShowMessage:
			if (ShowMessage == null)
			{
				ShowMessage = new ShowMessage();
			}
			ShowMessage.MergeFrom(other.ShowMessage);
			break;
		case MessageTypeOneofCase.HideMessage:
			if (HideMessage == null)
			{
				HideMessage = new GenericEvent();
			}
			HideMessage.MergeFrom(other.HideMessage);
			break;
		case MessageTypeOneofCase.GetMediaThumbnail:
			if (GetMediaThumbnail == null)
			{
				GetMediaThumbnail = new GetMediaThumbnail();
			}
			GetMediaThumbnail.MergeFrom(other.GetMediaThumbnail);
			break;
		case MessageTypeOneofCase.RequestWebfillTokenAndCookies:
			if (RequestWebfillTokenAndCookies == null)
			{
				RequestWebfillTokenAndCookies = new RequestWebFillTokenAndCookies();
			}
			RequestWebfillTokenAndCookies.MergeFrom(other.RequestWebfillTokenAndCookies);
			break;
		case MessageTypeOneofCase.MediaAssetTriggered:
			if (MediaAssetTriggered == null)
			{
				MediaAssetTriggered = new MediaAssetTriggered();
			}
			MediaAssetTriggered.MergeFrom(other.MediaAssetTriggered);
			break;
		case MessageTypeOneofCase.LeaveBreadcrumb:
			if (LeaveBreadcrumb == null)
			{
				LeaveBreadcrumb = new LeaveBreadcrumb();
			}
			LeaveBreadcrumb.MergeFrom(other.LeaveBreadcrumb);
			break;
		case MessageTypeOneofCase.SlideThumbnail:
			if (SlideThumbnail == null)
			{
				SlideThumbnail = new SlideThumbnailResponse();
			}
			SlideThumbnail.MergeFrom(other.SlideThumbnail);
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
			case 8u:
				MessageId = input.ReadInt32();
				break;
			case 18u:
			{
				ValidateEncoderResponse validateEncoderResponse = new ValidateEncoderResponse();
				if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderResponse)
				{
					validateEncoderResponse.MergeFrom(ValidateEncoderResponse);
				}
				input.ReadMessage(validateEncoderResponse);
				ValidateEncoderResponse = validateEncoderResponse;
				break;
			}
			case 26u:
			{
				TimerStateUpdate timerStateUpdate = new TimerStateUpdate();
				if (messageTypeCase_ == MessageTypeOneofCase.TimerState)
				{
					timerStateUpdate.MergeFrom(TimerState);
				}
				input.ReadMessage(timerStateUpdate);
				TimerState = timerStateUpdate;
				break;
			}
			case 34u:
			{
				CaptureActionRequest captureActionRequest = new CaptureActionRequest();
				if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionRequest)
				{
					captureActionRequest.MergeFrom(CaptureActionRequest);
				}
				input.ReadMessage(captureActionRequest);
				CaptureActionRequest = captureActionRequest;
				break;
			}
			case 42u:
			{
				TestPatternResponse testPatternResponse = new TestPatternResponse();
				if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
				{
					testPatternResponse.MergeFrom(TestPattern);
				}
				input.ReadMessage(testPatternResponse);
				TestPattern = testPatternResponse;
				break;
			}
			case 50u:
			{
				HandledException ex = new HandledException();
				if (messageTypeCase_ == MessageTypeOneofCase.HandledException)
				{
					ex.MergeFrom(HandledException);
				}
				input.ReadMessage(ex);
				HandledException = ex;
				break;
			}
			case 66u:
			{
				UUID uUID2 = new UUID();
				if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistFocusUuid)
				{
					uUID2.MergeFrom(AudioPlaylistFocusUuid);
				}
				input.ReadMessage(uUID2);
				AudioPlaylistFocusUuid = uUID2;
				break;
			}
			case 74u:
			{
				UUID uUID4 = new UUID();
				if (messageTypeCase_ == MessageTypeOneofCase.MediaPlaylistFocusUuid)
				{
					uUID4.MergeFrom(MediaPlaylistFocusUuid);
				}
				input.ReadMessage(uUID4);
				MediaPlaylistFocusUuid = uUID4;
				break;
			}
			case 82u:
			{
				UUID uUID3 = new UUID();
				if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistFocusUuid)
				{
					uUID3.MergeFrom(LibraryPlaylistFocusUuid);
				}
				input.ReadMessage(uUID3);
				LibraryPlaylistFocusUuid = uUID3;
				break;
			}
			case 90u:
			{
				UUID uUID = new UUID();
				if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistItemFocusUuid)
				{
					uUID.MergeFrom(LibraryPlaylistItemFocusUuid);
				}
				input.ReadMessage(uUID);
				LibraryPlaylistItemFocusUuid = uUID;
				break;
			}
			case 98u:
			{
				PropPauseResponse propPauseResponse = new PropPauseResponse();
				if (messageTypeCase_ == MessageTypeOneofCase.PropPause)
				{
					propPauseResponse.MergeFrom(PropPause);
				}
				input.ReadMessage(propPauseResponse);
				PropPause = propPauseResponse;
				break;
			}
			case 106u:
			{
				ShowMessage showMessage = new ShowMessage();
				if (messageTypeCase_ == MessageTypeOneofCase.ShowMessage)
				{
					showMessage.MergeFrom(ShowMessage);
				}
				input.ReadMessage(showMessage);
				ShowMessage = showMessage;
				break;
			}
			case 114u:
			{
				GenericEvent genericEvent = new GenericEvent();
				if (messageTypeCase_ == MessageTypeOneofCase.HideMessage)
				{
					genericEvent.MergeFrom(HideMessage);
				}
				input.ReadMessage(genericEvent);
				HideMessage = genericEvent;
				break;
			}
			case 122u:
			{
				GetMediaThumbnail getMediaThumbnail = new GetMediaThumbnail();
				if (messageTypeCase_ == MessageTypeOneofCase.GetMediaThumbnail)
				{
					getMediaThumbnail.MergeFrom(GetMediaThumbnail);
				}
				input.ReadMessage(getMediaThumbnail);
				GetMediaThumbnail = getMediaThumbnail;
				break;
			}
			case 130u:
			{
				RequestWebFillTokenAndCookies requestWebFillTokenAndCookies = new RequestWebFillTokenAndCookies();
				if (messageTypeCase_ == MessageTypeOneofCase.RequestWebfillTokenAndCookies)
				{
					requestWebFillTokenAndCookies.MergeFrom(RequestWebfillTokenAndCookies);
				}
				input.ReadMessage(requestWebFillTokenAndCookies);
				RequestWebfillTokenAndCookies = requestWebFillTokenAndCookies;
				break;
			}
			case 138u:
			{
				MediaAssetTriggered mediaAssetTriggered = new MediaAssetTriggered();
				if (messageTypeCase_ == MessageTypeOneofCase.MediaAssetTriggered)
				{
					mediaAssetTriggered.MergeFrom(MediaAssetTriggered);
				}
				input.ReadMessage(mediaAssetTriggered);
				MediaAssetTriggered = mediaAssetTriggered;
				break;
			}
			case 146u:
			{
				LeaveBreadcrumb leaveBreadcrumb = new LeaveBreadcrumb();
				if (messageTypeCase_ == MessageTypeOneofCase.LeaveBreadcrumb)
				{
					leaveBreadcrumb.MergeFrom(LeaveBreadcrumb);
				}
				input.ReadMessage(leaveBreadcrumb);
				LeaveBreadcrumb = leaveBreadcrumb;
				break;
			}
			case 154u:
			{
				SlideThumbnailResponse slideThumbnailResponse = new SlideThumbnailResponse();
				if (messageTypeCase_ == MessageTypeOneofCase.SlideThumbnail)
				{
					slideThumbnailResponse.MergeFrom(SlideThumbnail);
				}
				input.ReadMessage(slideThumbnailResponse);
				SlideThumbnail = slideThumbnailResponse;
				break;
			}
			}
		}
	}
}
