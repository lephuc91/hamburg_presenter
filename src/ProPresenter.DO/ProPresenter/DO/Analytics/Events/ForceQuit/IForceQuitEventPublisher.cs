namespace ProPresenter.DO.Analytics.Events.ForceQuit;

public interface IForceQuitEventPublisher
{
	void ForceQuit(ForceQuitReason reason);
}
