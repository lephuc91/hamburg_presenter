namespace Pro.Common.Utility;

public interface IInternetAccess
{
	bool IsInternetAvailable();

	bool CheckIfInternetAvailableThenShowPrompt();
}
