using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class BibleDownloadProgress : IMessage<BibleDownloadProgress>, IMessage, IEquatable<BibleDownloadProgress>, IDeepCloneable<BibleDownloadProgress>
{
	private static readonly MessageParser<BibleDownloadProgress> _parser = new MessageParser<BibleDownloadProgress>(() => new BibleDownloadProgress());

	private UnknownFieldSet _unknownFields;

	public const int StatusFieldNumber = 1;

	private Status status_;

	public const int CompleteFieldNumber = 2;

	private bool complete_;

	public const int ProgressFieldNumber = 3;

	private float progress_;

	public const int BibleIdFieldNumber = 4;

	private string bibleId_ = "";

	public const int FileNameFieldNumber = 5;

	private string fileName_ = "";

	public const int DownloadLinkFieldNumber = 6;

	private string downloadLink_ = "";

	public const int ClientAlertFieldNumber = 7;

	private ClientAlertMessage clientAlert_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<BibleDownloadProgress> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[27];

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
	public string BibleId
	{
		get
		{
			return bibleId_;
		}
		set
		{
			bibleId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string FileName
	{
		get
		{
			return fileName_;
		}
		set
		{
			fileName_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string DownloadLink
	{
		get
		{
			return downloadLink_;
		}
		set
		{
			downloadLink_ = ProtoPreconditions.CheckNotNull(value, "value");
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
	public BibleDownloadProgress()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleDownloadProgress(BibleDownloadProgress other)
		: this()
	{
		status_ = other.status_;
		complete_ = other.complete_;
		progress_ = other.progress_;
		bibleId_ = other.bibleId_;
		fileName_ = other.fileName_;
		downloadLink_ = other.downloadLink_;
		clientAlert_ = other.clientAlert_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleDownloadProgress Clone()
	{
		return new BibleDownloadProgress(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as BibleDownloadProgress);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(BibleDownloadProgress other)
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
		if (BibleId != other.BibleId)
		{
			return false;
		}
		if (FileName != other.FileName)
		{
			return false;
		}
		if (DownloadLink != other.DownloadLink)
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
		if (BibleId.Length != 0)
		{
			num ^= BibleId.GetHashCode();
		}
		if (FileName.Length != 0)
		{
			num ^= FileName.GetHashCode();
		}
		if (DownloadLink.Length != 0)
		{
			num ^= DownloadLink.GetHashCode();
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
		if (BibleId.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(BibleId);
		}
		if (FileName.Length != 0)
		{
			output.WriteRawTag(42);
			output.WriteString(FileName);
		}
		if (DownloadLink.Length != 0)
		{
			output.WriteRawTag(50);
			output.WriteString(DownloadLink);
		}
		if (ClientAlert != 0)
		{
			output.WriteRawTag(56);
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
		if (BibleId.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(BibleId);
		}
		if (FileName.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(FileName);
		}
		if (DownloadLink.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(DownloadLink);
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
	public void MergeFrom(BibleDownloadProgress other)
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
			if (other.BibleId.Length != 0)
			{
				BibleId = other.BibleId;
			}
			if (other.FileName.Length != 0)
			{
				FileName = other.FileName;
			}
			if (other.DownloadLink.Length != 0)
			{
				DownloadLink = other.DownloadLink;
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
			case 34u:
				BibleId = input.ReadString();
				break;
			case 42u:
				FileName = input.ReadString();
				break;
			case 50u:
				DownloadLink = input.ReadString();
				break;
			case 56u:
				ClientAlert = (ClientAlertMessage)input.ReadEnum();
				break;
			}
		}
	}
}
