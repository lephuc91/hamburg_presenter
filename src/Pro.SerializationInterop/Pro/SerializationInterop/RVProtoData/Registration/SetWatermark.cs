using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SetWatermark : IMessage<SetWatermark>, IMessage, IEquatable<SetWatermark>, IDeepCloneable<SetWatermark>
{
	private static readonly MessageParser<SetWatermark> _parser = new MessageParser<SetWatermark>(() => new SetWatermark());

	private UnknownFieldSet _unknownFields;

	public const int IsRegisteredFieldNumber = 1;

	private bool isRegistered_;

	public const int ActiveSeatFieldNumber = 2;

	private bool activeSeat_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SetWatermark> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[25];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsRegistered
	{
		get
		{
			return isRegistered_;
		}
		set
		{
			isRegistered_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ActiveSeat
	{
		get
		{
			return activeSeat_;
		}
		set
		{
			activeSeat_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetWatermark()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetWatermark(SetWatermark other)
		: this()
	{
		isRegistered_ = other.isRegistered_;
		activeSeat_ = other.activeSeat_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetWatermark Clone()
	{
		return new SetWatermark(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SetWatermark);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SetWatermark other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (IsRegistered != other.IsRegistered)
		{
			return false;
		}
		if (ActiveSeat != other.ActiveSeat)
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
		if (IsRegistered)
		{
			num ^= IsRegistered.GetHashCode();
		}
		if (ActiveSeat)
		{
			num ^= ActiveSeat.GetHashCode();
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
		if (IsRegistered)
		{
			output.WriteRawTag(8);
			output.WriteBool(IsRegistered);
		}
		if (ActiveSeat)
		{
			output.WriteRawTag(16);
			output.WriteBool(ActiveSeat);
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
		if (IsRegistered)
		{
			num += 2;
		}
		if (ActiveSeat)
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
	public void MergeFrom(SetWatermark other)
	{
		if (other != null)
		{
			if (other.IsRegistered)
			{
				IsRegistered = other.IsRegistered;
			}
			if (other.ActiveSeat)
			{
				ActiveSeat = other.ActiveSeat;
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
				IsRegistered = input.ReadBool();
				break;
			case 16u:
				ActiveSeat = input.ReadBool();
				break;
			}
		}
	}
}
