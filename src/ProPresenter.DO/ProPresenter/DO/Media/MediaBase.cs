using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media;

public abstract class MediaBase : LinkedNotifyPropertyChangedBase, ICloneable<MediaBase>
{
	private UndoStack? _undoStack;

	public abstract MediaType MediaType { get; }

	public Guid ID { get; protected set; } = Guid.NewGuid();

	public bool SupportsSwappingSource { get; internal set; } = true;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			UndoStackChanged(value);
		}
	}

	public virtual bool IsValid => false;

	protected bool SuppressDataModifications { get; set; }

	public event Action<MediaBase>? DataModified;

	public event System.Action? VisualInvalidated;

	public event Action<string, string>? UpdateActionName;

	public virtual ObjectBinder<MediaBase, IMedia> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia right)
	{
		return Bind(scheduler, entityFactory, right);
	}

	protected ObjectBinder<MediaBase, IMedia> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia right)
	{
		ObjectBinder<MediaBase, IMedia> objectBinder = new ObjectBinder<MediaBase, IMedia>(this, right);
		objectBinder.Bind((MediaBase l) => l.WhenPropertyChanges("ID"), (IMedia r) => r.Uuid.WhenValueChanges, delegate(MediaBase l, IMedia r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMedia r, MediaBase l)
		{
			l.ID = r.Uuid.Value;
		});
		return objectBinder;
	}

	public abstract MediaBase Clone();

	protected virtual MediaBase CopyProperties(MediaBase newMedia)
	{
		return newMedia;
	}

	protected internal abstract void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media protoMedia);

	protected internal abstract Pro.SerializationInterop.RVProtoData.Media ProtoSerialize();

	protected virtual void OnDataModified()
	{
		if (!SuppressDataModifications)
		{
			this.DataModified?.Invoke(this);
		}
	}

	protected void OnUpdateActionName(string oldDefaultName, string newDefaultName)
	{
		this.UpdateActionName?.Invoke(oldDefaultName, newDefaultName);
	}

	protected void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke();
	}

	protected virtual void UndoStackChanged(UndoStack? undoStack)
	{
	}

	public virtual void UpdateValidity()
	{
		OnPropertyChanged("IsValid");
	}

	public abstract void TransposeProperties(MediaBase media);

	public void ResetId()
	{
		ID = Guid.NewGuid();
	}
}
