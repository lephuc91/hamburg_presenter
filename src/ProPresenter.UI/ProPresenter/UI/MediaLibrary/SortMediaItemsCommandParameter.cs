using ProPresenter.DO.Media;

namespace ProPresenter.UI.MediaLibrary;

public class SortMediaItemsCommandParameter
{
	public VisualSortType SortType { get; }

	public bool IsAscending { get; }

	public SortMediaItemsCommandParameter(VisualSortType sortType, bool isAscending)
	{
		SortType = sortType;
		IsAscending = isAscending;
	}
}
