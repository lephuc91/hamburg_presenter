using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LicenseInfo : IMessage<LicenseInfo>, IMessage, IEquatable<LicenseInfo>, IDeepCloneable<LicenseInfo>
{
	private static readonly MessageParser<LicenseInfo> _parser = new MessageParser<LicenseInfo>(() => new LicenseInfo());

	private UnknownFieldSet _unknownFields;

	public const int RegistrationInfoFieldNumber = 1;

	private RegistrationInfo registrationInfo_;

	public const int AvailableSeatsFieldNumber = 2;

	private Seats availableSeats_;

	public const int TotalSeatsFieldNumber = 3;

	private Seats totalSeats_;

	public const int LegacyFieldNumber = 4;

	private bool legacy_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LicenseInfo> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[49];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationInfo RegistrationInfo
	{
		get
		{
			return registrationInfo_;
		}
		set
		{
			registrationInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Seats AvailableSeats
	{
		get
		{
			return availableSeats_;
		}
		set
		{
			availableSeats_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Seats TotalSeats
	{
		get
		{
			return totalSeats_;
		}
		set
		{
			totalSeats_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Legacy
	{
		get
		{
			return legacy_;
		}
		set
		{
			legacy_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseInfo()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseInfo(LicenseInfo other)
		: this()
	{
		registrationInfo_ = ((other.registrationInfo_ != null) ? other.registrationInfo_.Clone() : null);
		availableSeats_ = ((other.availableSeats_ != null) ? other.availableSeats_.Clone() : null);
		totalSeats_ = ((other.totalSeats_ != null) ? other.totalSeats_.Clone() : null);
		legacy_ = other.legacy_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseInfo Clone()
	{
		return new LicenseInfo(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LicenseInfo);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LicenseInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(RegistrationInfo, other.RegistrationInfo))
		{
			return false;
		}
		if (!object.Equals(AvailableSeats, other.AvailableSeats))
		{
			return false;
		}
		if (!object.Equals(TotalSeats, other.TotalSeats))
		{
			return false;
		}
		if (Legacy != other.Legacy)
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
		if (registrationInfo_ != null)
		{
			num ^= RegistrationInfo.GetHashCode();
		}
		if (availableSeats_ != null)
		{
			num ^= AvailableSeats.GetHashCode();
		}
		if (totalSeats_ != null)
		{
			num ^= TotalSeats.GetHashCode();
		}
		if (Legacy)
		{
			num ^= Legacy.GetHashCode();
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
		if (registrationInfo_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(RegistrationInfo);
		}
		if (availableSeats_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(AvailableSeats);
		}
		if (totalSeats_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(TotalSeats);
		}
		if (Legacy)
		{
			output.WriteRawTag(32);
			output.WriteBool(Legacy);
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
		if (registrationInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RegistrationInfo);
		}
		if (availableSeats_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AvailableSeats);
		}
		if (totalSeats_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TotalSeats);
		}
		if (Legacy)
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
	public void MergeFrom(LicenseInfo other)
	{
		if (other == null)
		{
			return;
		}
		if (other.registrationInfo_ != null)
		{
			if (registrationInfo_ == null)
			{
				RegistrationInfo = new RegistrationInfo();
			}
			RegistrationInfo.MergeFrom(other.RegistrationInfo);
		}
		if (other.availableSeats_ != null)
		{
			if (availableSeats_ == null)
			{
				AvailableSeats = new Seats();
			}
			AvailableSeats.MergeFrom(other.AvailableSeats);
		}
		if (other.totalSeats_ != null)
		{
			if (totalSeats_ == null)
			{
				TotalSeats = new Seats();
			}
			TotalSeats.MergeFrom(other.TotalSeats);
		}
		if (other.Legacy)
		{
			Legacy = other.Legacy;
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
				if (registrationInfo_ == null)
				{
					RegistrationInfo = new RegistrationInfo();
				}
				input.ReadMessage(RegistrationInfo);
				break;
			case 18u:
				if (availableSeats_ == null)
				{
					AvailableSeats = new Seats();
				}
				input.ReadMessage(AvailableSeats);
				break;
			case 26u:
				if (totalSeats_ == null)
				{
					TotalSeats = new Seats();
				}
				input.ReadMessage(TotalSeats);
				break;
			case 32u:
				Legacy = input.ReadBool();
				break;
			}
		}
	}
}
