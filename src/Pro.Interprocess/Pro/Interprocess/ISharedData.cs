namespace Pro.Interprocess;

public interface ISharedData<in T>
{
	string ReadData(T key);

	void SendData(T key, string data);
}
