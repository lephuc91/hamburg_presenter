using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface ITransition : IEntity, IDisposable
{
	public class Types
	{
		public interface IPreset : IEntity, IDisposable
		{
			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IComplexObservableProperty<ITransition> Transition { get; }
		}

		public interface IPresetDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPreset
		{
		}

		internal sealed class Preset : IPreset, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private ComplexObservableProperty<ITransition> Transition_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IComplexObservableProperty<ITransition> Transition => Transition_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Transition_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Transition_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Preset()
				: this(new LoroMap())
			{
			}

			public Preset(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Transition_ = new ComplexObservableProperty<ITransition>("transition__3", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Transition_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Transition_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Transition_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		internal sealed class PresetDoc : EntityDocumentBase, IPresetDoc, IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, IPreset
		{
			private readonly Preset _entity;

			public IObservableProperty<Guid> Uuid => _entity.Uuid;

			public IObservableProperty<string> Name => _entity.Name;

			public IComplexObservableProperty<ITransition> Transition => _entity.Transition;

			public PresetDoc(LoroDoc doc, ulong peerId)
				: base(doc, peerId)
			{
				_entity = new Preset(base.Doc.GetMap("root".ToLoroContainerIdLike()));
			}

			public PresetDoc(ulong peerId)
				: this(new LoroDoc(), peerId)
			{
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing)
				{
					_entity.Dispose();
				}
			}

			public override void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				_entity.OnDiff(path, diff);
			}

			public override void RegisterLinkedDisposable(IDisposable disposable)
			{
				_entity.RegisterLinkedDisposable(disposable);
			}
		}
	}

	IObservableProperty<double> Duration { get; }

	IObservableProperty<Guid?> FavoriteUuid { get; }

	IComplexObservableProperty<IEffect> Effect { get; }
}
