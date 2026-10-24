using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProPresenter.DO.ProContent.Model.Format;

public record ProContentFormat([property: JsonPropertyName("id")] string Id, [property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("width")] int Width, [property: JsonPropertyName("height")] int Height, [property: JsonPropertyName("framerate")] double? Framerate = null, [property: JsonPropertyName("interlaced")] bool? Interlaced = null) : IProContentFormat
{
	public static explicit operator ProContentFormat?(string? value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return JsonSerializer.Deserialize<ProContentFormat>(value);
		}
		return null;
	}

	public override string ToString()
	{
		return JsonSerializer.Serialize(this, new JsonSerializerOptions
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
		});
	}
}
