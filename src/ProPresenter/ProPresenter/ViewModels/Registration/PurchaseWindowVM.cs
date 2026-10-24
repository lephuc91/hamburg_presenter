using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.Registration;

namespace ProPresenter.ViewModels.Registration;

public sealed class PurchaseWindowVM : ObservableObject, IPurchaseWindowVM, INotifyPropertyChanged
{
	private const string RegistrationNameKey = "rvregname";

	private const string UnlockCodeKey = "rvpro7unlockcode";

	private const string PurchaseCompleteKey = "purchasecomplete";

	private const string TrialSuccessfulKey = "trialsuccessful";

	[ObservableProperty]
	private NameValueCollection? _currentHeaders;

	[ObservableProperty]
	private bool _isPurchaseComplete;

	public string RegistrationName { get; private set; } = string.Empty;

	public string UnlockCode { get; private set; } = string.Empty;

	public bool IsTrialComplete { get; private set; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public NameValueCollection? CurrentHeaders
	{
		get
		{
			return _currentHeaders;
		}
		set
		{
			if (!EqualityComparer<NameValueCollection>.Default.Equals(_currentHeaders, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CurrentHeaders);
				_currentHeaders = value;
				OnCurrentHeadersChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CurrentHeaders);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPurchaseComplete
	{
		get
		{
			return _isPurchaseComplete;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPurchaseComplete, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsPurchaseComplete);
				_isPurchaseComplete = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsPurchaseComplete);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentHeadersChanged(NameValueCollection? value)
	{
		IsPurchaseComplete |= value?.Get("purchasecomplete") == "true";
		IsTrialComplete |= value?.AllKeys.Contains<string>("trialsuccessful") ?? false;
		if (value != null && value.AllKeys.ContainsAll<string>(new string[2] { "rvregname", "rvpro7unlockcode" }))
		{
			RegistrationName = value.Get("rvregname") ?? string.Empty;
			UnlockCode = value.Get("rvpro7unlockcode") ?? string.Empty;
		}
	}
}
