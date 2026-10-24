using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Transition : IMessage<Transition>, IMessage, IEquatable<Transition>, IDeepCloneable<Transition>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Preset : IMessage<Preset>, IMessage, IEquatable<Preset>, IDeepCloneable<Preset>
		{
			private static readonly MessageParser<Preset> _parser = new MessageParser<Preset>(() => new Preset());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private UUID uuid_;

			public const int NameFieldNumber = 2;

			private string name_ = "";

			public const int TransitionFieldNumber = 3;

			private Transition transition_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Preset> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => Transition.Descriptor.NestedTypes[0];

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
			public Preset()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset(Preset other)
				: this()
			{
				uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
				name_ = other.name_;
				transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Preset Clone()
			{
				return new Preset(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Preset);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Preset other)
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
				if (!object.Equals(Transition, other.Transition))
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
				if (transition_ != null)
				{
					num ^= Transition.GetHashCode();
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
				if (transition_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Transition);
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
				if (uuid_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (transition_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Preset other)
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
				if (other.transition_ != null)
				{
					if (transition_ == null)
					{
						Transition = new Transition();
					}
					Transition.MergeFrom(other.Transition);
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
						if (transition_ == null)
						{
							Transition = new Transition();
						}
						input.ReadMessage(Transition);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<Transition> _parser = new MessageParser<Transition>(() => new Transition());

	private UnknownFieldSet _unknownFields;

	public const int DurationFieldNumber = 1;

	private double duration_;

	public const int FavoriteUuidFieldNumber = 2;

	private UUID favoriteUuid_;

	public const int EffectFieldNumber = 3;

	private Effect effect_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Transition> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => EffectsReflection.Descriptor.MessageTypes[1];

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
	public UUID FavoriteUuid
	{
		get
		{
			return favoriteUuid_;
		}
		set
		{
			favoriteUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Effect Effect
	{
		get
		{
			return effect_;
		}
		set
		{
			effect_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition(Transition other)
		: this()
	{
		duration_ = other.duration_;
		favoriteUuid_ = ((other.favoriteUuid_ != null) ? other.favoriteUuid_.Clone() : null);
		effect_ = ((other.effect_ != null) ? other.effect_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition Clone()
	{
		return new Transition(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Transition);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Transition other)
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
		if (!object.Equals(FavoriteUuid, other.FavoriteUuid))
		{
			return false;
		}
		if (!object.Equals(Effect, other.Effect))
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
		if (favoriteUuid_ != null)
		{
			num ^= FavoriteUuid.GetHashCode();
		}
		if (effect_ != null)
		{
			num ^= Effect.GetHashCode();
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
		if (favoriteUuid_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(FavoriteUuid);
		}
		if (effect_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Effect);
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
		if (favoriteUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FavoriteUuid);
		}
		if (effect_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Effect);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Transition other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Duration != 0.0)
		{
			Duration = other.Duration;
		}
		if (other.favoriteUuid_ != null)
		{
			if (favoriteUuid_ == null)
			{
				FavoriteUuid = new UUID();
			}
			FavoriteUuid.MergeFrom(other.FavoriteUuid);
		}
		if (other.effect_ != null)
		{
			if (effect_ == null)
			{
				Effect = new Effect();
			}
			Effect.MergeFrom(other.Effect);
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
			case 9u:
				Duration = input.ReadDouble();
				break;
			case 18u:
				if (favoriteUuid_ == null)
				{
					FavoriteUuid = new UUID();
				}
				input.ReadMessage(FavoriteUuid);
				break;
			case 26u:
				if (effect_ == null)
				{
					Effect = new Effect();
				}
				input.ReadMessage(Effect);
				break;
			}
		}
	}
}
