using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DownloadProgress : IMessage<DownloadProgress>, IMessage, IEquatable<DownloadProgress>, IDeepCloneable<DownloadProgress>
{
	private static readonly MessageParser<DownloadProgress> _parser = new MessageParser<DownloadProgress>(() => new DownloadProgress());

	private UnknownFieldSet _unknownFields;

	public const int StatusFieldNumber = 1;

	private Status status_;

	public const int CompleteFieldNumber = 2;

	private bool complete_;

	public const int ProgressFieldNumber = 3;

	private float progress_;

	public const int ClientAlertFieldNumber = 4;

	private ClientAlertMessage clientAlert_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DownloadProgress> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[35];

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
	public bool Complete
	{
		get
		{
			return complete_;
		}
		set
		{
			complete_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Progress
	{
		get
		{
			return progress_;
		}
		set
		{
			progress_ = value;
		}
	}

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
	public DownloadProgress()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadProgress(DownloadProgress other)
		: this()
	{
		status_ = other.status_;
		complete_ = other.complete_;
		progress_ = other.progress_;
		clientAlert_ = other.clientAlert_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadProgress Clone()
	{
		return new DownloadProgress(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DownloadProgress);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DownloadProgress other)
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
		if (Complete != other.Complete)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Progress, other.Progress))
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
		if (Complete)
		{
			num ^= Complete.GetHashCode();
		}
		if (Progress != 0f)
		{
			num ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Progress);
		}
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
		if (Complete)
		{
			output.WriteRawTag(16);
			output.WriteBool(Complete);
		}
		if (Progress != 0f)
		{
			output.WriteRawTag(29);
			output.WriteFloat(Progress);
		}
		if (ClientAlert != 0)
		{
			output.WriteRawTag(32);
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
		if (Complete)
		{
			num += 2;
		}
		if (Progress != 0f)
		{
			num += 5;
		}
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
	public void MergeFrom(DownloadProgress other)
	{
		if (other != null)
		{
			if (other.Status != 0)
			{
				Status = other.Status;
			}
			if (other.Complete)
			{
				Complete = other.Complete;
			}
			if (other.Progress != 0f)
			{
				Progress = other.Progress;
			}
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
				Complete = input.ReadBool();
				break;
			case 29u:
				Progress = input.ReadFloat();
				break;
			case 32u:
				ClientAlert = (ClientAlertMessage)input.ReadEnum();
				break;
			}
		}
	}
}
