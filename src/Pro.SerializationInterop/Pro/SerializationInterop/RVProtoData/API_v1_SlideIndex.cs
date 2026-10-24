using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_SlideIndex : IMessage<API_v1_SlideIndex>, IMessage, IEquatable<API_v1_SlideIndex>, IDeepCloneable<API_v1_SlideIndex>
{
	private static readonly MessageParser<API_v1_SlideIndex> _parser = new MessageParser<API_v1_SlideIndex>(() => new API_v1_SlideIndex());

	private UnknownFieldSet _unknownFields;

	public const int IndexFieldNumber = 1;

	private uint index_;

	public const int PresentationIdFieldNumber = 2;

	private API_v1_Identifier presentationId_;

	public const int TotalCuesFieldNumber = 3;

	private uint totalCues_;

	public const int RemainingCuesFieldNumber = 4;

	private uint remainingCues_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_SlideIndex> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PresentationReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Index
	{
		get
		{
			return index_;
		}
		set
		{
			index_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier PresentationId
	{
		get
		{
			return presentationId_;
		}
		set
		{
			presentationId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint TotalCues
	{
		get
		{
			return totalCues_;
		}
		set
		{
			totalCues_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint RemainingCues
	{
		get
		{
			return remainingCues_;
		}
		set
		{
			remainingCues_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_SlideIndex()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_SlideIndex(API_v1_SlideIndex other)
		: this()
	{
		index_ = other.index_;
		presentationId_ = ((other.presentationId_ != null) ? other.presentationId_.Clone() : null);
		totalCues_ = other.totalCues_;
		remainingCues_ = other.remainingCues_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_SlideIndex Clone()
	{
		return new API_v1_SlideIndex(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_SlideIndex);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_SlideIndex other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Index != other.Index)
		{
			return false;
		}
		if (!object.Equals(PresentationId, other.PresentationId))
		{
			return false;
		}
		if (TotalCues != other.TotalCues)
		{
			return false;
		}
		if (RemainingCues != other.RemainingCues)
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
		if (Index != 0)
		{
			num ^= Index.GetHashCode();
		}
		if (presentationId_ != null)
		{
			num ^= PresentationId.GetHashCode();
		}
		if (TotalCues != 0)
		{
			num ^= TotalCues.GetHashCode();
		}
		if (RemainingCues != 0)
		{
			num ^= RemainingCues.GetHashCode();
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
		if (Index != 0)
		{
			output.WriteRawTag(8);
			output.WriteUInt32(Index);
		}
		if (presentationId_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(PresentationId);
		}
		if (TotalCues != 0)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(TotalCues);
		}
		if (RemainingCues != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(RemainingCues);
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
		if (Index != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Index);
		}
		if (presentationId_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PresentationId);
		}
		if (TotalCues != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(TotalCues);
		}
		if (RemainingCues != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(RemainingCues);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_SlideIndex other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Index != 0)
		{
			Index = other.Index;
		}
		if (other.presentationId_ != null)
		{
			if (presentationId_ == null)
			{
				PresentationId = new API_v1_Identifier();
			}
			PresentationId.MergeFrom(other.PresentationId);
		}
		if (other.TotalCues != 0)
		{
			TotalCues = other.TotalCues;
		}
		if (other.RemainingCues != 0)
		{
			RemainingCues = other.RemainingCues;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
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
				Index = input.ReadUInt32();
				break;
			case 18u:
				if (presentationId_ == null)
				{
					PresentationId = new API_v1_Identifier();
				}
				input.ReadMessage(PresentationId);
				break;
			case 24u:
				TotalCues = input.ReadUInt32();
				break;
			case 32u:
				RemainingCues = input.ReadUInt32();
				break;
			}
		}
	}
}
