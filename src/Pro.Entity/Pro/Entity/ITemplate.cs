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

public interface ITemplate : IEntity, IDisposable
{
	public class Types
	{
		public interface IDocument : IEntity, IDisposable
		{
			IComplexCollection<ISlide> Slides { get; }
		}

		public interface IDocumentDoc : IEntityDocument, IEntity, IDisposable, Pro.Entity.IDocument, ICanExportSnapshot, IDocument
		{
		}

		internal sealed class Document : IDocument, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private MapCollection<ISlide> Slides_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexCollection<ISlide> Slides => Slides_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Slides_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Slides_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Document()
				: this(new LoroMap())
			{
			}

			public Document(LoroMap values)
			{
				_map = values;
				Slides_ = new MapCollection<ISlide>(LoroMap, "slides__3", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Slides_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Slides_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Slides_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}

		internal sealed class DocumentDoc : EntityDocumentBase, IDocumentDoc, IEntityDocument, IEntity, IDisposable, Pro.Entity.IDocument, ICanExportSnapshot, IDocument
		{
			private readonly Document _entity;

			public IComplexCollection<ISlide> Slides => _entity.Slides;

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

		public interface ISlide : IEntity, IDisposable
		{
			IComplexObservableProperty<Pro.Entity.ISlide> BaseSlide { get; }

			IObservableProperty<string> Name { get; }

			IComplexCollection<IAction> Actions { get; }
		}

		internal sealed class Slide : ISlide, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<Pro.Entity.ISlide> BaseSlide_;

			private StringObservableProperty Name_;

			private MapCollection<IAction> Actions_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<Pro.Entity.ISlide> BaseSlide => BaseSlide_;

			public IObservableProperty<string> Name => Name_;

			public IComplexCollection<IAction> Actions => Actions_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				BaseSlide_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				Actions_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				BaseSlide_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				Actions_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Slide()
				: this(new LoroMap())
			{
			}

			public Slide(LoroMap values)
			{
				_map = values;
				BaseSlide_ = new ComplexObservableProperty<Pro.Entity.ISlide>("base_slide__1", LoroMap, new EntityFactory());
				Name_ = new StringObservableProperty("name__2", LoroMap);
				Actions_ = new MapCollection<IAction>(LoroMap, "actions__3", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(BaseSlide_.WhenChangeHappens, Name_.WhenChangeHappens, Actions_.WhenChangeHappens);
			}

			public void Dispose()
			{
				BaseSlide_.Dispose();
				Name_.Dispose();
				Actions_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				BaseSlide_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				Actions_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
