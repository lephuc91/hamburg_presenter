using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_GroupDefinition : IMessage<API_v1_GroupDefinition>, IMessage, IEquatable<API_v1_GroupDefinition>, IDeepCloneable<API_v1_GroupDefinition>
{
	private static readonly MessageParser<API_v1_GroupDefinition> _parser = new MessageParser<API_v1_GroupDefinition>(() => new API_v1_GroupDefinition());

	private UnknownFieldSet _unknownFields;

	public const int TimestampFieldNumber = 1;

	private Timestamp timestamp_;

	public const int SecretFieldNumber = 2;

	private string secret_ = "";

	public const int NameFieldNumber = 3;

	private string name_ = "";

	public const int MembersFieldNumber = 4;

	private static readonly FieldCodec<API_v1_GroupMember> _repeated_members_codec = FieldCodec.ForMessage(34u, API_v1_GroupMember.Parser);

	private readonly RepeatedField<API_v1_GroupMember> members_ = new RepeatedField<API_v1_GroupMember>();

	public const int GroupIdentifierFieldNumber = 5;

	private UUID groupIdentifier_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_GroupDefinition> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LinkReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Timestamp Timestamp
	{
		get
		{
			return timestamp_;
		}
		set
		{
			timestamp_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Secret
	{
		get
		{
			return secret_;
		}
		set
		{
			secret_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			return name_;
		}
		set
		{
			name_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<API_v1_GroupMember> Members => members_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID GroupIdentifier
	{
		get
		{
			return groupIdentifier_;
		}
		set
		{
			groupIdentifier_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupDefinition()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupDefinition(API_v1_GroupDefinition other)
		: this()
	{
		timestamp_ = ((other.timestamp_ != null) ? other.timestamp_.Clone() : null);
		secret_ = other.secret_;
		name_ = other.name_;
		members_ = other.members_.Clone();
		groupIdentifier_ = ((other.groupIdentifier_ != null) ? other.groupIdentifier_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_GroupDefinition Clone()
	{
		return new API_v1_GroupDefinition(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_GroupDefinition);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_GroupDefinition other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Timestamp, other.Timestamp))
		{
			return false;
		}
		if (Secret != other.Secret)
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (!members_.Equals(other.members_))
		{
			return false;
		}
		if (!object.Equals(GroupIdentifier, other.GroupIdentifier))
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
		if (timestamp_ != null)
		{
			num ^= Timestamp.GetHashCode();
		}
		if (Secret.Length != 0)
		{
			num ^= Secret.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		num ^= members_.GetHashCode();
		if (groupIdentifier_ != null)
		{
			num ^= GroupIdentifier.GetHashCode();
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
		if (timestamp_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Timestamp);
		}
		if (Secret.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Secret);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Name);
		}
		members_.WriteTo(output, _repeated_members_codec);
		if (groupIdentifier_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GroupIdentifier);
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
		if (timestamp_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Timestamp);
		}
		if (Secret.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Secret);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		num += members_.CalculateSize(_repeated_members_codec);
		if (groupIdentifier_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GroupIdentifier);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_GroupDefinition other)
	{
		if (other == null)
		{
			return;
		}
		if (other.timestamp_ != null)
		{
			if (timestamp_ == null)
			{
				Timestamp = new Timestamp();
			}
			Timestamp.MergeFrom(other.Timestamp);
		}
		if (other.Secret.Length != 0)
		{
			Secret = other.Secret;
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		members_.Add(other.members_);
		if (other.groupIdentifier_ != null)
		{
			if (groupIdentifier_ == null)
			{
				GroupIdentifier = new UUID();
			}
			GroupIdentifier.MergeFrom(other.GroupIdentifier);
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
				if (timestamp_ == null)
				{
					Timestamp = new Timestamp();
				}
				input.ReadMessage(Timestamp);
				break;
			case 18u:
				Secret = input.ReadString();
				break;
			case 26u:
				Name = input.ReadString();
				break;
			case 34u:
				members_.AddEntriesFrom(input, _repeated_members_codec);
				break;
			case 42u:
				if (groupIdentifier_ == null)
				{
					GroupIdentifier = new UUID();
				}
				input.ReadMessage(GroupIdentifier);
				break;
			}
		}
	}
}
