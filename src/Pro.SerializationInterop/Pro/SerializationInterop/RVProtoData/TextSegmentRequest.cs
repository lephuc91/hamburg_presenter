using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TextSegmentRequest : IMessage<TextSegmentRequest>, IMessage, IEquatable<TextSegmentRequest>, IDeepCloneable<TextSegmentRequest>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Segment : IMessage<Segment>, IMessage, IEquatable<Segment>, IDeepCloneable<Segment>
		{
			private static readonly MessageParser<Segment> _parser = new MessageParser<Segment>(() => new Segment());

			private UnknownFieldSet _unknownFields;

			public const int IndexFieldNumber = 1;

			private uint index_;

			public const int SizeFieldNumber = 2;

			private double size_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Segment> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => TextSegmentRequest.Descriptor.NestedTypes[0];

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
			public double Size
			{
				get
				{
					return size_;
				}
				set
				{
					size_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Segment()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Segment(Segment other)
				: this()
			{
				index_ = other.index_;
				size_ = other.size_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Segment Clone()
			{
				return new Segment(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Segment);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Segment other)
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
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Size, other.Size))
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
				if (Size != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Size);
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
				if (Size != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(Size);
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
				if (Size != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Segment other)
			{
				if (other != null)
				{
					if (other.Index != 0)
					{
						Index = other.Index;
					}
					if (other.Size != 0.0)
					{
						Size = other.Size;
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
						Index = input.ReadUInt32();
						break;
					case 17u:
						Size = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<TextSegmentRequest> _parser = new MessageParser<TextSegmentRequest>(() => new TextSegmentRequest());

	private UnknownFieldSet _unknownFields;

	public const int SegmentsFieldNumber = 1;

	private static readonly FieldCodec<Types.Segment> _repeated_segments_codec = FieldCodec.ForMessage(10u, Types.Segment.Parser);

	private readonly RepeatedField<Types.Segment> segments_ = new RepeatedField<Types.Segment>();

	public const int StartPositionFieldNumber = 2;

	private double startPosition_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TextSegmentRequest> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Segment> Segments => segments_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double StartPosition
	{
		get
		{
			return startPosition_;
		}
		set
		{
			startPosition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextSegmentRequest()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextSegmentRequest(TextSegmentRequest other)
		: this()
	{
		segments_ = other.segments_.Clone();
		startPosition_ = other.startPosition_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TextSegmentRequest Clone()
	{
		return new TextSegmentRequest(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TextSegmentRequest);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TextSegmentRequest other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!segments_.Equals(other.segments_))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(StartPosition, other.StartPosition))
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
		num ^= segments_.GetHashCode();
		if (StartPosition != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(StartPosition);
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
		segments_.WriteTo(output, _repeated_segments_codec);
		if (StartPosition != 0.0)
		{
			output.WriteRawTag(17);
			output.WriteDouble(StartPosition);
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
		num += segments_.CalculateSize(_repeated_segments_codec);
		if (StartPosition != 0.0)
		{
			num += 9;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TextSegmentRequest other)
	{
		if (other != null)
		{
			segments_.Add(other.segments_);
			if (other.StartPosition != 0.0)
			{
				StartPosition = other.StartPosition;
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
				segments_.AddEntriesFrom(input, _repeated_segments_codec);
				break;
			case 17u:
				StartPosition = input.ReadDouble();
				break;
			}
		}
	}
}
