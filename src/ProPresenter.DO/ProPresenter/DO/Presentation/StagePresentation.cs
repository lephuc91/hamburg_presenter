using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Localization;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.DialogService;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Presentation;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncer" })]
public class StagePresentation : CustomPresentation, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<Stage.Types.Document>? _syncedData;

	private IEntityDocumentSyncer<IStage.Types.IDocumentDoc>? _syncer;

	private readonly IUiScheduler _scheduler;

	private readonly ISyncDataFactory _syncDataFactory;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	protected virtual Theme? StageTheme => DataVault.Themes?.StageTheme;

	protected override bool HasVariableSlideSizes => true;

	protected IFlagService FlagService { get; }

	public IEnumerable<SlideCue> Layouts => base.Cues;

	public override string ContainerId => "Stage";

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public IReadOnlyObjectBinder<StagePresentation, IStage.Types.IDocument> Bind(IUiScheduler scheduler, IStage.Types.IDocument stageDocument)
	{
		ObjectBinder<StagePresentation, IStage.Types.IDocument> objectBinder = new ObjectBinder<StagePresentation, IStage.Types.IDocument>(this, stageDocument);
		objectBinder.Bind((StagePresentation l) => Observable.FromEvent(delegate(Action<CueGroupCollection> h)
		{
			l.ArrangementGroups.CuesChanged += h;
		}, delegate(Action<CueGroupCollection> h)
		{
			l.ArrangementGroups.CuesChanged -= h;
		}), (IStage.Types.IDocument r) => r.Layouts.WhenCollectionChanges, delegate(StagePresentation l, IStage.Types.IDocument r)
		{
			r.Layouts.SynchronizeFrom(l.Cues, (SlideCue m, IStage.Types.ILayout e) => m.ID == e.Uuid.Value, delegate(SlideCue m)
			{
				IStage.Types.ILayout layout = base.FactoryProvider.EntityFactory.Create<IStage.Types.ILayout>();
				ObjectBinder<SlideCue, IStage.Types.ILayout> objectBinder2 = m.Bind(scheduler, base.FactoryProvider, layout);
				objectBinder2.InitializeRightFromLeft();
				layout.RegisterLinkedDisposable(objectBinder2);
				return layout;
			});
		}, delegate(IStage.Types.IDocument r, StagePresentation l)
		{
			r.Layouts.Items.SynchronizeTo(l.ArrangementGroups.First().Cues, (IStage.Types.ILayout e, SlideCue m) => m.ID == e.Uuid.Value, delegate(IStage.Types.ILayout e, int i)
			{
				SlideCue slideCue = new SlideCue(base.FactoryProvider, new CustomSlide(base.FactoryProvider, base.TransitionDescriptions), base.TransitionDescriptions);
				ObjectBinder<SlideCue, IStage.Types.ILayout> objectBinder3 = slideCue.Bind(scheduler, base.FactoryProvider, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				SlideCue targetCue = l.Cues.ElementAtOrDefault(i);
				EnsureLoaded();
				CueGroupCollection arrangementGroups = base.ArrangementGroups;
				CueGroup cueGroup = ((targetCue != null) ? arrangementGroups.FirstOrDefault((CueGroup g) => g.Cues.Contains(targetCue)) : arrangementGroups.LastOrDefault()) ?? base.ArrangementGroups.AddArrangementGroup(new GroupLabel(base.DefaultGroupName));
				int index = ((targetCue != null) ? (cueGroup.Cues.IndexOf(targetCue) + 1) : cueGroup.Cues.Count);
				cueGroup.Cues.InsertCues(index, new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(slideCue), isReversible: false);
			}, l.ArrangementGroups.First().Cues.Move, delegate(int i)
			{
				SlideCue slideCue2 = l.Cues.ElementAtOrDefault(i);
				if (slideCue2 != null)
				{
					l.RemoveCue(slideCue2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public StagePresentation(IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, ISyncDataFactory syncDataFactory, IFlagService flagService, IUiScheduler scheduler, IMessageDialogService messageDialogService, ICurrentTime currentTime, bool loadLegacy)
		: base(app, timerFactory, factoryProvider, transitionDescriptions, messageDialogService, currentTime)
	{
		base.UndoStack.StartIgnoring();
		_syncDataFactory = syncDataFactory;
		FlagService = flagService;
		_scheduler = scheduler;
		base.ArrangementGroups.AddArrangementGroup(new GroupLabel(base.DefaultGroupName));
		SetupDocumentSyncer(loadLegacy);
		base.DataModified += OnDataModified;
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		base.UndoStack.StopIgnoring();
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncedData?.Dispose();
		_syncer = null;
		_syncedData = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (FlagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = base.FactoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Stage", (IStage.Types.IDocumentDoc doc) => Bind(_scheduler, doc), () => SerializeStageDocument().ToByteArray(), delegate(byte[] d)
			{
				DeserializeStageDocument(Stage.Types.Document.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<Stage.Types.Document>(CommonPaths.Configuration, "Stage", SyncFileUpdated, SyncFileDeleted);
		}
	}

	private void LoadDefaults()
	{
		SyncFileDeleted(DataClearSource.FileRemoved);
	}

	private void SyncFileDeleted(DataClearSource clearSource)
	{
		if (clearSource == DataClearSource.FileRemoved)
		{
			base.UndoStack?.StartIgnoring();
			RemoveCues(base.Cues.ToArray(), canClearAll: true);
			AddCue(StageTheme?.ElementAtOrDefault(1));
			base.UndoStack?.StopIgnoring();
		}
	}

	private void SyncFileUpdated(Stage.Types.Document data)
	{
		base.DataModified -= OnDataModified;
		DeserializeStageDocument(data);
		base.DataModified += OnDataModified;
	}

	public override SlideCue AddCue(TemplateSlide? targetTemplate = null, SlideCue? targetCue = null)
	{
		SlideBase slideBase = (targetTemplate ?? StageTheme?.FirstOrDefault())?.Slide.Clone() ?? new CustomSlide(base.FactoryProvider, base.TransitionDescriptions);
		slideBase.ChangeSize(OutputVault.StageScreenArrangementCollection?.FirstOrDefault()?.TotalSize ?? new Vector2<double>(TargetDisplay.PrimaryDisplay.Width, TargetDisplay.PrimaryDisplay.Height));
		SlideCue slideCue = new SlideCue(base.FactoryProvider, slideBase, base.TransitionDescriptions);
		slideCue.Name = targetTemplate?.Name ?? LocalizedStrings.Get("EDITOR_STAGE_DEFAULT_LAYOUT_NAME_title");
		InsertCue(slideCue, targetCue);
		return slideCue;
	}

	public Stage.Types.Document SerializeStageDocument()
	{
		Stage.Types.Document document = new Stage.Types.Document
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize()
		};
		foreach (SlideCue cue in base.Cues)
		{
			document.Layouts.Add(new Stage.Types.Layout
			{
				Uuid = cue.ID.ToUUID(),
				Name = cue.Name,
				Slide = cue.SlideAction?.Slide.Serialize().BaseSlide
			});
		}
		return document;
	}

	public void DeserializeStageDocument(Stage.Types.Document document, bool removeExisting = true)
	{
		base.DeserializationInProgress = true;
		ApplicationData applicationData = ApplicationData.Deserialize(document.ApplicationInfo);
		base.Cues.DeserializeCollection(document.Layouts, (SlideCue c, Stage.Types.Layout l) => c.ID == l.Uuid.ToGuid(), delegate
		{
			CustomSlide customSlide = new CustomSlide(base.FactoryProvider, base.TransitionDescriptions);
			customSlide.UpdateContainerId("Stage");
			return new SlideCue(base.FactoryProvider, customSlide, base.TransitionDescriptions);
		}, delegate(SlideCue c)
		{
			InsertCue(c);
		}, delegate(SlideCue c)
		{
			if (removeExisting)
			{
				RemoveCue(c, canClearAll: true);
			}
		}, delegate(SlideCue c, Stage.Types.Layout l)
		{
			c.Deserialize(new Cue
			{
				Uuid = l.Uuid,
				Name = l.Name,
				IsEnabled = c.IsEnabled
			}, applicationData, "Stage");
			c.SlideAction?.Slide.DeserializeSlide(l.Slide, applicationData, "Stage", null);
		});
		AddDefault();
		base.DeserializationInProgress = false;
	}

	private void OnDataModified(IPresentation presentation)
	{
		Save();
	}

	public void AddDefault()
	{
		if (base.Cues.Empty())
		{
			AddCue(StageTheme?.ElementAtOrDefault(1));
		}
	}

	internal void Save()
	{
		_syncedData?.UpdateData(SerializeStageDocument());
		StageLayoutsUpdated.Publish(Layouts.Select((SlideCue l) => (ID: l.ID, Name: l.Name)));
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new StageDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			OnDispose();
			_syncedData?.Dispose();
			_syncer?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
