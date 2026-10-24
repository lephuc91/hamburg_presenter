using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class WindowedOutputCreated : IMessage<WindowedOutputCreated>, IMessage, IEquatable<WindowedOutputCreated>, IDeepCloneable<WindowedOutputCreated>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ScreenType
		{
			[OriginalName("AUDIENCE")]
			Audience,
			[OriginalName("STAGE")]
			Stage
		}
	}

	private static readonly MessageParser<WindowedOutputCreated> _parser = new MessageParser<WindowedOutputCreated>(() => new WindowedOutputCreated());

	private UnknownFieldSet _unknownFields;

	public const int ScreenTypeFieldNumber = 1;

	private Types.ScreenType screenType_;

	public const int NumActiveWindowedOutputsFieldNumber = 2;

	private int numActiveWindowedOutputs_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<WindowedOutputCreated> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[87];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ScreenType ScreenType
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
	public int NumActiveWindowedOutputs
	{
		get
		{
			return numActiveWindowedOutputs_;
		}
		set
		{
			numActiveWindowedOutputs_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WindowedOutputCreated()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WindowedOutputCreated(WindowedOutputCreated other)
		: this()
	{
		screenType_ = other.screenType_;
		numActiveWindowedOutputs_ = other.numActiveWindowedOutputs_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WindowedOutputCreated Clone()
	{
		return new WindowedOutputCreated(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as WindowedOutputCreated);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(WindowedOutputCreated other)
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
		if (NumActiveWindowedOutputs != other.NumActiveWindowedOutputs)
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
		if (NumActiveWindowedOutputs != 0)
		{
			num ^= NumActiveWindowedOutputs.GetHashCode();
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
		if (NumActiveWindowedOutputs != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(NumActiveWindowedOutputs);
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
		if (NumActiveWindowedOutputs != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(NumActiveWindowedOutputs);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(WindowedOutputCreated other)
	{
		if (other != null)
		{
			if (other.ScreenType != 0)
			{
				ScreenType = other.ScreenType;
			}
			if (other.NumActiveWindowedOutputs != 0)
			{
				NumActiveWindowedOutputs = other.NumActiveWindowedOutputs;
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
				ScreenType = (Types.ScreenType)input.ReadEnum();
				break;
			case 16u:
				NumActiveWindowedOutputs = input.ReadInt32();
				break;
			}
		}
	}
}
