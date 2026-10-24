using System;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.Resi;

public record Uploader([property: JsonPropertyName("version")] Version Version, [property: JsonPropertyName("apiVersion")] Version ApiVersion, [property: JsonPropertyName("macos")] PlatformInfo Macos, [property: JsonPropertyName("win32")] PlatformInfo Win32);
