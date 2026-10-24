using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IKeyMapping : IEntity, IDisposable
{
	public class Types
	{
		public interface IComputerKeyboard : IEntity, IDisposable
		{
			public class Types
			{
				public enum ModifierFlags
				{
					CommandKey,
					ShiftKey,
					OptionKey,
					ControlKey,
					FunctionKey
				}
			}

			IObservableProperty<string> KeyEquivalent { get; }

			ICollection<Types.ModifierFlags> KeyEquivalentModifierFlags { get; }
		}

		internal sealed class ComputerKeyboard : IComputerKeyboard, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty KeyEquivalent_;

			private EnumCollection<IComputerKeyboard.Types.ModifierFlags> KeyEquivalentModifierFlags_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> KeyEquivalent => KeyEquivalent_;

			public ICollection<IComputerKeyboard.Types.ModifierFlags> KeyEquivalentModifierFlags => KeyEquivalentModifierFlags_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				KeyEquivalent_.UpdateMap(_map);
				KeyEquivalentModifierFlags_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				KeyEquivalent_.UpdateMapOnInternalMapUpdate(_map);
				KeyEquivalentModifierFlags_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ComputerKeyboard()
				: this(new LoroMap())
			{
			}

			public ComputerKeyboard(LoroMap values)
			{
				_map = values;
				KeyEquivalent_ = new StringObservableProperty("key_equivalent__1", LoroMap);
				KeyEquivalentModifierFlags_ = new EnumCollection<IComputerKeyboard.Types.ModifierFlags>(LoroMap, "key_equivalent_modifier_flags__2");
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = KeyEquivalent_.WhenChangeHappens.Merge(KeyEquivalentModifierFlags_.WhenChangeHappens);
			}

			public void Dispose()
			{
				KeyEquivalent_.Dispose();
				KeyEquivalentModifierFlags_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				KeyEquivalent_.OnDiff(path, diff);
				KeyEquivalentModifierFlags_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMidiKeyboard : IEntity, IDisposable
		{
			IObservableProperty<int> Channel { get; }

			IObservableProperty<int> Pitch { get; }

			IObservableProperty<int> Velocity { get; }
		}

		internal sealed class MidiKeyboard : IMidiKeyboard, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private IntObservableProperty Channel_;

			private IntObservableProperty Pitch_;

			private IntObservableProperty Velocity_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<int> Channel => Channel_;

			public IObservableProperty<int> Pitch => Pitch_;

			public IObservableProperty<int> Velocity => Velocity_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Channel_.UpdateMap(_map);
				Pitch_.UpdateMap(_map);
				Velocity_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Channel_.UpdateMapOnInternalMapUpdate(_map);
				Pitch_.UpdateMapOnInternalMapUpdate(_map);
				Velocity_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MidiKeyboard()
				: this(new LoroMap())
			{
			}

			public MidiKeyboard(LoroMap values)
			{
				_map = values;
				Channel_ = new IntObservableProperty("channel__1", LoroMap);
				Pitch_ = new IntObservableProperty("pitch__2", LoroMap);
				Velocity_ = new IntObservableProperty("velocity__3", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Channel_.WhenChangeHappens, Pitch_.WhenChangeHappens, Velocity_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Channel_.Dispose();
				Pitch_.Dispose();
				Velocity_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Channel_.OnDiff(path, diff);
				Pitch_.OnDiff(path, diff);
				Velocity_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface ITargetIdentifier : IEntity, IDisposable
		{
			public interface IMenuItem : ITargetIdentifier, IEntity, IDisposable, IObservableProperty<string>
			{
			}

			public interface IClearGroupIdentifier : ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>
			{
			}

			public interface ICueIdentifier : ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>
			{
			}

			public interface IGroupIdentifier : ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>
			{
			}

			public interface IMacroIdentifier : ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>
			{
			}

			public interface IPropIdentifier : ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>
			{
			}

			public interface ITimerIdentifier : ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>
			{
			}

			internal class MenuItem : IMenuItem, ITargetIdentifier, IEntity, IDisposable, IObservableProperty<string>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private CompositeDisposable _linkedDisposables = new CompositeDisposable();

				private StringObservableProperty _MenuItem_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _MenuItem_.WhenChangeHappens;

				public IObservable<string> WhenValueChanges => _MenuItem_.WhenValueChanges;

				public string Value => _MenuItem_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_MenuItem_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_MenuItem_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "menu_item__100".ToLoroValueLike());
					return loroMap;
				}

				public MenuItem()
					: this(InitializeMap())
				{
				}

				public MenuItem(LoroMap values)
				{
					_map = values;
					_MenuItem_ = new StringObservableProperty("menu_item__100", LoroMap);
				}

				public void Dispose()
				{
					_MenuItem_.Dispose();
					LoroMap.Dispose();
					_linkedDisposables.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_MenuItem_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_linkedDisposables.Add(disposable);
				}

				public void Set(string value)
				{
					_MenuItem_.Set(value);
				}
			}

			internal class ClearGroupIdentifier : IClearGroupIdentifier, ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICollectionElementType> _ClearGroupIdentifier_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _ClearGroupIdentifier_.WhenChangeHappens;

				public IObservable<ICollectionElementType> WhenValueChanges => _ClearGroupIdentifier_.WhenValueChanges;

				public ICollectionElementType Value => _ClearGroupIdentifier_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_ClearGroupIdentifier_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_ClearGroupIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "clear_group_identifier__101".ToLoroValueLike());
					return loroMap;
				}

				public ClearGroupIdentifier()
					: this(InitializeMap())
				{
				}

				public ClearGroupIdentifier(LoroMap values)
				{
					_map = values;
					_ClearGroupIdentifier_ = new ComplexObservableProperty<ICollectionElementType>("clear_group_identifier__101", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_ClearGroupIdentifier_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_ClearGroupIdentifier_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_ClearGroupIdentifier_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICollectionElementType value)
				{
					_ClearGroupIdentifier_.Set(value);
				}
			}

			internal class CueIdentifier : ICueIdentifier, ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICollectionElementType> _CueIdentifier_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _CueIdentifier_.WhenChangeHappens;

				public IObservable<ICollectionElementType> WhenValueChanges => _CueIdentifier_.WhenValueChanges;

				public ICollectionElementType Value => _CueIdentifier_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_CueIdentifier_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_CueIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "cue_identifier__102".ToLoroValueLike());
					return loroMap;
				}

				public CueIdentifier()
					: this(InitializeMap())
				{
				}

				public CueIdentifier(LoroMap values)
				{
					_map = values;
					_CueIdentifier_ = new ComplexObservableProperty<ICollectionElementType>("cue_identifier__102", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_CueIdentifier_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_CueIdentifier_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_CueIdentifier_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICollectionElementType value)
				{
					_CueIdentifier_.Set(value);
				}
			}

			internal class GroupIdentifier : IGroupIdentifier, ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICollectionElementType> _GroupIdentifier_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _GroupIdentifier_.WhenChangeHappens;

				public IObservable<ICollectionElementType> WhenValueChanges => _GroupIdentifier_.WhenValueChanges;

				public ICollectionElementType Value => _GroupIdentifier_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_GroupIdentifier_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_GroupIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "group_identifier__103".ToLoroValueLike());
					return loroMap;
				}

				public GroupIdentifier()
					: this(InitializeMap())
				{
				}

				public GroupIdentifier(LoroMap values)
				{
					_map = values;
					_GroupIdentifier_ = new ComplexObservableProperty<ICollectionElementType>("group_identifier__103", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_GroupIdentifier_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_GroupIdentifier_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_GroupIdentifier_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICollectionElementType value)
				{
					_GroupIdentifier_.Set(value);
				}
			}

			internal class MacroIdentifier : IMacroIdentifier, ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICollectionElementType> _MacroIdentifier_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _MacroIdentifier_.WhenChangeHappens;

				public IObservable<ICollectionElementType> WhenValueChanges => _MacroIdentifier_.WhenValueChanges;

				public ICollectionElementType Value => _MacroIdentifier_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_MacroIdentifier_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_MacroIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "macro_identifier__104".ToLoroValueLike());
					return loroMap;
				}

				public MacroIdentifier()
					: this(InitializeMap())
				{
				}

				public MacroIdentifier(LoroMap values)
				{
					_map = values;
					_MacroIdentifier_ = new ComplexObservableProperty<ICollectionElementType>("macro_identifier__104", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_MacroIdentifier_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_MacroIdentifier_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_MacroIdentifier_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICollectionElementType value)
				{
					_MacroIdentifier_.Set(value);
				}
			}

			internal class PropIdentifier : IPropIdentifier, ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICollectionElementType> _PropIdentifier_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _PropIdentifier_.WhenChangeHappens;

				public IObservable<ICollectionElementType> WhenValueChanges => _PropIdentifier_.WhenValueChanges;

				public ICollectionElementType Value => _PropIdentifier_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_PropIdentifier_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_PropIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "prop_identifier__105".ToLoroValueLike());
					return loroMap;
				}

				public PropIdentifier()
					: this(InitializeMap())
				{
				}

				public PropIdentifier(LoroMap values)
				{
					_map = values;
					_PropIdentifier_ = new ComplexObservableProperty<ICollectionElementType>("prop_identifier__105", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_PropIdentifier_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_PropIdentifier_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_PropIdentifier_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICollectionElementType value)
				{
					_PropIdentifier_.Set(value);
				}
			}

			internal class TimerIdentifier : ITimerIdentifier, ITargetIdentifier, IEntity, IDisposable, IObservableProperty<ICollectionElementType>, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
			{
				private LoroMap _map;

				private ComplexObservableProperty<ICollectionElementType> _TimerIdentifier_;

				public LoroMap LoroMap => _map;

				public IObservable<Unit> WhenChangeHappens => _TimerIdentifier_.WhenChangeHappens;

				public IObservable<ICollectionElementType> WhenValueChanges => _TimerIdentifier_.WhenValueChanges;

				public ICollectionElementType Value => _TimerIdentifier_.Value;

				public void UpdateMap(LoroMap value)
				{
					_map = value;
					_TimerIdentifier_.UpdateMap(_map);
				}

				public void UpdateMapOnInternalMapUpdate(LoroMap value)
				{
					_map = value;
					_TimerIdentifier_.UpdateMapOnInternalMapUpdate(_map);
				}

				private static LoroMap InitializeMap()
				{
					LoroMap loroMap = new LoroMap();
					loroMap.Insert("__tag", "timer_identifier__106".ToLoroValueLike());
					return loroMap;
				}

				public TimerIdentifier()
					: this(InitializeMap())
				{
				}

				public TimerIdentifier(LoroMap values)
				{
					_map = values;
					_TimerIdentifier_ = new ComplexObservableProperty<ICollectionElementType>("timer_identifier__106", LoroMap, new EntityFactory());
				}

				public void Dispose()
				{
					_TimerIdentifier_.Dispose();
					LoroMap.Dispose();
				}

				public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
				{
					_TimerIdentifier_.OnDiff(path, diff);
				}

				public void RegisterLinkedDisposable(IDisposable disposable)
				{
					_TimerIdentifier_.Value.RegisterLinkedDisposable(disposable);
				}

				public void Set(ICollectionElementType value)
				{
					_TimerIdentifier_.Set(value);
				}
			}
		}

		internal class TargetIdentifierFactory : IUnionValueFactory<ITargetIdentifier>
		{
			public string SelectionKey => "__tag";

			public ITargetIdentifier? CreateInstance(LoroMap map)
			{
				return map.Get("__tag").ToStringValue() switch
				{
					"menu_item__100" => new ITargetIdentifier.MenuItem(map), 
					"clear_group_identifier__101" => new ITargetIdentifier.ClearGroupIdentifier(map), 
					"cue_identifier__102" => new ITargetIdentifier.CueIdentifier(map), 
					"group_identifier__103" => new ITargetIdentifier.GroupIdentifier(map), 
					"macro_identifier__104" => new ITargetIdentifier.MacroIdentifier(map), 
					"prop_identifier__105" => new ITargetIdentifier.PropIdentifier(map), 
					"timer_identifier__106" => new ITargetIdentifier.TimerIdentifier(map), 
					_ => null, 
				};
			}

			public ITargetIdentifier CreateDefault(LoroMap map)
			{
				map.Insert("__tag", "menu_item__100".ToLoroValueLike());
				return new ITargetIdentifier.MenuItem(map);
			}
		}
	}

	IComplexObservableProperty<Types.IComputerKeyboard> Keyboard { get; }

	IComplexObservableProperty<Types.IMidiKeyboard> Midi { get; }

	IComplexObservableProperty<Types.ITargetIdentifier> TargetIdentifier { get; }
}
