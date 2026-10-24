using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class FontReplacement : IMessage<FontReplacement>, IMessage, IEquatable<FontReplacement>, IDeepCloneable<FontReplacement>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Source
		{
			[OriginalName("IMPORT")]
			Import,
			[OriginalName("BANNER")]
			Banner
		}
	}

	private static readonly MessageParser<FontReplacement> _parser = new MessageParser<FontReplacement>(() => new FontReplacement());

	private UnknownFieldSet _unknownFields;

	public const int SourceFieldNumber = 1;

	private Types.Source source_;

	public const int MissingFontFieldNumber = 2;

	private string missingFont_ = "";

	public const int ReplacementFontFieldNumber = 3;

	private string replacementFont_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<FontReplacement> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[34];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Source Source
	{
		get
		{
			return source_;
		}
		set
		{
			source_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MissingFont
	{
		get
		{
			return missingFont_;
		}
		set
		{
			missingFont_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ReplacementFont
	{
		get
		{
			return replacementFont_;
		}
		set
		{
			replacementFont_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FontReplacement()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FontReplacement(FontReplacement other)
		: this()
	{
		source_ = other.source_;
		missingFont_ = other.missingFont_;
		replacementFont_ = other.replacementFont_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FontReplacement Clone()
	{
		return new FontReplacement(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as FontReplacement);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(FontReplacement other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Source != other.Source)
		{
			return false;
		}
		if (MissingFont != other.MissingFont)
		{
			return false;
		}
		if (ReplacementFont != other.ReplacementFont)
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
		if (Source != 0)
		{
			num ^= Source.GetHashCode();
		}
		if (MissingFont.Length != 0)
		{
			num ^= MissingFont.GetHashCode();
		}
		if (ReplacementFont.Length != 0)
		{
			num ^= ReplacementFont.GetHashCode();
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
		if (Source != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Source);
		}
		if (MissingFont.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(MissingFont);
		}
		if (ReplacementFont.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ReplacementFont);
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
		if (Source != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Source);
		}
		if (MissingFont.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(MissingFont);
		}
		if (ReplacementFont.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ReplacementFont);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(FontReplacement other)
	{
		if (other != null)
		{
			if (other.Source != 0)
			{
				Source = other.Source;
			}
			if (other.MissingFont.Length != 0)
			{
				MissingFont = other.MissingFont;
			}
			if (other.ReplacementFont.Length != 0)
			{
				ReplacementFont = other.ReplacementFont;
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
				Source = (Types.Source)input.ReadEnum();
				break;
			case 18u:
				MissingFont = input.ReadString();
				break;
			case 26u:
				ReplacementFont = input.ReadString();
				break;
			}
		}
	}
}
