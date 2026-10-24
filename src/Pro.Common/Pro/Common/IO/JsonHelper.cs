using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pro.Common.IO;

public static class JsonHelper
{
	private static readonly JsonSerializerSettings DefaultJsonSettings = new JsonSerializerSettings
	{
		ContractResolver = new DefaultContractResolver
		{
			NamingStrategy = new CamelCaseNamingStrategy()
		}
	};

	public static string ToJson(this object data)
	{
		return JsonConvert.SerializeObject(data, DefaultJsonSettings);
	}

	public static T? FromJson<T>(this string value)
	{
		return JsonConvert.DeserializeObject<T>(value);
	}

	public static bool TryFromJson<T>(this string value, out T? data)
	{
		if (value == null)
		{
			data = default(T);
			return false;
		}
		bool success = true;
		JsonSerializerSettings settings = new JsonSerializerSettings
		{
			Error = errorHandler
		};
		data = JsonConvert.DeserializeObject<T>(value, settings);
		return success;
		void errorHandler(object? sender, ErrorEventArgs args)
		{
			success = false;
			args.ErrorContext.Handled = true;
		}
	}
}
