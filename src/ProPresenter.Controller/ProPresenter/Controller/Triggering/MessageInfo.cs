using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.Triggering;

public class MessageInfo
{
	public Message Message { get; }

	public Guid PrimaryTextElement { get; }

	public MessageInfo(Message message, Guid primaryTextElement)
	{
		Message = message;
		PrimaryTextElement = primaryTextElement;
	}
}
