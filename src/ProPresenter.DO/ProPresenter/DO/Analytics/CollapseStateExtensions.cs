namespace ProPresenter.DO.Analytics;

public static class CollapseStateExtensions
{
	public static CollapseState ToCollapseState(this bool isExpanded)
	{
		if (!isExpanded)
		{
			return CollapseState.Collapsed;
		}
		return CollapseState.Expanded;
	}
}
