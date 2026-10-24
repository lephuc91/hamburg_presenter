using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Strings;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Arrangements;

public class ArrangementCollection : ImmutableObservableCollection<IArrangement>
{
	private UndoStack _undoStack;

	private readonly bool _canShowGroupLabel;

	public Arrangement MasterArrangement { get; }

	public UndoStack UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			if (_undoStack != value)
			{
				_undoStack = value;
				MasterArrangement.UndoStack = _undoStack;
				this.ForEach(delegate(IArrangement arrangement)
				{
					arrangement.UndoStack = _undoStack;
				});
			}
		}
	}

	public event Action<ArrangementCollection>? DataModified;

	public ArrangementCollection(IPresentation presentation, bool canShowGroupLabel)
	{
		_canShowGroupLabel = canShowGroupLabel;
		MasterArrangement = new Arrangement(presentation, canShowGroupLabel);
		_undoStack = presentation.UndoStack;
		base.CollectionChanged += ArrangementCollection_CollectionChanged;
	}

	public IArrangement AddArrangement(string name, IArrangement targetArrangement)
	{
		return InsertArrangement(base.Count, name, targetArrangement);
	}

	public IArrangement AddArrangement(string name)
	{
		return InsertArrangement(base.Count, name, null);
	}

	public IArrangement AddArrangement(string name, IEnumerable<CueGroup>? groups)
	{
		return InsertArrangement(base.Count, name, groups);
	}

	public IArrangement InsertArrangement(int index, string name, IEnumerable<CueGroup>? groups)
	{
		Arrangement arrangement = new Arrangement(name, groups ?? MasterArrangement, UndoStack, _canShowGroupLabel);
		InsertArrangement(index, arrangement);
		return arrangement;
	}

	public void InsertArrangement(int index, IArrangement arrangement)
	{
		index = base.Collection.ClampIndexExclusive(index);
		base.Collection.Insert(index, arrangement);
		UndoStack.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddArrangement), delegate
		{
			base.Collection.RemoveAt(index);
		}, delegate
		{
			base.Collection.Insert(index, arrangement);
		}, null, null, autoFinalize: true);
	}

	public IArrangement DuplicateArrangement(IArrangement targetArrangement)
	{
		return DuplicateArrangements(new IArrangement[1] { targetArrangement }).First();
	}

	public IEnumerable<IArrangement> DuplicateArrangements(IEnumerable<IArrangement> targetArrangements)
	{
		UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.DuplicateArrangement));
		IArrangement[] result = targetArrangements.Select((IArrangement a) => AddArrangement(a.Name.DuplicateName(base.Collection, (IArrangement i) => i.Name), a)).ToArray();
		UndoStack.EndCommit(null, null, autoFinalize: true);
		return result;
	}

	public void RemoveArrangement(IArrangement arrangement)
	{
		RemoveArrangements(new IArrangement[1] { arrangement });
	}

	public void RemoveArrangements(IEnumerable<IArrangement> arrangements)
	{
		if (!base.Collection.ContainsAny(arrangements))
		{
			throw new InvalidOperationException("Collection does not contain arrangement");
		}
		KeyValuePair<IArrangement, int>[] indices = (from v in arrangements.ToDictionary((IArrangement a) => a, (IArrangement a) => base.Collection.IndexOf(a))
			orderby v.Value
			select v).ToArray();
		UndoStack.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RemoveArrangement), delegate
		{
			indices.ForEach(delegate(KeyValuePair<IArrangement, int> v)
			{
				base.Collection.Insert(v.Value, v.Key);
			});
		}, delegate
		{
			indices.Reverse().ForEach(delegate(KeyValuePair<IArrangement, int> v)
			{
				base.Collection.RemoveAt(v.Value);
			});
		});
		base.Collection.RemoveRange(arrangements);
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(RemoveArrangement);
	}

	private void ArrangementCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<Arrangement>().ForEach(delegate(Arrangement a)
		{
			a.DataModified -= ArrangementModified;
		});
		e.NewItems?.Cast<Arrangement>().ForEach(delegate(Arrangement a)
		{
			a.DataModified += ArrangementModified;
		});
		OnDataModified();
	}

	private void ArrangementModified(IArrangement arrangement)
	{
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	public void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement> protoArrangements)
	{
		base.Collection.DeserializeCollection(protoArrangements, (IArrangement a, Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement p) => a.ID == p.Uuid.ToGuid(), (Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement p) => AddArrangement(p.Name), delegate
		{
		}, RemoveArrangement, delegate(IArrangement a, Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement p)
		{
			a.Deserialize(p);
		});
	}

	public void MoveArrangement(IEnumerable<IArrangement> arrangements, int index)
	{
		UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveArrangement));
		base.Collection.MoveTo(arrangements, index, UndoStack);
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	internal void Move(int from, int to)
	{
		base.Collection.Move(from, to);
	}
}
