using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_PropCollection : IMessage<API_v1_PropCollection>, IMessage, IEquatable<API_v1_PropCollection>, IDeepCloneable<API_v1_PropCollection>
{
	private static readonly MessageParser<API_v1_PropCollection> _parser = new MessageParser<API_v1_PropCollection>(() => new API_v1_PropCollection());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int PropsFieldNumber = 2;

	private static readonly FieldCodec<API_v1_PropData> _repeated_props_codec = FieldCodec.ForMessage(18u, API_v1_PropData.Parser);

	private readonly RepeatedField<API_v1_PropData> props_ = new RepeatedField<API_v1_PropData>();

	public const int SinglePropEnabledFieldNumber = 3;

	private bool singlePropEnabled_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_PropCollection> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PropReflection.Descriptor.MessageTypes[2];

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
	public RepeatedField<API_v1_PropData> Props => props_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool SinglePropEnabled
	{
		get
		{
			return singlePropEnabled_;
		}
		set
		{
			singlePropEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PropCollection()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PropCollection(API_v1_PropCollection other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		props_ = other.props_.Clone();
		singlePropEnabled_ = other.singlePropEnabled_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PropCollection Clone()
	{
		return new API_v1_PropCollection(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_PropCollection);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_PropCollection other)
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
		if (!props_.Equals(other.props_))
		{
			return false;
		}
		if (SinglePropEnabled != other.SinglePropEnabled)
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
		num ^= props_.GetHashCode();
		if (SinglePropEnabled)
		{
			num ^= SinglePropEnabled.GetHashCode();
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		props_.WriteTo(output, _repeated_props_codec);
		if (SinglePropEnabled)
		{
			output.WriteRawTag(24);
			output.WriteBool(SinglePropEnabled);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		num += props_.CalculateSize(_repeated_props_codec);
		if (SinglePropEnabled)
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
	public void MergeFrom(API_v1_PropCollection other)
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
		props_.Add(other.props_);
		if (other.SinglePropEnabled)
		{
			SinglePropEnabled = other.SinglePropEnabled;
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
				if (id_ == null)
				{
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				props_.AddEntriesFrom(input, _repeated_props_codec);
				break;
			case 24u:
				SinglePropEnabled = input.ReadBool();
				break;
			}
		}
	}
}
