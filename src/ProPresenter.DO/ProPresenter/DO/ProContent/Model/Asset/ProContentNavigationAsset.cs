using System;

namespace ProPresenter.DO.ProContent.Model.Asset;

public record ProContentNavigationAsset(string Id, string DisplayName, Uri ThumbnailUrl, Uri? PreviewUrl) : IProContentAsset
{
	public bool IsNavigable => true;

	public ProContentAssetType Type => ProContentAssetType.Navigation;
}
