using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TriggerTransferRenderState : IMessage<TriggerTransferRenderState>, IMessage, IEquatable<TriggerTransferRenderState>, IDeepCloneable<TriggerTransferRenderState>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimerState : IMessage<TimerState>, IMessage, IEquatable<TimerState>, IDeepCloneable<TimerState>
		{
			private static readonly MessageParser<TimerState> _parser = new MessageParser<TimerState>(() => new TimerState());

			private UnknownFieldSet _unknownFields;

			public const int TimerFieldNumber = 1;

			private Timer timer_;

			public const int IsRunningFieldNumber = 2;

			private bool isRunning_;

			public const int HasOverrunFieldNumber = 3;

			private bool hasOverrun_;

			public const int ValueFieldNumber = 4;

			private float value_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimerState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerTransferRenderState.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timer Timer
			{
				get
				{
					return timer_;
				}
				set
				{
					timer_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsRunning
			{
				get
				{
					return isRunning_;
				}
				set
				{
					isRunning_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasOverrun
			{
				get
				{
					return hasOverrun_;
				}
				set
				{
					hasOverrun_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float Value
			{
				get
				{
					return value_;
				}
				set
				{
					value_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerState(TimerState other)
				: this()
			{
				timer_ = ((other.timer_ != null) ? other.timer_.Clone() : null);
				isRunning_ = other.isRunning_;
				hasOverrun_ = other.hasOverrun_;
				value_ = other.value_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimerState Clone()
			{
				return new TimerState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimerState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimerState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Timer, other.Timer))
				{
					return false;
				}
				if (IsRunning != other.IsRunning)
				{
					return false;
				}
				if (HasOverrun != other.HasOverrun)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Value, other.Value))
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
				if (timer_ != null)
				{
					num ^= Timer.GetHashCode();
				}
				if (IsRunning)
				{
					num ^= IsRunning.GetHashCode();
				}
				if (HasOverrun)
				{
					num ^= HasOverrun.GetHashCode();
				}
				if (Value != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Value);
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
				if (timer_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Timer);
				}
				if (IsRunning)
				{
					output.WriteRawTag(16);
					output.WriteBool(IsRunning);
				}
				if (HasOverrun)
				{
					output.WriteRawTag(24);
					output.WriteBool(HasOverrun);
				}
				if (Value != 0f)
				{
					output.WriteRawTag(37);
					output.WriteFloat(Value);
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
				if (timer_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Timer);
				}
				if (IsRunning)
				{
					num += 2;
				}
				if (HasOverrun)
				{
					num += 2;
				}
				if (Value != 0f)
				{
					num += 5;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimerState other)
			{
				if (other == null)
				{
					return;
				}
				if (other.timer_ != null)
				{
					if (timer_ == null)
					{
						Timer = new Timer();
					}
					Timer.MergeFrom(other.Timer);
				}
				if (other.IsRunning)
				{
					IsRunning = other.IsRunning;
				}
				if (other.HasOverrun)
				{
					HasOverrun = other.HasOverrun;
				}
				if (other.Value != 0f)
				{
					Value = other.Value;
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
						if (timer_ == null)
						{
							Timer = new Timer();
						}
						input.ReadMessage(Timer);
						break;
					case 16u:
						IsRunning = input.ReadBool();
						break;
					case 24u:
						HasOverrun = input.ReadBool();
						break;
					case 37u:
						Value = input.ReadFloat();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MediaState : IMessage<MediaState>, IMessage, IEquatable<MediaState>, IDeepCloneable<MediaState>
		{
			private static readonly MessageParser<MediaState> _parser = new MessageParser<MediaState>(() => new MediaState());

			private UnknownFieldSet _unknownFields;

			public const int CurrentMediaFieldNumber = 1;

			private Media currentMedia_;

			public const int IsPlayingFieldNumber = 2;

			private bool isPlaying_;

			public const int IsLoopingFieldNumber = 3;

			private bool isLooping_;

			public const int CurrentTimeFieldNumber = 4;

			private float currentTime_;

			public const int TimeRemainingFieldNumber = 5;

			private float timeRemaining_;

			public const int PlaylistUuidFieldNumber = 6;

			private UUID playlistUuid_;

			public const int PlaylistNameFieldNumber = 7;

			private string playlistName_ = "";

			public const int MarkersFieldNumber = 8;

			private static readonly FieldCodec<Action.Types.MediaType.Types.PlaybackMarker> _repeated_markers_codec = FieldCodec.ForMessage(66u, Action.Types.MediaType.Types.PlaybackMarker.Parser);

			private readonly RepeatedField<Action.Types.MediaType.Types.PlaybackMarker> markers_ = new RepeatedField<Action.Types.MediaType.Types.PlaybackMarker>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MediaState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerTransferRenderState.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media CurrentMedia
			{
				get
				{
					return currentMedia_;
				}
				set
				{
					currentMedia_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsPlaying
			{
				get
				{
					return isPlaying_;
				}
				set
				{
					isPlaying_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsLooping
			{
				get
				{
					return isLooping_;
				}
				set
				{
					isLooping_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float CurrentTime
			{
				get
				{
					return currentTime_;
				}
				set
				{
					currentTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float TimeRemaining
			{
				get
				{
					return timeRemaining_;
				}
				set
				{
					timeRemaining_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID PlaylistUuid
			{
				get
				{
					return playlistUuid_;
				}
				set
				{
					playlistUuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string PlaylistName
			{
				get
				{
					return playlistName_;
				}
				set
				{
					playlistName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Action.Types.MediaType.Types.PlaybackMarker> Markers => markers_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaState(MediaState other)
				: this()
			{
				currentMedia_ = ((other.currentMedia_ != null) ? other.currentMedia_.Clone() : null);
				isPlaying_ = other.isPlaying_;
				isLooping_ = other.isLooping_;
				currentTime_ = other.currentTime_;
				timeRemaining_ = other.timeRemaining_;
				playlistUuid_ = ((other.playlistUuid_ != null) ? other.playlistUuid_.Clone() : null);
				playlistName_ = other.playlistName_;
				markers_ = other.markers_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaState Clone()
			{
				return new MediaState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MediaState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MediaState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(CurrentMedia, other.CurrentMedia))
				{
					return false;
				}
				if (IsPlaying != other.IsPlaying)
				{
					return false;
				}
				if (IsLooping != other.IsLooping)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(CurrentTime, other.CurrentTime))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(TimeRemaining, other.TimeRemaining))
				{
					return false;
				}
				if (!object.Equals(PlaylistUuid, other.PlaylistUuid))
				{
					return false;
				}
				if (PlaylistName != other.PlaylistName)
				{
					return false;
				}
				if (!markers_.Equals(other.markers_))
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
				if (currentMedia_ != null)
				{
					num ^= CurrentMedia.GetHashCode();
				}
				if (IsPlaying)
				{
					num ^= IsPlaying.GetHashCode();
				}
				if (IsLooping)
				{
					num ^= IsLooping.GetHashCode();
				}
				if (CurrentTime != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(CurrentTime);
				}
				if (TimeRemaining != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(TimeRemaining);
				}
				if (playlistUuid_ != null)
				{
					num ^= PlaylistUuid.GetHashCode();
				}
				if (PlaylistName.Length != 0)
				{
					num ^= PlaylistName.GetHashCode();
				}
				num ^= markers_.GetHashCode();
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
				if (currentMedia_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(CurrentMedia);
				}
				if (IsPlaying)
				{
					output.WriteRawTag(16);
					output.WriteBool(IsPlaying);
				}
				if (IsLooping)
				{
					output.WriteRawTag(24);
					output.WriteBool(IsLooping);
				}
				if (CurrentTime != 0f)
				{
					output.WriteRawTag(37);
					output.WriteFloat(CurrentTime);
				}
				if (TimeRemaining != 0f)
				{
					output.WriteRawTag(45);
					output.WriteFloat(TimeRemaining);
				}
				if (playlistUuid_ != null)
				{
					output.WriteRawTag(50);
					output.WriteMessage(PlaylistUuid);
				}
				if (PlaylistName.Length != 0)
				{
					output.WriteRawTag(58);
					output.WriteString(PlaylistName);
				}
				markers_.WriteTo(output, _repeated_markers_codec);
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
				if (currentMedia_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CurrentMedia);
				}
				if (IsPlaying)
				{
					num += 2;
				}
				if (IsLooping)
				{
					num += 2;
				}
				if (CurrentTime != 0f)
				{
					num += 5;
				}
				if (TimeRemaining != 0f)
				{
					num += 5;
				}
				if (playlistUuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistUuid);
				}
				if (PlaylistName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(PlaylistName);
				}
				num += markers_.CalculateSize(_repeated_markers_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MediaState other)
			{
				if (other == null)
				{
					return;
				}
				if (other.currentMedia_ != null)
				{
					if (currentMedia_ == null)
					{
						CurrentMedia = new Media();
					}
					CurrentMedia.MergeFrom(other.CurrentMedia);
				}
				if (other.IsPlaying)
				{
					IsPlaying = other.IsPlaying;
				}
				if (other.IsLooping)
				{
					IsLooping = other.IsLooping;
				}
				if (other.CurrentTime != 0f)
				{
					CurrentTime = other.CurrentTime;
				}
				if (other.TimeRemaining != 0f)
				{
					TimeRemaining = other.TimeRemaining;
				}
				if (other.playlistUuid_ != null)
				{
					if (playlistUuid_ == null)
					{
						PlaylistUuid = new UUID();
					}
					PlaylistUuid.MergeFrom(other.PlaylistUuid);
				}
				if (other.PlaylistName.Length != 0)
				{
					PlaylistName = other.PlaylistName;
				}
				markers_.Add(other.markers_);
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
						if (currentMedia_ == null)
						{
							CurrentMedia = new Media();
						}
						input.ReadMessage(CurrentMedia);
						break;
					case 16u:
						IsPlaying = input.ReadBool();
						break;
					case 24u:
						IsLooping = input.ReadBool();
						break;
					case 37u:
						CurrentTime = input.ReadFloat();
						break;
					case 45u:
						TimeRemaining = input.ReadFloat();
						break;
					case 50u:
						if (playlistUuid_ == null)
						{
							PlaylistUuid = new UUID();
						}
						input.ReadMessage(PlaylistUuid);
						break;
					case 58u:
						PlaylistName = input.ReadString();
						break;
					case 66u:
						markers_.AddEntriesFrom(input, _repeated_markers_codec);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CaptureState : IMessage<CaptureState>, IMessage, IEquatable<CaptureState>, IDeepCloneable<CaptureState>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Status
				{
					[OriginalName("Stopped")]
					Stopped,
					[OriginalName("Active")]
					Active,
					[OriginalName("Caution")]
					Caution,
					[OriginalName("Error")]
					Error
				}
			}

			private static readonly MessageParser<CaptureState> _parser = new MessageParser<CaptureState>(() => new CaptureState());

			private UnknownFieldSet _unknownFields;

			public const int StatusFieldNumber = 1;

			private Types.Status status_;

			public const int TimeFieldNumber = 2;

			private float time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CaptureState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerTransferRenderState.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Status Status
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
			public float Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CaptureState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CaptureState(CaptureState other)
				: this()
			{
				status_ = other.status_;
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CaptureState Clone()
			{
				return new CaptureState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CaptureState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CaptureState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Status != other.Status)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Time, other.Time))
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
				if (Status != 0)
				{
					num ^= Status.GetHashCode();
				}
				if (Time != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Time);
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
				if (Status != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Status);
				}
				if (Time != 0f)
				{
					output.WriteRawTag(21);
					output.WriteFloat(Time);
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
				if (Status != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Status);
				}
				if (Time != 0f)
				{
					num += 5;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CaptureState other)
			{
				if (other != null)
				{
					if (other.Status != 0)
					{
						Status = other.Status;
					}
					if (other.Time != 0f)
					{
						Time = other.Time;
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
						Status = (Types.Status)input.ReadEnum();
						break;
					case 21u:
						Time = input.ReadFloat();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class AutoAdvanceState : IMessage<AutoAdvanceState>, IMessage, IEquatable<AutoAdvanceState>, IDeepCloneable<AutoAdvanceState>
		{
			private static readonly MessageParser<AutoAdvanceState> _parser = new MessageParser<AutoAdvanceState>(() => new AutoAdvanceState());

			private UnknownFieldSet _unknownFields;

			public const int ActiveFieldNumber = 1;

			private bool active_;

			public const int RemainingTimeFieldNumber = 2;

			private float remainingTime_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<AutoAdvanceState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerTransferRenderState.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Active
			{
				get
				{
					return active_;
				}
				set
				{
					active_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float RemainingTime
			{
				get
				{
					return remainingTime_;
				}
				set
				{
					remainingTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AutoAdvanceState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AutoAdvanceState(AutoAdvanceState other)
				: this()
			{
				active_ = other.active_;
				remainingTime_ = other.remainingTime_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AutoAdvanceState Clone()
			{
				return new AutoAdvanceState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as AutoAdvanceState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(AutoAdvanceState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Active != other.Active)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(RemainingTime, other.RemainingTime))
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
				if (Active)
				{
					num ^= Active.GetHashCode();
				}
				if (RemainingTime != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(RemainingTime);
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
				if (Active)
				{
					output.WriteRawTag(8);
					output.WriteBool(Active);
				}
				if (RemainingTime != 0f)
				{
					output.WriteRawTag(21);
					output.WriteFloat(RemainingTime);
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
				if (Active)
				{
					num += 2;
				}
				if (RemainingTime != 0f)
				{
					num += 5;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(AutoAdvanceState other)
			{
				if (other != null)
				{
					if (other.Active)
					{
						Active = other.Active;
					}
					if (other.RemainingTime != 0f)
					{
						RemainingTime = other.RemainingTime;
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
						Active = input.ReadBool();
						break;
					case 21u:
						RemainingTime = input.ReadFloat();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimelineState : IMessage<TimelineState>, IMessage, IEquatable<TimelineState>, IDeepCloneable<TimelineState>
		{
			private static readonly MessageParser<TimelineState> _parser = new MessageParser<TimelineState>(() => new TimelineState());

			private UnknownFieldSet _unknownFields;

			public const int ActiveFieldNumber = 1;

			private bool active_;

			public const int CurrentTimeFieldNumber = 2;

			private float currentTime_;

			public const int LastSlideIndexFieldNumber = 3;

			private int lastSlideIndex_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimelineState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerTransferRenderState.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Active
			{
				get
				{
					return active_;
				}
				set
				{
					active_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float CurrentTime
			{
				get
				{
					return currentTime_;
				}
				set
				{
					currentTime_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int LastSlideIndex
			{
				get
				{
					return lastSlideIndex_;
				}
				set
				{
					lastSlideIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineState(TimelineState other)
				: this()
			{
				active_ = other.active_;
				currentTime_ = other.currentTime_;
				lastSlideIndex_ = other.lastSlideIndex_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineState Clone()
			{
				return new TimelineState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimelineState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimelineState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Active != other.Active)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(CurrentTime, other.CurrentTime))
				{
					return false;
				}
				if (LastSlideIndex != other.LastSlideIndex)
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
				if (Active)
				{
					num ^= Active.GetHashCode();
				}
				if (CurrentTime != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(CurrentTime);
				}
				if (LastSlideIndex != 0)
				{
					num ^= LastSlideIndex.GetHashCode();
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
				if (Active)
				{
					output.WriteRawTag(8);
					output.WriteBool(Active);
				}
				if (CurrentTime != 0f)
				{
					output.WriteRawTag(21);
					output.WriteFloat(CurrentTime);
				}
				if (LastSlideIndex != 0)
				{
					output.WriteRawTag(24);
					output.WriteInt32(LastSlideIndex);
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
				if (Active)
				{
					num += 2;
				}
				if (CurrentTime != 0f)
				{
					num += 5;
				}
				if (LastSlideIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(LastSlideIndex);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimelineState other)
			{
				if (other != null)
				{
					if (other.Active)
					{
						Active = other.Active;
					}
					if (other.CurrentTime != 0f)
					{
						CurrentTime = other.CurrentTime;
					}
					if (other.LastSlideIndex != 0)
					{
						LastSlideIndex = other.LastSlideIndex;
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
						Active = input.ReadBool();
						break;
					case 21u:
						CurrentTime = input.ReadFloat();
						break;
					case 24u:
						LastSlideIndex = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SlideState : IMessage<SlideState>, IMessage, IEquatable<SlideState>, IDeepCloneable<SlideState>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum TriggerSource
				{
					[OriginalName("Normal")]
					Normal,
					[OriginalName("Timeline")]
					Timeline,
					[OriginalName("Editor")]
					Editor
				}
			}

			private static readonly MessageParser<SlideState> _parser = new MessageParser<SlideState>(() => new SlideState());

			private UnknownFieldSet _unknownFields;

			public const int PresentationFieldNumber = 1;

			private Presentation presentation_;

			public const int PlaylistFieldNumber = 2;

			private Playlist playlist_;

			public const int CurrentCueFieldNumber = 3;

			private UUID currentCue_;

			public const int NextCueFieldNumber = 4;

			private UUID nextCue_;

			public const int AutoAdvanceFieldNumber = 5;

			private AutoAdvanceState autoAdvance_;

			public const int TimelineStateFieldNumber = 6;

			private TimelineState timelineState_;

			public const int CurrentCueIndexFieldNumber = 7;

			private int currentCueIndex_;

			public const int CurrentPlaylistIndexFieldNumber = 8;

			private int currentPlaylistIndex_;

			public const int IsCurrentPositionFieldNumber = 9;

			private bool isCurrentPosition_;

			public const int TriggerSourceFieldNumber = 10;

			private Types.TriggerSource triggerSource_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SlideState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerTransferRenderState.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Presentation Presentation
			{
				get
				{
					return presentation_;
				}
				set
				{
					presentation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Playlist Playlist
			{
				get
				{
					return playlist_;
				}
				set
				{
					playlist_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID CurrentCue
			{
				get
				{
					return currentCue_;
				}
				set
				{
					currentCue_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID NextCue
			{
				get
				{
					return nextCue_;
				}
				set
				{
					nextCue_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AutoAdvanceState AutoAdvance
			{
				get
				{
					return autoAdvance_;
				}
				set
				{
					autoAdvance_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimelineState TimelineState
			{
				get
				{
					return timelineState_;
				}
				set
				{
					timelineState_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CurrentCueIndex
			{
				get
				{
					return currentCueIndex_;
				}
				set
				{
					currentCueIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int CurrentPlaylistIndex
			{
				get
				{
					return currentPlaylistIndex_;
				}
				set
				{
					currentPlaylistIndex_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsCurrentPosition
			{
				get
				{
					return isCurrentPosition_;
				}
				set
				{
					isCurrentPosition_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.TriggerSource TriggerSource
			{
				get
				{
					return triggerSource_;
				}
				set
				{
					triggerSource_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideState(SlideState other)
				: this()
			{
				presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
				playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
				currentCue_ = ((other.currentCue_ != null) ? other.currentCue_.Clone() : null);
				nextCue_ = ((other.nextCue_ != null) ? other.nextCue_.Clone() : null);
				autoAdvance_ = ((other.autoAdvance_ != null) ? other.autoAdvance_.Clone() : null);
				timelineState_ = ((other.timelineState_ != null) ? other.timelineState_.Clone() : null);
				currentCueIndex_ = other.currentCueIndex_;
				currentPlaylistIndex_ = other.currentPlaylistIndex_;
				isCurrentPosition_ = other.isCurrentPosition_;
				triggerSource_ = other.triggerSource_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SlideState Clone()
			{
				return new SlideState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SlideState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SlideState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Presentation, other.Presentation))
				{
					return false;
				}
				if (!object.Equals(Playlist, other.Playlist))
				{
					return false;
				}
				if (!object.Equals(CurrentCue, other.CurrentCue))
				{
					return false;
				}
				if (!object.Equals(NextCue, other.NextCue))
				{
					return false;
				}
				if (!object.Equals(AutoAdvance, other.AutoAdvance))
				{
					return false;
				}
				if (!object.Equals(TimelineState, other.TimelineState))
				{
					return false;
				}
				if (CurrentCueIndex != other.CurrentCueIndex)
				{
					return false;
				}
				if (CurrentPlaylistIndex != other.CurrentPlaylistIndex)
				{
					return false;
				}
				if (IsCurrentPosition != other.IsCurrentPosition)
				{
					return false;
				}
				if (TriggerSource != other.TriggerSource)
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
				if (presentation_ != null)
				{
					num ^= Presentation.GetHashCode();
				}
				if (playlist_ != null)
				{
					num ^= Playlist.GetHashCode();
				}
				if (currentCue_ != null)
				{
					num ^= CurrentCue.GetHashCode();
				}
				if (nextCue_ != null)
				{
					num ^= NextCue.GetHashCode();
				}
				if (autoAdvance_ != null)
				{
					num ^= AutoAdvance.GetHashCode();
				}
				if (timelineState_ != null)
				{
					num ^= TimelineState.GetHashCode();
				}
				if (CurrentCueIndex != 0)
				{
					num ^= CurrentCueIndex.GetHashCode();
				}
				if (CurrentPlaylistIndex != 0)
				{
					num ^= CurrentPlaylistIndex.GetHashCode();
				}
				if (IsCurrentPosition)
				{
					num ^= IsCurrentPosition.GetHashCode();
				}
				if (TriggerSource != 0)
				{
					num ^= TriggerSource.GetHashCode();
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
				if (presentation_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Presentation);
				}
				if (playlist_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Playlist);
				}
				if (currentCue_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(CurrentCue);
				}
				if (nextCue_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(NextCue);
				}
				if (autoAdvance_ != null)
				{
					output.WriteRawTag(42);
					output.WriteMessage(AutoAdvance);
				}
				if (timelineState_ != null)
				{
					output.WriteRawTag(50);
					output.WriteMessage(TimelineState);
				}
				if (CurrentCueIndex != 0)
				{
					output.WriteRawTag(56);
					output.WriteInt32(CurrentCueIndex);
				}
				if (CurrentPlaylistIndex != 0)
				{
					output.WriteRawTag(64);
					output.WriteInt32(CurrentPlaylistIndex);
				}
				if (IsCurrentPosition)
				{
					output.WriteRawTag(72);
					output.WriteBool(IsCurrentPosition);
				}
				if (TriggerSource != 0)
				{
					output.WriteRawTag(80);
					output.WriteEnum((int)TriggerSource);
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
				if (presentation_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
				}
				if (playlist_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
				}
				if (currentCue_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CurrentCue);
				}
				if (nextCue_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(NextCue);
				}
				if (autoAdvance_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AutoAdvance);
				}
				if (timelineState_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(TimelineState);
				}
				if (CurrentCueIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(CurrentCueIndex);
				}
				if (CurrentPlaylistIndex != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(CurrentPlaylistIndex);
				}
				if (IsCurrentPosition)
				{
					num += 2;
				}
				if (TriggerSource != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)TriggerSource);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SlideState other)
			{
				if (other == null)
				{
					return;
				}
				if (other.presentation_ != null)
				{
					if (presentation_ == null)
					{
						Presentation = new Presentation();
					}
					Presentation.MergeFrom(other.Presentation);
				}
				if (other.playlist_ != null)
				{
					if (playlist_ == null)
					{
						Playlist = new Playlist();
					}
					Playlist.MergeFrom(other.Playlist);
				}
				if (other.currentCue_ != null)
				{
					if (currentCue_ == null)
					{
						CurrentCue = new UUID();
					}
					CurrentCue.MergeFrom(other.CurrentCue);
				}
				if (other.nextCue_ != null)
				{
					if (nextCue_ == null)
					{
						NextCue = new UUID();
					}
					NextCue.MergeFrom(other.NextCue);
				}
				if (other.autoAdvance_ != null)
				{
					if (autoAdvance_ == null)
					{
						AutoAdvance = new AutoAdvanceState();
					}
					AutoAdvance.MergeFrom(other.AutoAdvance);
				}
				if (other.timelineState_ != null)
				{
					if (timelineState_ == null)
					{
						TimelineState = new TimelineState();
					}
					TimelineState.MergeFrom(other.TimelineState);
				}
				if (other.CurrentCueIndex != 0)
				{
					CurrentCueIndex = other.CurrentCueIndex;
				}
				if (other.CurrentPlaylistIndex != 0)
				{
					CurrentPlaylistIndex = other.CurrentPlaylistIndex;
				}
				if (other.IsCurrentPosition)
				{
					IsCurrentPosition = other.IsCurrentPosition;
				}
				if (other.TriggerSource != 0)
				{
					TriggerSource = other.TriggerSource;
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
						if (presentation_ == null)
						{
							Presentation = new Presentation();
						}
						input.ReadMessage(Presentation);
						break;
					case 18u:
						if (playlist_ == null)
						{
							Playlist = new Playlist();
						}
						input.ReadMessage(Playlist);
						break;
					case 26u:
						if (currentCue_ == null)
						{
							CurrentCue = new UUID();
						}
						input.ReadMessage(CurrentCue);
						break;
					case 34u:
						if (nextCue_ == null)
						{
							NextCue = new UUID();
						}
						input.ReadMessage(NextCue);
						break;
					case 42u:
						if (autoAdvance_ == null)
						{
							AutoAdvance = new AutoAdvanceState();
						}
						input.ReadMessage(AutoAdvance);
						break;
					case 50u:
						if (timelineState_ == null)
						{
							TimelineState = new TimelineState();
						}
						input.ReadMessage(TimelineState);
						break;
					case 56u:
						CurrentCueIndex = input.ReadInt32();
						break;
					case 64u:
						CurrentPlaylistIndex = input.ReadInt32();
						break;
					case 72u:
						IsCurrentPosition = input.ReadBool();
						break;
					case 80u:
						TriggerSource = (Types.TriggerSource)input.ReadEnum();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TimecodeState : IMessage<TimecodeState>, IMessage, IEquatable<TimecodeState>, IDeepCloneable<TimecodeState>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum Status
				{
					[OriginalName("Stopped")]
					Stopped,
					[OriginalName("Playing")]
					Playing,
					[OriginalName("Error")]
					Error,
					[OriginalName("Discontinuity")]
					Discontinuity
				}
			}

			private static readonly MessageParser<TimecodeState> _parser = new MessageParser<TimecodeState>(() => new TimecodeState());

			private UnknownFieldSet _unknownFields;

			public const int StatusFieldNumber = 1;

			private Types.Status status_;

			public const int TimeFieldNumber = 2;

			private float time_;

			public const int FpsFieldNumber = 3;

			private float fps_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TimecodeState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TriggerTransferRenderState.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Status Status
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
			public float Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public float Fps
			{
				get
				{
					return fps_;
				}
				set
				{
					fps_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimecodeState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimecodeState(TimecodeState other)
				: this()
			{
				status_ = other.status_;
				time_ = other.time_;
				fps_ = other.fps_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TimecodeState Clone()
			{
				return new TimecodeState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TimecodeState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TimecodeState other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Status != other.Status)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Time, other.Time))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Fps, other.Fps))
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
				if (Status != 0)
				{
					num ^= Status.GetHashCode();
				}
				if (Time != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Time);
				}
				if (Fps != 0f)
				{
					num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Fps);
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
				if (Status != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Status);
				}
				if (Time != 0f)
				{
					output.WriteRawTag(21);
					output.WriteFloat(Time);
				}
				if (Fps != 0f)
				{
					output.WriteRawTag(29);
					output.WriteFloat(Fps);
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
				if (Status != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Status);
				}
				if (Time != 0f)
				{
					num += 5;
				}
				if (Fps != 0f)
				{
					num += 5;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(TimecodeState other)
			{
				if (other != null)
				{
					if (other.Status != 0)
					{
						Status = other.Status;
					}
					if (other.Time != 0f)
					{
						Time = other.Time;
					}
					if (other.Fps != 0f)
					{
						Fps = other.Fps;
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
						Status = (Types.Status)input.ReadEnum();
						break;
					case 21u:
						Time = input.ReadFloat();
						break;
					case 29u:
						Fps = input.ReadFloat();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TriggerTransferRenderState> _parser = new MessageParser<TriggerTransferRenderState>(() => new TriggerTransferRenderState());

	private UnknownFieldSet _unknownFields;

	public const int SlideFieldNumber = 1;

	private Slide slide_;

	public const int StageMessageFieldNumber = 2;

	private string stageMessage_ = "";

	public const int PresentationMediaFieldNumber = 3;

	private Types.MediaState presentationMedia_;

	public const int AnnouncementMediaFieldNumber = 4;

	private Types.MediaState announcementMedia_;

	public const int AudioMediaFieldNumber = 5;

	private Types.MediaState audioMedia_;

	public const int LiveVideoMediaFieldNumber = 6;

	private Media liveVideoMedia_;

	public const int PresentationFieldNumber = 7;

	private Types.SlideState presentation_;

	public const int AnnouncementFieldNumber = 8;

	private Types.SlideState announcement_;

	public const int TimersFieldNumber = 9;

	private static readonly FieldCodec<Types.TimerState> _repeated_timers_codec = FieldCodec.ForMessage(74u, Types.TimerState.Parser);

	private readonly RepeatedField<Types.TimerState> timers_ = new RepeatedField<Types.TimerState>();

	public const int CaptureFieldNumber = 10;

	private Types.CaptureState capture_;

	public const int TimecodeFieldNumber = 11;

	private Types.TimecodeState timecode_;

	public const int SystemTimeFieldNumber = 12;

	private ulong systemTime_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TriggerTransferRenderState> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[34];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide Slide
	{
		get
		{
			return slide_;
		}
		set
		{
			slide_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string StageMessage
	{
		get
		{
			return stageMessage_;
		}
		set
		{
			stageMessage_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaState PresentationMedia
	{
		get
		{
			return presentationMedia_;
		}
		set
		{
			presentationMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaState AnnouncementMedia
	{
		get
		{
			return announcementMedia_;
		}
		set
		{
			announcementMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MediaState AudioMedia
	{
		get
		{
			return audioMedia_;
		}
		set
		{
			audioMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media LiveVideoMedia
	{
		get
		{
			return liveVideoMedia_;
		}
		set
		{
			liveVideoMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SlideState Presentation
	{
		get
		{
			return presentation_;
		}
		set
		{
			presentation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SlideState Announcement
	{
		get
		{
			return announcement_;
		}
		set
		{
			announcement_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.TimerState> Timers => timers_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CaptureState Capture
	{
		get
		{
			return capture_;
		}
		set
		{
			capture_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TimecodeState Timecode
	{
		get
		{
			return timecode_;
		}
		set
		{
			timecode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong SystemTime
	{
		get
		{
			return systemTime_;
		}
		set
		{
			systemTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerTransferRenderState()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerTransferRenderState(TriggerTransferRenderState other)
		: this()
	{
		slide_ = ((other.slide_ != null) ? other.slide_.Clone() : null);
		stageMessage_ = other.stageMessage_;
		presentationMedia_ = ((other.presentationMedia_ != null) ? other.presentationMedia_.Clone() : null);
		announcementMedia_ = ((other.announcementMedia_ != null) ? other.announcementMedia_.Clone() : null);
		audioMedia_ = ((other.audioMedia_ != null) ? other.audioMedia_.Clone() : null);
		liveVideoMedia_ = ((other.liveVideoMedia_ != null) ? other.liveVideoMedia_.Clone() : null);
		presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
		announcement_ = ((other.announcement_ != null) ? other.announcement_.Clone() : null);
		timers_ = other.timers_.Clone();
		capture_ = ((other.capture_ != null) ? other.capture_.Clone() : null);
		timecode_ = ((other.timecode_ != null) ? other.timecode_.Clone() : null);
		systemTime_ = other.systemTime_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerTransferRenderState Clone()
	{
		return new TriggerTransferRenderState(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TriggerTransferRenderState);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TriggerTransferRenderState other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Slide, other.Slide))
		{
			return false;
		}
		if (StageMessage != other.StageMessage)
		{
			return false;
		}
		if (!object.Equals(PresentationMedia, other.PresentationMedia))
		{
			return false;
		}
		if (!object.Equals(AnnouncementMedia, other.AnnouncementMedia))
		{
			return false;
		}
		if (!object.Equals(AudioMedia, other.AudioMedia))
		{
			return false;
		}
		if (!object.Equals(LiveVideoMedia, other.LiveVideoMedia))
		{
			return false;
		}
		if (!object.Equals(Presentation, other.Presentation))
		{
			return false;
		}
		if (!object.Equals(Announcement, other.Announcement))
		{
			return false;
		}
		if (!timers_.Equals(other.timers_))
		{
			return false;
		}
		if (!object.Equals(Capture, other.Capture))
		{
			return false;
		}
		if (!object.Equals(Timecode, other.Timecode))
		{
			return false;
		}
		if (SystemTime != other.SystemTime)
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
		if (slide_ != null)
		{
			num ^= Slide.GetHashCode();
		}
		if (StageMessage.Length != 0)
		{
			num ^= StageMessage.GetHashCode();
		}
		if (presentationMedia_ != null)
		{
			num ^= PresentationMedia.GetHashCode();
		}
		if (announcementMedia_ != null)
		{
			num ^= AnnouncementMedia.GetHashCode();
		}
		if (audioMedia_ != null)
		{
			num ^= AudioMedia.GetHashCode();
		}
		if (liveVideoMedia_ != null)
		{
			num ^= LiveVideoMedia.GetHashCode();
		}
		if (presentation_ != null)
		{
			num ^= Presentation.GetHashCode();
		}
		if (announcement_ != null)
		{
			num ^= Announcement.GetHashCode();
		}
		num ^= timers_.GetHashCode();
		if (capture_ != null)
		{
			num ^= Capture.GetHashCode();
		}
		if (timecode_ != null)
		{
			num ^= Timecode.GetHashCode();
		}
		if (SystemTime != 0L)
		{
			num ^= SystemTime.GetHashCode();
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
		if (slide_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Slide);
		}
		if (StageMessage.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(StageMessage);
		}
		if (presentationMedia_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PresentationMedia);
		}
		if (announcementMedia_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(AnnouncementMedia);
		}
		if (audioMedia_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(AudioMedia);
		}
		if (liveVideoMedia_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(LiveVideoMedia);
		}
		if (presentation_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Presentation);
		}
		if (announcement_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Announcement);
		}
		timers_.WriteTo(output, _repeated_timers_codec);
		if (capture_ != null)
		{
			output.WriteRawTag(82);
			output.WriteMessage(Capture);
		}
		if (timecode_ != null)
		{
			output.WriteRawTag(90);
			output.WriteMessage(Timecode);
		}
		if (SystemTime != 0L)
		{
			output.WriteRawTag(96);
			output.WriteUInt64(SystemTime);
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
		if (slide_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Slide);
		}
		if (StageMessage.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(StageMessage);
		}
		if (presentationMedia_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PresentationMedia);
		}
		if (announcementMedia_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AnnouncementMedia);
		}
		if (audioMedia_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AudioMedia);
		}
		if (liveVideoMedia_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LiveVideoMedia);
		}
		if (presentation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
		}
		if (announcement_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Announcement);
		}
		num += timers_.CalculateSize(_repeated_timers_codec);
		if (capture_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Capture);
		}
		if (timecode_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Timecode);
		}
		if (SystemTime != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(SystemTime);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TriggerTransferRenderState other)
	{
		if (other == null)
		{
			return;
		}
		if (other.slide_ != null)
		{
			if (slide_ == null)
			{
				Slide = new Slide();
			}
			Slide.MergeFrom(other.Slide);
		}
		if (other.StageMessage.Length != 0)
		{
			StageMessage = other.StageMessage;
		}
		if (other.presentationMedia_ != null)
		{
			if (presentationMedia_ == null)
			{
				PresentationMedia = new Types.MediaState();
			}
			PresentationMedia.MergeFrom(other.PresentationMedia);
		}
		if (other.announcementMedia_ != null)
		{
			if (announcementMedia_ == null)
			{
				AnnouncementMedia = new Types.MediaState();
			}
			AnnouncementMedia.MergeFrom(other.AnnouncementMedia);
		}
		if (other.audioMedia_ != null)
		{
			if (audioMedia_ == null)
			{
				AudioMedia = new Types.MediaState();
			}
			AudioMedia.MergeFrom(other.AudioMedia);
		}
		if (other.liveVideoMedia_ != null)
		{
			if (liveVideoMedia_ == null)
			{
				LiveVideoMedia = new Media();
			}
			LiveVideoMedia.MergeFrom(other.LiveVideoMedia);
		}
		if (other.presentation_ != null)
		{
			if (presentation_ == null)
			{
				Presentation = new Types.SlideState();
			}
			Presentation.MergeFrom(other.Presentation);
		}
		if (other.announcement_ != null)
		{
			if (announcement_ == null)
			{
				Announcement = new Types.SlideState();
			}
			Announcement.MergeFrom(other.Announcement);
		}
		timers_.Add(other.timers_);
		if (other.capture_ != null)
		{
			if (capture_ == null)
			{
				Capture = new Types.CaptureState();
			}
			Capture.MergeFrom(other.Capture);
		}
		if (other.timecode_ != null)
		{
			if (timecode_ == null)
			{
				Timecode = new Types.TimecodeState();
			}
			Timecode.MergeFrom(other.Timecode);
		}
		if (other.SystemTime != 0L)
		{
			SystemTime = other.SystemTime;
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
				if (slide_ == null)
				{
					Slide = new Slide();
				}
				input.ReadMessage(Slide);
				break;
			case 18u:
				StageMessage = input.ReadString();
				break;
			case 26u:
				if (presentationMedia_ == null)
				{
					PresentationMedia = new Types.MediaState();
				}
				input.ReadMessage(PresentationMedia);
				break;
			case 34u:
				if (announcementMedia_ == null)
				{
					AnnouncementMedia = new Types.MediaState();
				}
				input.ReadMessage(AnnouncementMedia);
				break;
			case 42u:
				if (audioMedia_ == null)
				{
					AudioMedia = new Types.MediaState();
				}
				input.ReadMessage(AudioMedia);
				break;
			case 50u:
				if (liveVideoMedia_ == null)
				{
					LiveVideoMedia = new Media();
				}
				input.ReadMessage(LiveVideoMedia);
				break;
			case 58u:
				if (presentation_ == null)
				{
					Presentation = new Types.SlideState();
				}
				input.ReadMessage(Presentation);
				break;
			case 66u:
				if (announcement_ == null)
				{
					Announcement = new Types.SlideState();
				}
				input.ReadMessage(Announcement);
				break;
			case 74u:
				timers_.AddEntriesFrom(input, _repeated_timers_codec);
				break;
			case 82u:
				if (capture_ == null)
				{
					Capture = new Types.CaptureState();
				}
				input.ReadMessage(Capture);
				break;
			case 90u:
				if (timecode_ == null)
				{
					Timecode = new Types.TimecodeState();
				}
				input.ReadMessage(Timecode);
				break;
			case 96u:
				SystemTime = input.ReadUInt64();
				break;
			}
		}
	}
}
