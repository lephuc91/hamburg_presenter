using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Builds;

public class ChildBuildCollection : ImmutableObservableCollection<ChildBuild>
{
	private UndoStack? _undoStack;

	public ClosedBezierPath Element { get; }

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			SetValue<UndoStack>("UndoStack", ref _undoStack, value, delegate(UndoStack o, UndoStack n)
			{
				base.Collection.ForEach(delegate(ChildBuild b)
				{
					b.UndoStack = n;
				});
			});
		}
	}

	public event Action? DataModified;

	public ChildBuildCollection(ClosedBezierPath element)
	{
		Element = element;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
	}

	public ChildBuild Add(int indexOfChild)
	{
		ChildBuild childBuild = new ChildBuild(Element, indexOfChild)
		{
			UndoStack = UndoStack
		};
		OnInsert(base.Collection.Count, childBuild);
		return childBuild;
	}

	public void Remove(IEnumerable<ChildBuild> childBuilds)
	{
		childBuilds.ForEach(OnRemove);
	}

	public void Clear()
	{
		Remove(base.Collection.ToArray());
	}

	internal void Copy(ChildBuildCollection other)
	{
		other.ForEach(delegate(ChildBuild b)
		{
			OnInsert(base.Collection.Count, new ChildBuild(Element, b));
		});
	}

	private void OnInsert(int index, ChildBuild childBuild)
	{
		childBuild.DataModified += OnDataModified;
		base.Collection.Insert(index, childBuild);
	}

	private void OnRemove(ChildBuild childBuild)
	{
		childBuild.DataModified -= OnDataModified;
		base.Collection.Remove(childBuild);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
