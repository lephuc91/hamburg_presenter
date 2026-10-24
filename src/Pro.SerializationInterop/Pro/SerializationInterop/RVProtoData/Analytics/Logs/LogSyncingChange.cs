using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LogSyncingChange : IMessage<LogSyncingChange>, IMessage, IEquatable<LogSyncingChange>, IDeepCloneable<LogSyncingChange>
{
	private static readonly MessageParser<LogSyncingChange> _parser = new MessageParser<LogSyncingChange>(() => new LogSyncingChange());

	private UnknownFieldSet _unknownFields;

	public const int PausedFieldNumber = 1;

	private PauseState paused_;

	public const int OnlineFieldNumber = 2;

	private bool online_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LogSyncingChange> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsLogsReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseState Paused
	{
		get
		{
			return paused_;
		}
		set
		{
			paused_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Online
	{
		get
		{
			return online_;
		}
		set
		{
			online_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogSyncingChange()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogSyncingChange(LogSyncingChange other)
		: this()
	{
		paused_ = ((other.paused_ != null) ? other.paused_.Clone() : null);
		online_ = other.online_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LogSyncingChange Clone()
	{
		return new LogSyncingChange(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LogSyncingChange);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LogSyncingChange other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Paused, other.Paused))
		{
			return false;
		}
		if (Online != other.Online)
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
		if (paused_ != null)
		{
			num ^= Paused.GetHashCode();
		}
		if (Online)
		{
			num ^= Online.GetHashCode();
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
		if (paused_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Paused);
		}
		if (Online)
		{
			output.WriteRawTag(16);
			output.WriteBool(Online);
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
		if (paused_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Paused);
		}
		if (Online)
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
	public void MergeFrom(LogSyncingChange other)
	{
		if (other == null)
		{
			return;
		}
		if (other.paused_ != null)
		{
			if (paused_ == null)
			{
				Paused = new PauseState();
			}
			Paused.MergeFrom(other.Paused);
		}
		if (other.Online)
		{
			Online = other.Online;
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
				if (paused_ == null)
				{
					Paused = new PauseState();
				}
				input.ReadMessage(Paused);
				break;
			case 16u:
				Online = input.ReadBool();
				break;
			}
		}
	}
}
