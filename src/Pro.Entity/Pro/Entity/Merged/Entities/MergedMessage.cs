using System;
using System.Reactive.Disposables;
using Pro.Entity.Collections;
using Pro.Entity.Properties;

namespace Pro.Entity.Merged.Entities;

public sealed class MergedMessage(IMessage remote, ILocalMessage local) : IMergedMessage, IMessage, IEntity, IDisposable, ILocalMessage
{
	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	public IObservableProperty<Guid> Uuid => remote.Uuid;

	public IObservableProperty<string> Title => remote.Title;

	public IObservableProperty<double> TimeToRemove => remote.TimeToRemove;

	public IObservableProperty<bool> VisibleOnNetwork => remote.VisibleOnNetwork;

	public IComplexObservableProperty<ITemplateIdentification?> Template => remote.Template;

	public IObservableProperty<IMessage.Types.ClearType> ClearType => remote.ClearType;

	public IObservableProperty<string> MessageText => remote.MessageText;

	public IComplexCollection<IMessage.Types.IToken> Tokens => remote.Tokens;

	public IComplexCollection<IMessage.Types.ITokenValue> TokenValues => local.TokenValues;

	public IMessage Remote => remote;

	public ILocalMessage Local => local;

	public void Dispose()
	{
		_disposables.Dispose();
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_disposables.Add(disposable);
	}
}
