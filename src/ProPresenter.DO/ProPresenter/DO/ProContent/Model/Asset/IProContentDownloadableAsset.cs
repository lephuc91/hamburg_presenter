using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.DO.ProContent.Model.Asset;

public interface IProContentDownloadableAsset : IProContentAsset
{
	SubscriptionType SubscriptionType { get; }

	IProContentFormat[] Formats { get; }
}
