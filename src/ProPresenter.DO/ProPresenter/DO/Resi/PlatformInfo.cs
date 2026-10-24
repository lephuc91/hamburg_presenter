using System.Text.Json.Serialization;

namespace ProPresenter.DO.Resi;

public record PlatformInfo([property: JsonPropertyName("url")] string Url, [property: JsonPropertyName("md5checksum")] string Md5checksum, [property: JsonPropertyName("minOs")] string MinOs, [property: JsonPropertyName("maxOs")] string MaxOs);
