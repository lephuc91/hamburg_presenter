using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class KeyMapping : IMessage<KeyMapping>, IMessage, IEquatable<KeyMapping>, IDeepCloneable<KeyMapping>
{
	private static readonly MessageParser<KeyMapping> _parser = new MessageParser<KeyMapping>(() => new KeyMapping());

	private UnknownFieldSet _unknownFields;

	public const int TotalMappedFieldNumber = 1;

	private int totalMapped_;

	public const int ClearGroupsFieldNumber = 2;

	private int clearGroups_;

	public const int GroupsFieldNumber = 3;

	private int groups_;

	public const int MacrosFieldNumber = 4;

	private int macros_;

	public const int PropsFieldNumber = 5;

	private int props_;

	public const int MenusFieldNumber = 6;

	private int menus_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<KeyMapping> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[14];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalMapped
	{
		get
		{
			return totalMapped_;
		}
		set
		{
			totalMapped_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ClearGroups
	{
		get
		{
			return clearGroups_;
		}
		set
		{
			clearGroups_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Groups
	{
		get
		{
			return groups_;
		}
		set
		{
			groups_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Macros
	{
		get
		{
			return macros_;
		}
		set
		{
			macros_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Props
	{
		get
		{
			return props_;
		}
		set
		{
			props_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Menus
	{
		get
		{
			return menus_;
		}
		set
		{
			menus_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMapping()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMapping(KeyMapping other)
		: this()
	{
		totalMapped_ = other.totalMapped_;
		clearGroups_ = other.clearGroups_;
		groups_ = other.groups_;
		macros_ = other.macros_;
		props_ = other.props_;
		menus_ = other.menus_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public KeyMapping Clone()
	{
		return new KeyMapping(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as KeyMapping);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(KeyMapping other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TotalMapped != other.TotalMapped)
		{
			return false;
		}
		if (ClearGroups != other.ClearGroups)
		{
			return false;
		}
		if (Groups != other.Groups)
		{
			return false;
		}
		if (Macros != other.Macros)
		{
			return false;
		}
		if (Props != other.Props)
		{
			return false;
		}
		if (Menus != other.Menus)
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
		if (TotalMapped != 0)
		{
			num ^= TotalMapped.GetHashCode();
		}
		if (ClearGroups != 0)
		{
			num ^= ClearGroups.GetHashCode();
		}
		if (Groups != 0)
		{
			num ^= Groups.GetHashCode();
		}
		if (Macros != 0)
		{
			num ^= Macros.GetHashCode();
		}
		if (Props != 0)
		{
			num ^= Props.GetHashCode();
		}
		if (Menus != 0)
		{
			num ^= Menus.GetHashCode();
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
		if (TotalMapped != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TotalMapped);
		}
		if (ClearGroups != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(ClearGroups);
		}
		if (Groups != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(Groups);
		}
		if (Macros != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(Macros);
		}
		if (Props != 0)
		{
			output.WriteRawTag(40);
			output.WriteInt32(Props);
		}
		if (Menus != 0)
		{
			output.WriteRawTag(48);
			output.WriteInt32(Menus);
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
		if (TotalMapped != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalMapped);
		}
		if (ClearGroups != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ClearGroups);
		}
		if (Groups != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Groups);
		}
		if (Macros != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Macros);
		}
		if (Props != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Props);
		}
		if (Menus != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Menus);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(KeyMapping other)
	{
		if (other != null)
		{
			if (other.TotalMapped != 0)
			{
				TotalMapped = other.TotalMapped;
			}
			if (other.ClearGroups != 0)
			{
				ClearGroups = other.ClearGroups;
			}
			if (other.Groups != 0)
			{
				Groups = other.Groups;
			}
			if (other.Macros != 0)
			{
				Macros = other.Macros;
			}
			if (other.Props != 0)
			{
				Props = other.Props;
			}
			if (other.Menus != 0)
			{
				Menus = other.Menus;
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
				TotalMapped = input.ReadInt32();
				break;
			case 16u:
				ClearGroups = input.ReadInt32();
				break;
			case 24u:
				Groups = input.ReadInt32();
				break;
			case 32u:
				Macros = input.ReadInt32();
				break;
			case 40u:
				Props = input.ReadInt32();
				break;
			case 48u:
				Menus = input.ReadInt32();
				break;
			}
		}
	}
}
