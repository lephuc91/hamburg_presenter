using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
using Pro.Entity;
using Pro.Entity.Persistence;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Timer;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncers" })]
public class TimerDocument : NotifyPropertyChangedBase, IDocumentProvider, IDisposable
{
	private bool _didReset;

	private IProtoSyncedData<Pro.SerializationInterop.RVProtoData.TimersDocument>? _syncedData;

	private IEntityDocumentSyncer<ITimersDocumentDoc>? _syncer;

	private DisposableCollection _syncers;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IUiScheduler _scheduler;

	private readonly IFlagService _flagService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ILocalDocumentSyncerFactory _localTimerSyncerFactory;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TimerCollection Timers { get; }

	public UndoStack UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event System.Action? DataModified;

	public event System.Action? TimersUpdated;

	public TimerDocument(ISyncDataFactory syncDataFactory, IUiScheduler scheduler, IFlagService flagService, IProPresenterDOFactoryProvider factoryProvider, ILocalDocumentSyncerFactory localTimerSyncerFactory, bool loadLegacy)
	{
		_syncDataFactory = syncDataFactory;
		_scheduler = scheduler;
		_flagService = flagService;
		_factoryProvider = factoryProvider;
		_localTimerSyncerFactory = localTimerSyncerFactory;
		Timers = new TimerCollection
		{
			UndoStack = UndoStack
		};
		Timers.DataModified += OnDataModified;
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void TeardownDocumentSyncer()
	{
		_syncers.Dispose();
	}

	[MemberNotNull("_syncers")]
	private void SetupDocumentSyncer(bool loadLegacy)
	{
		_didReset = false;
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			ILocalDocumentSyncer<ITimersLocalDocumentDoc> localTimerSyncer = _localTimerSyncerFactory.CreateTimer();
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Timers", (ITimersDocumentDoc doc) => Timers.Bind(_scheduler, _factoryProvider.EntityFactory, _factoryProvider.MergedEntityFactory, doc.Timers, localTimerSyncer.Document.Timers), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(Pro.SerializationInterop.RVProtoData.TimersDocument.Parser.ParseFrom(d));
			}, DataCleared, loadLegacy);
			global::_003C_003Ey__InlineArray2<IDisposable> buffer = default(global::_003C_003Ey__InlineArray2<IDisposable>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(ref buffer, 0) = localTimerSyncer;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(ref buffer, 1) = _syncer;
			_syncers = DisposableCollection.Create(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(in buffer, 2));
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<Pro.SerializationInterop.RVProtoData.TimersDocument>(CommonPaths.Configuration, "Timers", SyncDataUpdated, SyncDataCleared);
			IDisposable reference = _syncedData;
			_syncers = DisposableCollection.Create(new ReadOnlySpan<IDisposable>(in reference));
		}
		if (_didReset)
		{
			OnDataModified();
		}
	}

	private void DataCleared()
	{
		SyncDataCleared(DataClearSource.FileRemoved);
	}

	public Pro.SerializationInterop.RVProtoData.TimersDocument Serialize()
	{
		Pro.SerializationInterop.RVProtoData.TimersDocument timersDocument = new Pro.SerializationInterop.RVProtoData.TimersDocument();
		timersDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		timersDocument.Timers.AddRange(Timers.Serialize());
		return timersDocument;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.TimersDocument data, bool removeExisting = true)
	{
		if (data != null)
		{
			Timers.Deserialize(data.Timers, removeExisting);
			this.TimersUpdated?.Invoke();
		}
	}

	private void OnDataModified()
	{
		_syncedData?.UpdateData(Serialize());
		this.DataModified?.Invoke();
	}

	private void SyncDataUpdated(Pro.SerializationInterop.RVProtoData.TimersDocument data)
	{
		Deserialize(data);
	}

	private void SyncDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			UndoStack.StartIgnoring();
			Timers.Reset();
			UndoStack.StopIgnoring();
			_didReset = true;
		}
	}

	internal void Save()
	{
		OnDataModified();
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new Pro.CoreApplication.Document.Intrinsic.TimersDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			_syncers.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
