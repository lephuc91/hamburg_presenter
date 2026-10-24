namespace Pro.Loro;

public interface ILoroCounter
{
	void Decrement(double value);

	LoroDoc? Doc();

	LoroCounter? GetAttached();

	double GetValue();

	ContainerId Id();

	void Increment(double value);

	bool IsAttached();

	bool IsDeleted();

	Subscription? Subscribe(Subscriber subscriber);
}
