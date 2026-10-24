using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pro.Common.Serialization.Enum;

public class CustomStringEnumConverter<T> : JsonConverter<T> where T : struct, System.Enum
{
	private static readonly IDictionary<string, T> _valueMap;

	private static readonly T _defaultValue;

	private static readonly bool _hasDefaultValue;

	static CustomStringEnumConverter()
	{
		_valueMap = new Dictionary<string, T>();
		_hasDefaultValue = false;
		Type typeFromHandle = typeof(T);
		foreach (T value in System.Enum.GetValues(typeFromHandle))
		{
			string name = System.Enum.GetName(typeFromHandle, value);
			if (!string.IsNullOrEmpty(name))
			{
				object[] obj = typeFromHandle.GetField(name)?.GetCustomAttributes(inherit: false);
				JsonStringEnumValueAttribute stringValueAttribute = obj?.OfType<JsonStringEnumValueAttribute>().SingleOrDefault();
				JsonStringEnumDefaultValueAttribute defaultValueAttribute = obj?.OfType<JsonStringEnumDefaultValueAttribute>().SingleOrDefault();
				AddStringMapping(value, stringValueAttribute);
				SetDefaultValue(value, defaultValueAttribute, out _defaultValue, ref _hasDefaultValue);
			}
		}
	}

	private static void SetDefaultValue(T value, JsonStringEnumDefaultValueAttribute? defaultValueAttribute, out T defaultValue, ref bool hasDefaultValue)
	{
		if (defaultValueAttribute == null)
		{
			defaultValue = default(T);
			return;
		}
		if (hasDefaultValue)
		{
			throw new Exception("Every enumeration can only have one default value. Multiple specified for " + typeof(T).FullName + ".");
		}
		defaultValue = value;
		hasDefaultValue = true;
	}

	private static void AddStringMapping(T value, JsonStringEnumValueAttribute? stringValueAttribute)
	{
		if (stringValueAttribute != null)
		{
			_valueMap[stringValueAttribute.Value] = value;
		}
	}

	public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (_valueMap.TryGetValue(@string ?? string.Empty, out var value))
		{
			return value;
		}
		if (_hasDefaultValue)
		{
			return _defaultValue;
		}
		throw new JsonException();
	}

	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
	{
		string text = (from pair in _valueMap
			where pair.Value.Equals(value)
			select pair.Key).FirstOrDefault();
		if (text != null)
		{
			writer.WriteStringValue(text);
			return;
		}
		if (_hasDefaultValue)
		{
			string text2 = (from pair in _valueMap
				where pair.Value.Equals(_defaultValue)
				select pair.Key).FirstOrDefault();
			if (text2 != null)
			{
				writer.WriteStringValue(text2);
				return;
			}
		}
		throw new JsonException();
	}
}
