using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Color : IMessage<Color>, IMessage, IEquatable<Color>, IDeepCloneable<Color>
{
	private static readonly MessageParser<Color> _parser = new MessageParser<Color>(() => new Color());

	private UnknownFieldSet _unknownFields;

	public const int RedFieldNumber = 1;

	private float red_;

	public const int GreenFieldNumber = 2;

	private float green_;

	public const int BlueFieldNumber = 3;

	private float blue_;

	public const int AlphaFieldNumber = 4;

	private float alpha_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Color> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ColorReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Red
	{
		get
		{
			return red_;
		}
		set
		{
			red_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Green
	{
		get
		{
			return green_;
		}
		set
		{
			green_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Blue
	{
		get
		{
			return blue_;
		}
		set
		{
			blue_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Alpha
	{
		get
		{
			return alpha_;
		}
		set
		{
			alpha_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color(Color other)
		: this()
	{
		red_ = other.red_;
		green_ = other.green_;
		blue_ = other.blue_;
		alpha_ = other.alpha_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color Clone()
	{
		return new Color(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Color);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Color other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Red, other.Red))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Green, other.Green))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Blue, other.Blue))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Alpha, other.Alpha))
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
		if (Red != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Red);
		}
		if (Green != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Green);
		}
		if (Blue != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Blue);
		}
		if (Alpha != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Alpha);
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
		if (Red != 0f)
		{
			output.WriteRawTag(13);
			output.WriteFloat(Red);
		}
		if (Green != 0f)
		{
			output.WriteRawTag(21);
			output.WriteFloat(Green);
		}
		if (Blue != 0f)
		{
			output.WriteRawTag(29);
			output.WriteFloat(Blue);
		}
		if (Alpha != 0f)
		{
			output.WriteRawTag(37);
			output.WriteFloat(Alpha);
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
		if (Red != 0f)
		{
			num += 5;
		}
		if (Green != 0f)
		{
			num += 5;
		}
		if (Blue != 0f)
		{
			num += 5;
		}
		if (Alpha != 0f)
		{
			num += 5;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Color other)
	{
		if (other != null)
		{
			if (other.Red != 0f)
			{
				Red = other.Red;
			}
			if (other.Green != 0f)
			{
				Green = other.Green;
			}
			if (other.Blue != 0f)
			{
				Blue = other.Blue;
			}
			if (other.Alpha != 0f)
			{
				Alpha = other.Alpha;
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
			case 13u:
				Red = input.ReadFloat();
				break;
			case 21u:
				Green = input.ReadFloat();
				break;
			case 29u:
				Blue = input.ReadFloat();
				break;
			case 37u:
				Alpha = input.ReadFloat();
				break;
			}
		}
	}
}
