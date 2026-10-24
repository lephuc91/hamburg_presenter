using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Group : IMessage<Group>, IMessage, IEquatable<Group>, IDeepCloneable<Group>
{
	private static readonly MessageParser<Group> _parser = new MessageParser<Group>(() => new Group());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int ColorFieldNumber = 3;

	private Color color_;

	public const int HotKeyFieldNumber = 4;

	private HotKey hotKey_;

	public const int ApplicationGroupIdentifierFieldNumber = 5;

	private UUID applicationGroupIdentifier_;

	public const int ApplicationGroupNameFieldNumber = 6;

	private string applicationGroupName_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Group> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => GroupsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
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
	public Color Color
	{
		get
		{
			return color_;
		}
		set
		{
			color_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HotKey HotKey
	{
		get
		{
			return hotKey_;
		}
		set
		{
			hotKey_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID ApplicationGroupIdentifier
	{
		get
		{
			return applicationGroupIdentifier_;
		}
		set
		{
			applicationGroupIdentifier_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ApplicationGroupName
	{
		get
		{
			return applicationGroupName_;
		}
		set
		{
			applicationGroupName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Group()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Group(Group other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		color_ = ((other.color_ != null) ? other.color_.Clone() : null);
		hotKey_ = ((other.hotKey_ != null) ? other.hotKey_.Clone() : null);
		applicationGroupIdentifier_ = ((other.applicationGroupIdentifier_ != null) ? other.applicationGroupIdentifier_.Clone() : null);
		applicationGroupName_ = other.applicationGroupName_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Group Clone()
	{
		return new Group(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Group);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Group other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (!object.Equals(Color, other.Color))
		{
			return false;
		}
		if (!object.Equals(HotKey, other.HotKey))
		{
			return false;
		}
		if (!object.Equals(ApplicationGroupIdentifier, other.ApplicationGroupIdentifier))
		{
			return false;
		}
		if (ApplicationGroupName != other.ApplicationGroupName)
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (color_ != null)
		{
			num ^= Color.GetHashCode();
		}
		if (hotKey_ != null)
		{
			num ^= HotKey.GetHashCode();
		}
		if (applicationGroupIdentifier_ != null)
		{
			num ^= ApplicationGroupIdentifier.GetHashCode();
		}
		if (ApplicationGroupName.Length != 0)
		{
			num ^= ApplicationGroupName.GetHashCode();
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (color_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Color);
		}
		if (hotKey_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(HotKey);
		}
		if (applicationGroupIdentifier_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ApplicationGroupIdentifier);
		}
		if (ApplicationGroupName.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(ApplicationGroupName);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (color_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Color);
		}
		if (hotKey_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HotKey);
		}
		if (applicationGroupIdentifier_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplicationGroupIdentifier);
		}
		if (ApplicationGroupName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ApplicationGroupName);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Group other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.color_ != null)
		{
			if (color_ == null)
			{
				Color = new Color();
			}
			Color.MergeFrom(other.Color);
		}
		if (other.hotKey_ != null)
		{
			if (hotKey_ == null)
			{
				HotKey = new HotKey();
			}
			HotKey.MergeFrom(other.HotKey);
		}
		if (other.applicationGroupIdentifier_ != null)
		{
			if (applicationGroupIdentifier_ == null)
			{
				ApplicationGroupIdentifier = new UUID();
			}
			ApplicationGroupIdentifier.MergeFrom(other.ApplicationGroupIdentifier);
		}
		if (other.ApplicationGroupName.Length != 0)
		{
			ApplicationGroupName = other.ApplicationGroupName;
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				Name = input.ReadString();
				break;
			case 26u:
				if (color_ == null)
				{
					Color = new Color();
				}
				input.ReadMessage(Color);
				break;
			case 34u:
				if (hotKey_ == null)
				{
					HotKey = new HotKey();
				}
				input.ReadMessage(HotKey);
				break;
			case 42u:
				if (applicationGroupIdentifier_ == null)
				{
					ApplicationGroupIdentifier = new UUID();
				}
				input.ReadMessage(ApplicationGroupIdentifier);
				break;
			case 50u:
				ApplicationGroupName = input.ReadString();
				break;
			}
		}
	}
}
