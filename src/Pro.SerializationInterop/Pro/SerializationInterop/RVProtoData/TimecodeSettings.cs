using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TimecodeSettings : IMessage<TimecodeSettings>, IMessage, IEquatable<TimecodeSettings>, IDeepCloneable<TimecodeSettings>
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

	private static readonly MessageParser<TimecodeSettings> _parser = new MessageParser<TimecodeSettings>(() => new TimecodeSettings());

	private UnknownFieldSet _unknownFields;

	public const int DeviceIdentifierFieldNumber = 1;

	private string deviceIdentifier_ = "";

	public const int ChannelFieldNumber = 2;

	private int channel_;

	public const int FormatFieldNumber = 3;

	private Types.Format format_;

	public const int OffsetFieldNumber = 4;

	private double offset_;

	public const int PlaylistIdentifierFieldNumber = 5;

	private UUID playlistIdentifier_;

	public const int IsActiveFieldNumber = 6;

	private bool isActive_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TimecodeSettings> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TimecodeReflection.Descriptor.MessageTypes[0];

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
	public UUID PlaylistIdentifier
	{
		get
		{
			return playlistIdentifier_;
		}
		set
		{
			playlistIdentifier_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsActive
	{
		get
		{
			return isActive_;
		}
		set
		{
			isActive_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimecodeSettings()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimecodeSettings(TimecodeSettings other)
		: this()
	{
		deviceIdentifier_ = other.deviceIdentifier_;
		channel_ = other.channel_;
		format_ = other.format_;
		offset_ = other.offset_;
		playlistIdentifier_ = ((other.playlistIdentifier_ != null) ? other.playlistIdentifier_.Clone() : null);
		isActive_ = other.isActive_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimecodeSettings Clone()
	{
		return new TimecodeSettings(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TimecodeSettings);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TimecodeSettings other)
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
		if (!object.Equals(PlaylistIdentifier, other.PlaylistIdentifier))
		{
			return false;
		}
		if (IsActive != other.IsActive)
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
		if (playlistIdentifier_ != null)
		{
			num ^= PlaylistIdentifier.GetHashCode();
		}
		if (IsActive)
		{
			num ^= IsActive.GetHashCode();
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
		if (playlistIdentifier_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(PlaylistIdentifier);
		}
		if (IsActive)
		{
			output.WriteRawTag(48);
			output.WriteBool(IsActive);
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
		if (playlistIdentifier_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistIdentifier);
		}
		if (IsActive)
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
	public void MergeFrom(TimecodeSettings other)
	{
		if (other == null)
		{
			return;
		}
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
		if (other.playlistIdentifier_ != null)
		{
			if (playlistIdentifier_ == null)
			{
				PlaylistIdentifier = new UUID();
			}
			PlaylistIdentifier.MergeFrom(other.PlaylistIdentifier);
		}
		if (other.IsActive)
		{
			IsActive = other.IsActive;
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
			case 42u:
				if (playlistIdentifier_ == null)
				{
					PlaylistIdentifier = new UUID();
				}
				input.ReadMessage(PlaylistIdentifier);
				break;
			case 48u:
				IsActive = input.ReadBool();
				break;
			}
		}
	}
}
