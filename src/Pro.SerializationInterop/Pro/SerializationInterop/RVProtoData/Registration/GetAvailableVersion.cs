using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class GetAvailableVersion : IMessage<GetAvailableVersion>, IMessage, IEquatable<GetAvailableVersion>, IDeepCloneable<GetAvailableVersion>
{
	private static readonly MessageParser<GetAvailableVersion> _parser = new MessageParser<GetAvailableVersion>(() => new GetAvailableVersion());

	private UnknownFieldSet _unknownFields;

	public const int IncludeNotesFieldNumber = 1;

	private bool includeNotes_;

	public const int ChannelFieldNumber = 2;

	private string channel_ = "";

	public const int FormatFieldNumber = 3;

	private string format_ = "";

	public const int UserInitiatedFieldNumber = 4;

	private bool userInitiated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<GetAvailableVersion> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[13];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IncludeNotes
	{
		get
		{
			return includeNotes_;
		}
		set
		{
			includeNotes_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Channel
	{
		get
		{
			return channel_;
		}
		set
		{
			channel_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Format
	{
		get
		{
			return format_;
		}
		set
		{
			format_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool UserInitiated
	{
		get
		{
			return userInitiated_;
		}
		set
		{
			userInitiated_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetAvailableVersion()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetAvailableVersion(GetAvailableVersion other)
		: this()
	{
		includeNotes_ = other.includeNotes_;
		channel_ = other.channel_;
		format_ = other.format_;
		userInitiated_ = other.userInitiated_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetAvailableVersion Clone()
	{
		return new GetAvailableVersion(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as GetAvailableVersion);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(GetAvailableVersion other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (IncludeNotes != other.IncludeNotes)
		{
			return false;
		}
		if (Channel != other.Channel)
		{
			return false;
		}
		if (Format != other.Format)
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
		if (IncludeNotes)
		{
			num ^= IncludeNotes.GetHashCode();
		}
		if (Channel.Length != 0)
		{
			num ^= Channel.GetHashCode();
		}
		if (Format.Length != 0)
		{
			num ^= Format.GetHashCode();
		}
		if (UserInitiated)
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
		if (IncludeNotes)
		{
			output.WriteRawTag(8);
			output.WriteBool(IncludeNotes);
		}
		if (Channel.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Channel);
		}
		if (Format.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Format);
		}
		if (UserInitiated)
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
		if (IncludeNotes)
		{
			num += 2;
		}
		if (Channel.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Channel);
		}
		if (Format.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Format);
		}
		if (UserInitiated)
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
	public void MergeFrom(GetAvailableVersion other)
	{
		if (other != null)
		{
			if (other.IncludeNotes)
			{
				IncludeNotes = other.IncludeNotes;
			}
			if (other.Channel.Length != 0)
			{
				Channel = other.Channel;
			}
			if (other.Format.Length != 0)
			{
				Format = other.Format;
			}
			if (other.UserInitiated)
			{
				UserInitiated = other.UserInitiated;
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
				IncludeNotes = input.ReadBool();
				break;
			case 18u:
				Channel = input.ReadString();
				break;
			case 26u:
				Format = input.ReadString();
				break;
			case 32u:
				UserInitiated = input.ReadBool();
				break;
			}
		}
	}
}
