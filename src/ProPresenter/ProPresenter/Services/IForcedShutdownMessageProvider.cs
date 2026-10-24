namespace ProPresenter.Services;

public interface IForcedShutdownMessageProvider
{
	public enum ShutdownReason
	{
		HostsFile,
		SystemTime,
		Watermark,
		PiratedSoftware
	}

	void ShowForcedApplicationShutdownDialog(ShutdownReason reason);
}
