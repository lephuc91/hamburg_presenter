using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.MultiTracks;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Import : IMessage<Import>, IMessage, IEquatable<Import>, IDeepCloneable<Import>
{
	private static readonly MessageParser<Import> _parser = new MessageParser<Import>(() => new Import());

	private UnknownFieldSet _unknownFields;

	public const int ChartProFieldNumber = 1;

	private Status chartPro_;

	public const int PropresenterAddonFieldNumber = 2;

	private Status propresenterAddon_;

	public const int ChartsAutomationFieldNumber = 3;

	private bool chartsAutomation_;

	public const int LinesFieldNumber = 4;

	private int lines_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Import> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsMultiTracksReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Status ChartPro
	{
		get
		{
			return chartPro_;
		}
		set
		{
			chartPro_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Status PropresenterAddon
	{
		get
		{
			return propresenterAddon_;
		}
		set
		{
			propresenterAddon_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ChartsAutomation
	{
		get
		{
			return chartsAutomation_;
		}
		set
		{
			chartsAutomation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Lines
	{
		get
		{
			return lines_;
		}
		set
		{
			lines_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Import()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Import(Import other)
		: this()
	{
		chartPro_ = other.chartPro_;
		propresenterAddon_ = other.propresenterAddon_;
		chartsAutomation_ = other.chartsAutomation_;
		lines_ = other.lines_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Import Clone()
	{
		return new Import(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Import);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Import other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ChartPro != other.ChartPro)
		{
			return false;
		}
		if (PropresenterAddon != other.PropresenterAddon)
		{
			return false;
		}
		if (ChartsAutomation != other.ChartsAutomation)
		{
			return false;
		}
		if (Lines != other.Lines)
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
		if (ChartPro != 0)
		{
			num ^= ChartPro.GetHashCode();
		}
		if (PropresenterAddon != 0)
		{
			num ^= PropresenterAddon.GetHashCode();
		}
		if (ChartsAutomation)
		{
			num ^= ChartsAutomation.GetHashCode();
		}
		if (Lines != 0)
		{
			num ^= Lines.GetHashCode();
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
		if (ChartPro != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ChartPro);
		}
		if (PropresenterAddon != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)PropresenterAddon);
		}
		if (ChartsAutomation)
		{
			output.WriteRawTag(24);
			output.WriteBool(ChartsAutomation);
		}
		if (Lines != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(Lines);
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
		if (ChartPro != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ChartPro);
		}
		if (PropresenterAddon != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)PropresenterAddon);
		}
		if (ChartsAutomation)
		{
			num += 2;
		}
		if (Lines != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Lines);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Import other)
	{
		if (other != null)
		{
			if (other.ChartPro != 0)
			{
				ChartPro = other.ChartPro;
			}
			if (other.PropresenterAddon != 0)
			{
				PropresenterAddon = other.PropresenterAddon;
			}
			if (other.ChartsAutomation)
			{
				ChartsAutomation = other.ChartsAutomation;
			}
			if (other.Lines != 0)
			{
				Lines = other.Lines;
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
				ChartPro = (Status)input.ReadEnum();
				break;
			case 16u:
				PropresenterAddon = (Status)input.ReadEnum();
				break;
			case 24u:
				ChartsAutomation = input.ReadBool();
				break;
			case 32u:
				Lines = input.ReadInt32();
				break;
			}
		}
	}
}
