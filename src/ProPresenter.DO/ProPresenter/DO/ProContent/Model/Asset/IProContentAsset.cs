using System;

namespace ProPresenter.DO.ProContent.Model.Asset;

public interface IProContentAsset
{
	string Id { get; }

	string DisplayName { get; }

	Uri ThumbnailUrl { get; }

	Uri? PreviewUrl { get; }

	bool IsNavigable { get; }

	ProContentAssetType Type { get; }
}
