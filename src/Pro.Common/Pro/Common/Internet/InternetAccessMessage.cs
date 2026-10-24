using Pro.Common.MessageService;

namespace Pro.Common.Internet;

public class InternetAccessMessage : IMessage
{
	public bool IsInternetAccessAvailable { get; }

	public InternetAccessMessage(bool isInternetAccessAvailable)
	{
		IsInternetAccessAvailable = isInternetAccessAvailable;
	}
}
