using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IPlaylistTemplate : IEntity, IDisposable
{
	public class Types
	{
		public interface ITemplate : IEntity, IDisposable
		{
			IObservableProperty<string> Name { get; }

			IComplexCollection<IPlaylistItem> PlaylistItems { get; }
		}

		internal sealed class Template : ITemplate, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private StringObservableProperty Name_;

			private MapCollection<IPlaylistItem> PlaylistItems_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<string> Name => Name_;

			public IComplexCollection<IPlaylistItem> PlaylistItems => PlaylistItems_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Name_.UpdateMap(_map);
				PlaylistItems_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Name_.UpdateMapOnInternalMapUpdate(_map);
				PlaylistItems_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Template()
				: this(new LoroMap())
			{
			}

			public Template(LoroMap values)
			{
				_map = values;
				Name_ = new StringObservableProperty("name__1", LoroMap);
				PlaylistItems_ = new MapCollection<IPlaylistItem>(LoroMap, "playlist_items__2", new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Name_.WhenChangeHappens.Merge(PlaylistItems_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Name_.Dispose();
				PlaylistItems_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Name_.OnDiff(path, diff);
				PlaylistItems_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexCollection<Types.ITemplate> Templates { get; }
}
