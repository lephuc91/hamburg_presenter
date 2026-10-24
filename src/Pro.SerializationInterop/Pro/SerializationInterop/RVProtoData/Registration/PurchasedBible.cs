using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PurchasedBible : IMessage<PurchasedBible>, IMessage, IEquatable<PurchasedBible>, IDeepCloneable<PurchasedBible>
{
	private static readonly MessageParser<PurchasedBible> _parser = new MessageParser<PurchasedBible>(() => new PurchasedBible());

	private UnknownFieldSet _unknownFields;

	public const int MetadataFieldNumber = 1;

	private Bible metadata_;

	public const int LicensingInfoFieldNumber = 2;

	private LicensingInfo licensingInfo_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PurchasedBible> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[48];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bible Metadata
	{
		get
		{
			return metadata_;
		}
		set
		{
			metadata_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicensingInfo LicensingInfo
	{
		get
		{
			return licensingInfo_;
		}
		set
		{
			licensingInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PurchasedBible()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PurchasedBible(PurchasedBible other)
		: this()
	{
		metadata_ = ((other.metadata_ != null) ? other.metadata_.Clone() : null);
		licensingInfo_ = ((other.licensingInfo_ != null) ? other.licensingInfo_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PurchasedBible Clone()
	{
		return new PurchasedBible(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PurchasedBible);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PurchasedBible other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Metadata, other.Metadata))
		{
			return false;
		}
		if (!object.Equals(LicensingInfo, other.LicensingInfo))
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
		if (metadata_ != null)
		{
			num ^= Metadata.GetHashCode();
		}
		if (licensingInfo_ != null)
		{
			num ^= LicensingInfo.GetHashCode();
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
		if (metadata_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Metadata);
		}
		if (licensingInfo_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(LicensingInfo);
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
		if (metadata_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Metadata);
		}
		if (licensingInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LicensingInfo);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PurchasedBible other)
	{
		if (other == null)
		{
			return;
		}
		if (other.metadata_ != null)
		{
			if (metadata_ == null)
			{
				Metadata = new Bible();
			}
			Metadata.MergeFrom(other.Metadata);
		}
		if (other.licensingInfo_ != null)
		{
			if (licensingInfo_ == null)
			{
				LicensingInfo = new LicensingInfo();
			}
			LicensingInfo.MergeFrom(other.LicensingInfo);
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
				if (metadata_ == null)
				{
					Metadata = new Bible();
				}
				input.ReadMessage(Metadata);
				break;
			case 18u:
				if (licensingInfo_ == null)
				{
					LicensingInfo = new LicensingInfo();
				}
				input.ReadMessage(LicensingInfo);
				break;
			}
		}
	}
}
