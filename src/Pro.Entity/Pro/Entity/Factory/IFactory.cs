namespace Pro.Entity.Factory;

public interface IFactory<out T>
{
	T CreateInstance();
}
