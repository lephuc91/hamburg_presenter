using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using ProPresenter.DO.Web;
using ProPresenter.UI.Registration;

namespace ProPresenter.ViewModels.Bibles;

public class LegacyPurchaseBiblesDialogService : ILegacyPurchaseBiblesDialogService
{
	private sealed class PurchaseWindowContext : ObservableObject
	{
		private const string PurchaseCompleteKey = "purchasecomplete";

		[ObservableProperty]
		private bool _isPurchaseComplete;

		[ObservableProperty]
		private NameValueCollection? _currentHeaders;

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
		private void OnCurrentHeadersChanged(NameValueCollection? value)
		{
			IsPurchaseComplete = value?.Get("purchasecomplete") == "true";
		}
	}

	private readonly IWebSourceProvider _webSourceProvider;

	public LegacyPurchaseBiblesDialogService(IWebSourceProvider webSourceProvider)
	{
		_webSourceProvider = webSourceProvider;
	}

	public void ShowPurchaseDialog()
	{
		PurchaseWindow purchaseWindow = new PurchaseWindow
		{
			DataContext = new PurchaseWindowContext()
		};
		if (purchaseWindow.Owner == null)
		{
			purchaseWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}
		purchaseWindow.InAppLink = null;
		purchaseWindow.InAppLink = _webSourceProvider.GenerateLink(InAppStoreType.Bibles).ToString();
		purchaseWindow.StoreType = InAppStoreType.Bibles;
		if (!purchaseWindow.IsVisible)
		{
			purchaseWindow.ShowDialog();
		}
	}
}
