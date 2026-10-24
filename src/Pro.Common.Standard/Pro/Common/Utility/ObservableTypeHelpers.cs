using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Pro.Common.Utility;

public static class ObservableTypeHelpers
{
	public static IObservable<Unit> ToUnit<T>(this IObservable<T> toConvert)
	{
		return toConvert.Select((T _) => Unit.Default);
	}
}
