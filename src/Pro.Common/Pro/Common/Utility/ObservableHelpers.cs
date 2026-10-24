using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Pro.Common.Collections;

namespace Pro.Common.Utility;

public static class ObservableHelpers
{
	public static IObservable<PropertyChangedEventArgs> WhenAnyPropertyChanges(this INotifyPropertyChanged propertyChangedObject)
	{
		return from x in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler x)
			{
				propertyChangedObject.PropertyChanged += x;
			}, delegate(PropertyChangedEventHandler x)
			{
				propertyChangedObject.PropertyChanged -= x;
			})
			select x.EventArgs;
	}

	public static IObservable<(T Object, PropertyChangedEventArgs ChangedArgs)> WhenAnyPropertyChanges<T>(this IObservable<T> propertyChangedObservable) where T : INotifyPropertyChanged
	{
		return propertyChangedObservable.Select((T x) => from y in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler y)
			{
				x.PropertyChanged += y;
			}, delegate(PropertyChangedEventHandler y)
			{
				x.PropertyChanged -= y;
			})
			select (x: x, EventArgs: y.EventArgs)).Switch();
	}

	public static IObservable<PropertyChangedEventArgs> WhenPropertyChanges(this IObservable<PropertyChangedEventArgs> observable, string propertyName)
	{
		return observable.Where((PropertyChangedEventArgs x) => x.PropertyName == null || x.PropertyName == propertyName);
	}

	public static IObservable<PropertyChangedEventArgs> WhenPropertyChanges(this IObservable<PropertyChangedEventArgs> observable, IReadOnlyList<string> propertyNames)
	{
		return observable.Where((PropertyChangedEventArgs x) => x.PropertyName == null || propertyNames.Contains<string>(x.PropertyName));
	}

	public static IObservable<PropertyChangedEventArgs> WhenPropertyChanges(this INotifyPropertyChanged propertyChangedObject, string propertyName)
	{
		return from x in propertyChangedObject.WhenAnyPropertyChanges()
			where x.PropertyName == null || x.PropertyName == propertyName
			select x;
	}

	public static IObservable<T> WhenPropertyChanges<T>(this IObservable<T> propertyChangedObservable, string propertyName) where T : INotifyPropertyChanged
	{
		return from x in propertyChangedObservable.WhenAnyPropertyChanges()
			where x.ChangedArgs.PropertyName == null || x.ChangedArgs.PropertyName == propertyName
			select x.Object;
	}

	public static IObservable<PropertyChangedEventArgs> WhenPropertyChanges(this INotifyPropertyChanged propertyChangedObject, IReadOnlyList<string> propertyNames)
	{
		return from x in propertyChangedObject.WhenAnyPropertyChanges()
			where x.PropertyName == null || propertyNames.Contains<string>(x.PropertyName)
			select x;
	}

	public static IObservable<INotifyCollectionChanged> WhenCollectionChanges(this INotifyCollectionChanged collection)
	{
		return from _ in Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged += x;
			}, delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged -= x;
			})
			select collection;
	}

	public static IObservable<INotifyEnumerableChanged<T>> WhenCollectionChanges<T>(this INotifyEnumerableChanged<T> collection)
	{
		return from _ in Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged += x;
			}, delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged -= x;
			})
			select collection;
	}

	public static IObservable<IImmutableObservableCollection<T>> WhenCollectionChanges<T>(this IImmutableObservableCollection<T> collection)
	{
		return from _ in Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged += x;
			}, delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged -= x;
			})
			select collection;
	}

	public static IObservable<ObservableCollection<T>> WhenCollectionChanges<T>(this ObservableCollection<T> collection)
	{
		return from _ in Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged += x;
			}, delegate(NotifyCollectionChangedEventHandler x)
			{
				collection.CollectionChanged -= x;
			})
			select collection;
	}

	public static T DisposeWith<T>(this T disposable, ICollection<IDisposable> disposables) where T : IDisposable
	{
		disposables.Add(disposable);
		return disposable;
	}
}
