using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Document;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IStage : IEntity, IDisposable
{
	public class Types
	{
		public interface IDocument : IEntity, IDisposable
		{
			IComplexCollection<ILayout> Layouts { get; }
		}

		public interface IDocumentDoc : IEntityDocument, IEntity, IDisposable, Pro.Entity.IDocument, ICanExportSnapshot, IDocument
		{
		}

		internal sealed class Document : IDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<ILayout> Layouts_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<ILayout> Layouts => Layouts_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Layouts_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Layouts_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Document()
				: this(new LoroMap())
			{
			}

			public Document(LoroMap values)
			{
				_map = values;
				Layouts_ = new MapCollection<ILayout>(LoroMap, "layouts__2", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Layouts_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Layouts_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Layouts_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		internal sealed class DocumentDoc : EntityDocumentBase, IDocumentDoc, IEntityDocument, IEntity, IDisposable, Pro.Entity.IDocument, ICanExportSnapshot, IDocument
		{
			private readonly Document _entity;

			public IComplexCollection<ILayout> Layouts => _entity.Layouts;

			public DocumentDoc(LoroDoc doc, ulong peerId)
				: base(doc, peerId)
			{
				_entity = new Document(base.Doc.GetMap("root".ToLoroContainerIdLike()));
			}

			public DocumentDoc(ulong peerId)
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

		public interface ILayout : IEntity, IDisposable
		{
			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			IComplexObservableProperty<ISlide> Slide { get; }
		}

		internal sealed class Layout : ILayout, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private ComplexObservableProperty<ISlide> Slide_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public IComplexObservableProperty<ISlide> Slide => Slide_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Slide_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Slide_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Layout()
				: this(new LoroMap())
			{
			}

			public Layout(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Slide_ = new ComplexObservableProperty<ISlide>("slide__3", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, Slide_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				Slide_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Slide_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		public interface IScreenAssignment : IEntity, IDisposable
		{
			IComplexObservableProperty<ICollectionElementType> Screen { get; }

			IComplexObservableProperty<ICollectionElementType> Layout { get; }
		}

		internal sealed class ScreenAssignment : IScreenAssignment, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<ICollectionElementType> Screen_;

			private ComplexObservableProperty<ICollectionElementType> Layout_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<ICollectionElementType> Screen => Screen_;

			public IComplexObservableProperty<ICollectionElementType> Layout => Layout_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Screen_.UpdateMap(_map);
				Layout_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Screen_.UpdateMapOnInternalMapUpdate(_map);
				Layout_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ScreenAssignment()
				: this(new LoroMap())
			{
			}

			public ScreenAssignment(LoroMap values)
			{
				_map = values;
				Screen_ = new ComplexObservableProperty<ICollectionElementType>("screen__1", LoroMap, new EntityFactory());
				Layout_ = new ComplexObservableProperty<ICollectionElementType>("layout__2", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Screen_.WhenChangeHappens.Merge(Layout_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Screen_.Dispose();
				Layout_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Screen_.OnDiff(path, diff);
				Layout_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
