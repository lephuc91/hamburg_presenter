using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LicensingInfo : IMessage<LicensingInfo>, IMessage, IEquatable<LicensingInfo>, IDeepCloneable<LicensingInfo>
{
	private static readonly MessageParser<LicensingInfo> _parser = new MessageParser<LicensingInfo>(() => new LicensingInfo());

	private UnknownFieldSet _unknownFields;

	public const int AvailableCopiesFieldNumber = 1;

	private int availableCopies_;

	public const int TotalCopiesFieldNumber = 2;

	private int totalCopies_;

	public const int IsActiveLocallyFieldNumber = 3;

	private bool isActiveLocally_;

	public const int OtherActiveCopiesFieldNumber = 4;

	private static readonly FieldCodec<ActiveCopy> _repeated_otherActiveCopies_codec = FieldCodec.ForMessage(34u, ActiveCopy.Parser);

	private readonly RepeatedField<ActiveCopy> otherActiveCopies_ = new RepeatedField<ActiveCopy>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LicensingInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[50];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int AvailableCopies
	{
		get
		{
			return availableCopies_;
		}
		set
		{
			availableCopies_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalCopies
	{
		get
		{
			return totalCopies_;
		}
		set
		{
			totalCopies_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsActiveLocally
	{
		get
		{
			return isActiveLocally_;
		}
		set
		{
			isActiveLocally_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<ActiveCopy> OtherActiveCopies => otherActiveCopies_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicensingInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicensingInfo(LicensingInfo other)
		: this()
	{
		availableCopies_ = other.availableCopies_;
		totalCopies_ = other.totalCopies_;
		isActiveLocally_ = other.isActiveLocally_;
		otherActiveCopies_ = other.otherActiveCopies_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicensingInfo Clone()
	{
		return new LicensingInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LicensingInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LicensingInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (AvailableCopies != other.AvailableCopies)
		{
			return false;
		}
		if (TotalCopies != other.TotalCopies)
		{
			return false;
		}
		if (IsActiveLocally != other.IsActiveLocally)
		{
			return false;
		}
		if (!otherActiveCopies_.Equals(other.otherActiveCopies_))
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
		if (AvailableCopies != 0)
		{
			num ^= AvailableCopies.GetHashCode();
		}
		if (TotalCopies != 0)
		{
			num ^= TotalCopies.GetHashCode();
		}
		if (IsActiveLocally)
		{
			num ^= IsActiveLocally.GetHashCode();
		}
		num ^= otherActiveCopies_.GetHashCode();
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
		if (AvailableCopies != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(AvailableCopies);
		}
		if (TotalCopies != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(TotalCopies);
		}
		if (IsActiveLocally)
		{
			output.WriteRawTag(24);
			output.WriteBool(IsActiveLocally);
		}
		otherActiveCopies_.WriteTo(output, _repeated_otherActiveCopies_codec);
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
		if (AvailableCopies != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(AvailableCopies);
		}
		if (TotalCopies != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalCopies);
		}
		if (IsActiveLocally)
		{
			num += 2;
		}
		num += otherActiveCopies_.CalculateSize(_repeated_otherActiveCopies_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LicensingInfo other)
	{
		if (other != null)
		{
			if (other.AvailableCopies != 0)
			{
				AvailableCopies = other.AvailableCopies;
			}
			if (other.TotalCopies != 0)
			{
				TotalCopies = other.TotalCopies;
			}
			if (other.IsActiveLocally)
			{
				IsActiveLocally = other.IsActiveLocally;
			}
			otherActiveCopies_.Add(other.otherActiveCopies_);
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
				AvailableCopies = input.ReadInt32();
				break;
			case 16u:
				TotalCopies = input.ReadInt32();
				break;
			case 24u:
				IsActiveLocally = input.ReadBool();
				break;
			case 34u:
				otherActiveCopies_.AddEntriesFrom(input, _repeated_otherActiveCopies_codec);
				break;
			}
		}
	}
}
