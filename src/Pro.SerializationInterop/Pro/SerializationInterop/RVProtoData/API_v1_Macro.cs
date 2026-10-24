using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Macro : IMessage<API_v1_Macro>, IMessage, IEquatable<API_v1_Macro>, IDeepCloneable<API_v1_Macro>
{
	private static readonly MessageParser<API_v1_Macro> _parser = new MessageParser<API_v1_Macro>(() => new API_v1_Macro());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int ColorFieldNumber = 2;

	private API_v1_Color color_;

	public const int ImageTypeFieldNumber = 3;

	private string imageType_ = "";

	public const int ActionsFieldNumber = 4;

	private static readonly FieldCodec<API_v1_MacroAction> _repeated_actions_codec = FieldCodec.ForMessage(34u, API_v1_MacroAction.Parser);

	private readonly RepeatedField<API_v1_MacroAction> actions_ = new RepeatedField<API_v1_MacroAction>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Macro> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MacroReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Color Color
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
	public string ImageType
	{
		get
		{
			return imageType_;
		}
		set
		{
			imageType_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<API_v1_MacroAction> Actions => actions_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro(API_v1_Macro other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		color_ = ((other.color_ != null) ? other.color_.Clone() : null);
		imageType_ = other.imageType_;
		actions_ = other.actions_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro Clone()
	{
		return new API_v1_Macro(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Macro);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Macro other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Id, other.Id))
		{
			return false;
		}
		if (!object.Equals(Color, other.Color))
		{
			return false;
		}
		if (ImageType != other.ImageType)
		{
			return false;
		}
		if (!actions_.Equals(other.actions_))
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
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (color_ != null)
		{
			num ^= Color.GetHashCode();
		}
		if (ImageType.Length != 0)
		{
			num ^= ImageType.GetHashCode();
		}
		num ^= actions_.GetHashCode();
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (color_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Color);
		}
		if (ImageType.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ImageType);
		}
		actions_.WriteTo(output, _repeated_actions_codec);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (color_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Color);
		}
		if (ImageType.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ImageType);
		}
		num += actions_.CalculateSize(_repeated_actions_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Macro other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new API_v1_Identifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.color_ != null)
		{
			if (color_ == null)
			{
				Color = new API_v1_Color();
			}
			Color.MergeFrom(other.Color);
		}
		if (other.ImageType.Length != 0)
		{
			ImageType = other.ImageType;
		}
		actions_.Add(other.actions_);
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
				if (id_ == null)
				{
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				if (color_ == null)
				{
					Color = new API_v1_Color();
				}
				input.ReadMessage(Color);
				break;
			case 26u:
				ImageType = input.ReadString();
				break;
			case 34u:
				actions_.AddEntriesFrom(input, _repeated_actions_codec);
				break;
			}
		}
	}
}
