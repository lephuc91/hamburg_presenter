using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LiveVideoPlaylist : IMessage<LiveVideoPlaylist>, IMessage, IEquatable<LiveVideoPlaylist>, IDeepCloneable<LiveVideoPlaylist>
{
	private static readonly MessageParser<LiveVideoPlaylist> _parser = new MessageParser<LiveVideoPlaylist>(() => new LiveVideoPlaylist());

	private UnknownFieldSet _unknownFields;

	public const int ActionsFieldNumber = 1;

	private static readonly FieldCodec<Action> _repeated_actions_codec = FieldCodec.ForMessage(10u, Action.Parser);

	private readonly RepeatedField<Action> actions_ = new RepeatedField<Action>();

	public const int TargetedLayerUUIDFieldNumber = 2;

	private UUID targetedLayerUUID_;

	public const int UuidFieldNumber = 3;

	private UUID uuid_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LiveVideoPlaylist> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => LiveVideoPlaylistReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Action> Actions => actions_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID TargetedLayerUUID
	{
		get
		{
			return targetedLayerUUID_;
		}
		set
		{
			targetedLayerUUID_ = value;
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
	public LiveVideoPlaylist()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LiveVideoPlaylist(LiveVideoPlaylist other)
		: this()
	{
		actions_ = other.actions_.Clone();
		targetedLayerUUID_ = ((other.targetedLayerUUID_ != null) ? other.targetedLayerUUID_.Clone() : null);
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LiveVideoPlaylist Clone()
	{
		return new LiveVideoPlaylist(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LiveVideoPlaylist);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LiveVideoPlaylist other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!actions_.Equals(other.actions_))
		{
			return false;
		}
		if (!object.Equals(TargetedLayerUUID, other.TargetedLayerUUID))
		{
			return false;
		}
		if (!object.Equals(Uuid, other.Uuid))
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
		num ^= actions_.GetHashCode();
		if (targetedLayerUUID_ != null)
		{
			num ^= TargetedLayerUUID.GetHashCode();
		}
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
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
		actions_.WriteTo(output, _repeated_actions_codec);
		if (targetedLayerUUID_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(TargetedLayerUUID);
		}
		if (uuid_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Uuid);
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
		num += actions_.CalculateSize(_repeated_actions_codec);
		if (targetedLayerUUID_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TargetedLayerUUID);
		}
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LiveVideoPlaylist other)
	{
		if (other == null)
		{
			return;
		}
		actions_.Add(other.actions_);
		if (other.targetedLayerUUID_ != null)
		{
			if (targetedLayerUUID_ == null)
			{
				TargetedLayerUUID = new UUID();
			}
			TargetedLayerUUID.MergeFrom(other.TargetedLayerUUID);
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
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
				actions_.AddEntriesFrom(input, _repeated_actions_codec);
				break;
			case 18u:
				if (targetedLayerUUID_ == null)
				{
					TargetedLayerUUID = new UUID();
				}
				input.ReadMessage(TargetedLayerUUID);
				break;
			case 26u:
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			}
		}
	}
}
