using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class EdgeBlend : IMessage<EdgeBlend>, IMessage, IEquatable<EdgeBlend>, IDeepCloneable<EdgeBlend>
{
	private static readonly MessageParser<EdgeBlend> _parser = new MessageParser<EdgeBlend>(() => new EdgeBlend());

	private UnknownFieldSet _unknownFields;

	public const int ScreenTypeFieldNumber = 1;

	private ScreenType screenType_;

	public const int ScreenColorEnabledFieldNumber = 2;

	private bool screenColorEnabled_;

	public const int CountFieldNumber = 3;

	private int count_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<EdgeBlend> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ScreenType ScreenType
	{
		get
		{
			return screenType_;
		}
		set
		{
			screenType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ScreenColorEnabled
	{
		get
		{
			return screenColorEnabled_;
		}
		set
		{
			screenColorEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Count
	{
		get
		{
			return count_;
		}
		set
		{
			count_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EdgeBlend()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EdgeBlend(EdgeBlend other)
		: this()
	{
		screenType_ = other.screenType_;
		screenColorEnabled_ = other.screenColorEnabled_;
		count_ = other.count_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EdgeBlend Clone()
	{
		return new EdgeBlend(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as EdgeBlend);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(EdgeBlend other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ScreenType != other.ScreenType)
		{
			return false;
		}
		if (ScreenColorEnabled != other.ScreenColorEnabled)
		{
			return false;
		}
		if (Count != other.Count)
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
		if (ScreenType != 0)
		{
			num ^= ScreenType.GetHashCode();
		}
		if (ScreenColorEnabled)
		{
			num ^= ScreenColorEnabled.GetHashCode();
		}
		if (Count != 0)
		{
			num ^= Count.GetHashCode();
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
		if (ScreenType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ScreenType);
		}
		if (ScreenColorEnabled)
		{
			output.WriteRawTag(16);
			output.WriteBool(ScreenColorEnabled);
		}
		if (Count != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(Count);
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
		if (ScreenType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ScreenType);
		}
		if (ScreenColorEnabled)
		{
			num += 2;
		}
		if (Count != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Count);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(EdgeBlend other)
	{
		if (other != null)
		{
			if (other.ScreenType != 0)
			{
				ScreenType = other.ScreenType;
			}
			if (other.ScreenColorEnabled)
			{
				ScreenColorEnabled = other.ScreenColorEnabled;
			}
			if (other.Count != 0)
			{
				Count = other.Count;
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
				ScreenType = (ScreenType)input.ReadEnum();
				break;
			case 16u:
				ScreenColorEnabled = input.ReadBool();
				break;
			case 24u:
				Count = input.ReadInt32();
				break;
			}
		}
	}
}
