using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.IdentityModel.JsonWebTokens;
using Pro.Common.Logging;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State.Bible;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.Registration.CallbackHandlers.State.Extensions;
using ProPresenter.Registration.CallbackHandlers.State.Extensions.Bible;

namespace ProPresenter.DO.Registration.State;

public class RegistrationStateHandler : ObservableObject, IRegistrationCallbackHandler, IRegistrationStateProvider, INotifyPropertyChanged
{
	private readonly DateTime _currentBuildDate;

	private readonly string _deviceName;

	private readonly JsonWebTokenHandler _jsonWebTokenHandler;

	[ObservableProperty]
	private RegistrationState _registration;

	[ObservableProperty]
	private Metadata[] _freeBibles = Array.Empty<Metadata>();

	[ObservableProperty]
	private Purchased[] _purchasedBibles = Array.Empty<Purchased>();

	[ObservableProperty]
	[NotifyPropertyChangedFor("OrganizationId")]
	private OAuthToken? _token;

	[ObservableProperty]
	private BannerMessage _bannerMessage;

	[ObservableProperty]
	private HardwareInfo _hardwareInformation = new HardwareInfo(string.Empty, string.Empty);

	[Obsolete("Be very careful to only use the organization ID for logging purposes. The way we receive it is very fragile and can change any time.")]
	public string OrganizationId => GetOrganizationId();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public RegistrationState Registration
	{
		get
		{
			return _registration;
		}
		[MemberNotNull("_registration")]
		set
		{
			if (!EqualityComparer<RegistrationState>.Default.Equals(_registration, value))
			{
				RegistrationState registration = _registration;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Registration);
				_registration = value;
				OnRegistrationChanged(registration, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Registration);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Metadata[] FreeBibles
	{
		get
		{
			return _freeBibles;
		}
		[MemberNotNull("_freeBibles")]
		set
		{
			if (!EqualityComparer<Metadata[]>.Default.Equals(_freeBibles, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FreeBibles);
				_freeBibles = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FreeBibles);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Purchased[] PurchasedBibles
	{
		get
		{
			return _purchasedBibles;
		}
		[MemberNotNull("_purchasedBibles")]
		set
		{
			if (!EqualityComparer<Purchased[]>.Default.Equals(_purchasedBibles, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PurchasedBibles);
				_purchasedBibles = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PurchasedBibles);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public OAuthToken? Token
	{
		get
		{
			return _token;
		}
		set
		{
			if (!EqualityComparer<OAuthToken>.Default.Equals(_token, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Token);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.OrganizationId);
				_token = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Token);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.OrganizationId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BannerMessage BannerMessage
	{
		get
		{
			return _bannerMessage;
		}
		set
		{
			if (!EqualityComparer<BannerMessage>.Default.Equals(_bannerMessage, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BannerMessage);
				_bannerMessage = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BannerMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public HardwareInfo HardwareInformation
	{
		get
		{
			return _hardwareInformation;
		}
		[MemberNotNull("_hardwareInformation")]
		set
		{
			if (!EqualityComparer<HardwareInfo>.Default.Equals(_hardwareInformation, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.HardwareInformation);
				_hardwareInformation = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.HardwareInformation);
			}
		}
	}

	public event Action? PerformUpdateCheck;

	public RegistrationStateHandler(DateTime currentBuildDate, JsonWebTokenHandler jsonWebTokenHandler, string deviceName)
	{
		_currentBuildDate = currentBuildDate;
		_deviceName = deviceName;
		_jsonWebTokenHandler = jsonWebTokenHandler;
		_registration = new RegistrationState(new UndeterminedStateState(), new InitialState(deviceName), ProContentRegistrationState.NotSignedIn);
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		switch (responseCallback.CallbackCase)
		{
		case Callback.CallbackOneofCase.VerificationComplete:
			HandleVerificationComplete(responseCallback.VerificationComplete);
			return true;
		case Callback.CallbackOneofCase.ReadRegistrationData:
			HardwareInformation = new HardwareInfo(responseCallback.ReadRegistrationData.Fingerprint, responseCallback.ReadRegistrationData.Identifier);
			return true;
		default:
			return false;
		}
	}

	public void UpdateToken(string accessToken, string refreshToken, DateTimeOffset dateTimeOffset)
	{
		Token = new OAuthToken(accessToken, refreshToken, dateTimeOffset);
	}

	private void HandleVerificationComplete(VerificationComplete verificationComplete)
	{
		Token = verificationComplete.Token.ToOAuthToken();
		Registration = verificationComplete.ToRegistrationState(_currentBuildDate, _deviceName, Registration);
		if (verificationComplete.Bibles != null)
		{
			FreeBibles = ConvertToArray(verificationComplete.Bibles.FreeBibles, MetadataExtension.ToMetadata);
			PurchasedBibles = ConvertToArray(verificationComplete.Bibles.PurchasedBibles, PurchasedBibleExtension.ToPurchased);
		}
		BannerMessage = verificationComplete.Banner.ToBannerMessage();
	}

	private static TResult[] ConvertToArray<TInput, TResult>(IList<TInput> input, Func<TInput, TResult> convert)
	{
		if (input.Count == 0)
		{
			return Array.Empty<TResult>();
		}
		return input.Select(convert).ToArray();
	}

	private static bool EqualsRegistrationState(IRegistrationState oldValue, IRegistrationState newValue)
	{
		if (!(oldValue is UnregisteredState))
		{
			if (!(oldValue is CodeState codeState))
			{
				if (oldValue is global::ProPresenter.DO.Registration.State.ProPresenter.SubscribedState subscribedState)
				{
					return (newValue is UnregisteredState) ? (!subscribedState.SeatInfo.IsActive) : (!(newValue is CodeState) && newValue is global::ProPresenter.DO.Registration.State.ProPresenter.SubscribedState subscribedState2 && subscribedState.ActivationKey == subscribedState2.ActivationKey);
				}
				return false;
			}
			return (newValue is UnregisteredState) ? (!codeState.SeatInfo.IsActive) : ((newValue is CodeState codeState2) ? (codeState.ActivationKey == codeState2.ActivationKey && codeState.IsCurrentBuildCoveredByLicense == codeState2.IsCurrentBuildCoveredByLicense) : (!(newValue is global::ProPresenter.DO.Registration.State.ProPresenter.SubscribedState) && false));
		}
		return newValue is UnregisteredState;
	}

	private string GetOrganizationId()
	{
		if ((object)Token == null)
		{
			return string.Empty;
		}
		try
		{
			return _jsonWebTokenHandler.ReadJsonWebToken(Token.AccessToken).Claims.FirstOrDefault((Claim c) => c.Type == "organization_id")?.Value ?? string.Empty;
		}
		catch (Exception ex)
		{
			Pro.Common.Logging.Log.Error("[{0}] Failed to acquire the organization id:{1}", "IRegistrationStateProvider", ex);
			return string.Empty;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnRegistrationChanged(RegistrationState? oldValue, RegistrationState newValue)
	{
		if ((object)oldValue == null || !EqualsRegistrationState(oldValue.ProPresenter, newValue.ProPresenter))
		{
			this.PerformUpdateCheck?.Invoke();
		}
	}
}
