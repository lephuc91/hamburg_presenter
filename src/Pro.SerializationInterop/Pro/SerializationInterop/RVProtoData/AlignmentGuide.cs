using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AlignmentGuide : IMessage<AlignmentGuide>, IMessage, IEquatable<AlignmentGuide>, IDeepCloneable<AlignmentGuide>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum GuidelineOrientation
		{
			[OriginalName("GUIDELINE_ORIENTATION_HORIZONTAL")]
			Horizontal,
			[OriginalName("GUIDELINE_ORIENTATION_VERTICAL")]
			Vertical
		}
	}

	private static readonly MessageParser<AlignmentGuide> _parser = new MessageParser<AlignmentGuide>(() => new AlignmentGuide());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int OrientationFieldNumber = 2;

	private Types.GuidelineOrientation orientation_;

	public const int LocationFieldNumber = 3;

	private double location_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AlignmentGuide> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AlignmentGuideReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GuidelineOrientation Orientation
	{
		get
		{
			return orientation_;
		}
		set
		{
			orientation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Location
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
	public AlignmentGuide()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AlignmentGuide(AlignmentGuide other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		orientation_ = other.orientation_;
		location_ = other.location_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AlignmentGuide Clone()
	{
		return new AlignmentGuide(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AlignmentGuide);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AlignmentGuide other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (Orientation != other.Orientation)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Location, other.Location))
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Orientation != 0)
		{
			num ^= Orientation.GetHashCode();
		}
		if (Location != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Location);
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (Orientation != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Orientation);
		}
		if (Location != 0.0)
		{
			output.WriteRawTag(25);
			output.WriteDouble(Location);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (Orientation != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Orientation);
		}
		if (Location != 0.0)
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
	public void MergeFrom(AlignmentGuide other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.Orientation != 0)
		{
			Orientation = other.Orientation;
		}
		if (other.Location != 0.0)
		{
			Location = other.Location;
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
			case 10u:
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 16u:
				Orientation = (Types.GuidelineOrientation)input.ReadEnum();
				break;
			case 25u:
				Location = input.ReadDouble();
				break;
			}
		}
	}
}
