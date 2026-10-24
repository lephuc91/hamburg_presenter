using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

public record Group([property: JsonPropertyName("id"), JsonRequired] string Id, [property: JsonPropertyName("display_name"), JsonRequired] string DisplayName, [property: JsonPropertyName("icon"), JsonRequired] string Icon, [property: JsonPropertyName("collections"), JsonRequired] Collection[] Collections);
