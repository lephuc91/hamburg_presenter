using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class UpgradesAvailable : IMessage<UpgradesAvailable>, IMessage, IEquatable<UpgradesAvailable>, IDeepCloneable<UpgradesAvailable>
{
	private static readonly MessageParser<UpgradesAvailable> _parser = new MessageParser<UpgradesAvailable>(() => new UpgradesAvailable());

	private UnknownFieldSet _unknownFields;

	public const int StatusFieldNumber = 1;

	private Status status_;

	public const int IsNonProductionActiveFieldNumber = 2;

	private bool isNonProductionActive_;

	public const int ActiveChannelFieldNumber = 3;

	private string activeChannel_ = "";

	public const int ReleaseNotesFieldNumber = 4;

	private string releaseNotes_ = "";

	public const int UpgradesFieldNumber = 5;

	private static readonly FieldCodec<BuildInformation> _repeated_upgrades_codec = FieldCodec.ForMessage(42u, BuildInformation.Parser);

	private readonly RepeatedField<BuildInformation> upgrades_ = new RepeatedField<BuildInformation>();

	public const int ClientAlertFieldNumber = 6;

	private ClientAlertMessage clientAlert_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<UpgradesAvailable> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[34];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Status Status
	{
		get
		{
			return status_;
		}
		set
		{
			status_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsNonProductionActive
	{
		get
		{
			return isNonProductionActive_;
		}
		set
		{
			isNonProductionActive_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ActiveChannel
	{
		get
		{
			return activeChannel_;
		}
		set
		{
			activeChannel_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ReleaseNotes
	{
		get
		{
			return releaseNotes_;
		}
		set
		{
			releaseNotes_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<BuildInformation> Upgrades => upgrades_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ClientAlertMessage ClientAlert
	{
		get
		{
			return clientAlert_;
		}
		set
		{
			clientAlert_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpgradesAvailable()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpgradesAvailable(UpgradesAvailable other)
		: this()
	{
		status_ = other.status_;
		isNonProductionActive_ = other.isNonProductionActive_;
		activeChannel_ = other.activeChannel_;
		releaseNotes_ = other.releaseNotes_;
		upgrades_ = other.upgrades_.Clone();
		clientAlert_ = other.clientAlert_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpgradesAvailable Clone()
	{
		return new UpgradesAvailable(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as UpgradesAvailable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(UpgradesAvailable other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Status != other.Status)
		{
			return false;
		}
		if (IsNonProductionActive != other.IsNonProductionActive)
		{
			return false;
		}
		if (ActiveChannel != other.ActiveChannel)
		{
			return false;
		}
		if (ReleaseNotes != other.ReleaseNotes)
		{
			return false;
		}
		if (!upgrades_.Equals(other.upgrades_))
		{
			return false;
		}
		if (ClientAlert != other.ClientAlert)
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
		if (Status != 0)
		{
			num ^= Status.GetHashCode();
		}
		if (IsNonProductionActive)
		{
			num ^= IsNonProductionActive.GetHashCode();
		}
		if (ActiveChannel.Length != 0)
		{
			num ^= ActiveChannel.GetHashCode();
		}
		if (ReleaseNotes.Length != 0)
		{
			num ^= ReleaseNotes.GetHashCode();
		}
		num ^= upgrades_.GetHashCode();
		if (ClientAlert != 0)
		{
			num ^= ClientAlert.GetHashCode();
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
		if (Status != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Status);
		}
		if (IsNonProductionActive)
		{
			output.WriteRawTag(16);
			output.WriteBool(IsNonProductionActive);
		}
		if (ActiveChannel.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(ActiveChannel);
		}
		if (ReleaseNotes.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(ReleaseNotes);
		}
		upgrades_.WriteTo(output, _repeated_upgrades_codec);
		if (ClientAlert != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)ClientAlert);
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
		if (Status != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Status);
		}
		if (IsNonProductionActive)
		{
			num += 2;
		}
		if (ActiveChannel.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ActiveChannel);
		}
		if (ReleaseNotes.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ReleaseNotes);
		}
		num += upgrades_.CalculateSize(_repeated_upgrades_codec);
		if (ClientAlert != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ClientAlert);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(UpgradesAvailable other)
	{
		if (other != null)
		{
			if (other.Status != 0)
			{
				Status = other.Status;
			}
			if (other.IsNonProductionActive)
			{
				IsNonProductionActive = other.IsNonProductionActive;
			}
			if (other.ActiveChannel.Length != 0)
			{
				ActiveChannel = other.ActiveChannel;
			}
			if (other.ReleaseNotes.Length != 0)
			{
				ReleaseNotes = other.ReleaseNotes;
			}
			upgrades_.Add(other.upgrades_);
			if (other.ClientAlert != 0)
			{
				ClientAlert = other.ClientAlert;
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
				Status = (Status)input.ReadEnum();
				break;
			case 16u:
				IsNonProductionActive = input.ReadBool();
				break;
			case 26u:
				ActiveChannel = input.ReadString();
				break;
			case 34u:
				ReleaseNotes = input.ReadString();
				break;
			case 42u:
				upgrades_.AddEntriesFrom(input, _repeated_upgrades_codec);
				break;
			case 48u:
				ClientAlert = (ClientAlertMessage)input.ReadEnum();
				break;
			}
		}
	}
}
