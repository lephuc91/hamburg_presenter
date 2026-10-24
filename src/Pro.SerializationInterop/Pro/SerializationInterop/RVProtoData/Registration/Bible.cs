using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Bible : IMessage<Bible>, IMessage, IEquatable<Bible>, IDeepCloneable<Bible>
{
	public enum AdditionalOneofCase
	{
		None = 0,
		Info = 9
	}

	private static readonly MessageParser<Bible> _parser = new MessageParser<Bible>(() => new Bible());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private string id_ = "";

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int LanguageFieldNumber = 3;

	private string language_ = "";

	public const int PublisherFieldNumber = 4;

	private string publisher_ = "";

	public const int CopyrightFieldNumber = 5;

	private string copyright_ = "";

	public const int DisplayAbbreviationFieldNumber = 6;

	private string displayAbbreviation_ = "";

	public const int InternalAbbreviationFieldNumber = 7;

	private string internalAbbreviation_ = "";

	public const int VersionFieldNumber = 8;

	private string version_ = "";

	public const int InfoFieldNumber = 9;

	private object additional_;

	private AdditionalOneofCase additionalCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Bible> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[47];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = ProtoPreconditions.CheckNotNull(value, "value");
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
	public string Language
	{
		get
		{
			return language_;
		}
		set
		{
			language_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Publisher
	{
		get
		{
			return publisher_;
		}
		set
		{
			publisher_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Copyright
	{
		get
		{
			return copyright_;
		}
		set
		{
			copyright_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DisplayAbbreviation
	{
		get
		{
			return displayAbbreviation_;
		}
		set
		{
			displayAbbreviation_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string InternalAbbreviation
	{
		get
		{
			return internalAbbreviation_;
		}
		set
		{
			internalAbbreviation_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Version
	{
		get
		{
			return version_;
		}
		set
		{
			version_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SupplementalInformation Info
	{
		get
		{
			if (additionalCase_ != AdditionalOneofCase.Info)
			{
				return null;
			}
			return (SupplementalInformation)additional_;
		}
		set
		{
			additional_ = value;
			additionalCase_ = ((value != null) ? AdditionalOneofCase.Info : AdditionalOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdditionalOneofCase AdditionalCase => additionalCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bible()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bible(Bible other)
		: this()
	{
		id_ = other.id_;
		name_ = other.name_;
		language_ = other.language_;
		publisher_ = other.publisher_;
		copyright_ = other.copyright_;
		displayAbbreviation_ = other.displayAbbreviation_;
		internalAbbreviation_ = other.internalAbbreviation_;
		version_ = other.version_;
		if (other.AdditionalCase == AdditionalOneofCase.Info)
		{
			Info = other.Info.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bible Clone()
	{
		return new Bible(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearAdditional()
	{
		additionalCase_ = AdditionalOneofCase.None;
		additional_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Bible);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Bible other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Id != other.Id)
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (Language != other.Language)
		{
			return false;
		}
		if (Publisher != other.Publisher)
		{
			return false;
		}
		if (Copyright != other.Copyright)
		{
			return false;
		}
		if (DisplayAbbreviation != other.DisplayAbbreviation)
		{
			return false;
		}
		if (InternalAbbreviation != other.InternalAbbreviation)
		{
			return false;
		}
		if (Version != other.Version)
		{
			return false;
		}
		if (!object.Equals(Info, other.Info))
		{
			return false;
		}
		if (AdditionalCase != other.AdditionalCase)
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
		if (Id.Length != 0)
		{
			num ^= Id.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (Language.Length != 0)
		{
			num ^= Language.GetHashCode();
		}
		if (Publisher.Length != 0)
		{
			num ^= Publisher.GetHashCode();
		}
		if (Copyright.Length != 0)
		{
			num ^= Copyright.GetHashCode();
		}
		if (DisplayAbbreviation.Length != 0)
		{
			num ^= DisplayAbbreviation.GetHashCode();
		}
		if (InternalAbbreviation.Length != 0)
		{
			num ^= InternalAbbreviation.GetHashCode();
		}
		if (Version.Length != 0)
		{
			num ^= Version.GetHashCode();
		}
		if (additionalCase_ == AdditionalOneofCase.Info)
		{
			num ^= Info.GetHashCode();
		}
		num ^= (int)additionalCase_;
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
		if (Id.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Id);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (Language.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(Language);
		}
		if (Publisher.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Publisher);
		}
		if (Copyright.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(Copyright);
		}
		if (DisplayAbbreviation.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(DisplayAbbreviation);
		}
		if (InternalAbbreviation.Length != 0)
		{
			output.WriteRawTag(58);
			output.WriteString(InternalAbbreviation);
		}
		if (Version.Length != 0)
		{
			output.WriteRawTag(66);
			output.WriteString(Version);
		}
		if (additionalCase_ == AdditionalOneofCase.Info)
		{
			output.WriteRawTag(74);
			output.WriteMessage(Info);
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
		if (Id.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Id);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (Language.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Language);
		}
		if (Publisher.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Publisher);
		}
		if (Copyright.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Copyright);
		}
		if (DisplayAbbreviation.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DisplayAbbreviation);
		}
		if (InternalAbbreviation.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(InternalAbbreviation);
		}
		if (Version.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Version);
		}
		if (additionalCase_ == AdditionalOneofCase.Info)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Info);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Bible other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Id.Length != 0)
		{
			Id = other.Id;
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.Language.Length != 0)
		{
			Language = other.Language;
		}
		if (other.Publisher.Length != 0)
		{
			Publisher = other.Publisher;
		}
		if (other.Copyright.Length != 0)
		{
			Copyright = other.Copyright;
		}
		if (other.DisplayAbbreviation.Length != 0)
		{
			DisplayAbbreviation = other.DisplayAbbreviation;
		}
		if (other.InternalAbbreviation.Length != 0)
		{
			InternalAbbreviation = other.InternalAbbreviation;
		}
		if (other.Version.Length != 0)
		{
			Version = other.Version;
		}
		if (other.AdditionalCase == AdditionalOneofCase.Info)
		{
			if (Info == null)
			{
				Info = new SupplementalInformation();
			}
			Info.MergeFrom(other.Info);
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
				Id = input.ReadString();
				break;
			case 18u:
				Name = input.ReadString();
				break;
			case 26u:
				Language = input.ReadString();
				break;
			case 34u:
				Publisher = input.ReadString();
				break;
			case 42u:
				Copyright = input.ReadString();
				break;
			case 50u:
				DisplayAbbreviation = input.ReadString();
				break;
			case 58u:
				InternalAbbreviation = input.ReadString();
				break;
			case 66u:
				Version = input.ReadString();
				break;
			case 74u:
			{
				SupplementalInformation supplementalInformation = new SupplementalInformation();
				if (additionalCase_ == AdditionalOneofCase.Info)
				{
					supplementalInformation.MergeFrom(Info);
				}
				input.ReadMessage(supplementalInformation);
				Info = supplementalInformation;
				break;
			}
			}
		}
	}
}
