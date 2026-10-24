using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal sealed class Message : IMessage, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	private LoroMap _map;

	private CompositeDisposable _linkedDisposables;

	private GuidObservableProperty Uuid_;

	private StringObservableProperty Title_;

	private DoubleObservableProperty TimeToRemove_;

	private BoolObservableProperty VisibleOnNetwork_;

	private OptionalComplexObservableProperty<ITemplateIdentification> Template_;

	private EnumObservableProperty<IMessage.Types.ClearType> ClearType_;

	private StringObservableProperty MessageText_;

	private MapCollection<IMessage.Types.IToken> Tokens_;

	public LoroMap LoroMap => _map;

	public IObservable<Unit> WhenChangeHappens { get; }

	public IObservableProperty<Guid> Uuid => Uuid_;

	public IObservableProperty<string> Title => Title_;

	public IObservableProperty<double> TimeToRemove => TimeToRemove_;

	public IObservableProperty<bool> VisibleOnNetwork => VisibleOnNetwork_;

	public IComplexObservableProperty<ITemplateIdentification?> Template => Template_;

	public IObservableProperty<IMessage.Types.ClearType> ClearType => ClearType_;

	public IObservableProperty<string> MessageText => MessageText_;

	public IComplexCollection<IMessage.Types.IToken> Tokens => Tokens_;

	public void UpdateMap(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMap(_map);
		Title_.UpdateMap(_map);
		TimeToRemove_.UpdateMap(_map);
		VisibleOnNetwork_.UpdateMap(_map);
		Template_.UpdateMap(_map);
		ClearType_.UpdateMap(_map);
		MessageText_.UpdateMap(_map);
		Tokens_.UpdateMap(_map);
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap value)
	{
		_map = value;
		Uuid_.UpdateMapOnInternalMapUpdate(_map);
		Title_.UpdateMapOnInternalMapUpdate(_map);
		TimeToRemove_.UpdateMapOnInternalMapUpdate(_map);
		VisibleOnNetwork_.UpdateMapOnInternalMapUpdate(_map);
		Template_.UpdateMapOnInternalMapUpdate(_map);
		ClearType_.UpdateMapOnInternalMapUpdate(_map);
		MessageText_.UpdateMapOnInternalMapUpdate(_map);
		Tokens_.UpdateMapOnInternalMapUpdate(_map);
	}

	public Message()
		: this(new LoroMap())
	{
	}

	public Message(LoroMap values)
	{
		_map = values;
		Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
		Title_ = new StringObservableProperty("title__2", LoroMap);
		TimeToRemove_ = new DoubleObservableProperty("time_to_remove__3", LoroMap);
		VisibleOnNetwork_ = new BoolObservableProperty("visible_on_network__4", LoroMap);
		Template_ = new OptionalComplexObservableProperty<ITemplateIdentification>("template__6", LoroMap, new EntityFactory());
		ClearType_ = new EnumObservableProperty<IMessage.Types.ClearType>("clear_type__9", LoroMap);
		MessageText_ = new StringObservableProperty("message_text__10", LoroMap);
		Tokens_ = new MapCollection<IMessage.Types.IToken>(LoroMap, "tokens__11", new EntityFactory());
		_linkedDisposables = new CompositeDisposable();
		WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Title_.WhenChangeHappens, TimeToRemove_.WhenChangeHappens, VisibleOnNetwork_.WhenChangeHappens, Template_.WhenChangeHappens, ClearType_.WhenChangeHappens, MessageText_.WhenChangeHappens, Tokens_.WhenChangeHappens);
	}

	public void Dispose()
	{
		Uuid_.Dispose();
		Title_.Dispose();
		TimeToRemove_.Dispose();
		VisibleOnNetwork_.Dispose();
		Template_.Dispose();
		ClearType_.Dispose();
		MessageText_.Dispose();
		Tokens_.Dispose();
		LoroMap.Dispose();
		_linkedDisposables.Dispose();
	}

	public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
	{
		Uuid_.OnDiff(path, diff);
		Title_.OnDiff(path, diff);
		TimeToRemove_.OnDiff(path, diff);
		VisibleOnNetwork_.OnDiff(path, diff);
		Template_.OnDiff(path, diff);
		ClearType_.OnDiff(path, diff);
		MessageText_.OnDiff(path, diff);
		Tokens_.OnDiff(path, diff);
	}

	public void RegisterLinkedDisposable(IDisposable disposable)
	{
		_linkedDisposables.Add(disposable);
	}
}
