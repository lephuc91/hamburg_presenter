using Pro.Text;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public static class RangeSelectionTypeExtensions
{
	public static RangeSelectionType GetRangeSelectionType(this Range[]? selectionRanges, TextDocument? document)
	{
		if (selectionRanges != null && selectionRanges.Length == 1)
		{
			Range value = selectionRanges[0];
			Range? obj = document?.EntireRange;
			if (value == obj)
			{
				return RangeSelectionType.Document;
			}
		}
		return RangeSelectionType.Range;
	}
}
