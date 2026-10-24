namespace ProPresenter.Controller;

public interface ITriggeringFactory
{
	ITriggering Create(TriggerSource triggerSource = TriggerSource.Internal);
}
