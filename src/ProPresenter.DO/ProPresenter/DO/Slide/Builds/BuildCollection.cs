using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Transitions;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Builds;

public class BuildCollection : ImmutableObservableCollection<IBuild>
{
	private UndoStack? _undoStack;

	private bool _ignoreChanges;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

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
				base.Collection.ForEach(delegate(IBuild b)
				{
					b.UndoStack = n;
				});
			});
		}
	}

	public event Action? DataModified;

	public event Action? BuildPropertyChanged;

	public BuildCollection(ITransitionDescriptionCollection transitionDescriptions)
	{
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
		_transitionDescriptions = transitionDescriptions;
	}

	public void AddBuild(IBuild build, bool isReversible = false)
	{
		InsertBuild(base.Collection.Count, build, isReversible);
	}

	public void InsertBuild(int index, IBuild build, bool isReversible = false)
	{
		OnInsertBuild(index, build, isReversible);
	}

	public Build AddBuildIn(SlideElementBase element, TransitionParameters? transition)
	{
		return AddBuildIn(element, new Build(element, transition, _transitionDescriptions));
	}

	public Build AddBuildIn(SlideElementBase element, Build build)
	{
		UndoStack?.BeginCommit(UndoActionTypes.AddBuildIn.ToAction());
		element.BuildIn = build;
		OnInsertBuild(base.Collection.Count, build);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		return build;
	}

	public Build AddBuildOut(SlideElementBase element, TransitionParameters? transition)
	{
		return AddBuildOut(element, new Build(element, transition, _transitionDescriptions));
	}

	public Build AddBuildOut(SlideElementBase element, Build build)
	{
		UndoStack?.BeginCommit(UndoActionTypes.AddBuildOut.ToAction());
		element.BuildOut = build;
		OnInsertBuild(base.Collection.Count, build);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		return build;
	}

	public void RemoveBuilds(SlideElementBase element, bool isReversible = false)
	{
		TeardownElement(element);
		element.AllBuilds.ForEach(delegate(IBuild b)
		{
			OnRemoveBuild(b, isReversible);
		});
	}

	public void RemoveBuildIn(SlideElementBase element)
	{
		if (element.BuildIn != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.RemoveBuildIn.ToAction());
			_ignoreChanges = true;
			IBuild[] first = element.AllBuilds.ToArray();
			element.RevealType = RevealType.None;
			element.BuildIn = null;
			first.Except(element.AllBuilds).ForEach(OnRemoveBuild);
			_ignoreChanges = false;
			UndoStack?.EndCommit(delegate
			{
				_ignoreChanges = true;
			}, delegate
			{
				_ignoreChanges = false;
			}, autoFinalize: true);
		}
	}

	public void RemoveBuildOut(SlideElementBase element)
	{
		if (element.BuildOut != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.RemoveBuildOut.ToAction());
			_ignoreChanges = true;
			OnRemoveBuild(element.BuildOut);
			element.BuildOut = null;
			_ignoreChanges = false;
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void Clear()
	{
		base.Collection.ToArray().ForEach(delegate(IBuild b)
		{
			OnRemoveBuild(b, updateNextBuildStart: false, isReversible: false);
		});
	}

	private void OnRemoveBuild(IBuild build)
	{
		OnRemoveBuild(build, updateNextBuildStart: true);
	}

	private void OnRemoveBuild(IBuild build, bool updateNextBuildStart, bool isReversible = true)
	{
		build.PropertyChanged -= Build_PropertyChanged;
		int index = base.Collection.IndexOf(build);
		if (index == -1)
		{
			return;
		}
		if (updateNextBuildStart)
		{
			updateNextBuild();
		}
		base.Collection.Remove(build);
		if (!isReversible)
		{
			return;
		}
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.Commit(delegate
			{
				OnInsertBuild(index, build);
			}, delegate
			{
				OnRemoveBuild(build, updateNextBuildStart);
			});
		}
		void updateNextBuild()
		{
			IBuild next = base.Collection.GetNext(build, (IBuild b) => b is Build);
			if (next != null)
			{
				if (build.Start == StartMode.OnClick)
				{
					next.Start = StartMode.OnClick;
				}
				else if (build.Start == StartMode.WithSlide)
				{
					next.Start = StartMode.WithSlide;
				}
			}
		}
	}

	private void OnInsertBuild(int index, IBuild build, bool isReversible = true)
	{
		if (base.Collection.Contains(build))
		{
			return;
		}
		if (build.Start == StartMode.WithSlide && base.Collection.Any((IBuild b) => b.Start == StartMode.WithSlide))
		{
			build.Start = StartMode.WithPrevious;
			index = base.Collection.FindIndex((IBuild b) => b.Start == StartMode.WithSlide) + 1;
		}
		build.UndoStack = UndoStack;
		build.PropertyChanged += Build_PropertyChanged;
		TeardownElement(build.Element);
		SetupElement(build.Element);
		base.Collection.Insert(index, build);
		if (!isReversible)
		{
			return;
		}
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack?.Commit(delegate
			{
				OnRemoveBuild(build);
			}, delegate
			{
				OnInsertBuild(index, build);
			});
		}
	}

	private void SetupElement(SlideElementBase element)
	{
		element.PropertyChanged += Element_PropertyChanged;
		if (element is ClosedBezierPath closedBezierPath)
		{
			closedBezierPath.ChildBuilds.CollectionChanged += ChildBuilds_CollectionChanged;
		}
	}

	private void TeardownElement(SlideElementBase element)
	{
		element.PropertyChanged -= Element_PropertyChanged;
		if (element is ClosedBezierPath closedBezierPath)
		{
			closedBezierPath.ChildBuilds.CollectionChanged -= ChildBuilds_CollectionChanged;
		}
	}

	private void Element_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (!_ignoreChanges && e.PropertyName == "AllBuilds")
		{
			sanitizeBuilds();
		}
		void sanitizeBuilds()
		{
			ClosedBezierPath element = sender as ClosedBezierPath;
			base.Collection.Where((IBuild b) => b.Element == element && !element.AllBuilds.Contains(b)).ToArray().ForEach(OnRemoveBuild);
			IBuild[] obj = element?.AllBuilds.Where((IBuild b) => !base.Collection.Contains(b)).ToArray();
			int insertIndex = base.Collection.FindIndex((IBuild b) => b.Element == element);
			insertIndex = ((insertIndex == -1) ? base.Collection.Count : insertIndex);
			obj?.Reverse().ForEach(delegate(IBuild b)
			{
				OnInsertBuild(insertIndex, b, isReversible: false);
			});
		}
	}

	private void ChildBuilds_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!_ignoreChanges)
		{
			e.OldItems?.Cast<ChildBuild>().ForEach(OnRemoveBuild);
			e.NewItems?.Cast<ChildBuild>().ForEach(insertBuild);
		}
		void insertBuild(IBuild build)
		{
			ChildBuildCollection childBuildCollection = sender as ChildBuildCollection;
			IBuild build2 = childBuildCollection?.ElementAtOrDefault(e.NewStartingIndex - 1);
			IBuild build3 = build2 ?? childBuildCollection?.Element.BuildIn;
			OnInsertBuild((build3 != null) ? (IndexOf(build3) + 1) : 0, build);
		}
	}

	private void Build_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Start":
		case "Delay":
		case "SelectedTransition":
			this.BuildPropertyChanged?.Invoke();
			break;
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public bool ValidateArrange(IBuild[] buildsToMove, int moveIndex)
	{
		if (moveIndex == 0)
		{
			IBuild? build = base.Collection.FirstOrDefault();
			if (build != null && build.Start == StartMode.WithSlide)
			{
				return false;
			}
		}
		List<IBuild> source = base.Collection.ToList();
		source.MoveTo(buildsToMove, moveIndex);
		foreach (SlideElementBase element in source.Select((IBuild b) => b.Element).Distinct())
		{
			if (!element.AllBuilds.ContentsMatchExactly(source.Where((IBuild b) => b.Element == element)))
			{
				return false;
			}
		}
		return true;
	}

	public void ArrangeBuildOrder(IBuild[] buildsToMove, int moveIndex, bool isInside, bool isHead, bool isTheSameGroup)
	{
		UndoStack?.BeginCommit(UndoActionTypes.ArrangeBuildOrder.ToAction());
		bool flag = false;
		foreach (IBuild build in buildsToMove)
		{
			if (build.Start == StartMode.OnClick)
			{
				flag = true;
			}
			int num = IndexOf(build) + 1;
			if (num != base.Count && !buildsToMove.Contains(base.Collection[num]) && (!isInside || !checkDropTargetIsHead(build)))
			{
				IBuild build2 = base.Collection[num];
				if (flag && (build2.Start == StartMode.WithPrevious || build2.Start == StartMode.AfterPrevious))
				{
					build2.Start = StartMode.OnClick;
				}
				flag = false;
			}
		}
		if (isInside)
		{
			buildsToMove.Where((IBuild b) => b.Start == StartMode.OnClick && !checkDropTargetIsHead(b)).ForEach(delegate(IBuild b)
			{
				b.Start = StartMode.WithPrevious;
			});
			if (isHead)
			{
				IBuild build3 = buildsToMove.First();
				IBuild build4 = base.Collection[Math.Min(moveIndex, base.Count - 1)];
				build3.Start = StartMode.OnClick;
				if (build3 != build4)
				{
					build4.Start = StartMode.WithPrevious;
				}
			}
		}
		else
		{
			buildsToMove.ForEach(delegate(IBuild b)
			{
				b.Start = StartMode.OnClick;
			});
		}
		base.Collection.MoveTo(buildsToMove, moveIndex, UndoStack);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		bool checkDropTargetIsHead(IBuild b)
		{
			int num2 = IndexOf(b);
			if (isTheSameGroup)
			{
				if (num2 != moveIndex)
				{
					return num2 == moveIndex - 1;
				}
				return true;
			}
			return false;
		}
	}

	internal void Reset(IEnumerable<Guid> buildOrder, SlideElementCollection elements)
	{
		if (buildOrder.Empty())
		{
			return;
		}
		UndoStack?.StartIgnoring();
		Clear();
		List<IBuild> allBuilds = elements.SelectMany((SlideElementBase e) => e.AllBuilds).ToList();
		buildOrder.Select(delegate(Guid id)
		{
			IBuild build = allBuilds.FirstOrDefault((IBuild b) => b.ID == id);
			if (build != null)
			{
				allBuilds.Remove(build);
			}
			return build;
		}).NonNull().ToArray()
			.Concat(allBuilds)
			.ForEach(delegate(IBuild b)
			{
				OnInsertBuild(base.Collection.Count, b);
			});
		SlideElementBase[] array = base.Collection.Select((IBuild b) => b.Element).Distinct().ToArray();
		foreach (SlideElementBase obj in array)
		{
			IBuild build2 = null;
			foreach (IBuild allBuild in obj.AllBuilds)
			{
				IBuild current;
				IBuild build3 = (current = allBuild);
				if (build2 != null)
				{
					int num = IndexOf(build2);
					int num2 = IndexOf(current);
					if (num2 < num)
					{
						base.Collection.Move(num2, base.Collection.ClampIndex(num + 1));
					}
				}
				build2 = build3;
			}
		}
		UndoStack?.StopIgnoring();
	}
}
