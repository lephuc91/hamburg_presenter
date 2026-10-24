using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.UI.ViewModels.Thumbnails;
using Reactive.Bindings;

namespace ProPresenter.RemoteFile;

public static class RemoteFileHelper
{
	public static IObservable<IReadOnlyList<ActionDownloadItemMatch>> WhenActionDownloadItemMapChanges(this IDownloadManager downloadManager, IObservable<IEnumerable<MediaAction>> whenMediaActionListChanges)
	{
		return whenMediaActionListChanges.CombineLatest(downloadManager.WhenDownloadItemsChanged).Select(GetMatchingDownloadItems);
	}

	public static IObservable<DownloadProgress> WhenOverallDownloadProgressChanges(this IObservable<IReadOnlyList<ActionDownloadItemMatch>> whenActionDownloadItemMapChanges)
	{
		return whenActionDownloadItemMapChanges.Select(GetOverallProgress).DistinctUntilChanged().Switch();
	}

	public static IObservable<IList<MediaAction>> WhenMediaValidityUpdates(this IObservable<IEnumerable<MediaAction>> whenMediaActionListChanges)
	{
		return whenMediaActionListChanges.Select(WhenMediaValidityUpdates).Switch();
	}

	public static IObservable<IList<MediaCue>> WhenMediaValidityUpdates(this IObservable<IEnumerable<MediaCue>> whenMediaCueListChanges)
	{
		return whenMediaCueListChanges.Select(WhenMediaCueValidityUpdates).Switch();
	}

	public static IObservable<InvalidMediaType> WhenInvalidMediaTypeChanges(this IObservable<IReadOnlyList<ActionDownloadItemMatch>> whenActionDownloadItemMapChanges)
	{
		return whenActionDownloadItemMapChanges.Select(CalculateInvalidMediaType).DistinctUntilChanged();
	}

	public static ICommand ToDownloadCommand(this IObservable<IReadOnlyList<ActionDownloadItemMatch>> whenActionDownloadItemMapChanges, Func<IEnumerable<MediaAction>> getActionList, IRemoteFileLoader remoteFileLoader, IUiScheduler uiScheduler)
	{
		return whenActionDownloadItemMapChanges.Select(CanDownload).Switch().DistinctUntilChanged()
			.ObserveOn(uiScheduler.Scheduler)
			.ToAsyncReactiveCommand()
			.WithSubscribe(() => DownloadAsync(getActionList, remoteFileLoader));
	}

	public static ICommand ToRelinkCommand(this IObservable<IList<MediaAction>> whenMediaValidityUpdates, Func<IEnumerable<MediaAction>> getActionList, IFileSelectorService fileSelector, IImportProcessFactory importProcessFactory)
	{
		return whenMediaValidityUpdates.Select(CanRelink).DistinctUntilChanged().ToReactiveCommand(initialValue: false)
			.WithSubscribe(delegate
			{
				Relink(getActionList, fileSelector, importProcessFactory);
			});
	}

	public static ICommand ToRelinkCommand(this IObservable<IList<MediaCue>> whenMediaValidityUpdates, Func<IEnumerable<MediaCue>> getMediaCues, IFileSelectorService fileSelector, IImportProcessFactory importProcessFactory)
	{
		return whenMediaValidityUpdates.Select(CanRelink).DistinctUntilChanged().ToReactiveCommand(initialValue: false)
			.WithSubscribe(delegate
			{
				Relink(getMediaCues, fileSelector, importProcessFactory);
			});
	}

	public static ICommand ToReconnectCommand(this IObservable<IList<MediaAction>> whenMediaValidityUpdates, ICommand? openLiveVideoSetupCommand)
	{
		if (openLiveVideoSetupCommand == null)
		{
			return Observable.Empty<bool>().ToReactiveCommand(initialValue: false);
		}
		return whenMediaValidityUpdates.Select(CanReconnectVideoInput).DistinctUntilChanged().ToReactiveCommand(initialValue: false)
			.WithSubscribe(delegate
			{
				ReconnectVideoInput(openLiveVideoSetupCommand);
			});
	}

	public static ICommand ToCancelDownloadCommand(this IObservable<DownloadProgress> whenDownloadProgressChanges, IObservable<IReadOnlyList<ActionDownloadItemMatch>> whenActionDownloadItemMapChanges)
	{
		ReactiveCommand reactiveCommand = whenDownloadProgressChanges.Select((DownloadProgress p) => p.Status == DownloadStatus.Active).DistinctUntilChanged().ToReactiveCommand(initialValue: false);
		reactiveCommand.WithLatestFrom(whenActionDownloadItemMapChanges).Subscribe(CancelDownload);
		return reactiveCommand;
	}

