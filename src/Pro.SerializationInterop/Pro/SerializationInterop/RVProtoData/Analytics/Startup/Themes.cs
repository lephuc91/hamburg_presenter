using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Themes : IMessage<Themes>, IMessage, IEquatable<Themes>, IDeepCloneable<Themes>
{
	private static readonly MessageParser<Themes> _parser = new MessageParser<Themes>(() => new Themes());

	private UnknownFieldSet _unknownFields;

	public const int ThemeCountFieldNumber = 1;

	private int themeCount_;

	public const int ThemeFolderCountFieldNumber = 2;

	private int themeFolderCount_;

	public const int ThemeFolderMaxDepthFieldNumber = 3;

	private int themeFolderMaxDepth_;

	public const int ThemeSlidesCountFieldNumber = 4;

	private int themeSlidesCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Themes> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[11];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ThemeCount
	{
		get
		{
			return themeCount_;
		}
		set
		{
			themeCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ThemeFolderCount
	{
		get
		{
			return themeFolderCount_;
		}
		set
		{
			themeFolderCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ThemeFolderMaxDepth
	{
		get
		{
			return themeFolderMaxDepth_;
		}
		set
		{
			themeFolderMaxDepth_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ThemeSlidesCount
	{
		get
		{
			return themeSlidesCount_;
		}
		set
		{
			themeSlidesCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Themes()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Themes(Themes other)
		: this()
	{
		themeCount_ = other.themeCount_;
		themeFolderCount_ = other.themeFolderCount_;
		themeFolderMaxDepth_ = other.themeFolderMaxDepth_;
		themeSlidesCount_ = other.themeSlidesCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Themes Clone()
	{
		return new Themes(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Themes);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Themes other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ThemeCount != other.ThemeCount)
		{
			return false;
		}
		if (ThemeFolderCount != other.ThemeFolderCount)
		{
			return false;
		}
		if (ThemeFolderMaxDepth != other.ThemeFolderMaxDepth)
		{
			return false;
		}
		if (ThemeSlidesCount != other.ThemeSlidesCount)
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
		if (ThemeCount != 0)
		{
			num ^= ThemeCount.GetHashCode();
		}
		if (ThemeFolderCount != 0)
		{
			num ^= ThemeFolderCount.GetHashCode();
		}
		if (ThemeFolderMaxDepth != 0)
		{
			num ^= ThemeFolderMaxDepth.GetHashCode();
		}
		if (ThemeSlidesCount != 0)
		{
			num ^= ThemeSlidesCount.GetHashCode();
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
		if (ThemeCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(ThemeCount);
		}
		if (ThemeFolderCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(ThemeFolderCount);
		}
		if (ThemeFolderMaxDepth != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(ThemeFolderMaxDepth);
		}
		if (ThemeSlidesCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(ThemeSlidesCount);
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
		if (ThemeCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ThemeCount);
		}
		if (ThemeFolderCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ThemeFolderCount);
		}
		if (ThemeFolderMaxDepth != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ThemeFolderMaxDepth);
		}
		if (ThemeSlidesCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ThemeSlidesCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Themes other)
	{
		if (other != null)
		{
			if (other.ThemeCount != 0)
			{
				ThemeCount = other.ThemeCount;
			}
			if (other.ThemeFolderCount != 0)
			{
				ThemeFolderCount = other.ThemeFolderCount;
			}
			if (other.ThemeFolderMaxDepth != 0)
			{
				ThemeFolderMaxDepth = other.ThemeFolderMaxDepth;
			}
			if (other.ThemeSlidesCount != 0)
			{
				ThemeSlidesCount = other.ThemeSlidesCount;
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
				ThemeCount = input.ReadInt32();
				break;
			case 16u:
				ThemeFolderCount = input.ReadInt32();
				break;
			case 24u:
				ThemeFolderMaxDepth = input.ReadInt32();
				break;
			case 32u:
				ThemeSlidesCount = input.ReadInt32();
				break;
			}
		}
	}
}
