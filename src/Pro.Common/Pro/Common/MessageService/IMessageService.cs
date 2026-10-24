using System;

namespace Pro.Common.MessageService;

public interface IMessageService
{
	void SubscribeToMessage<T>(Action<IMessage> callback) where T : IMessage;

	void PublishMessage(IMessage message);
}
