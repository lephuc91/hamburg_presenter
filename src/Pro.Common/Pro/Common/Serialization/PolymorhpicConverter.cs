using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pro.Common.Nullability;
using Pro.Common.Serialization.Polymorphism;

namespace Pro.Common.Serialization;

public class PolymorhpicConverter<T> : JsonConverter<T>
{
	private static readonly Dictionary<string, Type> _typeMap;

	private static readonly string? _typeDiscriminator;

	static PolymorhpicConverter()
	{
		object[] customAttributes = typeof(T).GetCustomAttributes(inherit: false);
		CustomJsonPolymorphicAttribute customJsonPolymorphicAttribute = customAttributes.OfType<CustomJsonPolymorphicAttribute>().SingleOrDefault();
		IEnumerable<CustomJsonDerivedTypeAttribute> enumerable = customAttributes.OfType<CustomJsonDerivedTypeAttribute>();
		if ((customJsonPolymorphicAttribute?.TypeDiscriminatorPropertyName).NullableIsNullOrEmpty())
		{
			throw new Exception("The PolymorhpicConverter can only be used if a valid type discriminator is set");
		}
		foreach (CustomJsonDerivedTypeAttribute item in enumerable)
		{
			if (!typeof(T).IsAssignableFrom(item.DerivedType))
			{
				throw new Exception("Cannot convert " + item.DerivedType.Name + " to " + typeof(T).Name);
			}
		}
		_typeDiscriminator = customJsonPolymorphicAttribute.TypeDiscriminatorPropertyName;
		_typeMap = enumerable.ToDictionary((CustomJsonDerivedTypeAttribute t) => t.TypeDiscriminator, (CustomJsonDerivedTypeAttribute t) => t.DerivedType);
	}

	public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		using JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader);
		if (_typeDiscriminator == null || !jsonDocument.RootElement.TryGetProperty(_typeDiscriminator, out var value))
		{
			return default(T);
		}
		if (!_typeMap.TryGetValue(value.GetString() ?? string.Empty, out Type value2))
		{
			return default(T);
		}
		return (T)jsonDocument.Deserialize(value2);
	}

	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
	{
		string key = _typeMap.FirstOrDefault<KeyValuePair<string, Type>>((KeyValuePair<string, Type> pair) => pair.Value.IsInstanceOfType(value)).Key;
		if (value != null && _typeDiscriminator != null && !string.IsNullOrEmpty(key))
		{
			writer.WriteStartObject();
			writer.WritePropertyName(_typeDiscriminator);
			writer.WriteStringValue(key);
			PropertyInfo[] properties = value.GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				writer.WritePropertyName(propertyInfo.Name);
				JsonSerializer.Serialize(writer, propertyInfo.GetValue(value));
			}
			writer.WriteEndObject();
		}
	}
}
