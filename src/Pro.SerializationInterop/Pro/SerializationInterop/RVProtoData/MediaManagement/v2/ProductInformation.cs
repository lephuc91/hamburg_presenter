using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProductInformation : IMessage<ProductInformation>, IMessage, IEquatable<ProductInformation>, IDeepCloneable<ProductInformation>
{
	private static readonly MessageParser<ProductInformation> _parser = new MessageParser<ProductInformation>(() => new ProductInformation());

	private UnknownFieldSet _unknownFields;

	public const int ProductNameFieldNumber = 1;

	private string productName_ = "";

	public const int MajorVersionFieldNumber = 2;

	private string majorVersion_ = "";

	public const int MinorVersionFieldNumber = 3;

	private string minorVersion_ = "";

	public const int PatchVersionFieldNumber = 4;

	private string patchVersion_ = "";

	public const int BuildNumberFieldNumber = 5;

	private string buildNumber_ = "";

	public const int BuildDateFieldNumber = 6;

	private long buildDate_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProductInformation> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ProductName
	{
		get
		{
			return productName_;
		}
		set
		{
			productName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MajorVersion
	{
		get
		{
			return majorVersion_;
		}
		set
		{
			majorVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string MinorVersion
	{
		get
		{
			return minorVersion_;
		}
		set
		{
			minorVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string PatchVersion
	{
		get
		{
			return patchVersion_;
		}
		set
		{
			patchVersion_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string BuildNumber
	{
		get
		{
			return buildNumber_;
		}
		set
		{
			buildNumber_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public long BuildDate
	{
		get
		{
			return buildDate_;
		}
		set
		{
			buildDate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProductInformation()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProductInformation(ProductInformation other)
		: this()
	{
		productName_ = other.productName_;
		majorVersion_ = other.majorVersion_;
		minorVersion_ = other.minorVersion_;
		patchVersion_ = other.patchVersion_;
		buildNumber_ = other.buildNumber_;
		buildDate_ = other.buildDate_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProductInformation Clone()
	{
		return new ProductInformation(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProductInformation);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProductInformation other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ProductName != other.ProductName)
		{
			return false;
		}
		if (MajorVersion != other.MajorVersion)
		{
			return false;
		}
		if (MinorVersion != other.MinorVersion)
		{
			return false;
		}
		if (PatchVersion != other.PatchVersion)
		{
			return false;
		}
		if (BuildNumber != other.BuildNumber)
		{
			return false;
		}
		if (BuildDate != other.BuildDate)
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
		if (ProductName.Length != 0)
		{
			num ^= ProductName.GetHashCode();
		}
		if (MajorVersion.Length != 0)
		{
			num ^= MajorVersion.GetHashCode();
		}
		if (MinorVersion.Length != 0)
		{
			num ^= MinorVersion.GetHashCode();
		}
		if (PatchVersion.Length != 0)
		{
			num ^= PatchVersion.GetHashCode();
		}
		if (BuildNumber.Length != 0)
		{
			num ^= BuildNumber.GetHashCode();
		}
		if (BuildDate != 0L)
		{
			num ^= BuildDate.GetHashCode();
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
		if (ProductName.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(ProductName);
		}
		if (MajorVersion.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(MajorVersion);
		}
		if (MinorVersion.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(MinorVersion);
		}
		if (PatchVersion.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(PatchVersion);
		}
		if (BuildNumber.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(BuildNumber);
		}
		if (BuildDate != 0L)
		{
			output.WriteRawTag(48);
			output.WriteInt64(BuildDate);
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
		if (ProductName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ProductName);
		}
		if (MajorVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(MajorVersion);
		}
		if (MinorVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(MinorVersion);
		}
		if (PatchVersion.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(PatchVersion);
		}
		if (BuildNumber.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BuildNumber);
		}
		if (BuildDate != 0L)
		{
			num += 1 + CodedOutputStream.ComputeInt64Size(BuildDate);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProductInformation other)
	{
		if (other != null)
		{
			if (other.ProductName.Length != 0)
			{
				ProductName = other.ProductName;
			}
			if (other.MajorVersion.Length != 0)
			{
				MajorVersion = other.MajorVersion;
			}
			if (other.MinorVersion.Length != 0)
			{
				MinorVersion = other.MinorVersion;
			}
			if (other.PatchVersion.Length != 0)
			{
				PatchVersion = other.PatchVersion;
			}
			if (other.BuildNumber.Length != 0)
			{
				BuildNumber = other.BuildNumber;
			}
			if (other.BuildDate != 0L)
			{
				BuildDate = other.BuildDate;
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
				ProductName = input.ReadString();
				break;
			case 18u:
				MajorVersion = input.ReadString();
				break;
			case 26u:
				MinorVersion = input.ReadString();
				break;
			case 34u:
				PatchVersion = input.ReadString();
				break;
			case 42u:
				BuildNumber = input.ReadString();
				break;
			case 48u:
				BuildDate = input.ReadInt64();
				break;
			}
		}
	}
}
