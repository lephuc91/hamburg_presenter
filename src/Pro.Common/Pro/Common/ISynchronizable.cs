namespace Pro.Common;

public interface ISynchronizable<in T>
{
	void SynchronizeFrom(T source);

	void SynchronizeTo(T target);
}
