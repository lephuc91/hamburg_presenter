using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Utility;

namespace Pro.Common.Cache;

public abstract class WeakKeyValueCache<K, T> : WeakKeyCache<K, T?, WeakReference<T>> where K : class where T : class
{
	protected override WeakReference<T> Pack(T? value)
	{
		return new WeakReference<T>(value);
	}

	protected override T? Unpack(WeakReference<T> packedValue)
	{
		return packedValue.GetTarget();
	}

	public override T? Get(K target)
	{
		T val = base.Get(target);
		if (val == null)
		{
			val = RecreateValue(target);
		}
		return val;
	}

	public override bool TryGet(K target, out T? value)
	{
		bool num = base.TryGet(target, out value);
		if (num && value == null)
		{
			value = RecreateValue(target);
		}
		return num;
	}

	private T? RecreateValue(K target)
	{
		T val = GenerateValue(target);
		Set(target, val);
		RemoveOrphanedKeys();
		return val;
	}

	protected override IEnumerable<KeyValuePair<WeakKey<K>, WeakReference<T>>> GetOrphanedItems(IEnumerable<KeyValuePair<WeakKey<K>, WeakReference<T>>> items)
	{
		return items.Where<KeyValuePair<WeakKey<K>, WeakReference<T>>>((KeyValuePair<WeakKey<K>, WeakReference<T>> i) => !i.Key.IsValid || !i.Value.IsValid());
	}
}
