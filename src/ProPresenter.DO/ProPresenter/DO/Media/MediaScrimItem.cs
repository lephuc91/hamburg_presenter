namespace ProPresenter.DO.Media;

public class MediaScrimItem : IScrimSource
{
	public TriggerLayer TriggerLayer { get; }

	public ScrimPosition Position => ScrimPosition.BottomRight;

	public DisplayMode DisplayMode => DisplayMode.Content;

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Content;

	public MediaScrimItem(TriggerLayer triggerLayer)
	{
		TriggerLayer = triggerLayer;
	}
}
