using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

public record Format([property: JsonPropertyName("id"), JsonRequired] string Id, [property: JsonPropertyName("name"), JsonRequired] string Name, [property: JsonPropertyName("width"), JsonRequired] int Width, [property: JsonPropertyName("height"), JsonRequired] int Height, [property: JsonPropertyName("framerate")] double? Framerate, [property: JsonPropertyName("interlaced")] bool? Interlaced);
