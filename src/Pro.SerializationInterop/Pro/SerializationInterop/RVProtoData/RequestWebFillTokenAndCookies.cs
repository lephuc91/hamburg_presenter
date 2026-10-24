using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RequestWebFillTokenAndCookies : IMessage<RequestWebFillTokenAndCookies>, IMessage, IEquatable<RequestWebFillTokenAndCookies>, IDeepCloneable<RequestWebFillTokenAndCookies>
{
	private static readonly MessageParser<RequestWebFillTokenAndCookies> _parser = new MessageParser<RequestWebFillTokenAndCookies>(() => new RequestWebFillTokenAndCookies());

	private UnknownFieldSet _unknownFields;

	public const int RefreshFirstFieldNumber = 1;

	private bool refreshFirst_;

	public const int LinkFieldNumber = 2;

	private string link_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RequestWebFillTokenAndCookies> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[30];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool RefreshFirst
	{
		get
		{
			return refreshFirst_;
		}
		set
		{
			refreshFirst_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Link
	{
		get
		{
			return link_;
		}
		set
		{
			link_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestWebFillTokenAndCookies()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestWebFillTokenAndCookies(RequestWebFillTokenAndCookies other)
		: this()
	{
		refreshFirst_ = other.refreshFirst_;
		link_ = other.link_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestWebFillTokenAndCookies Clone()
	{
		return new RequestWebFillTokenAndCookies(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RequestWebFillTokenAndCookies);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RequestWebFillTokenAndCookies other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (RefreshFirst != other.RefreshFirst)
		{
			return false;
		}
		if (Link != other.Link)
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
		if (RefreshFirst)
		{
			num ^= RefreshFirst.GetHashCode();
		}
		if (Link.Length != 0)
		{
			num ^= Link.GetHashCode();
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
		if (RefreshFirst)
		{
			output.WriteRawTag(8);
			output.WriteBool(RefreshFirst);
		}
		if (Link.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Link);
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
		if (RefreshFirst)
		{
			num += 2;
		}
		if (Link.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Link);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RequestWebFillTokenAndCookies other)
	{
		if (other != null)
		{
			if (other.RefreshFirst)
			{
				RefreshFirst = other.RefreshFirst;
			}
			if (other.Link.Length != 0)
			{
				Link = other.Link;
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
				RefreshFirst = input.ReadBool();
				break;
			case 18u:
				Link = input.ReadString();
				break;
			}
		}
	}
}
