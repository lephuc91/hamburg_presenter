using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Label;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Arrangements;

public class Arrangement : ImmutableObservableCollection<CueGroup>, IArrangement, INotifyEnumerableChanged<CueGroup>, IEnumerable<CueGroup>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IReadOnlyCollection<CueGroup>
{
	private Guid _id = Guid.NewGuid();

	private string? _name;

	private readonly ObservableCollection<ArrangedCue> _arrangedCues = new ObservableCollection<ArrangedCue>();

	private readonly Dictionary<CueGroup, NotifyCollectionChangedEventHandler> _cueCollectionHandlers = new Dictionary<CueGroup, NotifyCollectionChangedEventHandler>();

	private readonly bool _canShowGroupLabel;

	public Guid ID => _id;

	public string Name
	{
		get
		{
			return _name ?? string.Empty;
		}
		set
		{
			if (_name != value)
			{
				_name = value;
				OnPropertyChanged("Name");
				OnDataModified();
			}
		}
	}

	public bool IsMaster { get; }

	public IImmutableObservableCollection<ArrangedCue> ArrangedCues => _arrangedCues.ConvertImmutable();

	public UndoStack UndoStack { get; set; }

	public event Action<Arrangement>? DataModified;

	public ObjectBinder<Arrangement, Pro.Entity.IPresentation.Types.IArrangement> Bind(IUiScheduler scheduler, Pro.Entity.IPresentation.Types.IArrangement right, Func<IReadOnlyList<CueGroup>> getAllGroups)
	{
		ObjectBinder<Arrangement, Pro.Entity.IPresentation.Types.IArrangement> objectBinder = new ObjectBinder<Arrangement, Pro.Entity.IPresentation.Types.IArrangement>(this, right);
		objectBinder.Bind((Arrangement l) => l.WhenPropertyChanges("ID"), (Pro.Entity.IPresentation.Types.IArrangement r) => r.Uuid.WhenValueChanges, delegate(Arrangement l, Pro.Entity.IPresentation.Types.IArrangement r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(Pro.Entity.IPresentation.Types.IArrangement r, Arrangement l)
		{
			l._id = r.Uuid.Value;
		}).Bind((Arrangement l) => l.WhenPropertyChanges("Name"), (Pro.Entity.IPresentation.Types.IArrangement r) => r.Name.WhenValueChanges, delegate(Arrangement l, Pro.Entity.IPresentation.Types.IArrangement r)
		{
			r.Name.Set(l.Name);
		}, delegate(Pro.Entity.IPresentation.Types.IArrangement r, Arrangement l)
		{
			l.Name = r.Name.Value ?? string.Empty;
		}).Bind((Arrangement l) => l.WhenCollectionChanges(), (Pro.Entity.IPresentation.Types.IArrangement r) => r.GroupIdentifiers.WhenCollectionChanges, delegate(Arrangement l, Pro.Entity.IPresentation.Types.IArrangement r)
		{
			l.Items.SynchronizeTo(r.GroupIdentifiers.Items, (CueGroup m, Guid e) => m.ID == e, delegate(CueGroup c, int i)
			{
				r.GroupIdentifiers.Insert(i, c.ID);
			}, r.GroupIdentifiers.Move, r.GroupIdentifiers.RemoveAt);
		}, delegate(Pro.Entity.IPresentation.Types.IArrangement r, Arrangement l)
		{
			IReadOnlyList<CueGroup> allGroups = getAllGroups();
			r.GroupIdentifiers.Items.SynchronizeTo(l, (Guid e, CueGroup m) => m != null && m.ID == e, delegate(Guid e, int i)
			{
				CueGroup cueGroup = allGroups.FirstOrDefault((CueGroup g) => g.ID == e);
				if (cueGroup != null)
				{
					l.InsertArrangementGroup(i, cueGroup);
				}
			}, l.Collection.Move, l.Collection.RemoveAt);
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public Arrangement(UndoStack undoStack, bool canShowGroupLabel)
	{
		UndoStack = undoStack;
		_canShowGroupLabel = canShowGroupLabel;
		_arrangedCues.CollectionChanged += ArrangedCues_CollectionChanged;
	}

	public Arrangement(string name, IEnumerable<CueGroup> groups, UndoStack undoStack, bool canShowGroupLabel)
		: this(undoStack, canShowGroupLabel)
	{
		_name = name;
		AddArrangementGroups(groups);
	}

	public Arrangement(ProPresenter.DO.Presentation.IPresentation presentation, bool canShowGroupLabel)
		: this(presentation.UndoStack, canShowGroupLabel)
	{
		IsMaster = true;
		presentation.ArrangementGroups.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			if (e.OldItems != null)
			{
				OnRemoveArrangementGroups(e.OldItems.Cast<CueGroup>(), isReversible: false);
			}
			if (e.NewItems != null)
			{
				OnInsertArrangementGroups(e.NewStartingIndex, e.NewItems.Cast<CueGroup>(), isReversible: false);
			}
		};
	}

	private void ArrangedCues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		_arrangedCues.ForEach(delegate(ArrangedCue a)
		{
			a.Index = _arrangedCues.IndexOf(a) + 1;
		});
	}

	public void AddArrangementGroup(CueGroup group)
	{
		AddArrangementGroups(new CueGroup[1] { group });
	}

	public void AddArrangementGroups(IEnumerable<CueGroup> groups)
	{
		if (IsMaster)
		{
			throw new InvalidOperationException("Modifying the master arrangement is not directly supported");
		}
		InsertArrangementGroups(base.Count, groups);
	}

	public void InsertArrangementGroup(int index, CueGroup group)
	{
		InsertArrangementGroups(index, new CueGroup[1] { group });
	}

	public void InsertArrangementGroups(int index, IEnumerable<CueGroup> groups)
	{
		if (IsMaster)
		{
			throw new InvalidOperationException("Modifying the master arrangement is not directly supported");
		}
		OnInsertArrangementGroups(index, groups, isReversible: true);
	}

	private void OnInsertArrangementGroups(int index, IEnumerable<CueGroup> groups, bool isReversible)
	{
		groups = groups.Collect((CueGroup g) => (!base.Collection.Contains(g) && !groups.NonDistinct().Contains(g)) ? g : new CueGroup(g)).ToArray();
		index = base.Collection.ClampIndexToCount(index);
		if (isReversible)
		{
			UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AddArrangementGroup), delegate
			{
				base.Collection.RemoveAtRange(index, groups.Count());
			}, delegate
			{
				base.Collection.InsertRange(index, groups);
			}, null, null, autoFinalize: true);
		}
		base.Collection.InsertRange(index, groups, ignoreDuplicates: false);
	}

