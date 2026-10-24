using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Localization;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaBinHeaderNavigatorVM : ObservableObject, IMediaBinHeaderNavigatorVM, INavigationItem, INotifyPropertyChanged
{
	private readonly IProContentVM _proContentVM;

	private readonly IMediaPlaylistVM _playlistVM;

	private readonly PlaylistNavigationItem _playlistRoot;

	private bool _ignoreSelectionChange;

	private readonly Stack<INavigationItem> _backWardStack = new Stack<INavigationItem>();

	private readonly Stack<INavigationItem> _forwardStack = new Stack<INavigationItem>();

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("NavigateBackwardCommand", new string[] { "NavigateForwardCommand" })]
	private INavigationItem? _currentItem;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateBackwardCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateForwardCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<INavigationItem>? selectItemCommand;

	public ObservableCollection<INavigationItem> SelectedPath { get; } = new ObservableCollection<INavigationItem>();

	public INavigationItem? Parent => null;

	public IEnumerable Children => new INavigationItem[2] { _proContentVM, _playlistRoot };

	public ImageSource? Icon => null;

	public string Name => string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public INavigationItem? CurrentItem
	{
		get
		{
			return _currentItem;
		}
		set
		{
			if (!EqualityComparer<INavigationItem>.Default.Equals(_currentItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CurrentItem);
				_currentItem = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CurrentItem);
				NavigateBackwardCommand.NotifyCanExecuteChanged();
				NavigateForwardCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateBackwardCommand => navigateBackwardCommand ?? (navigateBackwardCommand = new AsyncRelayCommand(NavigateBackward, CanNavigateBackward, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateForwardCommand => navigateForwardCommand ?? (navigateForwardCommand = new AsyncRelayCommand(NavigateForward, CanNavigateForward, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<INavigationItem> SelectItemCommand => selectItemCommand ?? (selectItemCommand = new AsyncRelayCommand<INavigationItem>(SelectItem, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public MediaBinHeaderNavigatorVM(IProContentVM proContentVM, IMediaPlaylistVM playlistVM)
	{
		_proContentVM = proContentVM;
		_playlistVM = playlistVM;
		_playlistRoot = new PlaylistNavigationItem(this, _playlistVM.Playlists, LocalizedStrings.Get("LIBRARY_PLAYLIST_EXPORT_MULTIPLE_PLAYLISTS_SAVE_NAME_title"));
		OnPlaylistSelectedPlaylistChanged();
		_playlistVM.PropertyChanged += VM_PropertyChanged;
		_proContentVM.PropertyChanged += VM_PropertyChanged;
	}

	private void VM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "ActivePlaylist"))
		{
			if (propertyName == "CurrentGroup")
			{
				OnProContentSelectedCountentGroupChanged();
			}
		}
		else
		{
			OnPlaylistSelectedPlaylistChanged();
		}
	}

	[RelayCommand(CanExecute = "CanNavigateBackward", FlowExceptionsToTaskScheduler = true)]
	private async Task NavigateBackward()
	{
		_ignoreSelectionChange = true;
		INavigationItem navigationItem = FindNextNavigatable(_backWardStack);
		if (navigationItem != null)
		{
			if (CurrentItem != null)
			{
				_forwardStack.Push(CurrentItem);
			}
			_backWardStack.Pop();
			await NavigateAsync(navigationItem);
		}
		_ignoreSelectionChange = false;
	}

	private bool CanNavigateBackward()
	{
		return _backWardStack.Any();
	}

	[RelayCommand(CanExecute = "CanNavigateForward", FlowExceptionsToTaskScheduler = true)]
	private async Task NavigateForward()
	{
		_ignoreSelectionChange = true;
		INavigationItem navigationItem = FindNextNavigatable(_forwardStack);
		if (navigationItem != null)
		{
			if (CurrentItem != null)
			{
				_backWardStack.Push(CurrentItem);
			}
			_forwardStack.Pop();
			await NavigateAsync(navigationItem);
		}
		_ignoreSelectionChange = false;
	}

	private bool CanNavigateForward()
	{
		return _forwardStack.Any();
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	public async Task SelectItem(INavigationItem item)
	{
		await InternalSelectItemAsync(item);
	}

	private async Task InternalSelectItemAsync(INavigationItem item)
	{
		if (item is IProContentGroupVM group)
		{
			await _proContentVM.NavigateAsync(group);
			_proContentVM.FocusSearchBox = false;
			if (group is IProContentSearchGroupVM)
			{
				_proContentVM.FocusSearchBox = true;
			}
		}
		else if (item is PlaylistNavigationItem { Playlist: VisualPlaylist playlist })
		{
			_playlistVM.ActivePlaylist = playlist;
		}
	}

	private INavigationItem? FindNextNavigatable(Stack<INavigationItem> stack)
	{
		if (stack.Count == 0)
		{
			return null;
		}
		INavigationItem navigationItem = stack.Peek();
		if (IsNavigatable(navigationItem))
		{
			return navigationItem;
		}
		stack.Pop();
		return FindNextNavigatable(stack);
	}

	private bool IsNavigatable(INavigationItem item)
	{
		if (item is IProContentGroupVM)
		{
			return true;
		}
		if (item is PlaylistNavigationItem { Playlist: VisualPlaylist playlist })
		{
			return _playlistRoot.FindItem(playlist) != null;
		}
		return false;
	}

	private async Task NavigateAsync(INavigationItem item)
	{
		CurrentItem = item;
		await InternalSelectItemAsync(item);
		GenerateNavigationPath(item);
	}

	private void OnPlaylistSelectedPlaylistChanged()
	{
		if (!_ignoreSelectionChange && _playlistVM.ActivePlaylist != null)
		{
			INavigationItem navigationItem = _playlistRoot.FindItem(_playlistVM.ActivePlaylist);
			if (navigationItem != null)
			{
				MakeItemCurrent(navigationItem);
				GenerateNavigationPath(navigationItem);
			}
		}
	}

	private void OnProContentSelectedCountentGroupChanged()
	{
		if (!_ignoreSelectionChange && _proContentVM.CurrentGroup != null)
		{
			MakeItemCurrent(_proContentVM.CurrentGroup);
			GenerateNavigationPath(_proContentVM.CurrentGroup);
		}
	}

	private void MakeItemCurrent(INavigationItem item)
	{
		if (CurrentItem != null)
		{
			_backWardStack.Push(CurrentItem);
		}
		CurrentItem = item;
	}

	private void GenerateNavigationPath(INavigationItem item, ObservableCollection<INavigationItem> path)
	{
		if (item != null)
		{
			path.Insert(0, item);
			if (item.Parent != null && item.Parent != this)
			{
				GenerateNavigationPath(item.Parent, path);
			}
		}
	}

	private void GenerateNavigationPath(INavigationItem item)
	{
		SelectedPath.Clear();
		GenerateNavigationPath(item, SelectedPath);
	}
}
