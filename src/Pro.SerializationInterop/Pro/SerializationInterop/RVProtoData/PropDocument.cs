using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PropDocument : IMessage<PropDocument>, IMessage, IEquatable<PropDocument>, IDeepCloneable<PropDocument>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PropCollection : IMessage<PropCollection>, IMessage, IEquatable<PropCollection>, IDeepCloneable<PropCollection>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Item : IMessage<Item>, IMessage, IEquatable<Item>, IDeepCloneable<Item>
				{
					public enum ItemTypeOneofCase
					{
						None,
						PropCueUuid
					}

					private static readonly MessageParser<Item> _parser = new MessageParser<Item>(() => new Item());

					private UnknownFieldSet _unknownFields;

					public const int PropCueUuidFieldNumber = 1;

					private object itemType_;

					private ItemTypeOneofCase itemTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Item> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => PropCollection.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UUID PropCueUuid
					{
						get
						{
							if (itemTypeCase_ != ItemTypeOneofCase.PropCueUuid)
							{
								return null;
							}
							return (UUID)itemType_;
						}
						set
						{
							itemType_ = value;
							itemTypeCase_ = ((value != null) ? ItemTypeOneofCase.PropCueUuid : ItemTypeOneofCase.None);
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ItemTypeOneofCase ItemTypeCase => itemTypeCase_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Item()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Item(Item other)
						: this()
					{
						if (other.ItemTypeCase == ItemTypeOneofCase.PropCueUuid)
						{
							PropCueUuid = other.PropCueUuid.Clone();
						}
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Item Clone()
					{
						return new Item(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void ClearItemType()
					{
						itemTypeCase_ = ItemTypeOneofCase.None;
						itemType_ = null;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Item);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Item other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!object.Equals(PropCueUuid, other.PropCueUuid))
						{
							return false;
						}
						if (ItemTypeCase != other.ItemTypeCase)
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
						if (itemTypeCase_ == ItemTypeOneofCase.PropCueUuid)
						{
							num ^= PropCueUuid.GetHashCode();
						}
						num ^= (int)itemTypeCase_;
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
						if (itemTypeCase_ == ItemTypeOneofCase.PropCueUuid)
						{
							output.WriteRawTag(10);
							output.WriteMessage(PropCueUuid);
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
						if (itemTypeCase_ == ItemTypeOneofCase.PropCueUuid)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(PropCueUuid);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Item other)
					{
						if (other == null)
						{
							return;
						}
						if (other.ItemTypeCase == ItemTypeOneofCase.PropCueUuid)
						{
							if (PropCueUuid == null)
							{
								PropCueUuid = new UUID();
							}
							PropCueUuid.MergeFrom(other.PropCueUuid);
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
							UUID uUID = new UUID();
							if (itemTypeCase_ == ItemTypeOneofCase.PropCueUuid)
							{
								uUID.MergeFrom(PropCueUuid);
							}
							input.ReadMessage(uUID);
							PropCueUuid = uUID;
						}
					}
				}
			}

			private static readonly MessageParser<PropCollection> _parser = new MessageParser<PropCollection>(() => new PropCollection());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int ItemsFieldNumber = 3;

			private static readonly FieldCodec<Types.Item> _repeated_items_codec = FieldCodec.ForMessage(26u, Types.Item.Parser);

			private readonly RepeatedField<Types.Item> items_ = new RepeatedField<Types.Item>();

			public const int SinglePropEnabledFieldNumber = 4;

			private bool singlePropEnabled_;

			public const int CuesFieldNumber = 5;

			private static readonly FieldCodec<Cue> _repeated_cues_codec = FieldCodec.ForMessage(42u, Cue.Parser);

			private readonly RepeatedField<Cue> cues_ = new RepeatedField<Cue>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PropCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PropDocument.Descriptor.NestedTypes[0];

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
			public RepeatedField<Types.Item> Items => items_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool SinglePropEnabled
			{
				get
				{
					return singlePropEnabled_;
				}
				set
				{
					singlePropEnabled_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Cue> Cues => cues_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PropCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PropCollection(PropCollection other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				items_ = other.items_.Clone();
				singlePropEnabled_ = other.singlePropEnabled_;
				cues_ = other.cues_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PropCollection Clone()
			{
				return new PropCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PropCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PropCollection other)
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
				if (!items_.Equals(other.items_))
				{
					return false;
				}
				if (SinglePropEnabled != other.SinglePropEnabled)
				{
					return false;
				}
				if (!cues_.Equals(other.cues_))
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
				num ^= items_.GetHashCode();
				if (SinglePropEnabled)
				{
					num ^= SinglePropEnabled.GetHashCode();
				}
				num ^= cues_.GetHashCode();
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
				items_.WriteTo(output, _repeated_items_codec);
				if (SinglePropEnabled)
				{
					output.WriteRawTag(32);
					output.WriteBool(SinglePropEnabled);
				}
				cues_.WriteTo(output, _repeated_cues_codec);
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
				num += items_.CalculateSize(_repeated_items_codec);
				if (SinglePropEnabled)
				{
					num += 2;
				}
				num += cues_.CalculateSize(_repeated_cues_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PropCollection other)
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
				items_.Add(other.items_);
				if (other.SinglePropEnabled)
				{
					SinglePropEnabled = other.SinglePropEnabled;
				}
				cues_.Add(other.cues_);
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
						items_.AddEntriesFrom(input, _repeated_items_codec);
						break;
					case 32u:
						SinglePropEnabled = input.ReadBool();
						break;
					case 42u:
						cues_.AddEntriesFrom(input, _repeated_cues_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<PropDocument> _parser = new MessageParser<PropDocument>(() => new PropDocument());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationInfoFieldNumber = 1;

	private ApplicationInfo applicationInfo_;

	public const int CuesFieldNumber = 2;

	private static readonly FieldCodec<Cue> _repeated_cues_codec = FieldCodec.ForMessage(18u, Cue.Parser);

	private readonly RepeatedField<Cue> cues_ = new RepeatedField<Cue>();

	public const int TransitionFieldNumber = 3;

	private Transition transition_;

	public const int PropCollectionsFieldNumber = 4;

	private static readonly FieldCodec<Types.PropCollection> _repeated_propCollections_codec = FieldCodec.ForMessage(34u, Types.PropCollection.Parser);

	private readonly RepeatedField<Types.PropCollection> propCollections_ = new RepeatedField<Types.PropCollection>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PropDocument> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PropDocumentReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationInfo ApplicationInfo
	{
		get
		{
			return applicationInfo_;
		}
		set
		{
			applicationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Cue> Cues => cues_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.PropCollection> PropCollections => propCollections_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropDocument()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropDocument(PropDocument other)
		: this()
	{
		applicationInfo_ = ((other.applicationInfo_ != null) ? other.applicationInfo_.Clone() : null);
		cues_ = other.cues_.Clone();
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		propCollections_ = other.propCollections_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropDocument Clone()
	{
		return new PropDocument(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PropDocument);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PropDocument other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ApplicationInfo, other.ApplicationInfo))
		{
			return false;
		}
		if (!cues_.Equals(other.cues_))
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
		{
			return false;
		}
		if (!propCollections_.Equals(other.propCollections_))
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
		if (applicationInfo_ != null)
		{
			num ^= ApplicationInfo.GetHashCode();
		}
		num ^= cues_.GetHashCode();
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
		}
		num ^= propCollections_.GetHashCode();
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
		if (applicationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ApplicationInfo);
		}
		cues_.WriteTo(output, _repeated_cues_codec);
		if (transition_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Transition);
		}
		propCollections_.WriteTo(output, _repeated_propCollections_codec);
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
		if (applicationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationInfo);
		}
		num += cues_.CalculateSize(_repeated_cues_codec);
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		num += propCollections_.CalculateSize(_repeated_propCollections_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PropDocument other)
	{
		if (other == null)
		{
			return;
		}
		if (other.applicationInfo_ != null)
		{
			if (applicationInfo_ == null)
			{
				ApplicationInfo = new ApplicationInfo();
			}
			ApplicationInfo.MergeFrom(other.ApplicationInfo);
		}
		cues_.Add(other.cues_);
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
		}
		propCollections_.Add(other.propCollections_);
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
				if (applicationInfo_ == null)
				{
					ApplicationInfo = new ApplicationInfo();
				}
				input.ReadMessage(ApplicationInfo);
				break;
			case 18u:
				cues_.AddEntriesFrom(input, _repeated_cues_codec);
				break;
			case 26u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			case 34u:
				propCollections_.AddEntriesFrom(input, _repeated_propCollections_codec);
				break;
			}
		}
	}
}
