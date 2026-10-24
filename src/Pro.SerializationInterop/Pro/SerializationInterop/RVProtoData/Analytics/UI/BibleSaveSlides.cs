using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.UI;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class BibleSaveSlides : IMessage<BibleSaveSlides>, IMessage, IEquatable<BibleSaveSlides>, IDeepCloneable<BibleSaveSlides>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum SlideDestination
		{
			[OriginalName("SLIDE_DESTINATION_UNKNOWN")]
			Unknown,
			[OriginalName("SAVE_TO_LIBRARY")]
			SaveToLibrary,
			[OriginalName("SAVE_TO_PLAYLIST")]
			SaveToPlaylist,
			[OriginalName("COPY_TO_PRESENTATION")]
			CopyToPresentation
		}
	}

	private static readonly MessageParser<BibleSaveSlides> _parser = new MessageParser<BibleSaveSlides>(() => new BibleSaveSlides());

	private UnknownFieldSet _unknownFields;

	public const int DestinationFieldNumber = 1;

	private Types.SlideDestination destination_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<BibleSaveSlides> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsUIReflection.Descriptor.MessageTypes[13];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SlideDestination Destination
	{
		get
		{
			return destination_;
		}
		set
		{
			destination_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleSaveSlides()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleSaveSlides(BibleSaveSlides other)
		: this()
	{
		destination_ = other.destination_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleSaveSlides Clone()
	{
		return new BibleSaveSlides(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as BibleSaveSlides);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(BibleSaveSlides other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Destination != other.Destination)
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
		if (Destination != 0)
		{
			num ^= Destination.GetHashCode();
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
		if (Destination != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Destination);
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
		if (Destination != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Destination);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(BibleSaveSlides other)
	{
		if (other != null)
		{
			if (other.Destination != 0)
			{
				Destination = other.Destination;
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
				Destination = (Types.SlideDestination)input.ReadEnum();
			}
		}
	}
}
