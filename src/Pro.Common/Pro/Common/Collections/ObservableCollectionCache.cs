using System;
using Pro.Common.Cache;

namespace Pro.Common.Collections;

internal class ObservableCollectionCache<KC, TC> : WeakKeyValueCache<KC, TC> where KC : class where TC : class
{
	private Func<KC, TC> _generator;

	public ObservableCollectionCache(Func<KC, TC> generator)
	{
		_generator = generator;
	}

	protected override TC GenerateValue(KC target)
	{
		return _generator(target);
	}
}
