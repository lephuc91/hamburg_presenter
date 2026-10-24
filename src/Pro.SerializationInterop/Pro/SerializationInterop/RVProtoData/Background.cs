using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Background : IMessage<Background>, IMessage, IEquatable<Background>, IDeepCloneable<Background>
{
	public enum FillOneofCase
	{
		None,
		Color,
		Gradient
	}

	private static readonly MessageParser<Background> _parser = new MessageParser<Background>(() => new Background());

	private UnknownFieldSet _unknownFields;

	public const int ColorFieldNumber = 1;

	public const int GradientFieldNumber = 2;

	public const int IsEnabledFieldNumber = 3;

	private bool isEnabled_;

	private object fill_;

	private FillOneofCase fillCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Background> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => BackgroundReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color Color
	{
		get
		{
			if (fillCase_ != FillOneofCase.Color)
			{
				return null;
			}
			return (Color)fill_;
		}
		set
		{
			fill_ = value;
			fillCase_ = ((value != null) ? FillOneofCase.Color : FillOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Gradient Gradient
	{
		get
		{
			if (fillCase_ != FillOneofCase.Gradient)
			{
				return null;
			}
			return (Graphics.Types.Gradient)fill_;
		}
		set
		{
			fill_ = value;
			fillCase_ = ((value != null) ? FillOneofCase.Gradient : FillOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsEnabled
	{
		get
		{
			return isEnabled_;
		}
		set
		{
			isEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FillOneofCase FillCase => fillCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Background()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Background(Background other)
		: this()
	{
		isEnabled_ = other.isEnabled_;
		switch (other.FillCase)
		{
		case FillOneofCase.Color:
			Color = other.Color.Clone();
			break;
		case FillOneofCase.Gradient:
			Gradient = other.Gradient.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Background Clone()
	{
		return new Background(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearFill()
	{
		fillCase_ = FillOneofCase.None;
		fill_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Background);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Background other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Color, other.Color))
		{
			return false;
		}
		if (!object.Equals(Gradient, other.Gradient))
		{
			return false;
		}
		if (IsEnabled != other.IsEnabled)
		{
			return false;
		}
		if (FillCase != other.FillCase)
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
		if (fillCase_ == FillOneofCase.Color)
		{
			num ^= Color.GetHashCode();
		}
		if (fillCase_ == FillOneofCase.Gradient)
		{
			num ^= Gradient.GetHashCode();
		}
		if (IsEnabled)
		{
			num ^= IsEnabled.GetHashCode();
		}
		num ^= (int)fillCase_;
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
		if (fillCase_ == FillOneofCase.Color)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Color);
		}
		if (fillCase_ == FillOneofCase.Gradient)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Gradient);
		}
		if (IsEnabled)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsEnabled);
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
		if (fillCase_ == FillOneofCase.Color)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Color);
		}
		if (fillCase_ == FillOneofCase.Gradient)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Gradient);
		}
		if (IsEnabled)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Background other)
	{
		if (other == null)
		{
			return;
		}
		if (other.IsEnabled)
		{
			IsEnabled = other.IsEnabled;
		}
		switch (other.FillCase)
		{
		case FillOneofCase.Color:
			if (Color == null)
			{
				Color = new Color();
			}
			Color.MergeFrom(other.Color);
			break;
		case FillOneofCase.Gradient:
			if (Gradient == null)
			{
				Gradient = new Graphics.Types.Gradient();
			}
			Gradient.MergeFrom(other.Gradient);
			break;
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
			{
				Color color = new Color();
				if (fillCase_ == FillOneofCase.Color)
				{
					color.MergeFrom(Color);
				}
				input.ReadMessage(color);
				Color = color;
				break;
			}
			case 18u:
			{
				Graphics.Types.Gradient gradient = new Graphics.Types.Gradient();
				if (fillCase_ == FillOneofCase.Gradient)
				{
					gradient.MergeFrom(Gradient);
				}
				input.ReadMessage(gradient);
				Gradient = gradient;
				break;
			}
			case 24u:
				IsEnabled = input.ReadBool();
				break;
			}
		}
	}
}
