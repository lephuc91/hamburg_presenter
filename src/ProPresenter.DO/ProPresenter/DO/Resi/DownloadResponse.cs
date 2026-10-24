using System.Text.Json.Serialization;

namespace ProPresenter.DO.Resi;

public record DownloadResponse([property: JsonPropertyName("uploaders")] Uploader[] Uploaders);
