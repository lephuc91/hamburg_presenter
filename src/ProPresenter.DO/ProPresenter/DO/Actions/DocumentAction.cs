using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Text.Fills;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Actions;

public class DocumentAction : ActionBase, IDocumentAction, Pro.DO.Triggering.IAction, ICloneable<Pro.DO.Triggering.IAction>, INotifyPropertyChanged, IDisposable, IHasMediaContainerId
{
	private sealed record PendingArrangementData(Guid Id, string Name);

	private IArrangement? _activeArrangement;

	private Key? _targetKey;

	private OutputDestination? _destination;

	private bool _watchMedia;

	private PendingArrangementData? _activeArrangementPending;

	private RelativePath _documentPath;

	private ProPresenter.DO.Presentation.IPresentation? _presentation;

	private IPlaylistItem.Types.IItemType.IPresentation? _documentItem;

	private bool OverrideProperties { get; }

	public override ActionType ActionType => ActionType.Document;

	public ProPresenter.DO.Presentation.IPresentation? Presentation
	{
		get
		{
			return _presentation;
		}
		private set
		{
			SetValue<ProPresenter.DO.Presentation.IPresentation>("Presentation", ref _presentation, value, delegate(ProPresenter.DO.Presentation.IPresentation o, ProPresenter.DO.Presentation.IPresentation n)
			{
				if (o != null)
				{
					UnHookupPresentationDataNotifications(o);
				}
				if (n != null)
				{
					base.Name = n.Name;
					if (n.IsPendingLoad)
					{
						n.DataFirstLoaded += Presentation_DataFirstLoaded;
					}
					else
					{
						HookupPresentationDataNotifications();
					}
					n.PropertyChanged += base.RaiseLinkedValues;
					n.DataModified += Presentation_DataModified;
				}
				DocumentPath = n?.SourceFile ?? RelativePath.Empty();
				OnPropertyChanged("PresentationType");
				OnPropertyChanged("LibraryName");
				OnPropertyChanged("ActiveArrangementName");
				OnPropertyChanged("ActiveArrangement");
				OnPropertyChanged("TargetKey");
				OnPropertyChanged("Destination");
				OnDataModified();
			});
		}
	}

	public RelativePath DocumentPath
	{
		get
		{
			return _documentPath;
		}
		private set
		{
			SetValue("DocumentPath", ref _documentPath, value);
		}
	}

	public PresentationType PresentationType => Presentation?.PresentationType ?? PresentationType.Standard;

	public string LibraryName
	{
		get
		{
			if (Presentation != null && (object)Presentation.SourceFile != null)
			{
				return Directory.GetParent(Presentation.SourceFile)?.Name ?? string.Empty;
			}
			return string.Empty;
		}
	}

	public string? ActiveArrangementName
	{
		get
		{
			object obj = _activeArrangementPending?.Name;
			if (obj == null)
			{
				if (!OverrideProperties)
				{
					return Presentation?.ActiveArrangementName;
				}
				IArrangement? activeArrangement = ActiveArrangement;
				if (activeArrangement == null)
				{
					return null;
				}
				obj = activeArrangement.Name;
			}
			return (string?)obj;
		}
	}

	public IArrangement? ActiveArrangement
	{
		get
		{
			EnsureArrangementSelected();
			object obj = (OverrideProperties ? _activeArrangement : null);
			if (obj == null)
			{
				obj = Presentation?.ActiveArrangement;
				if (obj == null)
				{
					ProPresenter.DO.Presentation.IPresentation? presentation = Presentation;
					if (presentation == null)
					{
						return null;
					}
					obj = presentation.DefaultArrangement;
				}
			}
			return (IArrangement?)obj;
		}
		set
		{
			SetActiveArrangement(value);
		}
	}

