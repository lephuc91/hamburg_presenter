using System;
using System.Reactive;

namespace Pro.Entity;

internal interface IWhenChangeHappensSource
{
	IObservable<Unit> WhenChangeHappens { get; }
}
