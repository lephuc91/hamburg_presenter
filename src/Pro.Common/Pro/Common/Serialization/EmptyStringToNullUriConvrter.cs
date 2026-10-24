using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pro.Common.Nullability;

namespace Pro.Common.Serialization;

public class EmptyStringToNullUriConvrter : JsonConverter<Uri>
{
	public override Uri? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		switch (reader.TokenType)
		{
		case JsonTokenType.Null:
			return null;
		case JsonTokenType.String:
		{
			string @string = reader.GetString();
			if (@string.NullableIsNullOrEmpty())
			{
				return null;
			}
			return new Uri(@string);
		}
		default:
			throw new JsonException($"Cannot convert a json token of type {reader.TokenType} to a Uri");
		}
	}

	public override void Write(Utf8JsonWriter writer, Uri value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
	}
}
