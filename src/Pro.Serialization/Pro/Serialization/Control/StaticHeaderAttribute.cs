namespace Pro.Serialization.Control;

public class StaticHeaderAttribute : ControlAttributeBase
{
	public string Header { get; }

	public string Content { get; }

	public StaticHeaderAttribute(string header, string content)
	{
		Header = header;
		Content = content;
	}
}
