using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Callback : IMessage<Callback>, IMessage, IEquatable<Callback>, IDeepCloneable<Callback>
{
	public enum CallbackOneofCase
	{
		None,
		SetWatermark,
		BibleDownloadProgress,
		HardExit,
		ReadRegistrationData,
		WriteRegistrationData,
		GetProductInformation,
		Log,
		UpgradesAvailable,
		DownloadProgress,
		Alerts,
		ShowExpirationDialog,
		ReadOldToken,
		VerificationComplete,
		SetClientInfo,
		GetActivateCodeComplete,
		ReadNotificationData,
		WriteNotificationData,
		NotificationCallback,
		LicenseState
	}

	private static readonly MessageParser<Callback> _parser = new MessageParser<Callback>(() => new Callback());

	private UnknownFieldSet _unknownFields;

	public const int SetWatermarkFieldNumber = 1;

	public const int BibleDownloadProgressFieldNumber = 2;

	public const int HardExitFieldNumber = 3;

	public const int ReadRegistrationDataFieldNumber = 4;

	public const int WriteRegistrationDataFieldNumber = 5;

	public const int GetProductInformationFieldNumber = 6;

	public const int LogFieldNumber = 7;

	public const int UpgradesAvailableFieldNumber = 8;

	public const int DownloadProgressFieldNumber = 9;

	public const int AlertsFieldNumber = 10;

	public const int ShowExpirationDialogFieldNumber = 11;

	public const int ReadOldTokenFieldNumber = 12;

	public const int VerificationCompleteFieldNumber = 13;

	public const int SetClientInfoFieldNumber = 14;

	public const int GetActivateCodeCompleteFieldNumber = 15;

	public const int ReadNotificationDataFieldNumber = 16;

	public const int WriteNotificationDataFieldNumber = 17;

	public const int NotificationCallbackFieldNumber = 18;

	public const int LicenseStateFieldNumber = 19;

	private object callback_;

	private CallbackOneofCase callbackCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Callback> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetWatermark SetWatermark
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.SetWatermark)
			{
				return null;
			}
			return (SetWatermark)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.SetWatermark : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BibleDownloadProgress BibleDownloadProgress
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.BibleDownloadProgress)
			{
				return null;
			}
			return (BibleDownloadProgress)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.BibleDownloadProgress : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public HardExit HardExit
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.HardExit)
			{
				return null;
			}
			return (HardExit)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.HardExit : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReadRegistrationData ReadRegistrationData
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.ReadRegistrationData)
			{
				return null;
			}
			return (ReadRegistrationData)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.ReadRegistrationData : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WriteRegistrationData WriteRegistrationData
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.WriteRegistrationData)
			{
				return null;
			}
			return (WriteRegistrationData)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.WriteRegistrationData : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetProductInformation GetProductInformation
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.GetProductInformation)
			{
				return null;
			}
			return (GetProductInformation)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.GetProductInformation : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Log Log
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.Log)
			{
				return null;
			}
			return (Log)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.Log : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpgradesAvailable UpgradesAvailable
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.UpgradesAvailable)
			{
				return null;
			}
			return (UpgradesAvailable)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.UpgradesAvailable : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadProgress DownloadProgress
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.DownloadProgress)
			{
				return null;
			}
			return (DownloadProgress)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.DownloadProgress : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Alerts Alerts
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.Alerts)
			{
				return null;
			}
			return (Alerts)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.Alerts : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ShowExpirationDialog ShowExpirationDialog
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.ShowExpirationDialog)
			{
				return null;
			}
			return (ShowExpirationDialog)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.ShowExpirationDialog : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReadOldToken ReadOldToken
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.ReadOldToken)
			{
				return null;
			}
			return (ReadOldToken)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.ReadOldToken : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VerificationComplete VerificationComplete
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.VerificationComplete)
			{
				return null;
			}
			return (VerificationComplete)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.VerificationComplete : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SetClientInfo SetClientInfo
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.SetClientInfo)
			{
				return null;
			}
			return (SetClientInfo)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.SetClientInfo : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActivateCodeComplete GetActivateCodeComplete
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.GetActivateCodeComplete)
			{
				return null;
			}
			return (ActivateCodeComplete)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.GetActivateCodeComplete : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReadNotificationData ReadNotificationData
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.ReadNotificationData)
			{
				return null;
			}
			return (ReadNotificationData)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.ReadNotificationData : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public WriteNotificationData WriteNotificationData
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.WriteNotificationData)
			{
				return null;
			}
			return (WriteNotificationData)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.WriteNotificationData : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotificationCallback NotificationCallback
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.NotificationCallback)
			{
				return null;
			}
			return (NotificationCallback)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.NotificationCallback : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseState LicenseState
	{
		get
		{
			if (callbackCase_ != CallbackOneofCase.LicenseState)
			{
				return null;
			}
			return (LicenseState)callback_;
		}
		set
		{
			callback_ = value;
			callbackCase_ = ((value != null) ? CallbackOneofCase.LicenseState : CallbackOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CallbackOneofCase CallbackCase => callbackCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Callback()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Callback(Callback other)
		: this()
	{
		switch (other.CallbackCase)
		{
		case CallbackOneofCase.SetWatermark:
			SetWatermark = other.SetWatermark.Clone();
			break;
		case CallbackOneofCase.BibleDownloadProgress:
			BibleDownloadProgress = other.BibleDownloadProgress.Clone();
			break;
		case CallbackOneofCase.HardExit:
			HardExit = other.HardExit.Clone();
			break;
		case CallbackOneofCase.ReadRegistrationData:
			ReadRegistrationData = other.ReadRegistrationData.Clone();
			break;
		case CallbackOneofCase.WriteRegistrationData:
			WriteRegistrationData = other.WriteRegistrationData.Clone();
			break;
		case CallbackOneofCase.GetProductInformation:
			GetProductInformation = other.GetProductInformation.Clone();
			break;
		case CallbackOneofCase.Log:
			Log = other.Log.Clone();
			break;
		case CallbackOneofCase.UpgradesAvailable:
			UpgradesAvailable = other.UpgradesAvailable.Clone();
			break;
		case CallbackOneofCase.DownloadProgress:
			DownloadProgress = other.DownloadProgress.Clone();
			break;
		case CallbackOneofCase.Alerts:
			Alerts = other.Alerts.Clone();
			break;
		case CallbackOneofCase.ShowExpirationDialog:
			ShowExpirationDialog = other.ShowExpirationDialog.Clone();
			break;
		case CallbackOneofCase.ReadOldToken:
			ReadOldToken = other.ReadOldToken.Clone();
			break;
		case CallbackOneofCase.VerificationComplete:
			VerificationComplete = other.VerificationComplete.Clone();
			break;
		case CallbackOneofCase.SetClientInfo:
			SetClientInfo = other.SetClientInfo.Clone();
			break;
		case CallbackOneofCase.GetActivateCodeComplete:
			GetActivateCodeComplete = other.GetActivateCodeComplete.Clone();
			break;
		case CallbackOneofCase.ReadNotificationData:
			ReadNotificationData = other.ReadNotificationData.Clone();
			break;
		case CallbackOneofCase.WriteNotificationData:
			WriteNotificationData = other.WriteNotificationData.Clone();
			break;
		case CallbackOneofCase.NotificationCallback:
			NotificationCallback = other.NotificationCallback.Clone();
			break;
		case CallbackOneofCase.LicenseState:
			LicenseState = other.LicenseState.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Callback Clone()
	{
		return new Callback(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearCallback()
	{
		callbackCase_ = CallbackOneofCase.None;
		callback_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Callback);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Callback other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(SetWatermark, other.SetWatermark))
		{
			return false;
		}
		if (!object.Equals(BibleDownloadProgress, other.BibleDownloadProgress))
		{
			return false;
		}
		if (!object.Equals(HardExit, other.HardExit))
		{
			return false;
		}
		if (!object.Equals(ReadRegistrationData, other.ReadRegistrationData))
		{
			return false;
		}
		if (!object.Equals(WriteRegistrationData, other.WriteRegistrationData))
		{
			return false;
		}
		if (!object.Equals(GetProductInformation, other.GetProductInformation))
		{
			return false;
		}
		if (!object.Equals(Log, other.Log))
		{
			return false;
		}
		if (!object.Equals(UpgradesAvailable, other.UpgradesAvailable))
		{
			return false;
		}
		if (!object.Equals(DownloadProgress, other.DownloadProgress))
		{
			return false;
		}
		if (!object.Equals(Alerts, other.Alerts))
		{
			return false;
		}
		if (!object.Equals(ShowExpirationDialog, other.ShowExpirationDialog))
		{
			return false;
		}
		if (!object.Equals(ReadOldToken, other.ReadOldToken))
		{
			return false;
		}
		if (!object.Equals(VerificationComplete, other.VerificationComplete))
		{
			return false;
		}
		if (!object.Equals(SetClientInfo, other.SetClientInfo))
		{
			return false;
		}
		if (!object.Equals(GetActivateCodeComplete, other.GetActivateCodeComplete))
		{
			return false;
		}
		if (!object.Equals(ReadNotificationData, other.ReadNotificationData))
		{
			return false;
		}
		if (!object.Equals(WriteNotificationData, other.WriteNotificationData))
		{
			return false;
		}
		if (!object.Equals(NotificationCallback, other.NotificationCallback))
		{
			return false;
		}
		if (!object.Equals(LicenseState, other.LicenseState))
		{
			return false;
		}
		if (CallbackCase != other.CallbackCase)
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
		if (callbackCase_ == CallbackOneofCase.SetWatermark)
		{
			num ^= SetWatermark.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.BibleDownloadProgress)
		{
			num ^= BibleDownloadProgress.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.HardExit)
		{
			num ^= HardExit.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.ReadRegistrationData)
		{
			num ^= ReadRegistrationData.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.WriteRegistrationData)
		{
			num ^= WriteRegistrationData.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.GetProductInformation)
		{
			num ^= GetProductInformation.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.Log)
		{
			num ^= Log.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.UpgradesAvailable)
		{
			num ^= UpgradesAvailable.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.DownloadProgress)
		{
			num ^= DownloadProgress.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.Alerts)
		{
			num ^= Alerts.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.ShowExpirationDialog)
		{
			num ^= ShowExpirationDialog.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.ReadOldToken)
		{
			num ^= ReadOldToken.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.VerificationComplete)
		{
			num ^= VerificationComplete.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.SetClientInfo)
		{
			num ^= SetClientInfo.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.GetActivateCodeComplete)
		{
			num ^= GetActivateCodeComplete.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.ReadNotificationData)
		{
			num ^= ReadNotificationData.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.WriteNotificationData)
		{
			num ^= WriteNotificationData.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.NotificationCallback)
		{
			num ^= NotificationCallback.GetHashCode();
		}
		if (callbackCase_ == CallbackOneofCase.LicenseState)
		{
			num ^= LicenseState.GetHashCode();
		}
		num ^= (int)callbackCase_;
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
		if (callbackCase_ == CallbackOneofCase.SetWatermark)
		{
			output.WriteRawTag(10);
			output.WriteMessage(SetWatermark);
		}
		if (callbackCase_ == CallbackOneofCase.BibleDownloadProgress)
		{
			output.WriteRawTag(18);
			output.WriteMessage(BibleDownloadProgress);
		}
		if (callbackCase_ == CallbackOneofCase.HardExit)
		{
			output.WriteRawTag(26);
			output.WriteMessage(HardExit);
		}
		if (callbackCase_ == CallbackOneofCase.ReadRegistrationData)
		{
			output.WriteRawTag(34);
			output.WriteMessage(ReadRegistrationData);
		}
		if (callbackCase_ == CallbackOneofCase.WriteRegistrationData)
		{
			output.WriteRawTag(42);
			output.WriteMessage(WriteRegistrationData);
		}
		if (callbackCase_ == CallbackOneofCase.GetProductInformation)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetProductInformation);
		}
		if (callbackCase_ == CallbackOneofCase.Log)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Log);
		}
		if (callbackCase_ == CallbackOneofCase.UpgradesAvailable)
		{
			output.WriteRawTag(66);
			output.WriteMessage(UpgradesAvailable);
		}
		if (callbackCase_ == CallbackOneofCase.DownloadProgress)
		{
			output.WriteRawTag(74);
			output.WriteMessage(DownloadProgress);
		}
		if (callbackCase_ == CallbackOneofCase.Alerts)
		{
			output.WriteRawTag(82);
			output.WriteMessage(Alerts);
		}
		if (callbackCase_ == CallbackOneofCase.ShowExpirationDialog)
		{
			output.WriteRawTag(90);
			output.WriteMessage(ShowExpirationDialog);
		}
		if (callbackCase_ == CallbackOneofCase.ReadOldToken)
		{
			output.WriteRawTag(98);
			output.WriteMessage(ReadOldToken);
		}
		if (callbackCase_ == CallbackOneofCase.VerificationComplete)
		{
			output.WriteRawTag(106);
			output.WriteMessage(VerificationComplete);
		}
		if (callbackCase_ == CallbackOneofCase.SetClientInfo)
		{
			output.WriteRawTag(114);
			output.WriteMessage(SetClientInfo);
		}
		if (callbackCase_ == CallbackOneofCase.GetActivateCodeComplete)
		{
			output.WriteRawTag(122);
			output.WriteMessage(GetActivateCodeComplete);
		}
		if (callbackCase_ == CallbackOneofCase.ReadNotificationData)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(ReadNotificationData);
		}
		if (callbackCase_ == CallbackOneofCase.WriteNotificationData)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(WriteNotificationData);
		}
		if (callbackCase_ == CallbackOneofCase.NotificationCallback)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(NotificationCallback);
		}
		if (callbackCase_ == CallbackOneofCase.LicenseState)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(LicenseState);
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
		if (callbackCase_ == CallbackOneofCase.SetWatermark)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetWatermark);
		}
		if (callbackCase_ == CallbackOneofCase.BibleDownloadProgress)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BibleDownloadProgress);
		}
		if (callbackCase_ == CallbackOneofCase.HardExit)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(HardExit);
		}
		if (callbackCase_ == CallbackOneofCase.ReadRegistrationData)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ReadRegistrationData);
		}
		if (callbackCase_ == CallbackOneofCase.WriteRegistrationData)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(WriteRegistrationData);
		}
		if (callbackCase_ == CallbackOneofCase.GetProductInformation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetProductInformation);
		}
		if (callbackCase_ == CallbackOneofCase.Log)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Log);
		}
		if (callbackCase_ == CallbackOneofCase.UpgradesAvailable)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpgradesAvailable);
		}
		if (callbackCase_ == CallbackOneofCase.DownloadProgress)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DownloadProgress);
		}
		if (callbackCase_ == CallbackOneofCase.Alerts)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Alerts);
		}
		if (callbackCase_ == CallbackOneofCase.ShowExpirationDialog)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ShowExpirationDialog);
		}
		if (callbackCase_ == CallbackOneofCase.ReadOldToken)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ReadOldToken);
		}
		if (callbackCase_ == CallbackOneofCase.VerificationComplete)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VerificationComplete);
		}
		if (callbackCase_ == CallbackOneofCase.SetClientInfo)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetClientInfo);
		}
		if (callbackCase_ == CallbackOneofCase.GetActivateCodeComplete)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetActivateCodeComplete);
		}
		if (callbackCase_ == CallbackOneofCase.ReadNotificationData)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ReadNotificationData);
		}
		if (callbackCase_ == CallbackOneofCase.WriteNotificationData)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(WriteNotificationData);
		}
		if (callbackCase_ == CallbackOneofCase.NotificationCallback)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(NotificationCallback);
		}
		if (callbackCase_ == CallbackOneofCase.LicenseState)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(LicenseState);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Callback other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.CallbackCase)
		{
		case CallbackOneofCase.SetWatermark:
			if (SetWatermark == null)
			{
				SetWatermark = new SetWatermark();
			}
			SetWatermark.MergeFrom(other.SetWatermark);
			break;
		case CallbackOneofCase.BibleDownloadProgress:
			if (BibleDownloadProgress == null)
			{
				BibleDownloadProgress = new BibleDownloadProgress();
			}
			BibleDownloadProgress.MergeFrom(other.BibleDownloadProgress);
			break;
		case CallbackOneofCase.HardExit:
			if (HardExit == null)
			{
				HardExit = new HardExit();
			}
			HardExit.MergeFrom(other.HardExit);
			break;
		case CallbackOneofCase.ReadRegistrationData:
			if (ReadRegistrationData == null)
			{
				ReadRegistrationData = new ReadRegistrationData();
			}
			ReadRegistrationData.MergeFrom(other.ReadRegistrationData);
			break;
		case CallbackOneofCase.WriteRegistrationData:
			if (WriteRegistrationData == null)
			{
				WriteRegistrationData = new WriteRegistrationData();
			}
			WriteRegistrationData.MergeFrom(other.WriteRegistrationData);
			break;
		case CallbackOneofCase.GetProductInformation:
			if (GetProductInformation == null)
			{
				GetProductInformation = new GetProductInformation();
			}
			GetProductInformation.MergeFrom(other.GetProductInformation);
			break;
		case CallbackOneofCase.Log:
			if (Log == null)
			{
				Log = new Log();
			}
			Log.MergeFrom(other.Log);
			break;
		case CallbackOneofCase.UpgradesAvailable:
			if (UpgradesAvailable == null)
			{
				UpgradesAvailable = new UpgradesAvailable();
			}
			UpgradesAvailable.MergeFrom(other.UpgradesAvailable);
			break;
		case CallbackOneofCase.DownloadProgress:
			if (DownloadProgress == null)
			{
				DownloadProgress = new DownloadProgress();
			}
			DownloadProgress.MergeFrom(other.DownloadProgress);
			break;
		case CallbackOneofCase.Alerts:
			if (Alerts == null)
			{
				Alerts = new Alerts();
			}
			Alerts.MergeFrom(other.Alerts);
			break;
		case CallbackOneofCase.ShowExpirationDialog:
			if (ShowExpirationDialog == null)
			{
				ShowExpirationDialog = new ShowExpirationDialog();
			}
			ShowExpirationDialog.MergeFrom(other.ShowExpirationDialog);
			break;
		case CallbackOneofCase.ReadOldToken:
			if (ReadOldToken == null)
			{
				ReadOldToken = new ReadOldToken();
			}
			ReadOldToken.MergeFrom(other.ReadOldToken);
			break;
		case CallbackOneofCase.VerificationComplete:
			if (VerificationComplete == null)
			{
				VerificationComplete = new VerificationComplete();
			}
			VerificationComplete.MergeFrom(other.VerificationComplete);
			break;
		case CallbackOneofCase.SetClientInfo:
			if (SetClientInfo == null)
			{
				SetClientInfo = new SetClientInfo();
			}
			SetClientInfo.MergeFrom(other.SetClientInfo);
			break;
		case CallbackOneofCase.GetActivateCodeComplete:
			if (GetActivateCodeComplete == null)
			{
				GetActivateCodeComplete = new ActivateCodeComplete();
			}
			GetActivateCodeComplete.MergeFrom(other.GetActivateCodeComplete);
			break;
		case CallbackOneofCase.ReadNotificationData:
			if (ReadNotificationData == null)
			{
				ReadNotificationData = new ReadNotificationData();
			}
			ReadNotificationData.MergeFrom(other.ReadNotificationData);
			break;
		case CallbackOneofCase.WriteNotificationData:
			if (WriteNotificationData == null)
			{
				WriteNotificationData = new WriteNotificationData();
			}
			WriteNotificationData.MergeFrom(other.WriteNotificationData);
			break;
		case CallbackOneofCase.NotificationCallback:
			if (NotificationCallback == null)
			{
				NotificationCallback = new NotificationCallback();
			}
			NotificationCallback.MergeFrom(other.NotificationCallback);
			break;
		case CallbackOneofCase.LicenseState:
			if (LicenseState == null)
			{
				LicenseState = new LicenseState();
			}
			LicenseState.MergeFrom(other.LicenseState);
			break;
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
			{
				SetWatermark setWatermark = new SetWatermark();
				if (callbackCase_ == CallbackOneofCase.SetWatermark)
				{
					setWatermark.MergeFrom(SetWatermark);
				}
				input.ReadMessage(setWatermark);
				SetWatermark = setWatermark;
				break;
			}
			case 18u:
			{
				BibleDownloadProgress bibleDownloadProgress = new BibleDownloadProgress();
				if (callbackCase_ == CallbackOneofCase.BibleDownloadProgress)
				{
					bibleDownloadProgress.MergeFrom(BibleDownloadProgress);
				}
				input.ReadMessage(bibleDownloadProgress);
				BibleDownloadProgress = bibleDownloadProgress;
				break;
			}
			case 26u:
			{
				HardExit hardExit = new HardExit();
				if (callbackCase_ == CallbackOneofCase.HardExit)
				{
					hardExit.MergeFrom(HardExit);
				}
				input.ReadMessage(hardExit);
				HardExit = hardExit;
				break;
			}
			case 34u:
			{
				ReadRegistrationData readRegistrationData = new ReadRegistrationData();
				if (callbackCase_ == CallbackOneofCase.ReadRegistrationData)
				{
					readRegistrationData.MergeFrom(ReadRegistrationData);
				}
				input.ReadMessage(readRegistrationData);
				ReadRegistrationData = readRegistrationData;
				break;
			}
			case 42u:
			{
				WriteRegistrationData writeRegistrationData = new WriteRegistrationData();
				if (callbackCase_ == CallbackOneofCase.WriteRegistrationData)
				{
					writeRegistrationData.MergeFrom(WriteRegistrationData);
				}
				input.ReadMessage(writeRegistrationData);
				WriteRegistrationData = writeRegistrationData;
				break;
			}
			case 50u:
			{
				GetProductInformation getProductInformation = new GetProductInformation();
				if (callbackCase_ == CallbackOneofCase.GetProductInformation)
				{
					getProductInformation.MergeFrom(GetProductInformation);
				}
				input.ReadMessage(getProductInformation);
				GetProductInformation = getProductInformation;
				break;
			}
			case 58u:
			{
				Log log = new Log();
				if (callbackCase_ == CallbackOneofCase.Log)
				{
					log.MergeFrom(Log);
				}
				input.ReadMessage(log);
				Log = log;
				break;
			}
			case 66u:
			{
				UpgradesAvailable upgradesAvailable = new UpgradesAvailable();
				if (callbackCase_ == CallbackOneofCase.UpgradesAvailable)
				{
					upgradesAvailable.MergeFrom(UpgradesAvailable);
				}
				input.ReadMessage(upgradesAvailable);
				UpgradesAvailable = upgradesAvailable;
				break;
			}
			case 74u:
			{
				DownloadProgress downloadProgress = new DownloadProgress();
				if (callbackCase_ == CallbackOneofCase.DownloadProgress)
				{
					downloadProgress.MergeFrom(DownloadProgress);
				}
				input.ReadMessage(downloadProgress);
				DownloadProgress = downloadProgress;
				break;
			}
			case 82u:
			{
				Alerts alerts = new Alerts();
				if (callbackCase_ == CallbackOneofCase.Alerts)
				{
					alerts.MergeFrom(Alerts);
				}
				input.ReadMessage(alerts);
				Alerts = alerts;
				break;
			}
			case 90u:
			{
				ShowExpirationDialog showExpirationDialog = new ShowExpirationDialog();
				if (callbackCase_ == CallbackOneofCase.ShowExpirationDialog)
				{
					showExpirationDialog.MergeFrom(ShowExpirationDialog);
				}
				input.ReadMessage(showExpirationDialog);
				ShowExpirationDialog = showExpirationDialog;
				break;
			}
			case 98u:
			{
				ReadOldToken readOldToken = new ReadOldToken();
				if (callbackCase_ == CallbackOneofCase.ReadOldToken)
				{
					readOldToken.MergeFrom(ReadOldToken);
				}
				input.ReadMessage(readOldToken);
				ReadOldToken = readOldToken;
				break;
			}
			case 106u:
			{
				VerificationComplete verificationComplete = new VerificationComplete();
				if (callbackCase_ == CallbackOneofCase.VerificationComplete)
				{
					verificationComplete.MergeFrom(VerificationComplete);
				}
				input.ReadMessage(verificationComplete);
				VerificationComplete = verificationComplete;
				break;
			}
			case 114u:
			{
				SetClientInfo setClientInfo = new SetClientInfo();
				if (callbackCase_ == CallbackOneofCase.SetClientInfo)
				{
					setClientInfo.MergeFrom(SetClientInfo);
				}
				input.ReadMessage(setClientInfo);
				SetClientInfo = setClientInfo;
				break;
			}
			case 122u:
			{
				ActivateCodeComplete activateCodeComplete = new ActivateCodeComplete();
				if (callbackCase_ == CallbackOneofCase.GetActivateCodeComplete)
				{
					activateCodeComplete.MergeFrom(GetActivateCodeComplete);
				}
				input.ReadMessage(activateCodeComplete);
				GetActivateCodeComplete = activateCodeComplete;
				break;
			}
			case 130u:
			{
				ReadNotificationData readNotificationData = new ReadNotificationData();
				if (callbackCase_ == CallbackOneofCase.ReadNotificationData)
				{
					readNotificationData.MergeFrom(ReadNotificationData);
				}
				input.ReadMessage(readNotificationData);
				ReadNotificationData = readNotificationData;
				break;
			}
			case 138u:
			{
				WriteNotificationData writeNotificationData = new WriteNotificationData();
				if (callbackCase_ == CallbackOneofCase.WriteNotificationData)
				{
					writeNotificationData.MergeFrom(WriteNotificationData);
				}
				input.ReadMessage(writeNotificationData);
				WriteNotificationData = writeNotificationData;
				break;
			}
			case 146u:
			{
				NotificationCallback notificationCallback = new NotificationCallback();
				if (callbackCase_ == CallbackOneofCase.NotificationCallback)
				{
					notificationCallback.MergeFrom(NotificationCallback);
				}
				input.ReadMessage(notificationCallback);
				NotificationCallback = notificationCallback;
				break;
			}
			case 154u:
			{
				LicenseState licenseState = new LicenseState();
				if (callbackCase_ == CallbackOneofCase.LicenseState)
				{
					licenseState.MergeFrom(LicenseState);
				}
				input.ReadMessage(licenseState);
				LicenseState = licenseState;
				break;
			}
			}
		}
	}
}