	public Key? TargetKey
	{
		get
		{
			if (Presentation == null)
			{
				return null;
			}
			return (OverrideProperties ? _targetKey : null) ?? Presentation.TargetKey ?? Presentation.BaseKey;
		}
		set
		{
			if (OverrideProperties)
			{
				SetValue("TargetKey", ref _targetKey, value, base.OnDataModified);
				return;
			}
			if (Presentation != null)
			{
				Presentation.TargetKey = value;
			}
			OnPropertyChanged("TargetKey");
		}
	}

	public OutputDestination Destination
	{
		get
		{
			return (OverrideProperties ? _destination : ((OutputDestination?)null)) ?? Presentation?.Destination ?? OutputDestination.Presentation;
		}
		set
		{
			if (OverrideProperties)
			{
				SetValue("Destination", ref _destination, value, base.OnDataModified);
			}
			else if (Presentation != null)
			{
				Presentation.Destination = value;
				OnPropertyChanged("Destination");
			}
		}
	}

	public TimeSlice? DocumentLoopTime => GetDocumentLoopTime();

	public override string ContainerId => Presentation?.ContainerId ?? string.Empty;

	public ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, this, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IPresentationDocument presentationDocument = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IPresentationDocument;
		if (presentationDocument == null)
		{
			presentationDocument = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IPresentationDocument>();
			right.ActionTypeData.Set(presentationDocument);
		}
		ObjectBinder<DocumentAction, Pro.Entity.IAction.Types.IDocumentType> documentActionBinder = new ObjectBinder<DocumentAction, Pro.Entity.IAction.Types.IDocumentType>(this, presentationDocument.Value);
		documentActionBinder.Bind((DocumentAction l) => l.WhenPropertyChanges("ActiveArrangement"), (Pro.Entity.IAction.Types.IDocumentType r) => r.SelectedArrangement.WhenValueChanges, delegate(DocumentAction l, Pro.Entity.IAction.Types.IDocumentType r)
		{
			r.SelectedArrangement.Set(l.ActiveArrangement?.ID);
		}, delegate(Pro.Entity.IAction.Types.IDocumentType r, DocumentAction l)
		{
			l._activeArrangementPending = new PendingArrangementData(r.SelectedArrangement.Value ?? Guid.Empty, string.Empty);
		}).Bind((DocumentAction l) => l.WhenPropertyChanges("Destination"), (Pro.Entity.IAction.Types.IDocumentType r) => r.ContentDestination.WhenValueChanges, delegate(DocumentAction l, Pro.Entity.IAction.Types.IDocumentType r)
		{
			r.ContentDestination.Set(l.Destination.ToContentDestination());
		}, delegate(Pro.Entity.IAction.Types.IDocumentType r, DocumentAction l)
		{
			l.Destination = r.ContentDestination.Value.ToOutputDestination();
		});
		objectBinder.DoOnInitializeRightFromLeft(documentActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(documentActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => documentActionBinder);
		return objectBinder;
	}

