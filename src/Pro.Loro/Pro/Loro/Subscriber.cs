namespace Pro.Loro;

public interface Subscriber
{
	void OnDiff(DiffEvent diff);
}
