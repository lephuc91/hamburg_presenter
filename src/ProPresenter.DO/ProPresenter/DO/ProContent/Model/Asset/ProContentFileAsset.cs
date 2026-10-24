using System;
using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.DO.ProContent.Model.Asset;

public record ProContentFileAsset(string Id, string DisplayName, Uri ThumbnailUrl, Uri? PreviewUrl, bool IsNavigable, SubscriptionType SubscriptionType, IProContentFormat[] Formats) : IProContentDownloadableAsset, IProContentAsset
{
	public ProContentAssetType Type => ProContentAssetType.File;
}
