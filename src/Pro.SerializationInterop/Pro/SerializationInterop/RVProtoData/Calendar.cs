using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Calendar : IMessage<Calendar>, IMessage, IEquatable<Calendar>, IDeepCloneable<Calendar>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Event : IMessage<Event>, IMessage, IEquatable<Event>, IDeepCloneable<Event>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum DayOfWeek
				{
					[OriginalName("DAY_OF_WEEK_UNKNOWN")]
					Unknown,
					[OriginalName("DAY_OF_WEEK_SUNDAY")]
					Sunday,
					[OriginalName("DAY_OF_WEEK_MONDAY")]
					Monday,
					[OriginalName("DAY_OF_WEEK_TUESDAY")]
					Tuesday,
					[OriginalName("DAY_OF_WEEK_WEDNESDAY")]
					Wednesday,
					[OriginalName("DAY_OF_WEEK_THURSDAY")]
					Thursday,
					[OriginalName("DAY_OF_WEEK_FRIDAY")]
					Friday,
					[OriginalName("DAY_OF_WEEK_SATURDAY")]
					Saturday
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Action : IMessage<Action>, IMessage, IEquatable<Action>, IDeepCloneable<Action>
				{
					public enum ActionTypeOneofCase
					{
						None = 0,
						Playlist = 3,
						Macro = 4
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static class Types
					{
						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Playlist : IMessage<Playlist>, IMessage, IEquatable<Playlist>, IDeepCloneable<Playlist>
						{
							private static readonly MessageParser<Playlist> _parser = new MessageParser<Playlist>(() => new Playlist());

							private UnknownFieldSet _unknownFields;

							public const int PlaylistUuidFieldNumber = 1;

							private UUID playlistUuid_;

							public const int PlaylistItemUuidFieldNumber = 2;

							private UUID playlistItemUuid_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Playlist> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[0];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

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
							public UUID PlaylistItemUuid
							{
								get
								{
									return playlistItemUuid_;
								}
								set
								{
									playlistItemUuid_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Playlist()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Playlist(Playlist other)
								: this()
							{
								playlistUuid_ = ((other.playlistUuid_ != null) ? other.playlistUuid_.Clone() : null);
								playlistItemUuid_ = ((other.playlistItemUuid_ != null) ? other.playlistItemUuid_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Playlist Clone()
							{
								return new Playlist(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Playlist);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Playlist other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(PlaylistUuid, other.PlaylistUuid))
								{
									return false;
								}
								if (!object.Equals(PlaylistItemUuid, other.PlaylistItemUuid))
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
								if (playlistUuid_ != null)
								{
									num ^= PlaylistUuid.GetHashCode();
								}
								if (playlistItemUuid_ != null)
								{
									num ^= PlaylistItemUuid.GetHashCode();
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
								if (playlistUuid_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(PlaylistUuid);
								}
								if (playlistItemUuid_ != null)
								{
									output.WriteRawTag(18);
									output.WriteMessage(PlaylistItemUuid);
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
								if (playlistUuid_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistUuid);
								}
								if (playlistItemUuid_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistItemUuid);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Playlist other)
							{
								if (other == null)
								{
									return;
								}
								if (other.playlistUuid_ != null)
								{
									if (playlistUuid_ == null)
									{
										PlaylistUuid = new UUID();
									}
									PlaylistUuid.MergeFrom(other.PlaylistUuid);
								}
								if (other.playlistItemUuid_ != null)
								{
									if (playlistItemUuid_ == null)
									{
										PlaylistItemUuid = new UUID();
									}
									PlaylistItemUuid.MergeFrom(other.PlaylistItemUuid);
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
										if (playlistUuid_ == null)
										{
											PlaylistUuid = new UUID();
										}
										input.ReadMessage(PlaylistUuid);
										break;
									case 18u:
										if (playlistItemUuid_ == null)
										{
											PlaylistItemUuid = new UUID();
										}
										input.ReadMessage(PlaylistItemUuid);
										break;
									}
								}
							}
						}

						[DebuggerDisplay("{ToString(),nq}")]
						public sealed class Macro : IMessage<Macro>, IMessage, IEquatable<Macro>, IDeepCloneable<Macro>
						{
							private static readonly MessageParser<Macro> _parser = new MessageParser<Macro>(() => new Macro());

							private UnknownFieldSet _unknownFields;

							public const int IdentificationFieldNumber = 1;

							private CollectionElementType identification_;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageParser<Macro> Parser => _parser;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public static MessageDescriptor Descriptor => Action.Descriptor.NestedTypes[1];

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							MessageDescriptor IMessage.Descriptor => Descriptor;

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public CollectionElementType Identification
							{
								get
								{
									return identification_;
								}
								set
								{
									identification_ = value;
								}
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Macro()
							{
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Macro(Macro other)
								: this()
							{
								identification_ = ((other.identification_ != null) ? other.identification_.Clone() : null);
								_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public Macro Clone()
							{
								return new Macro(this);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public override bool Equals(object other)
							{
								return Equals(other as Macro);
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public bool Equals(Macro other)
							{
								if (other == null)
								{
									return false;
								}
								if (other == this)
								{
									return true;
								}
								if (!object.Equals(Identification, other.Identification))
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
								if (identification_ != null)
								{
									num ^= Identification.GetHashCode();
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
								if (identification_ != null)
								{
									output.WriteRawTag(10);
									output.WriteMessage(Identification);
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
								if (identification_ != null)
								{
									num += 1 + CodedOutputStream.ComputeMessageSize(Identification);
								}
								if (_unknownFields != null)
								{
									num += _unknownFields.CalculateSize();
								}
								return num;
							}

							[DebuggerNonUserCode]
							[GeneratedCode("protoc", null)]
							public void MergeFrom(Macro other)
							{
								if (other == null)
								{
									return;
								}
								if (other.identification_ != null)
								{
									if (identification_ == null)
									{
										Identification = new CollectionElementType();
									}
									Identification.MergeFrom(other.Identification);
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
									if (identification_ == null)
									{
										Identification = new CollectionElementType();
									}
									input.ReadMessage(Identification);
								}
							}
						}
					}

					private static readonly MessageParser<Action> _parser = new MessageParser<Action>(() => new Action());

					private UnknownFieldSet _unknownFields;

					public const int TypeFieldNumber = 1;

					private uint type_;

					public const int UuidFieldNumber = 2;

					private UUID uuid_;

					public const int PlaylistFieldNumber = 3;

					public const int MacroFieldNumber = 4;

					private object actionType_;

					private ActionTypeOneofCase actionTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Action> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Event.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public uint Type
					{
						get
						{
							return type_;
						}
						set
						{
							type_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UUID Uuid
					{
						get
						{
							return uuid_;
						}
						set
						{
							uuid_ = value;
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Playlist Playlist
					{
						get
						{
							if (actionTypeCase_ != ActionTypeOneofCase.Playlist)
							{
								return null;
							}
							return (Types.Playlist)actionType_;
						}
						set
						{
							actionType_ = value;
							actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Playlist : ActionTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Types.Macro Macro
					{
						get
						{
							if (actionTypeCase_ != ActionTypeOneofCase.Macro)
							{
								return null;
							}
							return (Types.Macro)actionType_;
						}
						set
						{
							actionType_ = value;
							actionTypeCase_ = ((value != null) ? ActionTypeOneofCase.Macro : ActionTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ActionTypeOneofCase ActionTypeCase => actionTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Action()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Action(Action other)
						: this()
					{
						type_ = other.type_;
						uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
						switch (other.ActionTypeCase)
						{
						case ActionTypeOneofCase.Playlist:
							Playlist = other.Playlist.Clone();
							break;
						case ActionTypeOneofCase.Macro:
							Macro = other.Macro.Clone();
							break;
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Action Clone()
					{
						return new Action(this);
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
						return Equals(other as Action);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Action other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (Type != other.Type)
						{
							return false;
						}
						if (!object.Equals(Uuid, other.Uuid))
						{
							return false;
						}
						if (!object.Equals(Playlist, other.Playlist))
						{
							return false;
						}
						if (!object.Equals(Macro, other.Macro))
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
						if (Type != 0)
						{
							num ^= Type.GetHashCode();
						}
						if (uuid_ != null)
						{
							num ^= Uuid.GetHashCode();
						}
						if (actionTypeCase_ == ActionTypeOneofCase.Playlist)
						{
							num ^= Playlist.GetHashCode();
						}
						if (actionTypeCase_ == ActionTypeOneofCase.Macro)
						{
							num ^= Macro.GetHashCode();
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
						if (Type != 0)
						{
							output.WriteRawTag(8);
							output.WriteUInt32(Type);
						}
						if (uuid_ != null)
						{
							output.WriteRawTag(18);
							output.WriteMessage(Uuid);
						}
						if (actionTypeCase_ == ActionTypeOneofCase.Playlist)
						{
							output.WriteRawTag(26);
							output.WriteMessage(Playlist);
						}
						if (actionTypeCase_ == ActionTypeOneofCase.Macro)
						{
							output.WriteRawTag(34);
							output.WriteMessage(Macro);
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
						if (Type != 0)
						{
							num += 1 + CodedOutputStream.ComputeUInt32Size(Type);
						}
						if (uuid_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
						}
						if (actionTypeCase_ == ActionTypeOneofCase.Playlist)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Playlist);
						}
						if (actionTypeCase_ == ActionTypeOneofCase.Macro)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Macro);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Action other)
					{
						if (other == null)
						{
							return;
						}
						if (other.Type != 0)
						{
							Type = other.Type;
						}
						if (other.uuid_ != null)
						{
							if (uuid_ == null)
							{
								Uuid = new UUID();
							}
							Uuid.MergeFrom(other.Uuid);
						}
						switch (other.ActionTypeCase)
						{
						case ActionTypeOneofCase.Playlist:
							if (Playlist == null)
							{
								Playlist = new Types.Playlist();
							}
							Playlist.MergeFrom(other.Playlist);
							break;
						case ActionTypeOneofCase.Macro:
							if (Macro == null)
							{
								Macro = new Types.Macro();
							}
							Macro.MergeFrom(other.Macro);
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
								Type = input.ReadUInt32();
								break;
							case 18u:
								if (uuid_ == null)
								{
									Uuid = new UUID();
								}
								input.ReadMessage(Uuid);
								break;
							case 26u:
							{
								Types.Playlist playlist = new Types.Playlist();
								if (actionTypeCase_ == ActionTypeOneofCase.Playlist)
								{
									playlist.MergeFrom(Playlist);
								}
								input.ReadMessage(playlist);
								Playlist = playlist;
								break;
							}
							case 34u:
							{
								Types.Macro macro = new Types.Macro();
								if (actionTypeCase_ == ActionTypeOneofCase.Macro)
								{
									macro.MergeFrom(Macro);
								}
								input.ReadMessage(macro);
								Macro = macro;
								break;
							}
							}
						}
					}
				}
			}

			private static readonly MessageParser<Event> _parser = new MessageParser<Event>(() => new Event());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int DescriptionFieldNumber = 3;

			private string description_ = "";

			public const int DateFieldNumber = 4;

			private Timestamp date_;

			public const int RecurrenceDaysFieldNumber = 5;

			private static readonly FieldCodec<Types.DayOfWeek> _repeated_recurrenceDays_codec = FieldCodec.ForEnum(42u, (Types.DayOfWeek x) => (int)x, (int x) => (Types.DayOfWeek)x);

			private readonly RepeatedField<Types.DayOfWeek> recurrenceDays_ = new RepeatedField<Types.DayOfWeek>();

			public const int RecurrenceLimitDateFieldNumber = 6;

			private Timestamp recurrenceLimitDate_;

			public const int RecurrenceExcludedDatesFieldNumber = 7;

			private static readonly FieldCodec<Timestamp> _repeated_recurrenceExcludedDates_codec = FieldCodec.ForMessage(58u, Timestamp.Parser);

			private readonly RepeatedField<Timestamp> recurrenceExcludedDates_ = new RepeatedField<Timestamp>();

			public const int ActionFieldNumber = 8;

			private Types.Action action_;

			public const int ActionsFieldNumber = 9;

			private static readonly FieldCodec<Action> _repeated_actions_codec = FieldCodec.ForMessage(74u, Pro.SerializationInterop.RVProtoData.Action.Parser);

			private readonly RepeatedField<Action> actions_ = new RepeatedField<Action>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Event> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Calendar.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UUID Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Name
			{
				get
				{
					return name_;
				}
				set
				{
					name_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Description
			{
				get
				{
					return description_;
				}
				set
				{
					description_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timestamp Date
			{
				get
				{
					return date_;
				}
				set
				{
					date_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Types.DayOfWeek> RecurrenceDays => recurrenceDays_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Timestamp RecurrenceLimitDate
			{
				get
				{
					return recurrenceLimitDate_;
				}
				set
				{
					recurrenceLimitDate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Timestamp> RecurrenceExcludedDates => recurrenceExcludedDates_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Action Action
			{
				get
				{
					return action_;
				}
				set
				{
					action_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Action> Actions => actions_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Event()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Event(Event other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				description_ = other.description_;
				date_ = ((other.date_ != null) ? other.date_.Clone() : null);
				recurrenceDays_ = other.recurrenceDays_.Clone();
				recurrenceLimitDate_ = ((other.recurrenceLimitDate_ != null) ? other.recurrenceLimitDate_.Clone() : null);
				recurrenceExcludedDates_ = other.recurrenceExcludedDates_.Clone();
				action_ = ((other.action_ != null) ? other.action_.Clone() : null);
				actions_ = other.actions_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Event Clone()
			{
				return new Event(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Event);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Event other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Uuid, other.Uuid))
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Description != other.Description)
				{
					return false;
				}
				if (!object.Equals(Date, other.Date))
				{
					return false;
				}
				if (!recurrenceDays_.Equals(other.recurrenceDays_))
				{
					return false;
				}
				if (!object.Equals(RecurrenceLimitDate, other.RecurrenceLimitDate))
				{
					return false;
				}
				if (!recurrenceExcludedDates_.Equals(other.recurrenceExcludedDates_))
				{
					return false;
				}
				if (!object.Equals(Action, other.Action))
				{
					return false;
				}
				if (!actions_.Equals(other.actions_))
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
				if (uuid_ != null)
				{
					num ^= Uuid.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Description.Length != 0)
				{
					num ^= Description.GetHashCode();
				}
				if (date_ != null)
				{
					num ^= Date.GetHashCode();
				}
				num ^= recurrenceDays_.GetHashCode();
				if (recurrenceLimitDate_ != null)
				{
					num ^= RecurrenceLimitDate.GetHashCode();
				}
				num ^= recurrenceExcludedDates_.GetHashCode();
				if (action_ != null)
				{
					num ^= Action.GetHashCode();
				}
				num ^= actions_.GetHashCode();
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
				if (uuid_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Uuid);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Name);
				}
				if (Description.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Description);
				}
				if (date_ != null)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Date);
				}
				recurrenceDays_.WriteTo(output, _repeated_recurrenceDays_codec);
				if (recurrenceLimitDate_ != null)
				{
					output.WriteRawTag(50);
					output.WriteMessage(RecurrenceLimitDate);
				}
				recurrenceExcludedDates_.WriteTo(output, _repeated_recurrenceExcludedDates_codec);
				if (action_ != null)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Action);
				}
				actions_.WriteTo(output, _repeated_actions_codec);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Description.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Description);
				}
				if (date_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Date);
				}
				num += recurrenceDays_.CalculateSize(_repeated_recurrenceDays_codec);
				if (recurrenceLimitDate_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(RecurrenceLimitDate);
				}
				num += recurrenceExcludedDates_.CalculateSize(_repeated_recurrenceExcludedDates_codec);
				if (action_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Action);
				}
				num += actions_.CalculateSize(_repeated_actions_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Event other)
			{
				if (other == null)
				{
					return;
				}
				if (other.uuid_ != null)
				{
					if (uuid_ == null)
					{
						Uuid = new UUID();
					}
					Uuid.MergeFrom(other.Uuid);
				}
				if (other.Name.Length != 0)
				{
					Name = other.Name;
				}
				if (other.Description.Length != 0)
				{
					Description = other.Description;
				}
				if (other.date_ != null)
				{
					if (date_ == null)
					{
						Date = new Timestamp();
					}
					Date.MergeFrom(other.Date);
				}
				recurrenceDays_.Add(other.recurrenceDays_);
				if (other.recurrenceLimitDate_ != null)
				{
					if (recurrenceLimitDate_ == null)
					{
						RecurrenceLimitDate = new Timestamp();
					}
					RecurrenceLimitDate.MergeFrom(other.RecurrenceLimitDate);
				}
				recurrenceExcludedDates_.Add(other.recurrenceExcludedDates_);
				if (other.action_ != null)
				{
					if (action_ == null)
					{
						Action = new Types.Action();
					}
					Action.MergeFrom(other.Action);
				}
				actions_.Add(other.actions_);
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
						if (uuid_ == null)
						{
							Uuid = new UUID();
						}
						input.ReadMessage(Uuid);
						break;
					case 18u:
						Name = input.ReadString();
						break;
					case 26u:
						Description = input.ReadString();
						break;
					case 34u:
						if (date_ == null)
						{
							Date = new Timestamp();
						}
						input.ReadMessage(Date);
						break;
					case 40u:
					case 42u:
						recurrenceDays_.AddEntriesFrom(input, _repeated_recurrenceDays_codec);
						break;
					case 50u:
						if (recurrenceLimitDate_ == null)
						{
							RecurrenceLimitDate = new Timestamp();
						}
						input.ReadMessage(RecurrenceLimitDate);
						break;
					case 58u:
						recurrenceExcludedDates_.AddEntriesFrom(input, _repeated_recurrenceExcludedDates_codec);
						break;
					case 66u:
						if (action_ == null)
						{
							Action = new Types.Action();
						}
						input.ReadMessage(Action);
						break;
					case 74u:
						actions_.AddEntriesFrom(input, _repeated_actions_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Calendar> _parser = new MessageParser<Calendar>(() => new Calendar());

	private UnknownFieldSet _unknownFields;

	public const int EventsFieldNumber = 1;

	private static readonly FieldCodec<Types.Event> _repeated_events_codec = FieldCodec.ForMessage(10u, Types.Event.Parser);

	private readonly RepeatedField<Types.Event> events_ = new RepeatedField<Types.Event>();

	public const int ActiveFieldNumber = 2;

	private bool active_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Calendar> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CalendarReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Event> Events => events_;

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
	public Calendar()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Calendar(Calendar other)
		: this()
	{
		events_ = other.events_.Clone();
		active_ = other.active_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Calendar Clone()
	{
		return new Calendar(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Calendar);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Calendar other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!events_.Equals(other.events_))
		{
			return false;
		}
		if (Active != other.Active)
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
		num ^= events_.GetHashCode();
		if (Active)
		{
			num ^= Active.GetHashCode();
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
		events_.WriteTo(output, _repeated_events_codec);
		if (Active)
		{
			output.WriteRawTag(16);
			output.WriteBool(Active);
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
		num += events_.CalculateSize(_repeated_events_codec);
		if (Active)
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
	public void MergeFrom(Calendar other)
	{
		if (other != null)
		{
			events_.Add(other.events_);
			if (other.Active)
			{
				Active = other.Active;
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
				events_.AddEntriesFrom(input, _repeated_events_codec);
				break;
			case 16u:
				Active = input.ReadBool();
				break;
			}
		}
	}
}
