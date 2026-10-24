using Pro.Text;

namespace ProPresenter.DO.Analytics;

public static class SelectionTypeExtensions
{
	public static SelectionType ToSelectionType(this Range[]? ranges)
	{
		if (ranges == null || !ranges.ContainsSelection())
		{
			return SelectionType.Object;
		}
		return SelectionType.Range;
	}
}
