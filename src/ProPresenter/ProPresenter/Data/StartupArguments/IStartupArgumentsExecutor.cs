namespace ProPresenter.Data.StartupArguments;

public interface IStartupArgumentsExecutor
{
	bool ProcessArgument(string argument);

	void Send();

	void UseLocally();
}
