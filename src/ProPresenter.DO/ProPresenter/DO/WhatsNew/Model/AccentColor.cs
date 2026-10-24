using System.Text.Json.Serialization;

namespace ProPresenter.DO.WhatsNew.Model;

internal record AccentColor([property: JsonPropertyName("red")] double Red, [property: JsonPropertyName("green")] double Green, [property: JsonPropertyName("blue")] double Blue, [property: JsonPropertyName("alpha")] double Alpha);
