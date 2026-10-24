namespace Pro.Loro;

public interface IStyleConfigMap
{
	StyleConfig? Get(string key);

	void Insert(string key, StyleConfig value);
}
