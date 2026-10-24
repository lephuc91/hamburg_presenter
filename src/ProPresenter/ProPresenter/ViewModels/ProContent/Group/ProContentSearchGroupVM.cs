using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.UI.Themes;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Group;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent.Group;

public class ProContentSearchGroupVM : ProContentGroupVM, IProContentSearchGroupVMInternal, IProContentGroupVMInternal, IProContentGroupVM, INavigationItem, INotifyPropertyChanged, IDisposable, IProContentSearchGroupVM
{
	private static readonly TimeSlice SearchDelayTime = TimeSlice.FromSeconds(0.5);

	private readonly IProContentProvider _provider;

	private readonly IPeriodicTimer _searchTimer;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<bool?>? performSearchCommand;

	public IProContentSearchGroup SearchGroup { get; }

	public string SearchTerm
	{
		get
		{
			return SearchGroup.SearchTerm;
		}
		set
		{
			SearchGroup.SearchTerm = value;
		}
	}

	public bool SearchInProgress => SearchGroup.SearchInProgress;

	private bool CanExecuteSearch
	{
		get
		{
			if (!string.IsNullOrEmpty(SearchTerm))
			{
				return SearchTerm.Length >= 2;
			}
			return true;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ClearSearchCommand => clearSearchCommand ?? (clearSearchCommand = new AsyncRelayCommand(ClearSearch, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<bool?> PerformSearchCommand => performSearchCommand ?? (performSearchCommand = new AsyncRelayCommand<bool?>(PerformSearch, CanPerformSearch, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public ProContentSearchGroupVM(IProContentProvider provider, IProContentSearchGroup searchGroup, INavigationItem parent, IProContentVMsFactory factory, ITimerFactory timerFactory)
		: base(searchGroup, parent, factory)
	{
		_provider = provider;
		_searchTimer = timerFactory.CreatePeriodicDispatched(SearchDelayTime, OnSearchTimerTick);
		SearchGroup = searchGroup;
		base.Icon = Application.Current?.TryFindResource(Icons.Search) as ImageSource;
		searchGroup.PropertyChanged += SearchGroup_PropertyChanged;
	}

	private void SearchGroup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "SearchTerm"))
		{
			if (propertyName == "SearchInProgress")
			{
				OnPropertyChanged("SearchInProgress");
			}
		}
		else
		{
			OnPropertyChanged("SearchTerm");
			_searchTimer.Stop();
			_searchTimer.Start();
		}
	}

	private void OnSearchTimerTick()
	{
		PerformSearchCommand.Execute(false);
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task ClearSearch()
	{
		SearchTerm = string.Empty;
		await PerformSearch(true);
	}

	[RelayCommand(CanExecute = "CanPerformSearch", FlowExceptionsToTaskScheduler = true)]
	private async Task PerformSearch(bool? forceExecuteSearch)
	{
		_searchTimer.Stop();
		if (CanPerformSearch(forceExecuteSearch))
		{
			await _provider.RefreshAsync(SearchGroup);
		}
	}

	private bool CanPerformSearch(bool? forceExecuteSearch)
	{
		if (!(forceExecuteSearch ?? true))
		{
			return CanExecuteSearch;
		}
		return true;
	}
}
