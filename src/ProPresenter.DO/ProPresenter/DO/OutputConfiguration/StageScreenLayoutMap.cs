using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.OutputConfiguration;

public class StageScreenLayoutMap : IReadOnlyDictionary<ScreenArrangementBase, SlideCue>, IEnumerable<KeyValuePair<ScreenArrangementBase, SlideCue>>, IEnumerable, IReadOnlyCollection<KeyValuePair<ScreenArrangementBase, SlideCue>>, ITriggerable
{
	private record struct Identification(Guid ID, string Name) : IIdentifiable
	{
		public static implicit operator Identification(CollectionElementType identifier)
		{
			return new Identification(identifier.ParameterUuid.ToGuid(), identifier.ParameterName);
		}

		public static implicit operator CollectionElementType(Identification identifier)
		{
			return new CollectionElementType
			{
				ParameterUuid = identifier.ID.ToUUID(),
				ParameterName = identifier.Name
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CSerialize_003Ed__20 : IEnumerable<Stage.Types.ScreenAssignment>, IEnumerable, IEnumerator<Stage.Types.ScreenAssignment>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Stage.Types.ScreenAssignment _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public StageScreenLayoutMap _003C_003E4__this;

		private Dictionary<Identification, Identification>.Enumerator _003C_003E7__wrap1;

		Stage.Types.ScreenAssignment IEnumerator<Stage.Types.ScreenAssignment>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSerialize_003Ed__20(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = default(Dictionary<Identification, Identification>.Enumerator);
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				StageScreenLayoutMap stageScreenLayoutMap = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = stageScreenLayoutMap._dictionary.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					KeyValuePair<Identification, Identification> current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = new Stage.Types.ScreenAssignment
					{
						Layout = current.Value,
						Screen = current.Key
					};
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = default(Dictionary<Identification, Identification>.Enumerator);
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003E7__wrap1/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<Stage.Types.ScreenAssignment> IEnumerable<Stage.Types.ScreenAssignment>.GetEnumerator()
		{
			_003CSerialize_003Ed__20 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CSerialize_003Ed__20(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Stage.Types.ScreenAssignment>)this).GetEnumerator();
		}
	}

	private readonly IImmutableObservableCollection<ScreenArrangementBase> _stageScreens;

	private readonly ProPresenter.DO.Presentation.IPresentation _stagePresentation;

	private readonly Dictionary<Identification, Identification> _dictionary = new Dictionary<Identification, Identification>();

	public IEnumerable<ScreenArrangementBase> Keys => from v in EnumerateValidItems()
		select v.Key;

	public IEnumerable<SlideCue> Values => from v in EnumerateValidItems()
		select v.Value;

	public int Count => EnumerateValidItems().Count();

	public SlideCue this[ScreenArrangementBase key]
	{
		get
		{
			if (_dictionary.TryGetValue(new Identification(key.ID, key.Name), out var cueIdentification))
			{
				SlideCue slideCue = GetCues().FirstOrDefault((SlideCue c) => c.ID == cueIdentification.ID && c.Name == cueIdentification.Name);
				if (slideCue != null)
				{
					return slideCue;
				}
			}
			throw new KeyNotFoundException();
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<StageScreenLayoutMap, Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment>> CreateBinder(IEntityFactory entityFactory, StageScreenLayoutMap left, Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment> right)
	{
		ObjectBinder<StageScreenLayoutMap, Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment>> objectBinder = new ObjectBinder<StageScreenLayoutMap, Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment>>(left, right);
		objectBinder.Bind((StageScreenLayoutMap l) => Observable.FromEvent(delegate(System.Action h)
		{
			l.DataModified += h;
		}, delegate(System.Action h)
		{
			l.DataModified -= h;
		}), (Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment> r) => r.WhenCollectionChanges, delegate(StageScreenLayoutMap l, Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment> r)
		{
			List<IStage.Types.IScreenAssignment> list = new List<IStage.Types.IScreenAssignment>();
			foreach (KeyValuePair<ScreenArrangementBase, SlideCue> item in l)
			{
				item.Deconstruct(out var key, out var value);
				ScreenArrangementBase screenArrangementBase = key;
				SlideCue slideCue = value;
				IStage.Types.IScreenAssignment screenAssignment = entityFactory.Create<IStage.Types.IScreenAssignment>();
				screenAssignment.Screen.Set(CreateIdentifier(entityFactory, screenArrangementBase.ID, screenArrangementBase.Name));
				screenAssignment.Layout.Set(CreateIdentifier(entityFactory, slideCue.ID, slideCue.Name));
				list.Add(screenAssignment);
			}
			r.Reset(list);
		}, delegate(Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment> r, StageScreenLayoutMap l)
		{
			foreach (IStage.Types.IScreenAssignment assignment in r.Items)
			{
				ScreenArrangementBase screenArrangementBase2 = l.Select<KeyValuePair<ScreenArrangementBase, SlideCue>, ScreenArrangementBase>((KeyValuePair<ScreenArrangementBase, SlideCue> a) => a.Key).FirstOrDefaultBy(delegate(ScreenArrangementBase s)
				{
					Guid iD = s.ID;
					Guid? value2 = assignment.Screen.Value.ParameterUuid.Value;
					return iD == value2;
				}, (ScreenArrangementBase s) => s.Name == assignment.Screen.Value.ParameterName.Value);
				if (screenArrangementBase2 != null)
				{
					SlideCue slideCue2 = l._stagePresentation?.DefaultArrangement.ArrangedCues.Select((ArrangedCue a) => a.Source).FirstOrDefaultBy(delegate(SlideCue s)
					{
						Guid iD2 = s.ID;
						Guid? value3 = assignment.Layout.Value.ParameterUuid.Value;
						return iD2 == value3;
					}, (SlideCue s) => s.Name == assignment.Layout.Value.ParameterName.Value);
					if (slideCue2 != null)
					{
						l.AssignScreen(screenArrangementBase2, slideCue2);
					}
				}
			}
		});
		return objectBinder;
	}

	private static ICollectionElementType CreateIdentifier(IEntityFactory entityFactory, Guid id, string name)
	{
		ICollectionElementType collectionElementType = entityFactory.Create<ICollectionElementType>();
		collectionElementType.ParameterUuid.Set(id);
		collectionElementType.ParameterName.Set(name);
		return collectionElementType;
	}

	public StageScreenLayoutMap(IImmutableObservableCollection<ScreenArrangementBase> stageScreens, ProPresenter.DO.Presentation.IPresentation stagePresentation)
	{
		_stageScreens = stageScreens;
		_stagePresentation = stagePresentation;
	}

	public void RemoveEntry(ScreenArrangementBase screenArrangement)
	{
		Identification key = new Identification(screenArrangement.ID, screenArrangement.Name);
		if (_dictionary.Remove(key))
		{
			screenArrangement.Screens.ForEach(delegate(Screen s)
			{
				s.PropertyChanged -= Screen_PropertyChanged;
			});
			OnDataModified();
		}
	}

	public void AssignScreen(ScreenArrangementBase? screenArrangement, SlideCue slideCue)
	{
		if (screenArrangement == null)
		{
			return;
		}
		Identification key = new Identification(screenArrangement.ID, screenArrangement.Name);
		bool num = _dictionary.ContainsKey(key);
		_dictionary[key] = new Identification(slideCue.ID, slideCue.Name);
		if (!num)
		{
			screenArrangement.Screens.ForEach(delegate(Screen s)
			{
				s.PropertyChanged += Screen_PropertyChanged;
			});
		}
		OnDataModified();
	}

	private void Screen_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("MainOutputDevice"))
		{
			OnDataModified();
		}
	}

	[IteratorStateMachine(typeof(_003CSerialize_003Ed__20))]
	public IEnumerable<Stage.Types.ScreenAssignment> Serialize()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSerialize_003Ed__20(-2)
		{
			_003C_003E4__this = this
		};
	}

