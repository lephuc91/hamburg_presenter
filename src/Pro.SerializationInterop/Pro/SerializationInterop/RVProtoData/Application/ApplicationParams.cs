using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Application;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ApplicationParams : IMessage<ApplicationParams>, IMessage, IEquatable<ApplicationParams>, IDeepCloneable<ApplicationParams>
{
	private static readonly MessageParser<ApplicationParams> _parser = new MessageParser<ApplicationParams>(() => new ApplicationParams());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int ProductInfoFieldNumber = 1;

	private ProductInformation productInfo_;

	public const int EnabledFeaturesFieldNumber = 2;

	private static readonly FieldCodec<string> _repeated_enabledFeatures_codec = FieldCodec.ForString(18u);

	private readonly RepeatedField<string> enabledFeatures_ = new RepeatedField<string>();

	public const int PeerIdFieldNumber = 3;

	private static readonly ulong PeerIdDefaultValue = 0uL;

	private ulong peerId_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ApplicationParams> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ParamsReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProductInformation ProductInfo
	{
		get
		{
			return productInfo_;
		}
		set
		{
			productInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<string> EnabledFeatures => enabledFeatures_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong PeerId
	{
		get
		{
			if ((_hasBits0 & 1) != 0)
			{
				return peerId_;
			}
			return PeerIdDefaultValue;
		}
		set
		{
			_hasBits0 |= 1;
			peerId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasPeerId => (_hasBits0 & 1) != 0;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationParams()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationParams(ApplicationParams other)
		: this()
	{
		_hasBits0 = other._hasBits0;
		productInfo_ = ((other.productInfo_ != null) ? other.productInfo_.Clone() : null);
		enabledFeatures_ = other.enabledFeatures_.Clone();
		peerId_ = other.peerId_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationParams Clone()
	{
		return new ApplicationParams(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearPeerId()
	{
		_hasBits0 &= -2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ApplicationParams);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ApplicationParams other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(ProductInfo, other.ProductInfo))
		{
			return false;
		}
		if (!enabledFeatures_.Equals(other.enabledFeatures_))
		{
			return false;
		}
		if (PeerId != other.PeerId)
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
		if (productInfo_ != null)
		{
			num ^= ProductInfo.GetHashCode();
		}
		num ^= enabledFeatures_.GetHashCode();
		if (HasPeerId)
		{
			num ^= PeerId.GetHashCode();
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
		if (productInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ProductInfo);
		}
		enabledFeatures_.WriteTo(output, _repeated_enabledFeatures_codec);
		if (HasPeerId)
		{
			output.WriteRawTag(24);
			output.WriteUInt64(PeerId);
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
		if (productInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ProductInfo);
		}
		num += enabledFeatures_.CalculateSize(_repeated_enabledFeatures_codec);
		if (HasPeerId)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(PeerId);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ApplicationParams other)
	{
		if (other == null)
		{
			return;
		}
		if (other.productInfo_ != null)
		{
			if (productInfo_ == null)
			{
				ProductInfo = new ProductInformation();
			}
			ProductInfo.MergeFrom(other.ProductInfo);
		}
		enabledFeatures_.Add(other.enabledFeatures_);
		if (other.HasPeerId)
		{
			PeerId = other.PeerId;
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
				if (productInfo_ == null)
				{
					ProductInfo = new ProductInformation();
				}
				input.ReadMessage(ProductInfo);
				break;
			case 18u:
				enabledFeatures_.AddEntriesFrom(input, _repeated_enabledFeatures_codec);
				break;
			case 24u:
				PeerId = input.ReadUInt64();
				break;
			}
		}
	}
}
