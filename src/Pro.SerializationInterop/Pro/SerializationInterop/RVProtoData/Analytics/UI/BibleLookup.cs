using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class BibleLookup : IMessage<BibleLookup>, IMessage, IEquatable<BibleLookup>, IDeepCloneable<BibleLookup>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Location
		{
			[OriginalName("LOCATION_UNKNOWN")]
			Unknown,
			[OriginalName("TEXT_REFERENCE")]
			TextReference,
			[OriginalName("MENU_BOOK")]
			MenuBook,
			[OriginalName("MENU_CHAPTER")]
			MenuChapter,
			[OriginalName("MENU_VERSE")]
			MenuVerse,
			[OriginalName("TEXT_SEARCH_CHAPTER")]
			TextSearchChapter,
			[OriginalName("TEXT_SEARCH_VERSE")]
			TextSearchVerse
		}
	}

	private static readonly MessageParser<BibleLookup> _parser = new MessageParser<BibleLookup>(() => new BibleLookup());

	private UnknownFieldSet _unknownFields;

	public const int LocationFieldNumber = 1;

	private Types.Location location_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<BibleLookup> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[14];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Location Location
	{
		get
		{
			return location_;
		}
		set
		{
			location_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleLookup()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleLookup(BibleLookup other)
		: this()
	{
		location_ = other.location_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleLookup Clone()
	{
		return new BibleLookup(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as BibleLookup);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(BibleLookup other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Location != other.Location)
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
		if (Location != 0)
		{
			num ^= Location.GetHashCode();
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
		if (Location != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Location);
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
		if (Location != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Location);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(BibleLookup other)
	{
		if (other != null)
		{
			if (other.Location != 0)
			{
				Location = other.Location;
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
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				Location = (Types.Location)input.ReadEnum();
			}
		}
	}
}
