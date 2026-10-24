using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TemplateIdentification : IMessage<TemplateIdentification>, IMessage, IEquatable<TemplateIdentification>, IDeepCloneable<TemplateIdentification>
{
	private static readonly MessageParser<TemplateIdentification> _parser = new MessageParser<TemplateIdentification>(() => new TemplateIdentification());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int SlideUuidFieldNumber = 3;

	private UUID slideUuid_;

	public const int SlideNameFieldNumber = 4;

	private string slideName_ = "";

	public const int SlideIndexFieldNumber = 5;

	private uint slideIndex_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TemplateIdentification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TemplateIdentificationReflection.Descriptor.MessageTypes[0];

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
	public UUID SlideUuid
	{
		get
		{
			return slideUuid_;
		}
		set
		{
			slideUuid_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string SlideName
	{
		get
		{
			return slideName_;
		}
		set
		{
			slideName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint SlideIndex
	{
		get
		{
			return slideIndex_;
		}
		set
		{
			slideIndex_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplateIdentification()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplateIdentification(TemplateIdentification other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		slideUuid_ = ((other.slideUuid_ != null) ? other.slideUuid_.Clone() : null);
		slideName_ = other.slideName_;
		slideIndex_ = other.slideIndex_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TemplateIdentification Clone()
	{
		return new TemplateIdentification(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TemplateIdentification);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TemplateIdentification other)
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
		if (!object.Equals(SlideUuid, other.SlideUuid))
		{
			return false;
		}
		if (SlideName != other.SlideName)
		{
			return false;
		}
		if (SlideIndex != other.SlideIndex)
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
		if (slideUuid_ != null)
		{
			num ^= SlideUuid.GetHashCode();
		}
		if (SlideName.Length != 0)
		{
			num ^= SlideName.GetHashCode();
		}
		if (SlideIndex != 0)
		{
			num ^= SlideIndex.GetHashCode();
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
		if (slideUuid_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(SlideUuid);
		}
		if (SlideName.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(SlideName);
		}
		if (SlideIndex != 0)
		{
			output.WriteRawTag(40);
			output.WriteUInt32(SlideIndex);
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
		if (slideUuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SlideUuid);
		}
		if (SlideName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(SlideName);
		}
		if (SlideIndex != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(SlideIndex);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TemplateIdentification other)
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
		if (other.slideUuid_ != null)
		{
			if (slideUuid_ == null)
			{
				SlideUuid = new UUID();
			}
			SlideUuid.MergeFrom(other.SlideUuid);
		}
		if (other.SlideName.Length != 0)
		{
			SlideName = other.SlideName;
		}
		if (other.SlideIndex != 0)
		{
			SlideIndex = other.SlideIndex;
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
				if (slideUuid_ == null)
				{
					SlideUuid = new UUID();
				}
				input.ReadMessage(SlideUuid);
				break;
			case 34u:
				SlideName = input.ReadString();
				break;
			case 40u:
				SlideIndex = input.ReadUInt32();
				break;
			}
		}
	}
}
