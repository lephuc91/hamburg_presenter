using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Download;

public record DownloadAssets([property: JsonPropertyName("assets"), JsonRequired] FileDownload[] Assets);
