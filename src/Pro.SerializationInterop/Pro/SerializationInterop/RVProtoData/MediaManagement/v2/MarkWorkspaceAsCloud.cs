using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MarkWorkspaceAsCloud : IMessage<MarkWorkspaceAsCloud>, IMessage, IEquatable<MarkWorkspaceAsCloud>, IDeepCloneable<MarkWorkspaceAsCloud>
{
	private static readonly MessageParser<MarkWorkspaceAsCloud> _parser = new MessageParser<MarkWorkspaceAsCloud>(() => new MarkWorkspaceAsCloud());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private string uuid_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MarkWorkspaceAsCloud> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[27];

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
	public MarkWorkspaceAsCloud()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MarkWorkspaceAsCloud(MarkWorkspaceAsCloud other)
		: this()
	{
		uuid_ = other.uuid_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MarkWorkspaceAsCloud Clone()
	{
		return new MarkWorkspaceAsCloud(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MarkWorkspaceAsCloud);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MarkWorkspaceAsCloud other)
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
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MarkWorkspaceAsCloud other)
	{
		if (other != null)
		{
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				Uuid = input.ReadString();
			}
		}
	}
}