	private static IReadOnlyList<ActionDownloadItemMatch> GetMatchingDownloadItems((IEnumerable<MediaAction>, IReadOnlyList<IDownloadItem>) actionsAndDownloadItems)
	{
		IEnumerable<MediaAction> source;
		IReadOnlyList<IDownloadItem> downloadItems;
		(source, downloadItems) = actionsAndDownloadItems;
		return source.Select((MediaAction action) => new ActionDownloadItemMatch(action, downloadItems.Where((IDownloadItem item) => (action.Media as IFileMedia)?.File?.RemoteProperties?.Matches(item) == true).ToList())).ToList();
	}

	private static IObservable<DownloadProgress> GetOverallProgress(IReadOnlyList<ActionDownloadItemMatch> matchedDownloadItems)
	{
		return matchedDownloadItems.Select((ActionDownloadItemMatch i) => i.DownloadItems.Select((IDownloadItem item) => item.WhenDownloadProgressChanged).CombineLatest().Select(CalculateCombinedDownloadProgress)).CombineLatest(CalculateCombinedDownloadProgress).StartWith(DownloadProgress.Empty);
	}

	private static IObservable<IList<MediaAction>> WhenMediaValidityUpdates(this IEnumerable<MediaAction> actions)
	{
		if (!actions.Any())
		{
			return Observable.Return(new List<MediaAction>());
		}
		return actions.Select((MediaAction action) => (from update in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler e)
			{
				action.Media.PropertyChanged += e;
			}, delegate(PropertyChangedEventHandler e)
			{
				action.Media.PropertyChanged -= e;
			})
			where update.EventArgs.PropertyName == "IsValid"
			select update into _
			select action).StartWith(action)).CombineLatest();
	}

	private static IObservable<IList<MediaCue>> WhenMediaCueValidityUpdates(this IEnumerable<MediaCue> cues)
	{
		if (!cues.Any())
		{
			return Observable.Return(new List<MediaCue>());
		}
		return cues.Select((MediaCue cue) => (from update in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler e)
			{
				cue.PropertyChanged += e;
			}, delegate(PropertyChangedEventHandler e)
			{
				cue.PropertyChanged -= e;
			})
			where update.EventArgs.PropertyName == "IsValid"
			select update into _
			select cue).StartWith(cue)).CombineLatest();
	}

	private static IObservable<bool> CanDownload(IReadOnlyList<ActionDownloadItemMatch> matchedDownloadItems)
	{
		if (matchedDownloadItems.Count == 0)
		{
			return Observable.Return(value: false);
		}
		return from values in matchedDownloadItems.Select(CanDownload).CombineLatest()
			select values.Any((bool v) => v);
	}

	private static IObservable<bool> CanDownload(ActionDownloadItemMatch match)
	{
		if (!IsRemoteFile(match.Action.Media as IFileMedia))
		{
			return Observable.Return(value: false);
		}
		IObservable<IList<DownloadProgress>> second = match.DownloadItems.Select((IDownloadItem d) => d.WhenDownloadProgressChanged).DefaultIfEmpty(Observable.Return(DownloadProgress.Empty)).CombineLatest();
		return (from update in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler e)
			{
				match.Action.PropertyChanged += e;
			}, delegate(PropertyChangedEventHandler e)
			{
				match.Action.PropertyChanged -= e;
			})
			where update.EventArgs.PropertyName == "IsValid"
			select update into _
			select match.Action).StartWith(match.Action).CombineLatest(second).Select(CanDownload);
	}

	private static bool CanDownload((MediaAction, IList<DownloadProgress>) values)
	{
		var (mediaAction, source) = values;
		if (!mediaAction.IsValid)
		{
			return source.All((DownloadProgress p) => p.Status != DownloadStatus.Active);
		}
		return false;
	}

	private static DownloadProgress CalculateCombinedDownloadProgress(IList<DownloadProgress> items)
	{
		IEnumerable<DownloadProgress> source = items.Where((DownloadProgress i) => i.Status == DownloadStatus.Active);
		if (!source.Any())
		{
			return DownloadProgress.Empty;
		}
		var (num, num2) = source.Aggregate((0L, 0L), ((long total, long current) previous, DownloadProgress item) => (total: previous.total + item.TotalBytes, current: previous.current + item.ReceivedBytes));
		return new DownloadProgress(DownloadStatus.Active, (int)((num != 0L) ? ((100 * num2 + num / 2) / num) : 0), num2, num, 0L);
	}

	private static InvalidMediaType CalculateInvalidMediaType(IReadOnlyList<ActionDownloadItemMatch> matchedDownloadItems)
	{
		return matchedDownloadItems.Aggregate(InvalidMediaType.Unknown, delegate(InvalidMediaType aggregatedState, ActionDownloadItemMatch match)
		{
			InvalidMediaType invalidMediaTypeForAction = GetInvalidMediaTypeForAction(match.Action);
			if (invalidMediaTypeForAction == InvalidMediaType.Remote || aggregatedState == InvalidMediaType.Remote)
			{
				return InvalidMediaType.Remote;
			}
			if (invalidMediaTypeForAction == InvalidMediaType.Local || aggregatedState == InvalidMediaType.Local)
			{
				return InvalidMediaType.Local;
			}
			return (invalidMediaTypeForAction == InvalidMediaType.Device || aggregatedState == InvalidMediaType.Device) ? InvalidMediaType.Device : InvalidMediaType.Unknown;
		});
	}

	private static InvalidMediaType GetInvalidMediaTypeForAction(MediaAction action)
	{
		if (action.Media == null)
		{
			return InvalidMediaType.Unknown;
		}
		switch (action.Media.MediaType)
		{
		case MediaType.Image:
		case MediaType.Video:
		case MediaType.Audio:
			if (!IsRemoteFile(action.Media as IFileMedia))
			{
				return InvalidMediaType.Local;
			}
			return InvalidMediaType.Remote;
		case MediaType.LiveVideo:
			return InvalidMediaType.Device;
		default:
			return InvalidMediaType.Unknown;
		}
	}

	private static bool IsRemoteFile(IFileMedia? fileMedia)
	{
		return fileMedia?.File.RemoteProperties != null;
	}

	private static async Task DownloadAsync(Func<IEnumerable<MediaAction>> getActionList, IRemoteFileLoader remoteFileLoader)
	{
		foreach (MediaAction item in from action in getActionList().OfType<MediaAction>()
			where !action.IsValid
			select action)
		{
			IRemoteFileProperties remoteFileProperties = (item.Media as IFileMedia)?.File?.RemoteProperties;
			if (remoteFileProperties != null)
			{
				await remoteFileLoader.StartDownloadAsync(remoteFileProperties);
			}
		}
	}

	private static bool CanRelink(IEnumerable<MediaAction> actions)
	{
		return actions.OfType<MediaAction>().Any((MediaAction action) => !action.IsValid && action.Media is IFileMedia fileMedia && !IsRemoteFile(fileMedia));
	}

	private static bool CanRelink(IEnumerable<MediaCue> cues)
	{
		return cues.OfType<MediaCue>().Any((MediaCue cue) => cue.MediaAction != null && !cue.MediaAction.Media.IsValid && cue.MediaAction?.Media is IFileMedia fileMedia && !IsRemoteFile(fileMedia));
	}

	private static void Relink(Func<IEnumerable<MediaAction>> getActionList, IFileSelectorService fileSelector, IImportProcessFactory importProcessFactory)
	{
		IEnumerable<FileMediaBase> fileMedia = (from action in getActionList()
			where action.Media is IFileMedia
			select action.Media).OfType<FileMediaBase>();
		ImportMedia(fileSelector, importProcessFactory, fileMedia);
	}

	private static void Relink(Func<IEnumerable<MediaCue>> getMediaCues, IFileSelectorService fileSelector, IImportProcessFactory importProcessFactory)
	{
		IEnumerable<FileMediaBase> fileMedia = (from cue in getMediaCues()
			where cue.MediaAction?.Media is IFileMedia
			select cue.MediaAction?.Media).OfType<FileMediaBase>();
		ImportMedia(fileSelector, importProcessFactory, fileMedia);
	}

	private static void ImportMedia(IFileSelectorService fileSelector, IImportProcessFactory importProcessFactory, IEnumerable<FileMediaBase> fileMedia)
	{
		foreach (FileMediaBase media in fileMedia)
		{
			string text = media.MediaType switch
			{
				MediaType.Image => FileFilters.ImageOnlyFilter, 
				MediaType.Video => FileFilters.VideoOnlyFilter, 
				MediaType.Audio => FileFilters.AudioOnlyFilter, 
				_ => string.Empty, 
			};
			if (text == string.Empty || !fileSelector.SelectFile(out string selectedFile, text))
			{
				continue;
			}
			importProcessFactory.Create(new FileImportRequest(selectedFile, delegate(string _, string newPath, FileMediaBase? createdMedia)
			{
				if (createdMedia == null)
				{
					media.UpdateSource(userInitiated: true, (RelativePath)newPath);
				}
			})
			{
				OverWriteOnConflict = true,
				ExistingMedia = media
			}).StartImport();
		}
	}

	private static bool CanReconnectVideoInput(IEnumerable<MediaAction> actions)
	{
		return actions.OfType<MediaAction>().Any((MediaAction action) => !action.IsValid && action.Media.MediaType == MediaType.LiveVideo);
	}

	private static void ReconnectVideoInput(ICommand openLiveVideoSetupCommand)
	{
		openLiveVideoSetupCommand.Execute(null);
	}

	private static void CancelDownload((object?, IReadOnlyList<ActionDownloadItemMatch>) values)
	{
		foreach (IDownloadItem item in from item in values.Item2.SelectMany((ActionDownloadItemMatch match) => match.DownloadItems)
			where item.Status == DownloadStatus.Active
			select item)
		{
			item.Cancel();
		}
	}
}
