using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.UI.ViewModels.Downloads;
using ProPresenter.ViewModels.DispatchingExtensions;
using Reactive.Bindings;

namespace ProPresenter.ViewModels.Downloads;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "Items", "PercentComplete", "IsActive" })]
public class DownloadsVM : ObservableObject, IDownloadsVM, IDisposable
{
	private const int PROGRESS_FOR_NO_ACTIVE_ITEM = 100;

	private readonly IDownloadManager _downloadManager;

	private readonly IDownloadsDialogService _dialogService;

	[ObservableProperty]
	private bool _showsPopover;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? clearCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<bool?>? togglePopoverCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ReadOnlyReactivePropertySlim<IReadOnlyCollection<IDownloadItemVM>> Items { get; }

	public ReadOnlyReactivePropertySlim<int> PercentComplete { get; }

	public ReadOnlyReactivePropertySlim<bool> IsActive { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowsPopover
	{
		get
		{
			return _showsPopover;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showsPopover, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ShowsPopover);
				_showsPopover = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ShowsPopover);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ClearCommand => clearCommand ?? (clearCommand = new AsyncRelayCommand(Clear, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<bool?> TogglePopoverCommand => togglePopoverCommand ?? (togglePopoverCommand = new RelayCommand<bool?>(TogglePopover, CanShowPopover));

	public DownloadsVM(IDownloadManager downloadManager, IDownloadVMsFactory factory, IDownloadsDialogService dialogService, IUiScheduler uiScheduler)
	{
		DownloadsVM downloadsVM = this;
		_downloadManager = downloadManager;
		_dialogService = dialogService;
		Items = ((IObservable<IReadOnlyCollection<IDownloadItemVM>>)downloadManager.WhenDownloadItemsChanged.Select((IReadOnlyList<IDownloadItem> items) => items.Select((IDownloadItem i) => factory.Create(i)).ToArray())).Scan((IReadOnlyCollection<IDownloadItemVM>)(object)Array.Empty<IDownloadItemVM>(), delegate(IReadOnlyCollection<IDownloadItemVM> oldItems, IReadOnlyCollection<IDownloadItemVM> newItems)
		{
			oldItems.ForEach(delegate(IDownloadItemVM i)
			{
				i.Dispose();
			});
			return newItems;
		}).ToReadOnlyReactivePropertySlim<IReadOnlyCollection<IDownloadItemVM>>(uiScheduler, (IReadOnlyCollection<IDownloadItemVM>)(object)Array.Empty<IDownloadItemVM>());
		PercentComplete = downloadManager.WhenDownloadItemsChanged.Select(GetOverallProgressObservableFromItemList).Switch().ToReadOnlyReactivePropertySlim(uiScheduler);
		IsActive = downloadManager.WhenDownloadItemsChanged.Select(GetIsActiveObservableFromItemList).Switch().ToReadOnlyReactivePropertySlim(uiScheduler);
		Items.Subscribe(delegate(IReadOnlyCollection<IDownloadItemVM> items)
		{
			downloadsVM.TogglePopoverCommand.NotifyCanExecuteChanged();
			if (items.Count == 0)
			{
				downloadsVM.ShowsPopover = false;
			}
		});
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task Clear()
	{
		bool doCleanup = false;
		if (_downloadManager.HasStoppedItems())
		{
			doCleanup = _dialogService.ShowCleanupPlaceholderActions();
		}
		await _downloadManager.RemoveAllAsync((IDownloadItem item) => item.Status != DownloadStatus.Active, doCleanup);
	}

	[RelayCommand(CanExecute = "CanShowPopover")]
	private void TogglePopover(bool? desiredState)
	{
		if (CanShowPopover(desiredState))
		{
			if (desiredState.HasValue)
			{
				ShowsPopover = desiredState.Value;
			}
			else
			{
				ShowsPopover = !ShowsPopover;
			}
		}
	}

	private bool CanShowPopover(bool? _)
	{
		return Items.Value.Count > 0;
	}

	private IObservable<bool> GetIsActiveObservableFromItemList(IReadOnlyList<IDownloadItem> items)
	{
		if (items.Count == 0)
		{
			return Observable.Return(value: false);
		}
		return items.Select((IDownloadItem i) => i.WhenDownloadProgressChanged).CombineLatest((IList<DownloadProgress> progresses) => progresses.Any((DownloadProgress p) => p.Status == DownloadStatus.Active));
	}

	private IObservable<int> GetOverallProgressObservableFromItemList(IReadOnlyList<IDownloadItem> items)
	{
		if (items.Count == 0)
		{
			return Observable.Return(100);
		}
		return items.Select((IDownloadItem i) => i.WhenDownloadProgressChanged).CombineLatest(CalculateOverallProgressPercentage);
	}

	private int CalculateOverallProgressPercentage(IList<DownloadProgress> items)
	{
		IEnumerable<DownloadProgress> source = items.Where((DownloadProgress i) => i.Status == DownloadStatus.Active);
		if (!source.Any())
		{
			return 100;
		}
		var (num, num2) = source.Aggregate((0L, 0L), ((long total, long current) previous, DownloadProgress item) => (total: previous.total + item.TotalBytes, current: previous.current + item.ReceivedBytes));
		if (num <= 0)
		{
			return 0;
		}
		return (int)(100 * num2 / num);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			Items.Dispose();
			PercentComplete.Dispose();
			IsActive.Dispose();
		}
	}
}
