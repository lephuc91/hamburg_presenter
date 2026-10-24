using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CollectionElementType : IMessage<CollectionElementType>, IMessage, IEquatable<CollectionElementType>, IDeepCloneable<CollectionElementType>
{
	private static readonly MessageParser<CollectionElementType> _parser = new MessageParser<CollectionElementType>(() => new CollectionElementType());

	private UnknownFieldSet _unknownFields;

	public const int ParameterUuidFieldNumber = 1;

	private UUID parameterUuid_;

	public const int ParameterNameFieldNumber = 2;

	private string parameterName_ = "";

	public const int ParentCollectionFieldNumber = 3;

	private CollectionElementType parentCollection_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CollectionElementType> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => CollectionElementTypeReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID ParameterUuid
	{
		get
		{
			return parameterUuid_;
		}
		set
		{
			parameterUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ParameterName
	{
		get
		{
			return parameterName_;
		}
		set
		{
			parameterName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType ParentCollection
	{
		get
		{
			return parentCollection_;
		}
		set
		{
			parentCollection_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType(CollectionElementType other)
		: this()
	{
		parameterUuid_ = ((other.parameterUuid_ != null) ? other.parameterUuid_.Clone() : null);
		parameterName_ = other.parameterName_;
		parentCollection_ = ((other.parentCollection_ != null) ? other.parentCollection_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CollectionElementType Clone()
	{
		return new CollectionElementType(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CollectionElementType);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CollectionElementType other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ParameterUuid, other.ParameterUuid))
		{
			return false;
		}
		if (ParameterName != other.ParameterName)
		{
			return false;
		}
		if (!object.Equals(ParentCollection, other.ParentCollection))
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
		if (parameterUuid_ != null)
		{
			num ^= ParameterUuid.GetHashCode();
		}
		if (ParameterName.Length != 0)
		{
			num ^= ParameterName.GetHashCode();
		}
		if (parentCollection_ != null)
		{
			num ^= ParentCollection.GetHashCode();
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
		if (parameterUuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ParameterUuid);
		}
		if (ParameterName.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(ParameterName);
		}
		if (parentCollection_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ParentCollection);
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
		if (parameterUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ParameterUuid);
		}
		if (ParameterName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ParameterName);
		}
		if (parentCollection_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ParentCollection);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CollectionElementType other)
	{
		if (other == null)
		{
			return;
		}
		if (other.parameterUuid_ != null)
		{
			if (parameterUuid_ == null)
			{
				ParameterUuid = new UUID();
			}
			ParameterUuid.MergeFrom(other.ParameterUuid);
		}
		if (other.ParameterName.Length != 0)
		{
			ParameterName = other.ParameterName;
		}
		if (other.parentCollection_ != null)
		{
			if (parentCollection_ == null)
			{
				ParentCollection = new CollectionElementType();
			}
			ParentCollection.MergeFrom(other.ParentCollection);
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
				if (parameterUuid_ == null)
				{
					ParameterUuid = new UUID();
				}
				input.ReadMessage(ParameterUuid);
				break;
			case 18u:
				ParameterName = input.ReadString();
				break;
			case 26u:
				if (parentCollection_ == null)
				{
					ParentCollection = new CollectionElementType();
				}
				input.ReadMessage(ParentCollection);
				break;
			}
		}
	}
}
