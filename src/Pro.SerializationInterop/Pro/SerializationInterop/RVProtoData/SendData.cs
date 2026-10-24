using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SendData : IMessage<SendData>, IMessage, IEquatable<SendData>, IDeepCloneable<SendData>
{
	public enum MessageTypeOneofCase
	{
		None = 0,
		Workspace = 2,
		StageDocument = 3,
		TimersDocument = 4,
		ValidateEncoderRequest = 5,
		TriggerCue = 6,
		DigitalAudioSetup = 7,
		MacrosDocument = 8,
		MessageDocument = 9,
		PropDocument = 10,
		CcliDocument = 11,
		AudienceLooks = 12,
		LiveAudienceLook = 13,
		Masks = 14,
		RecordingSettingsDocument = 15,
		CaptureActionResponse = 16,
		CopyrightLayout = 17,
		GlobalBackgroundTransition = 18,
		GlobalMessagesTransition = 19,
		GlobalForegroundTransition = 20,
		GlobalPropsTransition = 21,
		GlobalAudioTransition = 22,
		Preferences = 23,
		TestPattern = 24,
		StartupComplete = 25,
		VisualPlaylistDoc = 26,
		AudioPlaylistDoc = 27,
		KillWatchdog = 28,
		MacroIcons = 29,
		DebugTriggerDataDump = 30,
		LibraryPlaylistDoc = 31,
		AudioPlaylistFocusUuid = 32,
		MediaPlaylistFocusUuid = 33,
		LibraryPlaylistFocusUuid = 34,
		LibraryPlaylistItemFocusUuid = 35,
		PropPause = 36,
		MediaThumbnail = 37,
		PcoData = 38,
		WebfillTokenAndCookies = 39,
		PsbWorkspace = 40,
		InputStatusCallback = 41,
		SlideThumbnail = 42
	}

	private static readonly MessageParser<SendData> _parser = new MessageParser<SendData>(() => new SendData());

	private UnknownFieldSet _unknownFields;

	public const int MessageIdFieldNumber = 1;

	private int messageId_;

	public const int WorkspaceFieldNumber = 2;

	public const int StageDocumentFieldNumber = 3;

	public const int TimersDocumentFieldNumber = 4;

	public const int ValidateEncoderRequestFieldNumber = 5;

	public const int TriggerCueFieldNumber = 6;

	public const int DigitalAudioSetupFieldNumber = 7;

	public const int MacrosDocumentFieldNumber = 8;

	public const int MessageDocumentFieldNumber = 9;

	public const int PropDocumentFieldNumber = 10;

	public const int CcliDocumentFieldNumber = 11;

	public const int AudienceLooksFieldNumber = 12;

	public const int LiveAudienceLookFieldNumber = 13;

	public const int MasksFieldNumber = 14;

	public const int RecordingSettingsDocumentFieldNumber = 15;

	public const int CaptureActionResponseFieldNumber = 16;

	public const int CopyrightLayoutFieldNumber = 17;

	public const int GlobalBackgroundTransitionFieldNumber = 18;

	public const int GlobalMessagesTransitionFieldNumber = 19;

	public const int GlobalForegroundTransitionFieldNumber = 20;

	public const int GlobalPropsTransitionFieldNumber = 21;

	public const int GlobalAudioTransitionFieldNumber = 22;

	public const int PreferencesFieldNumber = 23;

	public const int TestPatternFieldNumber = 24;

	public const int StartupCompleteFieldNumber = 25;

	public const int VisualPlaylistDocFieldNumber = 26;

	public const int AudioPlaylistDocFieldNumber = 27;

	public const int KillWatchdogFieldNumber = 28;

	public const int MacroIconsFieldNumber = 29;

	public const int DebugTriggerDataDumpFieldNumber = 30;

	public const int LibraryPlaylistDocFieldNumber = 31;

	public const int AudioPlaylistFocusUuidFieldNumber = 32;

	public const int MediaPlaylistFocusUuidFieldNumber = 33;

	public const int LibraryPlaylistFocusUuidFieldNumber = 34;

	public const int LibraryPlaylistItemFocusUuidFieldNumber = 35;

	public const int PropPauseFieldNumber = 36;

	public const int MediaThumbnailFieldNumber = 37;

	public const int PcoDataFieldNumber = 38;

	public const int WebfillTokenAndCookiesFieldNumber = 39;

	public const int PsbWorkspaceFieldNumber = 40;

	public const int InputStatusCallbackFieldNumber = 41;

	public const int SlideThumbnailFieldNumber = 42;

	private object messageType_;

	private MessageTypeOneofCase messageTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SendData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[22];

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
	public ProPresenterWorkspace Workspace
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.Workspace)
			{
				return null;
			}
			return (ProPresenterWorkspace)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.Workspace : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Stage.Types.Document StageDocument
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.StageDocument)
			{
				return null;
			}
			return (Stage.Types.Document)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.StageDocument : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimersDocument TimersDocument
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.TimersDocument)
			{
				return null;
			}
			return (TimersDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.TimersDocument : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ValidateEncoderRequest ValidateEncoderRequest
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.ValidateEncoderRequest)
			{
				return null;
			}
			return (ValidateEncoderRequest)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.ValidateEncoderRequest : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerCue TriggerCue
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.TriggerCue)
			{
				return null;
			}
			return (TriggerCue)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.TriggerCue : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DigitalAudio.Types.Setup DigitalAudioSetup
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.DigitalAudioSetup)
			{
				return null;
			}
			return (DigitalAudio.Types.Setup)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.DigitalAudioSetup : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacrosDocument MacrosDocument
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.MacrosDocument)
			{
				return null;
			}
			return (MacrosDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.MacrosDocument : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageDocument MessageDocument
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.MessageDocument)
			{
				return null;
			}
			return (MessageDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.MessageDocument : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropDocument PropDocument
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.PropDocument)
			{
				return null;
			}
			return (PropDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.PropDocument : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CCLIDocument CcliDocument
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.CcliDocument)
			{
				return null;
			}
			return (CCLIDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.CcliDocument : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AudienceLookCollection AudienceLooks
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.AudienceLooks)
			{
				return null;
			}
			return (AudienceLookCollection)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.AudienceLooks : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProAudienceLook LiveAudienceLook
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.LiveAudienceLook)
			{
				return null;
			}
			return (ProAudienceLook)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.LiveAudienceLook : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MaskCollection Masks
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.Masks)
			{
				return null;
			}
			return (MaskCollection)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.Masks : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Recording.Types.SettingsDocument RecordingSettingsDocument
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.RecordingSettingsDocument)
			{
				return null;
			}
			return (Recording.Types.SettingsDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.RecordingSettingsDocument : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionResponse CaptureActionResponse
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.CaptureActionResponse)
			{
				return null;
			}
			return (CaptureActionResponse)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.CaptureActionResponse : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CopyrightLayout CopyrightLayout
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.CopyrightLayout)
			{
				return null;
			}
			return (CopyrightLayout)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.CopyrightLayout : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition GlobalBackgroundTransition
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.GlobalBackgroundTransition)
			{
				return null;
			}
			return (Transition)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.GlobalBackgroundTransition : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition GlobalMessagesTransition
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.GlobalMessagesTransition)
			{
				return null;
			}
			return (Transition)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.GlobalMessagesTransition : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition GlobalForegroundTransition
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.GlobalForegroundTransition)
			{
				return null;
			}
			return (Transition)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.GlobalForegroundTransition : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition GlobalPropsTransition
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.GlobalPropsTransition)
			{
				return null;
			}
			return (Transition)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.GlobalPropsTransition : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition GlobalAudioTransition
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.GlobalAudioTransition)
			{
				return null;
			}
			return (Transition)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.GlobalAudioTransition : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences Preferences
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.Preferences)
			{
				return null;
			}
			return (Preferences)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.Preferences : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPatternRequest TestPattern
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.TestPattern)
			{
				return null;
			}
			return (TestPatternRequest)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.TestPattern : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GenericEvent StartupComplete
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.StartupComplete)
			{
				return null;
			}
			return (GenericEvent)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.StartupComplete : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistDocument VisualPlaylistDoc
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.VisualPlaylistDoc)
			{
				return null;
			}
			return (PlaylistDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.VisualPlaylistDoc : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistDocument AudioPlaylistDoc
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.AudioPlaylistDoc)
			{
				return null;
			}
			return (PlaylistDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.AudioPlaylistDoc : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GenericEvent KillWatchdog
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.KillWatchdog)
			{
				return null;
			}
			return (GenericEvent)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.KillWatchdog : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacroIcons MacroIcons
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.MacroIcons)
			{
				return null;
			}
			return (MacroIcons)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.MacroIcons : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GenericEvent DebugTriggerDataDump
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.DebugTriggerDataDump)
			{
				return null;
			}
			return (GenericEvent)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.DebugTriggerDataDump : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistDocument LibraryPlaylistDoc
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.LibraryPlaylistDoc)
			{
				return null;
			}
			return (PlaylistDocument)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.LibraryPlaylistDoc : MessageTypeOneofCase.None);
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
	public PropPauseRequest PropPause
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.PropPause)
			{
				return null;
			}
			return (PropPauseRequest)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.PropPause : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaThumbnail MediaThumbnail
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.MediaThumbnail)
			{
				return null;
			}
			return (MediaThumbnail)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.MediaThumbnail : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PCOData PcoData
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.PcoData)
			{
				return null;
			}
			return (PCOData)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.PcoData : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WebFillTokenAndCookies WebfillTokenAndCookies
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.WebfillTokenAndCookies)
			{
				return null;
			}
			return (WebFillTokenAndCookies)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.WebfillTokenAndCookies : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProScoreboardWorkspace PsbWorkspace
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.PsbWorkspace)
			{
				return null;
			}
			return (ProScoreboardWorkspace)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.PsbWorkspace : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InputStatusCallback InputStatusCallback
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.InputStatusCallback)
			{
				return null;
			}
			return (InputStatusCallback)messageType_;
		}
		set
		{
			messageType_ = value;
			messageTypeCase_ = ((value != null) ? MessageTypeOneofCase.InputStatusCallback : MessageTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SlideThumbnailRequest SlideThumbnail
	{
		get
		{
			if (messageTypeCase_ != MessageTypeOneofCase.SlideThumbnail)
			{
				return null;
			}
			return (SlideThumbnailRequest)messageType_;
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
	public SendData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SendData(SendData other)
		: this()
	{
		messageId_ = other.messageId_;
		switch (other.MessageTypeCase)
		{
		case MessageTypeOneofCase.Workspace:
			Workspace = other.Workspace.Clone();
			break;
		case MessageTypeOneofCase.StageDocument:
			StageDocument = other.StageDocument.Clone();
			break;
		case MessageTypeOneofCase.TimersDocument:
			TimersDocument = other.TimersDocument.Clone();
			break;
		case MessageTypeOneofCase.ValidateEncoderRequest:
			ValidateEncoderRequest = other.ValidateEncoderRequest.Clone();
			break;
		case MessageTypeOneofCase.TriggerCue:
			TriggerCue = other.TriggerCue.Clone();
			break;
		case MessageTypeOneofCase.DigitalAudioSetup:
			DigitalAudioSetup = other.DigitalAudioSetup.Clone();
			break;
		case MessageTypeOneofCase.MacrosDocument:
			MacrosDocument = other.MacrosDocument.Clone();
			break;
		case MessageTypeOneofCase.MessageDocument:
			MessageDocument = other.MessageDocument.Clone();
			break;
		case MessageTypeOneofCase.PropDocument:
			PropDocument = other.PropDocument.Clone();
			break;
		case MessageTypeOneofCase.CcliDocument:
			CcliDocument = other.CcliDocument.Clone();
			break;
		case MessageTypeOneofCase.AudienceLooks:
			AudienceLooks = other.AudienceLooks.Clone();
			break;
		case MessageTypeOneofCase.LiveAudienceLook:
			LiveAudienceLook = other.LiveAudienceLook.Clone();
			break;
		case MessageTypeOneofCase.Masks:
			Masks = other.Masks.Clone();
			break;
		case MessageTypeOneofCase.RecordingSettingsDocument:
			RecordingSettingsDocument = other.RecordingSettingsDocument.Clone();
			break;
		case MessageTypeOneofCase.CaptureActionResponse:
			CaptureActionResponse = other.CaptureActionResponse.Clone();
			break;
		case MessageTypeOneofCase.CopyrightLayout:
			CopyrightLayout = other.CopyrightLayout.Clone();
			break;
		case MessageTypeOneofCase.GlobalBackgroundTransition:
			GlobalBackgroundTransition = other.GlobalBackgroundTransition.Clone();
			break;
		case MessageTypeOneofCase.GlobalMessagesTransition:
			GlobalMessagesTransition = other.GlobalMessagesTransition.Clone();
			break;
		case MessageTypeOneofCase.GlobalForegroundTransition:
			GlobalForegroundTransition = other.GlobalForegroundTransition.Clone();
			break;
		case MessageTypeOneofCase.GlobalPropsTransition:
			GlobalPropsTransition = other.GlobalPropsTransition.Clone();
			break;
		case MessageTypeOneofCase.GlobalAudioTransition:
			GlobalAudioTransition = other.GlobalAudioTransition.Clone();
			break;
		case MessageTypeOneofCase.Preferences:
			Preferences = other.Preferences.Clone();
			break;
		case MessageTypeOneofCase.TestPattern:
			TestPattern = other.TestPattern.Clone();
			break;
		case MessageTypeOneofCase.StartupComplete:
			StartupComplete = other.StartupComplete.Clone();
			break;
		case MessageTypeOneofCase.VisualPlaylistDoc:
			VisualPlaylistDoc = other.VisualPlaylistDoc.Clone();
			break;
		case MessageTypeOneofCase.AudioPlaylistDoc:
			AudioPlaylistDoc = other.AudioPlaylistDoc.Clone();
			break;
		case MessageTypeOneofCase.KillWatchdog:
			KillWatchdog = other.KillWatchdog.Clone();
			break;
		case MessageTypeOneofCase.MacroIcons:
			MacroIcons = other.MacroIcons.Clone();
			break;
		case MessageTypeOneofCase.DebugTriggerDataDump:
			DebugTriggerDataDump = other.DebugTriggerDataDump.Clone();
			break;
		case MessageTypeOneofCase.LibraryPlaylistDoc:
			LibraryPlaylistDoc = other.LibraryPlaylistDoc.Clone();
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
		case MessageTypeOneofCase.MediaThumbnail:
			MediaThumbnail = other.MediaThumbnail.Clone();
			break;
		case MessageTypeOneofCase.PcoData:
			PcoData = other.PcoData.Clone();
			break;
		case MessageTypeOneofCase.WebfillTokenAndCookies:
			WebfillTokenAndCookies = other.WebfillTokenAndCookies.Clone();
			break;
		case MessageTypeOneofCase.PsbWorkspace:
			PsbWorkspace = other.PsbWorkspace.Clone();
			break;
		case MessageTypeOneofCase.InputStatusCallback:
			InputStatusCallback = other.InputStatusCallback.Clone();
			break;
		case MessageTypeOneofCase.SlideThumbnail:
			SlideThumbnail = other.SlideThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SendData Clone()
	{
		return new SendData(this);
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
		return Equals(other as SendData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SendData other)
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
		if (!object.Equals(Workspace, other.Workspace))
		{
			return false;
		}
		if (!object.Equals(StageDocument, other.StageDocument))
		{
			return false;
		}
		if (!object.Equals(TimersDocument, other.TimersDocument))
		{
			return false;
		}
		if (!object.Equals(ValidateEncoderRequest, other.ValidateEncoderRequest))
		{
			return false;
		}
		if (!object.Equals(TriggerCue, other.TriggerCue))
		{
			return false;
		}
		if (!object.Equals(DigitalAudioSetup, other.DigitalAudioSetup))
		{
			return false;
		}
		if (!object.Equals(MacrosDocument, other.MacrosDocument))
		{
			return false;
		}
		if (!object.Equals(MessageDocument, other.MessageDocument))
		{
			return false;
		}
		if (!object.Equals(PropDocument, other.PropDocument))
		{
			return false;
		}
		if (!object.Equals(CcliDocument, other.CcliDocument))
		{
			return false;
		}
		if (!object.Equals(AudienceLooks, other.AudienceLooks))
		{
			return false;
		}
		if (!object.Equals(LiveAudienceLook, other.LiveAudienceLook))
		{
			return false;
		}
		if (!object.Equals(Masks, other.Masks))
		{
			return false;
		}
		if (!object.Equals(RecordingSettingsDocument, other.RecordingSettingsDocument))
		{
			return false;
		}
		if (!object.Equals(CaptureActionResponse, other.CaptureActionResponse))
		{
			return false;
		}
		if (!object.Equals(CopyrightLayout, other.CopyrightLayout))
		{
			return false;
		}
		if (!object.Equals(GlobalBackgroundTransition, other.GlobalBackgroundTransition))
		{
			return false;
		}
		if (!object.Equals(GlobalMessagesTransition, other.GlobalMessagesTransition))
		{
			return false;
		}
		if (!object.Equals(GlobalForegroundTransition, other.GlobalForegroundTransition))
		{
			return false;
		}
		if (!object.Equals(GlobalPropsTransition, other.GlobalPropsTransition))
		{
			return false;
		}
		if (!object.Equals(GlobalAudioTransition, other.GlobalAudioTransition))
		{
			return false;
		}
		if (!object.Equals(Preferences, other.Preferences))
		{
			return false;
		}
		if (!object.Equals(TestPattern, other.TestPattern))
		{
			return false;
		}
		if (!object.Equals(StartupComplete, other.StartupComplete))
		{
			return false;
		}
		if (!object.Equals(VisualPlaylistDoc, other.VisualPlaylistDoc))
		{
			return false;
		}
		if (!object.Equals(AudioPlaylistDoc, other.AudioPlaylistDoc))
		{
			return false;
		}
		if (!object.Equals(KillWatchdog, other.KillWatchdog))
		{
			return false;
		}
		if (!object.Equals(MacroIcons, other.MacroIcons))
		{
			return false;
		}
		if (!object.Equals(DebugTriggerDataDump, other.DebugTriggerDataDump))
		{
			return false;
		}
		if (!object.Equals(LibraryPlaylistDoc, other.LibraryPlaylistDoc))
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
		if (!object.Equals(MediaThumbnail, other.MediaThumbnail))
		{
			return false;
		}
		if (!object.Equals(PcoData, other.PcoData))
		{
			return false;
		}
		if (!object.Equals(WebfillTokenAndCookies, other.WebfillTokenAndCookies))
		{
			return false;
		}
		if (!object.Equals(PsbWorkspace, other.PsbWorkspace))
		{
			return false;
		}
		if (!object.Equals(InputStatusCallback, other.InputStatusCallback))
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
		if (messageTypeCase_ == MessageTypeOneofCase.Workspace)
		{
			num ^= Workspace.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.StageDocument)
		{
			num ^= StageDocument.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TimersDocument)
		{
			num ^= TimersDocument.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderRequest)
		{
			num ^= ValidateEncoderRequest.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TriggerCue)
		{
			num ^= TriggerCue.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.DigitalAudioSetup)
		{
			num ^= DigitalAudioSetup.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MacrosDocument)
		{
			num ^= MacrosDocument.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MessageDocument)
		{
			num ^= MessageDocument.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropDocument)
		{
			num ^= PropDocument.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CcliDocument)
		{
			num ^= CcliDocument.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudienceLooks)
		{
			num ^= AudienceLooks.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LiveAudienceLook)
		{
			num ^= LiveAudienceLook.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.Masks)
		{
			num ^= Masks.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.RecordingSettingsDocument)
		{
			num ^= RecordingSettingsDocument.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionResponse)
		{
			num ^= CaptureActionResponse.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CopyrightLayout)
		{
			num ^= CopyrightLayout.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalBackgroundTransition)
		{
			num ^= GlobalBackgroundTransition.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalMessagesTransition)
		{
			num ^= GlobalMessagesTransition.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalForegroundTransition)
		{
			num ^= GlobalForegroundTransition.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalPropsTransition)
		{
			num ^= GlobalPropsTransition.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalAudioTransition)
		{
			num ^= GlobalAudioTransition.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.Preferences)
		{
			num ^= Preferences.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
		{
			num ^= TestPattern.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.StartupComplete)
		{
			num ^= StartupComplete.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.VisualPlaylistDoc)
		{
			num ^= VisualPlaylistDoc.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistDoc)
		{
			num ^= AudioPlaylistDoc.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.KillWatchdog)
		{
			num ^= KillWatchdog.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MacroIcons)
		{
			num ^= MacroIcons.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.DebugTriggerDataDump)
		{
			num ^= DebugTriggerDataDump.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistDoc)
		{
			num ^= LibraryPlaylistDoc.GetHashCode();
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
		if (messageTypeCase_ == MessageTypeOneofCase.MediaThumbnail)
		{
			num ^= MediaThumbnail.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PcoData)
		{
			num ^= PcoData.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.WebfillTokenAndCookies)
		{
			num ^= WebfillTokenAndCookies.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PsbWorkspace)
		{
			num ^= PsbWorkspace.GetHashCode();
		}
		if (messageTypeCase_ == MessageTypeOneofCase.InputStatusCallback)
		{
			num ^= InputStatusCallback.GetHashCode();
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
		if (messageTypeCase_ == MessageTypeOneofCase.Workspace)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Workspace);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.StageDocument)
		{
			output.WriteRawTag(26);
			output.WriteMessage(StageDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TimersDocument)
		{
			output.WriteRawTag(34);
			output.WriteMessage(TimersDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderRequest)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ValidateEncoderRequest);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TriggerCue)
		{
			output.WriteRawTag(50);
			output.WriteMessage(TriggerCue);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.DigitalAudioSetup)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DigitalAudioSetup);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MacrosDocument)
		{
			output.WriteRawTag(66);
			output.WriteMessage(MacrosDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MessageDocument)
		{
			output.WriteRawTag(74);
			output.WriteMessage(MessageDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropDocument)
		{
			output.WriteRawTag(82);
			output.WriteMessage(PropDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CcliDocument)
		{
			output.WriteRawTag(90);
			output.WriteMessage(CcliDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudienceLooks)
		{
			output.WriteRawTag(98);
			output.WriteMessage(AudienceLooks);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LiveAudienceLook)
		{
			output.WriteRawTag(106);
			output.WriteMessage(LiveAudienceLook);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.Masks)
		{
			output.WriteRawTag(114);
			output.WriteMessage(Masks);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.RecordingSettingsDocument)
		{
			output.WriteRawTag(122);
			output.WriteMessage(RecordingSettingsDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionResponse)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(CaptureActionResponse);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CopyrightLayout)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(CopyrightLayout);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalBackgroundTransition)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(GlobalBackgroundTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalMessagesTransition)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(GlobalMessagesTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalForegroundTransition)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(GlobalForegroundTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalPropsTransition)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(GlobalPropsTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalAudioTransition)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(GlobalAudioTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.Preferences)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(Preferences);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
		{
			output.WriteRawTag(194, 1);
			output.WriteMessage(TestPattern);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.StartupComplete)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(StartupComplete);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.VisualPlaylistDoc)
		{
			output.WriteRawTag(210, 1);
			output.WriteMessage(VisualPlaylistDoc);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistDoc)
		{
			output.WriteRawTag(218, 1);
			output.WriteMessage(AudioPlaylistDoc);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.KillWatchdog)
		{
			output.WriteRawTag(226, 1);
			output.WriteMessage(KillWatchdog);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MacroIcons)
		{
			output.WriteRawTag(234, 1);
			output.WriteMessage(MacroIcons);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.DebugTriggerDataDump)
		{
			output.WriteRawTag(242, 1);
			output.WriteMessage(DebugTriggerDataDump);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistDoc)
		{
			output.WriteRawTag(250, 1);
			output.WriteMessage(LibraryPlaylistDoc);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistFocusUuid)
		{
			output.WriteRawTag(130, 2);
			output.WriteMessage(AudioPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaPlaylistFocusUuid)
		{
			output.WriteRawTag(138, 2);
			output.WriteMessage(MediaPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistFocusUuid)
		{
			output.WriteRawTag(146, 2);
			output.WriteMessage(LibraryPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistItemFocusUuid)
		{
			output.WriteRawTag(154, 2);
			output.WriteMessage(LibraryPlaylistItemFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropPause)
		{
			output.WriteRawTag(162, 2);
			output.WriteMessage(PropPause);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaThumbnail)
		{
			output.WriteRawTag(170, 2);
			output.WriteMessage(MediaThumbnail);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PcoData)
		{
			output.WriteRawTag(178, 2);
			output.WriteMessage(PcoData);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.WebfillTokenAndCookies)
		{
			output.WriteRawTag(186, 2);
			output.WriteMessage(WebfillTokenAndCookies);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PsbWorkspace)
		{
			output.WriteRawTag(194, 2);
			output.WriteMessage(PsbWorkspace);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.InputStatusCallback)
		{
			output.WriteRawTag(202, 2);
			output.WriteMessage(InputStatusCallback);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.SlideThumbnail)
		{
			output.WriteRawTag(210, 2);
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
		if (messageTypeCase_ == MessageTypeOneofCase.Workspace)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Workspace);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.StageDocument)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StageDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TimersDocument)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TimersDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderRequest)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ValidateEncoderRequest);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TriggerCue)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerCue);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.DigitalAudioSetup)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DigitalAudioSetup);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MacrosDocument)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MacrosDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MessageDocument)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MessageDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropDocument)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PropDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CcliDocument)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CcliDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudienceLooks)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudienceLooks);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LiveAudienceLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LiveAudienceLook);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.Masks)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Masks);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.RecordingSettingsDocument)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RecordingSettingsDocument);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionResponse)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(CaptureActionResponse);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.CopyrightLayout)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(CopyrightLayout);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalBackgroundTransition)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GlobalBackgroundTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalMessagesTransition)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GlobalMessagesTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalForegroundTransition)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GlobalForegroundTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalPropsTransition)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GlobalPropsTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.GlobalAudioTransition)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GlobalAudioTransition);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.Preferences)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Preferences);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TestPattern);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.StartupComplete)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(StartupComplete);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.VisualPlaylistDoc)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(VisualPlaylistDoc);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistDoc)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioPlaylistDoc);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.KillWatchdog)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(KillWatchdog);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MacroIcons)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MacroIcons);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.DebugTriggerDataDump)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(DebugTriggerDataDump);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistDoc)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LibraryPlaylistDoc);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistFocusUuid)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(AudioPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaPlaylistFocusUuid)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistFocusUuid)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LibraryPlaylistFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistItemFocusUuid)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LibraryPlaylistItemFocusUuid);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PropPause)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PropPause);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.MediaThumbnail)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MediaThumbnail);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PcoData)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PcoData);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.WebfillTokenAndCookies)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(WebfillTokenAndCookies);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.PsbWorkspace)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(PsbWorkspace);
		}
		if (messageTypeCase_ == MessageTypeOneofCase.InputStatusCallback)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(InputStatusCallback);
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
	public void MergeFrom(SendData other)
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
		case MessageTypeOneofCase.Workspace:
			if (Workspace == null)
			{
				Workspace = new ProPresenterWorkspace();
			}
			Workspace.MergeFrom(other.Workspace);
			break;
		case MessageTypeOneofCase.StageDocument:
			if (StageDocument == null)
			{
				StageDocument = new Stage.Types.Document();
			}
			StageDocument.MergeFrom(other.StageDocument);
			break;
		case MessageTypeOneofCase.TimersDocument:
			if (TimersDocument == null)
			{
				TimersDocument = new TimersDocument();
			}
			TimersDocument.MergeFrom(other.TimersDocument);
			break;
		case MessageTypeOneofCase.ValidateEncoderRequest:
			if (ValidateEncoderRequest == null)
			{
				ValidateEncoderRequest = new ValidateEncoderRequest();
			}
			ValidateEncoderRequest.MergeFrom(other.ValidateEncoderRequest);
			break;
		case MessageTypeOneofCase.TriggerCue:
			if (TriggerCue == null)
			{
				TriggerCue = new TriggerCue();
			}
			TriggerCue.MergeFrom(other.TriggerCue);
			break;
		case MessageTypeOneofCase.DigitalAudioSetup:
			if (DigitalAudioSetup == null)
			{
				DigitalAudioSetup = new DigitalAudio.Types.Setup();
			}
			DigitalAudioSetup.MergeFrom(other.DigitalAudioSetup);
			break;
		case MessageTypeOneofCase.MacrosDocument:
			if (MacrosDocument == null)
			{
				MacrosDocument = new MacrosDocument();
			}
			MacrosDocument.MergeFrom(other.MacrosDocument);
			break;
		case MessageTypeOneofCase.MessageDocument:
			if (MessageDocument == null)
			{
				MessageDocument = new MessageDocument();
			}
			MessageDocument.MergeFrom(other.MessageDocument);
			break;
		case MessageTypeOneofCase.PropDocument:
			if (PropDocument == null)
			{
				PropDocument = new PropDocument();
			}
			PropDocument.MergeFrom(other.PropDocument);
			break;
		case MessageTypeOneofCase.CcliDocument:
			if (CcliDocument == null)
			{
				CcliDocument = new CCLIDocument();
			}
			CcliDocument.MergeFrom(other.CcliDocument);
			break;
		case MessageTypeOneofCase.AudienceLooks:
			if (AudienceLooks == null)
			{
				AudienceLooks = new AudienceLookCollection();
			}
			AudienceLooks.MergeFrom(other.AudienceLooks);
			break;
		case MessageTypeOneofCase.LiveAudienceLook:
			if (LiveAudienceLook == null)
			{
				LiveAudienceLook = new ProAudienceLook();
			}
			LiveAudienceLook.MergeFrom(other.LiveAudienceLook);
			break;
		case MessageTypeOneofCase.Masks:
			if (Masks == null)
			{
				Masks = new MaskCollection();
			}
			Masks.MergeFrom(other.Masks);
			break;
		case MessageTypeOneofCase.RecordingSettingsDocument:
			if (RecordingSettingsDocument == null)
			{
				RecordingSettingsDocument = new Recording.Types.SettingsDocument();
			}
			RecordingSettingsDocument.MergeFrom(other.RecordingSettingsDocument);
			break;
		case MessageTypeOneofCase.CaptureActionResponse:
			if (CaptureActionResponse == null)
			{
				CaptureActionResponse = new CaptureActionResponse();
			}
			CaptureActionResponse.MergeFrom(other.CaptureActionResponse);
			break;
		case MessageTypeOneofCase.CopyrightLayout:
			if (CopyrightLayout == null)
			{
				CopyrightLayout = new CopyrightLayout();
			}
			CopyrightLayout.MergeFrom(other.CopyrightLayout);
			break;
		case MessageTypeOneofCase.GlobalBackgroundTransition:
			if (GlobalBackgroundTransition == null)
			{
				GlobalBackgroundTransition = new Transition();
			}
			GlobalBackgroundTransition.MergeFrom(other.GlobalBackgroundTransition);
			break;
		case MessageTypeOneofCase.GlobalMessagesTransition:
			if (GlobalMessagesTransition == null)
			{
				GlobalMessagesTransition = new Transition();
			}
			GlobalMessagesTransition.MergeFrom(other.GlobalMessagesTransition);
			break;
		case MessageTypeOneofCase.GlobalForegroundTransition:
			if (GlobalForegroundTransition == null)
			{
				GlobalForegroundTransition = new Transition();
			}
			GlobalForegroundTransition.MergeFrom(other.GlobalForegroundTransition);
			break;
		case MessageTypeOneofCase.GlobalPropsTransition:
			if (GlobalPropsTransition == null)
			{
				GlobalPropsTransition = new Transition();
			}
			GlobalPropsTransition.MergeFrom(other.GlobalPropsTransition);
			break;
		case MessageTypeOneofCase.GlobalAudioTransition:
			if (GlobalAudioTransition == null)
			{
				GlobalAudioTransition = new Transition();
			}
			GlobalAudioTransition.MergeFrom(other.GlobalAudioTransition);
			break;
		case MessageTypeOneofCase.Preferences:
			if (Preferences == null)
			{
				Preferences = new Preferences();
			}
			Preferences.MergeFrom(other.Preferences);
			break;
		case MessageTypeOneofCase.TestPattern:
			if (TestPattern == null)
			{
				TestPattern = new TestPatternRequest();
			}
			TestPattern.MergeFrom(other.TestPattern);
			break;
		case MessageTypeOneofCase.StartupComplete:
			if (StartupComplete == null)
			{
				StartupComplete = new GenericEvent();
			}
			StartupComplete.MergeFrom(other.StartupComplete);
			break;
		case MessageTypeOneofCase.VisualPlaylistDoc:
			if (VisualPlaylistDoc == null)
			{
				VisualPlaylistDoc = new PlaylistDocument();
			}
			VisualPlaylistDoc.MergeFrom(other.VisualPlaylistDoc);
			break;
		case MessageTypeOneofCase.AudioPlaylistDoc:
			if (AudioPlaylistDoc == null)
			{
				AudioPlaylistDoc = new PlaylistDocument();
			}
			AudioPlaylistDoc.MergeFrom(other.AudioPlaylistDoc);
			break;
		case MessageTypeOneofCase.KillWatchdog:
			if (KillWatchdog == null)
			{
				KillWatchdog = new GenericEvent();
			}
			KillWatchdog.MergeFrom(other.KillWatchdog);
			break;
		case MessageTypeOneofCase.MacroIcons:
			if (MacroIcons == null)
			{
				MacroIcons = new MacroIcons();
			}
			MacroIcons.MergeFrom(other.MacroIcons);
			break;
		case MessageTypeOneofCase.DebugTriggerDataDump:
			if (DebugTriggerDataDump == null)
			{
				DebugTriggerDataDump = new GenericEvent();
			}
			DebugTriggerDataDump.MergeFrom(other.DebugTriggerDataDump);
			break;
		case MessageTypeOneofCase.LibraryPlaylistDoc:
			if (LibraryPlaylistDoc == null)
			{
				LibraryPlaylistDoc = new PlaylistDocument();
			}
			LibraryPlaylistDoc.MergeFrom(other.LibraryPlaylistDoc);
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
				PropPause = new PropPauseRequest();
			}
			PropPause.MergeFrom(other.PropPause);
			break;
		case MessageTypeOneofCase.MediaThumbnail:
			if (MediaThumbnail == null)
			{
				MediaThumbnail = new MediaThumbnail();
			}
			MediaThumbnail.MergeFrom(other.MediaThumbnail);
			break;
		case MessageTypeOneofCase.PcoData:
			if (PcoData == null)
			{
				PcoData = new PCOData();
			}
			PcoData.MergeFrom(other.PcoData);
			break;
		case MessageTypeOneofCase.WebfillTokenAndCookies:
			if (WebfillTokenAndCookies == null)
			{
				WebfillTokenAndCookies = new WebFillTokenAndCookies();
			}
			WebfillTokenAndCookies.MergeFrom(other.WebfillTokenAndCookies);
			break;
		case MessageTypeOneofCase.PsbWorkspace:
			if (PsbWorkspace == null)
			{
				PsbWorkspace = new ProScoreboardWorkspace();
			}
			PsbWorkspace.MergeFrom(other.PsbWorkspace);
			break;
		case MessageTypeOneofCase.InputStatusCallback:
			if (InputStatusCallback == null)
			{
				InputStatusCallback = new InputStatusCallback();
			}
			InputStatusCallback.MergeFrom(other.InputStatusCallback);
			break;
		case MessageTypeOneofCase.SlideThumbnail:
			if (SlideThumbnail == null)
			{
				SlideThumbnail = new SlideThumbnailRequest();
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
				ProPresenterWorkspace proPresenterWorkspace = new ProPresenterWorkspace();
				if (messageTypeCase_ == MessageTypeOneofCase.Workspace)
				{
					proPresenterWorkspace.MergeFrom(Workspace);
				}
				input.ReadMessage(proPresenterWorkspace);
				Workspace = proPresenterWorkspace;
				break;
			}
			case 26u:
			{
				Stage.Types.Document document = new Stage.Types.Document();
				if (messageTypeCase_ == MessageTypeOneofCase.StageDocument)
				{
					document.MergeFrom(StageDocument);
				}
				input.ReadMessage(document);
				StageDocument = document;
				break;
			}
			case 34u:
			{
				TimersDocument timersDocument = new TimersDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.TimersDocument)
				{
					timersDocument.MergeFrom(TimersDocument);
				}
				input.ReadMessage(timersDocument);
				TimersDocument = timersDocument;
				break;
			}
			case 42u:
			{
				ValidateEncoderRequest validateEncoderRequest = new ValidateEncoderRequest();
				if (messageTypeCase_ == MessageTypeOneofCase.ValidateEncoderRequest)
				{
					validateEncoderRequest.MergeFrom(ValidateEncoderRequest);
				}
				input.ReadMessage(validateEncoderRequest);
				ValidateEncoderRequest = validateEncoderRequest;
				break;
			}
			case 50u:
			{
				TriggerCue triggerCue = new TriggerCue();
				if (messageTypeCase_ == MessageTypeOneofCase.TriggerCue)
				{
					triggerCue.MergeFrom(TriggerCue);
				}
				input.ReadMessage(triggerCue);
				TriggerCue = triggerCue;
				break;
			}
			case 58u:
			{
				DigitalAudio.Types.Setup setup = new DigitalAudio.Types.Setup();
				if (messageTypeCase_ == MessageTypeOneofCase.DigitalAudioSetup)
				{
					setup.MergeFrom(DigitalAudioSetup);
				}
				input.ReadMessage(setup);
				DigitalAudioSetup = setup;
				break;
			}
			case 66u:
			{
				MacrosDocument macrosDocument = new MacrosDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.MacrosDocument)
				{
					macrosDocument.MergeFrom(MacrosDocument);
				}
				input.ReadMessage(macrosDocument);
				MacrosDocument = macrosDocument;
				break;
			}
			case 74u:
			{
				MessageDocument messageDocument = new MessageDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.MessageDocument)
				{
					messageDocument.MergeFrom(MessageDocument);
				}
				input.ReadMessage(messageDocument);
				MessageDocument = messageDocument;
				break;
			}
			case 82u:
			{
				PropDocument propDocument = new PropDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.PropDocument)
				{
					propDocument.MergeFrom(PropDocument);
				}
				input.ReadMessage(propDocument);
				PropDocument = propDocument;
				break;
			}
			case 90u:
			{
				CCLIDocument cCLIDocument = new CCLIDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.CcliDocument)
				{
					cCLIDocument.MergeFrom(CcliDocument);
				}
				input.ReadMessage(cCLIDocument);
				CcliDocument = cCLIDocument;
				break;
			}
			case 98u:
			{
				AudienceLookCollection audienceLookCollection = new AudienceLookCollection();
				if (messageTypeCase_ == MessageTypeOneofCase.AudienceLooks)
				{
					audienceLookCollection.MergeFrom(AudienceLooks);
				}
				input.ReadMessage(audienceLookCollection);
				AudienceLooks = audienceLookCollection;
				break;
			}
			case 106u:
			{
				ProAudienceLook proAudienceLook = new ProAudienceLook();
				if (messageTypeCase_ == MessageTypeOneofCase.LiveAudienceLook)
				{
					proAudienceLook.MergeFrom(LiveAudienceLook);
				}
				input.ReadMessage(proAudienceLook);
				LiveAudienceLook = proAudienceLook;
				break;
			}
			case 114u:
			{
				MaskCollection maskCollection = new MaskCollection();
				if (messageTypeCase_ == MessageTypeOneofCase.Masks)
				{
					maskCollection.MergeFrom(Masks);
				}
				input.ReadMessage(maskCollection);
				Masks = maskCollection;
				break;
			}
			case 122u:
			{
				Recording.Types.SettingsDocument settingsDocument = new Recording.Types.SettingsDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.RecordingSettingsDocument)
				{
					settingsDocument.MergeFrom(RecordingSettingsDocument);
				}
				input.ReadMessage(settingsDocument);
				RecordingSettingsDocument = settingsDocument;
				break;
			}
			case 130u:
			{
				CaptureActionResponse captureActionResponse = new CaptureActionResponse();
				if (messageTypeCase_ == MessageTypeOneofCase.CaptureActionResponse)
				{
					captureActionResponse.MergeFrom(CaptureActionResponse);
				}
				input.ReadMessage(captureActionResponse);
				CaptureActionResponse = captureActionResponse;
				break;
			}
			case 138u:
			{
				CopyrightLayout copyrightLayout = new CopyrightLayout();
				if (messageTypeCase_ == MessageTypeOneofCase.CopyrightLayout)
				{
					copyrightLayout.MergeFrom(CopyrightLayout);
				}
				input.ReadMessage(copyrightLayout);
				CopyrightLayout = copyrightLayout;
				break;
			}
			case 146u:
			{
				Transition transition = new Transition();
				if (messageTypeCase_ == MessageTypeOneofCase.GlobalBackgroundTransition)
				{
					transition.MergeFrom(GlobalBackgroundTransition);
				}
				input.ReadMessage(transition);
				GlobalBackgroundTransition = transition;
				break;
			}
			case 154u:
			{
				Transition transition5 = new Transition();
				if (messageTypeCase_ == MessageTypeOneofCase.GlobalMessagesTransition)
				{
					transition5.MergeFrom(GlobalMessagesTransition);
				}
				input.ReadMessage(transition5);
				GlobalMessagesTransition = transition5;
				break;
			}
			case 162u:
			{
				Transition transition4 = new Transition();
				if (messageTypeCase_ == MessageTypeOneofCase.GlobalForegroundTransition)
				{
					transition4.MergeFrom(GlobalForegroundTransition);
				}
				input.ReadMessage(transition4);
				GlobalForegroundTransition = transition4;
				break;
			}
			case 170u:
			{
				Transition transition3 = new Transition();
				if (messageTypeCase_ == MessageTypeOneofCase.GlobalPropsTransition)
				{
					transition3.MergeFrom(GlobalPropsTransition);
				}
				input.ReadMessage(transition3);
				GlobalPropsTransition = transition3;
				break;
			}
			case 178u:
			{
				Transition transition2 = new Transition();
				if (messageTypeCase_ == MessageTypeOneofCase.GlobalAudioTransition)
				{
					transition2.MergeFrom(GlobalAudioTransition);
				}
				input.ReadMessage(transition2);
				GlobalAudioTransition = transition2;
				break;
			}
			case 186u:
			{
				Preferences preferences = new Preferences();
				if (messageTypeCase_ == MessageTypeOneofCase.Preferences)
				{
					preferences.MergeFrom(Preferences);
				}
				input.ReadMessage(preferences);
				Preferences = preferences;
				break;
			}
			case 194u:
			{
				TestPatternRequest testPatternRequest = new TestPatternRequest();
				if (messageTypeCase_ == MessageTypeOneofCase.TestPattern)
				{
					testPatternRequest.MergeFrom(TestPattern);
				}
				input.ReadMessage(testPatternRequest);
				TestPattern = testPatternRequest;
				break;
			}
			case 202u:
			{
				GenericEvent genericEvent = new GenericEvent();
				if (messageTypeCase_ == MessageTypeOneofCase.StartupComplete)
				{
					genericEvent.MergeFrom(StartupComplete);
				}
				input.ReadMessage(genericEvent);
				StartupComplete = genericEvent;
				break;
			}
			case 210u:
			{
				PlaylistDocument playlistDocument2 = new PlaylistDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.VisualPlaylistDoc)
				{
					playlistDocument2.MergeFrom(VisualPlaylistDoc);
				}
				input.ReadMessage(playlistDocument2);
				VisualPlaylistDoc = playlistDocument2;
				break;
			}
			case 218u:
			{
				PlaylistDocument playlistDocument = new PlaylistDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistDoc)
				{
					playlistDocument.MergeFrom(AudioPlaylistDoc);
				}
				input.ReadMessage(playlistDocument);
				AudioPlaylistDoc = playlistDocument;
				break;
			}
			case 226u:
			{
				GenericEvent genericEvent3 = new GenericEvent();
				if (messageTypeCase_ == MessageTypeOneofCase.KillWatchdog)
				{
					genericEvent3.MergeFrom(KillWatchdog);
				}
				input.ReadMessage(genericEvent3);
				KillWatchdog = genericEvent3;
				break;
			}
			case 234u:
			{
				MacroIcons macroIcons = new MacroIcons();
				if (messageTypeCase_ == MessageTypeOneofCase.MacroIcons)
				{
					macroIcons.MergeFrom(MacroIcons);
				}
				input.ReadMessage(macroIcons);
				MacroIcons = macroIcons;
				break;
			}
			case 242u:
			{
				GenericEvent genericEvent2 = new GenericEvent();
				if (messageTypeCase_ == MessageTypeOneofCase.DebugTriggerDataDump)
				{
					genericEvent2.MergeFrom(DebugTriggerDataDump);
				}
				input.ReadMessage(genericEvent2);
				DebugTriggerDataDump = genericEvent2;
				break;
			}
			case 250u:
			{
				PlaylistDocument playlistDocument3 = new PlaylistDocument();
				if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistDoc)
				{
					playlistDocument3.MergeFrom(LibraryPlaylistDoc);
				}
				input.ReadMessage(playlistDocument3);
				LibraryPlaylistDoc = playlistDocument3;
				break;
			}
			case 258u:
			{
				UUID uUID4 = new UUID();
				if (messageTypeCase_ == MessageTypeOneofCase.AudioPlaylistFocusUuid)
				{
					uUID4.MergeFrom(AudioPlaylistFocusUuid);
				}
				input.ReadMessage(uUID4);
				AudioPlaylistFocusUuid = uUID4;
				break;
			}
			case 266u:
			{
				UUID uUID3 = new UUID();
				if (messageTypeCase_ == MessageTypeOneofCase.MediaPlaylistFocusUuid)
				{
					uUID3.MergeFrom(MediaPlaylistFocusUuid);
				}
				input.ReadMessage(uUID3);
				MediaPlaylistFocusUuid = uUID3;
				break;
			}
			case 274u:
			{
				UUID uUID2 = new UUID();
				if (messageTypeCase_ == MessageTypeOneofCase.LibraryPlaylistFocusUuid)
				{
					uUID2.MergeFrom(LibraryPlaylistFocusUuid);
				}
				input.ReadMessage(uUID2);
				LibraryPlaylistFocusUuid = uUID2;
				break;
			}
			case 282u:
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
			case 290u:
			{
				PropPauseRequest propPauseRequest = new PropPauseRequest();
				if (messageTypeCase_ == MessageTypeOneofCase.PropPause)
				{
					propPauseRequest.MergeFrom(PropPause);
				}
				input.ReadMessage(propPauseRequest);
				PropPause = propPauseRequest;
				break;
			}
			case 298u:
			{
				MediaThumbnail mediaThumbnail = new MediaThumbnail();
				if (messageTypeCase_ == MessageTypeOneofCase.MediaThumbnail)
				{
					mediaThumbnail.MergeFrom(MediaThumbnail);
				}
				input.ReadMessage(mediaThumbnail);
				MediaThumbnail = mediaThumbnail;
				break;
			}
			case 306u:
			{
				PCOData pCOData = new PCOData();
				if (messageTypeCase_ == MessageTypeOneofCase.PcoData)
				{
					pCOData.MergeFrom(PcoData);
				}
				input.ReadMessage(pCOData);
				PcoData = pCOData;
				break;
			}
			case 314u:
			{
				WebFillTokenAndCookies webFillTokenAndCookies = new WebFillTokenAndCookies();
				if (messageTypeCase_ == MessageTypeOneofCase.WebfillTokenAndCookies)
				{
					webFillTokenAndCookies.MergeFrom(WebfillTokenAndCookies);
				}
				input.ReadMessage(webFillTokenAndCookies);
				WebfillTokenAndCookies = webFillTokenAndCookies;
				break;
			}
			case 322u:
			{
				ProScoreboardWorkspace proScoreboardWorkspace = new ProScoreboardWorkspace();
				if (messageTypeCase_ == MessageTypeOneofCase.PsbWorkspace)
				{
					proScoreboardWorkspace.MergeFrom(PsbWorkspace);
				}
				input.ReadMessage(proScoreboardWorkspace);
				PsbWorkspace = proScoreboardWorkspace;
				break;
			}
			case 330u:
			{
				InputStatusCallback inputStatusCallback = new InputStatusCallback();
				if (messageTypeCase_ == MessageTypeOneofCase.InputStatusCallback)
				{
					inputStatusCallback.MergeFrom(InputStatusCallback);
				}
				input.ReadMessage(inputStatusCallback);
				InputStatusCallback = inputStatusCallback;
				break;
			}
			case 338u:
			{
				SlideThumbnailRequest slideThumbnailRequest = new SlideThumbnailRequest();
				if (messageTypeCase_ == MessageTypeOneofCase.SlideThumbnail)
				{
					slideThumbnailRequest.MergeFrom(SlideThumbnail);
				}
				input.ReadMessage(slideThumbnailRequest);
				SlideThumbnail = slideThumbnailRequest;
				break;
			}
			}
		}
	}
}
