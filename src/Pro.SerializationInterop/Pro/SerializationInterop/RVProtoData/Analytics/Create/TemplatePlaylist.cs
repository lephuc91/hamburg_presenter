using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Create;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TemplatePlaylist : IMessage<TemplatePlaylist>, IMessage, IEquatable<TemplatePlaylist>, IDeepCloneable<TemplatePlaylist>
{
	private static readonly MessageParser<TemplatePlaylist> _parser = new MessageParser<TemplatePlaylist>(() => new TemplatePlaylist());

	private UnknownFieldSet _unknownFields;

	public const int TotalItemCountFieldNumber = 1;

	private int totalItemCount_;

	public const int HeaderCountFieldNumber = 2;

	private int headerCount_;

	public const int PlaceholderCountFieldNumber = 3;

	private int placeholderCount_;

	public const int PresentationCountFieldNumber = 4;

	private int presentationCount_;

	public const int MediaCountFieldNumber = 5;

	private int mediaCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TemplatePlaylist> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsCreateReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalItemCount
	{
		get
		{
			return totalItemCount_;
		}
		set
		{
			totalItemCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int HeaderCount
	{
		get
		{
			return headerCount_;
		}
		set
		{
			headerCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PlaceholderCount
	{
		get
		{
			return placeholderCount_;
		}
		set
		{
			placeholderCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int PresentationCount
	{
		get
		{
			return presentationCount_;
		}
		set
		{
			presentationCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaCount
	{
		get
		{
			return mediaCount_;
		}
		set
		{
			mediaCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplatePlaylist()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplatePlaylist(TemplatePlaylist other)
		: this()
	{
		totalItemCount_ = other.totalItemCount_;
		headerCount_ = other.headerCount_;
		placeholderCount_ = other.placeholderCount_;
		presentationCount_ = other.presentationCount_;
		mediaCount_ = other.mediaCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplatePlaylist Clone()
	{
		return new TemplatePlaylist(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TemplatePlaylist);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TemplatePlaylist other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TotalItemCount != other.TotalItemCount)
		{
			return false;
		}
		if (HeaderCount != other.HeaderCount)
		{
			return false;
		}
		if (PlaceholderCount != other.PlaceholderCount)
		{
			return false;
		}
		if (PresentationCount != other.PresentationCount)
		{
			return false;
		}
		if (MediaCount != other.MediaCount)
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
		if (TotalItemCount != 0)
		{
			num ^= TotalItemCount.GetHashCode();
		}
		if (HeaderCount != 0)
		{
			num ^= HeaderCount.GetHashCode();
		}
		if (PlaceholderCount != 0)
		{
			num ^= PlaceholderCount.GetHashCode();
		}
		if (PresentationCount != 0)
		{
			num ^= PresentationCount.GetHashCode();
		}
		if (MediaCount != 0)
		{
			num ^= MediaCount.GetHashCode();
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
		if (TotalItemCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TotalItemCount);
		}
		if (HeaderCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(HeaderCount);
		}
		if (PlaceholderCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(PlaceholderCount);
		}
		if (PresentationCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(PresentationCount);
		}
		if (MediaCount != 0)
		{
			output.WriteRawTag(40);
			output.WriteInt32(MediaCount);
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
		if (TotalItemCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalItemCount);
		}
		if (HeaderCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(HeaderCount);
		}
		if (PlaceholderCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(PlaceholderCount);
		}
		if (PresentationCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(PresentationCount);
		}
		if (MediaCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TemplatePlaylist other)
	{
		if (other != null)
		{
			if (other.TotalItemCount != 0)
			{
				TotalItemCount = other.TotalItemCount;
			}
			if (other.HeaderCount != 0)
			{
				HeaderCount = other.HeaderCount;
			}
			if (other.PlaceholderCount != 0)
			{
				PlaceholderCount = other.PlaceholderCount;
			}
			if (other.PresentationCount != 0)
			{
				PresentationCount = other.PresentationCount;
			}
			if (other.MediaCount != 0)
			{
				MediaCount = other.MediaCount;
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
				TotalItemCount = input.ReadInt32();
				break;
			case 16u:
				HeaderCount = input.ReadInt32();
				break;
			case 24u:
				PlaceholderCount = input.ReadInt32();
				break;
			case 32u:
				PresentationCount = input.ReadInt32();
				break;
			case 40u:
				MediaCount = input.ReadInt32();
				break;
			}
		}
	}
}
