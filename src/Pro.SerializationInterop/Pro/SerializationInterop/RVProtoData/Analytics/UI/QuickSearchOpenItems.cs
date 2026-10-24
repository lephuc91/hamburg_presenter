using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class QuickSearchOpenItems : IMessage<QuickSearchOpenItems>, IMessage, IEquatable<QuickSearchOpenItems>, IDeepCloneable<QuickSearchOpenItems>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Source
		{
			[OriginalName("SOURCE_UNKNOWN")]
			Unknown,
			[OriginalName("LIBRARY")]
			Library,
			[OriginalName("SONG_SELECT")]
			SongSelect,
			[OriginalName("MULTI_TRACKS")]
			MultiTracks
		}

		public enum Style
		{
			[OriginalName("STYLE_UNKNOWN")]
			Unknown,
			[OriginalName("STYLE_RETURN_KEY")]
			ReturnKey,
			[OriginalName("COMMAND_RETURN_KEY")]
			CommandReturnKey,
			[OriginalName("DRAG_DROP")]
			DragDrop
		}
	}

	private static readonly MessageParser<QuickSearchOpenItems> _parser = new MessageParser<QuickSearchOpenItems>(() => new QuickSearchOpenItems());

	private UnknownFieldSet _unknownFields;

	public const int SourceFieldNumber = 1;

	private Types.Source source_;

	public const int StyleFieldNumber = 2;

	private Types.Style style_;

	public const int CountFieldNumber = 3;

	private int count_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<QuickSearchOpenItems> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[2];

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
	public Types.Style Style
	{
		get
		{
			return style_;
		}
		set
		{
			style_ = value;
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
	public QuickSearchOpenItems()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public QuickSearchOpenItems(QuickSearchOpenItems other)
		: this()
	{
		source_ = other.source_;
		style_ = other.style_;
		count_ = other.count_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public QuickSearchOpenItems Clone()
	{
		return new QuickSearchOpenItems(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as QuickSearchOpenItems);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(QuickSearchOpenItems other)
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
		if (Style != other.Style)
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
		if (Source != 0)
		{
			num ^= Source.GetHashCode();
		}
		if (Style != 0)
		{
			num ^= Style.GetHashCode();
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
		if (Source != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Source);
		}
		if (Style != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Style);
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
		if (Source != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Source);
		}
		if (Style != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Style);
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
	public void MergeFrom(QuickSearchOpenItems other)
	{
		if (other != null)
		{
			if (other.Source != 0)
			{
				Source = other.Source;
			}
			if (other.Style != 0)
			{
				Style = other.Style;
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
				Source = (Types.Source)input.ReadEnum();
				break;
			case 16u:
				Style = (Types.Style)input.ReadEnum();
				break;
			case 24u:
				Count = input.ReadInt32();
				break;
			}
		}
	}
}
