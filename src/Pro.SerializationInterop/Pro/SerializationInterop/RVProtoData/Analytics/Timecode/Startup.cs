using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Timecode;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Startup : IMessage<Startup>, IMessage, IEquatable<Startup>, IDeepCloneable<Startup>
{
	private static readonly MessageParser<Startup> _parser = new MessageParser<Startup>(() => new Startup());

	private UnknownFieldSet _unknownFields;

	public const int IsInputConfiguredFieldNumber = 1;

	private bool isInputConfigured_;

	public const int IsEnabledFieldNumber = 2;

	private bool isEnabled_;

	public const int IsPlaylistSelectedFieldNumber = 3;

	private bool isPlaylistSelected_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Startup> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTimecodeReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsInputConfigured
	{
		get
		{
			return isInputConfigured_;
		}
		set
		{
			isInputConfigured_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsEnabled
	{
		get
		{
			return isEnabled_;
		}
		set
		{
			isEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsPlaylistSelected
	{
		get
		{
			return isPlaylistSelected_;
		}
		set
		{
			isPlaylistSelected_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Startup()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Startup(Startup other)
		: this()
	{
		isInputConfigured_ = other.isInputConfigured_;
		isEnabled_ = other.isEnabled_;
		isPlaylistSelected_ = other.isPlaylistSelected_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Startup Clone()
	{
		return new Startup(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Startup);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Startup other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (IsInputConfigured != other.IsInputConfigured)
		{
			return false;
		}
		if (IsEnabled != other.IsEnabled)
		{
			return false;
		}
		if (IsPlaylistSelected != other.IsPlaylistSelected)
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
		if (IsInputConfigured)
		{
			num ^= IsInputConfigured.GetHashCode();
		}
		if (IsEnabled)
		{
			num ^= IsEnabled.GetHashCode();
		}
		if (IsPlaylistSelected)
		{
			num ^= IsPlaylistSelected.GetHashCode();
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
		if (IsInputConfigured)
		{
			output.WriteRawTag(8);
			output.WriteBool(IsInputConfigured);
		}
		if (IsEnabled)
		{
			output.WriteRawTag(16);
			output.WriteBool(IsEnabled);
		}
		if (IsPlaylistSelected)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsPlaylistSelected);
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
		if (IsInputConfigured)
		{
			num += 2;
		}
		if (IsEnabled)
		{
			num += 2;
		}
		if (IsPlaylistSelected)
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
	public void MergeFrom(Startup other)
	{
		if (other != null)
		{
			if (other.IsInputConfigured)
			{
				IsInputConfigured = other.IsInputConfigured;
			}
			if (other.IsEnabled)
			{
				IsEnabled = other.IsEnabled;
			}
			if (other.IsPlaylistSelected)
			{
				IsPlaylistSelected = other.IsPlaylistSelected;
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
				IsInputConfigured = input.ReadBool();
				break;
			case 16u:
				IsEnabled = input.ReadBool();
				break;
			case 24u:
				IsPlaylistSelected = input.ReadBool();
				break;
			}
		}
	}
}
