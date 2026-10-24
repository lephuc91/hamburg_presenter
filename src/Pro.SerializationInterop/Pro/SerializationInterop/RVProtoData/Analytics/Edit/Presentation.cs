using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Edit;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Presentation : IMessage<Presentation>, IMessage, IEquatable<Presentation>, IDeepCloneable<Presentation>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum ChangeType
		{
			[OriginalName("EDIT")]
			Edit,
			[OriginalName("UNDO")]
			Undo,
			[OriginalName("REDO")]
			Redo
		}
	}

	private static readonly MessageParser<Presentation> _parser = new MessageParser<Presentation>(() => new Presentation());

	private UnknownFieldSet _unknownFields;

	public const int ChangeTypeFieldNumber = 1;

	private Types.ChangeType changeType_;

	public const int UuidFieldNumber = 3;

	private string uuid_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Presentation> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsEditReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ChangeType ChangeType
	{
		get
		{
			return changeType_;
		}
		set
		{
			changeType_ = value;
		}
	}

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
	public Presentation()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Presentation(Presentation other)
		: this()
	{
		changeType_ = other.changeType_;
		uuid_ = other.uuid_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Presentation Clone()
	{
		return new Presentation(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Presentation);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Presentation other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ChangeType != other.ChangeType)
		{
			return false;
		}
		if (Uuid != other.Uuid)
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
		if (ChangeType != 0)
		{
			num ^= ChangeType.GetHashCode();
		}
		if (Uuid.Length != 0)
		{
			num ^= Uuid.GetHashCode();
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
		if (ChangeType != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)ChangeType);
		}
		if (Uuid.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Uuid);
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
		if (ChangeType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ChangeType);
		}
		if (Uuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Presentation other)
	{
		if (other != null)
		{
			if (other.ChangeType != 0)
			{
				ChangeType = other.ChangeType;
			}
			if (other.Uuid.Length != 0)
			{
				Uuid = other.Uuid;
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
			case 8u:
				ChangeType = (Types.ChangeType)input.ReadEnum();
				break;
			case 26u:
				Uuid = input.ReadString();
				break;
			}
		}
	}
}
