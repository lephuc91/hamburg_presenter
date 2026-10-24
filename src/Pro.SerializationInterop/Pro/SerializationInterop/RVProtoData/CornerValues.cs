using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CornerValues : IMessage<CornerValues>, IMessage, IEquatable<CornerValues>, IDeepCloneable<CornerValues>
{
	private static readonly MessageParser<CornerValues> _parser = new MessageParser<CornerValues>(() => new CornerValues());

	private UnknownFieldSet _unknownFields;

	public const int TopLeftFieldNumber = 1;

	private Graphics.Types.Point topLeft_;

	public const int TopRightFieldNumber = 2;

	private Graphics.Types.Point topRight_;

	public const int BottomLeftFieldNumber = 3;

	private Graphics.Types.Point bottomLeft_;

	public const int BottomRightFieldNumber = 4;

	private Graphics.Types.Point bottomRight_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CornerValues> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ScreensReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Point TopLeft
	{
		get
		{
			return topLeft_;
		}
		set
		{
			topLeft_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Point TopRight
	{
		get
		{
			return topRight_;
		}
		set
		{
			topRight_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Point BottomLeft
	{
		get
		{
			return bottomLeft_;
		}
		set
		{
			bottomLeft_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Point BottomRight
	{
		get
		{
			return bottomRight_;
		}
		set
		{
			bottomRight_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CornerValues()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CornerValues(CornerValues other)
		: this()
	{
		topLeft_ = ((other.topLeft_ != null) ? other.topLeft_.Clone() : null);
		topRight_ = ((other.topRight_ != null) ? other.topRight_.Clone() : null);
		bottomLeft_ = ((other.bottomLeft_ != null) ? other.bottomLeft_.Clone() : null);
		bottomRight_ = ((other.bottomRight_ != null) ? other.bottomRight_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CornerValues Clone()
	{
		return new CornerValues(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CornerValues);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CornerValues other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(TopLeft, other.TopLeft))
		{
			return false;
		}
		if (!object.Equals(TopRight, other.TopRight))
		{
			return false;
		}
		if (!object.Equals(BottomLeft, other.BottomLeft))
		{
			return false;
		}
		if (!object.Equals(BottomRight, other.BottomRight))
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
		if (topLeft_ != null)
		{
			num ^= TopLeft.GetHashCode();
		}
		if (topRight_ != null)
		{
			num ^= TopRight.GetHashCode();
		}
		if (bottomLeft_ != null)
		{
			num ^= BottomLeft.GetHashCode();
		}
		if (bottomRight_ != null)
		{
			num ^= BottomRight.GetHashCode();
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
		if (topLeft_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(TopLeft);
		}
		if (topRight_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(TopRight);
		}
		if (bottomLeft_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(BottomLeft);
		}
		if (bottomRight_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(BottomRight);
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
		if (topLeft_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TopLeft);
		}
		if (topRight_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TopRight);
		}
		if (bottomLeft_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BottomLeft);
		}
		if (bottomRight_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BottomRight);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CornerValues other)
	{
		if (other == null)
		{
			return;
		}
		if (other.topLeft_ != null)
		{
			if (topLeft_ == null)
			{
				TopLeft = new Graphics.Types.Point();
			}
			TopLeft.MergeFrom(other.TopLeft);
		}
		if (other.topRight_ != null)
		{
			if (topRight_ == null)
			{
				TopRight = new Graphics.Types.Point();
			}
			TopRight.MergeFrom(other.TopRight);
		}
		if (other.bottomLeft_ != null)
		{
			if (bottomLeft_ == null)
			{
				BottomLeft = new Graphics.Types.Point();
			}
			BottomLeft.MergeFrom(other.BottomLeft);
		}
		if (other.bottomRight_ != null)
		{
			if (bottomRight_ == null)
			{
				BottomRight = new Graphics.Types.Point();
			}
			BottomRight.MergeFrom(other.BottomRight);
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
				if (topLeft_ == null)
				{
					TopLeft = new Graphics.Types.Point();
				}
				input.ReadMessage(TopLeft);
				break;
			case 18u:
				if (topRight_ == null)
				{
					TopRight = new Graphics.Types.Point();
				}
				input.ReadMessage(TopRight);
				break;
			case 26u:
				if (bottomLeft_ == null)
				{
					BottomLeft = new Graphics.Types.Point();
				}
				input.ReadMessage(BottomLeft);
				break;
			case 34u:
				if (bottomRight_ == null)
				{
					BottomRight = new Graphics.Types.Point();
				}
				input.ReadMessage(BottomRight);
				break;
			}
		}
	}
}
