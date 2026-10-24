using System;
using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.DO.ProContent.Model.Asset;

public record ProContentPackAsset(string Id, string DisplayName, Uri ThumbnailUrl, Uri? PreviewUrl, bool IsNavigable, SubscriptionType SubscriptionType, IProContentFormat[] Formats, int LoopCount, int ImageCount, int CountdownCount) : IProContentPackAsset, IProContentDownloadableAsset, IProContentAsset
{
	public ProContentAssetType Type => ProContentAssetType.Pack;
}
