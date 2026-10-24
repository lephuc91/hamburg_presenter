using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IFileProperties : IEntity, IDisposable
{
	public class Types
	{
		public interface IRemoteProperties : IEntity, IDisposable
		{
			public class Types
			{
				public interface IProContent : IEntity, IDisposable
				{
					IObservableProperty<string?> DownloadIdentifier { get; }
				}

				internal sealed class ProContent : IProContent, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
				{
					private LoroMap _map;

					private CompositeDisposable _linkedDisposables;

					private OptionalStringObservableProperty DownloadIdentifier_;

					public LoroMap LoroMap => _map;

					public IObservable<Unit> WhenChangeHappens { get; }

					public IObservableProperty<string?> DownloadIdentifier => DownloadIdentifier_;

					public void UpdateMap(LoroMap value)
					{
						_map = value;
						DownloadIdentifier_.UpdateMap(_map);
					}

					public void UpdateMapOnInternalMapUpdate(LoroMap value)
					{
						_map = value;
						DownloadIdentifier_.UpdateMapOnInternalMapUpdate(_map);
					}

					public ProContent()
						: this(new LoroMap())
					{
					}

					public ProContent(LoroMap values)
					{
						_map = values;
						DownloadIdentifier_ = new OptionalStringObservableProperty("download_identifier__1", LoroMap);
						_linkedDisposables = new CompositeDisposable();
						WhenChangeHappens = Observable.Merge<Unit>(DownloadIdentifier_.WhenChangeHappens);
					}

					public void Dispose()
					{
						DownloadIdentifier_.Dispose();
						LoroMap.Dispose();
						_linkedDisposables.Dispose();
					}

					public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
					{
						DownloadIdentifier_.OnDiff(path, diff);
					}

					public void RegisterLinkedDisposable(IDisposable disposable)
					{
						_linkedDisposables.Add(disposable);
					}
				}
			}

			IComplexObservableProperty<Types.IProContent> Procontent { get; }
		}

		internal sealed class RemoteProperties : IRemoteProperties, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private ComplexObservableProperty<IRemoteProperties.Types.IProContent> Procontent_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IComplexObservableProperty<IRemoteProperties.Types.IProContent> Procontent => Procontent_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Procontent_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Procontent_.UpdateMapOnInternalMapUpdate(_map);
			}

			public RemoteProperties()
				: this(new LoroMap())
			{
			}

			public RemoteProperties(LoroMap values)
			{
				_map = values;
				Procontent_ = new ComplexObservableProperty<IRemoteProperties.Types.IProContent>("procontent__1", LoroMap, new EntityFactory());
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Procontent_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Procontent_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Procontent_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IObservableProperty<Url> LocalUrl { get; }

	IComplexObservableProperty<Types.IRemoteProperties> RemoteProperties { get; }
}
