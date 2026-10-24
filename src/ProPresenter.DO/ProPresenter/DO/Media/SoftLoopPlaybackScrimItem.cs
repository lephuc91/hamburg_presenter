namespace ProPresenter.DO.Media;

public class SoftLoopPlaybackScrimItem : IScrimSource
{
	public ScrimPosition Position => ScrimPosition.BottomRight;

	public DisplayMode DisplayMode => DisplayMode.Content;

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Content;
}
