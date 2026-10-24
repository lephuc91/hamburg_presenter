using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pro.Common.Serialization;

public class StringIntegerConverter : JsonConverter<int>
{
	public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		switch (reader.TokenType)
		{
		case JsonTokenType.String:
		{
			string @string = reader.GetString();
			if (int.TryParse(@string, out var result))
			{
				return result;
			}
			throw new JsonException("Unable to parse \"" + @string + "\" as integer");
		}
		case JsonTokenType.Number:
			return reader.GetInt32();
		default:
			throw new JsonException($"Cannot convert a json token of type {reader.TokenType} to a number");
		}
	}

	public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToString());
	}
}
