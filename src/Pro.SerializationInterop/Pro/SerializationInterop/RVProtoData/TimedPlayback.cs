using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TimedPlayback : IMessage<TimedPlayback>, IMessage, IEquatable<TimedPlayback>, IDeepCloneable<TimedPlayback>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Sequence : IMessage<Sequence>, IMessage, IEquatable<Sequence>, IDeepCloneable<Sequence>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class SequenceItem : IMessage<SequenceItem>, IMessage, IEquatable<SequenceItem>, IDeepCloneable<SequenceItem>
				{
					public enum ItemOneofCase
					{
						None = 0,
						Cue = 5,
						Action = 6
					}

					private static readonly MessageParser<SequenceItem> _parser = new MessageParser<SequenceItem>(() => new SequenceItem());

					private UnknownFieldSet _unknownFields;

					public const int IdentifierFieldNumber = 1;

					private UUID identifier_;

					public const int TimeFieldNumber = 2;

					private double time_;

					public const int TriggerSourceFieldNumber = 3;

					private TriggerSource triggerSource_;

					public const int ContentDestinationFieldNumber = 4;

					private Action.Types.ContentDestination contentDestination_;

					public const int CueFieldNumber = 5;

					public const int ActionFieldNumber = 6;

					public const int EndTimeFieldNumber = 7;

					private double endTime_;

					private object item_;

					private ItemOneofCase itemCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<SequenceItem> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Sequence.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UUID Identifier
					{
						get
						{
							return identifier_;
						}
						set
						{
							identifier_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Time
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
					public TriggerSource TriggerSource
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
					public Action.Types.ContentDestination ContentDestination
					{
						get
						{
							return contentDestination_;
						}
						set
						{
							contentDestination_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Cue Cue
					{
						get
						{
							if (itemCase_ != ItemOneofCase.Cue)
							{
								return null;
							}
							return (Cue)item_;
						}
						set
						{
							item_ = value;
							itemCase_ = ((value != null) ? ItemOneofCase.Cue : ItemOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Action Action
					{
						get
						{
							if (itemCase_ != ItemOneofCase.Action)
							{
								return null;
							}
							return (Action)item_;
						}
						set
						{
							item_ = value;
							itemCase_ = ((value != null) ? ItemOneofCase.Action : ItemOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double EndTime
					{
						get
						{
							return endTime_;
						}
						set
						{
							endTime_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ItemOneofCase ItemCase => itemCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SequenceItem()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SequenceItem(SequenceItem other)
						: this()
					{
						identifier_ = ((other.identifier_ != null) ? other.identifier_.Clone() : null);
						time_ = other.time_;
						triggerSource_ = ((other.triggerSource_ != null) ? other.triggerSource_.Clone() : null);
						contentDestination_ = other.contentDestination_;
						endTime_ = other.endTime_;
						switch (other.ItemCase)
						{
						case ItemOneofCase.Cue:
							Cue = other.Cue.Clone();
							break;
						case ItemOneofCase.Action:
							Action = other.Action.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SequenceItem Clone()
					{
						return new SequenceItem(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearItem()
					{
						itemCase_ = ItemOneofCase.None;
						item_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as SequenceItem);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(SequenceItem other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(Identifier, other.Identifier))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
						{
							return false;
						}
						if (!object.Equals(TriggerSource, other.TriggerSource))
						{
							return false;
						}
						if (ContentDestination != other.ContentDestination)
						{
							return false;
						}
						if (!object.Equals(Cue, other.Cue))
						{
							return false;
						}
						if (!object.Equals(Action, other.Action))
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(EndTime, other.EndTime))
						{
							return false;
						}
						if (ItemCase != other.ItemCase)
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
						if (identifier_ != null)
						{
							num ^= Identifier.GetHashCode();
						}
						if (Time != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
						}
						if (triggerSource_ != null)
						{
							num ^= TriggerSource.GetHashCode();
						}
						if (ContentDestination != 0)
						{
							num ^= ContentDestination.GetHashCode();
						}
						if (itemCase_ == ItemOneofCase.Cue)
						{
							num ^= Cue.GetHashCode();
						}
						if (itemCase_ == ItemOneofCase.Action)
						{
							num ^= Action.GetHashCode();
						}
						if (EndTime != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(EndTime);
						}
						num ^= (int)itemCase_;
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
						if (identifier_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Identifier);
						}
						if (Time != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(Time);
						}
						if (triggerSource_ != null)
						{
							output.WriteRawTag(26);
							output.WriteMessage(TriggerSource);
						}
						if (ContentDestination != 0)
						{
							output.WriteRawTag(32);
							output.WriteEnum((int)ContentDestination);
						}
						if (itemCase_ == ItemOneofCase.Cue)
						{
							output.WriteRawTag(42);
							output.WriteMessage(Cue);
						}
						if (itemCase_ == ItemOneofCase.Action)
						{
							output.WriteRawTag(50);
							output.WriteMessage(Action);
						}
						if (EndTime != 0.0)
						{
							output.WriteRawTag(57);
							output.WriteDouble(EndTime);
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
						if (identifier_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Identifier);
						}
						if (Time != 0.0)
						{
							num += 9;
						}
						if (triggerSource_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(TriggerSource);
						}
						if (ContentDestination != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentDestination);
						}
						if (itemCase_ == ItemOneofCase.Cue)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Cue);
						}
						if (itemCase_ == ItemOneofCase.Action)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Action);
						}
						if (EndTime != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(SequenceItem other)
					{
						if (other == null)
						{
							return;
						}
						if (other.identifier_ != null)
						{
							if (identifier_ == null)
							{
								Identifier = new UUID();
							}
							Identifier.MergeFrom(other.Identifier);
						}
						if (other.Time != 0.0)
						{
							Time = other.Time;
						}
						if (other.triggerSource_ != null)
						{
							if (triggerSource_ == null)
							{
								TriggerSource = new TriggerSource();
							}
							TriggerSource.MergeFrom(other.TriggerSource);
						}
						if (other.ContentDestination != 0)
						{
							ContentDestination = other.ContentDestination;
						}
						if (other.EndTime != 0.0)
						{
							EndTime = other.EndTime;
						}
						switch (other.ItemCase)
						{
						case ItemOneofCase.Cue:
							if (Cue == null)
							{
								Cue = new Cue();
							}
							Cue.MergeFrom(other.Cue);
							break;
						case ItemOneofCase.Action:
							if (Action == null)
							{
								Action = new Action();
							}
							Action.MergeFrom(other.Action);
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
								if (identifier_ == null)
								{
									Identifier = new UUID();
								}
								input.ReadMessage(Identifier);
								break;
							case 17u:
								Time = input.ReadDouble();
								break;
							case 26u:
								if (triggerSource_ == null)
								{
									TriggerSource = new TriggerSource();
								}
								input.ReadMessage(TriggerSource);
								break;
							case 32u:
								ContentDestination = (Action.Types.ContentDestination)input.ReadEnum();
								break;
							case 42u:
							{
								Cue cue = new Cue();
								if (itemCase_ == ItemOneofCase.Cue)
								{
									cue.MergeFrom(Cue);
								}
								input.ReadMessage(cue);
								Cue = cue;
								break;
							}
							case 50u:
							{
								Action action = new Action();
								if (itemCase_ == ItemOneofCase.Action)
								{
									action.MergeFrom(Action);
								}
								input.ReadMessage(action);
								Action = action;
								break;
							}
							case 57u:
								EndTime = input.ReadDouble();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Sequence> _parser = new MessageParser<Sequence>(() => new Sequence());

			private UnknownFieldSet _unknownFields;

			public const int Sequence_FieldNumber = 1;

			private static readonly FieldCodec<Types.SequenceItem> _repeated_sequence_codec = FieldCodec.ForMessage(10u, Types.SequenceItem.Parser);

			private readonly RepeatedField<Types.SequenceItem> sequence_ = new RepeatedField<Types.SequenceItem>();

			public const int ContentDestinationFieldNumber = 2;

			private Action.Types.ContentDestination contentDestination_;

			public const int PresentationFieldNumber = 3;

			private Presentation presentation_;

			public const int PlaylistFieldNumber = 4;

			private Playlist playlist_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Sequence> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TimedPlayback.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.SequenceItem> Sequence_ => sequence_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action.Types.ContentDestination ContentDestination
			{
				get
				{
					return contentDestination_;
				}
				set
				{
					contentDestination_ = value;
				}
			}

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
			public Sequence()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Sequence(Sequence other)
				: this()
			{
				sequence_ = other.sequence_.Clone();
				contentDestination_ = other.contentDestination_;
				presentation_ = ((other.presentation_ != null) ? other.presentation_.Clone() : null);
				playlist_ = ((other.playlist_ != null) ? other.playlist_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Sequence Clone()
			{
				return new Sequence(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Sequence);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Sequence other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!sequence_.Equals(other.sequence_))
				{
					return false;
				}
				if (ContentDestination != other.ContentDestination)
				{
					return false;
				}
				if (!object.Equals(Presentation, other.Presentation))
				{
					return false;
				}
				if (!object.Equals(Playlist, other.Playlist))
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
				num ^= sequence_.GetHashCode();
				if (ContentDestination != 0)
				{
					num ^= ContentDestination.GetHashCode();
				}
				if (presentation_ != null)
				{
					num ^= Presentation.GetHashCode();
				}
				if (playlist_ != null)
				{
					num ^= Playlist.GetHashCode();
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
				sequence_.WriteTo(output, _repeated_sequence_codec);
				if (ContentDestination != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)ContentDestination);
				}
				if (presentation_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Presentation);
				}
				if (playlist_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Playlist);
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
				num += sequence_.CalculateSize(_repeated_sequence_codec);
				if (ContentDestination != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ContentDestination);
				}
				if (presentation_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Presentation);
				}
				if (playlist_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Sequence other)
			{
				if (other == null)
				{
					return;
				}
				sequence_.Add(other.sequence_);
				if (other.ContentDestination != 0)
				{
					ContentDestination = other.ContentDestination;
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
						sequence_.AddEntriesFrom(input, _repeated_sequence_codec);
						break;
					case 16u:
						ContentDestination = (Action.Types.ContentDestination)input.ReadEnum();
						break;
					case 26u:
						if (presentation_ == null)
						{
							Presentation = new Presentation();
						}
						input.ReadMessage(Presentation);
						break;
					case 34u:
						if (playlist_ == null)
						{
							Playlist = new Playlist();
						}
						input.ReadMessage(Playlist);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Timing : IMessage<Timing>, IMessage, IEquatable<Timing>, IDeepCloneable<Timing>
		{
			public enum SourceOneofCase
			{
				None,
				LayerTransport,
				SmpteTimecode,
				Internal
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class LayerTransport : IMessage<LayerTransport>, IMessage, IEquatable<LayerTransport>, IDeepCloneable<LayerTransport>
				{
					private static readonly MessageParser<LayerTransport> _parser = new MessageParser<LayerTransport>(() => new LayerTransport());

					private UnknownFieldSet _unknownFields;

					public const int LayerFieldNumber = 1;

					private int layer_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<LayerTransport> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Timing.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public int Layer
					{
						get
						{
							return layer_;
						}
						set
						{
							layer_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LayerTransport()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LayerTransport(LayerTransport other)
						: this()
					{
						layer_ = other.layer_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public LayerTransport Clone()
					{
						return new LayerTransport(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as LayerTransport);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(LayerTransport other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Layer != other.Layer)
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
						if (Layer != 0)
						{
							num ^= Layer.GetHashCode();
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
						if (Layer != 0)
						{
							output.WriteRawTag(8);
							output.WriteInt32(Layer);
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
						if (Layer != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(Layer);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(LayerTransport other)
					{
						if (other != null)
						{
							if (other.Layer != 0)
							{
								Layer = other.Layer;
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
								Layer = input.ReadInt32();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class SMPTETimecode : IMessage<SMPTETimecode>, IMessage, IEquatable<SMPTETimecode>, IDeepCloneable<SMPTETimecode>
				{
					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						public enum Format
						{
							[OriginalName("FORMAT_24_FPS")]
							_24Fps,
							[OriginalName("FORMAT_25_FPS")]
							_25Fps,
							[OriginalName("FORMAT_29_97_FPS")]
							_2997Fps,
							[OriginalName("FORMAT_30_FPS")]
							_30Fps
						}
					}

					private static readonly MessageParser<SMPTETimecode> _parser = new MessageParser<SMPTETimecode>(() => new SMPTETimecode());

					private UnknownFieldSet _unknownFields;

					public const int DeviceIdentifierFieldNumber = 1;

					private string deviceIdentifier_ = "";

					public const int ChannelFieldNumber = 2;

					private int channel_;

					public const int FormatFieldNumber = 3;

					private Types.Format format_;

					public const int OffsetFieldNumber = 4;

					private double offset_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<SMPTETimecode> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Timing.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string DeviceIdentifier
					{
						get
						{
							return deviceIdentifier_;
						}
						set
						{
							deviceIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public int Channel
					{
						get
						{
							return channel_;
						}
						set
						{
							channel_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Format Format
					{
						get
						{
							return format_;
						}
						set
						{
							format_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Offset
					{
						get
						{
							return offset_;
						}
						set
						{
							offset_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SMPTETimecode()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SMPTETimecode(SMPTETimecode other)
						: this()
					{
						deviceIdentifier_ = other.deviceIdentifier_;
						channel_ = other.channel_;
						format_ = other.format_;
						offset_ = other.offset_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public SMPTETimecode Clone()
					{
						return new SMPTETimecode(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as SMPTETimecode);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(SMPTETimecode other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (DeviceIdentifier != other.DeviceIdentifier)
						{
							return false;
						}
						if (Channel != other.Channel)
						{
							return false;
						}
						if (Format != other.Format)
						{
							return false;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Offset, other.Offset))
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
						if (DeviceIdentifier.Length != 0)
						{
							num ^= DeviceIdentifier.GetHashCode();
						}
						if (Channel != 0)
						{
							num ^= Channel.GetHashCode();
						}
						if (Format != 0)
						{
							num ^= Format.GetHashCode();
						}
						if (Offset != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Offset);
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
						if (DeviceIdentifier.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(DeviceIdentifier);
						}
						if (Channel != 0)
						{
							output.WriteRawTag(16);
							output.WriteInt32(Channel);
						}
						if (Format != 0)
						{
							output.WriteRawTag(24);
							output.WriteEnum((int)Format);
						}
						if (Offset != 0.0)
						{
							output.WriteRawTag(33);
							output.WriteDouble(Offset);
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
						if (DeviceIdentifier.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(DeviceIdentifier);
						}
						if (Channel != 0)
						{
							num += 1 + CodedOutputStream.ComputeInt32Size(Channel);
						}
						if (Format != 0)
						{
							num += 1 + CodedOutputStream.ComputeEnumSize((int)Format);
						}
						if (Offset != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(SMPTETimecode other)
					{
						if (other != null)
						{
							if (other.DeviceIdentifier.Length != 0)
							{
								DeviceIdentifier = other.DeviceIdentifier;
							}
							if (other.Channel != 0)
							{
								Channel = other.Channel;
							}
							if (other.Format != 0)
							{
								Format = other.Format;
							}
							if (other.Offset != 0.0)
							{
								Offset = other.Offset;
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
							case 10u:
								DeviceIdentifier = input.ReadString();
								break;
							case 16u:
								Channel = input.ReadInt32();
								break;
							case 24u:
								Format = (Types.Format)input.ReadEnum();
								break;
							case 33u:
								Offset = input.ReadDouble();
								break;
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Internal : IMessage<Internal>, IMessage, IEquatable<Internal>, IDeepCloneable<Internal>
				{
					private static readonly MessageParser<Internal> _parser = new MessageParser<Internal>(() => new Internal());

					private UnknownFieldSet _unknownFields;

					public const int DurationFieldNumber = 1;

					private double duration_;

					public const int ShouldLoopFieldNumber = 2;

					private bool shouldLoop_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Internal> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Timing.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Duration
					{
						get
						{
							return duration_;
						}
						set
						{
							duration_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool ShouldLoop
					{
						get
						{
							return shouldLoop_;
						}
						set
						{
							shouldLoop_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Internal()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Internal(Internal other)
						: this()
					{
						duration_ = other.duration_;
						shouldLoop_ = other.shouldLoop_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Internal Clone()
					{
						return new Internal(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Internal);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Internal other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration, other.Duration))
						{
							return false;
						}
						if (ShouldLoop != other.ShouldLoop)
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
						if (Duration != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration);
						}
						if (ShouldLoop)
						{
							num ^= ShouldLoop.GetHashCode();
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
						if (Duration != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Duration);
						}
						if (ShouldLoop)
						{
							output.WriteRawTag(16);
							output.WriteBool(ShouldLoop);
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
						if (Duration != 0.0)
						{
							num += 9;
						}
						if (ShouldLoop)
						{
							num += 2;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Internal other)
					{
						if (other != null)
						{
							if (other.Duration != 0.0)
							{
								Duration = other.Duration;
							}
							if (other.ShouldLoop)
							{
								ShouldLoop = other.ShouldLoop;
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
							case 9u:
								Duration = input.ReadDouble();
								break;
							case 16u:
								ShouldLoop = input.ReadBool();
								break;
							}
						}
					}
				}
			}

			private static readonly MessageParser<Timing> _parser = new MessageParser<Timing>(() => new Timing());

			private UnknownFieldSet _unknownFields;

			public const int LayerTransportFieldNumber = 1;

			public const int SmpteTimecodeFieldNumber = 2;

			public const int InternalFieldNumber = 3;

			private object source_;

			private SourceOneofCase sourceCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Timing> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TimedPlayback.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.LayerTransport LayerTransport
			{
				get
				{
					if (sourceCase_ != SourceOneofCase.LayerTransport)
					{
						return null;
					}
					return (Types.LayerTransport)source_;
				}
				set
				{
					source_ = value;
					sourceCase_ = ((value != null) ? SourceOneofCase.LayerTransport : SourceOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.SMPTETimecode SmpteTimecode
			{
				get
				{
					if (sourceCase_ != SourceOneofCase.SmpteTimecode)
					{
						return null;
					}
					return (Types.SMPTETimecode)source_;
				}
				set
				{
					source_ = value;
					sourceCase_ = ((value != null) ? SourceOneofCase.SmpteTimecode : SourceOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Internal Internal
			{
				get
				{
					if (sourceCase_ != SourceOneofCase.Internal)
					{
						return null;
					}
					return (Types.Internal)source_;
				}
				set
				{
					source_ = value;
					sourceCase_ = ((value != null) ? SourceOneofCase.Internal : SourceOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SourceOneofCase SourceCase => sourceCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timing()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timing(Timing other)
				: this()
			{
				switch (other.SourceCase)
				{
				case SourceOneofCase.LayerTransport:
					LayerTransport = other.LayerTransport.Clone();
					break;
				case SourceOneofCase.SmpteTimecode:
					SmpteTimecode = other.SmpteTimecode.Clone();
					break;
				case SourceOneofCase.Internal:
					Internal = other.Internal.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timing Clone()
			{
				return new Timing(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearSource()
			{
				sourceCase_ = SourceOneofCase.None;
				source_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Timing);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Timing other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(LayerTransport, other.LayerTransport))
				{
					return false;
				}
				if (!object.Equals(SmpteTimecode, other.SmpteTimecode))
				{
					return false;
				}
				if (!object.Equals(Internal, other.Internal))
				{
					return false;
				}
				if (SourceCase != other.SourceCase)
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
				if (sourceCase_ == SourceOneofCase.LayerTransport)
				{
					num ^= LayerTransport.GetHashCode();
				}
				if (sourceCase_ == SourceOneofCase.SmpteTimecode)
				{
					num ^= SmpteTimecode.GetHashCode();
				}
				if (sourceCase_ == SourceOneofCase.Internal)
				{
					num ^= Internal.GetHashCode();
				}
				num ^= (int)sourceCase_;
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
				if (sourceCase_ == SourceOneofCase.LayerTransport)
				{
					output.WriteRawTag(10);
					output.WriteMessage(LayerTransport);
				}
				if (sourceCase_ == SourceOneofCase.SmpteTimecode)
				{
					output.WriteRawTag(18);
					output.WriteMessage(SmpteTimecode);
				}
				if (sourceCase_ == SourceOneofCase.Internal)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Internal);
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
				if (sourceCase_ == SourceOneofCase.LayerTransport)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LayerTransport);
				}
				if (sourceCase_ == SourceOneofCase.SmpteTimecode)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(SmpteTimecode);
				}
				if (sourceCase_ == SourceOneofCase.Internal)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Internal);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Timing other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.SourceCase)
				{
				case SourceOneofCase.LayerTransport:
					if (LayerTransport == null)
					{
						LayerTransport = new Types.LayerTransport();
					}
					LayerTransport.MergeFrom(other.LayerTransport);
					break;
				case SourceOneofCase.SmpteTimecode:
					if (SmpteTimecode == null)
					{
						SmpteTimecode = new Types.SMPTETimecode();
					}
					SmpteTimecode.MergeFrom(other.SmpteTimecode);
					break;
				case SourceOneofCase.Internal:
					if (Internal == null)
					{
						Internal = new Types.Internal();
					}
					Internal.MergeFrom(other.Internal);
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
						Types.LayerTransport layerTransport = new Types.LayerTransport();
						if (sourceCase_ == SourceOneofCase.LayerTransport)
						{
							layerTransport.MergeFrom(LayerTransport);
						}
						input.ReadMessage(layerTransport);
						LayerTransport = layerTransport;
						break;
					}
					case 18u:
					{
						Types.SMPTETimecode sMPTETimecode = new Types.SMPTETimecode();
						if (sourceCase_ == SourceOneofCase.SmpteTimecode)
						{
							sMPTETimecode.MergeFrom(SmpteTimecode);
						}
						input.ReadMessage(sMPTETimecode);
						SmpteTimecode = sMPTETimecode;
						break;
					}
					case 26u:
					{
						Types.Internal @internal = new Types.Internal();
						if (sourceCase_ == SourceOneofCase.Internal)
						{
							@internal.MergeFrom(Internal);
						}
						input.ReadMessage(@internal);
						Internal = @internal;
						break;
					}
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Update : IMessage<Update>, IMessage, IEquatable<Update>, IDeepCloneable<Update>
		{
			public enum ActionTypeOneofCase
			{
				None,
				Play,
				Record,
				Pause,
				Reset,
				JumpToTime,
				StartScrub,
				EndScrub,
				Duration,
				Loop,
				UpdateSequence,
				MonitorSource
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Play : IMessage<Play>, IMessage, IEquatable<Play>, IDeepCloneable<Play>
				{
					private static readonly MessageParser<Play> _parser = new MessageParser<Play>(() => new Play());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Play> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Play()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Play(Play other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Play Clone()
					{
						return new Play(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Play);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Play other)
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
					public void MergeFrom(Play other)
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
				public sealed class Record : IMessage<Record>, IMessage, IEquatable<Record>, IDeepCloneable<Record>
				{
					private static readonly MessageParser<Record> _parser = new MessageParser<Record>(() => new Record());

					private UnknownFieldSet _unknownFields;

					public const int IsRecordingFieldNumber = 1;

					private bool isRecording_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Record> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool IsRecording
					{
						get
						{
							return isRecording_;
						}
						set
						{
							isRecording_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Record()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Record(Record other)
						: this()
					{
						isRecording_ = other.isRecording_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Record Clone()
					{
						return new Record(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Record);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Record other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (IsRecording != other.IsRecording)
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
						if (IsRecording)
						{
							num ^= IsRecording.GetHashCode();
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
						if (IsRecording)
						{
							output.WriteRawTag(8);
							output.WriteBool(IsRecording);
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
						if (IsRecording)
						{
							num += 2;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Record other)
					{
						if (other != null)
						{
							if (other.IsRecording)
							{
								IsRecording = other.IsRecording;
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
								IsRecording = input.ReadBool();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Pause : IMessage<Pause>, IMessage, IEquatable<Pause>, IDeepCloneable<Pause>
				{
					private static readonly MessageParser<Pause> _parser = new MessageParser<Pause>(() => new Pause());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Pause> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Pause()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Pause(Pause other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Pause Clone()
					{
						return new Pause(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Pause);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Pause other)
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
					public void MergeFrom(Pause other)
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
				public sealed class Reset : IMessage<Reset>, IMessage, IEquatable<Reset>, IDeepCloneable<Reset>
				{
					private static readonly MessageParser<Reset> _parser = new MessageParser<Reset>(() => new Reset());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Reset> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[3];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Reset()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Reset(Reset other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Reset Clone()
					{
						return new Reset(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Reset);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Reset other)
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
					public void MergeFrom(Reset other)
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
				public sealed class JumpToTime : IMessage<JumpToTime>, IMessage, IEquatable<JumpToTime>, IDeepCloneable<JumpToTime>
				{
					private static readonly MessageParser<JumpToTime> _parser = new MessageParser<JumpToTime>(() => new JumpToTime());

					private UnknownFieldSet _unknownFields;

					public const int TimeFieldNumber = 1;

					private double time_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<JumpToTime> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[4];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Time
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
					public JumpToTime()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public JumpToTime(JumpToTime other)
						: this()
					{
						time_ = other.time_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public JumpToTime Clone()
					{
						return new JumpToTime(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as JumpToTime);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(JumpToTime other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
						if (Time != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
						if (Time != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Time);
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
						if (Time != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(JumpToTime other)
					{
						if (other != null)
						{
							if (other.Time != 0.0)
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
							if (num != 9)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Time = input.ReadDouble();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class StartScrub : IMessage<StartScrub>, IMessage, IEquatable<StartScrub>, IDeepCloneable<StartScrub>
				{
					private static readonly MessageParser<StartScrub> _parser = new MessageParser<StartScrub>(() => new StartScrub());

					private UnknownFieldSet _unknownFields;

					public const int TimeFieldNumber = 1;

					private double time_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<StartScrub> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[5];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Time
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
					public StartScrub()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StartScrub(StartScrub other)
						: this()
					{
						time_ = other.time_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StartScrub Clone()
					{
						return new StartScrub(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as StartScrub);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(StartScrub other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
						if (Time != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
						if (Time != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Time);
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
						if (Time != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(StartScrub other)
					{
						if (other != null)
						{
							if (other.Time != 0.0)
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
							if (num != 9)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Time = input.ReadDouble();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class EndScrub : IMessage<EndScrub>, IMessage, IEquatable<EndScrub>, IDeepCloneable<EndScrub>
				{
					private static readonly MessageParser<EndScrub> _parser = new MessageParser<EndScrub>(() => new EndScrub());

					private UnknownFieldSet _unknownFields;

					public const int TimeFieldNumber = 2;

					private double time_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<EndScrub> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[6];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Time
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
					public EndScrub()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EndScrub(EndScrub other)
						: this()
					{
						time_ = other.time_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public EndScrub Clone()
					{
						return new EndScrub(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as EndScrub);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(EndScrub other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
						if (Time != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
						if (Time != 0.0)
						{
							output.WriteRawTag(17);
							output.WriteDouble(Time);
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
						if (Time != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(EndScrub other)
					{
						if (other != null)
						{
							if (other.Time != 0.0)
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
							if (num != 17)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Time = input.ReadDouble();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Duration : IMessage<Duration>, IMessage, IEquatable<Duration>, IDeepCloneable<Duration>
				{
					private static readonly MessageParser<Duration> _parser = new MessageParser<Duration>(() => new Duration());

					private UnknownFieldSet _unknownFields;

					public const int Duration_FieldNumber = 1;

					private double duration_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Duration> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[7];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public double Duration_
					{
						get
						{
							return duration_;
						}
						set
						{
							duration_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Duration()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Duration(Duration other)
						: this()
					{
						duration_ = other.duration_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Duration Clone()
					{
						return new Duration(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Duration);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Duration other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration_, other.Duration_))
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
						if (Duration_ != 0.0)
						{
							num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration_);
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
						if (Duration_ != 0.0)
						{
							output.WriteRawTag(9);
							output.WriteDouble(Duration_);
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
						if (Duration_ != 0.0)
						{
							num += 9;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Duration other)
					{
						if (other != null)
						{
							if (other.Duration_ != 0.0)
							{
								Duration_ = other.Duration_;
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
							if (num != 9)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								Duration_ = input.ReadDouble();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Loop : IMessage<Loop>, IMessage, IEquatable<Loop>, IDeepCloneable<Loop>
				{
					private static readonly MessageParser<Loop> _parser = new MessageParser<Loop>(() => new Loop());

					private UnknownFieldSet _unknownFields;

					public const int Loop_FieldNumber = 1;

					private bool loop_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Loop> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[8];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Loop_
					{
						get
						{
							return loop_;
						}
						set
						{
							loop_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Loop()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Loop(Loop other)
						: this()
					{
						loop_ = other.loop_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Loop Clone()
					{
						return new Loop(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Loop);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Loop other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Loop_ != other.Loop_)
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
						if (Loop_)
						{
							num ^= Loop_.GetHashCode();
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
						if (Loop_)
						{
							output.WriteRawTag(8);
							output.WriteBool(Loop_);
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
						if (Loop_)
						{
							num += 2;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Loop other)
					{
						if (other != null)
						{
							if (other.Loop_)
							{
								Loop_ = other.Loop_;
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
								Loop_ = input.ReadBool();
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class MonitorSource : IMessage<MonitorSource>, IMessage, IEquatable<MonitorSource>, IDeepCloneable<MonitorSource>
				{
					private static readonly MessageParser<MonitorSource> _parser = new MessageParser<MonitorSource>(() => new MonitorSource());

					private UnknownFieldSet _unknownFields;

					public const int EnableFieldNumber = 1;

					private bool enable_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<MonitorSource> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Update.Descriptor.NestedTypes[9];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Enable
					{
						get
						{
							return enable_;
						}
						set
						{
							enable_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MonitorSource()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MonitorSource(MonitorSource other)
						: this()
					{
						enable_ = other.enable_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public MonitorSource Clone()
					{
						return new MonitorSource(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as MonitorSource);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(MonitorSource other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Enable != other.Enable)
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
						if (Enable)
						{
							num ^= Enable.GetHashCode();
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
						if (Enable)
						{
							output.WriteRawTag(8);
							output.WriteBool(Enable);
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
						if (Enable)
						{
							num += 2;
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(MonitorSource other)
					{
						if (other != null)
						{
							if (other.Enable)
							{
								Enable = other.Enable;
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
								Enable = input.ReadBool();
							}
						}
					}
				}
			}

			private static readonly MessageParser<Update> _parser = new MessageParser<Update>(() => new Update());

			private UnknownFieldSet _unknownFields;

			public const int PlayFieldNumber = 1;

			public const int RecordFieldNumber = 2;

			public const int PauseFieldNumber = 3;

			public const int ResetFieldNumber = 4;

			public const int JumpToTimeFieldNumber = 5;

			public const int StartScrubFieldNumber = 6;

			public const int EndScrubFieldNumber = 7;

			public const int DurationFieldNumber = 8;

			public const int LoopFieldNumber = 9;

			public const int UpdateSequenceFieldNumber = 10;

			public const int MonitorSourceFieldNumber = 11;

			private object actionType_;

			private ActionTypeOneofCase actionTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Update> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TimedPlayback.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Play Play
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.Play)
					{
						return null;
					}
					return (Types.Play)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Play : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Record Record
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.Record)
					{
						return null;
					}
					return (Types.Record)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Record : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Pause Pause
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.Pause)
					{
						return null;
					}
					return (Types.Pause)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Pause : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Reset Reset
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.Reset)
					{
						return null;
					}
					return (Types.Reset)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Reset : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.JumpToTime JumpToTime
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.JumpToTime)
					{
						return null;
					}
					return (Types.JumpToTime)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.JumpToTime : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.StartScrub StartScrub
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.StartScrub)
					{
						return null;
					}
					return (Types.StartScrub)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.StartScrub : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.EndScrub EndScrub
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.EndScrub)
					{
						return null;
					}
					return (Types.EndScrub)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.EndScrub : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Duration Duration
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.Duration)
					{
						return null;
					}
					return (Types.Duration)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Duration : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Loop Loop
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.Loop)
					{
						return null;
					}
					return (Types.Loop)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Loop : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Sequence UpdateSequence
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.UpdateSequence)
					{
						return null;
					}
					return (Sequence)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.UpdateSequence : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.MonitorSource MonitorSource
			{
				get
				{
					if (actionTypeCase_ != ActionTypeOneofCase.MonitorSource)
					{
						return null;
					}
					return (Types.MonitorSource)actionType_;
				}
				set
				{
					actionType_ = value;
					actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.MonitorSource : ActionTypeOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActionTypeOneofCase ActionTypeCase => actionTypeCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Update()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Update(Update other)
				: this()
			{
				switch (other.ActionTypeCase)
				{
				case ActionTypeOneofCase.Play:
					Play = other.Play.Clone();
					break;
				case ActionTypeOneofCase.Record:
					Record = other.Record.Clone();
					break;
				case ActionTypeOneofCase.Pause:
					Pause = other.Pause.Clone();
					break;
				case ActionTypeOneofCase.Reset:
					Reset = other.Reset.Clone();
					break;
				case ActionTypeOneofCase.JumpToTime:
					JumpToTime = other.JumpToTime.Clone();
					break;
				case ActionTypeOneofCase.StartScrub:
					StartScrub = other.StartScrub.Clone();
					break;
				case ActionTypeOneofCase.EndScrub:
					EndScrub = other.EndScrub.Clone();
					break;
				case ActionTypeOneofCase.Duration:
					Duration = other.Duration.Clone();
					break;
				case ActionTypeOneofCase.Loop:
					Loop = other.Loop.Clone();
					break;
				case ActionTypeOneofCase.UpdateSequence:
					UpdateSequence = other.UpdateSequence.Clone();
					break;
				case ActionTypeOneofCase.MonitorSource:
					MonitorSource = other.MonitorSource.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Update Clone()
			{
				return new Update(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearActionType()
			{
				actionTypeCase_ = ActionTypeOneofCase.None;
				actionType_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Update);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Update other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Play, other.Play))
				{
					return false;
				}
				if (!object.Equals(Record, other.Record))
				{
					return false;
				}
				if (!object.Equals(Pause, other.Pause))
				{
					return false;
				}
				if (!object.Equals(Reset, other.Reset))
				{
					return false;
				}
				if (!object.Equals(JumpToTime, other.JumpToTime))
				{
					return false;
				}
				if (!object.Equals(StartScrub, other.StartScrub))
				{
					return false;
				}
				if (!object.Equals(EndScrub, other.EndScrub))
				{
					return false;
				}
				if (!object.Equals(Duration, other.Duration))
				{
					return false;
				}
				if (!object.Equals(Loop, other.Loop))
				{
					return false;
				}
				if (!object.Equals(UpdateSequence, other.UpdateSequence))
				{
					return false;
				}
				if (!object.Equals(MonitorSource, other.MonitorSource))
				{
					return false;
				}
				if (ActionTypeCase != other.ActionTypeCase)
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
				if (actionTypeCase_ == ActionTypeOneofCase.Play)
				{
					num ^= Play.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Record)
				{
					num ^= Record.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Pause)
				{
					num ^= Pause.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Reset)
				{
					num ^= Reset.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.JumpToTime)
				{
					num ^= JumpToTime.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.StartScrub)
				{
					num ^= StartScrub.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.EndScrub)
				{
					num ^= EndScrub.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Duration)
				{
					num ^= Duration.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Loop)
				{
					num ^= Loop.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.UpdateSequence)
				{
					num ^= UpdateSequence.GetHashCode();
				}
				if (actionTypeCase_ == ActionTypeOneofCase.MonitorSource)
				{
					num ^= MonitorSource.GetHashCode();
				}
				num ^= (int)actionTypeCase_;
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
				if (actionTypeCase_ == ActionTypeOneofCase.Play)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Play);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Record)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Record);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Pause)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Pause);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Reset)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Reset);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.JumpToTime)
				{
					output.WriteRawTag(42);
					output.WriteMessage(JumpToTime);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.StartScrub)
				{
					output.WriteRawTag(50);
					output.WriteMessage(StartScrub);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.EndScrub)
				{
					output.WriteRawTag(58);
					output.WriteMessage(EndScrub);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Duration)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Duration);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Loop)
				{
					output.WriteRawTag(74);
					output.WriteMessage(Loop);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.UpdateSequence)
				{
					output.WriteRawTag(82);
					output.WriteMessage(UpdateSequence);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.MonitorSource)
				{
					output.WriteRawTag(90);
					output.WriteMessage(MonitorSource);
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
				if (actionTypeCase_ == ActionTypeOneofCase.Play)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Play);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Record)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Record);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Pause)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Reset)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Reset);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.JumpToTime)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(JumpToTime);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.StartScrub)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(StartScrub);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.EndScrub)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(EndScrub);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Duration)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Duration);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.Loop)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Loop);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.UpdateSequence)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UpdateSequence);
				}
				if (actionTypeCase_ == ActionTypeOneofCase.MonitorSource)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MonitorSource);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Update other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ActionTypeCase)
				{
				case ActionTypeOneofCase.Play:
					if (Play == null)
					{
						Play = new Types.Play();
					}
					Play.MergeFrom(other.Play);
					break;
				case ActionTypeOneofCase.Record:
					if (Record == null)
					{
						Record = new Types.Record();
					}
					Record.MergeFrom(other.Record);
					break;
				case ActionTypeOneofCase.Pause:
					if (Pause == null)
					{
						Pause = new Types.Pause();
					}
					Pause.MergeFrom(other.Pause);
					break;
				case ActionTypeOneofCase.Reset:
					if (Reset == null)
					{
						Reset = new Types.Reset();
					}
					Reset.MergeFrom(other.Reset);
					break;
				case ActionTypeOneofCase.JumpToTime:
					if (JumpToTime == null)
					{
						JumpToTime = new Types.JumpToTime();
					}
					JumpToTime.MergeFrom(other.JumpToTime);
					break;
				case ActionTypeOneofCase.StartScrub:
					if (StartScrub == null)
					{
						StartScrub = new Types.StartScrub();
					}
					StartScrub.MergeFrom(other.StartScrub);
					break;
				case ActionTypeOneofCase.EndScrub:
					if (EndScrub == null)
					{
						EndScrub = new Types.EndScrub();
					}
					EndScrub.MergeFrom(other.EndScrub);
					break;
				case ActionTypeOneofCase.Duration:
					if (Duration == null)
					{
						Duration = new Types.Duration();
					}
					Duration.MergeFrom(other.Duration);
					break;
				case ActionTypeOneofCase.Loop:
					if (Loop == null)
					{
						Loop = new Types.Loop();
					}
					Loop.MergeFrom(other.Loop);
					break;
				case ActionTypeOneofCase.UpdateSequence:
					if (UpdateSequence == null)
					{
						UpdateSequence = new Sequence();
					}
					UpdateSequence.MergeFrom(other.UpdateSequence);
					break;
				case ActionTypeOneofCase.MonitorSource:
					if (MonitorSource == null)
					{
						MonitorSource = new Types.MonitorSource();
					}
					MonitorSource.MergeFrom(other.MonitorSource);
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
						Types.Play play = new Types.Play();
						if (actionTypeCase_ == ActionTypeOneofCase.Play)
						{
							play.MergeFrom(Play);
						}
						input.ReadMessage(play);
						Play = play;
						break;
					}
					case 18u:
					{
						Types.Record record = new Types.Record();
						if (actionTypeCase_ == ActionTypeOneofCase.Record)
						{
							record.MergeFrom(Record);
						}
						input.ReadMessage(record);
						Record = record;
						break;
					}
					case 26u:
					{
						Types.Pause pause = new Types.Pause();
						if (actionTypeCase_ == ActionTypeOneofCase.Pause)
						{
							pause.MergeFrom(Pause);
						}
						input.ReadMessage(pause);
						Pause = pause;
						break;
					}
					case 34u:
					{
						Types.Reset reset = new Types.Reset();
						if (actionTypeCase_ == ActionTypeOneofCase.Reset)
						{
							reset.MergeFrom(Reset);
						}
						input.ReadMessage(reset);
						Reset = reset;
						break;
					}
					case 42u:
					{
						Types.JumpToTime jumpToTime = new Types.JumpToTime();
						if (actionTypeCase_ == ActionTypeOneofCase.JumpToTime)
						{
							jumpToTime.MergeFrom(JumpToTime);
						}
						input.ReadMessage(jumpToTime);
						JumpToTime = jumpToTime;
						break;
					}
					case 50u:
					{
						Types.StartScrub startScrub = new Types.StartScrub();
						if (actionTypeCase_ == ActionTypeOneofCase.StartScrub)
						{
							startScrub.MergeFrom(StartScrub);
						}
						input.ReadMessage(startScrub);
						StartScrub = startScrub;
						break;
					}
					case 58u:
					{
						Types.EndScrub endScrub = new Types.EndScrub();
						if (actionTypeCase_ == ActionTypeOneofCase.EndScrub)
						{
							endScrub.MergeFrom(EndScrub);
						}
						input.ReadMessage(endScrub);
						EndScrub = endScrub;
						break;
					}
					case 66u:
					{
						Types.Duration duration = new Types.Duration();
						if (actionTypeCase_ == ActionTypeOneofCase.Duration)
						{
							duration.MergeFrom(Duration);
						}
						input.ReadMessage(duration);
						Duration = duration;
						break;
					}
					case 74u:
					{
						Types.Loop loop = new Types.Loop();
						if (actionTypeCase_ == ActionTypeOneofCase.Loop)
						{
							loop.MergeFrom(Loop);
						}
						input.ReadMessage(loop);
						Loop = loop;
						break;
					}
					case 82u:
					{
						Sequence sequence = new Sequence();
						if (actionTypeCase_ == ActionTypeOneofCase.UpdateSequence)
						{
							sequence.MergeFrom(UpdateSequence);
						}
						input.ReadMessage(sequence);
						UpdateSequence = sequence;
						break;
					}
					case 90u:
					{
						Types.MonitorSource monitorSource = new Types.MonitorSource();
						if (actionTypeCase_ == ActionTypeOneofCase.MonitorSource)
						{
							monitorSource.MergeFrom(MonitorSource);
						}
						input.ReadMessage(monitorSource);
						MonitorSource = monitorSource;
						break;
					}
					}
				}
			}
		}
	}

	private static readonly MessageParser<TimedPlayback> _parser = new MessageParser<TimedPlayback>(() => new TimedPlayback());

	private UnknownFieldSet _unknownFields;

	public const int SequenceFieldNumber = 1;

	private Types.Sequence sequence_;

	public const int TimingFieldNumber = 2;

	private Types.Timing timing_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TimedPlayback> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TimedPlaybackReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Sequence Sequence
	{
		get
		{
			return sequence_;
		}
		set
		{
			sequence_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Timing Timing
	{
		get
		{
			return timing_;
		}
		set
		{
			timing_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimedPlayback()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimedPlayback(TimedPlayback other)
		: this()
	{
		sequence_ = ((other.sequence_ != null) ? other.sequence_.Clone() : null);
		timing_ = ((other.timing_ != null) ? other.timing_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimedPlayback Clone()
	{
		return new TimedPlayback(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TimedPlayback);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TimedPlayback other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Sequence, other.Sequence))
		{
			return false;
		}
		if (!object.Equals(Timing, other.Timing))
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
		if (sequence_ != null)
		{
			num ^= Sequence.GetHashCode();
		}
		if (timing_ != null)
		{
			num ^= Timing.GetHashCode();
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
		if (sequence_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Sequence);
		}
		if (timing_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Timing);
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
		if (sequence_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Sequence);
		}
		if (timing_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Timing);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TimedPlayback other)
	{
		if (other == null)
		{
			return;
		}
		if (other.sequence_ != null)
		{
			if (sequence_ == null)
			{
				Sequence = new Types.Sequence();
			}
			Sequence.MergeFrom(other.Sequence);
		}
		if (other.timing_ != null)
		{
			if (timing_ == null)
			{
				Timing = new Types.Timing();
			}
			Timing.MergeFrom(other.Timing);
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
				if (sequence_ == null)
				{
					Sequence = new Types.Sequence();
				}
				input.ReadMessage(Sequence);
				break;
			case 18u:
				if (timing_ == null)
				{
					Timing = new Types.Timing();
				}
				input.ReadMessage(Timing);
				break;
			}
		}
	}
}
