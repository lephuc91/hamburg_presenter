using System.Linq;
using Pro.UI.Utility;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.Thumbnails;

public class PropsThumbnailPanel : CustomPresentationThumbnailPanel
{
	public PropsThumbnailPanel()
	{
		base.ActiveItemPredicate = (ArrangedCue i) => base.ActiveItems?.Any((ArrangedCue a) => a.Source == i.Source) ?? false;
	}

	protected override bool IsGroupAdornerVisible(ArrangedCue slide, AdornerPosition adornerPosition)
	{
		return false;
	}
}
