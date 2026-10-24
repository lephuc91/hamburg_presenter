using System;
using System.Reactive.Linq;
using Pro.Common.Dispatcher;
using Reactive.Bindings;

namespace ProPresenter.ViewModels.DispatchingExtensions;

public static class ReactiveBindingExtensions
{
	public static ReadOnlyReactivePropertySlim<T> ToReadOnlyReactivePropertySlim<T>(this IObservable<T> observable, IUiScheduler uiScheduler) where T : struct
	{
		return observable.ObserveOn(uiScheduler.Scheduler).ToReadOnlyReactivePropertySlim();
	}

	public static ReadOnlyReactivePropertySlim<T> ToReadOnlyReactivePropertySlim<T>(this IObservable<T> observable, IUiScheduler uiScheduler, T initialValue)
	{
		return observable.ObserveOn(uiScheduler.Scheduler).ToReadOnlyReactivePropertySlim(initialValue);
	}

	public static ReadOnlyReactivePropertySlim<T> ToReadOnlyReactivePropertySlim<T>(this IObservable<T> observable, IUiScheduler uiScheduler, T initialValue, ReactivePropertyMode mode)
	{
		return observable.ObserveOn(uiScheduler.Scheduler).ToReadOnlyReactivePropertySlim(initialValue, mode);
	}
}
