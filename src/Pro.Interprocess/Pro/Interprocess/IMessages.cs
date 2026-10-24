using System;

namespace Pro.Interprocess;

public interface IMessages<in T> where T : Enum
{
	void RegisterHandler(T message, Action handler);

	void SendMessage(T message);

	bool TryHandleMessage(int messageID);
}
