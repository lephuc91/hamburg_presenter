using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IPresentationSlide : IEntity, IDisposable
{
	public class Types
	{
		public interface INotes : IEntity, IDisposable
		{
			IObservableProperty<byte[]?> RtfData { get; }

			IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes?> Attributes { get; }
		}

		internal sealed class Notes : INotes, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private OptionalBytesObservableProperty RtfData_;

			private OptionalComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes> Attributes_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<byte[]?> RtfData => RtfData_;

			public IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes?> Attributes => Attributes_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				RtfData_.UpdateMap(_map);
				Attributes_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				RtfData_.UpdateMapOnInternalMapUpdate(_map);
				Attributes_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Notes()
				: this(new LoroMap())
			{
			}

			public Notes(LoroMap values)
			{
				_map = values;
				RtfData_ = new OptionalBytesObservableProperty("rtf_data__1", LoroMap);
				Attributes_ = new OptionalComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes>("attributes__2", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = RtfData_.WhenChangeHappens.Merge(Attributes_.WhenChangeHappens);
			}

			public void Dispose()
			{
				RtfData_.Dispose();
				Attributes_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				RtfData_.OnDiff(path, diff);
				Attributes_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexObservableProperty<ISlide> BaseSlide { get; }

	IComplexObservableProperty<Types.INotes?> Notes { get; }

	IComplexCollection<IAlignmentGuide> TemplateGuidelines { get; }

	IObservableProperty<Url?> ChordChart { get; }

	IComplexObservableProperty<ITransition?> Transition { get; }
}
