using System;
using System.Linq;
using System.Text.Json;

namespace ProPresenter.DO.Resi;

public static class UpdateHelper
{
	public static Uploader? GetLatestUploader(string jsonData, Version apiVersion)
	{
		return (((JsonSerializer.Deserialize<DownloadResponse>(jsonData)?.Uploaders)?.GroupBy((Uploader g) => g.ApiVersion))?.FirstOrDefault((IGrouping<Version, Uploader> a) => a.Key == apiVersion)?.OrderByDescending((Uploader a) => a.Version))?.FirstOrDefault();
	}
}