	public void Deserialize(RepeatedField<Stage.Types.ScreenAssignment> mappings)
	{
		foreach (Identification item in _dictionary.Keys.ToList())
		{
			if (TryResolveScreen(item, out ScreenArrangementBase screen))
			{
				screen.Screens.ForEach(delegate(Screen s)
				{
					s.PropertyChanged -= Screen_PropertyChanged;
				});
			}
		}
		_dictionary.Clear();
		foreach (Stage.Types.ScreenAssignment mapping in mappings)
		{
			_dictionary[mapping.Screen] = mapping.Layout;
			if (TryResolveScreen(mapping.Screen, out ScreenArrangementBase screen2))
			{
				screen2.Screens.ForEach(delegate(Screen s)
				{
					s.PropertyChanged += Screen_PropertyChanged;
				});
			}
		}
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
		StageLayoutMapUpdated.Publish(_dictionary.Select((KeyValuePair<Identification, Identification> kv) => ((IIdentifiable, IIdentifiable))(kv.Key, kv.Value)).ToArray());
	}

	public bool ContainsKey(ScreenArrangementBase key)
	{
		SlideCue value;
		return TryGetValue(key, out value);
	}

	public bool TryGetValue(ScreenArrangementBase key, [MaybeNullWhen(false)] out SlideCue value)
	{
		if (_dictionary.TryGetValue(new Identification(key.ID, key.Name), out var value2))
		{
			return TryResolveCue(value2, out value);
		}
		value = null;
		return false;
	}

	public IEnumerator<KeyValuePair<ScreenArrangementBase, SlideCue>> GetEnumerator()
	{
		return EnumerateValidItems().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private IEnumerable<SlideCue> GetCues()
	{
		return _stagePresentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues);
	}

	private IEnumerable<KeyValuePair<ScreenArrangementBase, SlideCue>> EnumerateValidItems()
	{
		ScreenArrangementBase screen;
		SlideCue cue;
		return from kv in _dictionary
			select (!TryResolveScreen(kv.Key, out screen) || !TryResolveCue(kv.Value, out cue)) ? (screen: null, cue: null) : (screen: screen, cue: cue) into kv
			where kv.screen != null && kv.cue != null
			select new KeyValuePair<ScreenArrangementBase, SlideCue>(kv.screen, kv.cue);
	}

	private bool TryResolveCue(Identification identifier, [NotNullWhen(true)] out SlideCue? cue)
	{
		using (IEnumerator<SlideCue> enumerator = (from c in GetCues()
			where c.ID == identifier.ID && c.Name == identifier.Name
			select c).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				SlideCue current = enumerator.Current;
				cue = current;
				return true;
			}
		}
		cue = null;
		return false;
	}

	private bool TryResolveScreen(Identification identifier, [NotNullWhen(true)] out ScreenArrangementBase? screen)
	{
		using (IEnumerator<ScreenArrangementBase> enumerator = _stageScreens.Where((ScreenArrangementBase s) => s.ID == identifier.ID && s.Name == identifier.Name).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				ScreenArrangementBase current = enumerator.Current;
				screen = current;
				return true;
			}
		}
		screen = null;
		return false;
	}
}
