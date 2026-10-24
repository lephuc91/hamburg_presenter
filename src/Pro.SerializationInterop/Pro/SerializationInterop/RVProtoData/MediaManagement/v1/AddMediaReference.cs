using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AddMediaReference : IMessage<AddMediaReference>, IMessage, IEquatable<AddMediaReference>, IDeepCloneable<AddMediaReference>
{
	private static readonly MessageParser<AddMediaReference> _parser = new MessageParser<AddMediaReference>(() => new AddMediaReference());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private string uuid_ = "";

	public const int UrlFieldNumber = 2;

	private string url_ = "";

	public const int PriorityFieldNumber = 3;

	private Priority priority_;

	public const int TransformationFieldNumber = 4;

	private Transformation transformation_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AddMediaReference> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[12];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Url
	{
		get
		{
			return url_;
		}
		set
		{
			url_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Priority Priority
	{
		get
		{
			return priority_;
		}
		set
		{
			priority_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transformation Transformation
	{
		get
		{
			return transformation_;
		}
		set
		{
			transformation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference(AddMediaReference other)
		: this()
	{
		uuid_ = other.uuid_;
		url_ = other.url_;
		priority_ = other.priority_;
		transformation_ = ((other.transformation_ != null) ? other.transformation_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference Clone()
	{
		return new AddMediaReference(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AddMediaReference);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AddMediaReference other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Uuid != other.Uuid)
		{
			return false;
		}
		if (Url != other.Url)
		{
			return false;
		}
		if (Priority != other.Priority)
		{
			return false;
		}
		if (!object.Equals(Transformation, other.Transformation))
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
		if (Uuid.Length != 0)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Url.Length != 0)
		{
			num ^= Url.GetHashCode();
		}
		if (Priority != 0)
		{
			num ^= Priority.GetHashCode();
		}
		if (transformation_ != null)
		{
			num ^= Transformation.GetHashCode();
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
		if (Uuid.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Uuid);
		}
		if (Url.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Url);
		}
		if (Priority != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Priority);
		}
		if (transformation_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Transformation);
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
		if (Uuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
		}
		if (Url.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Url);
		}
		if (Priority != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Priority);
		}
		if (transformation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transformation);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AddMediaReference other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Uuid.Length != 0)
		{
			Uuid = other.Uuid;
		}
		if (other.Url.Length != 0)
		{
			Url = other.Url;
		}
		if (other.Priority != 0)
		{
			Priority = other.Priority;
		}
		if (other.transformation_ != null)
		{
			if (transformation_ == null)
			{
				Transformation = new Transformation();
			}
			Transformation.MergeFrom(other.Transformation);
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
				Uuid = input.ReadString();
				break;
			case 18u:
				Url = input.ReadString();
				break;
			case 24u:
				Priority = (Priority)input.ReadEnum();
				break;
			case 34u:
				if (transformation_ == null)
				{
					Transformation = new Transformation();
				}
				input.ReadMessage(Transformation);
				break;
			}
		}
	}
}
