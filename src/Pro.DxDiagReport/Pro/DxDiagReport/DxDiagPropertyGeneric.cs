namespace Pro.DxDiagReport;

public class DxDiagPropertyGeneric<T> : IDxDiagPropertyGeneric<T>
{
	private string m_name;

	private T m_value;

	public virtual T Value => m_value;

	public virtual string Name => m_name;

	public DxDiagPropertyGeneric(string name, T value)
	{
		m_name = name;
		m_value = value;
	}
}
