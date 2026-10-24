using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IClock : IEntity, IDisposable
{
	public class Types
	{
		public interface IFormat : IEntity, IDisposable
		{
			public class Types
			{
				public enum DateFormatterStyle
				{
					None,
					Short,
					Medium,
					Long,
					Full
				}
			}

			IObservableProperty<Types.DateFormatterStyle> DateType { get; }

			IObservableProperty<Types.DateFormatterStyle> TimeFormat { get; }

			IObservableProperty<bool> MilitaryTimeEnabled { get; }
		}

		internal sealed class Format : IFormat, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private EnumObservableProperty<IFormat.Types.DateFormatterStyle> DateType_;

			private EnumObservableProperty<IFormat.Types.DateFormatterStyle> TimeFormat_;

			private BoolObservableProperty MilitaryTimeEnabled_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<IFormat.Types.DateFormatterStyle> DateType => DateType_;

			public IObservableProperty<IFormat.Types.DateFormatterStyle> TimeFormat => TimeFormat_;

			public IObservableProperty<bool> MilitaryTimeEnabled => MilitaryTimeEnabled_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				DateType_.UpdateMap(_map);
				TimeFormat_.UpdateMap(_map);
				MilitaryTimeEnabled_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				DateType_.UpdateMapOnInternalMapUpdate(_map);
				TimeFormat_.UpdateMapOnInternalMapUpdate(_map);
				MilitaryTimeEnabled_.UpdateMapOnInternalMapUpdate(_map);
			}

			public Format()
				: this(new LoroMap())
			{
			}

			public Format(LoroMap values)
			{
				_map = values;
				DateType_ = new EnumObservableProperty<IFormat.Types.DateFormatterStyle>("date_type__2", LoroMap);
				TimeFormat_ = new EnumObservableProperty<IFormat.Types.DateFormatterStyle>("time_format__3", LoroMap);
				MilitaryTimeEnabled_ = new BoolObservableProperty("military_time_enabled__4", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(DateType_.WhenChangeHappens, TimeFormat_.WhenChangeHappens, MilitaryTimeEnabled_.WhenChangeHappens);
			}

			public void Dispose()
			{
				DateType_.Dispose();
				TimeFormat_.Dispose();
				MilitaryTimeEnabled_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				DateType_.OnDiff(path, diff);
				TimeFormat_.OnDiff(path, diff);
				MilitaryTimeEnabled_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}
}
