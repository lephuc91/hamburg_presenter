using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.PPTImport;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PPTImportParams : IMessage<PPTImportParams>, IMessage, IEquatable<PPTImportParams>, IDeepCloneable<PPTImportParams>
{
	private static readonly MessageParser<PPTImportParams> _parser = new MessageParser<PPTImportParams>(() => new PPTImportParams());

	private UnknownFieldSet _unknownFields;

	public const int PptxPathFieldNumber = 1;

	private string pptxPath_ = "";

	public const int ResultFolderPathFieldNumber = 2;

	private string resultFolderPath_ = "";

	public const int SlideWidthFieldNumber = 3;

	private uint slideWidth_;

	public const int SlideHeightFieldNumber = 4;

	private uint slideHeight_;

	public const int IgnoreBackgroundsFieldNumber = 5;

	private bool ignoreBackgrounds_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PPTImportParams> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PptparamsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PptxPath
	{
		get
		{
			return pptxPath_;
		}
		set
		{
			pptxPath_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ResultFolderPath
	{
		get
		{
			return resultFolderPath_;
		}
		set
		{
			resultFolderPath_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint SlideWidth
	{
		get
		{
			return slideWidth_;
		}
		set
		{
			slideWidth_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint SlideHeight
	{
		get
		{
			return slideHeight_;
		}
		set
		{
			slideHeight_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IgnoreBackgrounds
	{
		get
		{
			return ignoreBackgrounds_;
		}
		set
		{
			ignoreBackgrounds_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PPTImportParams()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PPTImportParams(PPTImportParams other)
		: this()
	{
		pptxPath_ = other.pptxPath_;
		resultFolderPath_ = other.resultFolderPath_;
		slideWidth_ = other.slideWidth_;
		slideHeight_ = other.slideHeight_;
		ignoreBackgrounds_ = other.ignoreBackgrounds_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PPTImportParams Clone()
	{
		return new PPTImportParams(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PPTImportParams);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PPTImportParams other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (PptxPath != other.PptxPath)
		{
			return false;
		}
		if (ResultFolderPath != other.ResultFolderPath)
		{
			return false;
		}
		if (SlideWidth != other.SlideWidth)
		{
			return false;
		}
		if (SlideHeight != other.SlideHeight)
		{
			return false;
		}
		if (IgnoreBackgrounds != other.IgnoreBackgrounds)
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
		if (PptxPath.Length != 0)
		{
			num ^= PptxPath.GetHashCode();
		}
		if (ResultFolderPath.Length != 0)
		{
			num ^= ResultFolderPath.GetHashCode();
		}
		if (SlideWidth != 0)
		{
			num ^= SlideWidth.GetHashCode();
		}
		if (SlideHeight != 0)
		{
			num ^= SlideHeight.GetHashCode();
		}
		if (IgnoreBackgrounds)
		{
			num ^= IgnoreBackgrounds.GetHashCode();
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
		if (PptxPath.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(PptxPath);
		}
		if (ResultFolderPath.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(ResultFolderPath);
		}
		if (SlideWidth != 0)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(SlideWidth);
		}
		if (SlideHeight != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(SlideHeight);
		}
		if (IgnoreBackgrounds)
		{
			output.WriteRawTag(40);
			output.WriteBool(IgnoreBackgrounds);
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
		if (PptxPath.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PptxPath);
		}
		if (ResultFolderPath.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ResultFolderPath);
		}
		if (SlideWidth != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(SlideWidth);
		}
		if (SlideHeight != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(SlideHeight);
		}
		if (IgnoreBackgrounds)
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
	public void MergeFrom(PPTImportParams other)
	{
		if (other != null)
		{
			if (other.PptxPath.Length != 0)
			{
				PptxPath = other.PptxPath;
			}
			if (other.ResultFolderPath.Length != 0)
			{
				ResultFolderPath = other.ResultFolderPath;
			}
			if (other.SlideWidth != 0)
			{
				SlideWidth = other.SlideWidth;
			}
			if (other.SlideHeight != 0)
			{
				SlideHeight = other.SlideHeight;
			}
			if (other.IgnoreBackgrounds)
			{
				IgnoreBackgrounds = other.IgnoreBackgrounds;
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
			case 10u:
				PptxPath = input.ReadString();
				break;
			case 18u:
				ResultFolderPath = input.ReadString();
				break;
			case 24u:
				SlideWidth = input.ReadUInt32();
				break;
			case 32u:
				SlideHeight = input.ReadUInt32();
				break;
			case 40u:
				IgnoreBackgrounds = input.ReadBool();
				break;
			}
		}
	}
}
