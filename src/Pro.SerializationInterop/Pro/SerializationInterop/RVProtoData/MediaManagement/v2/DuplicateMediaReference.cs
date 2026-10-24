using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DuplicateMediaReference : IMessage<DuplicateMediaReference>, IMessage, IEquatable<DuplicateMediaReference>, IDeepCloneable<DuplicateMediaReference>
{
	private static readonly MessageParser<DuplicateMediaReference> _parser = new MessageParser<DuplicateMediaReference>(() => new DuplicateMediaReference());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int SrcIdFieldNumber = 1;

	private ReferenceIdentifier srcId_;

	public const int DestIdFieldNumber = 2;

	private ReferenceIdentifier destId_;

	public const int PriorityFieldNumber = 3;

	private Priority priority_;

	public const int UserInitiatedFieldNumber = 4;

	private static readonly bool UserInitiatedDefaultValue = false;

	private bool userInitiated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DuplicateMediaReference> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[19];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReferenceIdentifier SrcId
	{
		get
		{
			return srcId_;
		}
		set
		{
			srcId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReferenceIdentifier DestId
	{
		get
		{
			return destId_;
		}
		set
		{
			destId_ = value;
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
	public DuplicateMediaReference()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference(DuplicateMediaReference other)
		: this()
	{
		_hasBits0 = other._hasBits0;
		srcId_ = ((other.srcId_ != null) ? other.srcId_.Clone() : null);
		destId_ = ((other.destId_ != null) ? other.destId_.Clone() : null);
		priority_ = other.priority_;
		userInitiated_ = other.userInitiated_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference Clone()
	{
		return new DuplicateMediaReference(this);
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
		return Equals(other as DuplicateMediaReference);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DuplicateMediaReference other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(SrcId, other.SrcId))
		{
			return false;
		}
		if (!object.Equals(DestId, other.DestId))
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
		if (srcId_ != null)
		{
			num ^= SrcId.GetHashCode();
		}
		if (destId_ != null)
		{
			num ^= DestId.GetHashCode();
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
		if (srcId_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(SrcId);
		}
		if (destId_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(DestId);
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
		if (srcId_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SrcId);
		}
		if (destId_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DestId);
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
	public void MergeFrom(DuplicateMediaReference other)
	{
		if (other == null)
		{
			return;
		}
		if (other.srcId_ != null)
		{
			if (srcId_ == null)
			{
				SrcId = new ReferenceIdentifier();
			}
			SrcId.MergeFrom(other.SrcId);
		}
		if (other.destId_ != null)
		{
			if (destId_ == null)
			{
				DestId = new ReferenceIdentifier();
			}
			DestId.MergeFrom(other.DestId);
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
				if (srcId_ == null)
				{
					SrcId = new ReferenceIdentifier();
				}
				input.ReadMessage(SrcId);
				break;
			case 18u:
				if (destId_ == null)
				{
					DestId = new ReferenceIdentifier();
				}
				input.ReadMessage(DestId);
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
