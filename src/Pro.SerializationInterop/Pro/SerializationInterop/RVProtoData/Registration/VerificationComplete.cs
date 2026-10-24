using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Registration;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class VerificationComplete : IMessage<VerificationComplete>, IMessage, IEquatable<VerificationComplete>, IDeepCloneable<VerificationComplete>
{
	private static readonly MessageParser<VerificationComplete> _parser = new MessageParser<VerificationComplete>(() => new VerificationComplete());

	private UnknownFieldSet _unknownFields;

	public const int ResultFieldNumber = 1;

	private Status result_;

	public const int LicenseFieldNumber = 2;

	private LicenseInfo license_;

	public const int BiblesFieldNumber = 3;

	private Bibles bibles_;

	public const int TokenFieldNumber = 4;

	private TokenMetadata token_;

	public const int SubscriptionInfoFieldNumber = 5;

	private SubscriptionInfo subscriptionInfo_;

	public const int AlertFieldNumber = 6;

	private PopupAlertMessage alert_;

	public const int BannerFieldNumber = 7;

	private BannerMessage banner_;

	public const int ClientAlertFieldNumber = 8;

	private ClientAlertMessage clientAlert_;

	public const int FullyLaunchedFieldNumber = 9;

	private bool fullyLaunched_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<VerificationComplete> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RegistrationReflection.Descriptor.MessageTypes[38];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Status Result
	{
		get
		{
			return result_;
		}
		set
		{
			result_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LicenseInfo License
	{
		get
		{
			return license_;
		}
		set
		{
			license_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Bibles Bibles
	{
		get
		{
			return bibles_;
		}
		set
		{
			bibles_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TokenMetadata Token
	{
		get
		{
			return token_;
		}
		set
		{
			token_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SubscriptionInfo SubscriptionInfo
	{
		get
		{
			return subscriptionInfo_;
		}
		set
		{
			subscriptionInfo_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PopupAlertMessage Alert
	{
		get
		{
			return alert_;
		}
		set
		{
			alert_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BannerMessage Banner
	{
		get
		{
			return banner_;
		}
		set
		{
			banner_ = value;
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
	public bool FullyLaunched
	{
		get
		{
			return fullyLaunched_;
		}
		set
		{
			fullyLaunched_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VerificationComplete()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VerificationComplete(VerificationComplete other)
		: this()
	{
		result_ = other.result_;
		license_ = ((other.license_ != null) ? other.license_.Clone() : null);
		bibles_ = ((other.bibles_ != null) ? other.bibles_.Clone() : null);
		token_ = ((other.token_ != null) ? other.token_.Clone() : null);
		subscriptionInfo_ = ((other.subscriptionInfo_ != null) ? other.subscriptionInfo_.Clone() : null);
		alert_ = other.alert_;
		banner_ = other.banner_;
		clientAlert_ = other.clientAlert_;
		fullyLaunched_ = other.fullyLaunched_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VerificationComplete Clone()
	{
		return new VerificationComplete(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as VerificationComplete);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(VerificationComplete other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Result != other.Result)
		{
			return false;
		}
		if (!object.Equals(License, other.License))
		{
			return false;
		}
		if (!object.Equals(Bibles, other.Bibles))
		{
			return false;
		}
		if (!object.Equals(Token, other.Token))
		{
			return false;
		}
		if (!object.Equals(SubscriptionInfo, other.SubscriptionInfo))
		{
			return false;
		}
		if (Alert != other.Alert)
		{
			return false;
		}
		if (Banner != other.Banner)
		{
			return false;
		}
		if (ClientAlert != other.ClientAlert)
		{
			return false;
		}
		if (FullyLaunched != other.FullyLaunched)
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
		if (Result != 0)
		{
			num ^= Result.GetHashCode();
		}
		if (license_ != null)
		{
			num ^= License.GetHashCode();
		}
		if (bibles_ != null)
		{
			num ^= Bibles.GetHashCode();
		}
		if (token_ != null)
		{
			num ^= Token.GetHashCode();
		}
		if (subscriptionInfo_ != null)
		{
			num ^= SubscriptionInfo.GetHashCode();
		}
		if (Alert != 0)
		{
			num ^= Alert.GetHashCode();
		}
		if (Banner != 0)
		{
			num ^= Banner.GetHashCode();
		}
		if (ClientAlert != 0)
		{
			num ^= ClientAlert.GetHashCode();
		}
		if (FullyLaunched)
		{
			num ^= FullyLaunched.GetHashCode();
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
		if (Result != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Result);
		}
		if (license_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(License);
		}
		if (bibles_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Bibles);
		}
		if (token_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Token);
		}
		if (subscriptionInfo_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(SubscriptionInfo);
		}
		if (Alert != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)Alert);
		}
		if (Banner != 0)
		{
			output.WriteRawTag(56);
			output.WriteEnum((int)Banner);
		}
		if (ClientAlert != 0)
		{
			output.WriteRawTag(64);
			output.WriteEnum((int)ClientAlert);
		}
		if (FullyLaunched)
		{
			output.WriteRawTag(72);
			output.WriteBool(FullyLaunched);
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
		if (Result != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Result);
		}
		if (license_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(License);
		}
		if (bibles_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Bibles);
		}
		if (token_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Token);
		}
		if (subscriptionInfo_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SubscriptionInfo);
		}
		if (Alert != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Alert);
		}
		if (Banner != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Banner);
		}
		if (ClientAlert != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ClientAlert);
		}
		if (FullyLaunched)
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
	public void MergeFrom(VerificationComplete other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Result != 0)
		{
			Result = other.Result;
		}
		if (other.license_ != null)
		{
			if (license_ == null)
			{
				License = new LicenseInfo();
			}
			License.MergeFrom(other.License);
		}
		if (other.bibles_ != null)
		{
			if (bibles_ == null)
			{
				Bibles = new Bibles();
			}
			Bibles.MergeFrom(other.Bibles);
		}
		if (other.token_ != null)
		{
			if (token_ == null)
			{
				Token = new TokenMetadata();
			}
			Token.MergeFrom(other.Token);
		}
		if (other.subscriptionInfo_ != null)
		{
			if (subscriptionInfo_ == null)
			{
				SubscriptionInfo = new SubscriptionInfo();
			}
			SubscriptionInfo.MergeFrom(other.SubscriptionInfo);
		}
		if (other.Alert != 0)
		{
			Alert = other.Alert;
		}
		if (other.Banner != 0)
		{
			Banner = other.Banner;
		}
		if (other.ClientAlert != 0)
		{
			ClientAlert = other.ClientAlert;
		}
		if (other.FullyLaunched)
		{
			FullyLaunched = other.FullyLaunched;
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
			case 8u:
				Result = (Status)input.ReadEnum();
				break;
			case 18u:
				if (license_ == null)
				{
					License = new LicenseInfo();
				}
				input.ReadMessage(License);
				break;
			case 26u:
				if (bibles_ == null)
				{
					Bibles = new Bibles();
				}
				input.ReadMessage(Bibles);
				break;
			case 34u:
				if (token_ == null)
				{
					Token = new TokenMetadata();
				}
				input.ReadMessage(Token);
				break;
			case 42u:
				if (subscriptionInfo_ == null)
				{
					SubscriptionInfo = new SubscriptionInfo();
				}
				input.ReadMessage(SubscriptionInfo);
				break;
			case 48u:
				Alert = (PopupAlertMessage)input.ReadEnum();
				break;
			case 56u:
				Banner = (BannerMessage)input.ReadEnum();
				break;
			case 64u:
				ClientAlert = (ClientAlertMessage)input.ReadEnum();
				break;
			case 72u:
				FullyLaunched = input.ReadBool();
				break;
			}
		}
	}
}
