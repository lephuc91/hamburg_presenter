using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.RemoteFile;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;
using ProPresenter.ViewModels.DispatchingExtensions;
using Reactive.Bindings;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaCueThumbnailOverlayVM : ObservableObject, IMediaCueThumbnailOverlayVM, IMediaOverlayVM
{
	[ObservableProperty]
	private OverlayType _type;

	public ReadOnlyReactivePropertySlim<bool> IsValid { get; }

	public ReadOnlyReactivePropertySlim<DownloadProgress> DownloadProgress { get; }

	public ReadOnlyReactivePropertySlim<InvalidMediaType> InvalidMediaType { get; }

	public ReadOnlyReactivePropertySlim<MediaAvailability> CloudMediaAvailability { get; }

	public ICommand RelinkCommand { get; }

	public ICommand DownloadCommand { get; }

	public ICommand ReconnectVideoInputCommand { get; }

	public ICommand CancelDownloadCommand { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public OverlayType Type
	{
		get
		{
			return _type;
		}
		set
		{
			if (!EqualityComparer<OverlayType>.Default.Equals(_type, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Type);
				_type = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Type);
			}
		}
	}

	public MediaCueThumbnailOverlayVM(INotifyEnumerableChanged<IAction> actions, IDownloadManager downloadManager, IFileSelectorService fileSelector, IRemoteFileLoader remoteFileLoader, IImportProcessFactory importProcessFactory, IUiScheduler uiScheduler, ICommand? openLiveVideoSetupCommand = null)
	{
		IObservable<IEnumerable<MediaAction>> observable = (from _ in Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(delegate(NotifyCollectionChangedEventHandler e)
			{
				actions.CollectionChanged += e;
			}, delegate(NotifyCollectionChangedEventHandler e)
			{
				actions.CollectionChanged -= e;
			})
			select actions.OfType<MediaAction>().AsEnumerable()).StartWith(actions.OfType<MediaAction>().AsEnumerable());
		IObservable<IReadOnlyList<ActionDownloadItemMatch>> observable2 = downloadManager.WhenActionDownloadItemMapChanges(observable);
		IObservable<IList<MediaAction>> whenMediaValidityUpdates = observable.WhenMediaValidityUpdates();
		DownloadProgress = observable2.WhenOverallDownloadProgressChanges().ToReadOnlyReactivePropertySlim(uiScheduler, Pro.Common.Downloads.DownloadProgress.Empty);
		IsValid = observable2.Select(WhenIsValidChanges).Switch().ToReadOnlyReactivePropertySlim(uiScheduler, initialValue: true);
		InvalidMediaType = observable2.WhenInvalidMediaTypeChanges().ToReadOnlyReactivePropertySlim(uiScheduler);
		CloudMediaAvailability = (from x in (from x in observable.SelectMany((IEnumerable<MediaAction> x) => x)
				select x.FileMedia into x
				where x != null
				select (x)).WhenPropertyChanges("Availability")
			select x.Availability).ToReadOnlyReactivePropertySlim(uiScheduler, (actions.OfType<MediaAction>().FirstOrDefault()?.FileMedia?.Availability).GetValueOrDefault(), ReactivePropertyMode.RaiseLatestValueOnSubscribe);
		DownloadCommand = observable2.ToDownloadCommand(((IEnumerable)actions).OfType<MediaAction>, remoteFileLoader, uiScheduler);
		RelinkCommand = whenMediaValidityUpdates.ToRelinkCommand(((IEnumerable)actions).OfType<MediaAction>, fileSelector, importProcessFactory);
		ReconnectVideoInputCommand = whenMediaValidityUpdates.ToReconnectCommand(openLiveVideoSetupCommand);
		CancelDownloadCommand = DownloadProgress.ToCancelDownloadCommand(observable2);
		observable2.Select(GetFileNameUpdates).Switch().Subscribe(EnsureFilePathGetsUpdated);
	}

	private IObservable<bool> WhenIsValidChanges(IReadOnlyList<ActionDownloadItemMatch> matchedDownloadItems)
	{
		if (matchedDownloadItems.Count == 0)
		{
			return Observable.Return(value: true);
		}
		return matchedDownloadItems.Select(WhenIsValidOnActionChanges).CombineLatest((IList<bool> isValid) => isValid.All((bool v) => v));
	}

	private IObservable<bool> WhenIsValidOnActionChanges(ActionDownloadItemMatch match)
	{
		IObservable<bool> observable = (from update in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler e)
			{
				match.Action.PropertyChanged += e;
			}, delegate(PropertyChangedEventHandler e)
			{
				match.Action.PropertyChanged -= e;
			})
			where update.EventArgs.PropertyName == "IsValid"
			select update into _
			select match.Action.IsValid).StartWith(match.Action.IsValid);
		if (match.DownloadItems.Count == 0)
		{
			return observable;
		}
		IObservable<bool> second = from progresses in match.DownloadItems.Select((IDownloadItem i) => i.WhenDownloadProgressChanged).CombineLatest()
			select progresses.Any((DownloadProgress p) => p.Status != DownloadStatus.Active);
		return from values in observable.CombineLatest(second)
			select values.mediaValidity && values.isNotDownloading;
	}

	private IObservable<(string FilePath, MediaAction Action)> GetFileNameUpdates(IReadOnlyList<ActionDownloadItemMatch> matchedDownloadItems)
	{
		return matchedDownloadItems.Select((ActionDownloadItemMatch match) => from path in match.DownloadItems.Select((IDownloadItem item) => item.WhenFileDestinationChanged).Merge()
			select (FilePath: path, Action: match.Action)).Merge();
	}

	private void EnsureFilePathGetsUpdated((string FilePath, MediaAction Action) values)
	{
		(string FilePath, MediaAction Action) tuple = values;
		var (path, _) = tuple;
		tuple.Action.FileMedia?.UpdateSource(userInitiated: true, new RelativePath(path));
	}
}
