using System;
using System.Collections.Concurrent;
using Pro.Common.Collections;

namespace Pro.Common.MessageService;

public class MessageService : IMessageService
{
	private readonly ConcurrentDictionary<Type, ConcurrentBag<Action<IMessage>>> _subscribers;

	public MessageService()
	{
		_subscribers = new ConcurrentDictionary<Type, ConcurrentBag<Action<IMessage>>>();
	}

	public void SubscribeToMessage<T>(Action<IMessage> callback) where T : IMessage
	{
		_subscribers.AddOrUpdate(typeof(T), (Type key) => new ConcurrentBag<Action<IMessage>> { callback }, delegate(Type key, ConcurrentBag<Action<IMessage>> value)
		{
			value.Add(callback);
			return value;
		});
	}

	public void PublishMessage(IMessage message)
	{
		if (_subscribers.TryGetValue(message.GetType(), out ConcurrentBag<Action<IMessage>> value))
		{
			value.ForEach(delegate(Action<IMessage> callback)
			{
				callback(message);
			});
		}
	}
}
