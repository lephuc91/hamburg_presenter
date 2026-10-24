using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.ViewModels.Welcome;

public class ScreenSetupVM : ObservableObject, IScreenSetupVM, INotifyPropertyChanged
{
	private sealed class ArrangmentMainHardwareRectangleSelector : ObservableObject, ISimpleScreenConfiguration, INotifyPropertyChanged
	{
		private readonly ScreenArrangementCollectionBase _arrangementCollection;

		private ScreenArrangementBase? _arrangement;

		private Screen? _screen;

		public HardwareScreenRectangleOptions? MainOutput => _screen?.MainOutput;

		public bool IsConfigured => _arrangementCollection.Any();

		public bool IsComplex
		{
			get
			{
				if (_arrangementCollection.Count <= 1)
				{
					ScreenArrangementBase? arrangement = _arrangement;
					return ((arrangement != null) ? arrangement.Screens.Length : 0) > 1;
				}
				return true;
			}
		}

		public ArrangmentMainHardwareRectangleSelector(ScreenArrangementCollectionBase arrangementCollection)
		{
			_arrangementCollection = arrangementCollection;
			_arrangementCollection.CollectionChanged += ArrangementCollection_CollectionChanged;
			UpdateArrangment();
		}

		private void ArrangementCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			UpdateArrangment();
		}

		private void UpdateArrangment()
		{
			HashSet<string> hashSet = new HashSet<string>();
			if (_arrangement != null)
			{
				_arrangement.PropertyChanged -= Arrangement_ScreensChanged;
				_arrangement = null;
				_screen = null;
				hashSet.Add("MainOutput");
			}
			if (_arrangementCollection.Count == 1)
			{
				_arrangement = _arrangementCollection.First();
				_arrangement.PropertyChanged += Arrangement_ScreensChanged;
				UpdateScreen(hashSet);
			}
			hashSet.Add("IsConfigured");
			hashSet.Add("IsComplex");
			NotifyChanges(hashSet);
		}

		private void Arrangement_ScreensChanged(object? sender, PropertyChangedEventArgs e)
		{
			HashSet<string> changeNotifications = new HashSet<string>();
			UpdateScreen(changeNotifications);
			NotifyChanges(changeNotifications);
		}

		private void UpdateScreen(ISet<string> changeNotifications)
		{
			if (_screen != null)
			{
				_screen.MainOutput.PropertyChanged -= MainOutput_PropertyChanged;
				_screen = null;
			}
			ScreenArrangementBase? arrangement = _arrangement;
			if (arrangement != null && arrangement.Screens.Length == 1)
			{
				_screen = _arrangement.Screens[0];
				_screen.MainOutput.PropertyChanged += MainOutput_PropertyChanged;
			}
			changeNotifications.Add("MainOutput");
			changeNotifications.Add("IsComplex");
		}

		private void MainOutput_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged("MainOutput");
		}

		private void NotifyChanges(ISet<string> changeNotifications)
		{
			foreach (string changeNotification in changeNotifications)
			{
				OnPropertyChanged(changeNotification);
			}
		}
	}

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWelcomeAnalyticEventsPublisher _analytics;

	private readonly IWebSourceProvider _webSource;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openScreenConfigurationHelpCommand;

	public IScreenConfigVM ScreenConfigVM { get; }

	public ISimpleScreenConfiguration AudienceScreen { get; }

	public ISimpleScreenConfiguration StageScreen { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenScreenConfigurationHelpCommand => openScreenConfigurationHelpCommand ?? (openScreenConfigurationHelpCommand = new RelayCommand(OpenScreenConfigurationHelp));

	public ScreenSetupVM(IScreenConfigVM screenConfigVM, IHyperlinkService hyperlinkService, IWelcomeAnalyticEventsPublisher analytics, IWebSourceProvider webSource)
	{
		ScreenConfigVM = screenConfigVM;
		_hyperlinkService = hyperlinkService;
		_analytics = analytics;
		_webSource = webSource;
		AudienceScreen = new ArrangmentMainHardwareRectangleSelector(ScreenConfigVM.AudienceArrangementScreens);
		StageScreen = new ArrangmentMainHardwareRectangleSelector(ScreenConfigVM.StageArrangementScreens);
	}

	[RelayCommand]
	private void OpenScreenConfigurationHelp()
	{
		_analytics.ScreenConfigurationHelp();
		_hyperlinkService.Open(_webSource.ScreenConfiguration);
	}
}
