using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Download;

public record FileDownload([property: JsonPropertyName("display_name"), JsonRequired] string DisplayName, [property: JsonPropertyName("relative_path"), JsonRequired] string RelativePath, [property: JsonPropertyName("download_url"), JsonRequired] Uri DownloadUrl, [property: JsonPropertyName("thumbnail_url"), JsonRequired] Uri ThumbnailUrl, [property: JsonPropertyName("asset_type"), JsonRequired] AssetType AssetType, [property: JsonPropertyName("asset_identifier"), JsonRequired] string AssetIdentifier);
