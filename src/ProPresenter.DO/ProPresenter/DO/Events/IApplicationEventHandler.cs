namespace ProPresenter.DO.Events;

public interface IApplicationEventHandler
{
	void Handle(IApplicationEvent @event);
}
