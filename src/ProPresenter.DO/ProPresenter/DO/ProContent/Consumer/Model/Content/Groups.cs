using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Consumer.Model.Content;

public record Groups([property: JsonPropertyName("groups"), JsonRequired] Group[] Items);
