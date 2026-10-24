using System;
using System.Reactive;
using System.Reactive.Subjects;
using Pro.Common.Utility;
using Pro.Entity.Extensions;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class ValueObservableProperty<T> : IInternalObservableProperty<T>, IObservableProperty<T>, IDiffReceiver, IWhenChangeHappensSource, IReceiveMapUpdates, IDisposable
{
	private readonly string _key;

	private readonly Func<T, LoroValue> _serialize;

	private readonly Func<LoroValue?, T> _deserialize;

	private readonly BehaviorSubject<T> _subject;

	private bool _isDisposed;

	private LoroMap _map;

	public IObservable<Unit> WhenChangeHappens => WhenValueChanges.ToUnit();

	public IObservable<T> WhenValueChanges => _subject;

	public T Value => _subject.Value;

	public ValueObservableProperty(string key, LoroMap map, Func<LoroValue?, T> deserialize, Func<T, LoroValue> serialize)
	{
		_key = key;
		_serialize = serialize;
		_map = map;
		_deserialize = deserialize;
		_subject = new BehaviorSubject<T>(Deserialize());
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Set(T value)
	{
		_map.Insert(_key, _serialize(value).AsValueLike());
		if (!ValueEquals(value, Value))
		{
			_subject.OnNext(value);
		}
		_map.Doc()?.Commit();
	}

	public void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		if (updatedPaths.Length <= 0 && diff is Diff.Map map && map.diff.updated.ContainsKey(_key))
		{
			T val = Deserialize();
			if (!ValueEquals(val, Value))
			{
				_subject.OnNext(val);
			}
		}
	}

	public void UpdateMap(LoroMap map)
	{
		_map = map;
		T val = Deserialize();
		if (!ValueEquals(val, Value))
		{
			_subject.OnNext(val);
		}
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap map)
	{
		_map = map;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing)
			{
				_subject.Dispose();
			}
			_isDisposed = true;
		}
	}

	private T Deserialize()
	{
		return _deserialize(_map.Get(_key)?.AsValue());
	}

	public override string ToString()
	{
		T value = Value;
		return ((value != null) ? value.ToString() : null) ?? "null";
	}

	protected virtual bool ValueEquals(T a, T b)
	{
		return object.Equals(a, b);
	}
}
