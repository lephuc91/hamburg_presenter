namespace CoreRegistrationClient;

public interface IRegistrationInteractorCallbackReceiver
{
	void OnRegistrationCallback(byte[] data);

	void LogError(string message, params object[] @params);
}
