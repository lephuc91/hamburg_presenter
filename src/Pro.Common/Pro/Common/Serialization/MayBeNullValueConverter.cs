using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pro.Common.Serialization;

public class MayBeNullValueConverter<T> : JsonConverter<T> where T : struct
{
	public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
		{
			return default(T);
		}
		return JsonSerializer.Deserialize<T>(ref reader, options);
	}

	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}
}
