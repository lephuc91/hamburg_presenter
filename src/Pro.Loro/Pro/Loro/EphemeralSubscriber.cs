namespace Pro.Loro;

public interface EphemeralSubscriber
{
	void OnEphemeralEvent(EphemeralStoreEvent @event);
}
