using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class StageScreenAssignments : ImmutableObservableCollection<StageScreenAssignment>, IStageScreenAssignments, ICloneable<StageScreenAssignments>, IImmutableObservableCollection<StageScreenAssignment>, IReadOnlyList<StageScreenAssignment>, IEnumerable<StageScreenAssignment>, IEnumerable, IReadOnlyCollection<StageScreenAssignment>, INotifyEnumerableChanged<StageScreenAssignment>, INotifyCollectionChanged
{
	private readonly List<StageScreenAssignment> _deleted = new List<StageScreenAssignment>();

	private UndoStack? _undoStack;

	internal IImmutableObservableCollection<ScreenArrangementBase> Screens { get; }

	internal StagePresentation Layouts { get; }

	public bool IsValid
	{
		get
		{
			OnValidate(raisePropertyChange: false);
			return base.Collection.All((StageScreenAssignment m) => m.IsValid);
		}
	}

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			base.Collection.ForEach(delegate(StageScreenAssignment a)
			{
				a.UndoStack = value;
			});
		}
	}

	public event System.Action? CollectionModified;

	public StageScreenAssignments(IImmutableObservableCollection<ScreenArrangementBase> screens, StagePresentation layouts)
	{
		Screens = screens;
		Layouts = layouts;
		Screens.ForEach(AddScreenAssignment);
		Layouts.ArrangementGroups.ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged += Cues_CollectionChanged;
			g.Cues.ForEach(delegate(SlideCue c)
			{
				c.PropertyChanged += SlideCue_PropertyChanged;
			});
		});
		Screens.CollectionChanged += Screens_CollectionChanged;
		Layouts.ArrangementGroups.CollectionChanged += ArrangementGroups_CollectionChanged;
	}

	private void Screens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UndoStack?.StartIgnoring();
		e.OldItems?.OfType<ScreenArrangementBase>().ForEach(RemoveScreenAssignment);
		e.NewItems?.OfType<ScreenArrangementBase>().ForEach(AddScreenAssignment);
		SortScreens();
		UndoStack?.StopIgnoring();
	}

	private void SortScreens()
	{
		for (int i = 0; i < Screens.Count(); i++)
		{
			ScreenArrangementBase screen = Screens[i];
			StageScreenAssignment stageScreenAssignment = base.Collection.FirstOrDefaultBy((StageScreenAssignment a) => a.Screen.ID == screen.ID, (StageScreenAssignment a) => a.Screen.Name == screen.Name);
			if (stageScreenAssignment != null)
			{
				base.Collection.MoveTo(stageScreenAssignment, i);
			}
		}
	}

	private StageScreenAssignment? GetAssignmentFromScreen(Guid id, string name)
	{
		return base.Collection.FirstOrDefaultBy((StageScreenAssignment a) => a.Screen.ID == id, (StageScreenAssignment a) => a.Screen.Name == name);
	}

	private void RemoveScreenAssignment(ScreenArrangementBase screen)
	{
		screen.PropertyChanged -= Screen_PropertyChanged;
		StageScreenAssignment assignmentFromScreen = GetAssignmentFromScreen(screen.ID, screen.Name);
		if (assignmentFromScreen != null)
		{
			_deleted.Add(assignmentFromScreen);
		}
		RemoveAssignment(assignmentFromScreen?.Screen);
	}

	private void AddScreenAssignment(ScreenArrangementBase screen)
	{
		screen.PropertyChanged += Screen_PropertyChanged;
		Identifier screen2 = new Identifier(screen.ID, screen.Name);
		StageScreenAssignment stageScreenAssignment = _deleted.FirstOrDefaultBy((StageScreenAssignment a) => a.Screen.ID == screen.ID, (StageScreenAssignment a) => a.Screen.Name == screen.Name);
		if (stageScreenAssignment != null)
		{
			Identifier layout = stageScreenAssignment.Layout;
			layout = (((object)layout != null && Layouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue a) => a.Source).FirstOrDefaultBy((SlideCue s) => s.ID == layout.ID, (SlideCue s) => s.Name == layout.Name) != null) ? layout : null);
			_deleted.Remove(stageScreenAssignment);
			stageScreenAssignment.Screen = screen2;
			stageScreenAssignment.Layout = layout;
			AddAssignment(stageScreenAssignment);
		}
		else
		{
			stageScreenAssignment = GetAssignmentFromScreen(screen.ID, screen.Name);
			if (stageScreenAssignment != null)
			{
				stageScreenAssignment.CanAssign = CheckCanAssign(stageScreenAssignment.Screen);
				return;
			}
			AddAssignment(new StageScreenAssignment(screen2, null)
			{
				UndoStack = UndoStack
			});
		}
	}

	private void Screen_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName == null || !propertyName.Equals("Name"))
		{
			return;
		}
		ScreenArrangementBase screen = sender as ScreenArrangementBase;
		if (screen == null)
		{
			return;
		}
		StageScreenAssignment stageScreenAssignment = base.Collection.FirstOrDefaultBy((StageScreenAssignment a) => a.Screen.ID == screen.ID);
		if (stageScreenAssignment != null)
		{
			StageScreenAssignment stageScreenAssignment2 = _deleted.FirstOrDefaultBy((StageScreenAssignment a) => a.Screen.ID == screen.ID, (StageScreenAssignment a) => a.Screen.Name == screen.Name);
			if (stageScreenAssignment2 != null)
			{
				stageScreenAssignment.Layout = stageScreenAssignment2.Layout ?? stageScreenAssignment.Layout;
				_deleted.Remove(stageScreenAssignment2);
			}
			stageScreenAssignment.CanAssign = CheckCanAssign(stageScreenAssignment.Screen);
			stageScreenAssignment.Screen.Name = screen.Name;
			SortScreens();
		}
	}

	private void ArrangementGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged -= Cues_CollectionChanged;
		});
		e.NewItems?.OfType<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged += Cues_CollectionChanged;
		});
	}

	private void Cues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		bool collectionWasModified = false;
		e.OldItems?.OfType<SlideCue>().ForEach(delegate(SlideCue c)
		{
			if (base.Collection.FirstOrDefaultBy((StageScreenAssignment a) => (object)a.Layout != null && a.Layout.ID == c.ID) != null)
			{
				collectionWasModified = true;
			}
			c.PropertyChanged -= SlideCue_PropertyChanged;
		});
		e.NewItems?.OfType<SlideCue>().ForEach(delegate(SlideCue c)
		{
			c.PropertyChanged += SlideCue_PropertyChanged;
		});
		if (collectionWasModified)
		{
			OnCollectionModified();
		}
	}

	private void SlideCue_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName == null || !propertyName.Equals("Name"))
		{
			return;
		}
		SlideCue layout = sender as SlideCue;
		if (layout != null)
		{
			StageScreenAssignment stageScreenAssignment = base.Collection.FirstOrDefaultBy((StageScreenAssignment a) => (object)a.Layout != null && a.Layout.ID == layout.ID);
			if ((object)stageScreenAssignment?.Layout != null)
			{
				stageScreenAssignment.Layout.Name = layout.Name;
			}
		}
	}

	public IEnumerable<Stage.Types.ScreenAssignment> Serialize()
	{
		return base.Collection.Select((StageScreenAssignment a) => new Stage.Types.ScreenAssignment
		{
			Screen = a.Screen.Serialize(),
			Layout = a.Layout?.Serialize()
		});
	}

	public void Deserialize(IEnumerable<Stage.Types.ScreenAssignment> protoScreenAssignments, IImmutableObservableCollection<ScreenArrangementBase> stageScreens)
	{
		foreach (Stage.Types.ScreenAssignment protoScreenAssignment in protoScreenAssignments)
		{
			if (protoScreenAssignment.Screen != null)
			{
				Identifier screen = new Identifier(protoScreenAssignment.Screen);
				Identifier layout = null;
				if (protoScreenAssignment.Layout != null)
				{
					layout = new Identifier(protoScreenAssignment.Layout);
				}
				if (stageScreens.FirstOrDefault((ScreenArrangementBase s) => s.Name == screen.Name) != null)
				{
					StageScreenAssignment assignment = new StageScreenAssignment(screen, layout)
					{
						CanAssign = CheckCanAssign(screen),
						UndoStack = UndoStack
					};
					AddAssignment(assignment);
				}
			}
		}
	}

	public void AddAssignment(StageScreenAssignment assignment)
	{
		InsertAssignment(assignment, base.Collection.Count);
	}

	public void InsertAssignment(StageScreenAssignment assignment, int index)
	{
		UndoStack?.StartIgnoring();
		if (assignment.Screen.ID == Guid.Empty)
		{
			ScreenArrangementBase screenArrangementBase = Screens.FirstOrDefault();
			if (screenArrangementBase == null)
			{
				return;
			}
			assignment.Screen = new Identifier(screenArrangementBase.ID, screenArrangementBase.Name);
		}
		StageScreenAssignment assignmentFromScreen = GetAssignmentFromScreen(assignment.Screen.ID, assignment.Screen.Name);
		if (assignmentFromScreen != null)
		{
			assignmentFromScreen.CanAssign = CheckCanAssign(assignment.Screen);
			assignmentFromScreen.Layout = assignment.Layout;
		}
		else
		{
			assignment.DataModified += OnCollectionModified;
			base.Collection.Insert(index, assignment);
			OnCollectionModified();
		}
		UndoStack?.StopIgnoring();
	}

	public void MoveAssignment(int fromIndex, int toIndex)
	{
		base.Collection.Move(fromIndex, toIndex);
		OnCollectionModified();
	}

	public void RemoveAssignment(StageScreenAssignment assignment)
	{
		assignment.DataModified -= OnCollectionModified;
		base.Collection.Remove(assignment);
	}

	public void Clear()
	{
		base.Collection.ForEach(delegate(StageScreenAssignment x)
		{
			x.DataModified -= OnCollectionModified;
		});
		base.Collection.Clear();
		OnCollectionModified();
	}

	private void RemoveAssignment(Identifier? screen)
	{
		if ((object)screen != null)
		{
			StageScreenAssignment assignmentFromScreen = GetAssignmentFromScreen(screen.ID, screen.Name);
			if (assignmentFromScreen != null)
			{
				assignmentFromScreen.DataModified -= OnCollectionModified;
				base.Collection.Remove(assignmentFromScreen);
				OnCollectionModified();
			}
		}
	}

	private void OnCollectionModified()
	{
		this.CollectionModified?.Invoke();
	}

	public StageScreenAssignments Clone()
	{
		StageScreenAssignments stageScreenAssignments = new StageScreenAssignments(Screens, Layouts);
		using IEnumerator<StageScreenAssignment> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			StageScreenAssignment current = enumerator.Current;
			stageScreenAssignments.AddAssignment(current.Clone());
		}
		return stageScreenAssignments;
	}

	private bool CheckCanAssign(Identifier screen)
	{
		return Screens.Any((ScreenArrangementBase s) => s.ID == screen.ID || s.Name == screen.Name);
	}

	public void Validate()
	{
		OnValidate(raisePropertyChange: true);
	}

	private void OnValidate(bool raisePropertyChange)
	{
		foreach (StageScreenAssignment assignment in base.Collection.Where((StageScreenAssignment a) => (object)a.Layout != null && a.CanAssign))
		{
			assignment.IsValid = Layouts.Layouts.Any(delegate(SlideCue l)
			{
				Guid iD = l.ID;
				Guid? obj = assignment?.Layout?.ID;
				return iD == obj || l.Name == assignment?.Layout?.Name;
			});
		}
		if (raisePropertyChange)
		{
			OnPropertyChanged("IsValid");
		}
	}
}
