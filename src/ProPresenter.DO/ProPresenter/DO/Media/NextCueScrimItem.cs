using Pro.DO.Triggering;

namespace ProPresenter.DO.Media;

public class NextCueScrimItem : IScrimSource
{
	public ScrimPosition Position => ScrimPosition.BottomRight;

	public DisplayMode DisplayMode => DisplayMode.Content;

	public CompletionTargetType Type { get; }

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Content;

	public NextCueScrimItem(CompletionTargetType type)
	{
		Type = type;
	}
}
