namespace Pro.Entity.Properties;

internal interface IInternalObservableProperty<T> : IObservableProperty<T>, IDiffReceiver, IWhenChangeHappensSource
{
}
