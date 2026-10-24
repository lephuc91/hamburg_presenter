using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class ColorTriggerCollection : ImmutableObservableCollection<IColorTrigger>, IColorTriggerCollection, IDragDropCollection<IColorTrigger>, INotifyEnumerableChanged<IColorTrigger>, IEnumerable<IColorTrigger>, IEnumerable, INotifyCollectionChanged
{
	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			this.ForEach(delegate(IColorTrigger t)
			{
				t.UndoStack = value;
			});
		}
	}

	public event System.Action? CollectionModified;

	public ColorTriggerCollection()
	{
		base.CollectionChanged += delegate
		{
			OnCollectionModified();
		};
	}

	private void Insert(IColorTrigger colorTrigger, int index = -1)
	{
		index = ((index < 0) ? base.Count : index);
		insertAction();
		UndoStack?.Commit(UndoActionTypes.AddColorTrigger.ToAction(), delegate
		{
			Remove(colorTrigger);
		}, insertAction, null, null, autoFinalize: true);
		void insertAction()
		{
			colorTrigger.DataModified += OnCollectionModified;
			colorTrigger.UndoStack = UndoStack;
			base.Collection.Insert(index, colorTrigger);
		}
	}

	private void OnInsert(int index, IEnumerable<IColorTrigger> colorTriggers, bool autoFinalize = true)
	{
		if (colorTriggers != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddColorTrigger.ToAction());
			colorTriggers.ForEach(delegate(IColorTrigger c)
			{
				Insert(c, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize);
		}
	}

	public void Add()
	{
		Add(new ColorTrigger());
	}

	public void Add(IColorTrigger colorTrigger)
	{
		Add(new IColorTrigger[1] { colorTrigger });
	}

	public void Add(IEnumerable<IColorTrigger> colorTriggers)
	{
		colorTriggers = colorTriggers.ToArray();
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddColorTrigger), delegate
		{
			Remove(colorTriggers);
		}, delegate
		{
			Add(colorTriggers);
		});
		colorTriggers.ForEach(delegate(IColorTrigger c)
		{
			Insert(c);
		});
	}

	private void OnRemove(IColorTrigger colorTrigger)
	{
		colorTrigger.DataModified -= OnCollectionModified;
		base.Collection.Remove(colorTrigger);
	}

	public void Remove(IColorTrigger colorTrigger)
	{
		Remove(new IColorTrigger[1] { colorTrigger });
	}

	public void Remove(IEnumerable<IColorTrigger> colorTriggers)
	{
		colorTriggers = colorTriggers.ToArray();
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RemoveColorTrigger), delegate
		{
			Add(colorTriggers);
		}, delegate
		{
			Remove(colorTriggers);
		});
		colorTriggers.ForEach(OnRemove);
	}

	public void Clear()
	{
		Remove(base.Collection.ToArray());
	}

	public void DraggedFrom(IEnumerable<IColorTrigger> items)
	{
	}

	public void DroppedInto(IEnumerable<IColorTrigger> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MoveColorTrigger.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		OnInsert(index, items);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<IColorTrigger> items, int index)
	{
		UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveColorTrigger));
		base.Collection.MoveTo(items, index, UndoStack);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	protected internal IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ColorTrigger> Serialize()
	{
		return base.Collection.Select((IColorTrigger c) => c.Serialize());
	}

	protected internal void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ColorTrigger> protoColorTriggers)
	{
		Clear();
		Add(protoColorTriggers.Select(ColorTrigger.Deserialize).ToArray());
	}

	private void OnCollectionModified()
	{
		this.CollectionModified?.Invoke();
	}
}
