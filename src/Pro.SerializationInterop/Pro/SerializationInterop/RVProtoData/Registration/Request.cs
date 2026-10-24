using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Request : IMessage<Request>, IMessage, IEquatable<Request>, IDeepCloneable<Request>
{
	public enum RequestOneofCase
	{
		None,
		Register,
		Unregister,
		ChangeSeatType,
		GetBibles,
		ActivateBible,
		DeactivateBible,
		DownloadBible,
		RegistrationData,
		ProductInformation,
		GetUpgradesAvailable,
		DownloadNewVersion,
		Refresh,
		ActivateLink,
		UpdateToken,
		OldTokenData,
		Signout,
		GetActivateCode,
		NotificationData,
		MarkNotificationsRead,
		GetLicenseState,
		RefreshUserAuthTokens,
		RefreshAccessToken
	}

	private static readonly MessageParser<Request> _parser = new MessageParser<Request>(() => new Request());

	private UnknownFieldSet _unknownFields;

	public const int RegisterFieldNumber = 1;

	public const int UnregisterFieldNumber = 2;

	public const int ChangeSeatTypeFieldNumber = 3;

	public const int GetBiblesFieldNumber = 4;

	public const int ActivateBibleFieldNumber = 5;

	public const int DeactivateBibleFieldNumber = 6;

	public const int DownloadBibleFieldNumber = 7;

	public const int RegistrationDataFieldNumber = 8;

	public const int ProductInformationFieldNumber = 9;

	public const int GetUpgradesAvailableFieldNumber = 10;

	public const int DownloadNewVersionFieldNumber = 11;

	public const int RefreshFieldNumber = 12;

	public const int ActivateLinkFieldNumber = 13;

	public const int UpdateTokenFieldNumber = 14;

	public const int OldTokenDataFieldNumber = 15;

	public const int SignoutFieldNumber = 16;

	public const int GetActivateCodeFieldNumber = 17;

	public const int NotificationDataFieldNumber = 18;

	public const int MarkNotificationsReadFieldNumber = 19;

	public const int GetLicenseStateFieldNumber = 20;

	public const int RefreshUserAuthTokensFieldNumber = 21;

	public const int RefreshAccessTokenFieldNumber = 22;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Register Register
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Register)
			{
				return null;
			}
			return (Register)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Register : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Unregister Unregister
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Unregister)
			{
				return null;
			}
			return (Unregister)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Unregister : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeSeatType ChangeSeatType
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ChangeSeatType)
			{
				return null;
			}
			return (ChangeSeatType)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ChangeSeatType : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetBibles GetBibles
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetBibles)
			{
				return null;
			}
			return (GetBibles)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetBibles : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActivateBible ActivateBible
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivateBible)
			{
				return null;
			}
			return (ActivateBible)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivateBible : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DeactivateBible DeactivateBible
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeactivateBible)
			{
				return null;
			}
			return (DeactivateBible)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeactivateBible : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadBible DownloadBible
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DownloadBible)
			{
				return null;
			}
			return (DownloadBible)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DownloadBible : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationData RegistrationData
	{
		get
		{
			if (requestCase_ != RequestOneofCase.RegistrationData)
			{
				return null;
			}
			return (RegistrationData)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.RegistrationData : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProductInformation ProductInformation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ProductInformation)
			{
				return null;
			}
			return (ProductInformation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ProductInformation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetAvailableVersion GetUpgradesAvailable
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetUpgradesAvailable)
			{
				return null;
			}
			return (GetAvailableVersion)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetUpgradesAvailable : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DownloadNewVersion DownloadNewVersion
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DownloadNewVersion)
			{
				return null;
			}
			return (DownloadNewVersion)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DownloadNewVersion : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Refresh Refresh
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Refresh)
			{
				return null;
			}
			return (Refresh)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Refresh : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ActivateLink ActivateLink
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ActivateLink)
			{
				return null;
			}
			return (ActivateLink)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ActivateLink : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateToken UpdateToken
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdateToken)
			{
				return null;
			}
			return (UpdateToken)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdateToken : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OldTokenData OldTokenData
	{
		get
		{
			if (requestCase_ != RequestOneofCase.OldTokenData)
			{
				return null;
			}
			return (OldTokenData)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.OldTokenData : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Signout Signout
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Signout)
			{
				return null;
			}
			return (Signout)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Signout : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetActivateCode GetActivateCode
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetActivateCode)
			{
				return null;
			}
			return (GetActivateCode)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetActivateCode : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NotificationData NotificationData
	{
		get
		{
			if (requestCase_ != RequestOneofCase.NotificationData)
			{
				return null;
			}
			return (NotificationData)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.NotificationData : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MarkNotificationsRead MarkNotificationsRead
	{
		get
		{
			if (requestCase_ != RequestOneofCase.MarkNotificationsRead)
			{
				return null;
			}
			return (MarkNotificationsRead)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.MarkNotificationsRead : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetLicenseState GetLicenseState
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetLicenseState)
			{
				return null;
			}
			return (GetLicenseState)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetLicenseState : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RefreshUserAuthTokens RefreshUserAuthTokens
	{
		get
		{
			if (requestCase_ != RequestOneofCase.RefreshUserAuthTokens)
			{
				return null;
			}
			return (RefreshUserAuthTokens)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.RefreshUserAuthTokens : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RefreshAccessToken RefreshAccessToken
	{
		get
		{
			if (requestCase_ != RequestOneofCase.RefreshAccessToken)
			{
				return null;
			}
			return (RefreshAccessToken)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.RefreshAccessToken : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Request(Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Register:
			Register = other.Register.Clone();
			break;
		case RequestOneofCase.Unregister:
			Unregister = other.Unregister.Clone();
			break;
		case RequestOneofCase.ChangeSeatType:
			ChangeSeatType = other.ChangeSeatType.Clone();
			break;
		case RequestOneofCase.GetBibles:
			GetBibles = other.GetBibles.Clone();
			break;
		case RequestOneofCase.ActivateBible:
			ActivateBible = other.ActivateBible.Clone();
			break;
		case RequestOneofCase.DeactivateBible:
			DeactivateBible = other.DeactivateBible.Clone();
			break;
		case RequestOneofCase.DownloadBible:
			DownloadBible = other.DownloadBible.Clone();
			break;
		case RequestOneofCase.RegistrationData:
			RegistrationData = other.RegistrationData.Clone();
			break;
		case RequestOneofCase.ProductInformation:
			ProductInformation = other.ProductInformation.Clone();
			break;
		case RequestOneofCase.GetUpgradesAvailable:
			GetUpgradesAvailable = other.GetUpgradesAvailable.Clone();
			break;
		case RequestOneofCase.DownloadNewVersion:
			DownloadNewVersion = other.DownloadNewVersion.Clone();
			break;
		case RequestOneofCase.Refresh:
			Refresh = other.Refresh.Clone();
			break;
		case RequestOneofCase.ActivateLink:
			ActivateLink = other.ActivateLink.Clone();
			break;
		case RequestOneofCase.UpdateToken:
			UpdateToken = other.UpdateToken.Clone();
			break;
		case RequestOneofCase.OldTokenData:
			OldTokenData = other.OldTokenData.Clone();
			break;
		case RequestOneofCase.Signout:
			Signout = other.Signout.Clone();
			break;
		case RequestOneofCase.GetActivateCode:
			GetActivateCode = other.GetActivateCode.Clone();
			break;
		case RequestOneofCase.NotificationData:
			NotificationData = other.NotificationData.Clone();
			break;
		case RequestOneofCase.MarkNotificationsRead:
			MarkNotificationsRead = other.MarkNotificationsRead.Clone();
			break;
		case RequestOneofCase.GetLicenseState:
			GetLicenseState = other.GetLicenseState.Clone();
			break;
		case RequestOneofCase.RefreshUserAuthTokens:
			RefreshUserAuthTokens = other.RefreshUserAuthTokens.Clone();
			break;
		case RequestOneofCase.RefreshAccessToken:
			RefreshAccessToken = other.RefreshAccessToken.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Request Clone()
	{
		return new Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Register, other.Register))
		{
			return false;
		}
		if (!object.Equals(Unregister, other.Unregister))
		{
			return false;
		}
		if (!object.Equals(ChangeSeatType, other.ChangeSeatType))
		{
			return false;
		}
		if (!object.Equals(GetBibles, other.GetBibles))
		{
			return false;
		}
		if (!object.Equals(ActivateBible, other.ActivateBible))
		{
			return false;
		}
		if (!object.Equals(DeactivateBible, other.DeactivateBible))
		{
			return false;
		}
		if (!object.Equals(DownloadBible, other.DownloadBible))
		{
			return false;
		}
		if (!object.Equals(RegistrationData, other.RegistrationData))
		{
			return false;
		}
		if (!object.Equals(ProductInformation, other.ProductInformation))
		{
			return false;
		}
		if (!object.Equals(GetUpgradesAvailable, other.GetUpgradesAvailable))
		{
			return false;
		}
		if (!object.Equals(DownloadNewVersion, other.DownloadNewVersion))
		{
			return false;
		}
		if (!object.Equals(Refresh, other.Refresh))
		{
			return false;
		}
		if (!object.Equals(ActivateLink, other.ActivateLink))
		{
			return false;
		}
		if (!object.Equals(UpdateToken, other.UpdateToken))
		{
			return false;
		}
		if (!object.Equals(OldTokenData, other.OldTokenData))
		{
			return false;
		}
		if (!object.Equals(Signout, other.Signout))
		{
			return false;
		}
		if (!object.Equals(GetActivateCode, other.GetActivateCode))
		{
			return false;
		}
		if (!object.Equals(NotificationData, other.NotificationData))
		{
			return false;
		}
		if (!object.Equals(MarkNotificationsRead, other.MarkNotificationsRead))
		{
			return false;
		}
		if (!object.Equals(GetLicenseState, other.GetLicenseState))
		{
			return false;
		}
		if (!object.Equals(RefreshUserAuthTokens, other.RefreshUserAuthTokens))
		{
			return false;
		}
		if (!object.Equals(RefreshAccessToken, other.RefreshAccessToken))
		{
			return false;
		}
		if (RequestCase != other.RequestCase)
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
		if (requestCase_ == RequestOneofCase.Register)
		{
			num ^= Register.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Unregister)
		{
			num ^= Unregister.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ChangeSeatType)
		{
			num ^= ChangeSeatType.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetBibles)
		{
			num ^= GetBibles.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivateBible)
		{
			num ^= ActivateBible.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeactivateBible)
		{
			num ^= DeactivateBible.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DownloadBible)
		{
			num ^= DownloadBible.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.RegistrationData)
		{
			num ^= RegistrationData.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ProductInformation)
		{
			num ^= ProductInformation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetUpgradesAvailable)
		{
			num ^= GetUpgradesAvailable.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DownloadNewVersion)
		{
			num ^= DownloadNewVersion.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Refresh)
		{
			num ^= Refresh.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ActivateLink)
		{
			num ^= ActivateLink.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdateToken)
		{
			num ^= UpdateToken.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.OldTokenData)
		{
			num ^= OldTokenData.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Signout)
		{
			num ^= Signout.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetActivateCode)
		{
			num ^= GetActivateCode.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.NotificationData)
		{
			num ^= NotificationData.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.MarkNotificationsRead)
		{
			num ^= MarkNotificationsRead.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetLicenseState)
		{
			num ^= GetLicenseState.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.RefreshUserAuthTokens)
		{
			num ^= RefreshUserAuthTokens.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.RefreshAccessToken)
		{
			num ^= RefreshAccessToken.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (requestCase_ == RequestOneofCase.Register)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Register);
		}
		if (requestCase_ == RequestOneofCase.Unregister)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Unregister);
		}
		if (requestCase_ == RequestOneofCase.ChangeSeatType)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ChangeSeatType);
		}
		if (requestCase_ == RequestOneofCase.GetBibles)
		{
			output.WriteRawTag(34);
			output.WriteMessage(GetBibles);
		}
		if (requestCase_ == RequestOneofCase.ActivateBible)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ActivateBible);
		}
		if (requestCase_ == RequestOneofCase.DeactivateBible)
		{
			output.WriteRawTag(50);
			output.WriteMessage(DeactivateBible);
		}
		if (requestCase_ == RequestOneofCase.DownloadBible)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DownloadBible);
		}
		if (requestCase_ == RequestOneofCase.RegistrationData)
		{
			output.WriteRawTag(66);
			output.WriteMessage(RegistrationData);
		}
		if (requestCase_ == RequestOneofCase.ProductInformation)
		{
			output.WriteRawTag(74);
			output.WriteMessage(ProductInformation);
		}
		if (requestCase_ == RequestOneofCase.GetUpgradesAvailable)
		{
			output.WriteRawTag(82);
			output.WriteMessage(GetUpgradesAvailable);
		}
		if (requestCase_ == RequestOneofCase.DownloadNewVersion)
		{
			output.WriteRawTag(90);
			output.WriteMessage(DownloadNewVersion);
		}
		if (requestCase_ == RequestOneofCase.Refresh)
		{
			output.WriteRawTag(98);
			output.WriteMessage(Refresh);
		}
		if (requestCase_ == RequestOneofCase.ActivateLink)
		{
			output.WriteRawTag(106);
			output.WriteMessage(ActivateLink);
		}
		if (requestCase_ == RequestOneofCase.UpdateToken)
		{
			output.WriteRawTag(114);
			output.WriteMessage(UpdateToken);
		}
		if (requestCase_ == RequestOneofCase.OldTokenData)
		{
			output.WriteRawTag(122);
			output.WriteMessage(OldTokenData);
		}
		if (requestCase_ == RequestOneofCase.Signout)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(Signout);
		}
		if (requestCase_ == RequestOneofCase.GetActivateCode)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(GetActivateCode);
		}
		if (requestCase_ == RequestOneofCase.NotificationData)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(NotificationData);
		}
		if (requestCase_ == RequestOneofCase.MarkNotificationsRead)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(MarkNotificationsRead);
		}
		if (requestCase_ == RequestOneofCase.GetLicenseState)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(GetLicenseState);
		}
		if (requestCase_ == RequestOneofCase.RefreshUserAuthTokens)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(RefreshUserAuthTokens);
		}
		if (requestCase_ == RequestOneofCase.RefreshAccessToken)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(RefreshAccessToken);
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
		if (requestCase_ == RequestOneofCase.Register)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Register);
		}
		if (requestCase_ == RequestOneofCase.Unregister)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Unregister);
		}
		if (requestCase_ == RequestOneofCase.ChangeSeatType)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChangeSeatType);
		}
		if (requestCase_ == RequestOneofCase.GetBibles)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetBibles);
		}
		if (requestCase_ == RequestOneofCase.ActivateBible)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivateBible);
		}
		if (requestCase_ == RequestOneofCase.DeactivateBible)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeactivateBible);
		}
		if (requestCase_ == RequestOneofCase.DownloadBible)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DownloadBible);
		}
		if (requestCase_ == RequestOneofCase.RegistrationData)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RegistrationData);
		}
		if (requestCase_ == RequestOneofCase.ProductInformation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ProductInformation);
		}
		if (requestCase_ == RequestOneofCase.GetUpgradesAvailable)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetUpgradesAvailable);
		}
		if (requestCase_ == RequestOneofCase.DownloadNewVersion)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DownloadNewVersion);
		}
		if (requestCase_ == RequestOneofCase.Refresh)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Refresh);
		}
		if (requestCase_ == RequestOneofCase.ActivateLink)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivateLink);
		}
		if (requestCase_ == RequestOneofCase.UpdateToken)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdateToken);
		}
		if (requestCase_ == RequestOneofCase.OldTokenData)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(OldTokenData);
		}
		if (requestCase_ == RequestOneofCase.Signout)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(Signout);
		}
		if (requestCase_ == RequestOneofCase.GetActivateCode)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GetActivateCode);
		}
		if (requestCase_ == RequestOneofCase.NotificationData)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(NotificationData);
		}
		if (requestCase_ == RequestOneofCase.MarkNotificationsRead)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MarkNotificationsRead);
		}
		if (requestCase_ == RequestOneofCase.GetLicenseState)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(GetLicenseState);
		}
		if (requestCase_ == RequestOneofCase.RefreshUserAuthTokens)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(RefreshUserAuthTokens);
		}
		if (requestCase_ == RequestOneofCase.RefreshAccessToken)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(RefreshAccessToken);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Register:
			if (Register == null)
			{
				Register = new Register();
			}
			Register.MergeFrom(other.Register);
			break;
		case RequestOneofCase.Unregister:
			if (Unregister == null)
			{
				Unregister = new Unregister();
			}
			Unregister.MergeFrom(other.Unregister);
			break;
		case RequestOneofCase.ChangeSeatType:
			if (ChangeSeatType == null)
			{
				ChangeSeatType = new ChangeSeatType();
			}
			ChangeSeatType.MergeFrom(other.ChangeSeatType);
			break;
		case RequestOneofCase.GetBibles:
			if (GetBibles == null)
			{
				GetBibles = new GetBibles();
			}
			GetBibles.MergeFrom(other.GetBibles);
			break;
		case RequestOneofCase.ActivateBible:
			if (ActivateBible == null)
			{
				ActivateBible = new ActivateBible();
			}
			ActivateBible.MergeFrom(other.ActivateBible);
			break;
		case RequestOneofCase.DeactivateBible:
			if (DeactivateBible == null)
			{
				DeactivateBible = new DeactivateBible();
			}
			DeactivateBible.MergeFrom(other.DeactivateBible);
			break;
		case RequestOneofCase.DownloadBible:
			if (DownloadBible == null)
			{
				DownloadBible = new DownloadBible();
			}
			DownloadBible.MergeFrom(other.DownloadBible);
			break;
		case RequestOneofCase.RegistrationData:
			if (RegistrationData == null)
			{
				RegistrationData = new RegistrationData();
			}
			RegistrationData.MergeFrom(other.RegistrationData);
			break;
		case RequestOneofCase.ProductInformation:
			if (ProductInformation == null)
			{
				ProductInformation = new ProductInformation();
			}
			ProductInformation.MergeFrom(other.ProductInformation);
			break;
		case RequestOneofCase.GetUpgradesAvailable:
			if (GetUpgradesAvailable == null)
			{
				GetUpgradesAvailable = new GetAvailableVersion();
			}
			GetUpgradesAvailable.MergeFrom(other.GetUpgradesAvailable);
			break;
		case RequestOneofCase.DownloadNewVersion:
			if (DownloadNewVersion == null)
			{
				DownloadNewVersion = new DownloadNewVersion();
			}
			DownloadNewVersion.MergeFrom(other.DownloadNewVersion);
			break;
		case RequestOneofCase.Refresh:
			if (Refresh == null)
			{
				Refresh = new Refresh();
			}
			Refresh.MergeFrom(other.Refresh);
			break;
		case RequestOneofCase.ActivateLink:
			if (ActivateLink == null)
			{
				ActivateLink = new ActivateLink();
			}
			ActivateLink.MergeFrom(other.ActivateLink);
			break;
		case RequestOneofCase.UpdateToken:
			if (UpdateToken == null)
			{
				UpdateToken = new UpdateToken();
			}
			UpdateToken.MergeFrom(other.UpdateToken);
			break;
		case RequestOneofCase.OldTokenData:
			if (OldTokenData == null)
			{
				OldTokenData = new OldTokenData();
			}
			OldTokenData.MergeFrom(other.OldTokenData);
			break;
		case RequestOneofCase.Signout:
			if (Signout == null)
			{
				Signout = new Signout();
			}
			Signout.MergeFrom(other.Signout);
			break;
		case RequestOneofCase.GetActivateCode:
			if (GetActivateCode == null)
			{
				GetActivateCode = new GetActivateCode();
			}
			GetActivateCode.MergeFrom(other.GetActivateCode);
			break;
		case RequestOneofCase.NotificationData:
			if (NotificationData == null)
			{
				NotificationData = new NotificationData();
			}
			NotificationData.MergeFrom(other.NotificationData);
			break;
		case RequestOneofCase.MarkNotificationsRead:
			if (MarkNotificationsRead == null)
			{
				MarkNotificationsRead = new MarkNotificationsRead();
			}
			MarkNotificationsRead.MergeFrom(other.MarkNotificationsRead);
			break;
		case RequestOneofCase.GetLicenseState:
			if (GetLicenseState == null)
			{
				GetLicenseState = new GetLicenseState();
			}
			GetLicenseState.MergeFrom(other.GetLicenseState);
			break;
		case RequestOneofCase.RefreshUserAuthTokens:
			if (RefreshUserAuthTokens == null)
			{
				RefreshUserAuthTokens = new RefreshUserAuthTokens();
			}
			RefreshUserAuthTokens.MergeFrom(other.RefreshUserAuthTokens);
			break;
		case RequestOneofCase.RefreshAccessToken:
			if (RefreshAccessToken == null)
			{
				RefreshAccessToken = new RefreshAccessToken();
			}
			RefreshAccessToken.MergeFrom(other.RefreshAccessToken);
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
				Register register = new Register();
				if (requestCase_ == RequestOneofCase.Register)
				{
					register.MergeFrom(Register);
				}
				input.ReadMessage(register);
				Register = register;
				break;
			}
			case 18u:
			{
				Unregister unregister = new Unregister();
				if (requestCase_ == RequestOneofCase.Unregister)
				{
					unregister.MergeFrom(Unregister);
				}
				input.ReadMessage(unregister);
				Unregister = unregister;
				break;
			}
			case 26u:
			{
				ChangeSeatType changeSeatType = new ChangeSeatType();
				if (requestCase_ == RequestOneofCase.ChangeSeatType)
				{
					changeSeatType.MergeFrom(ChangeSeatType);
				}
				input.ReadMessage(changeSeatType);
				ChangeSeatType = changeSeatType;
				break;
			}
			case 34u:
			{
				GetBibles getBibles = new GetBibles();
				if (requestCase_ == RequestOneofCase.GetBibles)
				{
					getBibles.MergeFrom(GetBibles);
				}
				input.ReadMessage(getBibles);
				GetBibles = getBibles;
				break;
			}
			case 42u:
			{
				ActivateBible activateBible = new ActivateBible();
				if (requestCase_ == RequestOneofCase.ActivateBible)
				{
					activateBible.MergeFrom(ActivateBible);
				}
				input.ReadMessage(activateBible);
				ActivateBible = activateBible;
				break;
			}
			case 50u:
			{
				DeactivateBible deactivateBible = new DeactivateBible();
				if (requestCase_ == RequestOneofCase.DeactivateBible)
				{
					deactivateBible.MergeFrom(DeactivateBible);
				}
				input.ReadMessage(deactivateBible);
				DeactivateBible = deactivateBible;
				break;
			}
			case 58u:
			{
				DownloadBible downloadBible = new DownloadBible();
				if (requestCase_ == RequestOneofCase.DownloadBible)
				{
					downloadBible.MergeFrom(DownloadBible);
				}
				input.ReadMessage(downloadBible);
				DownloadBible = downloadBible;
				break;
			}
			case 66u:
			{
				RegistrationData registrationData = new RegistrationData();
				if (requestCase_ == RequestOneofCase.RegistrationData)
				{
					registrationData.MergeFrom(RegistrationData);
				}
				input.ReadMessage(registrationData);
				RegistrationData = registrationData;
				break;
			}
			case 74u:
			{
				ProductInformation productInformation = new ProductInformation();
				if (requestCase_ == RequestOneofCase.ProductInformation)
				{
					productInformation.MergeFrom(ProductInformation);
				}
				input.ReadMessage(productInformation);
				ProductInformation = productInformation;
				break;
			}
			case 82u:
			{
				GetAvailableVersion getAvailableVersion = new GetAvailableVersion();
				if (requestCase_ == RequestOneofCase.GetUpgradesAvailable)
				{
					getAvailableVersion.MergeFrom(GetUpgradesAvailable);
				}
				input.ReadMessage(getAvailableVersion);
				GetUpgradesAvailable = getAvailableVersion;
				break;
			}
			case 90u:
			{
				DownloadNewVersion downloadNewVersion = new DownloadNewVersion();
				if (requestCase_ == RequestOneofCase.DownloadNewVersion)
				{
					downloadNewVersion.MergeFrom(DownloadNewVersion);
				}
				input.ReadMessage(downloadNewVersion);
				DownloadNewVersion = downloadNewVersion;
				break;
			}
			case 98u:
			{
				Refresh refresh = new Refresh();
				if (requestCase_ == RequestOneofCase.Refresh)
				{
					refresh.MergeFrom(Refresh);
				}
				input.ReadMessage(refresh);
				Refresh = refresh;
				break;
			}
			case 106u:
			{
				ActivateLink activateLink = new ActivateLink();
				if (requestCase_ == RequestOneofCase.ActivateLink)
				{
					activateLink.MergeFrom(ActivateLink);
				}
				input.ReadMessage(activateLink);
				ActivateLink = activateLink;
				break;
			}
			case 114u:
			{
				UpdateToken updateToken = new UpdateToken();
				if (requestCase_ == RequestOneofCase.UpdateToken)
				{
					updateToken.MergeFrom(UpdateToken);
				}
				input.ReadMessage(updateToken);
				UpdateToken = updateToken;
				break;
			}
			case 122u:
			{
				OldTokenData oldTokenData = new OldTokenData();
				if (requestCase_ == RequestOneofCase.OldTokenData)
				{
					oldTokenData.MergeFrom(OldTokenData);
				}
				input.ReadMessage(oldTokenData);
				OldTokenData = oldTokenData;
				break;
			}
			case 130u:
			{
				Signout signout = new Signout();
				if (requestCase_ == RequestOneofCase.Signout)
				{
					signout.MergeFrom(Signout);
				}
				input.ReadMessage(signout);
				Signout = signout;
				break;
			}
			case 138u:
			{
				GetActivateCode getActivateCode = new GetActivateCode();
				if (requestCase_ == RequestOneofCase.GetActivateCode)
				{
					getActivateCode.MergeFrom(GetActivateCode);
				}
				input.ReadMessage(getActivateCode);
				GetActivateCode = getActivateCode;
				break;
			}
			case 146u:
			{
				NotificationData notificationData = new NotificationData();
				if (requestCase_ == RequestOneofCase.NotificationData)
				{
					notificationData.MergeFrom(NotificationData);
				}
				input.ReadMessage(notificationData);
				NotificationData = notificationData;
				break;
			}
			case 154u:
			{
				MarkNotificationsRead markNotificationsRead = new MarkNotificationsRead();
				if (requestCase_ == RequestOneofCase.MarkNotificationsRead)
				{
					markNotificationsRead.MergeFrom(MarkNotificationsRead);
				}
				input.ReadMessage(markNotificationsRead);
				MarkNotificationsRead = markNotificationsRead;
				break;
			}
			case 162u:
			{
				GetLicenseState getLicenseState = new GetLicenseState();
				if (requestCase_ == RequestOneofCase.GetLicenseState)
				{
					getLicenseState.MergeFrom(GetLicenseState);
				}
				input.ReadMessage(getLicenseState);
				GetLicenseState = getLicenseState;
				break;
			}
			case 170u:
			{
				RefreshUserAuthTokens refreshUserAuthTokens = new RefreshUserAuthTokens();
				if (requestCase_ == RequestOneofCase.RefreshUserAuthTokens)
				{
					refreshUserAuthTokens.MergeFrom(RefreshUserAuthTokens);
				}
				input.ReadMessage(refreshUserAuthTokens);
				RefreshUserAuthTokens = refreshUserAuthTokens;
				break;
			}
			case 178u:
			{
				RefreshAccessToken refreshAccessToken = new RefreshAccessToken();
				if (requestCase_ == RequestOneofCase.RefreshAccessToken)
				{
					refreshAccessToken.MergeFrom(RefreshAccessToken);
				}
				input.ReadMessage(refreshAccessToken);
				RefreshAccessToken = refreshAccessToken;
				break;
			}
			}
		}
	}
}
