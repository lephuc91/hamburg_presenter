using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ActionCollection : ImmutableObservableCollection<IAction>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates, IDisposable
{
	private readonly Predicate<IAction> _canRemove;

	private UndoStack _undoStack = new UndoStack();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStack UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			this.ForEach(delegate(IAction a)
			{
				a.UndoStack = _undoStack;
			});
		}
	}

	public string ContainerId { get; private set; } = string.Empty;

	public event System.Action? DataModified;

	public static ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, ActionCollection left, IComplexCollection<Pro.Entity.IAction> right)
	{
		ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>> objectBinder = new ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>>(left, right);
		objectBinder.Bind((ActionCollection l) => l.Collection.WhenCollectionChanges(), (IComplexCollection<Pro.Entity.IAction> r) => r.WhenCollectionChanges, delegate(ActionCollection l, IComplexCollection<Pro.Entity.IAction> r)
		{
			r.SynchronizeFrom(l, (IAction s, Pro.Entity.IAction d) => d.Uuid.Value == s.ID, delegate(IAction model)
			{
				Pro.Entity.IAction action = entityFactory.Create<Pro.Entity.IAction>();
				IReadOnlyObjectBinder<IAction, Pro.Entity.IAction> readOnlyObjectBinder = actionBinderFactory.CreateBinder(model, action);
				action.RegisterLinkedDisposable(readOnlyObjectBinder);
				readOnlyObjectBinder.InitializeRightFromLeft();
				return action;
			});
		}, delegate(IComplexCollection<Pro.Entity.IAction> r, ActionCollection l)
		{
			r.Items.SynchronizeTo(l.Collection, (Pro.Entity.IAction e, IAction m) => m.ID == e.Uuid.Value, delegate(Pro.Entity.IAction e, int i)
			{
				IAction action2 = actionBinderFactory.CreateAction(e, l.ContainerId);
				IReadOnlyObjectBinder<IAction, Pro.Entity.IAction> readOnlyObjectBinder2 = actionBinderFactory.CreateBinder(action2, e);
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				l.Insert(action2, i);
			}, l.Collection.Move, delegate(int i)
			{
				IAction action3 = l.ElementAtOrDefault(i);
				if (action3 != null)
				{
					l.Remove(action3);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public ActionCollection()
		: this((IAction a) => true)
	{
	}

	internal ActionCollection(Predicate<IAction> canRemove)
	{
		_canRemove = canRemove;
	}

	public void Add(IAction action)
	{
		Insert(action, base.Collection.Count);
	}

	public void Insert(IAction action, int index)
	{
		OnInsert(action, index);
	}

	public bool Remove(IAction action)
	{
		return OnRemove(action);
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(delegate(IAction a)
		{
			Remove(a);
		});
	}

	private void OnInsert(IAction action, int index)
	{
		action.DataModified += OnDataModified;
		action.UndoStack = UndoStack;
		base.Collection.Insert(index, action);
	}

	private bool OnRemove(IAction action)
	{
		if (!_canRemove(action))
		{
			return false;
		}
		action.DataModified -= OnDataModified;
		action.Dispose();
		return base.Collection.Remove(action);
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<IAction>().ForEach(delegate(IAction a)
		{
			a.DataModified -= OnDataModified;
		});
		e.NewItems?.Cast<IAction>().ForEach(delegate(IAction a)
		{
			a.DataModified += OnDataModified;
			if (a is ICanReceiveMediaContainerIdUpdates canReceiveMediaContainerIdUpdates)
			{
				canReceiveMediaContainerIdUpdates.UpdateContainerId(ContainerId);
			}
		});
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	internal void Deserialize(Pro.SerializationInterop.RVProtoData.Cue data, ApplicationData? applicationData, string containerId)
	{
		Deserialize(data.Actions, applicationData, containerId);
	}

	public void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Action> protoActions, ApplicationData? applicationData, string containerId)
	{
		ContainerId = containerId;
		base.Collection.DeserializeCollection(protoActions, delegate(IAction a, Pro.SerializationInterop.RVProtoData.Action p)
		{
			Guid? guid = a?.ID;
			Guid? guid2 = p.Uuid?.ToGuid();
			if (guid.HasValue != guid2.HasValue)
			{
				return false;
			}
			return !guid.HasValue || guid.GetValueOrDefault() == guid2.GetValueOrDefault();
		}, delegate(Pro.SerializationInterop.RVProtoData.Action p)
		{
			if (p.Type.IsAnyOf(default(Pro.SerializationInterop.RVProtoData.Action.Types.ActionType)))
			{
				return (IAction)null;
			}
			try
			{
				return p.Type.ToActionType().ConstructAction(p, ContainerId);
			}
			catch (NotSupportedException)
			{
				Log.Error($"Encountered unknown action type {p.Type}");
				return (IAction)null;
			}
		}, delegate(IAction a)
		{
			if (a != null)
			{
				if (a is ICanReceiveMediaContainerIdUpdates canReceiveMediaContainerIdUpdates)
				{
					canReceiveMediaContainerIdUpdates.UpdateContainerId(ContainerId);
				}
				Add(a);
			}
		}, delegate(IAction a)
		{
			if (a != null)
			{
				Remove(a);
			}
		}, delegate(IAction a, Pro.SerializationInterop.RVProtoData.Action p)
		{
			if (a != null)
			{
				a.DataModified -= OnDataModified;
				a.Deserialize(p, applicationData, containerId);
				a.DataModified += OnDataModified;
			}
		});
	}

	internal void Serialize(Pro.SerializationInterop.RVProtoData.Cue data)
	{
		data.Actions.AddRange(base.Collection.Select((IAction a) => a.Serialize()));
	}

	public void UpdateContainerId(string containerId)
	{
		ContainerId = containerId;
		base.Collection.OfType<ICanReceiveMediaContainerIdUpdates>().ForEach(delegate(ICanReceiveMediaContainerIdUpdates x)
		{
			x.UpdateContainerId(containerId);
		});
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
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		base.Collection.ForEach(delegate(IAction a)
		{
			a.Dispose();
			a.DataModified -= OnDataModified;
		});
		base.Collection.Clear();
	}
}