	public void MoveArrangementGroups(IEnumerable<CueGroup> groups, int index)
	{
		if (IsMaster)
		{
			throw new InvalidOperationException("Modifying the master arrangement is not directly supported");
		}
		OnMoveArrangementGroups(groups, index, isReversible: true);
	}

	private void OnMoveArrangementGroups(IEnumerable<CueGroup> groups, int index, bool isReversible)
	{
		KeyValuePair<int, CueGroup>[] indices = (from i in base.Collection.ToDictionary(base.Collection.IndexOf, (CueGroup g) => g)
			orderby i.Key
			select i).ToArray();
		if (indices.Any((KeyValuePair<int, CueGroup> i) => i.Key < 0))
		{
			throw new InvalidOperationException("Collection does not contain one or more groups");
		}
		System.Action action = delegate
		{
			base.Collection.MoveTo(groups, index);
		};
		if (isReversible)
		{
			UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveArrangementGroup), delegate
			{
				indices.ForEach(delegate(KeyValuePair<int, CueGroup> i)
				{
					base.Collection.Move(base.Collection.IndexOf(i.Value), i.Key);
				});
			}, action, null, null, autoFinalize: true);
		}
		action();
	}

	public bool RemoveArrangementGroup(CueGroup group)
	{
		return RemoveArrangementGroups(new CueGroup[1] { group });
	}

	public bool RemoveArrangementGroups(IEnumerable<CueGroup> group)
	{
		if (IsMaster)
		{
			Log.Error("Modifying the master arrangement is not directly supported.");
			return false;
		}
		OnRemoveArrangementGroups(group, isReversible: true);
		return true;
	}

	private void OnRemoveArrangementGroups(IEnumerable<CueGroup> groups, bool isReversible)
	{
		KeyValuePair<int, CueGroup>[] indices = (from i in groups.ToDictionary(base.Collection.IndexOf, (CueGroup g) => g)
			orderby i.Key
			select i).ToArray();
		if (isReversible)
		{
			UndoStack?.Commit(UndoActionTypes.RemoveArrangementGroup.ToAction(), delegate
			{
				indices.ForEach(delegate(KeyValuePair<int, CueGroup> i)
				{
					base.Collection.Insert(i.Key, i.Value);
				});
			}, remove, null, null, autoFinalize: true);
		}
		remove();
		void remove()
		{
			indices.Reverse().ForEach(delegate(KeyValuePair<int, CueGroup> i)
			{
				base.Collection.RemoveAt(i.Key);
			});
		}
	}

	public void Clear()
	{
		OnRemoveArrangementGroups(base.Collection.ToArray(), isReversible: false);
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null)
		{
			foreach (CueGroup item in e.OldItems.Cast<CueGroup>())
			{
				OnCuesRemoved(item, item.Cues);
				RemoveCueCollectionChangedHandler(item);
				item.PropertyChanged -= Hotkey_PropertyChanged;
			}
		}
		if (e.NewItems != null)
		{
			foreach (CueGroup item2 in e.NewItems.Cast<CueGroup>())
			{
				OnCuesAdded(item2, item2.Cues);
				item2.PropertyChanged += Hotkey_PropertyChanged;
			}
			ResetCueCollectionChangedHandlers();
		}
		UpdateHotkeys();
		UpdateGroupLabelVisibility();
		OnDataModified();
	}

	private void ResetCueCollectionChangedHandlers()
	{
		KeyValuePair<CueGroup, NotifyCollectionChangedEventHandler>[] array = _cueCollectionHandlers.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			KeyValuePair<CueGroup, NotifyCollectionChangedEventHandler> keyValuePair = array[i];
			var (cueGroup2, value) = (KeyValuePair<CueGroup, NotifyCollectionChangedEventHandler>)(ref keyValuePair);
			cueGroup2.Cues.CollectionChanged -= value;
			_cueCollectionHandlers.Remove(cueGroup2);
		}
		foreach (CueGroup group in base.Collection)
		{
			NotifyCollectionChangedEventHandler value2 = delegate(object? s, NotifyCollectionChangedEventArgs e)
			{
				ArrangementGroup_CuesChanged(group, e);
			};
			_cueCollectionHandlers.Add(group, value2);
			group.Cues.CollectionChanged += value2;
		}
	}

	private void RemoveCueCollectionChangedHandler(CueGroup group)
	{
		if (_cueCollectionHandlers.ContainsKey(group))
		{
			NotifyCollectionChangedEventHandler value = _cueCollectionHandlers[group];
			_cueCollectionHandlers.Remove(group);
			group.Cues.CollectionChanged -= value;
		}
	}

	private void ArrangementGroup_CuesChanged(CueGroup group, NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null)
		{
			OnCuesRemoved(group, e.OldItems.Cast<SlideCue>());
		}
		if (e.NewItems != null)
		{
			OnCuesAdded(group, e.NewItems.Cast<SlideCue>(), e.NewStartingIndex);
		}
		UpdateHotkeys();
		UpdateGroupLabelVisibility();
	}

	private void Hotkey_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Label" || propertyName == "Hotkey")
		{
			UpdateHotkeys();
		}
	}

	private void OnCuesRemoved(CueGroup group, IEnumerable<SlideCue> cues)
	{
		foreach (SlideCue cue in cues)
		{
			cue.PropertyChanged -= Hotkey_PropertyChanged;
			_arrangedCues.RemoveIf((ArrangedCue a) => a.Source == cue && a.Group == group);
		}
	}

	private void OnCuesAdded(CueGroup group, IEnumerable<SlideCue> cues, int indexOffset = 0)
	{
		int index = base.Collection.TakeWhile((CueGroup g) => g != group).Sum((CueGroup g) => g.Cues.Count) + indexOffset;
		cues.ForEach(delegate(SlideCue c)
		{
			c.PropertyChanged += Hotkey_PropertyChanged;
		});
		_arrangedCues.InsertRange(index, cues.Collect((SlideCue c) => new ArrangedCue(c, group)));
	}

	private void UpdateHotkeys()
	{
		foreach (IGrouping<GroupLabel, ArrangedCue> item in from a in _arrangedCues
			group a by a.GroupLabel?.MasterLabel)
		{
			ArrangedCue arrangedCue = item.FirstOrDefault();
			foreach (ArrangedCue item2 in item)
			{
				item2.ShowGroupHotkey = item2 == arrangedCue;
			}
		}
		foreach (IGrouping<Pro.DO.Hotkey, ArrangedCue> item3 in from a in _arrangedCues
			group a by a.Source.Hotkey)
		{
			ArrangedCue arrangedCue2 = item3.FirstOrDefault();
			foreach (ArrangedCue item4 in item3)
			{
				int showSlideHotkey;
				if (item4 == arrangedCue2)
				{
					GroupLabel? groupLabel = item4.GroupLabel;
					showSlideHotkey = (((groupLabel != null && !groupLabel.Hotkey.IsValid()) || item4.Source != item4.Group.Cues.FirstOrDefault()) ? 1 : 0);
				}
				else
				{
					showSlideHotkey = 0;
				}
				item4.ShowSlideHotkey = (byte)showSlideHotkey != 0;
			}
		}
	}

	private void UpdateGroupLabelVisibility()
	{
		_arrangedCues.ContiguousGroups((ArrangedCue l, ArrangedCue r) => l.Group == r.Group).ForEach(delegate(ArrangedCue[] g)
		{
			g.ForEach(delegate(ArrangedCue s)
			{
				s.ShowGroupLabel = s == g[0] && _canShowGroupLabel;
			});
		});
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	public Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement arrangement = new Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement();
		arrangement.Uuid = ID.ToUUID();
		arrangement.Name = Name;
		arrangement.GroupIdentifiers.AddRange(base.Collection.Select((CueGroup g) => g.ID.ToUUID()));
		return arrangement;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement protoArrangement)
	{
		if (protoArrangement.Uuid != null)
		{
			_id = protoArrangement.Uuid.ToGuid();
		}
		Name = protoArrangement.Name;
	}
}
