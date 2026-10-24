using ProPresenter.DO;

namespace ProPresenter.Data.Messages;

public interface IMessageHandler
{
	AppMessages HandledMessage { get; }

	void Handle();
}
