using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.UI.ProContent;

public class ProContentDropParameter<T>
{
	public IProContentAssetVM Asset { get; }

	public T Target { get; }

	public int DropIndex { get; }

	public bool DropBefore { get; }

	public bool DropOutside { get; }

	public ProContentDropParameter(IProContentAssetVM asset, T target, int dropIndex = -1, bool dropBefore = false, bool dropOutside = false)
	{
		Asset = asset;
		Target = target;
		DropIndex = dropIndex;
		DropBefore = dropBefore;
		DropOutside = dropOutside;
	}
}
