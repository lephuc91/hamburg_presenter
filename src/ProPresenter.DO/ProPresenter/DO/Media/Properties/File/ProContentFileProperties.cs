using Pro.Common.Components;
using Pro.Common.Downloads;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ProContent.Downloads;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.Media.Properties.File;

public class ProContentFileProperties : IRemoteFileProperties, ICloneable<IRemoteFileProperties>
{
	public string DownloadId { get; }

	public string? DisplayName { get; }

	public string? DownloadUrl { get; }

	public string? ThumbnailUrl { get; }

	public string? RelativePath { get; }

	public ProContentDownloadAssetType AssetType { get; }

	public ProContentFileProperties(string downloadId, string? displayName = null, string? downloadUrl = null, string? thumbnailUrl = null, string? relativePath = null, ProContentDownloadAssetType assetType = (ProContentDownloadAssetType)0)
	{
		DownloadId = downloadId;
		DisplayName = displayName;
		DownloadUrl = downloadUrl;
		ThumbnailUrl = thumbnailUrl;
		RelativePath = relativePath;
		AssetType = assetType;
	}

	public Pro.SerializationInterop.RVProtoData.FileProperties.Types.RemoteProperties Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.FileProperties.Types.RemoteProperties
		{
			Procontent = new Pro.SerializationInterop.RVProtoData.FileProperties.Types.RemoteProperties.Types.ProContent
			{
				DownloadIdentifier = DownloadId
			}
		};
	}

	public IRemoteFileProperties Clone()
	{
		return new ProContentFileProperties(DownloadId, DisplayName, DownloadUrl, ThumbnailUrl, RelativePath, AssetType);
	}

	public string GetManufacture()
	{
		return "ProContent";
	}

	public bool Matches(IDownloadItem item)
	{
		if (item is IProContentDownloadItem proContentDownloadItem)
		{
			return proContentDownloadItem.AssetIdentifier.Equals(DownloadId);
		}
		return false;
	}
}
