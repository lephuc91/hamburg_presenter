using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Timecode;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Activate : IMessage<Activate>, IMessage, IEquatable<Activate>, IDeepCloneable<Activate>
{
	private static readonly MessageParser<Activate> _parser = new MessageParser<Activate>(() => new Activate());

	private UnknownFieldSet _unknownFields;

	public const int PlaylistItemCountFieldNumber = 1;

	private int playlistItemCount_;

	public const int CueCountFieldNumber = 2;

	private int cueCount_;

	public const int IsStartupFieldNumber = 3;

	private bool isStartup_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Activate> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTimecodeReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PlaylistItemCount
	{
		get
		{
			return playlistItemCount_;
		}
		set
		{
			playlistItemCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CueCount
	{
		get
		{
			return cueCount_;
		}
		set
		{
			cueCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsStartup
	{
		get
		{
			return isStartup_;
		}
		set
		{
			isStartup_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Activate()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Activate(Activate other)
		: this()
	{
		playlistItemCount_ = other.playlistItemCount_;
		cueCount_ = other.cueCount_;
		isStartup_ = other.isStartup_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Activate Clone()
	{
		return new Activate(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Activate);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Activate other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PlaylistItemCount != other.PlaylistItemCount)
		{
			return false;
		}
		if (CueCount != other.CueCount)
		{
			return false;
		}
		if (IsStartup != other.IsStartup)
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
		if (PlaylistItemCount != 0)
		{
			num ^= PlaylistItemCount.GetHashCode();
		}
		if (CueCount != 0)
		{
			num ^= CueCount.GetHashCode();
		}
		if (IsStartup)
		{
			num ^= IsStartup.GetHashCode();
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
		if (PlaylistItemCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(PlaylistItemCount);
		}
		if (CueCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(CueCount);
		}
		if (IsStartup)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsStartup);
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
		if (PlaylistItemCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(PlaylistItemCount);
		}
		if (CueCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(CueCount);
		}
		if (IsStartup)
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
	public void MergeFrom(Activate other)
	{
		if (other != null)
		{
			if (other.PlaylistItemCount != 0)
			{
				PlaylistItemCount = other.PlaylistItemCount;
			}
			if (other.CueCount != 0)
			{
				CueCount = other.CueCount;
			}
			if (other.IsStartup)
			{
				IsStartup = other.IsStartup;
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
				PlaylistItemCount = input.ReadInt32();
				break;
			case 16u:
				CueCount = input.ReadInt32();
				break;
			case 24u:
				IsStartup = input.ReadBool();
				break;
			}
		}
	}
}
