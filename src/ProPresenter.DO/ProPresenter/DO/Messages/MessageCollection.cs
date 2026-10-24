using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Merged.Factory;
using Pro.Entity.Persistence;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Messages;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncers" })]
public class MessageCollection : ImmutableObservableCollection<Message>, IDragDropCollection<Message>, ICutPasteCollection<Message>, ICutCollection<Message>, IDocumentProvider, IDisposable
{
	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IThemeCollection _themes;

	private readonly IFlagService _flagService;

	private readonly IUiScheduler _uiScheduler;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ILocalDocumentSyncerFactory _localDocumentSyncerFactory;

	private DisposableCollection _syncers;

	private IEntityDocumentSyncer<IMessageDocumentDoc>? _syncer;

	private IProtoSyncedData<MessageDocument>? _syncedData;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStack UndoStack { get; } = new UndoStack();

	public bool IgnoreTokenChanges { get; set; }

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event System.Action? DataModified;

	public event System.Action? TokensChanged;

	public event Action<Message>? NameChanged;

	public event Action<string>? LocationChanged;

	private ObjectBinder<MessageCollection, IMergedCollection<IMergedMessage>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedEntityFactory mergedEntityFactory, IComplexCollection<Pro.Entity.IMessage> remoteMessages, IComplexCollection<ILocalMessage> localMessages)
	{
		IMergedCollection<IMergedMessage> mergedCollection = mergedEntityFactory.CreateMessageCollection(remoteMessages, localMessages);
		ObjectBinder<MessageCollection, IMergedCollection<IMergedMessage>> objectBinder = new ObjectBinder<MessageCollection, IMergedCollection<IMergedMessage>>(this, mergedCollection);
		objectBinder.Bind((MessageCollection l) => l.WhenCollectionChanges(), (IMergedCollection<IMergedMessage> r) => r.WhenCollectionChanges, delegate(MessageCollection l, IMergedCollection<IMergedMessage> r)
		{
			r.SynchronizeFrom(l.Collection, (Message m, IMergedMessage e) => m.ID == e.Uuid.Value, delegate(Message m)
			{
				IMergedMessage mergedMessage = mergedEntityFactory.CreateMergedMessage(m.ID);
				IReadOnlyObjectBinder<Message, IMergedMessage> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, mergedMessage);
				readOnlyObjectBinder.InitializeRightFromLeft();
				mergedMessage.RegisterLinkedDisposable(readOnlyObjectBinder);
				return mergedMessage;
			});
		}, delegate(IMergedCollection<IMergedMessage> r, MessageCollection l)
		{
			r.Items.SynchronizeTo(l, (IMergedMessage e, Message m) => m.ID == e.Uuid.Value, delegate(IMergedMessage e, int i)
			{
				Message message = new Message(_themes);
				IReadOnlyObjectBinder<Message, IMergedMessage> readOnlyObjectBinder2 = message.Bind(scheduler, entityFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.InsertMessage(message, i);
			}, l.Collection.Move, delegate(int i)
			{
				Message message2 = l.ElementAtOrDefault(i);
				if (message2 != null)
				{
					l.RemoveMessage(message2);
				}
			});
		}, null, scheduler.Scheduler);
		objectBinder.RegisterChildDisposable(() => mergedCollection);
		return objectBinder;
	}

	public MessageCollection(ISyncDataFactory syncDataFactory, IThemeCollection themes, IFlagService flagService, IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, ILocalDocumentSyncerFactory localDocumentSyncerFactory, bool loadLegacy)
	{
		_syncDataFactory = syncDataFactory;
		_themes = themes;
		_flagService = flagService;
		_uiScheduler = uiScheduler;
		_factoryProvider = factoryProvider;
		_localDocumentSyncerFactory = localDocumentSyncerFactory;
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
	}

	private void TeardownDocumentSyncer()
	{
		_syncers.Dispose();
	}

	[MemberNotNull("_syncers")]
	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			ILocalDocumentSyncer<IMessageLocalDocumentDoc> localMessageSyncer = _localDocumentSyncerFactory.CreateMessages();
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Messages", (IMessageDocumentDoc doc) => Bind(_uiScheduler, _factoryProvider.EntityFactory, _factoryProvider.MergedEntityFactory, doc.Messages, localMessageSyncer.Document.Messages), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				SyncDataUpdated(MessageDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
			global::_003C_003Ey__InlineArray2<IDisposable> buffer = default(global::_003C_003Ey__InlineArray2<IDisposable>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(ref buffer, 0) = localMessageSyncer;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(ref buffer, 1) = _syncer;
			_syncers = DisposableCollection.Create(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(in buffer, 2));
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<MessageDocument>(CommonPaths.Configuration, "Messages", SyncDataUpdated, SyncDataCleared);
			IDisposable reference = _syncedData;
			_syncers = DisposableCollection.Create(new ReadOnlySpan<IDisposable>(in reference));
		}
		this.LocationChanged?.Invoke(CommonPaths.Configuration);
	}

	private void LoadDefaults()
	{
		SyncDataCleared(DataClearSource.FileRemoved);
	}

	public Message AddNewMessage(string name = "", bool isVisibleOnNetwork = false)
	{
		Message message = new Message(_themes)
		{
			Name = name,
			IsVisibleOnNetwork = isVisibleOnNetwork
		};
		return AddMessage(message);
	}

	public Message AddMessage(Message message)
	{
		InsertMessage(message, base.Count);
		return message;
	}

	public void InsertMessage(Message message, int index)
	{
		insertAction();
		UndoStack?.Commit(UndoActionTypes.MessageAdd.ToAction(), delegate
		{
			RemoveMessage(message);
		}, insertAction, null, null, autoFinalize: true);
		void insertAction()
		{
			message.DataModified += OnDataModified;
			message.UndoStack = UndoStack;
			message.Tokens.CollectionChanged += Tokens_CollectionChanged;
			message.PropertyChanged += Message_PropertyChanged;
			message.Name = message.Name.DuplicateName(base.Collection, (Message m) => m.Name);
			base.Collection.Insert(index, message);
		}
	}

	private void OnInsert(IEnumerable<Message> messages, int index)
	{
		if (messages != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.MessageAdd.ToAction());
			messages.ForEach(delegate(Message m)
			{
				InsertMessage(m, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void RemoveMessage(Message message)
	{
		RemoveMessages(message.ToEnumerable());
	}

	public void RemoveMessages(IEnumerable<Message> messages)
	{
		KeyValuePair<int, Message>[] itemIndices = (from m in messages.ToDictionary((Message m) => base.Collection.IndexOf(m), (Message i) => i)
			orderby m.Key
			select m).ToArray();
		System.Action action = delegate
		{
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, Message> m)
			{
				m.Value.DataModified -= OnDataModified;
				Message message = base.Collection.ElementAtOrDefault(m.Key);
				if (message != null)
				{
					base.Collection.Remove(message);
				}
			});
		};
		action();
		UndoStack?.Commit(UndoActionTypes.MessageRemove.ToAction(), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, Message> m)
			{
				m.Value.DataModified += OnDataModified;
				base.Collection.Insert(m.Key, m.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	private void Message_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("Name") && sender is Message obj)
		{
			this.NameChanged?.Invoke(obj);
		}
	}

	private void Tokens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!IgnoreTokenChanges)
		{
			this.TokensChanged?.Invoke();
		}
	}

	private void SyncDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			UndoStack?.StartIgnoring();
			base.Collection.ToArray().ForEach(RemoveMessage);
			UndoStack?.StopIgnoring();
		}
	}

	private void SyncDataUpdated(MessageDocument document)
	{
		if (document != null)
		{
			Deserialize(document.Messages);
		}
	}

	public void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Message> protoMessages, bool removeExisting = true)
	{
		UndoStack.StartIgnoring();
		base.Collection.DeserializeCollection(protoMessages, (Message m, Pro.SerializationInterop.RVProtoData.Message d) => m.ID == d.Uuid.ToGuid(), (Pro.SerializationInterop.RVProtoData.Message d) => new Message(_themes), delegate(Message m)
		{
			AddMessage(m);
		}, delegate(Message m)
		{
			if (removeExisting)
			{
				RemoveMessage(m);
			}
		}, delegate(Message m, Pro.SerializationInterop.RVProtoData.Message d)
		{
			m.DataModified -= OnDataModified;
			m.UndoStack = UndoStack;
			m.Deserialize(d);
			m.DataModified += OnDataModified;
		});
		UndoStack.StopIgnoring();
	}

	public MessageDocument Serialize()
	{
		MessageDocument messageDocument = new MessageDocument();
		messageDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		messageDocument.Messages.AddRange(base.Collection.Select((Message m) => m.Serialize()));
		return messageDocument;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
		_syncedData?.UpdateData(Serialize());
	}

	internal void Save()
	{
		OnDataModified();
	}

	int IDragDropCollection<Message>.IndexOf(Message item)
	{
		return base.Collection.IndexOf(item);
	}

	void IDragDropCollection<Message>.DraggedFrom(IEnumerable<Message> items)
	{
	}

	public void DroppedInto(IEnumerable<Message> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MessageAdd.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		OnInsert(items, index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<Message> items, int index)
	{
		base.Collection.MoveTo(items, index);
	}

	public void CutFrom(IEnumerable<Message> items)
	{
		RemoveMessages(items.ToArray());
	}

	public void PasteInto(IEnumerable<Message> items, int index)
	{
		foreach (Message item in items)
		{
			InsertMessage(item, index++);
		}
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new MessagesDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
