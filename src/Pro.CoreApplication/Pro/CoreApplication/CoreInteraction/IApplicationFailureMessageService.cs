namespace Pro.CoreApplication.CoreInteraction;

public interface IApplicationFailureMessageService
{
	public enum StartupUserSelection
	{
		Retry,
		Continue,
		Quit
	}

	public enum VersionMismatchUserSelection
	{
		Continue,
		Update,
		Quit
	}

	StartupUserSelection ShowMediaServiceStartupFailure(string error);

	VersionMismatchUserSelection ShowMediaServiceApiVersionMismatch();

	void ShowServiceBootstrapError();
}
