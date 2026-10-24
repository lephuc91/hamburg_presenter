using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ActiveCopy : IMessage<ActiveCopy>, IMessage, IEquatable<ActiveCopy>, IDeepCloneable<ActiveCopy>
{
	private static readonly MessageParser<ActiveCopy> _parser = new MessageParser<ActiveCopy>(() => new ActiveCopy());

	private UnknownFieldSet _unknownFields;

	public const int DisplayNameFieldNumber = 1;

	private string displayName_ = "";

	public const int HostnameFieldNumber = 2;

	private string hostname_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ActiveCopy> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[51];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DisplayName
	{
		get
		{
			return displayName_;
		}
		set
		{
			displayName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Hostname
	{
		get
		{
			return hostname_;
		}
		set
		{
			hostname_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActiveCopy()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActiveCopy(ActiveCopy other)
		: this()
	{
		displayName_ = other.displayName_;
		hostname_ = other.hostname_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActiveCopy Clone()
	{
		return new ActiveCopy(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ActiveCopy);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ActiveCopy other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (DisplayName != other.DisplayName)
		{
			return false;
		}
		if (Hostname != other.Hostname)
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
		if (DisplayName.Length != 0)
		{
			num ^= DisplayName.GetHashCode();
		}
		if (Hostname.Length != 0)
		{
			num ^= Hostname.GetHashCode();
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
		if (DisplayName.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(DisplayName);
		}
		if (Hostname.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Hostname);
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
		if (DisplayName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DisplayName);
		}
		if (Hostname.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Hostname);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ActiveCopy other)
	{
		if (other != null)
		{
			if (other.DisplayName.Length != 0)
			{
				DisplayName = other.DisplayName;
			}
			if (other.Hostname.Length != 0)
			{
				Hostname = other.Hostname;
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
				DisplayName = input.ReadString();
				break;
			case 18u:
				Hostname = input.ReadString();
				break;
			}
		}
	}
}
