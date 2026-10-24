using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Color : IMessage<API_v1_Color>, IMessage, IEquatable<API_v1_Color>, IDeepCloneable<API_v1_Color>
{
	private static readonly MessageParser<API_v1_Color> _parser = new MessageParser<API_v1_Color>(() => new API_v1_Color());

	private UnknownFieldSet _unknownFields;

	public const int RedFieldNumber = 1;

	private double red_;

	public const int GreenFieldNumber = 2;

	private double green_;

	public const int BlueFieldNumber = 3;

	private double blue_;

	public const int AlphaFieldNumber = 4;

	private double alpha_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Color> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1ColorReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double Red
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
	public double Green
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
	public double Blue
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
	public double Alpha
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
	public API_v1_Color()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Color(API_v1_Color other)
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
	public API_v1_Color Clone()
	{
		return new API_v1_Color(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Color);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Color other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Red, other.Red))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Green, other.Green))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Blue, other.Blue))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Alpha, other.Alpha))
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
		if (Red != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Red);
		}
		if (Green != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Green);
		}
		if (Blue != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Blue);
		}
		if (Alpha != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Alpha);
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
		if (Red != 0.0)
		{
			output.WriteRawTag(9);
			output.WriteDouble(Red);
		}
		if (Green != 0.0)
		{
			output.WriteRawTag(17);
			output.WriteDouble(Green);
		}
		if (Blue != 0.0)
		{
			output.WriteRawTag(25);
			output.WriteDouble(Blue);
		}
		if (Alpha != 0.0)
		{
			output.WriteRawTag(33);
			output.WriteDouble(Alpha);
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
		if (Red != 0.0)
		{
			num += 9;
		}
		if (Green != 0.0)
		{
			num += 9;
		}
		if (Blue != 0.0)
		{
			num += 9;
		}
		if (Alpha != 0.0)
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
	public void MergeFrom(API_v1_Color other)
	{
		if (other != null)
		{
			if (other.Red != 0.0)
			{
				Red = other.Red;
			}
			if (other.Green != 0.0)
			{
				Green = other.Green;
			}
			if (other.Blue != 0.0)
			{
				Blue = other.Blue;
			}
			if (other.Alpha != 0.0)
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
			case 9u:
				Red = input.ReadDouble();
				break;
			case 17u:
				Green = input.ReadDouble();
				break;
			case 25u:
				Blue = input.ReadDouble();
				break;
			case 33u:
				Alpha = input.ReadDouble();
				break;
			}
		}
	}
}
