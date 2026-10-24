using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Mask : IMessage<Mask>, IMessage, IEquatable<Mask>, IDeepCloneable<Mask>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Mode
		{
			[OriginalName("MODE_OVERLAY")]
			Overlay,
			[OriginalName("MODE_KEYHOLE")]
			Keyhole
		}
	}

	private static readonly MessageParser<Mask> _parser = new MessageParser<Mask>(() => new Mask());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int ColorFieldNumber = 3;

	private Color color_;

	public const int ModeFieldNumber = 4;

	private Types.Mode mode_;

	public const int ShapesFieldNumber = 5;

	private static readonly FieldCodec<Graphics.Types.Element> _repeated_shapes_codec = FieldCodec.ForMessage(42u, Graphics.Types.Element.Parser);

	private readonly RepeatedField<Graphics.Types.Element> shapes_ = new RepeatedField<Graphics.Types.Element>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Mask> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => MasksReflection.Descriptor.MessageTypes[0];

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
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Color Color
	{
		get
		{
			return color_;
		}
		set
		{
			color_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Mode Mode
	{
		get
		{
			return mode_;
		}
		set
		{
			mode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Graphics.Types.Element> Shapes => shapes_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Mask()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Mask(Mask other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		color_ = ((other.color_ != null) ? other.color_.Clone() : null);
		mode_ = other.mode_;
		shapes_ = other.shapes_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Mask Clone()
	{
		return new Mask(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Mask);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Mask other)
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
		if (Name != other.Name)
		{
			return false;
		}
		if (!object.Equals(Color, other.Color))
		{
			return false;
		}
		if (Mode != other.Mode)
		{
			return false;
		}
		if (!shapes_.Equals(other.shapes_))
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
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (color_ != null)
		{
			num ^= Color.GetHashCode();
		}
		if (Mode != 0)
		{
			num ^= Mode.GetHashCode();
		}
		num ^= shapes_.GetHashCode();
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
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (color_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Color);
		}
		if (Mode != 0)
		{
			output.WriteRawTag(32);
			output.WriteEnum((int)Mode);
		}
		shapes_.WriteTo(output, _repeated_shapes_codec);
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
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (color_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Color);
		}
		if (Mode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
		}
		num += shapes_.CalculateSize(_repeated_shapes_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Mask other)
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
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.color_ != null)
		{
			if (color_ == null)
			{
				Color = new Color();
			}
			Color.MergeFrom(other.Color);
		}
		if (other.Mode != 0)
		{
			Mode = other.Mode;
		}
		shapes_.Add(other.shapes_);
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
			case 18u:
				Name = input.ReadString();
				break;
			case 26u:
				if (color_ == null)
				{
					Color = new Color();
				}
				input.ReadMessage(Color);
				break;
			case 32u:
				Mode = (Types.Mode)input.ReadEnum();
				break;
			case 42u:
				shapes_.AddEntriesFrom(input, _repeated_shapes_codec);
				break;
			}
		}
	}
}
