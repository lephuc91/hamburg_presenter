using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class EditorObjectAdded : IMessage<EditorObjectAdded>, IMessage, IEquatable<EditorObjectAdded>, IDeepCloneable<EditorObjectAdded>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum FromInsertionSource
		{
			[OriginalName("EDITOR_TOOLBAR")]
			EditorToolbar,
			[OriginalName("EDITOR_MAIN_MENU")]
			EditorMainMenu,
			[OriginalName("EDITOR_HOTKEY")]
			EditorHotkey,
			[OriginalName("EDITOR_COPY_PASTE")]
			EditorCopyPaste
		}

		public enum InsertedType
		{
			[OriginalName("EDITOR_TEXT")]
			EditorText,
			[OriginalName("EDITOR_SHAPE")]
			EditorShape,
			[OriginalName("EDITOR_CUSTOM_SHAPE")]
			EditorCustomShape,
			[OriginalName("EDITOR_MEDIA")]
			EditorMedia,
			[OriginalName("EDITOR_VIDEO_INPUT")]
			EditorVideoInput,
			[OriginalName("EDITOR_WEB")]
			EditorWeb,
			[OriginalName("EDITOR_CURRENT_SLIDE")]
			EditorCurrentSlide,
			[OriginalName("EDITOR_NEXT_SLIDE")]
			EditorNextSlide,
			[OriginalName("EDITOR_SCREEN_PREVIEW")]
			EditorScreenPreview,
			[OriginalName("EDITOR_TIMER")]
			EditorTimer,
			[OriginalName("EDITOR_SYSTEM_CLOCK")]
			EditorSystemClock,
			[OriginalName("EDITOR_VIDEO_COUNTDOWN")]
			EditorVideoCountdown,
			[OriginalName("EDITOR_AUDIO_COUNTDOWN")]
			EditorAudioCountdown,
			[OriginalName("EDITOR_PLAYBACK_MARKER")]
			EditorPlaybackMarker,
			[OriginalName("EDITOR_CHORD_CHART")]
			EditorChordChart,
			[OriginalName("EDITOR_STAGE_MESSAGE")]
			EditorStageMessage,
			[OriginalName("EDITOR_PLANNING_CENTER_LIVE")]
			EditorPlanningCenterLive,
			[OriginalName("EDITOR_TIMECODE")]
			EditorTimecode,
			[OriginalName("EDITOR_GROUP")]
			EditorGroup,
			[OriginalName("EDITOR_LABEL")]
			EditorLabel,
			[OriginalName("EDITOR_CAPTURE_STATUS")]
			EditorCaptureStatus
		}
	}

	private static readonly MessageParser<EditorObjectAdded> _parser = new MessageParser<EditorObjectAdded>(() => new EditorObjectAdded());

	private UnknownFieldSet _unknownFields;

	public const int FromInsertionSourceFieldNumber = 1;

	private Types.FromInsertionSource fromInsertionSource_;

	public const int InsertedTypeFieldNumber = 2;

	private Types.InsertedType insertedType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<EditorObjectAdded> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[28];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FromInsertionSource FromInsertionSource
	{
		get
		{
			return fromInsertionSource_;
		}
		set
		{
			fromInsertionSource_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.InsertedType InsertedType
	{
		get
		{
			return insertedType_;
		}
		set
		{
			insertedType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EditorObjectAdded()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EditorObjectAdded(EditorObjectAdded other)
		: this()
	{
		fromInsertionSource_ = other.fromInsertionSource_;
		insertedType_ = other.insertedType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EditorObjectAdded Clone()
	{
		return new EditorObjectAdded(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as EditorObjectAdded);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(EditorObjectAdded other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (FromInsertionSource != other.FromInsertionSource)
		{
			return false;
		}
		if (InsertedType != other.InsertedType)
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
		if (FromInsertionSource != 0)
		{
			num ^= FromInsertionSource.GetHashCode();
		}
		if (InsertedType != 0)
		{
			num ^= InsertedType.GetHashCode();
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
		if (FromInsertionSource != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)FromInsertionSource);
		}
		if (InsertedType != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)InsertedType);
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
		if (FromInsertionSource != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)FromInsertionSource);
		}
		if (InsertedType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)InsertedType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(EditorObjectAdded other)
	{
		if (other != null)
		{
			if (other.FromInsertionSource != 0)
			{
				FromInsertionSource = other.FromInsertionSource;
			}
			if (other.InsertedType != 0)
			{
				InsertedType = other.InsertedType;
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
				FromInsertionSource = (Types.FromInsertionSource)input.ReadEnum();
				break;
			case 16u:
				InsertedType = (Types.InsertedType)input.ReadEnum();
				break;
			}
		}
	}
}
