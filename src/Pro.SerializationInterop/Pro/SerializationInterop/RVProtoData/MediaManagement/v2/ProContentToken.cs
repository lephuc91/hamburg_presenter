using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProContentToken : IMessage<ProContentToken>, IMessage, IEquatable<ProContentToken>, IDeepCloneable<ProContentToken>
{
	private static readonly MessageParser<ProContentToken> _parser = new MessageParser<ProContentToken>(() => new ProContentToken());

	private UnknownFieldSet _unknownFields;

	public const int AccessFieldNumber = 1;

	private string access_ = "";

	public const int RefreshFieldNumber = 2;

	private string refresh_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProContentToken> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Access
	{
		get
		{
			return access_;
		}
		set
		{
			access_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Refresh
	{
		get
		{
			return refresh_;
		}
		set
		{
			refresh_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProContentToken()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProContentToken(ProContentToken other)
		: this()
	{
		access_ = other.access_;
		refresh_ = other.refresh_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProContentToken Clone()
	{
		return new ProContentToken(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProContentToken);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProContentToken other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Access != other.Access)
		{
			return false;
		}
		if (Refresh != other.Refresh)
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
		if (Access.Length != 0)
		{
			num ^= Access.GetHashCode();
		}
		if (Refresh.Length != 0)
		{
			num ^= Refresh.GetHashCode();
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
		if (Access.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Access);
		}
		if (Refresh.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Refresh);
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
		if (Access.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Access);
		}
		if (Refresh.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Refresh);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProContentToken other)
	{
		if (other != null)
		{
			if (other.Access.Length != 0)
			{
				Access = other.Access;
			}
			if (other.Refresh.Length != 0)
			{
				Refresh = other.Refresh;
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
			case 10u:
				Access = input.ReadString();
				break;
			case 18u:
				Refresh = input.ReadString();
				break;
			}
		}
	}
}
