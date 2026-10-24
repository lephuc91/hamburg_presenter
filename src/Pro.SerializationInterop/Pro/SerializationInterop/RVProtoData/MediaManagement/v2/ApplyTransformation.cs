using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ApplyTransformation : IMessage<ApplyTransformation>, IMessage, IEquatable<ApplyTransformation>, IDeepCloneable<ApplyTransformation>
{
	private static readonly MessageParser<ApplyTransformation> _parser = new MessageParser<ApplyTransformation>(() => new ApplyTransformation());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int IdFieldNumber = 1;

	private ReferenceIdentifier id_;

	public const int TransformationFieldNumber = 2;

	private Transformation transformation_;

	public const int PriorityFieldNumber = 3;

	private Priority priority_;

	public const int UserInitiatedFieldNumber = 4;

	private static readonly bool UserInitiatedDefaultValue = false;

	private bool userInitiated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ApplyTransformation> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[21];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReferenceIdentifier Id
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
	public bool UserInitiated
	{
		get
		{
			if ((_hasBits0 & 1) != 0)
			{
				return userInitiated_;
			}
			return UserInitiatedDefaultValue;
		}
		set
		{
			_hasBits0 |= 1;
			userInitiated_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasUserInitiated => (_hasBits0 & 1) != 0;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplyTransformation()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplyTransformation(ApplyTransformation other)
		: this()
	{
		_hasBits0 = other._hasBits0;
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		transformation_ = ((other.transformation_ != null) ? other.transformation_.Clone() : null);
		priority_ = other.priority_;
		userInitiated_ = other.userInitiated_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplyTransformation Clone()
	{
		return new ApplyTransformation(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearUserInitiated()
	{
		_hasBits0 &= -2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ApplyTransformation);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ApplyTransformation other)
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
		if (!object.Equals(Transformation, other.Transformation))
		{
			return false;
		}
		if (Priority != other.Priority)
		{
			return false;
		}
		if (UserInitiated != other.UserInitiated)
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
		if (transformation_ != null)
		{
			num ^= Transformation.GetHashCode();
		}
		if (Priority != 0)
		{
			num ^= Priority.GetHashCode();
		}
		if (HasUserInitiated)
		{
			num ^= UserInitiated.GetHashCode();
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
		if (transformation_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Transformation);
		}
		if (Priority != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Priority);
		}
		if (HasUserInitiated)
		{
			output.WriteRawTag(32);
			output.WriteBool(UserInitiated);
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
		if (transformation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transformation);
		}
		if (Priority != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Priority);
		}
		if (HasUserInitiated)
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
	public void MergeFrom(ApplyTransformation other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new ReferenceIdentifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.transformation_ != null)
		{
			if (transformation_ == null)
			{
				Transformation = new Transformation();
			}
			Transformation.MergeFrom(other.Transformation);
		}
		if (other.Priority != 0)
		{
			Priority = other.Priority;
		}
		if (other.HasUserInitiated)
		{
			UserInitiated = other.UserInitiated;
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
					Id = new ReferenceIdentifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
				if (transformation_ == null)
				{
					Transformation = new Transformation();
				}
				input.ReadMessage(Transformation);
				break;
			case 24u:
				Priority = (Priority)input.ReadEnum();
				break;
			case 32u:
				UserInitiated = input.ReadBool();
				break;
			}
		}
	}
}
