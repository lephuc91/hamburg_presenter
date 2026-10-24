using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IMacrosDocument : IEntity, IDisposable
{
	public class Types
	{
		public interface IMacro : IEntity, IDisposable
		{
			public class Types
			{
				public enum ImageType
				{
					Default,
					One,
					Two,
					Three,
					Four,
					Five,
					Six,
					Seven,
					Eight,
					Nine,
					Zero,
					Arrow,
					Audio,
					Bell,
					Bulb,
					Cloud,
					Cupcake,
					Exclamation,
					Flask,
					Flower,
					Glasses,
					Hashtag,
					Hat,
					Heart,
					Megaphone,
					Message,
					Paperclip,
					Play,
					Slide,
					Star,
					Sun,
					Sunglasses,
					Target,
					Timer,
					VideoInput,
					XClear,
					LetterA,
					LetterB,
					LetterC,
					LetterD,
					LetterE,
					LetterF,
					LetterG,
					LetterH,
					LetterI,
					LetterJ,
					LetterK,
					LetterL,
					LetterM,
					LetterN,
					LetterO,
					LetterP,
					LetterQ,
					LetterR,
					LetterS,
					LetterT,
					LetterU,
					LetterV,
					LetterW,
					LetterX,
					LetterY,
					LetterZ,
					Custom
				}
			}

			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IObservableProperty<Color> Color { get; }

			IComplexCollection<IAction> Actions { get; }

			IObservableProperty<bool> TriggerOnStartup { get; }

			IObservableProperty<Types.ImageType> ImageType { get; }

			IObservableProperty<byte[]?> ImageData { get; }
		}

		internal sealed class Macro : IMacro, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private AtomicObservableProperty<Color> Color_;

			private MapCollection<IAction> Actions_;

			private BoolObservableProperty TriggerOnStartup_;

			private EnumObservableProperty<IMacro.Types.ImageType> ImageType_;

			private OptionalBytesObservableProperty ImageData_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IObservableProperty<Color> Color => Color_;

			public IComplexCollection<IAction> Actions => Actions_;

			public IObservableProperty<bool> TriggerOnStartup => TriggerOnStartup_;

			public IObservableProperty<IMacro.Types.ImageType> ImageType => ImageType_;

			public IObservableProperty<byte[]?> ImageData => ImageData_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Color_.UpdateMap(_map);
				Actions_.UpdateMap(_map);
				TriggerOnStartup_.UpdateMap(_map);
				ImageType_.UpdateMap(_map);
				ImageData_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Color_.UpdateMapOnInternalMapUpdate(_map);
				Actions_.UpdateMapOnInternalMapUpdate(_map);
				TriggerOnStartup_.UpdateMapOnInternalMapUpdate(_map);
				ImageType_.UpdateMapOnInternalMapUpdate(_map);
				ImageData_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Macro()
				: this(new LoroMap())
			{
			}

			public Macro(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Color_ = new AtomicObservableProperty<Color>("color__3", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				Actions_ = new MapCollection<IAction>(LoroMap, "actions__4", new EntityFactory());
				TriggerOnStartup_ = new BoolObservableProperty("trigger_on_startup__5", LoroMap);
				ImageType_ = new EnumObservableProperty<IMacro.Types.ImageType>("image_type__6", LoroMap);
				ImageData_ = new OptionalBytesObservableProperty("image_data__7", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Color_.WhenChangeHappens, Actions_.WhenChangeHappens, TriggerOnStartup_.WhenChangeHappens, ImageType_.WhenChangeHappens, ImageData_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Color_.Dispose();
				Actions_.Dispose();
				TriggerOnStartup_.Dispose();
				ImageType_.Dispose();
				ImageData_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Color_.OnDiff(path, diff);
				Actions_.OnDiff(path, diff);
				TriggerOnStartup_.OnDiff(path, diff);
				ImageType_.OnDiff(path, diff);
				ImageData_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IMacroCollection : IEntity, IDisposable
		{
			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IComplexCollection<IMacro> Macros { get; }
		}

		internal sealed class MacroCollection : IMacroCollection, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private MapCollection<IMacro> Macros_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IComplexCollection<IMacro> Macros => Macros_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Macros_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Macros_.UpdateMapOnInternalMapUpdate(_map);
			}

			public MacroCollection()
				: this(new LoroMap())
			{
			}

			public MacroCollection(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Macros_ = new MapCollection<IMacro>(LoroMap, "macros__4", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Macros_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Macros_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Macros_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexCollection<Types.IMacroCollection> MacroCollections { get; }
}
