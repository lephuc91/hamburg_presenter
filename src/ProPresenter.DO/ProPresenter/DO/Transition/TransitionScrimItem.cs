using Pro.DO.Transitions;

namespace ProPresenter.DO.Transition;

public class TransitionScrimItem : IScrimSource
{
	public ScrimPosition Position => ScrimPosition.BottomRight;

	public DisplayMode DisplayMode
	{
		get
		{
			if (!IsMediaTransition)
			{
				return DisplayMode.Label;
			}
			return DisplayMode.Content;
		}
	}

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Preview;

	public TransitionParameters TransitionParameters { get; }

	public bool IsMediaTransition { get; }

	public TransitionScrimItem(TransitionParameters transitionParameters, bool isMediaTransition = false)
	{
		TransitionParameters = transitionParameters;
		IsMediaTransition = isMediaTransition;
	}
}
