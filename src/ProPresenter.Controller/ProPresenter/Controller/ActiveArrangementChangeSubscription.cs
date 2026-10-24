using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;

namespace ProPresenter.Controller;

public sealed class ActiveArrangementChangeSubscription : IDisposable
{
	private readonly IDisposable _subscription;

	public ActiveArrangementChangeSubscription(IDocumentCue? cue, Action onChange)
	{
		_subscription = WhenDocumentActionChanged(cue).Select(WhenActiveArrangementChanged).Switch().Select(WhenActiveArrangementArrangedCuesChanged)
			.Switch()
			.Subscribe(delegate
			{
				onChange();
			});
	}

	private static IObservable<IDocumentAction?> WhenDocumentActionChanged(IDocumentCue? cue)
	{
		if (cue != null)
		{
			return (from update in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler h)
				{
					cue.PropertyChanged += h;
				}, delegate(PropertyChangedEventHandler h)
				{
					cue.PropertyChanged -= h;
				})
				where update.EventArgs.PropertyName == "DocumentAction"
				select update into _
				select cue.DocumentAction).StartWith(cue.DocumentAction);
		}
		return Observable.Return<IDocumentAction>(null);
	}

	private static IObservable<IArrangement?> WhenActiveArrangementChanged(IDocumentAction? action)
	{
		if (action != null)
		{
			return (from update in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler h)
				{
					action.PropertyChanged += h;
				}, delegate(PropertyChangedEventHandler h)
				{
					action.PropertyChanged -= h;
				})
				where update.EventArgs.PropertyName == "ActiveArrangement"
				select update into _
				select action.ActiveArrangement).StartWith(action.ActiveArrangement);
		}
		return Observable.Return<IArrangement>(null);
	}

	private static IObservable<EventPattern<NotifyCollectionChangedEventArgs>?> WhenActiveArrangementArrangedCuesChanged(IArrangement? arrangement)
	{
		if (arrangement != null)
		{
			return Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(delegate(NotifyCollectionChangedEventHandler h)
			{
				arrangement.ArrangedCues.CollectionChanged += h;
			}, delegate(NotifyCollectionChangedEventHandler h)
			{
				arrangement.ArrangedCues.CollectionChanged -= h;
			}).StartWith(new EventPattern<NotifyCollectionChangedEventArgs>[1]);
		}
		return Observable.Return<EventPattern<NotifyCollectionChangedEventArgs>>(null);
	}

	public void Dispose()
	{
		_subscription.Dispose();
	}
}
