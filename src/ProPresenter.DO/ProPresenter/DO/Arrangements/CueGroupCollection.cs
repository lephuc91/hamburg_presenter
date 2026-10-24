using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.DO.Label;
using Pro.DO.Transitions;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Arrangements;

public class CueGroupCollection : ImmutableObservableCollection<CueGroup>
{
	private readonly IPresentation _presentation;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public event Action<CueGroupCollection>? DataModifed;

	public event Action<CueGroupCollection>? CuesChanged;

	public CueGroupCollection(IPresentation presentation, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_presentation = presentation;
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
	}

	public CueGroup AddArrangementGroup(GroupLabel group)
	{
		return InsertArrangementGroup(base.Count, group);
	}

	public CueGroup InsertArrangementGroup(int index, GroupLabel label)
	{
		CueGroup newGroup = new CueGroup(_presentation, label, _factoryProvider, _transitionDescriptions);
		InsertArrangementGroup(index, newGroup);
		_presentation.UndoStack.Commit(UndoActionTypes.AddArrangementGroup.ToAction(), delegate
		{
			RemoveArrangementGroup(newGroup);
		}, delegate
		{
			InsertArrangementGroup(index, newGroup);
		}, null, null, autoFinalize: true);
		return newGroup;
	}

	public void InsertArrangementGroup(int index, CueGroup group)
	{
		group.DataModified += Group_DataModified;
		group.Cues.CollectionChanged += Cues_CollectionChanged;
		base.Collection.Insert(base.Collection.ClampIndexToCount(index), group);
		OnDataModifed();
	}

	internal void Move(int from, int to)
	{
		base.Collection.Move(from, to);
		OnDataModifed();
	}

	private void Cues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnCuesChanged();
	}

	private void OnCuesChanged()
	{
		this.CuesChanged?.Invoke(this);
	}

	public void InsertArrangementGroups(int index, IEnumerable<CueGroup> groups)
	{
		groups.Reverse().ForEach(delegate(CueGroup g)
		{
			InsertArrangementGroup(index, g);
		});
	}

	public void RemoveArrangementGroup(CueGroup group)
	{
		group.DataModified -= Group_DataModified;
		group.Cues.CollectionChanged -= Cues_CollectionChanged;
		base.Collection.Remove(group);
		OnDataModifed();
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(RemoveArrangementGroup);
	}

	public void MoveArrangementGroups(int index, IEnumerable<CueGroup> groups)
	{
		_presentation.UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveArrangementGroup));
		base.Collection.MoveTo(groups, index.Clamp(0, base.Collection.Count), _presentation.UndoStack);
		OnDataModifed();
		_presentation.UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	private void Group_DataModified(CueGroup group)
	{
		OnDataModifed();
	}

	private void OnDataModifed()
	{
		this.DataModifed?.Invoke(this);
	}
}
