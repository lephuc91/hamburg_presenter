namespace ProPresenter.DO.Slide.Custom.Elements;

public class TextOverflowWarningScrimItem : IScrimSource
{
	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Content;
}
