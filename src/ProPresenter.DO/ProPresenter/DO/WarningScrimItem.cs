namespace ProPresenter.DO;

public class WarningScrimItem : IScrimSource
{
	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Content;

	public string Message { get; }

	public WarningScrimItem(string message)
	{
		Message = message;
	}
}