	public ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> CreatePlaylistBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IPlaylistItem.Types.IPresentation presentation)
	{
		ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> objectBinder = new ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation>(this, presentation);
		objectBinder.Bind((DocumentAction l) => l.WhenPropertyChanges("ActiveArrangement"), (IPlaylistItem.Types.IPresentation r) => r.Arrangement.WhenValueChanges.ToUnit().Merge(r.ArrangementName.WhenValueChanges.ToUnit()), delegate(DocumentAction l, IPlaylistItem.Types.IPresentation r)
		{
			r.Arrangement.Set(l.ActiveArrangement?.ID);
		}, delegate(IPlaylistItem.Types.IPresentation r, DocumentAction l)
		{
			l._activeArrangementPending = new PendingArrangementData(r.Arrangement.Value ?? Guid.Empty, r.ArrangementName.Value);
		}).Bind((DocumentAction l) => l.WhenPropertyChanges("Destination"), (IPlaylistItem.Types.IPresentation r) => r.ContentDestination.WhenValueChanges, delegate(DocumentAction l, IPlaylistItem.Types.IPresentation r)
		{
			r.ContentDestination.Set(l.Destination.ToContentDestination());
		}, delegate(IPlaylistItem.Types.IPresentation r, DocumentAction l)
		{
			l.Destination = r.ContentDestination.Value.ToOutputDestination();
		}).Bind((DocumentAction l) => l.DocumentPath.WhenPropertyChanges("DocumentPath"), (IPlaylistItem.Types.IPresentation r) => r.DocumentPath.WhenValueChanges, delegate(DocumentAction l, IPlaylistItem.Types.IPresentation r)
		{
			r.DocumentPath.Set(RelativePath.Create(l.DocumentPath));
		}, delegate(IPlaylistItem.Types.IPresentation r, DocumentAction l)
		{
			l.Presentation = null;
			l.DocumentPath = RelativePath.Create(r.DocumentPath.Value, out URL _);
		})
			.Bind((DocumentAction l) => l.WhenPropertyChanges("TargetKey"), (IPlaylistItem.Types.IPresentation r) => r.UserMusicKey.WhenAnyValueChanges, delegate(DocumentAction l, IPlaylistItem.Types.IPresentation r)
			{
				if (l.TargetKey == null)
				{
					r.UserMusicKey.Set(null);
				}
				else
				{
					IMusicKeyScale musicKeyScale = entityFactory.Create<IMusicKeyScale>();
					musicKeyScale.MusicKey.Set(l.TargetKey.Note.ToEntityMusicNote());
					musicKeyScale.MusicScale.Set(l.TargetKey.Scale.ToEntityMusicScale());
					r.UserMusicKey.Set(musicKeyScale);
				}
			}, delegate(IPlaylistItem.Types.IPresentation r, DocumentAction l)
			{
				if (r.UserMusicKey.Value == null)
				{
					l.TargetKey = null;
				}
				else
				{
					l.TargetKey = new Key(r.UserMusicKey.Value.MusicKey.Value.ToNote(), r.UserMusicKey.Value.MusicScale.Value.ToScale());
				}
			});
		return objectBinder;
	}

	public DocumentAction(ProPresenter.DO.Presentation.IPresentation? presentation, bool overrideProperties = true)
		: this(presentation?.SourceFile ?? RelativePath.Empty(), overrideProperties)
	{
		OverrideProperties = overrideProperties;
		Presentation = presentation;
		base.Name = Presentation?.Name ?? string.Empty;
	}

	public DocumentAction(IPlaylistItem.Types.IItemType.IPresentation documentItem, bool overrideProperties = true)
		: this(RelativePath.Create(documentItem.Value.DocumentPath.Value, out URL _), overrideProperties)
	{
		_documentItem = documentItem;
	}

	public DocumentAction(RelativePath documentPath, bool overrideProperties = true)
	{
		_documentPath = documentPath;
		OverrideProperties = overrideProperties;
		base.Name = documentPath.Name;
		LinkAction("Name", delegate
		{
			base.Name = Presentation?.Name ?? string.Empty;
		});
		LinkProperties("ActiveArrangement", "ActiveArrangement");
		LinkProperties("ActiveArrangementName", "ActiveArrangementName");
		LinkProperties("TargetKey", "TargetKey");
		LinkProperties("SourceFile", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "LibraryName", "Name" }));
		LinkAction(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "SlideShowEnabled", "SlideShowDuration" }), NotifyDocumentLoopTime);
		LinkAction("SourceFile", delegate
		{
			DocumentPath = Presentation?.SourceFile ?? RelativePath.Empty();
		});
	}

	private void HookupPresentationDataNotifications()
	{
		Presentation.ThrowWhenNull("Presentation");
		Presentation.Arrangements.CollectionChanged += Arrangements_CollectionChanged;
		Presentation.ArrangementGroups.CollectionChanged += ArrangementGroups_CollectionChanged;
		Presentation.ArrangementGroups.ForEach(delegate(CueGroup cueGroup)
		{
			cueGroup.Cues.CollectionChanged += Cues_CollectionChanged;
			SetupSlideCues(cueGroup.Cues);
			foreach (SlideCue cue in cueGroup.Cues)
			{
				cue.SlideTimeChanged += NotifyDocumentLoopTime;
			}
		});
		if (!OverrideProperties)
		{
			IArrangement activeArrangement = Presentation.ActiveArrangement;
			if (activeArrangement != null)
			{
				activeArrangement.CollectionChanged += ArrangementGroups_CollectionChanged;
			}
		}
	}

	private void UnHookupPresentationDataNotifications(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		if (presentation.ActiveArrangement != null)
		{
			presentation.ActiveArrangement.PropertyChanged -= ActiveArrangementOnPropertyChanged;
			presentation.ActiveArrangement.CollectionChanged -= ArrangementGroups_CollectionChanged;
			if (_watchMedia)
			{
				StopWatchingArrangementMedia(presentation.ActiveArrangement);
			}
		}
		presentation.Arrangements.CollectionChanged -= Arrangements_CollectionChanged;
		presentation.ArrangementGroups.CollectionChanged -= ArrangementGroups_CollectionChanged;
		presentation.ArrangementGroups.ForEach(delegate(CueGroup cueGroup)
		{
			cueGroup.Cues.CollectionChanged -= Cues_CollectionChanged;
			TeardownSlideCues(cueGroup.Cues);
			foreach (SlideCue cue in cueGroup.Cues)
			{
				cue.SlideTimeChanged -= NotifyDocumentLoopTime;
			}
		});
		if (!OverrideProperties)
		{
			IArrangement activeArrangement = presentation.ActiveArrangement;
			if (activeArrangement != null)
			{
				activeArrangement.CollectionChanged -= ArrangementGroups_CollectionChanged;
			}
		}
		presentation.DataFirstLoaded -= Presentation_DataFirstLoaded;
		presentation.PropertyChanged -= base.RaiseLinkedValues;
		presentation.DataModified -= Presentation_DataModified;
	}

	private void Presentation_DataFirstLoaded(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		HookupPresentationDataNotifications();
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		EnsureArrangementSelected();
		DocumentAction action = new DocumentAction(Presentation)
		{
			_activeArrangement = _activeArrangement,
			_targetKey = _targetKey,
			_destination = _destination
		};
		return CopyProperties(action);
	}

	public PlaylistItem.Types.Presentation OnProtoSerializePlaylistItem()
	{
		PlaylistItem.Types.Presentation presentation = new PlaylistItem.Types.Presentation
		{
			DocumentPath = (Presentation?.SourceFile?.Serialize() ?? DocumentPath.Serialize()),
			ContentDestination = Destination.ToProtoDestination()
		};
		PendingArrangementData? activeArrangementPending = _activeArrangementPending;
		Guid? guid = (((object)activeArrangementPending != null) ? new Guid?(activeArrangementPending.Id) : ActiveArrangement?.ID);
		string text = _activeArrangementPending?.Name ?? ActiveArrangementName;
		if (guid.HasValue)
		{
			presentation.Arrangement = guid.Value.ToUUID();
		}
		if (text != null)
		{
			presentation.ArrangementName = text;
		}
		if (_targetKey != null)
		{
			presentation.UserMusicKey = _targetKey.ToProtoMusicKeyScale();
		}
		return presentation;
	}

	public void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem)
	{
		if (playlistItem.Presentation != null)
		{
			_activeArrangementPending = new PendingArrangementData(playlistItem.Presentation.Arrangement.ToGuid(), playlistItem.Presentation.ArrangementName);
			object obj = playlistItem.Presentation.UserMusicKey?.ToKey();
			if (obj == null)
			{
				ProPresenter.DO.Presentation.IPresentation? presentation = Presentation;
				obj = ((presentation != null && presentation.SupportsChords) ? Presentation.TargetKey : null);
			}
			TargetKey = (Key?)obj;
			Destination = playlistItem.Presentation.ContentDestination.ToDestination();
		}
	}

	public void StartWatchingMedia()
	{
		if (!_watchMedia)
		{
			_watchMedia = true;
			StartWatchingArrangementMedia(ActiveArrangement);
		}
	}

	public void StopWatchingMedia()
	{
		if (_watchMedia)
		{
			_watchMedia = false;
			StopWatchingArrangementMedia(ActiveArrangement);
		}
	}

	private static void StartWatchingArrangementMedia(IArrangement? arrangement)
	{
		arrangement?.OfType<CueGroup>().ForEach(delegate(CueGroup c)
		{
			c.Cues.OfType<SlideCue>().ForEach(StartWatchingSlideCueMedia);
		});
	}

	private static void StopWatchingArrangementMedia(IArrangement? arrangement)
	{
		arrangement?.OfType<CueGroup>().ForEach(delegate(CueGroup c)
		{
			c.Cues.OfType<SlideCue>().ForEach(StopWatchingSlideCueMedia);
		});
	}

	private void Cues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		TeardownSlideCues(e.OldItems?.OfType<SlideCue>() ?? Array.Empty<SlideCue>());
		SetupSlideCues(e.NewItems?.OfType<SlideCue>() ?? Array.Empty<SlideCue>());
		NotifyDocumentLoopTime();
	}

	private void TeardownSlideCues(IEnumerable<SlideCue> cues)
	{
		if (cues == null || cues.Empty())
		{
			return;
		}
		foreach (SlideCue cue in cues)
		{
			cue.SlideTimeChanged -= NotifyDocumentLoopTime;
			cue.Actions.CollectionChanged -= SlideCueActionCollectionChanged;
			if (_watchMedia)
			{
				StopWatchingSlideCueMedia(cue);
			}
		}
	}

	private void SetupSlideCues(IEnumerable<SlideCue> cues)
	{
		if (cues == null || cues.Empty())
		{
			return;
		}
		foreach (SlideCue cue in cues)
		{
			cue.SlideTimeChanged += NotifyDocumentLoopTime;
			cue.Actions.CollectionChanged += SlideCueActionCollectionChanged;
			if (_watchMedia)
			{
				StartWatchingSlideCueMedia(cue);
			}
		}
	}

	private static void StartWatchingSlideCueMedia(SlideCue slideCue)
	{
		slideCue.Actions.OfType<MediaAction>().ForEach(StartWatchingMediaAction);
		(slideCue.SlideAction?.Slide as CustomSlide)?.Elements.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath closedBezierPath)
		{
			closedBezierPath.Text?.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
			{
				if (run.Settings.Fill is MediaTextFill mediaTextFill)
				{
					mediaTextFill.Media?.StartObservingSourceFile();
					mediaTextFill.ValidityChanged += slideCue.UpdateValidity;
				}
			});
			closedBezierPath.FillChanged += ClosedBezierPath_FillChanged;
			if (closedBezierPath.Fill is MediaFill mediaFill)
			{
				mediaFill.StartObservingSourceFile();
			}
		});
	}

	private static void ClosedBezierPath_FillChanged(IFill oldFill, IFill newFill)
	{
		if (oldFill is MediaFill mediaFill)
		{
			mediaFill.StopObservingSourceFile();
		}
		if (newFill is MediaFill mediaFill2)
		{
			mediaFill2.StartObservingSourceFile();
		}
	}

	private static void StopWatchingSlideCueMedia(SlideCue slideCue)
	{
		slideCue.Actions.OfType<MediaAction>().ForEach(StopWatchingMediaAction);
		(slideCue.SlideAction?.Slide as CustomSlide)?.Elements.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath closedBezierPath)
		{
			closedBezierPath.Text?.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
			{
				if (run.Settings.Fill is MediaTextFill mediaTextFill)
				{
					mediaTextFill.Media?.StopObservingSourceFile();
					mediaTextFill.ValidityChanged -= slideCue.UpdateValidity;
				}
			});
			closedBezierPath.FillChanged -= ClosedBezierPath_FillChanged;
			if (closedBezierPath.Fill is MediaFill mediaFill)
			{
				mediaFill.StopObservingSourceFile();
			}
		});
	}

	private void SlideCueActionCollectionChanged(object? s, NotifyCollectionChangedEventArgs e)
	{
		if (_watchMedia)
		{
			e.OldItems?.OfType<MediaAction>().ForEach(StopWatchingMediaAction);
			e.NewItems?.OfType<MediaAction>().ForEach(StartWatchingMediaAction);
		}
		OnSlideCueActionsChanged(e, e);
	}

	protected virtual void OnSlideCueActionsChanged(object s, NotifyCollectionChangedEventArgs e)
	{
	}

	private static void StartWatchingMediaAction(MediaAction m)
	{
		m.FileMedia?.StartObservingSourceFile();
	}

	private static void StopWatchingMediaAction(MediaAction m)
	{
		m.FileMedia?.StopObservingSourceFile();
	}

	private void ArrangementGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<CueGroup>().ForEach(delegate(CueGroup c)
		{
			c.Cues.CollectionChanged -= Cues_CollectionChanged;
		});
		e.NewItems?.OfType<CueGroup>().ForEach(delegate(CueGroup c)
		{
			c.Cues.CollectionChanged += Cues_CollectionChanged;
		});
		NotifyDocumentLoopTime();
	}

	private void Arrangements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (_activeArrangement != null)
		{
			ProPresenter.DO.Presentation.IPresentation? presentation = Presentation;
			if (presentation != null && !presentation.Arrangements.Contains(_activeArrangement))
			{
				_activeArrangement = null;
			}
		}
	}

	private void NotifyDocumentLoopTime()
	{
		OnPropertyChanged("DocumentLoopTime");
	}

	private TimeSlice? GetDocumentLoopTime()
	{
		if (Presentation == null)
		{
			return null;
		}
		Presentation.EnsureLoaded();
		IEnumerable<SlideCue> source = ActiveArrangement?.SelectMany((CueGroup g) => g.Cues) ?? Enumerable.Empty<SlideCue>();
		double num = 0.0;
		if (!source.Any())
		{
			return null;
		}
		foreach (SlideCue item in source.Where((SlideCue c) => c.IsEnabled))
		{
			if (item.GotoNext == null && !Presentation.SlideShowEnabled)
			{
				return null;
			}
			num += item.GetSlideDuration(Presentation.SlideShowDuration);
			GotoNext? gotoNext = item.GotoNext;
			if (gotoNext != null && gotoNext.LoopToBeginning)
			{
				break;
			}
		}
		return TimeSlice.FromSeconds(num);
	}

	private void ActiveArrangementOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name" && Presentation?.ActiveArrangement != null)
		{
			Presentation.ActiveArrangement.Name = ActiveArrangement?.Name ?? string.Empty;
		}
	}

	private void SetActiveArrangement(IArrangement? arrangement, bool invokeDataModified = true, bool notifyPropertyChange = true)
	{
		if (OverrideProperties)
		{
			SetDocumentActionActiveArrangement(arrangement, invokeDataModified, notifyPropertyChange);
		}
		else
		{
			SetPresentationActiveArrangement(arrangement, notifyPropertyChange);
		}
		OnPropertyChanged("ActiveArrangementName");
		NotifyDocumentLoopTime();
	}

	private void SetDocumentActionActiveArrangement(IArrangement? arrangement, bool invokeDataModified, bool notifyPropertyChange)
	{
		IArrangement activeArrangement = _activeArrangement;
		if (activeArrangement == arrangement)
		{
			return;
		}
		if (activeArrangement != null)
		{
			activeArrangement.CollectionChanged -= ArrangementGroups_CollectionChanged;
			if (_watchMedia)
			{
				StopWatchingArrangementMedia(activeArrangement);
			}
		}
		_activeArrangement = arrangement;
		if (arrangement != null)
		{
			arrangement.CollectionChanged += ArrangementGroups_CollectionChanged;
			if (_watchMedia)
			{
				StartWatchingArrangementMedia(arrangement);
			}
		}
		if (invokeDataModified)
		{
			OnDataModified();
		}
		if (notifyPropertyChange)
		{
			OnPropertyChanged("ActiveArrangement");
		}
	}

	private void SetPresentationActiveArrangement(IArrangement? arrangement, bool notifyPropertyChange = true)
	{
		if (Presentation != null)
		{
			if (Presentation.ActiveArrangement != null)
			{
				Presentation.ActiveArrangement.PropertyChanged -= ActiveArrangementOnPropertyChanged;
				Presentation.ActiveArrangement.CollectionChanged -= ArrangementGroups_CollectionChanged;
				if (_watchMedia)
				{
					StopWatchingArrangementMedia(Presentation.ActiveArrangement);
				}
			}
			Presentation.ActiveArrangement = arrangement;
			if (Presentation.ActiveArrangement != null)
			{
				Presentation.ActiveArrangement.PropertyChanged += ActiveArrangementOnPropertyChanged;
				Presentation.ActiveArrangement.CollectionChanged += ArrangementGroups_CollectionChanged;
				if (_watchMedia)
				{
					StartWatchingArrangementMedia(Presentation.ActiveArrangement);
				}
			}
		}
		if (notifyPropertyChange)
		{
			OnPropertyChanged("ActiveArrangement");
		}
	}

	private void EnsureArrangementSelected()
	{
		if ((object)_activeArrangementPending != null)
		{
			Guid arrangementId = _activeArrangementPending.Id;
			IArrangement arrangement = Presentation?.Arrangements.FirstOrDefault((IArrangement a) => a.ID == arrangementId) ?? Presentation?.DefaultArrangement;
			ProPresenter.DO.Presentation.IPresentation? presentation = Presentation;
			if (presentation != null && !presentation.IsPendingLoad)
			{
				_activeArrangementPending = null;
			}
			if (arrangement != null)
			{
				SetActiveArrangement(arrangement, invokeDataModified: false, notifyPropertyChange: false);
			}
		}
	}

	public void EnsurePresentationResolved(ILibraryCollection library)
	{
		if ((Presentation != null && Presentation.SourceFile == _documentPath) || _documentPath.IsEmpty)
		{
			return;
		}
		DocumentCue documentCue = library.FindDocument(_documentPath);
		if ((object)documentCue?.DocumentAction?.Presentation?.SourceFile == null)
		{
			return;
		}
		Presentation = documentCue.DocumentAction.Presentation;
		base.Name = documentCue.Name;
		if (_documentItem != null)
		{
			_activeArrangementPending = new PendingArrangementData(_documentItem.Value.Arrangement.Value ?? Guid.Empty, _documentItem.Value.ArrangementName.Value);
			object targetKey;
			if (_documentItem.Value.UserMusicKey.Value == null)
			{
				ProPresenter.DO.Presentation.IPresentation? presentation = Presentation;
				targetKey = ((presentation != null && presentation.SupportsChords) ? Presentation.TargetKey : null);
			}
			else
			{
				targetKey = new Key(_documentItem.Value.UserMusicKey.Value.MusicKey.Value.ToNote(), _documentItem.Value.UserMusicKey.Value.MusicScale.Value.ToScale());
			}
			TargetKey = (Key?)targetKey;
			Destination = _documentItem.Value.ContentDestination.Value.ToOutputDestination();
			_documentItem = null;
		}
	}

	private void Presentation_DataModified(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		OnDataModified();
	}
}
