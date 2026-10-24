using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SongSelect : IMessage<SongSelect>, IMessage, IEquatable<SongSelect>, IDeepCloneable<SongSelect>
{
	private static readonly MessageParser<SongSelect> _parser = new MessageParser<SongSelect>(() => new SongSelect());

	private UnknownFieldSet _unknownFields;

	public const int LoggedInFieldNumber = 1;

	private bool loggedIn_;

	public const int AutoReportingEnabledFieldNumber = 2;

	private bool autoReportingEnabled_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SongSelect> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[9];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LoggedIn
	{
		get
		{
			return loggedIn_;
		}
		set
		{
			loggedIn_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool AutoReportingEnabled
	{
		get
		{
			return autoReportingEnabled_;
		}
		set
		{
			autoReportingEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SongSelect()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SongSelect(SongSelect other)
		: this()
	{
		loggedIn_ = other.loggedIn_;
		autoReportingEnabled_ = other.autoReportingEnabled_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SongSelect Clone()
	{
		return new SongSelect(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SongSelect);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SongSelect other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (LoggedIn != other.LoggedIn)
		{
			return false;
		}
		if (AutoReportingEnabled != other.AutoReportingEnabled)
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
		if (LoggedIn)
		{
			num ^= LoggedIn.GetHashCode();
		}
		if (AutoReportingEnabled)
		{
			num ^= AutoReportingEnabled.GetHashCode();
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
		if (LoggedIn)
		{
			output.WriteRawTag(8);
			output.WriteBool(LoggedIn);
		}
		if (AutoReportingEnabled)
		{
			output.WriteRawTag(16);
			output.WriteBool(AutoReportingEnabled);
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
		if (LoggedIn)
		{
			num += 2;
		}
		if (AutoReportingEnabled)
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
	public void MergeFrom(SongSelect other)
	{
		if (other != null)
		{
			if (other.LoggedIn)
			{
				LoggedIn = other.LoggedIn;
			}
			if (other.AutoReportingEnabled)
			{
				AutoReportingEnabled = other.AutoReportingEnabled;
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
				LoggedIn = input.ReadBool();
				break;
			case 16u:
				AutoReportingEnabled = input.ReadBool();
				break;
			}
		}
	}
}
