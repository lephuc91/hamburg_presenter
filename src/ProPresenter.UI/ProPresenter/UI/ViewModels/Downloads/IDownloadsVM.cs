using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;

namespace ProPresenter.UI.ViewModels.Downloads;

public interface IDownloadsVM : IDisposable
{
	ReadOnlyReactivePropertySlim<int> PercentComplete { get; }

	ReadOnlyReactivePropertySlim<bool> IsActive { get; }

	ReadOnlyReactivePropertySlim<IReadOnlyCollection<IDownloadItemVM>> Items { get; }

	bool ShowsPopover { get; }

	IAsyncRelayCommand ClearCommand { get; }

	IRelayCommand<bool?> TogglePopoverCommand { get; }
}
