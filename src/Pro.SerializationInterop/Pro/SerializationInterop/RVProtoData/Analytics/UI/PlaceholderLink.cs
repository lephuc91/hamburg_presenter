using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PlaceholderLink : IMessage<PlaceholderLink>, IMessage, IEquatable<PlaceholderLink>, IDeepCloneable<PlaceholderLink>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("TYPE_UNKNOWN")]
			Unknown,
			[OriginalName("PRESENTATION")]
			Presentation,
			[OriginalName("MEDIA")]
			Media,
			[OriginalName("EXTERNAL_PRESENTATION")]
			ExternalPresentation
		}

		public enum Source
		{
			[OriginalName("SOURCE_UNKNOWN")]
			Unknown,
			[OriginalName("QUICK_SEARCH")]
			QuickSearch,
			[OriginalName("IMPORT_BUTTON")]
			ImportButton,
			[OriginalName("CREATE_BUTTON")]
			CreateButton,
			[OriginalName("DRAG_DROP")]
			DragDrop,
			[OriginalName("AUTOMATIC")]
			Automatic
		}
	}

	private static readonly MessageParser<PlaceholderLink> _parser = new MessageParser<PlaceholderLink>(() => new PlaceholderLink());

	private UnknownFieldSet _unknownFields;

	public const int LinkTypeFieldNumber = 1;

	private Types.Type linkType_;

	public const int LinkSourceFieldNumber = 2;

	private Types.Source linkSource_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PlaceholderLink> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[66];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Type LinkType
	{
		get
		{
			return linkType_;
		}
		set
		{
			linkType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Source LinkSource
	{
		get
		{
			return linkSource_;
		}
		set
		{
			linkSource_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaceholderLink()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaceholderLink(PlaceholderLink other)
		: this()
	{
		linkType_ = other.linkType_;
		linkSource_ = other.linkSource_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaceholderLink Clone()
	{
		return new PlaceholderLink(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PlaceholderLink);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PlaceholderLink other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (LinkType != other.LinkType)
		{
			return false;
		}
		if (LinkSource != other.LinkSource)
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
		if (LinkType != 0)
		{
			num ^= LinkType.GetHashCode();
		}
		if (LinkSource != 0)
		{
			num ^= LinkSource.GetHashCode();
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
		if (LinkType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)LinkType);
		}
		if (LinkSource != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)LinkSource);
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
		if (LinkType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LinkType);
		}
		if (LinkSource != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)LinkSource);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PlaceholderLink other)
	{
		if (other != null)
		{
			if (other.LinkType != 0)
			{
				LinkType = other.LinkType;
			}
			if (other.LinkSource != 0)
			{
				LinkSource = other.LinkSource;
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
				LinkType = (Types.Type)input.ReadEnum();
				break;
			case 16u:
				LinkSource = (Types.Source)input.ReadEnum();
				break;
			}
		}
	}
}
